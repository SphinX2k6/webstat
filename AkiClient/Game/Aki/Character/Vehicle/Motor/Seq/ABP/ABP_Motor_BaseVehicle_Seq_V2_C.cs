using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Seq.ABP
{
	// Token: 0x02003F9D RID: 16285
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Seq/ABP/ABP_Motor_BaseVehicle_Seq_V2.ABP_Motor_BaseVehicle_Seq_V2_C")]
	[UnrealStructLayout(2672, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2664)]
	public class ABP_Motor_BaseVehicle_Seq_V2_C : UAnimInstance, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028D35 RID: 167221 RVA: 0x00A17C7C File Offset: 0x00A15E7C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_Motor_BaseVehicle_Seq_V2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Seq/ABP/ABP_Motor_BaseVehicle_Seq_V2.ABP_Motor_BaseVehicle_Seq_V2_C");
			}
			return ABP_Motor_BaseVehicle_Seq_V2_C._ClassPtr;
		}

		// Token: 0x06028D36 RID: 167222 RVA: 0x00A17CA0 File Offset: 0x00A15EA0
		public ABP_Motor_BaseVehicle_Seq_V2_C() : this(BuiltinUtils.AllocNativeUObject(ABP_Motor_BaseVehicle_Seq_V2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028D37 RID: 167223 RVA: 0x00A17CC8 File Offset: 0x00A15EC8
		public ABP_Motor_BaseVehicle_Seq_V2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_Motor_BaseVehicle_Seq_V2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700644A RID: 25674
		// (get) Token: 0x06028D38 RID: 167224 RVA: 0x00A17CFC File Offset: 0x00A15EFC
		// (set) Token: 0x06028D39 RID: 167225 RVA: 0x00A17D35 File Offset: 0x00A15F35
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_Seq_V2_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_Seq_V2_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700644B RID: 25675
		// (get) Token: 0x06028D3A RID: 167226 RVA: 0x00A17D58 File Offset: 0x00A15F58
		// (set) Token: 0x06028D3B RID: 167227 RVA: 0x00A17D91 File Offset: 0x00A15F91
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_Seq_V2_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_Seq_V2_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700644C RID: 25676
		// (get) Token: 0x06028D3C RID: 167228 RVA: 0x00A17DB4 File Offset: 0x00A15FB4
		// (set) Token: 0x06028D3D RID: 167229 RVA: 0x00A17DED File Offset: 0x00A15FED
		public FAnimNode_Slot AnimGraphNode_Slot
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot) == null)
				{
					result = (this._AnimGraphNode_Slot = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_Seq_V2_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_Seq_V2_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700644D RID: 25677
		// (get) Token: 0x06028D3E RID: 167230 RVA: 0x00A17E10 File Offset: 0x00A16010
		// (set) Token: 0x06028D3F RID: 167231 RVA: 0x00A17E49 File Offset: 0x00A16049
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_Seq_V2_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_Seq_V2_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06028D40 RID: 167232 RVA: 0x00A17E6C File Offset: 0x00A1606C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(FPoseLink InPose, ref FPoseLink AnimGraph)
		{
			ABP_Motor_BaseVehicle_Seq_V2_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_Motor_BaseVehicle_Seq_V2_C.__AnimGraph_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(ABP_Motor_BaseVehicle_Seq_V2_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_Motor_BaseVehicle_Seq_V2_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (InPose != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->InPose, InPose.NativePtr, 1, false);
			}
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Motor_BaseVehicle_Seq_V2_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x06028D41 RID: 167233 RVA: 0x00A17F18 File Offset: 0x00A16118
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_Motor_BaseVehicle_Seq_V2(int EntryPoint)
		{
			ABP_Motor_BaseVehicle_Seq_V2_C.__ExecuteUbergraph_ABP_Motor_BaseVehicle_Seq_V2_FunctionParams* ptr = stackalloc ABP_Motor_BaseVehicle_Seq_V2_C.__ExecuteUbergraph_ABP_Motor_BaseVehicle_Seq_V2_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_Motor_BaseVehicle_Seq_V2_C.__ExecuteUbergraph_ABP_Motor_BaseVehicle_Seq_V2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_Motor_BaseVehicle_Seq_V2_C.__ExecuteUbergraph_ABP_Motor_BaseVehicle_Seq_V2_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_Motor_BaseVehicle_Seq_V2_C.__ExecuteUbergraph_ABP_Motor_BaseVehicle_Seq_V2_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028D42 RID: 167234 RVA: 0x00A17F5F File Offset: 0x00A1615F
		protected ABP_Motor_BaseVehicle_Seq_V2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401594D RID: 88397
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Seq/ABP/ABP_Motor_BaseVehicle_Seq_V2.ABP_Motor_BaseVehicle_Seq_V2_C";

		// Token: 0x0401594E RID: 88398
		private static IntPtr _ClassPtr;

		// Token: 0x0401594F RID: 88399
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015950 RID: 88400
		internal static int __PropertyOffset_0;

		// Token: 0x04015951 RID: 88401
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015952 RID: 88402
		internal static int __PropertyOffset_1;

		// Token: 0x04015953 RID: 88403
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x04015954 RID: 88404
		internal static int __PropertyOffset_2;

		// Token: 0x04015955 RID: 88405
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot;

		// Token: 0x04015956 RID: 88406
		internal static int __PropertyOffset_3;

		// Token: 0x04015957 RID: 88407
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose;

		// Token: 0x04015958 RID: 88408
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x04015959 RID: 88409
		private static IntPtr __ExecuteUbergraph_ABP_Motor_BaseVehicle_Seq_V2_NativeFunctionPtr;

		// Token: 0x0200A14F RID: 41295
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x04032E87 RID: 208519
			[FieldOffset(0)]
			public byte InPose;

			// Token: 0x04032E88 RID: 208520
			[FieldOffset(24)]
			public byte AnimGraph;
		}

		// Token: 0x0200A150 RID: 41296
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_ABP_Motor_BaseVehicle_Seq_V2_FunctionParams
		{
			// Token: 0x04032E89 RID: 208521
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
