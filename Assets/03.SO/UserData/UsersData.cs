[System.Serializable]
public class UsersData
{
   public string userName;
   public int money;
   public int balance;
   public string hashedPassword;
   public string userId;

   public UsersData()
   {
      userId = "";
      userName = "DefaultUser";
      money = 0;
      balance = 0;
      hashedPassword = "";
   }


   public UsersData(string userName, int money, int balance, string userId, string hashedPassword)
   {
      this.userName = userName;
      this.money = money;
      this.balance = balance;
      this.hashedPassword = hashedPassword;
   }
}