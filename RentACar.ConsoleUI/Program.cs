using System;
using System.Collections.Generic;
using System.Text;
using RentACar.Business.Concrete;
using RentACar.DataAccess.Concrete.EntityFramework;
using RentACar.DataAccess.Concrete.InMemory;
using RentACar.Entities.Concrete;

namespace RentACar.ConsoleUI
{

    class Program
    {
        private static CarManager carManager;
        private static BrandManager brandManager;
        private static ColorManager colorManager;
        /// <summary>
        /// Center alignment for console.write
        /// </summary>
        /// <param name="word">any string</param>
        /// <param name="isQuestion">Asked questions by program</param>
        private static void WriteToCenter(string word, bool isQuestion = false)
        {
            Console.WriteLine();
            if (isQuestion) Console.ForegroundColor = ConsoleColor.DarkGray;
            else Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition((Console.WindowWidth - word.Length) / 2, Console.CursorTop);
            Console.Write(word);
        }
        /// <summary>
        /// Edit word if word's length greater than 12
        /// </summary>
        /// <param name="word">Any string</param>
        /// <returns></returns>
        private static string FormatWord(string word)
        {
            if (word.Length > 12)
            {
                word = word.Substring(0, 12) + ".";
            }

            return word;
        }
        /// <summary>
        /// Print cars with CarManager 
        /// </summary>
        private static void PrintCars()
        {
            WriteToCenter(new string('_', 10) + " Car List " + new string('_', 10),true);
            Console.Write("\n");
            var processResult = carManager.GetAll();
            if (processResult.IsSuccess)
            {
                foreach (var car in processResult.Data)
                {
                    string result = new StringBuilder().AppendFormat("\t\tId : {0}  \t|   Name : {1}  \t|   DailyPrice : {2}  \t|  Model Year : {3}  ", car.Id, FormatWord(car.Description), car.DailyPrice, car.ModelYear).ToString();
                    Console.WriteLine(result);
                }
            }
        }
        /// <summary>
        /// Add car with CarManager 
        /// </summary>
        private static void AddCars()
        {
            WriteToCenter("How Much will you insert car?");
            List<Car> cars = new List<Car>();
            int counter = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < counter; i++)
            {
                WriteToCenter("Car Name : ");
                string carName = Console.ReadLine();
                WriteToCenter("Model Year : ");
                int ModelYear = Convert.ToInt32(Console.ReadLine());
                WriteToCenter("Daily Price : ");
                int dailyPrice = Convert.ToInt32(Console.ReadLine());
                WriteToCenter("Brand Id: ");
                int brandId = Convert.ToInt32(Console.ReadLine());
                WriteToCenter("Color Id : ");
                int colorId = Convert.ToInt32(Console.ReadLine());
                cars.Add(new Car
                {
                    Description = carName,
                    DailyPrice = dailyPrice,
                    ModelYear = ModelYear,
                    BrandId = brandId,
                    ColorId = colorId,
                });
            }
            var result =carManager.AddRange(cars);
            if(result.IsSuccess)
                    WriteToCenter(result.Message);
        }
        /// <summary>
        /// Update car with CarManager
        /// </summary>
        private static void UpdateCar()
        {
            PrintCars();
            WriteToCenter("Enter the id to be updated :");
            int updatedIndex = Convert.ToInt32(Console.ReadLine());
            WriteToCenter("Car Name : ");
            string carName = Console.ReadLine();
            WriteToCenter("Model Year : ");
            int ModelYear = Convert.ToInt32(Console.ReadLine());
            WriteToCenter("Daily Price : ");
            int dailyPrice = Convert.ToInt32(Console.ReadLine());
            WriteToCenter("Brand Id: ");
            int brandId = Convert.ToInt32(Console.ReadLine());
            WriteToCenter("Color Id : ");
            int colorId = Convert.ToInt32(Console.ReadLine());
            var result =carManager.Update(new Car
            {
                Id=updatedIndex,
                Description = carName,
                DailyPrice = dailyPrice,
                ModelYear = ModelYear,
                BrandId = brandId,
                ColorId = colorId,
            });
            if(result.IsSuccess)
                WriteToCenter(result.Message);
        }
        /// <summary>
        /// Add brand with brandManager
        /// </summary>
        private static void AddBrands()
        {
            List<Brand> brands = new List<Brand>();
            WriteToCenter("How much will you insert brand?");
            int counter = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < counter; i++)
            {
                WriteToCenter("Enter the brand to be added : ");
                brands.Add(new Brand { Name = Console.ReadLine() });
            }
            var result = brandManager.AddRange(brands);
            if(result.IsSuccess)
                WriteToCenter(result.Message);
        }
        /// <summary>
        /// Print Brand with BrandManager 
        /// </summary>
        private static void PrintBrands()
        {
            WriteToCenter(new string('_', 10) + " Brand List " + new string('_', 10), true);
            Console.Write("\n");
            var processResult = brandManager.GetAll();
            if (processResult.IsSuccess)
            {
                foreach (var brand in processResult.Data)
                {
                    WriteToCenter("Id : " + brand.Id + "     Name : " + brand.Name);
                }
            }
        }
        /// <summary>
        /// Update Brand with BrandManager 
        /// </summary>
        private static void UpdateBrand()
        {
            PrintBrands();
            WriteToCenter("Enter the id to be updated :");
            int updatedIndex = Convert.ToInt32(Console.ReadLine());
            WriteToCenter("New Name : ");
            var result = brandManager.Update(new Brand
            {
                Id = updatedIndex,
                Name = Console.ReadLine()
            });
            if (result.IsSuccess)
                WriteToCenter(result.Message);
        }
        /// <summary>
        /// Add Color with ColorManager
        /// </summary>
        private static void AddColors()
        {
            List<Color> colors = new List<Color>();
            WriteToCenter("How much will you insert color?");
            int counter = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < counter; i++)
            {
                WriteToCenter("Enter the color to be added : ");
                colors.Add(new Color { Name = Console.ReadLine() });
            }
            var result = colorManager.AddRange(colors);
            if (result.IsSuccess)
                WriteToCenter(result.Message);
        }
        /// <summary>
        /// Print Color with ColorManager 
        /// </summary>
        private static void PrintColors()
        {
            WriteToCenter(new string('_', 10) + " Brand List " + new string('_', 10), true);
            Console.Write("\n");
            var processResult = colorManager.GetAll();
            if (processResult.IsSuccess)
            {
                foreach (var color in processResult.Data)
                {
                    WriteToCenter("Id : " + color.Id + "     Name : " + color.Name);
                }
            }
        }
        /// <summary>
        /// Update Color with ColorManager 
        /// </summary>
        private static void UpdateColor()
        {
            PrintColors();
            WriteToCenter("Enter the id to be updated :");
            int updatedIndex = Convert.ToInt32(Console.ReadLine());
            WriteToCenter("New Name : ");
            var result = colorManager.Update(new Color
            {
                Id = updatedIndex,
                Name = Console.ReadLine()
            });
            if (result.IsSuccess)
                WriteToCenter(result.Message);
        }
       
        /* There are many main functions at above*/

        static void Main(string[] args)
        {
            WriteToCenter("-----------------------------------------------");
            WriteToCenter("-                                             -");
            WriteToCenter("-        Software Development Camp            -");
            WriteToCenter("-                                             -");
            WriteToCenter("-            Rent A Car System                -");
            WriteToCenter("-                                             -");
            WriteToCenter("-----------------------------------------------");
            WriteToCenter("Welcome to Rent A Car system.");
            WriteToCenter("1) Car Menu     2)Brand Menu     3) Color Menu"); 
            WriteToCenter("Which one do you choose :", true);      /* FIRST MENU */
            string menuId = Console.ReadLine();
            switch (menuId)         
            {
                case "1":
                    WriteToCenter("Service Types");
                    WriteToCenter("1) Internal     2) External");
                    WriteToCenter("Which one do you choose :", true);            /*SECOND MENU*/
                    string managerId = Console.ReadLine();
                    switch (managerId)
                    {
                        case "1":
                            carManager = new CarManager(new InMemoryCarDal()); // Chosen Internal Car Manager
                            WriteToCenter("Process Types");
                            WriteToCenter("1) Add     2) Delete     3) Update     4) List");
                            WriteToCenter("Which one do you choose :", true);    /*THIRD MENU*/
                            string processId = Console.ReadLine();
                            switch (processId)
                            {
                                case "1":
                                    #region Add Car
                                    AddCars();
                                    #endregion
                                    break;
                                case "2":
                                    #region Delete the Car
                                    PrintCars();
                                    WriteToCenter("Enter the Id to be deleted :");
                                    int deletedIndex = Convert.ToInt32(Console.ReadLine());
                                    var process = carManager.Delete(deletedIndex);
                                    WriteToCenter(process.IsSuccess is true ? process.Message : "");
                                    #endregion
                                    break;
                                case "3":
                                    #region Update the Car
                                    UpdateCar();
                                    #endregion
                                    break;
                                case "4":
                                    #region Get Cars
                                    PrintCars();
                                    #endregion
                                    break;
                                default:
                                    WriteToCenter("Options not found !", true);
                                    break;
                            }
                            break;
                        case "2": 
                            carManager = new CarManager(new EfCarDal());  //Chosen External Car Manager
                            WriteToCenter("Process Types");
                            WriteToCenter("1) Add     2) Delete     3) Update     4) List");
                            WriteToCenter("Which one do you choose :", true);
                            string processId2 = Console.ReadLine();
                            switch (processId2)
                            {
                                case "1":
                                    #region Add Data
                                    AddCars();
                                    #endregion
                                    break;
                                case "2":
                                    #region Delete the Car
                                    PrintCars();
                                    WriteToCenter("Enter the Id to be deleted :");
                                    int deletedIndex = Convert.ToInt32(Console.ReadLine());
                                    var process = carManager.Delete(deletedIndex);
                                    WriteToCenter(process.IsSuccess is true ? process.Message : "");
                                    #endregion
                                    break;
                                case "3":
                                    #region Update the Car
                                    UpdateCar();
                                    #endregion
                                    break;
                                case "4":
                                    #region Get Cars
                                    PrintCars();
                                    #endregion
                                    break;
                                default:
                                    WriteToCenter("Options not found !", true);
                                    break;
                            }
                            break;
                        default:
                            WriteToCenter("Options not found !", true);
                            break;
                    }
                    break;
                case "2":
                    WriteToCenter("Service Types");
                    WriteToCenter("1) Internal     2) External");
                    WriteToCenter("Which one do you choose :", true);            /*SECOND MENU*/
                    string managerId2 = Console.ReadLine();
                    switch (managerId2)
                    {
                        case "1":
                            brandManager=new BrandManager(new InMemoryBrandDal()); // Chosen Internal Brand Manager
                            WriteToCenter("Process Types");
                            WriteToCenter("1) Add     2) Delete     3) Update     4) List");
                            WriteToCenter("Which one do you choose :", true);    /*THIRD MENU*/
                            string processId2 = Console.ReadLine();
                            switch (processId2)
                            {
                                case "1":
                                    #region Add brand
                                    AddBrands();
                                    #endregion
                                    break;
                                case "2":
                                    #region Delete Brand
                                    PrintBrands();
                                    WriteToCenter("Enter the Id to be deleted :");
                                    int deletedIndex = Convert.ToInt32(Console.ReadLine());
                                    var process = brandManager.Delete(deletedIndex);
                                    WriteToCenter(process.IsSuccess is true ? process.Message : "");
                                    #endregion
                                    break;
                                case "3":
                                    #region Update brand
                                    UpdateBrand();
                                    #endregion
                                    break;
                                case "4":
                                    #region Get brands
                                    PrintBrands();
                                    #endregion
                                    break;
                            }
                            break;
                        case "2":
                            brandManager=new BrandManager(new EfBrandDal()); // Chosen External Brand Manager
                            WriteToCenter("Process Types");
                            WriteToCenter("1) Add     2) Delete     3) Update     4) List");
                            WriteToCenter("Which one do you choose :", true);    /*THIRD MENU*/
                            string processId3 = Console.ReadLine();
                            switch (processId3)
                            {
                                case "1":
                                    #region Add brand
                                    AddBrands();
                                    #endregion
                                    break;
                                case "2":
                                    #region Delete Brand
                                    PrintBrands();
                                    WriteToCenter("Enter the Id to be deleted :");
                                    int deletedIndex = Convert.ToInt32(Console.ReadLine());
                                    var process = brandManager.Delete(deletedIndex);
                                    WriteToCenter(process.IsSuccess is true ? process.Message : "");
                                    #endregion
                                    break;
                                case "3":
                                    #region Update brand
                                    UpdateBrand();
                                    #endregion
                                    break;
                                case "4":
                                    #region Get brands
                                    PrintBrands();
                                    #endregion
                                    break;
                            }
                            break;
                    }
                    break;
                case "3":
                    WriteToCenter("Service Types");
                    WriteToCenter("1) Internal     2) External");
                    WriteToCenter("Which one do you choose :", true);            /*SECOND MENU*/
                    string managerId3 = Console.ReadLine();
                    switch (managerId3)
                    {
                        case "1":
                            colorManager = new ColorManager(new InMemoryColorDal()) ; // Chosen Internal Color Manager
                            WriteToCenter("Process Types");
                            WriteToCenter("1) Add     2) Delete     3) Update     4) List");
                            WriteToCenter("Which one do you choose :", true);    /*THIRD MENU*/
                            string processId2 = Console.ReadLine();
                            switch (processId2)
                            {
                                case "1":
                                    #region Add Color
                                    AddColors();
                                    #endregion
                                    break;
                                case "2":
                                    #region Delete Color
                                    PrintColors();
                                    WriteToCenter("Enter the Id to be deleted :");
                                    int deletedIndex = Convert.ToInt32(Console.ReadLine());
                                    var process = colorManager.Delete(deletedIndex);
                                    WriteToCenter(process.IsSuccess is true ? process.Message : "");
                                    #endregion
                                    break;
                                case "3":
                                    #region Update Color
                                    UpdateColor();
                                    #endregion
                                    break;
                                case "4":
                                    #region Get Color
                                    PrintColors();
                                    #endregion
                                    break;
                            }
                            break;
                        case "2":
                            colorManager = new ColorManager(new EfColorDal()); // Chosen External Color Manager
                            WriteToCenter("Process Types");
                            WriteToCenter("1) Add     2) Delete     3) Update     4) List");
                            WriteToCenter("Which one do you choose :", true);    /*THIRD MENU*/
                            string processId3 = Console.ReadLine();
                            switch (processId3)
                            {
                                case "1":
                                    #region Add Color
                                    AddColors();
                                    #endregion
                                    break;
                                case "2":
                                    #region Update Color
                                    UpdateColor();
                                    #endregion
                                    break;
                                case "3":
                                    #region Delete Color
                                    PrintColors();
                                    WriteToCenter("Enter the Id to be deleted :");
                                    int deletedIndex = Convert.ToInt32(Console.ReadLine());
                                    var process = colorManager.Delete(deletedIndex);
                                    WriteToCenter(process.IsSuccess is true ? process.Message : "");
                                    #endregion
                                    break;
                                case "4":
                                    #region Get Color
                                    PrintColors();
                                    #endregion
                                    break;
                            }
                            break;
                    }
                    break;
                default:
                    WriteToCenter("Menu not found !", true);
                    break;
            }
            Console.ReadLine();
        }
    }
}
