using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Shared.Models
{
    [FirestoreData]
    public class Customer
    {
        [Required]
        public string cust_id { get; set; }

        public DateTime date { get; set; }

        [FirestoreProperty]
        [Required]
        public string cust_fname { get; set; }

        [FirestoreProperty]
        [Required]
        public string cust_lname { get; set; }

        [FirestoreProperty]
        [Required]
        public string cust_gender { get; set; }

        [FirestoreProperty]
        [Required]
        public string cust_birthDate { get; set; }

        [FirestoreProperty]
        [Required]
        public string cust_phoneNum { get; set; }

        [FirestoreProperty]
        [Required]
        public string cust_email { get; set; }

        [FirestoreProperty]
        [Required]
        public int? cust_numOfReservations { get; set; }

        [FirestoreProperty]
        [Required]
        public string cust_status { get; set; }

        [FirestoreProperty]
        [Required]
        public string cust_password { get; set; }

        [FirestoreProperty]
        [Required]
        public string cust_image { get; set; }
    }
}
