using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common
{
	// Token: 0x02003FFB RID: 16379
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/ABP_PhysicsClothBlendAlpha_Template.ABP_PhysicsClothBlendAlpha_Template_C")]
	[UnrealStructLayout(3040, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 3032)]
	public class ABP_PhysicsClothBlendAlpha_Template_C : UAnimInstance, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A848 RID: 174152 RVA: 0x00A5B933 File Offset: 0x00A59B33
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_PhysicsClothBlendAlpha_Template_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/ABP_PhysicsClothBlendAlpha_Template.ABP_PhysicsClothBlendAlpha_Template_C");
			}
			return ABP_PhysicsClothBlendAlpha_Template_C._ClassPtr;
		}

		// Token: 0x0602A849 RID: 174153 RVA: 0x00A5B958 File Offset: 0x00A59B58
		public ABP_PhysicsClothBlendAlpha_Template_C() : this(BuiltinUtils.AllocNativeUObject(ABP_PhysicsClothBlendAlpha_Template_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A84A RID: 174154 RVA: 0x00A5B980 File Offset: 0x00A59B80
		public ABP_PhysicsClothBlendAlpha_Template_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_PhysicsClothBlendAlpha_Template_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006E7A RID: 28282
		// (get) Token: 0x0602A84B RID: 174155 RVA: 0x00A5B9B4 File Offset: 0x00A59BB4
		// (set) Token: 0x0602A84C RID: 174156 RVA: 0x00A5B9ED File Offset: 0x00A59BED
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_PhysicsClothBlendAlpha_Template_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_PhysicsClothBlendAlpha_Template_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E7B RID: 28283
		// (get) Token: 0x0602A84D RID: 174157 RVA: 0x00A5BA10 File Offset: 0x00A59C10
		// (set) Token: 0x0602A84E RID: 174158 RVA: 0x00A5BA49 File Offset: 0x00A59C49
		public FAnimNode_Root AnimGraphNode_Root_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_1) == null)
				{
					result = (this._AnimGraphNode_Root_1 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_PhysicsClothBlendAlpha_Template_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_PhysicsClothBlendAlpha_Template_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E7C RID: 28284
		// (get) Token: 0x0602A84F RID: 174159 RVA: 0x00A5BA6C File Offset: 0x00A59C6C
		// (set) Token: 0x0602A850 RID: 174160 RVA: 0x00A5BAA5 File Offset: 0x00A59CA5
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_PhysicsClothBlendAlpha_Template_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_PhysicsClothBlendAlpha_Template_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E7D RID: 28285
		// (get) Token: 0x0602A851 RID: 174161 RVA: 0x00A5BAC8 File Offset: 0x00A59CC8
		// (set) Token: 0x0602A852 RID: 174162 RVA: 0x00A5BB01 File Offset: 0x00A59D01
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_PhysicsClothBlendAlpha_Template_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_PhysicsClothBlendAlpha_Template_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E7E RID: 28286
		// (get) Token: 0x0602A853 RID: 174163 RVA: 0x00A5BB24 File Offset: 0x00A59D24
		// (set) Token: 0x0602A854 RID: 174164 RVA: 0x00A5BB5D File Offset: 0x00A59D5D
		public FAnimNode_LinkedAnimGraph AnimGraphNode_LinkedAnimGraph
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimGraph result;
				if ((result = this._AnimGraphNode_LinkedAnimGraph) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimGraph = new FAnimNode_LinkedAnimGraph(base.NativePtr + (IntPtr)ABP_PhysicsClothBlendAlpha_Template_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimGraph.StaticStruct(), base.NativePtr + (IntPtr)ABP_PhysicsClothBlendAlpha_Template_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E7F RID: 28287
		// (get) Token: 0x0602A855 RID: 174165 RVA: 0x00A5BB80 File Offset: 0x00A59D80
		// (set) Token: 0x0602A856 RID: 174166 RVA: 0x00A5BBB9 File Offset: 0x00A59DB9
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_PhysicsClothBlendAlpha_Template_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PhysicsClothBlendAlpha_Template_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E80 RID: 28288
		// (get) Token: 0x0602A857 RID: 174167 RVA: 0x00A5BBDA File Offset: 0x00A59DDA
		// (set) Token: 0x0602A858 RID: 174168 RVA: 0x00A5BBEA File Offset: 0x00A59DEA
		public unsafe bool PhysicsClothSimulateEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PhysicsClothBlendAlpha_Template_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PhysicsClothBlendAlpha_Template_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006E81 RID: 28289
		// (get) Token: 0x0602A859 RID: 174169 RVA: 0x00A5BBFB File Offset: 0x00A59DFB
		// (set) Token: 0x0602A85A RID: 174170 RVA: 0x00A5BC0B File Offset: 0x00A59E0B
		public unsafe float PhysicsClothSimulateScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PhysicsClothBlendAlpha_Template_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PhysicsClothBlendAlpha_Template_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x0602A85B RID: 174171 RVA: 0x00A5BC1C File Offset: 0x00A59E1C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void PhyCloth(FPoseLink InPose, ref FPoseLink PhyCloth)
		{
			ABP_PhysicsClothBlendAlpha_Template_C.__PhyCloth_FunctionParams* ptr = stackalloc ABP_PhysicsClothBlendAlpha_Template_C.__PhyCloth_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(ABP_PhysicsClothBlendAlpha_Template_C.__PhyCloth_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PhysicsClothBlendAlpha_Template_C.__PhyCloth_NativeFunctionPtr, (void*)ptr, 1);
			if (InPose != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->InPose, InPose.NativePtr, 1, false);
			}
			if (PhyCloth != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->PhyCloth, PhyCloth.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PhysicsClothBlendAlpha_Template_C.__PhyCloth_NativeFunctionPtr, (void*)ptr);
			if (PhyCloth != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), PhyCloth.NativePtr, &ptr->PhyCloth, 1, false);
			}
		}

		// Token: 0x0602A85C RID: 174172 RVA: 0x00A5BCC8 File Offset: 0x00A59EC8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_PhysicsClothBlendAlpha_Template_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_PhysicsClothBlendAlpha_Template_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_PhysicsClothBlendAlpha_Template_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PhysicsClothBlendAlpha_Template_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PhysicsClothBlendAlpha_Template_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0602A85D RID: 174173 RVA: 0x00A5BD50 File Offset: 0x00A59F50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdatePhysicsClothSimulateEnable(float DeltaTIme)
		{
			ABP_PhysicsClothBlendAlpha_Template_C.__UpdatePhysicsClothSimulateEnable_FunctionParams* ptr = stackalloc ABP_PhysicsClothBlendAlpha_Template_C.__UpdatePhysicsClothSimulateEnable_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(ABP_PhysicsClothBlendAlpha_Template_C.__UpdatePhysicsClothSimulateEnable_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PhysicsClothBlendAlpha_Template_C.__UpdatePhysicsClothSimulateEnable_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTIme = DeltaTIme;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PhysicsClothBlendAlpha_Template_C.__UpdatePhysicsClothSimulateEnable_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602A85E RID: 174174 RVA: 0x00A5BD98 File Offset: 0x00A59F98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void BlueprintUpdateAnimation(float DeltaTimeX)
		{
			ABP_PhysicsClothBlendAlpha_Template_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_PhysicsClothBlendAlpha_Template_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_PhysicsClothBlendAlpha_Template_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PhysicsClothBlendAlpha_Template_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PhysicsClothBlendAlpha_Template_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602A85F RID: 174175 RVA: 0x00A5BDE0 File Offset: 0x00A59FE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BlueprintUpdateAnimation_Implementation(float DeltaTimeX)
		{
			ABP_PhysicsClothBlendAlpha_Template_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_PhysicsClothBlendAlpha_Template_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_PhysicsClothBlendAlpha_Template_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PhysicsClothBlendAlpha_Template_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_PhysicsClothBlendAlpha_Template_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602A860 RID: 174176 RVA: 0x00A5BE28 File Offset: 0x00A5A028
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_PhysicsClothBlendAlpha_Template(int EntryPoint)
		{
			ABP_PhysicsClothBlendAlpha_Template_C.__ExecuteUbergraph_ABP_PhysicsClothBlendAlpha_Template_FunctionParams* ptr = stackalloc ABP_PhysicsClothBlendAlpha_Template_C.__ExecuteUbergraph_ABP_PhysicsClothBlendAlpha_Template_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(ABP_PhysicsClothBlendAlpha_Template_C.__ExecuteUbergraph_ABP_PhysicsClothBlendAlpha_Template_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PhysicsClothBlendAlpha_Template_C.__ExecuteUbergraph_ABP_PhysicsClothBlendAlpha_Template_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_PhysicsClothBlendAlpha_Template_C.__ExecuteUbergraph_ABP_PhysicsClothBlendAlpha_Template_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602A861 RID: 174177 RVA: 0x00A5BE6F File Offset: 0x00A5A06F
		protected ABP_PhysicsClothBlendAlpha_Template_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040171ED RID: 94701
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/ABP_PhysicsClothBlendAlpha_Template.ABP_PhysicsClothBlendAlpha_Template_C";

		// Token: 0x040171EE RID: 94702
		private static IntPtr _ClassPtr;

		// Token: 0x040171EF RID: 94703
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040171F0 RID: 94704
		internal static int __PropertyOffset_0;

		// Token: 0x040171F1 RID: 94705
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040171F2 RID: 94706
		internal static int __PropertyOffset_1;

		// Token: 0x040171F3 RID: 94707
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_1;

		// Token: 0x040171F4 RID: 94708
		internal static int __PropertyOffset_2;

		// Token: 0x040171F5 RID: 94709
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose;

		// Token: 0x040171F6 RID: 94710
		internal static int __PropertyOffset_3;

		// Token: 0x040171F7 RID: 94711
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x040171F8 RID: 94712
		internal static int __PropertyOffset_4;

		// Token: 0x040171F9 RID: 94713
		[Nullable(2)]
		private FAnimNode_LinkedAnimGraph _AnimGraphNode_LinkedAnimGraph;

		// Token: 0x040171FA RID: 94714
		internal static int __PropertyOffset_5;

		// Token: 0x040171FB RID: 94715
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer;

		// Token: 0x040171FC RID: 94716
		internal static int __PropertyOffset_6;

		// Token: 0x040171FD RID: 94717
		internal static int __PropertyOffset_7;

		// Token: 0x040171FE RID: 94718
		private static IntPtr __PhyCloth_NativeFunctionPtr;

		// Token: 0x040171FF RID: 94719
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x04017200 RID: 94720
		private static IntPtr __UpdatePhysicsClothSimulateEnable_NativeFunctionPtr;

		// Token: 0x04017201 RID: 94721
		private static IntPtr __BlueprintUpdateAnimation_NativeFunctionPtr;

		// Token: 0x04017202 RID: 94722
		private static IntPtr __ExecuteUbergraph_ABP_PhysicsClothBlendAlpha_Template_NativeFunctionPtr;

		// Token: 0x0200A24E RID: 41550
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __PhyCloth_FunctionParams
		{
			// Token: 0x04032FF6 RID: 208886
			[FieldOffset(0)]
			public byte InPose;

			// Token: 0x04032FF7 RID: 208887
			[FieldOffset(24)]
			public byte PhyCloth;
		}

		// Token: 0x0200A24F RID: 41551
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x04032FF8 RID: 208888
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A250 RID: 41552
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __UpdatePhysicsClothSimulateEnable_FunctionParams
		{
			// Token: 0x04032FF9 RID: 208889
			[FieldOffset(0)]
			public float DeltaTIme;
		}

		// Token: 0x0200A251 RID: 41553
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __BlueprintUpdateAnimation_FunctionParams
		{
			// Token: 0x04032FFA RID: 208890
			[FieldOffset(0)]
			public float DeltaTimeX;
		}

		// Token: 0x0200A252 RID: 41554
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_ABP_PhysicsClothBlendAlpha_Template_FunctionParams
		{
			// Token: 0x04032FFB RID: 208891
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
