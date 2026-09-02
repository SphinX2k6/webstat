using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Data.Camera
{
	// Token: 0x02003FBA RID: 16314
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Jump.CS_Motor_Jump_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class CS_Motor_Jump_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028EF6 RID: 167670 RVA: 0x00A1B308 File Offset: 0x00A19508
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (CS_Motor_Jump_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Jump.CS_Motor_Jump_C");
			}
			return CS_Motor_Jump_C._ClassPtr;
		}

		// Token: 0x06028EF7 RID: 167671 RVA: 0x00A1B32C File Offset: 0x00A1952C
		public CS_Motor_Jump_C() : this(BuiltinUtils.AllocNativeUObject(CS_Motor_Jump_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028EF8 RID: 167672 RVA: 0x00A1B354 File Offset: 0x00A19554
		[NullableContext(1)]
		public CS_Motor_Jump_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CS_Motor_Jump_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028EF9 RID: 167673 RVA: 0x00A1B387 File Offset: 0x00A19587
		protected CS_Motor_Jump_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015A7E RID: 88702
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Jump.CS_Motor_Jump_C";

		// Token: 0x04015A7F RID: 88703
		private static IntPtr _ClassPtr;

		// Token: 0x04015A80 RID: 88704
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
