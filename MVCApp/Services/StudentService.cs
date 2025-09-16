using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MVCApp.Models;
using Npgsql;

namespace MVCApp.Services
{
    public class StudentService
    {
        private readonly NpgsqlConnection conn;
        public StudentService(NpgsqlConnection connection)
        {
            conn = connection;

        }
        public async Task<List<Student>> GetAllAsync()
        {
            var student = new List<Student>();
            try
            {
                await conn.OpenAsync();
                using var cmd = new NpgsqlCommand("SELECT c_studid, c_studname, c_dob, c_stream FROM t_student",conn);
                using var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    student.Add(new Student
                    {
                        c_studid = reader.GetInt32(0),
                        c_studname = reader.GetString(1),
                        c_dob = reader.IsDBNull(2) ? null : reader.GetDateTime(2),
                        c_stream = reader.IsDBNull(3) ? null : reader.GetString(3)
                    });
                }
            }
            catch (Exception ex)
            {


            }
            finally
            {
                await conn.CloseAsync();
            }
            return student;
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            try
            {
                await conn.OpenAsync();
                using var cmd = new NpgsqlCommand("SELECT c_studid, c_studname, c_dob, c_stream FROM t_student WHERE c_studid = @id", conn);
                cmd.Parameters.AddWithValue("id", id);
                using var reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {

                    return new Student
                    {
                        c_studid = reader.GetInt32(0),
                        c_studname = reader.GetString(1),
                        c_dob = reader.IsDBNull(2) ? null : reader.GetDateTime(2),
                        c_stream = reader.IsDBNull(3) ? null : reader.GetString(3)
                    };
                }
            }
            catch (Exception ex)
            { }
            finally
            {
                await conn.CloseAsync();
            }

            return null;
        }

        public async Task AddAsync(Student student)
        {
            try
            {
                await conn.OpenAsync();
                using var cmd = new NpgsqlCommand(@"INSERT INTO t_student (c_studname, c_dob, c_stream)
                VALUES (@name, @dob, @stream)", conn);
                cmd.Parameters.AddWithValue("name", student.c_studname);
                cmd.Parameters.AddWithValue("dob", (object?)student.c_dob ?? DBNull.Value);
                cmd.Parameters.AddWithValue("stream", (object?)student.c_stream ?? DBNull.Value);
                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex) { }
            finally
            {
                await conn.CloseAsync();
            }


        }

        public async Task UpdateAsync(Student student)
        {
            try
            {
                await conn.OpenAsync();
                using var cmd = new NpgsqlCommand(@"UPDATE t_student SET c_studname = @name, c_dob = @dob, c_stream = @stream
                WHERE c_studid = @id", conn);
                cmd.Parameters.AddWithValue("name", student.c_studname);
                cmd.Parameters.AddWithValue("dob", (object?)student.c_dob ?? DBNull.Value);
                cmd.Parameters.AddWithValue("stream", (object?)student.c_stream ?? DBNull.Value);
                cmd.Parameters.AddWithValue("id", student.c_studid);
                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex) { }
            finally
            {
                await conn.CloseAsync();
            }


        }
        
        public async Task DeleteAsync(int id)
        {
            try
            {
                await conn.OpenAsync();
                using var cmd = new NpgsqlCommand(@"DELETE FROM t_student WHERE c_studid = @id", conn);
                cmd.Parameters.AddWithValue("id", id);
                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex) { }
            finally
            {
                await conn.CloseAsync();
            }


        }

    }
}