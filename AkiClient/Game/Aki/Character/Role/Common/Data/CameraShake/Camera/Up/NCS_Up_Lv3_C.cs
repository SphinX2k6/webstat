using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Up
{
	// Token: 0x02004025 RID: 16421
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv3.NCS_Up_Lv3_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Up_Lv3_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A9F9 RID: 174585 RVA: 0x00A5E5A8 File Offset: 0x00A5C7A8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Up_Lv3_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv3.NCS_Up_Lv3_C");
			}
			return NCS_Up_Lv3_C._ClassPtr;
		}

		// Token: 0x0602A9FA RID: 174586 RVA: 0x00A5E5CC File Offset: 0x00A5C7CC
		public NCS_Up_Lv3_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Up_Lv3_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A9FB RID: 174587 RVA: 0x00A5E5F4 File Offset: 0x00A5C7F4
		[NullableContext(1)]
		public NCS_Up_Lv3_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Up_Lv3_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602A9FC RID: 174588 RVA: 0x00A5E627 File Offset: 0x00A5C827
		protected NCS_Up_Lv3_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017310 RID: 94992
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv3.NCS_Up_Lv3_C";

		// Token: 0x04017311 RID: 94993
		private static IntPtr _ClassPtr;

		// Token: 0x04017312 RID: 94994
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
