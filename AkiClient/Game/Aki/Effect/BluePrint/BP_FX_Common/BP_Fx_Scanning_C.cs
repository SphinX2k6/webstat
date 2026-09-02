using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Effect.BluePrint.BP_FX_Common
{
	// Token: 0x02003DEE RID: 15854
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_Fx_Scanning.BP_Fx_Scanning_C")]
	[UnrealStructLayout(1216, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1212)]
	public class BP_Fx_Scanning_C : __TsBpFxEffect_InheritProxy, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026FAF RID: 159663 RVA: 0x009E7080 File Offset: 0x009E5280
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Fx_Scanning_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_Fx_Scanning.BP_Fx_Scanning_C");
			}
			return BP_Fx_Scanning_C._ClassPtr;
		}

		// Token: 0x06026FB0 RID: 159664 RVA: 0x009E70A4 File Offset: 0x009E52A4
		public BP_Fx_Scanning_C() : this(BuiltinUtils.AllocNativeUObject(BP_Fx_Scanning_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026FB1 RID: 159665 RVA: 0x009E70CC File Offset: 0x009E52CC
		[NullableContext(1)]
		public BP_Fx_Scanning_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Fx_Scanning_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005A5E RID: 23134
		// (get) Token: 0x06026FB2 RID: 159666 RVA: 0x009E7100 File Offset: 0x009E5300
		// (set) Token: 0x06026FB3 RID: 159667 RVA: 0x009E7139 File Offset: 0x009E5339
		[Nullable(1)]
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005A5F RID: 23135
		// (get) Token: 0x06026FB4 RID: 159668 RVA: 0x009E715A File Offset: 0x009E535A
		// (set) Token: 0x06026FB5 RID: 159669 RVA: 0x009E716E File Offset: 0x009E536E
		public unsafe UPostProcessComponent PostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005A60 RID: 23136
		// (get) Token: 0x06026FB6 RID: 159670 RVA: 0x009E7183 File Offset: 0x009E5383
		// (set) Token: 0x06026FB7 RID: 159671 RVA: 0x009E7193 File Offset: 0x009E5393
		public unsafe float Timeline_0_heiping_353B1A7A4A9CB64DD0E9F4A743D43275
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005A61 RID: 23137
		// (get) Token: 0x06026FB8 RID: 159672 RVA: 0x009E71A4 File Offset: 0x009E53A4
		// (set) Token: 0x06026FB9 RID: 159673 RVA: 0x009E71B4 File Offset: 0x009E53B4
		public unsafe float Timeline_0_LUT_353B1A7A4A9CB64DD0E9F4A743D43275
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005A62 RID: 23138
		// (get) Token: 0x06026FBA RID: 159674 RVA: 0x009E71C5 File Offset: 0x009E53C5
		// (set) Token: 0x06026FBB RID: 159675 RVA: 0x009E71D9 File Offset: 0x009E53D9
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> Timeline_0__Direction_353B1A7A4A9CB64DD0E9F4A743D43275
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_4);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005A63 RID: 23139
		// (get) Token: 0x06026FBC RID: 159676 RVA: 0x009E71EE File Offset: 0x009E53EE
		// (set) Token: 0x06026FBD RID: 159677 RVA: 0x009E7202 File Offset: 0x009E5402
		public unsafe UTimelineComponent Timeline_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17005A64 RID: 23140
		// (get) Token: 0x06026FBE RID: 159678 RVA: 0x009E7217 File Offset: 0x009E5417
		// (set) Token: 0x06026FBF RID: 159679 RVA: 0x009E7227 File Offset: 0x009E5427
		public unsafe float __________51722C4C46877BE320D640A615DF102A
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005A65 RID: 23141
		// (get) Token: 0x06026FC0 RID: 159680 RVA: 0x009E7238 File Offset: 0x009E5438
		// (set) Token: 0x06026FC1 RID: 159681 RVA: 0x009E724C File Offset: 0x009E544C
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> ______Direction_51722C4C46877BE320D640A615DF102A
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_7);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005A66 RID: 23142
		// (get) Token: 0x06026FC2 RID: 159682 RVA: 0x009E7261 File Offset: 0x009E5461
		// (set) Token: 0x06026FC3 RID: 159683 RVA: 0x009E7275 File Offset: 0x009E5475
		public unsafe UTimelineComponent 衰退范围
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17005A67 RID: 23143
		// (get) Token: 0x06026FC4 RID: 159684 RVA: 0x009E728A File Offset: 0x009E548A
		// (set) Token: 0x06026FC5 RID: 159685 RVA: 0x009E729A File Offset: 0x009E549A
		public unsafe float __________4BA202604863CA55AF0FC0B49F86965B
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005A68 RID: 23144
		// (get) Token: 0x06026FC6 RID: 159686 RVA: 0x009E72AB File Offset: 0x009E54AB
		// (set) Token: 0x06026FC7 RID: 159687 RVA: 0x009E72BF File Offset: 0x009E54BF
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> ______Direction_4BA202604863CA55AF0FC0B49F86965B
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_10);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005A69 RID: 23145
		// (get) Token: 0x06026FC8 RID: 159688 RVA: 0x009E72D4 File Offset: 0x009E54D4
		// (set) Token: 0x06026FC9 RID: 159689 RVA: 0x009E72E8 File Offset: 0x009E54E8
		public unsafe UTimelineComponent 轮廓强度
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17005A6A RID: 23146
		// (get) Token: 0x06026FCA RID: 159690 RVA: 0x009E72FD File Offset: 0x009E54FD
		// (set) Token: 0x06026FCB RID: 159691 RVA: 0x009E730D File Offset: 0x009E550D
		public unsafe float ______NewTrack_0_F355743F48DC9EB377A77A9C1115080C
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17005A6B RID: 23147
		// (get) Token: 0x06026FCC RID: 159692 RVA: 0x009E731E File Offset: 0x009E551E
		// (set) Token: 0x06026FCD RID: 159693 RVA: 0x009E7332 File Offset: 0x009E5532
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> _______Direction_F355743F48DC9EB377A77A9C1115080C
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_13);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17005A6C RID: 23148
		// (get) Token: 0x06026FCE RID: 159694 RVA: 0x009E7347 File Offset: 0x009E5547
		// (set) Token: 0x06026FCF RID: 159695 RVA: 0x009E735B File Offset: 0x009E555B
		public unsafe UTimelineComponent 扫描带强度
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17005A6D RID: 23149
		// (get) Token: 0x06026FD0 RID: 159696 RVA: 0x009E7370 File Offset: 0x009E5570
		// (set) Token: 0x06026FD1 RID: 159697 RVA: 0x009E7380 File Offset: 0x009E5580
		public unsafe float _____NewTrack_0_06BB87C141833981013181AD8BBDFB4F
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17005A6E RID: 23150
		// (get) Token: 0x06026FD2 RID: 159698 RVA: 0x009E7391 File Offset: 0x009E5591
		// (set) Token: 0x06026FD3 RID: 159699 RVA: 0x009E73A5 File Offset: 0x009E55A5
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> ______Direction_06BB87C141833981013181AD8BBDFB4F
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_16);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17005A6F RID: 23151
		// (get) Token: 0x06026FD4 RID: 159700 RVA: 0x009E73BA File Offset: 0x009E55BA
		// (set) Token: 0x06026FD5 RID: 159701 RVA: 0x009E73CE File Offset: 0x009E55CE
		public unsafe UTimelineComponent 扫描范围
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17005A70 RID: 23152
		// (get) Token: 0x06026FD6 RID: 159702 RVA: 0x009E73E3 File Offset: 0x009E55E3
		// (set) Token: 0x06026FD7 RID: 159703 RVA: 0x009E73F7 File Offset: 0x009E55F7
		public unsafe UMaterialInterface ScanMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17005A71 RID: 23153
		// (get) Token: 0x06026FD8 RID: 159704 RVA: 0x009E740C File Offset: 0x009E560C
		// (set) Token: 0x06026FD9 RID: 159705 RVA: 0x009E741C File Offset: 0x009E561C
		public unsafe bool 反向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005A72 RID: 23154
		// (get) Token: 0x06026FDA RID: 159706 RVA: 0x009E742D File Offset: 0x009E562D
		// (set) Token: 0x06026FDB RID: 159707 RVA: 0x009E743D File Offset: 0x009E563D
		public unsafe float Play_Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17005A73 RID: 23155
		// (get) Token: 0x06026FDC RID: 159708 RVA: 0x009E744E File Offset: 0x009E564E
		// (set) Token: 0x06026FDD RID: 159709 RVA: 0x009E7462 File Offset: 0x009E5662
		public unsafe UMaterialInstanceDynamic ScanMaterialMID
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17005A74 RID: 23156
		// (get) Token: 0x06026FDE RID: 159710 RVA: 0x009E7477 File Offset: 0x009E5677
		// (set) Token: 0x06026FDF RID: 159711 RVA: 0x009E7487 File Offset: 0x009E5687
		public unsafe float PlaySpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17005A75 RID: 23157
		// (get) Token: 0x06026FE0 RID: 159712 RVA: 0x009E7498 File Offset: 0x009E5698
		// (set) Token: 0x06026FE1 RID: 159713 RVA: 0x009E74A8 File Offset: 0x009E56A8
		public unsafe bool StartTicking
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005A76 RID: 23158
		// (get) Token: 0x06026FE2 RID: 159714 RVA: 0x009E74B9 File Offset: 0x009E56B9
		// (set) Token: 0x06026FE3 RID: 159715 RVA: 0x009E74C9 File Offset: 0x009E56C9
		public unsafe bool IsUsedForSeq
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005A77 RID: 23159
		// (get) Token: 0x06026FE4 RID: 159716 RVA: 0x009E74DA File Offset: 0x009E56DA
		// (set) Token: 0x06026FE5 RID: 159717 RVA: 0x009E74EA File Offset: 0x009E56EA
		public unsafe float SeqLifeCycle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x06026FE6 RID: 159718 RVA: 0x009E74FB File Offset: 0x009E56FB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartScanEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_C.__StartScanEffect_NativeFunctionPtr, null);
		}

		// Token: 0x06026FE7 RID: 159719 RVA: 0x009E750F File Offset: 0x009E570F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetRevert()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_C.__SetRevert_NativeFunctionPtr, null);
		}

		// Token: 0x06026FE8 RID: 159720 RVA: 0x009E7523 File Offset: 0x009E5723
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 扫描范围__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_C.__扫描范围__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026FE9 RID: 159721 RVA: 0x009E7537 File Offset: 0x009E5737
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 扫描范围__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_C.__扫描范围__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026FEA RID: 159722 RVA: 0x009E754B File Offset: 0x009E574B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 扫描带强度__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_C.__扫描带强度__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026FEB RID: 159723 RVA: 0x009E755F File Offset: 0x009E575F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 扫描带强度__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_C.__扫描带强度__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026FEC RID: 159724 RVA: 0x009E7573 File Offset: 0x009E5773
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 轮廓强度__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_C.__轮廓强度__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026FED RID: 159725 RVA: 0x009E7587 File Offset: 0x009E5787
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 轮廓强度__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_C.__轮廓强度__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026FEE RID: 159726 RVA: 0x009E759B File Offset: 0x009E579B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 衰退范围__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_C.__衰退范围__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026FEF RID: 159727 RVA: 0x009E75AF File Offset: 0x009E57AF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 衰退范围__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_C.__衰退范围__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026FF0 RID: 159728 RVA: 0x009E75C3 File Offset: 0x009E57C3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_0__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_C.__Timeline_0__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026FF1 RID: 159729 RVA: 0x009E75D7 File Offset: 0x009E57D7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_0__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_C.__Timeline_0__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026FF2 RID: 159730 RVA: 0x009E75EC File Offset: 0x009E57EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Fx_Scanning_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Fx_Scanning_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Fx_Scanning_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_Scanning_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026FF3 RID: 159731 RVA: 0x009E7634 File Offset: 0x009E5834
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Fx_Scanning_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Fx_Scanning_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Fx_Scanning_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_Scanning_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Fx_Scanning_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026FF4 RID: 159732 RVA: 0x009E767B File Offset: 0x009E587B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06026FF5 RID: 159733 RVA: 0x009E768F File Offset: 0x009E588F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Fx_Scanning_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06026FF6 RID: 159734 RVA: 0x009E76A4 File Offset: 0x009E58A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Fx_Scanning(int EntryPoint)
		{
			BP_Fx_Scanning_C.__ExecuteUbergraph_BP_Fx_Scanning_FunctionParams* ptr = stackalloc BP_Fx_Scanning_C.__ExecuteUbergraph_BP_Fx_Scanning_FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(BP_Fx_Scanning_C.__ExecuteUbergraph_BP_Fx_Scanning_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_Scanning_C.__ExecuteUbergraph_BP_Fx_Scanning_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Fx_Scanning_C.__ExecuteUbergraph_BP_Fx_Scanning_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026FF7 RID: 159735 RVA: 0x009E76EB File Offset: 0x009E58EB
		protected BP_Fx_Scanning_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040145A9 RID: 83369
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_Fx_Scanning.BP_Fx_Scanning_C";

		// Token: 0x040145AA RID: 83370
		private static IntPtr _ClassPtr;

		// Token: 0x040145AB RID: 83371
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040145AC RID: 83372
		internal static int __PropertyOffset_0;

		// Token: 0x040145AD RID: 83373
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040145AE RID: 83374
		internal static int __PropertyOffset_1;

		// Token: 0x040145AF RID: 83375
		internal static int __PropertyOffset_2;

		// Token: 0x040145B0 RID: 83376
		internal static int __PropertyOffset_3;

		// Token: 0x040145B1 RID: 83377
		internal static int __PropertyOffset_4;

		// Token: 0x040145B2 RID: 83378
		internal static int __PropertyOffset_5;

		// Token: 0x040145B3 RID: 83379
		internal static int __PropertyOffset_6;

		// Token: 0x040145B4 RID: 83380
		internal static int __PropertyOffset_7;

		// Token: 0x040145B5 RID: 83381
		internal static int __PropertyOffset_8;

		// Token: 0x040145B6 RID: 83382
		internal static int __PropertyOffset_9;

		// Token: 0x040145B7 RID: 83383
		internal static int __PropertyOffset_10;

		// Token: 0x040145B8 RID: 83384
		internal static int __PropertyOffset_11;

		// Token: 0x040145B9 RID: 83385
		internal static int __PropertyOffset_12;

		// Token: 0x040145BA RID: 83386
		internal static int __PropertyOffset_13;

		// Token: 0x040145BB RID: 83387
		internal static int __PropertyOffset_14;

		// Token: 0x040145BC RID: 83388
		internal static int __PropertyOffset_15;

		// Token: 0x040145BD RID: 83389
		internal static int __PropertyOffset_16;

		// Token: 0x040145BE RID: 83390
		internal static int __PropertyOffset_17;

		// Token: 0x040145BF RID: 83391
		internal static int __PropertyOffset_18;

		// Token: 0x040145C0 RID: 83392
		internal static int __PropertyOffset_19;

		// Token: 0x040145C1 RID: 83393
		internal static int __PropertyOffset_20;

		// Token: 0x040145C2 RID: 83394
		internal static int __PropertyOffset_21;

		// Token: 0x040145C3 RID: 83395
		internal static int __PropertyOffset_22;

		// Token: 0x040145C4 RID: 83396
		internal static int __PropertyOffset_23;

		// Token: 0x040145C5 RID: 83397
		internal static int __PropertyOffset_24;

		// Token: 0x040145C6 RID: 83398
		internal static int __PropertyOffset_25;

		// Token: 0x040145C7 RID: 83399
		private static IntPtr __StartScanEffect_NativeFunctionPtr;

		// Token: 0x040145C8 RID: 83400
		private static IntPtr __SetRevert_NativeFunctionPtr;

		// Token: 0x040145C9 RID: 83401
		private static IntPtr __扫描范围__FinishedFunc_NativeFunctionPtr;

		// Token: 0x040145CA RID: 83402
		private static IntPtr __扫描范围__UpdateFunc_NativeFunctionPtr;

		// Token: 0x040145CB RID: 83403
		private static IntPtr __扫描带强度__FinishedFunc_NativeFunctionPtr;

		// Token: 0x040145CC RID: 83404
		private static IntPtr __扫描带强度__UpdateFunc_NativeFunctionPtr;

		// Token: 0x040145CD RID: 83405
		private static IntPtr __轮廓强度__FinishedFunc_NativeFunctionPtr;

		// Token: 0x040145CE RID: 83406
		private static IntPtr __轮廓强度__UpdateFunc_NativeFunctionPtr;

		// Token: 0x040145CF RID: 83407
		private static IntPtr __衰退范围__FinishedFunc_NativeFunctionPtr;

		// Token: 0x040145D0 RID: 83408
		private static IntPtr __衰退范围__UpdateFunc_NativeFunctionPtr;

		// Token: 0x040145D1 RID: 83409
		private static IntPtr __Timeline_0__FinishedFunc_NativeFunctionPtr;

		// Token: 0x040145D2 RID: 83410
		private static IntPtr __Timeline_0__UpdateFunc_NativeFunctionPtr;

		// Token: 0x040145D3 RID: 83411
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040145D4 RID: 83412
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040145D5 RID: 83413
		private static IntPtr __ExecuteUbergraph_BP_Fx_Scanning_NativeFunctionPtr;

		// Token: 0x0200A0CA RID: 41162
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032D7E RID: 208254
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A0CB RID: 41163
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __ExecuteUbergraph_BP_Fx_Scanning_FunctionParams
		{
			// Token: 0x04032D7F RID: 208255
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
