﻿using Microsoft.AspNetCore.Identity;

namespace Demo_Product.Models
{
    public class CustomerIdentityValidator:IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = "Parola en az 6 karakter olmalıdır"
            };
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code= "PasswordRequiresUpper",
                Description = "Parola en az bir büyük harf içermelidir."
            };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
             Code= "PasswordRequiresLower",
             Description="Parole en az bir küçük harf içermelidir."
            };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "Parola en az bir alfanümerik karakter içermeldir."
            };
        }
    }
}
