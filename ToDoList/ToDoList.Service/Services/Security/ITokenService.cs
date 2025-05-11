using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Service.Dtos;

namespace ToDoList.Service.Services.Security;

public interface ITokenService
{
    public string GenerateToken(UserGetDto user);
}