using Stytch.MagicLink;
using Stytch.Models.MagicLink;

class Program
{
    async static Task Main(string[] args)
    {
        var magicLink = new MagicLink(new HttpClient());
        var res = await magicLink.LoginOrCreate(new LoginOrCreateParams("gigametabyte@gmail.com"));
        var res2 = await magicLink.SendMagicLink(new SendMagicLinkParams("gigametabyte@gmail.com"));
        var res3 = await magicLink.Invite(new InviteParams("gigametabyte@gmail.com"));
        var res4 = await magicLink.RevokeInvite("gigametabyte@gmail.com");
        Console.WriteLine(res.StatusCode);
        Console.WriteLine(res2.StatusCode);
        Console.WriteLine(res3.StatusCode);
        Console.WriteLine($"{res.RequestId}");
        Console.WriteLine($"{res2.RequestId}");
        Console.WriteLine(
            $"{res3.RequestId} {res3.StatusCode} {res3.ErrorType} {res3.ErrorMessage}"
        );
        Console.WriteLine($"{res4.RequestId} {res4.StatusCode} {res4.ErrorType} {res4.ErrorMessage}");
    }
}
