using System;
using System.Collections.Generic;

namespace Monopoly
{
    public class GameBoard
    {
        public static string Error { get; private set; } = "";
        public List<EventCard> EventCards { get; private set; } = new List<EventCard>();
        public List<CommunityCard> CommunityCards { get; private set; } = new List<CommunityCard>();
        public List<StreetCard> AvailableStreetCars { get; private set; } = new List<StreetCard>();
        public List<Cell> Cells { get; private set; } = new List<Cell>();  

        public static GameBoard TryCreateGameBoard()
        {
            GameBoard board = new GameBoard();
            List<StreetCard> availableStreetCars = new List<StreetCard>();
            List<Cell> cells = new List<Cell>();

            //for (int a = 0; a < 16; a++)
            //    EventCards.Add(new EventCard("EventCard" + (a + 1)));
            //for (int a = 0; a < 16; a++)
            //    CommunityCards.Add(new CommunityCard("CommunityCard" + (a + 1)));

            try
            {
                string[] streetData = GetStreetsData().Replace("\r\n", "\r").Split('\r');

                for (int a = 1; a < streetData.Length; a++)
                {
                    string[] splits = streetData[a].Split(';');
                    StreetCard streetCard = new StreetCard(Convert.ToInt32(splits[1]),
                           Convert.ToInt32(splits[2]), Convert.ToInt32(splits[3]), Convert.ToInt32(splits[4]), Convert.ToInt32(splits[5]),
                           Convert.ToInt32(splits[6]), Convert.ToInt32(splits[7]), Convert.ToInt32(splits[8]), splits[9], splits[10]);
                    availableStreetCars.Add(streetCard); 
                    cells.Add(new Cell(cells.Count,streetCard));
                }

                board.AvailableStreetCars = availableStreetCars;
                board.Cells = cells;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
            return board;
        }

        private static string GetStreetsData()
        {
            return "Index;BuyPrice;HousePrice;Rent;OneHousePrice;TwoHousesPrice;ThreeHousesPrice;FourHousesPrice;HotelPrice;Name" +
                "\r\n1;60;50;2;10;30;90;160;250;Badstraße;Brown" +
                "\r\n3;60;50;4;20;60;180;320;450;Turmstraße;Brown" +

                "\r\n5;100;50;6;30;90;270;400;550;Chausseestraße;LightBlue" +
                "\r\n7;100;50;6;30;90;270;400;550;Elisenstraße;LightBlue" +
                "\r\n8;120;50;8;40;100;300;450;600;Poststraße;LightBlue" +

                "\r\n10;140;100;10;50;150;450;625;750;Seestraße;Pink" +
                "\r\n12;140;100;10;50;150;450;625;750;Hafenstraße;Pink" +
                "\r\n13;160;100;12;60;180;500;700;900;Neue Straße;Pink" +

                "\r\n15;180;100;14;70;200;550;750;950;Münchener Straße;Orange" +
                "\r\n16;180;100;14;70;200;550;750;950;Wiener Straße;Orange" +
                "\r\n18;200;100;16;80;220;600;800;1000;Berliner Straße;Orange" +

                "\r\n0;220;150;18;90;250;700;875;1050;Theaterstraße;Red" +
                "\r\n0;220;150;18;90;250;700;875;1050;Museumstraße;Red" +
                "\r\n0;240;150;20;100;300;750;925;1100;Opernplatz;Red" +

                "\r\n25;260;150;22;110;330;800;975;1150;Schillerstraße;Yellow" +
                "\r\n26;260;150;22;110;330;800;975;1150;Lessingstraße;Yellow" +
                "\r\n28;280;24;150;120;360;850;1025;1200;Goethestrasse;Yellow" +

                "\r\n30;300;200;26;130;390;900;1100;1275;Rathausplatz;Green" +
                "\r\n32;300;200;26;130;390;900;1100;1275;Hauptstraße;Green" +
                "\r\n33;320;200;28;150;450;1000;1200;1400;Bahnhofstraße;Green" +

                "\r\n37;350;200;35;175;500;1100;1300;1500;Parkstraße;DarkBlue" +
                "\r\n39;400;200;50;200;600;1400;1700;2000;Schlossallee;DarkBlue";


                //"\r\n11;4x augen, 10x augen;150;Elektrizitätswerk" +
                //"\r\n27;4x augen, 10x augen;150;Wasserwerk" +

            //"\r\n4;200;25;50;100;200;Hauptbahnhof" +
            //"\r\n14;200;25;50;100;200;Südbahnhof" +
            //"\r\n24;200;25;50;100;200;Westbahnhof" +
            //"\r\n34;200;25;50;100;200;Nordbahnhof";
        }

        private string GetCommunityCardsData()
        {
            return "Gefängnis frei\r\n+10€\r\n+20€\r\nzurück Badstraße\r\nvor nächste Bahnhof\r\nvor Los\r\n-100€\r\nGefängnis\r\n+100 2x\r\n+25\r\n+200\r\n-10 oder Ereigniskarte\r\n+50\r\n-50\r\nvon jedem spieler 10";
        }

        private string GetEventCardsData()
        {
            return "Gefängnis frei\r\n+50\r\nzurück 3 felder\r\nGefängnis\r\nvor Schlossallee\r\nvor Südbahnhof\r\nvor Opernplatz\r\nrenovieren, haus 25, hotel 100\r\n50 an jeden spieler\r\nvor los\r\n+150\r\n-15\r\nrenovieren, haus 40, hotel 115\r\n-150\r\n+100\r\nvor seestraße";
        }
    }
}