using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.WinClient.Infrastructure
{
    public class Pagination
    {
        public int TotalCount;
        public int CountOnPage;
        public int CurrentPageNum;

        public int PreviousPageNum;
        public int NextPageNum;

        public bool NextPageExist;
        public bool PreviousPageExist;


        public Pagination(int totalItems, int countOnPage, int currentPage)
        {
            TotalCount = totalItems;
            CountOnPage = countOnPage;
            CurrentPageNum = currentPage;

            if (currentPage == 0)
            {
                if (TotalCount > CountOnPage)
                {
                    NextPageExist = true;
                    NextPageNum = 1;
                }
                PreviousPageExist = false;
                PreviousPageNum = 0;
            }
            else 
            {
                if(TotalCount > (CountOnPage * (CurrentPageNum+1)) ) 
                {
                    NextPageExist = true;
                    NextPageNum = CurrentPageNum + 1;
                }
                if (TotalCount <= (CountOnPage * (CurrentPageNum + 1)) ) 
                {
                    NextPageExist = false;
                    NextPageNum = CurrentPageNum;
                }
                PreviousPageExist = true;
                PreviousPageNum = CurrentPageNum - 1;
            }
        }
    }
}
