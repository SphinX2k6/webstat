using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Data.Camera
{
	// Token: 0x02003FB9 RID: 16313
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_In_Lv7.CS_Motor_In_Lv7_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class CS_Motor_In_Lv7_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028EF2 RID: 167666 RVA: 0x00A1B280 File Offset: 0x00A19480
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (CS_Motor_In_Lv7_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_In_Lv7.CS_Motor_In_Lv7_C");
			}
			return CS_Motor_In_Lv7_C._ClassPtr;
		}

		// Token: 0x06028EF3 RID: 167667 RVA: 0x00A1B2A4 File Offset: 0x00A194A4
		public CS_Motor_In_Lv7_C() : this(BuiltinUtils.AllocNativeUObject(CS_Motor_In_Lv7_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028EF4 RID: 167668 RVA: 0x00A1B2CC File Offset: 0x00A194CC
		[NullableContext(1)]
		public CS_Motor_In_Lv7_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CS_Motor_In_Lv7_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028EF5 RID: 167669 RVA: 0x00A1B2FF File Offset: 0x00A194FF
		protected CS_Motor_In_Lv7_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015A7B RID: 88699
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_In_Lv7.CS_Motor_In_Lv7_C";

		// Token: 0x04015A7C RID: 88700
		private static IntPtr _ClassPtr;

		// Token: 0x04015A7D RID: 88701
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
