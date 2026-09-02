using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GPUGrassInteraction
{
	// Token: 0x02003C15 RID: 15381
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GPUGrassInteraction/BP_LongGrass.BP_LongGrass_C")]
	[UnrealStructLayout(1472, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1465)]
	public class BP_LongGrass_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022FFD RID: 143357 RVA: 0x00975AB4 File Offset: 0x00973CB4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_LongGrass_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/GPUGrassInteraction/BP_LongGrass.BP_LongGrass_C");
			}
			return BP_LongGrass_C._ClassPtr;
		}

		// Token: 0x06022FFE RID: 143358 RVA: 0x00975AD8 File Offset: 0x00973CD8
		public BP_LongGrass_C() : this(BuiltinUtils.AllocNativeUObject(BP_LongGrass_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022FFF RID: 143359 RVA: 0x00975B00 File Offset: 0x00973D00
		[NullableContext(1)]
		public BP_LongGrass_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_LongGrass_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170043E0 RID: 17376
		// (get) Token: 0x06023000 RID: 143360 RVA: 0x00975B34 File Offset: 0x00973D34
		// (set) Token: 0x06023001 RID: 143361 RVA: 0x00975B6D File Offset: 0x00973D6D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_LongGrass_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_LongGrass_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170043E1 RID: 17377
		// (get) Token: 0x06023002 RID: 143362 RVA: 0x00975B8E File Offset: 0x00973D8E
		// (set) Token: 0x06023003 RID: 143363 RVA: 0x00975BA2 File Offset: 0x00973DA2
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LongGrass_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LongGrass_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170043E2 RID: 17378
		// (get) Token: 0x06023004 RID: 143364 RVA: 0x00975BB7 File Offset: 0x00973DB7
		// (set) Token: 0x06023005 RID: 143365 RVA: 0x00975BCB File Offset: 0x00973DCB
		public unsafe UStaticMeshComponent Static_Mesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LongGrass_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LongGrass_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170043E3 RID: 17379
		// (get) Token: 0x06023006 RID: 143366 RVA: 0x00975BE0 File Offset: 0x00973DE0
		// (set) Token: 0x06023007 RID: 143367 RVA: 0x00975BF4 File Offset: 0x00973DF4
		public unsafe UNiagaraComponent NS_FX_LongGrass
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LongGrass_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LongGrass_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170043E4 RID: 17380
		// (get) Token: 0x06023008 RID: 143368 RVA: 0x00975C09 File Offset: 0x00973E09
		// (set) Token: 0x06023009 RID: 143369 RVA: 0x00975C1D File Offset: 0x00973E1D
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LongGrass_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LongGrass_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170043E5 RID: 17381
		// (get) Token: 0x0602300A RID: 143370 RVA: 0x00975C32 File Offset: 0x00973E32
		// (set) Token: 0x0602300B RID: 143371 RVA: 0x00975C46 File Offset: 0x00973E46
		public unsafe UStaticMesh Mesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LongGrass_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LongGrass_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170043E6 RID: 17382
		// (get) Token: 0x0602300C RID: 143372 RVA: 0x00975C5B File Offset: 0x00973E5B
		// (set) Token: 0x0602300D RID: 143373 RVA: 0x00975C6F File Offset: 0x00973E6F
		public unsafe UHoudiniPointCache HoudiniPointCache
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UHoudiniPointCache>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LongGrass_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LongGrass_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170043E7 RID: 17383
		// (get) Token: 0x0602300E RID: 143374 RVA: 0x00975C84 File Offset: 0x00973E84
		// (set) Token: 0x0602300F RID: 143375 RVA: 0x00975C94 File Offset: 0x00973E94
		public unsafe int BoneCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LongGrass_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LongGrass_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170043E8 RID: 17384
		// (get) Token: 0x06023010 RID: 143376 RVA: 0x00975CA5 File Offset: 0x00973EA5
		// (set) Token: 0x06023011 RID: 143377 RVA: 0x00975CB5 File Offset: 0x00973EB5
		public unsafe bool bAllowDebugDraw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LongGrass_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LongGrass_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x170043E9 RID: 17385
		// (get) Token: 0x06023012 RID: 143378 RVA: 0x00975CC6 File Offset: 0x00973EC6
		// (set) Token: 0x06023013 RID: 143379 RVA: 0x00975CDA File Offset: 0x00973EDA
		public unsafe UTextureRenderTarget2D RT_Pos
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LongGrass_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LongGrass_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x170043EA RID: 17386
		// (get) Token: 0x06023014 RID: 143380 RVA: 0x00975CEF File Offset: 0x00973EEF
		// (set) Token: 0x06023015 RID: 143381 RVA: 0x00975D03 File Offset: 0x00973F03
		public unsafe UTextureRenderTarget2D RT_Rot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LongGrass_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LongGrass_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x170043EB RID: 17387
		// (get) Token: 0x06023016 RID: 143382 RVA: 0x00975D18 File Offset: 0x00973F18
		// (set) Token: 0x06023017 RID: 143383 RVA: 0x00975D28 File Offset: 0x00973F28
		public unsafe int First_Index
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LongGrass_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LongGrass_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170043EC RID: 17388
		// (get) Token: 0x06023018 RID: 143384 RVA: 0x00975D39 File Offset: 0x00973F39
		// (set) Token: 0x06023019 RID: 143385 RVA: 0x00975D49 File Offset: 0x00973F49
		public unsafe int Last_Index
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LongGrass_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LongGrass_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170043ED RID: 17389
		// (get) Token: 0x0602301A RID: 143386 RVA: 0x00975D5A File Offset: 0x00973F5A
		// (set) Token: 0x0602301B RID: 143387 RVA: 0x00975D6A File Offset: 0x00973F6A
		public unsafe int InteractionIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LongGrass_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LongGrass_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170043EE RID: 17390
		// (get) Token: 0x0602301C RID: 143388 RVA: 0x00975D7B File Offset: 0x00973F7B
		// (set) Token: 0x0602301D RID: 143389 RVA: 0x00975D8F File Offset: 0x00973F8F
		public unsafe UMaterialInterface Dynamic_Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LongGrass_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LongGrass_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x170043EF RID: 17391
		// (get) Token: 0x0602301E RID: 143390 RVA: 0x00975DA4 File Offset: 0x00973FA4
		// (set) Token: 0x0602301F RID: 143391 RVA: 0x00975DB4 File Offset: 0x00973FB4
		public unsafe bool Active
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LongGrass_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LongGrass_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x170043F0 RID: 17392
		// (get) Token: 0x06023020 RID: 143392 RVA: 0x00975DC5 File Offset: 0x00973FC5
		// (set) Token: 0x06023021 RID: 143393 RVA: 0x00975DD5 File Offset: 0x00973FD5
		public unsafe bool StopAlready
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LongGrass_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LongGrass_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x170043F1 RID: 17393
		// (get) Token: 0x06023022 RID: 143394 RVA: 0x00975DE6 File Offset: 0x00973FE6
		// (set) Token: 0x06023023 RID: 143395 RVA: 0x00975DF6 File Offset: 0x00973FF6
		public unsafe float TickTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LongGrass_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LongGrass_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170043F2 RID: 17394
		// (get) Token: 0x06023024 RID: 143396 RVA: 0x00975E07 File Offset: 0x00974007
		// (set) Token: 0x06023025 RID: 143397 RVA: 0x00975E1B File Offset: 0x0097401B
		public unsafe UMaterialInterface Static_Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LongGrass_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LongGrass_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x170043F3 RID: 17395
		// (get) Token: 0x06023026 RID: 143398 RVA: 0x00975E30 File Offset: 0x00974030
		// (set) Token: 0x06023027 RID: 143399 RVA: 0x00975E69 File Offset: 0x00974069
		[Nullable(1)]
		public TArray<float> CustomData
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._CustomData) == null)
				{
					result = (this._CustomData = new TArray<float>(base.NativePtr + (IntPtr)BP_LongGrass_C.__PropertyOffset_19, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CustomData.CopyAssign(value);
			}
		}

		// Token: 0x170043F4 RID: 17396
		// (get) Token: 0x06023028 RID: 143400 RVA: 0x00975E77 File Offset: 0x00974077
		// (set) Token: 0x06023029 RID: 143401 RVA: 0x00975E8B File Offset: 0x0097408B
		public unsafe BP_GPUFoliageInteraction_C DataAsset
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_GPUFoliageInteraction_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LongGrass_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LongGrass_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x170043F5 RID: 17397
		// (get) Token: 0x0602302A RID: 143402 RVA: 0x00975EA0 File Offset: 0x009740A0
		// (set) Token: 0x0602302B RID: 143403 RVA: 0x00975EB0 File Offset: 0x009740B0
		public unsafe bool UseDataAsset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LongGrass_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LongGrass_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602302C RID: 143404 RVA: 0x00975EC4 File Offset: 0x009740C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CopyCustomPrimitiveData(UStaticMeshComponent Target)
		{
			BP_LongGrass_C.__CopyCustomPrimitiveData_FunctionParams* ptr = stackalloc BP_LongGrass_C.__CopyCustomPrimitiveData_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_LongGrass_C.__CopyCustomPrimitiveData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LongGrass_C.__CopyCustomPrimitiveData_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Target = ((Target != null) ? Target.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LongGrass_C.__CopyCustomPrimitiveData_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602302D RID: 143405 RVA: 0x00975F19 File Offset: 0x00974119
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_Params_And_MID()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LongGrass_C.__Set_Params_And_MID_NativeFunctionPtr, null);
		}

		// Token: 0x0602302E RID: 143406 RVA: 0x00975F2D File Offset: 0x0097412D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Stop_Interaction()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LongGrass_C.__Stop_Interaction_NativeFunctionPtr, null);
		}

		// Token: 0x0602302F RID: 143407 RVA: 0x00975F41 File Offset: 0x00974141
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Draw_Transfrom()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LongGrass_C.__Draw_Transfrom_NativeFunctionPtr, null);
		}

		// Token: 0x06023030 RID: 143408 RVA: 0x00975F55 File Offset: 0x00974155
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Clear_RT()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LongGrass_C.__Clear_RT_NativeFunctionPtr, null);
		}

		// Token: 0x06023031 RID: 143409 RVA: 0x00975F69 File Offset: 0x00974169
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LongGrass_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023032 RID: 143410 RVA: 0x00975F7D File Offset: 0x0097417D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LongGrass_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023033 RID: 143411 RVA: 0x00975F94 File Offset: 0x00974194
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_LongGrass_C.__BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_LongGrass_C.__BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_LongGrass_C.__BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LongGrass_C.__BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LongGrass_C.__BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023034 RID: 143412 RVA: 0x00976020 File Offset: 0x00974220
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_LongGrass_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LongGrass_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LongGrass_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LongGrass_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LongGrass_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023035 RID: 143413 RVA: 0x00976068 File Offset: 0x00974268
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_LongGrass_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LongGrass_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LongGrass_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LongGrass_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LongGrass_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023036 RID: 143414 RVA: 0x009760B0 File Offset: 0x009742B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_LongGrass_C.__BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_LongGrass_C.__BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_LongGrass_C.__BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LongGrass_C.__BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LongGrass_C.__BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023037 RID: 143415 RVA: 0x0097616C File Offset: 0x0097436C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_LongGrass_C.__EditorTick_FunctionParams* ptr = stackalloc BP_LongGrass_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LongGrass_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LongGrass_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LongGrass_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023038 RID: 143416 RVA: 0x009761B4 File Offset: 0x009743B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_LongGrass_C.__EditorTick_FunctionParams* ptr = stackalloc BP_LongGrass_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LongGrass_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LongGrass_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LongGrass_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023039 RID: 143417 RVA: 0x009761FC File Offset: 0x009743FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_LongGrass(int EntryPoint)
		{
			BP_LongGrass_C.__ExecuteUbergraph_BP_LongGrass_FunctionParams* ptr = stackalloc BP_LongGrass_C.__ExecuteUbergraph_BP_LongGrass_FunctionParams[(UIntPtr)247] + 15L / (long)sizeof(BP_LongGrass_C.__ExecuteUbergraph_BP_LongGrass_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LongGrass_C.__ExecuteUbergraph_BP_LongGrass_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LongGrass_C.__ExecuteUbergraph_BP_LongGrass_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602303A RID: 143418 RVA: 0x00976246 File Offset: 0x00974446
		protected BP_LongGrass_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011C91 RID: 72849
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUGrassInteraction/BP_LongGrass.BP_LongGrass_C";

		// Token: 0x04011C92 RID: 72850
		private static IntPtr _ClassPtr;

		// Token: 0x04011C93 RID: 72851
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011C94 RID: 72852
		internal static int __PropertyOffset_0;

		// Token: 0x04011C95 RID: 72853
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011C96 RID: 72854
		internal static int __PropertyOffset_1;

		// Token: 0x04011C97 RID: 72855
		internal static int __PropertyOffset_2;

		// Token: 0x04011C98 RID: 72856
		internal static int __PropertyOffset_3;

		// Token: 0x04011C99 RID: 72857
		internal static int __PropertyOffset_4;

		// Token: 0x04011C9A RID: 72858
		internal static int __PropertyOffset_5;

		// Token: 0x04011C9B RID: 72859
		internal static int __PropertyOffset_6;

		// Token: 0x04011C9C RID: 72860
		internal static int __PropertyOffset_7;

		// Token: 0x04011C9D RID: 72861
		internal static int __PropertyOffset_8;

		// Token: 0x04011C9E RID: 72862
		internal static int __PropertyOffset_9;

		// Token: 0x04011C9F RID: 72863
		internal static int __PropertyOffset_10;

		// Token: 0x04011CA0 RID: 72864
		internal static int __PropertyOffset_11;

		// Token: 0x04011CA1 RID: 72865
		internal static int __PropertyOffset_12;

		// Token: 0x04011CA2 RID: 72866
		internal static int __PropertyOffset_13;

		// Token: 0x04011CA3 RID: 72867
		internal static int __PropertyOffset_14;

		// Token: 0x04011CA4 RID: 72868
		internal static int __PropertyOffset_15;

		// Token: 0x04011CA5 RID: 72869
		internal static int __PropertyOffset_16;

		// Token: 0x04011CA6 RID: 72870
		internal static int __PropertyOffset_17;

		// Token: 0x04011CA7 RID: 72871
		internal static int __PropertyOffset_18;

		// Token: 0x04011CA8 RID: 72872
		internal static int __PropertyOffset_19;

		// Token: 0x04011CA9 RID: 72873
		private TArray<float> _CustomData;

		// Token: 0x04011CAA RID: 72874
		internal static int __PropertyOffset_20;

		// Token: 0x04011CAB RID: 72875
		internal static int __PropertyOffset_21;

		// Token: 0x04011CAC RID: 72876
		private static IntPtr __CopyCustomPrimitiveData_NativeFunctionPtr;

		// Token: 0x04011CAD RID: 72877
		private static IntPtr __Set_Params_And_MID_NativeFunctionPtr;

		// Token: 0x04011CAE RID: 72878
		private static IntPtr __Stop_Interaction_NativeFunctionPtr;

		// Token: 0x04011CAF RID: 72879
		private static IntPtr __Draw_Transfrom_NativeFunctionPtr;

		// Token: 0x04011CB0 RID: 72880
		private static IntPtr __Clear_RT_NativeFunctionPtr;

		// Token: 0x04011CB1 RID: 72881
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011CB2 RID: 72882
		private static IntPtr __BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011CB3 RID: 72883
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011CB4 RID: 72884
		private static IntPtr __BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011CB5 RID: 72885
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04011CB6 RID: 72886
		private static IntPtr __ExecuteUbergraph_BP_LongGrass_NativeFunctionPtr;

		// Token: 0x02009C6F RID: 40047
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __CopyCustomPrimitiveData_FunctionParams
		{
			// Token: 0x04032555 RID: 206165
			[FieldOffset(0)]
			public IntPtr Target;
		}

		// Token: 0x02009C70 RID: 40048
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032556 RID: 206166
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032557 RID: 206167
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032558 RID: 206168
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032559 RID: 206169
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009C71 RID: 40049
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403255A RID: 206170
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C72 RID: 40050
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403255B RID: 206171
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403255C RID: 206172
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403255D RID: 206173
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403255E RID: 206174
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x0403255F RID: 206175
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032560 RID: 206176
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009C73 RID: 40051
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032561 RID: 206177
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C74 RID: 40052
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 232)]
		protected ref struct __ExecuteUbergraph_BP_LongGrass_FunctionParams
		{
			// Token: 0x04032562 RID: 206178
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
