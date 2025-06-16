using DAL.Compartido.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Compartido.Contracts
{
    public interface IPagoRepository
    {
        List<PagoModel> GetAllByTransactionId(TransaccionModel transaccionModel);
        List<PagoModel> GetAll();
        void Insert(PagoModel pago, SqlConnection? connection = null, SqlTransaction? sqlTransaction = null);
        void Update(PagoModel pago, SqlConnection? connection = null, SqlTransaction? sqlTransaction = null);
        void Remove(PagoModel pago, SqlConnection? connection = null, SqlTransaction? sqlTransaction = null);
        void RemoveByTransactionId(TransaccionModel pago, SqlConnection? connection = null, SqlTransaction? sqlTransaction = null);
    }
}
