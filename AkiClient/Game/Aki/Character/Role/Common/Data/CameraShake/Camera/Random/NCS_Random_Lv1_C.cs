using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Random
{
	// Token: 0x02004038 RID: 16440
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv1.NCS_Random_Lv1_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Random_Lv1_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA45 RID: 174661 RVA: 0x00A5EFC0 File Offset: 0x00A5D1C0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Random_Lv1_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv1.NCS_Random_Lv1_C");
			}
			return NCS_Random_Lv1_C._ClassPtr;
		}

		// Token: 0x0602AA46 RID: 174662 RVA: 0x00A5EFE4 File Offset: 0x00A5D1E4
		public NCS_Random_Lv1_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Random_Lv1_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA47 RID: 174663 RVA: 0x00A5F00C File Offset: 0x00A5D20C
		[NullableContext(1)]
		public NCS_Random_Lv1_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Random_Lv1_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA48 RID: 174664 RVA: 0x00A5F03F File Offset: 0x00A5D23F
		protected NCS_Random_Lv1_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017349 RID: 95049
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv1.NCS_Random_Lv1_C";

		// Token: 0x0401734A RID: 95050
		private static IntPtr _ClassPtr;

		// Token: 0x0401734B RID: 95051
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
