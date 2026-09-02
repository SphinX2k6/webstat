using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Sequence.Seq_BP.BpSeqCustom
{
	// Token: 0x0200439C RID: 17308
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Sequence/Seq_BP/BpSeqCustom/BP_SeqCustom.BP_SeqCustom_C")]
	[UnrealStructLayout(1192, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1188)]
	public class BP_SeqCustom_C : AActor, IUnrealUObject, IUnrealObject, ISeqAnimDataInterface, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0602DED5 RID: 188117 RVA: 0x00AD1823 File Offset: 0x00ACFA23
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SeqCustom_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Sequence/Seq_BP/BpSeqCustom/BP_SeqCustom.BP_SeqCustom_C");
			}
			return BP_SeqCustom_C._ClassPtr;
		}

		// Token: 0x0602DED6 RID: 188118 RVA: 0x00AD1847 File Offset: 0x00ACFA47
		int ISeqAnimDataInterface.InterfaceOffset()
		{
			return BP_SeqCustom_C.__InterfaceOffset_ISeqAnimDataInterface;
		}

		// Token: 0x0602DED7 RID: 188119 RVA: 0x00AD1850 File Offset: 0x00ACFA50
		public BP_SeqCustom_C() : this(BuiltinUtils.AllocNativeUObject(BP_SeqCustom_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DED8 RID: 188120 RVA: 0x00AD1878 File Offset: 0x00ACFA78
		[NullableContext(1)]
		public BP_SeqCustom_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SeqCustom_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007E09 RID: 32265
		// (get) Token: 0x0602DED9 RID: 188121 RVA: 0x00AD18AC File Offset: 0x00ACFAAC
		// (set) Token: 0x0602DEDA RID: 188122 RVA: 0x00AD18E5 File Offset: 0x00ACFAE5
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SeqCustom_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SeqCustom_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007E0A RID: 32266
		// (get) Token: 0x0602DEDB RID: 188123 RVA: 0x00AD1906 File Offset: 0x00ACFB06
		// (set) Token: 0x0602DEDC RID: 188124 RVA: 0x00AD191A File Offset: 0x00ACFB1A
		public unsafe SeqCustomComp_C SeqCustomComp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<SeqCustomComp_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqCustom_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqCustom_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007E0B RID: 32267
		// (get) Token: 0x0602DEDD RID: 188125 RVA: 0x00AD192F File Offset: 0x00ACFB2F
		// (set) Token: 0x0602DEDE RID: 188126 RVA: 0x00AD1943 File Offset: 0x00ACFB43
		public unsafe USkeletalMeshComponent SkeletalMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqCustom_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqCustom_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17007E0C RID: 32268
		// (get) Token: 0x0602DEDF RID: 188127 RVA: 0x00AD1958 File Offset: 0x00ACFB58
		// (set) Token: 0x0602DEE0 RID: 188128 RVA: 0x00AD196C File Offset: 0x00ACFB6C
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqCustom_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqCustom_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17007E0D RID: 32269
		// (get) Token: 0x0602DEE1 RID: 188129 RVA: 0x00AD1981 File Offset: 0x00ACFB81
		// (set) Token: 0x0602DEE2 RID: 188130 RVA: 0x00AD1995 File Offset: 0x00ACFB95
		public unsafe USkeletalMesh Mesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqCustom_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqCustom_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17007E0E RID: 32270
		// (get) Token: 0x0602DEE3 RID: 188131 RVA: 0x00AD19AC File Offset: 0x00ACFBAC
		// (set) Token: 0x0602DEE4 RID: 188132 RVA: 0x00AD19E5 File Offset: 0x00ACFBE5
		[Nullable(1)]
		public TMap<FName, FTransform> BoneData
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FTransform> result;
				if ((result = this._BoneData) == null)
				{
					result = (this._BoneData = new TMap<FName, FTransform>(base.NativePtr + (IntPtr)BP_SeqCustom_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.BoneData.CopyAssign(value);
			}
		}

		// Token: 0x17007E0F RID: 32271
		// (get) Token: 0x0602DEE5 RID: 188133 RVA: 0x00AD19F4 File Offset: 0x00ACFBF4
		// (set) Token: 0x0602DEE6 RID: 188134 RVA: 0x00AD1A2D File Offset: 0x00ACFC2D
		[Nullable(1)]
		public TArray<FName> SupportNames
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._SupportNames) == null)
				{
					result = (this._SupportNames = new TArray<FName>(base.NativePtr + (IntPtr)BP_SeqCustom_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SupportNames.CopyAssign(value);
			}
		}

		// Token: 0x17007E10 RID: 32272
		// (get) Token: 0x0602DEE7 RID: 188135 RVA: 0x00AD1A3B File Offset: 0x00ACFC3B
		// (set) Token: 0x0602DEE8 RID: 188136 RVA: 0x00AD1A4B File Offset: 0x00ACFC4B
		public unsafe int TalkID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqCustom_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqCustom_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17007E11 RID: 32273
		// (get) Token: 0x0602DEE9 RID: 188137 RVA: 0x00AD1A5C File Offset: 0x00ACFC5C
		// (set) Token: 0x0602DEEA RID: 188138 RVA: 0x00AD1A6C File Offset: 0x00ACFC6C
		public unsafe int TalkID_SP
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqCustom_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqCustom_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17007E12 RID: 32274
		// (get) Token: 0x0602DEEB RID: 188139 RVA: 0x00AD1A7D File Offset: 0x00ACFC7D
		// (set) Token: 0x0602DEEC RID: 188140 RVA: 0x00AD1A8D File Offset: 0x00ACFC8D
		public unsafe bool SetNewBound
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqCustom_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqCustom_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007E13 RID: 32275
		// (get) Token: 0x0602DEED RID: 188141 RVA: 0x00AD1A9E File Offset: 0x00ACFC9E
		// (set) Token: 0x0602DEEE RID: 188142 RVA: 0x00AD1AAE File Offset: 0x00ACFCAE
		public unsafe float NewBoundScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqCustom_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqCustom_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17007E14 RID: 32276
		// (get) Token: 0x0602DEEF RID: 188143 RVA: 0x00AD1ABF File Offset: 0x00ACFCBF
		// (set) Token: 0x0602DEF0 RID: 188144 RVA: 0x00AD1ACF File Offset: 0x00ACFCCF
		public unsafe float OriginBound
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqCustom_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqCustom_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x0602DEF1 RID: 188145 RVA: 0x00AD1AE0 File Offset: 0x00ACFCE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool IsCustomSupport()
		{
			BP_SeqCustom_C.__IsCustomSupport_FunctionParams* ptr = stackalloc BP_SeqCustom_C.__IsCustomSupport_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_SeqCustom_C.__IsCustomSupport_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqCustom_C.__IsCustomSupport_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqCustom_C.__IsCustomSupport_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602DEF2 RID: 188146 RVA: 0x00AD1B28 File Offset: 0x00ACFD28
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool IsCustomSupport_Implementation()
		{
			BP_SeqCustom_C.__IsCustomSupport_FunctionParams* ptr = stackalloc BP_SeqCustom_C.__IsCustomSupport_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_SeqCustom_C.__IsCustomSupport_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqCustom_C.__IsCustomSupport_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqCustom_C.__IsCustomSupport_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0602DEF3 RID: 188147 RVA: 0x00AD1B70 File Offset: 0x00ACFD70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool GetAnimDataTransform(ref TMap<FName, FTransform> FloatCurveData)
		{
			BP_SeqCustom_C.__GetAnimDataTransform_FunctionParams* ptr = stackalloc BP_SeqCustom_C.__GetAnimDataTransform_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SeqCustom_C.__GetAnimDataTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqCustom_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			TMap<FName, FTransform> tmap = FloatCurveData;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqCustom_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr);
			TMap<FName, FTransform> tmap2 = FloatCurveData;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqCustom_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DEF4 RID: 188148 RVA: 0x00AD1BF0 File Offset: 0x00ACFDF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool GetAnimDataTransform_Implementation(ref TMap<FName, FTransform> FloatCurveData)
		{
			BP_SeqCustom_C.__GetAnimDataTransform_FunctionParams* ptr = stackalloc BP_SeqCustom_C.__GetAnimDataTransform_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SeqCustom_C.__GetAnimDataTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqCustom_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			TMap<FName, FTransform> tmap = FloatCurveData;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqCustom_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 0);
			TMap<FName, FTransform> tmap2 = FloatCurveData;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqCustom_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DEF5 RID: 188149 RVA: 0x00AD1C70 File Offset: 0x00ACFE70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool SetAnimDataTransform(in TMap<FName, FTransform> FloatCurveData)
		{
			BP_SeqCustom_C.__SetAnimDataTransform_FunctionParams* ptr = stackalloc BP_SeqCustom_C.__SetAnimDataTransform_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SeqCustom_C.__SetAnimDataTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqCustom_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			object obj = FloatCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqCustom_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr);
			object obj2 = FloatCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqCustom_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DEF6 RID: 188150 RVA: 0x00AD1CF0 File Offset: 0x00ACFEF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool SetAnimDataTransform_Implementation(in TMap<FName, FTransform> FloatCurveData)
		{
			BP_SeqCustom_C.__SetAnimDataTransform_FunctionParams* ptr = stackalloc BP_SeqCustom_C.__SetAnimDataTransform_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SeqCustom_C.__SetAnimDataTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqCustom_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			object obj = FloatCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqCustom_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 0);
			object obj2 = FloatCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqCustom_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DEF7 RID: 188151 RVA: 0x00AD1D70 File Offset: 0x00ACFF70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool GetAnimDataFloat([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<FNamedCurveValue> FloatCurveData)
		{
			BP_SeqCustom_C.__GetAnimDataFloat_FunctionParams* ptr = stackalloc BP_SeqCustom_C.__GetAnimDataFloat_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_SeqCustom_C.__GetAnimDataFloat_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqCustom_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FNamedCurveValue> tarray = FloatCurveData;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqCustom_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr);
			TArray<FNamedCurveValue> tarray2 = FloatCurveData;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqCustom_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DEF8 RID: 188152 RVA: 0x00AD1DF0 File Offset: 0x00ACFFF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool GetAnimDataFloat_Implementation([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<FNamedCurveValue> FloatCurveData)
		{
			BP_SeqCustom_C.__GetAnimDataFloat_FunctionParams* ptr = stackalloc BP_SeqCustom_C.__GetAnimDataFloat_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_SeqCustom_C.__GetAnimDataFloat_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqCustom_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FNamedCurveValue> tarray = FloatCurveData;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqCustom_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 0);
			TArray<FNamedCurveValue> tarray2 = FloatCurveData;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqCustom_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DEF9 RID: 188153 RVA: 0x00AD1E70 File Offset: 0x00AD0070
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool GetAnimDataVector(ref TMap<FName, FVector> VectorCurveData)
		{
			BP_SeqCustom_C.__GetAnimDataVector_FunctionParams* ptr = stackalloc BP_SeqCustom_C.__GetAnimDataVector_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SeqCustom_C.__GetAnimDataVector_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqCustom_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			TMap<FName, FVector> tmap = VectorCurveData;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->VectorCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqCustom_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr);
			TMap<FName, FVector> tmap2 = VectorCurveData;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->VectorCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqCustom_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DEFA RID: 188154 RVA: 0x00AD1EF0 File Offset: 0x00AD00F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool GetAnimDataVector_Implementation(ref TMap<FName, FVector> VectorCurveData)
		{
			BP_SeqCustom_C.__GetAnimDataVector_FunctionParams* ptr = stackalloc BP_SeqCustom_C.__GetAnimDataVector_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SeqCustom_C.__GetAnimDataVector_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqCustom_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			TMap<FName, FVector> tmap = VectorCurveData;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->VectorCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqCustom_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr, 0);
			TMap<FName, FVector> tmap2 = VectorCurveData;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->VectorCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqCustom_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DEFB RID: 188155 RVA: 0x00AD1F70 File Offset: 0x00AD0170
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual TArray<FName> GetSupportGroupNames()
		{
			BP_SeqCustom_C.__GetSupportGroupNames_FunctionParams* ptr = stackalloc BP_SeqCustom_C.__GetSupportGroupNames_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_SeqCustom_C.__GetSupportGroupNames_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqCustom_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqCustom_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr);
			TArray<FName> result = new TArray<FName>(&ptr->__Result, true, true);
			UnrealReflectionUtils.DestroyStruct(BP_SeqCustom_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr, 1);
			return result;
		}

		// Token: 0x0602DEFC RID: 188156 RVA: 0x00AD1FD0 File Offset: 0x00AD01D0
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual TArray<FName> GetSupportGroupNames_Implementation()
		{
			BP_SeqCustom_C.__GetSupportGroupNames_FunctionParams* ptr = stackalloc BP_SeqCustom_C.__GetSupportGroupNames_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_SeqCustom_C.__GetSupportGroupNames_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqCustom_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqCustom_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr, 0);
			TArray<FName> result = new TArray<FName>(&ptr->__Result, true, true);
			UnrealReflectionUtils.DestroyStruct(BP_SeqCustom_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr, 1);
			return result;
		}

		// Token: 0x0602DEFD RID: 188157 RVA: 0x00AD2030 File Offset: 0x00AD0230
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool SetAnimDataFloat([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<FNamedCurveValue> FloatCurveData)
		{
			BP_SeqCustom_C.__SetAnimDataFloat_FunctionParams* ptr = stackalloc BP_SeqCustom_C.__SetAnimDataFloat_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_SeqCustom_C.__SetAnimDataFloat_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqCustom_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			object obj = FloatCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqCustom_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr);
			object obj2 = FloatCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqCustom_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DEFE RID: 188158 RVA: 0x00AD20B0 File Offset: 0x00AD02B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool SetAnimDataFloat_Implementation([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<FNamedCurveValue> FloatCurveData)
		{
			BP_SeqCustom_C.__SetAnimDataFloat_FunctionParams* ptr = stackalloc BP_SeqCustom_C.__SetAnimDataFloat_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_SeqCustom_C.__SetAnimDataFloat_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqCustom_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			object obj = FloatCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqCustom_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 0);
			object obj2 = FloatCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqCustom_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DEFF RID: 188159 RVA: 0x00AD2130 File Offset: 0x00AD0330
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool SetAnimDataVector(in TMap<FName, FVector> VectorCurveData)
		{
			BP_SeqCustom_C.__SetAnimDataVector_FunctionParams* ptr = stackalloc BP_SeqCustom_C.__SetAnimDataVector_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SeqCustom_C.__SetAnimDataVector_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqCustom_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			object obj = VectorCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->VectorCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqCustom_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr);
			object obj2 = VectorCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->VectorCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqCustom_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DF00 RID: 188160 RVA: 0x00AD21B0 File Offset: 0x00AD03B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool SetAnimDataVector_Implementation(in TMap<FName, FVector> VectorCurveData)
		{
			BP_SeqCustom_C.__SetAnimDataVector_FunctionParams* ptr = stackalloc BP_SeqCustom_C.__SetAnimDataVector_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SeqCustom_C.__SetAnimDataVector_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqCustom_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			object obj = VectorCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->VectorCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqCustom_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr, 0);
			object obj2 = VectorCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->VectorCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqCustom_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DF01 RID: 188161 RVA: 0x00AD222F File Offset: 0x00AD042F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqCustom_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602DF02 RID: 188162 RVA: 0x00AD2243 File Offset: 0x00AD0443
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqCustom_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602DF03 RID: 188163 RVA: 0x00AD2258 File Offset: 0x00AD0458
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqCustom_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602DF04 RID: 188164 RVA: 0x00AD226C File Offset: 0x00AD046C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqCustom_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602DF05 RID: 188165 RVA: 0x00AD2284 File Offset: 0x00AD0484
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SeqCustom_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SeqCustom_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SeqCustom_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqCustom_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqCustom_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DF06 RID: 188166 RVA: 0x00AD22CC File Offset: 0x00AD04CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SeqCustom_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SeqCustom_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SeqCustom_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqCustom_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqCustom_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DF07 RID: 188167 RVA: 0x00AD2314 File Offset: 0x00AD0514
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_SeqCustom_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_SeqCustom_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_SeqCustom_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqCustom_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqCustom_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DF08 RID: 188168 RVA: 0x00AD2360 File Offset: 0x00AD0560
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_SeqCustom_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_SeqCustom_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_SeqCustom_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqCustom_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqCustom_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DF09 RID: 188169 RVA: 0x00AD23AC File Offset: 0x00AD05AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SeqCustom(int EntryPoint)
		{
			BP_SeqCustom_C.__ExecuteUbergraph_BP_SeqCustom_FunctionParams* ptr = stackalloc BP_SeqCustom_C.__ExecuteUbergraph_BP_SeqCustom_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_SeqCustom_C.__ExecuteUbergraph_BP_SeqCustom_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqCustom_C.__ExecuteUbergraph_BP_SeqCustom_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqCustom_C.__ExecuteUbergraph_BP_SeqCustom_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DF0A RID: 188170 RVA: 0x00AD23F3 File Offset: 0x00AD05F3
		protected BP_SeqCustom_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019F3E RID: 106302
		internal static int __InterfaceOffset_ISeqAnimDataInterface;

		// Token: 0x04019F3F RID: 106303
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Sequence/Seq_BP/BpSeqCustom/BP_SeqCustom.BP_SeqCustom_C";

		// Token: 0x04019F40 RID: 106304
		private static IntPtr _ClassPtr;

		// Token: 0x04019F41 RID: 106305
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019F42 RID: 106306
		internal static int __PropertyOffset_0;

		// Token: 0x04019F43 RID: 106307
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04019F44 RID: 106308
		internal static int __PropertyOffset_1;

		// Token: 0x04019F45 RID: 106309
		internal static int __PropertyOffset_2;

		// Token: 0x04019F46 RID: 106310
		internal static int __PropertyOffset_3;

		// Token: 0x04019F47 RID: 106311
		internal static int __PropertyOffset_4;

		// Token: 0x04019F48 RID: 106312
		internal static int __PropertyOffset_5;

		// Token: 0x04019F49 RID: 106313
		private TMap<FName, FTransform> _BoneData;

		// Token: 0x04019F4A RID: 106314
		internal static int __PropertyOffset_6;

		// Token: 0x04019F4B RID: 106315
		private TArray<FName> _SupportNames;

		// Token: 0x04019F4C RID: 106316
		internal static int __PropertyOffset_7;

		// Token: 0x04019F4D RID: 106317
		internal static int __PropertyOffset_8;

		// Token: 0x04019F4E RID: 106318
		internal static int __PropertyOffset_9;

		// Token: 0x04019F4F RID: 106319
		internal static int __PropertyOffset_10;

		// Token: 0x04019F50 RID: 106320
		internal static int __PropertyOffset_11;

		// Token: 0x04019F51 RID: 106321
		private static IntPtr __IsCustomSupport_NativeFunctionPtr;

		// Token: 0x04019F52 RID: 106322
		private static IntPtr __GetAnimDataTransform_NativeFunctionPtr;

		// Token: 0x04019F53 RID: 106323
		private static IntPtr __SetAnimDataTransform_NativeFunctionPtr;

		// Token: 0x04019F54 RID: 106324
		private static IntPtr __GetAnimDataFloat_NativeFunctionPtr;

		// Token: 0x04019F55 RID: 106325
		private static IntPtr __GetAnimDataVector_NativeFunctionPtr;

		// Token: 0x04019F56 RID: 106326
		private static IntPtr __GetSupportGroupNames_NativeFunctionPtr;

		// Token: 0x04019F57 RID: 106327
		private static IntPtr __SetAnimDataFloat_NativeFunctionPtr;

		// Token: 0x04019F58 RID: 106328
		private static IntPtr __SetAnimDataVector_NativeFunctionPtr;

		// Token: 0x04019F59 RID: 106329
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04019F5A RID: 106330
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04019F5B RID: 106331
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04019F5C RID: 106332
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04019F5D RID: 106333
		private static IntPtr __ExecuteUbergraph_BP_SeqCustom_NativeFunctionPtr;

		// Token: 0x0200A5F0 RID: 42480
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __IsCustomSupport_FunctionParams
		{
			// Token: 0x0403359B RID: 210331
			[FieldOffset(0)]
			public bool __Result;
		}

		// Token: 0x0200A5F1 RID: 42481
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __GetAnimDataTransform_FunctionParams
		{
			// Token: 0x0403359C RID: 210332
			[FieldOffset(0)]
			public byte FloatCurveData;

			// Token: 0x0403359D RID: 210333
			[FieldOffset(80)]
			public bool __Result;
		}

		// Token: 0x0200A5F2 RID: 42482
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __SetAnimDataTransform_FunctionParams
		{
			// Token: 0x0403359E RID: 210334
			[FieldOffset(0)]
			public byte FloatCurveData;

			// Token: 0x0403359F RID: 210335
			[FieldOffset(80)]
			public bool __Result;
		}

		// Token: 0x0200A5F3 RID: 42483
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __GetAnimDataFloat_FunctionParams
		{
			// Token: 0x040335A0 RID: 210336
			[FieldOffset(0)]
			public byte FloatCurveData;

			// Token: 0x040335A1 RID: 210337
			[FieldOffset(16)]
			public bool __Result;
		}

		// Token: 0x0200A5F4 RID: 42484
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __GetAnimDataVector_FunctionParams
		{
			// Token: 0x040335A2 RID: 210338
			[FieldOffset(0)]
			public byte VectorCurveData;

			// Token: 0x040335A3 RID: 210339
			[FieldOffset(80)]
			public bool __Result;
		}

		// Token: 0x0200A5F5 RID: 42485
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __GetSupportGroupNames_FunctionParams
		{
			// Token: 0x040335A4 RID: 210340
			[FieldOffset(0)]
			public byte __Result;
		}

		// Token: 0x0200A5F6 RID: 42486
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __SetAnimDataFloat_FunctionParams
		{
			// Token: 0x040335A5 RID: 210341
			[FieldOffset(0)]
			public byte FloatCurveData;

			// Token: 0x040335A6 RID: 210342
			[FieldOffset(16)]
			public bool __Result;
		}

		// Token: 0x0200A5F7 RID: 42487
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __SetAnimDataVector_FunctionParams
		{
			// Token: 0x040335A7 RID: 210343
			[FieldOffset(0)]
			public byte VectorCurveData;

			// Token: 0x040335A8 RID: 210344
			[FieldOffset(80)]
			public bool __Result;
		}

		// Token: 0x0200A5F8 RID: 42488
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040335A9 RID: 210345
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A5F9 RID: 42489
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x040335AA RID: 210346
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x0200A5FA RID: 42490
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_SeqCustom_FunctionParams
		{
			// Token: 0x040335AB RID: 210347
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
