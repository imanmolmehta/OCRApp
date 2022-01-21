<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OCRApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 5%;">
        <div class="row">
            <div class="col-lg-12">
                <div class="col-md-6">
                    <asp:Image ID="fileUploadImage" runat="server" Width="200px" Height="100px" />
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Upload Image</label>
                        <asp:FileUpload ID="fileUpload" runat="server" />
                        <asp:HiddenField ID="fileUrl" runat="server" Value="" />
                        <asp:Panel ID="frmConfirmation" Visible="False" runat="server">
                            <asp:Label ID="lblUploadResult" runat="server"></asp:Label>
                        </asp:Panel>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="fileUploadBtn" runat="server" Text="Upload" OnClick="FileUploadBtn_Click" />
                        <asp:Button ID="processBtn" runat="server" Text="Process" OnClick="ProcessBtn_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Panel ID="processedImage" Visible="False" runat="server">
        <asp:Label ID="lblProcessedImage" runat="server"></asp:Label>
    </asp:Panel>

</asp:Content>
