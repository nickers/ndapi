﻿using System;
using System.Runtime.InteropServices;

namespace NdapiManaged.Core
{
    internal delegate IntPtr D2fMalloc(ref D2fContext context, IntPtr size);

    internal delegate IntPtr D2fRealloc(ref D2fContext context, IntPtr ptr, IntPtr newsize);

    internal delegate void D2fFree(ref D2fContext context, IntPtr ptr);

    [StructLayout(LayoutKind.Sequential)]
    internal struct D2fContext
    {
        public IntPtr pidgc_d2fctx;
        public IntPtr cdata_d2fctx;
        public D2fMalloc d2fmalc_d2fctx;
        public D2fFree d2fmfre_d2fctx;
        public D2fRealloc d2fmrlc_d2fctx;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct D2fContextAttributes
    {
        public uint mask_d2fctxa;
        public IntPtr cdata_d2fctxa;
        public D2fMalloc d2fmalc_d2fctxa;
        public D2fFree d2fmfre_d2fctxa;
        public D2fRealloc d2fmrlc_d2fctxa;
    }

}
