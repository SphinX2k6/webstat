using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.TypeScript.Game.NewWorld.Character.SimpleNpc.Blueprint
{
	// Token: 0x020039BC RID: 14780
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/BP_Simpleholographic.BP_SimpleHolographic_C")]
	[UnrealStructLayout(1192, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1186)]
	public class BP_SimpleHolographic_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601DDE3 RID: 122339 RVA: 0x008E5298 File Offset: 0x008E3498
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SimpleHolographic_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/BP_Simpleholographic.BP_SimpleHolographic_C");
			}
			return BP_SimpleHolographic_C._ClassPtr;
		}

		// Token: 0x0601DDE4 RID: 122340 RVA: 0x008E52BC File Offset: 0x008E34BC
		public BP_SimpleHolographic_C() : this(BuiltinUtils.AllocNativeUObject(BP_SimpleHolographic_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601DDE5 RID: 122341 RVA: 0x008E52E4 File Offset: 0x008E34E4
		public BP_SimpleHolographic_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SimpleHolographic_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002791 RID: 10129
		// (get) Token: 0x0601DDE6 RID: 122342 RVA: 0x008E5318 File Offset: 0x008E3518
		// (set) Token: 0x0601DDE7 RID: 122343 RVA: 0x008E5351 File Offset: 0x008E3551
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SimpleHolographic_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SimpleHolographic_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002792 RID: 10130
		// (get) Token: 0x0601DDE8 RID: 122344 RVA: 0x008E5372 File Offset: 0x008E3572
		// (set) Token: 0x0601DDE9 RID: 122345 RVA: 0x008E5386 File Offset: 0x008E3586
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleHolographic_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleHolographic_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002793 RID: 10131
		// (get) Token: 0x0601DDEA RID: 122346 RVA: 0x008E539C File Offset: 0x008E359C
		// (set) Token: 0x0601DDEB RID: 122347 RVA: 0x008E53D5 File Offset: 0x008E35D5
		public TMap<USkeletalMeshComponent, SHolographicMaterialsCache> ComponentMaterialsCache
		{
			get
			{
				base.FastCheckIsValid();
				TMap<USkeletalMeshComponent, SHolographicMaterialsCache> result;
				if ((result = this._ComponentMaterialsCache) == null)
				{
					result = (this._ComponentMaterialsCache = new TMap<USkeletalMeshComponent, SHolographicMaterialsCache>(base.NativePtr + (IntPtr)BP_SimpleHolographic_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.ComponentMaterialsCache.CopyAssign(value);
			}
		}

		// Token: 0x17002794 RID: 10132
		// (get) Token: 0x0601DDEC RID: 122348 RVA: 0x008E53E4 File Offset: 0x008E35E4
		// (set) Token: 0x0601DDED RID: 122349 RVA: 0x008E541D File Offset: 0x008E361D
		public TArray<UMaterialInstanceDynamic> OL_Materials
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._OL_Materials) == null)
				{
					result = (this._OL_Materials = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_SimpleHolographic_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.OL_Materials.CopyAssign(value);
			}
		}

		// Token: 0x17002795 RID: 10133
		// (get) Token: 0x0601DDEE RID: 122350 RVA: 0x008E542C File Offset: 0x008E362C
		// (set) Token: 0x0601DDEF RID: 122351 RVA: 0x008E5465 File Offset: 0x008E3665
		public TArray<UMaterialInstanceDynamic> Other_Materials
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._Other_Materials) == null)
				{
					result = (this._Other_Materials = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_SimpleHolographic_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.Other_Materials.CopyAssign(value);
			}
		}

		// Token: 0x17002796 RID: 10134
		// (get) Token: 0x0601DDF0 RID: 122352 RVA: 0x008E5473 File Offset: 0x008E3673
		// (set) Token: 0x0601DDF1 RID: 122353 RVA: 0x008E5487 File Offset: 0x008E3687
		[Nullable(2)]
		public unsafe PD_HolographicEffect_C DATA
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_HolographicEffect_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleHolographic_C.__PropertyOffset_5);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleHolographic_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17002797 RID: 10135
		// (get) Token: 0x0601DDF2 RID: 122354 RVA: 0x008E549C File Offset: 0x008E369C
		// (set) Token: 0x0601DDF3 RID: 122355 RVA: 0x008E54AC File Offset: 0x008E36AC
		public unsafe float TimeCounter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SimpleHolographic_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SimpleHolographic_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17002798 RID: 10136
		// (get) Token: 0x0601DDF4 RID: 122356 RVA: 0x008E54BD File Offset: 0x008E36BD
		// (set) Token: 0x0601DDF5 RID: 122357 RVA: 0x008E54D1 File Offset: 0x008E36D1
		[Nullable(2)]
		public unsafe AActor TargetRole
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleHolographic_C.__PropertyOffset_7);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleHolographic_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17002799 RID: 10137
		// (get) Token: 0x0601DDF6 RID: 122358 RVA: 0x008E54E6 File Offset: 0x008E36E6
		// (set) Token: 0x0601DDF7 RID: 122359 RVA: 0x008E54FA File Offset: 0x008E36FA
		[Nullable(0)]
		public unsafe TEnumAsByte<EHolographicState> State
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SimpleHolographic_C.__PropertyOffset_8);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_SimpleHolographic_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700279A RID: 10138
		// (get) Token: 0x0601DDF8 RID: 122360 RVA: 0x008E550F File Offset: 0x008E370F
		// (set) Token: 0x0601DDF9 RID: 122361 RVA: 0x008E551F File Offset: 0x008E371F
		public unsafe bool bCached
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SimpleHolographic_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SimpleHolographic_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601DDFA RID: 122362 RVA: 0x008E5530 File Offset: 0x008E3730
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void RevertMaterialParamters(SMaterialParamCache MaterialCache, ref UMaterialInstanceDynamic result)
		{
			BP_SimpleHolographic_C.__RevertMaterialParamters_FunctionParams* ptr = stackalloc BP_SimpleHolographic_C.__RevertMaterialParamters_FunctionParams[(UIntPtr)495] + 15L / (long)sizeof(BP_SimpleHolographic_C.__RevertMaterialParamters_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SimpleHolographic_C.__RevertMaterialParamters_NativeFunctionPtr, (void*)ptr, 1);
			if (MaterialCache != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialParamCache.StaticStruct(), &ptr->MaterialCache, MaterialCache.NativePtr, 1, false);
			}
			ref BP_SimpleHolographic_C.__RevertMaterialParamters_FunctionParams ptr2 = ref *ptr;
			UMaterialInstanceDynamic umaterialInstanceDynamic = result;
			ptr2.result = ((umaterialInstanceDynamic != null) ? umaterialInstanceDynamic.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SimpleHolographic_C.__RevertMaterialParamters_NativeFunctionPtr, (void*)ptr);
			result = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMaterialInstanceDynamic>(ptr->result);
			UnrealReflectionUtils.DestroyStruct(BP_SimpleHolographic_C.__RevertMaterialParamters_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DDFB RID: 122363 RVA: 0x008E55CC File Offset: 0x008E37CC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual UMaterialInstanceDynamic CacheAndReplace(in SHolographicData SHolographicData, UPrimitiveComponent self2, int ElementIndex, UMaterialInstanceDynamic material, ref SMaterialParamCache CacheResult)
		{
			BP_SimpleHolographic_C.__CacheAndReplace_FunctionParams* ptr = stackalloc BP_SimpleHolographic_C.__CacheAndReplace_FunctionParams[(UIntPtr)519] + 15L / (long)sizeof(BP_SimpleHolographic_C.__CacheAndReplace_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SimpleHolographic_C.__CacheAndReplace_NativeFunctionPtr, (void*)ptr, 1);
			if (SHolographicData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SHolographicData.StaticStruct(), &ptr->SHolographicData, SHolographicData.NativePtr, 1, false);
			}
			ptr->self2 = ((self2 != null) ? self2.NativePtr : IntPtr.Zero);
			ptr->ElementIndex = ElementIndex;
			ptr->material = ((material != null) ? material.NativePtr : IntPtr.Zero);
			if (CacheResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialParamCache.StaticStruct(), &ptr->CacheResult, CacheResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SimpleHolographic_C.__CacheAndReplace_NativeFunctionPtr, (void*)ptr);
			if (CacheResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialParamCache.StaticStruct(), CacheResult.NativePtr, &ptr->CacheResult, 1, false);
			}
			UMaterialInstanceDynamic orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMaterialInstanceDynamic>(ptr->__Result);
			UnrealReflectionUtils.DestroyStruct(BP_SimpleHolographic_C.__CacheAndReplace_NativeFunctionPtr, (void*)ptr, 1);
			return orCreateUObjectByNativePointer;
		}

		// Token: 0x0601DDFC RID: 122364 RVA: 0x008E56D0 File Offset: 0x008E38D0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CacheMaterialParameters([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<SMaterialControllerFloatParameter> floats, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<SMaterialControllerColorParameter> colors, UMaterialInstanceDynamic material, bool bReplaceMaterial, int index, ref SMaterialParamCache result)
		{
			BP_SimpleHolographic_C.__CacheMaterialParameters_FunctionParams* ptr = stackalloc BP_SimpleHolographic_C.__CacheMaterialParameters_FunctionParams[(UIntPtr)2743] + 15L / (long)sizeof(BP_SimpleHolographic_C.__CacheMaterialParameters_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SimpleHolographic_C.__CacheMaterialParameters_NativeFunctionPtr, (void*)ptr, 1);
			TArray<SMaterialControllerFloatParameter> tarray = floats;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->floats);
			}
			TArray<SMaterialControllerColorParameter> tarray2 = colors;
			if (tarray2 != null)
			{
				tarray2.MoveTo(&ptr->colors);
			}
			ptr->material = ((material != null) ? material.NativePtr : IntPtr.Zero);
			ptr->bReplaceMaterial = bReplaceMaterial;
			ptr->index = index;
			if (result != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialParamCache.StaticStruct(), &ptr->result, result.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SimpleHolographic_C.__CacheMaterialParameters_NativeFunctionPtr, (void*)ptr);
			TArray<SMaterialControllerFloatParameter> tarray3 = floats;
			if (tarray3 != null)
			{
				tarray3.MoveAssign(&ptr->floats);
			}
			TArray<SMaterialControllerColorParameter> tarray4 = colors;
			if (tarray4 != null)
			{
				tarray4.MoveAssign(&ptr->colors);
			}
			if (result != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialParamCache.StaticStruct(), result.NativePtr, &ptr->result, 1, false);
			}
			UnrealReflectionUtils.DestroyStruct(BP_SimpleHolographic_C.__CacheMaterialParameters_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DDFD RID: 122365 RVA: 0x008E57E5 File Offset: 0x008E39E5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Clear()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SimpleHolographic_C.__Clear_NativeFunctionPtr, null);
		}

		// Token: 0x0601DDFE RID: 122366 RVA: 0x008E57F9 File Offset: 0x008E39F9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RemoveNpcEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SimpleHolographic_C.__RemoveNpcEffect_NativeFunctionPtr, null);
		}

		// Token: 0x0601DDFF RID: 122367 RVA: 0x008E5810 File Offset: 0x008E3A10
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateMaterialsWithDa([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<UMaterialInstanceDynamic> Materials, in SHolographicData SHolographicData)
		{
			BP_SimpleHolographic_C.__UpdateMaterialsWithDa_FunctionParams* ptr = stackalloc BP_SimpleHolographic_C.__UpdateMaterialsWithDa_FunctionParams[(UIntPtr)3031] + 15L / (long)sizeof(BP_SimpleHolographic_C.__UpdateMaterialsWithDa_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SimpleHolographic_C.__UpdateMaterialsWithDa_NativeFunctionPtr, (void*)ptr, 1);
			TArray<UMaterialInstanceDynamic> tarray = Materials;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->Materials);
			}
			if (SHolographicData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SHolographicData.StaticStruct(), &ptr->SHolographicData, SHolographicData.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SimpleHolographic_C.__UpdateMaterialsWithDa_NativeFunctionPtr, (void*)ptr);
			TArray<UMaterialInstanceDynamic> tarray2 = Materials;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->Materials);
			}
			UnrealReflectionUtils.DestroyStruct(BP_SimpleHolographic_C.__UpdateMaterialsWithDa_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DE00 RID: 122368 RVA: 0x008E58AF File Offset: 0x008E3AAF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EndEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SimpleHolographic_C.__EndEffect_NativeFunctionPtr, null);
		}

		// Token: 0x0601DE01 RID: 122369 RVA: 0x008E58C3 File Offset: 0x008E3AC3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SimpleHolographic_C.__StartEffect_NativeFunctionPtr, null);
		}

		// Token: 0x0601DE02 RID: 122370 RVA: 0x008E58D8 File Offset: 0x008E3AD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SimpleHolographic_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SimpleHolographic_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SimpleHolographic_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SimpleHolographic_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SimpleHolographic_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DE03 RID: 122371 RVA: 0x008E5920 File Offset: 0x008E3B20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SimpleHolographic_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SimpleHolographic_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SimpleHolographic_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SimpleHolographic_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SimpleHolographic_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601DE04 RID: 122372 RVA: 0x008E5968 File Offset: 0x008E3B68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SimpleHolographic(int EntryPoint)
		{
			BP_SimpleHolographic_C.__ExecuteUbergraph_BP_SimpleHolographic_FunctionParams* ptr = stackalloc BP_SimpleHolographic_C.__ExecuteUbergraph_BP_SimpleHolographic_FunctionParams[(UIntPtr)35] + 15L / (long)sizeof(BP_SimpleHolographic_C.__ExecuteUbergraph_BP_SimpleHolographic_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SimpleHolographic_C.__ExecuteUbergraph_BP_SimpleHolographic_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SimpleHolographic_C.__ExecuteUbergraph_BP_SimpleHolographic_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601DE05 RID: 122373 RVA: 0x008E59AF File Offset: 0x008E3BAF
		protected BP_SimpleHolographic_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EA08 RID: 59912
		public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/BP_Simpleholographic.BP_SimpleHolographic_C";

		// Token: 0x0400EA09 RID: 59913
		private static IntPtr _ClassPtr;

		// Token: 0x0400EA0A RID: 59914
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400EA0B RID: 59915
		internal static int __PropertyOffset_0;

		// Token: 0x0400EA0C RID: 59916
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400EA0D RID: 59917
		internal static int __PropertyOffset_1;

		// Token: 0x0400EA0E RID: 59918
		internal static int __PropertyOffset_2;

		// Token: 0x0400EA0F RID: 59919
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<USkeletalMeshComponent, SHolographicMaterialsCache> _ComponentMaterialsCache;

		// Token: 0x0400EA10 RID: 59920
		internal static int __PropertyOffset_3;

		// Token: 0x0400EA11 RID: 59921
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _OL_Materials;

		// Token: 0x0400EA12 RID: 59922
		internal static int __PropertyOffset_4;

		// Token: 0x0400EA13 RID: 59923
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _Other_Materials;

		// Token: 0x0400EA14 RID: 59924
		internal static int __PropertyOffset_5;

		// Token: 0x0400EA15 RID: 59925
		internal static int __PropertyOffset_6;

		// Token: 0x0400EA16 RID: 59926
		internal static int __PropertyOffset_7;

		// Token: 0x0400EA17 RID: 59927
		internal static int __PropertyOffset_8;

		// Token: 0x0400EA18 RID: 59928
		internal static int __PropertyOffset_9;

		// Token: 0x0400EA19 RID: 59929
		private static IntPtr __RevertMaterialParamters_NativeFunctionPtr;

		// Token: 0x0400EA1A RID: 59930
		private static IntPtr __CacheAndReplace_NativeFunctionPtr;

		// Token: 0x0400EA1B RID: 59931
		private static IntPtr __CacheMaterialParameters_NativeFunctionPtr;

		// Token: 0x0400EA1C RID: 59932
		private static IntPtr __Clear_NativeFunctionPtr;

		// Token: 0x0400EA1D RID: 59933
		private static IntPtr __RemoveNpcEffect_NativeFunctionPtr;

		// Token: 0x0400EA1E RID: 59934
		private static IntPtr __UpdateMaterialsWithDa_NativeFunctionPtr;

		// Token: 0x0400EA1F RID: 59935
		private static IntPtr __EndEffect_NativeFunctionPtr;

		// Token: 0x0400EA20 RID: 59936
		private static IntPtr __StartEffect_NativeFunctionPtr;

		// Token: 0x0400EA21 RID: 59937
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400EA22 RID: 59938
		private static IntPtr __ExecuteUbergraph_BP_SimpleHolographic_NativeFunctionPtr;

		// Token: 0x02009726 RID: 38694
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 480)]
		protected ref struct __RevertMaterialParamters_FunctionParams
		{
			// Token: 0x04031C78 RID: 203896
			[FieldOffset(0)]
			public byte MaterialCache;

			// Token: 0x04031C79 RID: 203897
			[FieldOffset(176)]
			public IntPtr result;
		}

		// Token: 0x02009727 RID: 38695
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 504)]
		protected ref struct __CacheAndReplace_FunctionParams
		{
			// Token: 0x04031C7A RID: 203898
			[FieldOffset(0)]
			public byte SHolographicData;

			// Token: 0x04031C7B RID: 203899
			[FieldOffset(96)]
			public IntPtr self2;

			// Token: 0x04031C7C RID: 203900
			[FieldOffset(104)]
			public int ElementIndex;

			// Token: 0x04031C7D RID: 203901
			[FieldOffset(112)]
			public IntPtr material;

			// Token: 0x04031C7E RID: 203902
			[FieldOffset(120)]
			public IntPtr __Result;

			// Token: 0x04031C7F RID: 203903
			[FieldOffset(128)]
			public byte CacheResult;
		}

		// Token: 0x02009728 RID: 38696
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2728)]
		protected ref struct __CacheMaterialParameters_FunctionParams
		{
			// Token: 0x04031C80 RID: 203904
			[FieldOffset(0)]
			public byte floats;

			// Token: 0x04031C81 RID: 203905
			[FieldOffset(16)]
			public byte colors;

			// Token: 0x04031C82 RID: 203906
			[FieldOffset(32)]
			public IntPtr material;

			// Token: 0x04031C83 RID: 203907
			[FieldOffset(40)]
			public bool bReplaceMaterial;

			// Token: 0x04031C84 RID: 203908
			[FieldOffset(44)]
			public int index;

			// Token: 0x04031C85 RID: 203909
			[FieldOffset(48)]
			public byte result;
		}

		// Token: 0x02009729 RID: 38697
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 3016)]
		protected ref struct __UpdateMaterialsWithDa_FunctionParams
		{
			// Token: 0x04031C86 RID: 203910
			[FieldOffset(0)]
			public byte Materials;

			// Token: 0x04031C87 RID: 203911
			[FieldOffset(16)]
			public byte SHolographicData;
		}

		// Token: 0x0200972A RID: 38698
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031C88 RID: 203912
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200972B RID: 38699
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 20)]
		protected ref struct __ExecuteUbergraph_BP_SimpleHolographic_FunctionParams
		{
			// Token: 0x04031C89 RID: 203913
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
