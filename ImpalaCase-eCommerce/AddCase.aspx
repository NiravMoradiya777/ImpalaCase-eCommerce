<%@ Page Title="" Language="C#" MasterPageFile="~/ImpalaMaster.Master" AutoEventWireup="true" CodeBehind="AddCase.aspx.cs" Inherits="ImpalaCase_eCommerce.AddCase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Add New Case</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainBody" runat="server">
    <div class="form-group">
        <asp:Label ID="lblMessage" runat="server" CssClass="text-success"></asp:Label>
    </div>

    <div class="form-group">
        <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger"></asp:Label>
    </div>
    <div class="form-group">
        <label for="txtTitle">Title</label>
        <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" Required="true"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle"
            InitialValue="" ErrorMessage="Title is required" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="txtShortDescription">Short Description</label>
        <asp:TextBox ID="txtShortDescription" runat="server" CssClass="form-control" Required="true"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvShortDescription" runat="server" ControlToValidate="txtShortDescription"
            InitialValue="" ErrorMessage="Short Description is required" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="txtLongDescription">Long Description</label>
        <asp:TextBox ID="txtLongDescription" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtAbout">About</label>
        <asp:TextBox ID="txtAbout" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtWeight">Weight in KG</label>
        <asp:TextBox ID="txtWeight" runat="server" CssClass="form-control" Required="true"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvWeight" runat="server" ControlToValidate="txtWeight"
            InitialValue="" ErrorMessage="Weight is required" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revWeight" runat="server" ControlToValidate="txtWeight"
            ValidationExpression="^[0-9]\d*(\.\d+)?$" ErrorMessage="Please enter a valid numeric value."
            Display="Dynamic" CssClass="text-danger" />
    </div>
    <div class="form-row">
        <div class="col-md-2 mb-2">
            <label for="txtLength">Length</label>
            <asp:TextBox ID="txtLength" runat="server" CssClass="form-control" Required="true"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvLength" runat="server" ControlToValidate="txtLength"
                InitialValue="" ErrorMessage="Length is required" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revLength" runat="server" ControlToValidate="txtLength"
                ValidationExpression="^\d+$" ErrorMessage="Please enter a valid numeric value."
                Display="Dynamic" CssClass="text-danger" />
        </div>
        <div class="col-md-2 mb-2">
            <label for="txtWidth">Width</label>
            <asp:TextBox ID="txtWidth" runat="server" CssClass="form-control" Required="true"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvWidth" runat="server" ControlToValidate="txtWidth"
                InitialValue="" ErrorMessage="Width is required" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revWidth" runat="server" ControlToValidate="txtWidth"
                ValidationExpression="^\d+$" ErrorMessage="Please enter a valid numeric value."
                Display="Dynamic" CssClass="text-danger" />
        </div>
        <div class="col-md-2 mb-2">
            <label for="txtDepth">Depth</label>
            <asp:TextBox ID="txtDepth" runat="server" CssClass="form-control" Required="true"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDepth" runat="server" ControlToValidate="txtDepth"
                InitialValue="" ErrorMessage="Depth is required" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revDepth" runat="server" ControlToValidate="txtDepth"
                ValidationExpression="^\d+$" ErrorMessage="Please enter a valid numeric value."
                Display="Dynamic" CssClass="text-danger" />
        </div>
    </div>
    <div class="form-group">
        <label for="txtColor">Color</label>
        <asp:TextBox ID="txtColor" runat="server" CssClass="form-control" Required="true"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvColor" runat="server" ControlToValidate="txtColor"
            InitialValue="" ErrorMessage="Color is required" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="ddlModel">Compatible Phone Model</label>
        <asp:DropDownList ID="ddlModel" runat="server" CssClass="form-control" Required="true">
            <asp:ListItem Value="iPhone 11">iPhone 11</asp:ListItem>
            <asp:ListItem Value="iPhone 11 Pro">iPhone 11 Pro</asp:ListItem>
            <asp:ListItem Value="iPhone 11 Pro Max">iPhone 11 Pro Max</asp:ListItem>
            <asp:ListItem Value="iPhone 12">iPhone 12</asp:ListItem>
            <asp:ListItem Value="iPhone 12 Pro">iPhone 12 Pro</asp:ListItem>
            <asp:ListItem Value="iPhone 12 Pro Max">iPhone 12 Pro Max</asp:ListItem>
            <asp:ListItem Value="iPhone 13 Mini">iPhone 13 Mini</asp:ListItem>
            <asp:ListItem Value="iPhone 13">iPhone 13</asp:ListItem>
            <asp:ListItem Value="iPhone 13 Pro">iPhone 13 Pro</asp:ListItem>
            <asp:ListItem Value="iPhone 13 Pro Max">iPhone 13 Pro Max</asp:ListItem>
            <asp:ListItem Value="iPhone 14 Mini">iPhone 14 Mini</asp:ListItem>
            <asp:ListItem Value="iPhone 14">iPhone 14</asp:ListItem>
            <asp:ListItem Value="iPhone 14 Pro">iPhone 14 Pro</asp:ListItem>
            <asp:ListItem Value="iPhone 14 Pro Max">iPhone 14 Pro Max</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvModel" runat="server" ControlToValidate="ddlModel"
            InitialValue="" ErrorMessage="Compatible Phone Model is required"
            Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="txtMaterial">Material</label>
        <asp:TextBox ID="txtMaterial" runat="server" CssClass="form-control" Required="true"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvMaterial" runat="server" ControlToValidate="txtMaterial"
            InitialValue="" ErrorMessage="Material is required" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="txtPrice">Price</label>
        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" Required="true"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ControlToValidate="txtPrice"
            InitialValue="" ErrorMessage="Price is required" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revPrice" runat="server" ControlToValidate="txtPrice"
            ValidationExpression="^[0-9]\d*(\.\d+)?$" ErrorMessage="Please enter a valid numeric value."
            Display="Dynamic" CssClass="text-danger" />
    </div>
    <div class="form-group">
        <label for="fileToUpload">Image</label>
        <asp:FileUpload ID="fileToUpload" runat="server" CssClass="form-control" accept=".jpg,.jpeg,.png,.gif" />
        <asp:RequiredFieldValidator ID="rfvFile" runat="server" ControlToValidate="fileToUpload"
            InitialValue="" ErrorMessage="Please select an image file" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <asp:Button ID="btnAddCase" runat="server" Text="Add Case" CssClass="btn btn-primary" OnClick="btnAddCase_Click" />
    </div>
</asp:Content>
