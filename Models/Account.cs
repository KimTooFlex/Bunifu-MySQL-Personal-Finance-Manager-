using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace Models
{
     
    public class Account: IModel
    {
        //Columnid
        //ColumncreatedAt
        //Columndescription
        //Columnname

        public long Id { get; private set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime CreatedAt { get; set; }

        //database instance
        Database.MySQL db = Connection.GetNewInstance();
        //constructor new account
        public Account()
        {
            //create 
            Id = -1; //new record
        }

        //load existing ID
        public Account(long accountID)
        {
            //LOAD RECORD FROM TABLE ACCOUNTS IN DB
            db.ExecuteSQL("SELECT * FROM `accounts` WHERE `id`='" + accountID + "' LIMIT 1");
            if (db.records > 0)
            { //EXISTS
                this.Id = long.Parse(db.Results(0, "id"));
                this.Name = db.Results(0, "name");
                this.Description = db.Results(0, "description");
                this.CreatedAt = DateTime.Parse(db.Results(0, "createdAt"));
            }
            else
            {
                //RECORD NOT EXIST , THROW ERROR
                throw new Exception("Accounts Model, Record "+accountID+" Not found");
            }
        }

        //checks if the account instance in null
        public bool IsNull()
        {
            return (this.Id==-1);
        }

        //function to delete 
        public void Delete()
        { 
            //check if is not null (id>=0)
            if (!this.IsNull())
            {
                db.ExecuteNonQuery("DELETE FROM `accounts` WHERE  `id`="+this.Id);
                this.Id = -1;
            }
            else
            {
                throw new Exception("Attempted delete of null Account");
            }
        }
 

        public long Update()
        {
            //code to save data
            //if isNull then insert
            if(this.IsNull())
            {
                this.Id=db.ExecuteNonQuery("INSERT INTO `accounts` (`id`, `name`, `description`, `createdAt`) VALUES (NULL, '"+this.Name+"', '"+this.Description+"', CURRENT_TIMESTAMP);");

            }
            else
            {
                //else update db
                db.ExecuteNonQuery("UPDATE `accounts` SET `name` = '"+this.Name+"', `description` = '"+this.Description+"' WHERE `id` ="+this.Id); 
            }
            return this.Id;
        }

        public override bool Equals(object obj)
        {
            var account = obj as Account;
            return account != null &&
                   Id == account.Id &&
                   Name == account.Name &&
                   Description == account.Description &&
                   CreatedAt == account.CreatedAt;
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
