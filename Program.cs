using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    class Program
    {
    // UC1- Product Review Management
             
        static void Main(string[] args) //Main Method
        {

            List<ListOfProductReview> productReviewlist = new List<ListOfProductReview>()//Adding Data into the list
            {
               new ListOfProductReview() { ProductId = 1, UserId = 1, Rating = 3, Review = "Average", isLike = true }, 
               new ListOfProductReview() { ProductId = 2, UserId = 2, Rating = 2, Review = "Bad", isLike = false }, 
               new ListOfProductReview() { ProductId = 3, UserId = 3, Rating = 4, Review = "Nice", isLike = true }, 
               new ListOfProductReview() { ProductId = 4, UserId = 4, Rating = 5, Review = "Good", isLike = false }, 
               new ListOfProductReview() { ProductId = 5, UserId = 5, Rating = 6, Review = "Excelent", isLike = false }, 
               new ListOfProductReview() { ProductId = 6, UserId = 10, Rating = 4, Review = "Nice", isLike = true }, 
               new ListOfProductReview() { ProductId = 7, UserId = 6, Rating = 3, Review = "Average", isLike = true }, 
               new ListOfProductReview() { ProductId = 8, UserId = 5, Rating = 2, Review = "Bad", isLike = true },
               new ListOfProductReview() { ProductId = 9, UserId = 10, Rating = 5, Review = "Good", isLike = true }, 
               new ListOfProductReview() { ProductId = 10, UserId = 41, Rating = 6, Review = "Excelent", isLike = false }, 
               new ListOfProductReview() { ProductId = 11, UserId = 5, Rating = 4, Review = "Nice", isLike = false }, 
               new ListOfProductReview() { ProductId = 12, UserId = 4, Rating = 1, Review = "Very Bad", isLike = true },
               new ListOfProductReview() { ProductId = 13, UserId = 48, Rating = 0, Review = "Excelent", isLike = false }, 
               new ListOfProductReview() { ProductId = 14, UserId =41, Rating = 3, Review = "Average", isLike = true }, 
               new ListOfProductReview() { ProductId = 15, UserId = 51, Rating = 4, Review = "Nice", isLike = true }, 
               new ListOfProductReview() { ProductId = 16, UserId = 8, Rating = 1, Review = "Very Bad", isLike = false }, 
               new ListOfProductReview() { ProductId = 17, UserId = 18, Rating = 6, Review = "Excelent", isLike = true }, 
               new ListOfProductReview() { ProductId = 18, UserId = 9, Rating = 5, Review = "Good", isLike = true }, 
               new ListOfProductReview() { ProductId = 19, UserId = 10, Rating = 4, Review = "Nice", isLike = false },
               new ListOfProductReview() { ProductId = 20, UserId = 7, Rating = 3, Review = "Average", isLike = true }, 
               new ListOfProductReview() { ProductId = 21, UserId = 6, Rating = 2, Review = "Bad", isLike = true }, 
               new ListOfProductReview() { ProductId = 22, UserId = 5, Rating = 1, Review = "Very Bad", isLike = false }, 
               new ListOfProductReview() { ProductId = 23, UserId = 10, Rating = 5, Review = "Good", isLike = false },
               new ListOfProductReview() { ProductId = 24, UserId = 8, Rating = 2, Review = "Bad", isLike = true }, 
               new ListOfProductReview() { ProductId = 25, UserId = 12, Rating = 3, Review = "Average", isLike = false }, 
              
            };
            //CreateDataTable(); // Class Program

            //IterateProductReview(); //UC1
            //RetrieveTop3Records(productReviewlist); //UC2
            //RetrieveRecordsWithGreaterThan3Rating(productReviewlist);//UC3
            //RetrieveCountOfReviewPresentForEachProductId(productReviewlist);//UC4
            //RetrieveOnlyProductIDAndReviewOfAllRecords(productReviewlist);//UC5
            SkipTopFiveRecords(productReviewlist);
            Console.ReadLine();
        }

        public static void IterateProductReview(List<ListOfProductReview> productReviewlist)
        {
            foreach (ListOfProductReview list in productReviewlist) //ptint list item
            {
                Console.WriteLine($"ProductId:- {list.ProductId}   || UserId:- {list.UserId}   || Rating:- {list.Rating}   || Review:- {list.Review }   ||   IsLike:- {list.isLike }"); //Print data
            }
        }
        // UC2:Retrieve top 3 records from the list who’s rating is high using LINQ.
            
        public static void RetrieveTop3Records(List<ListOfProductReview> productReviewlist)
        {
            //Query syntax for LINQ
            var result = (from products in productReviewlist
                          orderby products.Rating descending
                          select products).Take(3);
            foreach (var elements in result)
            {
                Console.WriteLine($"ProductId:- {elements.ProductId} UserId:- {elements.UserId} Rating:- {elements.Rating} Review:- {elements.Review} isLike:- {elements.isLike}");
            }

        }
        //UC3: - Retrieve all record from the list who’s rating are greater then 3 and productID is 1 or 4 or 9 using LINQ.
                     
        public static void RetrieveRecordsWithGreaterThan3Rating(List<ListOfProductReview> productReviewlist)
        {           //Query syntax for LINQ 
            var RecordedData = (from productReviews in productReviewlist
                                where (productReviews.ProductId == 1 || productReviews.ProductId == 4 || productReviews.ProductId == 9)
                                && productReviews.Rating > 3
                                select productReviews);
            Console.WriteLine("\nProducts with Rating Greater than 3 and productID = 1 or 4 or 9 are:- ");
            foreach (var List in RecordedData)
            {
                Console.WriteLine($"ProductId:- {List.ProductId}   || UserId:- {List.UserId}   || Rating:- {List.Rating}   || Review:- {List.Review }   ||   IsLike:- {List.isLike }"); //Print data
            }
        }
        // UC4:Retrieve count of review present for each productID.
        
        public static void RetrieveCountOfReviewPresentForEachProductId(List<ListOfProductReview> productReviewlist)
        {
            var RecordedData = (productReviewlist.GroupBy(p => p.ProductId).Select(x => new { ProductId = x.Key, Count = x.Count() }));
            Console.WriteLine("\n Count group by ProductId");
            foreach (var List in RecordedData)
            {
                Console.WriteLine($"ProductId:- {List.ProductId}   || Count :- {List.Count}"); //Print data
            }
        }
        // UC5: Retrieve only productId and review from the list for all Records. 
               
        public static void RetrieveOnlyProductIDAndReviewOfAllRecords(List<ListOfProductReview> productReviewlist)
        {
            try
            {
                //Query syntax for LINQ 
                var RecordedData = (from products in productReviewlist
                                    select new { ProductId = products.ProductId, Review = products.Review });
                Console.WriteLine("Retrieving Product and Review from list:-");
                foreach (var productReview in RecordedData) //traversing each items
                {
                    Console.WriteLine($"ProductID:-   {productReview.ProductId}  \t Review:-   { productReview.Review}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // UC6:Skip top 5 records from the list using LINQ and display other Records.


        public static void SkipTopFiveRecords(List<ListOfProductReview> productReviewlist)
        {
            try
            {
                var RecordedData = (from products in productReviewlist
                                    select products).Skip(5);
                Console.WriteLine("\n Skiping the Top five records and Display others ");
                foreach (var productReview in RecordedData) //traversing each items
                {
                    Console.WriteLine($"ProductId:- {productReview.ProductId}\tUserId:- {productReview.UserId}\tRating:- {productReview.Rating}\t  Review:- {productReview.Review}  \t    isLike:- {productReview.isLike}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //UC7:- Retrieve only productId and review from the list for all records using LINQ select operator.


        public static void RetrieveProductIDAndReviewUsingLambdaSyntax(List<ListOfProductReview> productReviewlist)
        {
            try
            {                // Query syntax for LINQ 
                var RecordedData = productReviewlist.Select(reviews => new { ProductId = reviews.ProductId, Review = reviews.Review });
                Console.WriteLine("\nRetrieving Product and Review from list");
                foreach (var productReview in RecordedData) //traversing each items
                {
                    Console.WriteLine($"ProductId:- {productReview.ProductId}\tReview:- {productReview.Review}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void CreateDataTable() //create method
        {
            DataTable table = new DataTable(); //create table and create object
            table.Columns.Add("ProductId");     // add Columns in table
            table.Columns.Add("ProductName"); // add Columns in table

            table.Rows.Add("1", "Laptop"); //add rows on table
            table.Rows.Add("2", "Mobile");
            table.Rows.Add("3", "Tablet");
            table.Rows.Add("4", "Desktop");
            table.Rows.Add("5", "Watch");
            DisplayTableProduct(table);

        }
            
        public static void DisplayTableProduct(DataTable table) //Create DisplayTableProduct method
        {
            var Productname = from product in table.AsEnumerable() select product.Field<string>("ProductName"); //Fetch Product of the table
            foreach (var item in Productname) //iiterate 
            {
                Console.WriteLine($"ProductName:- {item}"); //print 
            }
        }
    }
}