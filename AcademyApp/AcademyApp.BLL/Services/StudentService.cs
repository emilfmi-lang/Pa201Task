using AcademyApp.DLL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApp.BLL.Services
{
    internal class StudentService
    {
        private readonly AppDbContext _appDbContext;
        public StudentService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
