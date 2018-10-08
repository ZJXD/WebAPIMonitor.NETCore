using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Models.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Models.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; }
        public SelectList Genres { get; set; }     // 电影流派列表
        public string MovieGenre { get; set; }     // 查询的电影流派

        /// <summary>
        /// 可搜索接口
        /// </summary>
        /// <param name="searchString">名称搜索条件</param>
        /// <param name="movieGenre">电影流派</param>
        /// <returns></returns>
        public async Task OnGetAsync(string searchString, string movieGenre)
        {
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from m in _context.Movie select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(m => m.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(m => m.Genre == movieGenre);
            }

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            Movie = await movies.ToListAsync();
        }
    }
}
