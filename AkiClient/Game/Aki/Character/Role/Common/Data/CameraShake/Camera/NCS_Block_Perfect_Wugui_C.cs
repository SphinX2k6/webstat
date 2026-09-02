using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera
{
	// Token: 0x02004015 RID: 16405
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Block_Perfect_Wugui.NCS_Block_Perfect_Wugui_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Block_Perfect_Wugui_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A9B9 RID: 174521 RVA: 0x00A5DD28 File Offset: 0x00A5BF28
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Block_Perfect_Wugui_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Block_Perfect_Wugui.NCS_Block_Perfect_Wugui_C");
			}
			return NCS_Block_Perfect_Wugui_C._ClassPtr;
		}

		// Token: 0x0602A9BA RID: 174522 RVA: 0x00A5DD4C File Offset: 0x00A5BF4C
		public NCS_Block_Perfect_Wugui_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Block_Perfect_Wugui_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A9BB RID: 174523 RVA: 0x00A5DD74 File Offset: 0x00A5BF74
		[NullableContext(1)]
		public NCS_Block_Perfect_Wugui_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Block_Perfect_Wugui_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602A9BC RID: 174524 RVA: 0x00A5DDA7 File Offset: 0x00A5BFA7
		protected NCS_Block_Perfect_Wugui_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040172E0 RID: 94944
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Block_Perfect_Wugui.NCS_Block_Perfect_Wugui_C";

		// Token: 0x040172E1 RID: 94945
		private static IntPtr _ClassPtr;

		// Token: 0x040172E2 RID: 94946
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
