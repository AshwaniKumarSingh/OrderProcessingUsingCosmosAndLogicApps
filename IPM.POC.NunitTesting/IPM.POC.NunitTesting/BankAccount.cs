using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace IPM.POC.NunitTesting
{
  public  class BankAccount
    {
        public int  Amount { get; set; }

        public BankAccount( int amount)
        {
            this.Amount = amount;

        }
        public void Deposite(int Amount)
        {
            if (Amount <= 0) throw new ArgumentException("Deposit amount must be positive", nameof(Amount));
            this.Amount = this.Amount + Amount;
           

        }
        public void WithDraw(int ammount)
        {
            this.Amount = this.Amount- ammount;

        }

        [TestFixture]
        public class BankFunctionalityTest
        {

            private BankAccount ba;

            [SetUp]
            public void Setup()
            {
                 ba = new BankAccount(500);
            }

            [Test]
            public void BankWithDrawalDeducltionTest()
            {
              
                ba.Deposite(200);
                Assert.That(ba.Amount, Is.EqualTo(700));
            }

            [Test]
            public void BankWithDrawalTest()
            {
               ba.WithDraw(100);
                Assert.Multiple(() =>
                    {
                        Assert.That(ba.Amount, Is.EqualTo(400));
                        Assert.That(ba.Amount, Is.EqualTo(400));
                    }
                );
                Assert.That(ba.Amount, Is.EqualTo(400));

            }
            [Test]
            public void BankAccountThrowOnNonPositiveAmount()
            {


               var ex=  Assert.Throws<ArgumentException>(
                    () => ba.Deposite(-1)
                );

                StringAssert.StartsWith("Deposit amount must be positive", ex.Message);
            }



        }


    }
}
