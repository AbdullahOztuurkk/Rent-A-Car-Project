using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RentACar.Business.Abstract;
using RentACar.Business.Constants;
using RentACar.Core.Utilities.Result;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;

namespace RentACar.Business.Concrete
{
    public class CardManager:ICardService
    {
        ICardDal _cardDal;
        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }
        public IResult Add(Card card)
        {
            _cardDal.Add(card);
            return new SuccessResult(Messages.Add_Message(Messages.GetNameDict[typeof(Card)]));
        }

        public IResult Delete(Card card)
        {
            _cardDal.Delete(card);
            return new SuccessResult(Messages.Delete_Message(Messages.GetNameDict[typeof(Card)]));
        }

        public IDataResult<List<Card>> GetAllCards()
        {
            return new SuccessDataResult<List<Card>>(_cardDal.GetAll());
        }

        public IDataResult<Card> GetByCustomerId(int id)
        {
            return new SuccessDataResult<Card>(_cardDal.GetAll(c=>c.CustomerId==id).FirstOrDefault());
        }

        public IResult Update(Card card)
        {
            _cardDal.Update(card);
            return new SuccessResult(Messages.Update_Message(Messages.GetNameDict[typeof(Card)]));
        }
        public IDataResult<Card> GetbyCardNumber(string cardNumber)
        {
            var getCardNumber = _cardDal.GetAll(u => u.CardNumber == cardNumber).FirstOrDefault();
            return new SuccessDataResult<Card>(getCardNumber);
        }
    }
}
