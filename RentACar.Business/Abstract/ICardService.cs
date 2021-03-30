using System;
using System.Collections.Generic;
using System.Text;
using RentACar.Core.Utilities.Result;
using RentACar.Entities.Concrete;

namespace RentACar.Business.Abstract
{
    public interface ICardService
    {
        IResult Add(Card card);
        IResult Update(Card card);
        IResult Delete(Card card);
        IDataResult<List<Card>> GetAllCards();
        IDataResult<Card> GetByCustomerId(int id);
        IDataResult<Card> GetbyCardNumber(string cardNumber);
    }
}
