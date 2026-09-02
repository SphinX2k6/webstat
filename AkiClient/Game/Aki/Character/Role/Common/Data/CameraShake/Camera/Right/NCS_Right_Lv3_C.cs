using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Right
{
	// Token: 0x0200402F RID: 16431
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv3.NCS_Right_Lv3_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Right_Lv3_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA21 RID: 174625 RVA: 0x00A5EAF8 File Offset: 0x00A5CCF8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Right_Lv3_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv3.NCS_Right_Lv3_C");
			}
			return NCS_Right_Lv3_C._ClassPtr;
		}

		// Token: 0x0602AA22 RID: 174626 RVA: 0x00A5EB1C File Offset: 0x00A5CD1C
		public NCS_Right_Lv3_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Right_Lv3_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA23 RID: 174627 RVA: 0x00A5EB44 File Offset: 0x00A5CD44
		[NullableContext(1)]
		public NCS_Right_Lv3_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Right_Lv3_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA24 RID: 174628 RVA: 0x00A5EB77 File Offset: 0x00A5CD77
		protected NCS_Right_Lv3_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401732E RID: 95022
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv3.NCS_Right_Lv3_C";

		// Token: 0x0401732F RID: 95023
		private static IntPtr _ClassPtr;

		// Token: 0x04017330 RID: 95024
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
