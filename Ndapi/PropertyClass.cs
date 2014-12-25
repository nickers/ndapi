﻿using System.Collections.Generic;
using Ndapi.Core.Handles;
using Ndapi.Enums;
using Ndapi.Core;

namespace Ndapi
{
    /// <summary>
    /// Represent a property class.
    /// </summary>
    public class PropertyClass : NdapiObject
    {
        /// <summary>
        /// Creates a property class.
        /// </summary>
        /// <param name="module">Property class owner.</param>
        /// <param name="name">Property class name.</param>
        public PropertyClass(FormModule module, string name)
        {
            Create(name, ObjectType.PropertyClass, module);
        }

        /// <summary>
        /// Creates a property class.
        /// </summary>
        /// <param name="module">Property class owner.</param>
        /// <param name="name">Property class name.</param>
        public PropertyClass(MenuModule module, string name)
        {
            Create(name, ObjectType.PropertyClass, module);
        }

        /// <summary>
        /// Creates a property class.
        /// </summary>
        /// <param name="group">Property class owner.</param>
        /// <param name="name">Property class name.</param>
        public PropertyClass(ObjectGroup group, string name)
        {
            Create(name, ObjectType.PropertyClass, group);
        }

        /// <summary>
        /// Creates a property class.
        /// </summary>
        /// <param name="library">Property class owner.</param>
        /// <param name="name">Property class name.</param>
        public PropertyClass(LibraryModule library, string name)
        {
            Create(name, ObjectType.PropertyClass, library);
        }

        internal PropertyClass(ObjectSafeHandle handle) : base(handle)
        {
        }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        public string Comment
        {
            get { return GetStringProperty(NdapiConstants.D2FP_COMMENT); }
            set { SetStringProperty(NdapiConstants.D2FP_COMMENT, value); }
        }

        /// <summary>
        /// Gets all the triggers attached to this property class.
        /// </summary>
        public IEnumerable<Trigger> Triggers =>
            GetObjectList<Trigger>(NdapiConstants.D2FP_TRIGGER);

        /// <summary>
        /// Remove the specified property from the property class.
        /// </summary>
        /// <param name="propertyId">Property id (see <see cref="NdapiConstants"/>).</param>
        public void RemoveProperty(int propertyId)
        {
            var status = NativeMethods.d2fppcrp_RemoveProp(NdapiContext.Context, _handle, propertyId);
            Ensure.Success(status);
        }
    }
}
