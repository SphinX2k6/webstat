using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.UI;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Level.Vehicle
{
	// Token: 0x02003E69 RID: 15977
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Level/Vehicle/BP_VehicleConfig.BP_VehicleConfig_C")]
	[UnrealStructLayout(752, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 752)]
	public class BP_VehicleConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06027791 RID: 161681 RVA: 0x009F286E File Offset: 0x009F0A6E
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VehicleConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Level/Vehicle/BP_VehicleConfig.BP_VehicleConfig_C");
			}
			return BP_VehicleConfig_C._ClassPtr;
		}

		// Token: 0x06027792 RID: 161682 RVA: 0x009F2894 File Offset: 0x009F0A94
		public BP_VehicleConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_VehicleConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06027793 RID: 161683 RVA: 0x009F28BC File Offset: 0x009F0ABC
		public BP_VehicleConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VehicleConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005CFC RID: 23804
		// (get) Token: 0x06027794 RID: 161684 RVA: 0x009F28F0 File Offset: 0x009F0AF0
		// (set) Token: 0x06027795 RID: 161685 RVA: 0x009F2929 File Offset: 0x009F0B29
		public FGameplayTagContainer 载具出生Tag
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._载具出生Tag) == null)
				{
					result = (this._载具出生Tag = new FGameplayTagContainer(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005CFD RID: 23805
		// (get) Token: 0x06027796 RID: 161686 RVA: 0x009F294C File Offset: 0x009F0B4C
		// (set) Token: 0x06027797 RID: 161687 RVA: 0x009F2985 File Offset: 0x009F0B85
		public FGameplayTagContainer 载具乘坐期间Tag
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._载具乘坐期间Tag) == null)
				{
					result = (this._载具乘坐期间Tag = new FGameplayTagContainer(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005CFE RID: 23806
		// (get) Token: 0x06027798 RID: 161688 RVA: 0x009F29A8 File Offset: 0x009F0BA8
		// (set) Token: 0x06027799 RID: 161689 RVA: 0x009F29E1 File Offset: 0x009F0BE1
		public FGameplayTagContainer 角色乘坐期间Tag
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._角色乘坐期间Tag) == null)
				{
					result = (this._角色乘坐期间Tag = new FGameplayTagContainer(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005CFF RID: 23807
		// (get) Token: 0x0602779A RID: 161690 RVA: 0x009F2A02 File Offset: 0x009F0C02
		// (set) Token: 0x0602779B RID: 161691 RVA: 0x009F2A12 File Offset: 0x009F0C12
		public unsafe float 弹射时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005D00 RID: 23808
		// (get) Token: 0x0602779C RID: 161692 RVA: 0x009F2A23 File Offset: 0x009F0C23
		// (set) Token: 0x0602779D RID: 161693 RVA: 0x009F2A33 File Offset: 0x009F0C33
		public unsafe float 弹射高度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005D01 RID: 23809
		// (get) Token: 0x0602779E RID: 161694 RVA: 0x009F2A44 File Offset: 0x009F0C44
		// (set) Token: 0x0602779F RID: 161695 RVA: 0x009F2A54 File Offset: 0x009F0C54
		public unsafe float 打开滑翔伞延迟时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005D02 RID: 23810
		// (get) Token: 0x060277A0 RID: 161696 RVA: 0x009F2A65 File Offset: 0x009F0C65
		// (set) Token: 0x060277A1 RID: 161697 RVA: 0x009F2A7A File Offset: 0x009F0C7A
		public TSoftObjectPtr<UCurveFloat> 弹射时间路径曲线
		{
			get
			{
				return new TSoftObjectPtr<UCurveFloat>(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_6, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_6, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005D03 RID: 23811
		// (get) Token: 0x060277A2 RID: 161698 RVA: 0x009F2A9F File Offset: 0x009F0C9F
		// (set) Token: 0x060277A3 RID: 161699 RVA: 0x009F2AB4 File Offset: 0x009F0CB4
		public TSoftObjectPtr<UEffectModelGroup> PreEnterEffect
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelGroup>(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_7, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_7, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005D04 RID: 23812
		// (get) Token: 0x060277A4 RID: 161700 RVA: 0x009F2AD9 File Offset: 0x009F0CD9
		// (set) Token: 0x060277A5 RID: 161701 RVA: 0x009F2AEE File Offset: 0x009F0CEE
		public TSoftObjectPtr<UEffectModelGroup> PostEnterEffect
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelGroup>(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_8, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_8, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005D05 RID: 23813
		// (get) Token: 0x060277A6 RID: 161702 RVA: 0x009F2B13 File Offset: 0x009F0D13
		// (set) Token: 0x060277A7 RID: 161703 RVA: 0x009F2B28 File Offset: 0x009F0D28
		public TSoftObjectPtr<PD_CharacterControllerData_C> PreEnterMatEffect
		{
			get
			{
				return new TSoftObjectPtr<PD_CharacterControllerData_C>(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_9, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_9, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005D06 RID: 23814
		// (get) Token: 0x060277A8 RID: 161704 RVA: 0x009F2B4D File Offset: 0x009F0D4D
		// (set) Token: 0x060277A9 RID: 161705 RVA: 0x009F2B62 File Offset: 0x009F0D62
		public TSoftObjectPtr<PD_CharacterControllerDataGroup_C> PostEnterMatEffect
		{
			get
			{
				return new TSoftObjectPtr<PD_CharacterControllerDataGroup_C>(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_10, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_10, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005D07 RID: 23815
		// (get) Token: 0x060277AA RID: 161706 RVA: 0x009F2B88 File Offset: 0x009F0D88
		// (set) Token: 0x060277AB RID: 161707 RVA: 0x009F2BC1 File Offset: 0x009F0DC1
		public TMap<FGameplayTag, SGameplayTagArray> 驾驶员同步Tag
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, SGameplayTagArray> result;
				if ((result = this._驾驶员同步Tag) == null)
				{
					result = (this._驾驶员同步Tag = new TMap<FGameplayTag, SGameplayTagArray>(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				this.驾驶员同步Tag.CopyAssign(value);
			}
		}

		// Token: 0x17005D08 RID: 23816
		// (get) Token: 0x060277AC RID: 161708 RVA: 0x009F2BD0 File Offset: 0x009F0DD0
		// (set) Token: 0x060277AD RID: 161709 RVA: 0x009F2C09 File Offset: 0x009F0E09
		public TMap<FGameplayTag, SInt64Array> 驾驶员同步Buff
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, SInt64Array> result;
				if ((result = this._驾驶员同步Buff) == null)
				{
					result = (this._驾驶员同步Buff = new TMap<FGameplayTag, SInt64Array>(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				this.驾驶员同步Buff.CopyAssign(value);
			}
		}

		// Token: 0x17005D09 RID: 23817
		// (get) Token: 0x060277AE RID: 161710 RVA: 0x009F2C17 File Offset: 0x009F0E17
		// (set) Token: 0x060277AF RID: 161711 RVA: 0x009F2C2B File Offset: 0x009F0E2B
		[Nullable(2)]
		public unsafe UCurveFloat 前后输入映射曲线
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleConfig_C.__PropertyOffset_13);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleConfig_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17005D0A RID: 23818
		// (get) Token: 0x060277B0 RID: 161712 RVA: 0x009F2C40 File Offset: 0x009F0E40
		// (set) Token: 0x060277B1 RID: 161713 RVA: 0x009F2C79 File Offset: 0x009F0E79
		public TMap<FGameplayTag, SGameplayTagArray> 载具同步驾驶员Tag
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, SGameplayTagArray> result;
				if ((result = this._载具同步驾驶员Tag) == null)
				{
					result = (this._载具同步驾驶员Tag = new TMap<FGameplayTag, SGameplayTagArray>(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				this.载具同步驾驶员Tag.CopyAssign(value);
			}
		}

		// Token: 0x17005D0B RID: 23819
		// (get) Token: 0x060277B2 RID: 161714 RVA: 0x009F2C88 File Offset: 0x009F0E88
		// (set) Token: 0x060277B3 RID: 161715 RVA: 0x009F2CC1 File Offset: 0x009F0EC1
		public TArray<SFloatThresholdAndCameraShake> 撞击震屏
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SFloatThresholdAndCameraShake> result;
				if ((result = this._撞击震屏) == null)
				{
					result = (this._撞击震屏 = new TArray<SFloatThresholdAndCameraShake>(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				this.撞击震屏.CopyAssign(value);
			}
		}

		// Token: 0x17005D0C RID: 23820
		// (get) Token: 0x060277B4 RID: 161716 RVA: 0x009F2CD0 File Offset: 0x009F0ED0
		// (set) Token: 0x060277B5 RID: 161717 RVA: 0x009F2D09 File Offset: 0x009F0F09
		public TArray<SFloatThresholdAndCameraShake> 撞击震屏Z
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SFloatThresholdAndCameraShake> result;
				if ((result = this._撞击震屏Z) == null)
				{
					result = (this._撞击震屏Z = new TArray<SFloatThresholdAndCameraShake>(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				this.撞击震屏Z.CopyAssign(value);
			}
		}

		// Token: 0x17005D0D RID: 23821
		// (get) Token: 0x060277B6 RID: 161718 RVA: 0x009F2D17 File Offset: 0x009F0F17
		// (set) Token: 0x060277B7 RID: 161719 RVA: 0x009F2D27 File Offset: 0x009F0F27
		public unsafe float 震屏CD
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17005D0E RID: 23822
		// (get) Token: 0x060277B8 RID: 161720 RVA: 0x009F2D38 File Offset: 0x009F0F38
		// (set) Token: 0x060277B9 RID: 161721 RVA: 0x009F2D71 File Offset: 0x009F0F71
		public TArray<SFloatThresholdAndCameraShake> 撞击震屏_第一人称
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SFloatThresholdAndCameraShake> result;
				if ((result = this._撞击震屏_第一人称) == null)
				{
					result = (this._撞击震屏_第一人称 = new TArray<SFloatThresholdAndCameraShake>(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				this.撞击震屏_第一人称.CopyAssign(value);
			}
		}

		// Token: 0x17005D0F RID: 23823
		// (get) Token: 0x060277BA RID: 161722 RVA: 0x009F2D80 File Offset: 0x009F0F80
		// (set) Token: 0x060277BB RID: 161723 RVA: 0x009F2DB9 File Offset: 0x009F0FB9
		public TArray<SFloatThresholdAndCameraShake> 撞击震屏Z_第一人称
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SFloatThresholdAndCameraShake> result;
				if ((result = this._撞击震屏Z_第一人称) == null)
				{
					result = (this._撞击震屏Z_第一人称 = new TArray<SFloatThresholdAndCameraShake>(base.NativePtr + (IntPtr)BP_VehicleConfig_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				this.撞击震屏Z_第一人称.CopyAssign(value);
			}
		}

		// Token: 0x060277BC RID: 161724 RVA: 0x009F2DC7 File Offset: 0x009F0FC7
		protected BP_VehicleConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014ACA RID: 84682
		public new const string __ObjectPath = "/Game/Aki/Data/Level/Vehicle/BP_VehicleConfig.BP_VehicleConfig_C";

		// Token: 0x04014ACB RID: 84683
		private static IntPtr _ClassPtr;

		// Token: 0x04014ACC RID: 84684
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014ACD RID: 84685
		internal static int __PropertyOffset_0;

		// Token: 0x04014ACE RID: 84686
		[Nullable(2)]
		private FGameplayTagContainer _载具出生Tag;

		// Token: 0x04014ACF RID: 84687
		internal static int __PropertyOffset_1;

		// Token: 0x04014AD0 RID: 84688
		[Nullable(2)]
		private FGameplayTagContainer _载具乘坐期间Tag;

		// Token: 0x04014AD1 RID: 84689
		internal static int __PropertyOffset_2;

		// Token: 0x04014AD2 RID: 84690
		[Nullable(2)]
		private FGameplayTagContainer _角色乘坐期间Tag;

		// Token: 0x04014AD3 RID: 84691
		internal static int __PropertyOffset_3;

		// Token: 0x04014AD4 RID: 84692
		internal static int __PropertyOffset_4;

		// Token: 0x04014AD5 RID: 84693
		internal static int __PropertyOffset_5;

		// Token: 0x04014AD6 RID: 84694
		internal static int __PropertyOffset_6;

		// Token: 0x04014AD7 RID: 84695
		internal static int __PropertyOffset_7;

		// Token: 0x04014AD8 RID: 84696
		internal static int __PropertyOffset_8;

		// Token: 0x04014AD9 RID: 84697
		internal static int __PropertyOffset_9;

		// Token: 0x04014ADA RID: 84698
		internal static int __PropertyOffset_10;

		// Token: 0x04014ADB RID: 84699
		internal static int __PropertyOffset_11;

		// Token: 0x04014ADC RID: 84700
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FGameplayTag, SGameplayTagArray> _驾驶员同步Tag;

		// Token: 0x04014ADD RID: 84701
		internal static int __PropertyOffset_12;

		// Token: 0x04014ADE RID: 84702
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FGameplayTag, SInt64Array> _驾驶员同步Buff;

		// Token: 0x04014ADF RID: 84703
		internal static int __PropertyOffset_13;

		// Token: 0x04014AE0 RID: 84704
		internal static int __PropertyOffset_14;

		// Token: 0x04014AE1 RID: 84705
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FGameplayTag, SGameplayTagArray> _载具同步驾驶员Tag;

		// Token: 0x04014AE2 RID: 84706
		internal static int __PropertyOffset_15;

		// Token: 0x04014AE3 RID: 84707
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SFloatThresholdAndCameraShake> _撞击震屏;

		// Token: 0x04014AE4 RID: 84708
		internal static int __PropertyOffset_16;

		// Token: 0x04014AE5 RID: 84709
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SFloatThresholdAndCameraShake> _撞击震屏Z;

		// Token: 0x04014AE6 RID: 84710
		internal static int __PropertyOffset_17;

		// Token: 0x04014AE7 RID: 84711
		internal static int __PropertyOffset_18;

		// Token: 0x04014AE8 RID: 84712
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SFloatThresholdAndCameraShake> _撞击震屏_第一人称;

		// Token: 0x04014AE9 RID: 84713
		internal static int __PropertyOffset_19;

		// Token: 0x04014AEA RID: 84714
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SFloatThresholdAndCameraShake> _撞击震屏Z_第一人称;
	}
}
