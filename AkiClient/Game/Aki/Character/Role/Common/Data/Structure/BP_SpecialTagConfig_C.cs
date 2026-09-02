using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.Structure
{
	// Token: 0x02004008 RID: 16392
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/Structure/BP_SpecialTagConfig.BP_SpecialTagConfig_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 160)]
	public class BP_SpecialTagConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A95D RID: 174429 RVA: 0x00A5D4B0 File Offset: 0x00A5B6B0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SpecialTagConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/Structure/BP_SpecialTagConfig.BP_SpecialTagConfig_C");
			}
			return BP_SpecialTagConfig_C._ClassPtr;
		}

		// Token: 0x0602A95E RID: 174430 RVA: 0x00A5D4D4 File Offset: 0x00A5B6D4
		public BP_SpecialTagConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_SpecialTagConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A95F RID: 174431 RVA: 0x00A5D4FC File Offset: 0x00A5B6FC
		public BP_SpecialTagConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SpecialTagConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006EE5 RID: 28389
		// (get) Token: 0x0602A960 RID: 174432 RVA: 0x00A5D530 File Offset: 0x00A5B730
		// (set) Token: 0x0602A961 RID: 174433 RVA: 0x00A5D569 File Offset: 0x00A5B769
		public SSpecialTagListenerInfo SpecialTagListener
		{
			get
			{
				base.FastCheckIsValid();
				SSpecialTagListenerInfo result;
				if ((result = this._SpecialTagListener) == null)
				{
					result = (this._SpecialTagListener = new SSpecialTagListenerInfo(base.NativePtr + (IntPtr)BP_SpecialTagConfig_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SSpecialTagListenerInfo.StaticStruct(), base.NativePtr + (IntPtr)BP_SpecialTagConfig_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602A962 RID: 174434 RVA: 0x00A5D58A File Offset: 0x00A5B78A
		protected BP_SpecialTagConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401728E RID: 94862
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/Structure/BP_SpecialTagConfig.BP_SpecialTagConfig_C";

		// Token: 0x0401728F RID: 94863
		private static IntPtr _ClassPtr;

		// Token: 0x04017290 RID: 94864
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017291 RID: 94865
		internal static int __PropertyOffset_0;

		// Token: 0x04017292 RID: 94866
		[Nullable(2)]
		private SSpecialTagListenerInfo _SpecialTagListener;
	}
}
