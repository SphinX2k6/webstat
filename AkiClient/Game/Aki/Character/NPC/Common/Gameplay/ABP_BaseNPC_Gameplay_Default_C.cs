using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Common.Gameplay
{
	// Token: 0x020040EF RID: 16623
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Common/Gameplay/ABP_BaseNPC_Gameplay_Default.ABP_BaseNPC_Gameplay_Default_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2240)]
	public class ABP_BaseNPC_Gameplay_Default_C : UAnimInstance, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C0F4 RID: 180468 RVA: 0x00A9376B File Offset: 0x00A9196B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_BaseNPC_Gameplay_Default_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Common/Gameplay/ABP_BaseNPC_Gameplay_Default.ABP_BaseNPC_Gameplay_Default_C");
			}
			return ABP_BaseNPC_Gameplay_Default_C._ClassPtr;
		}

		// Token: 0x0602C0F5 RID: 180469 RVA: 0x00A93790 File Offset: 0x00A91990
		public ABP_BaseNPC_Gameplay_Default_C() : this(BuiltinUtils.AllocNativeUObject(ABP_BaseNPC_Gameplay_Default_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C0F6 RID: 180470 RVA: 0x00A937B8 File Offset: 0x00A919B8
		public ABP_BaseNPC_Gameplay_Default_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_BaseNPC_Gameplay_Default_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170075E5 RID: 30181
		// (get) Token: 0x0602C0F7 RID: 180471 RVA: 0x00A937EC File Offset: 0x00A919EC
		// (set) Token: 0x0602C0F8 RID: 180472 RVA: 0x00A93825 File Offset: 0x00A91A25
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_BaseNPC_Gameplay_Default_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_Gameplay_Default_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075E6 RID: 30182
		// (get) Token: 0x0602C0F9 RID: 180473 RVA: 0x00A93848 File Offset: 0x00A91A48
		// (set) Token: 0x0602C0FA RID: 180474 RVA: 0x00A93881 File Offset: 0x00A91A81
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseNPC_Gameplay_Default_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_Gameplay_Default_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602C0FB RID: 180475 RVA: 0x00A938A4 File Offset: 0x00A91AA4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_BaseNPC_Gameplay_Default_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_BaseNPC_Gameplay_Default_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_BaseNPC_Gameplay_Default_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseNPC_Gameplay_Default_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_Gameplay_Default_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0602C0FC RID: 180476 RVA: 0x00A9392C File Offset: 0x00A91B2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_BaseNPC_Gameplay_Default(int EntryPoint)
		{
			ABP_BaseNPC_Gameplay_Default_C.__ExecuteUbergraph_ABP_BaseNPC_Gameplay_Default_FunctionParams* ptr = stackalloc ABP_BaseNPC_Gameplay_Default_C.__ExecuteUbergraph_ABP_BaseNPC_Gameplay_Default_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseNPC_Gameplay_Default_C.__ExecuteUbergraph_ABP_BaseNPC_Gameplay_Default_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseNPC_Gameplay_Default_C.__ExecuteUbergraph_ABP_BaseNPC_Gameplay_Default_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseNPC_Gameplay_Default_C.__ExecuteUbergraph_ABP_BaseNPC_Gameplay_Default_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C0FD RID: 180477 RVA: 0x00A93973 File Offset: 0x00A91B73
		protected ABP_BaseNPC_Gameplay_Default_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040185B4 RID: 99764
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Common/Gameplay/ABP_BaseNPC_Gameplay_Default.ABP_BaseNPC_Gameplay_Default_C";

		// Token: 0x040185B5 RID: 99765
		private static IntPtr _ClassPtr;

		// Token: 0x040185B6 RID: 99766
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040185B7 RID: 99767
		internal static int __PropertyOffset_0;

		// Token: 0x040185B8 RID: 99768
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040185B9 RID: 99769
		internal static int __PropertyOffset_1;

		// Token: 0x040185BA RID: 99770
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x040185BB RID: 99771
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x040185BC RID: 99772
		private static IntPtr __ExecuteUbergraph_ABP_BaseNPC_Gameplay_Default_NativeFunctionPtr;

		// Token: 0x0200A420 RID: 42016
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x04033217 RID: 209431
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A421 RID: 42017
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_ABP_BaseNPC_Gameplay_Default_FunctionParams
		{
			// Token: 0x04033218 RID: 209432
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
