using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
///     Summary description for BinModel
/// </summary>
public class BinModel
{
    public string InsertBin(Bin bin)
    {
        try
        {
            var db = new OnlineShopDBEntities();
            db.Bins.Add(bin);
            db.SaveChanges();

            return bin.DatePurchase + " was successfully inserted.";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string UpdateBin(int id, Bin bin)
    {
        try
        {
            var db = new OnlineShopDBEntities();

            // Fetch object from db
            var p = db.Bins.Find(id);

            //Replace p with bins
            p.DatePurchase = bin.DatePurchase;
            p.ProductID = bin.ProductID;
            p.Quantity = bin.Quantity;
            p.ClientID = bin.ClientID;
            p.IsInBin = bin.IsInBin;

            db.SaveChanges();
            return bin.DatePurchase + " was successfully updated.";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string DeleteBin(int id)
    {
        try
        {
            var db = new OnlineShopDBEntities();
            var p = db.Bins.Find(id);

            db.Bins.Attach(p);
            db.Bins.Remove(p);
            db.SaveChanges();
            return p.DatePurchase + " was successfully removed.";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    //get list of purchases for the given buyer
    public List<Bin> GetOrdersInBin(string userId)
    {
        var db = new OnlineShopDBEntities();
        var purchases = (from x in db.Bins
            where (x.ClientID == userId)
                  && x.IsInBin
            orderby x.DatePurchase
            select x).ToList();

        return purchases;
    }

    //get number of purchases for the given buyer
    public int GetAmountOfPurchases(string userId)
    {
        try
        {
            var db = new OnlineShopDBEntities();
            var amount = (from x in db.Bins
                where (x.ClientID == userId)
                      && x.IsInBin
                select x.Quantity).Sum();
            return amount;
        }
        catch
        {
            return 0;
        }
    }

    //update purchases quantity
    public void UpdateQuantity(int id, int quantity)
    {
        var db = new OnlineShopDBEntities();
        var bin = db.Bins.Find(id);
        bin.Quantity = quantity;

        db.SaveChanges();
    }

    //mark purchase a a payd one
    public void MarkPurchaseAsPayd(List<Bin> bins)
    {
        var db = new OnlineShopDBEntities();
        if (bins != null)
        {
            foreach (var bin in bins)
            {
                var oldBin = db.Bins.Find(bin.ID);
                oldBin.DatePurchase = DateTime.Now;
                oldBin.IsInBin = false;
            }

            db.SaveChanges();
        }
    }
}