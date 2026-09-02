using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Data.Camera
{
	// Token: 0x02003FAB RID: 16299
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_MotorSkill.CS_MotorSkill_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class CS_MotorSkill_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028EBA RID: 167610 RVA: 0x00A1AB0F File Offset: 0x00A18D0F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (CS_MotorSkill_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_MotorSkill.CS_MotorSkill_C");
			}
			return CS_MotorSkill_C._ClassPtr;
		}

		// Token: 0x06028EBB RID: 167611 RVA: 0x00A1AB34 File Offset: 0x00A18D34
		public CS_MotorSkill_C() : this(BuiltinUtils.AllocNativeUObject(CS_MotorSkill_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028EBC RID: 167612 RVA: 0x00A1AB5C File Offset: 0x00A18D5C
		[NullableContext(1)]
		public CS_MotorSkill_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CS_MotorSkill_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028EBD RID: 167613 RVA: 0x00A1AB8F File Offset: 0x00A18D8F
		protected CS_MotorSkill_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015A51 RID: 88657
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_MotorSkill.CS_MotorSkill_C";

		// Token: 0x04015A52 RID: 88658
		private static IntPtr _ClassPtr;

		// Token: 0x04015A53 RID: 88659
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
