using MediatR;
using TeamHost.Application.Contracts.Profile.PutEditProfile;

namespace TeamHost.Application.Features.Queries.Profile.PutEditProfile;

public class PutEditProfileCommand : PutEditProfileRequest, IRequest<bool>
{
    public PutEditProfileCommand(PutEditProfileRequest request)
        : base(request)
    {
    }
}