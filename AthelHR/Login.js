$(document).ready(function () {

    setInterval(function () {
        location.reload();
    }, 18 * 60000)
    
   // FillGeneralCobmboSelectAll('selCompany', "Company_Id", "Company_NameEn", "Hr_Companies", "");
    // FillGeneralCobmboSelectAll('selBranch', "Branch_Id", "Branch_NameEn", "Hr_Branches", "");

    GetLogo();

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
      
        $("#chkLangEn").prop("checked", getCookie("LangCookie") == "en");
        $("#chkLangAr").prop("checked", getCookie("LangCookie") == "ar");

    }
    $("#Submit-btn").click(function () { forgetPassword() });
    GetMultiCompanies();

});

var varGLang;
function FillBranch() 
{
   
    if ($('#selCompany').val() != "")
    {
    FillGeneralCobmboSelectAll('selBranch', "Branch_Id", "Branch_NameEn", "Hr_Branches", " Company_Id ='" + $('#selCompany').val() + "' ");
    }
}
function disableScreen() {
    // creates <div class="overlay"></div> and 
    // adds it to the DOM
    //var Overlay = document.createElement("div");
    //Overlay.className += "overlay";
    //document.body.appendChild(Overlay);
    $('#overlay').css('display', 'flex');
    $('#Loader').css('display','flex');

    //$.LoadingOverlay("show");

   
}
function enableScreen()
{
    debugger;
    $('#overlay').css('display', 'none');
   $('#Loader').css('display','none');
}


function LOAD() {
    $('body').addClass('loading-ok');
}

function UNLOAD() {
    $('body').removeClass('loading-ok');
}



  function CheckValidedInputData() {
    debugger;
    disableScreen();
    //LOAD();

    if (validData())
    {
        var ObjCompanyAndBranch;
        debugger;
        //IsValidUser = CheckUserAuthority_Old($('#txtUserName').val(), $('#txtPassword').val(), $('#selCompany').val(), $('#selBranch').val());
       // var UserName = GetUserNameByMailOrName($('#txtUserName').val());
        GetUserNameByMailOrName($('#txtUserName').val());

        //$.when(GetUserNameByMailOrName($('#txtUserName').val())).done(function (response) {
        //    UserName = response;
        //});
       // GetUserNameByMailOrName($('#txtUserName').val());
        debugger;
        //if (UserName != "" && UserName != null && UserName != undefined) {

        //    ObjCompanyAndBranch = CheckUserAuthority(UserName, $('#txtPassword').val());

        //    if (ObjCompanyAndBranch != null) {
        //        debugger;
        //        var restult = SetBranchAndCompanyName(ObjCompanyAndBranch.company_Id, ObjCompanyAndBranch.branch_Id);

        //        //  setTimeout(UNLOAD, 5000); 
        //        setTimeout(enableScreen, 3000);

        //        if (restult) {

        //            gotoApp();
        //        }

        //    }
        //    else {
        //        // setTimeout(UNLOAD, 5000); 
        //        setTimeout(enableScreen, 2000);

        //        bootbox.alert("Please Ensure The User Name and password and confirm your email");
        //        $('#txtUserName').focus();

        //    }

        //}
        //else {
        //    // setTimeout(UNLOAD, 5000); 
        //    setTimeout(enableScreen, 2000);

        //    bootbox.alert("please ensure your username or your email ");
        //    $('#txtUserName').focus();
        //}

      
    }

    else
    {
       // setTimeout(enableScreen, 2000); 
        enableScreen();

       // bootbox.alert('Please Enter All The Required Data');
        $('#txtUserName').focus();
    }



}
  function test(UserName) {
      debugger;
      if (UserName != "" && UserName != null && UserName != undefined) {

          ObjCompanyAndBranch = CheckUserAuthority(UserName, $('#txtPassword').val());

          if (ObjCompanyAndBranch != null) {
              debugger;
              var restult = SetBranchAndCompanyName(ObjCompanyAndBranch.company_Id, ObjCompanyAndBranch.branch_Id);

              //  setTimeout(UNLOAD, 5000); 
             // setTimeout(enableScreen, 3000);
              if (restult) {
                  enableScreen();

                  gotoApp();
              }

          }
          else {
              // setTimeout(UNLOAD, 5000); 
             // setTimeout(enableScreen, 2000);
              enableScreen();
              bootbox.alert("Please Ensure The User Name and password and confirm your email");
              $('#txtUserName').focus();

          }

      }
      else {
          // setTimeout(UNLOAD, 5000); 
         // setTimeout(enableScreen, 2000);
          enableScreen();
          bootbox.alert("please ensure your username or your email ");
          $('#txtUserName').focus();
      }
  }

 function GetUserNameByMailOrName(txtusername)
{
   // disableScreen();
    var result = ""
    debugger;
    var DTO = { 'varusername': txtusername};
    debugger;
    var result;
    $.ajax({
        type: "POST",
        url: $(location).attr('href') + "/GetUserNameByMailOrName",
        data: JSON.stringify(DTO),
        contentType: "application/json",
        dataType: "json",
        //beforeSend: function () { disableScreen(); },
        async: true,
        success: function (data) {
            debugger;
            test(data.d)
           // result = data.d;

        },

        //error: function (xhr, status, error) {
        //    debugger;
        //    if (xhr.status === 401)
        //        location.reload();
        //}

    });
  
  
    
}

function CheckUserAuthority(strLoginName, strPassword)
{
    debugger;
    var berardata
    if (accessToken == '')
    {
        debugger;
        GetNewToken(strLoginName, strPassword);
        berardata = accessToken;
       // berardata = 'eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJuYW1laWQiOiI1NDFmY2M2ZS03ZDhmLTQ5NmYtOTIzYi00MzEyNDdmZDE5NDYiLCJ1bmlxdWVfbmFtZSI6IkFobWVkcjIzMDQiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL2FjY2Vzc2NvbnRyb2xzZXJ2aWNlLzIwMTAvMDcvY2xhaW1zL2lkZW50aXR5cHJvdmlkZXIiOiJBU1AuTkVUIElkZW50aXR5IiwiQXNwTmV0LklkZW50aXR5LlNlY3VyaXR5U3RhbXAiOiIxZjc1YWIzYy1mYWIwLTRjZDQtOTUwZS02NTIyMjg5MWFlNTQiLCJyb2xlIjpbIkFkbWluIiwiU3VwZXJBZG1pbiJdLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjEwMjQiLCJhdWQiOiI0MTRlMTkyN2EzODg0ZjY4YWJjNzlmNzI4MzgzN2ZkMSIsImV4cCI6MTQ5MjM0MDQwMywibmJmIjoxNDkyMjU0MDAzfQ.yGcNVpeV6bAVywIVzlAXZZm3GP6eLhxgPn_357Q13ss';
    } else {
        debugger;
        berardata = accessToken;
    }

    if (berardata != '')
    {
        debugger;
        var result;
        $.ajax({
            type: "POST",
            url: document.location.origin + "/api/accounts/GetUserByName?username=" + strLoginName + "",
            data: '',
            contentType: "application/json",
            dataType: "json",
            async: false,
            success: function (data) {
                if (data != null) {
                    debugger;
                    setUserData(data);
                    result = data;
                } else {
                    bootbox.alert('Please ensure from the user name and password');
                }
            },
            error: function (error) {
                result = null;
                jsonValue = jQuery.parseJSON(error.responseText);
                bootbox.alert("error" + error.responseText);
            },
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Accept", "application/vvv.website+json;version=1");
                xhr.setRequestHeader('Authorization', 'Bearer ' + berardata)
            },
            Accept: "application/json",

        });

    } else
    {
        result = null;
       // bootbox.alert('Please ensure from the user name and password and confirm your email');

    }
    return result;
}

function SetBranchAndCompanyName(Company_Id, Branch_Id) {

    ////FillGeneralCobmboSelectAll('selCompany', "Company_Id", "Company_Name" , "Hr_Companies", "");
    ////FillGeneralCobmboSelectAll('selBranch', "Branch_Id",  "Branch_Name" , "Hr_Branches", "");

    //var strCompanyName = "";// $('#selCompany option[value="' + (Company_Id == "" ? -1 : Company_Id) + '"]').text();
    //var strBranchName = "";// $('#selBranch option[value="' + (Branch_Id == "" ? -1 : Branch_Id) + '"]').text();
    //$('#selCompany').html("");
    //$('#selBranch').html("");
    ////FillGeneralCobmboSelectAll('selCompany', "Company_Id","Company_NameEn", "Hr_Companies", "");
    ////FillGeneralCobmboSelectAll('selBranch', "Branch_Id", "Branch_NameEn", "Hr_Branches", "");

    //var strCompanyNameEN = "";// $('#selCompany option[value="' + (Company_Id == "" ? -1 : Company_Id) + '"]').text();
    //var strBranchNameEN = "";// $('#selBranch option[value="' + (Branch_Id == "" ? -1 : Branch_Id) + '"]').text();
    var strCompanyNameEN = "";
    var strBranchNameEN = "";
    var strCompanyName = "";
    var strBranchName = "";
    debugger;
    var DTO = { 'Company_Id': Company_Id, 'Branch_Id': Branch_Id };
    debugger;
    var result;
    var res;
    $.ajax({
        type: "POST",
        url: $(location).attr('href') + "/GetBranchAndCompanyName",
        data: JSON.stringify(DTO),
        contentType: "application/json",
        dataType: "json",
        async: false,
        success: function (data) {
            result = data.d;
            $.each(result, function (i, l) {
                debugger;
                strCompanyNameEN = result[i].Company_NameEn;
                strBranchNameEN = result[i].Branch_NameEn;
                strCompanyName = result[i].Company_Name;
                strBranchName = result[i].Branch_Name
            });


            var varstrLang;
            debugger;
            if ($("#chkLangEn").prop("checked")) {
                varstrLang = "en";
            } else {
                varstrLang = "ar";
            }

            varGLang = varstrLang;

            debugger;
            var DTO1 = { 'strCompanyName': strCompanyName, 'strBranchName': strBranchName, 'strCompanyNameEN': strCompanyNameEN, 'strBranchNameEN': strBranchNameEN, 'strLang': varstrLang };
            debugger;
            var result;
            $.ajax({
                type: "POST",
                url: $(location).attr('href') + "/SetBranchAndCompanyName",
                data: JSON.stringify(DTO1),
                contentType: "application/json",
                dataType: "json",
                async: false,
                success: function (data) {
                    res = data.d;
                 
                }


            });
            return res;
       
        }, 
        //complete: function () {
        //    enableScreen();
        //}
    });
    return res;
    //  return result;
}


//function SetBranchAndCompanyName(Company_Id, Branch_Id) {

//    FillGeneralCobmboSelectAll('selCompany', "Company_Id", "Company_Name", "Hr_Companies", "");
//    FillGeneralCobmboSelectAll('selBranch', "Branch_Id", "Branch_Name", "Hr_Branches", "");



//    var strCompanyName = $('#selCompany option[value="' + (Company_Id == "" ? -1 : Company_Id) + '"]').text();
//    var strBranchName = $('#selBranch option[value="' + (Branch_Id == "" ? -1 : Branch_Id) + '"]').text();

//    FillGeneralCobmboSelectAll('selCompany', "Company_Id", "Company_NameEn", "Hr_Companies", "");
//    FillGeneralCobmboSelectAll('selBranch', "Branch_Id", "Branch_NameEn", "Hr_Branches", "");

//    var strCompanyNameEN = $('#selCompany option[value="' + (Company_Id == "" ? -1 : Company_Id) + '"]').text();
//    var strBranchNameEN = $('#selBranch option[value="' + (Branch_Id == "" ? -1 : Branch_Id) + '"]').text();


//    var varstrLang;
//    debugger;
//    if ($("#chkLangEn").prop("checked")) {
//        varstrLang = "en";
//    } else {
//        varstrLang = "ar";
//    }

//    varGLang = varstrLang;

//    debugger;
//    var DTO = { 'strCompanyName': strCompanyName, 'strBranchName': strBranchName, 'strCompanyNameEN': strCompanyNameEN, 'strBranchNameEN': strBranchNameEN, 'strLang': varstrLang };
//    debugger;
//    var result;
//    $.ajax({
//        type: "POST",
//        url: $(location).attr('href') + "/SetBranchAndCompanyName",
//        data: JSON.stringify(DTO),
//        contentType: "application/json",
//        dataType: "json",
//        async: false,
//        success: function (data) {
//            result = data.d;
//        }

//    });
//    return result;
//}


//function SetBranchAndCompanyName(Company_Id, Branch_Id)
//{

//    FillGeneralCobmboSelectAll('selCompany', "Company_Id", ((getCookie("LangCookie") == "ar") ? "Company_Name" : "Company_NameEn"), "Hr_Companies", "");
//    FillGeneralCobmboSelectAll('selBranch', "Branch_Id", ((getCookie("LangCookie") == "ar") ? "Branch_Name" : "Branch_NameEn"), "Hr_Branches", "");

//    var strCompanyName = $('#selCompany option[value="' + (Company_Id == "" ? -1 : Company_Id) + '"]').text();
//    var strBranchName = $('#selBranch option[value="' + (Branch_Id == "" ? -1 : Branch_Id) + '"]').text();
//    var varstrLang;
//    debugger;
//    if ($("#chkLangEn").prop("checked")) {
//        varstrLang = "en";
//    } else {
//        varstrLang = "ar";
//    }

//    varGLang = varstrLang;

//    debugger;
//    var DTO = { 'strCompanyName': strCompanyName, 'strBranchName': strBranchName, 'strLang': varstrLang };
//    debugger;
//    var result;
//    $.ajax({
//        type: "POST",
//        url: $(location).attr('href') + "/SetBranchAndCompanyName",
//        data: JSON.stringify(DTO),
//        contentType: "application/json",
//        dataType: "json",
//        async: false,
//        success: function (data) {
//            result = data.d;
//        }

//    });
//    return result;
//}


function forgetPassword()
{
    debugger;
    var model =
      {
          Email: $('#txtEmail').val()
         
      };

    debugger;
    var DTO = { 'model': model };
    debugger;
    var result;
    $.ajax({
        type: "POST",
        url: document.location.origin + "/api/accounts/ForgetPass",
        data: JSON.stringify(model),
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            debugger;
            if (data != null)
            {
                debugger;
                bootbox.alert(data);
               // $('#btnCloseRestPassword').trigger('click');

            }

        },
        error: function (error) {

            jsonValue = jQuery.parseJSON(error.responseText);
            alert("error" + error.responseText);
        }
    });

}


function TestNewUser() {


    debugger;

    var createUserModel =
        {
            LoginName: "Ahmedr2304",
            Password: "Admin@123",
            CompanyId: "005",
            BranchNo: "1"

        };
    var DT0 = { 'username': createUserModel.LoginName }
     // getToken(createUserModel.LoginName, createUserModel.Password);
    var berardata
    if (accessToken == '') {
        GetNewToken(createUserModel.LoginName, createUserModel.Password);
        berardata = accessToken;
    } else {
        berardata = accessToken;
    }



    debugger;
    var result;
    $.ajax({
        type: "POST",
        url: document.location.origin + "/api/accounts/GetUserByName?username=" + createUserModel.LoginName + "",
        data: '',
        contentType: "application/json",
        dataType: "json",
        async: false,
        success: function (data) {

            debugger;
            /// this is correct return data alert(data[0].["fullName"]);

            if (data != null) {
                debugger;
                setUserData(data);
            }
            //alert(data.fullName);
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





function setUserData(ObjList) {


    var DTO = { 'objUser': ObjList };
    debugger;
    var result;
    $.ajax({
        type: "POST",
        url: $(location).attr('href') + "/setUserData",
        data: JSON.stringify(DTO),
        contentType: "application/json",
        dataType: "json",
        async: false,
        success: function (data)
        {
            result = data.d;
           
        }

    });
    return result;
}



function SetBranchAndCompanyName_Old()
{
    var strCompanyName = $('#selCompany option:selected').text();
    var strBranchName = $('#selBranch option:selected').text();
    var varstrLang;
    if ($("#chkLangEn").prop("checked"))
    {
        varstrLang = "en";
    } else
    {
        varstrLang = "ar";
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
    if ($('#txtUserName').val() == "" || $('#txtPassword').val() == "")
    {
        Result = false;
    }
    return Result;
}


function CheckUserAuthority_Old(strLoginName, strPassword, strCompanyId, strBranchNo)
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
        setCookie("LangCookie", varGLang, "en");
        
    } else
    {
        setCookie("UserNameCookie", $('#txtUserName').val().trim(), -1);
        setCookie("PasswordCookie", $('#txtPassword').val().trim(), -1);
        setCookie("LangCookie", varGLang, "en");

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
    Username : "AthelAdmin0101",
    Email: "adminhr@pharma.com.sa",
    FirstName : "AthelTree",
    LastName : "Admin",
    Level :3,
    Company_Id : "001",
    Branch_Id : "001",
    Emp_Serial_No : -1,
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

function TestUser()
{
    
    var createUserModel =
        {
            LoginName: "Ahmedr2304",
            Password: "Admin@123",
            CompanyId: "001",
            BranchNo: "001"
            
        };

    // getToken(createUserModel.LoginName, createUserModel.Password);
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

function ResetPassword()
{
    debugger;
    var ResetPasswordViewModel =
       {
           Id: "38ece8ce-4714-4e37-8365-cfa190c1279d",
           NewPassword: "Admin@1234",
           ConfirmPassword: "Admin@1234"
         

       };

     // getToken(createUserModel.LoginName, createUserModel.Password);

    var berardata = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJuYW1laWQiOiIxYmU3M2UzZS1lOWEzLTRjMDUtYjI0MS0wMDUyMDdjMTZkODAiLCJ1bmlxdWVfbmFtZSI6IkF0aGVsQWRtaW4wMTAxIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS9hY2Nlc3Njb250cm9sc2VydmljZS8yMDEwLzA3L2NsYWltcy9pZGVudGl0eXByb3ZpZGVyIjoiQVNQLk5FVCBJZGVudGl0eSIsIkFzcE5ldC5JZGVudGl0eS5TZWN1cml0eVN0YW1wIjoiYWIwYmIyNDctZDU3Ni00NDZlLTk1ZTktMDU4MmFmNmYzYmI3Iiwicm9sZSI6IkFkbWluIiwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDoxMDI0IiwiYXVkIjoiNDE0ZTE5MjdhMzg4NGY2OGFiYzc5ZjcyODM4MzdmZDEiLCJleHAiOjE0OTMwNDQ3MTAsIm5iZiI6MTQ5Mjk1ODMxMH0.bVXtS08LwTx0ba1PyZdg-UJmn4UfkzkVHcsO6rtOdGQ"
   


    var DTO = { 'model': ResetPasswordViewModel };
    debugger;
    var result;
    $.ajax({
        type: "POST",
        url: document.location.origin + "/api/accounts/ResetPassword",
        data: JSON.stringify(ResetPasswordViewModel),
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

function saveUserRoles() {
    debugger;

    var ResetPasswordViewModel =
       {
           Id: "38ece8ce-4714-4e37-8365-cfa190c1279d",
           NewPassword: "Admin@1234",
           ConfirmPassword: "Admin@1234"


       };

     // getToken(createUserModel.LoginName, createUserModel.Password);

    var berardata = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJuYW1laWQiOiIxYmU3M2UzZS1lOWEzLTRjMDUtYjI0MS0wMDUyMDdjMTZkODAiLCJ1bmlxdWVfbmFtZSI6IkF0aGVsQWRtaW4wMTAxIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS9hY2Nlc3Njb250cm9sc2VydmljZS8yMDEwLzA3L2NsYWltcy9pZGVudGl0eXByb3ZpZGVyIjoiQVNQLk5FVCBJZGVudGl0eSIsIkFzcE5ldC5JZGVudGl0eS5TZWN1cml0eVN0YW1wIjoiYWIwYmIyNDctZDU3Ni00NDZlLTk1ZTktMDU4MmFmNmYzYmI3Iiwicm9sZSI6IkFkbWluIiwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDoxMDI0IiwiYXVkIjoiNDE0ZTE5MjdhMzg4NGY2OGFiYzc5ZjcyODM4MzdmZDEiLCJleHAiOjE0OTMwNDQ3MTAsIm5iZiI6MTQ5Mjk1ODMxMH0.bVXtS08LwTx0ba1PyZdg-UJmn4UfkzkVHcsO6rtOdGQ"



    var DTO = { 'model': ResetPasswordViewModel };
    debugger;
    var result;
    $.ajax({
        type: "POST",
        url: document.location.origin + "/api/accounts/ResetPassword",
        data: JSON.stringify(ResetPasswordViewModel),
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
function GetLogo(){
    debugger;
    var Path = "AttachFilesApp/CompLogoAttach/";
    var Img = "DefaultLargeLogo.png";
    $.ajax({
        type: "POST",
        url:$(location).attr("href")+"/GetLogo",
        data: '',
        contentType: "application/json",
        dataType: "json",
        async: false,
        success: function (data) {
            debugger;
            $('#Logo').html("");
            if (data.d != null && data.d != "") {
                Img = data.d;

            }
            var fullPath = Path + Img;
            var image = $('<img src="' + fullPath + '" />');
            $('#Logo').append('<img class="login-logo login-6" style="height:10%;width:50%;" src="' + fullPath + '"/>');
            debugger;
            $("img").bind("error", function () {
            
                $(this).attr("src", '' + Path + 'DefaultLargeLogo.png');
            });
           
            
        }

    });
}

function GetMultiCompanies() {
    $.ajax({
        type: "POST",
        url: GeneralHelperAjaxUrl + "GetMultiCompanies",
        data: '',
        contentType: "application/json",
        dataType: "json",
        async: false,
        success: function (data) {
            debugger;
            if (data.d.MultiCompanies == 0 || data.d.MultiCompanies == null) {
                $('#GotoCompanies').css('display', 'none');
            }
            else if (data.d.MultiCompanies == 1) {
                $('#GotoCompaniesLink').attr("href", data.d.DefaultHomePage)
            }

        }
    });
}