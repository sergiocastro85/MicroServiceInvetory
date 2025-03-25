using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.Command.User;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Handlers
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, int>
    {

        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        public AddUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            
        }

        public async Task<int> Handle(AddUserCommand resquest, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(resquest);
            var result = await _userRepository.CreateduserAsync(user);
            return result;
        }

    }
}
