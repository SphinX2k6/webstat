using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera
{
	// Token: 0x02004020 RID: 16416
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_Soar.NCS_Role_Soar_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Role_Soar_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A9E5 RID: 174565 RVA: 0x00A5E300 File Offset: 0x00A5C500
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Role_Soar_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_Soar.NCS_Role_Soar_C");
			}
			return NCS_Role_Soar_C._ClassPtr;
		}

		// Token: 0x0602A9E6 RID: 174566 RVA: 0x00A5E324 File Offset: 0x00A5C524
		public NCS_Role_Soar_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Role_Soar_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A9E7 RID: 174567 RVA: 0x00A5E34C File Offset: 0x00A5C54C
		[NullableContext(1)]
		public NCS_Role_Soar_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Role_Soar_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602A9E8 RID: 174568 RVA: 0x00A5E37F File Offset: 0x00A5C57F
		protected NCS_Role_Soar_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017301 RID: 94977
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_Soar.NCS_Role_Soar_C";

		// Token: 0x04017302 RID: 94978
		private static IntPtr _ClassPtr;

		// Token: 0x04017303 RID: 94979
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
