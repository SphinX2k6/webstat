using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Weapon.Prop.Huaxiangsan
{
	// Token: 0x02003F88 RID: 16264
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Weapon/Prop/Huaxiangsan/ABP_ParaglidingBase.ABP_ParaglidingBase_C")]
	[UnrealStructLayout(3632, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 3628)]
	public class ABP_ParaglidingBase_C : UAnimInstance, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028AE0 RID: 166624 RVA: 0x00A12689 File Offset: 0x00A10889
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_ParaglidingBase_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Weapon/Prop/Huaxiangsan/ABP_ParaglidingBase.ABP_ParaglidingBase_C");
			}
			return ABP_ParaglidingBase_C._ClassPtr;
		}

		// Token: 0x06028AE1 RID: 166625 RVA: 0x00A126B0 File Offset: 0x00A108B0
		public ABP_ParaglidingBase_C() : this(BuiltinUtils.AllocNativeUObject(ABP_ParaglidingBase_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028AE2 RID: 166626 RVA: 0x00A126D8 File Offset: 0x00A108D8
		public ABP_ParaglidingBase_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_ParaglidingBase_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700636C RID: 25452
		// (get) Token: 0x06028AE3 RID: 166627 RVA: 0x00A1270C File Offset: 0x00A1090C
		// (set) Token: 0x06028AE4 RID: 166628 RVA: 0x00A12745 File Offset: 0x00A10945
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700636D RID: 25453
		// (get) Token: 0x06028AE5 RID: 166629 RVA: 0x00A12768 File Offset: 0x00A10968
		// (set) Token: 0x06028AE6 RID: 166630 RVA: 0x00A127A1 File Offset: 0x00A109A1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_5) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_5 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700636E RID: 25454
		// (get) Token: 0x06028AE7 RID: 166631 RVA: 0x00A127C4 File Offset: 0x00A109C4
		// (set) Token: 0x06028AE8 RID: 166632 RVA: 0x00A127FD File Offset: 0x00A109FD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_4) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_4 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700636F RID: 25455
		// (get) Token: 0x06028AE9 RID: 166633 RVA: 0x00A12820 File Offset: 0x00A10A20
		// (set) Token: 0x06028AEA RID: 166634 RVA: 0x00A12859 File Offset: 0x00A10A59
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_3) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_3 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006370 RID: 25456
		// (get) Token: 0x06028AEB RID: 166635 RVA: 0x00A1287C File Offset: 0x00A10A7C
		// (set) Token: 0x06028AEC RID: 166636 RVA: 0x00A128B5 File Offset: 0x00A10AB5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_2) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_2 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006371 RID: 25457
		// (get) Token: 0x06028AED RID: 166637 RVA: 0x00A128D8 File Offset: 0x00A10AD8
		// (set) Token: 0x06028AEE RID: 166638 RVA: 0x00A12911 File Offset: 0x00A10B11
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_1) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_1 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006372 RID: 25458
		// (get) Token: 0x06028AEF RID: 166639 RVA: 0x00A12934 File Offset: 0x00A10B34
		// (set) Token: 0x06028AF0 RID: 166640 RVA: 0x00A1296D File Offset: 0x00A10B6D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult) == null)
				{
					result = (this._AnimGraphNode_TransitionResult = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006373 RID: 25459
		// (get) Token: 0x06028AF1 RID: 166641 RVA: 0x00A12990 File Offset: 0x00A10B90
		// (set) Token: 0x06028AF2 RID: 166642 RVA: 0x00A129C9 File Offset: 0x00A10BC9
		public FAnimNode_StateResult AnimGraphNode_StateResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_2) == null)
				{
					result = (this._AnimGraphNode_StateResult_2 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006374 RID: 25460
		// (get) Token: 0x06028AF3 RID: 166643 RVA: 0x00A129EC File Offset: 0x00A10BEC
		// (set) Token: 0x06028AF4 RID: 166644 RVA: 0x00A12A25 File Offset: 0x00A10C25
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006375 RID: 25461
		// (get) Token: 0x06028AF5 RID: 166645 RVA: 0x00A12A48 File Offset: 0x00A10C48
		// (set) Token: 0x06028AF6 RID: 166646 RVA: 0x00A12A81 File Offset: 0x00A10C81
		public FAnimNode_StateResult AnimGraphNode_StateResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_1) == null)
				{
					result = (this._AnimGraphNode_StateResult_1 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006376 RID: 25462
		// (get) Token: 0x06028AF7 RID: 166647 RVA: 0x00A12AA4 File Offset: 0x00A10CA4
		// (set) Token: 0x06028AF8 RID: 166648 RVA: 0x00A12ADD File Offset: 0x00A10CDD
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006377 RID: 25463
		// (get) Token: 0x06028AF9 RID: 166649 RVA: 0x00A12B00 File Offset: 0x00A10D00
		// (set) Token: 0x06028AFA RID: 166650 RVA: 0x00A12B39 File Offset: 0x00A10D39
		public FAnimNode_StateResult AnimGraphNode_StateResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult) == null)
				{
					result = (this._AnimGraphNode_StateResult = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006378 RID: 25464
		// (get) Token: 0x06028AFB RID: 166651 RVA: 0x00A12B5C File Offset: 0x00A10D5C
		// (set) Token: 0x06028AFC RID: 166652 RVA: 0x00A12B95 File Offset: 0x00A10D95
		public FAnimNode_StateMachine AnimGraphNode_StateMachine
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine) == null)
				{
					result = (this._AnimGraphNode_StateMachine = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006379 RID: 25465
		// (get) Token: 0x06028AFD RID: 166653 RVA: 0x00A12BB8 File Offset: 0x00A10DB8
		// (set) Token: 0x06028AFE RID: 166654 RVA: 0x00A12BF1 File Offset: 0x00A10DF1
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700637A RID: 25466
		// (get) Token: 0x06028AFF RID: 166655 RVA: 0x00A12C12 File Offset: 0x00A10E12
		// (set) Token: 0x06028B00 RID: 166656 RVA: 0x00A12C26 File Offset: 0x00A10E26
		[Nullable(2)]
		public unsafe TsBaseCharacter 角色蓝图
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_ParaglidingBase_C.__PropertyOffset_14);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_ParaglidingBase_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x1700637B RID: 25467
		// (get) Token: 0x06028B01 RID: 166657 RVA: 0x00A12C3B File Offset: 0x00A10E3B
		// (set) Token: 0x06028B02 RID: 166658 RVA: 0x00A12C4B File Offset: 0x00A10E4B
		public unsafe bool 开伞
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700637C RID: 25468
		// (get) Token: 0x06028B03 RID: 166659 RVA: 0x00A12C5C File Offset: 0x00A10E5C
		// (set) Token: 0x06028B04 RID: 166660 RVA: 0x00A12C70 File Offset: 0x00A10E70
		[Nullable(2)]
		public unsafe EffectModelGroup 消散特效
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<EffectModelGroup>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_ParaglidingBase_C.__PropertyOffset_16);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_ParaglidingBase_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x1700637D RID: 25469
		// (get) Token: 0x06028B05 RID: 166661 RVA: 0x00A12C85 File Offset: 0x00A10E85
		// (set) Token: 0x06028B06 RID: 166662 RVA: 0x00A12C95 File Offset: 0x00A10E95
		public unsafe bool 滑翔滞空
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700637E RID: 25470
		// (get) Token: 0x06028B07 RID: 166663 RVA: 0x00A12CA6 File Offset: 0x00A10EA6
		// (set) Token: 0x06028B08 RID: 166664 RVA: 0x00A12CB6 File Offset: 0x00A10EB6
		public unsafe bool 滑翔上升
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700637F RID: 25471
		// (get) Token: 0x06028B09 RID: 166665 RVA: 0x00A12CC7 File Offset: 0x00A10EC7
		// (set) Token: 0x06028B0A RID: 166666 RVA: 0x00A12CD7 File Offset: 0x00A10ED7
		public unsafe float 滑翔混合当前值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17006380 RID: 25472
		// (get) Token: 0x06028B0B RID: 166667 RVA: 0x00A12CE8 File Offset: 0x00A10EE8
		// (set) Token: 0x06028B0C RID: 166668 RVA: 0x00A12CF8 File Offset: 0x00A10EF8
		public unsafe float 滑翔混合目标值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17006381 RID: 25473
		// (get) Token: 0x06028B0D RID: 166669 RVA: 0x00A12D09 File Offset: 0x00A10F09
		// (set) Token: 0x06028B0E RID: 166670 RVA: 0x00A12D19 File Offset: 0x00A10F19
		public unsafe float 滑翔混合插值值速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17006382 RID: 25474
		// (get) Token: 0x06028B0F RID: 166671 RVA: 0x00A12D2A File Offset: 0x00A10F2A
		// (set) Token: 0x06028B10 RID: 166672 RVA: 0x00A12D3E File Offset: 0x00A10F3E
		public unsafe FVector 滑翔伞修正偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_ParaglidingBase_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x06028B11 RID: 166673 RVA: 0x00A12D54 File Offset: 0x00A10F54
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_ParaglidingBase_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_ParaglidingBase_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_ParaglidingBase_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_ParaglidingBase_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_ParaglidingBase_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x06028B12 RID: 166674 RVA: 0x00A12DDC File Offset: 0x00A10FDC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetDash(bool Dash)
		{
			ABP_ParaglidingBase_C.__SetDash_FunctionParams* ptr = stackalloc ABP_ParaglidingBase_C.__SetDash_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(ABP_ParaglidingBase_C.__SetDash_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_ParaglidingBase_C.__SetDash_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Dash = Dash;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_ParaglidingBase_C.__SetDash_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028B13 RID: 166675 RVA: 0x00A12E24 File Offset: 0x00A11024
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetHover(bool Hover)
		{
			ABP_ParaglidingBase_C.__SetHover_FunctionParams* ptr = stackalloc ABP_ParaglidingBase_C.__SetHover_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(ABP_ParaglidingBase_C.__SetHover_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_ParaglidingBase_C.__SetHover_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Hover = Hover;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_ParaglidingBase_C.__SetHover_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028B14 RID: 166676 RVA: 0x00A12E6C File Offset: 0x00A1106C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetOpenParagliding(bool bOpen)
		{
			ABP_ParaglidingBase_C.__SetOpenParagliding_FunctionParams* ptr = stackalloc ABP_ParaglidingBase_C.__SetOpenParagliding_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(ABP_ParaglidingBase_C.__SetOpenParagliding_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_ParaglidingBase_C.__SetOpenParagliding_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bOpen = bOpen;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_ParaglidingBase_C.__SetOpenParagliding_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028B15 RID: 166677 RVA: 0x00A12EB4 File Offset: 0x00A110B4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SyncAnim(ABP_ParaglidingBase_C Other)
		{
			ABP_ParaglidingBase_C.__SyncAnim_FunctionParams* ptr = stackalloc ABP_ParaglidingBase_C.__SyncAnim_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(ABP_ParaglidingBase_C.__SyncAnim_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_ParaglidingBase_C.__SyncAnim_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Other = ((Other != null) ? Other.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_ParaglidingBase_C.__SyncAnim_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028B16 RID: 166678 RVA: 0x00A12F09 File Offset: 0x00A11109
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_ParaglidingBase_AnimGraphNode_TransitionResult_A64E5D5C4CA3F0D40F80E095719CB0BC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_ParaglidingBase_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_ParaglidingBase_AnimGraphNode_TransitionResult_A64E5D5C4CA3F0D40F80E095719CB0BC_NativeFunctionPtr, null);
		}

		// Token: 0x06028B17 RID: 166679 RVA: 0x00A12F1D File Offset: 0x00A1111D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BlueprintInitializeAnimation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_ParaglidingBase_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null);
		}

		// Token: 0x06028B18 RID: 166680 RVA: 0x00A12F31 File Offset: 0x00A11131
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BlueprintInitializeAnimation_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_ParaglidingBase_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06028B19 RID: 166681 RVA: 0x00A12F48 File Offset: 0x00A11148
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void BlueprintUpdateAnimation(float DeltaTimeX)
		{
			ABP_ParaglidingBase_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_ParaglidingBase_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_ParaglidingBase_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_ParaglidingBase_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_ParaglidingBase_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028B1A RID: 166682 RVA: 0x00A12F90 File Offset: 0x00A11190
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BlueprintUpdateAnimation_Implementation(float DeltaTimeX)
		{
			ABP_ParaglidingBase_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_ParaglidingBase_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_ParaglidingBase_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_ParaglidingBase_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_ParaglidingBase_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028B1B RID: 166683 RVA: 0x00A12FD8 File Offset: 0x00A111D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_ParaglidingBase(int EntryPoint)
		{
			ABP_ParaglidingBase_C.__ExecuteUbergraph_ABP_ParaglidingBase_FunctionParams* ptr = stackalloc ABP_ParaglidingBase_C.__ExecuteUbergraph_ABP_ParaglidingBase_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(ABP_ParaglidingBase_C.__ExecuteUbergraph_ABP_ParaglidingBase_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_ParaglidingBase_C.__ExecuteUbergraph_ABP_ParaglidingBase_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_ParaglidingBase_C.__ExecuteUbergraph_ABP_ParaglidingBase_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028B1C RID: 166684 RVA: 0x00A1301F File Offset: 0x00A1121F
		protected ABP_ParaglidingBase_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401575D RID: 87901
		public new const string __ObjectPath = "/Game/Aki/Character/Weapon/Prop/Huaxiangsan/ABP_ParaglidingBase.ABP_ParaglidingBase_C";

		// Token: 0x0401575E RID: 87902
		private static IntPtr _ClassPtr;

		// Token: 0x0401575F RID: 87903
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015760 RID: 87904
		internal static int __PropertyOffset_0;

		// Token: 0x04015761 RID: 87905
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015762 RID: 87906
		internal static int __PropertyOffset_1;

		// Token: 0x04015763 RID: 87907
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_5;

		// Token: 0x04015764 RID: 87908
		internal static int __PropertyOffset_2;

		// Token: 0x04015765 RID: 87909
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_4;

		// Token: 0x04015766 RID: 87910
		internal static int __PropertyOffset_3;

		// Token: 0x04015767 RID: 87911
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_3;

		// Token: 0x04015768 RID: 87912
		internal static int __PropertyOffset_4;

		// Token: 0x04015769 RID: 87913
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_2;

		// Token: 0x0401576A RID: 87914
		internal static int __PropertyOffset_5;

		// Token: 0x0401576B RID: 87915
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_1;

		// Token: 0x0401576C RID: 87916
		internal static int __PropertyOffset_6;

		// Token: 0x0401576D RID: 87917
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult;

		// Token: 0x0401576E RID: 87918
		internal static int __PropertyOffset_7;

		// Token: 0x0401576F RID: 87919
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_2;

		// Token: 0x04015770 RID: 87920
		internal static int __PropertyOffset_8;

		// Token: 0x04015771 RID: 87921
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer;

		// Token: 0x04015772 RID: 87922
		internal static int __PropertyOffset_9;

		// Token: 0x04015773 RID: 87923
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_1;

		// Token: 0x04015774 RID: 87924
		internal static int __PropertyOffset_10;

		// Token: 0x04015775 RID: 87925
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x04015776 RID: 87926
		internal static int __PropertyOffset_11;

		// Token: 0x04015777 RID: 87927
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult;

		// Token: 0x04015778 RID: 87928
		internal static int __PropertyOffset_12;

		// Token: 0x04015779 RID: 87929
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine;

		// Token: 0x0401577A RID: 87930
		internal static int __PropertyOffset_13;

		// Token: 0x0401577B RID: 87931
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x0401577C RID: 87932
		internal static int __PropertyOffset_14;

		// Token: 0x0401577D RID: 87933
		internal static int __PropertyOffset_15;

		// Token: 0x0401577E RID: 87934
		internal static int __PropertyOffset_16;

		// Token: 0x0401577F RID: 87935
		internal static int __PropertyOffset_17;

		// Token: 0x04015780 RID: 87936
		internal static int __PropertyOffset_18;

		// Token: 0x04015781 RID: 87937
		internal static int __PropertyOffset_19;

		// Token: 0x04015782 RID: 87938
		internal static int __PropertyOffset_20;

		// Token: 0x04015783 RID: 87939
		internal static int __PropertyOffset_21;

		// Token: 0x04015784 RID: 87940
		internal static int __PropertyOffset_22;

		// Token: 0x04015785 RID: 87941
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x04015786 RID: 87942
		private static IntPtr __SetDash_NativeFunctionPtr;

		// Token: 0x04015787 RID: 87943
		private static IntPtr __SetHover_NativeFunctionPtr;

		// Token: 0x04015788 RID: 87944
		private static IntPtr __SetOpenParagliding_NativeFunctionPtr;

		// Token: 0x04015789 RID: 87945
		private static IntPtr __SyncAnim_NativeFunctionPtr;

		// Token: 0x0401578A RID: 87946
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_ParaglidingBase_AnimGraphNode_TransitionResult_A64E5D5C4CA3F0D40F80E095719CB0BC_NativeFunctionPtr;

		// Token: 0x0401578B RID: 87947
		private static IntPtr __BlueprintInitializeAnimation_NativeFunctionPtr;

		// Token: 0x0401578C RID: 87948
		private static IntPtr __BlueprintUpdateAnimation_NativeFunctionPtr;

		// Token: 0x0401578D RID: 87949
		private static IntPtr __ExecuteUbergraph_ABP_ParaglidingBase_NativeFunctionPtr;

		// Token: 0x0200A131 RID: 41265
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x04032E65 RID: 208485
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A132 RID: 41266
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __SetDash_FunctionParams
		{
			// Token: 0x04032E66 RID: 208486
			[FieldOffset(0)]
			public bool Dash;
		}

		// Token: 0x0200A133 RID: 41267
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __SetHover_FunctionParams
		{
			// Token: 0x04032E67 RID: 208487
			[FieldOffset(0)]
			public bool Hover;
		}

		// Token: 0x0200A134 RID: 41268
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __SetOpenParagliding_FunctionParams
		{
			// Token: 0x04032E68 RID: 208488
			[FieldOffset(0)]
			public bool bOpen;
		}

		// Token: 0x0200A135 RID: 41269
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __SyncAnim_FunctionParams
		{
			// Token: 0x04032E69 RID: 208489
			[FieldOffset(0)]
			public IntPtr Other;
		}

		// Token: 0x0200A136 RID: 41270
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __BlueprintUpdateAnimation_FunctionParams
		{
			// Token: 0x04032E6A RID: 208490
			[FieldOffset(0)]
			public float DeltaTimeX;
		}

		// Token: 0x0200A137 RID: 41271
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __ExecuteUbergraph_ABP_ParaglidingBase_FunctionParams
		{
			// Token: 0x04032E6B RID: 208491
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
