using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Up
{
	// Token: 0x02004027 RID: 16423
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv5.NCS_Up_Lv5_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Up_Lv5_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA01 RID: 174593 RVA: 0x00A5E6B8 File Offset: 0x00A5C8B8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Up_Lv5_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv5.NCS_Up_Lv5_C");
			}
			return NCS_Up_Lv5_C._ClassPtr;
		}

		// Token: 0x0602AA02 RID: 174594 RVA: 0x00A5E6DC File Offset: 0x00A5C8DC
		public NCS_Up_Lv5_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Up_Lv5_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA03 RID: 174595 RVA: 0x00A5E704 File Offset: 0x00A5C904
		[NullableContext(1)]
		public NCS_Up_Lv5_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Up_Lv5_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA04 RID: 174596 RVA: 0x00A5E737 File Offset: 0x00A5C937
		protected NCS_Up_Lv5_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017316 RID: 94998
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv5.NCS_Up_Lv5_C";

		// Token: 0x04017317 RID: 94999
		private static IntPtr _ClassPtr;

		// Token: 0x04017318 RID: 95000
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
