using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor
{
	// Token: 0x02003F94 RID: 16276
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/BP_Motor_BaseVehicle_Feixue.BP_Motor_BaseVehicle_Feixue_C")]
	[UnrealStructLayout(2272, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2272)]
	public class BP_Motor_BaseVehicle_Feixue_C : BP_Motor_BaseVehicle_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028CBC RID: 167100 RVA: 0x00A16D6C File Offset: 0x00A14F6C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Motor_BaseVehicle_Feixue_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/BP_Motor_BaseVehicle_Feixue.BP_Motor_BaseVehicle_Feixue_C");
			}
			return BP_Motor_BaseVehicle_Feixue_C._ClassPtr;
		}

		// Token: 0x06028CBD RID: 167101 RVA: 0x00A16D90 File Offset: 0x00A14F90
		public BP_Motor_BaseVehicle_Feixue_C() : this(BuiltinUtils.AllocNativeUObject(BP_Motor_BaseVehicle_Feixue_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028CBE RID: 167102 RVA: 0x00A16DB8 File Offset: 0x00A14FB8
		[NullableContext(1)]
		public BP_Motor_BaseVehicle_Feixue_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Motor_BaseVehicle_Feixue_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006429 RID: 25641
		// (get) Token: 0x06028CBF RID: 167103 RVA: 0x00A16DEB File Offset: 0x00A14FEB
		// (set) Token: 0x06028CC0 RID: 167104 RVA: 0x00A16DFF File Offset: 0x00A14FFF
		public unsafe UNiagaraComponent Niagara2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Feixue_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Feixue_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x1700642A RID: 25642
		// (get) Token: 0x06028CC1 RID: 167105 RVA: 0x00A16E14 File Offset: 0x00A15014
		// (set) Token: 0x06028CC2 RID: 167106 RVA: 0x00A16E28 File Offset: 0x00A15028
		public unsafe UNiagaraComponent Niagara1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Feixue_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Feixue_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06028CC3 RID: 167107 RVA: 0x00A16E3D File Offset: 0x00A1503D
		protected BP_Motor_BaseVehicle_Feixue_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015900 RID: 88320
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/BP_Motor_BaseVehicle_Feixue.BP_Motor_BaseVehicle_Feixue_C";

		// Token: 0x04015901 RID: 88321
		private static IntPtr _ClassPtr;

		// Token: 0x04015902 RID: 88322
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015903 RID: 88323
		internal new static int __PropertyOffset_0;

		// Token: 0x04015904 RID: 88324
		internal new static int __PropertyOffset_1;
	}
}
