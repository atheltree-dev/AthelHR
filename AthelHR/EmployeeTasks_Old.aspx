<%@ Page Title="" Language="C#" MasterPageFile="~/MasterFiles/MasterSiteEn.Master" AutoEventWireup="true" CodeBehind="EmployeeTasks_Old.aspx.cs" 
    Inherits="PharmaERP.EmployeeTasks_Old" %>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHeadGlobalScript" runat="server">
<link href="<%= Page.ResolveClientUrl("~/assets/global/plugins/select2/css/select2.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/assets/global/plugins/select2/css/select2-bootstrap.min.css") %>" rel="stylesheet" type="text/css" />

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           

             <div class="portlet light portlet-fit portlet-form bordered">


                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class=" icon-layers font-red"></i>
                                        <span class="caption-subject font-red sbold uppercase" id="SpnScreenTitle">MyTask</span>
                                    </div>

                                </div>
         <div class="portlet light bordered">
                                    <div class="portlet-title">
                                        <div class="caption font-dark">
                                            <i class="icon-settings font-dark"></i>
                                            <span class="caption-subject bold uppercase" id="SpnTabelHdr">MyTask</span>
                                        </div>
                                      <%--  <div class="actions">
                                            <div class="btn-group btn-group-devided" data-toggle="buttons">
                                                <label class="btn btn-transparent dark btn-outline btn-circle btn-sm active">
                                                    <input type="radio" name="options" class="toggle" id="option1">Actions</label>
                                                <label class="btn btn-transparent dark btn-outline btn-circle btn-sm">
                                                    <input type="radio" name="options" class="toggle" id="option2">Settings</label>
                                            </div>
                                        </div>--%>
                                     <div id="divSearchData">
                                              <div class="row" id="divSearchCompany">
                                                       <!-- BEGIN divColRow3-1-->
                                                       <div class="col-md-12" >
                                                           <div class="col-md-6">
                                                               
                                                                 <div class="form-group has-success" >  
                                                                  <label for="selSearchCompany_Id" class="control-label">Company</label>
                                                                  <select id="selSearchCompany_Id" class="form-control select2" onchange="SearchData();" >
                                                                  </select>
                                                                 </div>
                                                               
                                                           </div>
                                                          <div class="col-md-6">
                                                                <div class="form-group has-success" >  
                                                                  <label for="selSearchBranch_Id" class="control-label">Branch</label>
                                                                  <select id="selSearchBranch_Id" class="form-control select2"  onchange="SearchData();">
                                                                  </select>
                                                                 </div>
                                                           </div>
                                                          
                                                      
                                                      </div>
                                                       <!-- End divColRow3-1-->
                                                  </div>

                                            <div class ="row">
                                                 <div class="col-md-12">
                                                       
                                                           <div class="col-md-5">
                                                               
                                                                 <div class="form-group has-success" >  
                                                                  <label for="selSearchNotifyType" class="control-label">Notify Type</label>
                                                                  <select id="selSearchNotifyType" class="form-control select2" onchange="SearchData();" >
                                                                  </select>
                                                                 </div>
                                                               
                                                           </div>
                                                          <div class="col-md-5">
                                                                <div class="form-group has-success" >  
                                                                  <label for="selSearchRequestType" class="control-label">RequestType</label>
                                                                  <select id="selSearchRequestType" class="form-control select2" onchange="SearchData();" >
                                                                  </select>
                                                                 </div>
                                                           </div>
                                                          <div class="col-md-5" style="display:none;">
                                                                <div class="form-group has-success" >  
                                                                  <label for="selSearchApplicant" class="control-label">Applicant</label>
                                                                  <select id="selSearchApplicant" class="form-control select2" onchange="SearchData();" >
                                                                  </select>
                                                                 </div>
                                                           </div>
                                                      
                                                      

                                                        <div class="col-md-2" style="margin-top:2%;">
                                                            <div class="m-grid-col-bottom" ">
                                                                <a href="javascript:;" id="btnSearch" onclick="SearchData();"  class="btn btn-md yellow">
                                                                <span>show</span>
                                                                <i class="fa fa-search"></i>
                                                                </a>
                                                            </div>
                                                        </div>
                                                  </div>
                                            </div>
                                        </div>


                                    </div>
                                    <div class="portlet-body portletdiv">
                                        <table class="table table-striped table-bordered table-hover table-header-fixed" id="TblHeader">
                                            <thead>
                                                <tr class="">
                                                    <th style="width:2%;">#</th>
                                                    <th style="width:3%;">NotifyType</th>
                                                    <th style="width:3%;">RequestType</th>
                                                    <th style="width:16%;">RequestTypeName</th>
                                                    <th style="width:20%;">RequestOwner</th>
                                                    <th style="width:20%;">Applicant</th>
                                                    <th style="width:25%;">RoleName</th>
                                                    <th style="width:3%;">SendDate</th>
                                                    <th style="width:3%;">MaxDate</th>
                                                    <th style="width:5%;">Select</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                              
                                               
                                            </tbody>
                                        </table>
                                    </div>
                                </div>

                                <!-- END EXAMPLE TABLE PORTLET-->
                                              <div class="form-actions">
                                                        <div class="row">
                                                            <div class="col-md-12" style="left:45%" >
                                                                 <%--<a href="javascript:;" class="btn btn-md  purple">
                                                                 <span>Rest</span>
                                                                 <i class="fa fa-plus"></i>
                                                                </a>--%>
                                                                <a href="javascript:;" class="btn btn-lg green" onclick="ViewDetailRequest();">
                                                                        <span>View Details</span>
                                                                    <i class="fa fa-floppy-o"></i>
                                                                </a>
                                                                    <a href="javascript:;" class="btn btn-lg red" onclick="CloseScr();">
                                                                        <span>Close</span>
                                                                    <i class="fa fa-times"></i>
                                                                </a>
                                                        
                                                            </div>
                                                        </div>
                                            </div>
         </div>

             <%--
                 <h1 class="page-title"> My Tasks
            
                 </h1>
                   
                  <div class="portlet box yellow">
                                    <div class="portlet-title">
                                        <div class="caption">
                                            <i class="fa fa-gift"></i>My Task</div>
                                        <div class="tools">
                                            <a href="javascript:;" class="collapse" data-original-title="" title=""> </a>
                                            <a href="#portlet-config" data-toggle="modal" class="config" data-original-title="" title=""> </a>
                                            <a href="javascript:;" class="reload" data-original-title="" title=""> </a>
                                            <a href="javascript:;" class="remove" data-original-title="" title=""> </a>
                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        <div class="panel-group accordion" id="accordion3">
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">
                                                        <a class="accordion-toggle accordion-toggle-styled collapsed" data-toggle="collapse" data-parent="#accordion3" href="#collapse_3_1" aria-expanded="false"> Collapsible Group Item #1 </a>
                                                    </h4>
                                                </div>
                                                <div id="collapse_3_1" class="panel-collapse collapse" aria-expanded="false" style="height: 0px;">
                                                    <div class="panel-body">
                                                        <p> Duis autem vel eum iriure dolor in hendrerit in vulputate. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut. </p>
                                                        <p> Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum
                                                            eiusmod. </p>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">
                                                        <a class="accordion-toggle accordion-toggle-styled collapsed" data-toggle="collapse" data-parent="#accordion3" href="#collapse_3_2" aria-expanded="false"> Collapsible Group Item #2 </a>
                                                    </h4>
                                                </div>
                                                <div id="collapse_3_2" class="panel-collapse collapse" aria-expanded="false" style="height: 0px;">
                                                    <div class="panel-body" style="height:200px; overflow-y:auto;">
                                                        <p> Duis autem vel eum iriure dolor in hendrerit in vulputate. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut. </p>
                                                        <p> Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum
                                                            eiusmod. </p>
                                                        <p> Duis autem vel eum iriure dolor in hendrerit in vulputate. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut. </p>
                                                        <p>
                                                            <a class="btn blue" href="ui_tabs_accordions_navs.html#collapse_3_2" target="_blank"> Activate this section via URL </a>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">
                                                        <a class="accordion-toggle accordion-toggle-styled collapsed" data-toggle="collapse" data-parent="#accordion3" href="#collapse_3_3" aria-expanded="false"> Collapsible Group Item #3 </a>
                                                    </h4>
                                                </div>
                                                <div id="collapse_3_3" class="panel-collapse collapse" aria-expanded="false" style="height: 0px;">
                                                    <div class="panel-body">
                                                        <p> Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum
                                                            eiusmod. Brunch 3 wolf moon tempor. </p>
                                                        <p> Duis autem vel eum iriure dolor in hendrerit in vulputate. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut. </p>
                                                        <p>
                                                            <a class="btn green" href="ui_tabs_accordions_navs.html#collapse_3_3" target="_blank"> Activate this section via URL </a>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">
                                                        <a class="accordion-toggle accordion-toggle-styled collapsed" data-toggle="collapse" data-parent="#accordion3" href="#collapse_3_4" aria-expanded="false"> Collapsible Group Item #4 </a>
                                                    </h4>
                                                </div>
                                                <div id="collapse_3_4" class="panel-collapse collapse" aria-expanded="false" style="height: 0px;">
                                                    <div class="panel-body">
                                                        <p> Duis autem vel eum iriure dolor in hendrerit in vulputate. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut. </p>
                                                        <p> Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum
                                                            eiusmod. Brunch 3 wolf moon tempor. </p>
                                                        <p> Duis autem vel eum iriure dolor in hendrerit in vulputate. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut. </p>
                                                        <p>
                                                            <a class="btn red" href="ui_tabs_accordions_navs.html#collapse_3_4" target="_blank"> Activate this section via URL </a>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>--%>
         

</asp:Content>
  <asp:Content ID="Content5" ContentPlaceHolderID="CPBodyGlobalScript" runat="server">
     <script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/select2/js/select2.full.min.js") %>"> type="text/javascript"></script>

   <script src="<%= Page.ResolveClientUrl("~/assets/global/scripts/datatable.js") %>"> type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/datatables/datatables.min.js") %>"> type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js") %>"> type="text/javascript"></script>
 </asp:Content>
   <asp:Content ID="Content6" ContentPlaceHolderID="CPBodyPageScript" runat="server">
     <script src="<%= Page.ResolveClientUrl("~/assets/pages/scripts/components-select2.min.js") %>"> type="text/javascript"></script>
       <script src="<%= Page.ResolveClientUrl("~/assets/pages/scripts/table-datatables-fixedheader.min.js") %>"> type="text/javascript"></script>
     <script src="<%= Page.ResolveClientUrl("~/Scripts/HrServices/EmployeeTask_Old.js") %>"> type="text/javascript"></script> 
       
    </asp:Content>

   