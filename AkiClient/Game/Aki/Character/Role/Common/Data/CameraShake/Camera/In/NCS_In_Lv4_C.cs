using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.In
{
	// Token: 0x0200405C RID: 16476
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv4.NCS_In_Lv4_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_In_Lv4_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AAD5 RID: 174805 RVA: 0x00A602E0 File Offset: 0x00A5E4E0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_In_Lv4_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv4.NCS_In_Lv4_C");
			}
			return NCS_In_Lv4_C._ClassPtr;
		}

		// Token: 0x0602AAD6 RID: 174806 RVA: 0x00A60304 File Offset: 0x00A5E504
		public NCS_In_Lv4_C() : this(BuiltinUtils.AllocNativeUObject(NCS_In_Lv4_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AAD7 RID: 174807 RVA: 0x00A6032C File Offset: 0x00A5E52C
		[NullableContext(1)]
		public NCS_In_Lv4_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_In_Lv4_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AAD8 RID: 174808 RVA: 0x00A6035F File Offset: 0x00A5E55F
		protected NCS_In_Lv4_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040173B5 RID: 95157
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv4.NCS_In_Lv4_C";

		// Token: 0x040173B6 RID: 95158
		private static IntPtr _ClassPtr;

		// Token: 0x040173B7 RID: 95159
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
