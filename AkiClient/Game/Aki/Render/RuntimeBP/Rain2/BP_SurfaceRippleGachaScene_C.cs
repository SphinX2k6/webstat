using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Rain2
{
	// Token: 0x02003B3D RID: 15165
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Rain2/BP_SurfaceRippleGachaScene.BP_SurfaceRippleGachaScene_C")]
	[UnrealStructLayout(1568, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1557)]
	public class BP_SurfaceRippleGachaScene_C : AKuroSurfaceRipple, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020D31 RID: 134449 RVA: 0x00937D24 File Offset: 0x00935F24
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SurfaceRippleGachaScene_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Rain2/BP_SurfaceRippleGachaScene.BP_SurfaceRippleGachaScene_C");
			}
			return BP_SurfaceRippleGachaScene_C._ClassPtr;
		}

		// Token: 0x06020D32 RID: 134450 RVA: 0x00937D48 File Offset: 0x00935F48
		public BP_SurfaceRippleGachaScene_C() : this(BuiltinUtils.AllocNativeUObject(BP_SurfaceRippleGachaScene_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020D33 RID: 134451 RVA: 0x00937D70 File Offset: 0x00935F70
		[NullableContext(1)]
		public BP_SurfaceRippleGachaScene_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SurfaceRippleGachaScene_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700377B RID: 14203
		// (get) Token: 0x06020D34 RID: 134452 RVA: 0x00937DA4 File Offset: 0x00935FA4
		// (set) Token: 0x06020D35 RID: 134453 RVA: 0x00937DDD File Offset: 0x00935FDD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SurfaceRippleGachaScene_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SurfaceRippleGachaScene_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700377C RID: 14204
		// (get) Token: 0x06020D36 RID: 134454 RVA: 0x00937DFE File Offset: 0x00935FFE
		// (set) Token: 0x06020D37 RID: 134455 RVA: 0x00937E12 File Offset: 0x00936012
		public unsafe UKuroGameBudgetComponent KuroGameBudget
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroGameBudgetComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SurfaceRippleGachaScene_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SurfaceRippleGachaScene_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700377D RID: 14205
		// (get) Token: 0x06020D38 RID: 134456 RVA: 0x00937E27 File Offset: 0x00936027
		// (set) Token: 0x06020D39 RID: 134457 RVA: 0x00937E3B File Offset: 0x0093603B
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SurfaceRippleGachaScene_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SurfaceRippleGachaScene_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700377E RID: 14206
		// (get) Token: 0x06020D3A RID: 134458 RVA: 0x00937E50 File Offset: 0x00936050
		// (set) Token: 0x06020D3B RID: 134459 RVA: 0x00937E64 File Offset: 0x00936064
		public unsafe UMaterialParameterCollection Global_MPC_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SurfaceRippleGachaScene_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SurfaceRippleGachaScene_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700377F RID: 14207
		// (get) Token: 0x06020D3C RID: 134460 RVA: 0x00937E79 File Offset: 0x00936079
		// (set) Token: 0x06020D3D RID: 134461 RVA: 0x00937E8D File Offset: 0x0093608D
		public unsafe UMaterialInstanceDynamic MID_Ripple_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SurfaceRippleGachaScene_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SurfaceRippleGachaScene_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003780 RID: 14208
		// (get) Token: 0x06020D3E RID: 134462 RVA: 0x00937EA2 File Offset: 0x009360A2
		// (set) Token: 0x06020D3F RID: 134463 RVA: 0x00937EB6 File Offset: 0x009360B6
		public unsafe UTextureRenderTarget2D RT_Ripple_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SurfaceRippleGachaScene_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SurfaceRippleGachaScene_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003781 RID: 14209
		// (get) Token: 0x06020D40 RID: 134464 RVA: 0x00937ECB File Offset: 0x009360CB
		// (set) Token: 0x06020D41 RID: 134465 RVA: 0x00937EDB File Offset: 0x009360DB
		public unsafe float RainDensity_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SurfaceRippleGachaScene_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SurfaceRippleGachaScene_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003782 RID: 14210
		// (get) Token: 0x06020D42 RID: 134466 RVA: 0x00937EEC File Offset: 0x009360EC
		// (set) Token: 0x06020D43 RID: 134467 RVA: 0x00937EFC File Offset: 0x009360FC
		public unsafe float LastRainDensity_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SurfaceRippleGachaScene_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SurfaceRippleGachaScene_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003783 RID: 14211
		// (get) Token: 0x06020D44 RID: 134468 RVA: 0x00937F0D File Offset: 0x0093610D
		// (set) Token: 0x06020D45 RID: 134469 RVA: 0x00937F1D File Offset: 0x0093611D
		public unsafe float DeltaTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SurfaceRippleGachaScene_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SurfaceRippleGachaScene_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003784 RID: 14212
		// (get) Token: 0x06020D46 RID: 134470 RVA: 0x00937F2E File Offset: 0x0093612E
		// (set) Token: 0x06020D47 RID: 134471 RVA: 0x00937F3E File Offset: 0x0093613E
		public unsafe float RainTimePassed_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SurfaceRippleGachaScene_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SurfaceRippleGachaScene_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003785 RID: 14213
		// (get) Token: 0x06020D48 RID: 134472 RVA: 0x00937F4F File Offset: 0x0093614F
		// (set) Token: 0x06020D49 RID: 134473 RVA: 0x00937F5F File Offset: 0x0093615F
		public unsafe float 下雨渐变最大时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SurfaceRippleGachaScene_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SurfaceRippleGachaScene_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003786 RID: 14214
		// (get) Token: 0x06020D4A RID: 134474 RVA: 0x00937F70 File Offset: 0x00936170
		// (set) Token: 0x06020D4B RID: 134475 RVA: 0x00937F84 File Offset: 0x00936184
		public unsafe FVector4 下雨地面变化参数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SurfaceRippleGachaScene_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SurfaceRippleGachaScene_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003787 RID: 14215
		// (get) Token: 0x06020D4C RID: 134476 RVA: 0x00937F99 File Offset: 0x00936199
		// (set) Token: 0x06020D4D RID: 134477 RVA: 0x00937FAD File Offset: 0x009361AD
		public unsafe FLinearColor GlobalRainGradualData
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SurfaceRippleGachaScene_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SurfaceRippleGachaScene_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003788 RID: 14216
		// (get) Token: 0x06020D4E RID: 134478 RVA: 0x00937FC2 File Offset: 0x009361C2
		// (set) Token: 0x06020D4F RID: 134479 RVA: 0x00937FD6 File Offset: 0x009361D6
		public unsafe FLinearColor GlobalRainLerpData
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SurfaceRippleGachaScene_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SurfaceRippleGachaScene_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003789 RID: 14217
		// (get) Token: 0x06020D50 RID: 134480 RVA: 0x00937FEB File Offset: 0x009361EB
		// (set) Token: 0x06020D51 RID: 134481 RVA: 0x00937FFB File Offset: 0x009361FB
		public unsafe float RainIntensity_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SurfaceRippleGachaScene_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SurfaceRippleGachaScene_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700378A RID: 14218
		// (get) Token: 0x06020D52 RID: 134482 RVA: 0x0093800C File Offset: 0x0093620C
		// (set) Token: 0x06020D53 RID: 134483 RVA: 0x0093801C File Offset: 0x0093621C
		public unsafe bool UpdateRainRT_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SurfaceRippleGachaScene_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SurfaceRippleGachaScene_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x06020D54 RID: 134484 RVA: 0x0093802D File Offset: 0x0093622D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_No_Rain_Roughness()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SurfaceRippleGachaScene_C.__Set_No_Rain_Roughness_NativeFunctionPtr, null);
		}

		// Token: 0x06020D55 RID: 134485 RVA: 0x00938041 File Offset: 0x00936241
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_Rain_Roughness()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SurfaceRippleGachaScene_C.__Set_Rain_Roughness_NativeFunctionPtr, null);
		}

		// Token: 0x06020D56 RID: 134486 RVA: 0x00938055 File Offset: 0x00936255
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_No_Rain()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SurfaceRippleGachaScene_C.__Set_No_Rain_NativeFunctionPtr, null);
		}

		// Token: 0x06020D57 RID: 134487 RVA: 0x00938069 File Offset: 0x00936269
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_Rain()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SurfaceRippleGachaScene_C.__Set_Rain_NativeFunctionPtr, null);
		}

		// Token: 0x06020D58 RID: 134488 RVA: 0x00938080 File Offset: 0x00936280
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateGradualData(int Index, float InputParam, ref FLinearColor GlobalRainGradualData, ref bool Vaild)
		{
			BP_SurfaceRippleGachaScene_C.__UpdateGradualData_FunctionParams* ptr = stackalloc BP_SurfaceRippleGachaScene_C.__UpdateGradualData_FunctionParams[(UIntPtr)107] + 15L / (long)sizeof(BP_SurfaceRippleGachaScene_C.__UpdateGradualData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SurfaceRippleGachaScene_C.__UpdateGradualData_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Index = Index;
			ptr->InputParam = InputParam;
			ptr->GlobalRainGradualData = GlobalRainGradualData;
			ptr->Vaild = Vaild;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SurfaceRippleGachaScene_C.__UpdateGradualData_NativeFunctionPtr, (void*)ptr);
			GlobalRainGradualData = ptr->GlobalRainGradualData;
			Vaild = ptr->Vaild;
		}

		// Token: 0x06020D59 RID: 134489 RVA: 0x009380F7 File Offset: 0x009362F7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SurfaceRippleGachaScene_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06020D5A RID: 134490 RVA: 0x0093810B File Offset: 0x0093630B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SurfaceRippleGachaScene_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020D5B RID: 134491 RVA: 0x00938120 File Offset: 0x00936320
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SurfaceRippleGachaScene_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020D5C RID: 134492 RVA: 0x00938134 File Offset: 0x00936334
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SurfaceRippleGachaScene_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020D5D RID: 134493 RVA: 0x0093814C File Offset: 0x0093634C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SurfaceRippleGachaScene_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SurfaceRippleGachaScene_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SurfaceRippleGachaScene_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SurfaceRippleGachaScene_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SurfaceRippleGachaScene_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020D5E RID: 134494 RVA: 0x00938194 File Offset: 0x00936394
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SurfaceRippleGachaScene_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SurfaceRippleGachaScene_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SurfaceRippleGachaScene_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SurfaceRippleGachaScene_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SurfaceRippleGachaScene_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020D5F RID: 134495 RVA: 0x009381DC File Offset: 0x009363DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_SurfaceRippleGachaScene_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_SurfaceRippleGachaScene_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_SurfaceRippleGachaScene_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SurfaceRippleGachaScene_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SurfaceRippleGachaScene_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020D60 RID: 134496 RVA: 0x00938228 File Offset: 0x00936428
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_SurfaceRippleGachaScene_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_SurfaceRippleGachaScene_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_SurfaceRippleGachaScene_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SurfaceRippleGachaScene_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SurfaceRippleGachaScene_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020D61 RID: 134497 RVA: 0x00938274 File Offset: 0x00936474
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_SurfaceRippleGachaScene_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SurfaceRippleGachaScene_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SurfaceRippleGachaScene_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SurfaceRippleGachaScene_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SurfaceRippleGachaScene_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020D62 RID: 134498 RVA: 0x009382BC File Offset: 0x009364BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_SurfaceRippleGachaScene_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SurfaceRippleGachaScene_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SurfaceRippleGachaScene_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SurfaceRippleGachaScene_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SurfaceRippleGachaScene_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020D63 RID: 134499 RVA: 0x00938304 File Offset: 0x00936504
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SurfaceRippleGachaScene(int EntryPoint)
		{
			BP_SurfaceRippleGachaScene_C.__ExecuteUbergraph_BP_SurfaceRippleGachaScene_FunctionParams* ptr = stackalloc BP_SurfaceRippleGachaScene_C.__ExecuteUbergraph_BP_SurfaceRippleGachaScene_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_SurfaceRippleGachaScene_C.__ExecuteUbergraph_BP_SurfaceRippleGachaScene_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SurfaceRippleGachaScene_C.__ExecuteUbergraph_BP_SurfaceRippleGachaScene_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SurfaceRippleGachaScene_C.__ExecuteUbergraph_BP_SurfaceRippleGachaScene_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020D64 RID: 134500 RVA: 0x0093834E File Offset: 0x0093654E
		protected BP_SurfaceRippleGachaScene_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010753 RID: 67411
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Rain2/BP_SurfaceRippleGachaScene.BP_SurfaceRippleGachaScene_C";

		// Token: 0x04010754 RID: 67412
		private static IntPtr _ClassPtr;

		// Token: 0x04010755 RID: 67413
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010756 RID: 67414
		internal static int __PropertyOffset_0;

		// Token: 0x04010757 RID: 67415
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010758 RID: 67416
		internal static int __PropertyOffset_1;

		// Token: 0x04010759 RID: 67417
		internal static int __PropertyOffset_2;

		// Token: 0x0401075A RID: 67418
		internal static int __PropertyOffset_3;

		// Token: 0x0401075B RID: 67419
		internal static int __PropertyOffset_4;

		// Token: 0x0401075C RID: 67420
		internal static int __PropertyOffset_5;

		// Token: 0x0401075D RID: 67421
		internal static int __PropertyOffset_6;

		// Token: 0x0401075E RID: 67422
		internal static int __PropertyOffset_7;

		// Token: 0x0401075F RID: 67423
		internal static int __PropertyOffset_8;

		// Token: 0x04010760 RID: 67424
		internal static int __PropertyOffset_9;

		// Token: 0x04010761 RID: 67425
		internal static int __PropertyOffset_10;

		// Token: 0x04010762 RID: 67426
		internal static int __PropertyOffset_11;

		// Token: 0x04010763 RID: 67427
		internal static int __PropertyOffset_12;

		// Token: 0x04010764 RID: 67428
		internal static int __PropertyOffset_13;

		// Token: 0x04010765 RID: 67429
		internal static int __PropertyOffset_14;

		// Token: 0x04010766 RID: 67430
		internal static int __PropertyOffset_15;

		// Token: 0x04010767 RID: 67431
		private static IntPtr __Set_No_Rain_Roughness_NativeFunctionPtr;

		// Token: 0x04010768 RID: 67432
		private static IntPtr __Set_Rain_Roughness_NativeFunctionPtr;

		// Token: 0x04010769 RID: 67433
		private static IntPtr __Set_No_Rain_NativeFunctionPtr;

		// Token: 0x0401076A RID: 67434
		private static IntPtr __Set_Rain_NativeFunctionPtr;

		// Token: 0x0401076B RID: 67435
		private static IntPtr __UpdateGradualData_NativeFunctionPtr;

		// Token: 0x0401076C RID: 67436
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401076D RID: 67437
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401076E RID: 67438
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401076F RID: 67439
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04010770 RID: 67440
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010771 RID: 67441
		private static IntPtr __ExecuteUbergraph_BP_SurfaceRippleGachaScene_NativeFunctionPtr;

		// Token: 0x02009A35 RID: 39477
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 92)]
		protected ref struct __UpdateGradualData_FunctionParams
		{
			// Token: 0x0403212F RID: 205103
			[FieldOffset(0)]
			public int Index;

			// Token: 0x04032130 RID: 205104
			[FieldOffset(4)]
			public float InputParam;

			// Token: 0x04032131 RID: 205105
			[FieldOffset(8)]
			public FLinearColor GlobalRainGradualData;

			// Token: 0x04032132 RID: 205106
			[FieldOffset(24)]
			public bool Vaild;
		}

		// Token: 0x02009A36 RID: 39478
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032133 RID: 205107
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A37 RID: 39479
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04032134 RID: 205108
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009A38 RID: 39480
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032135 RID: 205109
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A39 RID: 39481
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __ExecuteUbergraph_BP_SurfaceRippleGachaScene_FunctionParams
		{
			// Token: 0x04032136 RID: 205110
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
