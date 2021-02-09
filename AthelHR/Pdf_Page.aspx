<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pdf_Page.aspx.cs" Inherits="AthelHR.Pdf_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="JS/jquery-1.10.2.min.js"></script>


</head>
<body oncontextmenu="return false">
    <div id="test">
        <iframe id="frame" src="PDF_File/algorithms_4th_edition.pdf#toolbar=0&navpanes=0" style="height:99%;width:99%;" ></iframe>
        <div id="front"></div>
    </div>
    <script>
        document.addEventListener('contextmenu', event => event.preventDefault());

    </script>

    <style>
        #frame {
            position: absolute;
        }

        #front {
            position: absolute;
            width: 98.3%;
            height: 100%;
            background: transparent;
        }
    </style>
</body>
</html>
