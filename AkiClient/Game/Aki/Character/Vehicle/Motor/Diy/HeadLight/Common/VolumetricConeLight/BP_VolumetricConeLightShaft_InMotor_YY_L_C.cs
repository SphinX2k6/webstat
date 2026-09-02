using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Diy.HeadLight.Common.VolumetricConeLight
{
	// Token: 0x02003FA2 RID: 16290
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Diy/HeadLight/Common/VolumetricConeLight/BP_VolumetricConeLightShaft_InMotor_YY_L.BP_VolumetricConeLightShaft_InMotor_YY_L_C")]
	[UnrealStructLayout(2752, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2752)]
	public class BP_VolumetricConeLightShaft_InMotor_YY_L_C : BP_VolumetricConeLightShaft_InMotor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028DF0 RID: 167408 RVA: 0x00A19050 File Offset: 0x00A17250
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VolumetricConeLightShaft_InMotor_YY_L_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Diy/HeadLight/Common/VolumetricConeLight/BP_VolumetricConeLightShaft_InMotor_YY_L.BP_VolumetricConeLightShaft_InMotor_YY_L_C");
			}
			return BP_VolumetricConeLightShaft_InMotor_YY_L_C._ClassPtr;
		}

		// Token: 0x06028DF1 RID: 167409 RVA: 0x00A19074 File Offset: 0x00A17274
		public BP_VolumetricConeLightShaft_InMotor_YY_L_C() : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricConeLightShaft_InMotor_YY_L_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028DF2 RID: 167410 RVA: 0x00A1909C File Offset: 0x00A1729C
		[NullableContext(1)]
		public BP_VolumetricConeLightShaft_InMotor_YY_L_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricConeLightShaft_InMotor_YY_L_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006496 RID: 25750
		// (get) Token: 0x06028DF3 RID: 167411 RVA: 0x00A190CF File Offset: 0x00A172CF
		// (set) Token: 0x06028DF4 RID: 167412 RVA: 0x00A190E3 File Offset: 0x00A172E3
		[Nullable(2)]
		public unsafe UChildActorComponent BP_VolumetricConeLightShaft_InMotor_YY_R
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_YY_L_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_YY_L_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x06028DF5 RID: 167413 RVA: 0x00A190F8 File Offset: 0x00A172F8
		protected BP_VolumetricConeLightShaft_InMotor_YY_L_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040159C3 RID: 88515
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Diy/HeadLight/Common/VolumetricConeLight/BP_VolumetricConeLightShaft_InMotor_YY_L.BP_VolumetricConeLightShaft_InMotor_YY_L_C";

		// Token: 0x040159C4 RID: 88516
		private static IntPtr _ClassPtr;

		// Token: 0x040159C5 RID: 88517
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040159C6 RID: 88518
		internal new static int __PropertyOffset_0;
	}
}
