using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Right
{
	// Token: 0x02004031 RID: 16433
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv5.NCS_Right_Lv5_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Right_Lv5_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA29 RID: 174633 RVA: 0x00A5EC08 File Offset: 0x00A5CE08
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Right_Lv5_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv5.NCS_Right_Lv5_C");
			}
			return NCS_Right_Lv5_C._ClassPtr;
		}

		// Token: 0x0602AA2A RID: 174634 RVA: 0x00A5EC2C File Offset: 0x00A5CE2C
		public NCS_Right_Lv5_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Right_Lv5_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA2B RID: 174635 RVA: 0x00A5EC54 File Offset: 0x00A5CE54
		[NullableContext(1)]
		public NCS_Right_Lv5_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Right_Lv5_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA2C RID: 174636 RVA: 0x00A5EC87 File Offset: 0x00A5CE87
		protected NCS_Right_Lv5_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017334 RID: 95028
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv5.NCS_Right_Lv5_C";

		// Token: 0x04017335 RID: 95029
		private static IntPtr _ClassPtr;

		// Token: 0x04017336 RID: 95030
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
