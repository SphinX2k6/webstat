using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Seq
{
	// Token: 0x02003F9B RID: 16283
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Seq/BP_Motor_Mengzhou_Seq_V2.BP_Motor_Mengzhou_Seq_V2_C")]
	[UnrealStructLayout(1200, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1200)]
	public class BP_Motor_Mengzhou_Seq_V2_C : BP_Motor_BaseVehicle_Seq_V2_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028D2D RID: 167213 RVA: 0x00A17B6C File Offset: 0x00A15D6C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Motor_Mengzhou_Seq_V2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Seq/BP_Motor_Mengzhou_Seq_V2.BP_Motor_Mengzhou_Seq_V2_C");
			}
			return BP_Motor_Mengzhou_Seq_V2_C._ClassPtr;
		}

		// Token: 0x06028D2E RID: 167214 RVA: 0x00A17B90 File Offset: 0x00A15D90
		public BP_Motor_Mengzhou_Seq_V2_C() : this(BuiltinUtils.AllocNativeUObject(BP_Motor_Mengzhou_Seq_V2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028D2F RID: 167215 RVA: 0x00A17BB8 File Offset: 0x00A15DB8
		[NullableContext(1)]
		public BP_Motor_Mengzhou_Seq_V2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Motor_Mengzhou_Seq_V2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028D30 RID: 167216 RVA: 0x00A17BEB File Offset: 0x00A15DEB
		protected BP_Motor_Mengzhou_Seq_V2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015947 RID: 88391
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Seq/BP_Motor_Mengzhou_Seq_V2.BP_Motor_Mengzhou_Seq_V2_C";

		// Token: 0x04015948 RID: 88392
		private static IntPtr _ClassPtr;

		// Token: 0x04015949 RID: 88393
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
