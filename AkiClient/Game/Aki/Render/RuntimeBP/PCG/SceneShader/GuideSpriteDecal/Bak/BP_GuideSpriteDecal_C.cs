using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SceneShader.GuideSpriteDecal.Bak
{
	// Token: 0x02003B7F RID: 15231
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SceneShader/GuideSpriteDecal/Bak/BP_GuideSpriteDecal.BP_GuideSpriteDecal_C")]
	[UnrealStructLayout(1432, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1426)]
	public class BP_GuideSpriteDecal_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060219CD RID: 137677 RVA: 0x0094DFCF File Offset: 0x0094C1CF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_GuideSpriteDecal_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SceneShader/GuideSpriteDecal/Bak/BP_GuideSpriteDecal.BP_GuideSpriteDecal_C");
			}
			return BP_GuideSpriteDecal_C._ClassPtr;
		}

		// Token: 0x060219CE RID: 137678 RVA: 0x0094DFF4 File Offset: 0x0094C1F4
		public BP_GuideSpriteDecal_C() : this(BuiltinUtils.AllocNativeUObject(BP_GuideSpriteDecal_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060219CF RID: 137679 RVA: 0x0094E01C File Offset: 0x0094C21C
		[NullableContext(1)]
		public BP_GuideSpriteDecal_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_GuideSpriteDecal_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003C14 RID: 15380
		// (get) Token: 0x060219D0 RID: 137680 RVA: 0x0094E050 File Offset: 0x0094C250
		// (set) Token: 0x060219D1 RID: 137681 RVA: 0x0094E089 File Offset: 0x0094C289
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_GuideSpriteDecal_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003C15 RID: 15381
		// (get) Token: 0x060219D2 RID: 137682 RVA: 0x0094E0AA File Offset: 0x0094C2AA
		// (set) Token: 0x060219D3 RID: 137683 RVA: 0x0094E0BE File Offset: 0x0094C2BE
		public unsafe UBoxComponent TriggerBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003C16 RID: 15382
		// (get) Token: 0x060219D4 RID: 137684 RVA: 0x0094E0D3 File Offset: 0x0094C2D3
		// (set) Token: 0x060219D5 RID: 137685 RVA: 0x0094E0E7 File Offset: 0x0094C2E7
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003C17 RID: 15383
		// (get) Token: 0x060219D6 RID: 137686 RVA: 0x0094E0FC File Offset: 0x0094C2FC
		// (set) Token: 0x060219D7 RID: 137687 RVA: 0x0094E110 File Offset: 0x0094C310
		public unsafe FVector Collision_Box_Extent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17003C18 RID: 15384
		// (get) Token: 0x060219D8 RID: 137688 RVA: 0x0094E125 File Offset: 0x0094C325
		// (set) Token: 0x060219D9 RID: 137689 RVA: 0x0094E135 File Offset: 0x0094C335
		public unsafe float Progress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003C19 RID: 15385
		// (get) Token: 0x060219DA RID: 137690 RVA: 0x0094E146 File Offset: 0x0094C346
		// (set) Token: 0x060219DB RID: 137691 RVA: 0x0094E156 File Offset: 0x0094C356
		public unsafe float DeltaSeconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003C1A RID: 15386
		// (get) Token: 0x060219DC RID: 137692 RVA: 0x0094E167 File Offset: 0x0094C367
		// (set) Token: 0x060219DD RID: 137693 RVA: 0x0094E177 File Offset: 0x0094C377
		public unsafe bool bShouldMove
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003C1B RID: 15387
		// (get) Token: 0x060219DE RID: 137694 RVA: 0x0094E188 File Offset: 0x0094C388
		// (set) Token: 0x060219DF RID: 137695 RVA: 0x0094E198 File Offset: 0x0094C398
		public unsafe float Progress_Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003C1C RID: 15388
		// (get) Token: 0x060219E0 RID: 137696 RVA: 0x0094E1A9 File Offset: 0x0094C3A9
		// (set) Token: 0x060219E1 RID: 137697 RVA: 0x0094E1BE File Offset: 0x0094C3BE
		[Nullable(1)]
		public TSoftObjectPtr<ADecalActor> Decal
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<ADecalActor>(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_C.__PropertyOffset_8, this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_C.__PropertyOffset_8, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17003C1D RID: 15389
		// (get) Token: 0x060219E2 RID: 137698 RVA: 0x0094E1E3 File Offset: 0x0094C3E3
		// (set) Token: 0x060219E3 RID: 137699 RVA: 0x0094E1F7 File Offset: 0x0094C3F7
		public unsafe UMaterialInstanceDynamic DMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17003C1E RID: 15390
		// (get) Token: 0x060219E4 RID: 137700 RVA: 0x0094E20C File Offset: 0x0094C40C
		// (set) Token: 0x060219E5 RID: 137701 RVA: 0x0094E21C File Offset: 0x0094C41C
		public unsafe bool Debug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003C1F RID: 15391
		// (get) Token: 0x060219E6 RID: 137702 RVA: 0x0094E22D File Offset: 0x0094C42D
		// (set) Token: 0x060219E7 RID: 137703 RVA: 0x0094E23D File Offset: 0x0094C43D
		public unsafe bool Debug_One
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x060219E8 RID: 137704 RVA: 0x0094E24E File Offset: 0x0094C44E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Initialize()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuideSpriteDecal_C.__Initialize_NativeFunctionPtr, null);
		}

		// Token: 0x060219E9 RID: 137705 RVA: 0x0094E262 File Offset: 0x0094C462
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_ProgressSeconds()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuideSpriteDecal_C.__Set_ProgressSeconds_NativeFunctionPtr, null);
		}

		// Token: 0x060219EA RID: 137706 RVA: 0x0094E276 File Offset: 0x0094C476
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuideSpriteDecal_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060219EB RID: 137707 RVA: 0x0094E28A File Offset: 0x0094C48A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GuideSpriteDecal_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060219EC RID: 137708 RVA: 0x0094E2A0 File Offset: 0x0094C4A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnLoaded_367A92FD4EA8FCCD11F1B3BEAC615927(UObject Loaded)
		{
			BP_GuideSpriteDecal_C.__OnLoaded_367A92FD4EA8FCCD11F1B3BEAC615927_FunctionParams* ptr = stackalloc BP_GuideSpriteDecal_C.__OnLoaded_367A92FD4EA8FCCD11F1B3BEAC615927_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_GuideSpriteDecal_C.__OnLoaded_367A92FD4EA8FCCD11F1B3BEAC615927_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GuideSpriteDecal_C.__OnLoaded_367A92FD4EA8FCCD11F1B3BEAC615927_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Loaded = ((Loaded != null) ? Loaded.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuideSpriteDecal_C.__OnLoaded_367A92FD4EA8FCCD11F1B3BEAC615927_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060219ED RID: 137709 RVA: 0x0094E2F5 File Offset: 0x0094C4F5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuideSpriteDecal_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060219EE RID: 137710 RVA: 0x0094E309 File Offset: 0x0094C509
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GuideSpriteDecal_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060219EF RID: 137711 RVA: 0x0094E320 File Offset: 0x0094C520
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_GuideSpriteDecal_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_GuideSpriteDecal_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GuideSpriteDecal_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GuideSpriteDecal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuideSpriteDecal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060219F0 RID: 137712 RVA: 0x0094E368 File Offset: 0x0094C568
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_GuideSpriteDecal_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_GuideSpriteDecal_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GuideSpriteDecal_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GuideSpriteDecal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GuideSpriteDecal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060219F1 RID: 137713 RVA: 0x0094E3B0 File Offset: 0x0094C5B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_GuideSpriteDecal_C.__EditorTick_FunctionParams* ptr = stackalloc BP_GuideSpriteDecal_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GuideSpriteDecal_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GuideSpriteDecal_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuideSpriteDecal_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060219F2 RID: 137714 RVA: 0x0094E3F8 File Offset: 0x0094C5F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_GuideSpriteDecal_C.__EditorTick_FunctionParams* ptr = stackalloc BP_GuideSpriteDecal_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GuideSpriteDecal_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GuideSpriteDecal_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GuideSpriteDecal_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060219F3 RID: 137715 RVA: 0x0094E440 File Offset: 0x0094C640
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_GuideSprote_TriggerBox_K2Node_ComponentBoundEvent_3_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_GuideSpriteDecal_C.__BndEvt__BP_GuideSprote_TriggerBox_K2Node_ComponentBoundEvent_3_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_GuideSpriteDecal_C.__BndEvt__BP_GuideSprote_TriggerBox_K2Node_ComponentBoundEvent_3_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_GuideSpriteDecal_C.__BndEvt__BP_GuideSprote_TriggerBox_K2Node_ComponentBoundEvent_3_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GuideSpriteDecal_C.__BndEvt__BP_GuideSprote_TriggerBox_K2Node_ComponentBoundEvent_3_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuideSpriteDecal_C.__BndEvt__BP_GuideSprote_TriggerBox_K2Node_ComponentBoundEvent_3_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060219F4 RID: 137716 RVA: 0x0094E4FC File Offset: 0x0094C6FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_GuideSprote_TriggerBox_K2Node_ComponentBoundEvent_4_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_GuideSpriteDecal_C.__BndEvt__BP_GuideSprote_TriggerBox_K2Node_ComponentBoundEvent_4_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_GuideSpriteDecal_C.__BndEvt__BP_GuideSprote_TriggerBox_K2Node_ComponentBoundEvent_4_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_GuideSpriteDecal_C.__BndEvt__BP_GuideSprote_TriggerBox_K2Node_ComponentBoundEvent_4_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GuideSpriteDecal_C.__BndEvt__BP_GuideSprote_TriggerBox_K2Node_ComponentBoundEvent_4_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuideSpriteDecal_C.__BndEvt__BP_GuideSprote_TriggerBox_K2Node_ComponentBoundEvent_4_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060219F5 RID: 137717 RVA: 0x0094E588 File Offset: 0x0094C788
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_GuideSpriteDecal(int EntryPoint)
		{
			BP_GuideSpriteDecal_C.__ExecuteUbergraph_BP_GuideSpriteDecal_FunctionParams* ptr = stackalloc BP_GuideSpriteDecal_C.__ExecuteUbergraph_BP_GuideSpriteDecal_FunctionParams[(UIntPtr)367] + 15L / (long)sizeof(BP_GuideSpriteDecal_C.__ExecuteUbergraph_BP_GuideSpriteDecal_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GuideSpriteDecal_C.__ExecuteUbergraph_BP_GuideSpriteDecal_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GuideSpriteDecal_C.__ExecuteUbergraph_BP_GuideSpriteDecal_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060219F6 RID: 137718 RVA: 0x0094E5D2 File Offset: 0x0094C7D2
		protected BP_GuideSpriteDecal_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010F03 RID: 69379
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SceneShader/GuideSpriteDecal/Bak/BP_GuideSpriteDecal.BP_GuideSpriteDecal_C";

		// Token: 0x04010F04 RID: 69380
		private static IntPtr _ClassPtr;

		// Token: 0x04010F05 RID: 69381
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010F06 RID: 69382
		internal static int __PropertyOffset_0;

		// Token: 0x04010F07 RID: 69383
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010F08 RID: 69384
		internal static int __PropertyOffset_1;

		// Token: 0x04010F09 RID: 69385
		internal static int __PropertyOffset_2;

		// Token: 0x04010F0A RID: 69386
		internal static int __PropertyOffset_3;

		// Token: 0x04010F0B RID: 69387
		internal static int __PropertyOffset_4;

		// Token: 0x04010F0C RID: 69388
		internal static int __PropertyOffset_5;

		// Token: 0x04010F0D RID: 69389
		internal static int __PropertyOffset_6;

		// Token: 0x04010F0E RID: 69390
		internal static int __PropertyOffset_7;

		// Token: 0x04010F0F RID: 69391
		internal static int __PropertyOffset_8;

		// Token: 0x04010F10 RID: 69392
		internal static int __PropertyOffset_9;

		// Token: 0x04010F11 RID: 69393
		internal static int __PropertyOffset_10;

		// Token: 0x04010F12 RID: 69394
		internal static int __PropertyOffset_11;

		// Token: 0x04010F13 RID: 69395
		private static IntPtr __Initialize_NativeFunctionPtr;

		// Token: 0x04010F14 RID: 69396
		private static IntPtr __Set_ProgressSeconds_NativeFunctionPtr;

		// Token: 0x04010F15 RID: 69397
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010F16 RID: 69398
		private static IntPtr __OnLoaded_367A92FD4EA8FCCD11F1B3BEAC615927_NativeFunctionPtr;

		// Token: 0x04010F17 RID: 69399
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010F18 RID: 69400
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010F19 RID: 69401
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010F1A RID: 69402
		private static IntPtr __BndEvt__BP_GuideSprote_TriggerBox_K2Node_ComponentBoundEvent_3_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010F1B RID: 69403
		private static IntPtr __BndEvt__BP_GuideSprote_TriggerBox_K2Node_ComponentBoundEvent_4_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010F1C RID: 69404
		private static IntPtr __ExecuteUbergraph_BP_GuideSpriteDecal_NativeFunctionPtr;

		// Token: 0x02009B03 RID: 39683
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __OnLoaded_367A92FD4EA8FCCD11F1B3BEAC615927_FunctionParams
		{
			// Token: 0x040322A3 RID: 205475
			[FieldOffset(0)]
			public IntPtr Loaded;
		}

		// Token: 0x02009B04 RID: 39684
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040322A4 RID: 205476
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B05 RID: 39685
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040322A5 RID: 205477
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B06 RID: 39686
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_GuideSprote_TriggerBox_K2Node_ComponentBoundEvent_3_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040322A6 RID: 205478
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040322A7 RID: 205479
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040322A8 RID: 205480
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040322A9 RID: 205481
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040322AA RID: 205482
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040322AB RID: 205483
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009B07 RID: 39687
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_GuideSprote_TriggerBox_K2Node_ComponentBoundEvent_4_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040322AC RID: 205484
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040322AD RID: 205485
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040322AE RID: 205486
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040322AF RID: 205487
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009B08 RID: 39688
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 352)]
		protected ref struct __ExecuteUbergraph_BP_GuideSpriteDecal_FunctionParams
		{
			// Token: 0x040322B0 RID: 205488
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
