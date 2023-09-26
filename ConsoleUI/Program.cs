﻿// See https://aka.ms/new-console-template for more information
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
        ProductManager productManager = new ProductManager(new EfProductDal());

        var result = productManager.GetProductDetails();
        if (result.Success==true)
        {
            foreach (var product in result.Data)
            {
                Console.WriteLine(product.ProductName + "/" + product.CategoryName);
            }
        }
        else { Console.WriteLine(result.Message); }
    }

    private static void CategoryTest()
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        foreach (var category in categoryManager.GetAll())
        {
            Console.WriteLine(category.CategoryName);
        }
    }

    private static void ProductTest()
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        foreach (var product in productManager.GetProductDetails().Data)
        {
            Console.WriteLine(product.ProductName+"/"+product.CategoryName);
        }
    }
}