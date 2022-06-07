using Admin.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Admin.Client.Pages
{
    public class DeleteCustomerModel:ComponentBase
    {
        [Inject]
        protected HttpClient Http { get; set; }
        [Inject]
        public NavigationManager urlNavigationManager { get; set; }
        [Parameter]
        public string custID { get; set; }
        protected string Title = "Delete";
        public Customer cust = new Customer();

        protected override async Task OnParametersSetAsync()
        {
            if (!string.IsNullOrEmpty(custID))
            {
                Title = "Confirm Delete";
                cust = await Http.GetFromJsonAsync<Customer>("api/Customer/" + custID);
            }
        }

        protected async Task DeleteCustomer()
        {

            await Http.DeleteAsync("api/Customer/" + custID);
            Cancel();
        }

        public void Cancel()
        {
            urlNavigationManager.NavigateTo("/customerrecords");
        }
    }
}
