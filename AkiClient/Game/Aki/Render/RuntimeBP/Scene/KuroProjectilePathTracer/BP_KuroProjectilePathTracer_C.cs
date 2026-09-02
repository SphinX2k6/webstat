using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.KuroProjectilePathTracer
{
	// Token: 0x02003AB5 RID: 15029
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/KuroProjectilePathTracer/BP_KuroProjectilePathTracer.BP_KuroProjectilePathTracer_C")]
	[UnrealStructLayout(1208, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1208)]
	public class BP_KuroProjectilePathTracer_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060200E2 RID: 131298 RVA: 0x00920FB4 File Offset: 0x0091F1B4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroProjectilePathTracer_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/KuroProjectilePathTracer/BP_KuroProjectilePathTracer.BP_KuroProjectilePathTracer_C");
			}
			return BP_KuroProjectilePathTracer_C._ClassPtr;
		}

		// Token: 0x060200E3 RID: 131299 RVA: 0x00920FD8 File Offset: 0x0091F1D8
		public BP_KuroProjectilePathTracer_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroProjectilePathTracer_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060200E4 RID: 131300 RVA: 0x00921000 File Offset: 0x0091F200
		[NullableContext(1)]
		public BP_KuroProjectilePathTracer_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroProjectilePathTracer_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170033B0 RID: 13232
		// (get) Token: 0x060200E5 RID: 131301 RVA: 0x00921034 File Offset: 0x0091F234
		// (set) Token: 0x060200E6 RID: 131302 RVA: 0x0092106D File Offset: 0x0091F26D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170033B1 RID: 13233
		// (get) Token: 0x060200E7 RID: 131303 RVA: 0x0092108E File Offset: 0x0091F28E
		// (set) Token: 0x060200E8 RID: 131304 RVA: 0x009210A2 File Offset: 0x0091F2A2
		public unsafe UDecalComponent Decal
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDecalComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroProjectilePathTracer_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroProjectilePathTracer_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170033B2 RID: 13234
		// (get) Token: 0x060200E9 RID: 131305 RVA: 0x009210B7 File Offset: 0x0091F2B7
		// (set) Token: 0x060200EA RID: 131306 RVA: 0x009210CB File Offset: 0x0091F2CB
		public unsafe UHierarchicalInstancedStaticMeshComponent HierarchicalInstancedStaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UHierarchicalInstancedStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroProjectilePathTracer_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroProjectilePathTracer_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170033B3 RID: 13235
		// (get) Token: 0x060200EB RID: 131307 RVA: 0x009210E0 File Offset: 0x0091F2E0
		// (set) Token: 0x060200EC RID: 131308 RVA: 0x009210F4 File Offset: 0x0091F2F4
		public unsafe USplineComponent Spline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroProjectilePathTracer_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroProjectilePathTracer_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170033B4 RID: 13236
		// (get) Token: 0x060200ED RID: 131309 RVA: 0x00921109 File Offset: 0x0091F309
		// (set) Token: 0x060200EE RID: 131310 RVA: 0x0092111D File Offset: 0x0091F31D
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroProjectilePathTracer_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroProjectilePathTracer_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170033B5 RID: 13237
		// (get) Token: 0x060200EF RID: 131311 RVA: 0x00921132 File Offset: 0x0091F332
		// (set) Token: 0x060200F0 RID: 131312 RVA: 0x00921142 File Offset: 0x0091F342
		public unsafe bool Visible
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x170033B6 RID: 13238
		// (get) Token: 0x060200F1 RID: 131313 RVA: 0x00921153 File Offset: 0x0091F353
		// (set) Token: 0x060200F2 RID: 131314 RVA: 0x00921167 File Offset: 0x0091F367
		public unsafe UStaticMesh DistanceRecordMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroProjectilePathTracer_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroProjectilePathTracer_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170033B7 RID: 13239
		// (get) Token: 0x060200F3 RID: 131315 RVA: 0x0092117C File Offset: 0x0091F37C
		// (set) Token: 0x060200F4 RID: 131316 RVA: 0x0092118C File Offset: 0x0091F38C
		public unsafe float DisplayDistancePerRecord
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170033B8 RID: 13240
		// (get) Token: 0x060200F5 RID: 131317 RVA: 0x0092119D File Offset: 0x0091F39D
		// (set) Token: 0x060200F6 RID: 131318 RVA: 0x009211AD File Offset: 0x0091F3AD
		public unsafe int MaxPlaceCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170033B9 RID: 13241
		// (get) Token: 0x060200F7 RID: 131319 RVA: 0x009211BE File Offset: 0x0091F3BE
		// (set) Token: 0x060200F8 RID: 131320 RVA: 0x009211CE File Offset: 0x0091F3CE
		public unsafe float RecordDeltaAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170033BA RID: 13242
		// (get) Token: 0x060200F9 RID: 131321 RVA: 0x009211DF File Offset: 0x0091F3DF
		// (set) Token: 0x060200FA RID: 131322 RVA: 0x009211EF File Offset: 0x0091F3EF
		public unsafe float AnimationDelta
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170033BB RID: 13243
		// (get) Token: 0x060200FB RID: 131323 RVA: 0x00921200 File Offset: 0x0091F400
		// (set) Token: 0x060200FC RID: 131324 RVA: 0x00921210 File Offset: 0x0091F410
		public unsafe float AnimationSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170033BC RID: 13244
		// (get) Token: 0x060200FD RID: 131325 RVA: 0x00921224 File Offset: 0x0091F424
		// (set) Token: 0x060200FE RID: 131326 RVA: 0x0092125D File Offset: 0x0091F45D
		[Nullable(1)]
		public TArray<FVector> CachedPathPositions
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._CachedPathPositions) == null)
				{
					result = (this._CachedPathPositions = new TArray<FVector>(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_12, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CachedPathPositions.CopyAssign(value);
			}
		}

		// Token: 0x170033BD RID: 13245
		// (get) Token: 0x060200FF RID: 131327 RVA: 0x0092126B File Offset: 0x0091F46B
		// (set) Token: 0x06020100 RID: 131328 RVA: 0x0092127F File Offset: 0x0091F47F
		public unsafe FVector CachedLastTraceDestination
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170033BE RID: 13246
		// (get) Token: 0x06020101 RID: 131329 RVA: 0x00921294 File Offset: 0x0091F494
		// (set) Token: 0x06020102 RID: 131330 RVA: 0x009212A4 File Offset: 0x0091F4A4
		public unsafe bool CachedReturnValue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x170033BF RID: 13247
		// (get) Token: 0x06020103 RID: 131331 RVA: 0x009212B5 File Offset: 0x0091F4B5
		// (set) Token: 0x06020104 RID: 131332 RVA: 0x009212C9 File Offset: 0x0091F4C9
		public unsafe FVector CachedImpactPoint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170033C0 RID: 13248
		// (get) Token: 0x06020105 RID: 131333 RVA: 0x009212DE File Offset: 0x0091F4DE
		// (set) Token: 0x06020106 RID: 131334 RVA: 0x009212F2 File Offset: 0x0091F4F2
		public unsafe FVector CachedImpactNormal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170033C1 RID: 13249
		// (get) Token: 0x06020107 RID: 131335 RVA: 0x00921307 File Offset: 0x0091F507
		// (set) Token: 0x06020108 RID: 131336 RVA: 0x00921317 File Offset: 0x0091F517
		public unsafe bool CachedEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x170033C2 RID: 13250
		// (get) Token: 0x06020109 RID: 131337 RVA: 0x00921328 File Offset: 0x0091F528
		// (set) Token: 0x0602010A RID: 131338 RVA: 0x00921338 File Offset: 0x0091F538
		public unsafe float TargetDeltaAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170033C3 RID: 13251
		// (get) Token: 0x0602010B RID: 131339 RVA: 0x00921349 File Offset: 0x0091F549
		// (set) Token: 0x0602010C RID: 131340 RVA: 0x00921359 File Offset: 0x0091F559
		public unsafe float TargetSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170033C4 RID: 13252
		// (get) Token: 0x0602010D RID: 131341 RVA: 0x0092136A File Offset: 0x0091F56A
		// (set) Token: 0x0602010E RID: 131342 RVA: 0x0092137A File Offset: 0x0091F57A
		public unsafe float TargetThreshold
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170033C5 RID: 13253
		// (get) Token: 0x0602010F RID: 131343 RVA: 0x0092138B File Offset: 0x0091F58B
		// (set) Token: 0x06020110 RID: 131344 RVA: 0x0092139F File Offset: 0x0091F59F
		public unsafe PD_KuroProjectileAsset_C KuroProjectileAsset
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_KuroProjectileAsset_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroProjectilePathTracer_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroProjectilePathTracer_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x170033C6 RID: 13254
		// (get) Token: 0x06020111 RID: 131345 RVA: 0x009213B4 File Offset: 0x0091F5B4
		// (set) Token: 0x06020112 RID: 131346 RVA: 0x009213C4 File Offset: 0x0091F5C4
		public unsafe float RecordSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x170033C7 RID: 13255
		// (get) Token: 0x06020113 RID: 131347 RVA: 0x009213D5 File Offset: 0x0091F5D5
		// (set) Token: 0x06020114 RID: 131348 RVA: 0x009213E5 File Offset: 0x0091F5E5
		public unsafe bool UseTargetDecal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroProjectilePathTracer_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x170033C8 RID: 13256
		// (get) Token: 0x06020115 RID: 131349 RVA: 0x009213F6 File Offset: 0x0091F5F6
		// (set) Token: 0x06020116 RID: 131350 RVA: 0x0092140A File Offset: 0x0091F60A
		public unsafe UMaterialInstance TargetDecalMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroProjectilePathTracer_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroProjectilePathTracer_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x06020117 RID: 131351 RVA: 0x0092141F File Offset: 0x0091F61F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateDataAsset()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroProjectilePathTracer_C.__UpdateDataAsset_NativeFunctionPtr, null);
		}

		// Token: 0x06020118 RID: 131352 RVA: 0x00921434 File Offset: 0x0091F634
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetPredictProjectileInfo(bool ReturnValue, ref TArray<FVector> OutPathPosition, FVector OutLastTraceDestination, FHitResult OutHit)
		{
			BP_KuroProjectilePathTracer_C.__SetPredictProjectileInfo_FunctionParams* ptr = stackalloc BP_KuroProjectilePathTracer_C.__SetPredictProjectileInfo_FunctionParams[(UIntPtr)343] + 15L / (long)sizeof(BP_KuroProjectilePathTracer_C.__SetPredictProjectileInfo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroProjectilePathTracer_C.__SetPredictProjectileInfo_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ReturnValue = ReturnValue;
			TArray<FVector> tarray = OutPathPosition;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->OutPathPosition);
			}
			ptr->OutLastTraceDestination = OutLastTraceDestination;
			if (OutHit != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->OutHit, OutHit.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroProjectilePathTracer_C.__SetPredictProjectileInfo_NativeFunctionPtr, (void*)ptr);
			TArray<FVector> tarray2 = OutPathPosition;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->OutPathPosition);
			}
			UnrealReflectionUtils.DestroyStruct(BP_KuroProjectilePathTracer_C.__SetPredictProjectileInfo_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06020119 RID: 131353 RVA: 0x009214E1 File Offset: 0x0091F6E1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateDisplay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroProjectilePathTracer_C.__UpdateDisplay_NativeFunctionPtr, null);
		}

		// Token: 0x0602011A RID: 131354 RVA: 0x009214F5 File Offset: 0x0091F6F5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClearCache()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroProjectilePathTracer_C.__ClearCache_NativeFunctionPtr, null);
		}

		// Token: 0x0602011B RID: 131355 RVA: 0x0092150C File Offset: 0x0091F70C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetVisible(bool IsVisible)
		{
			BP_KuroProjectilePathTracer_C.__SetVisible_FunctionParams* ptr = stackalloc BP_KuroProjectilePathTracer_C.__SetVisible_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroProjectilePathTracer_C.__SetVisible_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroProjectilePathTracer_C.__SetVisible_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsVisible = IsVisible;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroProjectilePathTracer_C.__SetVisible_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602011C RID: 131356 RVA: 0x00921554 File Offset: 0x0091F754
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KuroProjectilePathTracer_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroProjectilePathTracer_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroProjectilePathTracer_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroProjectilePathTracer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroProjectilePathTracer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602011D RID: 131357 RVA: 0x0092159C File Offset: 0x0091F79C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KuroProjectilePathTracer_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroProjectilePathTracer_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroProjectilePathTracer_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroProjectilePathTracer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroProjectilePathTracer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602011E RID: 131358 RVA: 0x009215E4 File Offset: 0x0091F7E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroProjectilePathTracer(int EntryPoint)
		{
			BP_KuroProjectilePathTracer_C.__ExecuteUbergraph_BP_KuroProjectilePathTracer_FunctionParams* ptr = stackalloc BP_KuroProjectilePathTracer_C.__ExecuteUbergraph_BP_KuroProjectilePathTracer_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_KuroProjectilePathTracer_C.__ExecuteUbergraph_BP_KuroProjectilePathTracer_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroProjectilePathTracer_C.__ExecuteUbergraph_BP_KuroProjectilePathTracer_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroProjectilePathTracer_C.__ExecuteUbergraph_BP_KuroProjectilePathTracer_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602011F RID: 131359 RVA: 0x0092162B File Offset: 0x0091F82B
		protected BP_KuroProjectilePathTracer_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FF79 RID: 65401
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/KuroProjectilePathTracer/BP_KuroProjectilePathTracer.BP_KuroProjectilePathTracer_C";

		// Token: 0x0400FF7A RID: 65402
		private static IntPtr _ClassPtr;

		// Token: 0x0400FF7B RID: 65403
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FF7C RID: 65404
		internal static int __PropertyOffset_0;

		// Token: 0x0400FF7D RID: 65405
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FF7E RID: 65406
		internal static int __PropertyOffset_1;

		// Token: 0x0400FF7F RID: 65407
		internal static int __PropertyOffset_2;

		// Token: 0x0400FF80 RID: 65408
		internal static int __PropertyOffset_3;

		// Token: 0x0400FF81 RID: 65409
		internal static int __PropertyOffset_4;

		// Token: 0x0400FF82 RID: 65410
		internal static int __PropertyOffset_5;

		// Token: 0x0400FF83 RID: 65411
		internal static int __PropertyOffset_6;

		// Token: 0x0400FF84 RID: 65412
		internal static int __PropertyOffset_7;

		// Token: 0x0400FF85 RID: 65413
		internal static int __PropertyOffset_8;

		// Token: 0x0400FF86 RID: 65414
		internal static int __PropertyOffset_9;

		// Token: 0x0400FF87 RID: 65415
		internal static int __PropertyOffset_10;

		// Token: 0x0400FF88 RID: 65416
		internal static int __PropertyOffset_11;

		// Token: 0x0400FF89 RID: 65417
		internal static int __PropertyOffset_12;

		// Token: 0x0400FF8A RID: 65418
		private TArray<FVector> _CachedPathPositions;

		// Token: 0x0400FF8B RID: 65419
		internal static int __PropertyOffset_13;

		// Token: 0x0400FF8C RID: 65420
		internal static int __PropertyOffset_14;

		// Token: 0x0400FF8D RID: 65421
		internal static int __PropertyOffset_15;

		// Token: 0x0400FF8E RID: 65422
		internal static int __PropertyOffset_16;

		// Token: 0x0400FF8F RID: 65423
		internal static int __PropertyOffset_17;

		// Token: 0x0400FF90 RID: 65424
		internal static int __PropertyOffset_18;

		// Token: 0x0400FF91 RID: 65425
		internal static int __PropertyOffset_19;

		// Token: 0x0400FF92 RID: 65426
		internal static int __PropertyOffset_20;

		// Token: 0x0400FF93 RID: 65427
		internal static int __PropertyOffset_21;

		// Token: 0x0400FF94 RID: 65428
		internal static int __PropertyOffset_22;

		// Token: 0x0400FF95 RID: 65429
		internal static int __PropertyOffset_23;

		// Token: 0x0400FF96 RID: 65430
		internal static int __PropertyOffset_24;

		// Token: 0x0400FF97 RID: 65431
		private static IntPtr __UpdateDataAsset_NativeFunctionPtr;

		// Token: 0x0400FF98 RID: 65432
		private static IntPtr __SetPredictProjectileInfo_NativeFunctionPtr;

		// Token: 0x0400FF99 RID: 65433
		private static IntPtr __UpdateDisplay_NativeFunctionPtr;

		// Token: 0x0400FF9A RID: 65434
		private static IntPtr __ClearCache_NativeFunctionPtr;

		// Token: 0x0400FF9B RID: 65435
		private static IntPtr __SetVisible_NativeFunctionPtr;

		// Token: 0x0400FF9C RID: 65436
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FF9D RID: 65437
		private static IntPtr __ExecuteUbergraph_BP_KuroProjectilePathTracer_NativeFunctionPtr;

		// Token: 0x02009952 RID: 39250
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 328)]
		protected ref struct __SetPredictProjectileInfo_FunctionParams
		{
			// Token: 0x04031FB8 RID: 204728
			[FieldOffset(0)]
			public bool ReturnValue;

			// Token: 0x04031FB9 RID: 204729
			[FieldOffset(8)]
			public byte OutPathPosition;

			// Token: 0x04031FBA RID: 204730
			[FieldOffset(24)]
			public FVector OutLastTraceDestination;

			// Token: 0x04031FBB RID: 204731
			[FieldOffset(36)]
			public byte OutHit;
		}

		// Token: 0x02009953 RID: 39251
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __SetVisible_FunctionParams
		{
			// Token: 0x04031FBC RID: 204732
			[FieldOffset(0)]
			public bool IsVisible;
		}

		// Token: 0x02009954 RID: 39252
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031FBD RID: 204733
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009955 RID: 39253
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_KuroProjectilePathTracer_FunctionParams
		{
			// Token: 0x04031FBE RID: 204734
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
