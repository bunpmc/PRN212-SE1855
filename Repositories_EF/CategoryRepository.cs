﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_EF;
using DataAccessLayer_EF;

namespace Repositories_EF
{
    public class CategoryRepository : ICategoryRepository
    {
        CategoryDAO cd = new CategoryDAO();
        public List<Category> GetCategories()
        {
            return cd.GetCategories();
        }

    }
}
