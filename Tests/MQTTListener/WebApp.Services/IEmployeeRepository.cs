﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services;

public interface IEmployeeRepository
{
    IEnumerable<Employee> GetAllEmployees(); 
}
