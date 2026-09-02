using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Level.Vehicle.VehicleControlState
{
	// Token: 0x02003E6D RID: 15981
	[UnrealObjectPath("/Game/Aki/Data/Level/Vehicle/VehicleControlState/BP_VehicleCruiseBaseParams.BP_VehicleCruiseBaseParams_C")]
	[UnrealStructLayout(88, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 88)]
	public class BP_VehicleCruiseBaseParams_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060277DA RID: 161754 RVA: 0x009F3024 File Offset: 0x009F1224
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VehicleCruiseBaseParams_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Level/Vehicle/VehicleControlState/BP_VehicleCruiseBaseParams.BP_VehicleCruiseBaseParams_C");
			}
			return BP_VehicleCruiseBaseParams_C._ClassPtr;
		}

		// Token: 0x060277DB RID: 161755 RVA: 0x009F3048 File Offset: 0x009F1248
		public BP_VehicleCruiseBaseParams_C() : this(BuiltinUtils.AllocNativeUObject(BP_VehicleCruiseBaseParams_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060277DC RID: 161756 RVA: 0x009F3070 File Offset: 0x009F1270
		[NullableContext(1)]
		public BP_VehicleCruiseBaseParams_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VehicleCruiseBaseParams_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005D15 RID: 23829
		// (get) Token: 0x060277DD RID: 161757 RVA: 0x009F30A3 File Offset: 0x009F12A3
		// (set) Token: 0x060277DE RID: 161758 RVA: 0x009F30B3 File Offset: 0x009F12B3
		public unsafe float 前进最大移动速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleCruiseBaseParams_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleCruiseBaseParams_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005D16 RID: 23830
		// (get) Token: 0x060277DF RID: 161759 RVA: 0x009F30C4 File Offset: 0x009F12C4
		// (set) Token: 0x060277E0 RID: 161760 RVA: 0x009F30D4 File Offset: 0x009F12D4
		public unsafe float 常态前进加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleCruiseBaseParams_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleCruiseBaseParams_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x060277E1 RID: 161761 RVA: 0x009F30E5 File Offset: 0x009F12E5
		protected BP_VehicleCruiseBaseParams_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014AF9 RID: 84729
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/Level/Vehicle/VehicleControlState/BP_VehicleCruiseBaseParams.BP_VehicleCruiseBaseParams_C";

		// Token: 0x04014AFA RID: 84730
		private static IntPtr _ClassPtr;

		// Token: 0x04014AFB RID: 84731
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014AFC RID: 84732
		internal static int __PropertyOffset_0;

		// Token: 0x04014AFD RID: 84733
		internal static int __PropertyOffset_1;
	}
}
