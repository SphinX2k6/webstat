using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Left
{
	// Token: 0x02004056 RID: 16470
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv8.NCS_Left_Lv8_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Left_Lv8_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AABD RID: 174781 RVA: 0x00A5FFB0 File Offset: 0x00A5E1B0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Left_Lv8_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv8.NCS_Left_Lv8_C");
			}
			return NCS_Left_Lv8_C._ClassPtr;
		}

		// Token: 0x0602AABE RID: 174782 RVA: 0x00A5FFD4 File Offset: 0x00A5E1D4
		public NCS_Left_Lv8_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Left_Lv8_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AABF RID: 174783 RVA: 0x00A5FFFC File Offset: 0x00A5E1FC
		[NullableContext(1)]
		public NCS_Left_Lv8_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Left_Lv8_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AAC0 RID: 174784 RVA: 0x00A6002F File Offset: 0x00A5E22F
		protected NCS_Left_Lv8_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040173A3 RID: 95139
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv8.NCS_Left_Lv8_C";

		// Token: 0x040173A4 RID: 95140
		private static IntPtr _ClassPtr;

		// Token: 0x040173A5 RID: 95141
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
