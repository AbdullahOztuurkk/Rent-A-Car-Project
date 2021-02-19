using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleTableExt;
using RentACar.Business.Concrete;
using RentACar.Core.Entities;
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
        private static ConsoleTableBuilder builder;
        /// <summary>
        /// Center alignment for console.write
        /// </summary>
        /// <param name="word">any string</param>
        /// <param name="isQuestion">Asked questions by program</param>
        private static void WriteToCenter(string word, bool isQuestion = false)
        {
            Console.WriteLine();
            if (isQuestion) Console.ForegroundColor = ConsoleColor.Red;
            else Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition((Console.WindowWidth - word.Length) / 2, Console.CursorTop);
            Console.Write(word);
        }
        /// <summary>
        /// Add car with CarManager 
        /// </summary>
        private static void AddCar()
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
            var result = carManager.Add(new Car
            {
                Description = carName,
                DailyPrice = dailyPrice,
                ModelYear = ModelYear,
                BrandId = brandId,
                ColorId = colorId,
            });
            if (result.IsSuccess)
                WriteToCenter(result.Message);
        }
        /// <summary>
        /// Update car with CarManager
        /// </summary>
        private static void UpdateCar()
        {
            PrintListToTable(new CarManager(new EfCarDal()).GetAll().Data);
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
            var result = carManager.Update(new Car
            {
                Id = updatedIndex,
                Description = carName,
                DailyPrice = dailyPrice,
                ModelYear = ModelYear,
                BrandId = brandId,
                ColorId = colorId,
            });
            if (result.IsSuccess)
                WriteToCenter(result.Message);
        }
        /// <summary>
        /// Add brand with brandManager
        /// </summary>
        private static void AddBrand()
        {
            WriteToCenter("Enter the brand to be added : ");
            var result = brandManager.Add(new Brand { Name = Console.ReadLine() });
            if (result.IsSuccess)
                WriteToCenter(result.Message);
        }
        /// <summary>
        /// Print any list to table with column names
        /// </summary>
        /// <typeparam name="T">Any database entity</typeparam>
        /// <param name="data">List of database entities</param>
        private static void PrintListToTable<T>(List<T> data) where T : class, IEntity, new()
        {
            ConsoleTableBuilder.From(data)
                .WithTitle($@"{typeof(T).Name} List", ConsoleColor.White, ConsoleColor.Black)
                .WithFormat(ConsoleTableBuilderFormat.Alternative)
                .WithPaddingLeft(string.Empty)
                .WithTextAlignment(new Dictionary<int, TextAligntment>
                {
                    {1,TextAligntment.Right},
                    {2,TextAligntment.Left}
                })
                .WithColumn(typeof(T).GetProperties().Select(predicate => predicate.Name).ToList())
                .ExportAndWriteLine(TableAligntment.Center);
        }

        /// <summary>
        /// Update Brand with BrandManager 
        /// </summary>
        private static void UpdateBrand()
        {
            PrintListToTable(new BrandManager(new EfBrandDal()).GetAll().Data);
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
        private static void AddColor()
        {
            WriteToCenter("Enter the color to be added : ");
            var result = colorManager.Add(new Color { Name = Console.ReadLine() });
            if (result.IsSuccess)
                WriteToCenter(result.Message);
        }
        /// <summary>
        /// Update Color with ColorManager 
        /// </summary>
        private static void UpdateColor()
        {
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
            WriteToCenter("'''''''''''''''''''''''''''''''''''''''''''''''");
            WriteToCenter("'                                             '");
            WriteToCenter("'        Software Development Camp            '");
            WriteToCenter("'                                             '");
            WriteToCenter("'            Rent A Car System                '");
            WriteToCenter("'                                             '");
            WriteToCenter("'''''''''''''''''''''''''''''''''''''''''''''''");
            WriteToCenter("Welcome to Rent A Car system.");
            WriteToCenter("1) Car Menu     2)Brand Menu     3) Color Menu");
            WriteToCenter("Which one do you choose :", true);      /* Entities Menu */
            string menuId = Console.ReadLine();
            switch (menuId)
            {
                case "1":
                    carManager = new CarManager(new EfCarDal());  //Chosen Database Car Manager
                    WriteToCenter("Process Types");
                    WriteToCenter("1) Add     2) Delete     3) Update     4) List");
                    WriteToCenter("Which one do you choose :", true);   /*Process Types Menu*/
                    string processId_1 = Console.ReadLine(); 
                    switch (processId_1)
                    {
                        case "1":
                            #region Add Data
                            AddCar();
                            #endregion
                            break;
                        case "2":
                            #region Delete the Car
                            PrintListToTable(new CarManager(new EfCarDal()).GetAll().Data);
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
                            PrintListToTable(new CarManager(new EfCarDal()).GetAll().Data);
                            #endregion
                            break;
                        default:
                            WriteToCenter("Options not found !", true);
                            break;
                    }
                    break;
                case "2":
                    brandManager = new BrandManager(new EfBrandDal()); // Chosen Database Brand Manager
                    WriteToCenter("Process Types");
                    WriteToCenter("1) Add     2) Delete     3) Update     4) List");
                    WriteToCenter("Which one do you choose :", true);    /*Process Types Menu*/
                    string processId_2 = Console.ReadLine();
                    switch (processId_2)
                    {
                        case "1":
                            #region Add brand
                            AddBrand();
                            #endregion
                            break;
                        case "2":
                            #region Delete Brand
                            PrintListToTable(new BrandManager(new EfBrandDal()).GetAll().Data);
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
                            PrintListToTable(new BrandManager(new EfBrandDal()).GetAll().Data);
                            #endregion
                            break;
                    }
                    break;
                case "3":
                    colorManager = new ColorManager(new EfColorDal()); // Chosen Database Color Manager
                    WriteToCenter("Process Types");
                    WriteToCenter("1) Add     2) Delete     3) Update     4) List");
                    WriteToCenter("Which one do you choose :", true);    /*Process Types Menu*/
                    string processId_3 = Console.ReadLine();
                    switch (processId_3)
                    {
                        case "1":
                            #region Add Color
                            AddColor();
                            #endregion
                            break;
                        case "2":
                            #region Update Color
                            UpdateColor();
                            #endregion
                            break;
                        case "3":
                            #region Delete Color
                            PrintListToTable(colorManager.GetAll().Data);
                            WriteToCenter("Enter the Id to be deleted :");
                            int deletedIndex = Convert.ToInt32(Console.ReadLine());
                            var process = colorManager.Delete(deletedIndex);
                            WriteToCenter(process.IsSuccess is true ? process.Message : "");
                            #endregion
                            break;
                        case "4":
                            #region Get Color
                            PrintListToTable(colorManager.GetAll().Data);
                            #endregion
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
