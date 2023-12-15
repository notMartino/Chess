using Chess.Application.DTOs;
using Chess.Application.Services.Interfaces;
using Chess.Domain.Entities;
using Chess.Infrastructure.DAL;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Application.Services.Implementation
{
    public class BoxService : IBoxService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BoxService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<BoxDTO>> GetAll(Expression<Func<Box, bool>> filter = null, Func<IQueryable<Box>, IOrderedQueryable<Box>> orderBy = null, List<string> includes = null)
        {
            List<Box> boxes = await _unitOfWork.boxRepository.GetAll(filter, orderBy, includes);

            List<BoxDTO> boxesDTO = _mapper.Map<List<BoxDTO>>(boxes);

            throw new NotImplementedException();
        }

        public async Task<BoxDTO> Get(Expression<Func<Box, bool>> filter = null, List<string> includes = null)
        {
            Box box = await _unitOfWork.boxRepository.Get(filter, includes);
            BoxDTO boxDTO = new();

            if (box != null)
                boxDTO = _mapper.Map<BoxDTO>(box);

            return boxDTO;
        }

    }
}
