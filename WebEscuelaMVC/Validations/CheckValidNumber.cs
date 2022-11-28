using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebEscuelaMVC.Validations
{
    public class CheckValidNumber : ValidationAttribute
    {
        public CheckValidNumber() 
        {
            ErrorMessage = "El número debe ser mayor a 100";
        }

        public override bool IsValid(object value)
        {
            int Numero = (int)value;

            if (Numero < 100)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}