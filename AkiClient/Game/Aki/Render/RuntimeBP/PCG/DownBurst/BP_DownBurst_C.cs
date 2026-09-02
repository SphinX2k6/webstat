using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.DownBurst
{
	// Token: 0x02003C35 RID: 15413
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/DownBurst/BP_DownBurst.BP_DownBurst_C")]
	[UnrealStructLayout(1608, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1608)]
	public class BP_DownBurst_C : AUKuroCustomCookActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023553 RID: 144723 RVA: 0x0097F213 File Offset: 0x0097D413
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DownBurst_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/DownBurst/BP_DownBurst.BP_DownBurst_C");
			}
			return BP_DownBurst_C._ClassPtr;
		}

		// Token: 0x06023554 RID: 144724 RVA: 0x0097F238 File Offset: 0x0097D438
		public BP_DownBurst_C() : this(BuiltinUtils.AllocNativeUObject(BP_DownBurst_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023555 RID: 144725 RVA: 0x0097F260 File Offset: 0x0097D460
		[NullableContext(1)]
		public BP_DownBurst_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DownBurst_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170045CF RID: 17871
		// (get) Token: 0x06023556 RID: 144726 RVA: 0x0097F294 File Offset: 0x0097D494
		// (set) Token: 0x06023557 RID: 144727 RVA: 0x0097F2CD File Offset: 0x0097D4CD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_DownBurst_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_DownBurst_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170045D0 RID: 17872
		// (get) Token: 0x06023558 RID: 144728 RVA: 0x0097F2EE File Offset: 0x0097D4EE
		// (set) Token: 0x06023559 RID: 144729 RVA: 0x0097F302 File Offset: 0x0097D502
		public unsafe UStaticMeshComponent SM_VerticalQuad
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DownBurst_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DownBurst_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170045D1 RID: 17873
		// (get) Token: 0x0602355A RID: 144730 RVA: 0x0097F317 File Offset: 0x0097D517
		// (set) Token: 0x0602355B RID: 144731 RVA: 0x0097F32B File Offset: 0x0097D52B
		public unsafe USceneComponent MeshRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DownBurst_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DownBurst_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170045D2 RID: 17874
		// (get) Token: 0x0602355C RID: 144732 RVA: 0x0097F340 File Offset: 0x0097D540
		// (set) Token: 0x0602355D RID: 144733 RVA: 0x0097F354 File Offset: 0x0097D554
		public unsafe UBoxComponent StreamVolume
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DownBurst_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DownBurst_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170045D3 RID: 17875
		// (get) Token: 0x0602355E RID: 144734 RVA: 0x0097F369 File Offset: 0x0097D569
		// (set) Token: 0x0602355F RID: 144735 RVA: 0x0097F37D File Offset: 0x0097D57D
		public unsafe UBoxComponent WeatherVolume
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DownBurst_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DownBurst_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170045D4 RID: 17876
		// (get) Token: 0x06023560 RID: 144736 RVA: 0x0097F392 File Offset: 0x0097D592
		// (set) Token: 0x06023561 RID: 144737 RVA: 0x0097F3A6 File Offset: 0x0097D5A6
		public unsafe USceneComponent WeatherRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DownBurst_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DownBurst_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170045D5 RID: 17877
		// (get) Token: 0x06023562 RID: 144738 RVA: 0x0097F3BB File Offset: 0x0097D5BB
		// (set) Token: 0x06023563 RID: 144739 RVA: 0x0097F3CF File Offset: 0x0097D5CF
		public unsafe USplineComponent Spline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DownBurst_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DownBurst_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170045D6 RID: 17878
		// (get) Token: 0x06023564 RID: 144740 RVA: 0x0097F3E4 File Offset: 0x0097D5E4
		// (set) Token: 0x06023565 RID: 144741 RVA: 0x0097F3F8 File Offset: 0x0097D5F8
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DownBurst_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DownBurst_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170045D7 RID: 17879
		// (get) Token: 0x06023566 RID: 144742 RVA: 0x0097F40D File Offset: 0x0097D60D
		// (set) Token: 0x06023567 RID: 144743 RVA: 0x0097F41D File Offset: 0x0097D61D
		public unsafe float Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DownBurst_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DownBurst_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170045D8 RID: 17880
		// (get) Token: 0x06023568 RID: 144744 RVA: 0x0097F42E File Offset: 0x0097D62E
		// (set) Token: 0x06023569 RID: 144745 RVA: 0x0097F43E File Offset: 0x0097D63E
		public unsafe float MoveSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DownBurst_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DownBurst_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170045D9 RID: 17881
		// (get) Token: 0x0602356A RID: 144746 RVA: 0x0097F450 File Offset: 0x0097D650
		// (set) Token: 0x0602356B RID: 144747 RVA: 0x0097F489 File Offset: 0x0097D689
		[Nullable(1)]
		public TSet<AActor> BoundActors
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TSet<AActor> result;
				if ((result = this._BoundActors) == null)
				{
					result = (this._BoundActors = new TSet<AActor>(base.NativePtr + (IntPtr)BP_DownBurst_C.__PropertyOffset_10, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.BoundActors.CopyAssign(value);
			}
		}

		// Token: 0x170045DA RID: 17882
		// (get) Token: 0x0602356C RID: 144748 RVA: 0x0097F497 File Offset: 0x0097D697
		// (set) Token: 0x0602356D RID: 144749 RVA: 0x0097F4A7 File Offset: 0x0097D6A7
		public unsafe bool bStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DownBurst_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DownBurst_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x170045DB RID: 17883
		// (get) Token: 0x0602356E RID: 144750 RVA: 0x0097F4B8 File Offset: 0x0097D6B8
		// (set) Token: 0x0602356F RID: 144751 RVA: 0x0097F4C8 File Offset: 0x0097D6C8
		public unsafe float SumLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DownBurst_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DownBurst_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170045DC RID: 17884
		// (get) Token: 0x06023570 RID: 144752 RVA: 0x0097F4D9 File Offset: 0x0097D6D9
		// (set) Token: 0x06023571 RID: 144753 RVA: 0x0097F4E9 File Offset: 0x0097D6E9
		public unsafe float Duration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DownBurst_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DownBurst_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170045DD RID: 17885
		// (get) Token: 0x06023572 RID: 144754 RVA: 0x0097F4FA File Offset: 0x0097D6FA
		// (set) Token: 0x06023573 RID: 144755 RVA: 0x0097F50A File Offset: 0x0097D70A
		public unsafe float timeCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DownBurst_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DownBurst_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170045DE RID: 17886
		// (get) Token: 0x06023574 RID: 144756 RVA: 0x0097F51B File Offset: 0x0097D71B
		// (set) Token: 0x06023575 RID: 144757 RVA: 0x0097F52B File Offset: 0x0097D72B
		public unsafe float fade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DownBurst_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DownBurst_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170045DF RID: 17887
		// (get) Token: 0x06023576 RID: 144758 RVA: 0x0097F53C File Offset: 0x0097D73C
		// (set) Token: 0x06023577 RID: 144759 RVA: 0x0097F54C File Offset: 0x0097D74C
		public unsafe float fadeSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DownBurst_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DownBurst_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170045E0 RID: 17888
		// (get) Token: 0x06023578 RID: 144760 RVA: 0x0097F560 File Offset: 0x0097D760
		// (set) Token: 0x06023579 RID: 144761 RVA: 0x0097F599 File Offset: 0x0097D799
		[Nullable(1)]
		public TMap<AActor, float> BoundActorsOpacity
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<AActor, float> result;
				if ((result = this._BoundActorsOpacity) == null)
				{
					result = (this._BoundActorsOpacity = new TMap<AActor, float>(base.NativePtr + (IntPtr)BP_DownBurst_C.__PropertyOffset_17, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.BoundActorsOpacity.CopyAssign(value);
			}
		}

		// Token: 0x170045E1 RID: 17889
		// (get) Token: 0x0602357A RID: 144762 RVA: 0x0097F5A8 File Offset: 0x0097D7A8
		// (set) Token: 0x0602357B RID: 144763 RVA: 0x0097F5E1 File Offset: 0x0097D7E1
		[Nullable(1)]
		public TArray<AActor> BoundActorsArray
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._BoundActorsArray) == null)
				{
					result = (this._BoundActorsArray = new TArray<AActor>(base.NativePtr + (IntPtr)BP_DownBurst_C.__PropertyOffset_18, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.BoundActorsArray.CopyAssign(value);
			}
		}

		// Token: 0x170045E2 RID: 17890
		// (get) Token: 0x0602357C RID: 144764 RVA: 0x0097F5EF File Offset: 0x0097D7EF
		// (set) Token: 0x0602357D RID: 144765 RVA: 0x0097F5FF File Offset: 0x0097D7FF
		public unsafe float coldDownTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DownBurst_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DownBurst_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170045E3 RID: 17891
		// (get) Token: 0x0602357E RID: 144766 RVA: 0x0097F610 File Offset: 0x0097D810
		// (set) Token: 0x0602357F RID: 144767 RVA: 0x0097F620 File Offset: 0x0097D820
		public unsafe bool bPC
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DownBurst_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DownBurst_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x170045E4 RID: 17892
		// (get) Token: 0x06023580 RID: 144768 RVA: 0x0097F631 File Offset: 0x0097D831
		// (set) Token: 0x06023581 RID: 144769 RVA: 0x0097F645 File Offset: 0x0097D845
		public unsafe UKuroWeatherDataAsset WeatherDa
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroWeatherDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DownBurst_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DownBurst_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x170045E5 RID: 17893
		// (get) Token: 0x06023582 RID: 144770 RVA: 0x0097F65A File Offset: 0x0097D85A
		// (set) Token: 0x06023583 RID: 144771 RVA: 0x0097F66E File Offset: 0x0097D86E
		public unsafe AKuroPostProcessVolume Weather
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AKuroPostProcessVolume>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DownBurst_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DownBurst_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x170045E6 RID: 17894
		// (get) Token: 0x06023584 RID: 144772 RVA: 0x0097F683 File Offset: 0x0097D883
		// (set) Token: 0x06023585 RID: 144773 RVA: 0x0097F697 File Offset: 0x0097D897
		public unsafe UMaterialInterface DownburstMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DownBurst_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DownBurst_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x170045E7 RID: 17895
		// (get) Token: 0x06023586 RID: 144774 RVA: 0x0097F6AC File Offset: 0x0097D8AC
		// (set) Token: 0x06023587 RID: 144775 RVA: 0x0097F6C0 File Offset: 0x0097D8C0
		public unsafe UMaterialInstanceDynamic MID
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DownBurst_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DownBurst_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x06023588 RID: 144776 RVA: 0x0097F6D5 File Offset: 0x0097D8D5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CacheInitBoundOpacity()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DownBurst_C.__CacheInitBoundOpacity_NativeFunctionPtr, null);
		}

		// Token: 0x06023589 RID: 144777 RVA: 0x0097F6EC File Offset: 0x0097D8EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateBoundOpacity(float Blend_Weight)
		{
			BP_DownBurst_C.__UpdateBoundOpacity_FunctionParams* ptr = stackalloc BP_DownBurst_C.__UpdateBoundOpacity_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_DownBurst_C.__UpdateBoundOpacity_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DownBurst_C.__UpdateBoundOpacity_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Blend_Weight = Blend_Weight;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DownBurst_C.__UpdateBoundOpacity_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602358A RID: 144778 RVA: 0x0097F732 File Offset: 0x0097D932
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DownBurst_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602358B RID: 144779 RVA: 0x0097F746 File Offset: 0x0097D946
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DownBurst_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602358C RID: 144780 RVA: 0x0097F75C File Offset: 0x0097D95C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_DownBurst_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_DownBurst_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DownBurst_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DownBurst_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DownBurst_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602358D RID: 144781 RVA: 0x0097F7A4 File Offset: 0x0097D9A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_DownBurst_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_DownBurst_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DownBurst_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DownBurst_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DownBurst_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602358E RID: 144782 RVA: 0x0097F7EB File Offset: 0x0097D9EB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DownBurst_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0602358F RID: 144783 RVA: 0x0097F7FF File Offset: 0x0097D9FF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DownBurst_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023590 RID: 144784 RVA: 0x0097F814 File Offset: 0x0097DA14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_DownBurst_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_DownBurst_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_DownBurst_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DownBurst_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DownBurst_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023591 RID: 144785 RVA: 0x0097F860 File Offset: 0x0097DA60
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_DownBurst_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_DownBurst_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_DownBurst_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DownBurst_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DownBurst_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023592 RID: 144786 RVA: 0x0097F8AC File Offset: 0x0097DAAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_DownBurst(int EntryPoint)
		{
			BP_DownBurst_C.__ExecuteUbergraph_BP_DownBurst_FunctionParams* ptr = stackalloc BP_DownBurst_C.__ExecuteUbergraph_BP_DownBurst_FunctionParams[(UIntPtr)719] + 15L / (long)sizeof(BP_DownBurst_C.__ExecuteUbergraph_BP_DownBurst_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DownBurst_C.__ExecuteUbergraph_BP_DownBurst_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DownBurst_C.__ExecuteUbergraph_BP_DownBurst_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023593 RID: 144787 RVA: 0x0097F8F6 File Offset: 0x0097DAF6
		protected BP_DownBurst_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011F9F RID: 73631
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/DownBurst/BP_DownBurst.BP_DownBurst_C";

		// Token: 0x04011FA0 RID: 73632
		private static IntPtr _ClassPtr;

		// Token: 0x04011FA1 RID: 73633
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011FA2 RID: 73634
		internal static int __PropertyOffset_0;

		// Token: 0x04011FA3 RID: 73635
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011FA4 RID: 73636
		internal static int __PropertyOffset_1;

		// Token: 0x04011FA5 RID: 73637
		internal static int __PropertyOffset_2;

		// Token: 0x04011FA6 RID: 73638
		internal static int __PropertyOffset_3;

		// Token: 0x04011FA7 RID: 73639
		internal static int __PropertyOffset_4;

		// Token: 0x04011FA8 RID: 73640
		internal static int __PropertyOffset_5;

		// Token: 0x04011FA9 RID: 73641
		internal static int __PropertyOffset_6;

		// Token: 0x04011FAA RID: 73642
		internal static int __PropertyOffset_7;

		// Token: 0x04011FAB RID: 73643
		internal static int __PropertyOffset_8;

		// Token: 0x04011FAC RID: 73644
		internal static int __PropertyOffset_9;

		// Token: 0x04011FAD RID: 73645
		internal static int __PropertyOffset_10;

		// Token: 0x04011FAE RID: 73646
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TSet<AActor> _BoundActors;

		// Token: 0x04011FAF RID: 73647
		internal static int __PropertyOffset_11;

		// Token: 0x04011FB0 RID: 73648
		internal static int __PropertyOffset_12;

		// Token: 0x04011FB1 RID: 73649
		internal static int __PropertyOffset_13;

		// Token: 0x04011FB2 RID: 73650
		internal static int __PropertyOffset_14;

		// Token: 0x04011FB3 RID: 73651
		internal static int __PropertyOffset_15;

		// Token: 0x04011FB4 RID: 73652
		internal static int __PropertyOffset_16;

		// Token: 0x04011FB5 RID: 73653
		internal static int __PropertyOffset_17;

		// Token: 0x04011FB6 RID: 73654
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<AActor, float> _BoundActorsOpacity;

		// Token: 0x04011FB7 RID: 73655
		internal static int __PropertyOffset_18;

		// Token: 0x04011FB8 RID: 73656
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _BoundActorsArray;

		// Token: 0x04011FB9 RID: 73657
		internal static int __PropertyOffset_19;

		// Token: 0x04011FBA RID: 73658
		internal static int __PropertyOffset_20;

		// Token: 0x04011FBB RID: 73659
		internal static int __PropertyOffset_21;

		// Token: 0x04011FBC RID: 73660
		internal static int __PropertyOffset_22;

		// Token: 0x04011FBD RID: 73661
		internal static int __PropertyOffset_23;

		// Token: 0x04011FBE RID: 73662
		internal static int __PropertyOffset_24;

		// Token: 0x04011FBF RID: 73663
		private static IntPtr __CacheInitBoundOpacity_NativeFunctionPtr;

		// Token: 0x04011FC0 RID: 73664
		private static IntPtr __UpdateBoundOpacity_NativeFunctionPtr;

		// Token: 0x04011FC1 RID: 73665
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011FC2 RID: 73666
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011FC3 RID: 73667
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x04011FC4 RID: 73668
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04011FC5 RID: 73669
		private static IntPtr __ExecuteUbergraph_BP_DownBurst_NativeFunctionPtr;

		// Token: 0x02009CC3 RID: 40131
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __UpdateBoundOpacity_FunctionParams
		{
			// Token: 0x0403262E RID: 206382
			[FieldOffset(0)]
			public float Blend_Weight;
		}

		// Token: 0x02009CC4 RID: 40132
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403262F RID: 206383
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009CC5 RID: 40133
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04032630 RID: 206384
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009CC6 RID: 40134
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 704)]
		protected ref struct __ExecuteUbergraph_BP_DownBurst_FunctionParams
		{
			// Token: 0x04032631 RID: 206385
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
