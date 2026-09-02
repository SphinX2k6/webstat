using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Data.Camera
{
	// Token: 0x02003FB5 RID: 16309
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_In_Lv3.CS_Motor_In_Lv3_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class CS_Motor_In_Lv3_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028EE2 RID: 167650 RVA: 0x00A1B060 File Offset: 0x00A19260
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (CS_Motor_In_Lv3_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_In_Lv3.CS_Motor_In_Lv3_C");
			}
			return CS_Motor_In_Lv3_C._ClassPtr;
		}

		// Token: 0x06028EE3 RID: 167651 RVA: 0x00A1B084 File Offset: 0x00A19284
		public CS_Motor_In_Lv3_C() : this(BuiltinUtils.AllocNativeUObject(CS_Motor_In_Lv3_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028EE4 RID: 167652 RVA: 0x00A1B0AC File Offset: 0x00A192AC
		[NullableContext(1)]
		public CS_Motor_In_Lv3_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CS_Motor_In_Lv3_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028EE5 RID: 167653 RVA: 0x00A1B0DF File Offset: 0x00A192DF
		protected CS_Motor_In_Lv3_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015A6F RID: 88687
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_In_Lv3.CS_Motor_In_Lv3_C";

		// Token: 0x04015A70 RID: 88688
		private static IntPtr _ClassPtr;

		// Token: 0x04015A71 RID: 88689
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
