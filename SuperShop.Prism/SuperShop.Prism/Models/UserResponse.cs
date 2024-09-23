using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.Prism.Models
{
   public class UserResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedEmail {  get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed {  get; set; }
        public string PasswordHash {  get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public object PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnable {  get; set; }
        public object LockOutEnd {  get; set; }
        public object LockOutEnable { get; set; }
        public int AccessFailedCount { get; set; }




    }
}
