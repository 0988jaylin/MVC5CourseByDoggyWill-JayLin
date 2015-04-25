using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    public class IsEvenNumAttribute : DataTypeAttribute
    {
        public IsEvenNumAttribute()
            : base("IsEvenNum")
        {

        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            int number;
            if (int.TryParse(value.ToString(), out number))
            {
                if (number % 2 != 0)
                {
                    return false;
                }

                return true;
            }
            else
            { 
                return false;
            }
        }
    }
}