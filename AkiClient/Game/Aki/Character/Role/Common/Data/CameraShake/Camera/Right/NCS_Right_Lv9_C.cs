using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Right
{
	// Token: 0x02004035 RID: 16437
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv9.NCS_Right_Lv9_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Right_Lv9_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA39 RID: 174649 RVA: 0x00A5EE28 File Offset: 0x00A5D028
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Right_Lv9_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv9.NCS_Right_Lv9_C");
			}
			return NCS_Right_Lv9_C._ClassPtr;
		}

		// Token: 0x0602AA3A RID: 174650 RVA: 0x00A5EE4C File Offset: 0x00A5D04C
		public NCS_Right_Lv9_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Right_Lv9_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA3B RID: 174651 RVA: 0x00A5EE74 File Offset: 0x00A5D074
		[NullableContext(1)]
		public NCS_Right_Lv9_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Right_Lv9_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA3C RID: 174652 RVA: 0x00A5EEA7 File Offset: 0x00A5D0A7
		protected NCS_Right_Lv9_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017340 RID: 95040
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv9.NCS_Right_Lv9_C";

		// Token: 0x04017341 RID: 95041
		private static IntPtr _ClassPtr;

		// Token: 0x04017342 RID: 95042
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
