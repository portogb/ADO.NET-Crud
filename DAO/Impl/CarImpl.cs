using ConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DAO.Impl
{
    public class CarImpl : CrudDao<Car>
    {
        public async Task<int> SaveAsync(Car car)
        {
            int row;
            string query = string.Format
            (
                @"insert into Car(Name, Color, CarKey)
                values (@Name, @Color, @CarKey);"
                + @"Select @@Identity", car.Name, car.Color, car.CarKey
            );

            using (SqlConnection conn = new SqlConnection(DataBaseHelper.ConnectionString))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand(query, conn);

                command.Parameters.AddWithValue("@Name", car.Name);
                command.Parameters.AddWithValue("@Color", car.Color);
                command.Parameters.AddWithValue("@CarKey", car.CarKey);

                row = Convert.ToInt32(await command.ExecuteScalarAsync());
            }
            return row;
        }

        public async Task<List<Car>> GetAllAsync()
        {
            List<Car> list = new();
            string query = string.Format("select * from Car");

            using (SqlConnection conn = new SqlConnection(DataBaseHelper.ConnectionString))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader dataReader = await command.ExecuteReaderAsync();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Car car = new();

                        car.Id = Convert.ToInt32(dataReader["CarId"]);
                        car.Name = dataReader["Name"].ToString();
                        car.Color = dataReader["Color"].ToString();
                        car.CarKey = Convert.ToInt32(dataReader["CarKey"]);

                        list.Add(car);
                    }
                }
            }
            return list;
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            Car car = new Car();
            string query = string.Format("select * from Car where CarId = {0}", id);

            using (SqlConnection conn = new SqlConnection(DataBaseHelper.ConnectionString))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader dataReader = await command.ExecuteReaderAsync();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        car.Id = Convert.ToInt32(dataReader["CarId"]);
                        car.Name = dataReader["Name"].ToString();
                        car.Color = dataReader["Color"].ToString();
                        car.CarKey = Convert.ToInt32(dataReader["CarKey"]);
                    }
                }
            }
            return car;
        }

        public async Task<int> UpdateAsync(Car car, int id)
        {
            int row;
            string query = string.Format
            (
                @"update Car Set 
                Name = @Name, Color = @Color, CarKey = @CarKey
                where CarId = @CarId"
            );

            using (SqlConnection conn = new SqlConnection(DataBaseHelper.ConnectionString))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand(query, conn);

                command.Parameters.AddWithValue("@Name", car.Name);
                command.Parameters.AddWithValue("@Color", car.Color);
                command.Parameters.AddWithValue("@CarKey", car.CarKey);
                command.Parameters.AddWithValue("@CarId", id);

                row = Convert.ToInt32(await command.ExecuteNonQueryAsync());
            }
            return row;
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            int row;
            string query = string.Format("delete from Car where CarId={0}", id);

            using (SqlConnection conn = new SqlConnection(DataBaseHelper.ConnectionString))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@CarId", id);

                row = await command.ExecuteNonQueryAsync();
            }
            
            return row;
        }

    }
}
