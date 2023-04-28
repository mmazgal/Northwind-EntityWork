using EntityWork;

namespace EntityWork
{
    public class Program
    {
        static void Main(string[] args)
        {
            GetAllData();
            GetData();
            GetCountryCustoData("New York");
            GetId(1);
            GetLastProduct();
            GetProductPrice();
            GetAvUnitPrice(1);
            HowManyProduct();
            Price();
            GetByTea();
            HighLow();
        }
        static void GetAllData()
        {
            using (var context = new DBFirstContext())
            {
                var custo = context.Customers.ToList();

                foreach (var e in custo)
                {
                    Console.WriteLine($"CompanyName: {e.CompanyName} ContactName: {e.ContactName} ContactTitle: {e.ContactTitle} Address: {e.Address} " +
                        $"City: {e.City} Region: {e.Region} PostalCode: {e.PostalCode} Country: {e.Country} Phone: {e.Phone} Fax: {e.Fax}");
                }
            }
        }
        static void GetData()
        {
            using (var context = new DBFirstContext())
            {
                var custo = context.Customers.ToList();

                foreach (var e in custo)
                {
                    Console.WriteLine($"CompanyName: {e.CompanyName} ContactName: {e.ContactName}");
                }
            }
        }
        static void GetCountryCustoData(string city)
        {
            using (var context = new DBFirstContext())
            {
                var custo = context.Customers.Where(e => e.City == city).OrderBy(e => e.CompanyName).ToList();

                foreach (var e in custo)
                {
                    Console.WriteLine($"CompanyName: {e.CompanyName} City: {e.City}");
                }
            }
        }
        static void GetId(int id)
        {
            using (var context = new DBFirstContext())
            {
                var pd = context.Products.Where(e => e.CategoryId == id).ToList();

                foreach (var e in pd)
                {
                    Console.WriteLine($"Name: {e.ProductName}");
                }
            }
        }
        static void GetLastProduct()
        {
            using (var context = new DBFirstContext())
            {
                int num = context.Products.Count();
                var pd = context.Products.OrderBy(e => e.ProductId).Skip(num - 5).Take(5).ToList();

                foreach (var e in pd)
                {
                    Console.WriteLine($"Name: {e.ProductName}");
                }
            }
        }
        static void GetProductPrice()
        {
            using (var context = new DBFirstContext())
            {
                var pd = context.Products.Where(e => e.UnitPrice >= 10 && e.UnitPrice <= 30).OrderByDescending(e => e.UnitPrice);

                foreach (var e in pd)
                {
                    Console.WriteLine($"CompanyName: {e.ProductName} UnitPrice: {e.UnitPrice}");
                }
            }
        }
        static void GetAvUnitPrice(int id)
        {
            using (var context = new DBFirstContext())
            {
                var pd = context.Products.Where(e => e.CategoryId == id).Average(e => e.UnitPrice);

                Console.WriteLine("Ortalama:" + pd);
            }
        }
        static void HowManyProduct()
        {
            using (var context = new DBFirstContext())
            {
                var pd = context.Products.Where(e => e.CategoryId == 1).Count();
                Console.WriteLine(pd);
            }
        }
        static void Price()
        {
            using (var context = new DBFirstContext())
            {
                var pd = context.Products.Where(p => p.CategoryId == 1 || p.CategoryId == 2).Sum(p => p.UnitPrice);
                Console.WriteLine("Ürün ortalama:" + pd);
            }
        }
        static void GetByTea()
        {
            using (var context = new DBFirstContext())
            {
                var pd = context.Products.Where(e => e.ProductName.Contains("Tea")).Select(e => e.ProductName);

                foreach (var e in pd)
                {
                    Console.WriteLine(e);
                }
            }
        }
        static void HighLow()
        {
            using (var context = new DBFirstContext())
            {
                /*var maxPrice = db.Products.Max(p => p.UnitPrice);
                  var productName = db.Products.Where(p => p.UnitPrice == maxPrice).Select(p => p.ProductName).FirstOrDefault();

                  Console.WriteLine("En pahalı: "+productName+"Ürün fiyat: "+maxPrice);

                  var MinPrice = db.Products.Min(p => p.UnitPrice);
                  var Productnames = db.Products.Where(p => p.UnitPrice == MinPrice).Select(p => p.ProductName).FirstOrDefault();

                  Console.WriteLine("En ucuz: "+Productnames+"Ürün fiyatı: "+MinPrice);*/

                var max = context.Products.Where(p => p.UnitPrice == context.Products.Max(p => p.UnitPrice)).Select(p => new { p.ProductName, p.UnitPrice }).FirstOrDefault();

                Console.WriteLine($"En pahalı1:{max.ProductName} Fiyat:{max.UnitPrice}");

                var min = context.Products.Where(p => p.UnitPrice == context.Products.Min(p => p.UnitPrice)).Select(p => new { p.ProductName, p.UnitPrice }).FirstOrDefault();

                Console.WriteLine($"En pahalı1:{min.ProductName} Fiyat:{min.UnitPrice}");
            }
        }
    }
}