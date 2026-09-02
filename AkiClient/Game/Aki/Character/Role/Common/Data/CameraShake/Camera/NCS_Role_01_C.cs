using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera
{
	// Token: 0x02004019 RID: 16409
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_01.NCS_Role_01_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Role_01_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A9C9 RID: 174537 RVA: 0x00A5DF48 File Offset: 0x00A5C148
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Role_01_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_01.NCS_Role_01_C");
			}
			return NCS_Role_01_C._ClassPtr;
		}

		// Token: 0x0602A9CA RID: 174538 RVA: 0x00A5DF6C File Offset: 0x00A5C16C
		public NCS_Role_01_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Role_01_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A9CB RID: 174539 RVA: 0x00A5DF94 File Offset: 0x00A5C194
		[NullableContext(1)]
		public NCS_Role_01_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Role_01_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602A9CC RID: 174540 RVA: 0x00A5DFC7 File Offset: 0x00A5C1C7
		protected NCS_Role_01_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040172EC RID: 94956
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_01.NCS_Role_01_C";

		// Token: 0x040172ED RID: 94957
		private static IntPtr _ClassPtr;

		// Token: 0x040172EE RID: 94958
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
