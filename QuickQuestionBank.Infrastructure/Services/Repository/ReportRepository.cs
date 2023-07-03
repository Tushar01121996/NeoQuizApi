using AutoMapper.Internal.Mappers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain;
using QuickQuestionBank.Domain.Entities;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace QuickQuestionBank.Infrastructure.Services.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly QuickQuestionDbContext _context;
        public ReportRepository(QuickQuestionDbContext context, Application.Interfaces.IRepository.IMailService mailService)
        {
            this._context = context;
        }
        public async Task<DataTable> GetAllUserResultbyQuizIdAsync(Guid quizId)
        {
            string str = _context.Database.GetConnectionString();
            SqlConnection con = new SqlConnection(str);
            string query = "exec SP_GETALLUSERATTEMPTS '" + quizId.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query, con); ;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dynamic result = dt;
            //var resultSet = _context.Database.ExecuteSqlRawAsync("exec SP_GETALLUSERATTEMPTS @quizid", parameter.ToArray());
            return dt;
        }

       
    }
}
