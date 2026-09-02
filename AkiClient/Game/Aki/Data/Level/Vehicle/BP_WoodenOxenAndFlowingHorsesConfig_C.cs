using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Level.Vehicle
{
	// Token: 0x02003E6A RID: 15978
	[UnrealObjectPath("/Game/Aki/Data/Level/Vehicle/BP_WoodenOxenAndFlowingHorsesConfig.BP_WoodenOxenAndFlowingHorsesConfig_C")]
	[UnrealStructLayout(768, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 764)]
	public class BP_WoodenOxenAndFlowingHorsesConfig_C : BP_VehicleConfig_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060277BD RID: 161725 RVA: 0x009F2DD0 File Offset: 0x009F0FD0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WoodenOxenAndFlowingHorsesConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Level/Vehicle/BP_WoodenOxenAndFlowingHorsesConfig.BP_WoodenOxenAndFlowingHorsesConfig_C");
			}
			return BP_WoodenOxenAndFlowingHorsesConfig_C._ClassPtr;
		}

		// Token: 0x060277BE RID: 161726 RVA: 0x009F2DF4 File Offset: 0x009F0FF4
		public BP_WoodenOxenAndFlowingHorsesConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_WoodenOxenAndFlowingHorsesConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060277BF RID: 161727 RVA: 0x009F2E1C File Offset: 0x009F101C
		[NullableContext(1)]
		public BP_WoodenOxenAndFlowingHorsesConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WoodenOxenAndFlowingHorsesConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005D10 RID: 23824
		// (get) Token: 0x060277C0 RID: 161728 RVA: 0x009F2E4F File Offset: 0x009F104F
		// (set) Token: 0x060277C1 RID: 161729 RVA: 0x009F2E5F File Offset: 0x009F105F
		public unsafe float ObstacleHalfLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WoodenOxenAndFlowingHorsesConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WoodenOxenAndFlowingHorsesConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005D11 RID: 23825
		// (get) Token: 0x060277C2 RID: 161730 RVA: 0x009F2E70 File Offset: 0x009F1070
		// (set) Token: 0x060277C3 RID: 161731 RVA: 0x009F2E80 File Offset: 0x009F1080
		public unsafe float ObstacleHalfWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WoodenOxenAndFlowingHorsesConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WoodenOxenAndFlowingHorsesConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005D12 RID: 23826
		// (get) Token: 0x060277C4 RID: 161732 RVA: 0x009F2E91 File Offset: 0x009F1091
		// (set) Token: 0x060277C5 RID: 161733 RVA: 0x009F2EA1 File Offset: 0x009F10A1
		public unsafe float WaypointHalfLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WoodenOxenAndFlowingHorsesConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WoodenOxenAndFlowingHorsesConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x060277C6 RID: 161734 RVA: 0x009F2EB2 File Offset: 0x009F10B2
		protected BP_WoodenOxenAndFlowingHorsesConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014AEB RID: 84715
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/Level/Vehicle/BP_WoodenOxenAndFlowingHorsesConfig.BP_WoodenOxenAndFlowingHorsesConfig_C";

		// Token: 0x04014AEC RID: 84716
		private static IntPtr _ClassPtr;

		// Token: 0x04014AED RID: 84717
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014AEE RID: 84718
		internal new static int __PropertyOffset_0;

		// Token: 0x04014AEF RID: 84719
		internal new static int __PropertyOffset_1;

		// Token: 0x04014AF0 RID: 84720
		internal new static int __PropertyOffset_2;
	}
}
