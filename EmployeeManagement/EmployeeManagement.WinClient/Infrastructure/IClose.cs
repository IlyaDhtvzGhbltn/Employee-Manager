﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.WinClient.Infrastructure
{
    interface IClose
    {
        Action Close { get; set; }
    }
}
