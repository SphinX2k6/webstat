using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera
{
	// Token: 0x0200401C RID: 16412
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_Manipulate_Draw.NCS_Role_Manipulate_Draw_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Role_Manipulate_Draw_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A9D5 RID: 174549 RVA: 0x00A5E0E0 File Offset: 0x00A5C2E0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Role_Manipulate_Draw_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_Manipulate_Draw.NCS_Role_Manipulate_Draw_C");
			}
			return NCS_Role_Manipulate_Draw_C._ClassPtr;
		}

		// Token: 0x0602A9D6 RID: 174550 RVA: 0x00A5E104 File Offset: 0x00A5C304
		public NCS_Role_Manipulate_Draw_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Role_Manipulate_Draw_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A9D7 RID: 174551 RVA: 0x00A5E12C File Offset: 0x00A5C32C
		[NullableContext(1)]
		public NCS_Role_Manipulate_Draw_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Role_Manipulate_Draw_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602A9D8 RID: 174552 RVA: 0x00A5E15F File Offset: 0x00A5C35F
		protected NCS_Role_Manipulate_Draw_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040172F5 RID: 94965
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_Manipulate_Draw.NCS_Role_Manipulate_Draw_C";

		// Token: 0x040172F6 RID: 94966
		private static IntPtr _ClassPtr;

		// Token: 0x040172F7 RID: 94967
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
