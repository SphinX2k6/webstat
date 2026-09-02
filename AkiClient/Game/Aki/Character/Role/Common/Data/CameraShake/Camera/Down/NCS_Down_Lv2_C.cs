using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Down
{
	// Token: 0x02004065 RID: 16485
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv2.NCS_Down_Lv2_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Down_Lv2_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AAF9 RID: 174841 RVA: 0x00A607A8 File Offset: 0x00A5E9A8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Down_Lv2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv2.NCS_Down_Lv2_C");
			}
			return NCS_Down_Lv2_C._ClassPtr;
		}

		// Token: 0x0602AAFA RID: 174842 RVA: 0x00A607CC File Offset: 0x00A5E9CC
		public NCS_Down_Lv2_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Down_Lv2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AAFB RID: 174843 RVA: 0x00A607F4 File Offset: 0x00A5E9F4
		[NullableContext(1)]
		public NCS_Down_Lv2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Down_Lv2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AAFC RID: 174844 RVA: 0x00A60827 File Offset: 0x00A5EA27
		protected NCS_Down_Lv2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040173D0 RID: 95184
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv2.NCS_Down_Lv2_C";

		// Token: 0x040173D1 RID: 95185
		private static IntPtr _ClassPtr;

		// Token: 0x040173D2 RID: 95186
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
