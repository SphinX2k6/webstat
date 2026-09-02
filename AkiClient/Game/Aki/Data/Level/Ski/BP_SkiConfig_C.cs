using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Level.Ski
{
	// Token: 0x02003E74 RID: 15988
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Level/Ski/BP_SkiConfig.BP_SkiConfig_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 160)]
	public class BP_SkiConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06027836 RID: 161846 RVA: 0x009F38C2 File Offset: 0x009F1AC2
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SkiConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Level/Ski/BP_SkiConfig.BP_SkiConfig_C");
			}
			return BP_SkiConfig_C._ClassPtr;
		}

		// Token: 0x06027837 RID: 161847 RVA: 0x009F38E8 File Offset: 0x009F1AE8
		public BP_SkiConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_SkiConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06027838 RID: 161848 RVA: 0x009F3910 File Offset: 0x009F1B10
		public BP_SkiConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SkiConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005D33 RID: 23859
		// (get) Token: 0x06027839 RID: 161849 RVA: 0x009F3943 File Offset: 0x009F1B43
		// (set) Token: 0x0602783A RID: 161850 RVA: 0x009F3953 File Offset: 0x009F1B53
		public unsafe float 初始速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkiConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkiConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005D34 RID: 23860
		// (get) Token: 0x0602783B RID: 161851 RVA: 0x009F3964 File Offset: 0x009F1B64
		// (set) Token: 0x0602783C RID: 161852 RVA: 0x009F3974 File Offset: 0x009F1B74
		public unsafe float 转向速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkiConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkiConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005D35 RID: 23861
		// (get) Token: 0x0602783D RID: 161853 RVA: 0x009F3985 File Offset: 0x009F1B85
		// (set) Token: 0x0602783E RID: 161854 RVA: 0x009F3995 File Offset: 0x009F1B95
		public unsafe float 基础加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkiConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkiConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005D36 RID: 23862
		// (get) Token: 0x0602783F RID: 161855 RVA: 0x009F39A6 File Offset: 0x009F1BA6
		// (set) Token: 0x06027840 RID: 161856 RVA: 0x009F39B6 File Offset: 0x009F1BB6
		public unsafe float 基础减速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkiConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkiConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005D37 RID: 23863
		// (get) Token: 0x06027841 RID: 161857 RVA: 0x009F39C7 File Offset: 0x009F1BC7
		// (set) Token: 0x06027842 RID: 161858 RVA: 0x009F39D7 File Offset: 0x009F1BD7
		public unsafe float 基础目标速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkiConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkiConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005D38 RID: 23864
		// (get) Token: 0x06027843 RID: 161859 RVA: 0x009F39E8 File Offset: 0x009F1BE8
		// (set) Token: 0x06027844 RID: 161860 RVA: 0x009F39F8 File Offset: 0x009F1BF8
		public unsafe float 斜坡额外加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkiConfig_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkiConfig_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005D39 RID: 23865
		// (get) Token: 0x06027845 RID: 161861 RVA: 0x009F3A09 File Offset: 0x009F1C09
		// (set) Token: 0x06027846 RID: 161862 RVA: 0x009F3A19 File Offset: 0x009F1C19
		public unsafe float 斜坡额外目标速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkiConfig_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkiConfig_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005D3A RID: 23866
		// (get) Token: 0x06027847 RID: 161863 RVA: 0x009F3A2A File Offset: 0x009F1C2A
		// (set) Token: 0x06027848 RID: 161864 RVA: 0x009F3A3A File Offset: 0x009F1C3A
		public unsafe float 忽视阶梯高度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkiConfig_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkiConfig_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005D3B RID: 23867
		// (get) Token: 0x06027849 RID: 161865 RVA: 0x009F3A4B File Offset: 0x009F1C4B
		// (set) Token: 0x0602784A RID: 161866 RVA: 0x009F3A5B File Offset: 0x009F1C5B
		public unsafe float 跳跃转向速度系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkiConfig_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkiConfig_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005D3C RID: 23868
		// (get) Token: 0x0602784B RID: 161867 RVA: 0x009F3A6C File Offset: 0x009F1C6C
		// (set) Token: 0x0602784C RID: 161868 RVA: 0x009F3A7C File Offset: 0x009F1C7C
		public unsafe float 跳跃滞空缩放系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkiConfig_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkiConfig_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005D3D RID: 23869
		// (get) Token: 0x0602784D RID: 161869 RVA: 0x009F3A8D File Offset: 0x009F1C8D
		// (set) Token: 0x0602784E RID: 161870 RVA: 0x009F3A9D File Offset: 0x009F1C9D
		public unsafe float 跳跃高度缩放系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkiConfig_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkiConfig_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005D3E RID: 23870
		// (get) Token: 0x0602784F RID: 161871 RVA: 0x009F3AAE File Offset: 0x009F1CAE
		// (set) Token: 0x06027850 RID: 161872 RVA: 0x009F3ABE File Offset: 0x009F1CBE
		public unsafe float 跳跃下落最大平面速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkiConfig_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkiConfig_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17005D3F RID: 23871
		// (get) Token: 0x06027851 RID: 161873 RVA: 0x009F3AD0 File Offset: 0x009F1CD0
		// (set) Token: 0x06027852 RID: 161874 RVA: 0x009F3B09 File Offset: 0x009F1D09
		public FGameplayTagContainer 期间Tag
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._期间Tag) == null)
				{
					result = (this._期间Tag = new FGameplayTagContainer(base.NativePtr + (IntPtr)BP_SkiConfig_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)BP_SkiConfig_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06027853 RID: 161875 RVA: 0x009F3B2A File Offset: 0x009F1D2A
		protected BP_SkiConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014B2F RID: 84783
		public new const string __ObjectPath = "/Game/Aki/Data/Level/Ski/BP_SkiConfig.BP_SkiConfig_C";

		// Token: 0x04014B30 RID: 84784
		private static IntPtr _ClassPtr;

		// Token: 0x04014B31 RID: 84785
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014B32 RID: 84786
		internal static int __PropertyOffset_0;

		// Token: 0x04014B33 RID: 84787
		internal static int __PropertyOffset_1;

		// Token: 0x04014B34 RID: 84788
		internal static int __PropertyOffset_2;

		// Token: 0x04014B35 RID: 84789
		internal static int __PropertyOffset_3;

		// Token: 0x04014B36 RID: 84790
		internal static int __PropertyOffset_4;

		// Token: 0x04014B37 RID: 84791
		internal static int __PropertyOffset_5;

		// Token: 0x04014B38 RID: 84792
		internal static int __PropertyOffset_6;

		// Token: 0x04014B39 RID: 84793
		internal static int __PropertyOffset_7;

		// Token: 0x04014B3A RID: 84794
		internal static int __PropertyOffset_8;

		// Token: 0x04014B3B RID: 84795
		internal static int __PropertyOffset_9;

		// Token: 0x04014B3C RID: 84796
		internal static int __PropertyOffset_10;

		// Token: 0x04014B3D RID: 84797
		internal static int __PropertyOffset_11;

		// Token: 0x04014B3E RID: 84798
		internal static int __PropertyOffset_12;

		// Token: 0x04014B3F RID: 84799
		[Nullable(2)]
		private FGameplayTagContainer _期间Tag;
	}
}
