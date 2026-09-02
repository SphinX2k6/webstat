using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Rain2
{
	// Token: 0x02003B3E RID: 15166
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Rain2/BP_SurfaceRipple.BP_SurfaceRipple_C")]
	[UnrealStructLayout(1568, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1557)]
	public class BP_SurfaceRipple_C : AKuroSurfaceRipple, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020D65 RID: 134501 RVA: 0x00938357 File Offset: 0x00936557
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SurfaceRipple_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Rain2/BP_SurfaceRipple.BP_SurfaceRipple_C");
			}
			return BP_SurfaceRipple_C._ClassPtr;
		}

		// Token: 0x06020D66 RID: 134502 RVA: 0x0093837C File Offset: 0x0093657C
		public BP_SurfaceRipple_C() : this(BuiltinUtils.AllocNativeUObject(BP_SurfaceRipple_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020D67 RID: 134503 RVA: 0x009383A4 File Offset: 0x009365A4
		[NullableContext(1)]
		public BP_SurfaceRipple_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SurfaceRipple_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700378B RID: 14219
		// (get) Token: 0x06020D68 RID: 134504 RVA: 0x009383D8 File Offset: 0x009365D8
		// (set) Token: 0x06020D69 RID: 134505 RVA: 0x00938411 File Offset: 0x00936611
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SurfaceRipple_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SurfaceRipple_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700378C RID: 14220
		// (get) Token: 0x06020D6A RID: 134506 RVA: 0x00938432 File Offset: 0x00936632
		// (set) Token: 0x06020D6B RID: 134507 RVA: 0x00938446 File Offset: 0x00936646
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SurfaceRipple_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SurfaceRipple_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700378D RID: 14221
		// (get) Token: 0x06020D6C RID: 134508 RVA: 0x0093845B File Offset: 0x0093665B
		// (set) Token: 0x06020D6D RID: 134509 RVA: 0x0093846F File Offset: 0x0093666F
		public unsafe UMaterialParameterCollection Global_MPC_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SurfaceRipple_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SurfaceRipple_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700378E RID: 14222
		// (get) Token: 0x06020D6E RID: 134510 RVA: 0x00938484 File Offset: 0x00936684
		// (set) Token: 0x06020D6F RID: 134511 RVA: 0x00938498 File Offset: 0x00936698
		public unsafe UMaterialInstanceDynamic MID_Ripple_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SurfaceRipple_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SurfaceRipple_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700378F RID: 14223
		// (get) Token: 0x06020D70 RID: 134512 RVA: 0x009384AD File Offset: 0x009366AD
		// (set) Token: 0x06020D71 RID: 134513 RVA: 0x009384C1 File Offset: 0x009366C1
		public unsafe UTextureRenderTarget2D RT_Ripple_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SurfaceRipple_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SurfaceRipple_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003790 RID: 14224
		// (get) Token: 0x06020D72 RID: 134514 RVA: 0x009384D6 File Offset: 0x009366D6
		// (set) Token: 0x06020D73 RID: 134515 RVA: 0x009384E6 File Offset: 0x009366E6
		public unsafe float RainDensity_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SurfaceRipple_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SurfaceRipple_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003791 RID: 14225
		// (get) Token: 0x06020D74 RID: 134516 RVA: 0x009384F7 File Offset: 0x009366F7
		// (set) Token: 0x06020D75 RID: 134517 RVA: 0x00938507 File Offset: 0x00936707
		public unsafe float LastRainDensity_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SurfaceRipple_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SurfaceRipple_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003792 RID: 14226
		// (get) Token: 0x06020D76 RID: 134518 RVA: 0x00938518 File Offset: 0x00936718
		// (set) Token: 0x06020D77 RID: 134519 RVA: 0x00938528 File Offset: 0x00936728
		public unsafe float DeltaTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SurfaceRipple_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SurfaceRipple_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003793 RID: 14227
		// (get) Token: 0x06020D78 RID: 134520 RVA: 0x00938539 File Offset: 0x00936739
		// (set) Token: 0x06020D79 RID: 134521 RVA: 0x00938549 File Offset: 0x00936749
		public unsafe float RainTimePassed_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SurfaceRipple_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SurfaceRipple_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003794 RID: 14228
		// (get) Token: 0x06020D7A RID: 134522 RVA: 0x0093855A File Offset: 0x0093675A
		// (set) Token: 0x06020D7B RID: 134523 RVA: 0x0093856A File Offset: 0x0093676A
		public unsafe float 下雨渐变最大时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SurfaceRipple_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SurfaceRipple_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003795 RID: 14229
		// (get) Token: 0x06020D7C RID: 134524 RVA: 0x0093857B File Offset: 0x0093677B
		// (set) Token: 0x06020D7D RID: 134525 RVA: 0x0093858F File Offset: 0x0093678F
		public unsafe FVector4 下雨地面变化参数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SurfaceRipple_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SurfaceRipple_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003796 RID: 14230
		// (get) Token: 0x06020D7E RID: 134526 RVA: 0x009385A4 File Offset: 0x009367A4
		// (set) Token: 0x06020D7F RID: 134527 RVA: 0x009385B8 File Offset: 0x009367B8
		public unsafe FLinearColor GlobalRainGradualData
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SurfaceRipple_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SurfaceRipple_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003797 RID: 14231
		// (get) Token: 0x06020D80 RID: 134528 RVA: 0x009385CD File Offset: 0x009367CD
		// (set) Token: 0x06020D81 RID: 134529 RVA: 0x009385E1 File Offset: 0x009367E1
		public unsafe FLinearColor GlobalRainLerpData
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SurfaceRipple_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SurfaceRipple_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003798 RID: 14232
		// (get) Token: 0x06020D82 RID: 134530 RVA: 0x009385F6 File Offset: 0x009367F6
		// (set) Token: 0x06020D83 RID: 134531 RVA: 0x00938606 File Offset: 0x00936806
		public unsafe float RainIntensity_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SurfaceRipple_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SurfaceRipple_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003799 RID: 14233
		// (get) Token: 0x06020D84 RID: 134532 RVA: 0x00938617 File Offset: 0x00936817
		// (set) Token: 0x06020D85 RID: 134533 RVA: 0x00938627 File Offset: 0x00936827
		public unsafe bool UpdateRainRT_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SurfaceRipple_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SurfaceRipple_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x06020D86 RID: 134534 RVA: 0x00938638 File Offset: 0x00936838
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_No_Rain_Roughness()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SurfaceRipple_C.__Set_No_Rain_Roughness_NativeFunctionPtr, null);
		}

		// Token: 0x06020D87 RID: 134535 RVA: 0x0093864C File Offset: 0x0093684C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_Rain_Roughness()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SurfaceRipple_C.__Set_Rain_Roughness_NativeFunctionPtr, null);
		}

		// Token: 0x06020D88 RID: 134536 RVA: 0x00938660 File Offset: 0x00936860
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_No_Rain()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SurfaceRipple_C.__Set_No_Rain_NativeFunctionPtr, null);
		}

		// Token: 0x06020D89 RID: 134537 RVA: 0x00938674 File Offset: 0x00936874
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_Rain()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SurfaceRipple_C.__Set_Rain_NativeFunctionPtr, null);
		}

		// Token: 0x06020D8A RID: 134538 RVA: 0x00938688 File Offset: 0x00936888
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateGradualData(int Index, float InputParam, ref FLinearColor GlobalRainGradualData, ref bool Vaild)
		{
			BP_SurfaceRipple_C.__UpdateGradualData_FunctionParams* ptr = stackalloc BP_SurfaceRipple_C.__UpdateGradualData_FunctionParams[(UIntPtr)107] + 15L / (long)sizeof(BP_SurfaceRipple_C.__UpdateGradualData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SurfaceRipple_C.__UpdateGradualData_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Index = Index;
			ptr->InputParam = InputParam;
			ptr->GlobalRainGradualData = GlobalRainGradualData;
			ptr->Vaild = Vaild;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SurfaceRipple_C.__UpdateGradualData_NativeFunctionPtr, (void*)ptr);
			GlobalRainGradualData = ptr->GlobalRainGradualData;
			Vaild = ptr->Vaild;
		}

		// Token: 0x06020D8B RID: 134539 RVA: 0x009386FF File Offset: 0x009368FF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SurfaceRipple_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06020D8C RID: 134540 RVA: 0x00938713 File Offset: 0x00936913
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SurfaceRipple_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020D8D RID: 134541 RVA: 0x00938728 File Offset: 0x00936928
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SurfaceRipple_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020D8E RID: 134542 RVA: 0x0093873C File Offset: 0x0093693C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SurfaceRipple_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020D8F RID: 134543 RVA: 0x00938754 File Offset: 0x00936954
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SurfaceRipple_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SurfaceRipple_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SurfaceRipple_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SurfaceRipple_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SurfaceRipple_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020D90 RID: 134544 RVA: 0x0093879C File Offset: 0x0093699C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SurfaceRipple_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SurfaceRipple_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SurfaceRipple_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SurfaceRipple_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SurfaceRipple_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020D91 RID: 134545 RVA: 0x009387E4 File Offset: 0x009369E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_SurfaceRipple_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_SurfaceRipple_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_SurfaceRipple_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SurfaceRipple_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SurfaceRipple_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020D92 RID: 134546 RVA: 0x00938830 File Offset: 0x00936A30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_SurfaceRipple_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_SurfaceRipple_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_SurfaceRipple_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SurfaceRipple_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SurfaceRipple_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020D93 RID: 134547 RVA: 0x0093887C File Offset: 0x00936A7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_SurfaceRipple_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SurfaceRipple_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SurfaceRipple_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SurfaceRipple_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SurfaceRipple_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020D94 RID: 134548 RVA: 0x009388C4 File Offset: 0x00936AC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_SurfaceRipple_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SurfaceRipple_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SurfaceRipple_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SurfaceRipple_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SurfaceRipple_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020D95 RID: 134549 RVA: 0x0093890C File Offset: 0x00936B0C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SurfaceRipple(int EntryPoint)
		{
			BP_SurfaceRipple_C.__ExecuteUbergraph_BP_SurfaceRipple_FunctionParams* ptr = stackalloc BP_SurfaceRipple_C.__ExecuteUbergraph_BP_SurfaceRipple_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_SurfaceRipple_C.__ExecuteUbergraph_BP_SurfaceRipple_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SurfaceRipple_C.__ExecuteUbergraph_BP_SurfaceRipple_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SurfaceRipple_C.__ExecuteUbergraph_BP_SurfaceRipple_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020D96 RID: 134550 RVA: 0x00938956 File Offset: 0x00936B56
		protected BP_SurfaceRipple_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010772 RID: 67442
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Rain2/BP_SurfaceRipple.BP_SurfaceRipple_C";

		// Token: 0x04010773 RID: 67443
		private static IntPtr _ClassPtr;

		// Token: 0x04010774 RID: 67444
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010775 RID: 67445
		internal static int __PropertyOffset_0;

		// Token: 0x04010776 RID: 67446
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010777 RID: 67447
		internal static int __PropertyOffset_1;

		// Token: 0x04010778 RID: 67448
		internal static int __PropertyOffset_2;

		// Token: 0x04010779 RID: 67449
		internal static int __PropertyOffset_3;

		// Token: 0x0401077A RID: 67450
		internal static int __PropertyOffset_4;

		// Token: 0x0401077B RID: 67451
		internal static int __PropertyOffset_5;

		// Token: 0x0401077C RID: 67452
		internal static int __PropertyOffset_6;

		// Token: 0x0401077D RID: 67453
		internal static int __PropertyOffset_7;

		// Token: 0x0401077E RID: 67454
		internal static int __PropertyOffset_8;

		// Token: 0x0401077F RID: 67455
		internal static int __PropertyOffset_9;

		// Token: 0x04010780 RID: 67456
		internal static int __PropertyOffset_10;

		// Token: 0x04010781 RID: 67457
		internal static int __PropertyOffset_11;

		// Token: 0x04010782 RID: 67458
		internal static int __PropertyOffset_12;

		// Token: 0x04010783 RID: 67459
		internal static int __PropertyOffset_13;

		// Token: 0x04010784 RID: 67460
		internal static int __PropertyOffset_14;

		// Token: 0x04010785 RID: 67461
		private static IntPtr __Set_No_Rain_Roughness_NativeFunctionPtr;

		// Token: 0x04010786 RID: 67462
		private static IntPtr __Set_Rain_Roughness_NativeFunctionPtr;

		// Token: 0x04010787 RID: 67463
		private static IntPtr __Set_No_Rain_NativeFunctionPtr;

		// Token: 0x04010788 RID: 67464
		private static IntPtr __Set_Rain_NativeFunctionPtr;

		// Token: 0x04010789 RID: 67465
		private static IntPtr __UpdateGradualData_NativeFunctionPtr;

		// Token: 0x0401078A RID: 67466
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401078B RID: 67467
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401078C RID: 67468
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401078D RID: 67469
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x0401078E RID: 67470
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401078F RID: 67471
		private static IntPtr __ExecuteUbergraph_BP_SurfaceRipple_NativeFunctionPtr;

		// Token: 0x02009A3A RID: 39482
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 92)]
		protected ref struct __UpdateGradualData_FunctionParams
		{
			// Token: 0x04032137 RID: 205111
			[FieldOffset(0)]
			public int Index;

			// Token: 0x04032138 RID: 205112
			[FieldOffset(4)]
			public float InputParam;

			// Token: 0x04032139 RID: 205113
			[FieldOffset(8)]
			public FLinearColor GlobalRainGradualData;

			// Token: 0x0403213A RID: 205114
			[FieldOffset(24)]
			public bool Vaild;
		}

		// Token: 0x02009A3B RID: 39483
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403213B RID: 205115
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A3C RID: 39484
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x0403213C RID: 205116
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009A3D RID: 39485
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x0403213D RID: 205117
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A3E RID: 39486
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __ExecuteUbergraph_BP_SurfaceRipple_FunctionParams
		{
			// Token: 0x0403213E RID: 205118
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
