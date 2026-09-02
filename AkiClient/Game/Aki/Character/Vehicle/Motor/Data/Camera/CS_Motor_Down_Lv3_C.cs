using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Data.Camera
{
	// Token: 0x02003FAD RID: 16301
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Down_Lv3.CS_Motor_Down_Lv3_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class CS_Motor_Down_Lv3_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028EC2 RID: 167618 RVA: 0x00A1AC20 File Offset: 0x00A18E20
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (CS_Motor_Down_Lv3_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Down_Lv3.CS_Motor_Down_Lv3_C");
			}
			return CS_Motor_Down_Lv3_C._ClassPtr;
		}

		// Token: 0x06028EC3 RID: 167619 RVA: 0x00A1AC44 File Offset: 0x00A18E44
		public CS_Motor_Down_Lv3_C() : this(BuiltinUtils.AllocNativeUObject(CS_Motor_Down_Lv3_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028EC4 RID: 167620 RVA: 0x00A1AC6C File Offset: 0x00A18E6C
		[NullableContext(1)]
		public CS_Motor_Down_Lv3_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CS_Motor_Down_Lv3_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028EC5 RID: 167621 RVA: 0x00A1AC9F File Offset: 0x00A18E9F
		protected CS_Motor_Down_Lv3_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015A57 RID: 88663
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Down_Lv3.CS_Motor_Down_Lv3_C";

		// Token: 0x04015A58 RID: 88664
		private static IntPtr _ClassPtr;

		// Token: 0x04015A59 RID: 88665
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
