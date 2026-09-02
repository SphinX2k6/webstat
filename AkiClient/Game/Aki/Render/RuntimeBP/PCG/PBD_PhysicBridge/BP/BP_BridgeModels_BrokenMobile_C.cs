using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.PBD_PhysicBridge.BP
{
	// Token: 0x02003BAF RID: 15279
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/PBD_PhysicBridge/BP/BP_BridgeModels_BrokenMobile.BP_BridgeModels_BrokenMobile_C")]
	[UnrealStructLayout(1400, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1400)]
	public class BP_BridgeModels_BrokenMobile_C : AKuroBPActor, IUnrealUObject, IUnrealObject, IBPI_BridgeModels_BrokenMobile_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x0602212F RID: 139567 RVA: 0x0095B2BB File Offset: 0x009594BB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BridgeModels_BrokenMobile_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/PBD_PhysicBridge/BP/BP_BridgeModels_BrokenMobile.BP_BridgeModels_BrokenMobile_C");
			}
			return BP_BridgeModels_BrokenMobile_C._ClassPtr;
		}

		// Token: 0x06022130 RID: 139568 RVA: 0x0095B2E0 File Offset: 0x009594E0
		public BP_BridgeModels_BrokenMobile_C() : this(BuiltinUtils.AllocNativeUObject(BP_BridgeModels_BrokenMobile_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022131 RID: 139569 RVA: 0x0095B308 File Offset: 0x00959508
		[NullableContext(1)]
		public BP_BridgeModels_BrokenMobile_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BridgeModels_BrokenMobile_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003EB1 RID: 16049
		// (get) Token: 0x06022132 RID: 139570 RVA: 0x0095B33C File Offset: 0x0095953C
		// (set) Token: 0x06022133 RID: 139571 RVA: 0x0095B375 File Offset: 0x00959575
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_BridgeModels_BrokenMobile_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_BridgeModels_BrokenMobile_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003EB2 RID: 16050
		// (get) Token: 0x06022134 RID: 139572 RVA: 0x0095B396 File Offset: 0x00959596
		// (set) Token: 0x06022135 RID: 139573 RVA: 0x0095B3AA File Offset: 0x009595AA
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_BrokenMobile_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_BrokenMobile_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003EB3 RID: 16051
		// (get) Token: 0x06022136 RID: 139574 RVA: 0x0095B3BF File Offset: 0x009595BF
		// (set) Token: 0x06022137 RID: 139575 RVA: 0x0095B3D3 File Offset: 0x009595D3
		public unsafe UStaticMeshComponent SM_Gel_Pro_305AM_FX
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_BrokenMobile_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_BrokenMobile_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003EB4 RID: 16052
		// (get) Token: 0x06022138 RID: 139576 RVA: 0x0095B3E8 File Offset: 0x009595E8
		// (set) Token: 0x06022139 RID: 139577 RVA: 0x0095B3FC File Offset: 0x009595FC
		public unsafe UStaticMeshComponent SM_Gel_Pro_304AM_FX
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_BrokenMobile_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_BrokenMobile_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003EB5 RID: 16053
		// (get) Token: 0x0602213A RID: 139578 RVA: 0x0095B411 File Offset: 0x00959611
		// (set) Token: 0x0602213B RID: 139579 RVA: 0x0095B425 File Offset: 0x00959625
		public unsafe UStaticMeshComponent SM_MB_Gel_Bri_04TL
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_BrokenMobile_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_BrokenMobile_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003EB6 RID: 16054
		// (get) Token: 0x0602213C RID: 139580 RVA: 0x0095B43A File Offset: 0x0095963A
		// (set) Token: 0x0602213D RID: 139581 RVA: 0x0095B44E File Offset: 0x0095964E
		public unsafe UStaticMeshComponent SM_Gel_Bri_04IL
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_BrokenMobile_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_BrokenMobile_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003EB7 RID: 16055
		// (get) Token: 0x0602213E RID: 139582 RVA: 0x0095B463 File Offset: 0x00959663
		// (set) Token: 0x0602213F RID: 139583 RVA: 0x0095B477 File Offset: 0x00959677
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_BrokenMobile_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_BrokenMobile_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17003EB8 RID: 16056
		// (get) Token: 0x06022140 RID: 139584 RVA: 0x0095B48C File Offset: 0x0095968C
		// (set) Token: 0x06022141 RID: 139585 RVA: 0x0095B4C5 File Offset: 0x009596C5
		[Nullable(1)]
		public custom custom
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				custom result;
				if ((result = this._custom) == null)
				{
					result = (this._custom = new custom(base.NativePtr + (IntPtr)BP_BridgeModels_BrokenMobile_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_BridgeModels_BrokenMobile_C.__PropertyOffset_7, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17003EB9 RID: 16057
		// (get) Token: 0x06022142 RID: 139586 RVA: 0x0095B4E6 File Offset: 0x009596E6
		// (set) Token: 0x06022143 RID: 139587 RVA: 0x0095B4FA File Offset: 0x009596FA
		public unsafe FVector NewVar_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BridgeModels_BrokenMobile_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BridgeModels_BrokenMobile_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003EBA RID: 16058
		// (get) Token: 0x06022144 RID: 139588 RVA: 0x0095B50F File Offset: 0x0095970F
		// (set) Token: 0x06022145 RID: 139589 RVA: 0x0095B51F File Offset: 0x0095971F
		public unsafe float CustomTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BridgeModels_BrokenMobile_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BridgeModels_BrokenMobile_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003EBB RID: 16059
		// (get) Token: 0x06022146 RID: 139590 RVA: 0x0095B530 File Offset: 0x00959730
		// (set) Token: 0x06022147 RID: 139591 RVA: 0x0095B540 File Offset: 0x00959740
		public unsafe bool IsBroken
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BridgeModels_BrokenMobile_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BridgeModels_BrokenMobile_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003EBC RID: 16060
		// (get) Token: 0x06022148 RID: 139592 RVA: 0x0095B551 File Offset: 0x00959751
		// (set) Token: 0x06022149 RID: 139593 RVA: 0x0095B561 File Offset: 0x00959761
		public unsafe float InterpTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BridgeModels_BrokenMobile_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BridgeModels_BrokenMobile_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x0602214A RID: 139594 RVA: 0x0095B572 File Offset: 0x00959772
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BreakTest()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BridgeModels_BrokenMobile_C.__BreakTest_NativeFunctionPtr, null);
		}

		// Token: 0x0602214B RID: 139595 RVA: 0x0095B586 File Offset: 0x00959786
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Reset()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BridgeModels_BrokenMobile_C.__Reset_NativeFunctionPtr, null);
		}

		// Token: 0x0602214C RID: 139596 RVA: 0x0095B59C File Offset: 0x0095979C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetBridgeLink(int idx, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<UChildActorComponent> tempArray1)
		{
			BP_BridgeModels_BrokenMobile_C.__GetBridgeLink_FunctionParams* ptr = stackalloc BP_BridgeModels_BrokenMobile_C.__GetBridgeLink_FunctionParams[(UIntPtr)575] + 15L / (long)sizeof(BP_BridgeModels_BrokenMobile_C.__GetBridgeLink_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BridgeModels_BrokenMobile_C.__GetBridgeLink_NativeFunctionPtr, (void*)ptr, 1);
			ptr->idx = idx;
			TArray<UChildActorComponent> tarray = tempArray1;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->tempArray1);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BridgeModels_BrokenMobile_C.__GetBridgeLink_NativeFunctionPtr, (void*)ptr);
			TArray<UChildActorComponent> tarray2 = tempArray1;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->tempArray1);
			}
			UnrealReflectionUtils.DestroyStruct(BP_BridgeModels_BrokenMobile_C.__GetBridgeLink_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602214D RID: 139597 RVA: 0x0095B61E File Offset: 0x0095981E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BridgeModels_BrokenMobile_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602214E RID: 139598 RVA: 0x0095B632 File Offset: 0x00959832
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BridgeModels_BrokenMobile_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602214F RID: 139599 RVA: 0x0095B648 File Offset: 0x00959848
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Completed_92BA8E5D417BEAC0CD4FF88EAA5B9EC5(int PlayingID)
		{
			BP_BridgeModels_BrokenMobile_C.__Completed_92BA8E5D417BEAC0CD4FF88EAA5B9EC5_FunctionParams* ptr = stackalloc BP_BridgeModels_BrokenMobile_C.__Completed_92BA8E5D417BEAC0CD4FF88EAA5B9EC5_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BridgeModels_BrokenMobile_C.__Completed_92BA8E5D417BEAC0CD4FF88EAA5B9EC5_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BridgeModels_BrokenMobile_C.__Completed_92BA8E5D417BEAC0CD4FF88EAA5B9EC5_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PlayingID = PlayingID;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BridgeModels_BrokenMobile_C.__Completed_92BA8E5D417BEAC0CD4FF88EAA5B9EC5_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022150 RID: 139600 RVA: 0x0095B68E File Offset: 0x0095988E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BridgeModels_BrokenMobile_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022151 RID: 139601 RVA: 0x0095B6A2 File Offset: 0x009598A2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BridgeModels_BrokenMobile_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022152 RID: 139602 RVA: 0x0095B6B8 File Offset: 0x009598B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_BridgeModels_BrokenMobile_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BridgeModels_BrokenMobile_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BridgeModels_BrokenMobile_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BridgeModels_BrokenMobile_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BridgeModels_BrokenMobile_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022153 RID: 139603 RVA: 0x0095B700 File Offset: 0x00959900
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_BridgeModels_BrokenMobile_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BridgeModels_BrokenMobile_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BridgeModels_BrokenMobile_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BridgeModels_BrokenMobile_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BridgeModels_BrokenMobile_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022154 RID: 139604 RVA: 0x0095B747 File Offset: 0x00959947
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BreakEvent()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BridgeModels_BrokenMobile_C.__BreakEvent_NativeFunctionPtr, null);
		}

		// Token: 0x06022155 RID: 139605 RVA: 0x0095B75B File Offset: 0x0095995B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BreakTrigger()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BridgeModels_BrokenMobile_C.__BreakTrigger_NativeFunctionPtr, null);
		}

		// Token: 0x06022156 RID: 139606 RVA: 0x0095B770 File Offset: 0x00959970
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_BridgeModels_BrokenMobile_Box_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_BridgeModels_BrokenMobile_C.__BndEvt__BP_BridgeModels_BrokenMobile_Box_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_BridgeModels_BrokenMobile_C.__BndEvt__BP_BridgeModels_BrokenMobile_Box_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_BridgeModels_BrokenMobile_C.__BndEvt__BP_BridgeModels_BrokenMobile_Box_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BridgeModels_BrokenMobile_C.__BndEvt__BP_BridgeModels_BrokenMobile_Box_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BridgeModels_BrokenMobile_C.__BndEvt__BP_BridgeModels_BrokenMobile_Box_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022157 RID: 139607 RVA: 0x0095B82C File Offset: 0x00959A2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_BridgeModels_BrokenMobile_Box_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_BridgeModels_BrokenMobile_C.__BndEvt__BP_BridgeModels_BrokenMobile_Box_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_BridgeModels_BrokenMobile_C.__BndEvt__BP_BridgeModels_BrokenMobile_Box_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_BridgeModels_BrokenMobile_C.__BndEvt__BP_BridgeModels_BrokenMobile_Box_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BridgeModels_BrokenMobile_C.__BndEvt__BP_BridgeModels_BrokenMobile_Box_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BridgeModels_BrokenMobile_C.__BndEvt__BP_BridgeModels_BrokenMobile_Box_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022158 RID: 139608 RVA: 0x0095B8B8 File Offset: 0x00959AB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_BridgeModels_BrokenMobile(int EntryPoint)
		{
			BP_BridgeModels_BrokenMobile_C.__ExecuteUbergraph_BP_BridgeModels_BrokenMobile_FunctionParams* ptr = stackalloc BP_BridgeModels_BrokenMobile_C.__ExecuteUbergraph_BP_BridgeModels_BrokenMobile_FunctionParams[(UIntPtr)487] + 15L / (long)sizeof(BP_BridgeModels_BrokenMobile_C.__ExecuteUbergraph_BP_BridgeModels_BrokenMobile_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BridgeModels_BrokenMobile_C.__ExecuteUbergraph_BP_BridgeModels_BrokenMobile_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BridgeModels_BrokenMobile_C.__ExecuteUbergraph_BP_BridgeModels_BrokenMobile_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022159 RID: 139609 RVA: 0x0095B902 File Offset: 0x00959B02
		protected BP_BridgeModels_BrokenMobile_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011369 RID: 70505
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/PBD_PhysicBridge/BP/BP_BridgeModels_BrokenMobile.BP_BridgeModels_BrokenMobile_C";

		// Token: 0x0401136A RID: 70506
		private static IntPtr _ClassPtr;

		// Token: 0x0401136B RID: 70507
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401136C RID: 70508
		public static IntPtr __custom__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401136D RID: 70509
		internal static int __PropertyOffset_0;

		// Token: 0x0401136E RID: 70510
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401136F RID: 70511
		internal static int __PropertyOffset_1;

		// Token: 0x04011370 RID: 70512
		internal static int __PropertyOffset_2;

		// Token: 0x04011371 RID: 70513
		internal static int __PropertyOffset_3;

		// Token: 0x04011372 RID: 70514
		internal static int __PropertyOffset_4;

		// Token: 0x04011373 RID: 70515
		internal static int __PropertyOffset_5;

		// Token: 0x04011374 RID: 70516
		internal static int __PropertyOffset_6;

		// Token: 0x04011375 RID: 70517
		internal static int __PropertyOffset_7;

		// Token: 0x04011376 RID: 70518
		private custom _custom;

		// Token: 0x04011377 RID: 70519
		internal static int __PropertyOffset_8;

		// Token: 0x04011378 RID: 70520
		internal static int __PropertyOffset_9;

		// Token: 0x04011379 RID: 70521
		internal static int __PropertyOffset_10;

		// Token: 0x0401137A RID: 70522
		internal static int __PropertyOffset_11;

		// Token: 0x0401137B RID: 70523
		private static IntPtr __BreakTest_NativeFunctionPtr;

		// Token: 0x0401137C RID: 70524
		private static IntPtr __Reset_NativeFunctionPtr;

		// Token: 0x0401137D RID: 70525
		private static IntPtr __GetBridgeLink_NativeFunctionPtr;

		// Token: 0x0401137E RID: 70526
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401137F RID: 70527
		private static IntPtr __Completed_92BA8E5D417BEAC0CD4FF88EAA5B9EC5_NativeFunctionPtr;

		// Token: 0x04011380 RID: 70528
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011381 RID: 70529
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011382 RID: 70530
		private static IntPtr __BreakEvent_NativeFunctionPtr;

		// Token: 0x04011383 RID: 70531
		private static IntPtr __BreakTrigger_NativeFunctionPtr;

		// Token: 0x04011384 RID: 70532
		private static IntPtr __BndEvt__BP_BridgeModels_BrokenMobile_Box_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011385 RID: 70533
		private static IntPtr __BndEvt__BP_BridgeModels_BrokenMobile_Box_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011386 RID: 70534
		private static IntPtr __ExecuteUbergraph_BP_BridgeModels_BrokenMobile_NativeFunctionPtr;

		// Token: 0x02009B8A RID: 39818
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 560)]
		protected ref struct __GetBridgeLink_FunctionParams
		{
			// Token: 0x0403238C RID: 205708
			[FieldOffset(0)]
			public int idx;

			// Token: 0x0403238D RID: 205709
			[FieldOffset(8)]
			public byte tempArray1;
		}

		// Token: 0x02009B8B RID: 39819
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Completed_92BA8E5D417BEAC0CD4FF88EAA5B9EC5_FunctionParams
		{
			// Token: 0x0403238E RID: 205710
			[FieldOffset(0)]
			public int PlayingID;
		}

		// Token: 0x02009B8C RID: 39820
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403238F RID: 205711
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B8D RID: 39821
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_BridgeModels_BrokenMobile_Box_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032390 RID: 205712
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032391 RID: 205713
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032392 RID: 205714
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032393 RID: 205715
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04032394 RID: 205716
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032395 RID: 205717
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009B8E RID: 39822
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_BridgeModels_BrokenMobile_Box_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032396 RID: 205718
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032397 RID: 205719
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032398 RID: 205720
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032399 RID: 205721
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009B8F RID: 39823
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 472)]
		protected ref struct __ExecuteUbergraph_BP_BridgeModels_BrokenMobile_FunctionParams
		{
			// Token: 0x0403239A RID: 205722
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
