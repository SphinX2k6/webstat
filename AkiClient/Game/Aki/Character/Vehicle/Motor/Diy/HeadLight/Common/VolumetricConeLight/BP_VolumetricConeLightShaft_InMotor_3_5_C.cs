using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Diy.HeadLight.Common.VolumetricConeLight
{
	// Token: 0x02003F9E RID: 16286
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Diy/HeadLight/Common/VolumetricConeLight/BP_VolumetricConeLightShaft_InMotor_3_5.BP_VolumetricConeLightShaft_InMotor_3_5_C")]
	[UnrealStructLayout(2744, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2744)]
	public class BP_VolumetricConeLightShaft_InMotor_3_5_C : BP_VolumetricConeLightShaft_InMotor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028D43 RID: 167235 RVA: 0x00A17F68 File Offset: 0x00A16168
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VolumetricConeLightShaft_InMotor_3_5_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Diy/HeadLight/Common/VolumetricConeLight/BP_VolumetricConeLightShaft_InMotor_3_5.BP_VolumetricConeLightShaft_InMotor_3_5_C");
			}
			return BP_VolumetricConeLightShaft_InMotor_3_5_C._ClassPtr;
		}

		// Token: 0x06028D44 RID: 167236 RVA: 0x00A17F8C File Offset: 0x00A1618C
		public BP_VolumetricConeLightShaft_InMotor_3_5_C() : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricConeLightShaft_InMotor_3_5_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028D45 RID: 167237 RVA: 0x00A17FB4 File Offset: 0x00A161B4
		[NullableContext(1)]
		public BP_VolumetricConeLightShaft_InMotor_3_5_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricConeLightShaft_InMotor_3_5_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028D46 RID: 167238 RVA: 0x00A17FE7 File Offset: 0x00A161E7
		protected BP_VolumetricConeLightShaft_InMotor_3_5_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401595A RID: 88410
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Diy/HeadLight/Common/VolumetricConeLight/BP_VolumetricConeLightShaft_InMotor_3_5.BP_VolumetricConeLightShaft_InMotor_3_5_C";

		// Token: 0x0401595B RID: 88411
		private static IntPtr _ClassPtr;

		// Token: 0x0401595C RID: 88412
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
