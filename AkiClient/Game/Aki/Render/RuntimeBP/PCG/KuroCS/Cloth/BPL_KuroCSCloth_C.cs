using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroCS.Cloth
{
	// Token: 0x02003BFE RID: 15358
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroCS/Cloth/BPL_KuroCSCloth.BPL_KuroCSCloth_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public class BPL_KuroCSCloth_C : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022C39 RID: 142393 RVA: 0x0096E51F File Offset: 0x0096C71F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BPL_KuroCSCloth_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/Cloth/BPL_KuroCSCloth.BPL_KuroCSCloth_C");
			}
			return BPL_KuroCSCloth_C._ClassPtr;
		}

		// Token: 0x06022C3A RID: 142394 RVA: 0x0096E544 File Offset: 0x0096C744
		public BPL_KuroCSCloth_C() : this(BuiltinUtils.AllocNativeUObject(BPL_KuroCSCloth_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022C3B RID: 142395 RVA: 0x0096E56C File Offset: 0x0096C76C
		[NullableContext(1)]
		public BPL_KuroCSCloth_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BPL_KuroCSCloth_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06022C3C RID: 142396 RVA: 0x0096E5A0 File Offset: 0x0096C7A0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static bool CheckClothEnable(AActor Actor, UObject __WorldContext)
		{
			BPL_KuroCSCloth_C.StaticClass();
			BPL_KuroCSCloth_C.__CheckClothEnable_FunctionParams* ptr = stackalloc BPL_KuroCSCloth_C.__CheckClothEnable_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BPL_KuroCSCloth_C.__CheckClothEnable_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_KuroCSCloth_C.__CheckClothEnable_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Actor = ((Actor != null) ? Actor.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(BPL_KuroCSCloth_C._ClassDefaultObjectPtr, BPL_KuroCSCloth_C.__CheckClothEnable_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x06022C3D RID: 142397 RVA: 0x0096E618 File Offset: 0x0096C818
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ReadParamsFromDA(BP_KuroCSCloth_C Cloth, PD_MeshToClothData_C DA, UObject __WorldContext, ref bool bFind)
		{
			BPL_KuroCSCloth_C.__ReadParamsFromDA_FunctionParams* ptr = stackalloc BPL_KuroCSCloth_C.__ReadParamsFromDA_FunctionParams[(UIntPtr)183] + 15L / (long)sizeof(BPL_KuroCSCloth_C.__ReadParamsFromDA_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_KuroCSCloth_C.__ReadParamsFromDA_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Cloth = ((Cloth != null) ? Cloth.NativePtr : IntPtr.Zero);
			ptr->DA = ((DA != null) ? DA.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->bFind = bFind;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BPL_KuroCSCloth_C.__ReadParamsFromDA_NativeFunctionPtr, (void*)ptr);
			bFind = ptr->bFind;
		}

		// Token: 0x06022C3E RID: 142398 RVA: 0x0096E6B0 File Offset: 0x0096C8B0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ApplyBPToDA(BP_KuroCSCloth_C Cloth, PD_MeshToClothData_C DA, UObject __WorldContext)
		{
			BPL_KuroCSCloth_C.__ApplyBPToDA_FunctionParams* ptr = stackalloc BPL_KuroCSCloth_C.__ApplyBPToDA_FunctionParams[(UIntPtr)167] + 15L / (long)sizeof(BPL_KuroCSCloth_C.__ApplyBPToDA_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_KuroCSCloth_C.__ApplyBPToDA_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Cloth = ((Cloth != null) ? Cloth.NativePtr : IntPtr.Zero);
			ptr->DA = ((DA != null) ? DA.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BPL_KuroCSCloth_C.__ApplyBPToDA_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022C3F RID: 142399 RVA: 0x0096E734 File Offset: 0x0096C934
		protected BPL_KuroCSCloth_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011A1C RID: 72220
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/Cloth/BPL_KuroCSCloth.BPL_KuroCSCloth_C";

		// Token: 0x04011A1D RID: 72221
		private static IntPtr _ClassPtr;

		// Token: 0x04011A1E RID: 72222
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011A1F RID: 72223
		private static IntPtr __CheckClothEnable_NativeFunctionPtr;

		// Token: 0x04011A20 RID: 72224
		private static IntPtr __ReadParamsFromDA_NativeFunctionPtr;

		// Token: 0x04011A21 RID: 72225
		private static IntPtr __ApplyBPToDA_NativeFunctionPtr;

		// Token: 0x02009C25 RID: 39973
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __CheckClothEnable_FunctionParams
		{
			// Token: 0x04032498 RID: 205976
			[FieldOffset(0)]
			public IntPtr Actor;

			// Token: 0x04032499 RID: 205977
			[FieldOffset(8)]
			public IntPtr __WorldContext;

			// Token: 0x0403249A RID: 205978
			[FieldOffset(16)]
			public bool __Result;
		}

		// Token: 0x02009C26 RID: 39974
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 168)]
		protected ref struct __ReadParamsFromDA_FunctionParams
		{
			// Token: 0x0403249B RID: 205979
			[FieldOffset(0)]
			public IntPtr Cloth;

			// Token: 0x0403249C RID: 205980
			[FieldOffset(8)]
			public IntPtr DA;

			// Token: 0x0403249D RID: 205981
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x0403249E RID: 205982
			[FieldOffset(24)]
			public bool bFind;
		}

		// Token: 0x02009C27 RID: 39975
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 152)]
		protected ref struct __ApplyBPToDA_FunctionParams
		{
			// Token: 0x0403249F RID: 205983
			[FieldOffset(0)]
			public IntPtr Cloth;

			// Token: 0x040324A0 RID: 205984
			[FieldOffset(8)]
			public IntPtr DA;

			// Token: 0x040324A1 RID: 205985
			[FieldOffset(16)]
			public IntPtr __WorldContext;
		}
	}
}
