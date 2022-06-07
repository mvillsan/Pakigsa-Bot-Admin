using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Shared
{
    [FirestoreData]
    public class User
    {
        public string admin_id { get; set; }

        [FirestoreProperty]
        public string admin_email { get; set; }
        [FirestoreProperty]

        public string admin_password { get; set; }
    }
}
