using ContextExample.Data;
using System;
using ContextExample.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace ContextExample.Services;

/// <summary>
///     You would need to inject your interfaces here to execute the methods in Invoke()
///     See the commented out code as an example
/// </summary>
public class MainService : IMainService
{
    private readonly IContext _context;

    public MainService(IContext context)
    {
        _context = context;
    }

    

    public void Invoke()
    {
        string choice;
        // provide an option to the user to 
        do
        {
            Console.WriteLine("---Menu---");
            Console.WriteLine("1. Get Movie by Id");
            Console.WriteLine("2. Get movie by title");
            Console.WriteLine("3. Find List of movies matching title");
            Console.WriteLine("4.Exit");
            Console.WriteLine("Enter a choice: ");
            choice = Console.ReadLine();
            // 1. select by id
            if (choice == "1")
            {
                Console.WriteLine();
                Console.WriteLine("What movie would you like to choose: ");
                int movieChoice = Convert.ToInt32(Console.ReadLine());
                var movie1 = _context.GetById((movieChoice));
                Console.WriteLine($"Your movie is {movie1.Title}");

            }
            // 2. select by title 
            else if (choice == "2")
            {
                Console.WriteLine("Enter a title to search for: ");
                string searchTitle = Console.ReadLine();
                var movieByTitle = _context.GetByTitle(searchTitle);
                Console.WriteLine($"Matching movie is :{movieByTitle.Title}");


            }
            // 3. find movie by title
            else if (choice == "3")
            {
                Console.WriteLine("Enter a partial title to search for: ");
                string searchTitle = Console.ReadLine();
                var matchingMovies = _context.FindMovie(searchTitle);
                Console.WriteLine($"Movie titles found with that matches {matchingMovies}");

            }
        }
        while (choice != "4");

        
       
        var movie = _context.GetById(1);
        Console.WriteLine($"Your movie is {movie.Title}");


    }
}
