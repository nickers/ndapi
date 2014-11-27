﻿using Ndapi.Core.Handles;
using Ndapi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ndapi
{
    public class RecordGroup : NdapiObject
    {
        public RecordGroup(FormModule module, string name)
        {
            Create(name, NdapiConstants.D2FFO_REC_GROUP, module);
        }

        internal RecordGroup(ObjectSafeHandle handle) : base(handle)
        {
        }

        public string Comment
        {
            get { return GetStringProperty(NdapiConstants.D2FP_COMMENT); }
            set { SetStringProperty(NdapiConstants.D2FP_COMMENT, value); }
        }

        public int FetchSize
        {
            get { return GetNumberProperty(NdapiConstants.D2FP_REC_GRP_FETCH_SIZ); }
            set { SetNumberProperty(NdapiConstants.D2FP_REC_GRP_FETCH_SIZ, value); }
        }

        public string Query
        {
            get { return GetStringProperty(NdapiConstants.D2FP_REC_GRP_QRY); }
            set { SetStringProperty(NdapiConstants.D2FP_REC_GRP_QRY, value); }
        }

        public RecordGroupType Type
        {
            get { return GetNumberProperty<RecordGroupType>(NdapiConstants.D2FP_REC_GRP_TYP); }
            set { SetNumberProperty(NdapiConstants.D2FP_REC_GRP_TYP, value); }
        }

        public IEnumerable<ColumnSpecification> ColumnSpecifications
        {
            get { return GetObjectList<ColumnSpecification>(NdapiConstants.D2FP_COL_SPEC); }
        }
    }
}