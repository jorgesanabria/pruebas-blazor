using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Services;
using PruebaBlazor.Models;

namespace PruebaBlazor.Base
{
    public class CivilizationsBase : ComponentBase
    {
        [Inject]
        public HttpClient http { get; set; }
        [Inject]
        public IUriHelper url { get; set; }
        public List<Civilization> Civilizations { get; set; }
        protected override async Task OnInitAsync()
        {
            var r = await http.GetJsonAsync<Civilitations>("https://age-of-empires-2-api.herokuapp.com/api/v1/civilizations");
            Civilizations = r.civilizations.ToList();
        }
        protected void IrAlInicio()
        {
            url.NavigateTo("/");
        }
    }
}
