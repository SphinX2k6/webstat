using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Data.Camera
{
	// Token: 0x02003FAE RID: 16302
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Down_Lv4.CS_Motor_Down_Lv4_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class CS_Motor_Down_Lv4_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028EC6 RID: 167622 RVA: 0x00A1ACA8 File Offset: 0x00A18EA8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (CS_Motor_Down_Lv4_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Down_Lv4.CS_Motor_Down_Lv4_C");
			}
			return CS_Motor_Down_Lv4_C._ClassPtr;
		}

		// Token: 0x06028EC7 RID: 167623 RVA: 0x00A1ACCC File Offset: 0x00A18ECC
		public CS_Motor_Down_Lv4_C() : this(BuiltinUtils.AllocNativeUObject(CS_Motor_Down_Lv4_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028EC8 RID: 167624 RVA: 0x00A1ACF4 File Offset: 0x00A18EF4
		[NullableContext(1)]
		public CS_Motor_Down_Lv4_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CS_Motor_Down_Lv4_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028EC9 RID: 167625 RVA: 0x00A1AD27 File Offset: 0x00A18F27
		protected CS_Motor_Down_Lv4_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015A5A RID: 88666
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Down_Lv4.CS_Motor_Down_Lv4_C";

		// Token: 0x04015A5B RID: 88667
		private static IntPtr _ClassPtr;

		// Token: 0x04015A5C RID: 88668
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
