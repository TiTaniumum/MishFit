using AutoMapper;
using MishFit.Entities;
using MishFit.Responses;

namespace MishFit.Profiles;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Tracker, TrackerResponse>();
    }
}