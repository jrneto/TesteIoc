using Entidades;
using OracleDataAccessRepository.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

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

        protected IEnumerable<Paciente> ToListPaciente(IDbCommand command)
        {
            using (var record = command.ExecuteReader())
            {
                List<Paciente> items = new List<Paciente>();
                while (record.Read())
                {
                    items.Add(Map2(record));
                }
                return items;
            }
        }

        protected TEntity Map<TEntity>(IDataRecord record)
        {
            var objT = Activator.CreateInstance<TEntity>();
            foreach (var property in typeof(TEntity).GetProperties())
            {
                string attrName = GetAttributeName(property);
                if ( record.HasColumn(attrName) && !record.IsDBNull(record.GetOrdinal(attrName)) )  
                {
                    property.SetValue(objT, Convert.ChangeType(record[attrName], property.PropertyType), null);
                    continue;
                }

                if ( record.HasColumn(property.Name) && !record.IsDBNull(record.GetOrdinal(property.Name)))
                {
                    property.SetValue(objT, Convert.ChangeType(record[property.Name], property.PropertyType), null);
                }
            }
            return objT;
        }

        protected Paciente Map2(IDataRecord record)
        {
            var objT = new Paciente();

            if (record["FIC_INICIAL_ID"] != DBNull.Value)
                objT.Codigo = Convert.ToInt32(record["FIC_INICIAL_ID"]);
            if (record["NOME"] != DBNull.Value)
                objT.Nome = Convert.ToString(record["NOME"]);
            if (record["SOBRENOME"] != DBNull.Value)
                objT.Sobrenome = Convert.ToString(record["SOBRENOME"]);
            if (record["PHONE"] != DBNull.Value)
                objT.celular = Convert.ToString(record["PHONE"]);
            if (record["OPTION_TEL1"] != DBNull.Value)
                objT.OptionCel1 = Convert.ToString(record["OPTION_TEL1"]);
            if (record["OPTION_TEL2"] != DBNull.Value)
                objT.OptionCel2 = Convert.ToString(record["OPTION_TEL2"]);
            if (record["OPTION_TEL3"] != DBNull.Value)
                objT.OptionCel3 = Convert.ToString(record["OPTION_TEL3"]);
            if (record["CFPB_PTNH_COD"] != DBNull.Value)
                objT.CodigoProgramaTNH = Convert.ToString(record["CFPB_PTNH_COD"]);
            if (record["OPTION_CARTEIRINHA_GNDI"] != DBNull.Value)
                objT.OptionCarteirinhaIntermedica = Convert.ToString(record["OPTION_CARTEIRINHA_GNDI"]);
            if (record["KEY"] != DBNull.Value)
                objT.PacienteKey = Convert.ToString(record["KEY"]);
            if (record["SECRET"] != DBNull.Value)
                objT.PacienteSecret = Convert.ToString(record["SECRET"]);


            return objT;
        }


        protected string GetAttributeName(PropertyInfo prop)
        {
            object[] attrs = prop.GetCustomAttributes(true);
            if (attrs != null && attrs.Length > 0)
            {
                return attrs.OfType<ColunaBD>().FirstOrDefault().Name;
            }

            return string.Empty;
        }
        //protected abstract TEntity Map<TEntity>(IDataRecord record);
    }
}
