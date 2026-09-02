using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera
{
	// Token: 0x02004016 RID: 16406
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_DarkZhu_Burst.NCS_DarkZhu_Burst_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_DarkZhu_Burst_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A9BD RID: 174525 RVA: 0x00A5DDB0 File Offset: 0x00A5BFB0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_DarkZhu_Burst_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_DarkZhu_Burst.NCS_DarkZhu_Burst_C");
			}
			return NCS_DarkZhu_Burst_C._ClassPtr;
		}

		// Token: 0x0602A9BE RID: 174526 RVA: 0x00A5DDD4 File Offset: 0x00A5BFD4
		public NCS_DarkZhu_Burst_C() : this(BuiltinUtils.AllocNativeUObject(NCS_DarkZhu_Burst_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A9BF RID: 174527 RVA: 0x00A5DDFC File Offset: 0x00A5BFFC
		[NullableContext(1)]
		public NCS_DarkZhu_Burst_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_DarkZhu_Burst_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602A9C0 RID: 174528 RVA: 0x00A5DE2F File Offset: 0x00A5C02F
		protected NCS_DarkZhu_Burst_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040172E3 RID: 94947
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_DarkZhu_Burst.NCS_DarkZhu_Burst_C";

		// Token: 0x040172E4 RID: 94948
		private static IntPtr _ClassPtr;

		// Token: 0x040172E5 RID: 94949
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
