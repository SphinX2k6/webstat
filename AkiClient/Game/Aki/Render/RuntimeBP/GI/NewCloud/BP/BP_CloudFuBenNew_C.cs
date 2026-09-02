using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.BP
{
	// Token: 0x02003CBE RID: 15550
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_CloudFuBenNew.BP_CloudFuBenNew_C")]
	[UnrealStructLayout(1648, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1642)]
	public class BP_CloudFuBenNew_C : AKuroCloudsActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024C94 RID: 150676 RVA: 0x009A8158 File Offset: 0x009A6358
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CloudFuBenNew_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_CloudFuBenNew.BP_CloudFuBenNew_C");
			}
			return BP_CloudFuBenNew_C._ClassPtr;
		}

		// Token: 0x06024C95 RID: 150677 RVA: 0x009A817C File Offset: 0x009A637C
		public BP_CloudFuBenNew_C() : this(BuiltinUtils.AllocNativeUObject(BP_CloudFuBenNew_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024C96 RID: 150678 RVA: 0x009A81A4 File Offset: 0x009A63A4
		[NullableContext(1)]
		public BP_CloudFuBenNew_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CloudFuBenNew_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004DE4 RID: 19940
		// (get) Token: 0x06024C97 RID: 150679 RVA: 0x009A81D8 File Offset: 0x009A63D8
		// (set) Token: 0x06024C98 RID: 150680 RVA: 0x009A8211 File Offset: 0x009A6411
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004DE5 RID: 19941
		// (get) Token: 0x06024C99 RID: 150681 RVA: 0x009A8232 File Offset: 0x009A6432
		// (set) Token: 0x06024C9A RID: 150682 RVA: 0x009A8246 File Offset: 0x009A6446
		public unsafe UChildActorComponent Cloud2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBenNew_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBenNew_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004DE6 RID: 19942
		// (get) Token: 0x06024C9B RID: 150683 RVA: 0x009A825B File Offset: 0x009A645B
		// (set) Token: 0x06024C9C RID: 150684 RVA: 0x009A826F File Offset: 0x009A646F
		public unsafe UChildActorComponent Cloud1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBenNew_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBenNew_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004DE7 RID: 19943
		// (get) Token: 0x06024C9D RID: 150685 RVA: 0x009A8284 File Offset: 0x009A6484
		// (set) Token: 0x06024C9E RID: 150686 RVA: 0x009A8298 File Offset: 0x009A6498
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBenNew_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBenNew_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004DE8 RID: 19944
		// (get) Token: 0x06024C9F RID: 150687 RVA: 0x009A82AD File Offset: 0x009A64AD
		// (set) Token: 0x06024CA0 RID: 150688 RVA: 0x009A82BD File Offset: 0x009A64BD
		public unsafe bool EnableSequence
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004DE9 RID: 19945
		// (get) Token: 0x06024CA1 RID: 150689 RVA: 0x009A82CE File Offset: 0x009A64CE
		// (set) Token: 0x06024CA2 RID: 150690 RVA: 0x009A82DE File Offset: 0x009A64DE
		public unsafe bool CoverOffsetParameters
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004DEA RID: 19946
		// (get) Token: 0x06024CA3 RID: 150691 RVA: 0x009A82EF File Offset: 0x009A64EF
		// (set) Token: 0x06024CA4 RID: 150692 RVA: 0x009A82FF File Offset: 0x009A64FF
		public unsafe float Cloud_Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004DEB RID: 19947
		// (get) Token: 0x06024CA5 RID: 150693 RVA: 0x009A8310 File Offset: 0x009A6510
		// (set) Token: 0x06024CA6 RID: 150694 RVA: 0x009A8320 File Offset: 0x009A6520
		public unsafe float Cloud_Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17004DEC RID: 19948
		// (get) Token: 0x06024CA7 RID: 150695 RVA: 0x009A8331 File Offset: 0x009A6531
		// (set) Token: 0x06024CA8 RID: 150696 RVA: 0x009A8345 File Offset: 0x009A6545
		public unsafe PD_CloudPreset_C CloudData
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_CloudPreset_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBenNew_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBenNew_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17004DED RID: 19949
		// (get) Token: 0x06024CA9 RID: 150697 RVA: 0x009A835A File Offset: 0x009A655A
		// (set) Token: 0x06024CAA RID: 150698 RVA: 0x009A836A File Offset: 0x009A656A
		public unsafe bool Is_Sky_Ocean
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004DEE RID: 19950
		// (get) Token: 0x06024CAB RID: 150699 RVA: 0x009A837B File Offset: 0x009A657B
		// (set) Token: 0x06024CAC RID: 150700 RVA: 0x009A8390 File Offset: 0x009A6590
		[Nullable(1)]
		public TSoftObjectPtr<PD_CloudPrefab_C> CloudAsset
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_10, this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_10, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004DEF RID: 19951
		// (get) Token: 0x06024CAD RID: 150701 RVA: 0x009A83B5 File Offset: 0x009A65B5
		// (set) Token: 0x06024CAE RID: 150702 RVA: 0x009A83C9 File Offset: 0x009A65C9
		public unsafe PD_CloudPrefab_C As_PD_Cloud_Prefab
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_CloudPrefab_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBenNew_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBenNew_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17004DF0 RID: 19952
		// (get) Token: 0x06024CAF RID: 150703 RVA: 0x009A83DE File Offset: 0x009A65DE
		// (set) Token: 0x06024CB0 RID: 150704 RVA: 0x009A83F2 File Offset: 0x009A65F2
		public unsafe UAkAudioEvent SkyOceanAudio
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBenNew_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBenNew_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17004DF1 RID: 19953
		// (get) Token: 0x06024CB1 RID: 150705 RVA: 0x009A8408 File Offset: 0x009A6608
		// (set) Token: 0x06024CB2 RID: 150706 RVA: 0x009A8441 File Offset: 0x009A6641
		[Nullable(1)]
		public TArray<int> SortNumber
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._SortNumber) == null)
				{
					result = (this._SortNumber = new TArray<int>(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_13, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SortNumber.CopyAssign(value);
			}
		}

		// Token: 0x17004DF2 RID: 19954
		// (get) Token: 0x06024CB3 RID: 150707 RVA: 0x009A844F File Offset: 0x009A664F
		// (set) Token: 0x06024CB4 RID: 150708 RVA: 0x009A845F File Offset: 0x009A665F
		public unsafe bool Counting
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004DF3 RID: 19955
		// (get) Token: 0x06024CB5 RID: 150709 RVA: 0x009A8470 File Offset: 0x009A6670
		// (set) Token: 0x06024CB6 RID: 150710 RVA: 0x009A8480 File Offset: 0x009A6680
		public unsafe KuroFeatureLevel FeatureLevel
		{
			get
			{
				return (KuroFeatureLevel)(*(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_15));
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_15) = (byte)value;
			}
		}

		// Token: 0x17004DF4 RID: 19956
		// (get) Token: 0x06024CB7 RID: 150711 RVA: 0x009A8491 File Offset: 0x009A6691
		// (set) Token: 0x06024CB8 RID: 150712 RVA: 0x009A84A5 File Offset: 0x009A66A5
		[Nullable(0)]
		public unsafe TEnumAsByte<E_Cloud_Presents> 当前云
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_16);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17004DF5 RID: 19957
		// (get) Token: 0x06024CB9 RID: 150713 RVA: 0x009A84BA File Offset: 0x009A66BA
		// (set) Token: 0x06024CBA RID: 150714 RVA: 0x009A84CA File Offset: 0x009A66CA
		public unsafe bool Is_Reversed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004DF6 RID: 19958
		// (get) Token: 0x06024CBB RID: 150715 RVA: 0x009A84DB File Offset: 0x009A66DB
		// (set) Token: 0x06024CBC RID: 150716 RVA: 0x009A84EB File Offset: 0x009A66EB
		public unsafe float Reversed_ZHeight_Bias
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17004DF7 RID: 19959
		// (get) Token: 0x06024CBD RID: 150717 RVA: 0x009A84FC File Offset: 0x009A66FC
		// (set) Token: 0x06024CBE RID: 150718 RVA: 0x009A8510 File Offset: 0x009A6710
		[Nullable(0)]
		public unsafe TEnumAsByte<E_Cloud_Presents> 待切换云
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_19);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17004DF8 RID: 19960
		// (get) Token: 0x06024CBF RID: 150719 RVA: 0x009A8525 File Offset: 0x009A6725
		// (set) Token: 0x06024CC0 RID: 150720 RVA: 0x009A8535 File Offset: 0x009A6735
		public unsafe bool CoverNoiseParameters
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004DF9 RID: 19961
		// (get) Token: 0x06024CC1 RID: 150721 RVA: 0x009A8546 File Offset: 0x009A6746
		// (set) Token: 0x06024CC2 RID: 150722 RVA: 0x009A8556 File Offset: 0x009A6756
		public unsafe bool EnableChange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004DFA RID: 19962
		// (get) Token: 0x06024CC3 RID: 150723 RVA: 0x009A8567 File Offset: 0x009A6767
		// (set) Token: 0x06024CC4 RID: 150724 RVA: 0x009A8577 File Offset: 0x009A6777
		public unsafe float Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17004DFB RID: 19963
		// (get) Token: 0x06024CC5 RID: 150725 RVA: 0x009A8588 File Offset: 0x009A6788
		// (set) Token: 0x06024CC6 RID: 150726 RVA: 0x009A8598 File Offset: 0x009A6798
		public unsafe float Noise_Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17004DFC RID: 19964
		// (get) Token: 0x06024CC7 RID: 150727 RVA: 0x009A85A9 File Offset: 0x009A67A9
		// (set) Token: 0x06024CC8 RID: 150728 RVA: 0x009A85B9 File Offset: 0x009A67B9
		public unsafe float Noise_Strength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17004DFD RID: 19965
		// (get) Token: 0x06024CC9 RID: 150729 RVA: 0x009A85CA File Offset: 0x009A67CA
		// (set) Token: 0x06024CCA RID: 150730 RVA: 0x009A85DA File Offset: 0x009A67DA
		public unsafe float NoiseTiling
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17004DFE RID: 19966
		// (get) Token: 0x06024CCB RID: 150731 RVA: 0x009A85EC File Offset: 0x009A67EC
		// (set) Token: 0x06024CCC RID: 150732 RVA: 0x009A8625 File Offset: 0x009A6825
		[Nullable(1)]
		public FKuroCurveFloat ProgressCurve
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._ProgressCurve) == null)
				{
					result = (this._ProgressCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_26, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_26, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004DFF RID: 19967
		// (get) Token: 0x06024CCD RID: 150733 RVA: 0x009A8646 File Offset: 0x009A6846
		// (set) Token: 0x06024CCE RID: 150734 RVA: 0x009A8656 File Offset: 0x009A6856
		public unsafe float TotalChangeTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17004E00 RID: 19968
		// (get) Token: 0x06024CCF RID: 150735 RVA: 0x009A8667 File Offset: 0x009A6867
		// (set) Token: 0x06024CD0 RID: 150736 RVA: 0x009A8677 File Offset: 0x009A6877
		public unsafe float CurveTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17004E01 RID: 19969
		// (get) Token: 0x06024CD1 RID: 150737 RVA: 0x009A8688 File Offset: 0x009A6888
		// (set) Token: 0x06024CD2 RID: 150738 RVA: 0x009A8698 File Offset: 0x009A6898
		public unsafe bool CanChange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_29) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_29) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004E02 RID: 19970
		// (get) Token: 0x06024CD3 RID: 150739 RVA: 0x009A86A9 File Offset: 0x009A68A9
		// (set) Token: 0x06024CD4 RID: 150740 RVA: 0x009A86B9 File Offset: 0x009A68B9
		public unsafe bool First
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_30) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBenNew_C.__PropertyOffset_30) = (value ? 1 : 0);
			}
		}

		// Token: 0x06024CD5 RID: 150741 RVA: 0x009A86CA File Offset: 0x009A68CA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void HiddenOld()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBenNew_C.__HiddenOld_NativeFunctionPtr, null);
		}

		// Token: 0x06024CD6 RID: 150742 RVA: 0x009A86E0 File Offset: 0x009A68E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Timer(float DeltaTime)
		{
			BP_CloudFuBenNew_C.__Timer_FunctionParams* ptr = stackalloc BP_CloudFuBenNew_C.__Timer_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_CloudFuBenNew_C.__Timer_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudFuBenNew_C.__Timer_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBenNew_C.__Timer_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024CD7 RID: 150743 RVA: 0x009A8726 File Offset: 0x009A6926
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Change_Start()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBenNew_C.__Change_Start_NativeFunctionPtr, null);
		}

		// Token: 0x06024CD8 RID: 150744 RVA: 0x009A873A File Offset: 0x009A693A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 编辑器下切换()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBenNew_C.__编辑器下切换_NativeFunctionPtr, null);
		}

		// Token: 0x06024CD9 RID: 150745 RVA: 0x009A874E File Offset: 0x009A694E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Cloud_Main_Params_Update()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBenNew_C.__Cloud_Main_Params_Update_NativeFunctionPtr, null);
		}

		// Token: 0x06024CDA RID: 150746 RVA: 0x009A8764 File Offset: 0x009A6964
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Set_Cloud_Parameters(PD_CloudPrefab_C CloudPrefab, UChildActorComponent CloudActorComponent, float ChangeSpeed, int TransSortNumber)
		{
			BP_CloudFuBenNew_C.__Set_Cloud_Parameters_FunctionParams* ptr = stackalloc BP_CloudFuBenNew_C.__Set_Cloud_Parameters_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_CloudFuBenNew_C.__Set_Cloud_Parameters_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudFuBenNew_C.__Set_Cloud_Parameters_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CloudPrefab = ((CloudPrefab != null) ? CloudPrefab.NativePtr : IntPtr.Zero);
			ptr->CloudActorComponent = ((CloudActorComponent != null) ? CloudActorComponent.NativePtr : IntPtr.Zero);
			ptr->ChangeSpeed = ChangeSpeed;
			ptr->TransSortNumber = TransSortNumber;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBenNew_C.__Set_Cloud_Parameters_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024CDB RID: 150747 RVA: 0x009A87E0 File Offset: 0x009A69E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Switch_Clouds_Sub(PD_CloudPrefab_C CloudPresents, float ChangeSpeed)
		{
			BP_CloudFuBenNew_C.__Switch_Clouds_Sub_FunctionParams* ptr = stackalloc BP_CloudFuBenNew_C.__Switch_Clouds_Sub_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_CloudFuBenNew_C.__Switch_Clouds_Sub_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudFuBenNew_C.__Switch_Clouds_Sub_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CloudPresents = ((CloudPresents != null) ? CloudPresents.NativePtr : IntPtr.Zero);
			ptr->ChangeSpeed = ChangeSpeed;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBenNew_C.__Switch_Clouds_Sub_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024CDC RID: 150748 RVA: 0x009A883C File Offset: 0x009A6A3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Hide_BPCloudFuBen_Check(E_Cloud_Presents In_Type)
		{
			BP_CloudFuBenNew_C.__Hide_BPCloudFuBen_Check_FunctionParams* ptr = stackalloc BP_CloudFuBenNew_C.__Hide_BPCloudFuBen_Check_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(BP_CloudFuBenNew_C.__Hide_BPCloudFuBen_Check_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudFuBenNew_C.__Hide_BPCloudFuBen_Check_NativeFunctionPtr, (void*)ptr, 1);
			ptr->In_Type = In_Type;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBenNew_C.__Hide_BPCloudFuBen_Check_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024CDD RID: 150749 RVA: 0x009A8888 File Offset: 0x009A6A88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnLoaded_B83844664BD317A13AA3988948C763B1(UObject Loaded)
		{
			BP_CloudFuBenNew_C.__OnLoaded_B83844664BD317A13AA3988948C763B1_FunctionParams* ptr = stackalloc BP_CloudFuBenNew_C.__OnLoaded_B83844664BD317A13AA3988948C763B1_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_CloudFuBenNew_C.__OnLoaded_B83844664BD317A13AA3988948C763B1_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudFuBenNew_C.__OnLoaded_B83844664BD317A13AA3988948C763B1_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Loaded = ((Loaded != null) ? Loaded.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBenNew_C.__OnLoaded_B83844664BD317A13AA3988948C763B1_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024CDE RID: 150750 RVA: 0x009A88DD File Offset: 0x009A6ADD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBenNew_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024CDF RID: 150751 RVA: 0x009A88F1 File Offset: 0x009A6AF1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CloudFuBenNew_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024CE0 RID: 150752 RVA: 0x009A8908 File Offset: 0x009A6B08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CloudFuBenNew_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CloudFuBenNew_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CloudFuBenNew_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudFuBenNew_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBenNew_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024CE1 RID: 150753 RVA: 0x009A8950 File Offset: 0x009A6B50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CloudFuBenNew_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CloudFuBenNew_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CloudFuBenNew_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudFuBenNew_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CloudFuBenNew_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024CE2 RID: 150754 RVA: 0x009A8998 File Offset: 0x009A6B98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Switch_Clouds(E_Cloud_Presents CloudPresents, float ChangeSpeed, bool IsInEditor, bool bOverrideCloudRotation)
		{
			BP_CloudFuBenNew_C.__Switch_Clouds_FunctionParams* ptr = stackalloc BP_CloudFuBenNew_C.__Switch_Clouds_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_CloudFuBenNew_C.__Switch_Clouds_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudFuBenNew_C.__Switch_Clouds_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CloudPresents = CloudPresents;
			ptr->ChangeSpeed = ChangeSpeed;
			ptr->IsInEditor = IsInEditor;
			ptr->bOverrideCloudRotation = bOverrideCloudRotation;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBenNew_C.__Switch_Clouds_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024CE3 RID: 150755 RVA: 0x009A89FC File Offset: 0x009A6BFC
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void LoadAndSwitch(TSoftObjectPtr<UObject> Asset, float ChangeSpeed, bool IsInEditor, bool IsAudio)
		{
			BP_CloudFuBenNew_C.__LoadAndSwitch_FunctionParams* ptr = stackalloc BP_CloudFuBenNew_C.__LoadAndSwitch_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_CloudFuBenNew_C.__LoadAndSwitch_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudFuBenNew_C.__LoadAndSwitch_NativeFunctionPtr, (void*)ptr, 1);
			if (Asset != null)
			{
				FSoftObjectPtr.NativeCopy(&ptr->Asset, Asset.NativePtr, 1);
			}
			ptr->ChangeSpeed = ChangeSpeed;
			ptr->IsInEditor = IsInEditor;
			ptr->IsAudio = IsAudio;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBenNew_C.__LoadAndSwitch_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_CloudFuBenNew_C.__LoadAndSwitch_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06024CE4 RID: 150756 RVA: 0x009A8A80 File Offset: 0x009A6C80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_CloudFuBenNew_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CloudFuBenNew_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CloudFuBenNew_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudFuBenNew_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBenNew_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024CE5 RID: 150757 RVA: 0x009A8AC8 File Offset: 0x009A6CC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_CloudFuBenNew_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CloudFuBenNew_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CloudFuBenNew_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudFuBenNew_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CloudFuBenNew_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024CE6 RID: 150758 RVA: 0x009A8B0F File Offset: 0x009A6D0F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Change_Cloud_Editor()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBenNew_C.__Change_Cloud_Editor_NativeFunctionPtr, null);
		}

		// Token: 0x06024CE7 RID: 150759 RVA: 0x009A8B23 File Offset: 0x009A6D23
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Change_Cloud_Play()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBenNew_C.__Change_Cloud_Play_NativeFunctionPtr, null);
		}

		// Token: 0x06024CE8 RID: 150760 RVA: 0x009A8B38 File Offset: 0x009A6D38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CloudFuBenNew(int EntryPoint)
		{
			BP_CloudFuBenNew_C.__ExecuteUbergraph_BP_CloudFuBenNew_FunctionParams* ptr = stackalloc BP_CloudFuBenNew_C.__ExecuteUbergraph_BP_CloudFuBenNew_FunctionParams[(UIntPtr)359] + 15L / (long)sizeof(BP_CloudFuBenNew_C.__ExecuteUbergraph_BP_CloudFuBenNew_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudFuBenNew_C.__ExecuteUbergraph_BP_CloudFuBenNew_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CloudFuBenNew_C.__ExecuteUbergraph_BP_CloudFuBenNew_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024CE9 RID: 150761 RVA: 0x009A8B82 File Offset: 0x009A6D82
		protected BP_CloudFuBenNew_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012DF4 RID: 77300
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_CloudFuBenNew.BP_CloudFuBenNew_C";

		// Token: 0x04012DF5 RID: 77301
		private static IntPtr _ClassPtr;

		// Token: 0x04012DF6 RID: 77302
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012DF7 RID: 77303
		internal static int __PropertyOffset_0;

		// Token: 0x04012DF8 RID: 77304
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012DF9 RID: 77305
		internal static int __PropertyOffset_1;

		// Token: 0x04012DFA RID: 77306
		internal static int __PropertyOffset_2;

		// Token: 0x04012DFB RID: 77307
		internal static int __PropertyOffset_3;

		// Token: 0x04012DFC RID: 77308
		internal static int __PropertyOffset_4;

		// Token: 0x04012DFD RID: 77309
		internal static int __PropertyOffset_5;

		// Token: 0x04012DFE RID: 77310
		internal static int __PropertyOffset_6;

		// Token: 0x04012DFF RID: 77311
		internal static int __PropertyOffset_7;

		// Token: 0x04012E00 RID: 77312
		internal static int __PropertyOffset_8;

		// Token: 0x04012E01 RID: 77313
		internal static int __PropertyOffset_9;

		// Token: 0x04012E02 RID: 77314
		internal static int __PropertyOffset_10;

		// Token: 0x04012E03 RID: 77315
		internal static int __PropertyOffset_11;

		// Token: 0x04012E04 RID: 77316
		internal static int __PropertyOffset_12;

		// Token: 0x04012E05 RID: 77317
		internal static int __PropertyOffset_13;

		// Token: 0x04012E06 RID: 77318
		private TArray<int> _SortNumber;

		// Token: 0x04012E07 RID: 77319
		internal static int __PropertyOffset_14;

		// Token: 0x04012E08 RID: 77320
		internal static int __PropertyOffset_15;

		// Token: 0x04012E09 RID: 77321
		internal static int __PropertyOffset_16;

		// Token: 0x04012E0A RID: 77322
		internal static int __PropertyOffset_17;

		// Token: 0x04012E0B RID: 77323
		internal static int __PropertyOffset_18;

		// Token: 0x04012E0C RID: 77324
		internal static int __PropertyOffset_19;

		// Token: 0x04012E0D RID: 77325
		internal static int __PropertyOffset_20;

		// Token: 0x04012E0E RID: 77326
		internal static int __PropertyOffset_21;

		// Token: 0x04012E0F RID: 77327
		internal static int __PropertyOffset_22;

		// Token: 0x04012E10 RID: 77328
		internal static int __PropertyOffset_23;

		// Token: 0x04012E11 RID: 77329
		internal static int __PropertyOffset_24;

		// Token: 0x04012E12 RID: 77330
		internal static int __PropertyOffset_25;

		// Token: 0x04012E13 RID: 77331
		internal static int __PropertyOffset_26;

		// Token: 0x04012E14 RID: 77332
		private FKuroCurveFloat _ProgressCurve;

		// Token: 0x04012E15 RID: 77333
		internal static int __PropertyOffset_27;

		// Token: 0x04012E16 RID: 77334
		internal static int __PropertyOffset_28;

		// Token: 0x04012E17 RID: 77335
		internal static int __PropertyOffset_29;

		// Token: 0x04012E18 RID: 77336
		internal static int __PropertyOffset_30;

		// Token: 0x04012E19 RID: 77337
		private static IntPtr __HiddenOld_NativeFunctionPtr;

		// Token: 0x04012E1A RID: 77338
		private static IntPtr __Timer_NativeFunctionPtr;

		// Token: 0x04012E1B RID: 77339
		private static IntPtr __Change_Start_NativeFunctionPtr;

		// Token: 0x04012E1C RID: 77340
		private static IntPtr __编辑器下切换_NativeFunctionPtr;

		// Token: 0x04012E1D RID: 77341
		private static IntPtr __Cloud_Main_Params_Update_NativeFunctionPtr;

		// Token: 0x04012E1E RID: 77342
		private static IntPtr __Set_Cloud_Parameters_NativeFunctionPtr;

		// Token: 0x04012E1F RID: 77343
		private static IntPtr __Switch_Clouds_Sub_NativeFunctionPtr;

		// Token: 0x04012E20 RID: 77344
		private static IntPtr __Hide_BPCloudFuBen_Check_NativeFunctionPtr;

		// Token: 0x04012E21 RID: 77345
		private static IntPtr __OnLoaded_B83844664BD317A13AA3988948C763B1_NativeFunctionPtr;

		// Token: 0x04012E22 RID: 77346
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012E23 RID: 77347
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012E24 RID: 77348
		private static IntPtr __Switch_Clouds_NativeFunctionPtr;

		// Token: 0x04012E25 RID: 77349
		private static IntPtr __LoadAndSwitch_NativeFunctionPtr;

		// Token: 0x04012E26 RID: 77350
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04012E27 RID: 77351
		private static IntPtr __Change_Cloud_Editor_NativeFunctionPtr;

		// Token: 0x04012E28 RID: 77352
		private static IntPtr __Change_Cloud_Play_NativeFunctionPtr;

		// Token: 0x04012E29 RID: 77353
		private static IntPtr __ExecuteUbergraph_BP_CloudFuBenNew_NativeFunctionPtr;

		// Token: 0x02009E6C RID: 40556
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __Timer_FunctionParams
		{
			// Token: 0x040328BF RID: 207039
			[FieldOffset(0)]
			public float DeltaTime;
		}

		// Token: 0x02009E6D RID: 40557
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __Set_Cloud_Parameters_FunctionParams
		{
			// Token: 0x040328C0 RID: 207040
			[FieldOffset(0)]
			public IntPtr CloudPrefab;

			// Token: 0x040328C1 RID: 207041
			[FieldOffset(8)]
			public IntPtr CloudActorComponent;

			// Token: 0x040328C2 RID: 207042
			[FieldOffset(16)]
			public float ChangeSpeed;

			// Token: 0x040328C3 RID: 207043
			[FieldOffset(20)]
			public int TransSortNumber;
		}

		// Token: 0x02009E6E RID: 40558
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __Switch_Clouds_Sub_FunctionParams
		{
			// Token: 0x040328C4 RID: 207044
			[FieldOffset(0)]
			public IntPtr CloudPresents;

			// Token: 0x040328C5 RID: 207045
			[FieldOffset(8)]
			public float ChangeSpeed;
		}

		// Token: 0x02009E6F RID: 40559
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __Hide_BPCloudFuBen_Check_FunctionParams
		{
			// Token: 0x040328C6 RID: 207046
			[FieldOffset(0)]
			public TEnumAsByte<E_Cloud_Presents> In_Type;
		}

		// Token: 0x02009E70 RID: 40560
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __OnLoaded_B83844664BD317A13AA3988948C763B1_FunctionParams
		{
			// Token: 0x040328C7 RID: 207047
			[FieldOffset(0)]
			public IntPtr Loaded;
		}

		// Token: 0x02009E71 RID: 40561
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040328C8 RID: 207048
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E72 RID: 40562
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Switch_Clouds_FunctionParams
		{
			// Token: 0x040328C9 RID: 207049
			[FieldOffset(0)]
			public TEnumAsByte<E_Cloud_Presents> CloudPresents;

			// Token: 0x040328CA RID: 207050
			[FieldOffset(4)]
			public float ChangeSpeed;

			// Token: 0x040328CB RID: 207051
			[FieldOffset(8)]
			public bool IsInEditor;

			// Token: 0x040328CC RID: 207052
			[FieldOffset(9)]
			public bool bOverrideCloudRotation;
		}

		// Token: 0x02009E73 RID: 40563
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __LoadAndSwitch_FunctionParams
		{
			// Token: 0x040328CD RID: 207053
			[FieldOffset(0)]
			public byte Asset;

			// Token: 0x040328CE RID: 207054
			[FieldOffset(48)]
			public float ChangeSpeed;

			// Token: 0x040328CF RID: 207055
			[FieldOffset(52)]
			public bool IsInEditor;

			// Token: 0x040328D0 RID: 207056
			[FieldOffset(53)]
			public bool IsAudio;
		}

		// Token: 0x02009E74 RID: 40564
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040328D1 RID: 207057
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E75 RID: 40565
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 344)]
		protected ref struct __ExecuteUbergraph_BP_CloudFuBenNew_FunctionParams
		{
			// Token: 0x040328D2 RID: 207058
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
