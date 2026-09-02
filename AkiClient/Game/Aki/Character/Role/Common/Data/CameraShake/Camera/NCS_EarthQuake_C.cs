using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera
{
	// Token: 0x02004017 RID: 16407
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_EarthQuake.NCS_EarthQuake_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_EarthQuake_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A9C1 RID: 174529 RVA: 0x00A5DE38 File Offset: 0x00A5C038
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_EarthQuake_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_EarthQuake.NCS_EarthQuake_C");
			}
			return NCS_EarthQuake_C._ClassPtr;
		}

		// Token: 0x0602A9C2 RID: 174530 RVA: 0x00A5DE5C File Offset: 0x00A5C05C
		public NCS_EarthQuake_C() : this(BuiltinUtils.AllocNativeUObject(NCS_EarthQuake_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A9C3 RID: 174531 RVA: 0x00A5DE84 File Offset: 0x00A5C084
		[NullableContext(1)]
		public NCS_EarthQuake_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_EarthQuake_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602A9C4 RID: 174532 RVA: 0x00A5DEB7 File Offset: 0x00A5C0B7
		protected NCS_EarthQuake_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040172E6 RID: 94950
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_EarthQuake.NCS_EarthQuake_C";

		// Token: 0x040172E7 RID: 94951
		private static IntPtr _ClassPtr;

		// Token: 0x040172E8 RID: 94952
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
