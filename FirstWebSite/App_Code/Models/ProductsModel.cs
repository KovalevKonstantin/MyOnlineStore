using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
///     Summary description for ProductsModel
/// </summary>
public class ProductsModel
{
    public string InsertProduct(Product product)
    {
        try
        {
            var db = new OnlineShopDBEntities();
            db.Products.Add(product);
            db.SaveChanges();

            return product.ProductName + " was successfully inserted.";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string UpdateProduct(int id, Product product)
    {
        try
        {
            var db = new OnlineShopDBEntities();

            // Fetch object from db
            var p = db.Products.Find(id);

            //Replace p with products
            p.ProductName = product.ProductName;
            p.ProductPrice = product.ProductPrice;
            p.ProductTypeID = product.ProductTypeID;
            p.ProductDescription = product.ProductDescription;
            p.ProductImage = product.ProductImage;
            p.SellerID = product.SellerID;

            db.SaveChanges();
            return product.ProductName + " was successfully updated.";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string DeleteProduct(int id)
    {
        try
        {
            var db = new OnlineShopDBEntities();
            var p = db.Products.Find(id);

            db.Products.Attach(p);
            db.Products.Remove(p);
            db.SaveChanges();
            return p.ProductName + " was successfully removed.";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public Product GetProduct(int id)
    {
        try
        {
            using (var db = new OnlineShopDBEntities())
            {
                var p = db.Products.Find(id);
                return p;
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    public List<Product> GetAllProducts()
    {
        try
        {
            using (var db = new OnlineShopDBEntities())
            {
                var p = (from x in db.Products select x).ToList();
                return p;
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    public List<Product> GetProductByType(int typeId)
    {
        try
        {
            using (var db = new OnlineShopDBEntities())
            {
                var p = (from x in db.Products where x.ProductTypeID == typeId select x).ToList();
                return p;
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    public List<Product> GetProductsBySeller(string userGuid)
    {
        var db = new OnlineShopDBEntities();
        var userId = (from x in db.UserInformations where x.GUID == userGuid select x.id).FirstOrDefault();
        var products = (from x in db.Products where x.SellerID == userId orderby x.ProductName select x).ToList();

        return products;
    }

    public int GetSellerIDByProductID(int productId)
    {
        var db = new OnlineShopDBEntities();
        var p = db.Products.Find(productId);
        return (from x in db.UserInformations where x.id == p.SellerID select x.id).FirstOrDefault();
    }
}