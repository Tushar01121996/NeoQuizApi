using AutoMapper;
using QuickQuestionBank.Domain.DTOs;
using QuickQuestionBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.AutoMapperProfiles
{
    public class QuizMapperProfile:Profile  
    {
        public QuizMapperProfile()
        {
            CreateMap<Quiz,QuizDTO>().ReverseMap();
            CreateMap<QuizDTO,Quiz>();
        }
    }
}
