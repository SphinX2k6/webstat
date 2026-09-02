using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Data.Camera
{
	// Token: 0x02003FBB RID: 16315
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Jump_xuli.CS_Motor_Jump_xuli_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class CS_Motor_Jump_xuli_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028EFA RID: 167674 RVA: 0x00A1B390 File Offset: 0x00A19590
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (CS_Motor_Jump_xuli_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Jump_xuli.CS_Motor_Jump_xuli_C");
			}
			return CS_Motor_Jump_xuli_C._ClassPtr;
		}

		// Token: 0x06028EFB RID: 167675 RVA: 0x00A1B3B4 File Offset: 0x00A195B4
		public CS_Motor_Jump_xuli_C() : this(BuiltinUtils.AllocNativeUObject(CS_Motor_Jump_xuli_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028EFC RID: 167676 RVA: 0x00A1B3DC File Offset: 0x00A195DC
		[NullableContext(1)]
		public CS_Motor_Jump_xuli_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CS_Motor_Jump_xuli_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028EFD RID: 167677 RVA: 0x00A1B40F File Offset: 0x00A1960F
		protected CS_Motor_Jump_xuli_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015A81 RID: 88705
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Jump_xuli.CS_Motor_Jump_xuli_C";

		// Token: 0x04015A82 RID: 88706
		private static IntPtr _ClassPtr;

		// Token: 0x04015A83 RID: 88707
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
