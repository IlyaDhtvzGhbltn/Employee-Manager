using EmployeeManagement.WinClient.DAL;
using EmployeeManagement.WinClient.Infrastructure;
using EmployeeManagement.WinClient.Infrastructure.Commands;
using EmployeeManagement.WinClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace EmployeeManagement.WinClient.ViewModels
{
    public class EmploeeListViewModel : ViewModelBase
    {
        private ObservableCollection<EmployeeModel> _emploeeList;
        private readonly IDataProvider _dataProvider;
        private readonly AsyncCommand _updateListCommand;

        private int _totalItems;
        private int _currentPage;
        private int _nextPage;
        private int _previousPage;
        private bool _nextPageExists;
        private bool _previousPageExists;

        public int TotalItems
        {
            get
            {
                return _totalItems;
            }
            set
            {
                SetProperty(ref _totalItems, value);
            }
        }
        public int CurrentPage 
        {
            get
            {
                return _currentPage; 
            }
            set 
            {
                SetProperty(ref _currentPage, value);
            }
        }
        public int NextPage 
        { 
            get 
            {
                return _nextPage; 
            }
            set 
            {
                SetProperty(ref _nextPage, value);
            }
        }
        public int PreviousPage
        {
            get
            {
                return _previousPage;
            }
            set
            {
                SetProperty(ref _previousPage, value);
            }
        }
        public bool NextPageExists
        {
            get
            {
                return _nextPageExists;
            }
            set
            {
                SetProperty(ref _nextPageExists, value);
            }
        }
        public bool PreviousPageExists
        {
            get
            {
                return _previousPageExists;
            }
            set
            {
                SetProperty(ref _previousPageExists, value);
            }
        }

        public ObservableCollection<EmployeeModel> EmploeeList
        {
            get
            {
                return _emploeeList;
            }
            set
            {
                SetProperty(ref _emploeeList, value);
            }
        }
        public ICommand UpdateListCommand => _updateListCommand;
        public readonly int EmploeeOnScreen = 50;


        public EmploeeListViewModel()
        {
            _dataProvider = new SimplestDataProvider();
            _updateListCommand = new UpdateEmploeeListCommand(this, _dataProvider);
            Seed();
        }

        protected async void Seed()
        {
            EmploeeList = await _dataProvider.GetEmployeeList(EmploeeOnScreen, 0);
            _totalItems = await _dataProvider.GetEmploeeCount();
            var Pagination = new Pagination(_totalItems, EmploeeOnScreen, 0);

            PreviousPageExists = Pagination.PreviousPageExist;
            PreviousPage = Pagination.PreviousPageNum;
            NextPageExists = Pagination.NextPageExist;
            NextPage = Pagination.NextPageNum;
        }

    }
}
