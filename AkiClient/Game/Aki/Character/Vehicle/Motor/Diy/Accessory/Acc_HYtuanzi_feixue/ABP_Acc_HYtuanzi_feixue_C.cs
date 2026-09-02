using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Diy.Accessory.Acc_HYtuanzi_feixue
{
	// Token: 0x02003FA6 RID: 16294
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Diy/Accessory/Acc_HYtuanzi_feixue/ABP_Acc_HYtuanzi_feixue.ABP_Acc_HYtuanzi_feixue_C")]
	[UnrealStructLayout(2464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2456)]
	public class ABP_Acc_HYtuanzi_feixue_C : UAnimInstance, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028E7C RID: 167548 RVA: 0x00A1A23C File Offset: 0x00A1843C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_Acc_HYtuanzi_feixue_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Diy/Accessory/Acc_HYtuanzi_feixue/ABP_Acc_HYtuanzi_feixue.ABP_Acc_HYtuanzi_feixue_C");
			}
			return ABP_Acc_HYtuanzi_feixue_C._ClassPtr;
		}

		// Token: 0x06028E7D RID: 167549 RVA: 0x00A1A260 File Offset: 0x00A18460
		public ABP_Acc_HYtuanzi_feixue_C() : this(BuiltinUtils.AllocNativeUObject(ABP_Acc_HYtuanzi_feixue_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028E7E RID: 167550 RVA: 0x00A1A288 File Offset: 0x00A18488
		public ABP_Acc_HYtuanzi_feixue_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_Acc_HYtuanzi_feixue_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170064C7 RID: 25799
		// (get) Token: 0x06028E7F RID: 167551 RVA: 0x00A1A2BC File Offset: 0x00A184BC
		// (set) Token: 0x06028E80 RID: 167552 RVA: 0x00A1A2F5 File Offset: 0x00A184F5
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_Acc_HYtuanzi_feixue_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_Acc_HYtuanzi_feixue_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170064C8 RID: 25800
		// (get) Token: 0x06028E81 RID: 167553 RVA: 0x00A1A318 File Offset: 0x00A18518
		// (set) Token: 0x06028E82 RID: 167554 RVA: 0x00A1A351 File Offset: 0x00A18551
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_Acc_HYtuanzi_feixue_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_Acc_HYtuanzi_feixue_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170064C9 RID: 25801
		// (get) Token: 0x06028E83 RID: 167555 RVA: 0x00A1A374 File Offset: 0x00A18574
		// (set) Token: 0x06028E84 RID: 167556 RVA: 0x00A1A3AD File Offset: 0x00A185AD
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Acc_HYtuanzi_feixue_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Acc_HYtuanzi_feixue_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06028E85 RID: 167557 RVA: 0x00A1A3D0 File Offset: 0x00A185D0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_Acc_HYtuanzi_feixue_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_Acc_HYtuanzi_feixue_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_Acc_HYtuanzi_feixue_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_Acc_HYtuanzi_feixue_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Acc_HYtuanzi_feixue_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x06028E86 RID: 167558 RVA: 0x00A1A458 File Offset: 0x00A18658
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_Acc_HYtuanzi_feixue(int EntryPoint)
		{
			ABP_Acc_HYtuanzi_feixue_C.__ExecuteUbergraph_ABP_Acc_HYtuanzi_feixue_FunctionParams* ptr = stackalloc ABP_Acc_HYtuanzi_feixue_C.__ExecuteUbergraph_ABP_Acc_HYtuanzi_feixue_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_Acc_HYtuanzi_feixue_C.__ExecuteUbergraph_ABP_Acc_HYtuanzi_feixue_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_Acc_HYtuanzi_feixue_C.__ExecuteUbergraph_ABP_Acc_HYtuanzi_feixue_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_Acc_HYtuanzi_feixue_C.__ExecuteUbergraph_ABP_Acc_HYtuanzi_feixue_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028E87 RID: 167559 RVA: 0x00A1A49F File Offset: 0x00A1869F
		protected ABP_Acc_HYtuanzi_feixue_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015A16 RID: 88598
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Diy/Accessory/Acc_HYtuanzi_feixue/ABP_Acc_HYtuanzi_feixue.ABP_Acc_HYtuanzi_feixue_C";

		// Token: 0x04015A17 RID: 88599
		private static IntPtr _ClassPtr;

		// Token: 0x04015A18 RID: 88600
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015A19 RID: 88601
		internal static int __PropertyOffset_0;

		// Token: 0x04015A1A RID: 88602
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015A1B RID: 88603
		internal static int __PropertyOffset_1;

		// Token: 0x04015A1C RID: 88604
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x04015A1D RID: 88605
		internal static int __PropertyOffset_2;

		// Token: 0x04015A1E RID: 88606
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x04015A1F RID: 88607
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x04015A20 RID: 88608
		private static IntPtr __ExecuteUbergraph_ABP_Acc_HYtuanzi_feixue_NativeFunctionPtr;

		// Token: 0x0200A163 RID: 41315
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x04032EA3 RID: 208547
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A164 RID: 41316
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_ABP_Acc_HYtuanzi_feixue_FunctionParams
		{
			// Token: 0x04032EA4 RID: 208548
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
