using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Random
{
	// Token: 0x02004036 RID: 16438
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv10.NCS_Random_Lv10_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Random_Lv10_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA3D RID: 174653 RVA: 0x00A5EEB0 File Offset: 0x00A5D0B0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Random_Lv10_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv10.NCS_Random_Lv10_C");
			}
			return NCS_Random_Lv10_C._ClassPtr;
		}

		// Token: 0x0602AA3E RID: 174654 RVA: 0x00A5EED4 File Offset: 0x00A5D0D4
		public NCS_Random_Lv10_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Random_Lv10_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA3F RID: 174655 RVA: 0x00A5EEFC File Offset: 0x00A5D0FC
		[NullableContext(1)]
		public NCS_Random_Lv10_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Random_Lv10_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA40 RID: 174656 RVA: 0x00A5EF2F File Offset: 0x00A5D12F
		protected NCS_Random_Lv10_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017343 RID: 95043
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv10.NCS_Random_Lv10_C";

		// Token: 0x04017344 RID: 95044
		private static IntPtr _ClassPtr;

		// Token: 0x04017345 RID: 95045
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
