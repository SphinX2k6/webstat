using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.In
{
	// Token: 0x0200405D RID: 16477
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv5.NCS_In_Lv5_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_In_Lv5_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AAD9 RID: 174809 RVA: 0x00A60368 File Offset: 0x00A5E568
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_In_Lv5_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv5.NCS_In_Lv5_C");
			}
			return NCS_In_Lv5_C._ClassPtr;
		}

		// Token: 0x0602AADA RID: 174810 RVA: 0x00A6038C File Offset: 0x00A5E58C
		public NCS_In_Lv5_C() : this(BuiltinUtils.AllocNativeUObject(NCS_In_Lv5_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AADB RID: 174811 RVA: 0x00A603B4 File Offset: 0x00A5E5B4
		[NullableContext(1)]
		public NCS_In_Lv5_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_In_Lv5_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AADC RID: 174812 RVA: 0x00A603E7 File Offset: 0x00A5E5E7
		protected NCS_In_Lv5_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040173B8 RID: 95160
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv5.NCS_In_Lv5_C";

		// Token: 0x040173B9 RID: 95161
		private static IntPtr _ClassPtr;

		// Token: 0x040173BA RID: 95162
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
