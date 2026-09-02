using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common
{
	// Token: 0x02003FF8 RID: 16376
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/ABP_BaseSequenceRole.ABP_BaseSequenceRole_C")]
	[UnrealStructLayout(4432, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 4421)]
	public class ABP_BaseSequenceRole_C : UAnimInstance, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A52C RID: 173356 RVA: 0x00A538F7 File Offset: 0x00A51AF7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_BaseSequenceRole_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/ABP_BaseSequenceRole.ABP_BaseSequenceRole_C");
			}
			return ABP_BaseSequenceRole_C._ClassPtr;
		}

		// Token: 0x0602A52D RID: 173357 RVA: 0x00A5391C File Offset: 0x00A51B1C
		public ABP_BaseSequenceRole_C() : this(BuiltinUtils.AllocNativeUObject(ABP_BaseSequenceRole_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A52E RID: 173358 RVA: 0x00A53944 File Offset: 0x00A51B44
		public ABP_BaseSequenceRole_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_BaseSequenceRole_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006D2B RID: 27947
		// (get) Token: 0x0602A52F RID: 173359 RVA: 0x00A53978 File Offset: 0x00A51B78
		// (set) Token: 0x0602A530 RID: 173360 RVA: 0x00A539B1 File Offset: 0x00A51BB1
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D2C RID: 27948
		// (get) Token: 0x0602A531 RID: 173361 RVA: 0x00A539D4 File Offset: 0x00A51BD4
		// (set) Token: 0x0602A532 RID: 173362 RVA: 0x00A53A0D File Offset: 0x00A51C0D
		public FAnimNode_Root AnimGraphNode_Root_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_2) == null)
				{
					result = (this._AnimGraphNode_Root_2 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D2D RID: 27949
		// (get) Token: 0x0602A533 RID: 173363 RVA: 0x00A53A30 File Offset: 0x00A51C30
		// (set) Token: 0x0602A534 RID: 173364 RVA: 0x00A53A69 File Offset: 0x00A51C69
		public FAnimNode_PoseBlendNode AnimGraphNode_PoseBlendNode_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_PoseBlendNode result;
				if ((result = this._AnimGraphNode_PoseBlendNode_1) == null)
				{
					result = (this._AnimGraphNode_PoseBlendNode_1 = new FAnimNode_PoseBlendNode(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_PoseBlendNode.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D2E RID: 27950
		// (get) Token: 0x0602A535 RID: 173365 RVA: 0x00A53A8C File Offset: 0x00A51C8C
		// (set) Token: 0x0602A536 RID: 173366 RVA: 0x00A53AC5 File Offset: 0x00A51CC5
		public FAnimNode_Slot AnimGraphNode_Slot_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_6) == null)
				{
					result = (this._AnimGraphNode_Slot_6 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D2F RID: 27951
		// (get) Token: 0x0602A537 RID: 173367 RVA: 0x00A53AE8 File Offset: 0x00A51CE8
		// (set) Token: 0x0602A538 RID: 173368 RVA: 0x00A53B21 File Offset: 0x00A51D21
		public FAnimNode_Slot AnimGraphNode_Slot_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_5) == null)
				{
					result = (this._AnimGraphNode_Slot_5 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D30 RID: 27952
		// (get) Token: 0x0602A539 RID: 173369 RVA: 0x00A53B44 File Offset: 0x00A51D44
		// (set) Token: 0x0602A53A RID: 173370 RVA: 0x00A53B7D File Offset: 0x00A51D7D
		public FAnimNode_Slot AnimGraphNode_Slot_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_4) == null)
				{
					result = (this._AnimGraphNode_Slot_4 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D31 RID: 27953
		// (get) Token: 0x0602A53B RID: 173371 RVA: 0x00A53BA0 File Offset: 0x00A51DA0
		// (set) Token: 0x0602A53C RID: 173372 RVA: 0x00A53BD9 File Offset: 0x00A51DD9
		public FAnimNode_Root AnimGraphNode_Root_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_1) == null)
				{
					result = (this._AnimGraphNode_Root_1 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D32 RID: 27954
		// (get) Token: 0x0602A53D RID: 173373 RVA: 0x00A53BFC File Offset: 0x00A51DFC
		// (set) Token: 0x0602A53E RID: 173374 RVA: 0x00A53C35 File Offset: 0x00A51E35
		public FAnimNode_Slot AnimGraphNode_Slot_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_3) == null)
				{
					result = (this._AnimGraphNode_Slot_3 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D33 RID: 27955
		// (get) Token: 0x0602A53F RID: 173375 RVA: 0x00A53C58 File Offset: 0x00A51E58
		// (set) Token: 0x0602A540 RID: 173376 RVA: 0x00A53C91 File Offset: 0x00A51E91
		public FAnimNode_Slot AnimGraphNode_Slot_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_2) == null)
				{
					result = (this._AnimGraphNode_Slot_2 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D34 RID: 27956
		// (get) Token: 0x0602A541 RID: 173377 RVA: 0x00A53CB4 File Offset: 0x00A51EB4
		// (set) Token: 0x0602A542 RID: 173378 RVA: 0x00A53CED File Offset: 0x00A51EED
		public FAnimNode_LayeredBoneBlend AnimGraphNode_LayeredBoneBlend
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LayeredBoneBlend result;
				if ((result = this._AnimGraphNode_LayeredBoneBlend) == null)
				{
					result = (this._AnimGraphNode_LayeredBoneBlend = new FAnimNode_LayeredBoneBlend(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LayeredBoneBlend.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D35 RID: 27957
		// (get) Token: 0x0602A543 RID: 173379 RVA: 0x00A53D10 File Offset: 0x00A51F10
		// (set) Token: 0x0602A544 RID: 173380 RVA: 0x00A53D49 File Offset: 0x00A51F49
		public FAnimNode_PoseBlendNode AnimGraphNode_PoseBlendNode
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_PoseBlendNode result;
				if ((result = this._AnimGraphNode_PoseBlendNode) == null)
				{
					result = (this._AnimGraphNode_PoseBlendNode = new FAnimNode_PoseBlendNode(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_PoseBlendNode.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D36 RID: 27958
		// (get) Token: 0x0602A545 RID: 173381 RVA: 0x00A53D6C File Offset: 0x00A51F6C
		// (set) Token: 0x0602A546 RID: 173382 RVA: 0x00A53DA5 File Offset: 0x00A51FA5
		public FAnimNode_Slot AnimGraphNode_Slot_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_1) == null)
				{
					result = (this._AnimGraphNode_Slot_1 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D37 RID: 27959
		// (get) Token: 0x0602A547 RID: 173383 RVA: 0x00A53DC8 File Offset: 0x00A51FC8
		// (set) Token: 0x0602A548 RID: 173384 RVA: 0x00A53E01 File Offset: 0x00A52001
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D38 RID: 27960
		// (get) Token: 0x0602A549 RID: 173385 RVA: 0x00A53E24 File Offset: 0x00A52024
		// (set) Token: 0x0602A54A RID: 173386 RVA: 0x00A53E5D File Offset: 0x00A5205D
		public FAnimNode_Slot AnimGraphNode_Slot
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot) == null)
				{
					result = (this._AnimGraphNode_Slot = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D39 RID: 27961
		// (get) Token: 0x0602A54B RID: 173387 RVA: 0x00A53E80 File Offset: 0x00A52080
		// (set) Token: 0x0602A54C RID: 173388 RVA: 0x00A53EB9 File Offset: 0x00A520B9
		public FAnimNode_TwoWayBlend AnimGraphNode_TwoWayBlend
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TwoWayBlend result;
				if ((result = this._AnimGraphNode_TwoWayBlend) == null)
				{
					result = (this._AnimGraphNode_TwoWayBlend = new FAnimNode_TwoWayBlend(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TwoWayBlend.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_14, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D3A RID: 27962
		// (get) Token: 0x0602A54D RID: 173389 RVA: 0x00A53EDC File Offset: 0x00A520DC
		// (set) Token: 0x0602A54E RID: 173390 RVA: 0x00A53F15 File Offset: 0x00A52115
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer_1) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer_1 = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_15, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D3B RID: 27963
		// (get) Token: 0x0602A54F RID: 173391 RVA: 0x00A53F38 File Offset: 0x00A52138
		// (set) Token: 0x0602A550 RID: 173392 RVA: 0x00A53F71 File Offset: 0x00A52171
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_16, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D3C RID: 27964
		// (get) Token: 0x0602A551 RID: 173393 RVA: 0x00A53F92 File Offset: 0x00A52192
		// (set) Token: 0x0602A552 RID: 173394 RVA: 0x00A53FA6 File Offset: 0x00A521A6
		[Nullable(2)]
		public unsafe UPoseAsset SeqMouthPoseAsset
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPoseAsset>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseSequenceRole_C.__PropertyOffset_17);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseSequenceRole_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17006D3D RID: 27965
		// (get) Token: 0x0602A553 RID: 173395 RVA: 0x00A53FBB File Offset: 0x00A521BB
		// (set) Token: 0x0602A554 RID: 173396 RVA: 0x00A53FCB File Offset: 0x00A521CB
		public unsafe float SeqMouthAlpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17006D3E RID: 27966
		// (get) Token: 0x0602A555 RID: 173397 RVA: 0x00A53FDC File Offset: 0x00A521DC
		// (set) Token: 0x0602A556 RID: 173398 RVA: 0x00A53FEC File Offset: 0x00A521EC
		public unsafe bool UseOverrideLayer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseSequenceRole_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602A557 RID: 173399 RVA: 0x00A54000 File Offset: 0x00A52200
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void MouthAddLayer(ref FPoseLink MouthAddLayer)
		{
			ABP_BaseSequenceRole_C.__MouthAddLayer_FunctionParams* ptr = stackalloc ABP_BaseSequenceRole_C.__MouthAddLayer_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_BaseSequenceRole_C.__MouthAddLayer_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseSequenceRole_C.__MouthAddLayer_NativeFunctionPtr, (void*)ptr, 1);
			if (MouthAddLayer != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->MouthAddLayer, MouthAddLayer.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseSequenceRole_C.__MouthAddLayer_NativeFunctionPtr, (void*)ptr);
			if (MouthAddLayer != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), MouthAddLayer.NativePtr, &ptr->MouthAddLayer, 1, false);
			}
		}

		// Token: 0x0602A558 RID: 173400 RVA: 0x00A54088 File Offset: 0x00A52288
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void MouthOverrideLayer(ref FPoseLink MouthOverrideLayer)
		{
			ABP_BaseSequenceRole_C.__MouthOverrideLayer_FunctionParams* ptr = stackalloc ABP_BaseSequenceRole_C.__MouthOverrideLayer_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_BaseSequenceRole_C.__MouthOverrideLayer_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseSequenceRole_C.__MouthOverrideLayer_NativeFunctionPtr, (void*)ptr, 1);
			if (MouthOverrideLayer != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->MouthOverrideLayer, MouthOverrideLayer.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseSequenceRole_C.__MouthOverrideLayer_NativeFunctionPtr, (void*)ptr);
			if (MouthOverrideLayer != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), MouthOverrideLayer.NativePtr, &ptr->MouthOverrideLayer, 1, false);
			}
		}

		// Token: 0x0602A559 RID: 173401 RVA: 0x00A54110 File Offset: 0x00A52310
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_BaseSequenceRole_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_BaseSequenceRole_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_BaseSequenceRole_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseSequenceRole_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseSequenceRole_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0602A55A RID: 173402 RVA: 0x00A54198 File Offset: 0x00A52398
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void BlueprintUpdateAnimation(float DeltaTimeX)
		{
			ABP_BaseSequenceRole_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_BaseSequenceRole_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseSequenceRole_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseSequenceRole_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseSequenceRole_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602A55B RID: 173403 RVA: 0x00A541E0 File Offset: 0x00A523E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BlueprintUpdateAnimation_Implementation(float DeltaTimeX)
		{
			ABP_BaseSequenceRole_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_BaseSequenceRole_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseSequenceRole_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseSequenceRole_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseSequenceRole_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602A55C RID: 173404 RVA: 0x00A54228 File Offset: 0x00A52428
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_BaseSequenceRole(int EntryPoint)
		{
			ABP_BaseSequenceRole_C.__ExecuteUbergraph_ABP_BaseSequenceRole_FunctionParams* ptr = stackalloc ABP_BaseSequenceRole_C.__ExecuteUbergraph_ABP_BaseSequenceRole_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(ABP_BaseSequenceRole_C.__ExecuteUbergraph_ABP_BaseSequenceRole_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseSequenceRole_C.__ExecuteUbergraph_ABP_BaseSequenceRole_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseSequenceRole_C.__ExecuteUbergraph_ABP_BaseSequenceRole_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602A55D RID: 173405 RVA: 0x00A5426F File Offset: 0x00A5246F
		protected ABP_BaseSequenceRole_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04016F02 RID: 93954
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/ABP_BaseSequenceRole.ABP_BaseSequenceRole_C";

		// Token: 0x04016F03 RID: 93955
		private static IntPtr _ClassPtr;

		// Token: 0x04016F04 RID: 93956
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04016F05 RID: 93957
		internal static int __PropertyOffset_0;

		// Token: 0x04016F06 RID: 93958
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04016F07 RID: 93959
		internal static int __PropertyOffset_1;

		// Token: 0x04016F08 RID: 93960
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_2;

		// Token: 0x04016F09 RID: 93961
		internal static int __PropertyOffset_2;

		// Token: 0x04016F0A RID: 93962
		[Nullable(2)]
		private FAnimNode_PoseBlendNode _AnimGraphNode_PoseBlendNode_1;

		// Token: 0x04016F0B RID: 93963
		internal static int __PropertyOffset_3;

		// Token: 0x04016F0C RID: 93964
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_6;

		// Token: 0x04016F0D RID: 93965
		internal static int __PropertyOffset_4;

		// Token: 0x04016F0E RID: 93966
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_5;

		// Token: 0x04016F0F RID: 93967
		internal static int __PropertyOffset_5;

		// Token: 0x04016F10 RID: 93968
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_4;

		// Token: 0x04016F11 RID: 93969
		internal static int __PropertyOffset_6;

		// Token: 0x04016F12 RID: 93970
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_1;

		// Token: 0x04016F13 RID: 93971
		internal static int __PropertyOffset_7;

		// Token: 0x04016F14 RID: 93972
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_3;

		// Token: 0x04016F15 RID: 93973
		internal static int __PropertyOffset_8;

		// Token: 0x04016F16 RID: 93974
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_2;

		// Token: 0x04016F17 RID: 93975
		internal static int __PropertyOffset_9;

		// Token: 0x04016F18 RID: 93976
		[Nullable(2)]
		private FAnimNode_LayeredBoneBlend _AnimGraphNode_LayeredBoneBlend;

		// Token: 0x04016F19 RID: 93977
		internal static int __PropertyOffset_10;

		// Token: 0x04016F1A RID: 93978
		[Nullable(2)]
		private FAnimNode_PoseBlendNode _AnimGraphNode_PoseBlendNode;

		// Token: 0x04016F1B RID: 93979
		internal static int __PropertyOffset_11;

		// Token: 0x04016F1C RID: 93980
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_1;

		// Token: 0x04016F1D RID: 93981
		internal static int __PropertyOffset_12;

		// Token: 0x04016F1E RID: 93982
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x04016F1F RID: 93983
		internal static int __PropertyOffset_13;

		// Token: 0x04016F20 RID: 93984
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot;

		// Token: 0x04016F21 RID: 93985
		internal static int __PropertyOffset_14;

		// Token: 0x04016F22 RID: 93986
		[Nullable(2)]
		private FAnimNode_TwoWayBlend _AnimGraphNode_TwoWayBlend;

		// Token: 0x04016F23 RID: 93987
		internal static int __PropertyOffset_15;

		// Token: 0x04016F24 RID: 93988
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer_1;

		// Token: 0x04016F25 RID: 93989
		internal static int __PropertyOffset_16;

		// Token: 0x04016F26 RID: 93990
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer;

		// Token: 0x04016F27 RID: 93991
		internal static int __PropertyOffset_17;

		// Token: 0x04016F28 RID: 93992
		internal static int __PropertyOffset_18;

		// Token: 0x04016F29 RID: 93993
		internal static int __PropertyOffset_19;

		// Token: 0x04016F2A RID: 93994
		private static IntPtr __MouthAddLayer_NativeFunctionPtr;

		// Token: 0x04016F2B RID: 93995
		private static IntPtr __MouthOverrideLayer_NativeFunctionPtr;

		// Token: 0x04016F2C RID: 93996
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x04016F2D RID: 93997
		private static IntPtr __BlueprintUpdateAnimation_NativeFunctionPtr;

		// Token: 0x04016F2E RID: 93998
		private static IntPtr __ExecuteUbergraph_ABP_BaseSequenceRole_NativeFunctionPtr;

		// Token: 0x0200A239 RID: 41529
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __MouthAddLayer_FunctionParams
		{
			// Token: 0x04032FD9 RID: 208857
			[FieldOffset(0)]
			public byte MouthAddLayer;
		}

		// Token: 0x0200A23A RID: 41530
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __MouthOverrideLayer_FunctionParams
		{
			// Token: 0x04032FDA RID: 208858
			[FieldOffset(0)]
			public byte MouthOverrideLayer;
		}

		// Token: 0x0200A23B RID: 41531
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x04032FDB RID: 208859
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A23C RID: 41532
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __BlueprintUpdateAnimation_FunctionParams
		{
			// Token: 0x04032FDC RID: 208860
			[FieldOffset(0)]
			public float DeltaTimeX;
		}

		// Token: 0x0200A23D RID: 41533
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __ExecuteUbergraph_ABP_BaseSequenceRole_FunctionParams
		{
			// Token: 0x04032FDD RID: 208861
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
