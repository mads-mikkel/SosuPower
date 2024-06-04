using SosuPower.Entities;
using SosuPower.Services;

using System.Collections.ObjectModel;

namespace SosuPower.CareApp.ViewModels
{
    public partial class MainPageViewModel: BaseViewModel
    {
        private readonly ISosuService sosuService;

        public ObservableCollection<Assignment> TodaysAssignments { get; } = new();

        public MainPageViewModel(ISosuService sosuService)
        {
            Title = "FORSIDEN";
            this.sosuService = sosuService;            
            UpdateAssignments();
        }        

        private async void UpdateAssignments()
        {
            TodaysAssignments.Clear();
            
            var result = await sosuService.GetAssignmentsForAsync(new DateTime(2024,05,24), new Employee() { Id = 2008 });
            foreach (var assignment in result)
            {
                TodaysAssignments.Add(assignment);                
            }
        }
    }
}