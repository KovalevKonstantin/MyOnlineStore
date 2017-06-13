using System.Linq;

//Detailed information about users.
public class UserInfoModel
{
    public UserInformation GetUserInformation(string guId)
    {
        var db = new OnlineShopDBEntities();
        var info = (from x in db.UserInformations
            where x.GUID == guId
            select x).FirstOrDefault();
        return info;
    }

    public void InsertUserInformation(UserInformation info)
    {
        var db = new OnlineShopDBEntities();
        db.UserInformations.Add(info);
        db.SaveChanges();
    }

    public void UpdateInformation(UserInformation info)
    {
        var db = new OnlineShopDBEntities();
        var u = db.UserInformations.Find(info.id);
        u.FirstName = info.FirstName;
        u.LastName = info.LastName;
        u.Address = info.Address;
        u.PostalCode = info.PostalCode;
        u.Phone = info.Phone;
        u.GUID = info.GUID;
        u.EmailAddress = info.EmailAddress;
        db.SaveChanges();
    }

    public int GetUserIDByGUID(string userGuid)
    {
        var db = new OnlineShopDBEntities();
        var userId = (from x in db.UserInformations where x.GUID == userGuid select x.id).FirstOrDefault();
        return userId;
    }
}