﻿using DAL.Ingredientes.Models;
using DAL.Insumos.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Ingredientes.Contracts
{
    internal interface IIngredienteRepository
    {
        public int Insert(IngredienteModel ingrediente, SqlConnection connection, SqlTransaction? sqlTransaction = null);
        public List<IngredienteModel> GetAll(SqlConnection sqlConnection, SqlTransaction? sqlTransaction = null);
        void RemoveByInsumo(InsumoModel insumo, SqlConnection sqlConnection, SqlTransaction? sqlTransaction = null);
    }
}
