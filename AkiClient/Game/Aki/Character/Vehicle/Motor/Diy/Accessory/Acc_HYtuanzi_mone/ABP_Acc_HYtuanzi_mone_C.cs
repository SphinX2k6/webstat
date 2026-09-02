using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Diy.Accessory.Acc_HYtuanzi_mone
{
	// Token: 0x02003FA5 RID: 16293
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Diy/Accessory/Acc_HYtuanzi_mone/ABP_Acc_HYtuanzi_mone.ABP_Acc_HYtuanzi_mone_C")]
	[UnrealStructLayout(2464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2456)]
	public class ABP_Acc_HYtuanzi_mone_C : UAnimInstance, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028E70 RID: 167536 RVA: 0x00A19FCD File Offset: 0x00A181CD
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_Acc_HYtuanzi_mone_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Diy/Accessory/Acc_HYtuanzi_mone/ABP_Acc_HYtuanzi_mone.ABP_Acc_HYtuanzi_mone_C");
			}
			return ABP_Acc_HYtuanzi_mone_C._ClassPtr;
		}

		// Token: 0x06028E71 RID: 167537 RVA: 0x00A19FF4 File Offset: 0x00A181F4
		public ABP_Acc_HYtuanzi_mone_C() : this(BuiltinUtils.AllocNativeUObject(ABP_Acc_HYtuanzi_mone_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028E72 RID: 167538 RVA: 0x00A1A01C File Offset: 0x00A1821C
		public ABP_Acc_HYtuanzi_mone_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_Acc_HYtuanzi_mone_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170064C4 RID: 25796
		// (get) Token: 0x06028E73 RID: 167539 RVA: 0x00A1A050 File Offset: 0x00A18250
		// (set) Token: 0x06028E74 RID: 167540 RVA: 0x00A1A089 File Offset: 0x00A18289
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_Acc_HYtuanzi_mone_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_Acc_HYtuanzi_mone_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170064C5 RID: 25797
		// (get) Token: 0x06028E75 RID: 167541 RVA: 0x00A1A0AC File Offset: 0x00A182AC
		// (set) Token: 0x06028E76 RID: 167542 RVA: 0x00A1A0E5 File Offset: 0x00A182E5
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_Acc_HYtuanzi_mone_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_Acc_HYtuanzi_mone_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170064C6 RID: 25798
		// (get) Token: 0x06028E77 RID: 167543 RVA: 0x00A1A108 File Offset: 0x00A18308
		// (set) Token: 0x06028E78 RID: 167544 RVA: 0x00A1A141 File Offset: 0x00A18341
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Acc_HYtuanzi_mone_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Acc_HYtuanzi_mone_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06028E79 RID: 167545 RVA: 0x00A1A164 File Offset: 0x00A18364
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_Acc_HYtuanzi_mone_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_Acc_HYtuanzi_mone_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_Acc_HYtuanzi_mone_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_Acc_HYtuanzi_mone_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Acc_HYtuanzi_mone_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x06028E7A RID: 167546 RVA: 0x00A1A1EC File Offset: 0x00A183EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_Acc_HYtuanzi_mone(int EntryPoint)
		{
			ABP_Acc_HYtuanzi_mone_C.__ExecuteUbergraph_ABP_Acc_HYtuanzi_mone_FunctionParams* ptr = stackalloc ABP_Acc_HYtuanzi_mone_C.__ExecuteUbergraph_ABP_Acc_HYtuanzi_mone_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_Acc_HYtuanzi_mone_C.__ExecuteUbergraph_ABP_Acc_HYtuanzi_mone_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_Acc_HYtuanzi_mone_C.__ExecuteUbergraph_ABP_Acc_HYtuanzi_mone_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_Acc_HYtuanzi_mone_C.__ExecuteUbergraph_ABP_Acc_HYtuanzi_mone_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028E7B RID: 167547 RVA: 0x00A1A233 File Offset: 0x00A18433
		protected ABP_Acc_HYtuanzi_mone_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015A0B RID: 88587
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Diy/Accessory/Acc_HYtuanzi_mone/ABP_Acc_HYtuanzi_mone.ABP_Acc_HYtuanzi_mone_C";

		// Token: 0x04015A0C RID: 88588
		private static IntPtr _ClassPtr;

		// Token: 0x04015A0D RID: 88589
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015A0E RID: 88590
		internal static int __PropertyOffset_0;

		// Token: 0x04015A0F RID: 88591
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015A10 RID: 88592
		internal static int __PropertyOffset_1;

		// Token: 0x04015A11 RID: 88593
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x04015A12 RID: 88594
		internal static int __PropertyOffset_2;

		// Token: 0x04015A13 RID: 88595
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x04015A14 RID: 88596
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x04015A15 RID: 88597
		private static IntPtr __ExecuteUbergraph_ABP_Acc_HYtuanzi_mone_NativeFunctionPtr;

		// Token: 0x0200A161 RID: 41313
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x04032EA1 RID: 208545
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A162 RID: 41314
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_ABP_Acc_HYtuanzi_mone_FunctionParams
		{
			// Token: 0x04032EA2 RID: 208546
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
