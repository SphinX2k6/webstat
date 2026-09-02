using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Up
{
	// Token: 0x02004026 RID: 16422
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv4.NCS_Up_Lv4_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Up_Lv4_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A9FD RID: 174589 RVA: 0x00A5E630 File Offset: 0x00A5C830
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Up_Lv4_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv4.NCS_Up_Lv4_C");
			}
			return NCS_Up_Lv4_C._ClassPtr;
		}

		// Token: 0x0602A9FE RID: 174590 RVA: 0x00A5E654 File Offset: 0x00A5C854
		public NCS_Up_Lv4_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Up_Lv4_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A9FF RID: 174591 RVA: 0x00A5E67C File Offset: 0x00A5C87C
		[NullableContext(1)]
		public NCS_Up_Lv4_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Up_Lv4_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA00 RID: 174592 RVA: 0x00A5E6AF File Offset: 0x00A5C8AF
		protected NCS_Up_Lv4_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017313 RID: 94995
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv4.NCS_Up_Lv4_C";

		// Token: 0x04017314 RID: 94996
		private static IntPtr _ClassPtr;

		// Token: 0x04017315 RID: 94997
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
