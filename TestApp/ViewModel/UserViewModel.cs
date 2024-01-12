using CommunityToolkit.Mvvm.ComponentModel;

namespace TestApp.ViewModel
{
    public class UserViewModel : ObservableObject
    {
        public UserViewModel()
        {
            Users = new List<UserData>();
            InitUserData();
        }
        public List<UserData> Users { get; set; }

        void InitUserData()
        {
            for (int i = 1; i <= 10; i++)
            {
                UserData user = new UserData()
                {
                    ID = i,
                    FullName = "Nghinh Thu",
                    UserName = "nghinhthu",
                    ImageUrl = "logomsa.jpg"
                };
                Users.Add(user);
            }
        }
    }
}
