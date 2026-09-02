using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera
{
	// Token: 0x0200401F RID: 16415
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_Manipulate_Intercat.NCS_Role_Manipulate_Intercat_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Role_Manipulate_Intercat_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A9E1 RID: 174561 RVA: 0x00A5E278 File Offset: 0x00A5C478
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Role_Manipulate_Intercat_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_Manipulate_Intercat.NCS_Role_Manipulate_Intercat_C");
			}
			return NCS_Role_Manipulate_Intercat_C._ClassPtr;
		}

		// Token: 0x0602A9E2 RID: 174562 RVA: 0x00A5E29C File Offset: 0x00A5C49C
		public NCS_Role_Manipulate_Intercat_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Role_Manipulate_Intercat_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A9E3 RID: 174563 RVA: 0x00A5E2C4 File Offset: 0x00A5C4C4
		[NullableContext(1)]
		public NCS_Role_Manipulate_Intercat_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Role_Manipulate_Intercat_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602A9E4 RID: 174564 RVA: 0x00A5E2F7 File Offset: 0x00A5C4F7
		protected NCS_Role_Manipulate_Intercat_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040172FE RID: 94974
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_Manipulate_Intercat.NCS_Role_Manipulate_Intercat_C";

		// Token: 0x040172FF RID: 94975
		private static IntPtr _ClassPtr;

		// Token: 0x04017300 RID: 94976
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
