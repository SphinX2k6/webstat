using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.YangYangBirds
{
	// Token: 0x020039F6 RID: 14838
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/YangYangBirds/BP_YangYangBirdsSpawnerComponent.BP_YangYangBirdsSpawnerComponent_C")]
	[UnrealStructLayout(704, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 702)]
	public class BP_YangYangBirdsSpawnerComponent_C : USceneComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E275 RID: 123509 RVA: 0x008EDE53 File Offset: 0x008EC053
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_YangYangBirdsSpawnerComponent_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/YangYangBirds/BP_YangYangBirdsSpawnerComponent.BP_YangYangBirdsSpawnerComponent_C");
			}
			return BP_YangYangBirdsSpawnerComponent_C._ClassPtr;
		}

		// Token: 0x0601E276 RID: 123510 RVA: 0x008EDE78 File Offset: 0x008EC078
		public BP_YangYangBirdsSpawnerComponent_C() : this(BuiltinUtils.AllocNativeUObject(BP_YangYangBirdsSpawnerComponent_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E277 RID: 123511 RVA: 0x008EDEA0 File Offset: 0x008EC0A0
		public BP_YangYangBirdsSpawnerComponent_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_YangYangBirdsSpawnerComponent_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170028B8 RID: 10424
		// (get) Token: 0x0601E278 RID: 123512 RVA: 0x008EDED4 File Offset: 0x008EC0D4
		// (set) Token: 0x0601E279 RID: 123513 RVA: 0x008EDF0D File Offset: 0x008EC10D
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170028B9 RID: 10425
		// (get) Token: 0x0601E27A RID: 123514 RVA: 0x008EDF2E File Offset: 0x008EC12E
		// (set) Token: 0x0601E27B RID: 123515 RVA: 0x008EDF42 File Offset: 0x008EC142
		[Nullable(2)]
		public unsafe BP_YangYangBirds_C BirdsActor
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_YangYangBirds_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170028BA RID: 10426
		// (get) Token: 0x0601E27C RID: 123516 RVA: 0x008EDF57 File Offset: 0x008EC157
		// (set) Token: 0x0601E27D RID: 123517 RVA: 0x008EDF6B File Offset: 0x008EC16B
		[Nullable(2)]
		public unsafe BP_YangyangBirdssss_Skill_C SkillBirdsActor
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_YangyangBirdssss_Skill_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170028BB RID: 10427
		// (get) Token: 0x0601E27E RID: 123518 RVA: 0x008EDF80 File Offset: 0x008EC180
		// (set) Token: 0x0601E27F RID: 123519 RVA: 0x008EDFB9 File Offset: 0x008EC1B9
		public TArray<FVectorDouble> Points
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVectorDouble> result;
				if ((result = this._Points) == null)
				{
					result = (this._Points = new TArray<FVectorDouble>(base.NativePtr + (IntPtr)BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.Points.CopyAssign(value);
			}
		}

		// Token: 0x170028BC RID: 10428
		// (get) Token: 0x0601E280 RID: 123520 RVA: 0x008EDFC7 File Offset: 0x008EC1C7
		// (set) Token: 0x0601E281 RID: 123521 RVA: 0x008EDFD7 File Offset: 0x008EC1D7
		public unsafe int LoopCounter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170028BD RID: 10429
		// (get) Token: 0x0601E282 RID: 123522 RVA: 0x008EDFE8 File Offset: 0x008EC1E8
		// (set) Token: 0x0601E283 RID: 123523 RVA: 0x008EDFF8 File Offset: 0x008EC1F8
		public unsafe float StartCounter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170028BE RID: 10430
		// (get) Token: 0x0601E284 RID: 123524 RVA: 0x008EE009 File Offset: 0x008EC209
		// (set) Token: 0x0601E285 RID: 123525 RVA: 0x008EE01D File Offset: 0x008EC21D
		public unsafe FVectorDouble MovementBoundMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170028BF RID: 10431
		// (get) Token: 0x0601E286 RID: 123526 RVA: 0x008EE032 File Offset: 0x008EC232
		// (set) Token: 0x0601E287 RID: 123527 RVA: 0x008EE046 File Offset: 0x008EC246
		public unsafe FVectorDouble MovementBoundMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170028C0 RID: 10432
		// (get) Token: 0x0601E288 RID: 123528 RVA: 0x008EE05B File Offset: 0x008EC25B
		// (set) Token: 0x0601E289 RID: 123529 RVA: 0x008EE06B File Offset: 0x008EC26B
		public unsafe bool BirdsPendingDestroy
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x170028C1 RID: 10433
		// (get) Token: 0x0601E28A RID: 123530 RVA: 0x008EE07C File Offset: 0x008EC27C
		// (set) Token: 0x0601E28B RID: 123531 RVA: 0x008EE08C File Offset: 0x008EC28C
		public unsafe bool BirdsPendingSpawn
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x170028C2 RID: 10434
		// (get) Token: 0x0601E28C RID: 123532 RVA: 0x008EE09D File Offset: 0x008EC29D
		// (set) Token: 0x0601E28D RID: 123533 RVA: 0x008EE0AD File Offset: 0x008EC2AD
		public unsafe float LastTimeDestroyBirds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170028C3 RID: 10435
		// (get) Token: 0x0601E28E RID: 123534 RVA: 0x008EE0BE File Offset: 0x008EC2BE
		// (set) Token: 0x0601E28F RID: 123535 RVA: 0x008EE0CE File Offset: 0x008EC2CE
		public unsafe float LastTimeSpawnBirds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170028C4 RID: 10436
		// (get) Token: 0x0601E290 RID: 123536 RVA: 0x008EE0DF File Offset: 0x008EC2DF
		// (set) Token: 0x0601E291 RID: 123537 RVA: 0x008EE0EF File Offset: 0x008EC2EF
		public unsafe float IntervalBetweenSpawns
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170028C5 RID: 10437
		// (get) Token: 0x0601E292 RID: 123538 RVA: 0x008EE100 File Offset: 0x008EC300
		// (set) Token: 0x0601E293 RID: 123539 RVA: 0x008EE110 File Offset: 0x008EC310
		public unsafe float MaxBirdsLiveTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170028C6 RID: 10438
		// (get) Token: 0x0601E294 RID: 123540 RVA: 0x008EE121 File Offset: 0x008EC321
		// (set) Token: 0x0601E295 RID: 123541 RVA: 0x008EE131 File Offset: 0x008EC331
		public unsafe bool ForceSpawnBirds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x170028C7 RID: 10439
		// (get) Token: 0x0601E296 RID: 123542 RVA: 0x008EE142 File Offset: 0x008EC342
		// (set) Token: 0x0601E297 RID: 123543 RVA: 0x008EE152 File Offset: 0x008EC352
		public unsafe bool IsPlayingSkill
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_YangYangBirdsSpawnerComponent_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601E298 RID: 123544 RVA: 0x008EE164 File Offset: 0x008EC364
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CalcShouldSpawnOrDestroyBirds(float DeltaTime)
		{
			BP_YangYangBirdsSpawnerComponent_C.__CalcShouldSpawnOrDestroyBirds_FunctionParams* ptr = stackalloc BP_YangYangBirdsSpawnerComponent_C.__CalcShouldSpawnOrDestroyBirds_FunctionParams[(UIntPtr)431] + 15L / (long)sizeof(BP_YangYangBirdsSpawnerComponent_C.__CalcShouldSpawnOrDestroyBirds_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_YangYangBirdsSpawnerComponent_C.__CalcShouldSpawnOrDestroyBirds_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_YangYangBirdsSpawnerComponent_C.__CalcShouldSpawnOrDestroyBirds_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E299 RID: 123545 RVA: 0x008EE1AD File Offset: 0x008EC3AD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DestroyBirds()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_YangYangBirdsSpawnerComponent_C.__DestroyBirds_NativeFunctionPtr, null);
		}

		// Token: 0x0601E29A RID: 123546 RVA: 0x008EE1C1 File Offset: 0x008EC3C1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SpawnBirds()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_YangYangBirdsSpawnerComponent_C.__SpawnBirds_NativeFunctionPtr, null);
		}

		// Token: 0x0601E29B RID: 123547 RVA: 0x008EE1D5 File Offset: 0x008EC3D5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_YangYangBirdsSpawnerComponent_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601E29C RID: 123548 RVA: 0x008EE1E9 File Offset: 0x008EC3E9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_YangYangBirdsSpawnerComponent_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E29D RID: 123549 RVA: 0x008EE200 File Offset: 0x008EC400
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_YangYangBirdsSpawnerComponent_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_YangYangBirdsSpawnerComponent_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_YangYangBirdsSpawnerComponent_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_YangYangBirdsSpawnerComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_YangYangBirdsSpawnerComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E29E RID: 123550 RVA: 0x008EE248 File Offset: 0x008EC448
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_YangYangBirdsSpawnerComponent_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_YangYangBirdsSpawnerComponent_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_YangYangBirdsSpawnerComponent_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_YangYangBirdsSpawnerComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_YangYangBirdsSpawnerComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E29F RID: 123551 RVA: 0x008EE28F File Offset: 0x008EC48F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SpawnSkillBirds()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_YangYangBirdsSpawnerComponent_C.__SpawnSkillBirds_NativeFunctionPtr, null);
		}

		// Token: 0x0601E2A0 RID: 123552 RVA: 0x008EE2A3 File Offset: 0x008EC4A3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DestroySkillBirds()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_YangYangBirdsSpawnerComponent_C.__DestroySkillBirds_NativeFunctionPtr, null);
		}

		// Token: 0x0601E2A1 RID: 123553 RVA: 0x008EE2B8 File Offset: 0x008EC4B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_YangYangBirdsSpawnerComponent_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_YangYangBirdsSpawnerComponent_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_YangYangBirdsSpawnerComponent_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_YangYangBirdsSpawnerComponent_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_YangYangBirdsSpawnerComponent_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E2A2 RID: 123554 RVA: 0x008EE304 File Offset: 0x008EC504
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_YangYangBirdsSpawnerComponent_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_YangYangBirdsSpawnerComponent_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_YangYangBirdsSpawnerComponent_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_YangYangBirdsSpawnerComponent_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_YangYangBirdsSpawnerComponent_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E2A3 RID: 123555 RVA: 0x008EE350 File Offset: 0x008EC550
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_YangYangBirdsSpawnerComponent(int EntryPoint)
		{
			BP_YangYangBirdsSpawnerComponent_C.__ExecuteUbergraph_BP_YangYangBirdsSpawnerComponent_FunctionParams* ptr = stackalloc BP_YangYangBirdsSpawnerComponent_C.__ExecuteUbergraph_BP_YangYangBirdsSpawnerComponent_FunctionParams[(UIntPtr)383] + 15L / (long)sizeof(BP_YangYangBirdsSpawnerComponent_C.__ExecuteUbergraph_BP_YangYangBirdsSpawnerComponent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_YangYangBirdsSpawnerComponent_C.__ExecuteUbergraph_BP_YangYangBirdsSpawnerComponent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_YangYangBirdsSpawnerComponent_C.__ExecuteUbergraph_BP_YangYangBirdsSpawnerComponent_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E2A4 RID: 123556 RVA: 0x008EE39A File Offset: 0x008EC59A
		protected BP_YangYangBirdsSpawnerComponent_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400ED00 RID: 60672
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/YangYangBirds/BP_YangYangBirdsSpawnerComponent.BP_YangYangBirdsSpawnerComponent_C";

		// Token: 0x0400ED01 RID: 60673
		private static IntPtr _ClassPtr;

		// Token: 0x0400ED02 RID: 60674
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400ED03 RID: 60675
		internal static int __PropertyOffset_0;

		// Token: 0x0400ED04 RID: 60676
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400ED05 RID: 60677
		internal static int __PropertyOffset_1;

		// Token: 0x0400ED06 RID: 60678
		internal static int __PropertyOffset_2;

		// Token: 0x0400ED07 RID: 60679
		internal static int __PropertyOffset_3;

		// Token: 0x0400ED08 RID: 60680
		[Nullable(2)]
		private TArray<FVectorDouble> _Points;

		// Token: 0x0400ED09 RID: 60681
		internal static int __PropertyOffset_4;

		// Token: 0x0400ED0A RID: 60682
		internal static int __PropertyOffset_5;

		// Token: 0x0400ED0B RID: 60683
		internal static int __PropertyOffset_6;

		// Token: 0x0400ED0C RID: 60684
		internal static int __PropertyOffset_7;

		// Token: 0x0400ED0D RID: 60685
		internal static int __PropertyOffset_8;

		// Token: 0x0400ED0E RID: 60686
		internal static int __PropertyOffset_9;

		// Token: 0x0400ED0F RID: 60687
		internal static int __PropertyOffset_10;

		// Token: 0x0400ED10 RID: 60688
		internal static int __PropertyOffset_11;

		// Token: 0x0400ED11 RID: 60689
		internal static int __PropertyOffset_12;

		// Token: 0x0400ED12 RID: 60690
		internal static int __PropertyOffset_13;

		// Token: 0x0400ED13 RID: 60691
		internal static int __PropertyOffset_14;

		// Token: 0x0400ED14 RID: 60692
		internal static int __PropertyOffset_15;

		// Token: 0x0400ED15 RID: 60693
		private static IntPtr __CalcShouldSpawnOrDestroyBirds_NativeFunctionPtr;

		// Token: 0x0400ED16 RID: 60694
		private static IntPtr __DestroyBirds_NativeFunctionPtr;

		// Token: 0x0400ED17 RID: 60695
		private static IntPtr __SpawnBirds_NativeFunctionPtr;

		// Token: 0x0400ED18 RID: 60696
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400ED19 RID: 60697
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400ED1A RID: 60698
		private static IntPtr __SpawnSkillBirds_NativeFunctionPtr;

		// Token: 0x0400ED1B RID: 60699
		private static IntPtr __DestroySkillBirds_NativeFunctionPtr;

		// Token: 0x0400ED1C RID: 60700
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x0400ED1D RID: 60701
		private static IntPtr __ExecuteUbergraph_BP_YangYangBirdsSpawnerComponent_NativeFunctionPtr;

		// Token: 0x02009776 RID: 38774
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 416)]
		protected ref struct __CalcShouldSpawnOrDestroyBirds_FunctionParams
		{
			// Token: 0x04031D2B RID: 204075
			[FieldOffset(0)]
			public float DeltaTime;
		}

		// Token: 0x02009777 RID: 38775
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031D2C RID: 204076
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009778 RID: 38776
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04031D2D RID: 204077
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009779 RID: 38777
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 368)]
		protected ref struct __ExecuteUbergraph_BP_YangYangBirdsSpawnerComponent_FunctionParams
		{
			// Token: 0x04031D2E RID: 204078
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
