<%@ Page Title="" Language="C#" MasterPageFile="~/MasterFiles/MasterSiteEn.Master" AutoEventWireup="true" CodeBehind="EmployeeTasks.aspx.cs"
    Inherits="AthelHR.EmployeeTasks" %>

<asp:Content ID="Content3" ContentPlaceHolderID="CPHeadGlobalScript" runat="server">
    <link href="<%= Page.ResolveClientUrl("~/assets/global/plugins/select2/css/select2.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/assets/global/plugins/select2/css/select2-bootstrap.min.css") %>" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .table thead tr th {
            font-family: Segoe UI;
        }

        .table thead tr td {
            font-family: Segoe UI Light;
        }
    </style>


</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div id="divScr" class="portlet light portlet-fit portlet-form bordered">


        <div class="portlet-title">
            <div class="caption">
                <i class=" icon-layers font-red"></i>
                <span class="caption-subject font-red sbold uppercase" id="SpnScreenTitle"></span>
            </div>

        </div>
        <div class="portlet light bordered">
            <div class="portlet-title">
                <%-- <div class="caption font-dark">
                                            <i class="icon-settings font-dark"></i>
                                            <span class="caption-subject bold uppercase" id="SpnTabelHdr">MyTask</span>
                                        </div>--%>

                <div id="divbody">

                    <div class="panel-group accordion" id="accordion3">
                        <div class="panel panel-default" id="pnlRequest" style="display: none;">
                            <div class="panel-heading">
                                <div style="height: 35px;">
                                    <h4 class="panel-title">
                                        <a style="font-family: Segoe UI Light" class="accordion-toggle accordion-toggle-styled collapsed dictionary-class" keyprop="strRequestNotifiction" data-toggle="collapse" data-parent="#accordion3" href="#collapse_3_1"></a>
                                    </h4>
                                    <span id="SpnRequstNotf" class="badge badge-warning" style="margin-top: -4%; margin-left: 37%; background-color: #32c5d2;">0</span>
                                </div>
                            </div>
                            <%--To open Collapse to add class (in) not (collapse) ex: <div id="collapse_3_1" class="panel-collapse in">--%>
                            <div id="collapse_3_1" class="panel-collapse collapse">
                                <div class="panel-body" style="height: 200px; overflow-y: auto;">

                                    <div class="row" style="margin-top: -11px;">
                                        <div class="col-md-offset-5 col-md-7">
                                            <a href="javascript:;" id="btnviewRequest" class="btn btn-sm green" onclick="ViewDetailRequest();">
                                                <span style="font-size: 11px; font-family: Segoe UI Light; margin-left: -11px;" class="dictionary-class" keyprop="strDetails"></span>
                                                <%--<i class="fa fa-floppy-o"></i>--%>
                                            </a>
                                            <%--<button type="button" class="btn btn-circle grey-salsa btn-outline">Cancel</button>--%>
                                        </div>
                                    </div>
                                    <hr style="margin-top: 6px;" />

                                    <div class="portlet-body portletdiv" style="margin-top: -10px;">
                                        <table class="table table-striped table-bordered table-hover table-header-fixed" id="TblHeaderRequest">
                                            <thead>
                                                <tr class="">
                                                    <th style="width: 2%;">#</th>
                                                    <th style="width: 3%; display: none;">NotifyType</th>
                                                    <th style="width: 3%;" class="dictionary-class" keyprop="strRequesttype"></th>
                                                    <th style="width: 16%;" class="dictionary-class" keyprop="strRequesttypeName"></th>
                                                    <th style="width: 20%;" class="dictionary-class" keyprop="strRequestOwner"></th>
                                                    <th style="width: 20%;" class="dictionary-class" keyprop="strRequestApp"></th>
                                                    <th style="width: 20%;" class="dictionary-class" keyprop="strRoleName"></th>
                                                    <th style="width: 3%;" class="dictionary-class" keyprop="strSndDate"></th>
                                                    <th style="width: 11%;" class="dictionary-class" keyprop="strMaxDate"></th>
                                                    <th style="width: 5%;" class="dictionary-class" keyprop="strSelect"></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            </tbody>
                                        </table>
                                    </div>



                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default" id="pnlBrnchDoc" style="display: none;">
                            <div class="panel-heading">
                                <div style="height: 35px;">
                                    <h4 class="panel-title">
                                        <a style="font-family: Segoe UI Light" class="accordion-toggle accordion-toggle-styled collapsed dictionary-class" keyprop="strBrnchDocNotifiction" data-toggle="collapse" data-parent="#accordion3" href="#collapse_3_2"></a>
                                    </h4>
                                    <span id="SpnBranchNotf" class="badge badge-warning" style="margin-top: -4%; margin-left: 37%; display: none; background-color: #32c5d2;">0</span>
                                </div>
                            </div>
                            <div id="collapse_3_2" class="panel-collapse collapse">
                                <div class="panel-body" style="height: 200px; overflow-y: auto;">
                                    <div class="row" style="margin-top: -11px;">
                                        <div class="col-md-offset-5 col-md-7">
                                            <a href="javascript:;" id="btnviewBrnch" class="btn btn-sm green" onclick="ViewDetailBrnchDoc();">
                                                <span style="font-size: 11px; font-family: Segoe UI Light; margin-left: -11px;" class="dictionary-class" keyprop="strDetails"></span>
                                                <%--<i class="fa fa-floppy-o"></i>--%>
                                            </a>
                                            <%--<button type="button" class="btn btn-circle grey-salsa btn-outline">Cancel</button>--%>
                                        </div>
                                    </div>
                                    <hr style="margin-top: 6px;" />

                                    <div class="portlet-body portletdiv" style="margin-top: -10px;">
                                        <table class="table table-striped table-bordered table-hover table-header-fixed" id="TblHeaderBrnchDoc">
                                            <thead>
                                                <tr class="">
                                                    <th style="width: 2%;">#</th>
                                                    <th style="width: 3%; display: none;">NotifyType</th>
                                                    <th style="width: 6%; display: none;">Notify</th>
                                                    <th style="width: 16%;" class="dictionary-class" keyprop="strDocName"></th>
                                                    <th style="width: 23%;" class="dictionary-class" keyprop="strDocOwner"></th>
                                                    <th style="width: 20%;" class="dictionary-class" keyprop="strRequestApp"></th>
                                                    <th style="width: 28%;" class="dictionary-class" keyprop="strRoleName"></th>
                                                    <th style="width: 3%; display: none;">SendDate</th>
                                                    <th style="width: 3%; display: none;">MaxDate</th>
                                                    <th style="width: 5%;" class="dictionary-class" keyprop="strSelect"></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            </tbody>
                                        </table>
                                    </div>




                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default" id="pnlEmpDoc" style="display: none;">
                            <div class="panel-heading">
                                <div style="height: 35px;">
                                    <h4 class="panel-title">
                                        <a style="font-family: Segoe UI Light" class="accordion-toggle accordion-toggle-styled collapsed dictionary-class" keyprop="strEmpDocNotifiction" data-toggle="collapse" data-parent="#accordion3" href="#collapse_3_3"></a>
                                    </h4>
                                    <span id="SpnEmpNotf" class="badge badge-warning" style="margin-top: -4%; margin-left: 37%; background-color: #32c5d2;">0</span>
                                </div>
                            </div>
                            <div id="collapse_3_3" class="panel-collapse collapse">
                                <div class="panel-body" style="height: 200px; overflow-y: auto;">

                                    <div class="row" style="margin-top: -11px;">
                                        <div class="col-md-offset-5 col-md-7">
                                            <a href="javascript:;" id="btnviewEmpDoc" class="btn btn-sm green" onclick="ViewDetailEmpDoc();">
                                                <span style="font-size: 11px; font-family: Segoe UI Light; margin-left: -11px;" class="dictionary-class" keyprop="strDetails"></span>
                                                <%--<i class="fa fa-floppy-o"></i>--%>
                                            </a>
                                            <%--<button type="button" class="btn btn-circle grey-salsa btn-outline">Cancel</button>--%>
                                        </div>
                                    </div>
                                    <hr style="margin-top: 6px;" />

                                    <div class="portlet-body portletdiv" style="margin-top: -10px;">

                                        <table class="table table-striped table-bordered table-hover table-header-fixed" id="TblHeaderEmp">
                                            <thead>
                                                <tr class="">
                                                    <th style="width: 2%;">#</th>
                                                    <th style="width: 16%;" class="dictionary-class" keyprop="strNotify"></th>
                                                    <th style="width: 3%; display: none;">NotifyType</th>
                                                    <th style="width: 6%;" class="dictionary-class" keyprop="strDocName"></th>
                                                    <th style="width: 23%;" class="dictionary-class" keyprop="strDocOwner"></th>
                                                    <th style="width: 20%;" class="dictionary-class" keyprop="strRequestApp"></th>
                                                    <th style="width: 28%;" class="dictionary-class" keyprop="strRoleName"></th>
                                                    <th style="width: 3%; display: none;">SendDate</th>
                                                    <th style="width: 3%; display: none;">MaxDate</th>
                                                    <th style="width: 5%;" class="dictionary-class" keyprop="strSelect"></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            </tbody>
                                        </table>
                                    </div>



                                </div>
                            </div>
                        </div>

                        <div class="panel panel-default" id="pnlEmpCntrct" style="display: none;">
                            <div class="panel-heading">
                                <div style="height: 35px;">
                                    <h4 class="panel-title">
                                        <a style="font-family: Segoe UI Light" class="accordion-toggle accordion-toggle-styled collapsed dictionary-class" keyprop="strEmpContctNotifiction" data-toggle="collapse" data-parent="#accordion3" href="#collapse_3_4"></a>
                                    </h4>
                                    <span id="SpnEmpCntrct" class="badge badge-warning" style="margin-top: -4%; margin-left: 37%; background-color: #32c5d2;">0</span>
                                </div>
                            </div>
                            <div id="collapse_3_4" class="panel-collapse collapse">
                                <div class="panel-body" style="height: 200px; overflow-y: auto;">

                                    <div class="row" style="margin-top: -11px;">
                                        <div class="col-md-offset-5 col-md-7">
                                            <a href="javascript:;" id="btnviewEmpContrct" class="btn btn-sm green" onclick="ViewDetailEmpContrct();">
                                                <span style="font-size: 11px; font-family: Segoe UI Light; margin-left: -11px;" class="dictionary-class" keyprop="strDetails"></span>
                                                <%--<i class="fa fa-floppy-o"></i>--%>
                                            </a>
                                            <%--<button type="button" class="btn btn-circle grey-salsa btn-outline">Cancel</button>--%>
                                        </div>
                                    </div>
                                    <hr style="margin-top: 6px;" />

                                    <div class="portlet-body portletdiv" style="margin-top: -10px;">

                                        <table class="table table-striped table-bordered table-hover table-header-fixed" id="TblHeaderEmpContrct">
                                            <thead>
                                                <tr class="">
                                                    <th style="width: 2%;">#</th>
                                                    <th style="width: 3%; display: none;">NotifyType</th>
                                                    <th style="width: 6%; display: none;">Notify</th>
                                                    <th style="width: 42%;" class="dictionary-class" keyprop="strDocOwner"></th>
                                                    <th style="width: 23%; display: none;">ContractOwner</th>
                                                    <th style="width: 20%;" class="dictionary-class" keyprop="strRequestApp"></th>
                                                    <th style="width: 20%;" class="dictionary-class" keyprop="strRoleName"></th>
                                                    <th style="width: 3%;" class="dictionary-class" keyprop="strSndDate"></th>
                                                    <th style="width: 8%;" class="dictionary-class" keyprop="strFinishDate"></th>
                                                    <th style="width: 5%;" class="dictionary-class" keyprop="strSelect"></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            </tbody>
                                        </table>
                                    </div>



                                </div>
                            </div>
                        </div>

                        <div class="panel panel-default" id="pnlEmpTestingCntrct" style="display: none;">
                            <div class="panel-heading">
                                <div style="height: 35px;">
                                    <h4 class="panel-title">
                                        <a style="font-family: Segoe UI Light" class="accordion-toggle accordion-toggle-styled collapsed dictionary-class" keyprop="strEmpContctTestingNotifiction" data-toggle="collapse" data-parent="#accordion3" href="#collapse_3_5"></a>
                                    </h4>
                                    <span id="SpnEmpTestingCntrct" class="badge badge-warning" style="margin-top: -4%; margin-left: 37%; background-color: #32c5d2;">0</span>
                                </div>
                            </div>
                            <div id="collapse_3_5" class="panel-collapse collapse">
                                <div class="panel-body" style="height: 200px; overflow-y: auto;">

                                    <div class="row" style="margin-top: -11px;">
                                        <div class="col-md-offset-5 col-md-7">
                                            <a href="javascript:;" id="btnviewEmpTestingContrct" class="btn btn-sm green" onclick="ViewDetailEmpTestingContrct();">
                                                <span style="font-size: 11px; font-family: Segoe UI Light; margin-left: -11px;" class="dictionary-class" keyprop="strDetails"></span>
                                                <%--<i class="fa fa-floppy-o"></i>--%>
                                            </a>
                                            <%--<button type="button" class="btn btn-circle grey-salsa btn-outline">Cancel</button>--%>
                                        </div>
                                    </div>
                                    <hr style="margin-top: 6px;" />

                                    <div class="portlet-body portletdiv" style="margin-top: -10px;">

                                        <table class="table table-striped table-bordered table-hover table-header-fixed" id="TblHeaderEmpTestingContrct">
                                            <thead>
                                                <tr class="">
                                                    <th style="width: 2%;">#</th>
                                                    <th style="width: 3%; display: none;">NotifyType</th>
                                                    <th style="width: 6%; display: none;">Notify</th>
                                                    <th style="width: 42%;" class="dictionary-class" keyprop="StrEmpName"></th>
                                                    <th style="width: 23%; display: none;">ContractOwner</th>
                                                    <th style="width: 20%;" class="dictionary-class" keyprop="strRequestApp"></th>
                                                    <th style="width: 20%;" class="dictionary-class" keyprop="strRoleName"></th>
                                                    <th style="width: 3%;" class="dictionary-class" keyprop="strHireDate"></th>
                                                    <th style="width: 8%;" class="dictionary-class" keyprop="strFinishTestingDate"></th>
                                                    <th style="width: 5%;" class="dictionary-class" keyprop="strSelect"></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            </tbody>
                                        </table>
                                    </div>



                                </div>
                            </div>
                        </div>


                    </div>





                </div>

            </div>

        </div>

    </div>

    <!-- END EXAMPLE TABLE PORTLET-->






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

    <script src="/Scripts/HrServices/EmployeeTask.js?bust_js_cache=<%=System.IO.File.GetLastWriteTime(Server.MapPath("/Scripts/HrServices/EmployeeTask.js")).ToString("HH:mm:ss")%>" type="text/javascript"></script>



</asp:Content>

