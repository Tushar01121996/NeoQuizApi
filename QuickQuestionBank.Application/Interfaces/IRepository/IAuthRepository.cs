﻿using QuickQuestionBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Interfaces.IRepository
{
    public interface IAuthRepository
    {
        bool LoginAsync(LoginUser login);

    }
}
