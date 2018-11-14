using AutoMapper;
using RentNow.Dtos;
using RentNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace RentNow.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET api/movies

        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.Include(m => m.Genre).ToList().Select(Mapper.Map<Movie , MovieDto>));
        }

        //GET api/movies/1
        public IHttpActionResult GetMovies(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        //POST api/movies

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto moviedto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(moviedto);
            movie.DateAdded = DateTime.Now;
            _context.Movies.Add(movie);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                Console.WriteLine("ERROR: " + ex);
            }
            

            moviedto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id) , moviedto);

        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(MovieDto movieDto , int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var moviesInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (moviesInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(movieDto, moviesInDb);

            _context.SaveChanges();

            return Ok();


        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();

        }



    }
}
