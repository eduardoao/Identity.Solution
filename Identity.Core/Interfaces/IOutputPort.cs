﻿

namespace Identity.Core.Interfaces
{
    public interface IOutputPort<in TUseCaseResponse>
    {
        void Handle(TUseCaseResponse response);
    }
}
