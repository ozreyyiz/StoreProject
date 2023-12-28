// See https://aka.ms/new-console-template for more information


using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

//ProductTest();

CategoryManager categoryManager=new CategoryManager(new EfCategoryDal());

//foreach (var category in categoryManager.GetAll())
//{
//    Console.WriteLine(category.CategoryName);
//}


//var a = categoryManager.GetById(2);
//Console.WriteLine(a.CategoryName);

ProductTest();

static void ProductTest()
{
    ProductManager productManager = new ProductManager(new EfProductDal());

    var result = productManager.GetProductsDetail();

    if (result.Success)
    {
        foreach (var product in productManager.GetProductsDetail().Data)
        {
            Console.WriteLine(product.ProductName + " / " + product.CategoryName);
        }
    }

    else
    {
        Console.WriteLine(result.Message);
    }

   
}

