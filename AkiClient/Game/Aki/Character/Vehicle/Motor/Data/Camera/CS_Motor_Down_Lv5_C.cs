using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Data.Camera
{
	// Token: 0x02003FAF RID: 16303
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Down_Lv5.CS_Motor_Down_Lv5_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class CS_Motor_Down_Lv5_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028ECA RID: 167626 RVA: 0x00A1AD30 File Offset: 0x00A18F30
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (CS_Motor_Down_Lv5_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Down_Lv5.CS_Motor_Down_Lv5_C");
			}
			return CS_Motor_Down_Lv5_C._ClassPtr;
		}

		// Token: 0x06028ECB RID: 167627 RVA: 0x00A1AD54 File Offset: 0x00A18F54
		public CS_Motor_Down_Lv5_C() : this(BuiltinUtils.AllocNativeUObject(CS_Motor_Down_Lv5_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028ECC RID: 167628 RVA: 0x00A1AD7C File Offset: 0x00A18F7C
		[NullableContext(1)]
		public CS_Motor_Down_Lv5_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CS_Motor_Down_Lv5_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028ECD RID: 167629 RVA: 0x00A1ADAF File Offset: 0x00A18FAF
		protected CS_Motor_Down_Lv5_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015A5D RID: 88669
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Down_Lv5.CS_Motor_Down_Lv5_C";

		// Token: 0x04015A5E RID: 88670
		private static IntPtr _ClassPtr;

		// Token: 0x04015A5F RID: 88671
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
