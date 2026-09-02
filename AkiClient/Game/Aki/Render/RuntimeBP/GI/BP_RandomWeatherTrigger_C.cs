using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI
{
	// Token: 0x02003C99 RID: 15513
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/BP_RandomWeatherTrigger.BP_RandomWeatherTrigger_C")]
	[UnrealStructLayout(1128, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1121)]
	public class BP_RandomWeatherTrigger_C : ATriggerBox, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602478D RID: 149389 RVA: 0x0099E8B0 File Offset: 0x0099CAB0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_RandomWeatherTrigger_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/BP_RandomWeatherTrigger.BP_RandomWeatherTrigger_C");
			}
			return BP_RandomWeatherTrigger_C._ClassPtr;
		}

		// Token: 0x0602478E RID: 149390 RVA: 0x0099E8D4 File Offset: 0x0099CAD4
		public BP_RandomWeatherTrigger_C() : this(BuiltinUtils.AllocNativeUObject(BP_RandomWeatherTrigger_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602478F RID: 149391 RVA: 0x0099E8FC File Offset: 0x0099CAFC
		[NullableContext(1)]
		public BP_RandomWeatherTrigger_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_RandomWeatherTrigger_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004C43 RID: 19523
		// (get) Token: 0x06024790 RID: 149392 RVA: 0x0099E930 File Offset: 0x0099CB30
		// (set) Token: 0x06024791 RID: 149393 RVA: 0x0099E969 File Offset: 0x0099CB69
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_RandomWeatherTrigger_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_RandomWeatherTrigger_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004C44 RID: 19524
		// (get) Token: 0x06024792 RID: 149394 RVA: 0x0099E98A File Offset: 0x0099CB8A
		// (set) Token: 0x06024793 RID: 149395 RVA: 0x0099E99E File Offset: 0x0099CB9E
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RandomWeatherTrigger_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RandomWeatherTrigger_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004C45 RID: 19525
		// (get) Token: 0x06024794 RID: 149396 RVA: 0x0099E9B3 File Offset: 0x0099CBB3
		// (set) Token: 0x06024795 RID: 149397 RVA: 0x0099E9C3 File Offset: 0x0099CBC3
		public unsafe bool IsInVolume
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RandomWeatherTrigger_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RandomWeatherTrigger_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004C46 RID: 19526
		// (get) Token: 0x06024796 RID: 149398 RVA: 0x0099E9D4 File Offset: 0x0099CBD4
		// (set) Token: 0x06024797 RID: 149399 RVA: 0x0099E9E4 File Offset: 0x0099CBE4
		public unsafe float RandomIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RandomWeatherTrigger_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RandomWeatherTrigger_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17004C47 RID: 19527
		// (get) Token: 0x06024798 RID: 149400 RVA: 0x0099E9F5 File Offset: 0x0099CBF5
		// (set) Token: 0x06024799 RID: 149401 RVA: 0x0099EA05 File Offset: 0x0099CC05
		public unsafe float PostProcessIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RandomWeatherTrigger_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RandomWeatherTrigger_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004C48 RID: 19528
		// (get) Token: 0x0602479A RID: 149402 RVA: 0x0099EA16 File Offset: 0x0099CC16
		// (set) Token: 0x0602479B RID: 149403 RVA: 0x0099EA2A File Offset: 0x0099CC2A
		public unsafe UKuroWeatherDataAsset RandomWeatherDA
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroWeatherDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RandomWeatherTrigger_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RandomWeatherTrigger_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004C49 RID: 19529
		// (get) Token: 0x0602479C RID: 149404 RVA: 0x0099EA3F File Offset: 0x0099CC3F
		// (set) Token: 0x0602479D RID: 149405 RVA: 0x0099EA4F File Offset: 0x0099CC4F
		public unsafe float RandomFrequency
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RandomWeatherTrigger_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RandomWeatherTrigger_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004C4A RID: 19530
		// (get) Token: 0x0602479E RID: 149406 RVA: 0x0099EA60 File Offset: 0x0099CC60
		// (set) Token: 0x0602479F RID: 149407 RVA: 0x0099EA70 File Offset: 0x0099CC70
		public unsafe float RainyDayPersistSecond
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RandomWeatherTrigger_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RandomWeatherTrigger_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17004C4B RID: 19531
		// (get) Token: 0x060247A0 RID: 149408 RVA: 0x0099EA81 File Offset: 0x0099CC81
		// (set) Token: 0x060247A1 RID: 149409 RVA: 0x0099EA91 File Offset: 0x0099CC91
		public unsafe float RandomWeatherCounter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RandomWeatherTrigger_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RandomWeatherTrigger_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004C4C RID: 19532
		// (get) Token: 0x060247A2 RID: 149410 RVA: 0x0099EAA2 File Offset: 0x0099CCA2
		// (set) Token: 0x060247A3 RID: 149411 RVA: 0x0099EAB2 File Offset: 0x0099CCB2
		public unsafe bool IsRaining
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RandomWeatherTrigger_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RandomWeatherTrigger_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004C4D RID: 19533
		// (get) Token: 0x060247A4 RID: 149412 RVA: 0x0099EAC3 File Offset: 0x0099CCC3
		// (set) Token: 0x060247A5 RID: 149413 RVA: 0x0099EAD3 File Offset: 0x0099CCD3
		public unsafe float EnteringCounter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RandomWeatherTrigger_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RandomWeatherTrigger_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17004C4E RID: 19534
		// (get) Token: 0x060247A6 RID: 149414 RVA: 0x0099EAE4 File Offset: 0x0099CCE4
		// (set) Token: 0x060247A7 RID: 149415 RVA: 0x0099EAF4 File Offset: 0x0099CCF4
		public unsafe float ExitingCounter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RandomWeatherTrigger_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RandomWeatherTrigger_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17004C4F RID: 19535
		// (get) Token: 0x060247A8 RID: 149416 RVA: 0x0099EB05 File Offset: 0x0099CD05
		// (set) Token: 0x060247A9 RID: 149417 RVA: 0x0099EB15 File Offset: 0x0099CD15
		public unsafe float EnteringTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RandomWeatherTrigger_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RandomWeatherTrigger_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17004C50 RID: 19536
		// (get) Token: 0x060247AA RID: 149418 RVA: 0x0099EB26 File Offset: 0x0099CD26
		// (set) Token: 0x060247AB RID: 149419 RVA: 0x0099EB36 File Offset: 0x0099CD36
		public unsafe float ExitingTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RandomWeatherTrigger_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RandomWeatherTrigger_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17004C51 RID: 19537
		// (get) Token: 0x060247AC RID: 149420 RVA: 0x0099EB47 File Offset: 0x0099CD47
		// (set) Token: 0x060247AD RID: 149421 RVA: 0x0099EB57 File Offset: 0x0099CD57
		public unsafe bool IsExitingRain
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RandomWeatherTrigger_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RandomWeatherTrigger_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x060247AE RID: 149422 RVA: 0x0099EB68 File Offset: 0x0099CD68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateRandomWeather(float DeltaTime)
		{
			BP_RandomWeatherTrigger_C.__UpdateRandomWeather_FunctionParams* ptr = stackalloc BP_RandomWeatherTrigger_C.__UpdateRandomWeather_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_RandomWeatherTrigger_C.__UpdateRandomWeather_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RandomWeatherTrigger_C.__UpdateRandomWeather_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RandomWeatherTrigger_C.__UpdateRandomWeather_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060247AF RID: 149423 RVA: 0x0099EBB0 File Offset: 0x0099CDB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void IsLegalActor(AActor InActor, ref bool Suc)
		{
			BP_RandomWeatherTrigger_C.__IsLegalActor_FunctionParams* ptr = stackalloc BP_RandomWeatherTrigger_C.__IsLegalActor_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_RandomWeatherTrigger_C.__IsLegalActor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RandomWeatherTrigger_C.__IsLegalActor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InActor = ((InActor != null) ? InActor.NativePtr : IntPtr.Zero);
			ptr->Suc = Suc;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RandomWeatherTrigger_C.__IsLegalActor_NativeFunctionPtr, (void*)ptr);
			Suc = ptr->Suc;
		}

		// Token: 0x060247B0 RID: 149424 RVA: 0x0099EC18 File Offset: 0x0099CE18
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ExitWithActor(AActor InActor)
		{
			BP_RandomWeatherTrigger_C.__ExitWithActor_FunctionParams* ptr = stackalloc BP_RandomWeatherTrigger_C.__ExitWithActor_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_RandomWeatherTrigger_C.__ExitWithActor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RandomWeatherTrigger_C.__ExitWithActor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InActor = ((InActor != null) ? InActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RandomWeatherTrigger_C.__ExitWithActor_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060247B1 RID: 149425 RVA: 0x0099EC70 File Offset: 0x0099CE70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OverlapWithActor(AActor InActor)
		{
			BP_RandomWeatherTrigger_C.__OverlapWithActor_FunctionParams* ptr = stackalloc BP_RandomWeatherTrigger_C.__OverlapWithActor_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_RandomWeatherTrigger_C.__OverlapWithActor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RandomWeatherTrigger_C.__OverlapWithActor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InActor = ((InActor != null) ? InActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RandomWeatherTrigger_C.__OverlapWithActor_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060247B2 RID: 149426 RVA: 0x0099ECC5 File Offset: 0x0099CEC5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RandomWeatherTrigger_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060247B3 RID: 149427 RVA: 0x0099ECD9 File Offset: 0x0099CED9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RandomWeatherTrigger_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060247B4 RID: 149428 RVA: 0x0099ECF0 File Offset: 0x0099CEF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveActorBeginOverlap(AActor OtherActor)
		{
			BP_RandomWeatherTrigger_C.__ReceiveActorBeginOverlap_FunctionParams* ptr = stackalloc BP_RandomWeatherTrigger_C.__ReceiveActorBeginOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_RandomWeatherTrigger_C.__ReceiveActorBeginOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RandomWeatherTrigger_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RandomWeatherTrigger_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060247B5 RID: 149429 RVA: 0x0099ED48 File Offset: 0x0099CF48
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveActorBeginOverlap_Implementation(AActor OtherActor)
		{
			BP_RandomWeatherTrigger_C.__ReceiveActorBeginOverlap_FunctionParams* ptr = stackalloc BP_RandomWeatherTrigger_C.__ReceiveActorBeginOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_RandomWeatherTrigger_C.__ReceiveActorBeginOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RandomWeatherTrigger_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RandomWeatherTrigger_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060247B6 RID: 149430 RVA: 0x0099EDA0 File Offset: 0x0099CFA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_RandomWeatherTrigger_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_RandomWeatherTrigger_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_RandomWeatherTrigger_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RandomWeatherTrigger_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RandomWeatherTrigger_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060247B7 RID: 149431 RVA: 0x0099EDE8 File Offset: 0x0099CFE8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_RandomWeatherTrigger_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_RandomWeatherTrigger_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_RandomWeatherTrigger_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RandomWeatherTrigger_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RandomWeatherTrigger_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060247B8 RID: 149432 RVA: 0x0099EE30 File Offset: 0x0099D030
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveActorEndOverlap(AActor OtherActor)
		{
			BP_RandomWeatherTrigger_C.__ReceiveActorEndOverlap_FunctionParams* ptr = stackalloc BP_RandomWeatherTrigger_C.__ReceiveActorEndOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_RandomWeatherTrigger_C.__ReceiveActorEndOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RandomWeatherTrigger_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RandomWeatherTrigger_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060247B9 RID: 149433 RVA: 0x0099EE88 File Offset: 0x0099D088
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveActorEndOverlap_Implementation(AActor OtherActor)
		{
			BP_RandomWeatherTrigger_C.__ReceiveActorEndOverlap_FunctionParams* ptr = stackalloc BP_RandomWeatherTrigger_C.__ReceiveActorEndOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_RandomWeatherTrigger_C.__ReceiveActorEndOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RandomWeatherTrigger_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RandomWeatherTrigger_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060247BA RID: 149434 RVA: 0x0099EEE0 File Offset: 0x0099D0E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_RandomWeatherTrigger(int EntryPoint)
		{
			BP_RandomWeatherTrigger_C.__ExecuteUbergraph_BP_RandomWeatherTrigger_FunctionParams* ptr = stackalloc BP_RandomWeatherTrigger_C.__ExecuteUbergraph_BP_RandomWeatherTrigger_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_RandomWeatherTrigger_C.__ExecuteUbergraph_BP_RandomWeatherTrigger_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RandomWeatherTrigger_C.__ExecuteUbergraph_BP_RandomWeatherTrigger_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RandomWeatherTrigger_C.__ExecuteUbergraph_BP_RandomWeatherTrigger_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060247BB RID: 149435 RVA: 0x0099EF27 File Offset: 0x0099D127
		protected BP_RandomWeatherTrigger_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012AF0 RID: 76528
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/BP_RandomWeatherTrigger.BP_RandomWeatherTrigger_C";

		// Token: 0x04012AF1 RID: 76529
		private static IntPtr _ClassPtr;

		// Token: 0x04012AF2 RID: 76530
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012AF3 RID: 76531
		internal static int __PropertyOffset_0;

		// Token: 0x04012AF4 RID: 76532
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012AF5 RID: 76533
		internal static int __PropertyOffset_1;

		// Token: 0x04012AF6 RID: 76534
		internal static int __PropertyOffset_2;

		// Token: 0x04012AF7 RID: 76535
		internal static int __PropertyOffset_3;

		// Token: 0x04012AF8 RID: 76536
		internal static int __PropertyOffset_4;

		// Token: 0x04012AF9 RID: 76537
		internal static int __PropertyOffset_5;

		// Token: 0x04012AFA RID: 76538
		internal static int __PropertyOffset_6;

		// Token: 0x04012AFB RID: 76539
		internal static int __PropertyOffset_7;

		// Token: 0x04012AFC RID: 76540
		internal static int __PropertyOffset_8;

		// Token: 0x04012AFD RID: 76541
		internal static int __PropertyOffset_9;

		// Token: 0x04012AFE RID: 76542
		internal static int __PropertyOffset_10;

		// Token: 0x04012AFF RID: 76543
		internal static int __PropertyOffset_11;

		// Token: 0x04012B00 RID: 76544
		internal static int __PropertyOffset_12;

		// Token: 0x04012B01 RID: 76545
		internal static int __PropertyOffset_13;

		// Token: 0x04012B02 RID: 76546
		internal static int __PropertyOffset_14;

		// Token: 0x04012B03 RID: 76547
		private static IntPtr __UpdateRandomWeather_NativeFunctionPtr;

		// Token: 0x04012B04 RID: 76548
		private static IntPtr __IsLegalActor_NativeFunctionPtr;

		// Token: 0x04012B05 RID: 76549
		private static IntPtr __ExitWithActor_NativeFunctionPtr;

		// Token: 0x04012B06 RID: 76550
		private static IntPtr __OverlapWithActor_NativeFunctionPtr;

		// Token: 0x04012B07 RID: 76551
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012B08 RID: 76552
		private static IntPtr __ReceiveActorBeginOverlap_NativeFunctionPtr;

		// Token: 0x04012B09 RID: 76553
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012B0A RID: 76554
		private static IntPtr __ReceiveActorEndOverlap_NativeFunctionPtr;

		// Token: 0x04012B0B RID: 76555
		private static IntPtr __ExecuteUbergraph_BP_RandomWeatherTrigger_NativeFunctionPtr;

		// Token: 0x02009DF0 RID: 40432
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __UpdateRandomWeather_FunctionParams
		{
			// Token: 0x04032830 RID: 206896
			[FieldOffset(0)]
			public float DeltaTime;
		}

		// Token: 0x02009DF1 RID: 40433
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __IsLegalActor_FunctionParams
		{
			// Token: 0x04032831 RID: 206897
			[FieldOffset(0)]
			public IntPtr InActor;

			// Token: 0x04032832 RID: 206898
			[FieldOffset(8)]
			public bool Suc;
		}

		// Token: 0x02009DF2 RID: 40434
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __ExitWithActor_FunctionParams
		{
			// Token: 0x04032833 RID: 206899
			[FieldOffset(0)]
			public IntPtr InActor;
		}

		// Token: 0x02009DF3 RID: 40435
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __OverlapWithActor_FunctionParams
		{
			// Token: 0x04032834 RID: 206900
			[FieldOffset(0)]
			public IntPtr InActor;
		}

		// Token: 0x02009DF4 RID: 40436
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ReceiveActorBeginOverlap_FunctionParams
		{
			// Token: 0x04032835 RID: 206901
			[FieldOffset(0)]
			public IntPtr OtherActor;
		}

		// Token: 0x02009DF5 RID: 40437
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032836 RID: 206902
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009DF6 RID: 40438
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ReceiveActorEndOverlap_FunctionParams
		{
			// Token: 0x04032837 RID: 206903
			[FieldOffset(0)]
			public IntPtr OtherActor;
		}

		// Token: 0x02009DF7 RID: 40439
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __ExecuteUbergraph_BP_RandomWeatherTrigger_FunctionParams
		{
			// Token: 0x04032838 RID: 206904
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
