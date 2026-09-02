using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.CommonSmallAnimal
{
	// Token: 0x02004190 RID: 16784
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/CommonSmallAnimal/ABP_CommonSmallAnimal.ABP_CommonSmallAnimal_C")]
	[UnrealStructLayout(4288, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 4280)]
	public class ABP_CommonSmallAnimal_C : UKuroAnimInstance, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C78D RID: 182157 RVA: 0x00AA28EC File Offset: 0x00AA0AEC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_CommonSmallAnimal_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/CommonSmallAnimal/ABP_CommonSmallAnimal.ABP_CommonSmallAnimal_C");
			}
			return ABP_CommonSmallAnimal_C._ClassPtr;
		}

		// Token: 0x0602C78E RID: 182158 RVA: 0x00AA2910 File Offset: 0x00AA0B10
		public ABP_CommonSmallAnimal_C() : this(BuiltinUtils.AllocNativeUObject(ABP_CommonSmallAnimal_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C78F RID: 182159 RVA: 0x00AA2938 File Offset: 0x00AA0B38
		public ABP_CommonSmallAnimal_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_CommonSmallAnimal_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700777F RID: 30591
		// (get) Token: 0x0602C790 RID: 182160 RVA: 0x00AA296C File Offset: 0x00AA0B6C
		// (set) Token: 0x0602C791 RID: 182161 RVA: 0x00AA29A5 File Offset: 0x00AA0BA5
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007780 RID: 30592
		// (get) Token: 0x0602C792 RID: 182162 RVA: 0x00AA29C8 File Offset: 0x00AA0BC8
		// (set) Token: 0x0602C793 RID: 182163 RVA: 0x00AA2A01 File Offset: 0x00AA0C01
		public FAnimNode_Root AnimGraphNode_Root_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_1) == null)
				{
					result = (this._AnimGraphNode_Root_1 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007781 RID: 30593
		// (get) Token: 0x0602C794 RID: 182164 RVA: 0x00AA2A24 File Offset: 0x00AA0C24
		// (set) Token: 0x0602C795 RID: 182165 RVA: 0x00AA2A5D File Offset: 0x00AA0C5D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_1) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_1 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007782 RID: 30594
		// (get) Token: 0x0602C796 RID: 182166 RVA: 0x00AA2A80 File Offset: 0x00AA0C80
		// (set) Token: 0x0602C797 RID: 182167 RVA: 0x00AA2AB9 File Offset: 0x00AA0CB9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult) == null)
				{
					result = (this._AnimGraphNode_TransitionResult = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007783 RID: 30595
		// (get) Token: 0x0602C798 RID: 182168 RVA: 0x00AA2ADC File Offset: 0x00AA0CDC
		// (set) Token: 0x0602C799 RID: 182169 RVA: 0x00AA2B15 File Offset: 0x00AA0D15
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007784 RID: 30596
		// (get) Token: 0x0602C79A RID: 182170 RVA: 0x00AA2B38 File Offset: 0x00AA0D38
		// (set) Token: 0x0602C79B RID: 182171 RVA: 0x00AA2B71 File Offset: 0x00AA0D71
		public FAnimNode_StateResult AnimGraphNode_StateResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_1) == null)
				{
					result = (this._AnimGraphNode_StateResult_1 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007785 RID: 30597
		// (get) Token: 0x0602C79C RID: 182172 RVA: 0x00AA2B94 File Offset: 0x00AA0D94
		// (set) Token: 0x0602C79D RID: 182173 RVA: 0x00AA2BCD File Offset: 0x00AA0DCD
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007786 RID: 30598
		// (get) Token: 0x0602C79E RID: 182174 RVA: 0x00AA2BF0 File Offset: 0x00AA0DF0
		// (set) Token: 0x0602C79F RID: 182175 RVA: 0x00AA2C29 File Offset: 0x00AA0E29
		public FAnimNode_StateResult AnimGraphNode_StateResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult) == null)
				{
					result = (this._AnimGraphNode_StateResult = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007787 RID: 30599
		// (get) Token: 0x0602C7A0 RID: 182176 RVA: 0x00AA2C4C File Offset: 0x00AA0E4C
		// (set) Token: 0x0602C7A1 RID: 182177 RVA: 0x00AA2C85 File Offset: 0x00AA0E85
		public FAnimNode_StateMachine AnimGraphNode_StateMachine
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine) == null)
				{
					result = (this._AnimGraphNode_StateMachine = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007788 RID: 30600
		// (get) Token: 0x0602C7A2 RID: 182178 RVA: 0x00AA2CA8 File Offset: 0x00AA0EA8
		// (set) Token: 0x0602C7A3 RID: 182179 RVA: 0x00AA2CE1 File Offset: 0x00AA0EE1
		public FAnimNode_Inertialization AnimGraphNode_Inertialization
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Inertialization result;
				if ((result = this._AnimGraphNode_Inertialization) == null)
				{
					result = (this._AnimGraphNode_Inertialization = new FAnimNode_Inertialization(base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Inertialization.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007789 RID: 30601
		// (get) Token: 0x0602C7A4 RID: 182180 RVA: 0x00AA2D04 File Offset: 0x00AA0F04
		// (set) Token: 0x0602C7A5 RID: 182181 RVA: 0x00AA2D3D File Offset: 0x00AA0F3D
		public FAnimNode_Slot AnimGraphNode_Slot
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot) == null)
				{
					result = (this._AnimGraphNode_Slot = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700778A RID: 30602
		// (get) Token: 0x0602C7A6 RID: 182182 RVA: 0x00AA2D60 File Offset: 0x00AA0F60
		// (set) Token: 0x0602C7A7 RID: 182183 RVA: 0x00AA2D99 File Offset: 0x00AA0F99
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700778B RID: 30603
		// (get) Token: 0x0602C7A8 RID: 182184 RVA: 0x00AA2DBC File Offset: 0x00AA0FBC
		// (set) Token: 0x0602C7A9 RID: 182185 RVA: 0x00AA2DF5 File Offset: 0x00AA0FF5
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700778C RID: 30604
		// (get) Token: 0x0602C7AA RID: 182186 RVA: 0x00AA2E16 File Offset: 0x00AA1016
		// (set) Token: 0x0602C7AB RID: 182187 RVA: 0x00AA2E2A File Offset: 0x00AA102A
		[Nullable(2)]
		public unsafe TsBaseCharacter 角色蓝图
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_CommonSmallAnimal_C.__PropertyOffset_13);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_CommonSmallAnimal_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x1700778D RID: 30605
		// (get) Token: 0x0602C7AC RID: 182188 RVA: 0x00AA2E3F File Offset: 0x00AA103F
		// (set) Token: 0x0602C7AD RID: 182189 RVA: 0x00AA2E4F File Offset: 0x00AA104F
		public unsafe bool 是否有移动输入
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700778E RID: 30606
		// (get) Token: 0x0602C7AE RID: 182190 RVA: 0x00AA2E60 File Offset: 0x00AA1060
		// (set) Token: 0x0602C7AF RID: 182191 RVA: 0x00AA2E70 File Offset: 0x00AA1070
		public unsafe float 走跑混合速度参数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_CommonSmallAnimal_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x0602C7B0 RID: 182192 RVA: 0x00AA2E84 File Offset: 0x00AA1084
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 基础层(ref FPoseLink 基础层)
		{
			ABP_CommonSmallAnimal_C.__基础层_FunctionParams* ptr = stackalloc ABP_CommonSmallAnimal_C.__基础层_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_CommonSmallAnimal_C.__基础层_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_CommonSmallAnimal_C.__基础层_NativeFunctionPtr, (void*)ptr, 1);
			if (基础层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->基础层, 基础层.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_CommonSmallAnimal_C.__基础层_NativeFunctionPtr, (void*)ptr);
			if (基础层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), 基础层.NativePtr, &ptr->基础层, 1, false);
			}
		}

		// Token: 0x0602C7B1 RID: 182193 RVA: 0x00AA2F0C File Offset: 0x00AA110C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_CommonSmallAnimal_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_CommonSmallAnimal_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_CommonSmallAnimal_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_CommonSmallAnimal_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_CommonSmallAnimal_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0602C7B2 RID: 182194 RVA: 0x00AA2F93 File Offset: 0x00AA1193
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新角色移动()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_CommonSmallAnimal_C.__更新角色移动_NativeFunctionPtr, null);
		}

		// Token: 0x0602C7B3 RID: 182195 RVA: 0x00AA2FA8 File Offset: 0x00AA11A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void BlueprintUpdateAnimation(float DeltaTimeX)
		{
			ABP_CommonSmallAnimal_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_CommonSmallAnimal_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_CommonSmallAnimal_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_CommonSmallAnimal_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_CommonSmallAnimal_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C7B4 RID: 182196 RVA: 0x00AA2FF0 File Offset: 0x00AA11F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BlueprintUpdateAnimation_Implementation(float DeltaTimeX)
		{
			ABP_CommonSmallAnimal_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_CommonSmallAnimal_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_CommonSmallAnimal_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_CommonSmallAnimal_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_CommonSmallAnimal_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C7B5 RID: 182197 RVA: 0x00AA3037 File Offset: 0x00AA1237
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BlueprintInitializeAnimation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_CommonSmallAnimal_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null);
		}

		// Token: 0x0602C7B6 RID: 182198 RVA: 0x00AA304B File Offset: 0x00AA124B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BlueprintInitializeAnimation_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_CommonSmallAnimal_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C7B7 RID: 182199 RVA: 0x00AA3060 File Offset: 0x00AA1260
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_CommonSmallAnimal(int EntryPoint)
		{
			ABP_CommonSmallAnimal_C.__ExecuteUbergraph_ABP_CommonSmallAnimal_FunctionParams* ptr = stackalloc ABP_CommonSmallAnimal_C.__ExecuteUbergraph_ABP_CommonSmallAnimal_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(ABP_CommonSmallAnimal_C.__ExecuteUbergraph_ABP_CommonSmallAnimal_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_CommonSmallAnimal_C.__ExecuteUbergraph_ABP_CommonSmallAnimal_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_CommonSmallAnimal_C.__ExecuteUbergraph_ABP_CommonSmallAnimal_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C7B8 RID: 182200 RVA: 0x00AA30A7 File Offset: 0x00AA12A7
		protected ABP_CommonSmallAnimal_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018B41 RID: 101185
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/CommonSmallAnimal/ABP_CommonSmallAnimal.ABP_CommonSmallAnimal_C";

		// Token: 0x04018B42 RID: 101186
		private static IntPtr _ClassPtr;

		// Token: 0x04018B43 RID: 101187
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018B44 RID: 101188
		internal static int __PropertyOffset_0;

		// Token: 0x04018B45 RID: 101189
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04018B46 RID: 101190
		internal static int __PropertyOffset_1;

		// Token: 0x04018B47 RID: 101191
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_1;

		// Token: 0x04018B48 RID: 101192
		internal static int __PropertyOffset_2;

		// Token: 0x04018B49 RID: 101193
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_1;

		// Token: 0x04018B4A RID: 101194
		internal static int __PropertyOffset_3;

		// Token: 0x04018B4B RID: 101195
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult;

		// Token: 0x04018B4C RID: 101196
		internal static int __PropertyOffset_4;

		// Token: 0x04018B4D RID: 101197
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer;

		// Token: 0x04018B4E RID: 101198
		internal static int __PropertyOffset_5;

		// Token: 0x04018B4F RID: 101199
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_1;

		// Token: 0x04018B50 RID: 101200
		internal static int __PropertyOffset_6;

		// Token: 0x04018B51 RID: 101201
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x04018B52 RID: 101202
		internal static int __PropertyOffset_7;

		// Token: 0x04018B53 RID: 101203
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult;

		// Token: 0x04018B54 RID: 101204
		internal static int __PropertyOffset_8;

		// Token: 0x04018B55 RID: 101205
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine;

		// Token: 0x04018B56 RID: 101206
		internal static int __PropertyOffset_9;

		// Token: 0x04018B57 RID: 101207
		[Nullable(2)]
		private FAnimNode_Inertialization _AnimGraphNode_Inertialization;

		// Token: 0x04018B58 RID: 101208
		internal static int __PropertyOffset_10;

		// Token: 0x04018B59 RID: 101209
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot;

		// Token: 0x04018B5A RID: 101210
		internal static int __PropertyOffset_11;

		// Token: 0x04018B5B RID: 101211
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x04018B5C RID: 101212
		internal static int __PropertyOffset_12;

		// Token: 0x04018B5D RID: 101213
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer;

		// Token: 0x04018B5E RID: 101214
		internal static int __PropertyOffset_13;

		// Token: 0x04018B5F RID: 101215
		internal static int __PropertyOffset_14;

		// Token: 0x04018B60 RID: 101216
		internal static int __PropertyOffset_15;

		// Token: 0x04018B61 RID: 101217
		private static IntPtr __基础层_NativeFunctionPtr;

		// Token: 0x04018B62 RID: 101218
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x04018B63 RID: 101219
		private static IntPtr __更新角色移动_NativeFunctionPtr;

		// Token: 0x04018B64 RID: 101220
		private static IntPtr __BlueprintUpdateAnimation_NativeFunctionPtr;

		// Token: 0x04018B65 RID: 101221
		private static IntPtr __BlueprintInitializeAnimation_NativeFunctionPtr;

		// Token: 0x04018B66 RID: 101222
		private static IntPtr __ExecuteUbergraph_ABP_CommonSmallAnimal_NativeFunctionPtr;

		// Token: 0x0200A44F RID: 42063
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __基础层_FunctionParams
		{
			// Token: 0x04033251 RID: 209489
			[FieldOffset(0)]
			public byte 基础层;
		}

		// Token: 0x0200A450 RID: 42064
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x04033252 RID: 209490
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A451 RID: 42065
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __BlueprintUpdateAnimation_FunctionParams
		{
			// Token: 0x04033253 RID: 209491
			[FieldOffset(0)]
			public float DeltaTimeX;
		}

		// Token: 0x0200A452 RID: 42066
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __ExecuteUbergraph_ABP_CommonSmallAnimal_FunctionParams
		{
			// Token: 0x04033254 RID: 209492
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
