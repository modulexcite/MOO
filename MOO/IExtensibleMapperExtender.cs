﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Diogo Lucas">
//
// Copyright (C) 2010 Diogo Lucas
//
// This file is part of Moo.
//
// Moo is free software: you can redistribute it and/or modify
// it under the +terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along Moo.  If not, see http://www.gnu.org/licenses/.
// </copyright>
// <summary>
// Moo is a object-to-object multi-mapper.
// Email: diogo.lucas@gmail.com
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Moo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;

    using Moo.Core;

    /// <summary>
    /// Extends the IExtensibleMapper interface with fluent methods.
    /// </summary>
    public static class IExtensibleMapperExtender
    {
        /// <summary>
        /// Adds a fluent AddMapping method to IExtensibleMapperExtender
        /// </summary>
        /// <typeparam name="TSource">Type of the source object.</typeparam>
        /// <typeparam name="TTarget">Type of the target object.</typeparam>
        /// <param name="mapper">Mapper to extend.</param>
        /// <returns>A ISourceSpec object, for fluent mapping.</returns>
        public static ISourceSpec<TSource, TTarget> AddMapping<TSource, TTarget>(this IExtensibleMapper<TSource, TTarget> mapper)
        {
            return new SourceSpec<TSource, TTarget>(mapper);
        }
    }
}
