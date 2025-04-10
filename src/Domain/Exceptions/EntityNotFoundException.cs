﻿using Domain.Rules;

namespace Domain.Exceptions
{
    public class EntityNotFoundException<T>() : Exception($"{typeof(T).Name} could not be found."), INonSensitiveException
    {
    }
}