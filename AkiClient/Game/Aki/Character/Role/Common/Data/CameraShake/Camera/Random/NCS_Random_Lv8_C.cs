using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Random
{
	// Token: 0x0200403F RID: 16447
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv8.NCS_Random_Lv8_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Random_Lv8_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA61 RID: 174689 RVA: 0x00A5F378 File Offset: 0x00A5D578
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Random_Lv8_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv8.NCS_Random_Lv8_C");
			}
			return NCS_Random_Lv8_C._ClassPtr;
		}

		// Token: 0x0602AA62 RID: 174690 RVA: 0x00A5F39C File Offset: 0x00A5D59C
		public NCS_Random_Lv8_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Random_Lv8_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA63 RID: 174691 RVA: 0x00A5F3C4 File Offset: 0x00A5D5C4
		[NullableContext(1)]
		public NCS_Random_Lv8_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Random_Lv8_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA64 RID: 174692 RVA: 0x00A5F3F7 File Offset: 0x00A5D5F7
		protected NCS_Random_Lv8_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401735E RID: 95070
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv8.NCS_Random_Lv8_C";

		// Token: 0x0401735F RID: 95071
		private static IntPtr _ClassPtr;

		// Token: 0x04017360 RID: 95072
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
