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
    public class DeleteEstablishmentModel : ComponentBase
    {
        [Inject]
        protected HttpClient Http { get; set; }
        [Inject]
        public NavigationManager urlNavigationManager { get; set; }
        [Parameter]
        public string estID { get; set; }
        protected string Title = "Delete Establishment";
        public Establishment est = new Establishment();

        protected override async Task OnParametersSetAsync()
        {
            if (!string.IsNullOrEmpty(estID))
            {
                Title = "Confirm Delete";
                est = await Http.GetFromJsonAsync<Establishment>("api/Establishment/" + estID);
            }
        }

        protected async Task DeleteEstablishment()
        {
            await Http.DeleteAsync("api/Establishment/" + estID);
            Cancel();
        }

        public void Cancel()
        {
            urlNavigationManager.NavigateTo("/establishmentrecords");
        }
    }
}
