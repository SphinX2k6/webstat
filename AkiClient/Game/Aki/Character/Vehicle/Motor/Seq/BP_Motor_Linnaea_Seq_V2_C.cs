using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Seq
{
	// Token: 0x02003F9A RID: 16282
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Seq/BP_Motor_Linnaea_Seq_V2.BP_Motor_Linnaea_Seq_V2_C")]
	[UnrealStructLayout(1200, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1200)]
	public class BP_Motor_Linnaea_Seq_V2_C : BP_Motor_BaseVehicle_Seq_V2_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028D29 RID: 167209 RVA: 0x00A17AE4 File Offset: 0x00A15CE4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Motor_Linnaea_Seq_V2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Seq/BP_Motor_Linnaea_Seq_V2.BP_Motor_Linnaea_Seq_V2_C");
			}
			return BP_Motor_Linnaea_Seq_V2_C._ClassPtr;
		}

		// Token: 0x06028D2A RID: 167210 RVA: 0x00A17B08 File Offset: 0x00A15D08
		public BP_Motor_Linnaea_Seq_V2_C() : this(BuiltinUtils.AllocNativeUObject(BP_Motor_Linnaea_Seq_V2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028D2B RID: 167211 RVA: 0x00A17B30 File Offset: 0x00A15D30
		[NullableContext(1)]
		public BP_Motor_Linnaea_Seq_V2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Motor_Linnaea_Seq_V2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028D2C RID: 167212 RVA: 0x00A17B63 File Offset: 0x00A15D63
		protected BP_Motor_Linnaea_Seq_V2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015944 RID: 88388
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Seq/BP_Motor_Linnaea_Seq_V2.BP_Motor_Linnaea_Seq_V2_C";

		// Token: 0x04015945 RID: 88389
		private static IntPtr _ClassPtr;

		// Token: 0x04015946 RID: 88390
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
