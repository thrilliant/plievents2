<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="MailAttach._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU" crossorigin="anonymous"/>

    <title>Create Message</title>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <div class="container py-2">
        


<div class="card">
    <div class="card-header">
        Create Message
    </div>
    <div class="card-body">
        
            <div class="mb-3">
                <label class="form-label" for="Title">Title</label>
                <asp:TextBox ID="Title" runat="server" data-val="true" data-val-required="The Title field is required." class="form-control"></asp:TextBox>
                
                <span class="text-danger field-validation-valid" data-valmsg-for="Title" data-valmsg-replace="true"></span>
            </div>
            <div class="mb-3">
                <label class="form-label" for="File">Image File</label>
                <asp:FileUpload ID="File" runat="server" CssClass="form-control" />
                <span class="text-danger field-validation-valid" data-valmsg-for="File" data-valmsg-replace="true"></span>
            </div>
            <div class="mb-3">
                <label class="form-label" for="Address">Address</label>
                <input class="form-control" type="text" data-val="true" data-val-required="The Address field is required." id="Address" name="Address" value="" runat="server"/>
                <span class="text-danger field-validation-valid" data-valmsg-for="Address" data-valmsg-replace="true"></span>
            </div>
            <div class="mb-3">
                <label class="form-label" for="Date">Date</label>
                <asp:TextBox ID="Date"  class="form-control" type="datetime-local" data-val="true" data-val-required="The Date field is required." runat="server"></asp:TextBox>
                
                <span class="text-danger field-validation-valid" data-valmsg-for="Date" data-valmsg-replace="true"></span>
            </div>
            <div class="mb-3">
                <label class="form-label" for="QrCodeData">QR Code Data</label>
                <input class="form-control" type="text" data-val="true" data-val-required="The QR Code Data field is required." id="QrCodeData" name="QrCodeData" value="" runat="server"/>
                <span class="text-danger field-validation-valid" data-valmsg-for="QrCodeData" data-valmsg-replace="true"></span>
            </div>
            <div class="mb-3">
                <label class="form-label" for="FullName">Full Name</label>
                <input class="form-control" type="text" data-val="true" data-val-required="The Full Name field is required." id="FullName" name="FullName" value="" runat="server"/>
                <span class="text-danger field-validation-valid" data-valmsg-for="File" data-valmsg-replace="true"></span>
            </div>
            <div class="mb-3">
                <label class="form-label" for="Type">Type</label>
                <input class="form-control" type="text" data-val="true" data-val-required="The Type field is required." id="Type" name="Type" value="" runat="server"/>
                <span class="text-danger field-validation-valid" data-valmsg-for="File" data-valmsg-replace="true"></span>
            </div>
            <div class="mb-3">
                <label class="form-label" for="OrderDate">Order Date</label>
                <asp:TextBox ID="OrderDate" class="form-control" type="datetime-local" data-val="true" data-val-required="The Order Date field is required." runat="server"></asp:TextBox>
                
                <span class="text-danger field-validation-valid" data-valmsg-for="OrderDate" data-valmsg-replace="true"></span>
            </div>
            <div class="mb-3">
                <label class="form-label" for="OrderID">Order ID</label>
                <input class="form-control" type="text" data-val="true" data-val-required="The Order ID field is required." id="OrderID" name="OrderID" value="" runat="server"/>
                <span class="text-danger field-validation-valid" data-valmsg-for="OrderID" data-valmsg-replace="true"></span>
            </div>
            <div class="mb-3">
                <label class="form-label" for="To">E Mail</label>
                <asp:TextBox ID="To" class="form-control" type="email" data-val="true" data-val-required="The E Mail field is required." runat="server"></asp:TextBox>
          
                <span class="text-danger field-validation-valid" data-valmsg-for="To" data-valmsg-replace="true"></span>
            </div>
            <div class="mb-3">
                <label class="form-label" for="Body">Message</label>
                <asp:TextBox ID="Body" TextMode="MultiLine" class="form-control" data-val="true" data-val-required="The Message field is required."  runat="server"></asp:TextBox>
                
                <span class="text-danger field-validation-valid" data-valmsg-for="Body" data-valmsg-replace="true"></span>
            </div>
            <asp:Button ID="btnSendEmail" runat="server" Text="Send E-Mail" class="btn btn-secondary btn-block" />
            
        <input name="__RequestVerificationToken" type="hidden" value="CfDJ8HtNTYN6TtRFm2ojcjAhkFVagLRa5eRFlY4WFueEulWUVwRn-tV2gTRPd9pCiBm9Bn8RHlflgx67_HiCmgcWYmFGAMHpVZXX8yt9j0RAfu3tz_LYOMbMb0RTHNlSqQ3ysXEH1a9zAlaHAzwfVPSGujY" /></form>
    </div>
</div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-/bQdsTh/da6pkI1MST/rWKFNjaCP5gBSY4sEBT38Q/9RBh9AH40zEOg7Hlq2THRZ"
        crossorigin="anonymous"></script>
    </form>
</body>
</html>
