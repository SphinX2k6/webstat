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
	// Token: 0x020039BB RID: 14779
	[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/BP_NPCMaterialController.BP_NPCMaterialController_C")]
	[UnrealStructLayout(368, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 361)]
	public class BP_NPCMaterialController_C : UActorComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601DDB8 RID: 122296 RVA: 0x008E4988 File Offset: 0x008E2B88
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NPCMaterialController_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/BP_NPCMaterialController.BP_NPCMaterialController_C");
			}
			return BP_NPCMaterialController_C._ClassPtr;
		}

		// Token: 0x0601DDB9 RID: 122297 RVA: 0x008E49AC File Offset: 0x008E2BAC
		public BP_NPCMaterialController_C() : this(BuiltinUtils.AllocNativeUObject(BP_NPCMaterialController_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601DDBA RID: 122298 RVA: 0x008E49D4 File Offset: 0x008E2BD4
		[NullableContext(1)]
		public BP_NPCMaterialController_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NPCMaterialController_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002785 RID: 10117
		// (get) Token: 0x0601DDBB RID: 122299 RVA: 0x008E4A08 File Offset: 0x008E2C08
		// (set) Token: 0x0601DDBC RID: 122300 RVA: 0x008E4A41 File Offset: 0x008E2C41
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_NPCMaterialController_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_NPCMaterialController_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002786 RID: 10118
		// (get) Token: 0x0601DDBD RID: 122301 RVA: 0x008E4A64 File Offset: 0x008E2C64
		// (set) Token: 0x0601DDBE RID: 122302 RVA: 0x008E4A9D File Offset: 0x008E2C9D
		[Nullable(1)]
		public TArray<UMaterialInstanceDynamic> OL_Materials
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._OL_Materials) == null)
				{
					result = (this._OL_Materials = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_NPCMaterialController_C.__PropertyOffset_1, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.OL_Materials.CopyAssign(value);
			}
		}

		// Token: 0x17002787 RID: 10119
		// (get) Token: 0x0601DDBF RID: 122303 RVA: 0x008E4AAC File Offset: 0x008E2CAC
		// (set) Token: 0x0601DDC0 RID: 122304 RVA: 0x008E4AE5 File Offset: 0x008E2CE5
		[Nullable(1)]
		public TArray<UMaterialInstanceDynamic> Other_Materials
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._Other_Materials) == null)
				{
					result = (this._Other_Materials = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_NPCMaterialController_C.__PropertyOffset_2, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Other_Materials.CopyAssign(value);
			}
		}

		// Token: 0x17002788 RID: 10120
		// (get) Token: 0x0601DDC1 RID: 122305 RVA: 0x008E4AF3 File Offset: 0x008E2CF3
		// (set) Token: 0x0601DDC2 RID: 122306 RVA: 0x008E4B07 File Offset: 0x008E2D07
		[Nullable(2)]
		public unsafe PD_HolographicEffect_C DATA
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_HolographicEffect_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NPCMaterialController_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NPCMaterialController_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002789 RID: 10121
		// (get) Token: 0x0601DDC3 RID: 122307 RVA: 0x008E4B1C File Offset: 0x008E2D1C
		// (set) Token: 0x0601DDC4 RID: 122308 RVA: 0x008E4B2C File Offset: 0x008E2D2C
		public unsafe float TimeCounter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NPCMaterialController_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NPCMaterialController_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700278A RID: 10122
		// (get) Token: 0x0601DDC5 RID: 122309 RVA: 0x008E4B3D File Offset: 0x008E2D3D
		// (set) Token: 0x0601DDC6 RID: 122310 RVA: 0x008E4B51 File Offset: 0x008E2D51
		public unsafe TEnumAsByte<EHolographicState> State
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NPCMaterialController_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NPCMaterialController_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700278B RID: 10123
		// (get) Token: 0x0601DDC7 RID: 122311 RVA: 0x008E4B66 File Offset: 0x008E2D66
		// (set) Token: 0x0601DDC8 RID: 122312 RVA: 0x008E4B76 File Offset: 0x008E2D76
		public unsafe bool bCached
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NPCMaterialController_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NPCMaterialController_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700278C RID: 10124
		// (get) Token: 0x0601DDC9 RID: 122313 RVA: 0x008E4B88 File Offset: 0x008E2D88
		// (set) Token: 0x0601DDCA RID: 122314 RVA: 0x008E4BC1 File Offset: 0x008E2DC1
		[Nullable(1)]
		public TMap<USkeletalMeshComponent, SHolographicMaterialsCache> ComponentMaterialsCache
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<USkeletalMeshComponent, SHolographicMaterialsCache> result;
				if ((result = this._ComponentMaterialsCache) == null)
				{
					result = (this._ComponentMaterialsCache = new TMap<USkeletalMeshComponent, SHolographicMaterialsCache>(base.NativePtr + (IntPtr)BP_NPCMaterialController_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.ComponentMaterialsCache.CopyAssign(value);
			}
		}

		// Token: 0x1700278D RID: 10125
		// (get) Token: 0x0601DDCB RID: 122315 RVA: 0x008E4BCF File Offset: 0x008E2DCF
		// (set) Token: 0x0601DDCC RID: 122316 RVA: 0x008E4BDF File Offset: 0x008E2DDF
		public unsafe bool EnableBattle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NPCMaterialController_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NPCMaterialController_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700278E RID: 10126
		// (get) Token: 0x0601DDCD RID: 122317 RVA: 0x008E4BF0 File Offset: 0x008E2DF0
		// (set) Token: 0x0601DDCE RID: 122318 RVA: 0x008E4C00 File Offset: 0x008E2E00
		public unsafe bool EnableMask
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NPCMaterialController_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NPCMaterialController_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700278F RID: 10127
		// (get) Token: 0x0601DDCF RID: 122319 RVA: 0x008E4C11 File Offset: 0x008E2E11
		// (set) Token: 0x0601DDD0 RID: 122320 RVA: 0x008E4C25 File Offset: 0x008E2E25
		[Nullable(2)]
		public unsafe UKuroMaterialControllerComponent MaterialController
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroMaterialControllerComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NPCMaterialController_C.__PropertyOffset_10);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NPCMaterialController_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17002790 RID: 10128
		// (get) Token: 0x0601DDD1 RID: 122321 RVA: 0x008E4C3A File Offset: 0x008E2E3A
		// (set) Token: 0x0601DDD2 RID: 122322 RVA: 0x008E4C4A File Offset: 0x008E2E4A
		public unsafe bool IsOnMobile
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NPCMaterialController_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NPCMaterialController_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601DDD3 RID: 122323 RVA: 0x008E4C5C File Offset: 0x008E2E5C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ApplyMaterialAndTexture(in SHolographicData SHolographicData, EKuroCharSlotSpecifiedType SlotType)
		{
			BP_NPCMaterialController_C.__ApplyMaterialAndTexture_FunctionParams* ptr = stackalloc BP_NPCMaterialController_C.__ApplyMaterialAndTexture_FunctionParams[(UIntPtr)135] + 15L / (long)sizeof(BP_NPCMaterialController_C.__ApplyMaterialAndTexture_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NPCMaterialController_C.__ApplyMaterialAndTexture_NativeFunctionPtr, (void*)ptr, 1);
			if (SHolographicData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SHolographicData.StaticStruct(), &ptr->SHolographicData, SHolographicData.NativePtr, 1, false);
			}
			ptr->SlotType = SlotType;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NPCMaterialController_C.__ApplyMaterialAndTexture_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_NPCMaterialController_C.__ApplyMaterialAndTexture_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DDD4 RID: 122324 RVA: 0x008E4CDC File Offset: 0x008E2EDC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ApplyMaterialsWithDa(in SHolographicData SHolographicData, EKuroCharSlotSpecifiedType SlotType)
		{
			BP_NPCMaterialController_C.__ApplyMaterialsWithDa_FunctionParams* ptr = stackalloc BP_NPCMaterialController_C.__ApplyMaterialsWithDa_FunctionParams[(UIntPtr)2967] + 15L / (long)sizeof(BP_NPCMaterialController_C.__ApplyMaterialsWithDa_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NPCMaterialController_C.__ApplyMaterialsWithDa_NativeFunctionPtr, (void*)ptr, 1);
			if (SHolographicData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SHolographicData.StaticStruct(), &ptr->SHolographicData, SHolographicData.NativePtr, 1, false);
			}
			ptr->SlotType = SlotType;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NPCMaterialController_C.__ApplyMaterialsWithDa_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_NPCMaterialController_C.__ApplyMaterialsWithDa_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DDD5 RID: 122325 RVA: 0x008E4D5C File Offset: 0x008E2F5C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void MaterialPretreatment([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<UMaterialInstanceDynamic> Materials, in SHolographicData SHolographicData)
		{
			BP_NPCMaterialController_C.__MaterialPretreatment_FunctionParams* ptr = stackalloc BP_NPCMaterialController_C.__MaterialPretreatment_FunctionParams[(UIntPtr)855] + 15L / (long)sizeof(BP_NPCMaterialController_C.__MaterialPretreatment_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NPCMaterialController_C.__MaterialPretreatment_NativeFunctionPtr, (void*)ptr, 1);
			TArray<UMaterialInstanceDynamic> tarray = Materials;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->Materials);
			}
			if (SHolographicData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SHolographicData.StaticStruct(), &ptr->SHolographicData, SHolographicData.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NPCMaterialController_C.__MaterialPretreatment_NativeFunctionPtr, (void*)ptr);
			TArray<UMaterialInstanceDynamic> tarray2 = Materials;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->Materials);
			}
			UnrealReflectionUtils.DestroyStruct(BP_NPCMaterialController_C.__MaterialPretreatment_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DDD6 RID: 122326 RVA: 0x008E4DFB File Offset: 0x008E2FFB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EndEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NPCMaterialController_C.__EndEffect_NativeFunctionPtr, null);
		}

		// Token: 0x0601DDD7 RID: 122327 RVA: 0x008E4E0F File Offset: 0x008E300F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NPCMaterialController_C.__StartEffect_NativeFunctionPtr, null);
		}

		// Token: 0x0601DDD8 RID: 122328 RVA: 0x008E4E24 File Offset: 0x008E3024
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateMaterialsWithDa([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<UMaterialInstanceDynamic> Materials, in SHolographicData SHolographicData)
		{
			BP_NPCMaterialController_C.__UpdateMaterialsWithDa_FunctionParams* ptr = stackalloc BP_NPCMaterialController_C.__UpdateMaterialsWithDa_FunctionParams[(UIntPtr)3007] + 15L / (long)sizeof(BP_NPCMaterialController_C.__UpdateMaterialsWithDa_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NPCMaterialController_C.__UpdateMaterialsWithDa_NativeFunctionPtr, (void*)ptr, 1);
			TArray<UMaterialInstanceDynamic> tarray = Materials;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->Materials);
			}
			if (SHolographicData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SHolographicData.StaticStruct(), &ptr->SHolographicData, SHolographicData.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NPCMaterialController_C.__UpdateMaterialsWithDa_NativeFunctionPtr, (void*)ptr);
			TArray<UMaterialInstanceDynamic> tarray2 = Materials;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->Materials);
			}
			UnrealReflectionUtils.DestroyStruct(BP_NPCMaterialController_C.__UpdateMaterialsWithDa_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DDD9 RID: 122329 RVA: 0x008E4EC3 File Offset: 0x008E30C3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RemoveNpcEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NPCMaterialController_C.__RemoveNpcEffect_NativeFunctionPtr, null);
		}

		// Token: 0x0601DDDA RID: 122330 RVA: 0x008E4ED7 File Offset: 0x008E30D7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Clear()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NPCMaterialController_C.__Clear_NativeFunctionPtr, null);
		}

		// Token: 0x0601DDDB RID: 122331 RVA: 0x008E4EEC File Offset: 0x008E30EC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void RevertMaterialParamters(SMaterialParamCache MaterialCache, ref UMaterialInstanceDynamic result)
		{
			BP_NPCMaterialController_C.__RevertMaterialParamters_FunctionParams* ptr = stackalloc BP_NPCMaterialController_C.__RevertMaterialParamters_FunctionParams[(UIntPtr)495] + 15L / (long)sizeof(BP_NPCMaterialController_C.__RevertMaterialParamters_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NPCMaterialController_C.__RevertMaterialParamters_NativeFunctionPtr, (void*)ptr, 1);
			if (MaterialCache != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialParamCache.StaticStruct(), &ptr->MaterialCache, MaterialCache.NativePtr, 1, false);
			}
			ref BP_NPCMaterialController_C.__RevertMaterialParamters_FunctionParams ptr2 = ref *ptr;
			UMaterialInstanceDynamic umaterialInstanceDynamic = result;
			ptr2.result = ((umaterialInstanceDynamic != null) ? umaterialInstanceDynamic.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NPCMaterialController_C.__RevertMaterialParamters_NativeFunctionPtr, (void*)ptr);
			result = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMaterialInstanceDynamic>(ptr->result);
			UnrealReflectionUtils.DestroyStruct(BP_NPCMaterialController_C.__RevertMaterialParamters_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DDDC RID: 122332 RVA: 0x008E4F88 File Offset: 0x008E3188
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual UMaterialInstanceDynamic CacheAndReplace(in SHolographicData SHolographicData, UPrimitiveComponent self2, int ElementIndex, UMaterialInstanceDynamic material, ref SMaterialParamCache CacheResult)
		{
			BP_NPCMaterialController_C.__CacheAndReplace_FunctionParams* ptr = stackalloc BP_NPCMaterialController_C.__CacheAndReplace_FunctionParams[(UIntPtr)519] + 15L / (long)sizeof(BP_NPCMaterialController_C.__CacheAndReplace_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NPCMaterialController_C.__CacheAndReplace_NativeFunctionPtr, (void*)ptr, 1);
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
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NPCMaterialController_C.__CacheAndReplace_NativeFunctionPtr, (void*)ptr);
			if (CacheResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialParamCache.StaticStruct(), CacheResult.NativePtr, &ptr->CacheResult, 1, false);
			}
			UMaterialInstanceDynamic orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMaterialInstanceDynamic>(ptr->__Result);
			UnrealReflectionUtils.DestroyStruct(BP_NPCMaterialController_C.__CacheAndReplace_NativeFunctionPtr, (void*)ptr, 1);
			return orCreateUObjectByNativePointer;
		}

		// Token: 0x0601DDDD RID: 122333 RVA: 0x008E508C File Offset: 0x008E328C
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
			BP_NPCMaterialController_C.__CacheMaterialParameters_FunctionParams* ptr = stackalloc BP_NPCMaterialController_C.__CacheMaterialParameters_FunctionParams[(UIntPtr)2743] + 15L / (long)sizeof(BP_NPCMaterialController_C.__CacheMaterialParameters_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NPCMaterialController_C.__CacheMaterialParameters_NativeFunctionPtr, (void*)ptr, 1);
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
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NPCMaterialController_C.__CacheMaterialParameters_NativeFunctionPtr, (void*)ptr);
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
			UnrealReflectionUtils.DestroyStruct(BP_NPCMaterialController_C.__CacheMaterialParameters_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DDDE RID: 122334 RVA: 0x008E51A4 File Offset: 0x008E33A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_NPCMaterialController_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_NPCMaterialController_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_NPCMaterialController_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NPCMaterialController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NPCMaterialController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DDDF RID: 122335 RVA: 0x008E51EC File Offset: 0x008E33EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_NPCMaterialController_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_NPCMaterialController_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_NPCMaterialController_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NPCMaterialController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NPCMaterialController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601DDE0 RID: 122336 RVA: 0x008E5233 File Offset: 0x008E3433
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomTickOnce()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NPCMaterialController_C.__CustomTickOnce_NativeFunctionPtr, null);
		}

		// Token: 0x0601DDE1 RID: 122337 RVA: 0x008E5248 File Offset: 0x008E3448
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_NPCMaterialController(int EntryPoint)
		{
			BP_NPCMaterialController_C.__ExecuteUbergraph_BP_NPCMaterialController_FunctionParams* ptr = stackalloc BP_NPCMaterialController_C.__ExecuteUbergraph_BP_NPCMaterialController_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_NPCMaterialController_C.__ExecuteUbergraph_BP_NPCMaterialController_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NPCMaterialController_C.__ExecuteUbergraph_BP_NPCMaterialController_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NPCMaterialController_C.__ExecuteUbergraph_BP_NPCMaterialController_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601DDE2 RID: 122338 RVA: 0x008E528F File Offset: 0x008E348F
		protected BP_NPCMaterialController_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400E9E7 RID: 59879
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/BP_NPCMaterialController.BP_NPCMaterialController_C";

		// Token: 0x0400E9E8 RID: 59880
		private static IntPtr _ClassPtr;

		// Token: 0x0400E9E9 RID: 59881
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400E9EA RID: 59882
		internal static int __PropertyOffset_0;

		// Token: 0x0400E9EB RID: 59883
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400E9EC RID: 59884
		internal static int __PropertyOffset_1;

		// Token: 0x0400E9ED RID: 59885
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _OL_Materials;

		// Token: 0x0400E9EE RID: 59886
		internal static int __PropertyOffset_2;

		// Token: 0x0400E9EF RID: 59887
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _Other_Materials;

		// Token: 0x0400E9F0 RID: 59888
		internal static int __PropertyOffset_3;

		// Token: 0x0400E9F1 RID: 59889
		internal static int __PropertyOffset_4;

		// Token: 0x0400E9F2 RID: 59890
		internal static int __PropertyOffset_5;

		// Token: 0x0400E9F3 RID: 59891
		internal static int __PropertyOffset_6;

		// Token: 0x0400E9F4 RID: 59892
		internal static int __PropertyOffset_7;

		// Token: 0x0400E9F5 RID: 59893
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<USkeletalMeshComponent, SHolographicMaterialsCache> _ComponentMaterialsCache;

		// Token: 0x0400E9F6 RID: 59894
		internal static int __PropertyOffset_8;

		// Token: 0x0400E9F7 RID: 59895
		internal static int __PropertyOffset_9;

		// Token: 0x0400E9F8 RID: 59896
		internal static int __PropertyOffset_10;

		// Token: 0x0400E9F9 RID: 59897
		internal static int __PropertyOffset_11;

		// Token: 0x0400E9FA RID: 59898
		private static IntPtr __ApplyMaterialAndTexture_NativeFunctionPtr;

		// Token: 0x0400E9FB RID: 59899
		private static IntPtr __ApplyMaterialsWithDa_NativeFunctionPtr;

		// Token: 0x0400E9FC RID: 59900
		private static IntPtr __MaterialPretreatment_NativeFunctionPtr;

		// Token: 0x0400E9FD RID: 59901
		private static IntPtr __EndEffect_NativeFunctionPtr;

		// Token: 0x0400E9FE RID: 59902
		private static IntPtr __StartEffect_NativeFunctionPtr;

		// Token: 0x0400E9FF RID: 59903
		private static IntPtr __UpdateMaterialsWithDa_NativeFunctionPtr;

		// Token: 0x0400EA00 RID: 59904
		private static IntPtr __RemoveNpcEffect_NativeFunctionPtr;

		// Token: 0x0400EA01 RID: 59905
		private static IntPtr __Clear_NativeFunctionPtr;

		// Token: 0x0400EA02 RID: 59906
		private static IntPtr __RevertMaterialParamters_NativeFunctionPtr;

		// Token: 0x0400EA03 RID: 59907
		private static IntPtr __CacheAndReplace_NativeFunctionPtr;

		// Token: 0x0400EA04 RID: 59908
		private static IntPtr __CacheMaterialParameters_NativeFunctionPtr;

		// Token: 0x0400EA05 RID: 59909
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400EA06 RID: 59910
		private static IntPtr __CustomTickOnce_NativeFunctionPtr;

		// Token: 0x0400EA07 RID: 59911
		private static IntPtr __ExecuteUbergraph_BP_NPCMaterialController_NativeFunctionPtr;

		// Token: 0x0200971D RID: 38685
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 120)]
		protected ref struct __ApplyMaterialAndTexture_FunctionParams
		{
			// Token: 0x04031C60 RID: 203872
			[FieldOffset(0)]
			public byte SHolographicData;

			// Token: 0x04031C61 RID: 203873
			[FieldOffset(96)]
			public EKuroCharSlotSpecifiedType SlotType;
		}

		// Token: 0x0200971E RID: 38686
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2952)]
		protected ref struct __ApplyMaterialsWithDa_FunctionParams
		{
			// Token: 0x04031C62 RID: 203874
			[FieldOffset(0)]
			public byte SHolographicData;

			// Token: 0x04031C63 RID: 203875
			[FieldOffset(96)]
			public EKuroCharSlotSpecifiedType SlotType;
		}

		// Token: 0x0200971F RID: 38687
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 840)]
		protected ref struct __MaterialPretreatment_FunctionParams
		{
			// Token: 0x04031C64 RID: 203876
			[FieldOffset(0)]
			public byte Materials;

			// Token: 0x04031C65 RID: 203877
			[FieldOffset(16)]
			public byte SHolographicData;
		}

		// Token: 0x02009720 RID: 38688
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2992)]
		protected ref struct __UpdateMaterialsWithDa_FunctionParams
		{
			// Token: 0x04031C66 RID: 203878
			[FieldOffset(0)]
			public byte Materials;

			// Token: 0x04031C67 RID: 203879
			[FieldOffset(16)]
			public byte SHolographicData;
		}

		// Token: 0x02009721 RID: 38689
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 480)]
		protected ref struct __RevertMaterialParamters_FunctionParams
		{
			// Token: 0x04031C68 RID: 203880
			[FieldOffset(0)]
			public byte MaterialCache;

			// Token: 0x04031C69 RID: 203881
			[FieldOffset(176)]
			public IntPtr result;
		}

		// Token: 0x02009722 RID: 38690
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 504)]
		protected ref struct __CacheAndReplace_FunctionParams
		{
			// Token: 0x04031C6A RID: 203882
			[FieldOffset(0)]
			public byte SHolographicData;

			// Token: 0x04031C6B RID: 203883
			[FieldOffset(96)]
			public IntPtr self2;

			// Token: 0x04031C6C RID: 203884
			[FieldOffset(104)]
			public int ElementIndex;

			// Token: 0x04031C6D RID: 203885
			[FieldOffset(112)]
			public IntPtr material;

			// Token: 0x04031C6E RID: 203886
			[FieldOffset(120)]
			public IntPtr __Result;

			// Token: 0x04031C6F RID: 203887
			[FieldOffset(128)]
			public byte CacheResult;
		}

		// Token: 0x02009723 RID: 38691
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2728)]
		protected ref struct __CacheMaterialParameters_FunctionParams
		{
			// Token: 0x04031C70 RID: 203888
			[FieldOffset(0)]
			public byte floats;

			// Token: 0x04031C71 RID: 203889
			[FieldOffset(16)]
			public byte colors;

			// Token: 0x04031C72 RID: 203890
			[FieldOffset(32)]
			public IntPtr material;

			// Token: 0x04031C73 RID: 203891
			[FieldOffset(40)]
			public bool bReplaceMaterial;

			// Token: 0x04031C74 RID: 203892
			[FieldOffset(44)]
			public int index;

			// Token: 0x04031C75 RID: 203893
			[FieldOffset(48)]
			public byte result;
		}

		// Token: 0x02009724 RID: 38692
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031C76 RID: 203894
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009725 RID: 38693
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_BP_NPCMaterialController_FunctionParams
		{
			// Token: 0x04031C77 RID: 203895
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
