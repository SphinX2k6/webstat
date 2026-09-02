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
	// Token: 0x020039C1 RID: 14785
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/SimpleHolographicComponent.SimpleHolographicComponent_C")]
	[UnrealStructLayout(344, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 344)]
	public class SimpleHolographicComponent_C : UActorComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601DE3E RID: 122430 RVA: 0x008E5EF0 File Offset: 0x008E40F0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (SimpleHolographicComponent_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/SimpleHolographicComponent.SimpleHolographicComponent_C");
			}
			return SimpleHolographicComponent_C._ClassPtr;
		}

		// Token: 0x0601DE3F RID: 122431 RVA: 0x008E5F14 File Offset: 0x008E4114
		public SimpleHolographicComponent_C() : this(BuiltinUtils.AllocNativeUObject(SimpleHolographicComponent_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601DE40 RID: 122432 RVA: 0x008E5F3C File Offset: 0x008E413C
		public SimpleHolographicComponent_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SimpleHolographicComponent_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170027AD RID: 10157
		// (get) Token: 0x0601DE41 RID: 122433 RVA: 0x008E5F70 File Offset: 0x008E4170
		// (set) Token: 0x0601DE42 RID: 122434 RVA: 0x008E5FA9 File Offset: 0x008E41A9
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)SimpleHolographicComponent_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)SimpleHolographicComponent_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170027AE RID: 10158
		// (get) Token: 0x0601DE43 RID: 122435 RVA: 0x008E5FCC File Offset: 0x008E41CC
		// (set) Token: 0x0601DE44 RID: 122436 RVA: 0x008E6005 File Offset: 0x008E4205
		public TArray<UMaterialInstanceDynamic> OL_Materials
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._OL_Materials) == null)
				{
					result = (this._OL_Materials = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)SimpleHolographicComponent_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.OL_Materials.CopyAssign(value);
			}
		}

		// Token: 0x170027AF RID: 10159
		// (get) Token: 0x0601DE45 RID: 122437 RVA: 0x008E6014 File Offset: 0x008E4214
		// (set) Token: 0x0601DE46 RID: 122438 RVA: 0x008E604D File Offset: 0x008E424D
		public TArray<UMaterialInstanceDynamic> Other_Materials
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._Other_Materials) == null)
				{
					result = (this._Other_Materials = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)SimpleHolographicComponent_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.Other_Materials.CopyAssign(value);
			}
		}

		// Token: 0x170027B0 RID: 10160
		// (get) Token: 0x0601DE47 RID: 122439 RVA: 0x008E605B File Offset: 0x008E425B
		// (set) Token: 0x0601DE48 RID: 122440 RVA: 0x008E606F File Offset: 0x008E426F
		[Nullable(2)]
		public unsafe PD_HolographicEffect_C DATA
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_HolographicEffect_C>(base.NativePtr / (IntPtr)sizeof(void*) + SimpleHolographicComponent_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SimpleHolographicComponent_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170027B1 RID: 10161
		// (get) Token: 0x0601DE49 RID: 122441 RVA: 0x008E6084 File Offset: 0x008E4284
		// (set) Token: 0x0601DE4A RID: 122442 RVA: 0x008E6094 File Offset: 0x008E4294
		public unsafe float TimeCounter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SimpleHolographicComponent_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SimpleHolographicComponent_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170027B2 RID: 10162
		// (get) Token: 0x0601DE4B RID: 122443 RVA: 0x008E60A5 File Offset: 0x008E42A5
		// (set) Token: 0x0601DE4C RID: 122444 RVA: 0x008E60B9 File Offset: 0x008E42B9
		[Nullable(0)]
		public unsafe TEnumAsByte<EHolographicState> State
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SimpleHolographicComponent_C.__PropertyOffset_5);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SimpleHolographicComponent_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170027B3 RID: 10163
		// (get) Token: 0x0601DE4D RID: 122445 RVA: 0x008E60CE File Offset: 0x008E42CE
		// (set) Token: 0x0601DE4E RID: 122446 RVA: 0x008E60DE File Offset: 0x008E42DE
		public unsafe bool bCached
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SimpleHolographicComponent_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SimpleHolographicComponent_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x170027B4 RID: 10164
		// (get) Token: 0x0601DE4F RID: 122447 RVA: 0x008E60F0 File Offset: 0x008E42F0
		// (set) Token: 0x0601DE50 RID: 122448 RVA: 0x008E6129 File Offset: 0x008E4329
		public TMap<USkeletalMeshComponent, SHolographicMaterialsCache> ComponentMaterialsCache
		{
			get
			{
				base.FastCheckIsValid();
				TMap<USkeletalMeshComponent, SHolographicMaterialsCache> result;
				if ((result = this._ComponentMaterialsCache) == null)
				{
					result = (this._ComponentMaterialsCache = new TMap<USkeletalMeshComponent, SHolographicMaterialsCache>(base.NativePtr + (IntPtr)SimpleHolographicComponent_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				this.ComponentMaterialsCache.CopyAssign(value);
			}
		}

		// Token: 0x0601DE51 RID: 122449 RVA: 0x008E6137 File Offset: 0x008E4337
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SimpleHolographicComponent_C.__StartEffect_NativeFunctionPtr, null);
		}

		// Token: 0x0601DE52 RID: 122450 RVA: 0x008E614B File Offset: 0x008E434B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EndEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SimpleHolographicComponent_C.__EndEffect_NativeFunctionPtr, null);
		}

		// Token: 0x0601DE53 RID: 122451 RVA: 0x008E6160 File Offset: 0x008E4360
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateMaterialsWithDa([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<UMaterialInstanceDynamic> Materials, in SHolographicData SHolographicData)
		{
			SimpleHolographicComponent_C.__UpdateMaterialsWithDa_FunctionParams* ptr = stackalloc SimpleHolographicComponent_C.__UpdateMaterialsWithDa_FunctionParams[(UIntPtr)3031] + 15L / (long)sizeof(SimpleHolographicComponent_C.__UpdateMaterialsWithDa_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SimpleHolographicComponent_C.__UpdateMaterialsWithDa_NativeFunctionPtr, (void*)ptr, 1);
			TArray<UMaterialInstanceDynamic> tarray = Materials;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->Materials);
			}
			if (SHolographicData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SHolographicData.StaticStruct(), &ptr->SHolographicData, SHolographicData.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SimpleHolographicComponent_C.__UpdateMaterialsWithDa_NativeFunctionPtr, (void*)ptr);
			TArray<UMaterialInstanceDynamic> tarray2 = Materials;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->Materials);
			}
			UnrealReflectionUtils.DestroyStruct(SimpleHolographicComponent_C.__UpdateMaterialsWithDa_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DE54 RID: 122452 RVA: 0x008E61FF File Offset: 0x008E43FF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RemoveNpcEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SimpleHolographicComponent_C.__RemoveNpcEffect_NativeFunctionPtr, null);
		}

		// Token: 0x0601DE55 RID: 122453 RVA: 0x008E6213 File Offset: 0x008E4413
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Clear()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SimpleHolographicComponent_C.__Clear_NativeFunctionPtr, null);
		}

		// Token: 0x0601DE56 RID: 122454 RVA: 0x008E6228 File Offset: 0x008E4428
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void RevertMaterialParamters(SMaterialParamCache MaterialCache, ref UMaterialInstanceDynamic result)
		{
			SimpleHolographicComponent_C.__RevertMaterialParamters_FunctionParams* ptr = stackalloc SimpleHolographicComponent_C.__RevertMaterialParamters_FunctionParams[(UIntPtr)495] + 15L / (long)sizeof(SimpleHolographicComponent_C.__RevertMaterialParamters_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SimpleHolographicComponent_C.__RevertMaterialParamters_NativeFunctionPtr, (void*)ptr, 1);
			if (MaterialCache != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialParamCache.StaticStruct(), &ptr->MaterialCache, MaterialCache.NativePtr, 1, false);
			}
			ref SimpleHolographicComponent_C.__RevertMaterialParamters_FunctionParams ptr2 = ref *ptr;
			UMaterialInstanceDynamic umaterialInstanceDynamic = result;
			ptr2.result = ((umaterialInstanceDynamic != null) ? umaterialInstanceDynamic.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SimpleHolographicComponent_C.__RevertMaterialParamters_NativeFunctionPtr, (void*)ptr);
			result = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMaterialInstanceDynamic>(ptr->result);
			UnrealReflectionUtils.DestroyStruct(SimpleHolographicComponent_C.__RevertMaterialParamters_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DE57 RID: 122455 RVA: 0x008E62C4 File Offset: 0x008E44C4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual UMaterialInstanceDynamic CacheAndReplace(in SHolographicData SHolographicData, UPrimitiveComponent self2, int ElementIndex, UMaterialInstanceDynamic material, ref SMaterialParamCache CacheResult)
		{
			SimpleHolographicComponent_C.__CacheAndReplace_FunctionParams* ptr = stackalloc SimpleHolographicComponent_C.__CacheAndReplace_FunctionParams[(UIntPtr)519] + 15L / (long)sizeof(SimpleHolographicComponent_C.__CacheAndReplace_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SimpleHolographicComponent_C.__CacheAndReplace_NativeFunctionPtr, (void*)ptr, 1);
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
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SimpleHolographicComponent_C.__CacheAndReplace_NativeFunctionPtr, (void*)ptr);
			if (CacheResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialParamCache.StaticStruct(), CacheResult.NativePtr, &ptr->CacheResult, 1, false);
			}
			UMaterialInstanceDynamic orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMaterialInstanceDynamic>(ptr->__Result);
			UnrealReflectionUtils.DestroyStruct(SimpleHolographicComponent_C.__CacheAndReplace_NativeFunctionPtr, (void*)ptr, 1);
			return orCreateUObjectByNativePointer;
		}

		// Token: 0x0601DE58 RID: 122456 RVA: 0x008E63C8 File Offset: 0x008E45C8
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
			SimpleHolographicComponent_C.__CacheMaterialParameters_FunctionParams* ptr = stackalloc SimpleHolographicComponent_C.__CacheMaterialParameters_FunctionParams[(UIntPtr)2743] + 15L / (long)sizeof(SimpleHolographicComponent_C.__CacheMaterialParameters_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SimpleHolographicComponent_C.__CacheMaterialParameters_NativeFunctionPtr, (void*)ptr, 1);
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
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SimpleHolographicComponent_C.__CacheMaterialParameters_NativeFunctionPtr, (void*)ptr);
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
			UnrealReflectionUtils.DestroyStruct(SimpleHolographicComponent_C.__CacheMaterialParameters_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DE59 RID: 122457 RVA: 0x008E64E0 File Offset: 0x008E46E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			SimpleHolographicComponent_C.__ReceiveTick_FunctionParams* ptr = stackalloc SimpleHolographicComponent_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(SimpleHolographicComponent_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SimpleHolographicComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SimpleHolographicComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DE5A RID: 122458 RVA: 0x008E6528 File Offset: 0x008E4728
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			SimpleHolographicComponent_C.__ReceiveTick_FunctionParams* ptr = stackalloc SimpleHolographicComponent_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(SimpleHolographicComponent_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SimpleHolographicComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, SimpleHolographicComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601DE5B RID: 122459 RVA: 0x008E6570 File Offset: 0x008E4770
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_SimpleHolographicComponent(int EntryPoint)
		{
			SimpleHolographicComponent_C.__ExecuteUbergraph_SimpleHolographicComponent_FunctionParams* ptr = stackalloc SimpleHolographicComponent_C.__ExecuteUbergraph_SimpleHolographicComponent_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(SimpleHolographicComponent_C.__ExecuteUbergraph_SimpleHolographicComponent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SimpleHolographicComponent_C.__ExecuteUbergraph_SimpleHolographicComponent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, SimpleHolographicComponent_C.__ExecuteUbergraph_SimpleHolographicComponent_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601DE5C RID: 122460 RVA: 0x008E65B7 File Offset: 0x008E47B7
		protected SimpleHolographicComponent_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EA47 RID: 59975
		public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/SimpleHolographicComponent.SimpleHolographicComponent_C";

		// Token: 0x0400EA48 RID: 59976
		private static IntPtr _ClassPtr;

		// Token: 0x0400EA49 RID: 59977
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400EA4A RID: 59978
		internal static int __PropertyOffset_0;

		// Token: 0x0400EA4B RID: 59979
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400EA4C RID: 59980
		internal static int __PropertyOffset_1;

		// Token: 0x0400EA4D RID: 59981
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _OL_Materials;

		// Token: 0x0400EA4E RID: 59982
		internal static int __PropertyOffset_2;

		// Token: 0x0400EA4F RID: 59983
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _Other_Materials;

		// Token: 0x0400EA50 RID: 59984
		internal static int __PropertyOffset_3;

		// Token: 0x0400EA51 RID: 59985
		internal static int __PropertyOffset_4;

		// Token: 0x0400EA52 RID: 59986
		internal static int __PropertyOffset_5;

		// Token: 0x0400EA53 RID: 59987
		internal static int __PropertyOffset_6;

		// Token: 0x0400EA54 RID: 59988
		internal static int __PropertyOffset_7;

		// Token: 0x0400EA55 RID: 59989
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<USkeletalMeshComponent, SHolographicMaterialsCache> _ComponentMaterialsCache;

		// Token: 0x0400EA56 RID: 59990
		private static IntPtr __StartEffect_NativeFunctionPtr;

		// Token: 0x0400EA57 RID: 59991
		private static IntPtr __EndEffect_NativeFunctionPtr;

		// Token: 0x0400EA58 RID: 59992
		private static IntPtr __UpdateMaterialsWithDa_NativeFunctionPtr;

		// Token: 0x0400EA59 RID: 59993
		private static IntPtr __RemoveNpcEffect_NativeFunctionPtr;

		// Token: 0x0400EA5A RID: 59994
		private static IntPtr __Clear_NativeFunctionPtr;

		// Token: 0x0400EA5B RID: 59995
		private static IntPtr __RevertMaterialParamters_NativeFunctionPtr;

		// Token: 0x0400EA5C RID: 59996
		private static IntPtr __CacheAndReplace_NativeFunctionPtr;

		// Token: 0x0400EA5D RID: 59997
		private static IntPtr __CacheMaterialParameters_NativeFunctionPtr;

		// Token: 0x0400EA5E RID: 59998
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400EA5F RID: 59999
		private static IntPtr __ExecuteUbergraph_SimpleHolographicComponent_NativeFunctionPtr;

		// Token: 0x0200972C RID: 38700
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 3016)]
		protected ref struct __UpdateMaterialsWithDa_FunctionParams
		{
			// Token: 0x04031C8A RID: 203914
			[FieldOffset(0)]
			public byte Materials;

			// Token: 0x04031C8B RID: 203915
			[FieldOffset(16)]
			public byte SHolographicData;
		}

		// Token: 0x0200972D RID: 38701
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 480)]
		protected ref struct __RevertMaterialParamters_FunctionParams
		{
			// Token: 0x04031C8C RID: 203916
			[FieldOffset(0)]
			public byte MaterialCache;

			// Token: 0x04031C8D RID: 203917
			[FieldOffset(176)]
			public IntPtr result;
		}

		// Token: 0x0200972E RID: 38702
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 504)]
		protected ref struct __CacheAndReplace_FunctionParams
		{
			// Token: 0x04031C8E RID: 203918
			[FieldOffset(0)]
			public byte SHolographicData;

			// Token: 0x04031C8F RID: 203919
			[FieldOffset(96)]
			public IntPtr self2;

			// Token: 0x04031C90 RID: 203920
			[FieldOffset(104)]
			public int ElementIndex;

			// Token: 0x04031C91 RID: 203921
			[FieldOffset(112)]
			public IntPtr material;

			// Token: 0x04031C92 RID: 203922
			[FieldOffset(120)]
			public IntPtr __Result;

			// Token: 0x04031C93 RID: 203923
			[FieldOffset(128)]
			public byte CacheResult;
		}

		// Token: 0x0200972F RID: 38703
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2728)]
		protected ref struct __CacheMaterialParameters_FunctionParams
		{
			// Token: 0x04031C94 RID: 203924
			[FieldOffset(0)]
			public byte floats;

			// Token: 0x04031C95 RID: 203925
			[FieldOffset(16)]
			public byte colors;

			// Token: 0x04031C96 RID: 203926
			[FieldOffset(32)]
			public IntPtr material;

			// Token: 0x04031C97 RID: 203927
			[FieldOffset(40)]
			public bool bReplaceMaterial;

			// Token: 0x04031C98 RID: 203928
			[FieldOffset(44)]
			public int index;

			// Token: 0x04031C99 RID: 203929
			[FieldOffset(48)]
			public byte result;
		}

		// Token: 0x02009730 RID: 38704
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031C9A RID: 203930
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009731 RID: 38705
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __ExecuteUbergraph_SimpleHolographicComponent_FunctionParams
		{
			// Token: 0x04031C9B RID: 203931
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
