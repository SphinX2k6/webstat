using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Data.Camera
{
	// Token: 0x02003FB0 RID: 16304
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Down_Lv6.CS_Motor_Down_Lv6_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class CS_Motor_Down_Lv6_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028ECE RID: 167630 RVA: 0x00A1ADB8 File Offset: 0x00A18FB8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (CS_Motor_Down_Lv6_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Down_Lv6.CS_Motor_Down_Lv6_C");
			}
			return CS_Motor_Down_Lv6_C._ClassPtr;
		}

		// Token: 0x06028ECF RID: 167631 RVA: 0x00A1ADDC File Offset: 0x00A18FDC
		public CS_Motor_Down_Lv6_C() : this(BuiltinUtils.AllocNativeUObject(CS_Motor_Down_Lv6_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028ED0 RID: 167632 RVA: 0x00A1AE04 File Offset: 0x00A19004
		[NullableContext(1)]
		public CS_Motor_Down_Lv6_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CS_Motor_Down_Lv6_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028ED1 RID: 167633 RVA: 0x00A1AE37 File Offset: 0x00A19037
		protected CS_Motor_Down_Lv6_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015A60 RID: 88672
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Down_Lv6.CS_Motor_Down_Lv6_C";

		// Token: 0x04015A61 RID: 88673
		private static IntPtr _ClassPtr;

		// Token: 0x04015A62 RID: 88674
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
