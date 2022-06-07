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
    public class CustomerDataModel:ComponentBase
    {
        [Inject]
        protected HttpClient Http { get; set; }

        protected List<Customer> custList = new List<Customer>();
        protected Customer cust = new Customer();
        protected string modalTitle { get; set; }
        protected string SearchString { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GetCustomerList();
        }

        protected async Task GetCustomerList()
        {
            custList = await Http.GetFromJsonAsync<List<Customer>>("api/Customer");
        }

        protected async Task SearchCustomer()
        {
            await GetCustomerList();
            if (SearchString != "")
            {
                custList = custList.Where(
                x => x.cust_fname.IndexOf(SearchString,
                StringComparison.OrdinalIgnoreCase) != -1).ToList();
            }
        }
    }
}
