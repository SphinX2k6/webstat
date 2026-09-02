using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Random
{
	// Token: 0x0200403E RID: 16446
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv7.NCS_Random_Lv7_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Random_Lv7_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA5D RID: 174685 RVA: 0x00A5F2F0 File Offset: 0x00A5D4F0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Random_Lv7_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv7.NCS_Random_Lv7_C");
			}
			return NCS_Random_Lv7_C._ClassPtr;
		}

		// Token: 0x0602AA5E RID: 174686 RVA: 0x00A5F314 File Offset: 0x00A5D514
		public NCS_Random_Lv7_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Random_Lv7_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA5F RID: 174687 RVA: 0x00A5F33C File Offset: 0x00A5D53C
		[NullableContext(1)]
		public NCS_Random_Lv7_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Random_Lv7_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA60 RID: 174688 RVA: 0x00A5F36F File Offset: 0x00A5D56F
		protected NCS_Random_Lv7_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401735B RID: 95067
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv7.NCS_Random_Lv7_C";

		// Token: 0x0401735C RID: 95068
		private static IntPtr _ClassPtr;

		// Token: 0x0401735D RID: 95069
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
