﻿namespace MySchool.Server.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        List<T> GetAll();

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
