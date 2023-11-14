﻿using ProgramacionIII.Data.Context;
using ProgramacionIII.Services.Interfaces;

namespace ProgramacionIII.Services.Implementations
{
    public class SaleOrderLineService : ISaleOrderLineService
    {
        private readonly EcommerceContext _context;

        public SaleOrderLineService(EcommerceContext context) 
        {
            _context = context;
        }
    }
}
