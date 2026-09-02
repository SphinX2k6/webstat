using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.In
{
	// Token: 0x0200405A RID: 16474
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv2.NCS_In_Lv2_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_In_Lv2_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AACD RID: 174797 RVA: 0x00A601D0 File Offset: 0x00A5E3D0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_In_Lv2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv2.NCS_In_Lv2_C");
			}
			return NCS_In_Lv2_C._ClassPtr;
		}

		// Token: 0x0602AACE RID: 174798 RVA: 0x00A601F4 File Offset: 0x00A5E3F4
		public NCS_In_Lv2_C() : this(BuiltinUtils.AllocNativeUObject(NCS_In_Lv2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AACF RID: 174799 RVA: 0x00A6021C File Offset: 0x00A5E41C
		[NullableContext(1)]
		public NCS_In_Lv2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_In_Lv2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AAD0 RID: 174800 RVA: 0x00A6024F File Offset: 0x00A5E44F
		protected NCS_In_Lv2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040173AF RID: 95151
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv2.NCS_In_Lv2_C";

		// Token: 0x040173B0 RID: 95152
		private static IntPtr _ClassPtr;

		// Token: 0x040173B1 RID: 95153
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
