<%@ Page Title="" Language="C#" MasterPageFile="~/MasterFiles/MasterSiteAr.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AthelHR.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script type="text/javascript">
          $(document).ready(function ()
          {
              EmphasTask();
          });
          </script>

            <h1 class="page-title"> برنامج إداراة شئون الموظفين
            <%--<small>HRMS Management</small>--%>
             </h1>
            <%--<div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">                          
            <center><img src ="<%= Page.ResolveClientUrl("~/images/pharmalogo.gif") %>" class = "img-circle" style="width:18%;" ></center> 
            </div>   
            </div>--%>

            <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">                          
            <img style="margin-right: 18%;margin-top: 5%;" src ="<%= Page.ResolveClientUrl("~/images/Background2.jpg") %>"  > 
            </div>   
            </div>
                    <%--class = "img-thumbnail"--%>   
                        <!-- END DASHBOARD STATS 1-->
                     

</asp:Content>

 <asp:Content ID="Content4" ContentPlaceHolderID="CPBodyPageScript" runat="server">
  
       
    </asp:Content>
