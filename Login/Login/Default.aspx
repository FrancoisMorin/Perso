<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="Login._Default" %>

<asp:Content style="width: 100%;" runat="server" ContentPlaceHolderID="slidercontent">
    <script src="//code.jquery.com/jquery-latest.min.js"></script>
    <script src="Scripts/unslider.js"></script>

    <script>
        $(function () {
            if (window.chrome) {
                $('.banner li').css('background-size', '100% 100%');
            }
            $('.banner').unslider({

                speed: 500,
                delay: 3000,
                complete: function () { },
                keys: true,
                dots: true,
                fluid: true
            });
        });
    </script>

    <div class="banner">
        <ul>
            <li style="background-image: url('Images/borddeplage.jpg');">
                <div class="backgrounddivh1">
                    <h1>Visiter nos hôtels</h1>
                </div>
            </li>
            <li style="background-image: url('Images/piscine.jpg');">
                <div class="backgrounddivh1">
                    <h1>Réserver une chambre</h1>
                </div>
            </li>
            <li style="background-image: url('Images/bar.jpg');">
                <div class="backgrounddivh1">
                    <h1>Consulter nos forfaits</h1>
                </div>
            </li>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--<script src="//code.jquery.com/jquery-latest.min.js"></script>
    <script src="Scripts/unslider.js"></script>

    <script>
        $(function () {
            if (window.chrome) {
                $('.banner li').css('background-size', '100% 100%');
            }
            $('.banner').unslider({

                speed: 500,
                delay: 3000,
                complete: function () { },
                keys: true,
                dots: true,
                fluid: false
            });
        });
    </script>

    <div class="banner">
        <ul>
            <li style="background-image: url('Images/hotel1.jpg');">
                <div>
                    <h1>Visiter nos hôtels</h1>
                </div>
            </li>
            <li style="background-image: url('Images/hotel2.jpg');">
                <div>
                    <h1>Réserver une chambre</h1>
                </div>
            </li>
            <li style="background-image: url('Images/hotel3.jpg');">
                <div>
                    <h1>Consulter nos forfaits</h1>
                </div>
            </li>
        </ul>
    </div>--%>

    <div class="row">

        <div class="col-md-4">
            <h2>Réserver une chambre</h2>
            <p>
                La chaîne d'hôtels Nouvotel offre de nombreuses chambres dans différent hôtels à travers le Canada.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">En savoir plus &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Consulter nos forfaits</h2>
            <p>
                Vous trouverez facilement le forfait qui convient pour votre séjour dans nos hôtels.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">En savoir plus &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
