using Microsoft.AspNetCore.Components;
using Admin.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace Admin.Client.Pages
{
    public class AddEditEstablishmentModel : ComponentBase
    {
        [Inject]
        protected HttpClient Http { get; set; }
        [Inject]
        public NavigationManager urlNavigationManager { get; set; }
        [Parameter]
        public string estID { get; set; }
        protected string Title = "Add";
        public Establishment est = new Establishment();

        protected override async Task OnParametersSetAsync()
        {
            if (!string.IsNullOrEmpty(estID))
            {
                Title = "Edit";
                est = await Http.GetFromJsonAsync<Establishment>("api/Establishment/" + estID);
            }
        }

        protected async Task SaveEstablishment()
        {
            if (est.est_id != null)
            {
                await Http.PutAsJsonAsync("api/Establishment", est);
            }

            else
            {
                await Http.PostAsJsonAsync("api/Establishment", est);
            }

            Cancel();
        }

        public void Cancel()
        {
            urlNavigationManager.NavigateTo("/establishmentrecords");
        }
    }
}
