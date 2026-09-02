using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core
{
	// Token: 0x02003F3B RID: 16187
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Core/BP_TestGameMode.BP_TestGameMode_C")]
	[UnrealStructLayout(1512, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1512)]
	public class BP_TestGameMode_C : AKuroSilenceGameMode, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028695 RID: 165525 RVA: 0x00A09BA0 File Offset: 0x00A07DA0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_TestGameMode_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Core/BP_TestGameMode.BP_TestGameMode_C");
			}
			return BP_TestGameMode_C._ClassPtr;
		}

		// Token: 0x06028696 RID: 165526 RVA: 0x00A09BC4 File Offset: 0x00A07DC4
		public BP_TestGameMode_C() : this(BuiltinUtils.AllocNativeUObject(BP_TestGameMode_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028697 RID: 165527 RVA: 0x00A09BEC File Offset: 0x00A07DEC
		public BP_TestGameMode_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_TestGameMode_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700622E RID: 25134
		// (get) Token: 0x06028698 RID: 165528 RVA: 0x00A09C20 File Offset: 0x00A07E20
		// (set) Token: 0x06028699 RID: 165529 RVA: 0x00A09C59 File Offset: 0x00A07E59
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_TestGameMode_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_TestGameMode_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700622F RID: 25135
		// (get) Token: 0x0602869A RID: 165530 RVA: 0x00A09C7A File Offset: 0x00A07E7A
		// (set) Token: 0x0602869B RID: 165531 RVA: 0x00A09C8E File Offset: 0x00A07E8E
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TestGameMode_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TestGameMode_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17006230 RID: 25136
		// (get) Token: 0x0602869C RID: 165532 RVA: 0x00A09CA3 File Offset: 0x00A07EA3
		// (set) Token: 0x0602869D RID: 165533 RVA: 0x00A09CB7 File Offset: 0x00A07EB7
		[Nullable(2)]
		public unsafe AActor StreamingSource
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TestGameMode_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TestGameMode_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17006231 RID: 25137
		// (get) Token: 0x0602869E RID: 165534 RVA: 0x00A09CCC File Offset: 0x00A07ECC
		// (set) Token: 0x0602869F RID: 165535 RVA: 0x00A09D05 File Offset: 0x00A07F05
		public TArray<APlayerStart> PlayerStarts
		{
			get
			{
				base.FastCheckIsValid();
				TArray<APlayerStart> result;
				if ((result = this._PlayerStarts) == null)
				{
					result = (this._PlayerStarts = new TArray<APlayerStart>(base.NativePtr + (IntPtr)BP_TestGameMode_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.PlayerStarts.CopyAssign(value);
			}
		}

		// Token: 0x17006232 RID: 25138
		// (get) Token: 0x060286A0 RID: 165536 RVA: 0x00A09D14 File Offset: 0x00A07F14
		// (set) Token: 0x060286A1 RID: 165537 RVA: 0x00A09D4D File Offset: 0x00A07F4D
		public TArray<FWorldPartitionStreamingQuerySource> QuerySources
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FWorldPartitionStreamingQuerySource> result;
				if ((result = this._QuerySources) == null)
				{
					result = (this._QuerySources = new TArray<FWorldPartitionStreamingQuerySource>(base.NativePtr + (IntPtr)BP_TestGameMode_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.QuerySources.CopyAssign(value);
			}
		}

		// Token: 0x17006233 RID: 25139
		// (get) Token: 0x060286A2 RID: 165538 RVA: 0x00A09D5C File Offset: 0x00A07F5C
		// (set) Token: 0x060286A3 RID: 165539 RVA: 0x00A09D95 File Offset: 0x00A07F95
		public FTimerHandle Handler
		{
			get
			{
				base.FastCheckIsValid();
				FTimerHandle result;
				if ((result = this._Handler) == null)
				{
					result = (this._Handler = new FTimerHandle(base.NativePtr + (IntPtr)BP_TestGameMode_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FTimerHandle.StaticStruct(), base.NativePtr + (IntPtr)BP_TestGameMode_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006234 RID: 25140
		// (get) Token: 0x060286A4 RID: 165540 RVA: 0x00A09DB6 File Offset: 0x00A07FB6
		// (set) Token: 0x060286A5 RID: 165541 RVA: 0x00A09DC6 File Offset: 0x00A07FC6
		public unsafe bool IsMovieRenderQueueMode
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TestGameMode_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TestGameMode_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006235 RID: 25141
		// (get) Token: 0x060286A6 RID: 165542 RVA: 0x00A09DD7 File Offset: 0x00A07FD7
		// (set) Token: 0x060286A7 RID: 165543 RVA: 0x00A09DEB File Offset: 0x00A07FEB
		[Nullable(2)]
		public unsafe BP_MainGameInstance_C BpMainGameInstance
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_MainGameInstance_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TestGameMode_C.__PropertyOffset_7);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TestGameMode_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17006236 RID: 25142
		// (get) Token: 0x060286A8 RID: 165544 RVA: 0x00A09E00 File Offset: 0x00A08000
		// (set) Token: 0x060286A9 RID: 165545 RVA: 0x00A09E14 File Offset: 0x00A08014
		[Nullable(2)]
		public unsafe AActor StreamingSourceActor
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TestGameMode_C.__PropertyOffset_8);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TestGameMode_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17006237 RID: 25143
		// (get) Token: 0x060286AA RID: 165546 RVA: 0x00A09E29 File Offset: 0x00A08029
		// (set) Token: 0x060286AB RID: 165547 RVA: 0x00A09E39 File Offset: 0x00A08039
		public unsafe bool IsLoginServerReady
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TestGameMode_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TestGameMode_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006238 RID: 25144
		// (get) Token: 0x060286AC RID: 165548 RVA: 0x00A09E4A File Offset: 0x00A0804A
		// (set) Token: 0x060286AD RID: 165549 RVA: 0x00A09E5A File Offset: 0x00A0805A
		public unsafe bool IsWaitingLoginHttpResponse
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TestGameMode_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TestGameMode_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006239 RID: 25145
		// (get) Token: 0x060286AE RID: 165550 RVA: 0x00A09E6B File Offset: 0x00A0806B
		// (set) Token: 0x060286AF RID: 165551 RVA: 0x00A09E7F File Offset: 0x00A0807F
		public unsafe string LoginUrl
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_TestGameMode_C.__PropertyOffset_11)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_TestGameMode_C.__PropertyOffset_11)), value);
			}
		}

		// Token: 0x1700623A RID: 25146
		// (get) Token: 0x060286B0 RID: 165552 RVA: 0x00A09E94 File Offset: 0x00A08094
		// (set) Token: 0x060286B1 RID: 165553 RVA: 0x00A09EA4 File Offset: 0x00A080A4
		public unsafe bool IsWaitingApiHttpResponse
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TestGameMode_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TestGameMode_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700623B RID: 25147
		// (get) Token: 0x060286B2 RID: 165554 RVA: 0x00A09EB5 File Offset: 0x00A080B5
		// (set) Token: 0x060286B3 RID: 165555 RVA: 0x00A09EC5 File Offset: 0x00A080C5
		public unsafe bool IsApiServerReady
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TestGameMode_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TestGameMode_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700623C RID: 25148
		// (get) Token: 0x060286B4 RID: 165556 RVA: 0x00A09ED6 File Offset: 0x00A080D6
		// (set) Token: 0x060286B5 RID: 165557 RVA: 0x00A09EEA File Offset: 0x00A080EA
		public unsafe string ApiUrl
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_TestGameMode_C.__PropertyOffset_14)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_TestGameMode_C.__PropertyOffset_14)), value);
			}
		}

		// Token: 0x1700623D RID: 25149
		// (get) Token: 0x060286B6 RID: 165558 RVA: 0x00A09EFF File Offset: 0x00A080FF
		// (set) Token: 0x060286B7 RID: 165559 RVA: 0x00A09F0F File Offset: 0x00A0810F
		public unsafe bool bTriggerLoginOnce
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TestGameMode_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TestGameMode_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700623E RID: 25150
		// (get) Token: 0x060286B8 RID: 165560 RVA: 0x00A09F20 File Offset: 0x00A08120
		// (set) Token: 0x060286B9 RID: 165561 RVA: 0x00A09F59 File Offset: 0x00A08159
		public TMap<string, string> LevelNameMapping
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, string> result;
				if ((result = this._LevelNameMapping) == null)
				{
					result = (this._LevelNameMapping = new TMap<string, string>(base.NativePtr + (IntPtr)BP_TestGameMode_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				this.LevelNameMapping.CopyAssign(value);
			}
		}

		// Token: 0x060286BA RID: 165562 RVA: 0x00A09F68 File Offset: 0x00A08168
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetServerIpAndPort(ref string ServerIp, ref string ApiServerPort, ref string LoginServerPort)
		{
			BP_TestGameMode_C.__GetServerIpAndPort_FunctionParams* ptr = stackalloc BP_TestGameMode_C.__GetServerIpAndPort_FunctionParams[(UIntPtr)335] + 15L / (long)sizeof(BP_TestGameMode_C.__GetServerIpAndPort_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TestGameMode_C.__GetServerIpAndPort_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->ServerIp), ServerIp);
			FString.CopyFrom((void*)(&ptr->ApiServerPort), ApiServerPort);
			FString.CopyFrom((void*)(&ptr->LoginServerPort), LoginServerPort);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TestGameMode_C.__GetServerIpAndPort_NativeFunctionPtr, (void*)ptr);
			ServerIp = FString.ToString((void*)(&ptr->ServerIp));
			ApiServerPort = FString.ToString((void*)(&ptr->ApiServerPort));
			LoginServerPort = FString.ToString((void*)(&ptr->LoginServerPort));
			UnrealReflectionUtils.DestroyStruct(BP_TestGameMode_C.__GetServerIpAndPort_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060286BB RID: 165563 RVA: 0x00A0A00F File Offset: 0x00A0820F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DelayStreamingSource()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TestGameMode_C.__DelayStreamingSource_NativeFunctionPtr, null);
		}

		// Token: 0x060286BC RID: 165564 RVA: 0x00A0A023 File Offset: 0x00A08223
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StreamingCompleted()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TestGameMode_C.__StreamingCompleted_NativeFunctionPtr, null);
		}

		// Token: 0x060286BD RID: 165565 RVA: 0x00A0A038 File Offset: 0x00A08238
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Get_Player_Starts(ref bool Exist, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<APlayerStart> PlayerStarts)
		{
			BP_TestGameMode_C.__Get_Player_Starts_FunctionParams* ptr = stackalloc BP_TestGameMode_C.__Get_Player_Starts_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_TestGameMode_C.__Get_Player_Starts_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TestGameMode_C.__Get_Player_Starts_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Exist = Exist;
			TArray<APlayerStart> tarray = PlayerStarts;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->PlayerStarts);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TestGameMode_C.__Get_Player_Starts_NativeFunctionPtr, (void*)ptr);
			Exist = ptr->Exist;
			TArray<APlayerStart> tarray2 = PlayerStarts;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->PlayerStarts);
			}
			UnrealReflectionUtils.DestroyStruct(BP_TestGameMode_C.__Get_Player_Starts_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060286BE RID: 165566 RVA: 0x00A0A0C0 File Offset: 0x00A082C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CheckStreamingHandler()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TestGameMode_C.__CheckStreamingHandler_NativeFunctionPtr, null);
		}

		// Token: 0x060286BF RID: 165567 RVA: 0x00A0A0D4 File Offset: 0x00A082D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Check()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TestGameMode_C.__Check_NativeFunctionPtr, null);
		}

		// Token: 0x060286C0 RID: 165568 RVA: 0x00A0A0E8 File Offset: 0x00A082E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TestGameMode_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060286C1 RID: 165569 RVA: 0x00A0A0FC File Offset: 0x00A082FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TestGameMode_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060286C2 RID: 165570 RVA: 0x00A0A114 File Offset: 0x00A08314
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_TestGameMode_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_TestGameMode_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_TestGameMode_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TestGameMode_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TestGameMode_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060286C3 RID: 165571 RVA: 0x00A0A15C File Offset: 0x00A0835C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_TestGameMode_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_TestGameMode_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_TestGameMode_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TestGameMode_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TestGameMode_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060286C4 RID: 165572 RVA: 0x00A0A1A4 File Offset: 0x00A083A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void LoginServerStatusResponse(bool bConnectedSuccessfully, int HttpResponseCode, string Data)
		{
			BP_TestGameMode_C.__LoginServerStatusResponse_FunctionParams* ptr = stackalloc BP_TestGameMode_C.__LoginServerStatusResponse_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_TestGameMode_C.__LoginServerStatusResponse_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TestGameMode_C.__LoginServerStatusResponse_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bConnectedSuccessfully = bConnectedSuccessfully;
			ptr->HttpResponseCode = HttpResponseCode;
			FString.CopyFrom((void*)(&ptr->Data), Data);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TestGameMode_C.__LoginServerStatusResponse_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_TestGameMode_C.__LoginServerStatusResponse_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060286C5 RID: 165573 RVA: 0x00A0A210 File Offset: 0x00A08410
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ApiServereStatusResponse(bool bConnectedSuccessfully, int HttpResponseCode, string Data)
		{
			BP_TestGameMode_C.__ApiServereStatusResponse_FunctionParams* ptr = stackalloc BP_TestGameMode_C.__ApiServereStatusResponse_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_TestGameMode_C.__ApiServereStatusResponse_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TestGameMode_C.__ApiServereStatusResponse_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bConnectedSuccessfully = bConnectedSuccessfully;
			ptr->HttpResponseCode = HttpResponseCode;
			FString.CopyFrom((void*)(&ptr->Data), Data);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TestGameMode_C.__ApiServereStatusResponse_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_TestGameMode_C.__ApiServereStatusResponse_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060286C6 RID: 165574 RVA: 0x00A0A27C File Offset: 0x00A0847C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_TestGameMode(int EntryPoint)
		{
			BP_TestGameMode_C.__ExecuteUbergraph_BP_TestGameMode_FunctionParams* ptr = stackalloc BP_TestGameMode_C.__ExecuteUbergraph_BP_TestGameMode_FunctionParams[(UIntPtr)1111] + 15L / (long)sizeof(BP_TestGameMode_C.__ExecuteUbergraph_BP_TestGameMode_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TestGameMode_C.__ExecuteUbergraph_BP_TestGameMode_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TestGameMode_C.__ExecuteUbergraph_BP_TestGameMode_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060286C7 RID: 165575 RVA: 0x00A0A2C6 File Offset: 0x00A084C6
		protected BP_TestGameMode_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015414 RID: 87060
		public new const string __ObjectPath = "/Game/Aki/Core/BP_TestGameMode.BP_TestGameMode_C";

		// Token: 0x04015415 RID: 87061
		private static IntPtr _ClassPtr;

		// Token: 0x04015416 RID: 87062
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015417 RID: 87063
		internal static int __PropertyOffset_0;

		// Token: 0x04015418 RID: 87064
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015419 RID: 87065
		internal static int __PropertyOffset_1;

		// Token: 0x0401541A RID: 87066
		internal static int __PropertyOffset_2;

		// Token: 0x0401541B RID: 87067
		internal static int __PropertyOffset_3;

		// Token: 0x0401541C RID: 87068
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<APlayerStart> _PlayerStarts;

		// Token: 0x0401541D RID: 87069
		internal static int __PropertyOffset_4;

		// Token: 0x0401541E RID: 87070
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FWorldPartitionStreamingQuerySource> _QuerySources;

		// Token: 0x0401541F RID: 87071
		internal static int __PropertyOffset_5;

		// Token: 0x04015420 RID: 87072
		[Nullable(2)]
		private FTimerHandle _Handler;

		// Token: 0x04015421 RID: 87073
		internal static int __PropertyOffset_6;

		// Token: 0x04015422 RID: 87074
		internal static int __PropertyOffset_7;

		// Token: 0x04015423 RID: 87075
		internal static int __PropertyOffset_8;

		// Token: 0x04015424 RID: 87076
		internal static int __PropertyOffset_9;

		// Token: 0x04015425 RID: 87077
		internal static int __PropertyOffset_10;

		// Token: 0x04015426 RID: 87078
		internal static int __PropertyOffset_11;

		// Token: 0x04015427 RID: 87079
		internal static int __PropertyOffset_12;

		// Token: 0x04015428 RID: 87080
		internal static int __PropertyOffset_13;

		// Token: 0x04015429 RID: 87081
		internal static int __PropertyOffset_14;

		// Token: 0x0401542A RID: 87082
		internal static int __PropertyOffset_15;

		// Token: 0x0401542B RID: 87083
		internal static int __PropertyOffset_16;

		// Token: 0x0401542C RID: 87084
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<string, string> _LevelNameMapping;

		// Token: 0x0401542D RID: 87085
		private static IntPtr __GetServerIpAndPort_NativeFunctionPtr;

		// Token: 0x0401542E RID: 87086
		private static IntPtr __DelayStreamingSource_NativeFunctionPtr;

		// Token: 0x0401542F RID: 87087
		private static IntPtr __StreamingCompleted_NativeFunctionPtr;

		// Token: 0x04015430 RID: 87088
		private static IntPtr __Get_Player_Starts_NativeFunctionPtr;

		// Token: 0x04015431 RID: 87089
		private static IntPtr __CheckStreamingHandler_NativeFunctionPtr;

		// Token: 0x04015432 RID: 87090
		private static IntPtr __Check_NativeFunctionPtr;

		// Token: 0x04015433 RID: 87091
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04015434 RID: 87092
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04015435 RID: 87093
		private static IntPtr __LoginServerStatusResponse_NativeFunctionPtr;

		// Token: 0x04015436 RID: 87094
		private static IntPtr __ApiServereStatusResponse_NativeFunctionPtr;

		// Token: 0x04015437 RID: 87095
		private static IntPtr __ExecuteUbergraph_BP_TestGameMode_NativeFunctionPtr;

		// Token: 0x0200A0E7 RID: 41191
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 320)]
		protected ref struct __GetServerIpAndPort_FunctionParams
		{
			// Token: 0x04032DA6 RID: 208294
			[FieldOffset(0)]
			public FString ServerIp;

			// Token: 0x04032DA7 RID: 208295
			[FieldOffset(16)]
			public FString ApiServerPort;

			// Token: 0x04032DA8 RID: 208296
			[FieldOffset(32)]
			public FString LoginServerPort;
		}

		// Token: 0x0200A0E8 RID: 41192
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __Get_Player_Starts_FunctionParams
		{
			// Token: 0x04032DA9 RID: 208297
			[FieldOffset(0)]
			public bool Exist;

			// Token: 0x04032DAA RID: 208298
			[FieldOffset(8)]
			public byte PlayerStarts;
		}

		// Token: 0x0200A0E9 RID: 41193
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032DAB RID: 208299
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A0EA RID: 41194
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __LoginServerStatusResponse_FunctionParams
		{
			// Token: 0x04032DAC RID: 208300
			[FieldOffset(0)]
			public bool bConnectedSuccessfully;

			// Token: 0x04032DAD RID: 208301
			[FieldOffset(4)]
			public int HttpResponseCode;

			// Token: 0x04032DAE RID: 208302
			[FieldOffset(8)]
			public FString Data;
		}

		// Token: 0x0200A0EB RID: 41195
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ApiServereStatusResponse_FunctionParams
		{
			// Token: 0x04032DAF RID: 208303
			[FieldOffset(0)]
			public bool bConnectedSuccessfully;

			// Token: 0x04032DB0 RID: 208304
			[FieldOffset(4)]
			public int HttpResponseCode;

			// Token: 0x04032DB1 RID: 208305
			[FieldOffset(8)]
			public FString Data;
		}

		// Token: 0x0200A0EC RID: 41196
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1096)]
		protected ref struct __ExecuteUbergraph_BP_TestGameMode_FunctionParams
		{
			// Token: 0x04032DB2 RID: 208306
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
