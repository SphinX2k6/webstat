using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Data.Camera
{
	// Token: 0x02003FBC RID: 16316
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Out.CS_Motor_Out_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class CS_Motor_Out_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028EFE RID: 167678 RVA: 0x00A1B418 File Offset: 0x00A19618
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (CS_Motor_Out_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Out.CS_Motor_Out_C");
			}
			return CS_Motor_Out_C._ClassPtr;
		}

		// Token: 0x06028EFF RID: 167679 RVA: 0x00A1B43C File Offset: 0x00A1963C
		public CS_Motor_Out_C() : this(BuiltinUtils.AllocNativeUObject(CS_Motor_Out_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028F00 RID: 167680 RVA: 0x00A1B464 File Offset: 0x00A19664
		[NullableContext(1)]
		public CS_Motor_Out_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CS_Motor_Out_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028F01 RID: 167681 RVA: 0x00A1B497 File Offset: 0x00A19697
		protected CS_Motor_Out_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015A84 RID: 88708
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Out.CS_Motor_Out_C";

		// Token: 0x04015A85 RID: 88709
		private static IntPtr _ClassPtr;

		// Token: 0x04015A86 RID: 88710
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
