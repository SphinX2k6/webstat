using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.RoadSpline
{
	// Token: 0x02003B94 RID: 15252
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/BP_ConveyorBelt.BP_ConveyorBelt_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1481)]
	public class BP_ConveyorBelt_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021D0C RID: 138508 RVA: 0x009544F0 File Offset: 0x009526F0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ConveyorBelt_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/BP_ConveyorBelt.BP_ConveyorBelt_C");
			}
			return BP_ConveyorBelt_C._ClassPtr;
		}

		// Token: 0x06021D0D RID: 138509 RVA: 0x00954514 File Offset: 0x00952714
		public BP_ConveyorBelt_C() : this(BuiltinUtils.AllocNativeUObject(BP_ConveyorBelt_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021D0E RID: 138510 RVA: 0x0095453C File Offset: 0x0095273C
		[NullableContext(1)]
		public BP_ConveyorBelt_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ConveyorBelt_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003D2D RID: 15661
		// (get) Token: 0x06021D0F RID: 138511 RVA: 0x00954570 File Offset: 0x00952770
		// (set) Token: 0x06021D10 RID: 138512 RVA: 0x009545A9 File Offset: 0x009527A9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_ConveyorBelt_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_ConveyorBelt_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003D2E RID: 15662
		// (get) Token: 0x06021D11 RID: 138513 RVA: 0x009545CA File Offset: 0x009527CA
		// (set) Token: 0x06021D12 RID: 138514 RVA: 0x009545DE File Offset: 0x009527DE
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConveyorBelt_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConveyorBelt_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003D2F RID: 15663
		// (get) Token: 0x06021D13 RID: 138515 RVA: 0x009545F3 File Offset: 0x009527F3
		// (set) Token: 0x06021D14 RID: 138516 RVA: 0x00954607 File Offset: 0x00952807
		public unsafe UStaticMeshComponent StaticMesh1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConveyorBelt_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConveyorBelt_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003D30 RID: 15664
		// (get) Token: 0x06021D15 RID: 138517 RVA: 0x0095461C File Offset: 0x0095281C
		// (set) Token: 0x06021D16 RID: 138518 RVA: 0x00954630 File Offset: 0x00952830
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConveyorBelt_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConveyorBelt_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003D31 RID: 15665
		// (get) Token: 0x06021D17 RID: 138519 RVA: 0x00954645 File Offset: 0x00952845
		// (set) Token: 0x06021D18 RID: 138520 RVA: 0x00954659 File Offset: 0x00952859
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConveyorBelt_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConveyorBelt_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003D32 RID: 15666
		// (get) Token: 0x06021D19 RID: 138521 RVA: 0x0095466E File Offset: 0x0095286E
		// (set) Token: 0x06021D1A RID: 138522 RVA: 0x00954682 File Offset: 0x00952882
		public unsafe UStaticMesh New_Mesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConveyorBelt_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConveyorBelt_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003D33 RID: 15667
		// (get) Token: 0x06021D1B RID: 138523 RVA: 0x00954697 File Offset: 0x00952897
		// (set) Token: 0x06021D1C RID: 138524 RVA: 0x009546A7 File Offset: 0x009528A7
		public unsafe float Length
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ConveyorBelt_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ConveyorBelt_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003D34 RID: 15668
		// (get) Token: 0x06021D1D RID: 138525 RVA: 0x009546B8 File Offset: 0x009528B8
		// (set) Token: 0x06021D1E RID: 138526 RVA: 0x009546C8 File Offset: 0x009528C8
		public unsafe float Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ConveyorBelt_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ConveyorBelt_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003D35 RID: 15669
		// (get) Token: 0x06021D1F RID: 138527 RVA: 0x009546D9 File Offset: 0x009528D9
		// (set) Token: 0x06021D20 RID: 138528 RVA: 0x009546E9 File Offset: 0x009528E9
		public unsafe float DeltaOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ConveyorBelt_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ConveyorBelt_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003D36 RID: 15670
		// (get) Token: 0x06021D21 RID: 138529 RVA: 0x009546FA File Offset: 0x009528FA
		// (set) Token: 0x06021D22 RID: 138530 RVA: 0x0095470A File Offset: 0x0095290A
		public unsafe bool Restart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ConveyorBelt_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ConveyorBelt_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003D37 RID: 15671
		// (get) Token: 0x06021D23 RID: 138531 RVA: 0x0095471C File Offset: 0x0095291C
		// (set) Token: 0x06021D24 RID: 138532 RVA: 0x00954755 File Offset: 0x00952955
		[Nullable(1)]
		public TMap<UStaticMeshComponent, bool> MeshState
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<UStaticMeshComponent, bool> result;
				if ((result = this._MeshState) == null)
				{
					result = (this._MeshState = new TMap<UStaticMeshComponent, bool>(base.NativePtr + (IntPtr)BP_ConveyorBelt_C.__PropertyOffset_10, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.MeshState.CopyAssign(value);
			}
		}

		// Token: 0x17003D38 RID: 15672
		// (get) Token: 0x06021D25 RID: 138533 RVA: 0x00954763 File Offset: 0x00952963
		// (set) Token: 0x06021D26 RID: 138534 RVA: 0x00954773 File Offset: 0x00952973
		public unsafe bool Tick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ConveyorBelt_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ConveyorBelt_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003D39 RID: 15673
		// (get) Token: 0x06021D27 RID: 138535 RVA: 0x00954784 File Offset: 0x00952984
		// (set) Token: 0x06021D28 RID: 138536 RVA: 0x00954798 File Offset: 0x00952998
		public unsafe FVector New_Location
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ConveyorBelt_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ConveyorBelt_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003D3A RID: 15674
		// (get) Token: 0x06021D29 RID: 138537 RVA: 0x009547AD File Offset: 0x009529AD
		// (set) Token: 0x06021D2A RID: 138538 RVA: 0x009547BD File Offset: 0x009529BD
		public unsafe bool LastState
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ConveyorBelt_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ConveyorBelt_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x06021D2B RID: 138539 RVA: 0x009547CE File Offset: 0x009529CE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void NewFunction_0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ConveyorBelt_C.__NewFunction_0_NativeFunctionPtr, null);
		}

		// Token: 0x06021D2C RID: 138540 RVA: 0x009547E2 File Offset: 0x009529E2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DisableTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ConveyorBelt_C.__DisableTick_NativeFunctionPtr, null);
		}

		// Token: 0x06021D2D RID: 138541 RVA: 0x009547F6 File Offset: 0x009529F6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EnableTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ConveyorBelt_C.__EnableTick_NativeFunctionPtr, null);
		}

		// Token: 0x06021D2E RID: 138542 RVA: 0x0095480A File Offset: 0x00952A0A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ConveyorBelt_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021D2F RID: 138543 RVA: 0x0095481E File Offset: 0x00952A1E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ConveyorBelt_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021D30 RID: 138544 RVA: 0x00954834 File Offset: 0x00952A34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_ConveyorBelt_Box_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_ConveyorBelt_C.__BndEvt__BP_ConveyorBelt_Box_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_ConveyorBelt_C.__BndEvt__BP_ConveyorBelt_Box_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_ConveyorBelt_C.__BndEvt__BP_ConveyorBelt_Box_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ConveyorBelt_C.__BndEvt__BP_ConveyorBelt_Box_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ConveyorBelt_C.__BndEvt__BP_ConveyorBelt_Box_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021D31 RID: 138545 RVA: 0x009548BD File Offset: 0x00952ABD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ConveyorBelt_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021D32 RID: 138546 RVA: 0x009548D1 File Offset: 0x00952AD1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ConveyorBelt_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021D33 RID: 138547 RVA: 0x009548E8 File Offset: 0x00952AE8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_ConveyorBelt_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ConveyorBelt_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ConveyorBelt_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ConveyorBelt_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ConveyorBelt_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021D34 RID: 138548 RVA: 0x00954930 File Offset: 0x00952B30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_ConveyorBelt_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ConveyorBelt_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ConveyorBelt_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ConveyorBelt_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ConveyorBelt_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021D35 RID: 138549 RVA: 0x00954978 File Offset: 0x00952B78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_ConveyorBelt_Box_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_ConveyorBelt_C.__BndEvt__BP_ConveyorBelt_Box_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_ConveyorBelt_C.__BndEvt__BP_ConveyorBelt_Box_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_ConveyorBelt_C.__BndEvt__BP_ConveyorBelt_Box_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ConveyorBelt_C.__BndEvt__BP_ConveyorBelt_Box_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ConveyorBelt_C.__BndEvt__BP_ConveyorBelt_Box_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021D36 RID: 138550 RVA: 0x00954A34 File Offset: 0x00952C34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_ConveyorBelt_C.__EditorTick_FunctionParams* ptr = stackalloc BP_ConveyorBelt_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ConveyorBelt_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ConveyorBelt_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ConveyorBelt_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021D37 RID: 138551 RVA: 0x00954A7C File Offset: 0x00952C7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_ConveyorBelt_C.__EditorTick_FunctionParams* ptr = stackalloc BP_ConveyorBelt_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ConveyorBelt_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ConveyorBelt_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ConveyorBelt_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021D38 RID: 138552 RVA: 0x00954AC4 File Offset: 0x00952CC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_ConveyorBelt(int EntryPoint)
		{
			BP_ConveyorBelt_C.__ExecuteUbergraph_BP_ConveyorBelt_FunctionParams* ptr = stackalloc BP_ConveyorBelt_C.__ExecuteUbergraph_BP_ConveyorBelt_FunctionParams[(UIntPtr)287] + 15L / (long)sizeof(BP_ConveyorBelt_C.__ExecuteUbergraph_BP_ConveyorBelt_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ConveyorBelt_C.__ExecuteUbergraph_BP_ConveyorBelt_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ConveyorBelt_C.__ExecuteUbergraph_BP_ConveyorBelt_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021D39 RID: 138553 RVA: 0x00954B0E File Offset: 0x00952D0E
		protected BP_ConveyorBelt_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011107 RID: 69895
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/BP_ConveyorBelt.BP_ConveyorBelt_C";

		// Token: 0x04011108 RID: 69896
		private static IntPtr _ClassPtr;

		// Token: 0x04011109 RID: 69897
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401110A RID: 69898
		internal static int __PropertyOffset_0;

		// Token: 0x0401110B RID: 69899
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401110C RID: 69900
		internal static int __PropertyOffset_1;

		// Token: 0x0401110D RID: 69901
		internal static int __PropertyOffset_2;

		// Token: 0x0401110E RID: 69902
		internal static int __PropertyOffset_3;

		// Token: 0x0401110F RID: 69903
		internal static int __PropertyOffset_4;

		// Token: 0x04011110 RID: 69904
		internal static int __PropertyOffset_5;

		// Token: 0x04011111 RID: 69905
		internal static int __PropertyOffset_6;

		// Token: 0x04011112 RID: 69906
		internal static int __PropertyOffset_7;

		// Token: 0x04011113 RID: 69907
		internal static int __PropertyOffset_8;

		// Token: 0x04011114 RID: 69908
		internal static int __PropertyOffset_9;

		// Token: 0x04011115 RID: 69909
		internal static int __PropertyOffset_10;

		// Token: 0x04011116 RID: 69910
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<UStaticMeshComponent, bool> _MeshState;

		// Token: 0x04011117 RID: 69911
		internal static int __PropertyOffset_11;

		// Token: 0x04011118 RID: 69912
		internal static int __PropertyOffset_12;

		// Token: 0x04011119 RID: 69913
		internal static int __PropertyOffset_13;

		// Token: 0x0401111A RID: 69914
		private static IntPtr __NewFunction_0_NativeFunctionPtr;

		// Token: 0x0401111B RID: 69915
		private static IntPtr __DisableTick_NativeFunctionPtr;

		// Token: 0x0401111C RID: 69916
		private static IntPtr __EnableTick_NativeFunctionPtr;

		// Token: 0x0401111D RID: 69917
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401111E RID: 69918
		private static IntPtr __BndEvt__BP_ConveyorBelt_Box_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401111F RID: 69919
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011120 RID: 69920
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011121 RID: 69921
		private static IntPtr __BndEvt__BP_ConveyorBelt_Box_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011122 RID: 69922
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04011123 RID: 69923
		private static IntPtr __ExecuteUbergraph_BP_ConveyorBelt_NativeFunctionPtr;

		// Token: 0x02009B55 RID: 39765
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_ConveyorBelt_Box_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032334 RID: 205620
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032335 RID: 205621
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032336 RID: 205622
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032337 RID: 205623
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009B56 RID: 39766
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032338 RID: 205624
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B57 RID: 39767
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_ConveyorBelt_Box_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032339 RID: 205625
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403233A RID: 205626
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403233B RID: 205627
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403233C RID: 205628
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x0403233D RID: 205629
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x0403233E RID: 205630
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009B58 RID: 39768
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x0403233F RID: 205631
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B59 RID: 39769
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 272)]
		protected ref struct __ExecuteUbergraph_BP_ConveyorBelt_FunctionParams
		{
			// Token: 0x04032340 RID: 205632
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
