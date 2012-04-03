﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using Lokad.Cqrs.TapeStorage;
using NUnit.Framework;

namespace Lokad.Cqrs.Feature.TapeStorage
{
    [TestFixture]
    public sealed class MemoryTapeStorageTests : TapeStorageTests
    {
        // ReSharper disable InconsistentNaming

        readonly ConcurrentDictionary<string, List<byte[]>> _storage = new ConcurrentDictionary<string, List<byte[]>>();
        MemoryTapeContainer _storageFactory;

        protected override void PrepareEnvironment()
        {
        }

        protected override ITapeStream InitializeAndGetTapeStorage()
        {
            _storageFactory = new MemoryTapeContainer(_storage, "default");
            

            const string name = "Memory";
            return _storageFactory.GetOrCreateStream(name);
        }

        protected override void FreeResources()
        {
            _storageFactory = null;
        }

        protected override void TearDownEnvironment()
        {
            _storage.Clear();
        }
    }
}