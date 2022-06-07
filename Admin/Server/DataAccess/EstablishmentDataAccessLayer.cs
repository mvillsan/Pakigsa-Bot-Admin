using Admin.Shared.Models;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Server.DataAccess
{
    public class EstablishmentDataAccessLayer
    {
        string projectID;
        FirestoreDb firestoreDb;

        public EstablishmentDataAccessLayer()
        {
            string filepath = "E:\\Louise Ann\\Documents\\IT-CAPSTONE41\\PAKIGSA_BOT_ADMIN\\pakigsa-bot-bca7e-firebase-adminsdk-4fhe7-84b63e229d.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "pakigsa-bot-bca7e";
            firestoreDb = FirestoreDb.Create(projectID);
        }

        public async Task<List<Establishment>> GetAllEstablishments()
        {
            try
            {
                Query estQuery = firestoreDb.Collection("establishments");
                QuerySnapshot estQuerySnapshot = await estQuery.GetSnapshotAsync();
                List<Establishment> lstEstablishment = new List<Establishment>();

                foreach (DocumentSnapshot docSnap in estQuerySnapshot.Documents)
                {
                    if (docSnap.Exists)
                    {
                        Dictionary<string, object> est = docSnap.ToDictionary();
                        string json = JsonConvert.SerializeObject(est);
                        Establishment newEst = JsonConvert.DeserializeObject<Establishment>(json);

                        newEst.est_id = docSnap.Id;
                        newEst.date = docSnap.CreateTime.Value.ToDateTime();
                        lstEstablishment.Add(newEst);
                    }
                }

                List<Establishment> storeEstablishmentList = lstEstablishment.OrderBy(x => x.date).ToList();
                return storeEstablishmentList;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public async void AddEstablishment(Establishment establishment)
        {
            try
            {
                CollectionReference collRef = firestoreDb.Collection("establishments");
                await collRef.AddAsync(establishment);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public async void UpdateEstablishment(Establishment establishment)
        {
            try
            {
                DocumentReference docRefUpdate = firestoreDb.Collection("establishments").Document(establishment.est_id);
                await docRefUpdate.SetAsync(establishment, SetOptions.Overwrite);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Establishment> GetEstablishmentData(string id)
        {
            try
            {
                DocumentReference docRef = firestoreDb.Collection("establishments").Document(id);
                DocumentSnapshot docSnap = await docRef.GetSnapshotAsync();

                if (docSnap.Exists)
                {
                    Establishment est = docSnap.ConvertTo<Establishment>();
                    est.est_id = docSnap.Id;
                    return est;
                }

                else
                {
                    return new Establishment();
                }
            }

            catch (Exception)
            {
                throw;
            }
        }

        public async void DeleteEstablishment(string id)
        {
            try
            {
                DocumentReference docRef = firestoreDb.Collection("establishments").Document(id);
                await docRef.DeleteAsync();
            }

            catch (Exception)
            {
                throw;
            }
        }
    }


}
