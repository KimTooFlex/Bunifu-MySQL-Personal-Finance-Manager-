using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //the interface to represent our default class models
    interface IModel
    { 

        void Delete();
        long Update();

        bool IsNull();

        bool Equals(object obj);
        int GetHashCode();
    }
}
