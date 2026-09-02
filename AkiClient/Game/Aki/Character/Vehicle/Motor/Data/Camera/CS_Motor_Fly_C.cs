using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Data.Camera
{
	// Token: 0x02003FB3 RID: 16307
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Fly.CS_Motor_Fly_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class CS_Motor_Fly_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028EDA RID: 167642 RVA: 0x00A1AF50 File Offset: 0x00A19150
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (CS_Motor_Fly_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Fly.CS_Motor_Fly_C");
			}
			return CS_Motor_Fly_C._ClassPtr;
		}

		// Token: 0x06028EDB RID: 167643 RVA: 0x00A1AF74 File Offset: 0x00A19174
		public CS_Motor_Fly_C() : this(BuiltinUtils.AllocNativeUObject(CS_Motor_Fly_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028EDC RID: 167644 RVA: 0x00A1AF9C File Offset: 0x00A1919C
		[NullableContext(1)]
		public CS_Motor_Fly_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CS_Motor_Fly_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028EDD RID: 167645 RVA: 0x00A1AFCF File Offset: 0x00A191CF
		protected CS_Motor_Fly_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015A69 RID: 88681
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Fly.CS_Motor_Fly_C";

		// Token: 0x04015A6A RID: 88682
		private static IntPtr _ClassPtr;

		// Token: 0x04015A6B RID: 88683
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
