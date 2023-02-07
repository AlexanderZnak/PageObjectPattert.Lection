using PageObjectPattert.Lection.Helpers;

namespace PageObjectPattert.Lection.Steps;

public class HomePageSteps
{
    public static void Login(ILoginStrategy loginStrategy)
    {
        loginStrategy.Login();
    }
    
    public static void LoginViaApi(User user)
    {
        // do smth
    }
}