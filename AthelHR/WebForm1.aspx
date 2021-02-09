<%@ Page Title="" Language="C#" MasterPageFile="~/MasterFiles/MasterSiteEn.Master" AutoEventWireup="true"
    CodeBehind="WebForm1.aspx.cs" Inherits="AthelHR.WebForm1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="CPHeadGlobalScript" runat="server">


    <link href="<%= Page.ResolveClientUrl("~/spStyles/pagination.css") %>" rel="stylesheet" type="text/css" />

    <link href="<%= Page.ResolveClientUrl("~/assets/global/plugins/select2/css/select2.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/assets/global/plugins/select2/css/select2-bootstrap.min.css") %>" rel="stylesheet" type="text/css" />


    <link href="<%= Page.ResolveClientUrl("~/assets/global/plugins/bootstrap-toastr/toastr.min.css") %>" rel="stylesheet" type="text/css" />

    <link href="<%= Page.ResolveClientUrl("~/assets/global/plugins/bootstrap-daterangepicker/NewTransfereddaterangepicker.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/assets/global/plugins/bootstrap-datepicker/css/bootstrap-datepicker3.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/assets/global/plugins/bootstrap-timepicker/css/bootstrap-timepicker.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/assets/global/plugins/bootstrap-datetimepicker/css/bootstrap-datetimepicker.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/assets/global/plugins/clockface/css/clockface.css") %>" rel="stylesheet" type="text/css" />



</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="TestDynamic.js"></script>
    <%--    <style type="text/css">
        body {
            font-family: Arial;
            font-size: 10pt;
        }

        table {
            border: 1px solid #ccc;
            border-collapse: collapse;
        }

            table th {
                background-color: #F7F7F7;
                color: #333;
                font-weight: bold;
            }

            table th, table td {
                padding: 5px;
                border-color: #ccc;
            }
    </style>--%>
    <style>
        /*.table-wrapper {
            overflow-y: scroll;
            overflow-x: scroll;
            height: 150px;
        }

            .table-wrapper th {
                position: sticky;
                top: 0;
            }

      
        table {
            border-collapse: collapse;
            width: 100%;
        }

        th {
            background: #DDD;
        }

        td, th {
            padding: 10px;
            text-align: center;
        }

        .fix {
            position: absolute;
            *position: relative; 
            margin-left: -100px;
            width: 100px;
        }*/

        /*div {
            max-width: 40em;
            max-height: 20em;
            overflow: scroll;
            position: relative;
        }*/
        .table-wrapper {
            overflow-y: scroll;
            overflow-x: scroll;
            height: 150px;
            width:500px;
        }
        table {
            position: relative;
            border-collapse: collapse;
         
        }

        td,th {
            padding: 0.25em;
        }

        thead th {
            position: -webkit-sticky; /* for Safari */
            position: sticky;
            top: 0;
            background: #000;
            color: #FFF;
        }

            thead th:first-child {
                left: 0;
                z-index: 1;
                width :24.1%;
            }
             thead th:nth-child(2){
                left: 24.1%;
                z-index: 1;
             }
              table td:nth-child(2){
                left: 24.1%;
                z-index: 1;
             }

                table td:first-child{
                left: 0;
                z-index: 1;
             }

        
        tbody th {
            position: -webkit-sticky; /* for Safari */
            position: sticky;
            left: 0;
            background: #FFF;
            border-right: 1px solid #CCC;
        }
         tbody th:nth-child(2) {
            position: -webkit-sticky; /* for Safari */
            position: sticky;
            left: 24.1%;
            background: #FFF;
            border-right: 1px solid #CCC;
        }
    </style>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="divScr" class="portlet light portlet-fit portlet-form bordered">


        <div class="portlet-title">
            <div class="caption">
                <i class=" icon-layers font-red"></i>
                <span class="caption-subject font-red sbold uppercase" id="SpnScreenTitle"></span>
            </div>
        </div>




        <form id="form2" runat="server">
            <div>
                <input type="button" value="Generate Table" onclick="GenerateTable()" />
                <hr />
                <div class="outer">
                    <div id="dvTable" class="inner table-wrapper">
                    </div>
                </div>

                <script type="text/javascript">

</script>
            </div>
        </form>


    </div>





</asp:Content>



<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="TestDynamic.js"></script>
    <style type="text/css">
        body {
            font-family: Arial;
            font-size: 10pt;
        }

        table {
            border: 1px solid #ccc;
            border-collapse: collapse;
        }

            table th {
                background-color: #F7F7F7;
                color: #333;
                font-weight: bold;
            }

            table th, table td {
                padding: 5px;
                border-color: #ccc;
            }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="button" value="Generate Table" onclick="GenerateTable()" />
            <hr />
            <div id="dvTable">
            </div>
            <script type="text/javascript">

</script>
        </div>
    </form>
</body>
</html>--%>


<asp:Content ID="Content5" ContentPlaceHolderID="CPBodyGlobalScript" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/select2/js/select2.full.min.js") %>"> type="text/javascript"></script>

    <script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/moment.min.js") %>"> type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/bootstrap-daterangepicker/daterangepicker.min.js") %>"> type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.min.js") %>"> type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/bootstrap-timepicker/js/bootstrap-timepicker.min.js") %>"> type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js") %>"> type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/clockface/js/clockface.js") %>"> type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPBodyPageScript" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/assets/pages/scripts/components-select2.min.js") %>"> type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets/pages/scripts/components-date-time-pickers.min.js") %>"> type="text/javascript"></script>

    <%--<script src="<%= Page.ResolveClientUrl("~/Scripts/HrServices/RequestManagement/BorrowRequest/EmpBorrowRequest.js") %>"> type="text/javascript"></script>--%>
    <%--    <script src="/Scripts/HrRecords/RecordManagement/VcationRecord.js?bust_js_cache=<%=System.IO.File.GetLastWriteTime(Server.MapPath("/Scripts/HrRecords/RecordManagement/VcationRecord.js")).ToString("HH:mm:ss")%>" type="text/javascript"></script>--%>
    <script src="TestDynamic.js"></script>


</asp:Content>
