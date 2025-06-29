using BLL.Compartido.Contracts;
using DAL.Compartido.Contracts;
using DAL.Compartido.Models;
using Mapper.Transacciones;
using Mapper.Compartido;
using Entities.Transacciones;


namespace BLL.Compartido.Services
{
    internal class PagoService : IPagoService
    {
        private readonly IPagoRepository pagoRepository;

        public event EventHandler? OnOperationFinished;
        public PagoService(IPagoRepository pagoRepository)
        {
            this.pagoRepository = pagoRepository;
        }
        public List<Pago> GetAll()
        {
            List<Pago> pagos = pagoRepository.GetAll().ToPagos();
            return pagos;
        }
        public void Insert(Pago pago, Transaccion transaccion)
        {
            PagoModel pagoModel = pago.ToModel(transaccion);
            pagoRepository.Insert(pagoModel);
        }

        public void Remove(Pago pago)
        {
            PagoModel pagoModel = pago.ToModel();
            pagoRepository.Remove(pagoModel);
            OnOperationFinished?.Invoke(pago, EventArgs.Empty);
        }

        public void Update(Pago pago, Transaccion transaccion)
        {
            PagoModel pagoModel = pago.ToModel(transaccion);
            pagoRepository.Update(pagoModel);
            OnOperationFinished?.Invoke(pago, EventArgs.Empty);
        }

        public List<Pago> GetAllByTransactionId(Transaccion transaccion)
        {
            TransaccionModel transaccionModel = transaccion.ToModel();
            List<PagoModel> pagosModel = pagoRepository.GetAllByTransactionId(transaccionModel);
            return pagosModel.ToPagos(); 
        }
    }
}
