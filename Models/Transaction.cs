using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace Models
{

    public class Transaction : IModel
    {
        //id
        //accountID
        //categoryID
        //typeID
        //modeID
        //amount
        //description
        //notes
        //createdAt

        public long Id { get; private set; }
        public long AccountID { get;   set; }
        public long CategoryID { get;   set; }
        public long TypeID { get;   set; }
        public long ModeID { get;   set; }
        public String Name { get; set; }
        public double Amount { get; set; }
        public String Description { get; set; }
        public String Notes { get; set; }
        public DateTime CreatedAt { get; set; }

        //database instance
        Database.MySQL db = Connection.GetNewInstance();
        //constructor new Transaction
        public Transaction()
        {
            //create 
            Id = -1; //new record
        }

        //load existing ID
        public Transaction(long TransactionID)
        {
            //LOAD RECORD FROM TABLE TransactionS IN DB
            db.ExecuteSQL("SELECT * FROM `transactions` WHERE `id`='" + TransactionID + "' LIMIT 1");
            if (db.records > 0)
            { //EXISTS
                this.Id = long.Parse(db.Results(0, "id"));
                this.AccountID = long.Parse(db.Results(0, "accountID"));
                this.CategoryID = long.Parse(db.Results(0, "categoryID"));
                this.TypeID = long.Parse(db.Results(0, "typeID"));
                this.ModeID = long.Parse(db.Results(0, "modeID"));
                this.Name = db.Results(0, "name");
                this.Amount =double.Parse( db.Results(0, "amount"));
                this.Description = db.Results(0, "description");
                this.Notes = db.Results(0, "notes");
                this.CreatedAt = DateTime.Parse(db.Results(0, "createdAt"));
            }
            else
            {
                //RECORD NOT EXIST , THROW ERROR
                throw new Exception("Transactions Model, Record " + TransactionID + " Not found");
            }
        }

        //checks if the Transaction instance in null
        public bool IsNull()
        {
            return (this.Id == -1);
        }

        //function to delete 
        public void Delete()
        {
            //check if is not null (id>=0)
            if (!this.IsNull())
            {
                db.ExecuteNonQuery("DELETE FROM `transactions` WHERE  `id`=" + this.Id);
                this.Id = -1;
            }
            else
            {
                throw new Exception("Attempted delete of null Transaction");
            }
        }


        public long Update()
        {
            //id
            //accountID
            //categoryID
            //typeID
            //modeID
            //amount
            //description
            //notes
            //createdAt


            //code to save data
            //if isNull then insert
            if (this.IsNull())
            {
                this.Id = db.ExecuteNonQuery("INSERT INTO `transactions` (`id`, `accountID`, `categoryID`, `typeID`, `description`, `amount`, `modeID`, `createdAt`, `notes`) VALUES (NULL, '"+this.AccountID+"', '"+this.CategoryID+"', '"+this.TypeID+"', '"+this.Description+"', '"+this.Amount+"', '"+this.ModeID+"', CURRENT_TIMESTAMP, 'notes');");

            }
            else
            {
                //else update db
                db.ExecuteNonQuery("UPDATE `transactions` SET   `accountID` = '"+this.AccountID+"', `categoryID` = '"+this.CategoryID+"', `typeID` = '"+this.TypeID+"', `description` = '"+this.Description+"', `amount` = '"+this.Amount+"', `modeID` = '"+this.ModeID+"', `notes` = '"+this.Notes+"' WHERE `id` =" + this.Id);
            }
            return this.Id;
        }

        //accountID
        //categoryID
        //typeID
        //modeID


        public Account Account
        {
            get
            {
                return new Account(this.AccountID);
            }
        }

        public Category Category
        {
            get
            {
                return new Category(this.CategoryID);
            }
        }

        public Expenditure Expenditure
        {
            get
            {
                if (Amount<0)
                {
                  return  new Expenditure(this.TypeID);
                }
                else
                {
                    return null;
                }
            }
        }

        public Income Income
        {
            get
            {
                if (Amount > 0)
                {
                    return new Income(this.TypeID);
                }
                else
                {
                    return null;
                }
            }
        }

        public Mode Mode
        {
            get
            {
                return new Mode(this.ModeID);
            }
        }







        public override bool Equals(object obj)
        {
            var Transaction = obj as Transaction;
            return Transaction != null &&
                   Id == Transaction.Id &&
                   Name == Transaction.Name &&
                   Description == Transaction.Description &&
                   CreatedAt == Transaction.CreatedAt;
        }

        public override int GetHashCode()
        {
            var hashCode = 1546327365;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + CreatedAt.GetHashCode();
            return hashCode;
        }
    }
}
