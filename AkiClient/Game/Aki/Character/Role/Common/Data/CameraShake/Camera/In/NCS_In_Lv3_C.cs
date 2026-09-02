using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.In
{
	// Token: 0x0200405B RID: 16475
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv3.NCS_In_Lv3_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_In_Lv3_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AAD1 RID: 174801 RVA: 0x00A60258 File Offset: 0x00A5E458
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_In_Lv3_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv3.NCS_In_Lv3_C");
			}
			return NCS_In_Lv3_C._ClassPtr;
		}

		// Token: 0x0602AAD2 RID: 174802 RVA: 0x00A6027C File Offset: 0x00A5E47C
		public NCS_In_Lv3_C() : this(BuiltinUtils.AllocNativeUObject(NCS_In_Lv3_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AAD3 RID: 174803 RVA: 0x00A602A4 File Offset: 0x00A5E4A4
		[NullableContext(1)]
		public NCS_In_Lv3_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_In_Lv3_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AAD4 RID: 174804 RVA: 0x00A602D7 File Offset: 0x00A5E4D7
		protected NCS_In_Lv3_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040173B2 RID: 95154
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv3.NCS_In_Lv3_C";

		// Token: 0x040173B3 RID: 95155
		private static IntPtr _ClassPtr;

		// Token: 0x040173B4 RID: 95156
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
