using System.Collections.Generic;
using MySql.Data.MySqlClient;
using BestRestaurants;
using System;

namespace BestRestaurants.Models
{
  public class Restaurant
  {
    private string _name;
    private string _city;
    private int _rating;
    private int _cuisineId;
    private int _restaurantId;
    // private static List<Restaurant> _restaurantList = new List<Restaurant> {};

    public Restaurant (string name, string city, int rating, int cuisineId, int restaurantId = 0;)
    {
      _name = name;
      _city = city;
      _rating = rating;
      _cuisineId = cuisineId;
      _restaurantId = restaurantId;

    }
    public string GetName()
    {
      return _name;
    }

    public string GetCity()
    {
      return _city;
    }

    public int GetRating()
    {
      return _rating;
    }

    public int GetCuisineId()
    {
      return _cuisineId;
    }

    // public void DeleteAll()
    // {
    //   Clear();
    // }
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"Insert Into restaurants (name, city, rating, cuisine_Id) VALUES (@name, @city, @rating, @cuisineId)";

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@name";
      name.Value = this._name;
      cmd.Parameters.Add(name);

      MySqlParameter city = new MySqlParameter();
      city.ParameterName = "@city";
      city.Value = this._city;
      cmd.Parameters.Add(city);

      MySqlParameter rating = new MySqlParameter();
      rating.ParameterName = "@rating";
      rating.Value = this._rating;
      cmd.Parameters.Add(rating);

      MySqlParameter cuisine_Id = new MySqlParameter();
      cuisine_Id.ParameterName = "@cuisineId";
      cuisine_Id.Value = this._cuisineId;
      cmd.Parameters.Add(cuisine_Id);

      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Restaurant> GetAll()
    {
      List<Restaurant> allRestaurants = new List<Restaurant> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlConnection cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM restaurants";
      MySQLDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int restaurantId = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string city = rdr.GetString(2);
        int rating = rdr.GetInt(3);
        int cuisineId = rdr.GetInt(4);
        Restaurant newRestaurant = new Restaurant (name, city, rating, cuisineId, restaurantId);
        allRestaurants.Add(newRestaurants);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allRestaurants;
    }

    public void Edit (string newRestaurant)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE restaurants SET name "
    }
  }
}