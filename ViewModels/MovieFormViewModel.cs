using RentNow.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentNow.ViewModels
{
    public class MovieFormViewModel
    {
        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            NumberInStock = movie.NumberInStock;
            ReleaseDate = movie.ReleaseDate;
            GenreId = movie.GenreId;
        }

        public IEnumerable<Genre> Genre { get; set; }
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        
        public string Name { get; set; }

        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        [Required]
        public int? NumberInStock { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }


        [Required]
        public byte GenreId { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }
    }
}