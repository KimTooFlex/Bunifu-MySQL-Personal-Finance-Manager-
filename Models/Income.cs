using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace Models
{

    public class Income : IModel
    {
        //Columnid
        //ColumncreatedAt
        //Columndescription
        //Columnname

        public long Id { get; private set; }
        public String Name { get; set; }
        public String DeafaultAmount { get; set; }
        public String Description { get; set; }
        public DateTime CreatedAt { get; set; }

        //database instance
        Database.MySQL db = Connection.GetNewInstance();
        //constructor new Income
        public Income()
        {
            //create 
            Id = -1; //new record
        }

        //load existing ID
        public Income(long IncomeID)
        {
            //LOAD RECORD FROM TABLE income IN DB
            db.ExecuteSQL("SELECT * FROM `income` WHERE `id`='" + IncomeID + "' LIMIT 1");
            if (db.records > 0)
            { //EXISTS
                this.Id = long.Parse(db.Results(0, "id"));
                this.Name = db.Results(0, "name");
                this.DeafaultAmount = db.Results(0, "defaultAmount");
                this.Description = db.Results(0, "description");
                this.CreatedAt = DateTime.Parse(db.Results(0, "createdAt"));
            }
            else
            {
                //RECORD NOT EXIST , THROW ERROR
                throw new Exception("income Model, Record " + IncomeID + " Not found");
            }
        }

        //checks if the Income instance in null
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
                db.ExecuteNonQuery("DELETE FROM `income` WHERE  `id`=" + this.Id);
                this.Id = -1;
            }
            else
            {
                throw new Exception("Attempted delete of null Income");
            }
        }


        public long Update()
        {
            //code to save data
            //if isNull then insert
            if (this.IsNull())
            {
                this.Id = db.ExecuteNonQuery("INSERT INTO `income` (`id`, `name`, `description`,`defaultAmount`, `createdAt`) VALUES (NULL, '" + this.Name + "', '" + this.Description + "','"+this.DeafaultAmount+"', CURRENT_TIMESTAMP);");

            }
            else
            {
                //else update db
                db.ExecuteNonQuery("UPDATE `income` SET `name` = '" + this.Name + "', `description` = '" + this.Description + "',`defaultAmount`='"+this.DeafaultAmount+"' WHERE `id` =" + this.Id);
            }
            return this.Id;
        }

        public override bool Equals(object obj)
        {
            var Income = obj as Income;
            return Income != null &&
                   Id == Income.Id &&
                   Name == Income.Name &&
                   Description == Income.Description &&
                   CreatedAt == Income.CreatedAt;
        }

        public override int GetHashCode()
        {
            var hashCode = 1546327365;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DeafaultAmount);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + CreatedAt.GetHashCode();
            return hashCode;
        }
    }
}
