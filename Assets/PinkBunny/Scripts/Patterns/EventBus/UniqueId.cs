﻿using System;

namespace Laphed.InterfacesEventBus
{
    public record UniqueId
    {
        public string Id => id ??= Guid.NewGuid().ToString();
        private string id;

        public static implicit operator string(UniqueId uniqueId) => uniqueId.Id;
    }
}