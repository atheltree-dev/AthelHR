
$(document).ready(function ()
{

    var VarUserId = $('#imguser').attr('UserId');//"541fcc6e-7d8f-496f-923b-431247fd1946";
    var VarCompany_Id = $('#SpnCompany').attr('tag');//"005";
    var VarBranch_Id = $('#SpnBranch').attr('tag');//"1";
    debugger;
    if (VarUserId != "" && VarUserId != null && VarUserId != undefined
        && VarCompany_Id != "" && VarCompany_Id != null && VarCompany_Id != undefined
        && VarBranch_Id != "" && VarBranch_Id != null && VarBranch_Id != undefined) {

        $.ajax({
            url: $(location).attr('origin') + '/' + "MenuHandler.ashx?User_Id=" + VarUserId + "&Company_Id=" + VarCompany_Id + "&Branch_Id=" + VarBranch_Id + "",
            method: 'get',
            dataType: 'json',
            success: function (data)
            {
                debugger;
                ObjUserMenu = data.slice();
                ObjUserMenugloabl = data.slice();
                
                obj1 = JSON.stringify(ObjUserMenugloabl);
                debugger;
                $('#SpnCompany').attr("data-dataObj", obj1);

                buildMenu($('#menu'), data);

                //var lastid0 = $(ObjClone1).filter(function (i, n) { return n.LevelId === 0});

                ObjLastMenu = GetlastMenuActive();
                if (ObjLastMenu != null && ObjLastMenu != "" && ObjLastMenu != undefined)
                {
                    lastid0 = ObjLastMenu.LastMenu0;
                    lastid1 = ObjLastMenu.LastMenu1;
                    lastid2 = ObjLastMenu.LastMenu2;
                    $('#'+lastid0).trigger('click');
                    $('#'+lastid1).trigger('click');
                    $('#'+lastid2).closest('li').addClass('open');

                }
                
               //alert($('#47').closest('li').addClass('active'));
              //  setNavigation();

              //  $('ul#mainmenu-nav > li > a').click(function(e) { e.preventDefault()});

                $('#menu').menu;
            }
        });
    } else
    {
        gotoLoginScren(false);
    }
   
});
var lastid0, lastid1, lastid2, ObjLastMenu;
//var ObjUserMenu = [];
//function GetRoles(strpageName)
//{
//    debugger;
//    alert(strpageName);
//   // alert(ObjUserMenu[0].pageName)

//}



var icon_index = 0;
var icon = ['<i class="fa fa-dashboard"></i>', '<i class="fa fa-bar-chart"></i>', '<i class="icon-docs"></i>', '<i class="icon-layers"></i>', '<i class="icon-calendar"></i>', '<i class="fa fa-paperclip"></i>', '<i class="fa fa-dollar"></i>', '<i class="icon-docs"></i>', '<i class="icon-user"></i>', '<i class="fa fa-pie-chart"></i>'];

function buildMenu(parentid, items) {
  //  consle.log(this);
  
    $.each(items, function () {
       
        var li = $('<li></li>');
        if (this.isActive == 1) {
            li.addClass('nav-item');
        }

        li.appendTo(parentid);

        if (this.LevelId == 0) {
		 
			   
            var aherf = $('<a></a>');
			
				
            aherf.addClass('nav-link nav-toggle');     
            aherf.html(icon[icon_index]);           
            var spntitle
         
            if (GLang == "en") {
              
                spntitle = $('<span>' + this.MenuNameEn + '</span>');
            } else
            {
                spntitle = $('<span>' + this.MenuName + '</span>');
            }
             //spntitle = $('<span>' + this.MenuNameEn + '</span>');
            spntitle.addClass('title');
            spntitle.appendTo(aherf);
            var spnRow = $('<span></span>');
            spnRow.addClass('arrow');
            aherf.attr("href", this.PathUrl);
            aherf.attr("id", this.MenuId);
            
            spnRow.appendTo(aherf);
            aherf.appendTo(li);
            $(aherf).on('click', function (e)
            {
                lastid0 = $(aherf).attr("id");
            });
            // creation UL SubMenuLevel 1
            buildbyparentid(items, this.MenuId, li);
            icon_index++;
        }
        
    });
}
    function buildbyparentid(item , strparentid,lastparenttag)
    {
        var ullevelGlob1 = $('<ul></ul>');
        ullevelGlob1.addClass('sub-menu');

        $.each(item, function () {
            
            if (this.ParentId == strparentid && this.LevelId==1)
            {
                var lilevel1 = $('<li></li>');
                lilevel1.addClass('nav-item');
                var aherflevel1 = $('<a></a>');
                aherflevel1.addClass('nav-link nav-toggle');
                var spntitlelevel1;
                if (GLang == "en") {
                    spntitlelevel1 = $('<span><strong>' + this.MenuNameEn + '</strong></span>');
                } else
                {
                    spntitlelevel1 = $('<span><strong>' + this.MenuName + '</strong></span>');
                }

                spntitlelevel1.addClass('title');
                spntitlelevel1.appendTo(aherflevel1);
                var spnRowlevel1 = $('<span></span>');
                spnRowlevel1.addClass('arrow');
                aherflevel1.attr("href", this.PathUrl);
                aherflevel1.attr("id", this.MenuId);
                spnRowlevel1.appendTo(aherflevel1);

                aherflevel1.appendTo(lilevel1);
               
               // if (this.LevelId == 2) {
                   
                    buildbyparentLevel2(item, this.MenuId, lilevel1);
               // }

                    lilevel1.appendTo(ullevelGlob1)
               
            }

            $(aherflevel1).on('click', function (e) {
                lastid1 = $(aherflevel1).attr("id");
            });


        });

        ullevelGlob1.appendTo(lastparenttag);

        
    }


    function buildbyparentLevel2(item, strparent, lastparentLevel2)
    {
        var ullevelGlobal2;
        var lilevelGlobal2;

        ullevelGlobal2 = $('<ul></ul>');
        ullevelGlobal2.addClass('sub-menu');

        $.each(item, function () {
         
            if (this.LevelId == 2 && this.ParentId == strparent)
            {
                //var strUrl = "<%=Page.ResolveClientUrl(" + this.PathUrl + ")%>";
                //var strUrl = "'<%=ResolveUrl(" + this.PathUrl + ")%>'";
                var pageurl = $(location).attr('origin') + '/' + this.PathUrl;
              //  alert(pageurl);
                    var lilevel2;
                    lilevel2 = $('<li></li>');
                    lilevel2.addClass('nav-item');
                    var aherflevel2;
               
                if (GLang == "en") {
                    aherflevel2 = $('<a>' + this.MenuNameEn + '</a>');
                } else
                {
                    aherflevel2 = $('<a>' + this.MenuName + '</a>');
                }

                    aherflevel2.css('color', '#36c6d3');
                    aherflevel2.attr('href', pageurl);
                    aherflevel2.addClass('nav-link');
                    aherflevel2.addClass('level2');
                    aherflevel2.appendTo(lilevel2);
                    lilevel2.appendTo(ullevelGlobal2);
                    aherflevel2.attr("id", this.MenuId);

                    //$(".nav-link a").on('click', function (e)
                    //{
                    //    debugger;
                    //    alert('A');
                //});

               
                    $(aherflevel2).on('click', function (e)
                    {
                        lastid2=$(aherflevel2).attr('id');
                        //var obj = $(aherflevel2).attr('id');
                        setlastMenuActive();

                        //alert(lastid0);
                        //alert(lastid1);
                        //alert(lastid2);

                     
                      //  alert($(aherflevel2).attr('id'));
                        //$(aherflevel2).trigger('a');
                        //e.preventDefault();
                      //  e.stopPropagation();
                        //var path = window.location.pathname;
                        //path = path.replace(/\/$/, "");
                        //path = decodeURIComponent(path);

                        ////alert($(this).attr('href'));
                        //var href = $(this).attr('href');
                        //debugger;
                        //if (href != "javascript:;" && href != undefined)
                        //{
                        //    if (path.substring(0, href.length) === href)
                        //    {
                        //        debugger;
                        //        $(this).closest('li').addClass('active');
                        //    }
                        //}


                      //  alert($(this).attr('href'));
                        //$('a[class=nav-link]').trigger('href');
                    
                        // alert('A');

                        //var ValidAuth = CheckUserAuthontication();

                        //if (ValidAuth != null && ValidAuth != -1) {

                           

                        //} else if (ValidAuth == -1) {
                        //    var Message = ((getCookie("LangCookie") == "ar") ? "هذا المستخدم ليس له صلاحية" : "This User has not authontication ");
                        //    varpagename = "Login";
                        //    // gotoLoginScren(false);
                        //    CustomAlertConfirmLogout(Message, varpagename)
                        //    //window.location.replace($(location).attr('origin') + '/' + "Login.aspx");


                        //}


                    });


            }
        });

        ullevelGlobal2.appendTo(lastparentLevel2)

    }
    function setNavigation() {
        var path = window.location.pathname;
        path = path.replace(/\/$/, "");
        path = decodeURIComponent(path);

        $(".level2 a").each(function () {
            var href = $(this).attr('href');
            debugger;
            if (href != "javascript:;" && href != undefined)
            {
                    if (path.substring(0, href.length) === href) {
                        $(this).closest('li').addClass('active');
                    }
            }
        });
    }

    function setlastMenuActive()
    {
        if (lastid0 != null && lastid0 != "" && lastid0 != undefined
            && lastid1 != null && lastid1 != "" && lastid1 != undefined
            && lastid2 != null && lastid2 != "" && lastid2 != undefined)
            
        {
            var objLastMenuActivateDL = {};

            objLastMenuActivateDL.LastMenu0 = lastid0;
            objLastMenuActivateDL.LastMenu1 = lastid1;
            objLastMenuActivateDL.LastMenu2 = lastid2;

            debugger;
            var DTO = { 'objLastMenuActivateDL': objLastMenuActivateDL};
            debugger;
            var result;
            $.ajax({
                type: "POST",
                url: GeneralHelperAjaxUrl + "SetLastMenuActivate",
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
    }

    function GetlastMenuActive() {
        

            debugger;
           // var DTO = { 'objLastMenuActivateDL': objLastMenuActivateDL };
            debugger;
            var result;
            $.ajax({
                type: "POST",
                url: GeneralHelperAjaxUrl + "getLastMenuActivate",
                data: '',
                contentType: "application/json",
                dataType: "json",
                async: false,
                success: function (data) {
                    result = data.d;
                }

            });
            return result;
        }
    



    function myFunction() {
        document.getElementById("divmenu").classList.toggle("show");
    }

    function filterFunction() {
        var input, filter, ul, li, a, i;
        
        input = document.getElementById("myInput");
        
        filter = input.value.toUpperCase();
        div = document.getElementById("divmenu");
        a = div.getElementsByTagName("a");
        for (i = 0; i < a.length; i++) {
            
            if (a[i].innerHTML.toUpperCase().indexOf(filter) > -1) {
                a[i].style.display = "";
            } else {
                a[i].style.display = "none";
            }
        }
    }

// For searching in array

    //$(function () {
    //    var availableTags = [
    //      "ActionScript",
    //      "AppleScript",
    //      "Asp",
    //      "BASIC",
    //      "C"
    //    ];
    //    $("#tags").autocomplete({
    //        source: availableTags
    //    });
    //});

// The design for search
   /*
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
 
    <div class="ui-widget">
      <label for="tags">Tags: </label>
      <input id="tags">
    </div>
    */