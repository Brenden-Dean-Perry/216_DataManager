﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralFormLibrary1
{
    public interface IDataAccess<T> where T: class
    {
        Task<T> Get(int Id);

        Task<List<T>> GetAll();

        Task<bool> Delete(T entity);

        Task<int> Add(T entity);

        Task<bool> Update(T entity);
    }
}