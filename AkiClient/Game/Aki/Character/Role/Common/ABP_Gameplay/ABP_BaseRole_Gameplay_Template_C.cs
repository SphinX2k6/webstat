using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.ABP_Gameplay
{
	// Token: 0x02004072 RID: 16498
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/ABP_Gameplay/ABP_BaseRole_Gameplay_Template.ABP_BaseRole_Gameplay_Template_C")]
	[UnrealStructLayout(3824, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 3824)]
	public class ABP_BaseRole_Gameplay_Template_C : UKuroAnimInstanceRole, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602ADB8 RID: 175544 RVA: 0x00A676A8 File Offset: 0x00A658A8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_BaseRole_Gameplay_Template_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/ABP_Gameplay/ABP_BaseRole_Gameplay_Template.ABP_BaseRole_Gameplay_Template_C");
			}
			return ABP_BaseRole_Gameplay_Template_C._ClassPtr;
		}

		// Token: 0x0602ADB9 RID: 175545 RVA: 0x00A676CC File Offset: 0x00A658CC
		public ABP_BaseRole_Gameplay_Template_C() : this(BuiltinUtils.AllocNativeUObject(ABP_BaseRole_Gameplay_Template_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602ADBA RID: 175546 RVA: 0x00A676F4 File Offset: 0x00A658F4
		public ABP_BaseRole_Gameplay_Template_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_BaseRole_Gameplay_Template_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006FF8 RID: 28664
		// (get) Token: 0x0602ADBB RID: 175547 RVA: 0x00A67728 File Offset: 0x00A65928
		// (set) Token: 0x0602ADBC RID: 175548 RVA: 0x00A67761 File Offset: 0x00A65961
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Template_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Template_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FF9 RID: 28665
		// (get) Token: 0x0602ADBD RID: 175549 RVA: 0x00A67784 File Offset: 0x00A65984
		// (set) Token: 0x0602ADBE RID: 175550 RVA: 0x00A677BD File Offset: 0x00A659BD
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Template_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Template_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602ADBF RID: 175551 RVA: 0x00A677E0 File Offset: 0x00A659E0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_BaseRole_Gameplay_Template_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_BaseRole_Gameplay_Template_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_BaseRole_Gameplay_Template_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_Gameplay_Template_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Template_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0602ADC0 RID: 175552 RVA: 0x00A67868 File Offset: 0x00A65A68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_BaseRole_Gameplay_Template(int EntryPoint)
		{
			ABP_BaseRole_Gameplay_Template_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_Template_FunctionParams* ptr = stackalloc ABP_BaseRole_Gameplay_Template_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_Template_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseRole_Gameplay_Template_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_Template_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_Gameplay_Template_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_Template_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Template_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_Template_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602ADC1 RID: 175553 RVA: 0x00A678AF File Offset: 0x00A65AAF
		protected ABP_BaseRole_Gameplay_Template_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017665 RID: 95845
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/ABP_Gameplay/ABP_BaseRole_Gameplay_Template.ABP_BaseRole_Gameplay_Template_C";

		// Token: 0x04017666 RID: 95846
		private static IntPtr _ClassPtr;

		// Token: 0x04017667 RID: 95847
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017668 RID: 95848
		internal static int __PropertyOffset_0;

		// Token: 0x04017669 RID: 95849
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401766A RID: 95850
		internal static int __PropertyOffset_1;

		// Token: 0x0401766B RID: 95851
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x0401766C RID: 95852
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x0401766D RID: 95853
		private static IntPtr __ExecuteUbergraph_ABP_BaseRole_Gameplay_Template_NativeFunctionPtr;

		// Token: 0x0200A267 RID: 41575
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x04033011 RID: 208913
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A268 RID: 41576
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_ABP_BaseRole_Gameplay_Template_FunctionParams
		{
			// Token: 0x04033012 RID: 208914
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
