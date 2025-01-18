using AutoMapper;
using ListRace.BL.DTOs;
using ListRace.BL.Exceptions;
using ListRace.BL.Services.Abstractions;
using ListRace.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace ListRace.BL.Services.Concretes;

public class AccountService : IAccountService
{
    readonly UserManager<IdentityUser> _userManager;
    readonly SignInManager<IdentityUser> _signInManager;
    readonly IMapper _mapper;

    public AccountService(IMapper mapper, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
    {
        _mapper = mapper;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task RegisterAsync(UserRegisterDTO dto)
    {
        if (await _userManager.FindByNameAsync(dto.UserName) is not null) throw new BaseException();

        if (await _userManager.FindByEmailAsync(dto.Email) is not null) throw new BaseException();

        IdentityUser user = _mapper.Map<IdentityUser>(dto);

        IdentityResult res = await _userManager.CreateAsync(user, dto.Password);

        if (!res.Succeeded) throw new BaseException();

        res = await _userManager.AddToRoleAsync(user, Roles.User.ToString());

        if (!res.Succeeded) throw new BaseException();
    }

    public async Task LoginAsync(UserLoginDTO dto)
    {
        IdentityUser user = await _userManager.FindByNameAsync(dto.UserName) ?? throw new BaseException("Credentials are wrong!");

        SignInResult res = await _signInManager.PasswordSignInAsync(user, dto.Password, dto.RememberMe, true);

        if (!res.Succeeded) throw new BaseException("Credentials are wrong!");
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}
