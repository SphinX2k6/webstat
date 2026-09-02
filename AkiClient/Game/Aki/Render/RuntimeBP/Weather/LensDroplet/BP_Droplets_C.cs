using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Weather.LensDroplet
{
	// Token: 0x020039FB RID: 14843
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Weather/LensDroplet/BP_Droplets.BP_Droplets_C")]
	[UnrealStructLayout(1552, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1552)]
	public class BP_Droplets_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E301 RID: 123649 RVA: 0x008EF071 File Offset: 0x008ED271
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Droplets_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Weather/LensDroplet/BP_Droplets.BP_Droplets_C");
			}
			return BP_Droplets_C._ClassPtr;
		}

		// Token: 0x0601E302 RID: 123650 RVA: 0x008EF098 File Offset: 0x008ED298
		public BP_Droplets_C() : this(BuiltinUtils.AllocNativeUObject(BP_Droplets_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E303 RID: 123651 RVA: 0x008EF0C0 File Offset: 0x008ED2C0
		[NullableContext(1)]
		public BP_Droplets_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Droplets_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170028DC RID: 10460
		// (get) Token: 0x0601E304 RID: 123652 RVA: 0x008EF0F4 File Offset: 0x008ED2F4
		// (set) Token: 0x0601E305 RID: 123653 RVA: 0x008EF12D File Offset: 0x008ED32D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170028DD RID: 10461
		// (get) Token: 0x0601E306 RID: 123654 RVA: 0x008EF14E File Offset: 0x008ED34E
		// (set) Token: 0x0601E307 RID: 123655 RVA: 0x008EF162 File Offset: 0x008ED362
		public unsafe UProceduralMeshComponent Droplets
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UProceduralMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Droplets_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Droplets_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170028DE RID: 10462
		// (get) Token: 0x0601E308 RID: 123656 RVA: 0x008EF177 File Offset: 0x008ED377
		// (set) Token: 0x0601E309 RID: 123657 RVA: 0x008EF18B File Offset: 0x008ED38B
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Droplets_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Droplets_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170028DF RID: 10463
		// (get) Token: 0x0601E30A RID: 123658 RVA: 0x008EF1A0 File Offset: 0x008ED3A0
		// (set) Token: 0x0601E30B RID: 123659 RVA: 0x008EF1B4 File Offset: 0x008ED3B4
		public unsafe UMaterialInstanceDynamic DropletDMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Droplets_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Droplets_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170028E0 RID: 10464
		// (get) Token: 0x0601E30C RID: 123660 RVA: 0x008EF1C9 File Offset: 0x008ED3C9
		// (set) Token: 0x0601E30D RID: 123661 RVA: 0x008EF1D9 File Offset: 0x008ED3D9
		public unsafe float time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170028E1 RID: 10465
		// (get) Token: 0x0601E30E RID: 123662 RVA: 0x008EF1EA File Offset: 0x008ED3EA
		// (set) Token: 0x0601E30F RID: 123663 RVA: 0x008EF1FA File Offset: 0x008ED3FA
		public unsafe bool Should_Spawn
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x170028E2 RID: 10466
		// (get) Token: 0x0601E310 RID: 123664 RVA: 0x008EF20B File Offset: 0x008ED40B
		// (set) Token: 0x0601E311 RID: 123665 RVA: 0x008EF21F File Offset: 0x008ED41F
		public unsafe FRandomStream RandomStream
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170028E3 RID: 10467
		// (get) Token: 0x0601E312 RID: 123666 RVA: 0x008EF234 File Offset: 0x008ED434
		// (set) Token: 0x0601E313 RID: 123667 RVA: 0x008EF248 File Offset: 0x008ED448
		public unsafe FVector RandPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170028E4 RID: 10468
		// (get) Token: 0x0601E314 RID: 123668 RVA: 0x008EF260 File Offset: 0x008ED460
		// (set) Token: 0x0601E315 RID: 123669 RVA: 0x008EF299 File Offset: 0x008ED499
		[Nullable(1)]
		public TArray<FVector> VertexBuffer
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._VertexBuffer) == null)
				{
					result = (this._VertexBuffer = new TArray<FVector>(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_8, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.VertexBuffer.CopyAssign(value);
			}
		}

		// Token: 0x170028E5 RID: 10469
		// (get) Token: 0x0601E316 RID: 123670 RVA: 0x008EF2A8 File Offset: 0x008ED4A8
		// (set) Token: 0x0601E317 RID: 123671 RVA: 0x008EF2E1 File Offset: 0x008ED4E1
		[Nullable(1)]
		public TArray<FVector2D> UV0Buffer
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVector2D> result;
				if ((result = this._UV0Buffer) == null)
				{
					result = (this._UV0Buffer = new TArray<FVector2D>(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_9, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.UV0Buffer.CopyAssign(value);
			}
		}

		// Token: 0x170028E6 RID: 10470
		// (get) Token: 0x0601E318 RID: 123672 RVA: 0x008EF2F0 File Offset: 0x008ED4F0
		// (set) Token: 0x0601E319 RID: 123673 RVA: 0x008EF329 File Offset: 0x008ED529
		[Nullable(1)]
		public TArray<FLinearColor> VertexColorBuffer
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FLinearColor> result;
				if ((result = this._VertexColorBuffer) == null)
				{
					result = (this._VertexColorBuffer = new TArray<FLinearColor>(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_10, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.VertexColorBuffer.CopyAssign(value);
			}
		}

		// Token: 0x170028E7 RID: 10471
		// (get) Token: 0x0601E31A RID: 123674 RVA: 0x008EF337 File Offset: 0x008ED537
		// (set) Token: 0x0601E31B RID: 123675 RVA: 0x008EF347 File Offset: 0x008ED547
		public unsafe int Int
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170028E8 RID: 10472
		// (get) Token: 0x0601E31C RID: 123676 RVA: 0x008EF358 File Offset: 0x008ED558
		// (set) Token: 0x0601E31D RID: 123677 RVA: 0x008EF36C File Offset: 0x008ED56C
		public unsafe FVectorDouble CurrCamPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170028E9 RID: 10473
		// (get) Token: 0x0601E31E RID: 123678 RVA: 0x008EF381 File Offset: 0x008ED581
		// (set) Token: 0x0601E31F RID: 123679 RVA: 0x008EF395 File Offset: 0x008ED595
		public unsafe FVectorDouble PrezCamPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170028EA RID: 10474
		// (get) Token: 0x0601E320 RID: 123680 RVA: 0x008EF3AA File Offset: 0x008ED5AA
		// (set) Token: 0x0601E321 RID: 123681 RVA: 0x008EF3BE File Offset: 0x008ED5BE
		public unsafe FVector CurrCamVec
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170028EB RID: 10475
		// (get) Token: 0x0601E322 RID: 123682 RVA: 0x008EF3D3 File Offset: 0x008ED5D3
		// (set) Token: 0x0601E323 RID: 123683 RVA: 0x008EF3E3 File Offset: 0x008ED5E3
		public unsafe bool IsEditor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x170028EC RID: 10476
		// (get) Token: 0x0601E324 RID: 123684 RVA: 0x008EF3F4 File Offset: 0x008ED5F4
		// (set) Token: 0x0601E325 RID: 123685 RVA: 0x008EF404 File Offset: 0x008ED604
		public unsafe float DropletIntensityMul
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170028ED RID: 10477
		// (get) Token: 0x0601E326 RID: 123686 RVA: 0x008EF415 File Offset: 0x008ED615
		// (set) Token: 0x0601E327 RID: 123687 RVA: 0x008EF425 File Offset: 0x008ED625
		public unsafe float Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170028EE RID: 10478
		// (get) Token: 0x0601E328 RID: 123688 RVA: 0x008EF436 File Offset: 0x008ED636
		// (set) Token: 0x0601E329 RID: 123689 RVA: 0x008EF446 File Offset: 0x008ED646
		public unsafe float Gravity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170028EF RID: 10479
		// (get) Token: 0x0601E32A RID: 123690 RVA: 0x008EF457 File Offset: 0x008ED657
		// (set) Token: 0x0601E32B RID: 123691 RVA: 0x008EF467 File Offset: 0x008ED667
		public unsafe float RainIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170028F0 RID: 10480
		// (get) Token: 0x0601E32C RID: 123692 RVA: 0x008EF478 File Offset: 0x008ED678
		// (set) Token: 0x0601E32D RID: 123693 RVA: 0x008EF48C File Offset: 0x008ED68C
		public unsafe UMaterialInterface DropletMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Droplets_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Droplets_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x170028F1 RID: 10481
		// (get) Token: 0x0601E32E RID: 123694 RVA: 0x008EF4A1 File Offset: 0x008ED6A1
		// (set) Token: 0x0601E32F RID: 123695 RVA: 0x008EF4B5 File Offset: 0x008ED6B5
		[Nullable(0)]
		public unsafe TEnumAsByte<EKuroRainType> RainType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_21);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x170028F2 RID: 10482
		// (get) Token: 0x0601E330 RID: 123696 RVA: 0x008EF4CA File Offset: 0x008ED6CA
		// (set) Token: 0x0601E331 RID: 123697 RVA: 0x008EF4DE File Offset: 0x008ED6DE
		public unsafe BP_LensDropletManager_C DropletManager
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_LensDropletManager_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Droplets_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Droplets_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x170028F3 RID: 10483
		// (get) Token: 0x0601E332 RID: 123698 RVA: 0x008EF4F3 File Offset: 0x008ED6F3
		// (set) Token: 0x0601E333 RID: 123699 RVA: 0x008EF503 File Offset: 0x008ED703
		public unsafe float Boost
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x170028F4 RID: 10484
		// (get) Token: 0x0601E334 RID: 123700 RVA: 0x008EF514 File Offset: 0x008ED714
		// (set) Token: 0x0601E335 RID: 123701 RVA: 0x008EF524 File Offset: 0x008ED724
		public unsafe float RandomRainDropSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Droplets_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x0601E336 RID: 123702 RVA: 0x008EF535 File Offset: 0x008ED735
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateParameters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Droplets_C.__UpdateParameters_NativeFunctionPtr, null);
		}

		// Token: 0x0601E337 RID: 123703 RVA: 0x008EF549 File Offset: 0x008ED749
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void MakeOneDroplet()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Droplets_C.__MakeOneDroplet_NativeFunctionPtr, null);
		}

		// Token: 0x0601E338 RID: 123704 RVA: 0x008EF55D File Offset: 0x008ED75D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Droplets_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601E339 RID: 123705 RVA: 0x008EF571 File Offset: 0x008ED771
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Droplets_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E33A RID: 123706 RVA: 0x008EF586 File Offset: 0x008ED786
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Droplets_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601E33B RID: 123707 RVA: 0x008EF59A File Offset: 0x008ED79A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Droplets_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E33C RID: 123708 RVA: 0x008EF5B0 File Offset: 0x008ED7B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Droplets_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Droplets_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Droplets_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Droplets_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Droplets_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E33D RID: 123709 RVA: 0x008EF5F8 File Offset: 0x008ED7F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Droplets_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Droplets_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Droplets_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Droplets_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Droplets_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E33E RID: 123710 RVA: 0x008EF640 File Offset: 0x008ED840
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_Droplets_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Droplets_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Droplets_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Droplets_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Droplets_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E33F RID: 123711 RVA: 0x008EF688 File Offset: 0x008ED888
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_Droplets_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Droplets_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Droplets_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Droplets_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Droplets_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E340 RID: 123712 RVA: 0x008EF6D0 File Offset: 0x008ED8D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Droplets(int EntryPoint)
		{
			BP_Droplets_C.__ExecuteUbergraph_BP_Droplets_FunctionParams* ptr = stackalloc BP_Droplets_C.__ExecuteUbergraph_BP_Droplets_FunctionParams[(UIntPtr)123] + 15L / (long)sizeof(BP_Droplets_C.__ExecuteUbergraph_BP_Droplets_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Droplets_C.__ExecuteUbergraph_BP_Droplets_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Droplets_C.__ExecuteUbergraph_BP_Droplets_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E341 RID: 123713 RVA: 0x008EF717 File Offset: 0x008ED917
		protected BP_Droplets_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400ED5B RID: 60763
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Weather/LensDroplet/BP_Droplets.BP_Droplets_C";

		// Token: 0x0400ED5C RID: 60764
		private static IntPtr _ClassPtr;

		// Token: 0x0400ED5D RID: 60765
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400ED5E RID: 60766
		internal static int __PropertyOffset_0;

		// Token: 0x0400ED5F RID: 60767
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400ED60 RID: 60768
		internal static int __PropertyOffset_1;

		// Token: 0x0400ED61 RID: 60769
		internal static int __PropertyOffset_2;

		// Token: 0x0400ED62 RID: 60770
		internal static int __PropertyOffset_3;

		// Token: 0x0400ED63 RID: 60771
		internal static int __PropertyOffset_4;

		// Token: 0x0400ED64 RID: 60772
		internal static int __PropertyOffset_5;

		// Token: 0x0400ED65 RID: 60773
		internal static int __PropertyOffset_6;

		// Token: 0x0400ED66 RID: 60774
		internal static int __PropertyOffset_7;

		// Token: 0x0400ED67 RID: 60775
		internal static int __PropertyOffset_8;

		// Token: 0x0400ED68 RID: 60776
		private TArray<FVector> _VertexBuffer;

		// Token: 0x0400ED69 RID: 60777
		internal static int __PropertyOffset_9;

		// Token: 0x0400ED6A RID: 60778
		private TArray<FVector2D> _UV0Buffer;

		// Token: 0x0400ED6B RID: 60779
		internal static int __PropertyOffset_10;

		// Token: 0x0400ED6C RID: 60780
		private TArray<FLinearColor> _VertexColorBuffer;

		// Token: 0x0400ED6D RID: 60781
		internal static int __PropertyOffset_11;

		// Token: 0x0400ED6E RID: 60782
		internal static int __PropertyOffset_12;

		// Token: 0x0400ED6F RID: 60783
		internal static int __PropertyOffset_13;

		// Token: 0x0400ED70 RID: 60784
		internal static int __PropertyOffset_14;

		// Token: 0x0400ED71 RID: 60785
		internal static int __PropertyOffset_15;

		// Token: 0x0400ED72 RID: 60786
		internal static int __PropertyOffset_16;

		// Token: 0x0400ED73 RID: 60787
		internal static int __PropertyOffset_17;

		// Token: 0x0400ED74 RID: 60788
		internal static int __PropertyOffset_18;

		// Token: 0x0400ED75 RID: 60789
		internal static int __PropertyOffset_19;

		// Token: 0x0400ED76 RID: 60790
		internal static int __PropertyOffset_20;

		// Token: 0x0400ED77 RID: 60791
		internal static int __PropertyOffset_21;

		// Token: 0x0400ED78 RID: 60792
		internal static int __PropertyOffset_22;

		// Token: 0x0400ED79 RID: 60793
		internal static int __PropertyOffset_23;

		// Token: 0x0400ED7A RID: 60794
		internal static int __PropertyOffset_24;

		// Token: 0x0400ED7B RID: 60795
		private static IntPtr __UpdateParameters_NativeFunctionPtr;

		// Token: 0x0400ED7C RID: 60796
		private static IntPtr __MakeOneDroplet_NativeFunctionPtr;

		// Token: 0x0400ED7D RID: 60797
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400ED7E RID: 60798
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400ED7F RID: 60799
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400ED80 RID: 60800
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400ED81 RID: 60801
		private static IntPtr __ExecuteUbergraph_BP_Droplets_NativeFunctionPtr;

		// Token: 0x02009784 RID: 38788
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031D3B RID: 204091
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009785 RID: 38789
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031D3C RID: 204092
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009786 RID: 38790
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 108)]
		protected ref struct __ExecuteUbergraph_BP_Droplets_FunctionParams
		{
			// Token: 0x04031D3D RID: 204093
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
