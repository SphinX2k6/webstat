using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Right
{
	// Token: 0x02004030 RID: 16432
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv4.NCS_Right_Lv4_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Right_Lv4_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA25 RID: 174629 RVA: 0x00A5EB80 File Offset: 0x00A5CD80
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Right_Lv4_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv4.NCS_Right_Lv4_C");
			}
			return NCS_Right_Lv4_C._ClassPtr;
		}

		// Token: 0x0602AA26 RID: 174630 RVA: 0x00A5EBA4 File Offset: 0x00A5CDA4
		public NCS_Right_Lv4_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Right_Lv4_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA27 RID: 174631 RVA: 0x00A5EBCC File Offset: 0x00A5CDCC
		[NullableContext(1)]
		public NCS_Right_Lv4_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Right_Lv4_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA28 RID: 174632 RVA: 0x00A5EBFF File Offset: 0x00A5CDFF
		protected NCS_Right_Lv4_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017331 RID: 95025
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv4.NCS_Right_Lv4_C";

		// Token: 0x04017332 RID: 95026
		private static IntPtr _ClassPtr;

		// Token: 0x04017333 RID: 95027
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
