<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>

<script>

    var siteUrl = "http://www.myshopauto.com/ATPRestSvc/RestSvs.svc";

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
</script>

<%
	Response.Write("Hello")
%>
<script>
    GetYears();

</script>