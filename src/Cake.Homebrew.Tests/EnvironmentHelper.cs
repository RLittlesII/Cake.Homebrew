/*
* Copyright (c) .NET Foundation and Contributors.
* Copyrights licensed under the MIT License.
* See https://github.com/cake-build/cake/blob/main/LICENSE for terms.
*/

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using Cake.Core;

namespace Cake.Homebrew.Tests
{
    internal static class EnvironmentHelper
    {
#if !NETCORE
        private static bool? _isRunningOnMac;
#endif

        public static bool Is64BitOperativeSystem()
        {
#if NETCORE
            return RuntimeInformation.OSArchitecture == Architecture.X64
                || RuntimeInformation.OSArchitecture == Architecture.Arm64;
#else
            return Environment.Is64BitOperatingSystem;
#endif
        }

        public static PlatformFamily GetPlatformFamily()
        {
#if NETCORE
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return PlatformFamily.OSX;
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return PlatformFamily.Linux;
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return PlatformFamily.Windows;
            }
#else
            var platform = (int)Environment.OSVersion.Platform;
            if (platform <= 3 || platform == 5)
            {
                return PlatformFamily.Windows;
            }
            if (!_isRunningOnMac.HasValue)
            {
                _isRunningOnMac = Native.MacOSX.IsRunningOnMac();
            }
            if (_isRunningOnMac ?? false || platform == (int)PlatformID.MacOSX)
            {
                return PlatformFamily.OSX;
            }
            if (platform == 4 || platform == 6 || platform == 128)
            {
                return PlatformFamily.Linux;
            }
#endif
            return PlatformFamily.Unknown;
        }

        public static bool IsCoreClr()
        {
#if NETCORE
            return true;
#else
            return false;
#endif
        }

        public static bool IsUnix()
        {
            return IsUnix(GetPlatformFamily());
        }

        public static bool IsUnix(PlatformFamily family)
        {
            return family == PlatformFamily.Linux
                || family == PlatformFamily.OSX;
        }

        public static FrameworkName GetFramework()
        {
#if NETCORE
            return new FrameworkName(".NETStandard,Version=v1.6");
#else
            return new FrameworkName(".NETFramework,Version=v4.6.1");
#endif
        }
    }
}
