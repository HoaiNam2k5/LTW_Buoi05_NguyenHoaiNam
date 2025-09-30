using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Buoi05.Models;

namespace Buoi05.ViewModels
{
    public class DepartmentViewModel
    {
        public Deparment Department    { get; set; }
        public List<DepartmentViewModel> Departments { get; set; }
    }
}