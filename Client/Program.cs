using BL;
using MDBModels;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            McdollibeeMenuServices menuServices = new McdollibeeMenuServices();

            while (true)
            {
                Console.WriteLine("Mcdollibee Menu Management");
                Console.WriteLine("1. Add Menu Item");
                Console.WriteLine("2. Update Menu Item");
                Console.WriteLine("3. Delete Menu Item");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddMenuItem(menuServices);
                        break;
                    case "2":
                        UpdateMenuItem(menuServices);
                        break;
                    case "3":
                        DeleteMenuItem(menuServices);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private static void AddMenuItem(McdollibeeMenuServices menuServices)
        {
            Console.Write("Enter Item Name: ");
            string itemName = Console.ReadLine();

            Console.Write("Enter Category: ");
            string category = Console.ReadLine();

            Console.Write("Enter Code: ");
            string code = Console.ReadLine();

            menu newMenu = new menu { ItemName = itemName, Category = category, Code = code };

            if (menuServices.CreateMenu(newMenu))
            {
                Console.WriteLine("Menu item added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add menu item. It may already exist.");
            }
        }

        private static void UpdateMenuItem(McdollibeeMenuServices menuServices)
        {
            Console.Write("Enter Item Name to Update: ");
            string itemName = Console.ReadLine();

            Console.Write("Enter New Code: ");
            string newCode = Console.ReadLine();

            menu updatedMenu = new menu { ItemName = itemName, Code = newCode };

            if (menuServices.UpdateMenu(updatedMenu))
            {
                Console.WriteLine("Menu item updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update menu item. It may not exist.");
            }
        }

        private static void DeleteMenuItem(McdollibeeMenuServices menuServices)
        {
            Console.Write("Enter Code of Menu Item to Delete: ");
            string code = Console.ReadLine();

            if (menuServices.DeleteMenu(code))
            {
                Console.WriteLine("Menu item deleted successfully.");
            }
            else
            {
                Console.WriteLine("Failed to delete menu item. It may not exist.");
            }
        }
    }
}