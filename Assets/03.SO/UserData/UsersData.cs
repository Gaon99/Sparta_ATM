[System.Serializable]
public class UsersData
{
   public string userName;
   public int money; //[HideinInspector]
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

   public UsersData(string userName, string userId, string hashedPassword)
   {
      this.userId = userId;
      this.userName = userName;
      this.hashedPassword = hashedPassword;
      money = 100000; // 초기 자금 설정 (예시)
      balance = 0;
   }
}