[System.Serializable]
public class UsersData
{
   public string userName;
   public int money;
   public int balance;

   public UsersData()
   
      {
         userName = "DefaultUser";
         money = 0;
         balance = 0;
      }
   

   public UsersData(string userName, int money, int balance)
   {
      this.userName = userName;
      this.money = money;
      this.balance = balance;
   }
}