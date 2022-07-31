using EmployeeManagement.WinClient.DAL;
using EmployeeManagement.WinClient.ViewModels;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.WinClient.Infrastructure.Commands
{
    public class UpdateEmploeeListCommand : AsyncCommand
    {

        private readonly IDataProvider _dataProvider;
        protected readonly EmploeeListViewModel _emploeeListViewModel;


        public UpdateEmploeeListCommand(EmploeeListViewModel emploeeListViewModel, IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            _emploeeListViewModel = emploeeListViewModel;
        }


        protected override async Task ExecuteCommandAsync(object parameter)
        {
            await Task.Run(async ()=> 
            {
                //Thread.Sleep(10000);
                int page = (int)parameter;
                int onScreen = _emploeeListViewModel.EmploeeOnScreen;
                _emploeeListViewModel.EmploeeList = await _dataProvider.GetEmployeeList(onScreen, page * onScreen);

                Pagination pag = new Pagination(_emploeeListViewModel.TotalItems, _emploeeListViewModel.EmploeeOnScreen, page);
                _emploeeListViewModel.CurrentPage = page;
                _emploeeListViewModel.NextPage = pag.NextPageNum;
                _emploeeListViewModel.NextPageExists = pag.NextPageExist;
                _emploeeListViewModel.PreviousPage = pag.PreviousPageNum;
                _emploeeListViewModel.PreviousPageExists = pag.PreviousPageExist;
            });

        }
    }
}
