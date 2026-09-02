using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor
{
	// Token: 0x02003F98 RID: 16280
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/BP_Motor_BaseVehicle_Yangyang.BP_Motor_BaseVehicle_Yangyang_C")]
	[UnrealStructLayout(2272, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2264)]
	public class BP_Motor_BaseVehicle_Yangyang_C : BP_Motor_BaseVehicle_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028D1F RID: 167199 RVA: 0x00A179A8 File Offset: 0x00A15BA8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Motor_BaseVehicle_Yangyang_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/BP_Motor_BaseVehicle_Yangyang.BP_Motor_BaseVehicle_Yangyang_C");
			}
			return BP_Motor_BaseVehicle_Yangyang_C._ClassPtr;
		}

		// Token: 0x06028D20 RID: 167200 RVA: 0x00A179CC File Offset: 0x00A15BCC
		public BP_Motor_BaseVehicle_Yangyang_C() : this(BuiltinUtils.AllocNativeUObject(BP_Motor_BaseVehicle_Yangyang_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028D21 RID: 167201 RVA: 0x00A179F4 File Offset: 0x00A15BF4
		[NullableContext(1)]
		public BP_Motor_BaseVehicle_Yangyang_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Motor_BaseVehicle_Yangyang_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006449 RID: 25673
		// (get) Token: 0x06028D22 RID: 167202 RVA: 0x00A17A27 File Offset: 0x00A15C27
		// (set) Token: 0x06028D23 RID: 167203 RVA: 0x00A17A3B File Offset: 0x00A15C3B
		[Nullable(2)]
		public unsafe UNiagaraComponent NS_Fx_Motuo_Deng_Glow
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Yangyang_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Yangyang_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x06028D24 RID: 167204 RVA: 0x00A17A50 File Offset: 0x00A15C50
		protected BP_Motor_BaseVehicle_Yangyang_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401593D RID: 88381
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/BP_Motor_BaseVehicle_Yangyang.BP_Motor_BaseVehicle_Yangyang_C";

		// Token: 0x0401593E RID: 88382
		private static IntPtr _ClassPtr;

		// Token: 0x0401593F RID: 88383
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015940 RID: 88384
		internal new static int __PropertyOffset_0;
	}
}
