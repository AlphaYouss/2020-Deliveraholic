<%@ Page Title="" Language="C#" MasterPageFile="~/paypal/Payment.Master" AutoEventWireup="true" CodeBehind="PaymentStart.aspx.cs" Inherits="PayPal_Demo.paypal.PaymentStart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Start Payment</h1>
    <asp:Button ID="btnPaymentStart" runat="server" Text="Payment Start" OnClick="btnPaymentStart_Click" />
</asp:Content>
