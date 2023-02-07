using PageObjectPattert.Lection.Models;

namespace PageObjectPattert.Lection.TestData;

public static class UserRequestModelFactory
{
    public static readonly UserRequestModel TestUser = new UserRequestModel()
    {
        Email = "blabla@yandex.ru",
        Name = "sasha",
        Password = "blablapass",
        PhoneNumber = "123123123"
    };
}