using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Data.Camera
{
	// Token: 0x02003FB8 RID: 16312
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_In_Lv6.CS_Motor_In_Lv6_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class CS_Motor_In_Lv6_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028EEE RID: 167662 RVA: 0x00A1B1F8 File Offset: 0x00A193F8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (CS_Motor_In_Lv6_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_In_Lv6.CS_Motor_In_Lv6_C");
			}
			return CS_Motor_In_Lv6_C._ClassPtr;
		}

		// Token: 0x06028EEF RID: 167663 RVA: 0x00A1B21C File Offset: 0x00A1941C
		public CS_Motor_In_Lv6_C() : this(BuiltinUtils.AllocNativeUObject(CS_Motor_In_Lv6_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028EF0 RID: 167664 RVA: 0x00A1B244 File Offset: 0x00A19444
		[NullableContext(1)]
		public CS_Motor_In_Lv6_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CS_Motor_In_Lv6_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028EF1 RID: 167665 RVA: 0x00A1B277 File Offset: 0x00A19477
		protected CS_Motor_In_Lv6_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015A78 RID: 88696
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_In_Lv6.CS_Motor_In_Lv6_C";

		// Token: 0x04015A79 RID: 88697
		private static IntPtr _ClassPtr;

		// Token: 0x04015A7A RID: 88698
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
