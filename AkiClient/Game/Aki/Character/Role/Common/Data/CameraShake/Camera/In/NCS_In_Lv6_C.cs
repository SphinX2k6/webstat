using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.In
{
	// Token: 0x0200405E RID: 16478
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv6.NCS_In_Lv6_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_In_Lv6_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AADD RID: 174813 RVA: 0x00A603F0 File Offset: 0x00A5E5F0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_In_Lv6_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv6.NCS_In_Lv6_C");
			}
			return NCS_In_Lv6_C._ClassPtr;
		}

		// Token: 0x0602AADE RID: 174814 RVA: 0x00A60414 File Offset: 0x00A5E614
		public NCS_In_Lv6_C() : this(BuiltinUtils.AllocNativeUObject(NCS_In_Lv6_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AADF RID: 174815 RVA: 0x00A6043C File Offset: 0x00A5E63C
		[NullableContext(1)]
		public NCS_In_Lv6_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_In_Lv6_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AAE0 RID: 174816 RVA: 0x00A6046F File Offset: 0x00A5E66F
		protected NCS_In_Lv6_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040173BB RID: 95163
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv6.NCS_In_Lv6_C";

		// Token: 0x040173BC RID: 95164
		private static IntPtr _ClassPtr;

		// Token: 0x040173BD RID: 95165
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
