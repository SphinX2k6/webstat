using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SandTrail
{
	// Token: 0x02003B90 RID: 15248
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SandTrail/BPC_ShachongTrail.BPC_ShachongTrail_C")]
	[UnrealStructLayout(624, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 620)]
	public class BPC_ShachongTrail_C : UKuroBPActorComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021C73 RID: 138355 RVA: 0x0095325B File Offset: 0x0095145B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BPC_ShachongTrail_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SandTrail/BPC_ShachongTrail.BPC_ShachongTrail_C");
			}
			return BPC_ShachongTrail_C._ClassPtr;
		}

		// Token: 0x06021C74 RID: 138356 RVA: 0x00953280 File Offset: 0x00951480
		public BPC_ShachongTrail_C() : this(BuiltinUtils.AllocNativeUObject(BPC_ShachongTrail_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021C75 RID: 138357 RVA: 0x009532A8 File Offset: 0x009514A8
		public BPC_ShachongTrail_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BPC_ShachongTrail_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003CF7 RID: 15607
		// (get) Token: 0x06021C76 RID: 138358 RVA: 0x009532DC File Offset: 0x009514DC
		// (set) Token: 0x06021C77 RID: 138359 RVA: 0x00953315 File Offset: 0x00951515
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003CF8 RID: 15608
		// (get) Token: 0x06021C78 RID: 138360 RVA: 0x00953336 File Offset: 0x00951536
		// (set) Token: 0x06021C79 RID: 138361 RVA: 0x00953346 File Offset: 0x00951546
		public unsafe bool bEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003CF9 RID: 15609
		// (get) Token: 0x06021C7A RID: 138362 RVA: 0x00953357 File Offset: 0x00951557
		// (set) Token: 0x06021C7B RID: 138363 RVA: 0x0095336B File Offset: 0x0095156B
		[Nullable(2)]
		public unsafe UMaterialInstanceDynamic MDI
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BPC_ShachongTrail_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BPC_ShachongTrail_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003CFA RID: 15610
		// (get) Token: 0x06021C7C RID: 138364 RVA: 0x00953380 File Offset: 0x00951580
		// (set) Token: 0x06021C7D RID: 138365 RVA: 0x00953394 File Offset: 0x00951594
		[Nullable(2)]
		public unsafe UMaterialInstanceDynamic MDI_pre
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BPC_ShachongTrail_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BPC_ShachongTrail_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003CFB RID: 15611
		// (get) Token: 0x06021C7E RID: 138366 RVA: 0x009533AC File Offset: 0x009515AC
		// (set) Token: 0x06021C7F RID: 138367 RVA: 0x009533E5 File Offset: 0x009515E5
		public TArray<FName> BoundBones
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._BoundBones) == null)
				{
					result = (this._BoundBones = new TArray<FName>(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.BoundBones.CopyAssign(value);
			}
		}

		// Token: 0x17003CFC RID: 15612
		// (get) Token: 0x06021C80 RID: 138368 RVA: 0x009533F4 File Offset: 0x009515F4
		// (set) Token: 0x06021C81 RID: 138369 RVA: 0x0095342D File Offset: 0x0095162D
		public TArray<float> tempWeights
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._tempWeights) == null)
				{
					result = (this._tempWeights = new TArray<float>(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				this.tempWeights.CopyAssign(value);
			}
		}

		// Token: 0x17003CFD RID: 15613
		// (get) Token: 0x06021C82 RID: 138370 RVA: 0x0095343B File Offset: 0x0095163B
		// (set) Token: 0x06021C83 RID: 138371 RVA: 0x0095344B File Offset: 0x0095164B
		public unsafe double FadeDistanceMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003CFE RID: 15614
		// (get) Token: 0x06021C84 RID: 138372 RVA: 0x0095345C File Offset: 0x0095165C
		// (set) Token: 0x06021C85 RID: 138373 RVA: 0x0095346C File Offset: 0x0095166C
		public unsafe double FadeDistanceMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003CFF RID: 15615
		// (get) Token: 0x06021C86 RID: 138374 RVA: 0x0095347D File Offset: 0x0095167D
		// (set) Token: 0x06021C87 RID: 138375 RVA: 0x0095348D File Offset: 0x0095168D
		public unsafe float tempVelocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003D00 RID: 15616
		// (get) Token: 0x06021C88 RID: 138376 RVA: 0x009534A0 File Offset: 0x009516A0
		// (set) Token: 0x06021C89 RID: 138377 RVA: 0x009534D9 File Offset: 0x009516D9
		public TMap<FName, float> BoundBonesVelocity
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._BoundBonesVelocity) == null)
				{
					result = (this._BoundBonesVelocity = new TMap<FName, float>(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				this.BoundBonesVelocity.CopyAssign(value);
			}
		}

		// Token: 0x17003D01 RID: 15617
		// (get) Token: 0x06021C8A RID: 138378 RVA: 0x009534E8 File Offset: 0x009516E8
		// (set) Token: 0x06021C8B RID: 138379 RVA: 0x00953521 File Offset: 0x00951721
		public TMap<FName, FVector> BoundBonesHitPos
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FVector> result;
				if ((result = this._BoundBonesHitPos) == null)
				{
					result = (this._BoundBonesHitPos = new TMap<FName, FVector>(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				this.BoundBonesHitPos.CopyAssign(value);
			}
		}

		// Token: 0x17003D02 RID: 15618
		// (get) Token: 0x06021C8C RID: 138380 RVA: 0x0095352F File Offset: 0x0095172F
		// (set) Token: 0x06021C8D RID: 138381 RVA: 0x0095353F File Offset: 0x0095173F
		public unsafe float WorldSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003D03 RID: 15619
		// (get) Token: 0x06021C8E RID: 138382 RVA: 0x00953550 File Offset: 0x00951750
		// (set) Token: 0x06021C8F RID: 138383 RVA: 0x00953564 File Offset: 0x00951764
		[Nullable(2)]
		public unsafe USkeletalMeshComponent Skeletal_Mesh_Component
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BPC_ShachongTrail_C.__PropertyOffset_12);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BPC_ShachongTrail_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17003D04 RID: 15620
		// (get) Token: 0x06021C90 RID: 138384 RVA: 0x00953579 File Offset: 0x00951779
		// (set) Token: 0x06021C91 RID: 138385 RVA: 0x0095358D File Offset: 0x0095178D
		public unsafe FVector LastPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003D05 RID: 15621
		// (get) Token: 0x06021C92 RID: 138386 RVA: 0x009535A2 File Offset: 0x009517A2
		// (set) Token: 0x06021C93 RID: 138387 RVA: 0x009535B6 File Offset: 0x009517B6
		public unsafe FVectorDouble SkeletalMeshPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17003D06 RID: 15622
		// (get) Token: 0x06021C94 RID: 138388 RVA: 0x009535CB File Offset: 0x009517CB
		// (set) Token: 0x06021C95 RID: 138389 RVA: 0x009535DF File Offset: 0x009517DF
		[Nullable(2)]
		public unsafe AActor Shachong
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BPC_ShachongTrail_C.__PropertyOffset_15);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BPC_ShachongTrail_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17003D07 RID: 15623
		// (get) Token: 0x06021C96 RID: 138390 RVA: 0x009535F4 File Offset: 0x009517F4
		// (set) Token: 0x06021C97 RID: 138391 RVA: 0x00953608 File Offset: 0x00951808
		public unsafe FLinearColor tempColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17003D08 RID: 15624
		// (get) Token: 0x06021C98 RID: 138392 RVA: 0x0095361D File Offset: 0x0095181D
		// (set) Token: 0x06021C99 RID: 138393 RVA: 0x0095362D File Offset: 0x0095182D
		public unsafe float fadespeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17003D09 RID: 15625
		// (get) Token: 0x06021C9A RID: 138394 RVA: 0x0095363E File Offset: 0x0095183E
		// (set) Token: 0x06021C9B RID: 138395 RVA: 0x00953652 File Offset: 0x00951852
		public unsafe FVector SandHitPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17003D0A RID: 15626
		// (get) Token: 0x06021C9C RID: 138396 RVA: 0x00953667 File Offset: 0x00951867
		// (set) Token: 0x06021C9D RID: 138397 RVA: 0x00953677 File Offset: 0x00951877
		public unsafe float VelocityRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17003D0B RID: 15627
		// (get) Token: 0x06021C9E RID: 138398 RVA: 0x00953688 File Offset: 0x00951888
		// (set) Token: 0x06021C9F RID: 138399 RVA: 0x00953698 File Offset: 0x00951898
		public unsafe float MaxWeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17003D0C RID: 15628
		// (get) Token: 0x06021CA0 RID: 138400 RVA: 0x009536A9 File Offset: 0x009518A9
		// (set) Token: 0x06021CA1 RID: 138401 RVA: 0x009536B9 File Offset: 0x009518B9
		public unsafe float MinWeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17003D0D RID: 15629
		// (get) Token: 0x06021CA2 RID: 138402 RVA: 0x009536CA File Offset: 0x009518CA
		// (set) Token: 0x06021CA3 RID: 138403 RVA: 0x009536DE File Offset: 0x009518DE
		public unsafe FVector ActivePosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17003D0E RID: 15630
		// (get) Token: 0x06021CA4 RID: 138404 RVA: 0x009536F4 File Offset: 0x009518F4
		// (set) Token: 0x06021CA5 RID: 138405 RVA: 0x0095372D File Offset: 0x0095192D
		public TArray<FName> BoundBonesMatparams
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._BoundBonesMatparams) == null)
				{
					result = (this._BoundBonesMatparams = new TArray<FName>(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_23, this));
				}
				return result;
			}
			set
			{
				this.BoundBonesMatparams.CopyAssign(value);
			}
		}

		// Token: 0x17003D0F RID: 15631
		// (get) Token: 0x06021CA6 RID: 138406 RVA: 0x0095373B File Offset: 0x0095193B
		// (set) Token: 0x06021CA7 RID: 138407 RVA: 0x0095374B File Offset: 0x0095194B
		public unsafe float MaxHitHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17003D10 RID: 15632
		// (get) Token: 0x06021CA8 RID: 138408 RVA: 0x0095375C File Offset: 0x0095195C
		// (set) Token: 0x06021CA9 RID: 138409 RVA: 0x00953770 File Offset: 0x00951970
		public unsafe FVector WorldOrigin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17003D11 RID: 15633
		// (get) Token: 0x06021CAA RID: 138410 RVA: 0x00953785 File Offset: 0x00951985
		// (set) Token: 0x06021CAB RID: 138411 RVA: 0x00953795 File Offset: 0x00951995
		public unsafe int NowQuality
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_ShachongTrail_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x06021CAC RID: 138412 RVA: 0x009537A6 File Offset: 0x009519A6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Clear()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BPC_ShachongTrail_C.__Clear_NativeFunctionPtr, null);
		}

		// Token: 0x06021CAD RID: 138413 RVA: 0x009537BC File Offset: 0x009519BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual float CaclChacaterAttenuation(FVector InVec)
		{
			BPC_ShachongTrail_C.__CaclChacaterAttenuation_FunctionParams* ptr = stackalloc BPC_ShachongTrail_C.__CaclChacaterAttenuation_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BPC_ShachongTrail_C.__CaclChacaterAttenuation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPC_ShachongTrail_C.__CaclChacaterAttenuation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InVec = InVec;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BPC_ShachongTrail_C.__CaclChacaterAttenuation_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x06021CAE RID: 138414 RVA: 0x0095380B File Offset: 0x00951A0B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BPC_ShachongTrail_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021CAF RID: 138415 RVA: 0x0095381F File Offset: 0x00951A1F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BPC_ShachongTrail_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021CB0 RID: 138416 RVA: 0x00953834 File Offset: 0x00951A34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BPC_ShachongTrail_C.__ReceiveTick_FunctionParams* ptr = stackalloc BPC_ShachongTrail_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BPC_ShachongTrail_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPC_ShachongTrail_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BPC_ShachongTrail_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021CB1 RID: 138417 RVA: 0x0095387C File Offset: 0x00951A7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BPC_ShachongTrail_C.__ReceiveTick_FunctionParams* ptr = stackalloc BPC_ShachongTrail_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BPC_ShachongTrail_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPC_ShachongTrail_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BPC_ShachongTrail_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021CB2 RID: 138418 RVA: 0x009538C4 File Offset: 0x00951AC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BPC_ShachongTrail_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BPC_ShachongTrail_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BPC_ShachongTrail_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPC_ShachongTrail_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BPC_ShachongTrail_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021CB3 RID: 138419 RVA: 0x00953910 File Offset: 0x00951B10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BPC_ShachongTrail_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BPC_ShachongTrail_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BPC_ShachongTrail_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPC_ShachongTrail_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BPC_ShachongTrail_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021CB4 RID: 138420 RVA: 0x0095395C File Offset: 0x00951B5C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateQualitySwitch()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BPC_ShachongTrail_C.__UpdateQualitySwitch_NativeFunctionPtr, null);
		}

		// Token: 0x06021CB5 RID: 138421 RVA: 0x00953970 File Offset: 0x00951B70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BPC_ShachongTrail(int EntryPoint)
		{
			BPC_ShachongTrail_C.__ExecuteUbergraph_BPC_ShachongTrail_FunctionParams* ptr = stackalloc BPC_ShachongTrail_C.__ExecuteUbergraph_BPC_ShachongTrail_FunctionParams[(UIntPtr)1199] + 15L / (long)sizeof(BPC_ShachongTrail_C.__ExecuteUbergraph_BPC_ShachongTrail_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPC_ShachongTrail_C.__ExecuteUbergraph_BPC_ShachongTrail_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BPC_ShachongTrail_C.__ExecuteUbergraph_BPC_ShachongTrail_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021CB6 RID: 138422 RVA: 0x009539BA File Offset: 0x00951BBA
		protected BPC_ShachongTrail_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040110A7 RID: 69799
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SandTrail/BPC_ShachongTrail.BPC_ShachongTrail_C";

		// Token: 0x040110A8 RID: 69800
		private static IntPtr _ClassPtr;

		// Token: 0x040110A9 RID: 69801
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040110AA RID: 69802
		internal static int __PropertyOffset_0;

		// Token: 0x040110AB RID: 69803
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040110AC RID: 69804
		internal static int __PropertyOffset_1;

		// Token: 0x040110AD RID: 69805
		internal static int __PropertyOffset_2;

		// Token: 0x040110AE RID: 69806
		internal static int __PropertyOffset_3;

		// Token: 0x040110AF RID: 69807
		internal static int __PropertyOffset_4;

		// Token: 0x040110B0 RID: 69808
		[Nullable(2)]
		private TArray<FName> _BoundBones;

		// Token: 0x040110B1 RID: 69809
		internal static int __PropertyOffset_5;

		// Token: 0x040110B2 RID: 69810
		[Nullable(2)]
		private TArray<float> _tempWeights;

		// Token: 0x040110B3 RID: 69811
		internal static int __PropertyOffset_6;

		// Token: 0x040110B4 RID: 69812
		internal static int __PropertyOffset_7;

		// Token: 0x040110B5 RID: 69813
		internal static int __PropertyOffset_8;

		// Token: 0x040110B6 RID: 69814
		internal static int __PropertyOffset_9;

		// Token: 0x040110B7 RID: 69815
		[Nullable(2)]
		private TMap<FName, float> _BoundBonesVelocity;

		// Token: 0x040110B8 RID: 69816
		internal static int __PropertyOffset_10;

		// Token: 0x040110B9 RID: 69817
		[Nullable(2)]
		private TMap<FName, FVector> _BoundBonesHitPos;

		// Token: 0x040110BA RID: 69818
		internal static int __PropertyOffset_11;

		// Token: 0x040110BB RID: 69819
		internal static int __PropertyOffset_12;

		// Token: 0x040110BC RID: 69820
		internal static int __PropertyOffset_13;

		// Token: 0x040110BD RID: 69821
		internal static int __PropertyOffset_14;

		// Token: 0x040110BE RID: 69822
		internal static int __PropertyOffset_15;

		// Token: 0x040110BF RID: 69823
		internal static int __PropertyOffset_16;

		// Token: 0x040110C0 RID: 69824
		internal static int __PropertyOffset_17;

		// Token: 0x040110C1 RID: 69825
		internal static int __PropertyOffset_18;

		// Token: 0x040110C2 RID: 69826
		internal static int __PropertyOffset_19;

		// Token: 0x040110C3 RID: 69827
		internal static int __PropertyOffset_20;

		// Token: 0x040110C4 RID: 69828
		internal static int __PropertyOffset_21;

		// Token: 0x040110C5 RID: 69829
		internal static int __PropertyOffset_22;

		// Token: 0x040110C6 RID: 69830
		internal static int __PropertyOffset_23;

		// Token: 0x040110C7 RID: 69831
		[Nullable(2)]
		private TArray<FName> _BoundBonesMatparams;

		// Token: 0x040110C8 RID: 69832
		internal static int __PropertyOffset_24;

		// Token: 0x040110C9 RID: 69833
		internal static int __PropertyOffset_25;

		// Token: 0x040110CA RID: 69834
		internal static int __PropertyOffset_26;

		// Token: 0x040110CB RID: 69835
		private static IntPtr __Clear_NativeFunctionPtr;

		// Token: 0x040110CC RID: 69836
		private static IntPtr __CaclChacaterAttenuation_NativeFunctionPtr;

		// Token: 0x040110CD RID: 69837
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040110CE RID: 69838
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040110CF RID: 69839
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x040110D0 RID: 69840
		private static IntPtr __UpdateQualitySwitch_NativeFunctionPtr;

		// Token: 0x040110D1 RID: 69841
		private static IntPtr __ExecuteUbergraph_BPC_ShachongTrail_NativeFunctionPtr;

		// Token: 0x02009B47 RID: 39751
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __CaclChacaterAttenuation_FunctionParams
		{
			// Token: 0x04032325 RID: 205605
			[FieldOffset(0)]
			public FVector InVec;

			// Token: 0x04032326 RID: 205606
			[FieldOffset(12)]
			public float __Result;
		}

		// Token: 0x02009B48 RID: 39752
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032327 RID: 205607
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B49 RID: 39753
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04032328 RID: 205608
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009B4A RID: 39754
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1184)]
		protected ref struct __ExecuteUbergraph_BPC_ShachongTrail_FunctionParams
		{
			// Token: 0x04032329 RID: 205609
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
