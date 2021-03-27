using System;

namespace bot_IG
{
    class Bot_Instagram
    {
        static void Main(string[] args)
        {
            Profile profile = Instagram.GetProfileByUser("therock");
            Console.WriteLine($"Usernarme = {profile.UserName}");
            Console.WriteLine($"Title = {profile.Title}");
            Console.WriteLine($"Description = {profile.Description}");
            Console.WriteLine($"Url = {profile.Url}");
            Console.WriteLine($"Image = {profile.Image}");
            Console.WriteLine($"AndroidAppId = {profile.AndroidAppId}");
            Console.WriteLine($"AndroidAppName = {profile.AndroidAppName}");
            Console.WriteLine($"Android Url = {profile.AndroidUrl}");
            Console.WriteLine($"IosAppId = {profile.IosAppId}");
            Console.WriteLine($"IosAppName = {profile.IosAppName}");
            Console.WriteLine($"Ios Url= {profile.IosUrl}");
        }
    }
}
