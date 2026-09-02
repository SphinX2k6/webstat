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
	// Token: 0x02004396 RID: 17302
	[UnrealObjectPath("/Game/Aki/Sequence/Seq_BP/BP_Mascot.BP_Mascot_C")]
	[UnrealStructLayout(1328, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1328)]
	public class BP_Mascot_C : AActor, IUnrealUObject, IUnrealObject, ISeqAnimDataInterface, IUnrealNativeInterface, IUnrealInterface, IABPC_Seq_MascotInterface_C, IUnrealBlueprintInterface
	{
		// Token: 0x0602DDED RID: 187885 RVA: 0x00ACEA48 File Offset: 0x00ACCC48
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Mascot_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Sequence/Seq_BP/BP_Mascot.BP_Mascot_C");
			}
			return BP_Mascot_C._ClassPtr;
		}

		// Token: 0x0602DDEE RID: 187886 RVA: 0x00ACEA6C File Offset: 0x00ACCC6C
		int ISeqAnimDataInterface.InterfaceOffset()
		{
			return BP_Mascot_C.__InterfaceOffset_ISeqAnimDataInterface;
		}

		// Token: 0x0602DDEF RID: 187887 RVA: 0x00ACEA74 File Offset: 0x00ACCC74
		public BP_Mascot_C() : this(BuiltinUtils.AllocNativeUObject(BP_Mascot_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DDF0 RID: 187888 RVA: 0x00ACEA9C File Offset: 0x00ACCC9C
		[NullableContext(1)]
		public BP_Mascot_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Mascot_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007DCE RID: 32206
		// (get) Token: 0x0602DDF1 RID: 187889 RVA: 0x00ACEACF File Offset: 0x00ACCCCF
		// (set) Token: 0x0602DDF2 RID: 187890 RVA: 0x00ACEAE3 File Offset: 0x00ACCCE3
		[Nullable(2)]
		public unsafe ABPC_Seq_Body_V2_C ABPC_Body_V2
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ABPC_Seq_Body_V2_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Mascot_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Mascot_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17007DCF RID: 32207
		// (get) Token: 0x0602DDF3 RID: 187891 RVA: 0x00ACEAF8 File Offset: 0x00ACCCF8
		// (set) Token: 0x0602DDF4 RID: 187892 RVA: 0x00ACEB0C File Offset: 0x00ACCD0C
		[Nullable(2)]
		public unsafe USkeletalMeshComponent SkeletalMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Mascot_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Mascot_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007DD0 RID: 32208
		// (get) Token: 0x0602DDF5 RID: 187893 RVA: 0x00ACEB21 File Offset: 0x00ACCD21
		// (set) Token: 0x0602DDF6 RID: 187894 RVA: 0x00ACEB35 File Offset: 0x00ACCD35
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Mascot_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Mascot_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17007DD1 RID: 32209
		// (get) Token: 0x0602DDF7 RID: 187895 RVA: 0x00ACEB4A File Offset: 0x00ACCD4A
		// (set) Token: 0x0602DDF8 RID: 187896 RVA: 0x00ACEB5E File Offset: 0x00ACCD5E
		public unsafe FRotator Add_Spine
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Mascot_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Mascot_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007DD2 RID: 32210
		// (get) Token: 0x0602DDF9 RID: 187897 RVA: 0x00ACEB73 File Offset: 0x00ACCD73
		// (set) Token: 0x0602DDFA RID: 187898 RVA: 0x00ACEB87 File Offset: 0x00ACCD87
		public unsafe FRotator Add_Spine_Head
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Mascot_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Mascot_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007DD3 RID: 32211
		// (get) Token: 0x0602DDFB RID: 187899 RVA: 0x00ACEB9C File Offset: 0x00ACCD9C
		// (set) Token: 0x0602DDFC RID: 187900 RVA: 0x00ACEBB0 File Offset: 0x00ACCDB0
		[Nullable(2)]
		public unsafe USkeletalMesh Mesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Mascot_C.__PropertyOffset_5);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Mascot_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17007DD4 RID: 32212
		// (get) Token: 0x0602DDFD RID: 187901 RVA: 0x00ACEBC8 File Offset: 0x00ACCDC8
		// (set) Token: 0x0602DDFE RID: 187902 RVA: 0x00ACEC01 File Offset: 0x00ACCE01
		[Nullable(1)]
		public TArray<FNamedCurveValue> NamedCurves
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FNamedCurveValue> result;
				if ((result = this._NamedCurves) == null)
				{
					result = (this._NamedCurves = new TArray<FNamedCurveValue>(base.NativePtr + (IntPtr)BP_Mascot_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.NamedCurves.CopyAssign(value);
			}
		}

		// Token: 0x17007DD5 RID: 32213
		// (get) Token: 0x0602DDFF RID: 187903 RVA: 0x00ACEC10 File Offset: 0x00ACCE10
		// (set) Token: 0x0602DE00 RID: 187904 RVA: 0x00ACEC49 File Offset: 0x00ACCE49
		[Nullable(1)]
		public FKuroCurveFloat KuroFixCurve
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._KuroFixCurve) == null)
				{
					result = (this._KuroFixCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_Mascot_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_Mascot_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007DD6 RID: 32214
		// (get) Token: 0x0602DE01 RID: 187905 RVA: 0x00ACEC6A File Offset: 0x00ACCE6A
		// (set) Token: 0x0602DE02 RID: 187906 RVA: 0x00ACEC7A File Offset: 0x00ACCE7A
		public unsafe int TalkID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Mascot_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Mascot_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17007DD7 RID: 32215
		// (get) Token: 0x0602DE03 RID: 187907 RVA: 0x00ACEC8B File Offset: 0x00ACCE8B
		// (set) Token: 0x0602DE04 RID: 187908 RVA: 0x00ACEC9B File Offset: 0x00ACCE9B
		public unsafe int TalkID_SP
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Mascot_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Mascot_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17007DD8 RID: 32216
		// (get) Token: 0x0602DE05 RID: 187909 RVA: 0x00ACECAC File Offset: 0x00ACCEAC
		// (set) Token: 0x0602DE06 RID: 187910 RVA: 0x00ACECE5 File Offset: 0x00ACCEE5
		[Nullable(1)]
		public TMap<FName, FTransform> Float_Curve_Data
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FTransform> result;
				if ((result = this._Float_Curve_Data) == null)
				{
					result = (this._Float_Curve_Data = new TMap<FName, FTransform>(base.NativePtr + (IntPtr)BP_Mascot_C.__PropertyOffset_10, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Float_Curve_Data.CopyAssign(value);
			}
		}

		// Token: 0x0602DE07 RID: 187911 RVA: 0x00ACECF4 File Offset: 0x00ACCEF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetAddSpineHeadValue(ref FRotator AddSpineHead)
		{
			BP_Mascot_C.__GetAddSpineHeadValue_FunctionParams* ptr = stackalloc BP_Mascot_C.__GetAddSpineHeadValue_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_Mascot_C.__GetAddSpineHeadValue_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Mascot_C.__GetAddSpineHeadValue_NativeFunctionPtr, (void*)ptr, 1);
			ptr->AddSpineHead = AddSpineHead;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Mascot_C.__GetAddSpineHeadValue_NativeFunctionPtr, (void*)ptr);
			AddSpineHead = ptr->AddSpineHead;
		}

		// Token: 0x0602DE08 RID: 187912 RVA: 0x00ACED4C File Offset: 0x00ACCF4C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetAddSpineValue(ref FRotator AddSpine)
		{
			BP_Mascot_C.__GetAddSpineValue_FunctionParams* ptr = stackalloc BP_Mascot_C.__GetAddSpineValue_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_Mascot_C.__GetAddSpineValue_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Mascot_C.__GetAddSpineValue_NativeFunctionPtr, (void*)ptr, 1);
			ptr->AddSpine = AddSpine;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Mascot_C.__GetAddSpineValue_NativeFunctionPtr, (void*)ptr);
			AddSpine = ptr->AddSpine;
		}

		// Token: 0x0602DE09 RID: 187913 RVA: 0x00ACEDA4 File Offset: 0x00ACCFA4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool GetAnimDataTransform(ref TMap<FName, FTransform> FloatCurveData)
		{
			BP_Mascot_C.__GetAnimDataTransform_FunctionParams* ptr = stackalloc BP_Mascot_C.__GetAnimDataTransform_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_Mascot_C.__GetAnimDataTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Mascot_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			TMap<FName, FTransform> tmap = FloatCurveData;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Mascot_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr);
			TMap<FName, FTransform> tmap2 = FloatCurveData;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_Mascot_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE0A RID: 187914 RVA: 0x00ACEE24 File Offset: 0x00ACD024
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool GetAnimDataTransform_Implementation(ref TMap<FName, FTransform> FloatCurveData)
		{
			BP_Mascot_C.__GetAnimDataTransform_FunctionParams* ptr = stackalloc BP_Mascot_C.__GetAnimDataTransform_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_Mascot_C.__GetAnimDataTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Mascot_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			TMap<FName, FTransform> tmap = FloatCurveData;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Mascot_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 0);
			TMap<FName, FTransform> tmap2 = FloatCurveData;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_Mascot_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE0B RID: 187915 RVA: 0x00ACEEA4 File Offset: 0x00ACD0A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool IsCustomSupport()
		{
			BP_Mascot_C.__IsCustomSupport_FunctionParams* ptr = stackalloc BP_Mascot_C.__IsCustomSupport_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_Mascot_C.__IsCustomSupport_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Mascot_C.__IsCustomSupport_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Mascot_C.__IsCustomSupport_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602DE0C RID: 187916 RVA: 0x00ACEEEC File Offset: 0x00ACD0EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool IsCustomSupport_Implementation()
		{
			BP_Mascot_C.__IsCustomSupport_FunctionParams* ptr = stackalloc BP_Mascot_C.__IsCustomSupport_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_Mascot_C.__IsCustomSupport_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Mascot_C.__IsCustomSupport_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Mascot_C.__IsCustomSupport_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0602DE0D RID: 187917 RVA: 0x00ACEF34 File Offset: 0x00ACD134
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool SetAnimDataTransform(in TMap<FName, FTransform> FloatCurveData)
		{
			BP_Mascot_C.__SetAnimDataTransform_FunctionParams* ptr = stackalloc BP_Mascot_C.__SetAnimDataTransform_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_Mascot_C.__SetAnimDataTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Mascot_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			object obj = FloatCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Mascot_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr);
			object obj2 = FloatCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_Mascot_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE0E RID: 187918 RVA: 0x00ACEFB4 File Offset: 0x00ACD1B4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool SetAnimDataTransform_Implementation(in TMap<FName, FTransform> FloatCurveData)
		{
			BP_Mascot_C.__SetAnimDataTransform_FunctionParams* ptr = stackalloc BP_Mascot_C.__SetAnimDataTransform_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_Mascot_C.__SetAnimDataTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Mascot_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			object obj = FloatCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Mascot_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 0);
			object obj2 = FloatCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_Mascot_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE0F RID: 187919 RVA: 0x00ACF034 File Offset: 0x00ACD234
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool GetAnimDataFloat([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<FNamedCurveValue> FloatCurveData)
		{
			BP_Mascot_C.__GetAnimDataFloat_FunctionParams* ptr = stackalloc BP_Mascot_C.__GetAnimDataFloat_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_Mascot_C.__GetAnimDataFloat_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Mascot_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FNamedCurveValue> tarray = FloatCurveData;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Mascot_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr);
			TArray<FNamedCurveValue> tarray2 = FloatCurveData;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_Mascot_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE10 RID: 187920 RVA: 0x00ACF0B4 File Offset: 0x00ACD2B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool GetAnimDataFloat_Implementation([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<FNamedCurveValue> FloatCurveData)
		{
			BP_Mascot_C.__GetAnimDataFloat_FunctionParams* ptr = stackalloc BP_Mascot_C.__GetAnimDataFloat_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_Mascot_C.__GetAnimDataFloat_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Mascot_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FNamedCurveValue> tarray = FloatCurveData;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Mascot_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 0);
			TArray<FNamedCurveValue> tarray2 = FloatCurveData;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_Mascot_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE11 RID: 187921 RVA: 0x00ACF134 File Offset: 0x00ACD334
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool GetAnimDataVector(ref TMap<FName, FVector> VectorCurveData)
		{
			BP_Mascot_C.__GetAnimDataVector_FunctionParams* ptr = stackalloc BP_Mascot_C.__GetAnimDataVector_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_Mascot_C.__GetAnimDataVector_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Mascot_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			TMap<FName, FVector> tmap = VectorCurveData;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->VectorCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Mascot_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr);
			TMap<FName, FVector> tmap2 = VectorCurveData;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->VectorCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_Mascot_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE12 RID: 187922 RVA: 0x00ACF1B4 File Offset: 0x00ACD3B4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool GetAnimDataVector_Implementation(ref TMap<FName, FVector> VectorCurveData)
		{
			BP_Mascot_C.__GetAnimDataVector_FunctionParams* ptr = stackalloc BP_Mascot_C.__GetAnimDataVector_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_Mascot_C.__GetAnimDataVector_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Mascot_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			TMap<FName, FVector> tmap = VectorCurveData;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->VectorCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Mascot_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr, 0);
			TMap<FName, FVector> tmap2 = VectorCurveData;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->VectorCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_Mascot_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE13 RID: 187923 RVA: 0x00ACF234 File Offset: 0x00ACD434
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual TArray<FName> GetSupportGroupNames()
		{
			BP_Mascot_C.__GetSupportGroupNames_FunctionParams* ptr = stackalloc BP_Mascot_C.__GetSupportGroupNames_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_Mascot_C.__GetSupportGroupNames_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Mascot_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Mascot_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr);
			TArray<FName> result = new TArray<FName>(&ptr->__Result, true, true);
			UnrealReflectionUtils.DestroyStruct(BP_Mascot_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr, 1);
			return result;
		}

		// Token: 0x0602DE14 RID: 187924 RVA: 0x00ACF294 File Offset: 0x00ACD494
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual TArray<FName> GetSupportGroupNames_Implementation()
		{
			BP_Mascot_C.__GetSupportGroupNames_FunctionParams* ptr = stackalloc BP_Mascot_C.__GetSupportGroupNames_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_Mascot_C.__GetSupportGroupNames_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Mascot_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Mascot_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr, 0);
			TArray<FName> result = new TArray<FName>(&ptr->__Result, true, true);
			UnrealReflectionUtils.DestroyStruct(BP_Mascot_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr, 1);
			return result;
		}

		// Token: 0x0602DE15 RID: 187925 RVA: 0x00ACF2F4 File Offset: 0x00ACD4F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool SetAnimDataFloat([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<FNamedCurveValue> FloatCurveData)
		{
			BP_Mascot_C.__SetAnimDataFloat_FunctionParams* ptr = stackalloc BP_Mascot_C.__SetAnimDataFloat_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_Mascot_C.__SetAnimDataFloat_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Mascot_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			object obj = FloatCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Mascot_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr);
			object obj2 = FloatCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_Mascot_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE16 RID: 187926 RVA: 0x00ACF374 File Offset: 0x00ACD574
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool SetAnimDataFloat_Implementation([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<FNamedCurveValue> FloatCurveData)
		{
			BP_Mascot_C.__SetAnimDataFloat_FunctionParams* ptr = stackalloc BP_Mascot_C.__SetAnimDataFloat_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_Mascot_C.__SetAnimDataFloat_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Mascot_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			object obj = FloatCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Mascot_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 0);
			object obj2 = FloatCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_Mascot_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE17 RID: 187927 RVA: 0x00ACF3F4 File Offset: 0x00ACD5F4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool SetAnimDataVector(in TMap<FName, FVector> VectorCurveData)
		{
			BP_Mascot_C.__SetAnimDataVector_FunctionParams* ptr = stackalloc BP_Mascot_C.__SetAnimDataVector_FunctionParams[(UIntPtr)207] + 15L / (long)sizeof(BP_Mascot_C.__SetAnimDataVector_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Mascot_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			object obj = VectorCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->VectorCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Mascot_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr);
			object obj2 = VectorCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->VectorCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_Mascot_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE18 RID: 187928 RVA: 0x00ACF478 File Offset: 0x00ACD678
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool SetAnimDataVector_Implementation(in TMap<FName, FVector> VectorCurveData)
		{
			BP_Mascot_C.__SetAnimDataVector_FunctionParams* ptr = stackalloc BP_Mascot_C.__SetAnimDataVector_FunctionParams[(UIntPtr)207] + 15L / (long)sizeof(BP_Mascot_C.__SetAnimDataVector_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Mascot_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			object obj = VectorCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->VectorCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Mascot_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr, 0);
			object obj2 = VectorCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->VectorCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_Mascot_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE19 RID: 187929 RVA: 0x00ACF4FC File Offset: 0x00ACD6FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CalcAllCurve_2([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<FNamedCurveValue> Ret)
		{
			BP_Mascot_C.__CalcAllCurve_2_FunctionParams* ptr = stackalloc BP_Mascot_C.__CalcAllCurve_2_FunctionParams[(UIntPtr)263] + 15L / (long)sizeof(BP_Mascot_C.__CalcAllCurve_2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Mascot_C.__CalcAllCurve_2_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FNamedCurveValue> tarray = Ret;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->Ret);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Mascot_C.__CalcAllCurve_2_NativeFunctionPtr, (void*)ptr);
			TArray<FNamedCurveValue> tarray2 = Ret;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->Ret);
			}
			UnrealReflectionUtils.DestroyStruct(BP_Mascot_C.__CalcAllCurve_2_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DE1A RID: 187930 RVA: 0x00ACF578 File Offset: 0x00ACD778
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CalcAllCurve([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<FNamedCurveValue> Ret)
		{
			BP_Mascot_C.__CalcAllCurve_FunctionParams* ptr = stackalloc BP_Mascot_C.__CalcAllCurve_FunctionParams[(UIntPtr)271] + 15L / (long)sizeof(BP_Mascot_C.__CalcAllCurve_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Mascot_C.__CalcAllCurve_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FNamedCurveValue> tarray = Ret;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->Ret);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Mascot_C.__CalcAllCurve_NativeFunctionPtr, (void*)ptr);
			TArray<FNamedCurveValue> tarray2 = Ret;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->Ret);
			}
			UnrealReflectionUtils.DestroyStruct(BP_Mascot_C.__CalcAllCurve_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DE1B RID: 187931 RVA: 0x00ACF5F4 File Offset: 0x00ACD7F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void HasFixCurve(FName CheckName, ref bool Ret, ref FName FixName)
		{
			BP_Mascot_C.__HasFixCurve_FunctionParams* ptr = stackalloc BP_Mascot_C.__HasFixCurve_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_Mascot_C.__HasFixCurve_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Mascot_C.__HasFixCurve_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CheckName = CheckName;
			ptr->Ret = Ret;
			ptr->FixName = FixName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Mascot_C.__HasFixCurve_NativeFunctionPtr, (void*)ptr);
			Ret = ptr->Ret;
			FixName = ptr->FixName;
		}

		// Token: 0x0602DE1C RID: 187932 RVA: 0x00ACF664 File Offset: 0x00ACD864
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetFixValue(float inValue, ref float FixValue)
		{
			BP_Mascot_C.__GetFixValue_FunctionParams* ptr = stackalloc BP_Mascot_C.__GetFixValue_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_Mascot_C.__GetFixValue_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Mascot_C.__GetFixValue_NativeFunctionPtr, (void*)ptr, 1);
			ptr->inValue = inValue;
			ptr->FixValue = FixValue;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Mascot_C.__GetFixValue_NativeFunctionPtr, (void*)ptr);
			FixValue = ptr->FixValue;
		}

		// Token: 0x0602DE1D RID: 187933 RVA: 0x00ACF6BA File Offset: 0x00ACD8BA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Mascot_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602DE1E RID: 187934 RVA: 0x00ACF6CE File Offset: 0x00ACD8CE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Mascot_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602DE1F RID: 187935 RVA: 0x00ACF6E3 File Offset: 0x00ACD8E3
		protected BP_Mascot_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019EAA RID: 106154
		internal static int __InterfaceOffset_ISeqAnimDataInterface;

		// Token: 0x04019EAB RID: 106155
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Sequence/Seq_BP/BP_Mascot.BP_Mascot_C";

		// Token: 0x04019EAC RID: 106156
		private static IntPtr _ClassPtr;

		// Token: 0x04019EAD RID: 106157
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019EAE RID: 106158
		internal static int __PropertyOffset_0;

		// Token: 0x04019EAF RID: 106159
		internal static int __PropertyOffset_1;

		// Token: 0x04019EB0 RID: 106160
		internal static int __PropertyOffset_2;

		// Token: 0x04019EB1 RID: 106161
		internal static int __PropertyOffset_3;

		// Token: 0x04019EB2 RID: 106162
		internal static int __PropertyOffset_4;

		// Token: 0x04019EB3 RID: 106163
		internal static int __PropertyOffset_5;

		// Token: 0x04019EB4 RID: 106164
		internal static int __PropertyOffset_6;

		// Token: 0x04019EB5 RID: 106165
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FNamedCurveValue> _NamedCurves;

		// Token: 0x04019EB6 RID: 106166
		internal static int __PropertyOffset_7;

		// Token: 0x04019EB7 RID: 106167
		[Nullable(2)]
		private FKuroCurveFloat _KuroFixCurve;

		// Token: 0x04019EB8 RID: 106168
		internal static int __PropertyOffset_8;

		// Token: 0x04019EB9 RID: 106169
		internal static int __PropertyOffset_9;

		// Token: 0x04019EBA RID: 106170
		internal static int __PropertyOffset_10;

		// Token: 0x04019EBB RID: 106171
		[Nullable(2)]
		private TMap<FName, FTransform> _Float_Curve_Data;

		// Token: 0x04019EBC RID: 106172
		private static IntPtr __GetAddSpineHeadValue_NativeFunctionPtr;

		// Token: 0x04019EBD RID: 106173
		private static IntPtr __GetAddSpineValue_NativeFunctionPtr;

		// Token: 0x04019EBE RID: 106174
		private static IntPtr __GetAnimDataTransform_NativeFunctionPtr;

		// Token: 0x04019EBF RID: 106175
		private static IntPtr __IsCustomSupport_NativeFunctionPtr;

		// Token: 0x04019EC0 RID: 106176
		private static IntPtr __SetAnimDataTransform_NativeFunctionPtr;

		// Token: 0x04019EC1 RID: 106177
		private static IntPtr __GetAnimDataFloat_NativeFunctionPtr;

		// Token: 0x04019EC2 RID: 106178
		private static IntPtr __GetAnimDataVector_NativeFunctionPtr;

		// Token: 0x04019EC3 RID: 106179
		private static IntPtr __GetSupportGroupNames_NativeFunctionPtr;

		// Token: 0x04019EC4 RID: 106180
		private static IntPtr __SetAnimDataFloat_NativeFunctionPtr;

		// Token: 0x04019EC5 RID: 106181
		private static IntPtr __SetAnimDataVector_NativeFunctionPtr;

		// Token: 0x04019EC6 RID: 106182
		private static IntPtr __CalcAllCurve_2_NativeFunctionPtr;

		// Token: 0x04019EC7 RID: 106183
		private static IntPtr __CalcAllCurve_NativeFunctionPtr;

		// Token: 0x04019EC8 RID: 106184
		private static IntPtr __HasFixCurve_NativeFunctionPtr;

		// Token: 0x04019EC9 RID: 106185
		private static IntPtr __GetFixValue_NativeFunctionPtr;

		// Token: 0x04019ECA RID: 106186
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0200A5C1 RID: 42433
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __GetAddSpineHeadValue_FunctionParams
		{
			// Token: 0x0403354F RID: 210255
			[FieldOffset(0)]
			public FRotator AddSpineHead;
		}

		// Token: 0x0200A5C2 RID: 42434
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __GetAddSpineValue_FunctionParams
		{
			// Token: 0x04033550 RID: 210256
			[FieldOffset(0)]
			public FRotator AddSpine;
		}

		// Token: 0x0200A5C3 RID: 42435
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __GetAnimDataTransform_FunctionParams
		{
			// Token: 0x04033551 RID: 210257
			[FieldOffset(0)]
			public byte FloatCurveData;

			// Token: 0x04033552 RID: 210258
			[FieldOffset(80)]
			public bool __Result;
		}

		// Token: 0x0200A5C4 RID: 42436
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __IsCustomSupport_FunctionParams
		{
			// Token: 0x04033553 RID: 210259
			[FieldOffset(0)]
			public bool __Result;
		}

		// Token: 0x0200A5C5 RID: 42437
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __SetAnimDataTransform_FunctionParams
		{
			// Token: 0x04033554 RID: 210260
			[FieldOffset(0)]
			public byte FloatCurveData;

			// Token: 0x04033555 RID: 210261
			[FieldOffset(80)]
			public bool __Result;
		}

		// Token: 0x0200A5C6 RID: 42438
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __GetAnimDataFloat_FunctionParams
		{
			// Token: 0x04033556 RID: 210262
			[FieldOffset(0)]
			public byte FloatCurveData;

			// Token: 0x04033557 RID: 210263
			[FieldOffset(16)]
			public bool __Result;
		}

		// Token: 0x0200A5C7 RID: 42439
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __GetAnimDataVector_FunctionParams
		{
			// Token: 0x04033558 RID: 210264
			[FieldOffset(0)]
			public byte VectorCurveData;

			// Token: 0x04033559 RID: 210265
			[FieldOffset(80)]
			public bool __Result;
		}

		// Token: 0x0200A5C8 RID: 42440
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __GetSupportGroupNames_FunctionParams
		{
			// Token: 0x0403355A RID: 210266
			[FieldOffset(0)]
			public byte __Result;
		}

		// Token: 0x0200A5C9 RID: 42441
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __SetAnimDataFloat_FunctionParams
		{
			// Token: 0x0403355B RID: 210267
			[FieldOffset(0)]
			public byte FloatCurveData;

			// Token: 0x0403355C RID: 210268
			[FieldOffset(16)]
			public bool __Result;
		}

		// Token: 0x0200A5CA RID: 42442
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 192)]
		protected ref struct __SetAnimDataVector_FunctionParams
		{
			// Token: 0x0403355D RID: 210269
			[FieldOffset(0)]
			public byte VectorCurveData;

			// Token: 0x0403355E RID: 210270
			[FieldOffset(80)]
			public bool __Result;
		}

		// Token: 0x0200A5CB RID: 42443
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 248)]
		protected ref struct __CalcAllCurve_2_FunctionParams
		{
			// Token: 0x0403355F RID: 210271
			[FieldOffset(0)]
			public byte Ret;
		}

		// Token: 0x0200A5CC RID: 42444
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 256)]
		protected ref struct __CalcAllCurve_FunctionParams
		{
			// Token: 0x04033560 RID: 210272
			[FieldOffset(0)]
			public byte Ret;
		}

		// Token: 0x0200A5CD RID: 42445
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __HasFixCurve_FunctionParams
		{
			// Token: 0x04033561 RID: 210273
			[FieldOffset(0)]
			public FName CheckName;

			// Token: 0x04033562 RID: 210274
			[FieldOffset(12)]
			public bool Ret;

			// Token: 0x04033563 RID: 210275
			[FieldOffset(16)]
			public FName FixName;
		}

		// Token: 0x0200A5CE RID: 42446
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __GetFixValue_FunctionParams
		{
			// Token: 0x04033564 RID: 210276
			[FieldOffset(0)]
			public float inValue;

			// Token: 0x04033565 RID: 210277
			[FieldOffset(4)]
			public float FixValue;
		}
	}
}
