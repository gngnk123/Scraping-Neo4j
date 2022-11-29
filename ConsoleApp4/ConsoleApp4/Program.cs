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

        // Main Method
        static public void Main()
        {


            var client = new GraphClient(new Uri("http://localhost:7474"), "GNG", "123456");

            try
            {
                client.ConnectAsync();
            }
            catch { Console.WriteLine("could not made connection to neo4j!"); }



            var query = @"MATCH (p:Person) WHERE toUpper(p.name) CONTAINS toUpper($searchString) 
                                RETURN p{ name: p.name, born: p.born } ORDER BY p.Name LIMIT 5";
         
            Console.WriteLine(query);

            //var createQuery = client.Cypher
            //    .Create("(j:Book {Title: 'Test', PageCount:250})<-[re1:HAS_BOOK]-(m:Person {Name: 'John Doe'})")
            //    .Return((j, m) => new
            //    {
            //        Book = j.As<Book>(),
            //        Person = m.As<Person>()
            //    }).ResultsAsync;
            //foreach(var item in createQuery)
            //{
            //    Console.WriteLine(item.Book.Title);
            //}
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

    }


 
    //public class HelloWorldExample: IDisposable
    //{
    //    private readonly IDriver _driver;
    //    public HelloWorldExample(string uri, string userName, string password)
    //    {
    //        _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(userName, password));
    //    }

    //    public void PrintGreeting(string message)
    //    {
    //        using var session = _driver.Session();
    //        var greeting = session.WriteTransaction(tx =>
    //        {
    //            var result = tx.Run("CREATE (a:Greeting) " +
    //                "SET a.message = $message " +
    //                "RETURN a.message + ', from node ' + id(a)",
    //                new { message });
    //            return result.Single()[0].As< string > ();
    //        });
    //        Console.WriteLine(greeting);
    //    }
    //    public void Dispose()
    //    {
    //        _driver.Dispose();
    //    }
    //}


    //public class Program
    //{
    //    private static IWebDriver driver;
    //    static public void Main(string[] args)
    //    {


    //        string connetionString = null;
    //        SqlConnection cnn;
    //        connetionString = @"data source = GNG; initial catalog = Mctrans; trusted_connection = true";
    //        cnn = new SqlConnection(connetionString);
    //        try
    //        {
    //            cnn.Open();
    //            SqlCommand command = new SqlCommand("SELECT * FROM Mc_Price", cnn);
    //            command.ExecuteNonQuery();
    //            using (SqlDataReader reader = command.ExecuteReader())
    //            {
    //                while (reader.Read())
    //                {
    //                     write the data on to the screen    
    //                    Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3} \t | {4}",
    //                         call the objects from their index    
    //                        reader[0], reader[1], reader[2], reader[3], reader[4]));
    //                }
    //            }

    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine("couldnt connect");
    //        }


    //         Creating and initializing threads
    //        Thread thr1 = new Thread(scraper1);
    //        Thread thr2 = new Thread(scraper2);
    //        thr1.Start();
    //        thr2.Start();


    //        driver = new ChromeDriver();
    //        driver.Navigate().GoToUrl("http://calculator.mctrans.ge/?fbclid=IwAR3zsudrbBgCGAfNnvWgEh2z9wqpKWKSPp6peY6_cQ6WwCjOypFc1vFfkjE");
    //        Thread.Sleep(2000);

    //        var collections = driver.FindElement(By.XPath("//*[@id=\"myModal\"]/div/div/div[1]/a"));
    //        Console.WriteLine(collections);
    //        collections.Submit();
    //        collections.Click();
    //        Thread.Sleep(2000);
    //        collections.SendKeys("Webshop");
    //        collections.Submit();

    //        var Auction = driver.FindElement(By.XPath("//*[@id=\"auc_id\"]"));
    //        Auction.Click();
    //        Thread.Sleep(1000);
    //        for (int i = 2; i < 10; i++)
    //        {
    //            var Copart = driver.FindElement(By.XPath("//*[@id=\"auc_id\"]/option[" + i + "]"));

    //            Copart.Click();
    //            Thread.Sleep(1000);

    //            var body = driver.FindElement(By.XPath("/html/body"));
    //            body.Click();
    //            Thread.Sleep(1000);

    //            var State_city = driver.FindElement(By.XPath("//*[@id=\"city_id\"]"));
    //            State_city.Click();
    //            Thread.Sleep(1000);

    //            for (int x = 2; x < 235; x++)
    //            {
    //                var AL_ANC = driver.FindElement(By.XPath("//*[@id=\"city_id\"]/option[" + x + "]"));

    //                AL_ANC.Click();


    //                body.Click();

    //                var USA_p = driver.FindElement(By.XPath("//*[@id=\"port_id\"]"));
    //                USA_p.Click();


    //                for (int y = 2; y < 8; y++)
    //                {

    //                    var nj = driver.FindElement(By.XPath("//*[@id=\"port_id\"]/option[" + y + "]"));

    //                    nj.Click();

    //                    var body1 = driver.FindElement(By.XPath("/html/body/div/div[1]"));
    //                    body1.Click();

    //                    var value = driver.FindElements(By.XPath("//*[@id=\"data3\"]"));
    //                    foreach (var item in value)
    //                    {
    //                        if (item.Text != "0 US$" && item.Text != "0US$")
    //                        {
    //                            Console.Write(Copart.Text + "   ");
    //                            Console.Write(AL_ANC.Text + "   ");
    //                            Console.Write(nj.Text + "   -");
    //                            Console.Write(item.Text + "\n");
    //                            SqlCommand insertCommand = new SqlCommand("INSERT INTO Mc_Price (Id, Auction, State_City, USA_Port, Price) VALUES (@0, @1, @2, @3, @4)", cnn);
    //                            SqlCommand cmd = new SqlCommand("sp_insert", cnn);
    //                            cmd.CommandType = CommandType.StoredProcedure;
    //                            cmd.Parameters.AddWithValue("@Id", i);
    //                            cmd.Parameters.AddWithValue("@Auction", Copart.Text);
    //                            cmd.Parameters.AddWithValue("@State_City", AL_ANC.Text);
    //                            cmd.Parameters.AddWithValue("@USA_Port", nj.Text);
    //                            cmd.Parameters.AddWithValue("@Price", item.Text);

    //                            int z = cmd.ExecuteNonQuery();


    //                        }
    //                    }
    //                }
    //            }
    //        }

    //    }

    //}


}



