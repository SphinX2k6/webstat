using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Effect.BluePrint.BP_FX_Common
{
	// Token: 0x02003DED RID: 15853
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_Fx_Scanning_2_7.BP_Fx_Scanning_2_7_C")]
	[UnrealStructLayout(1216, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1212)]
	public class BP_Fx_Scanning_2_7_C : __TsBpFxEffect_InheritProxy, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026F66 RID: 159590 RVA: 0x009E6A0C File Offset: 0x009E4C0C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Fx_Scanning_2_7_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_Fx_Scanning_2_7.BP_Fx_Scanning_2_7_C");
			}
			return BP_Fx_Scanning_2_7_C._ClassPtr;
		}

		// Token: 0x06026F67 RID: 159591 RVA: 0x009E6A30 File Offset: 0x009E4C30
		public BP_Fx_Scanning_2_7_C() : this(BuiltinUtils.AllocNativeUObject(BP_Fx_Scanning_2_7_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026F68 RID: 159592 RVA: 0x009E6A58 File Offset: 0x009E4C58
		[NullableContext(1)]
		public BP_Fx_Scanning_2_7_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Fx_Scanning_2_7_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005A44 RID: 23108
		// (get) Token: 0x06026F69 RID: 159593 RVA: 0x009E6A8C File Offset: 0x009E4C8C
		// (set) Token: 0x06026F6A RID: 159594 RVA: 0x009E6AC5 File Offset: 0x009E4CC5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005A45 RID: 23109
		// (get) Token: 0x06026F6B RID: 159595 RVA: 0x009E6AE6 File Offset: 0x009E4CE6
		// (set) Token: 0x06026F6C RID: 159596 RVA: 0x009E6AFA File Offset: 0x009E4CFA
		public unsafe UPostProcessComponent PostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_2_7_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_2_7_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005A46 RID: 23110
		// (get) Token: 0x06026F6D RID: 159597 RVA: 0x009E6B0F File Offset: 0x009E4D0F
		// (set) Token: 0x06026F6E RID: 159598 RVA: 0x009E6B1F File Offset: 0x009E4D1F
		public unsafe float Timeline_0_heiping_26A4F0B3447A7F029D57DD9F98C94050
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005A47 RID: 23111
		// (get) Token: 0x06026F6F RID: 159599 RVA: 0x009E6B30 File Offset: 0x009E4D30
		// (set) Token: 0x06026F70 RID: 159600 RVA: 0x009E6B40 File Offset: 0x009E4D40
		public unsafe float Timeline_0_LUT_26A4F0B3447A7F029D57DD9F98C94050
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005A48 RID: 23112
		// (get) Token: 0x06026F71 RID: 159601 RVA: 0x009E6B51 File Offset: 0x009E4D51
		// (set) Token: 0x06026F72 RID: 159602 RVA: 0x009E6B65 File Offset: 0x009E4D65
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> Timeline_0__Direction_26A4F0B3447A7F029D57DD9F98C94050
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_4);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005A49 RID: 23113
		// (get) Token: 0x06026F73 RID: 159603 RVA: 0x009E6B7A File Offset: 0x009E4D7A
		// (set) Token: 0x06026F74 RID: 159604 RVA: 0x009E6B8E File Offset: 0x009E4D8E
		public unsafe UTimelineComponent Timeline_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_2_7_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_2_7_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17005A4A RID: 23114
		// (get) Token: 0x06026F75 RID: 159605 RVA: 0x009E6BA3 File Offset: 0x009E4DA3
		// (set) Token: 0x06026F76 RID: 159606 RVA: 0x009E6BB3 File Offset: 0x009E4DB3
		public unsafe float __________4C5B91014089D599A5FB9C8759D37F26
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005A4B RID: 23115
		// (get) Token: 0x06026F77 RID: 159607 RVA: 0x009E6BC4 File Offset: 0x009E4DC4
		// (set) Token: 0x06026F78 RID: 159608 RVA: 0x009E6BD8 File Offset: 0x009E4DD8
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> ______Direction_4C5B91014089D599A5FB9C8759D37F26
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_7);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005A4C RID: 23116
		// (get) Token: 0x06026F79 RID: 159609 RVA: 0x009E6BED File Offset: 0x009E4DED
		// (set) Token: 0x06026F7A RID: 159610 RVA: 0x009E6C01 File Offset: 0x009E4E01
		public unsafe UTimelineComponent 衰退范围
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_2_7_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_2_7_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17005A4D RID: 23117
		// (get) Token: 0x06026F7B RID: 159611 RVA: 0x009E6C16 File Offset: 0x009E4E16
		// (set) Token: 0x06026F7C RID: 159612 RVA: 0x009E6C26 File Offset: 0x009E4E26
		public unsafe float __________EC357DD942DC2CB793230ABE2809390C
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005A4E RID: 23118
		// (get) Token: 0x06026F7D RID: 159613 RVA: 0x009E6C37 File Offset: 0x009E4E37
		// (set) Token: 0x06026F7E RID: 159614 RVA: 0x009E6C4B File Offset: 0x009E4E4B
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> ______Direction_EC357DD942DC2CB793230ABE2809390C
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_10);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005A4F RID: 23119
		// (get) Token: 0x06026F7F RID: 159615 RVA: 0x009E6C60 File Offset: 0x009E4E60
		// (set) Token: 0x06026F80 RID: 159616 RVA: 0x009E6C74 File Offset: 0x009E4E74
		public unsafe UTimelineComponent 轮廓强度
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_2_7_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_2_7_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17005A50 RID: 23120
		// (get) Token: 0x06026F81 RID: 159617 RVA: 0x009E6C89 File Offset: 0x009E4E89
		// (set) Token: 0x06026F82 RID: 159618 RVA: 0x009E6C99 File Offset: 0x009E4E99
		public unsafe float ______NewTrack_0_54592E184B553C57485F69996828A3B7
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17005A51 RID: 23121
		// (get) Token: 0x06026F83 RID: 159619 RVA: 0x009E6CAA File Offset: 0x009E4EAA
		// (set) Token: 0x06026F84 RID: 159620 RVA: 0x009E6CBE File Offset: 0x009E4EBE
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> _______Direction_54592E184B553C57485F69996828A3B7
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_13);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17005A52 RID: 23122
		// (get) Token: 0x06026F85 RID: 159621 RVA: 0x009E6CD3 File Offset: 0x009E4ED3
		// (set) Token: 0x06026F86 RID: 159622 RVA: 0x009E6CE7 File Offset: 0x009E4EE7
		public unsafe UTimelineComponent 扫描带强度
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_2_7_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_2_7_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17005A53 RID: 23123
		// (get) Token: 0x06026F87 RID: 159623 RVA: 0x009E6CFC File Offset: 0x009E4EFC
		// (set) Token: 0x06026F88 RID: 159624 RVA: 0x009E6D0C File Offset: 0x009E4F0C
		public unsafe float _____NewTrack_0_DA519B584841DBEF7DB959A666386E51
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17005A54 RID: 23124
		// (get) Token: 0x06026F89 RID: 159625 RVA: 0x009E6D1D File Offset: 0x009E4F1D
		// (set) Token: 0x06026F8A RID: 159626 RVA: 0x009E6D31 File Offset: 0x009E4F31
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> ______Direction_DA519B584841DBEF7DB959A666386E51
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_16);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17005A55 RID: 23125
		// (get) Token: 0x06026F8B RID: 159627 RVA: 0x009E6D46 File Offset: 0x009E4F46
		// (set) Token: 0x06026F8C RID: 159628 RVA: 0x009E6D5A File Offset: 0x009E4F5A
		public unsafe UTimelineComponent 扫描范围
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_2_7_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_2_7_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17005A56 RID: 23126
		// (get) Token: 0x06026F8D RID: 159629 RVA: 0x009E6D6F File Offset: 0x009E4F6F
		// (set) Token: 0x06026F8E RID: 159630 RVA: 0x009E6D83 File Offset: 0x009E4F83
		public unsafe UMaterialInterface ScanMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_2_7_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_2_7_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17005A57 RID: 23127
		// (get) Token: 0x06026F8F RID: 159631 RVA: 0x009E6D98 File Offset: 0x009E4F98
		// (set) Token: 0x06026F90 RID: 159632 RVA: 0x009E6DA8 File Offset: 0x009E4FA8
		public unsafe bool 反向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005A58 RID: 23128
		// (get) Token: 0x06026F91 RID: 159633 RVA: 0x009E6DB9 File Offset: 0x009E4FB9
		// (set) Token: 0x06026F92 RID: 159634 RVA: 0x009E6DC9 File Offset: 0x009E4FC9
		public unsafe float Play_Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17005A59 RID: 23129
		// (get) Token: 0x06026F93 RID: 159635 RVA: 0x009E6DDA File Offset: 0x009E4FDA
		// (set) Token: 0x06026F94 RID: 159636 RVA: 0x009E6DEE File Offset: 0x009E4FEE
		public unsafe UMaterialInstanceDynamic ScanMaterialMID
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_2_7_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Scanning_2_7_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17005A5A RID: 23130
		// (get) Token: 0x06026F95 RID: 159637 RVA: 0x009E6E03 File Offset: 0x009E5003
		// (set) Token: 0x06026F96 RID: 159638 RVA: 0x009E6E13 File Offset: 0x009E5013
		public unsafe float PlaySpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17005A5B RID: 23131
		// (get) Token: 0x06026F97 RID: 159639 RVA: 0x009E6E24 File Offset: 0x009E5024
		// (set) Token: 0x06026F98 RID: 159640 RVA: 0x009E6E34 File Offset: 0x009E5034
		public unsafe bool StartTicking
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005A5C RID: 23132
		// (get) Token: 0x06026F99 RID: 159641 RVA: 0x009E6E45 File Offset: 0x009E5045
		// (set) Token: 0x06026F9A RID: 159642 RVA: 0x009E6E55 File Offset: 0x009E5055
		public unsafe bool IsUsedForSeq
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005A5D RID: 23133
		// (get) Token: 0x06026F9B RID: 159643 RVA: 0x009E6E66 File Offset: 0x009E5066
		// (set) Token: 0x06026F9C RID: 159644 RVA: 0x009E6E76 File Offset: 0x009E5076
		public unsafe float SeqLifeCycle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Scanning_2_7_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x06026F9D RID: 159645 RVA: 0x009E6E87 File Offset: 0x009E5087
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartScanEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_2_7_C.__StartScanEffect_NativeFunctionPtr, null);
		}

		// Token: 0x06026F9E RID: 159646 RVA: 0x009E6E9B File Offset: 0x009E509B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetRevert()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_2_7_C.__SetRevert_NativeFunctionPtr, null);
		}

		// Token: 0x06026F9F RID: 159647 RVA: 0x009E6EAF File Offset: 0x009E50AF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 扫描范围__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_2_7_C.__扫描范围__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026FA0 RID: 159648 RVA: 0x009E6EC3 File Offset: 0x009E50C3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 扫描范围__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_2_7_C.__扫描范围__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026FA1 RID: 159649 RVA: 0x009E6ED7 File Offset: 0x009E50D7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 扫描带强度__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_2_7_C.__扫描带强度__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026FA2 RID: 159650 RVA: 0x009E6EEB File Offset: 0x009E50EB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 扫描带强度__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_2_7_C.__扫描带强度__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026FA3 RID: 159651 RVA: 0x009E6EFF File Offset: 0x009E50FF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 轮廓强度__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_2_7_C.__轮廓强度__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026FA4 RID: 159652 RVA: 0x009E6F13 File Offset: 0x009E5113
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 轮廓强度__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_2_7_C.__轮廓强度__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026FA5 RID: 159653 RVA: 0x009E6F27 File Offset: 0x009E5127
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 衰退范围__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_2_7_C.__衰退范围__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026FA6 RID: 159654 RVA: 0x009E6F3B File Offset: 0x009E513B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 衰退范围__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_2_7_C.__衰退范围__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026FA7 RID: 159655 RVA: 0x009E6F4F File Offset: 0x009E514F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_0__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_2_7_C.__Timeline_0__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026FA8 RID: 159656 RVA: 0x009E6F63 File Offset: 0x009E5163
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_0__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_2_7_C.__Timeline_0__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06026FA9 RID: 159657 RVA: 0x009E6F78 File Offset: 0x009E5178
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Fx_Scanning_2_7_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Fx_Scanning_2_7_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Fx_Scanning_2_7_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_Scanning_2_7_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_2_7_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026FAA RID: 159658 RVA: 0x009E6FC0 File Offset: 0x009E51C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Fx_Scanning_2_7_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Fx_Scanning_2_7_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Fx_Scanning_2_7_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_Scanning_2_7_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Fx_Scanning_2_7_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026FAB RID: 159659 RVA: 0x009E7007 File Offset: 0x009E5207
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Scanning_2_7_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06026FAC RID: 159660 RVA: 0x009E701B File Offset: 0x009E521B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Fx_Scanning_2_7_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06026FAD RID: 159661 RVA: 0x009E7030 File Offset: 0x009E5230
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Fx_Scanning_2_7(int EntryPoint)
		{
			BP_Fx_Scanning_2_7_C.__ExecuteUbergraph_BP_Fx_Scanning_2_7_FunctionParams* ptr = stackalloc BP_Fx_Scanning_2_7_C.__ExecuteUbergraph_BP_Fx_Scanning_2_7_FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(BP_Fx_Scanning_2_7_C.__ExecuteUbergraph_BP_Fx_Scanning_2_7_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_Scanning_2_7_C.__ExecuteUbergraph_BP_Fx_Scanning_2_7_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Fx_Scanning_2_7_C.__ExecuteUbergraph_BP_Fx_Scanning_2_7_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026FAE RID: 159662 RVA: 0x009E7077 File Offset: 0x009E5277
		protected BP_Fx_Scanning_2_7_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401457C RID: 83324
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_Fx_Scanning_2_7.BP_Fx_Scanning_2_7_C";

		// Token: 0x0401457D RID: 83325
		private static IntPtr _ClassPtr;

		// Token: 0x0401457E RID: 83326
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401457F RID: 83327
		internal static int __PropertyOffset_0;

		// Token: 0x04014580 RID: 83328
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04014581 RID: 83329
		internal static int __PropertyOffset_1;

		// Token: 0x04014582 RID: 83330
		internal static int __PropertyOffset_2;

		// Token: 0x04014583 RID: 83331
		internal static int __PropertyOffset_3;

		// Token: 0x04014584 RID: 83332
		internal static int __PropertyOffset_4;

		// Token: 0x04014585 RID: 83333
		internal static int __PropertyOffset_5;

		// Token: 0x04014586 RID: 83334
		internal static int __PropertyOffset_6;

		// Token: 0x04014587 RID: 83335
		internal static int __PropertyOffset_7;

		// Token: 0x04014588 RID: 83336
		internal static int __PropertyOffset_8;

		// Token: 0x04014589 RID: 83337
		internal static int __PropertyOffset_9;

		// Token: 0x0401458A RID: 83338
		internal static int __PropertyOffset_10;

		// Token: 0x0401458B RID: 83339
		internal static int __PropertyOffset_11;

		// Token: 0x0401458C RID: 83340
		internal static int __PropertyOffset_12;

		// Token: 0x0401458D RID: 83341
		internal static int __PropertyOffset_13;

		// Token: 0x0401458E RID: 83342
		internal static int __PropertyOffset_14;

		// Token: 0x0401458F RID: 83343
		internal static int __PropertyOffset_15;

		// Token: 0x04014590 RID: 83344
		internal static int __PropertyOffset_16;

		// Token: 0x04014591 RID: 83345
		internal static int __PropertyOffset_17;

		// Token: 0x04014592 RID: 83346
		internal static int __PropertyOffset_18;

		// Token: 0x04014593 RID: 83347
		internal static int __PropertyOffset_19;

		// Token: 0x04014594 RID: 83348
		internal static int __PropertyOffset_20;

		// Token: 0x04014595 RID: 83349
		internal static int __PropertyOffset_21;

		// Token: 0x04014596 RID: 83350
		internal static int __PropertyOffset_22;

		// Token: 0x04014597 RID: 83351
		internal static int __PropertyOffset_23;

		// Token: 0x04014598 RID: 83352
		internal static int __PropertyOffset_24;

		// Token: 0x04014599 RID: 83353
		internal static int __PropertyOffset_25;

		// Token: 0x0401459A RID: 83354
		private static IntPtr __StartScanEffect_NativeFunctionPtr;

		// Token: 0x0401459B RID: 83355
		private static IntPtr __SetRevert_NativeFunctionPtr;

		// Token: 0x0401459C RID: 83356
		private static IntPtr __扫描范围__FinishedFunc_NativeFunctionPtr;

		// Token: 0x0401459D RID: 83357
		private static IntPtr __扫描范围__UpdateFunc_NativeFunctionPtr;

		// Token: 0x0401459E RID: 83358
		private static IntPtr __扫描带强度__FinishedFunc_NativeFunctionPtr;

		// Token: 0x0401459F RID: 83359
		private static IntPtr __扫描带强度__UpdateFunc_NativeFunctionPtr;

		// Token: 0x040145A0 RID: 83360
		private static IntPtr __轮廓强度__FinishedFunc_NativeFunctionPtr;

		// Token: 0x040145A1 RID: 83361
		private static IntPtr __轮廓强度__UpdateFunc_NativeFunctionPtr;

		// Token: 0x040145A2 RID: 83362
		private static IntPtr __衰退范围__FinishedFunc_NativeFunctionPtr;

		// Token: 0x040145A3 RID: 83363
		private static IntPtr __衰退范围__UpdateFunc_NativeFunctionPtr;

		// Token: 0x040145A4 RID: 83364
		private static IntPtr __Timeline_0__FinishedFunc_NativeFunctionPtr;

		// Token: 0x040145A5 RID: 83365
		private static IntPtr __Timeline_0__UpdateFunc_NativeFunctionPtr;

		// Token: 0x040145A6 RID: 83366
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040145A7 RID: 83367
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040145A8 RID: 83368
		private static IntPtr __ExecuteUbergraph_BP_Fx_Scanning_2_7_NativeFunctionPtr;

		// Token: 0x0200A0C8 RID: 41160
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032D7C RID: 208252
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A0C9 RID: 41161
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __ExecuteUbergraph_BP_Fx_Scanning_2_7_FunctionParams
		{
			// Token: 0x04032D7D RID: 208253
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
