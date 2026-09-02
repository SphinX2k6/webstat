using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Diy.Accessory.Acc_AimisiDoll.Model
{
	// Token: 0x02003FA7 RID: 16295
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Diy/Accessory/Acc_AimisiDoll/Model/ABP_Acc_AimisiDoll.ABP_Acc_AimisiDoll_C")]
	[UnrealStructLayout(2464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2456)]
	public class ABP_Acc_AimisiDoll_C : UAnimInstance, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028E88 RID: 167560 RVA: 0x00A1A4A8 File Offset: 0x00A186A8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_Acc_AimisiDoll_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Diy/Accessory/Acc_AimisiDoll/Model/ABP_Acc_AimisiDoll.ABP_Acc_AimisiDoll_C");
			}
			return ABP_Acc_AimisiDoll_C._ClassPtr;
		}

		// Token: 0x06028E89 RID: 167561 RVA: 0x00A1A4CC File Offset: 0x00A186CC
		public ABP_Acc_AimisiDoll_C() : this(BuiltinUtils.AllocNativeUObject(ABP_Acc_AimisiDoll_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028E8A RID: 167562 RVA: 0x00A1A4F4 File Offset: 0x00A186F4
		public ABP_Acc_AimisiDoll_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_Acc_AimisiDoll_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170064CA RID: 25802
		// (get) Token: 0x06028E8B RID: 167563 RVA: 0x00A1A528 File Offset: 0x00A18728
		// (set) Token: 0x06028E8C RID: 167564 RVA: 0x00A1A561 File Offset: 0x00A18761
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_Acc_AimisiDoll_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_Acc_AimisiDoll_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170064CB RID: 25803
		// (get) Token: 0x06028E8D RID: 167565 RVA: 0x00A1A584 File Offset: 0x00A18784
		// (set) Token: 0x06028E8E RID: 167566 RVA: 0x00A1A5BD File Offset: 0x00A187BD
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_Acc_AimisiDoll_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_Acc_AimisiDoll_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170064CC RID: 25804
		// (get) Token: 0x06028E8F RID: 167567 RVA: 0x00A1A5E0 File Offset: 0x00A187E0
		// (set) Token: 0x06028E90 RID: 167568 RVA: 0x00A1A619 File Offset: 0x00A18819
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Acc_AimisiDoll_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Acc_AimisiDoll_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06028E91 RID: 167569 RVA: 0x00A1A63C File Offset: 0x00A1883C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_Acc_AimisiDoll_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_Acc_AimisiDoll_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_Acc_AimisiDoll_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_Acc_AimisiDoll_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Acc_AimisiDoll_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x06028E92 RID: 167570 RVA: 0x00A1A6C4 File Offset: 0x00A188C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_Acc_AimisiDoll(int EntryPoint)
		{
			ABP_Acc_AimisiDoll_C.__ExecuteUbergraph_ABP_Acc_AimisiDoll_FunctionParams* ptr = stackalloc ABP_Acc_AimisiDoll_C.__ExecuteUbergraph_ABP_Acc_AimisiDoll_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_Acc_AimisiDoll_C.__ExecuteUbergraph_ABP_Acc_AimisiDoll_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_Acc_AimisiDoll_C.__ExecuteUbergraph_ABP_Acc_AimisiDoll_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_Acc_AimisiDoll_C.__ExecuteUbergraph_ABP_Acc_AimisiDoll_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028E93 RID: 167571 RVA: 0x00A1A70B File Offset: 0x00A1890B
		protected ABP_Acc_AimisiDoll_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015A21 RID: 88609
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Diy/Accessory/Acc_AimisiDoll/Model/ABP_Acc_AimisiDoll.ABP_Acc_AimisiDoll_C";

		// Token: 0x04015A22 RID: 88610
		private static IntPtr _ClassPtr;

		// Token: 0x04015A23 RID: 88611
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015A24 RID: 88612
		internal static int __PropertyOffset_0;

		// Token: 0x04015A25 RID: 88613
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015A26 RID: 88614
		internal static int __PropertyOffset_1;

		// Token: 0x04015A27 RID: 88615
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x04015A28 RID: 88616
		internal static int __PropertyOffset_2;

		// Token: 0x04015A29 RID: 88617
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x04015A2A RID: 88618
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x04015A2B RID: 88619
		private static IntPtr __ExecuteUbergraph_ABP_Acc_AimisiDoll_NativeFunctionPtr;

		// Token: 0x0200A165 RID: 41317
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x04032EA5 RID: 208549
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A166 RID: 41318
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_ABP_Acc_AimisiDoll_FunctionParams
		{
			// Token: 0x04032EA6 RID: 208550
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
