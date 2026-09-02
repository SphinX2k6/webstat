using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Data.Camera
{
	// Token: 0x02003FB7 RID: 16311
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_In_Lv5.CS_Motor_In_Lv5_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class CS_Motor_In_Lv5_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028EEA RID: 167658 RVA: 0x00A1B170 File Offset: 0x00A19370
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (CS_Motor_In_Lv5_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_In_Lv5.CS_Motor_In_Lv5_C");
			}
			return CS_Motor_In_Lv5_C._ClassPtr;
		}

		// Token: 0x06028EEB RID: 167659 RVA: 0x00A1B194 File Offset: 0x00A19394
		public CS_Motor_In_Lv5_C() : this(BuiltinUtils.AllocNativeUObject(CS_Motor_In_Lv5_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028EEC RID: 167660 RVA: 0x00A1B1BC File Offset: 0x00A193BC
		[NullableContext(1)]
		public CS_Motor_In_Lv5_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CS_Motor_In_Lv5_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028EED RID: 167661 RVA: 0x00A1B1EF File Offset: 0x00A193EF
		protected CS_Motor_In_Lv5_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015A75 RID: 88693
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_In_Lv5.CS_Motor_In_Lv5_C";

		// Token: 0x04015A76 RID: 88694
		private static IntPtr _ClassPtr;

		// Token: 0x04015A77 RID: 88695
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
