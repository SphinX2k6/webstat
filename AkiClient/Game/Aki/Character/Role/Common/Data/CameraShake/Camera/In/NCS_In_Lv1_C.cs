using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.In
{
	// Token: 0x02004059 RID: 16473
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv1.NCS_In_Lv1_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_In_Lv1_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AAC9 RID: 174793 RVA: 0x00A60148 File Offset: 0x00A5E348
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_In_Lv1_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv1.NCS_In_Lv1_C");
			}
			return NCS_In_Lv1_C._ClassPtr;
		}

		// Token: 0x0602AACA RID: 174794 RVA: 0x00A6016C File Offset: 0x00A5E36C
		public NCS_In_Lv1_C() : this(BuiltinUtils.AllocNativeUObject(NCS_In_Lv1_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AACB RID: 174795 RVA: 0x00A60194 File Offset: 0x00A5E394
		[NullableContext(1)]
		public NCS_In_Lv1_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_In_Lv1_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AACC RID: 174796 RVA: 0x00A601C7 File Offset: 0x00A5E3C7
		protected NCS_In_Lv1_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040173AC RID: 95148
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv1.NCS_In_Lv1_C";

		// Token: 0x040173AD RID: 95149
		private static IntPtr _ClassPtr;

		// Token: 0x040173AE RID: 95150
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
