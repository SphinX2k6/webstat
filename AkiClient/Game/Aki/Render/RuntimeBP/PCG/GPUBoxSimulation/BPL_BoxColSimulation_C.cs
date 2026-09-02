using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GPUBoxSimulation
{
	// Token: 0x02003C21 RID: 15393
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/BPL_BoxColSimulation.BPL_BoxColSimulation_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public class BPL_BoxColSimulation_C : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060231AA RID: 143786 RVA: 0x00978A50 File Offset: 0x00976C50
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BPL_BoxColSimulation_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/BPL_BoxColSimulation.BPL_BoxColSimulation_C");
			}
			return BPL_BoxColSimulation_C._ClassPtr;
		}

		// Token: 0x060231AB RID: 143787 RVA: 0x00978A74 File Offset: 0x00976C74
		public BPL_BoxColSimulation_C() : this(BuiltinUtils.AllocNativeUObject(BPL_BoxColSimulation_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060231AC RID: 143788 RVA: 0x00978A9C File Offset: 0x00976C9C
		[NullableContext(1)]
		public BPL_BoxColSimulation_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BPL_BoxColSimulation_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x060231AD RID: 143789 RVA: 0x00978AD0 File Offset: 0x00976CD0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void Setup_Params_From_DA_ForCloth_Use_Inside_BP_(BP_genCloth_C GenCloth, PD_MeshToBoxData_C DA, UObject __WorldContext, ref bool Find)
		{
			BPL_BoxColSimulation_C.StaticClass();
			BPL_BoxColSimulation_C.__Setup_Params_From_DA_ForCloth_Use_Inside_BP__FunctionParams* ptr = stackalloc BPL_BoxColSimulation_C.__Setup_Params_From_DA_ForCloth_Use_Inside_BP__FunctionParams[(UIntPtr)239] + 15L / (long)sizeof(BPL_BoxColSimulation_C.__Setup_Params_From_DA_ForCloth_Use_Inside_BP__FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_BoxColSimulation_C.__Setup_Params_From_DA_ForCloth_Use_Inside_BP__NativeFunctionPtr, (void*)ptr, 1);
			ptr->GenCloth = ((GenCloth != null) ? GenCloth.NativePtr : IntPtr.Zero);
			ptr->DA = ((DA != null) ? DA.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->Find = Find;
			UnrealReflectionUtils.CallVirtualUFunction(BPL_BoxColSimulation_C._ClassDefaultObjectPtr, BPL_BoxColSimulation_C.__Setup_Params_From_DA_ForCloth_Use_Inside_BP__NativeFunctionPtr, (void*)ptr);
			Find = ptr->Find;
		}

		// Token: 0x060231AE RID: 143790 RVA: 0x00978B6C File Offset: 0x00976D6C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void Setup_Params_From_DA_ForCloth(BP_genCloth_C GenCloth, PD_MeshToBoxData_C DA, UObject __WorldContext, ref bool Find)
		{
			BPL_BoxColSimulation_C.StaticClass();
			BPL_BoxColSimulation_C.__Setup_Params_From_DA_ForCloth_FunctionParams* ptr = stackalloc BPL_BoxColSimulation_C.__Setup_Params_From_DA_ForCloth_FunctionParams[(UIntPtr)231] + 15L / (long)sizeof(BPL_BoxColSimulation_C.__Setup_Params_From_DA_ForCloth_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_BoxColSimulation_C.__Setup_Params_From_DA_ForCloth_NativeFunctionPtr, (void*)ptr, 1);
			ptr->GenCloth = ((GenCloth != null) ? GenCloth.NativePtr : IntPtr.Zero);
			ptr->DA = ((DA != null) ? DA.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->Find = Find;
			UnrealReflectionUtils.CallVirtualUFunction(BPL_BoxColSimulation_C._ClassDefaultObjectPtr, BPL_BoxColSimulation_C.__Setup_Params_From_DA_ForCloth_NativeFunctionPtr, (void*)ptr);
			Find = ptr->Find;
		}

		// Token: 0x060231AF RID: 143791 RVA: 0x00978C08 File Offset: 0x00976E08
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void boxCol_SM_2_SM_(PD_SM_2_BPSM_C DASM2SM, UStaticMesh SMInput, UObject __WorldContext, ref UStaticMesh SM, ref bool Find)
		{
			BPL_BoxColSimulation_C.StaticClass();
			BPL_BoxColSimulation_C.__boxCol_SM_2_SM__FunctionParams* ptr = stackalloc BPL_BoxColSimulation_C.__boxCol_SM_2_SM__FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(BPL_BoxColSimulation_C.__boxCol_SM_2_SM__FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_BoxColSimulation_C.__boxCol_SM_2_SM__NativeFunctionPtr, (void*)ptr, 1);
			ptr->DASM2SM = ((DASM2SM != null) ? DASM2SM.NativePtr : IntPtr.Zero);
			ptr->SMInput = ((SMInput != null) ? SMInput.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ref BPL_BoxColSimulation_C.__boxCol_SM_2_SM__FunctionParams ptr2 = ref *ptr;
			UStaticMesh ustaticMesh = SM;
			ptr2.SM = ((ustaticMesh != null) ? ustaticMesh.NativePtr : IntPtr.Zero);
			ptr->Find = Find;
			UnrealReflectionUtils.CallVirtualUFunction(BPL_BoxColSimulation_C._ClassDefaultObjectPtr, BPL_BoxColSimulation_C.__boxCol_SM_2_SM__NativeFunctionPtr, (void*)ptr);
			SM = BuiltinUtils.GetOrCreateUObjectByNativePointer<UStaticMesh>(ptr->SM);
			Find = ptr->Find;
		}

		// Token: 0x060231B0 RID: 143792 RVA: 0x00978CC8 File Offset: 0x00976EC8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void Setup_Params_From_DA__Use_Inside_BP_(BP_BoxCol_C BoxCol, PD_MeshToBoxData_C DA, UStaticMesh staticMesh, UObject __WorldContext, ref bool Find)
		{
			BPL_BoxColSimulation_C.StaticClass();
			BPL_BoxColSimulation_C.__Setup_Params_From_DA__Use_Inside_BP__FunctionParams* ptr = stackalloc BPL_BoxColSimulation_C.__Setup_Params_From_DA__Use_Inside_BP__FunctionParams[(UIntPtr)239] + 15L / (long)sizeof(BPL_BoxColSimulation_C.__Setup_Params_From_DA__Use_Inside_BP__FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_BoxColSimulation_C.__Setup_Params_From_DA__Use_Inside_BP__NativeFunctionPtr, (void*)ptr, 1);
			ptr->BoxCol = ((BoxCol != null) ? BoxCol.NativePtr : IntPtr.Zero);
			ptr->DA = ((DA != null) ? DA.NativePtr : IntPtr.Zero);
			ptr->staticMesh = ((staticMesh != null) ? staticMesh.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->Find = Find;
			UnrealReflectionUtils.CallVirtualUFunction(BPL_BoxColSimulation_C._ClassDefaultObjectPtr, BPL_BoxColSimulation_C.__Setup_Params_From_DA__Use_Inside_BP__NativeFunctionPtr, (void*)ptr);
			Find = ptr->Find;
		}

		// Token: 0x060231B1 RID: 143793 RVA: 0x00978D7C File Offset: 0x00976F7C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void Setup_Params_From_DA(BP_BoxCol_C BoxCol, PD_MeshToBoxData_C DA, UObject __WorldContext, ref bool Find)
		{
			BPL_BoxColSimulation_C.StaticClass();
			BPL_BoxColSimulation_C.__Setup_Params_From_DA_FunctionParams* ptr = stackalloc BPL_BoxColSimulation_C.__Setup_Params_From_DA_FunctionParams[(UIntPtr)231] + 15L / (long)sizeof(BPL_BoxColSimulation_C.__Setup_Params_From_DA_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_BoxColSimulation_C.__Setup_Params_From_DA_NativeFunctionPtr, (void*)ptr, 1);
			ptr->BoxCol = ((BoxCol != null) ? BoxCol.NativePtr : IntPtr.Zero);
			ptr->DA = ((DA != null) ? DA.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->Find = Find;
			UnrealReflectionUtils.CallVirtualUFunction(BPL_BoxColSimulation_C._ClassDefaultObjectPtr, BPL_BoxColSimulation_C.__Setup_Params_From_DA_NativeFunctionPtr, (void*)ptr);
			Find = ptr->Find;
		}

		// Token: 0x060231B2 RID: 143794 RVA: 0x00978E15 File Offset: 0x00977015
		protected BPL_BoxColSimulation_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011D93 RID: 73107
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/BPL_BoxColSimulation.BPL_BoxColSimulation_C";

		// Token: 0x04011D94 RID: 73108
		private static IntPtr _ClassPtr;

		// Token: 0x04011D95 RID: 73109
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011D96 RID: 73110
		private static IntPtr __Setup_Params_From_DA_ForCloth_Use_Inside_BP__NativeFunctionPtr;

		// Token: 0x04011D97 RID: 73111
		private static IntPtr __Setup_Params_From_DA_ForCloth_NativeFunctionPtr;

		// Token: 0x04011D98 RID: 73112
		private static IntPtr __boxCol_SM_2_SM__NativeFunctionPtr;

		// Token: 0x04011D99 RID: 73113
		private static IntPtr __Setup_Params_From_DA__Use_Inside_BP__NativeFunctionPtr;

		// Token: 0x04011D9A RID: 73114
		private static IntPtr __Setup_Params_From_DA_NativeFunctionPtr;

		// Token: 0x02009C89 RID: 40073
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 224)]
		protected ref struct __Setup_Params_From_DA_ForCloth_Use_Inside_BP__FunctionParams
		{
			// Token: 0x04032587 RID: 206215
			[FieldOffset(0)]
			public IntPtr GenCloth;

			// Token: 0x04032588 RID: 206216
			[FieldOffset(8)]
			public IntPtr DA;

			// Token: 0x04032589 RID: 206217
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x0403258A RID: 206218
			[FieldOffset(24)]
			public bool Find;
		}

		// Token: 0x02009C8A RID: 40074
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 216)]
		protected ref struct __Setup_Params_From_DA_ForCloth_FunctionParams
		{
			// Token: 0x0403258B RID: 206219
			[FieldOffset(0)]
			public IntPtr GenCloth;

			// Token: 0x0403258C RID: 206220
			[FieldOffset(8)]
			public IntPtr DA;

			// Token: 0x0403258D RID: 206221
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x0403258E RID: 206222
			[FieldOffset(24)]
			public bool Find;
		}

		// Token: 0x02009C8B RID: 40075
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __boxCol_SM_2_SM__FunctionParams
		{
			// Token: 0x0403258F RID: 206223
			[FieldOffset(0)]
			public IntPtr DASM2SM;

			// Token: 0x04032590 RID: 206224
			[FieldOffset(8)]
			public IntPtr SMInput;

			// Token: 0x04032591 RID: 206225
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04032592 RID: 206226
			[FieldOffset(24)]
			public IntPtr SM;

			// Token: 0x04032593 RID: 206227
			[FieldOffset(32)]
			public bool Find;
		}

		// Token: 0x02009C8C RID: 40076
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 224)]
		protected ref struct __Setup_Params_From_DA__Use_Inside_BP__FunctionParams
		{
			// Token: 0x04032594 RID: 206228
			[FieldOffset(0)]
			public IntPtr BoxCol;

			// Token: 0x04032595 RID: 206229
			[FieldOffset(8)]
			public IntPtr DA;

			// Token: 0x04032596 RID: 206230
			[FieldOffset(16)]
			public IntPtr staticMesh;

			// Token: 0x04032597 RID: 206231
			[FieldOffset(24)]
			public IntPtr __WorldContext;

			// Token: 0x04032598 RID: 206232
			[FieldOffset(32)]
			public bool Find;
		}

		// Token: 0x02009C8D RID: 40077
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 216)]
		protected ref struct __Setup_Params_From_DA_FunctionParams
		{
			// Token: 0x04032599 RID: 206233
			[FieldOffset(0)]
			public IntPtr BoxCol;

			// Token: 0x0403259A RID: 206234
			[FieldOffset(8)]
			public IntPtr DA;

			// Token: 0x0403259B RID: 206235
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x0403259C RID: 206236
			[FieldOffset(24)]
			public bool Find;
		}
	}
}
