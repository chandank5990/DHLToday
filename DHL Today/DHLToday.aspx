<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DHLToday.aspx.cs" Inherits="DHL_Today.DHLToday" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<style type="text/css">
.hidden-field
        {
            display: none;
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Search By Observation" 
    style="font-weight: 700"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" runat="server" 
    Style="text-align: center; font-weight: 700;" Height="20px"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search"
        Height="25px" style="font-weight: 700" />
    &nbsp;
    <asp:CheckBox ID="Pending" runat="server" />
    &nbsp;&nbsp;
    <asp:Label ID="lblPending" runat="server" Text="Pending" 
    style="font-weight: 700"></asp:Label>
    &nbsp;
    <asp:CheckBox ID="Delivered" runat="server" />
    &nbsp;&nbsp;
    <asp:Label ID="lblDelivered" runat="server" Text="Delivered" 
    style="font-weight: 700"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" style="font-weight: 700" 
        Text="Number Of DHL :"></asp:Label>
&nbsp;&nbsp;
    <asp:Label ID="lblNoOfDHL" runat="server" style="font-weight: 700"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" Style="text-align: center" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="UID">
                                <EditItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("NumOrd") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkView" OnClick="lnkView_Click" Text='<%# Bind("NumOrd") %>'
                                        autopostback="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
            <asp:BoundField DataField="Observaciones" HeaderText="Observation" ReadOnly="True" />
            <asp:BoundField DataField="Location" HeaderText="Location" ReadOnly="True" />
            <asp:BoundField DataField="ArtOrd" HeaderText="" ReadOnly="True">
            <ItemStyle CssClass="hidden-field" />
                            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
