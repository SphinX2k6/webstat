using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Up
{
	// Token: 0x02004028 RID: 16424
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv6.NCS_Up_Lv6_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Up_Lv6_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA05 RID: 174597 RVA: 0x00A5E740 File Offset: 0x00A5C940
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Up_Lv6_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv6.NCS_Up_Lv6_C");
			}
			return NCS_Up_Lv6_C._ClassPtr;
		}

		// Token: 0x0602AA06 RID: 174598 RVA: 0x00A5E764 File Offset: 0x00A5C964
		public NCS_Up_Lv6_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Up_Lv6_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA07 RID: 174599 RVA: 0x00A5E78C File Offset: 0x00A5C98C
		[NullableContext(1)]
		public NCS_Up_Lv6_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Up_Lv6_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA08 RID: 174600 RVA: 0x00A5E7BF File Offset: 0x00A5C9BF
		protected NCS_Up_Lv6_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017319 RID: 95001
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv6.NCS_Up_Lv6_C";

		// Token: 0x0401731A RID: 95002
		private static IntPtr _ClassPtr;

		// Token: 0x0401731B RID: 95003
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
