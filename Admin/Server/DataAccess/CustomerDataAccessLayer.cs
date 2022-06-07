using Admin.Shared.Models;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Server.DataAccess
{
    public class CustomerDataAccessLayer
    {
        string projectID;
        FirestoreDb firestoreDb;

        public CustomerDataAccessLayer()
        {
            string filepath = "E:\\Louise Ann\\Documents\\IT-CAPSTONE41\\PAKIGSA_BOT_ADMIN\\pakigsa-bot-bca7e-firebase-adminsdk-4fhe7-84b63e229d.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "pakigsa-bot-bca7e";
            firestoreDb = FirestoreDb.Create(projectID);
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            try
            {
                Query custQuery = firestoreDb.Collection("customers");
                QuerySnapshot custQuerySnapshot = await custQuery.GetSnapshotAsync();
                List<Customer> lstCustomer = new List<Customer>();

                foreach (DocumentSnapshot docSnap in custQuerySnapshot.Documents)
                {
                    if (docSnap.Exists)
                    {
                        Dictionary<string, object> cust = docSnap.ToDictionary();
                        string json = JsonConvert.SerializeObject(cust);
                        Customer newCust = JsonConvert.DeserializeObject<Customer>(json);

                        newCust.cust_id = docSnap.Id;
                        newCust.date = docSnap.CreateTime.Value.ToDateTime();
                        lstCustomer.Add(newCust);
                    }
                }

                List<Customer> storeCustomerList = lstCustomer.OrderBy(x => x.date).ToList();
                return storeCustomerList;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public async void AddCustomer(Customer customer)
        {
            try
            {
                CollectionReference collRef = firestoreDb.Collection("customers");
                await collRef.AddAsync(customer);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public async void UpdateCustomer(Customer customer)
        {
            try
            {
                DocumentReference docRefUpdate = firestoreDb.Collection("customers").Document(customer.cust_id);
                await docRefUpdate.SetAsync(customer, SetOptions.Overwrite);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Customer> GetCustomerData(string id)
        {
            try
            {
                DocumentReference docRef = firestoreDb.Collection("customers").Document(id);
                DocumentSnapshot docSnap = await docRef.GetSnapshotAsync();

                if (docSnap.Exists)
                {
                    Customer cust = docSnap.ConvertTo<Customer>();
                    cust.cust_id = docSnap.Id;
                    return cust;
                }

                else
                {
                    return new Customer();
                }
            }

            catch (Exception)
            {
                throw;
            }
        }

        public async void DeleteCustomer(string id)
        {
            try
            {
                DocumentReference docRef = firestoreDb.Collection("customers").Document(id);
                await docRef.DeleteAsync();
            }

            catch (Exception)
            {
                throw;
            }
        }
    }


}
