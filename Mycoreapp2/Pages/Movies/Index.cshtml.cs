﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mycoreapp2.Models;

namespace Mycoreapp2.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Mycoreapp2.Models.Mycoreapp2Context _context;

        public IndexModel(Mycoreapp2.Models.Mycoreapp2Context context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        public string MovieGenre { get; set; }

        public async Task OnGetAsync(string movieGenre, string searchString)
        { 
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;
        
            var movies = from m in _context.Movie
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
            SearchString = searchString;
        }
    }
}
