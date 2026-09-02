using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera
{
	// Token: 0x0200401E RID: 16414
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_Manipulate_HoldShake_Tmp.NCS_Role_Manipulate_HoldShake_Tmp_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Role_Manipulate_HoldShake_Tmp_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A9DD RID: 174557 RVA: 0x00A5E1F0 File Offset: 0x00A5C3F0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Role_Manipulate_HoldShake_Tmp_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_Manipulate_HoldShake_Tmp.NCS_Role_Manipulate_HoldShake_Tmp_C");
			}
			return NCS_Role_Manipulate_HoldShake_Tmp_C._ClassPtr;
		}

		// Token: 0x0602A9DE RID: 174558 RVA: 0x00A5E214 File Offset: 0x00A5C414
		public NCS_Role_Manipulate_HoldShake_Tmp_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Role_Manipulate_HoldShake_Tmp_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A9DF RID: 174559 RVA: 0x00A5E23C File Offset: 0x00A5C43C
		[NullableContext(1)]
		public NCS_Role_Manipulate_HoldShake_Tmp_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Role_Manipulate_HoldShake_Tmp_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602A9E0 RID: 174560 RVA: 0x00A5E26F File Offset: 0x00A5C46F
		protected NCS_Role_Manipulate_HoldShake_Tmp_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040172FB RID: 94971
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_Manipulate_HoldShake_Tmp.NCS_Role_Manipulate_HoldShake_Tmp_C";

		// Token: 0x040172FC RID: 94972
		private static IntPtr _ClassPtr;

		// Token: 0x040172FD RID: 94973
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
