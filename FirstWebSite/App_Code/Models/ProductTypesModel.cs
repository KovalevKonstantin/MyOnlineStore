using System;

/// <summary>
///     Summary description for ProductTypeTypesModel
/// </summary>
public class ProductTypeTypesModel
{
    public string InsertProductType(ProductType producttype)
    {
        try
        {
            var db = new OnlineShopDBEntities();
            db.ProductTypes.Add(producttype);
            db.SaveChanges();

            return producttype.Type + " was successfully inserted.";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string UpdateProductType(int id, ProductType producttype)
    {
        try
        {
            var db = new OnlineShopDBEntities();

            // Fetch object from db
            var p = db.ProductTypes.Find(id);

            //Replace p with producttypes
            p.Type = producttype.Type;

            db.SaveChanges();
            return producttype.Type + " was successfully updated.";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string DeleteProductType(int id)
    {
        try
        {
            var db = new OnlineShopDBEntities();
            var p = db.ProductTypes.Find(id);

            db.ProductTypes.Attach(p);
            db.ProductTypes.Remove(p);
            db.SaveChanges();
            return p.Type + " was successfully removed.";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }
}