using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Data.Camera
{
	// Token: 0x02003FB6 RID: 16310
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_In_Lv4.CS_Motor_In_Lv4_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class CS_Motor_In_Lv4_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028EE6 RID: 167654 RVA: 0x00A1B0E8 File Offset: 0x00A192E8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (CS_Motor_In_Lv4_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_In_Lv4.CS_Motor_In_Lv4_C");
			}
			return CS_Motor_In_Lv4_C._ClassPtr;
		}

		// Token: 0x06028EE7 RID: 167655 RVA: 0x00A1B10C File Offset: 0x00A1930C
		public CS_Motor_In_Lv4_C() : this(BuiltinUtils.AllocNativeUObject(CS_Motor_In_Lv4_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028EE8 RID: 167656 RVA: 0x00A1B134 File Offset: 0x00A19334
		[NullableContext(1)]
		public CS_Motor_In_Lv4_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CS_Motor_In_Lv4_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028EE9 RID: 167657 RVA: 0x00A1B167 File Offset: 0x00A19367
		protected CS_Motor_In_Lv4_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015A72 RID: 88690
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_In_Lv4.CS_Motor_In_Lv4_C";

		// Token: 0x04015A73 RID: 88691
		private static IntPtr _ClassPtr;

		// Token: 0x04015A74 RID: 88692
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
