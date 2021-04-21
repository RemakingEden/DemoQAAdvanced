using DemoQAAdvanced.helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQAAdvanced.POCO
{
    public static class PracticeFormData
    {
        public static string FirstName { get; } = "Foo";
        public static string LastName { get; } = "Bar";
        public static string Email { get; } = "foobar@mailinator.com";
        public static string MobileNumber { get; } = "0712345678";
        public static string Gender { get; } = "Male";
        public static string DOB { get; } = "01/01/2000";
        public static string Subject { get; } = "Physics";
        public static string Hobbies { get; } = "Sports";
        public static string PictureUpload { get; } = TestFolders.GetInputFilePath(@"..\..\..\input\5mbImage.jpg");
        public static string Address { get; } = "123 FooBar Street, Manchester, M1 2GF";
        public static string State { get; } = "NCR";
        public static string City { get; } = "Delhi";
    }
}
