using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Seq
{
	// Token: 0x02003F9C RID: 16284
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Seq/BP_Motor_Yangyang_Seq_V2.BP_Motor_Yangyang_Seq_V2_C")]
	[UnrealStructLayout(1200, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1200)]
	public class BP_Motor_Yangyang_Seq_V2_C : BP_Motor_BaseVehicle_Seq_V2_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028D31 RID: 167217 RVA: 0x00A17BF4 File Offset: 0x00A15DF4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Motor_Yangyang_Seq_V2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Seq/BP_Motor_Yangyang_Seq_V2.BP_Motor_Yangyang_Seq_V2_C");
			}
			return BP_Motor_Yangyang_Seq_V2_C._ClassPtr;
		}

		// Token: 0x06028D32 RID: 167218 RVA: 0x00A17C18 File Offset: 0x00A15E18
		public BP_Motor_Yangyang_Seq_V2_C() : this(BuiltinUtils.AllocNativeUObject(BP_Motor_Yangyang_Seq_V2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028D33 RID: 167219 RVA: 0x00A17C40 File Offset: 0x00A15E40
		[NullableContext(1)]
		public BP_Motor_Yangyang_Seq_V2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Motor_Yangyang_Seq_V2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028D34 RID: 167220 RVA: 0x00A17C73 File Offset: 0x00A15E73
		protected BP_Motor_Yangyang_Seq_V2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401594A RID: 88394
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Seq/BP_Motor_Yangyang_Seq_V2.BP_Motor_Yangyang_Seq_V2_C";

		// Token: 0x0401594B RID: 88395
		private static IntPtr _ClassPtr;

		// Token: 0x0401594C RID: 88396
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
