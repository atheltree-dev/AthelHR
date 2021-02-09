<%@ Page Title="" Language="C#" MasterPageFile="~/MasterFiles/MasterSiteEn.Master" AutoEventWireup="true" CodeBehind="indexEn.aspx.cs" Inherits="AthelHR.indexEn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script type="text/javascript">
          $(document).ready(function () {
              EmphasTask();
              if (GLang == "en")
              {
                  $('#pagTiltle').text("HRMS Application");
              } else
              {
                  $('#pagTiltle').text("برنامج إدارة شئون الموظفين");
              }
          });
          </script>

            <h1 class="page-title" id="pagTiltle"> HRMS Application
            <%--<small>HRMS Management</small>--%>
             </h1>
            <%--<div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">                          
            <center><img src ="<%= Page.ResolveClientUrl("~/images/pharmalogo.gif") %>" class = "img-circle" style="width:18%;" ></center> 
            </div>   
            </div>--%>

            <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">                          
            <img class="img-background-en" style="display: block;margin-left: auto;margin-right: auto;"" src ="<%= Page.ResolveClientUrl("~/images/Background2.jpg") %>"  > 
            </div>   
            </div>
                    <%--class = "img-thumbnail"--%>   
                        <!-- END DASHBOARD STATS 1-->
                     

</asp:Content>

 <asp:Content ID="Content4" ContentPlaceHolderID="CPBodyPageScript" runat="server">
  
       
    </asp:Content>



