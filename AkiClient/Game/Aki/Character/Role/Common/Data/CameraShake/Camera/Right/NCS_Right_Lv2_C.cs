using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Right
{
	// Token: 0x0200402E RID: 16430
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv2.NCS_Right_Lv2_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Right_Lv2_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA1D RID: 174621 RVA: 0x00A5EA70 File Offset: 0x00A5CC70
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Right_Lv2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv2.NCS_Right_Lv2_C");
			}
			return NCS_Right_Lv2_C._ClassPtr;
		}

		// Token: 0x0602AA1E RID: 174622 RVA: 0x00A5EA94 File Offset: 0x00A5CC94
		public NCS_Right_Lv2_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Right_Lv2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA1F RID: 174623 RVA: 0x00A5EABC File Offset: 0x00A5CCBC
		[NullableContext(1)]
		public NCS_Right_Lv2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Right_Lv2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA20 RID: 174624 RVA: 0x00A5EAEF File Offset: 0x00A5CCEF
		protected NCS_Right_Lv2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401732B RID: 95019
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv2.NCS_Right_Lv2_C";

		// Token: 0x0401732C RID: 95020
		private static IntPtr _ClassPtr;

		// Token: 0x0401732D RID: 95021
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
