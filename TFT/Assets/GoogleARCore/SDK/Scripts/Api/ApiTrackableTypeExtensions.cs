//-----------------------------------------------------------------------
// <copyright file="ApiTrackableTypeExtensions.cs" company="Google">
//
// Copyright 2017 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------

namespace GoogleARCoreInternal
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using GoogleARCore;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented",
    Justification = "Internal")]
    public static class ApiTrackableTypeExtensions
    {
       /* public static ApiTrackableType GetApiTrackableType(this Type type)
        {
            if (type == typeof(TrackedPlane))
            {
                return ApiTrackableType.Plane;
            }
            else if (type == typeof(Trackable))
            {
                return ApiTrackableType.BaseTrackable;
            }
            else
            {
                return ApiTrackableType.Invalid;
            }
        }*/
    }
}
