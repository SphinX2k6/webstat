using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.InteractFoliage.Blueprint.MeshActor;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.InteractFoliage.Blueprint
{
	// Token: 0x02003AD2 RID: 15058
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/InteractFoliage/Blueprint/BP_InteractFoliageActor.BP_InteractFoliageActor_C")]
	[UnrealStructLayout(1456, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1456)]
	public class BP_InteractFoliageActor_C : BP_InteractFoliageActor_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602032F RID: 131887 RVA: 0x00925083 File Offset: 0x00923283
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_InteractFoliageActor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/InteractFoliage/Blueprint/BP_InteractFoliageActor.BP_InteractFoliageActor_C");
			}
			return BP_InteractFoliageActor_C._ClassPtr;
		}

		// Token: 0x06020330 RID: 131888 RVA: 0x009250A8 File Offset: 0x009232A8
		public BP_InteractFoliageActor_C() : this(BuiltinUtils.AllocNativeUObject(BP_InteractFoliageActor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020331 RID: 131889 RVA: 0x009250D0 File Offset: 0x009232D0
		[NullableContext(1)]
		public BP_InteractFoliageActor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_InteractFoliageActor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003464 RID: 13412
		// (get) Token: 0x06020332 RID: 131890 RVA: 0x00925104 File Offset: 0x00923304
		// (set) Token: 0x06020333 RID: 131891 RVA: 0x0092513D File Offset: 0x0092333D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_InteractFoliageActor_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_InteractFoliageActor_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003465 RID: 13413
		// (get) Token: 0x06020334 RID: 131892 RVA: 0x0092515E File Offset: 0x0092335E
		// (set) Token: 0x06020335 RID: 131893 RVA: 0x00925172 File Offset: 0x00923372
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractFoliageActor_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractFoliageActor_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003466 RID: 13414
		// (get) Token: 0x06020336 RID: 131894 RVA: 0x00925187 File Offset: 0x00923387
		// (set) Token: 0x06020337 RID: 131895 RVA: 0x0092519B File Offset: 0x0092339B
		public unsafe USkeletalMeshComponent SkeletalMeshFoliage
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractFoliageActor_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractFoliageActor_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003467 RID: 13415
		// (get) Token: 0x06020338 RID: 131896 RVA: 0x009251B0 File Offset: 0x009233B0
		// (set) Token: 0x06020339 RID: 131897 RVA: 0x009251C4 File Offset: 0x009233C4
		public unsafe UStaticMeshComponent StaticMeshFoliage
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractFoliageActor_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractFoliageActor_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003468 RID: 13416
		// (get) Token: 0x0602033A RID: 131898 RVA: 0x009251D9 File Offset: 0x009233D9
		// (set) Token: 0x0602033B RID: 131899 RVA: 0x009251E9 File Offset: 0x009233E9
		public unsafe bool bEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractFoliageActor_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractFoliageActor_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003469 RID: 13417
		// (get) Token: 0x0602033C RID: 131900 RVA: 0x009251FA File Offset: 0x009233FA
		// (set) Token: 0x0602033D RID: 131901 RVA: 0x0092520E File Offset: 0x0092340E
		public unsafe KUROInteractFoliage_C FoliageType
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<KUROInteractFoliage_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractFoliageActor_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractFoliageActor_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700346A RID: 13418
		// (get) Token: 0x0602033E RID: 131902 RVA: 0x00925223 File Offset: 0x00923423
		// (set) Token: 0x0602033F RID: 131903 RVA: 0x00925233 File Offset: 0x00923433
		public unsafe bool Active
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractFoliageActor_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractFoliageActor_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700346B RID: 13419
		// (get) Token: 0x06020340 RID: 131904 RVA: 0x00925244 File Offset: 0x00923444
		// (set) Token: 0x06020341 RID: 131905 RVA: 0x00925254 File Offset: 0x00923454
		public unsafe float TraceRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractFoliageActor_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractFoliageActor_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700346C RID: 13420
		// (get) Token: 0x06020342 RID: 131906 RVA: 0x00925265 File Offset: 0x00923465
		// (set) Token: 0x06020343 RID: 131907 RVA: 0x00925279 File Offset: 0x00923479
		public unsafe FTransform CharacterTransform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractFoliageActor_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractFoliageActor_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700346D RID: 13421
		// (get) Token: 0x06020344 RID: 131908 RVA: 0x00925290 File Offset: 0x00923490
		// (set) Token: 0x06020345 RID: 131909 RVA: 0x009252C9 File Offset: 0x009234C9
		[Nullable(1)]
		public TArray<float> Primitive_Data
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._Primitive_Data) == null)
				{
					result = (this._Primitive_Data = new TArray<float>(base.NativePtr + (IntPtr)BP_InteractFoliageActor_C.__PropertyOffset_9, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Primitive_Data.CopyAssign(value);
			}
		}

		// Token: 0x1700346E RID: 13422
		// (get) Token: 0x06020346 RID: 131910 RVA: 0x009252D7 File Offset: 0x009234D7
		// (set) Token: 0x06020347 RID: 131911 RVA: 0x009252E7 File Offset: 0x009234E7
		public unsafe float MinDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractFoliageActor_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractFoliageActor_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700346F RID: 13423
		// (get) Token: 0x06020348 RID: 131912 RVA: 0x009252F8 File Offset: 0x009234F8
		// (set) Token: 0x06020349 RID: 131913 RVA: 0x00925308 File Offset: 0x00923508
		public unsafe float MaxDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractFoliageActor_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractFoliageActor_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003470 RID: 13424
		// (get) Token: 0x0602034A RID: 131914 RVA: 0x00925319 File Offset: 0x00923519
		// (set) Token: 0x0602034B RID: 131915 RVA: 0x00925329 File Offset: 0x00923529
		public unsafe float TickTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractFoliageActor_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractFoliageActor_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003471 RID: 13425
		// (get) Token: 0x0602034C RID: 131916 RVA: 0x0092533A File Offset: 0x0092353A
		// (set) Token: 0x0602034D RID: 131917 RVA: 0x0092534A File Offset: 0x0092354A
		public unsafe float CachedQualityLevel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractFoliageActor_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractFoliageActor_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x0602034E RID: 131918 RVA: 0x0092535C File Offset: 0x0092355C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AdaptQualityLevel(ref bool bShouldTick)
		{
			BP_InteractFoliageActor_C.__AdaptQualityLevel_FunctionParams* ptr = stackalloc BP_InteractFoliageActor_C.__AdaptQualityLevel_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_InteractFoliageActor_C.__AdaptQualityLevel_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractFoliageActor_C.__AdaptQualityLevel_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bShouldTick = bShouldTick;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractFoliageActor_C.__AdaptQualityLevel_NativeFunctionPtr, (void*)ptr);
			bShouldTick = ptr->bShouldTick;
		}

		// Token: 0x0602034F RID: 131919 RVA: 0x009253AC File Offset: 0x009235AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ChangeActiveFoliageNum(float ChangeNum)
		{
			BP_InteractFoliageActor_C.__ChangeActiveFoliageNum_FunctionParams* ptr = stackalloc BP_InteractFoliageActor_C.__ChangeActiveFoliageNum_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_InteractFoliageActor_C.__ChangeActiveFoliageNum_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractFoliageActor_C.__ChangeActiveFoliageNum_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ChangeNum = ChangeNum;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractFoliageActor_C.__ChangeActiveFoliageNum_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020350 RID: 131920 RVA: 0x009253F2 File Offset: 0x009235F2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitialData()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractFoliageActor_C.__InitialData_NativeFunctionPtr, null);
		}

		// Token: 0x06020351 RID: 131921 RVA: 0x00925406 File Offset: 0x00923606
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractFoliageActor_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06020352 RID: 131922 RVA: 0x0092541A File Offset: 0x0092361A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteractFoliageActor_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020353 RID: 131923 RVA: 0x00925430 File Offset: 0x00923630
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_InteractFoliageActor_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_InteractFoliageActor_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InteractFoliageActor_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractFoliageActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractFoliageActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020354 RID: 131924 RVA: 0x00925478 File Offset: 0x00923678
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_InteractFoliageActor_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_InteractFoliageActor_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InteractFoliageActor_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractFoliageActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteractFoliageActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020355 RID: 131925 RVA: 0x009254BF File Offset: 0x009236BF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractFoliageActor_C.__CustomTick_NativeFunctionPtr, null);
		}

		// Token: 0x06020356 RID: 131926 RVA: 0x009254D3 File Offset: 0x009236D3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractFoliageActor_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020357 RID: 131927 RVA: 0x009254E7 File Offset: 0x009236E7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteractFoliageActor_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020358 RID: 131928 RVA: 0x009254FC File Offset: 0x009236FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CallChange(float Weight)
		{
			BP_InteractFoliageActor_C.__CallChange_FunctionParams* ptr = stackalloc BP_InteractFoliageActor_C.__CallChange_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InteractFoliageActor_C.__CallChange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractFoliageActor_C.__CallChange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Weight = Weight;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractFoliageActor_C.__CallChange_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020359 RID: 131929 RVA: 0x00925544 File Offset: 0x00923744
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_InteractFoliageActor_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_InteractFoliageActor_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_InteractFoliageActor_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractFoliageActor_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractFoliageActor_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602035A RID: 131930 RVA: 0x00925600 File Offset: 0x00923800
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_InteractFoliageActor_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_InteractFoliageActor_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_InteractFoliageActor_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractFoliageActor_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractFoliageActor_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602035B RID: 131931 RVA: 0x0092568C File Offset: 0x0092388C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_InteractFoliageActor(int EntryPoint)
		{
			BP_InteractFoliageActor_C.__ExecuteUbergraph_BP_InteractFoliageActor_FunctionParams* ptr = stackalloc BP_InteractFoliageActor_C.__ExecuteUbergraph_BP_InteractFoliageActor_FunctionParams[(UIntPtr)679] + 15L / (long)sizeof(BP_InteractFoliageActor_C.__ExecuteUbergraph_BP_InteractFoliageActor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractFoliageActor_C.__ExecuteUbergraph_BP_InteractFoliageActor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteractFoliageActor_C.__ExecuteUbergraph_BP_InteractFoliageActor_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602035C RID: 131932 RVA: 0x009256D6 File Offset: 0x009238D6
		protected BP_InteractFoliageActor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040100DC RID: 65756
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/InteractFoliage/Blueprint/BP_InteractFoliageActor.BP_InteractFoliageActor_C";

		// Token: 0x040100DD RID: 65757
		private static IntPtr _ClassPtr;

		// Token: 0x040100DE RID: 65758
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040100DF RID: 65759
		internal new static int __PropertyOffset_0;

		// Token: 0x040100E0 RID: 65760
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040100E1 RID: 65761
		internal static int __PropertyOffset_1;

		// Token: 0x040100E2 RID: 65762
		internal static int __PropertyOffset_2;

		// Token: 0x040100E3 RID: 65763
		internal static int __PropertyOffset_3;

		// Token: 0x040100E4 RID: 65764
		internal static int __PropertyOffset_4;

		// Token: 0x040100E5 RID: 65765
		internal static int __PropertyOffset_5;

		// Token: 0x040100E6 RID: 65766
		internal static int __PropertyOffset_6;

		// Token: 0x040100E7 RID: 65767
		internal static int __PropertyOffset_7;

		// Token: 0x040100E8 RID: 65768
		internal static int __PropertyOffset_8;

		// Token: 0x040100E9 RID: 65769
		internal static int __PropertyOffset_9;

		// Token: 0x040100EA RID: 65770
		private TArray<float> _Primitive_Data;

		// Token: 0x040100EB RID: 65771
		internal static int __PropertyOffset_10;

		// Token: 0x040100EC RID: 65772
		internal static int __PropertyOffset_11;

		// Token: 0x040100ED RID: 65773
		internal static int __PropertyOffset_12;

		// Token: 0x040100EE RID: 65774
		internal static int __PropertyOffset_13;

		// Token: 0x040100EF RID: 65775
		private static IntPtr __AdaptQualityLevel_NativeFunctionPtr;

		// Token: 0x040100F0 RID: 65776
		private static IntPtr __ChangeActiveFoliageNum_NativeFunctionPtr;

		// Token: 0x040100F1 RID: 65777
		private static IntPtr __InitialData_NativeFunctionPtr;

		// Token: 0x040100F2 RID: 65778
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040100F3 RID: 65779
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040100F4 RID: 65780
		private static IntPtr __CustomTick_NativeFunctionPtr;

		// Token: 0x040100F5 RID: 65781
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040100F6 RID: 65782
		private static IntPtr __CallChange_NativeFunctionPtr;

		// Token: 0x040100F7 RID: 65783
		private static IntPtr __BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040100F8 RID: 65784
		private static IntPtr __BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040100F9 RID: 65785
		private static IntPtr __ExecuteUbergraph_BP_InteractFoliageActor_NativeFunctionPtr;

		// Token: 0x02009971 RID: 39281
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __AdaptQualityLevel_FunctionParams
		{
			// Token: 0x04031FEF RID: 204783
			[FieldOffset(0)]
			public bool bShouldTick;
		}

		// Token: 0x02009972 RID: 39282
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __ChangeActiveFoliageNum_FunctionParams
		{
			// Token: 0x04031FF0 RID: 204784
			[FieldOffset(0)]
			public float ChangeNum;
		}

		// Token: 0x02009973 RID: 39283
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031FF1 RID: 204785
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009974 RID: 39284
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __CallChange_FunctionParams
		{
			// Token: 0x04031FF2 RID: 204786
			[FieldOffset(0)]
			public float Weight;
		}

		// Token: 0x02009975 RID: 39285
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04031FF3 RID: 204787
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04031FF4 RID: 204788
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04031FF5 RID: 204789
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04031FF6 RID: 204790
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04031FF7 RID: 204791
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04031FF8 RID: 204792
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009976 RID: 39286
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04031FF9 RID: 204793
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04031FFA RID: 204794
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04031FFB RID: 204795
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04031FFC RID: 204796
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009977 RID: 39287
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 664)]
		protected ref struct __ExecuteUbergraph_BP_InteractFoliageActor_FunctionParams
		{
			// Token: 0x04031FFD RID: 204797
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
