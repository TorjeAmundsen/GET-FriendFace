namespace FriendFace
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var initialPublicProfiles = new List<Profile>()
            {
                new Profile("Throat_G0at_99", "Jon", "Åland", "Oslo", 24, "Male"),
                new Profile("xXTerjeBoi42069Xx", "Terje", "Kolderup", "Telemark", 40, "Male"),
                new Profile("veryRealWoman", "Frida", "Hansen", "Finnmark", 28, "Female"),
                new Profile("Random_Person", "Markus", "Smith", "Vestfold", 32, "Male"),
                new Profile("fish_fear_me", "Bård", "Kristensen", "Nordland", 82, "Male"),
                new Profile("tjommi22", "Tommy", "Fredriksen", "Østfold", 30, "Male"),
                new Profile("LobotomyVictim", "Martha", "Olsen", "Buskerud", 18, "Female"),
                new Profile("FRENCHPERSON222223333", "Louis", "Pierre", "Trøndelag", 35, "Male"),
            };
            var initialUser = new Profile("txrje", "Torje", "Amundsen", "Telemark", 24, "Male");
            var UI = new UserInterface(initialPublicProfiles, initialUser);
            UI.WelcomeMessage();
            UI.MainMenu();
        }
    }
}