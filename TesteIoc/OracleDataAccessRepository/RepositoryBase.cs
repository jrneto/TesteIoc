using OracleDataAccessRepository.Extensions;
using System;
using System.Collections.Generic;
using System.Data;

namespace OracleDataAccessRepository
{
    public abstract class RepositoryBase<TEntity> where TEntity : new()
    {
         
        protected IEnumerable<TEntity> ToList(IDbCommand command)
        {
            using (var record = command.ExecuteReader())
            {
                List<TEntity> items = new List<TEntity>();
                while (record.Read())
                {

                    items.Add(Map<TEntity>(record));
                }
                return items;
            }
        } 

        protected TEntity Map<TEntity>(IDataRecord record)
        {
            var objT = Activator.CreateInstance<TEntity>();
            foreach (var property in typeof(TEntity).GetProperties())
            {
                if (record.HasColumn(property.Name) && !record.IsDBNull(record.GetOrdinal(property.Name)))
                    //property.SetValue(objT, Convert.ChangeType(record[property.Name], property.PropertyType ) );
                    property.SetValue(objT, Convert.ChangeType(record[property.Name], property.PropertyType), null); 
            }
            return objT;
        }


        //protected abstract TEntity Map<TEntity>(IDataRecord record);
    }
}
