using Microsoft.AspNetCore.Components;
using Admin.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Microsoft.JSInterop;

namespace Admin.Client.Pages
{
    public class AddEditCustomerModel : ComponentBase
    {
        [Inject]
        protected HttpClient Http { get; set; }
        [Inject]
        public NavigationManager urlNavigationManager { get; set; }
        [Parameter]
        public string custID { get; set; }
        protected string Title = "Add";
        public Customer cust = new Customer();

        protected override async Task OnParametersSetAsync()
        {
            if (!string.IsNullOrEmpty(custID))
            {
                Title = "Edit";
                cust = await Http.GetFromJsonAsync<Customer>("api/Customer/" + custID);
            }
        }

        protected async Task SaveCustomer()
        {
            if (cust.cust_id != null)
            {
                await Http.PutAsJsonAsync("api/Customer", cust);
            }

            else
            {
                await Http.PostAsJsonAsync("api/Customer", cust);
            }

            Cancel();
        }

        public void Cancel()
        {
            urlNavigationManager.NavigateTo("/customerrecords");
        }
    }
}
