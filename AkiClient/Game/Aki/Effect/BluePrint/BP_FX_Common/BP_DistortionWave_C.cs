using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Effect.BluePrint.BP_FX_Common
{
	// Token: 0x02003DEA RID: 15850
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_DistortionWave.BP_DistortionWave_C")]
	[UnrealStructLayout(1216, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1212)]
	public class BP_DistortionWave_C : __TsBpFxEffect_InheritProxy, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026EED RID: 159469 RVA: 0x009E5D50 File Offset: 0x009E3F50
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DistortionWave_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_DistortionWave.BP_DistortionWave_C");
			}
			return BP_DistortionWave_C._ClassPtr;
		}

		// Token: 0x06026EEE RID: 159470 RVA: 0x009E5D74 File Offset: 0x009E3F74
		public BP_DistortionWave_C() : this(BuiltinUtils.AllocNativeUObject(BP_DistortionWave_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026EEF RID: 159471 RVA: 0x009E5D9C File Offset: 0x009E3F9C
		[NullableContext(1)]
		public BP_DistortionWave_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DistortionWave_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005A1B RID: 23067
		// (get) Token: 0x06026EF0 RID: 159472 RVA: 0x009E5DD0 File Offset: 0x009E3FD0
		// (set) Token: 0x06026EF1 RID: 159473 RVA: 0x009E5E09 File Offset: 0x009E4009
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005A1C RID: 23068
		// (get) Token: 0x06026EF2 RID: 159474 RVA: 0x009E5E2A File Offset: 0x009E402A
		// (set) Token: 0x06026EF3 RID: 159475 RVA: 0x009E5E3E File Offset: 0x009E403E
		public unsafe UPostProcessComponent PostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DistortionWave_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DistortionWave_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005A1D RID: 23069
		// (get) Token: 0x06026EF4 RID: 159476 RVA: 0x009E5E53 File Offset: 0x009E4053
		// (set) Token: 0x06026EF5 RID: 159477 RVA: 0x009E5E63 File Offset: 0x009E4063
		public unsafe float Timeline_0_heiping_F498AE8B4953C4FCA8CB1685A329F1E7
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005A1E RID: 23070
		// (get) Token: 0x06026EF6 RID: 159478 RVA: 0x009E5E74 File Offset: 0x009E4074
		// (set) Token: 0x06026EF7 RID: 159479 RVA: 0x009E5E84 File Offset: 0x009E4084
		public unsafe float Timeline_0_LUT_F498AE8B4953C4FCA8CB1685A329F1E7
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005A1F RID: 23071
		// (get) Token: 0x06026EF8 RID: 159480 RVA: 0x009E5E95 File Offset: 0x009E4095
		// (set) Token: 0x06026EF9 RID: 159481 RVA: 0x009E5EA9 File Offset: 0x009E40A9
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> Timeline_0__Direction_F498AE8B4953C4FCA8CB1685A329F1E7
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_4);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005A20 RID: 23072
		// (get) Token: 0x06026EFA RID: 159482 RVA: 0x009E5EBE File Offset: 0x009E40BE
		// (set) Token: 0x06026EFB RID: 159483 RVA: 0x009E5ED2 File Offset: 0x009E40D2
		public unsafe UTimelineComponent Timeline_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DistortionWave_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DistortionWave_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17005A21 RID: 23073
		// (get) Token: 0x06026EFC RID: 159484 RVA: 0x009E5EE7 File Offset: 0x009E40E7
		// (set) Token: 0x06026EFD RID: 159485 RVA: 0x009E5EF7 File Offset: 0x009E40F7
		public unsafe float __________7E2D64524C81AE74B55541807D0FA0EB
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005A22 RID: 23074
		// (get) Token: 0x06026EFE RID: 159486 RVA: 0x009E5F08 File Offset: 0x009E4108
		// (set) Token: 0x06026EFF RID: 159487 RVA: 0x009E5F1C File Offset: 0x009E411C
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> ______Direction_7E2D64524C81AE74B55541807D0FA0EB
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_7);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005A23 RID: 23075
		// (get) Token: 0x06026F00 RID: 159488 RVA: 0x009E5F31 File Offset: 0x009E4131
		// (set) Token: 0x06026F01 RID: 159489 RVA: 0x009E5F45 File Offset: 0x009E4145
		public unsafe UTimelineComponent 衰退范围
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DistortionWave_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DistortionWave_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17005A24 RID: 23076
		// (get) Token: 0x06026F02 RID: 159490 RVA: 0x009E5F5A File Offset: 0x009E415A
		// (set) Token: 0x06026F03 RID: 159491 RVA: 0x009E5F6A File Offset: 0x009E416A
		public unsafe float __________3E10D26547837C4A20A06C899EDEC0D1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005A25 RID: 23077
		// (get) Token: 0x06026F04 RID: 159492 RVA: 0x009E5F7B File Offset: 0x009E417B
		// (set) Token: 0x06026F05 RID: 159493 RVA: 0x009E5F8F File Offset: 0x009E418F
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> ______Direction_3E10D26547837C4A20A06C899EDEC0D1
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_10);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005A26 RID: 23078
		// (get) Token: 0x06026F06 RID: 159494 RVA: 0x009E5FA4 File Offset: 0x009E41A4
		// (set) Token: 0x06026F07 RID: 159495 RVA: 0x009E5FB8 File Offset: 0x009E41B8
		public unsafe UTimelineComponent 轮廓强度
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DistortionWave_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DistortionWave_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17005A27 RID: 23079
		// (get) Token: 0x06026F08 RID: 159496 RVA: 0x009E5FCD File Offset: 0x009E41CD
		// (set) Token: 0x06026F09 RID: 159497 RVA: 0x009E5FDD File Offset: 0x009E41DD
		public unsafe float ______NewTrack_0_526C2D26477019A3632C9B84238820CB
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17005A28 RID: 23080
		// (get) Token: 0x06026F0A RID: 159498 RVA: 0x009E5FEE File Offset: 0x009E41EE
		// (set) Token: 0x06026F0B RID: 159499 RVA: 0x009E6002 File Offset: 0x009E4202
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> _______Direction_526C2D26477019A3632C9B84238820CB
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_13);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17005A29 RID: 23081
		// (get) Token: 0x06026F0C RID: 159500 RVA: 0x009E6017 File Offset: 0x009E4217
		// (set) Token: 0x06026F0D RID: 159501 RVA: 0x009E602B File Offset: 0x009E422B
		public unsafe UTimelineComponent 扫描带强度
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DistortionWave_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DistortionWave_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17005A2A RID: 23082
		// (get) Token: 0x06026F0E RID: 159502 RVA: 0x009E6040 File Offset: 0x009E4240
		// (set) Token: 0x06026F0F RID: 159503 RVA: 0x009E6050 File Offset: 0x009E4250
		public unsafe float _____NewTrack_0_175C8B6644C323A3919A3BBDAA349603
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17005A2B RID: 23083
		// (get) Token: 0x06026F10 RID: 159504 RVA: 0x009E6061 File Offset: 0x009E4261
		// (set) Token: 0x06026F11 RID: 159505 RVA: 0x009E6075 File Offset: 0x009E4275
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> ______Direction_175C8B6644C323A3919A3BBDAA349603
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_16);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17005A2C RID: 23084
		// (get) Token: 0x06026F12 RID: 159506 RVA: 0x009E608A File Offset: 0x009E428A
		// (set) Token: 0x06026F13 RID: 159507 RVA: 0x009E609E File Offset: 0x009E429E
		public unsafe UTimelineComponent 扫描范围
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DistortionWave_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DistortionWave_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17005A2D RID: 23085
		// (get) Token: 0x06026F14 RID: 159508 RVA: 0x009E60B3 File Offset: 0x009E42B3
		// (set) Token: 0x06026F15 RID: 159509 RVA: 0x009E60C7 File Offset: 0x009E42C7
		public unsafe UMaterialInterface ScanMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DistortionWave_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DistortionWave_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17005A2E RID: 23086
		// (get) Token: 0x06026F16 RID: 159510 RVA: 0x009E60DC File Offset: 0x009E42DC
		// (set) Token: 0x06026F17 RID: 159511 RVA: 0x009E60EC File Offset: 0x009E42EC
		public unsafe bool 反向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005A2F RID: 23087
		// (get) Token: 0x06026F18 RID: 159512 RVA: 0x009E60FD File Offset: 0x009E42FD
		// (set) Token: 0x06026F19 RID: 159513 RVA: 0x009E610D File Offset: 0x009E430D
		public unsafe float Play_Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17005A30 RID: 23088
		// (get) Token: 0x06026F1A RID: 159514 RVA: 0x009E611E File Offset: 0x009E431E
		// (set) Token: 0x06026F1B RID: 159515 RVA: 0x009E6132 File Offset: 0x009E4332
		public unsafe UMaterialInstanceDynamic ScanMaterialMID
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DistortionWave_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DistortionWave_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17005A31 RID: 23089
		// (get) Token: 0x06026F1C RID: 159516 RVA: 0x009E6147 File Offset: 0x009E4347
		// (set) Token: 0x06026F1D RID: 159517 RVA: 0x009E6157 File Offset: 0x009E4357
		public unsafe float PlaySpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17005A32 RID: 23090
		// (get) Token: 0x06026F1E RID: 159518 RVA: 0x009E6168 File Offset: 0x009E4368
		// (set) Token: 0x06026F1F RID: 159519 RVA: 0x009E6178 File Offset: 0x009E4378
		public unsafe bool StartTicking
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005A33 RID: 23091
		// (get) Token: 0x06026F20 RID: 159520 RVA: 0x009E6189 File Offset: 0x009E4389
		// (set) Token: 0x06026F21 RID: 159521 RVA: 0x009E6199 File Offset: 0x009E4399
		public unsafe bool IsUsedForSeq
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005A34 RID: 23092
		// (get) Token: 0x06026F22 RID: 159522 RVA: 0x009E61AA File Offset: 0x009E43AA
		// (set) Token: 0x06026F23 RID: 159523 RVA: 0x009E61BA File Offset: 0x009E43BA
		public unsafe float SeqLifeCycle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DistortionWave_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x06026F24 RID: 159524 RVA: 0x009E61CB File Offset: 0x009E43CB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartScanEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DistortionWave_C.__StartScanEffect_NativeFunctionPtr, null);
		}

		// Token: 0x06026F25 RID: 159525 RVA: 0x009E61DF File Offset: 0x009E43DF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetRevert()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DistortionWave_C.__SetRevert_NativeFunctionPtr, null);
		}

		// Token: 0x06026F26 RID: 159526 RVA: 0x009E61F3 File Offset: 0x009E43F3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 轮廓强度__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DistortionWave_C.__轮廓强度__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026F27 RID: 159527 RVA: 0x009E6207 File Offset: 0x009E4407
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 轮廓强度__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DistortionWave_C.__轮廓强度__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026F28 RID: 159528 RVA: 0x009E621B File Offset: 0x009E441B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 衰退范围__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DistortionWave_C.__衰退范围__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026F29 RID: 159529 RVA: 0x009E622F File Offset: 0x009E442F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 衰退范围__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DistortionWave_C.__衰退范围__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026F2A RID: 159530 RVA: 0x009E6243 File Offset: 0x009E4443
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_0__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DistortionWave_C.__Timeline_0__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026F2B RID: 159531 RVA: 0x009E6257 File Offset: 0x009E4457
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_0__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DistortionWave_C.__Timeline_0__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026F2C RID: 159532 RVA: 0x009E626B File Offset: 0x009E446B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 扫描带强度__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DistortionWave_C.__扫描带强度__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026F2D RID: 159533 RVA: 0x009E627F File Offset: 0x009E447F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 扫描带强度__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DistortionWave_C.__扫描带强度__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026F2E RID: 159534 RVA: 0x009E6293 File Offset: 0x009E4493
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 扫描范围__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DistortionWave_C.__扫描范围__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026F2F RID: 159535 RVA: 0x009E62A7 File Offset: 0x009E44A7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 扫描范围__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DistortionWave_C.__扫描范围__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026F30 RID: 159536 RVA: 0x009E62BC File Offset: 0x009E44BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_DistortionWave_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_DistortionWave_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DistortionWave_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DistortionWave_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DistortionWave_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026F31 RID: 159537 RVA: 0x009E6304 File Offset: 0x009E4504
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_DistortionWave_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_DistortionWave_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DistortionWave_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DistortionWave_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DistortionWave_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026F32 RID: 159538 RVA: 0x009E634B File Offset: 0x009E454B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DistortionWave_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06026F33 RID: 159539 RVA: 0x009E635F File Offset: 0x009E455F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DistortionWave_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06026F34 RID: 159540 RVA: 0x009E6374 File Offset: 0x009E4574
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_DistortionWave(int EntryPoint)
		{
			BP_DistortionWave_C.__ExecuteUbergraph_BP_DistortionWave_FunctionParams* ptr = stackalloc BP_DistortionWave_C.__ExecuteUbergraph_BP_DistortionWave_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(BP_DistortionWave_C.__ExecuteUbergraph_BP_DistortionWave_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DistortionWave_C.__ExecuteUbergraph_BP_DistortionWave_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DistortionWave_C.__ExecuteUbergraph_BP_DistortionWave_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026F35 RID: 159541 RVA: 0x009E63BB File Offset: 0x009E45BB
		protected BP_DistortionWave_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014531 RID: 83249
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_DistortionWave.BP_DistortionWave_C";

		// Token: 0x04014532 RID: 83250
		private static IntPtr _ClassPtr;

		// Token: 0x04014533 RID: 83251
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014534 RID: 83252
		internal static int __PropertyOffset_0;

		// Token: 0x04014535 RID: 83253
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04014536 RID: 83254
		internal static int __PropertyOffset_1;

		// Token: 0x04014537 RID: 83255
		internal static int __PropertyOffset_2;

		// Token: 0x04014538 RID: 83256
		internal static int __PropertyOffset_3;

		// Token: 0x04014539 RID: 83257
		internal static int __PropertyOffset_4;

		// Token: 0x0401453A RID: 83258
		internal static int __PropertyOffset_5;

		// Token: 0x0401453B RID: 83259
		internal static int __PropertyOffset_6;

		// Token: 0x0401453C RID: 83260
		internal static int __PropertyOffset_7;

		// Token: 0x0401453D RID: 83261
		internal static int __PropertyOffset_8;

		// Token: 0x0401453E RID: 83262
		internal static int __PropertyOffset_9;

		// Token: 0x0401453F RID: 83263
		internal static int __PropertyOffset_10;

		// Token: 0x04014540 RID: 83264
		internal static int __PropertyOffset_11;

		// Token: 0x04014541 RID: 83265
		internal static int __PropertyOffset_12;

		// Token: 0x04014542 RID: 83266
		internal static int __PropertyOffset_13;

		// Token: 0x04014543 RID: 83267
		internal static int __PropertyOffset_14;

		// Token: 0x04014544 RID: 83268
		internal static int __PropertyOffset_15;

		// Token: 0x04014545 RID: 83269
		internal static int __PropertyOffset_16;

		// Token: 0x04014546 RID: 83270
		internal static int __PropertyOffset_17;

		// Token: 0x04014547 RID: 83271
		internal static int __PropertyOffset_18;

		// Token: 0x04014548 RID: 83272
		internal static int __PropertyOffset_19;

		// Token: 0x04014549 RID: 83273
		internal static int __PropertyOffset_20;

		// Token: 0x0401454A RID: 83274
		internal static int __PropertyOffset_21;

		// Token: 0x0401454B RID: 83275
		internal static int __PropertyOffset_22;

		// Token: 0x0401454C RID: 83276
		internal static int __PropertyOffset_23;

		// Token: 0x0401454D RID: 83277
		internal static int __PropertyOffset_24;

		// Token: 0x0401454E RID: 83278
		internal static int __PropertyOffset_25;

		// Token: 0x0401454F RID: 83279
		private static IntPtr __StartScanEffect_NativeFunctionPtr;

		// Token: 0x04014550 RID: 83280
		private static IntPtr __SetRevert_NativeFunctionPtr;

		// Token: 0x04014551 RID: 83281
		private static IntPtr __轮廓强度__FinishedFunc_NativeFunctionPtr;

		// Token: 0x04014552 RID: 83282
		private static IntPtr __轮廓强度__UpdateFunc_NativeFunctionPtr;

		// Token: 0x04014553 RID: 83283
		private static IntPtr __衰退范围__FinishedFunc_NativeFunctionPtr;

		// Token: 0x04014554 RID: 83284
		private static IntPtr __衰退范围__UpdateFunc_NativeFunctionPtr;

		// Token: 0x04014555 RID: 83285
		private static IntPtr __Timeline_0__FinishedFunc_NativeFunctionPtr;

		// Token: 0x04014556 RID: 83286
		private static IntPtr __Timeline_0__UpdateFunc_NativeFunctionPtr;

		// Token: 0x04014557 RID: 83287
		private static IntPtr __扫描带强度__FinishedFunc_NativeFunctionPtr;

		// Token: 0x04014558 RID: 83288
		private static IntPtr __扫描带强度__UpdateFunc_NativeFunctionPtr;

		// Token: 0x04014559 RID: 83289
		private static IntPtr __扫描范围__FinishedFunc_NativeFunctionPtr;

		// Token: 0x0401455A RID: 83290
		private static IntPtr __扫描范围__UpdateFunc_NativeFunctionPtr;

		// Token: 0x0401455B RID: 83291
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401455C RID: 83292
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401455D RID: 83293
		private static IntPtr __ExecuteUbergraph_BP_DistortionWave_NativeFunctionPtr;

		// Token: 0x0200A0C0 RID: 41152
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032D73 RID: 208243
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A0C1 RID: 41153
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __ExecuteUbergraph_BP_DistortionWave_FunctionParams
		{
			// Token: 0x04032D74 RID: 208244
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
