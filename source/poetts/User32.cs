using System;
using System.Runtime.InteropServices;

namespace poetts
{
    internal static partial class User32
    {
        [StructLayout(LayoutKind.Sequential)]
        internal struct Rect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [LibraryImport("user32.dll")]
        internal static partial IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

        [LibraryImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static partial bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [LibraryImport("user32.dll", EntryPoint = "SetProcessDPIAware", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static partial bool SetProcessDpiAware();
    }
}
