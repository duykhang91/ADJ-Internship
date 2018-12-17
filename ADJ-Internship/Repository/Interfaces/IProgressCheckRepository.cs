﻿using ADJ.DataModel.OrderTrack;
using ADJ.Repository.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADJ.Repository.Interfaces
{
    public interface IProgressCheckRepository : IRepository<ProgressCheck>
    {
       ProgressCheck GetProgressCheckByOrderId(int orderId);
    }
}
