using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Right
{
	// Token: 0x0200402D RID: 16429
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv1.NCS_Right_Lv1_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Right_Lv1_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA19 RID: 174617 RVA: 0x00A5E9E8 File Offset: 0x00A5CBE8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Right_Lv1_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv1.NCS_Right_Lv1_C");
			}
			return NCS_Right_Lv1_C._ClassPtr;
		}

		// Token: 0x0602AA1A RID: 174618 RVA: 0x00A5EA0C File Offset: 0x00A5CC0C
		public NCS_Right_Lv1_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Right_Lv1_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA1B RID: 174619 RVA: 0x00A5EA34 File Offset: 0x00A5CC34
		[NullableContext(1)]
		public NCS_Right_Lv1_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Right_Lv1_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA1C RID: 174620 RVA: 0x00A5EA67 File Offset: 0x00A5CC67
		protected NCS_Right_Lv1_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017328 RID: 95016
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv1.NCS_Right_Lv1_C";

		// Token: 0x04017329 RID: 95017
		private static IntPtr _ClassPtr;

		// Token: 0x0401732A RID: 95018
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
