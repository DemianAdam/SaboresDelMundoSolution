using DAL.Ingredientes.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Ingredientes.Contracts
{
    public interface IRecetaCantidadIngredienteRepository
    {
        public void Insert(RecetaCantidadIngredienteModel recetaCantidadIngrediente, SqlConnection? connection = null, SqlTransaction? sqlTransaction = null);
        public void Remove(RecetaCantidadIngredienteModel recetaCantidadIngrediente, SqlConnection? connection = null, SqlTransaction? sqlTransaction = null);
        public void Update(RecetaCantidadIngredienteModel recetaCantidadIngrediente, SqlConnection? connection = null, SqlTransaction? sqlTransaction = null);
        public List<RecetaCantidadIngredienteModel> GetAll(SqlConnection? sqlConnection = null);
        public void RemoveByRecetaId(int recetaId, SqlConnection? connection = null, SqlTransaction? sqlTransaction = null);
        public List<RecetaCantidadIngredienteModel> GetAllByRecetaId(int recetaId, SqlConnection? sqlConnection = null);
    }
}
