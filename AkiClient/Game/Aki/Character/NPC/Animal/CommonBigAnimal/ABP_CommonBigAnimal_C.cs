using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.CommonBigAnimal
{
	// Token: 0x02004196 RID: 16790
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/CommonBigAnimal/ABP_CommonBigAnimal.ABP_CommonBigAnimal_C")]
	[UnrealStructLayout(4288, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 4285)]
	public class ABP_CommonBigAnimal_C : UKuroAnimInstance, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C81B RID: 182299 RVA: 0x00AA417C File Offset: 0x00AA237C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_CommonBigAnimal_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/CommonBigAnimal/ABP_CommonBigAnimal.ABP_CommonBigAnimal_C");
			}
			return ABP_CommonBigAnimal_C._ClassPtr;
		}

		// Token: 0x0602C81C RID: 182300 RVA: 0x00AA41A0 File Offset: 0x00AA23A0
		public ABP_CommonBigAnimal_C() : this(BuiltinUtils.AllocNativeUObject(ABP_CommonBigAnimal_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C81D RID: 182301 RVA: 0x00AA41C8 File Offset: 0x00AA23C8
		public ABP_CommonBigAnimal_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_CommonBigAnimal_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170077B0 RID: 30640
		// (get) Token: 0x0602C81E RID: 182302 RVA: 0x00AA41FC File Offset: 0x00AA23FC
		// (set) Token: 0x0602C81F RID: 182303 RVA: 0x00AA4235 File Offset: 0x00AA2435
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077B1 RID: 30641
		// (get) Token: 0x0602C820 RID: 182304 RVA: 0x00AA4258 File Offset: 0x00AA2458
		// (set) Token: 0x0602C821 RID: 182305 RVA: 0x00AA4291 File Offset: 0x00AA2491
		public FAnimNode_Root AnimGraphNode_Root_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_1) == null)
				{
					result = (this._AnimGraphNode_Root_1 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077B2 RID: 30642
		// (get) Token: 0x0602C822 RID: 182306 RVA: 0x00AA42B4 File Offset: 0x00AA24B4
		// (set) Token: 0x0602C823 RID: 182307 RVA: 0x00AA42ED File Offset: 0x00AA24ED
		public FAnimNode_Slot AnimGraphNode_Slot
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot) == null)
				{
					result = (this._AnimGraphNode_Slot = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077B3 RID: 30643
		// (get) Token: 0x0602C824 RID: 182308 RVA: 0x00AA4310 File Offset: 0x00AA2510
		// (set) Token: 0x0602C825 RID: 182309 RVA: 0x00AA4349 File Offset: 0x00AA2549
		public FAnimNode_Inertialization AnimGraphNode_Inertialization
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Inertialization result;
				if ((result = this._AnimGraphNode_Inertialization) == null)
				{
					result = (this._AnimGraphNode_Inertialization = new FAnimNode_Inertialization(base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Inertialization.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077B4 RID: 30644
		// (get) Token: 0x0602C826 RID: 182310 RVA: 0x00AA436C File Offset: 0x00AA256C
		// (set) Token: 0x0602C827 RID: 182311 RVA: 0x00AA43A5 File Offset: 0x00AA25A5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_1) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_1 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077B5 RID: 30645
		// (get) Token: 0x0602C828 RID: 182312 RVA: 0x00AA43C8 File Offset: 0x00AA25C8
		// (set) Token: 0x0602C829 RID: 182313 RVA: 0x00AA4401 File Offset: 0x00AA2601
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult) == null)
				{
					result = (this._AnimGraphNode_TransitionResult = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077B6 RID: 30646
		// (get) Token: 0x0602C82A RID: 182314 RVA: 0x00AA4424 File Offset: 0x00AA2624
		// (set) Token: 0x0602C82B RID: 182315 RVA: 0x00AA445D File Offset: 0x00AA265D
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077B7 RID: 30647
		// (get) Token: 0x0602C82C RID: 182316 RVA: 0x00AA4480 File Offset: 0x00AA2680
		// (set) Token: 0x0602C82D RID: 182317 RVA: 0x00AA44B9 File Offset: 0x00AA26B9
		public FAnimNode_StateResult AnimGraphNode_StateResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_1) == null)
				{
					result = (this._AnimGraphNode_StateResult_1 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077B8 RID: 30648
		// (get) Token: 0x0602C82E RID: 182318 RVA: 0x00AA44DC File Offset: 0x00AA26DC
		// (set) Token: 0x0602C82F RID: 182319 RVA: 0x00AA4515 File Offset: 0x00AA2715
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077B9 RID: 30649
		// (get) Token: 0x0602C830 RID: 182320 RVA: 0x00AA4538 File Offset: 0x00AA2738
		// (set) Token: 0x0602C831 RID: 182321 RVA: 0x00AA4571 File Offset: 0x00AA2771
		public FAnimNode_StateResult AnimGraphNode_StateResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult) == null)
				{
					result = (this._AnimGraphNode_StateResult = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077BA RID: 30650
		// (get) Token: 0x0602C832 RID: 182322 RVA: 0x00AA4594 File Offset: 0x00AA2794
		// (set) Token: 0x0602C833 RID: 182323 RVA: 0x00AA45CD File Offset: 0x00AA27CD
		public FAnimNode_StateMachine AnimGraphNode_StateMachine
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine) == null)
				{
					result = (this._AnimGraphNode_StateMachine = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077BB RID: 30651
		// (get) Token: 0x0602C834 RID: 182324 RVA: 0x00AA45F0 File Offset: 0x00AA27F0
		// (set) Token: 0x0602C835 RID: 182325 RVA: 0x00AA4629 File Offset: 0x00AA2829
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077BC RID: 30652
		// (get) Token: 0x0602C836 RID: 182326 RVA: 0x00AA464C File Offset: 0x00AA284C
		// (set) Token: 0x0602C837 RID: 182327 RVA: 0x00AA4685 File Offset: 0x00AA2885
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077BD RID: 30653
		// (get) Token: 0x0602C838 RID: 182328 RVA: 0x00AA46A6 File Offset: 0x00AA28A6
		// (set) Token: 0x0602C839 RID: 182329 RVA: 0x00AA46B6 File Offset: 0x00AA28B6
		public unsafe float 走跑混合速度参数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170077BE RID: 30654
		// (get) Token: 0x0602C83A RID: 182330 RVA: 0x00AA46C7 File Offset: 0x00AA28C7
		// (set) Token: 0x0602C83B RID: 182331 RVA: 0x00AA46D7 File Offset: 0x00AA28D7
		public unsafe bool 是否有移动输入
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x170077BF RID: 30655
		// (get) Token: 0x0602C83C RID: 182332 RVA: 0x00AA46E8 File Offset: 0x00AA28E8
		// (set) Token: 0x0602C83D RID: 182333 RVA: 0x00AA46FC File Offset: 0x00AA28FC
		[Nullable(2)]
		public unsafe TsBaseCharacter 角色蓝图
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_CommonBigAnimal_C.__PropertyOffset_15);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_CommonBigAnimal_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x170077C0 RID: 30656
		// (get) Token: 0x0602C83E RID: 182334 RVA: 0x00AA4711 File Offset: 0x00AA2911
		// (set) Token: 0x0602C83F RID: 182335 RVA: 0x00AA4721 File Offset: 0x00AA2921
		public unsafe float 旋转剩余角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170077C1 RID: 30657
		// (get) Token: 0x0602C840 RID: 182336 RVA: 0x00AA4732 File Offset: 0x00AA2932
		// (set) Token: 0x0602C841 RID: 182337 RVA: 0x00AA4742 File Offset: 0x00AA2942
		public unsafe bool 是否有选转输入
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_CommonBigAnimal_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602C842 RID: 182338 RVA: 0x00AA4754 File Offset: 0x00AA2954
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 基础层(ref FPoseLink 基础层)
		{
			ABP_CommonBigAnimal_C.__基础层_FunctionParams* ptr = stackalloc ABP_CommonBigAnimal_C.__基础层_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_CommonBigAnimal_C.__基础层_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_CommonBigAnimal_C.__基础层_NativeFunctionPtr, (void*)ptr, 1);
			if (基础层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->基础层, 基础层.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_CommonBigAnimal_C.__基础层_NativeFunctionPtr, (void*)ptr);
			if (基础层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), 基础层.NativePtr, &ptr->基础层, 1, false);
			}
		}

		// Token: 0x0602C843 RID: 182339 RVA: 0x00AA47DC File Offset: 0x00AA29DC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_CommonBigAnimal_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_CommonBigAnimal_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_CommonBigAnimal_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_CommonBigAnimal_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_CommonBigAnimal_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0602C844 RID: 182340 RVA: 0x00AA4863 File Offset: 0x00AA2A63
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新旋转()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_CommonBigAnimal_C.__更新旋转_NativeFunctionPtr, null);
		}

		// Token: 0x0602C845 RID: 182341 RVA: 0x00AA4877 File Offset: 0x00AA2A77
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新角色移动()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_CommonBigAnimal_C.__更新角色移动_NativeFunctionPtr, null);
		}

		// Token: 0x0602C846 RID: 182342 RVA: 0x00AA488C File Offset: 0x00AA2A8C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void BlueprintUpdateAnimation(float DeltaTimeX)
		{
			ABP_CommonBigAnimal_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_CommonBigAnimal_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_CommonBigAnimal_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_CommonBigAnimal_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_CommonBigAnimal_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C847 RID: 182343 RVA: 0x00AA48D4 File Offset: 0x00AA2AD4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BlueprintUpdateAnimation_Implementation(float DeltaTimeX)
		{
			ABP_CommonBigAnimal_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_CommonBigAnimal_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_CommonBigAnimal_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_CommonBigAnimal_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_CommonBigAnimal_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C848 RID: 182344 RVA: 0x00AA491B File Offset: 0x00AA2B1B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BlueprintInitializeAnimation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_CommonBigAnimal_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null);
		}

		// Token: 0x0602C849 RID: 182345 RVA: 0x00AA492F File Offset: 0x00AA2B2F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BlueprintInitializeAnimation_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_CommonBigAnimal_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C84A RID: 182346 RVA: 0x00AA4944 File Offset: 0x00AA2B44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_CommonBigAnimal(int EntryPoint)
		{
			ABP_CommonBigAnimal_C.__ExecuteUbergraph_ABP_CommonBigAnimal_FunctionParams* ptr = stackalloc ABP_CommonBigAnimal_C.__ExecuteUbergraph_ABP_CommonBigAnimal_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(ABP_CommonBigAnimal_C.__ExecuteUbergraph_ABP_CommonBigAnimal_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_CommonBigAnimal_C.__ExecuteUbergraph_ABP_CommonBigAnimal_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_CommonBigAnimal_C.__ExecuteUbergraph_ABP_CommonBigAnimal_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C84B RID: 182347 RVA: 0x00AA498B File Offset: 0x00AA2B8B
		protected ABP_CommonBigAnimal_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018BBC RID: 101308
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/CommonBigAnimal/ABP_CommonBigAnimal.ABP_CommonBigAnimal_C";

		// Token: 0x04018BBD RID: 101309
		private static IntPtr _ClassPtr;

		// Token: 0x04018BBE RID: 101310
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018BBF RID: 101311
		internal static int __PropertyOffset_0;

		// Token: 0x04018BC0 RID: 101312
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04018BC1 RID: 101313
		internal static int __PropertyOffset_1;

		// Token: 0x04018BC2 RID: 101314
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_1;

		// Token: 0x04018BC3 RID: 101315
		internal static int __PropertyOffset_2;

		// Token: 0x04018BC4 RID: 101316
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot;

		// Token: 0x04018BC5 RID: 101317
		internal static int __PropertyOffset_3;

		// Token: 0x04018BC6 RID: 101318
		[Nullable(2)]
		private FAnimNode_Inertialization _AnimGraphNode_Inertialization;

		// Token: 0x04018BC7 RID: 101319
		internal static int __PropertyOffset_4;

		// Token: 0x04018BC8 RID: 101320
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_1;

		// Token: 0x04018BC9 RID: 101321
		internal static int __PropertyOffset_5;

		// Token: 0x04018BCA RID: 101322
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult;

		// Token: 0x04018BCB RID: 101323
		internal static int __PropertyOffset_6;

		// Token: 0x04018BCC RID: 101324
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer;

		// Token: 0x04018BCD RID: 101325
		internal static int __PropertyOffset_7;

		// Token: 0x04018BCE RID: 101326
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_1;

		// Token: 0x04018BCF RID: 101327
		internal static int __PropertyOffset_8;

		// Token: 0x04018BD0 RID: 101328
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x04018BD1 RID: 101329
		internal static int __PropertyOffset_9;

		// Token: 0x04018BD2 RID: 101330
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult;

		// Token: 0x04018BD3 RID: 101331
		internal static int __PropertyOffset_10;

		// Token: 0x04018BD4 RID: 101332
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine;

		// Token: 0x04018BD5 RID: 101333
		internal static int __PropertyOffset_11;

		// Token: 0x04018BD6 RID: 101334
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x04018BD7 RID: 101335
		internal static int __PropertyOffset_12;

		// Token: 0x04018BD8 RID: 101336
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer;

		// Token: 0x04018BD9 RID: 101337
		internal static int __PropertyOffset_13;

		// Token: 0x04018BDA RID: 101338
		internal static int __PropertyOffset_14;

		// Token: 0x04018BDB RID: 101339
		internal static int __PropertyOffset_15;

		// Token: 0x04018BDC RID: 101340
		internal static int __PropertyOffset_16;

		// Token: 0x04018BDD RID: 101341
		internal static int __PropertyOffset_17;

		// Token: 0x04018BDE RID: 101342
		private static IntPtr __基础层_NativeFunctionPtr;

		// Token: 0x04018BDF RID: 101343
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x04018BE0 RID: 101344
		private static IntPtr __更新旋转_NativeFunctionPtr;

		// Token: 0x04018BE1 RID: 101345
		private static IntPtr __更新角色移动_NativeFunctionPtr;

		// Token: 0x04018BE2 RID: 101346
		private static IntPtr __BlueprintUpdateAnimation_NativeFunctionPtr;

		// Token: 0x04018BE3 RID: 101347
		private static IntPtr __BlueprintInitializeAnimation_NativeFunctionPtr;

		// Token: 0x04018BE4 RID: 101348
		private static IntPtr __ExecuteUbergraph_ABP_CommonBigAnimal_NativeFunctionPtr;

		// Token: 0x0200A45A RID: 42074
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __基础层_FunctionParams
		{
			// Token: 0x0403325C RID: 209500
			[FieldOffset(0)]
			public byte 基础层;
		}

		// Token: 0x0200A45B RID: 42075
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x0403325D RID: 209501
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A45C RID: 42076
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __BlueprintUpdateAnimation_FunctionParams
		{
			// Token: 0x0403325E RID: 209502
			[FieldOffset(0)]
			public float DeltaTimeX;
		}

		// Token: 0x0200A45D RID: 42077
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __ExecuteUbergraph_ABP_CommonBigAnimal_FunctionParams
		{
			// Token: 0x0403325F RID: 209503
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
