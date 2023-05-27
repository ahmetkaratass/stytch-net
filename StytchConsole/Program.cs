using Stytch.MagicLink;
using Stytch.Models.MagicLink;

class Program
{
    async static Task Main(string[] args)
    {
        var projectId = "project-test-18a43ec3-a866-4f9f-9e16-ea4810ecd352";
        var projectSecret = "secret-test-GlVyZ7BMQpRdhkw3Bq7mm5ehtdM5iUmoodc=";
        var env = "test";

        var magicLink = new MagicLink(new HttpClient(), projectId, projectSecret, env);
        var res = await magicLink.LoginOrCreate(new LoginOrCreateParams("gigametabyte@gmail.com"));
        var res2 = await magicLink.SendMagicLink(new SendMagicLinkParams("gigametabyte@gmail.com"));
        var res3 = await magicLink.Invite(new InviteParams("gigametabyte@gmail.com"));
        var res4 = await magicLink.RevokeInvite("gigametabyte@gmail.com");
        var res5 = await magicLink.Authenticate(
            new AuthenticateParams("9gNUlK9rMdVC-AfGe_py_PjOuMFPr4DImXIlI8fWef17")
        );
        Console.WriteLine(res.StatusCode);
        Console.WriteLine(res2.StatusCode);
        Console.WriteLine(res3.StatusCode);
        Console.WriteLine(res4.StatusCode);
        Console.WriteLine(res5.StatusCode);
        Console.WriteLine($"{res.RequestId}");
        Console.WriteLine($"{res2.RequestId}");
        Console.WriteLine(
            $"{res3.RequestId} {res3.StatusCode} {res3.ErrorType} {res3.ErrorMessage}"
        );
        Console.WriteLine(
            $"{res4.RequestId} {res4.StatusCode} {res4.ErrorType} {res4.ErrorMessage}"
        );
        Console.WriteLine(
            $"{res5.RequestId} {res5.StatusCode} {res5.ErrorType} {res5.ErrorMessage}"
        );
    }
}
