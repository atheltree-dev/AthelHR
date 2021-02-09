$(document).ready(function () {

    
    FillGeneralCobmboSelectAll('selCompany', "Company_Id", "Company_NameEn", "Hr_Companies", "");
 
    if  (getCookie("UserNameCookie")!=null)
    {
        
        $('#txtUserName').val(getCookie("UserNameCookie"));   
    }
    if  (getCookie("PasswordCookie")!=null)
    {
        $('#txtPassword').val(getCookie("PasswordCookie"));   
    }
    if (getCookie("LangCookie") != null)
    {
      
        $("#chkLangEn").prop("checked", getCookie("LangCookie") == "EN");
        $("#chkLangAr").prop("checked", getCookie("LangCookie") == "Ar");

    }

});

var varGLang;
function FillBranch() 
{
   
    if ($('#selCompany').val() != "")
    {
    FillGeneralCobmboSelectAll('selBranch', "Branch_Id", "Branch_NameEn", "Hr_Branches", " Company_Id ='" + $('#selCompany').val() + "' ");
    }
}
function CheckValidedInputData() {

    if (validData())
    {
        var IsValidUser;
        debugger;
        IsValidUser= CheckUserAuthority($('#txtUserName').val(), $('#txtPassword').val(),$('#selCompany').val(),$('#selBranch').val());
        if (IsValidUser)
        {
            var restult = SetBranchAndCompanyName();
            if (restult)
            {
                gotoApp();
            }

        }
        else
        {
            bootbox.alert("The data don't match");
            $('#txtUserName').focus();
            
        }

    }

    else
    {
        bootbox.alert('Please Enter All The Required Data');
    }



}



function SetBranchAndCompanyName()
{
    var strCompanyName = $('#selCompany option:selected').text();
    var strBranchName = $('#selBranch option:selected').text();
    var varstrLang;
    if ($("#chkLangEn").prop("checked"))
    {
        varstrLang = "EN";
    } else
    {
        varstrLang = "Ar";
    }
   
    varGLang = varstrLang;
    
    debugger;
    var DTO = { 'strCompanyName': strCompanyName, 'strBranchName': strBranchName, 'strLang': varstrLang };
    debugger;
    var result;
    $.ajax({
        type: "POST",
        url: $(location).attr('href') + "/SetBranchAndCompanyName",
        data: JSON.stringify(DTO),
        contentType: "application/json",
        dataType: "json",
        async: false,
        success: function (data) {
            result = data.d;
        }

    });
    return result;
}


function validData() {
    var Result = true;
    // txtUserName,txtPassword,selCompany,selBranch
    debugger;
    if ($('#txtUserName').val() == "" || $('#txtPassword').val() == "" || $('#selCompany').val() == "" || $('#selBranch').val() == "")
    {
        Result = false;
    }
    return Result;
}


function CheckUserAuthority(strLoginName, strPassword, strCompanyId, strBranchNo)
{
    var berardata
    if (accessToken == '') {
        GetNewToken(strLoginName, strPassword);
        berardata = accessToken;
    }

    var DTO = { 'LoginName': strLoginName, 'Password': strPassword, 'CompanyId': strCompanyId, 'BranchNo': strBranchNo };
    debugger;
        var result;
        $.ajax({
            type: "POST",
            url: $(location).attr('href') + "/SelectByNameAndPassword",
            data: JSON.stringify(DTO),
            contentType: "application/json",
            dataType: "json",
            async: false,
            success: function (data) {
                result = data.d;
            }
            ,
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + berardata)
            }

        });
        return result;
    }



function gotoApp() {
    debugger;
    if ($('#ChkRememberMe').is(':checked')) {
        debugger;
        //alert('True');
        setCookie("UserNameCookie", $('#txtUserName').val().trim(), 15);
        setCookie("PasswordCookie", $('#txtPassword').val().trim(), 15);
        setCookie("LangCookie", varGLang, 15);
        
    } else
    {
        setCookie("UserNameCookie", $('#txtUserName').val().trim(), -1);
        setCookie("PasswordCookie", $('#txtPassword').val().trim(), -1);
        setCookie("LangCookie", varGLang, 15);

    }

    window.location.replace("indexEn.aspx");
    
}
function funTestSign()
{
    
    var berardata = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJuYW1laWQiOiI1NDFmY2M2ZS03ZDhmLTQ5NmYtOTIzYi00MzEyNDdmZDE5NDYiLCJ1bmlxdWVfbmFtZSI6IkFobWVkcjIzMDQiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL2FjY2Vzc2NvbnRyb2xzZXJ2aWNlLzIwMTAvMDcvY2xhaW1zL2lkZW50aXR5cHJvdmlkZXIiOiJBU1AuTkVUIElkZW50aXR5IiwiQXNwTmV0LklkZW50aXR5LlNlY3VyaXR5U3RhbXAiOiIxZjc1YWIzYy1mYWIwLTRjZDQtOTUwZS02NTIyMjg5MWFlNTQiLCJyb2xlIjpbIkFkbWluIiwiU3VwZXJBZG1pbiJdLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjEwMjQiLCJhdWQiOiI0MTRlMTkyN2EzODg0ZjY4YWJjNzlmNzI4MzgzN2ZkMSIsImV4cCI6MTQ5MjM0MDQwMywibmJmIjoxNDkyMjU0MDAzfQ.yGcNVpeV6bAVywIVzlAXZZm3GP6eLhxgPn_357Q13ss"
   // var DTO = { 'LoginName': strLoginName, 'Password': strPassword, 'CompanyId': strCompanyId, 'BranchNo': strBranchNo };
    debugger;
    var result;
    $.ajax({
        type: "POST",
        url: document.location.origin + "/api/accounts/users",
        data: '',
        contentType: "application/json",
        dataType: "json",
        async: false,
        success: function (data)
        {
            
            
            /// this is correct return data alert(data[0].["fullName"]);
            alert(data[0].fullName);
           /// alert(data[0].claims);
           
        },
        error: function (error) {

            jsonValue = jQuery.parseJSON(error.responseText);
            alert("error" + error.responseText);
        },
        beforeSend: function(xhr) {
            xhr.setRequestHeader('Authorization', 'Bearer ' + berardata)
        },
        Accept: "application/json",

    });
    return result;
}
   
function createUser()
{
    //var createUserModel = {};
    //createUserModel.Username="Ahmedr2304";
    //createUserModel.Email="arm@pharma.com.sa";
    //createUserModel.FirstName="Ahmed";
    //createUserModel.LastName = "Ramadan";
    //createUserModel.Level = 3;
    //createUserModel.Company_Id="005";
    //createUserModel.Branch_Id="1";
    //createUserModel.Emp_Serial_No=45;
    //createUserModel.JoinDate = '';
    //createUserModel.Password = "Admin@123";

    var createUserModel = 
        {
    Username : "Mohamed2304",
    Email : "msh@pharma.com.sa",
    FirstName : "Mohamed",
    LastName : "Sheshtaway",
    Level :3,
    Company_Id : "005",
    Branch_Id : "1",
    Emp_Serial_No : 44,
    JoinDate : '',
    Password: "Admin@123",
    ConfirmPassword: "Admin@123"
};

    var DTO = { 'createUserModel': createUserModel };
    debugger;
    var result;
    $.ajax({
        type: "POST",
        url: document.location.origin + "/api/accounts/create",
        data: JSON.stringify(createUserModel),
        contentType: "application/json",
        dataType: "json",
        async: false,
        success: function (data) {

            debugger;
            /// this is correct return data alert(data[0].["fullName"]);
            alert(data.UserName);
            /// alert(data[0].claims);

        },
        error: function (error) {

            jsonValue = jQuery.parseJSON(error.responseText);
            alert("error" + error.responseText);
        }

    });
    return result;
   
}

function testSeclectUsername()
{

    IsValidUser = CheckUserAuthority($('#txtUserName').val(), $('#txtPassword').val(), $('#selCompany').val(), $('#selBranch').val());
}

function TestUser() {
    //var createUserModel = {};
    //createUserModel.Username="Ahmedr2304";
    //createUserModel.Email="arm@pharma.com.sa";
    //createUserModel.FirstName="Ahmed";
    //createUserModel.LastName = "Ramadan";
    //createUserModel.Level = 3;
    //createUserModel.Company_Id="005";
    //createUserModel.Branch_Id="1";
    //createUserModel.Emp_Serial_No=45;
    //createUserModel.JoinDate = '';
    //createUserModel.Password = "Admin@123";



    var createUserModel =
        {
            LoginName: "Ahmedr2304",
            Password: "Admin@123",
            CompanyId: "005",
            BranchNo: "1"
            
        };

    //  getToken(createUserModel.LoginName, createUserModel.Password);
    var berardata
    if (accessToken == '')
    {
        GetNewToken(createUserModel.LoginName, createUserModel.Password);
        berardata = accessToken;
    }
     
   
    var DTO = { 'createUserModel': createUserModel };
    debugger;
    var result;
    $.ajax({
        type: "POST",
        url: $(location).attr('href') + "/SelectByNameAndPassword",
        data: JSON.stringify(createUserModel),
        contentType: "application/json",
        dataType: "json",
        async: false,
        success: function (data) {

            debugger;
            /// this is correct return data alert(data[0].["fullName"]);
            alert(data);
            /// alert(data[0].claims);

        },
        error: function (error) {

            jsonValue = jQuery.parseJSON(error.responseText);
            alert("error" + error.responseText);
        },
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Accept", "application/vvv.website+json;version=1");
            xhr.setRequestHeader('Authorization', 'Bearer ' + berardata)
        },
        Accept: "application/json",

    });

    ////$.ajaxSetup({
    ////    beforeSend: function (xhr) {
    ////        xhr.setRequestHeader("Accept", "application/vvv.website+json;version=1");
    ////        xhr.setRequestHeader("Authorization", 'Bearer ' + berardata);
    ////    }
    //});


    return result;


    
}

//var emphasTask;

//function CheckExistAnyTask()
//{
//       var strCompanyName = $('#selCompany option:selected').text();
//       var strBranchName = $('#selBranch option:selected').text();

//        debugger;
//        var DTO = { 'strCompanyName': strCompanyName, 'strBranchName': strBranchName };
//        debugger;
//        var result;
//        $.ajax({
//            type: "POST",
//            url: $(location).attr('href') + "/SetBranchAndCompanyName",
//            data: JSON.stringify(DTO),
//            contentType: "application/json",
//            dataType: "json",
//            async: false,
//            success: function (data) {
//                result = data.d;
//            }

//        });
//        return result;

//}