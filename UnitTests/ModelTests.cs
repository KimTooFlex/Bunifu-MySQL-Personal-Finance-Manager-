using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
namespace UnitTests
{
    [TestClass]
    public class AccountTests
    {

        #region ACCOUNT
        [TestMethod]
        public void AccountCreateTest()
        {
            Account accountTest = new Account();
            accountTest.Name = "Name test";
            accountTest.Description = "Description test";
            Assert.IsTrue(accountTest.Update() >= 0);
            accountTest.Delete();
        }



        [TestMethod]
        public void  AccountLoadTest()
        {
            Account accountTest = new Account();
            accountTest.Name = "Name test";
            accountTest.Description = "Description test";
            long id = accountTest.Update();
            Account accountTest2 = new Account(id);
            Assert.AreEqual(accountTest.Id, accountTest2.Id);
            accountTest.Delete();
            accountTest2.Delete();
        }

        [TestMethod]
        public void AccountUpdateTest()
        {
            Random r=new Random();
            string expected =  r.Next(0, 10000).ToString();
            Account accountTest = new Account();
            accountTest.Name = "Name test";
            accountTest.Description = "Description test";
            long id = accountTest.Update();
            accountTest.Description = expected;
            accountTest.Update();
            Account accountTest2 = new Account(id);
            Assert.AreEqual(expected, accountTest2.Description);
            accountTest.Delete();
            accountTest2.Delete();
        }


        [TestMethod]
        public void AccountDeleteTest()
        {
            Account accountTest = new Account();
            accountTest.Name = "Name test";
            accountTest.Description = "Description test";
            long id = accountTest.Update();
            Assert.IsFalse(accountTest.IsNull());
            accountTest.Delete();
            Assert.IsTrue(accountTest.IsNull());
        }

        #endregion

        #region CATEGORY
        [TestMethod]
        public void categoryCreateTest()
        {
           
            Category categoryTest = new Category();
            categoryTest.Name = "Name test";
            categoryTest.Description = "Description test";
            Assert.IsTrue(categoryTest.Update() >= 0);
            categoryTest.Delete();
        }



        [TestMethod]
        public void categoryLoadTest()
        {
            Category categoryTest = new Category();
            categoryTest.Name = "Name test";
            categoryTest.Description = "Description test";
            long id = categoryTest.Update();
            Category categoryTest2 = new Category(id);
            Assert.AreEqual(categoryTest.Id, categoryTest2.Id);
            categoryTest.Delete();
            categoryTest2.Delete();
        }

        [TestMethod]
        public void categoryUpdateTest()
        {
            Random r = new Random();
            string expected = r.Next(0, 10000).ToString();
            Category categoryTest = new Category();
            categoryTest.Name = "Name test";
            categoryTest.Description = "Description test";
            long id = categoryTest.Update();
            categoryTest.Description = expected;
            categoryTest.Update();
            Category categoryTest2 = new Category(id);
            Assert.AreEqual(expected, categoryTest2.Description);
            categoryTest.Delete();
            categoryTest2.Delete();
        }


        [TestMethod]
        public void categoryDeleteTest()
        {
            Category categoryTest = new Category();
            categoryTest.Name = "Name test";
            categoryTest.Description = "Description test";
            long id = categoryTest.Update();
            Assert.IsFalse(categoryTest.IsNull());
            categoryTest.Delete();
            Assert.IsTrue(categoryTest.IsNull());
        }

        #endregion

        #region mode
        [TestMethod]
        public void modeCreateTest()
        {

            Mode modeTest = new Mode();
            modeTest.Name = "Name test";
            modeTest.Description = "Description test";
            Assert.IsTrue(modeTest.Update() >= 0);
            modeTest.Delete();
        }



        [TestMethod]
        public void modeLoadTest()
        {
            Mode modeTest = new Mode();
            modeTest.Name = "Name test";
            modeTest.Description = "Description test";
            long id = modeTest.Update();
            Mode modeTest2 = new Mode(id);
            Assert.AreEqual(modeTest.Id, modeTest2.Id);
            modeTest.Delete();
            modeTest2.Delete();
        }

        [TestMethod]
        public void modeUpdateTest()
        {
            Random r = new Random();
            string expected = r.Next(0, 10000).ToString();
            Mode modeTest = new Mode();
            modeTest.Name = "Name test";
            modeTest.Description = "Description test";
            long id = modeTest.Update();
            modeTest.Description = expected;
            modeTest.Update();
            Mode modeTest2 = new Mode(id);
            Assert.AreEqual(expected, modeTest2.Description);
            modeTest.Delete();
            modeTest2.Delete();
        }


        [TestMethod]
        public void modeDeleteTest()
        {
            Mode modeTest = new Mode();
            modeTest.Name = "Name test";
            modeTest.Description = "Description test";
            long id = modeTest.Update();
            Assert.IsFalse(modeTest.IsNull());
            modeTest.Delete();
            Assert.IsTrue(modeTest.IsNull());
        }

        #endregion




        #region Income
        [TestMethod]
        public void IncomeCreateTest()
        {

            Income incomeTest = new Income();
            incomeTest.Name = "Name test";
            incomeTest.Description = "Description test";
            Assert.IsTrue(incomeTest.Update() >= 0);
            incomeTest.Delete();
        }



        [TestMethod]
        public void IncomeLoadTest()
        {
            Income incomeTest = new Income();
            incomeTest.Name = "Name test";
            incomeTest.Description = "Description test";
            long id = incomeTest.Update();
            Income incomeTest2 = new Income(id);
            Assert.AreEqual(incomeTest.Id, incomeTest2.Id);
            incomeTest.Delete();
            incomeTest2.Delete();
        }

        [TestMethod]
        public void IncomeUpdateTest()
        {
            Random r = new Random();
            string expected = r.Next(0, 10000).ToString();
            Income incomeTest = new Income();
            incomeTest.Name = "Name test";
            incomeTest.Description = "Description test";
            long id = incomeTest.Update();
            incomeTest.Description = expected;
            incomeTest.Update();
            Income incomeTest2 = new Income(id);
            Assert.AreEqual(expected, incomeTest2.Description);
            incomeTest.Delete();
            incomeTest2.Delete();
        }


        [TestMethod]
        public void IncomeDeleteTest()
        {
            Income incomeTest = new Income();
            incomeTest.Name = "Name test";
            incomeTest.Description = "Description test";
            long id = incomeTest.Update();
            Assert.IsFalse(incomeTest.IsNull());
            incomeTest.Delete();
            Assert.IsTrue(incomeTest.IsNull());
        }

        #endregion




        #region Expenditure
        [TestMethod]
        public void ExpenditureCreateTest()
        {

            Expenditure ExpenditureTest = new Expenditure();
            ExpenditureTest.Name = "Name test";
            ExpenditureTest.Description = "Description test";
            Assert.IsTrue(ExpenditureTest.Update() >= 0);
            ExpenditureTest.Delete();
        }



        [TestMethod]
        public void ExpenditureLoadTest()
        {
            Expenditure ExpenditureTest = new Expenditure();
            ExpenditureTest.Name = "Name test";
            ExpenditureTest.Description = "Description test";
            long id = ExpenditureTest.Update();
            Expenditure ExpenditureTest2 = new Expenditure(id);
            Assert.AreEqual(ExpenditureTest.Id, ExpenditureTest2.Id);
            ExpenditureTest.Delete();
            ExpenditureTest2.Delete();
        }

        [TestMethod]
        public void ExpenditureUpdateTest()
        {
            Random r = new Random();
            string expected = r.Next(0, 10000).ToString();
            Expenditure ExpenditureTest = new Expenditure();
            ExpenditureTest.Name = "Name test";
            ExpenditureTest.Description = "Description test";
            long id = ExpenditureTest.Update();
            ExpenditureTest.Description = expected;
            ExpenditureTest.Update();
            Expenditure ExpenditureTest2 = new Expenditure(id);
            Assert.AreEqual(expected, ExpenditureTest2.Description);
            ExpenditureTest.Delete();
            ExpenditureTest2.Delete();
        }


        [TestMethod]
        public void ExpenditureDeleteTest()
        {
            Expenditure ExpenditureTest = new Expenditure();
            ExpenditureTest.Name = "Name test";
            ExpenditureTest.Description = "Description test";
            long id = ExpenditureTest.Update();
            Assert.IsFalse(ExpenditureTest.IsNull());
            ExpenditureTest.Delete();
            Assert.IsTrue(ExpenditureTest.IsNull());
        }

        #endregion





        #region Transaction
        [TestMethod]
        public void TransactionCreateTest()
        {

            Transaction TransactionTest = new Transaction();
            TransactionTest.Name = "Name test";
            TransactionTest.Description = "Description test";
            Assert.IsTrue(TransactionTest.Update() >= 0);
            TransactionTest.Delete();
        }



        [TestMethod]
        public void TransactionLoadTest()
        {
            Transaction TransactionTest = new Transaction();
            TransactionTest.Name = "Name test";
            TransactionTest.Description = "Description test";
            long id = TransactionTest.Update();
            Transaction TransactionTest2 = new Transaction(id);
            Assert.AreEqual(TransactionTest.Id, TransactionTest2.Id);
            TransactionTest.Delete();
            TransactionTest2.Delete();
        }

        [TestMethod]
        public void TransactionUpdateTest()
        {
            Random r = new Random();
            string expected = r.Next(0, 10000).ToString();
            Transaction TransactionTest = new Transaction();
            TransactionTest.Name = "Name test";
            TransactionTest.Description = "Description test";
            long id = TransactionTest.Update();
            TransactionTest.Description = expected;
            TransactionTest.Update();
            Transaction TransactionTest2 = new Transaction(id);
            Assert.AreEqual(expected, TransactionTest2.Description);
            TransactionTest.Delete();
            TransactionTest2.Delete();
        }


        [TestMethod]
        public void TransactionDeleteTest()
        {
            Transaction TransactionTest = new Transaction();
            TransactionTest.Name = "Name test";
            TransactionTest.Description = "Description test";
            long id = TransactionTest.Update();
            Assert.IsFalse(TransactionTest.IsNull());
            TransactionTest.Delete();
            Assert.IsTrue(TransactionTest.IsNull());
        }

        #endregion



    }
}
