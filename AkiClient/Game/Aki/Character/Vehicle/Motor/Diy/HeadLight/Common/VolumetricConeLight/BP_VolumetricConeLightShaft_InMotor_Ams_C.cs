using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Diy.HeadLight.Common.VolumetricConeLight
{
	// Token: 0x02003F9F RID: 16287
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Diy/HeadLight/Common/VolumetricConeLight/BP_VolumetricConeLightShaft_InMotor_Ams.BP_VolumetricConeLightShaft_InMotor_Ams_C")]
	[UnrealStructLayout(2744, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2744)]
	public class BP_VolumetricConeLightShaft_InMotor_Ams_C : BP_VolumetricConeLightShaft_InMotor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028D47 RID: 167239 RVA: 0x00A17FF0 File Offset: 0x00A161F0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VolumetricConeLightShaft_InMotor_Ams_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Diy/HeadLight/Common/VolumetricConeLight/BP_VolumetricConeLightShaft_InMotor_Ams.BP_VolumetricConeLightShaft_InMotor_Ams_C");
			}
			return BP_VolumetricConeLightShaft_InMotor_Ams_C._ClassPtr;
		}

		// Token: 0x06028D48 RID: 167240 RVA: 0x00A18014 File Offset: 0x00A16214
		public BP_VolumetricConeLightShaft_InMotor_Ams_C() : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricConeLightShaft_InMotor_Ams_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028D49 RID: 167241 RVA: 0x00A1803C File Offset: 0x00A1623C
		[NullableContext(1)]
		public BP_VolumetricConeLightShaft_InMotor_Ams_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricConeLightShaft_InMotor_Ams_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028D4A RID: 167242 RVA: 0x00A1806F File Offset: 0x00A1626F
		protected BP_VolumetricConeLightShaft_InMotor_Ams_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401595D RID: 88413
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Diy/HeadLight/Common/VolumetricConeLight/BP_VolumetricConeLightShaft_InMotor_Ams.BP_VolumetricConeLightShaft_InMotor_Ams_C";

		// Token: 0x0401595E RID: 88414
		private static IntPtr _ClassPtr;

		// Token: 0x0401595F RID: 88415
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
