
using ConsoleApp3;
using System;
using Microsoft.Data.SqlClient;
using System.Threading.Channels;
using System.Transactions;

while (true)
{


    string contactName; //Replace with the actual value.
string contactEmail; //Replace with the actual value.
string contactAddress; //Replace with the actual value.


string a;

Console.WriteLine("Enter I to Insert your Contact Data: ");
Console.WriteLine("Enter D To Delete by ID: ");
Console.WriteLine("Enter U to Update Data Row by ID: "); 
Console.WriteLine("Enter F for to See Full ContactList Detail: ");
Console.WriteLine("Enter N to see One person Detail");


    a = Convert.ToString(Console.ReadLine());



    //ContactListRepository tbl1 = new ContactListRepository();
    //var Contactlist = tbl1.getConacts();

    //for (int i = 0; i < Contactlist.Count; i++)
    //{
    //    Console.WriteLine(Contactlist[i].Name);
    //}





    {
    // get row by id shortly
    if (a == "N" ||  a == "n")
    {
      Console.Write("Enter Id To Get Data Row Wise");
      int id = Convert.ToInt32(Console.ReadLine());
      ContactListRepository tbl1 = new ContactListRepository();
      var getid = tbl1.GetById(id);
            if (getid != null)
            {
                Console.WriteLine($"Id: {getid.Id},  Name: {getid.CName},  Email: {getid.Cemail},  Address: {getid.Caddress}");
            }
      else
            {
                Console.WriteLine("no id");
            }
      
    }


    // select data through table but in short way to instal after   DAPPER 
    else if(a == "F" || a == "f")
    {
        ContactListRepository tbl1 = new ContactListRepository();
            var Fulltable = tbl1.getConacts();
            //for ( int i = 0; i < Fulltable.Count; i++)
            //{
            //    Console.WriteLine(Fulltable[i].Name);
            //}
            //Console.WriteLine("All Table Detail");

            foreach (var c in Fulltable)
            {
                Console.WriteLine($"Id: {c.Id}||| Name: {c.CName},||| Email: {c.Cemail},||| Address: {c.Caddress}");
            }
        } 

    // Insert in row wise data 
    else if (a == "i" || a == "I")
    {
        Console.WriteLine("This can help you to save Contact and Detail ");
        Console.Write("Please enter your ContactName: ");
        contactName = Console.ReadLine();

        Console.Write("Please enter your Contact Email: ");
        contactEmail = Console.ReadLine();

        Console.Write("Please enter your Contact Address: ");
        contactAddress = Console.ReadLine();



        ContactListGetset Conactlist = new ContactListGetset();
        Conactlist.CName = contactName;
        Conactlist.Cemail = contactEmail;
        Conactlist.Caddress = contactAddress;
        ContactListRepository tbl2 = new ContactListRepository();
        tbl2.saveContactlist(Conactlist);
    }

    //delete fuction
    else if (a == "d" || a == "D")
    {


        Console.WriteLine("This can help you to Delete your Contact Detail through ID ");



            int id;
            while (true)
            {
                //Console.WriteLine("Enter the Id you want to delete: ");

                Console.Write("Enter Id: ");

                if(int.TryParse(Console.ReadLine(), out int inputVlaue))
                {
                    id = inputVlaue;
                    // string query = $"DELETE FROM tblcontactlist WHERE Id = {5};";
                    ContactListGetset Contactlist001 = new ContactListGetset();
                    Contactlist001.Id = id;
                    ContactListRepository tbl3 = new ContactListRepository();
                    tbl3.deleteContactlistRow(id);
                    Console.WriteLine("Id Effected");
                    break;
                    
                }
                else
                {
                    Console.WriteLine("Enter only numbers so this is invalid INPUT");
                }
                
            }
    }
    
    //Update function
    else if (a == "u" || a == "U")
    {
        Console.WriteLine("This can help you to Update your Contact through ID ");
            int IdF;
            while (true)
            {
                Console.Write("Enter Id For update: ");

                if (int.TryParse(Console.ReadLine(), out int inputValue))
                {
                    IdF = inputValue; // Capture the entered integer



                    string namef, emailf, addressf;
                    //Console.Write("Enter Id For update: ");
                   // IdF = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Name to Update: ");
                    namef = Console.ReadLine();

                    Console.Write("Enter Email to Update: ");
                    emailf = Console.ReadLine();

                    Console.Write("Enter Address to Update: ");
                    addressf = Console.ReadLine();



                    ContactListGetset contactlistupdate = new ContactListGetset();

                    contactlistupdate.Id = IdF;
                    contactlistupdate.CName = namef;
                    contactlistupdate.Cemail = emailf;
                    contactlistupdate.Caddress = addressf;
                    ContactListRepository tblUpdate = new ContactListRepository();
                    tblUpdate.UpdateRow(contactlistupdate);


                    break; // Exit the loop after displaying "Hello, World!"
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter an integer value.");
                }
            }

            // Use the enteredNumber in your program
            Console.WriteLine($"You entered: {IdF}");





          
        
    }
    
    
    //error
    else
    {
        string errorMessage = @"
                 ______                    |______|   
                |             
                | |-||-|      
                |_______        
                |_______|        
                ";

        Console.WriteLine(errorMessage);
        Console.WriteLine("An error occurred. Please try again.");
    }
}

    Console.WriteLine("Press Enter to Start Prgramme again, or type 'exit' to quit.");
    string P = Console.ReadLine();
    if (P == "Exit" || P == "exit")
    {
        break;
    }

}





