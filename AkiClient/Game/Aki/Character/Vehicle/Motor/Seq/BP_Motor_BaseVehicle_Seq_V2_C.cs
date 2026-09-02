using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Vehicle.Seq;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Seq
{
	// Token: 0x02003F99 RID: 16281
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Seq/BP_Motor_BaseVehicle_Seq_V2.BP_Motor_BaseVehicle_Seq_V2_C")]
	[UnrealStructLayout(1200, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1200)]
	public class BP_Motor_BaseVehicle_Seq_V2_C : BP_BaseVehicle_Seq_V2_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028D25 RID: 167205 RVA: 0x00A17A59 File Offset: 0x00A15C59
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Motor_BaseVehicle_Seq_V2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Seq/BP_Motor_BaseVehicle_Seq_V2.BP_Motor_BaseVehicle_Seq_V2_C");
			}
			return BP_Motor_BaseVehicle_Seq_V2_C._ClassPtr;
		}

		// Token: 0x06028D26 RID: 167206 RVA: 0x00A17A80 File Offset: 0x00A15C80
		public BP_Motor_BaseVehicle_Seq_V2_C() : this(BuiltinUtils.AllocNativeUObject(BP_Motor_BaseVehicle_Seq_V2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028D27 RID: 167207 RVA: 0x00A17AA8 File Offset: 0x00A15CA8
		[NullableContext(1)]
		public BP_Motor_BaseVehicle_Seq_V2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Motor_BaseVehicle_Seq_V2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028D28 RID: 167208 RVA: 0x00A17ADB File Offset: 0x00A15CDB
		protected BP_Motor_BaseVehicle_Seq_V2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015941 RID: 88385
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Seq/BP_Motor_BaseVehicle_Seq_V2.BP_Motor_BaseVehicle_Seq_V2_C";

		// Token: 0x04015942 RID: 88386
		private static IntPtr _ClassPtr;

		// Token: 0x04015943 RID: 88387
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
