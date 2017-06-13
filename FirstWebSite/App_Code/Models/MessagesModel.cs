using System;
using System.Linq;

/// <summary>
///     Summary description for MessagesModel
/// </summary>
public class MessagesModel
{
    public string InsertMessage(Message ms)
    {
        try
        {
            var db = new OnlineShopDBEntities();
            db.Messages.Add(ms);
            db.SaveChanges();

            return "Message was added successfully!";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string UpdateMessage(int id, Message message)
    {
        try
        {
            var db = new OnlineShopDBEntities();

            // Fetch object from db
            var ms = db.Messages.Find(id);

            //Replace p with bins
            ms.Checked = message.Checked;
            ms.Comments = message.Comments;
            ms.Date = message.Date;
            ms.FeedBack = message.FeedBack;
            ms.UserID = message.UserID;

            db.SaveChanges();
            return "Message was updated successfully.";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string DeleteMessage(int id)
    {
        try
        {
            var db = new OnlineShopDBEntities();
            var ms = db.Messages.Find(id);

            db.Messages.Attach(ms);
            db.Messages.Remove(ms);
            db.SaveChanges();
            var email = (from x in db.UserInformations where x.id == ms.UserID select x.EmailAddress).FirstOrDefault();
            return "Feedback from " + email + " was successfully removed.";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public void MarkMessageAsChecked(int id)
    {
        var db = new OnlineShopDBEntities();
        var ms = db.Messages.Find(id);
        ms.Checked = true;
        db.SaveChanges();
    }
}