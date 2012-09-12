﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Exemplopuro.InfraStructure
{
    public interface ITransactionManager : IDisposable
    {
        void VoteRollBack();
        void VoteCommit();
        void Initialize();
    }
}
