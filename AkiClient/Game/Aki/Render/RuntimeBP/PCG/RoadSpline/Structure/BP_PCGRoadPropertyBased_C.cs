using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.RoadSpline.Structure
{
	// Token: 0x02003B9C RID: 15260
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/Structure/BP_PCGRoadPropertyBased.BP_PCGRoadPropertyBased_C")]
	[UnrealStructLayout(112, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 112)]
	public class BP_PCGRoadPropertyBased_C : UObject, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021E35 RID: 138805 RVA: 0x00956820 File Offset: 0x00954A20
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PCGRoadPropertyBased_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/Structure/BP_PCGRoadPropertyBased.BP_PCGRoadPropertyBased_C");
			}
			return BP_PCGRoadPropertyBased_C._ClassPtr;
		}

		// Token: 0x06021E36 RID: 138806 RVA: 0x00956844 File Offset: 0x00954A44
		public BP_PCGRoadPropertyBased_C() : this(BuiltinUtils.AllocNativeUObject(BP_PCGRoadPropertyBased_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021E37 RID: 138807 RVA: 0x0095686C File Offset: 0x00954A6C
		public BP_PCGRoadPropertyBased_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PCGRoadPropertyBased_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003D91 RID: 15761
		// (get) Token: 0x06021E38 RID: 138808 RVA: 0x009568A0 File Offset: 0x00954AA0
		// (set) Token: 0x06021E39 RID: 138809 RVA: 0x009568D9 File Offset: 0x00954AD9
		public SPCG_RoadPropertyBased 属性列表
		{
			get
			{
				base.FastCheckIsValid();
				SPCG_RoadPropertyBased result;
				if ((result = this._属性列表) == null)
				{
					result = (this._属性列表 = new SPCG_RoadPropertyBased(base.NativePtr + (IntPtr)BP_PCGRoadPropertyBased_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SPCG_RoadPropertyBased.StaticStruct(), base.NativePtr + (IntPtr)BP_PCGRoadPropertyBased_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06021E3A RID: 138810 RVA: 0x009568FA File Offset: 0x00954AFA
		protected BP_PCGRoadPropertyBased_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040111C2 RID: 70082
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/Structure/BP_PCGRoadPropertyBased.BP_PCGRoadPropertyBased_C";

		// Token: 0x040111C3 RID: 70083
		private static IntPtr _ClassPtr;

		// Token: 0x040111C4 RID: 70084
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040111C5 RID: 70085
		internal static int __PropertyOffset_0;

		// Token: 0x040111C6 RID: 70086
		[Nullable(2)]
		private SPCG_RoadPropertyBased _属性列表;
	}
}
