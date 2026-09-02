using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Random
{
	// Token: 0x02004040 RID: 16448
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv9.NCS_Random_Lv9_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Random_Lv9_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA65 RID: 174693 RVA: 0x00A5F400 File Offset: 0x00A5D600
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Random_Lv9_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv9.NCS_Random_Lv9_C");
			}
			return NCS_Random_Lv9_C._ClassPtr;
		}

		// Token: 0x0602AA66 RID: 174694 RVA: 0x00A5F424 File Offset: 0x00A5D624
		public NCS_Random_Lv9_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Random_Lv9_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA67 RID: 174695 RVA: 0x00A5F44C File Offset: 0x00A5D64C
		[NullableContext(1)]
		public NCS_Random_Lv9_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Random_Lv9_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA68 RID: 174696 RVA: 0x00A5F47F File Offset: 0x00A5D67F
		protected NCS_Random_Lv9_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017361 RID: 95073
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv9.NCS_Random_Lv9_C";

		// Token: 0x04017362 RID: 95074
		private static IntPtr _ClassPtr;

		// Token: 0x04017363 RID: 95075
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
