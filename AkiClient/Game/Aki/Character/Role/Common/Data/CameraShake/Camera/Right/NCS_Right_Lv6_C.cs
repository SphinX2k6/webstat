using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Right
{
	// Token: 0x02004032 RID: 16434
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv6.NCS_Right_Lv6_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Right_Lv6_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA2D RID: 174637 RVA: 0x00A5EC90 File Offset: 0x00A5CE90
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Right_Lv6_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv6.NCS_Right_Lv6_C");
			}
			return NCS_Right_Lv6_C._ClassPtr;
		}

		// Token: 0x0602AA2E RID: 174638 RVA: 0x00A5ECB4 File Offset: 0x00A5CEB4
		public NCS_Right_Lv6_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Right_Lv6_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA2F RID: 174639 RVA: 0x00A5ECDC File Offset: 0x00A5CEDC
		[NullableContext(1)]
		public NCS_Right_Lv6_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Right_Lv6_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA30 RID: 174640 RVA: 0x00A5ED0F File Offset: 0x00A5CF0F
		protected NCS_Right_Lv6_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017337 RID: 95031
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv6.NCS_Right_Lv6_C";

		// Token: 0x04017338 RID: 95032
		private static IntPtr _ClassPtr;

		// Token: 0x04017339 RID: 95033
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
