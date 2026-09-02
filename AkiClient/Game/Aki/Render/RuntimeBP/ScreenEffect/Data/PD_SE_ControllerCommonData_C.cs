using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Data
{
	// Token: 0x02003A6B RID: 14955
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/ScreenEffect/Data/PD_SE_ControllerCommonData.PD_SE_ControllerCommonData_C")]
	[UnrealStructLayout(120, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 120)]
	public class PD_SE_ControllerCommonData_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F2C9 RID: 127689 RVA: 0x0090A041 File Offset: 0x00908241
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_SE_ControllerCommonData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/ScreenEffect/Data/PD_SE_ControllerCommonData.PD_SE_ControllerCommonData_C");
			}
			return PD_SE_ControllerCommonData_C._ClassPtr;
		}

		// Token: 0x0601F2CA RID: 127690 RVA: 0x0090A068 File Offset: 0x00908268
		public PD_SE_ControllerCommonData_C() : this(BuiltinUtils.AllocNativeUObject(PD_SE_ControllerCommonData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F2CB RID: 127691 RVA: 0x0090A090 File Offset: 0x00908290
		public PD_SE_ControllerCommonData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_SE_ControllerCommonData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002E78 RID: 11896
		// (get) Token: 0x0601F2CC RID: 127692 RVA: 0x0090A0C4 File Offset: 0x009082C4
		// (set) Token: 0x0601F2CD RID: 127693 RVA: 0x0090A0FD File Offset: 0x009082FD
		public S_SE_ControllerCommon Data
		{
			get
			{
				base.FastCheckIsValid();
				S_SE_ControllerCommon result;
				if ((result = this._Data) == null)
				{
					result = (this._Data = new S_SE_ControllerCommon(base.NativePtr + (IntPtr)PD_SE_ControllerCommonData_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(S_SE_ControllerCommon.StaticStruct(), base.NativePtr + (IntPtr)PD_SE_ControllerCommonData_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0601F2CE RID: 127694 RVA: 0x0090A11E File Offset: 0x0090831E
		protected PD_SE_ControllerCommonData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F737 RID: 63287
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/ScreenEffect/Data/PD_SE_ControllerCommonData.PD_SE_ControllerCommonData_C";

		// Token: 0x0400F738 RID: 63288
		private static IntPtr _ClassPtr;

		// Token: 0x0400F739 RID: 63289
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F73A RID: 63290
		internal static int __PropertyOffset_0;

		// Token: 0x0400F73B RID: 63291
		[Nullable(2)]
		private S_SE_ControllerCommon _Data;
	}
}
