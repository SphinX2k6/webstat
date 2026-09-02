using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Out
{
	// Token: 0x02004049 RID: 16457
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv6.NCS_Out_Lv6_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Out_Lv6_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA89 RID: 174729 RVA: 0x00A5F8C8 File Offset: 0x00A5DAC8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Out_Lv6_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv6.NCS_Out_Lv6_C");
			}
			return NCS_Out_Lv6_C._ClassPtr;
		}

		// Token: 0x0602AA8A RID: 174730 RVA: 0x00A5F8EC File Offset: 0x00A5DAEC
		public NCS_Out_Lv6_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Out_Lv6_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA8B RID: 174731 RVA: 0x00A5F914 File Offset: 0x00A5DB14
		[NullableContext(1)]
		public NCS_Out_Lv6_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Out_Lv6_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA8C RID: 174732 RVA: 0x00A5F947 File Offset: 0x00A5DB47
		protected NCS_Out_Lv6_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401737C RID: 95100
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv6.NCS_Out_Lv6_C";

		// Token: 0x0401737D RID: 95101
		private static IntPtr _ClassPtr;

		// Token: 0x0401737E RID: 95102
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
