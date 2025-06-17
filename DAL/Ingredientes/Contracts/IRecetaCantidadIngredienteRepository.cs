using DAL.Ingredientes.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Ingredientes.Contracts
{
    internal interface IRecetaCantidadIngredienteRepository
    {
        public void Insert(RecetaCantidadIngredienteModel recetaCantidadIngrediente, SqlConnection connection, SqlTransaction? sqlTransaction = null);
        public void Remove(RecetaCantidadIngredienteModel recetaCantidadIngrediente, SqlConnection connection, SqlTransaction? sqlTransaction = null);
        public void Update(RecetaCantidadIngredienteModel recetaCantidadIngrediente, SqlConnection connection, SqlTransaction? sqlTransaction = null);
        public List<RecetaCantidadIngredienteModel> GetAll(SqlConnection sqlConnection);
        public void RemoveByRecetaId(int recetaId, SqlConnection connection, SqlTransaction? sqlTransaction = null);
    }
}
