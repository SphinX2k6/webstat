using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Data.Camera
{
	// Token: 0x02003FAC RID: 16300
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Burning.CS_Motor_Burning_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class CS_Motor_Burning_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028EBE RID: 167614 RVA: 0x00A1AB98 File Offset: 0x00A18D98
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (CS_Motor_Burning_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Burning.CS_Motor_Burning_C");
			}
			return CS_Motor_Burning_C._ClassPtr;
		}

		// Token: 0x06028EBF RID: 167615 RVA: 0x00A1ABBC File Offset: 0x00A18DBC
		public CS_Motor_Burning_C() : this(BuiltinUtils.AllocNativeUObject(CS_Motor_Burning_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028EC0 RID: 167616 RVA: 0x00A1ABE4 File Offset: 0x00A18DE4
		[NullableContext(1)]
		public CS_Motor_Burning_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CS_Motor_Burning_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028EC1 RID: 167617 RVA: 0x00A1AC17 File Offset: 0x00A18E17
		protected CS_Motor_Burning_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015A54 RID: 88660
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Data/Camera/CS_Motor_Burning.CS_Motor_Burning_C";

		// Token: 0x04015A55 RID: 88661
		private static IntPtr _ClassPtr;

		// Token: 0x04015A56 RID: 88662
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
