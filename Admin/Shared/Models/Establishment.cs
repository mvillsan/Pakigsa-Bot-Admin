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
    public class Establishment
    {
        [Required]
        public string est_id { get; set; }

        public DateTime date { get; set; }

        [FirestoreProperty]
        [Required]
        public string est_Name { get; set; }

        [FirestoreProperty]
        [Required]
        public string est_Type { get; set; }

        [FirestoreProperty]
        [Required]
        public string est_address { get; set; }

        [FirestoreProperty]
        [Required]
        public string est_phoneNum { get; set; }

        [FirestoreProperty]
        [Required]
        public string est_email { get; set; }

        [FirestoreProperty]
        [Required]
        public string est_status { get; set; }

        [FirestoreProperty]
        [Required]
        public int? est_numOfReservation { get; set; }

        [FirestoreProperty]
        [Required]
        public string est_password { get; set; }

        [FirestoreProperty]
        [Required]
        public string est_image { get; set; }
    }
}
