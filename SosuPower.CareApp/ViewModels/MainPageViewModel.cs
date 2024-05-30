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
        }

        private void UpdateAssignments()
        {
            TodaysAssignments.Clear();
            var result = sosuService.GetAssignmentsFor(DateTime.Now, new Employee() { Id = 2 });
            foreach (var assignment in result)
            {
                TodaysAssignments.Add(assignment);
            }
        }
    }
}