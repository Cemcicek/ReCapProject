using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        public IResult ReceivePayment(Payment payment)
        {
            if (payment.Amount > 5000)
            {
                return new ErrorResult(Message.InsufficientBalance);
            }
            return new SuccessResult(Message.PaymentCompleted);
        }
    }
}
