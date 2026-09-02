using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseSeqCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Sequence.Seq_BP
{
	// Token: 0x02004398 RID: 17304
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Sequence/Seq_BP/BP_SeqSkeletal.BP_SeqSkeletal_C")]
	[UnrealStructLayout(1152, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1152)]
	public class BP_SeqSkeletal_C : AActor, IUnrealUObject, IUnrealObject, ISeqAnimDataInterface, IUnrealNativeInterface, IUnrealInterface, IABPC_Seq_Interface_C, IUnrealBlueprintInterface, IBPI_SeqAudio_C
	{
		// Token: 0x0602DE59 RID: 187993 RVA: 0x00AD0388 File Offset: 0x00ACE588
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SeqSkeletal_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Sequence/Seq_BP/BP_SeqSkeletal.BP_SeqSkeletal_C");
			}
			return BP_SeqSkeletal_C._ClassPtr;
		}

		// Token: 0x0602DE5A RID: 187994 RVA: 0x00AD03AC File Offset: 0x00ACE5AC
		int ISeqAnimDataInterface.InterfaceOffset()
		{
			return BP_SeqSkeletal_C.__InterfaceOffset_ISeqAnimDataInterface;
		}

		// Token: 0x0602DE5B RID: 187995 RVA: 0x00AD03B4 File Offset: 0x00ACE5B4
		public BP_SeqSkeletal_C() : this(BuiltinUtils.AllocNativeUObject(BP_SeqSkeletal_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DE5C RID: 187996 RVA: 0x00AD03DC File Offset: 0x00ACE5DC
		[NullableContext(1)]
		public BP_SeqSkeletal_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SeqSkeletal_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007DE6 RID: 32230
		// (get) Token: 0x0602DE5D RID: 187997 RVA: 0x00AD040F File Offset: 0x00ACE60F
		// (set) Token: 0x0602DE5E RID: 187998 RVA: 0x00AD0423 File Offset: 0x00ACE623
		public unsafe SeqAudio_Seq_V2_C SeqAudio_Seq_V2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<SeqAudio_Seq_V2_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqSkeletal_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqSkeletal_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17007DE7 RID: 32231
		// (get) Token: 0x0602DE5F RID: 187999 RVA: 0x00AD0438 File Offset: 0x00ACE638
		// (set) Token: 0x0602DE60 RID: 188000 RVA: 0x00AD044C File Offset: 0x00ACE64C
		public unsafe USkeletalMeshComponent SkeletalMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqSkeletal_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqSkeletal_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007DE8 RID: 32232
		// (get) Token: 0x0602DE61 RID: 188001 RVA: 0x00AD0461 File Offset: 0x00ACE661
		// (set) Token: 0x0602DE62 RID: 188002 RVA: 0x00AD0475 File Offset: 0x00ACE675
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqSkeletal_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqSkeletal_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17007DE9 RID: 32233
		// (get) Token: 0x0602DE63 RID: 188003 RVA: 0x00AD048A File Offset: 0x00ACE68A
		// (set) Token: 0x0602DE64 RID: 188004 RVA: 0x00AD049E File Offset: 0x00ACE69E
		public unsafe ABPC_Seq_Body_V2_C ABPC_Body_V2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ABPC_Seq_Body_V2_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqSkeletal_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqSkeletal_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17007DEA RID: 32234
		// (get) Token: 0x0602DE65 RID: 188005 RVA: 0x00AD04B3 File Offset: 0x00ACE6B3
		// (set) Token: 0x0602DE66 RID: 188006 RVA: 0x00AD04C7 File Offset: 0x00ACE6C7
		public unsafe USkeletalMesh Mesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqSkeletal_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqSkeletal_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17007DEB RID: 32235
		// (get) Token: 0x0602DE67 RID: 188007 RVA: 0x00AD04DC File Offset: 0x00ACE6DC
		// (set) Token: 0x0602DE68 RID: 188008 RVA: 0x00AD04EC File Offset: 0x00ACE6EC
		public unsafe int TalkID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqSkeletal_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqSkeletal_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007DEC RID: 32236
		// (get) Token: 0x0602DE69 RID: 188009 RVA: 0x00AD04FD File Offset: 0x00ACE6FD
		// (set) Token: 0x0602DE6A RID: 188010 RVA: 0x00AD050D File Offset: 0x00ACE70D
		public unsafe int TalkID_SP
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqSkeletal_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqSkeletal_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17007DED RID: 32237
		// (get) Token: 0x0602DE6B RID: 188011 RVA: 0x00AD0520 File Offset: 0x00ACE720
		// (set) Token: 0x0602DE6C RID: 188012 RVA: 0x00AD0559 File Offset: 0x00ACE759
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
					result = (this._BoneData = new TMap<FName, FTransform>(base.NativePtr + (IntPtr)BP_SeqSkeletal_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.BoneData.CopyAssign(value);
			}
		}

		// Token: 0x0602DE6D RID: 188013 RVA: 0x00AD0568 File Offset: 0x00ACE768
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetSeqAudio(ref SeqAudio_Seq_V2_C SeqAudio)
		{
			BP_SeqSkeletal_C.__GetSeqAudio_FunctionParams* ptr = stackalloc BP_SeqSkeletal_C.__GetSeqAudio_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SeqSkeletal_C.__GetSeqAudio_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqSkeletal_C.__GetSeqAudio_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_SeqSkeletal_C.__GetSeqAudio_FunctionParams ptr2 = ref *ptr;
			SeqAudio_Seq_V2_C seqAudio_Seq_V2_C = SeqAudio;
			ptr2.SeqAudio = ((seqAudio_Seq_V2_C != null) ? seqAudio_Seq_V2_C.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqSkeletal_C.__GetSeqAudio_NativeFunctionPtr, (void*)ptr);
			SeqAudio = BuiltinUtils.GetOrCreateUObjectByNativePointer<SeqAudio_Seq_V2_C>(ptr->SeqAudio);
		}

		// Token: 0x0602DE6E RID: 188014 RVA: 0x00AD05CC File Offset: 0x00ACE7CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetABPC_Body_V2(ref ABPC_Seq_Body_V2_C ABPC_Body_V2)
		{
			BP_SeqSkeletal_C.__GetABPC_Body_V2_FunctionParams* ptr = stackalloc BP_SeqSkeletal_C.__GetABPC_Body_V2_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SeqSkeletal_C.__GetABPC_Body_V2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqSkeletal_C.__GetABPC_Body_V2_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_SeqSkeletal_C.__GetABPC_Body_V2_FunctionParams ptr2 = ref *ptr;
			ABPC_Seq_Body_V2_C abpc_Seq_Body_V2_C = ABPC_Body_V2;
			ptr2.ABPC_Body_V2 = ((abpc_Seq_Body_V2_C != null) ? abpc_Seq_Body_V2_C.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqSkeletal_C.__GetABPC_Body_V2_NativeFunctionPtr, (void*)ptr);
			ABPC_Body_V2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<ABPC_Seq_Body_V2_C>(ptr->ABPC_Body_V2);
		}

		// Token: 0x0602DE6F RID: 188015 RVA: 0x00AD0630 File Offset: 0x00ACE830
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool GetAnimDataTransform(ref TMap<FName, FTransform> FloatCurveData)
		{
			BP_SeqSkeletal_C.__GetAnimDataTransform_FunctionParams* ptr = stackalloc BP_SeqSkeletal_C.__GetAnimDataTransform_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SeqSkeletal_C.__GetAnimDataTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqSkeletal_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			TMap<FName, FTransform> tmap = FloatCurveData;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqSkeletal_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr);
			TMap<FName, FTransform> tmap2 = FloatCurveData;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqSkeletal_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE70 RID: 188016 RVA: 0x00AD06B0 File Offset: 0x00ACE8B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool GetAnimDataTransform_Implementation(ref TMap<FName, FTransform> FloatCurveData)
		{
			BP_SeqSkeletal_C.__GetAnimDataTransform_FunctionParams* ptr = stackalloc BP_SeqSkeletal_C.__GetAnimDataTransform_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SeqSkeletal_C.__GetAnimDataTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqSkeletal_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			TMap<FName, FTransform> tmap = FloatCurveData;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqSkeletal_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 0);
			TMap<FName, FTransform> tmap2 = FloatCurveData;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqSkeletal_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE71 RID: 188017 RVA: 0x00AD0730 File Offset: 0x00ACE930
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool IsCustomSupport()
		{
			BP_SeqSkeletal_C.__IsCustomSupport_FunctionParams* ptr = stackalloc BP_SeqSkeletal_C.__IsCustomSupport_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_SeqSkeletal_C.__IsCustomSupport_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqSkeletal_C.__IsCustomSupport_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqSkeletal_C.__IsCustomSupport_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602DE72 RID: 188018 RVA: 0x00AD0778 File Offset: 0x00ACE978
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool IsCustomSupport_Implementation()
		{
			BP_SeqSkeletal_C.__IsCustomSupport_FunctionParams* ptr = stackalloc BP_SeqSkeletal_C.__IsCustomSupport_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_SeqSkeletal_C.__IsCustomSupport_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqSkeletal_C.__IsCustomSupport_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqSkeletal_C.__IsCustomSupport_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0602DE73 RID: 188019 RVA: 0x00AD07C0 File Offset: 0x00ACE9C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool SetAnimDataTransform(in TMap<FName, FTransform> FloatCurveData)
		{
			BP_SeqSkeletal_C.__SetAnimDataTransform_FunctionParams* ptr = stackalloc BP_SeqSkeletal_C.__SetAnimDataTransform_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SeqSkeletal_C.__SetAnimDataTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqSkeletal_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			object obj = FloatCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqSkeletal_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr);
			object obj2 = FloatCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqSkeletal_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE74 RID: 188020 RVA: 0x00AD0840 File Offset: 0x00ACEA40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool SetAnimDataTransform_Implementation(in TMap<FName, FTransform> FloatCurveData)
		{
			BP_SeqSkeletal_C.__SetAnimDataTransform_FunctionParams* ptr = stackalloc BP_SeqSkeletal_C.__SetAnimDataTransform_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SeqSkeletal_C.__SetAnimDataTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqSkeletal_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			object obj = FloatCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqSkeletal_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 0);
			object obj2 = FloatCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqSkeletal_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE75 RID: 188021 RVA: 0x00AD08C0 File Offset: 0x00ACEAC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool GetAnimDataFloat([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<FNamedCurveValue> FloatCurveData)
		{
			BP_SeqSkeletal_C.__GetAnimDataFloat_FunctionParams* ptr = stackalloc BP_SeqSkeletal_C.__GetAnimDataFloat_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_SeqSkeletal_C.__GetAnimDataFloat_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqSkeletal_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FNamedCurveValue> tarray = FloatCurveData;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqSkeletal_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr);
			TArray<FNamedCurveValue> tarray2 = FloatCurveData;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqSkeletal_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE76 RID: 188022 RVA: 0x00AD0940 File Offset: 0x00ACEB40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool GetAnimDataFloat_Implementation([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<FNamedCurveValue> FloatCurveData)
		{
			BP_SeqSkeletal_C.__GetAnimDataFloat_FunctionParams* ptr = stackalloc BP_SeqSkeletal_C.__GetAnimDataFloat_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_SeqSkeletal_C.__GetAnimDataFloat_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqSkeletal_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FNamedCurveValue> tarray = FloatCurveData;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqSkeletal_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 0);
			TArray<FNamedCurveValue> tarray2 = FloatCurveData;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqSkeletal_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE77 RID: 188023 RVA: 0x00AD09C0 File Offset: 0x00ACEBC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool GetAnimDataVector(ref TMap<FName, FVector> VectorCurveData)
		{
			BP_SeqSkeletal_C.__GetAnimDataVector_FunctionParams* ptr = stackalloc BP_SeqSkeletal_C.__GetAnimDataVector_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SeqSkeletal_C.__GetAnimDataVector_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqSkeletal_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			TMap<FName, FVector> tmap = VectorCurveData;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->VectorCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqSkeletal_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr);
			TMap<FName, FVector> tmap2 = VectorCurveData;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->VectorCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqSkeletal_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE78 RID: 188024 RVA: 0x00AD0A40 File Offset: 0x00ACEC40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool GetAnimDataVector_Implementation(ref TMap<FName, FVector> VectorCurveData)
		{
			BP_SeqSkeletal_C.__GetAnimDataVector_FunctionParams* ptr = stackalloc BP_SeqSkeletal_C.__GetAnimDataVector_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SeqSkeletal_C.__GetAnimDataVector_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqSkeletal_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			TMap<FName, FVector> tmap = VectorCurveData;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->VectorCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqSkeletal_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr, 0);
			TMap<FName, FVector> tmap2 = VectorCurveData;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->VectorCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqSkeletal_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE79 RID: 188025 RVA: 0x00AD0AC0 File Offset: 0x00ACECC0
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual TArray<FName> GetSupportGroupNames()
		{
			BP_SeqSkeletal_C.__GetSupportGroupNames_FunctionParams* ptr = stackalloc BP_SeqSkeletal_C.__GetSupportGroupNames_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_SeqSkeletal_C.__GetSupportGroupNames_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqSkeletal_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqSkeletal_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr);
			TArray<FName> result = new TArray<FName>(&ptr->__Result, true, true);
			UnrealReflectionUtils.DestroyStruct(BP_SeqSkeletal_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr, 1);
			return result;
		}

		// Token: 0x0602DE7A RID: 188026 RVA: 0x00AD0B20 File Offset: 0x00ACED20
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual TArray<FName> GetSupportGroupNames_Implementation()
		{
			BP_SeqSkeletal_C.__GetSupportGroupNames_FunctionParams* ptr = stackalloc BP_SeqSkeletal_C.__GetSupportGroupNames_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_SeqSkeletal_C.__GetSupportGroupNames_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqSkeletal_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqSkeletal_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr, 0);
			TArray<FName> result = new TArray<FName>(&ptr->__Result, true, true);
			UnrealReflectionUtils.DestroyStruct(BP_SeqSkeletal_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr, 1);
			return result;
		}

		// Token: 0x0602DE7B RID: 188027 RVA: 0x00AD0B80 File Offset: 0x00ACED80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool SetAnimDataFloat([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<FNamedCurveValue> FloatCurveData)
		{
			BP_SeqSkeletal_C.__SetAnimDataFloat_FunctionParams* ptr = stackalloc BP_SeqSkeletal_C.__SetAnimDataFloat_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_SeqSkeletal_C.__SetAnimDataFloat_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqSkeletal_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			object obj = FloatCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqSkeletal_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr);
			object obj2 = FloatCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqSkeletal_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE7C RID: 188028 RVA: 0x00AD0C00 File Offset: 0x00ACEE00
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool SetAnimDataFloat_Implementation([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<FNamedCurveValue> FloatCurveData)
		{
			BP_SeqSkeletal_C.__SetAnimDataFloat_FunctionParams* ptr = stackalloc BP_SeqSkeletal_C.__SetAnimDataFloat_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_SeqSkeletal_C.__SetAnimDataFloat_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqSkeletal_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			object obj = FloatCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqSkeletal_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 0);
			object obj2 = FloatCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqSkeletal_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE7D RID: 188029 RVA: 0x00AD0C80 File Offset: 0x00ACEE80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool SetAnimDataVector(in TMap<FName, FVector> VectorCurveData)
		{
			BP_SeqSkeletal_C.__SetAnimDataVector_FunctionParams* ptr = stackalloc BP_SeqSkeletal_C.__SetAnimDataVector_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SeqSkeletal_C.__SetAnimDataVector_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqSkeletal_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			object obj = VectorCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->VectorCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqSkeletal_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr);
			object obj2 = VectorCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->VectorCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqSkeletal_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE7E RID: 188030 RVA: 0x00AD0D00 File Offset: 0x00ACEF00
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool SetAnimDataVector_Implementation(in TMap<FName, FVector> VectorCurveData)
		{
			BP_SeqSkeletal_C.__SetAnimDataVector_FunctionParams* ptr = stackalloc BP_SeqSkeletal_C.__SetAnimDataVector_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SeqSkeletal_C.__SetAnimDataVector_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqSkeletal_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			object obj = VectorCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->VectorCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqSkeletal_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr, 0);
			object obj2 = VectorCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->VectorCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqSkeletal_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE7F RID: 188031 RVA: 0x00AD0D7F File Offset: 0x00ACEF7F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqSkeletal_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602DE80 RID: 188032 RVA: 0x00AD0D93 File Offset: 0x00ACEF93
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqSkeletal_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602DE81 RID: 188033 RVA: 0x00AD0DA8 File Offset: 0x00ACEFA8
		protected BP_SeqSkeletal_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019EEE RID: 106222
		internal static int __InterfaceOffset_ISeqAnimDataInterface;

		// Token: 0x04019EEF RID: 106223
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Sequence/Seq_BP/BP_SeqSkeletal.BP_SeqSkeletal_C";

		// Token: 0x04019EF0 RID: 106224
		private static IntPtr _ClassPtr;

		// Token: 0x04019EF1 RID: 106225
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019EF2 RID: 106226
		internal static int __PropertyOffset_0;

		// Token: 0x04019EF3 RID: 106227
		internal static int __PropertyOffset_1;

		// Token: 0x04019EF4 RID: 106228
		internal static int __PropertyOffset_2;

		// Token: 0x04019EF5 RID: 106229
		internal static int __PropertyOffset_3;

		// Token: 0x04019EF6 RID: 106230
		internal static int __PropertyOffset_4;

		// Token: 0x04019EF7 RID: 106231
		internal static int __PropertyOffset_5;

		// Token: 0x04019EF8 RID: 106232
		internal static int __PropertyOffset_6;

		// Token: 0x04019EF9 RID: 106233
		internal static int __PropertyOffset_7;

		// Token: 0x04019EFA RID: 106234
		private TMap<FName, FTransform> _BoneData;

		// Token: 0x04019EFB RID: 106235
		private static IntPtr __GetSeqAudio_NativeFunctionPtr;

		// Token: 0x04019EFC RID: 106236
		private static IntPtr __GetABPC_Body_V2_NativeFunctionPtr;

		// Token: 0x04019EFD RID: 106237
		private static IntPtr __GetAnimDataTransform_NativeFunctionPtr;

		// Token: 0x04019EFE RID: 106238
		private static IntPtr __IsCustomSupport_NativeFunctionPtr;

		// Token: 0x04019EFF RID: 106239
		private static IntPtr __SetAnimDataTransform_NativeFunctionPtr;

		// Token: 0x04019F00 RID: 106240
		private static IntPtr __GetAnimDataFloat_NativeFunctionPtr;

		// Token: 0x04019F01 RID: 106241
		private static IntPtr __GetAnimDataVector_NativeFunctionPtr;

		// Token: 0x04019F02 RID: 106242
		private static IntPtr __GetSupportGroupNames_NativeFunctionPtr;

		// Token: 0x04019F03 RID: 106243
		private static IntPtr __SetAnimDataFloat_NativeFunctionPtr;

		// Token: 0x04019F04 RID: 106244
		private static IntPtr __SetAnimDataVector_NativeFunctionPtr;

		// Token: 0x04019F05 RID: 106245
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0200A5DC RID: 42460
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __GetSeqAudio_FunctionParams
		{
			// Token: 0x04033579 RID: 210297
			[FieldOffset(0)]
			public IntPtr SeqAudio;
		}

		// Token: 0x0200A5DD RID: 42461
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __GetABPC_Body_V2_FunctionParams
		{
			// Token: 0x0403357A RID: 210298
			[FieldOffset(0)]
			public IntPtr ABPC_Body_V2;
		}

		// Token: 0x0200A5DE RID: 42462
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __GetAnimDataTransform_FunctionParams
		{
			// Token: 0x0403357B RID: 210299
			[FieldOffset(0)]
			public byte FloatCurveData;

			// Token: 0x0403357C RID: 210300
			[FieldOffset(80)]
			public bool __Result;
		}

		// Token: 0x0200A5DF RID: 42463
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __IsCustomSupport_FunctionParams
		{
			// Token: 0x0403357D RID: 210301
			[FieldOffset(0)]
			public bool __Result;
		}

		// Token: 0x0200A5E0 RID: 42464
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __SetAnimDataTransform_FunctionParams
		{
			// Token: 0x0403357E RID: 210302
			[FieldOffset(0)]
			public byte FloatCurveData;

			// Token: 0x0403357F RID: 210303
			[FieldOffset(80)]
			public bool __Result;
		}

		// Token: 0x0200A5E1 RID: 42465
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __GetAnimDataFloat_FunctionParams
		{
			// Token: 0x04033580 RID: 210304
			[FieldOffset(0)]
			public byte FloatCurveData;

			// Token: 0x04033581 RID: 210305
			[FieldOffset(16)]
			public bool __Result;
		}

		// Token: 0x0200A5E2 RID: 42466
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __GetAnimDataVector_FunctionParams
		{
			// Token: 0x04033582 RID: 210306
			[FieldOffset(0)]
			public byte VectorCurveData;

			// Token: 0x04033583 RID: 210307
			[FieldOffset(80)]
			public bool __Result;
		}

		// Token: 0x0200A5E3 RID: 42467
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __GetSupportGroupNames_FunctionParams
		{
			// Token: 0x04033584 RID: 210308
			[FieldOffset(0)]
			public byte __Result;
		}

		// Token: 0x0200A5E4 RID: 42468
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __SetAnimDataFloat_FunctionParams
		{
			// Token: 0x04033585 RID: 210309
			[FieldOffset(0)]
			public byte FloatCurveData;

			// Token: 0x04033586 RID: 210310
			[FieldOffset(16)]
			public bool __Result;
		}

		// Token: 0x0200A5E5 RID: 42469
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __SetAnimDataVector_FunctionParams
		{
			// Token: 0x04033587 RID: 210311
			[FieldOffset(0)]
			public byte VectorCurveData;

			// Token: 0x04033588 RID: 210312
			[FieldOffset(80)]
			public bool __Result;
		}
	}
}
