using SosuPower.Entities;

using System.Collections.ObjectModel;

namespace SosuPower.CareApp.ViewModels
{
    public partial class MainPageViewModel: BaseViewModel
    {

        public MainPageViewModel()
        {
            Title = "FORSIDEN";

            var a = new Assignment
            {
                Resident = new()
                {
                    Name = "Ibn Halfdan"
                },
                StartTime = new(2024, 01, 01, 12, 00, 00),
                EndTime = new(2024, 01, 01, 12, 30, 00)
            };
            var b = new Assignment
            {
                Resident = new()
                {
                    Name = "Ib Bifrost"
                },
                StartTime = new(2024, 01, 01, 15, 30, 00),
                EndTime = new(2024, 01, 01, 16, 30, 00)
            };

            TodaysAssignments.Add(a);
            TodaysAssignments.Add(b);
        }


        public ObservableCollection<Assignment> TodaysAssignments { get; } = new();

    }
}