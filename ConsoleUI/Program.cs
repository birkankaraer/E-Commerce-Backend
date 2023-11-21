// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

internal class Program
{
    //SOLID 
    //Open Closed Principle
    private static void Main(string[] args)
    {
        //ProductTest();
        //CategoryTest();
        //ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));

        //var result = productManager.GetProductDetails();
        //if (result.Success==true)
        //{
        //    foreach (var product in result.Data)
        //    {
        //        Console.WriteLine(product.ProductName + "/" + product.CategoryName);
        //    }
        //}
        //else { Console.WriteLine(result.Message); }

        //FizzBuzzer();
        //FakHesap();

    }

    private static void CategoryTest()
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        foreach (var category in categoryManager.GetAll().Data)
        {
            Console.WriteLine(category.CategoryName);
        }
    }

    private static void ProductTest()
    {
        ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));
        foreach (var product in productManager.GetProductDetails().Data)
        {
            Console.WriteLine(product.ProductName+"/"+product.CategoryName);
        }
    }

    public static void FizzBuzzer()
    {
        for(int i = 0; i <=100; i++)
        {
            if(i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if(i % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if(i % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(i);
            }
        }
    } 
    public static void FakHesap()
    {
        int sayi = 5;
        long fak = fakHesapla(sayi);

        Console.WriteLine($"{sayi} sayısının faktöriyeli: {fak}");


    }
    static long fakHesapla(int n)
    {
        if(n == 0|| n == 1)
        {
            return 1;
        }
        else
        {
            return n * fakHesapla(n - 1);
        }
    }
}