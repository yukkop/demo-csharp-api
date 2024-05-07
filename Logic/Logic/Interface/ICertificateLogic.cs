using Logic.Database.Models;
using Logic.Model.Result.Shared;
using Logic.Model.Result.Shared.Obsolete;

namespace Logic.Logic.Interface;

public interface ICertificateLogic: IBaseLogic
{
    public Task<IHandler<bool>> UpdateBytesInfo();
    // TODO to some repo
    public Task UpdateBytesForPeer(Certificate certificate);
}