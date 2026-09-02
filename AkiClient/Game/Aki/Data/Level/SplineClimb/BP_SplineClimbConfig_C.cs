using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Level.SplineClimb
{
	// Token: 0x02003E73 RID: 15987
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Level/SplineClimb/BP_SplineClimbConfig.BP_SplineClimbConfig_C")]
	[UnrealStructLayout(152, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 152)]
	public class BP_SplineClimbConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06027822 RID: 161826 RVA: 0x009F36D0 File Offset: 0x009F18D0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SplineClimbConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Level/SplineClimb/BP_SplineClimbConfig.BP_SplineClimbConfig_C");
			}
			return BP_SplineClimbConfig_C._ClassPtr;
		}

		// Token: 0x06027823 RID: 161827 RVA: 0x009F36F4 File Offset: 0x009F18F4
		public BP_SplineClimbConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_SplineClimbConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06027824 RID: 161828 RVA: 0x009F371C File Offset: 0x009F191C
		public BP_SplineClimbConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SplineClimbConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005D2B RID: 23851
		// (get) Token: 0x06027825 RID: 161829 RVA: 0x009F3750 File Offset: 0x009F1950
		// (set) Token: 0x06027826 RID: 161830 RVA: 0x009F3789 File Offset: 0x009F1989
		public FGameplayTagContainer 期间Tag
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._期间Tag) == null)
				{
					result = (this._期间Tag = new FGameplayTagContainer(base.NativePtr + (IntPtr)BP_SplineClimbConfig_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)BP_SplineClimbConfig_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D2C RID: 23852
		// (get) Token: 0x06027827 RID: 161831 RVA: 0x009F37AC File Offset: 0x009F19AC
		// (set) Token: 0x06027828 RID: 161832 RVA: 0x009F37E5 File Offset: 0x009F19E5
		public TArray<int> 打断技能
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._打断技能) == null)
				{
					result = (this._打断技能 = new TArray<int>(base.NativePtr + (IntPtr)BP_SplineClimbConfig_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.打断技能.CopyAssign(value);
			}
		}

		// Token: 0x17005D2D RID: 23853
		// (get) Token: 0x06027829 RID: 161833 RVA: 0x009F37F3 File Offset: 0x009F19F3
		// (set) Token: 0x0602782A RID: 161834 RVA: 0x009F3803 File Offset: 0x009F1A03
		public unsafe bool DebugDraw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineClimbConfig_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineClimbConfig_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005D2E RID: 23854
		// (get) Token: 0x0602782B RID: 161835 RVA: 0x009F3814 File Offset: 0x009F1A14
		// (set) Token: 0x0602782C RID: 161836 RVA: 0x009F3824 File Offset: 0x009F1A24
		public unsafe float 采样长度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineClimbConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineClimbConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005D2F RID: 23855
		// (get) Token: 0x0602782D RID: 161837 RVA: 0x009F3835 File Offset: 0x009F1A35
		// (set) Token: 0x0602782E RID: 161838 RVA: 0x009F3845 File Offset: 0x009F1A45
		public unsafe float 采样间隔
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineClimbConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineClimbConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005D30 RID: 23856
		// (get) Token: 0x0602782F RID: 161839 RVA: 0x009F3856 File Offset: 0x009F1A56
		// (set) Token: 0x06027830 RID: 161840 RVA: 0x009F3866 File Offset: 0x009F1A66
		public unsafe float 检测距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineClimbConfig_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineClimbConfig_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005D31 RID: 23857
		// (get) Token: 0x06027831 RID: 161841 RVA: 0x009F3877 File Offset: 0x009F1A77
		// (set) Token: 0x06027832 RID: 161842 RVA: 0x009F3887 File Offset: 0x009F1A87
		public unsafe float 检测起始偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineClimbConfig_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineClimbConfig_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005D32 RID: 23858
		// (get) Token: 0x06027833 RID: 161843 RVA: 0x009F3898 File Offset: 0x009F1A98
		// (set) Token: 0x06027834 RID: 161844 RVA: 0x009F38A8 File Offset: 0x009F1AA8
		public unsafe float 离墙额外距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineClimbConfig_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineClimbConfig_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x06027835 RID: 161845 RVA: 0x009F38B9 File Offset: 0x009F1AB9
		protected BP_SplineClimbConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014B22 RID: 84770
		public new const string __ObjectPath = "/Game/Aki/Data/Level/SplineClimb/BP_SplineClimbConfig.BP_SplineClimbConfig_C";

		// Token: 0x04014B23 RID: 84771
		private static IntPtr _ClassPtr;

		// Token: 0x04014B24 RID: 84772
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014B25 RID: 84773
		internal static int __PropertyOffset_0;

		// Token: 0x04014B26 RID: 84774
		[Nullable(2)]
		private FGameplayTagContainer _期间Tag;

		// Token: 0x04014B27 RID: 84775
		internal static int __PropertyOffset_1;

		// Token: 0x04014B28 RID: 84776
		[Nullable(2)]
		private TArray<int> _打断技能;

		// Token: 0x04014B29 RID: 84777
		internal static int __PropertyOffset_2;

		// Token: 0x04014B2A RID: 84778
		internal static int __PropertyOffset_3;

		// Token: 0x04014B2B RID: 84779
		internal static int __PropertyOffset_4;

		// Token: 0x04014B2C RID: 84780
		internal static int __PropertyOffset_5;

		// Token: 0x04014B2D RID: 84781
		internal static int __PropertyOffset_6;

		// Token: 0x04014B2E RID: 84782
		internal static int __PropertyOffset_7;
	}
}
