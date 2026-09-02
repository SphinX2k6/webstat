using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Data.Camera
{
	// Token: 0x02003FB4 RID: 16308
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Fly_In.CS_Motor_Fly_In_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class CS_Motor_Fly_In_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028EDE RID: 167646 RVA: 0x00A1AFD8 File Offset: 0x00A191D8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (CS_Motor_Fly_In_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Fly_In.CS_Motor_Fly_In_C");
			}
			return CS_Motor_Fly_In_C._ClassPtr;
		}

		// Token: 0x06028EDF RID: 167647 RVA: 0x00A1AFFC File Offset: 0x00A191FC
		public CS_Motor_Fly_In_C() : this(BuiltinUtils.AllocNativeUObject(CS_Motor_Fly_In_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028EE0 RID: 167648 RVA: 0x00A1B024 File Offset: 0x00A19224
		[NullableContext(1)]
		public CS_Motor_Fly_In_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CS_Motor_Fly_In_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028EE1 RID: 167649 RVA: 0x00A1B057 File Offset: 0x00A19257
		protected CS_Motor_Fly_In_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015A6C RID: 88684
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Fly_In.CS_Motor_Fly_In_C";

		// Token: 0x04015A6D RID: 88685
		private static IntPtr _ClassPtr;

		// Token: 0x04015A6E RID: 88686
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
