using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.Input.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Input.Blueprints
{
	// Token: 0x020041B0 RID: 16816
	[UnrealObjectPath("/Game/Aki/Character/Input/Blueprints/BPL_Input.BPL_Input_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public class BPL_Input_C : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CA3B RID: 182843 RVA: 0x00AA8A1C File Offset: 0x00AA6C1C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BPL_Input_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Input/Blueprints/BPL_Input.BPL_Input_C");
			}
			return BPL_Input_C._ClassPtr;
		}

		// Token: 0x0602CA3C RID: 182844 RVA: 0x00AA8A40 File Offset: 0x00AA6C40
		public BPL_Input_C() : this(BuiltinUtils.AllocNativeUObject(BPL_Input_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CA3D RID: 182845 RVA: 0x00AA8A68 File Offset: 0x00AA6C68
		[NullableContext(1)]
		public BPL_Input_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BPL_Input_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602CA3E RID: 182846 RVA: 0x00AA8A9C File Offset: 0x00AA6C9C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void GetKeyDownTime(EInputAction Action, UObject __WorldContext, ref float Time)
		{
			BPL_Input_C.StaticClass();
			BPL_Input_C.__GetKeyDownTime_FunctionParams* ptr = stackalloc BPL_Input_C.__GetKeyDownTime_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BPL_Input_C.__GetKeyDownTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_Input_C.__GetKeyDownTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Action = Action;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->Time = Time;
			UnrealReflectionUtils.CallVirtualUFunction(BPL_Input_C._ClassDefaultObjectPtr, BPL_Input_C.__GetKeyDownTime_NativeFunctionPtr, (void*)ptr);
			Time = ptr->Time;
		}

		// Token: 0x0602CA3F RID: 182847 RVA: 0x00AA8B14 File Offset: 0x00AA6D14
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static bool IsKeyDown(EInputAction NewParam, UObject __WorldContext)
		{
			BPL_Input_C.StaticClass();
			BPL_Input_C.__IsKeyDown_FunctionParams* ptr = stackalloc BPL_Input_C.__IsKeyDown_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BPL_Input_C.__IsKeyDown_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_Input_C.__IsKeyDown_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NewParam = NewParam;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(BPL_Input_C._ClassDefaultObjectPtr, BPL_Input_C.__IsKeyDown_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602CA40 RID: 182848 RVA: 0x00AA8B80 File Offset: 0x00AA6D80
		protected BPL_Input_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018D9E RID: 101790
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Input/Blueprints/BPL_Input.BPL_Input_C";

		// Token: 0x04018D9F RID: 101791
		private static IntPtr _ClassPtr;

		// Token: 0x04018DA0 RID: 101792
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018DA1 RID: 101793
		private static IntPtr __GetKeyDownTime_NativeFunctionPtr;

		// Token: 0x04018DA2 RID: 101794
		private static IntPtr __IsKeyDown_NativeFunctionPtr;

		// Token: 0x0200A46C RID: 42092
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __GetKeyDownTime_FunctionParams
		{
			// Token: 0x04033273 RID: 209523
			[FieldOffset(0)]
			public TEnumAsByte<EInputAction> Action;

			// Token: 0x04033274 RID: 209524
			[FieldOffset(8)]
			public IntPtr __WorldContext;

			// Token: 0x04033275 RID: 209525
			[FieldOffset(16)]
			public float Time;
		}

		// Token: 0x0200A46D RID: 42093
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __IsKeyDown_FunctionParams
		{
			// Token: 0x04033276 RID: 209526
			[FieldOffset(0)]
			public TEnumAsByte<EInputAction> NewParam;

			// Token: 0x04033277 RID: 209527
			[FieldOffset(8)]
			public IntPtr __WorldContext;

			// Token: 0x04033278 RID: 209528
			[FieldOffset(16)]
			public bool __Result;
		}
	}
}
