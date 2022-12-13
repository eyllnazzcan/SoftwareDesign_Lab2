using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public MusicController(IConfiguration configuration,IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select MusicId as ""MusicId"",
                        Playlist as ""Playlist"",
                        AlbumName as ""AlbumName"",
                        SingerName as ""SingerName"",
                        to_char(ReleaseDate,'YYYY-MM-DD') as ""ReleaseDate"",
                        Genre as ""Genre""
                from Music
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MusicAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult(table);
        }


        [HttpPost]
        public JsonResult Post(Music emp)
        {
            string query = @"
                insert into Music (Playlist, AlbumName, SingerName, ReleaseDate, Genre) 
                values               (@Playlist,@AlbumName,@SingerName,@ReleaseDate,@Genre) 
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MusicAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    
                    myCommand.Parameters.AddWithValue("@Playlist", emp.Playlist);
                    myCommand.Parameters.AddWithValue("@AlbumName", emp.AlbumName);
                    myCommand.Parameters.AddWithValue("@SingerName", emp.SingerName);
                    myCommand.Parameters.AddWithValue("@ReleaseDate", Convert.ToDateTime(emp.ReleaseDate));
                    myCommand.Parameters.AddWithValue("@Genre", emp.Genre);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Music emp)
        {
            string query = @"
                update Music
                set Playlist = @Playlist,
                AlbumName = @AlbumName,
                SingerName = @SingerName,
                ReleaseDate = @ReleaseDate,
                Genre = @Genre
                where MusicId=@MusicId 
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MusicAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@MusicId", emp.MusicId);
                    myCommand.Parameters.AddWithValue("@Playlist", emp.Playlist);
                    myCommand.Parameters.AddWithValue("@AlbumName", emp.AlbumName);
                    myCommand.Parameters.AddWithValue("@SingerName", emp.SingerName);
                    myCommand.Parameters.AddWithValue("@ReleaseDate",Convert.ToDateTime(emp.ReleaseDate));
                    myCommand.Parameters.AddWithValue("@Genre", emp.Genre);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                delete from Music
                where MusicId=@MusicId 
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MusicAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@MusicId", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Deleted Successfully");
        }

    }
}
