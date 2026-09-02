using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera
{
	// Token: 0x0200401D RID: 16413
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_Manipulate_HoldShake.NCS_Role_Manipulate_HoldShake_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Role_Manipulate_HoldShake_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A9D9 RID: 174553 RVA: 0x00A5E168 File Offset: 0x00A5C368
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Role_Manipulate_HoldShake_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_Manipulate_HoldShake.NCS_Role_Manipulate_HoldShake_C");
			}
			return NCS_Role_Manipulate_HoldShake_C._ClassPtr;
		}

		// Token: 0x0602A9DA RID: 174554 RVA: 0x00A5E18C File Offset: 0x00A5C38C
		public NCS_Role_Manipulate_HoldShake_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Role_Manipulate_HoldShake_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A9DB RID: 174555 RVA: 0x00A5E1B4 File Offset: 0x00A5C3B4
		[NullableContext(1)]
		public NCS_Role_Manipulate_HoldShake_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Role_Manipulate_HoldShake_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602A9DC RID: 174556 RVA: 0x00A5E1E7 File Offset: 0x00A5C3E7
		protected NCS_Role_Manipulate_HoldShake_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040172F8 RID: 94968
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_Manipulate_HoldShake.NCS_Role_Manipulate_HoldShake_C";

		// Token: 0x040172F9 RID: 94969
		private static IntPtr _ClassPtr;

		// Token: 0x040172FA RID: 94970
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
