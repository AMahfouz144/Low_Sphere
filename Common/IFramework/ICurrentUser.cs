using System;
using System.Collections.Generic;

namespace Common.Common
{
    public interface ICurrentUser
    {
        Guid Id { get; }
        string UserId { get; }
        string Fullname { get; }
        List<string> Roles { get; }
        Guid TokenId { get; }
    }
}