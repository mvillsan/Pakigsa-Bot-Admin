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
    public class EstablishmentDataModel : ComponentBase
    {
        [Inject]
        protected HttpClient Http { get; set; }

        protected List<Establishment> estList = new List<Establishment>();
        protected Establishment est = new Establishment();
        protected string modalTitle { get; set; }
        protected string SearchString { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GetEstablishmentList();
        }

        protected async Task GetEstablishmentList()
        {
            estList = await Http.GetFromJsonAsync<List<Establishment>>("api/Establishment");
        }

        protected async Task SearchEstablishment()
        {
            await GetEstablishmentList();
            if (SearchString != "")
            {
                estList = estList.Where(
                x => x.est_Name.IndexOf(SearchString,
                StringComparison.OrdinalIgnoreCase) != -1).ToList();
            }
        }
    }
}
