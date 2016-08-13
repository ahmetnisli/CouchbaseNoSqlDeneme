using Couchbase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouchbaseNOSqlDeneme
{
    class Program
    {
        static Cluster smallCluster;

        static void Main(string[] args)

        {

            smallCluster = new Cluster();



            using (var bucket = smallCluster.OpenBucket())
            {
                var document = new Document<dynamic>
                {
                    Id = "deneme",
                    Content = new List<Product>

                     {

                         new Product{ ID=1, Title="Fi", Price=20},

                         new Product{ID=2, Title="Çi", Price=15},

                         new Product{ID=3, Title="Pi", Price=30},

                         new Product{ID=4, Title="Ruby on Rails", Price=40},

                         new Product{ID=5, Title="C# Advanced",Price=45}

                     }
                };

                var upsert = bucket.Upsert(document);
                if (upsert.Success)
                {
                    var get = bucket.GetDocument<dynamic>(document.Id);
                    document = get.Document;
                    var msg = string.Format("{0} {1}!", document.Id,document.Content);
                    Console.WriteLine(msg);
                }
                else
                {
                    Console.WriteLine("dsadsadsads");
                }
                Console.Read();
            }
        }

    }

    public class Product

    {

        public int ID { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }



    }
}

