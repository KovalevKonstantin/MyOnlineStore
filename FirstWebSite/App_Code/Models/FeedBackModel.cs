using System;
using System.Linq;
using System.Web;

/// <summary>
///     Summary description for FeedBackModel
/// </summary>
public class FeedBackModel
{
    public string InsertFeedBack(FeedBack feedback)
    {
        try
        {
            var db = new OnlineShopDBEntities();
            db.FeedBacks.Add(feedback);
            db.SaveChanges();

            return "Feedback from " + HttpContext.Current.User.Identity.Name + " was successfully inserted!";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string UpdateFeedback(int id, FeedBack feedback)
    {
        try
        {
            var db = new OnlineShopDBEntities();

            // Fetch object from db
            var fb = db.FeedBacks.Find(id);

            //Replace p with bins
            fb.Checked = feedback.Checked;
            fb.Comments = feedback.Comments;
            fb.Date = feedback.Date;
            fb.FeedBack1 = feedback.FeedBack1;
            fb.UserID = feedback.UserID;

            db.SaveChanges();
            var email =
                (from x in db.UserInformations where x.id == feedback.UserID select x.EmailAddress).FirstOrDefault();
            return "Feedback from " + email + " was successfully updated.";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string DeleteFeedback(int id)
    {
        try
        {
            var db = new OnlineShopDBEntities();
            var fb = db.FeedBacks.Find(id);

            db.FeedBacks.Attach(fb);
            db.FeedBacks.Remove(fb);
            db.SaveChanges();
            var email = (from x in db.UserInformations where x.id == fb.UserID select x.EmailAddress).FirstOrDefault();
            return "Feedback from " + email + " was successfully removed.";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public void MarkFeedbackAsChecked(int id)
    {
        var db = new OnlineShopDBEntities();
        var fb = db.FeedBacks.Find(id);
        fb.Checked = true;
        db.SaveChanges();
    }
}