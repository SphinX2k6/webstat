using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Data.Camera
{
	// Token: 0x02003FB1 RID: 16305
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Down_Lv7.CS_Motor_Down_Lv7_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class CS_Motor_Down_Lv7_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028ED2 RID: 167634 RVA: 0x00A1AE40 File Offset: 0x00A19040
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (CS_Motor_Down_Lv7_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Down_Lv7.CS_Motor_Down_Lv7_C");
			}
			return CS_Motor_Down_Lv7_C._ClassPtr;
		}

		// Token: 0x06028ED3 RID: 167635 RVA: 0x00A1AE64 File Offset: 0x00A19064
		public CS_Motor_Down_Lv7_C() : this(BuiltinUtils.AllocNativeUObject(CS_Motor_Down_Lv7_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028ED4 RID: 167636 RVA: 0x00A1AE8C File Offset: 0x00A1908C
		[NullableContext(1)]
		public CS_Motor_Down_Lv7_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CS_Motor_Down_Lv7_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028ED5 RID: 167637 RVA: 0x00A1AEBF File Offset: 0x00A190BF
		protected CS_Motor_Down_Lv7_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015A63 RID: 88675
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Down_Lv7.CS_Motor_Down_Lv7_C";

		// Token: 0x04015A64 RID: 88676
		private static IntPtr _ClassPtr;

		// Token: 0x04015A65 RID: 88677
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
