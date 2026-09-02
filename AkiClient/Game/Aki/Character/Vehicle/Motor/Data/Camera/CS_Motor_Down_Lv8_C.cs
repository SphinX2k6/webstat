using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Data.Camera
{
	// Token: 0x02003FB2 RID: 16306
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Down_Lv8.CS_Motor_Down_Lv8_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class CS_Motor_Down_Lv8_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028ED6 RID: 167638 RVA: 0x00A1AEC8 File Offset: 0x00A190C8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (CS_Motor_Down_Lv8_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Down_Lv8.CS_Motor_Down_Lv8_C");
			}
			return CS_Motor_Down_Lv8_C._ClassPtr;
		}

		// Token: 0x06028ED7 RID: 167639 RVA: 0x00A1AEEC File Offset: 0x00A190EC
		public CS_Motor_Down_Lv8_C() : this(BuiltinUtils.AllocNativeUObject(CS_Motor_Down_Lv8_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028ED8 RID: 167640 RVA: 0x00A1AF14 File Offset: 0x00A19114
		[NullableContext(1)]
		public CS_Motor_Down_Lv8_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CS_Motor_Down_Lv8_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028ED9 RID: 167641 RVA: 0x00A1AF47 File Offset: 0x00A19147
		protected CS_Motor_Down_Lv8_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015A66 RID: 88678
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Down_Lv8.CS_Motor_Down_Lv8_C";

		// Token: 0x04015A67 RID: 88679
		private static IntPtr _ClassPtr;

		// Token: 0x04015A68 RID: 88680
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
