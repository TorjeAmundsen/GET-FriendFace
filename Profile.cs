namespace FriendFace
{
    internal class Profile
    {
        private string _firstName;
        private string _lastName;
        private string _residence;
        private int _age;
        private string _gender;
        private List<Profile> _friendList;
        private string _username;

        public Profile(string username, string firstName, string lastName, string residence, int age, string gender)
        {
            _firstName = firstName;
            _lastName = lastName;
            _residence = residence;
            _age = age;
            _gender = gender;
            _username = username;
            _friendList = new List<Profile>();
        }

        public string GetFirstName() { return _firstName; }
        public string GetLastName() { return _lastName; }
        public string GetFullName() { return $"{_firstName} {_lastName}"; }
        public string GetGender() { return _gender; }
        public int GetAge() { return _age; }
        public string GetResidence() { return _residence; }
        public string GetUsername() { return _username; }
        public List<Profile> GetFriends() { return _friendList;  }
        public string GetNameAndUsername() { return $"{_firstName} {_lastName} (@{_username})"; }
        public int GetFriendCount() { return _friendList.Count; }


        public void AddFriend(Profile newFriend)
        {
            foreach (var friend in _friendList)
            {
                if (friend == newFriend)
                {
                    Console.WriteLine($"You are already friends with {newFriend.GetFullName()}!");
                    return;
                }
            }
            _friendList.Add(newFriend);
            Console.WriteLine($"Successfully added {newFriend.GetFullName()} (@{newFriend.GetUsername()}) as a friend!");
        }
        public void RemoveFriend(Profile friendToRemove)
        {
            string nameAndUsername = $"{friendToRemove.GetFullName()} (@{friendToRemove.GetUsername()})";
            bool success = _friendList.Remove(friendToRemove);
            if (success) Console.WriteLine($"Removed {nameAndUsername} as a friend.");
            else Console.WriteLine($"You aren't friends with {nameAndUsername}.");
        }
    }
}
