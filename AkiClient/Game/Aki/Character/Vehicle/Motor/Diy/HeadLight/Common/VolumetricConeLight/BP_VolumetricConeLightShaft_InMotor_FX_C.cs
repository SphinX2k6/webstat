using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Diy.HeadLight.Common.VolumetricConeLight
{
	// Token: 0x02003FA1 RID: 16289
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Diy/HeadLight/Common/VolumetricConeLight/BP_VolumetricConeLightShaft_InMotor_FX.BP_VolumetricConeLightShaft_InMotor_FX_C")]
	[UnrealStructLayout(2744, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2744)]
	public class BP_VolumetricConeLightShaft_InMotor_FX_C : BP_VolumetricConeLightShaft_InMotor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028DEC RID: 167404 RVA: 0x00A18FC8 File Offset: 0x00A171C8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VolumetricConeLightShaft_InMotor_FX_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Diy/HeadLight/Common/VolumetricConeLight/BP_VolumetricConeLightShaft_InMotor_FX.BP_VolumetricConeLightShaft_InMotor_FX_C");
			}
			return BP_VolumetricConeLightShaft_InMotor_FX_C._ClassPtr;
		}

		// Token: 0x06028DED RID: 167405 RVA: 0x00A18FEC File Offset: 0x00A171EC
		public BP_VolumetricConeLightShaft_InMotor_FX_C() : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricConeLightShaft_InMotor_FX_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028DEE RID: 167406 RVA: 0x00A19014 File Offset: 0x00A17214
		[NullableContext(1)]
		public BP_VolumetricConeLightShaft_InMotor_FX_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricConeLightShaft_InMotor_FX_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028DEF RID: 167407 RVA: 0x00A19047 File Offset: 0x00A17247
		protected BP_VolumetricConeLightShaft_InMotor_FX_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040159C0 RID: 88512
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Diy/HeadLight/Common/VolumetricConeLight/BP_VolumetricConeLightShaft_InMotor_FX.BP_VolumetricConeLightShaft_InMotor_FX_C";

		// Token: 0x040159C1 RID: 88513
		private static IntPtr _ClassPtr;

		// Token: 0x040159C2 RID: 88514
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
