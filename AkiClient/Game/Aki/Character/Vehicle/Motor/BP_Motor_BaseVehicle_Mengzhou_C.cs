using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor
{
	// Token: 0x02003F95 RID: 16277
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/BP_Motor_BaseVehicle_Mengzhou.BP_Motor_BaseVehicle_Mengzhou_C")]
	[UnrealStructLayout(2256, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2256)]
	public class BP_Motor_BaseVehicle_Mengzhou_C : BP_Motor_BaseVehicle_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028CC4 RID: 167108 RVA: 0x00A16E46 File Offset: 0x00A15046
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Motor_BaseVehicle_Mengzhou_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/BP_Motor_BaseVehicle_Mengzhou.BP_Motor_BaseVehicle_Mengzhou_C");
			}
			return BP_Motor_BaseVehicle_Mengzhou_C._ClassPtr;
		}

		// Token: 0x06028CC5 RID: 167109 RVA: 0x00A16E6C File Offset: 0x00A1506C
		public BP_Motor_BaseVehicle_Mengzhou_C() : this(BuiltinUtils.AllocNativeUObject(BP_Motor_BaseVehicle_Mengzhou_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028CC6 RID: 167110 RVA: 0x00A16E94 File Offset: 0x00A15094
		[NullableContext(1)]
		public BP_Motor_BaseVehicle_Mengzhou_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Motor_BaseVehicle_Mengzhou_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028CC7 RID: 167111 RVA: 0x00A16EC7 File Offset: 0x00A150C7
		protected BP_Motor_BaseVehicle_Mengzhou_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015905 RID: 88325
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/BP_Motor_BaseVehicle_Mengzhou.BP_Motor_BaseVehicle_Mengzhou_C";

		// Token: 0x04015906 RID: 88326
		private static IntPtr _ClassPtr;

		// Token: 0x04015907 RID: 88327
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
