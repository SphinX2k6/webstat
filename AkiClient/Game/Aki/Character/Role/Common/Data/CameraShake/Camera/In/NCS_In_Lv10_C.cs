using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.In
{
	// Token: 0x02004058 RID: 16472
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv10.NCS_In_Lv10_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_In_Lv10_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AAC5 RID: 174789 RVA: 0x00A600C0 File Offset: 0x00A5E2C0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_In_Lv10_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv10.NCS_In_Lv10_C");
			}
			return NCS_In_Lv10_C._ClassPtr;
		}

		// Token: 0x0602AAC6 RID: 174790 RVA: 0x00A600E4 File Offset: 0x00A5E2E4
		public NCS_In_Lv10_C() : this(BuiltinUtils.AllocNativeUObject(NCS_In_Lv10_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AAC7 RID: 174791 RVA: 0x00A6010C File Offset: 0x00A5E30C
		[NullableContext(1)]
		public NCS_In_Lv10_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_In_Lv10_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AAC8 RID: 174792 RVA: 0x00A6013F File Offset: 0x00A5E33F
		protected NCS_In_Lv10_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040173A9 RID: 95145
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv10.NCS_In_Lv10_C";

		// Token: 0x040173AA RID: 95146
		private static IntPtr _ClassPtr;

		// Token: 0x040173AB RID: 95147
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
