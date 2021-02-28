using RentACar.Core.Entities.Concrete;

namespace RentACar.Business.Constants
{
    public static class Messages
    {
        /*Validation messages*/
        public static string Car_Description_Minimum_Length= "Description must be at least 2 characters!";
        public static string Car_DailyPrice_Minimum_Limit = "Daily price must be greater than zero!";
        public static string Car_Must_Be_Rental = "Car must be rental before deliver the car";

        public static string Car_Must_Be_Lower_Than_5_Photos = "You reached the maximum image limit.";
        public static string Car_Must_Be_Exists = "The car doesnt exist.";
        public static string Car_Image_Must_Be_Exists = "The car image doesnt exist.";
        public static string AuthorizationDenied = "You dont have a permission to do this.";

        public static string User_Register_Message = "User succesfully registered to system.";
        public static string User_Not_Found = "User doesn't exist";
        public static string User_Password_Doesnt_Match = "User password doesnt match";
        public static string User_Already_Exist = "The user already exist.";
        public static string User_Token_Created = "User Token successfully created";


        /*Validation function messages*/

        public static string Multiple_Add_Message(string text) => $@"Multiple {text}s  Added";
        public static string Add_Message(string text) => $@" {text}  Added";
        public static string Update_Message(string text) => $@"Updated the {text}";
        public static string Delete_Message(string text) => $@"Deleted the {text}";
    }
}
