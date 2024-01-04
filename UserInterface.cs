namespace FriendFace
{
    internal class UserInterface
    {
        private List<Profile> _profiles;
        private Profile _currentUser;

        public UserInterface(List<Profile> profiles, Profile currentUser)
        {
            _profiles = profiles;
            _currentUser = currentUser;
        }
        
        public void WelcomeMessage()
        {
            Console.WriteLine($"Welcome to FriendFace, {_currentUser.GetFirstName()}!");
        }

        public void MainMenu()
        {
            Console.WriteLine("[1] Show friends");
            Console.WriteLine("[2] Add a new friend");
            Console.WriteLine("[3] Remove a friend");
            Console.WriteLine("[4] View someone's profile");
            Console.WriteLine("[5] View your own profile");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1": ShowAllFriends(_currentUser); break;
                case "2": AddNewFriendMenu(); break;
                case "3": RemoveFriendMenu(); break;
                case "4": ViewProfileUpperMenu(); break;
                case "5": ViewProfile(_currentUser); break;
                default: Console.WriteLine("Invalid input! Try again.\n"); MainMenu(); break;
            }
        }

        public void ShowAllFriends(Profile profile)
        {
            var friendList = profile.GetFriends();
            Console.WriteLine($"\n{profile.GetFullName()}'s friends ({friendList.Count})");
            foreach (var friend in friendList)
            {
                Console.WriteLine(friend.GetNameAndUsername());
            }
            Console.WriteLine();
            MainMenu();
        }

        public void ListProfilesForMenu(List<Profile> profiles)
        {
            for (int i = 0; i < profiles.Count; i++)
            {
                var currentProfile = profiles[i];
                Console.WriteLine($"[{i + 1}] {currentProfile.GetNameAndUsername()}");
            }
        }

        public void AddNewFriendMenu()
        {
            ListProfilesForMenu(_profiles);
            Console.WriteLine("Type a person's number to add a friend, or \"cancel\" to cancel.");

            string userInputRaw = Console.ReadLine();
            int userInputNumber;

            bool isNumber = Int32.TryParse(userInputRaw, out userInputNumber);
            if (userInputRaw.ToLower() == "cancel")
            {
                MainMenu();
            }
            else if (!isNumber || userInputNumber < 1 || userInputNumber > _profiles.Count)
            {
                Console.WriteLine("Invalid input! Try again.");
                AddNewFriendMenu();
            }
            else
            {
                _currentUser.AddFriend(_profiles[userInputNumber - 1]);
            }
            MainMenu();
        }

        public void RemoveFriendMenu()
        {
            var friendList = _currentUser.GetFriends();
            ListProfilesForMenu(friendList);
            Console.WriteLine("Type a friend's number to remove them, or \"cancel\" to cancel.");

            string userInputRaw = Console.ReadLine();
            int userInputNumber;

            bool isNumber = Int32.TryParse(userInputRaw, out userInputNumber);
            if (userInputRaw.ToLower() == "cancel")
            {
                MainMenu();
                return;
            }
            else if (!isNumber || userInputNumber < 1 || userInputNumber > friendList.Count)
            {
                Console.WriteLine("Invalid input! Try again.");
                RemoveFriendMenu();
            }
            else
            {
                _currentUser.RemoveFriend(friendList[userInputNumber - 1]);
            }
            MainMenu();
        }

        public void ViewProfileUpperMenu()
        {
            Console.WriteLine("[1] View a friend's profile");
            Console.WriteLine("[2] View a non-friend's profile");
            Console.WriteLine("Type \"cancel\" to go back to the main menu.");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "cancel")
            {
                MainMenu();
            }
            else
            {
                switch (userInput)
                {
                    case "1": ViewProfileLowerMenu(_currentUser.GetFriends()); break;
                    case "2": ViewProfileLowerMenu(_profiles); break;
                    default: Console.WriteLine("Invalid input! Try again.\n"); ViewProfileUpperMenu(); break;
                }
            }
        }

        public void ViewProfileLowerMenu(List<Profile> profiles)
        {
            ListProfilesForMenu(profiles);
            Console.WriteLine("Type a profile's number to view it, or \"cancel\" to go back to the main menu.");

            string userInputRaw = Console.ReadLine();
            int userInputNumber;

            bool isNumber = Int32.TryParse(userInputRaw, out userInputNumber);
            if (userInputRaw.ToLower() == "cancel")
            {
                MainMenu();
                return;
            }
            else if (!isNumber || userInputNumber < 1 || userInputNumber > profiles.Count)
            {
                Console.WriteLine("Invalid input! Try again.");
                ViewProfileLowerMenu(profiles);
            }
            else
            {
                ViewProfile(profiles[userInputNumber - 1]);
            }
        }

        public void ViewProfile(Profile profile)
        {
            Console.WriteLine($"Viewing profile: {profile.GetNameAndUsername()}");
            Console.WriteLine($"Age: {profile.GetAge()}");
            Console.WriteLine($"Gender: {profile.GetGender()}");
            Console.WriteLine($"Residence: {profile.GetResidence()}");
            Console.WriteLine($"Friends: {profile.GetFriendCount()}");
            Console.WriteLine();
            MainMenu();
        }
    }
}
