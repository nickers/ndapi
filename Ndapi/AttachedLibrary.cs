﻿using Ndapi.Core;
using Ndapi.Core.Handles;
using Ndapi.Enums;

namespace Ndapi
{
    /// <summary>
    /// Represents an attached library object.
    /// </summary>
    public class AttachedLibrary : NdapiObject
    {
        /// <summary>
        /// Create an attached library in the specified module.
        /// </summary>
        /// <param name="module">Form module to attach the library.</param>
        /// <param name="location">Library location.</param>
        public AttachedLibrary(FormModule module, string location)
        {
            var status = NativeMethods.d2falbat_Attach(NdapiContext.Context, module._handle, out _handle, false, location);
            Ensure.Success(status);
        }

        /// <summary>
        /// Create an attached library in the specified module.
        /// </summary>
        /// <param name="module">Form module to attach the library.</param>
        /// <param name="location">Library location.</param>
        public AttachedLibrary(MenuModule module, string location)
        {
            var status = NativeMethods.d2falbat_Attach(NdapiContext.Context, module._handle, out _handle, false, location);
            Ensure.Success(status);
        }

        internal AttachedLibrary(ObjectSafeHandle handle) : base(handle)
        {
        }

        /// <summary>
        /// Gets or sets the comment property.
        /// </summary>
        public string Comment
        {
            get { return GetStringProperty(NdapiConstants.D2FP_COMMENT); }
            set { SetStringProperty(NdapiConstants.D2FP_COMMENT, value); }
        }

        /// <summary>
        /// Gets the library location.
        /// </summary>
        public string Location => GetStringProperty(NdapiConstants.D2FP_LIB_LOC);

        /// <summary>
        /// Gets the library source type.
        /// </summary>
        public SourceType SourceType => GetNumberProperty<SourceType>(NdapiConstants.D2FP_LIB_SRC);

        public void Detach()
        {
            var status = NativeMethods.d2falbdt_Detach(NdapiContext.Context, _handle);
            Ensure.Success(status);

            _handle = null;
        }
    }
}