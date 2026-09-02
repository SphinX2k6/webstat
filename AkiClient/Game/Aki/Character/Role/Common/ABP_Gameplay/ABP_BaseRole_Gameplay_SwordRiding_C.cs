using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.ABP_Gameplay
{
	// Token: 0x02004071 RID: 16497
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/ABP_Gameplay/ABP_BaseRole_Gameplay_SwordRiding.ABP_BaseRole_Gameplay_SwordRiding_C")]
	[UnrealStructLayout(3888, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 3873)]
	public class ABP_BaseRole_Gameplay_SwordRiding_C : UKuroAnimInstance, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AD90 RID: 175504 RVA: 0x00A67070 File Offset: 0x00A65270
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_BaseRole_Gameplay_SwordRiding_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/ABP_Gameplay/ABP_BaseRole_Gameplay_SwordRiding.ABP_BaseRole_Gameplay_SwordRiding_C");
			}
			return ABP_BaseRole_Gameplay_SwordRiding_C._ClassPtr;
		}

		// Token: 0x0602AD91 RID: 175505 RVA: 0x00A67094 File Offset: 0x00A65294
		public ABP_BaseRole_Gameplay_SwordRiding_C() : this(BuiltinUtils.AllocNativeUObject(ABP_BaseRole_Gameplay_SwordRiding_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AD92 RID: 175506 RVA: 0x00A670BC File Offset: 0x00A652BC
		public ABP_BaseRole_Gameplay_SwordRiding_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_BaseRole_Gameplay_SwordRiding_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006FEA RID: 28650
		// (get) Token: 0x0602AD93 RID: 175507 RVA: 0x00A670F0 File Offset: 0x00A652F0
		// (set) Token: 0x0602AD94 RID: 175508 RVA: 0x00A67129 File Offset: 0x00A65329
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FEB RID: 28651
		// (get) Token: 0x0602AD95 RID: 175509 RVA: 0x00A6714C File Offset: 0x00A6534C
		// (set) Token: 0x0602AD96 RID: 175510 RVA: 0x00A67185 File Offset: 0x00A65385
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FEC RID: 28652
		// (get) Token: 0x0602AD97 RID: 175511 RVA: 0x00A671A8 File Offset: 0x00A653A8
		// (set) Token: 0x0602AD98 RID: 175512 RVA: 0x00A671E1 File Offset: 0x00A653E1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_2) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_2 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FED RID: 28653
		// (get) Token: 0x0602AD99 RID: 175513 RVA: 0x00A67204 File Offset: 0x00A65404
		// (set) Token: 0x0602AD9A RID: 175514 RVA: 0x00A6723D File Offset: 0x00A6543D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_1) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_1 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FEE RID: 28654
		// (get) Token: 0x0602AD9B RID: 175515 RVA: 0x00A67260 File Offset: 0x00A65460
		// (set) Token: 0x0602AD9C RID: 175516 RVA: 0x00A67299 File Offset: 0x00A65499
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult) == null)
				{
					result = (this._AnimGraphNode_TransitionResult = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FEF RID: 28655
		// (get) Token: 0x0602AD9D RID: 175517 RVA: 0x00A672BC File Offset: 0x00A654BC
		// (set) Token: 0x0602AD9E RID: 175518 RVA: 0x00A672F5 File Offset: 0x00A654F5
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FF0 RID: 28656
		// (get) Token: 0x0602AD9F RID: 175519 RVA: 0x00A67318 File Offset: 0x00A65518
		// (set) Token: 0x0602ADA0 RID: 175520 RVA: 0x00A67351 File Offset: 0x00A65551
		public FAnimNode_StateResult AnimGraphNode_StateResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_2) == null)
				{
					result = (this._AnimGraphNode_StateResult_2 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FF1 RID: 28657
		// (get) Token: 0x0602ADA1 RID: 175521 RVA: 0x00A67374 File Offset: 0x00A65574
		// (set) Token: 0x0602ADA2 RID: 175522 RVA: 0x00A673AD File Offset: 0x00A655AD
		public FAnimNode_StateResult AnimGraphNode_StateResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_1) == null)
				{
					result = (this._AnimGraphNode_StateResult_1 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FF2 RID: 28658
		// (get) Token: 0x0602ADA3 RID: 175523 RVA: 0x00A673D0 File Offset: 0x00A655D0
		// (set) Token: 0x0602ADA4 RID: 175524 RVA: 0x00A67409 File Offset: 0x00A65609
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FF3 RID: 28659
		// (get) Token: 0x0602ADA5 RID: 175525 RVA: 0x00A6742C File Offset: 0x00A6562C
		// (set) Token: 0x0602ADA6 RID: 175526 RVA: 0x00A67465 File Offset: 0x00A65665
		public FAnimNode_StateResult AnimGraphNode_StateResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult) == null)
				{
					result = (this._AnimGraphNode_StateResult = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FF4 RID: 28660
		// (get) Token: 0x0602ADA7 RID: 175527 RVA: 0x00A67488 File Offset: 0x00A65688
		// (set) Token: 0x0602ADA8 RID: 175528 RVA: 0x00A674C1 File Offset: 0x00A656C1
		public FAnimNode_StateMachine AnimGraphNode_StateMachine
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine) == null)
				{
					result = (this._AnimGraphNode_StateMachine = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FF5 RID: 28661
		// (get) Token: 0x0602ADA9 RID: 175529 RVA: 0x00A674E2 File Offset: 0x00A656E2
		// (set) Token: 0x0602ADAA RID: 175530 RVA: 0x00A674F6 File Offset: 0x00A656F6
		[Nullable(2)]
		public unsafe TsBaseCharacter 角色蓝图
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_11);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17006FF6 RID: 28662
		// (get) Token: 0x0602ADAB RID: 175531 RVA: 0x00A6750B File Offset: 0x00A6570B
		// (set) Token: 0x0602ADAC RID: 175532 RVA: 0x00A6751F File Offset: 0x00A6571F
		[Nullable(2)]
		public unsafe UKuroAnimInstanceRole Kuro_Anim_Instance_Role
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroAnimInstanceRole>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_12);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17006FF7 RID: 28663
		// (get) Token: 0x0602ADAD RID: 175533 RVA: 0x00A67534 File Offset: 0x00A65734
		// (set) Token: 0x0602ADAE RID: 175534 RVA: 0x00A67544 File Offset: 0x00A65744
		public unsafe bool Start
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SwordRiding_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602ADAF RID: 175535 RVA: 0x00A67558 File Offset: 0x00A65758
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_BaseRole_Gameplay_SwordRiding_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_BaseRole_Gameplay_SwordRiding_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_BaseRole_Gameplay_SwordRiding_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_Gameplay_SwordRiding_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_SwordRiding_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0602ADB0 RID: 175536 RVA: 0x00A675DF File Offset: 0x00A657DF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SwordRiding_AnimGraphNode_BlendSpacePlayer_DEB854AC425775EDFC4C9C8B297CD4AE()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_SwordRiding_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SwordRiding_AnimGraphNode_BlendSpacePlayer_DEB854AC425775EDFC4C9C8B297CD4AE_NativeFunctionPtr, null);
		}

		// Token: 0x0602ADB1 RID: 175537 RVA: 0x00A675F3 File Offset: 0x00A657F3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SwordRiding_AnimGraphNode_TransitionResult_79672FCE480E2D4ED1E630A14EC0F327()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_SwordRiding_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SwordRiding_AnimGraphNode_TransitionResult_79672FCE480E2D4ED1E630A14EC0F327_NativeFunctionPtr, null);
		}

		// Token: 0x0602ADB2 RID: 175538 RVA: 0x00A67607 File Offset: 0x00A65807
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SwordRiding_AnimGraphNode_TransitionResult_FBE70FE049F6025CD16966B7E4165E8D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_SwordRiding_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SwordRiding_AnimGraphNode_TransitionResult_FBE70FE049F6025CD16966B7E4165E8D_NativeFunctionPtr, null);
		}

		// Token: 0x0602ADB3 RID: 175539 RVA: 0x00A6761B File Offset: 0x00A6581B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SwordRiding_AnimGraphNode_TransitionResult_8C1895BE46699906FDE3C8A549FB806D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_SwordRiding_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SwordRiding_AnimGraphNode_TransitionResult_8C1895BE46699906FDE3C8A549FB806D_NativeFunctionPtr, null);
		}

		// Token: 0x0602ADB4 RID: 175540 RVA: 0x00A6762F File Offset: 0x00A6582F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BlueprintInitializeAnimation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_SwordRiding_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null);
		}

		// Token: 0x0602ADB5 RID: 175541 RVA: 0x00A67643 File Offset: 0x00A65843
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BlueprintInitializeAnimation_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseRole_Gameplay_SwordRiding_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602ADB6 RID: 175542 RVA: 0x00A67658 File Offset: 0x00A65858
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_BaseRole_Gameplay_SwordRiding(int EntryPoint)
		{
			ABP_BaseRole_Gameplay_SwordRiding_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_SwordRiding_FunctionParams* ptr = stackalloc ABP_BaseRole_Gameplay_SwordRiding_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_SwordRiding_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(ABP_BaseRole_Gameplay_SwordRiding_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_SwordRiding_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_Gameplay_SwordRiding_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_SwordRiding_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseRole_Gameplay_SwordRiding_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_SwordRiding_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602ADB7 RID: 175543 RVA: 0x00A6769F File Offset: 0x00A6589F
		protected ABP_BaseRole_Gameplay_SwordRiding_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017642 RID: 95810
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/ABP_Gameplay/ABP_BaseRole_Gameplay_SwordRiding.ABP_BaseRole_Gameplay_SwordRiding_C";

		// Token: 0x04017643 RID: 95811
		private static IntPtr _ClassPtr;

		// Token: 0x04017644 RID: 95812
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017645 RID: 95813
		internal static int __PropertyOffset_0;

		// Token: 0x04017646 RID: 95814
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017647 RID: 95815
		internal static int __PropertyOffset_1;

		// Token: 0x04017648 RID: 95816
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x04017649 RID: 95817
		internal static int __PropertyOffset_2;

		// Token: 0x0401764A RID: 95818
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_2;

		// Token: 0x0401764B RID: 95819
		internal static int __PropertyOffset_3;

		// Token: 0x0401764C RID: 95820
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_1;

		// Token: 0x0401764D RID: 95821
		internal static int __PropertyOffset_4;

		// Token: 0x0401764E RID: 95822
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult;

		// Token: 0x0401764F RID: 95823
		internal static int __PropertyOffset_5;

		// Token: 0x04017650 RID: 95824
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x04017651 RID: 95825
		internal static int __PropertyOffset_6;

		// Token: 0x04017652 RID: 95826
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_2;

		// Token: 0x04017653 RID: 95827
		internal static int __PropertyOffset_7;

		// Token: 0x04017654 RID: 95828
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_1;

		// Token: 0x04017655 RID: 95829
		internal static int __PropertyOffset_8;

		// Token: 0x04017656 RID: 95830
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer;

		// Token: 0x04017657 RID: 95831
		internal static int __PropertyOffset_9;

		// Token: 0x04017658 RID: 95832
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult;

		// Token: 0x04017659 RID: 95833
		internal static int __PropertyOffset_10;

		// Token: 0x0401765A RID: 95834
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine;

		// Token: 0x0401765B RID: 95835
		internal static int __PropertyOffset_11;

		// Token: 0x0401765C RID: 95836
		internal static int __PropertyOffset_12;

		// Token: 0x0401765D RID: 95837
		internal static int __PropertyOffset_13;

		// Token: 0x0401765E RID: 95838
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x0401765F RID: 95839
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SwordRiding_AnimGraphNode_BlendSpacePlayer_DEB854AC425775EDFC4C9C8B297CD4AE_NativeFunctionPtr;

		// Token: 0x04017660 RID: 95840
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SwordRiding_AnimGraphNode_TransitionResult_79672FCE480E2D4ED1E630A14EC0F327_NativeFunctionPtr;

		// Token: 0x04017661 RID: 95841
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SwordRiding_AnimGraphNode_TransitionResult_FBE70FE049F6025CD16966B7E4165E8D_NativeFunctionPtr;

		// Token: 0x04017662 RID: 95842
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SwordRiding_AnimGraphNode_TransitionResult_8C1895BE46699906FDE3C8A549FB806D_NativeFunctionPtr;

		// Token: 0x04017663 RID: 95843
		private static IntPtr __BlueprintInitializeAnimation_NativeFunctionPtr;

		// Token: 0x04017664 RID: 95844
		private static IntPtr __ExecuteUbergraph_ABP_BaseRole_Gameplay_SwordRiding_NativeFunctionPtr;

		// Token: 0x0200A265 RID: 41573
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x0403300F RID: 208911
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A266 RID: 41574
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __ExecuteUbergraph_ABP_BaseRole_Gameplay_SwordRiding_FunctionParams
		{
			// Token: 0x04033010 RID: 208912
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
