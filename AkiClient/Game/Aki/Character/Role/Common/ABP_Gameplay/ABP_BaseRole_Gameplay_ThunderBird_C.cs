using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.ABP_Gameplay
{
	// Token: 0x02004073 RID: 16499
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/ABP_Gameplay/ABP_BaseRole_Gameplay_ThunderBird.ABP_BaseRole_Gameplay_ThunderBird_C")]
	[UnrealStructLayout(10352, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 10337)]
	public class ABP_BaseRole_Gameplay_ThunderBird_C : UKuroAnimInstance, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602ADC2 RID: 175554 RVA: 0x00A678B8 File Offset: 0x00A65AB8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_BaseRole_Gameplay_ThunderBird_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/ABP_Gameplay/ABP_BaseRole_Gameplay_ThunderBird.ABP_BaseRole_Gameplay_ThunderBird_C");
			}
			return ABP_BaseRole_Gameplay_ThunderBird_C._ClassPtr;
		}

		// Token: 0x0602ADC3 RID: 175555 RVA: 0x00A678DC File Offset: 0x00A65ADC
		public ABP_BaseRole_Gameplay_ThunderBird_C() : this(BuiltinUtils.AllocNativeUObject(ABP_BaseRole_Gameplay_ThunderBird_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602ADC4 RID: 175556 RVA: 0x00A67904 File Offset: 0x00A65B04
		public ABP_BaseRole_Gameplay_ThunderBird_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_BaseRole_Gameplay_ThunderBird_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006FFA RID: 28666
		// (get) Token: 0x0602ADC5 RID: 175557 RVA: 0x00A67938 File Offset: 0x00A65B38
		// (set) Token: 0x0602ADC6 RID: 175558 RVA: 0x00A67971 File Offset: 0x00A65B71
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FFB RID: 28667
		// (get) Token: 0x0602ADC7 RID: 175559 RVA: 0x00A67994 File Offset: 0x00A65B94
		// (set) Token: 0x0602ADC8 RID: 175560 RVA: 0x00A679CD File Offset: 0x00A65BCD
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FFC RID: 28668
		// (get) Token: 0x0602ADC9 RID: 175561 RVA: 0x00A679F0 File Offset: 0x00A65BF0
		// (set) Token: 0x0602ADCA RID: 175562 RVA: 0x00A67A29 File Offset: 0x00A65C29
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_3) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_3 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FFD RID: 28669
		// (get) Token: 0x0602ADCB RID: 175563 RVA: 0x00A67A4C File Offset: 0x00A65C4C
		// (set) Token: 0x0602ADCC RID: 175564 RVA: 0x00A67A85 File Offset: 0x00A65C85
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_2) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_2 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FFE RID: 28670
		// (get) Token: 0x0602ADCD RID: 175565 RVA: 0x00A67AA8 File Offset: 0x00A65CA8
		// (set) Token: 0x0602ADCE RID: 175566 RVA: 0x00A67AE1 File Offset: 0x00A65CE1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_1) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_1 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FFF RID: 28671
		// (get) Token: 0x0602ADCF RID: 175567 RVA: 0x00A67B04 File Offset: 0x00A65D04
		// (set) Token: 0x0602ADD0 RID: 175568 RVA: 0x00A67B3D File Offset: 0x00A65D3D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult) == null)
				{
					result = (this._AnimGraphNode_TransitionResult = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007000 RID: 28672
		// (get) Token: 0x0602ADD1 RID: 175569 RVA: 0x00A67B60 File Offset: 0x00A65D60
		// (set) Token: 0x0602ADD2 RID: 175570 RVA: 0x00A67B99 File Offset: 0x00A65D99
		public FAnimNode_StateResult AnimGraphNode_StateResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_2) == null)
				{
					result = (this._AnimGraphNode_StateResult_2 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007001 RID: 28673
		// (get) Token: 0x0602ADD3 RID: 175571 RVA: 0x00A67BBC File Offset: 0x00A65DBC
		// (set) Token: 0x0602ADD4 RID: 175572 RVA: 0x00A67BF5 File Offset: 0x00A65DF5
		public FAnimNode_ExtraFollowAnims AnimGraphNode_ExtraFollowAnims_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ExtraFollowAnims result;
				if ((result = this._AnimGraphNode_ExtraFollowAnims_1) == null)
				{
					result = (this._AnimGraphNode_ExtraFollowAnims_1 = new FAnimNode_ExtraFollowAnims(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ExtraFollowAnims.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007002 RID: 28674
		// (get) Token: 0x0602ADD5 RID: 175573 RVA: 0x00A67C18 File Offset: 0x00A65E18
		// (set) Token: 0x0602ADD6 RID: 175574 RVA: 0x00A67C51 File Offset: 0x00A65E51
		public FAnimNode_StateResult AnimGraphNode_StateResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_1) == null)
				{
					result = (this._AnimGraphNode_StateResult_1 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007003 RID: 28675
		// (get) Token: 0x0602ADD7 RID: 175575 RVA: 0x00A67C74 File Offset: 0x00A65E74
		// (set) Token: 0x0602ADD8 RID: 175576 RVA: 0x00A67CAD File Offset: 0x00A65EAD
		public FAnimNode_ExtraFollowAnims AnimGraphNode_ExtraFollowAnims
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ExtraFollowAnims result;
				if ((result = this._AnimGraphNode_ExtraFollowAnims) == null)
				{
					result = (this._AnimGraphNode_ExtraFollowAnims = new FAnimNode_ExtraFollowAnims(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ExtraFollowAnims.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007004 RID: 28676
		// (get) Token: 0x0602ADD9 RID: 175577 RVA: 0x00A67CD0 File Offset: 0x00A65ED0
		// (set) Token: 0x0602ADDA RID: 175578 RVA: 0x00A67D09 File Offset: 0x00A65F09
		public FAnimNode_StateResult AnimGraphNode_StateResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult) == null)
				{
					result = (this._AnimGraphNode_StateResult = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007005 RID: 28677
		// (get) Token: 0x0602ADDB RID: 175579 RVA: 0x00A67D2C File Offset: 0x00A65F2C
		// (set) Token: 0x0602ADDC RID: 175580 RVA: 0x00A67D65 File Offset: 0x00A65F65
		public FAnimNode_StateMachine AnimGraphNode_StateMachine
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine) == null)
				{
					result = (this._AnimGraphNode_StateMachine = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007006 RID: 28678
		// (get) Token: 0x0602ADDD RID: 175581 RVA: 0x00A67D86 File Offset: 0x00A65F86
		// (set) Token: 0x0602ADDE RID: 175582 RVA: 0x00A67D96 File Offset: 0x00A65F96
		public unsafe float DeltaTimeX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17007007 RID: 28679
		// (get) Token: 0x0602ADDF RID: 175583 RVA: 0x00A67DA7 File Offset: 0x00A65FA7
		// (set) Token: 0x0602ADE0 RID: 175584 RVA: 0x00A67DBB File Offset: 0x00A65FBB
		[Nullable(2)]
		public unsafe TsBaseCharacter 角色蓝图
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_13);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17007008 RID: 28680
		// (get) Token: 0x0602ADE1 RID: 175585 RVA: 0x00A67DD0 File Offset: 0x00A65FD0
		// (set) Token: 0x0602ADE2 RID: 175586 RVA: 0x00A67DE4 File Offset: 0x00A65FE4
		[Nullable(2)]
		public unsafe UKuroAnimInstanceChar MainAnimInst
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroAnimInstanceChar>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_14);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17007009 RID: 28681
		// (get) Token: 0x0602ADE3 RID: 175587 RVA: 0x00A67DF9 File Offset: 0x00A65FF9
		// (set) Token: 0x0602ADE4 RID: 175588 RVA: 0x00A67E09 File Offset: 0x00A66009
		public unsafe bool IsMainAnimInstValid
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_ThunderBird_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602ADE5 RID: 175589 RVA: 0x00A67E1C File Offset: 0x00A6601C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_BaseRole_Gameplay_ThunderBird_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_BaseRole_Gameplay_ThunderBird_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_BaseRole_Gameplay_ThunderBird_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_Gameplay_ThunderBird_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_ThunderBird_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0602ADE6 RID: 175590 RVA: 0x00A67EA3 File Offset: 0x00A660A3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_ThunderBird_AnimGraphNode_TransitionResult_36F8043547569C377466A28466646D16()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_ThunderBird_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_ThunderBird_AnimGraphNode_TransitionResult_36F8043547569C377466A28466646D16_NativeFunctionPtr, null);
		}

		// Token: 0x0602ADE7 RID: 175591 RVA: 0x00A67EB7 File Offset: 0x00A660B7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_ThunderBird_AnimGraphNode_TransitionResult_A40A46B346925A2CD3FF378C14DBA4CF()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_ThunderBird_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_ThunderBird_AnimGraphNode_TransitionResult_A40A46B346925A2CD3FF378C14DBA4CF_NativeFunctionPtr, null);
		}

		// Token: 0x0602ADE8 RID: 175592 RVA: 0x00A67ECB File Offset: 0x00A660CB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_ThunderBird_AnimGraphNode_TransitionResult_B358E07A4ECD32C0A5098A8E13E1D575()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_ThunderBird_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_ThunderBird_AnimGraphNode_TransitionResult_B358E07A4ECD32C0A5098A8E13E1D575_NativeFunctionPtr, null);
		}

		// Token: 0x0602ADE9 RID: 175593 RVA: 0x00A67EDF File Offset: 0x00A660DF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_ThunderBird_AnimGraphNode_TransitionResult_6F43356D47EB0B065C5D709930201746()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_ThunderBird_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_ThunderBird_AnimGraphNode_TransitionResult_6F43356D47EB0B065C5D709930201746_NativeFunctionPtr, null);
		}

		// Token: 0x0602ADEA RID: 175594 RVA: 0x00A67EF4 File Offset: 0x00A660F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void BlueprintUpdateAnimation(float DeltaTimeX)
		{
			ABP_BaseRole_Gameplay_ThunderBird_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_BaseRole_Gameplay_ThunderBird_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseRole_Gameplay_ThunderBird_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_Gameplay_ThunderBird_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_ThunderBird_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602ADEB RID: 175595 RVA: 0x00A67F3C File Offset: 0x00A6613C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BlueprintUpdateAnimation_Implementation(float DeltaTimeX)
		{
			ABP_BaseRole_Gameplay_ThunderBird_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_BaseRole_Gameplay_ThunderBird_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseRole_Gameplay_ThunderBird_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_Gameplay_ThunderBird_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseRole_Gameplay_ThunderBird_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602ADEC RID: 175596 RVA: 0x00A67F83 File Offset: 0x00A66183
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BlueprintInitializeAnimation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_ThunderBird_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null);
		}

		// Token: 0x0602ADED RID: 175597 RVA: 0x00A67F97 File Offset: 0x00A66197
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BlueprintInitializeAnimation_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseRole_Gameplay_ThunderBird_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602ADEE RID: 175598 RVA: 0x00A67FAC File Offset: 0x00A661AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_BaseRole_Gameplay_ThunderBird(int EntryPoint)
		{
			ABP_BaseRole_Gameplay_ThunderBird_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_ThunderBird_FunctionParams* ptr = stackalloc ABP_BaseRole_Gameplay_ThunderBird_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_ThunderBird_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(ABP_BaseRole_Gameplay_ThunderBird_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_ThunderBird_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_Gameplay_ThunderBird_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_ThunderBird_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseRole_Gameplay_ThunderBird_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_ThunderBird_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602ADEF RID: 175599 RVA: 0x00A67FF3 File Offset: 0x00A661F3
		protected ABP_BaseRole_Gameplay_ThunderBird_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401766E RID: 95854
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/ABP_Gameplay/ABP_BaseRole_Gameplay_ThunderBird.ABP_BaseRole_Gameplay_ThunderBird_C";

		// Token: 0x0401766F RID: 95855
		private static IntPtr _ClassPtr;

		// Token: 0x04017670 RID: 95856
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017671 RID: 95857
		internal static int __PropertyOffset_0;

		// Token: 0x04017672 RID: 95858
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017673 RID: 95859
		internal static int __PropertyOffset_1;

		// Token: 0x04017674 RID: 95860
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x04017675 RID: 95861
		internal static int __PropertyOffset_2;

		// Token: 0x04017676 RID: 95862
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_3;

		// Token: 0x04017677 RID: 95863
		internal static int __PropertyOffset_3;

		// Token: 0x04017678 RID: 95864
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_2;

		// Token: 0x04017679 RID: 95865
		internal static int __PropertyOffset_4;

		// Token: 0x0401767A RID: 95866
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_1;

		// Token: 0x0401767B RID: 95867
		internal static int __PropertyOffset_5;

		// Token: 0x0401767C RID: 95868
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult;

		// Token: 0x0401767D RID: 95869
		internal static int __PropertyOffset_6;

		// Token: 0x0401767E RID: 95870
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_2;

		// Token: 0x0401767F RID: 95871
		internal static int __PropertyOffset_7;

		// Token: 0x04017680 RID: 95872
		[Nullable(2)]
		private FAnimNode_ExtraFollowAnims _AnimGraphNode_ExtraFollowAnims_1;

		// Token: 0x04017681 RID: 95873
		internal static int __PropertyOffset_8;

		// Token: 0x04017682 RID: 95874
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_1;

		// Token: 0x04017683 RID: 95875
		internal static int __PropertyOffset_9;

		// Token: 0x04017684 RID: 95876
		[Nullable(2)]
		private FAnimNode_ExtraFollowAnims _AnimGraphNode_ExtraFollowAnims;

		// Token: 0x04017685 RID: 95877
		internal static int __PropertyOffset_10;

		// Token: 0x04017686 RID: 95878
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult;

		// Token: 0x04017687 RID: 95879
		internal static int __PropertyOffset_11;

		// Token: 0x04017688 RID: 95880
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine;

		// Token: 0x04017689 RID: 95881
		internal static int __PropertyOffset_12;

		// Token: 0x0401768A RID: 95882
		internal static int __PropertyOffset_13;

		// Token: 0x0401768B RID: 95883
		internal static int __PropertyOffset_14;

		// Token: 0x0401768C RID: 95884
		internal static int __PropertyOffset_15;

		// Token: 0x0401768D RID: 95885
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x0401768E RID: 95886
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_ThunderBird_AnimGraphNode_TransitionResult_36F8043547569C377466A28466646D16_NativeFunctionPtr;

		// Token: 0x0401768F RID: 95887
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_ThunderBird_AnimGraphNode_TransitionResult_A40A46B346925A2CD3FF378C14DBA4CF_NativeFunctionPtr;

		// Token: 0x04017690 RID: 95888
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_ThunderBird_AnimGraphNode_TransitionResult_B358E07A4ECD32C0A5098A8E13E1D575_NativeFunctionPtr;

		// Token: 0x04017691 RID: 95889
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_ThunderBird_AnimGraphNode_TransitionResult_6F43356D47EB0B065C5D709930201746_NativeFunctionPtr;

		// Token: 0x04017692 RID: 95890
		private static IntPtr __BlueprintUpdateAnimation_NativeFunctionPtr;

		// Token: 0x04017693 RID: 95891
		private static IntPtr __BlueprintInitializeAnimation_NativeFunctionPtr;

		// Token: 0x04017694 RID: 95892
		private static IntPtr __ExecuteUbergraph_ABP_BaseRole_Gameplay_ThunderBird_NativeFunctionPtr;

		// Token: 0x0200A269 RID: 41577
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x04033013 RID: 208915
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A26A RID: 41578
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __BlueprintUpdateAnimation_FunctionParams
		{
			// Token: 0x04033014 RID: 208916
			[FieldOffset(0)]
			public float DeltaTimeX;
		}

		// Token: 0x0200A26B RID: 41579
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __ExecuteUbergraph_ABP_BaseRole_Gameplay_ThunderBird_FunctionParams
		{
			// Token: 0x04033015 RID: 208917
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
