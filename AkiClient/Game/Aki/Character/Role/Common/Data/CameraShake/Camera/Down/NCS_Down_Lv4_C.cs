using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Down
{
	// Token: 0x02004067 RID: 16487
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv4.NCS_Down_Lv4_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Down_Lv4_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AB01 RID: 174849 RVA: 0x00A608B8 File Offset: 0x00A5EAB8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Down_Lv4_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv4.NCS_Down_Lv4_C");
			}
			return NCS_Down_Lv4_C._ClassPtr;
		}

		// Token: 0x0602AB02 RID: 174850 RVA: 0x00A608DC File Offset: 0x00A5EADC
		public NCS_Down_Lv4_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Down_Lv4_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AB03 RID: 174851 RVA: 0x00A60904 File Offset: 0x00A5EB04
		[NullableContext(1)]
		public NCS_Down_Lv4_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Down_Lv4_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AB04 RID: 174852 RVA: 0x00A60937 File Offset: 0x00A5EB37
		protected NCS_Down_Lv4_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040173D6 RID: 95190
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv4.NCS_Down_Lv4_C";

		// Token: 0x040173D7 RID: 95191
		private static IntPtr _ClassPtr;

		// Token: 0x040173D8 RID: 95192
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
