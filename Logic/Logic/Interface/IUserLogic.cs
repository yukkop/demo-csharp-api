using Logic.Database.Models;
using Logic.Enum;
using Logic.Model.Dto;
using Logic.Model.Dto.User;
using Logic.Model.Result.Shared;
using Logic.Model.Result.UserLogic;

namespace Logic.Logic.Interface;

public interface IUserLogic: IBaseLogic
{
    public Task<IGetTockenResult> GetToken(LoginRequestModel model);

    public Task<List<User>> GetAll();

    public Task<HandlerResult<string>> Register(RegisterRequestModel model, UserRoleEnum role);

    public Task<HandlerResult> Delete(Guid id);
}
