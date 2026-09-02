using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common
{
	// Token: 0x02003FF9 RID: 16377
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/ABP_BaseSequenceRole_V2.ABP_BaseSequenceRole_V2_C")]
	[UnrealStructLayout(3520, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 3520)]
	public class ABP_BaseSequenceRole_V2_C : UAnimInstance, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A55E RID: 173406 RVA: 0x00A54278 File Offset: 0x00A52478
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_BaseSequenceRole_V2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/ABP_BaseSequenceRole_V2.ABP_BaseSequenceRole_V2_C");
			}
			return ABP_BaseSequenceRole_V2_C._ClassPtr;
		}

		// Token: 0x0602A55F RID: 173407 RVA: 0x00A5429C File Offset: 0x00A5249C
		public ABP_BaseSequenceRole_V2_C() : this(BuiltinUtils.AllocNativeUObject(ABP_BaseSequenceRole_V2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A560 RID: 173408 RVA: 0x00A542C4 File Offset: 0x00A524C4
		public ABP_BaseSequenceRole_V2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_BaseSequenceRole_V2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006D3F RID: 27967
		// (get) Token: 0x0602A561 RID: 173409 RVA: 0x00A542F8 File Offset: 0x00A524F8
		// (set) Token: 0x0602A562 RID: 173410 RVA: 0x00A54331 File Offset: 0x00A52531
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D40 RID: 27968
		// (get) Token: 0x0602A563 RID: 173411 RVA: 0x00A54354 File Offset: 0x00A52554
		// (set) Token: 0x0602A564 RID: 173412 RVA: 0x00A5438D File Offset: 0x00A5258D
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D41 RID: 27969
		// (get) Token: 0x0602A565 RID: 173413 RVA: 0x00A543B0 File Offset: 0x00A525B0
		// (set) Token: 0x0602A566 RID: 173414 RVA: 0x00A543E9 File Offset: 0x00A525E9
		public FAnimNode_Slot AnimGraphNode_Slot_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_7) == null)
				{
					result = (this._AnimGraphNode_Slot_7 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D42 RID: 27970
		// (get) Token: 0x0602A567 RID: 173415 RVA: 0x00A5440C File Offset: 0x00A5260C
		// (set) Token: 0x0602A568 RID: 173416 RVA: 0x00A54445 File Offset: 0x00A52645
		public FAnimNode_Slot AnimGraphNode_Slot_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_6) == null)
				{
					result = (this._AnimGraphNode_Slot_6 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D43 RID: 27971
		// (get) Token: 0x0602A569 RID: 173417 RVA: 0x00A54468 File Offset: 0x00A52668
		// (set) Token: 0x0602A56A RID: 173418 RVA: 0x00A544A1 File Offset: 0x00A526A1
		public FAnimNode_Slot AnimGraphNode_Slot_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_5) == null)
				{
					result = (this._AnimGraphNode_Slot_5 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D44 RID: 27972
		// (get) Token: 0x0602A56B RID: 173419 RVA: 0x00A544C4 File Offset: 0x00A526C4
		// (set) Token: 0x0602A56C RID: 173420 RVA: 0x00A544FD File Offset: 0x00A526FD
		public FAnimNode_Slot AnimGraphNode_Slot_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_4) == null)
				{
					result = (this._AnimGraphNode_Slot_4 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D45 RID: 27973
		// (get) Token: 0x0602A56D RID: 173421 RVA: 0x00A54520 File Offset: 0x00A52720
		// (set) Token: 0x0602A56E RID: 173422 RVA: 0x00A54559 File Offset: 0x00A52759
		public FAnimNode_RefPose AnimGraphNode_LocalRefPose
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_RefPose result;
				if ((result = this._AnimGraphNode_LocalRefPose) == null)
				{
					result = (this._AnimGraphNode_LocalRefPose = new FAnimNode_RefPose(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_RefPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D46 RID: 27974
		// (get) Token: 0x0602A56F RID: 173423 RVA: 0x00A5457C File Offset: 0x00A5277C
		// (set) Token: 0x0602A570 RID: 173424 RVA: 0x00A545B5 File Offset: 0x00A527B5
		public FAnimNode_TwoWayBlend AnimGraphNode_TwoWayBlend
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TwoWayBlend result;
				if ((result = this._AnimGraphNode_TwoWayBlend) == null)
				{
					result = (this._AnimGraphNode_TwoWayBlend = new FAnimNode_TwoWayBlend(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TwoWayBlend.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D47 RID: 27975
		// (get) Token: 0x0602A571 RID: 173425 RVA: 0x00A545D8 File Offset: 0x00A527D8
		// (set) Token: 0x0602A572 RID: 173426 RVA: 0x00A54611 File Offset: 0x00A52811
		public FAnimNode_Slot AnimGraphNode_Slot_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_3) == null)
				{
					result = (this._AnimGraphNode_Slot_3 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D48 RID: 27976
		// (get) Token: 0x0602A573 RID: 173427 RVA: 0x00A54634 File Offset: 0x00A52834
		// (set) Token: 0x0602A574 RID: 173428 RVA: 0x00A5466D File Offset: 0x00A5286D
		public FAnimNode_Slot AnimGraphNode_Slot_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_2) == null)
				{
					result = (this._AnimGraphNode_Slot_2 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D49 RID: 27977
		// (get) Token: 0x0602A575 RID: 173429 RVA: 0x00A54690 File Offset: 0x00A52890
		// (set) Token: 0x0602A576 RID: 173430 RVA: 0x00A546C9 File Offset: 0x00A528C9
		public FAnimNode_Slot AnimGraphNode_Slot_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_1) == null)
				{
					result = (this._AnimGraphNode_Slot_1 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D4A RID: 27978
		// (get) Token: 0x0602A577 RID: 173431 RVA: 0x00A546EC File Offset: 0x00A528EC
		// (set) Token: 0x0602A578 RID: 173432 RVA: 0x00A54725 File Offset: 0x00A52925
		public FAnimNode_Slot AnimGraphNode_Slot
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot) == null)
				{
					result = (this._AnimGraphNode_Slot = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D4B RID: 27979
		// (get) Token: 0x0602A579 RID: 173433 RVA: 0x00A54748 File Offset: 0x00A52948
		// (set) Token: 0x0602A57A RID: 173434 RVA: 0x00A54781 File Offset: 0x00A52981
		public FAnimNode_LayeredBoneBlend AnimGraphNode_LayeredBoneBlend
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LayeredBoneBlend result;
				if ((result = this._AnimGraphNode_LayeredBoneBlend) == null)
				{
					result = (this._AnimGraphNode_LayeredBoneBlend = new FAnimNode_LayeredBoneBlend(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LayeredBoneBlend.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D4C RID: 27980
		// (get) Token: 0x0602A57B RID: 173435 RVA: 0x00A547A2 File Offset: 0x00A529A2
		// (set) Token: 0x0602A57C RID: 173436 RVA: 0x00A547B2 File Offset: 0x00A529B2
		public unsafe bool OverrideMouth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006D4D RID: 27981
		// (get) Token: 0x0602A57D RID: 173437 RVA: 0x00A547C3 File Offset: 0x00A529C3
		// (set) Token: 0x0602A57E RID: 173438 RVA: 0x00A547D3 File Offset: 0x00A529D3
		public unsafe float SeqMouthAlpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_V2_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x0602A57F RID: 173439 RVA: 0x00A547E4 File Offset: 0x00A529E4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_BaseSequenceRole_V2_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_BaseSequenceRole_V2_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_BaseSequenceRole_V2_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseSequenceRole_V2_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseSequenceRole_V2_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0602A580 RID: 173440 RVA: 0x00A5486C File Offset: 0x00A52A6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void BlueprintUpdateAnimation(float DeltaTimeX)
		{
			ABP_BaseSequenceRole_V2_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_BaseSequenceRole_V2_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseSequenceRole_V2_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseSequenceRole_V2_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseSequenceRole_V2_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602A581 RID: 173441 RVA: 0x00A548B4 File Offset: 0x00A52AB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BlueprintUpdateAnimation_Implementation(float DeltaTimeX)
		{
			ABP_BaseSequenceRole_V2_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_BaseSequenceRole_V2_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseSequenceRole_V2_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseSequenceRole_V2_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseSequenceRole_V2_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602A582 RID: 173442 RVA: 0x00A548FC File Offset: 0x00A52AFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_BaseSequenceRole_V2(int EntryPoint)
		{
			ABP_BaseSequenceRole_V2_C.__ExecuteUbergraph_ABP_BaseSequenceRole_V2_FunctionParams* ptr = stackalloc ABP_BaseSequenceRole_V2_C.__ExecuteUbergraph_ABP_BaseSequenceRole_V2_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(ABP_BaseSequenceRole_V2_C.__ExecuteUbergraph_ABP_BaseSequenceRole_V2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseSequenceRole_V2_C.__ExecuteUbergraph_ABP_BaseSequenceRole_V2_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseSequenceRole_V2_C.__ExecuteUbergraph_ABP_BaseSequenceRole_V2_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602A583 RID: 173443 RVA: 0x00A54943 File Offset: 0x00A52B43
		protected ABP_BaseSequenceRole_V2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04016F2F RID: 93999
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/ABP_BaseSequenceRole_V2.ABP_BaseSequenceRole_V2_C";

		// Token: 0x04016F30 RID: 94000
		private static IntPtr _ClassPtr;

		// Token: 0x04016F31 RID: 94001
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04016F32 RID: 94002
		internal static int __PropertyOffset_0;

		// Token: 0x04016F33 RID: 94003
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04016F34 RID: 94004
		internal static int __PropertyOffset_1;

		// Token: 0x04016F35 RID: 94005
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x04016F36 RID: 94006
		internal static int __PropertyOffset_2;

		// Token: 0x04016F37 RID: 94007
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_7;

		// Token: 0x04016F38 RID: 94008
		internal static int __PropertyOffset_3;

		// Token: 0x04016F39 RID: 94009
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_6;

		// Token: 0x04016F3A RID: 94010
		internal static int __PropertyOffset_4;

		// Token: 0x04016F3B RID: 94011
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_5;

		// Token: 0x04016F3C RID: 94012
		internal static int __PropertyOffset_5;

		// Token: 0x04016F3D RID: 94013
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_4;

		// Token: 0x04016F3E RID: 94014
		internal static int __PropertyOffset_6;

		// Token: 0x04016F3F RID: 94015
		[Nullable(2)]
		private FAnimNode_RefPose _AnimGraphNode_LocalRefPose;

		// Token: 0x04016F40 RID: 94016
		internal static int __PropertyOffset_7;

		// Token: 0x04016F41 RID: 94017
		[Nullable(2)]
		private FAnimNode_TwoWayBlend _AnimGraphNode_TwoWayBlend;

		// Token: 0x04016F42 RID: 94018
		internal static int __PropertyOffset_8;

		// Token: 0x04016F43 RID: 94019
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_3;

		// Token: 0x04016F44 RID: 94020
		internal static int __PropertyOffset_9;

		// Token: 0x04016F45 RID: 94021
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_2;

		// Token: 0x04016F46 RID: 94022
		internal static int __PropertyOffset_10;

		// Token: 0x04016F47 RID: 94023
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_1;

		// Token: 0x04016F48 RID: 94024
		internal static int __PropertyOffset_11;

		// Token: 0x04016F49 RID: 94025
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot;

		// Token: 0x04016F4A RID: 94026
		internal static int __PropertyOffset_12;

		// Token: 0x04016F4B RID: 94027
		[Nullable(2)]
		private FAnimNode_LayeredBoneBlend _AnimGraphNode_LayeredBoneBlend;

		// Token: 0x04016F4C RID: 94028
		internal static int __PropertyOffset_13;

		// Token: 0x04016F4D RID: 94029
		internal static int __PropertyOffset_14;

		// Token: 0x04016F4E RID: 94030
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x04016F4F RID: 94031
		private static IntPtr __BlueprintUpdateAnimation_NativeFunctionPtr;

		// Token: 0x04016F50 RID: 94032
		private static IntPtr __ExecuteUbergraph_ABP_BaseSequenceRole_V2_NativeFunctionPtr;

		// Token: 0x0200A23E RID: 41534
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x04032FDE RID: 208862
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A23F RID: 41535
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __BlueprintUpdateAnimation_FunctionParams
		{
			// Token: 0x04032FDF RID: 208863
			[FieldOffset(0)]
			public float DeltaTimeX;
		}

		// Token: 0x0200A240 RID: 41536
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __ExecuteUbergraph_ABP_BaseSequenceRole_V2_FunctionParams
		{
			// Token: 0x04032FE0 RID: 208864
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
