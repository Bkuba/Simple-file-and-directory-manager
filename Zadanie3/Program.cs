using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    class Menu
    {
        public void DisplayMenu()
        {
            Console.WriteLine("1) Sprawdz czy isnieje dany katalog lub plik.");
            Console.WriteLine("2) Stworz lub usun dany katalog lub plik.");
            Console.WriteLine("3) Zmien nazwe katalogu lub pliku.");
            Console.WriteLine("4) Przenies plik.");
            Console.WriteLine("5) Wyjdz z programu.");
        }

        public static void CheckExists()
        {
            Console.WriteLine("1) Sprwadz czy istnieje dany plik.");
            Console.WriteLine("2) Sprwadz czy istnieje dany katalog.");

            int x = int.Parse(Console.ReadLine());

            if (x == 1)
            {
                Console.WriteLine("Podaj sciezke pliku: ");
                string pathFile = Console.ReadLine();
                bool checkFile = File.Exists(pathFile);

                if (checkFile == true)
                {
                    Console.WriteLine("Znaleziono plik: " + pathFile);
                }
                else
                {
                    Console.WriteLine("Nie znaleziono pliku: " + pathFile);
                }
            }
            else if(x == 2)
            {
                Console.WriteLine("Podaj sciezke katalogu: ");
                string pathDirectory = Console.ReadLine();
                bool checkDirectory = Directory.Exists(pathDirectory);

                if(checkDirectory == true)
                {
                    Console.WriteLine("Znaleziono katalog: " + pathDirectory);
                }
                else
                {
                    Console.WriteLine("Nie znaleziono katalogu: " + pathDirectory);
                }
            }
            else
            {
                Console.WriteLine("Wprowadzono zla liczbe.");
                Console.WriteLine();
                //CheckExists();
            }
            CheckExists();
        }

        public static void CreateOrDelete()
        {
            Console.WriteLine("1) Stworz plik/ katalog.");
            Console.WriteLine("2) Usun plik/ katalog.");

            int x = int.Parse(Console.ReadLine());

            if(x == 1)
            {
                Console.WriteLine("1) Stworz plik.");
                Console.WriteLine("2) Stworz katalog.");

                int y = int.Parse(Console.ReadLine());

                if(y == 1)
                {
                    Console.WriteLine("Podaj sciezke pliku, ktory chcesz utworzyc: ");
                    string pathFile = Console.ReadLine();
                    File.Create(pathFile).Dispose();

                    bool checkCreateFile = File.Create(pathFile) != null;

                    if(checkCreateFile == true)
                    {
                        Console.WriteLine("Utworzono plik: " + pathFile);
                    }
                }
                else if(y == 2)
                {
                    Console.WriteLine("Podaj sciezke katalogu, ktory chcesz utworzyc: ");
                    string pathDirectory = Console.ReadLine();
                    bool checkCreateDirectory = Directory.CreateDirectory(pathDirectory) != null;

                    if(checkCreateDirectory == true)
                    {
                        Console.WriteLine("Utworzono katalog: " + pathDirectory);
                    }
                }
                else
                {
                    Console.WriteLine("Nieprawidlowy wybor.");
                    CreateOrDelete();
                }
            }
            else if(x == 2)
            {
                Console.WriteLine("1) Usun plik.");
                Console.WriteLine("2) Usun katalog.");

                int y = int.Parse(Console.ReadLine());

                if(y == 1)
                {
                    Console.WriteLine("Podaj sciezke pliku, ktory chcesz usunac: ");
                    string pathFile = Console.ReadLine();
                    File.Delete(pathFile);

                    Console.WriteLine("Usunieto plik.");
                }
                else if(y == 2)
                {
                    Console.WriteLine("Podaj sciezke katalogu, ktory chcesz usunac: ");
                    string pathDirectory = Console.ReadLine();
                    Directory.Delete(pathDirectory);

                    Console.WriteLine("Usunieto katalog: " + pathDirectory);
                }
                else
                {
                    Console.WriteLine("Nieprawidlowy wybor.");
                    CreateOrDelete();
                }
            }
            else
            {
                Console.WriteLine("Nieprawidlowy wybor.");
                CreateOrDelete();
            }
        }

        public static void ChangeName()
        {
            Console.WriteLine("1) Zmien nazwe pliku.");
            Console.WriteLine("2) Zmien nazwe katalogu.");

            int x = int.Parse(Console.ReadLine());

            if(x == 1)
            {
                Console.WriteLine("Podaj katalog, w ktorym znajduje sie plik: ");
                string pathDirectory = Console.ReadLine();
                Console.WriteLine("Podaj nazwe pliku, ktora chcesz zmienic poprzedzajac ja backslashem: ");
                string oldName = Console.ReadLine();
                Console.WriteLine("Podaj nowa nazwe pliku poprzedzajac ja backslashem: ");
                string newName = Console.ReadLine();

                File.Move(pathDirectory + oldName + ".txt", pathDirectory + newName + ".txt");

                Console.WriteLine("Zmieniono nazwe pliku.");
            }
            else if(x == 2)
            {
                Console.WriteLine("Podaj sciezke katalogu, ktorego nazwe chcesz zmienic: ");
                string pathFileOld = Console.ReadLine();
                Console.WriteLine("Podaj sciezke katalogu z nowa nazwa katalogu: ");
                string pathFileNew = Console.ReadLine();

                Directory.Move(pathFileOld, pathFileNew);

                //string temp = "<Object type=\"System.Windows.Forms.Form";

                Console.WriteLine("Zmienono nazwe katalogu.");
            }
            else
            {
                Console.WriteLine("Nieprawidlowy wybor.");
                Console.WriteLine();
                ChangeName();
            }
        }

        public static void MoveFile()
        {
            Console.WriteLine("Podaj sciezke pliku, ktory chcesz przeniesc: ");
            string pathFile = Console.ReadLine();
            Console.WriteLine("Podaj sciezke katalogu, do ktorego chcesz przenisc plik: ");
            string pathDirectory = Console.ReadLine();

            File.Move(pathFile, pathDirectory + ".txt");

            Console.WriteLine("Plik zostal przeniesiony.");
        }

        public static void Wybor(string wyborUsera)
        {
            switch (wyborUsera)
            {
                case "1":
                    Menu.CheckExists();
                    Console.ReadLine();
                    break;
                case "2":
                    Menu.CreateOrDelete();
                    Console.ReadLine();
                    break;
                case "3":
                    Menu.ChangeName();
                    Console.ReadLine();
                    break;
                case "4":
                    Menu.MoveFile();
                    Console.ReadLine();
                    break;
                default:
                    break;
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Menu menu = new Menu();

                string wpisz;
                do
                {
                    Console.Clear();
                    menu.DisplayMenu();
                    wpisz = Console.ReadLine();
                    Menu.Wybor(wpisz);

                } while (wpisz != "5");

            }
        }
    }
}
