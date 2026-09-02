using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera
{
	// Token: 0x0200401B RID: 16411
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_Manipulate_Chant.NCS_Role_Manipulate_Chant_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Role_Manipulate_Chant_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A9D1 RID: 174545 RVA: 0x00A5E058 File Offset: 0x00A5C258
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Role_Manipulate_Chant_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_Manipulate_Chant.NCS_Role_Manipulate_Chant_C");
			}
			return NCS_Role_Manipulate_Chant_C._ClassPtr;
		}

		// Token: 0x0602A9D2 RID: 174546 RVA: 0x00A5E07C File Offset: 0x00A5C27C
		public NCS_Role_Manipulate_Chant_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Role_Manipulate_Chant_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A9D3 RID: 174547 RVA: 0x00A5E0A4 File Offset: 0x00A5C2A4
		[NullableContext(1)]
		public NCS_Role_Manipulate_Chant_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Role_Manipulate_Chant_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602A9D4 RID: 174548 RVA: 0x00A5E0D7 File Offset: 0x00A5C2D7
		protected NCS_Role_Manipulate_Chant_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040172F2 RID: 94962
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_Manipulate_Chant.NCS_Role_Manipulate_Chant_C";

		// Token: 0x040172F3 RID: 94963
		private static IntPtr _ClassPtr;

		// Token: 0x040172F4 RID: 94964
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
