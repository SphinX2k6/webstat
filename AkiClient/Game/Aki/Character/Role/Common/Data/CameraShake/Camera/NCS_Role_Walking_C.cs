using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera
{
	// Token: 0x02004021 RID: 16417
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_Walking.NCS_Role_Walking_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Role_Walking_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A9E9 RID: 174569 RVA: 0x00A5E388 File Offset: 0x00A5C588
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Role_Walking_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_Walking.NCS_Role_Walking_C");
			}
			return NCS_Role_Walking_C._ClassPtr;
		}

		// Token: 0x0602A9EA RID: 174570 RVA: 0x00A5E3AC File Offset: 0x00A5C5AC
		public NCS_Role_Walking_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Role_Walking_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A9EB RID: 174571 RVA: 0x00A5E3D4 File Offset: 0x00A5C5D4
		[NullableContext(1)]
		public NCS_Role_Walking_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Role_Walking_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602A9EC RID: 174572 RVA: 0x00A5E407 File Offset: 0x00A5C607
		protected NCS_Role_Walking_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017304 RID: 94980
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_Walking.NCS_Role_Walking_C";

		// Token: 0x04017305 RID: 94981
		private static IntPtr _ClassPtr;

		// Token: 0x04017306 RID: 94982
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
