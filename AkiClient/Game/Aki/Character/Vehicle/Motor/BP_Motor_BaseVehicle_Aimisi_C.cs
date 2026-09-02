using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor
{
	// Token: 0x02003F92 RID: 16274
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/BP_Motor_BaseVehicle_Aimisi.BP_Motor_BaseVehicle_Aimisi_C")]
	[UnrealStructLayout(2256, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2256)]
	public class BP_Motor_BaseVehicle_Aimisi_C : BP_Motor_BaseVehicle_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028C89 RID: 167049 RVA: 0x00A16730 File Offset: 0x00A14930
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Motor_BaseVehicle_Aimisi_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/BP_Motor_BaseVehicle_Aimisi.BP_Motor_BaseVehicle_Aimisi_C");
			}
			return BP_Motor_BaseVehicle_Aimisi_C._ClassPtr;
		}

		// Token: 0x06028C8A RID: 167050 RVA: 0x00A16754 File Offset: 0x00A14954
		public BP_Motor_BaseVehicle_Aimisi_C() : this(BuiltinUtils.AllocNativeUObject(BP_Motor_BaseVehicle_Aimisi_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028C8B RID: 167051 RVA: 0x00A1677C File Offset: 0x00A1497C
		[NullableContext(1)]
		public BP_Motor_BaseVehicle_Aimisi_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Motor_BaseVehicle_Aimisi_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028C8C RID: 167052 RVA: 0x00A167AF File Offset: 0x00A149AF
		protected BP_Motor_BaseVehicle_Aimisi_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040158E0 RID: 88288
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/BP_Motor_BaseVehicle_Aimisi.BP_Motor_BaseVehicle_Aimisi_C";

		// Token: 0x040158E1 RID: 88289
		private static IntPtr _ClassPtr;

		// Token: 0x040158E2 RID: 88290
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
