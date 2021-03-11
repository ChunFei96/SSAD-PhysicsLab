using System.Threading.Tasks;
using AutoMapper;
using DAL;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Services.Parent
{
    public partial class ParentService : IParentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
       
        public ParentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }
    }
}
