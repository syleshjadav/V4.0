<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RestTester._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<script>

    var siteUrl = "https://www.myshopauto.com/ATPRestSvc/RestSvs.svc";

    function GetServiceTypes() {
        alert(siteUrl + "/GetDealers/5");

        $.ajax({
            type: "GET",
            url: siteUrl + "/GetDealers/5",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var jsonString = JSON.stringify({
                    GetServiceTypesResult: data
                });
                alert(jsonString);
            },
            error: function (jqXHR, status, error) {
                alert("jqXHR= " + jqXHR.getAllResponseHeaders() + ", textStatus= " + status + ", errorThrown= " + error);
            },
            failure: function (msg) {
                alert(msg);
            }
        });
    }


    function GetYears() {
        $.ajax({
            type: "GET",
            url: siteUrl + "/GetYears",
            dataType: "json",
            processData: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var jsonString = JSON.stringify({ GetYearsResult: data });
                alert(jsonString);
            },
            error: function (parsedjson, textStatus, errorThrown) {
                console.log("parsedJson: " + JSON.stringify(parsedjson));

                $('body').append(
                    "parsedJson status: " + parsedjson.status + '</br>' +
                    "errorStatus: " + textStatus + '</br>' +
                    "errorThrown: " + errorThrown);

            },
            failure: function (msg) {
                alert(msg);
            }
        });
    }

    GetYears();
</script>






</asp:Content>
