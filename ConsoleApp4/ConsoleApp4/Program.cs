using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using System.Data.SqlClient;
using OpenQA.Selenium;
using System.Data;
using Neo4j.Driver;
using Neo4jClient;
using System.Collections;
using Microsoft.Graph;

namespace ConsoleApp4
{

    public class GFG
    {
        private static IWebDriver driver;


        // static method one
        public static void method1()
        {


            string connetionString = null;
            SqlConnection cnn;
            connetionString = @"data source = GNG; initial catalog = Mctrans; trusted_connection = true";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Mc_Price", cnn);
                command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // write the data on to the screen    
                        Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3} \t | {4}",
                            // call the objects from their index    
                            reader[0], reader[1], reader[2], reader[3], reader[4]));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("couldnt connect");
            }




            driver = new ChromeDriver();
            Thread.Sleep(50);
            driver.Navigate().GoToUrl("http://calculator.mctrans.ge/?fbclid=IwAR3zsudrbBgCGAfNnvWgEh2z9wqpKWKSPp6peY6_cQ6WwCjOypFc1vFfkjE");
            Thread.Sleep(200);

            var collections = driver.FindElement(By.XPath("//*[@id=\"myModal\"]/div/div/div[1]/a"));
            Thread.Sleep(50);
            //Console.WriteLine(collections);
            //collections.Submit();
            try
            {
                collections.Click();
            }
            catch { Console.WriteLine("something went wrong while loading"); }   
            Thread.Sleep(200);
            //collections.SendKeys("Webshop");
            //collections.Submit();

            var Auction = driver.FindElement(By.XPath("//*[@id=\"auc_id\"]"));
            Thread.Sleep(50);
            Auction.Click();
            Thread.Sleep(1000);
            var Id = 1;
            for (int i = 2; i < 10; i += 4)
            {
                try
                {
                    var Copart = driver.FindElement(By.XPath("//*[@id=\"auc_id\"]/option[" + i + "]"));
                    Thread.Sleep(50);
                    Copart.Click();
                    Thread.Sleep(1000);

                    var body = driver.FindElement(By.XPath("/html/body"));
                    Thread.Sleep(50);
                    body.Click();
                    Thread.Sleep(1000);

                    var State_city = driver.FindElement(By.XPath("//*[@id=\"city_id\"]"));
                    Thread.Sleep(50);
                    State_city.Click();
                    Thread.Sleep(1000);

                    for (int x = 2; x < 235; x += 1)
                    {
                        var AL_ANC = driver.FindElement(By.XPath("//*[@id=\"city_id\"]/option[" + x + "]"));
                        Thread.Sleep(50);
                        AL_ANC.Click();
                        Thread.Sleep(50);

                        body.Click();
                        Thread.Sleep(50);
                        var USA_p = driver.FindElement(By.XPath("//*[@id=\"port_id\"]"));
                        Thread.Sleep(50);
                        USA_p.Click();
                        Thread.Sleep(50);

                        for (int y = 2; y < 8; y++)
                        {

                            var nj = driver.FindElement(By.XPath("//*[@id=\"port_id\"]/option[" + y + "]"));
                            Thread.Sleep(50);
                            nj.Click();
                            Thread.Sleep(50);
                            var body1 = driver.FindElement(By.XPath("/html/body/div/div[1]"));
                            Thread.Sleep(50);
                            body1.Click();
                            Thread.Sleep(50);
                            var value = driver.FindElements(By.XPath("//*[@id=\"data3\"]"));
                            Thread.Sleep(50);
                            foreach (var item in value)
                            {
                                if (item.Text != "0 US$" && item.Text != "0US$")
                                {
                                    Console.Write(Copart.Text + "   ");
                                    Console.Write(AL_ANC.Text + "   ");
                                    Console.Write(nj.Text + "   -");
                                    Console.Write(item.Text + "\n");
                                    SqlCommand insertCommand = new SqlCommand("INSERT INTO Mc_Price (Id, Auction, State_City, USA_Port, Price) VALUES (@0, @1, @2, @3, @4)", cnn);
                                    SqlCommand cmd = new SqlCommand("sp_insert", cnn);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@Id", Id);
                                    cmd.Parameters.AddWithValue("@Auction", Copart.Text);
                                    cmd.Parameters.AddWithValue("@State_City", AL_ANC.Text);
                                    cmd.Parameters.AddWithValue("@USA_Port", nj.Text);
                                    cmd.Parameters.AddWithValue("@Price", item.Text);

                                    Id += 4;

                                    int z = cmd.ExecuteNonQuery();

                                }

                            }
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("something went wrong on 1 loop!");
                }
            }
        }

        // static method two
        public static void method2()
        {
            string connetionString = null;
            SqlConnection cnn;
            connetionString = @"data source = GNG; initial catalog = Mctrans; trusted_connection = true";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Mc_Price", cnn);
                command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // write the data on to the screen    
                        Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3} \t | {4}",
                            // call the objects from their index    
                            reader[0], reader[1], reader[2], reader[3], reader[4]));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("couldnt connect");
            }

            Thread.Sleep(50);
            driver = new ChromeDriver();
            Thread.Sleep(50);
            driver.Navigate().GoToUrl("http://calculator.mctrans.ge/?fbclid=IwAR3zsudrbBgCGAfNnvWgEh2z9wqpKWKSPp6peY6_cQ6WwCjOypFc1vFfkjE");
            Thread.Sleep(200);

            var collections = driver.FindElement(By.XPath("//*[@id=\"myModal\"]/div/div/div[1]/a"));
            Thread.Sleep(50);
            //Console.WriteLine(collections);
            //collections.Submit();
            try
            {
                collections.Click();
            }
            catch { Console.WriteLine("something went wrong while loading!"); }
            Thread.Sleep(200);
            //collections.SendKeys("Webshop");
            //collections.Submit();

            var Auction = driver.FindElement(By.XPath("//*[@id=\"auc_id\"]"));
            Thread.Sleep(50);
            Auction.Click();
            Thread.Sleep(1000);
            var Id = 2;
            for (int i = 3; i < 10; i+=4)
            {
                try
                {
                    var Copart = driver.FindElement(By.XPath("//*[@id=\"auc_id\"]/option[" + i + "]"));
                    Thread.Sleep(50);
                    Copart.Click();
                    Thread.Sleep(1000);

                    var body = driver.FindElement(By.XPath("/html/body"));
                    Thread.Sleep(50);
                    body.Click();
                    Thread.Sleep(1000);

                    var State_city = driver.FindElement(By.XPath("//*[@id=\"city_id\"]"));
                    Thread.Sleep(50);
                    State_city.Click();
                    Thread.Sleep(1000);

                    for (int x = 2; x < 235; x++)
                    {
                        var AL_ANC = driver.FindElement(By.XPath("//*[@id=\"city_id\"]/option[" + x + "]"));
                        Thread.Sleep(50);
                        AL_ANC.Click();
                        Thread.Sleep(50);

                        body.Click();
                        Thread.Sleep(50);
                        var USA_p = driver.FindElement(By.XPath("//*[@id=\"port_id\"]"));
                        Thread.Sleep(50);
                        USA_p.Click();
                        Thread.Sleep(50);

                        for (int y = 2; y < 8; y++)
                        {

                            var nj = driver.FindElement(By.XPath("//*[@id=\"port_id\"]/option[" + y + "]"));
                            Thread.Sleep(50);
                            nj.Click();
                            Thread.Sleep(50);
                            var body1 = driver.FindElement(By.XPath("/html/body/div/div[1]"));
                            Thread.Sleep(50);
                            body1.Click();

                            var value = driver.FindElements(By.XPath("//*[@id=\"data3\"]"));
                            Thread.Sleep(50);
                            foreach (var item in value)
                            {
                                if (item.Text != "0 US$" && item.Text != "0US$")
                                {
                                    Console.Write(Copart.Text + "   ");
                                    Console.Write(AL_ANC.Text + "   ");
                                    Console.Write(nj.Text + "   -");
                                    Console.Write(item.Text + "\n");
                                    SqlCommand insertCommand = new SqlCommand("INSERT INTO Mc_Price (Id, Auction, State_City, USA_Port, Price) VALUES (@0, @1, @2, @3, @4)", cnn);
                                    SqlCommand cmd = new SqlCommand("sp_insert", cnn);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@Id", Id);
                                    cmd.Parameters.AddWithValue("@Auction", Copart.Text);
                                    cmd.Parameters.AddWithValue("@State_City", AL_ANC.Text);
                                    cmd.Parameters.AddWithValue("@USA_Port", nj.Text);
                                    cmd.Parameters.AddWithValue("@Price", item.Text);
                                    Id += 4;
                                    int z = cmd.ExecuteNonQuery();


                                }
                            }
                        }
                    }
                }
                catch { Console.WriteLine("something went wrong on 2 loop!"); }
            }
        }


        // method 3
        public static void method3()
        {
            string connetionString = null;
            SqlConnection cnn;
            connetionString = @"data source = GNG; initial catalog = Mctrans; trusted_connection = true";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Mc_Price", cnn);
                command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // write the data on to the screen    
                        Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3} \t | {4}",
                            // call the objects from their index    
                            reader[0], reader[1], reader[2], reader[3], reader[4]));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("couldnt connect");
            }


            driver = new ChromeDriver();
            Thread.Sleep(50);
            driver.Navigate().GoToUrl("http://calculator.mctrans.ge/?fbclid=IwAR3zsudrbBgCGAfNnvWgEh2z9wqpKWKSPp6peY6_cQ6WwCjOypFc1vFfkjE");
            Thread.Sleep(200);

            var collections = driver.FindElement(By.XPath("//*[@id=\"myModal\"]/div/div/div[1]/a"));
            Thread.Sleep(50);
            //Console.WriteLine(collections);
            //collections.Submit();
            try
            {
                collections.Click();
            }
            catch { Console.WriteLine("something went wrong while loading!"); }
            Thread.Sleep(200);
            //collections.SendKeys("Webshop");
            //collections.Submit();

            var Auction = driver.FindElement(By.XPath("//*[@id=\"auc_id\"]"));
            Thread.Sleep(50);
            Auction.Click();
            Thread.Sleep(1000);
            var Id = 3;
            for (int i = 4; i < 10; i += 4)
            {
                try
                {
                    var Copart = driver.FindElement(By.XPath("//*[@id=\"auc_id\"]/option[" + i + "]"));
                    Thread.Sleep(50);
                    Copart.Click();
                    Thread.Sleep(1000);

                    var body = driver.FindElement(By.XPath("/html/body"));
                    Thread.Sleep(50);
                    body.Click();
                    Thread.Sleep(1000);

                    var State_city = driver.FindElement(By.XPath("//*[@id=\"city_id\"]"));
                    Thread.Sleep(50);
                    State_city.Click();
                    Thread.Sleep(1000);

                    for (int x = 2; x < 235; x++)
                    {
                        var AL_ANC = driver.FindElement(By.XPath("//*[@id=\"city_id\"]/option[" + x + "]"));
                        Thread.Sleep(50);
                        AL_ANC.Click();
                        Thread.Sleep(50);

                        body.Click();
                        Thread.Sleep(50);
                        var USA_p = driver.FindElement(By.XPath("//*[@id=\"port_id\"]"));
                        Thread.Sleep(50);
                        USA_p.Click();
                        Thread.Sleep(50);

                        for (int y = 2; y < 8; y++)
                        {

                            var nj = driver.FindElement(By.XPath("//*[@id=\"port_id\"]/option[" + y + "]"));
                            Thread.Sleep(50);
                            nj.Click();
                            Thread.Sleep(50);
                            var body1 = driver.FindElement(By.XPath("/html/body/div/div[1]"));
                            Thread.Sleep(50);
                            body1.Click();
                            Thread.Sleep(50);
                            var value = driver.FindElements(By.XPath("//*[@id=\"data3\"]"));
                            foreach (var item in value)
                            {
                                if (item.Text != "0 US$" && item.Text != "0US$")
                                {
                                    Console.Write(Copart.Text + "   ");
                                    Console.Write(AL_ANC.Text + "   ");
                                    Console.Write(nj.Text + "   -");
                                    Console.Write(item.Text + "\n");
                                    SqlCommand insertCommand = new SqlCommand("INSERT INTO Mc_Price (Id, Auction, State_City, USA_Port, Price) VALUES (@0, @1, @2, @3, @4)", cnn);
                                    SqlCommand cmd = new SqlCommand("sp_insert", cnn);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@Id", Id);
                                    cmd.Parameters.AddWithValue("@Auction", Copart.Text);
                                    cmd.Parameters.AddWithValue("@State_City", AL_ANC.Text);
                                    cmd.Parameters.AddWithValue("@USA_Port", nj.Text);
                                    cmd.Parameters.AddWithValue("@Price", item.Text);
                                    Id += 4;
                                    int z = cmd.ExecuteNonQuery();


                                }
                            }
                        }
                    }
                }
                catch { Console.WriteLine("something went wrong on 2 loop!"); }
            }
        }

        //method 4
        public static void method4()
        {
            string connetionString = null;
            SqlConnection cnn;
            connetionString = @"data source = GNG; initial catalog = Mctrans; trusted_connection = true";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Mc_Price", cnn);
                command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // write the data on to the screen    
                        Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3} \t | {4}",
                            // call the objects from their index    
                            reader[0], reader[1], reader[2], reader[3], reader[4]));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("couldnt connect");
            }


            driver = new ChromeDriver();

            Thread.Sleep(50);
            driver.Navigate().GoToUrl("http://calculator.mctrans.ge/?fbclid=IwAR3zsudrbBgCGAfNnvWgEh2z9wqpKWKSPp6peY6_cQ6WwCjOypFc1vFfkjE");
            Thread.Sleep(200);

            var collections = driver.FindElement(By.XPath("//*[@id=\"myModal\"]/div/div/div[1]/a"));
            Thread.Sleep(50);
            //Console.WriteLine(collections);
            //collections.Submit();
            try
            {
                collections.Click();
            }
            catch { Console.WriteLine("something went wrong while loading!"); }
            Thread.Sleep(200);
            //collections.SendKeys("Webshop");
            //collections.Submit();

            var Auction = driver.FindElement(By.XPath("//*[@id=\"auc_id\"]"));
            Thread.Sleep(50);
            Auction.Click();
            Thread.Sleep(1000);
            var Id = 4;
            for (int i = 5; i < 10; i += 4)
            {
                try
                {
                    var Copart = driver.FindElement(By.XPath("//*[@id=\"auc_id\"]/option[" + i + "]"));
                    Thread.Sleep(50);
                    Copart.Click();
                    Thread.Sleep(1000);

                    var body = driver.FindElement(By.XPath("/html/body"));
                    body.Click();
                    Thread.Sleep(1000);

                    var State_city = driver.FindElement(By.XPath("//*[@id=\"city_id\"]"));
                    Thread.Sleep(50);
                    State_city.Click();
                    Thread.Sleep(1000);

                    for (int x = 2; x < 235; x++)
                    {
                        var AL_ANC = driver.FindElement(By.XPath("//*[@id=\"city_id\"]/option[" + x + "]"));
                        Thread.Sleep(50);
                        AL_ANC.Click();
                        Thread.Sleep(50);

                        body.Click();
                        Thread.Sleep(50);
                        var USA_p = driver.FindElement(By.XPath("//*[@id=\"port_id\"]"));
                        Thread.Sleep(50);
                        USA_p.Click();


                        for (int y = 2; y < 8; y++)
                        {

                            var nj = driver.FindElement(By.XPath("//*[@id=\"port_id\"]/option[" + y + "]"));
                            Thread.Sleep(50);
                            nj.Click();
                            Thread.Sleep(50);
                            var body1 = driver.FindElement(By.XPath("/html/body/div/div[1]"));
                            Thread.Sleep(50);
                            body1.Click();
                            Thread.Sleep(50);
                            var value = driver.FindElements(By.XPath("//*[@id=\"data3\"]"));
                            Thread.Sleep(50);
                            foreach (var item in value)
                            {
                                if (item.Text != "0 US$" && item.Text != "0US$")
                                {
                                    Console.Write(Copart.Text + "   ");
                                    Console.Write(AL_ANC.Text + "   ");
                                    Console.Write(nj.Text + "   -");
                                    Console.Write(item.Text + "\n");
                                    SqlCommand insertCommand = new SqlCommand("INSERT INTO Mc_Price (Id, Auction, State_City, USA_Port, Price) VALUES (@0, @1, @2, @3, @4)", cnn);
                                    SqlCommand cmd = new SqlCommand("sp_insert", cnn);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@Id", Id);
                                    cmd.Parameters.AddWithValue("@Auction", Copart.Text);
                                    cmd.Parameters.AddWithValue("@State_City", AL_ANC.Text);
                                    cmd.Parameters.AddWithValue("@USA_Port", nj.Text);
                                    cmd.Parameters.AddWithValue("@Price", item.Text);
                                    Id += 4;
                                    int z = cmd.ExecuteNonQuery();


                                }
                            }
                        }
                    }
                }
                catch { Console.WriteLine("something went wrong on 2 loop!"); }
            }
        }
        static void ReadData()
        {
            string connetionString = null;
            SqlConnection cnn;
            connetionString = @"data source = GNG; initial catalog = Mctrans; trusted_connection = true";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Mc_Price", cnn);
                command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // write the data on to the screen    
                        Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3} \t | {4}",
                            // call the objects from their index    
                            reader[0], reader[1], reader[2], reader[3], reader[4]));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("couldnt connect");
            }
        }

        // Main Method
        static async Task Main()
        {
            Console.WriteLine("Do you want to Scrap Webpage?  (y/n) :");
            string Scrapweb = Console.ReadLine();

            if (Scrapweb == "y")
            {
                // Creating and initializing threads
                Thread thr1 = new Thread(method1);
                Thread thr2 = new Thread(method2);
                Thread thr3 = new Thread(method3);
                Thread thr4 = new Thread(method4);
                thr1.Start();
                thr2.Start();
                thr3.Start();
                thr4.Start();
            }

                Console.WriteLine("Do you want to display existing data in database?  (y/n) :");
                string Databaseread = Console.ReadLine();
            if (Databaseread == "y") {
                ReadData();
            }
            
            Console.WriteLine("Do you want to create graph?  (y/n) :");
            string Neo4jGraph = Console.ReadLine();


            if (Neo4jGraph == "y")
            {
                var driver = GraphDatabase.Driver("bolt://localhost:7687",
                               AuthTokens.Basic("GNG", "123456"));

                var cypherQuery =
                  @"
      MATCH (p:Product)-[:PART_OF]->(:Category)-[:PARENT*0..]->
      (:Category {categoryName:$category})
      RETURN p.productName as product
      ";

                var session = driver.AsyncSession(o => o.WithDatabase("neo4j"));
                var result = await session.ReadTransactionAsync(async tx =>
                {
                    var r = await tx.RunAsync(cypherQuery,
                            new { category = "Dairy Products" });
                    return await r.ToListAsync();
                });

                await session?.CloseAsync();
                foreach (var row in result)
                    Console.WriteLine(row["product"].As<string>());

                var cypherQuery3 = "MATCH (n)\r\nDETACH DELETE n";


                //hjguytfuygvhguikghiujguigiyukggigjkgviujkgujikgiukgigikghujgyugug
                string connetionString = null;
                SqlConnection cnn;
                connetionString = @"data source = GNG; initial catalog = Mctrans; trusted_connection = true";
                cnn = new SqlConnection(connetionString);
                try
                {
                    cnn.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Mc_Price", cnn);
                    command.ExecuteNonQuery();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // write the data on to the screen    
                            //Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3} \t | {4}",
                                // call the objects from their index    
                                //reader[0], reader[1], reader[2], reader[3], reader[4]));
                            var cypherQuery5 = @"CREATE (Auction:AuctionType {name: '" + reader[1] + @"'})
                                             CREATE (State_City:State_CityType {name: '" + reader[2] + @"'})
                                             CREATE (Usa_Port:Usa_PortType {name: '" + reader[3] + @"'})
                                             CREATE (Price:PriceType {name: '" + reader[4] + @"'})
                                             CREATE 
                                                  (Auction)-[:IS_AUCTION_FOR]->(State_City),
                                                  (State_City)-[:CAR_GOES_TO]->(Usa_Port),
                                                  (Usa_Port)-[:TRANSPORT_PRICE_IS]->(Price)";
                            var session2 = driver.AsyncSession(o => o.WithDatabase("neo4j"));
                            var result2 = await session2.WriteTransactionAsync(async tx =>
                            {
                                var r = await tx.RunAsync(cypherQuery5,
                                        new { category = "Dairy Products" });
                                return await r.ToListAsync();
                            });

                        }
                        Console.WriteLine("Grap is created");
                        Thread.Sleep(10000);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("couldnt connect");
                }

            }
            else
            {
                Console.WriteLine("Finished!");
                Thread.Sleep(10000);
            }



        }


    }

    }





