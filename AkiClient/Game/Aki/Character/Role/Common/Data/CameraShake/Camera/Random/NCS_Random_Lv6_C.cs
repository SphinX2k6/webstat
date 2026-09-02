using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Random
{
	// Token: 0x0200403D RID: 16445
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv6.NCS_Random_Lv6_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Random_Lv6_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA59 RID: 174681 RVA: 0x00A5F268 File Offset: 0x00A5D468
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Random_Lv6_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv6.NCS_Random_Lv6_C");
			}
			return NCS_Random_Lv6_C._ClassPtr;
		}

		// Token: 0x0602AA5A RID: 174682 RVA: 0x00A5F28C File Offset: 0x00A5D48C
		public NCS_Random_Lv6_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Random_Lv6_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA5B RID: 174683 RVA: 0x00A5F2B4 File Offset: 0x00A5D4B4
		[NullableContext(1)]
		public NCS_Random_Lv6_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Random_Lv6_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA5C RID: 174684 RVA: 0x00A5F2E7 File Offset: 0x00A5D4E7
		protected NCS_Random_Lv6_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017358 RID: 95064
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv6.NCS_Random_Lv6_C";

		// Token: 0x04017359 RID: 95065
		private static IntPtr _ClassPtr;

		// Token: 0x0401735A RID: 95066
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
