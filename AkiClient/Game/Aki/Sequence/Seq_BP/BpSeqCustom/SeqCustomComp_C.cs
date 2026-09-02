using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Sequence.Seq_BP.BpSeqCustom
{
	// Token: 0x0200439D RID: 17309
	[UnrealObjectPath("/Game/Aki/Sequence/Seq_BP/BpSeqCustom/SeqCustomComp.SeqCustomComp_C")]
	[UnrealStructLayout(224, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 224)]
	public class SeqCustomComp_C : UActorComponent, IUnrealUObject, IUnrealObject, ICurveSourceInterface, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0602DF0B RID: 188171 RVA: 0x00AD23FC File Offset: 0x00AD05FC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (SeqCustomComp_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Sequence/Seq_BP/BpSeqCustom/SeqCustomComp.SeqCustomComp_C");
			}
			return SeqCustomComp_C._ClassPtr;
		}

		// Token: 0x0602DF0C RID: 188172 RVA: 0x00AD2420 File Offset: 0x00AD0620
		int ICurveSourceInterface.InterfaceOffset()
		{
			return SeqCustomComp_C.__InterfaceOffset_ICurveSourceInterface;
		}

		// Token: 0x0602DF0D RID: 188173 RVA: 0x00AD2428 File Offset: 0x00AD0628
		public SeqCustomComp_C() : this(BuiltinUtils.AllocNativeUObject(SeqCustomComp_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DF0E RID: 188174 RVA: 0x00AD2450 File Offset: 0x00AD0650
		[NullableContext(1)]
		public SeqCustomComp_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SeqCustomComp_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007E15 RID: 32277
		// (get) Token: 0x0602DF0F RID: 188175 RVA: 0x00AD2484 File Offset: 0x00AD0684
		// (set) Token: 0x0602DF10 RID: 188176 RVA: 0x00AD24BD File Offset: 0x00AD06BD
		[Nullable(1)]
		public TArray<FNamedCurveValue> CurveData
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FNamedCurveValue> result;
				if ((result = this._CurveData) == null)
				{
					result = (this._CurveData = new TArray<FNamedCurveValue>(base.NativePtr + (IntPtr)SeqCustomComp_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CurveData.CopyAssign(value);
			}
		}

		// Token: 0x17007E16 RID: 32278
		// (get) Token: 0x0602DF11 RID: 188177 RVA: 0x00AD24CB File Offset: 0x00AD06CB
		// (set) Token: 0x0602DF12 RID: 188178 RVA: 0x00AD24DB File Offset: 0x00AD06DB
		public unsafe float SeqLHandWeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SeqCustomComp_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SeqCustomComp_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007E17 RID: 32279
		// (get) Token: 0x0602DF13 RID: 188179 RVA: 0x00AD24EC File Offset: 0x00AD06EC
		// (set) Token: 0x0602DF14 RID: 188180 RVA: 0x00AD24FC File Offset: 0x00AD06FC
		public unsafe float SeqRHandWeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SeqCustomComp_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SeqCustomComp_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602DF15 RID: 188181 RVA: 0x00AD2510 File Offset: 0x00AD0710
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual FName GetBindingName()
		{
			SeqCustomComp_C.__GetBindingName_FunctionParams* ptr = stackalloc SeqCustomComp_C.__GetBindingName_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(SeqCustomComp_C.__GetBindingName_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SeqCustomComp_C.__GetBindingName_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SeqCustomComp_C.__GetBindingName_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602DF16 RID: 188182 RVA: 0x00AD2558 File Offset: 0x00AD0758
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual FName GetBindingName_Implementation()
		{
			SeqCustomComp_C.__GetBindingName_FunctionParams* ptr = stackalloc SeqCustomComp_C.__GetBindingName_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(SeqCustomComp_C.__GetBindingName_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SeqCustomComp_C.__GetBindingName_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, SeqCustomComp_C.__GetBindingName_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0602DF17 RID: 188183 RVA: 0x00AD25A0 File Offset: 0x00AD07A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCurves([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<FNamedCurveValue> OutValues)
		{
			SeqCustomComp_C.__GetCurves_FunctionParams* ptr = stackalloc SeqCustomComp_C.__GetCurves_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(SeqCustomComp_C.__GetCurves_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SeqCustomComp_C.__GetCurves_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FNamedCurveValue> tarray = OutValues;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->OutValues);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SeqCustomComp_C.__GetCurves_NativeFunctionPtr, (void*)ptr);
			TArray<FNamedCurveValue> tarray2 = OutValues;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->OutValues);
			}
			UnrealReflectionUtils.DestroyStruct(SeqCustomComp_C.__GetCurves_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DF18 RID: 188184 RVA: 0x00AD2618 File Offset: 0x00AD0818
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void GetCurves_Implementation([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<FNamedCurveValue> OutValues)
		{
			SeqCustomComp_C.__GetCurves_FunctionParams* ptr = stackalloc SeqCustomComp_C.__GetCurves_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(SeqCustomComp_C.__GetCurves_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SeqCustomComp_C.__GetCurves_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FNamedCurveValue> tarray = OutValues;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->OutValues);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, SeqCustomComp_C.__GetCurves_NativeFunctionPtr, (void*)ptr, 0);
			TArray<FNamedCurveValue> tarray2 = OutValues;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->OutValues);
			}
			UnrealReflectionUtils.DestroyStruct(SeqCustomComp_C.__GetCurves_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DF19 RID: 188185 RVA: 0x00AD2694 File Offset: 0x00AD0894
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual float GetCurveValue(FName CurveName)
		{
			SeqCustomComp_C.__GetCurveValue_FunctionParams* ptr = stackalloc SeqCustomComp_C.__GetCurveValue_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(SeqCustomComp_C.__GetCurveValue_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SeqCustomComp_C.__GetCurveValue_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CurveName = CurveName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SeqCustomComp_C.__GetCurveValue_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602DF1A RID: 188186 RVA: 0x00AD26E0 File Offset: 0x00AD08E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual float GetCurveValue_Implementation(FName CurveName)
		{
			SeqCustomComp_C.__GetCurveValue_FunctionParams* ptr = stackalloc SeqCustomComp_C.__GetCurveValue_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(SeqCustomComp_C.__GetCurveValue_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SeqCustomComp_C.__GetCurveValue_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CurveName = CurveName;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, SeqCustomComp_C.__GetCurveValue_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0602DF1B RID: 188187 RVA: 0x00AD2730 File Offset: 0x00AD0930
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Set_Vector_Data(TMap<FName, FVector> Name)
		{
			SeqCustomComp_C.__Set_Vector_Data_FunctionParams* ptr = stackalloc SeqCustomComp_C.__Set_Vector_Data_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(SeqCustomComp_C.__Set_Vector_Data_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SeqCustomComp_C.__Set_Vector_Data_NativeFunctionPtr, (void*)ptr, 1);
			if (Name != null)
			{
				Name.CopyTo(&ptr->Name, default(UScriptStructStackOnlyPtr));
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SeqCustomComp_C.__Set_Vector_Data_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(SeqCustomComp_C.__Set_Vector_Data_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DF1C RID: 188188 RVA: 0x00AD279C File Offset: 0x00AD099C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ProcessEye(FVector EyeLookAt, float AngleScale)
		{
			SeqCustomComp_C.__ProcessEye_FunctionParams* ptr = stackalloc SeqCustomComp_C.__ProcessEye_FunctionParams[(UIntPtr)235] + 15L / (long)sizeof(SeqCustomComp_C.__ProcessEye_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SeqCustomComp_C.__ProcessEye_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EyeLookAt = EyeLookAt;
			ptr->AngleScale = AngleScale;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SeqCustomComp_C.__ProcessEye_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DF1D RID: 188189 RVA: 0x00AD27EC File Offset: 0x00AD09EC
		protected SeqCustomComp_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019F5E RID: 106334
		internal static int __InterfaceOffset_ICurveSourceInterface;

		// Token: 0x04019F5F RID: 106335
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Sequence/Seq_BP/BpSeqCustom/SeqCustomComp.SeqCustomComp_C";

		// Token: 0x04019F60 RID: 106336
		private static IntPtr _ClassPtr;

		// Token: 0x04019F61 RID: 106337
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019F62 RID: 106338
		internal static int __PropertyOffset_0;

		// Token: 0x04019F63 RID: 106339
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FNamedCurveValue> _CurveData;

		// Token: 0x04019F64 RID: 106340
		internal static int __PropertyOffset_1;

		// Token: 0x04019F65 RID: 106341
		internal static int __PropertyOffset_2;

		// Token: 0x04019F66 RID: 106342
		private static IntPtr __GetBindingName_NativeFunctionPtr;

		// Token: 0x04019F67 RID: 106343
		private static IntPtr __GetCurves_NativeFunctionPtr;

		// Token: 0x04019F68 RID: 106344
		private static IntPtr __GetCurveValue_NativeFunctionPtr;

		// Token: 0x04019F69 RID: 106345
		private static IntPtr __Set_Vector_Data_NativeFunctionPtr;

		// Token: 0x04019F6A RID: 106346
		private static IntPtr __ProcessEye_NativeFunctionPtr;

		// Token: 0x0200A5FB RID: 42491
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __GetBindingName_FunctionParams
		{
			// Token: 0x040335AC RID: 210348
			[FieldOffset(0)]
			public FName __Result;
		}

		// Token: 0x0200A5FC RID: 42492
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __GetCurves_FunctionParams
		{
			// Token: 0x040335AD RID: 210349
			[FieldOffset(0)]
			public byte OutValues;
		}

		// Token: 0x0200A5FD RID: 42493
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __GetCurveValue_FunctionParams
		{
			// Token: 0x040335AE RID: 210350
			[FieldOffset(0)]
			public FName CurveName;

			// Token: 0x040335AF RID: 210351
			[FieldOffset(12)]
			public float __Result;
		}

		// Token: 0x0200A5FE RID: 42494
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __Set_Vector_Data_FunctionParams
		{
			// Token: 0x040335B0 RID: 210352
			[FieldOffset(0)]
			public byte Name;
		}

		// Token: 0x0200A5FF RID: 42495
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 220)]
		protected ref struct __ProcessEye_FunctionParams
		{
			// Token: 0x040335B1 RID: 210353
			[FieldOffset(0)]
			public FVector EyeLookAt;

			// Token: 0x040335B2 RID: 210354
			[FieldOffset(12)]
			public float AngleScale;
		}
	}
}
