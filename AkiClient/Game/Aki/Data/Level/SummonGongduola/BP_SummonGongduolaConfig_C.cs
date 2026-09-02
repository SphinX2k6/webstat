using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Level.SummonGongduola
{
	// Token: 0x02003E72 RID: 15986
	[UnrealObjectPath("/Game/Aki/Data/Level/SummonGongduola/BP_SummonGongduolaConfig.BP_SummonGongduolaConfig_C")]
	[UnrealStructLayout(112, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 109)]
	public class BP_SummonGongduolaConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602780E RID: 161806 RVA: 0x009F353F File Offset: 0x009F173F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SummonGongduolaConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Level/SummonGongduola/BP_SummonGongduolaConfig.BP_SummonGongduolaConfig_C");
			}
			return BP_SummonGongduolaConfig_C._ClassPtr;
		}

		// Token: 0x0602780F RID: 161807 RVA: 0x009F3564 File Offset: 0x009F1764
		public BP_SummonGongduolaConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_SummonGongduolaConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06027810 RID: 161808 RVA: 0x009F358C File Offset: 0x009F178C
		[NullableContext(1)]
		public BP_SummonGongduolaConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SummonGongduolaConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005D23 RID: 23843
		// (get) Token: 0x06027811 RID: 161809 RVA: 0x009F35BF File Offset: 0x009F17BF
		// (set) Token: 0x06027812 RID: 161810 RVA: 0x009F35CF File Offset: 0x009F17CF
		public unsafe float FadeInTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SummonGongduolaConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SummonGongduolaConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005D24 RID: 23844
		// (get) Token: 0x06027813 RID: 161811 RVA: 0x009F35E0 File Offset: 0x009F17E0
		// (set) Token: 0x06027814 RID: 161812 RVA: 0x009F35F0 File Offset: 0x009F17F0
		public unsafe float StayTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SummonGongduolaConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SummonGongduolaConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005D25 RID: 23845
		// (get) Token: 0x06027815 RID: 161813 RVA: 0x009F3601 File Offset: 0x009F1801
		// (set) Token: 0x06027816 RID: 161814 RVA: 0x009F3611 File Offset: 0x009F1811
		public unsafe float FadeOutTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SummonGongduolaConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SummonGongduolaConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005D26 RID: 23846
		// (get) Token: 0x06027817 RID: 161815 RVA: 0x009F3622 File Offset: 0x009F1822
		// (set) Token: 0x06027818 RID: 161816 RVA: 0x009F3632 File Offset: 0x009F1832
		public unsafe int Priority
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SummonGongduolaConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SummonGongduolaConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005D27 RID: 23847
		// (get) Token: 0x06027819 RID: 161817 RVA: 0x009F3643 File Offset: 0x009F1843
		// (set) Token: 0x0602781A RID: 161818 RVA: 0x009F3653 File Offset: 0x009F1853
		public unsafe float OffsetZ
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SummonGongduolaConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SummonGongduolaConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005D28 RID: 23848
		// (get) Token: 0x0602781B RID: 161819 RVA: 0x009F3664 File Offset: 0x009F1864
		// (set) Token: 0x0602781C RID: 161820 RVA: 0x009F3674 File Offset: 0x009F1874
		public unsafe bool BanInput
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SummonGongduolaConfig_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SummonGongduolaConfig_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005D29 RID: 23849
		// (get) Token: 0x0602781D RID: 161821 RVA: 0x009F3685 File Offset: 0x009F1885
		// (set) Token: 0x0602781E RID: 161822 RVA: 0x009F3695 File Offset: 0x009F1895
		public unsafe int ResummonDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SummonGongduolaConfig_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SummonGongduolaConfig_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005D2A RID: 23850
		// (get) Token: 0x0602781F RID: 161823 RVA: 0x009F36A6 File Offset: 0x009F18A6
		// (set) Token: 0x06027820 RID: 161824 RVA: 0x009F36B6 File Offset: 0x009F18B6
		public unsafe bool LockCamera
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SummonGongduolaConfig_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SummonGongduolaConfig_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x06027821 RID: 161825 RVA: 0x009F36C7 File Offset: 0x009F18C7
		protected BP_SummonGongduolaConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014B17 RID: 84759
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/Level/SummonGongduola/BP_SummonGongduolaConfig.BP_SummonGongduolaConfig_C";

		// Token: 0x04014B18 RID: 84760
		private static IntPtr _ClassPtr;

		// Token: 0x04014B19 RID: 84761
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014B1A RID: 84762
		internal static int __PropertyOffset_0;

		// Token: 0x04014B1B RID: 84763
		internal static int __PropertyOffset_1;

		// Token: 0x04014B1C RID: 84764
		internal static int __PropertyOffset_2;

		// Token: 0x04014B1D RID: 84765
		internal static int __PropertyOffset_3;

		// Token: 0x04014B1E RID: 84766
		internal static int __PropertyOffset_4;

		// Token: 0x04014B1F RID: 84767
		internal static int __PropertyOffset_5;

		// Token: 0x04014B20 RID: 84768
		internal static int __PropertyOffset_6;

		// Token: 0x04014B21 RID: 84769
		internal static int __PropertyOffset_7;
	}
}
