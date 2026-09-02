using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Left
{
	// Token: 0x02004050 RID: 16464
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv2.NCS_Left_Lv2_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Left_Lv2_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AAA5 RID: 174757 RVA: 0x00A5FC80 File Offset: 0x00A5DE80
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Left_Lv2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv2.NCS_Left_Lv2_C");
			}
			return NCS_Left_Lv2_C._ClassPtr;
		}

		// Token: 0x0602AAA6 RID: 174758 RVA: 0x00A5FCA4 File Offset: 0x00A5DEA4
		public NCS_Left_Lv2_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Left_Lv2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AAA7 RID: 174759 RVA: 0x00A5FCCC File Offset: 0x00A5DECC
		[NullableContext(1)]
		public NCS_Left_Lv2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Left_Lv2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AAA8 RID: 174760 RVA: 0x00A5FCFF File Offset: 0x00A5DEFF
		protected NCS_Left_Lv2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017391 RID: 95121
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv2.NCS_Left_Lv2_C";

		// Token: 0x04017392 RID: 95122
		private static IntPtr _ClassPtr;

		// Token: 0x04017393 RID: 95123
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
