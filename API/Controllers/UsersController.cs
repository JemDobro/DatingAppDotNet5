﻿using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDTO>>>GetUsers()
        {
            return Ok(await _userRepository.GetMembersAsync());
        }
       
        //[HttpGet("{id}")]
        //public async Task<ActionResult<AppUser>> GetUser(int id)
        //{
        //    return await _userRepository.GetUserByIdAsync(id);
        //}

        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDTO>> GetUser(string username)
        {
            return await _userRepository.GetMemberAsync(username);
        }
    }
}
