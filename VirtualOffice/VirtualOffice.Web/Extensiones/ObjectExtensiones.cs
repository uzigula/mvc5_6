using System;

namespace System
{
    public static class ObjectExtensiones
    {
        public static bool EsNulo(this object objeto)
        {
            return (objeto == null);
        }
    }
}