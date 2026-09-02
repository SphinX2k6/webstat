using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Core;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive
{
	// Token: 0x02003CF7 RID: 15607
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLive_MemoryPoolManager.NinjaLive_MemoryPoolManager_C")]
	[UnrealStructLayout(1176, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1170)]
	public class NinjaLive_MemoryPoolManager_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025853 RID: 153683 RVA: 0x009BBE43 File Offset: 0x009BA043
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NinjaLive_MemoryPoolManager_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLive_MemoryPoolManager.NinjaLive_MemoryPoolManager_C");
			}
			return NinjaLive_MemoryPoolManager_C._ClassPtr;
		}

		// Token: 0x06025854 RID: 153684 RVA: 0x009BBE68 File Offset: 0x009BA068
		public NinjaLive_MemoryPoolManager_C() : this(BuiltinUtils.AllocNativeUObject(NinjaLive_MemoryPoolManager_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025855 RID: 153685 RVA: 0x009BBE90 File Offset: 0x009BA090
		public NinjaLive_MemoryPoolManager_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NinjaLive_MemoryPoolManager_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005252 RID: 21074
		// (get) Token: 0x06025856 RID: 153686 RVA: 0x009BBEC4 File Offset: 0x009BA0C4
		// (set) Token: 0x06025857 RID: 153687 RVA: 0x009BBEFD File Offset: 0x009BA0FD
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005253 RID: 21075
		// (get) Token: 0x06025858 RID: 153688 RVA: 0x009BBF1E File Offset: 0x009BA11E
		// (set) Token: 0x06025859 RID: 153689 RVA: 0x009BBF32 File Offset: 0x009BA132
		[Nullable(2)]
		public unsafe UMaterialBillboardComponent EditorIcon
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_MemoryPoolManager_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_MemoryPoolManager_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005254 RID: 21076
		// (get) Token: 0x0602585A RID: 153690 RVA: 0x009BBF47 File Offset: 0x009BA147
		// (set) Token: 0x0602585B RID: 153691 RVA: 0x009BBF5B File Offset: 0x009BA15B
		[Nullable(2)]
		public unsafe USceneComponent Root
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_MemoryPoolManager_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_MemoryPoolManager_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005255 RID: 21077
		// (get) Token: 0x0602585C RID: 153692 RVA: 0x009BBF70 File Offset: 0x009BA170
		// (set) Token: 0x0602585D RID: 153693 RVA: 0x009BBF80 File Offset: 0x009BA180
		public unsafe bool DisableMemoryManager
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005256 RID: 21078
		// (get) Token: 0x0602585E RID: 153694 RVA: 0x009BBF91 File Offset: 0x009BA191
		// (set) Token: 0x0602585F RID: 153695 RVA: 0x009BBFA1 File Offset: 0x009BA1A1
		public unsafe int AmountOfRenderTargetSetsToGenerate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005257 RID: 21079
		// (get) Token: 0x06025860 RID: 153696 RVA: 0x009BBFB2 File Offset: 0x009BA1B2
		// (set) Token: 0x06025861 RID: 153697 RVA: 0x009BBFC6 File Offset: 0x009BA1C6
		[Nullable(0)]
		public unsafe TEnumAsByte<SimPrecision_Enum> Precision
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_5);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005258 RID: 21080
		// (get) Token: 0x06025862 RID: 153698 RVA: 0x009BBFDB File Offset: 0x009BA1DB
		// (set) Token: 0x06025863 RID: 153699 RVA: 0x009BBFEB File Offset: 0x009BA1EB
		public unsafe int PrecisionIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005259 RID: 21081
		// (get) Token: 0x06025864 RID: 153700 RVA: 0x009BBFFC File Offset: 0x009BA1FC
		// (set) Token: 0x06025865 RID: 153701 RVA: 0x009BC00C File Offset: 0x009BA20C
		public unsafe int ResolutionX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700525A RID: 21082
		// (get) Token: 0x06025866 RID: 153702 RVA: 0x009BC01D File Offset: 0x009BA21D
		// (set) Token: 0x06025867 RID: 153703 RVA: 0x009BC02D File Offset: 0x009BA22D
		public unsafe int ResolutionY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700525B RID: 21083
		// (get) Token: 0x06025868 RID: 153704 RVA: 0x009BC040 File Offset: 0x009BA240
		// (set) Token: 0x06025869 RID: 153705 RVA: 0x009BC079 File Offset: 0x009BA279
		public TArray<RenderTargetListItem> R_RenderTargetsList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<RenderTargetListItem> result;
				if ((result = this._R_RenderTargetsList) == null)
				{
					result = (this._R_RenderTargetsList = new TArray<RenderTargetListItem>(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				this.R_RenderTargetsList.CopyAssign(value);
			}
		}

		// Token: 0x1700525C RID: 21084
		// (get) Token: 0x0602586A RID: 153706 RVA: 0x009BC088 File Offset: 0x009BA288
		// (set) Token: 0x0602586B RID: 153707 RVA: 0x009BC0C1 File Offset: 0x009BA2C1
		public TArray<RenderTargetListItem> RG_RenderTargetsList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<RenderTargetListItem> result;
				if ((result = this._RG_RenderTargetsList) == null)
				{
					result = (this._RG_RenderTargetsList = new TArray<RenderTargetListItem>(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				this.RG_RenderTargetsList.CopyAssign(value);
			}
		}

		// Token: 0x1700525D RID: 21085
		// (get) Token: 0x0602586C RID: 153708 RVA: 0x009BC0D0 File Offset: 0x009BA2D0
		// (set) Token: 0x0602586D RID: 153709 RVA: 0x009BC109 File Offset: 0x009BA309
		public TArray<RenderTargetListItem> RGBA_RenderTargetsList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<RenderTargetListItem> result;
				if ((result = this._RGBA_RenderTargetsList) == null)
				{
					result = (this._RGBA_RenderTargetsList = new TArray<RenderTargetListItem>(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				this.RGBA_RenderTargetsList.CopyAssign(value);
			}
		}

		// Token: 0x1700525E RID: 21086
		// (get) Token: 0x0602586E RID: 153710 RVA: 0x009BC117 File Offset: 0x009BA317
		// (set) Token: 0x0602586F RID: 153711 RVA: 0x009BC127 File Offset: 0x009BA327
		public unsafe bool MMInitFinished
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700525F RID: 21087
		// (get) Token: 0x06025870 RID: 153712 RVA: 0x009BC138 File Offset: 0x009BA338
		// (set) Token: 0x06025871 RID: 153713 RVA: 0x009BC148 File Offset: 0x009BA348
		public unsafe bool PrintInitDebugMessages
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005260 RID: 21088
		// (get) Token: 0x06025872 RID: 153714 RVA: 0x009BC159 File Offset: 0x009BA359
		// (set) Token: 0x06025873 RID: 153715 RVA: 0x009BC169 File Offset: 0x009BA369
		public unsafe bool PrintRuntimeDebugMsg
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005261 RID: 21089
		// (get) Token: 0x06025874 RID: 153716 RVA: 0x009BC17A File Offset: 0x009BA37A
		// (set) Token: 0x06025875 RID: 153717 RVA: 0x009BC18A File Offset: 0x009BA38A
		public unsafe bool PrintRuntimeDebugMsgVerbose
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005262 RID: 21090
		// (get) Token: 0x06025876 RID: 153718 RVA: 0x009BC19B File Offset: 0x009BA39B
		// (set) Token: 0x06025877 RID: 153719 RVA: 0x009BC1AB File Offset: 0x009BA3AB
		public unsafe float DebugTextLifetime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17005263 RID: 21091
		// (get) Token: 0x06025878 RID: 153720 RVA: 0x009BC1BC File Offset: 0x009BA3BC
		// (set) Token: 0x06025879 RID: 153721 RVA: 0x009BC1CC File Offset: 0x009BA3CC
		public unsafe int ExtraRenderTargetsForDensityInput
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17005264 RID: 21092
		// (get) Token: 0x0602587A RID: 153722 RVA: 0x009BC1DD File Offset: 0x009BA3DD
		// (set) Token: 0x0602587B RID: 153723 RVA: 0x009BC1ED File Offset: 0x009BA3ED
		public unsafe float MemConsumptionTotal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17005265 RID: 21093
		// (get) Token: 0x0602587C RID: 153724 RVA: 0x009BC1FE File Offset: 0x009BA3FE
		// (set) Token: 0x0602587D RID: 153725 RVA: 0x009BC20E File Offset: 0x009BA40E
		public unsafe bool SaveDebugTextToDefaultLog
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005266 RID: 21094
		// (get) Token: 0x0602587E RID: 153726 RVA: 0x009BC21F File Offset: 0x009BA41F
		// (set) Token: 0x0602587F RID: 153727 RVA: 0x009BC233 File Offset: 0x009BA433
		public unsafe string MemAvailableMax
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_20)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_20)), value);
			}
		}

		// Token: 0x17005267 RID: 21095
		// (get) Token: 0x06025880 RID: 153728 RVA: 0x009BC248 File Offset: 0x009BA448
		// (set) Token: 0x06025881 RID: 153729 RVA: 0x009BC258 File Offset: 0x009BA458
		public unsafe bool HalfResPressureAndDivergenceBuffers
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005268 RID: 21096
		// (get) Token: 0x06025882 RID: 153730 RVA: 0x009BC269 File Offset: 0x009BA469
		// (set) Token: 0x06025883 RID: 153731 RVA: 0x009BC279 File Offset: 0x009BA479
		public unsafe bool SimAreaClamp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_MemoryPoolManager_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x06025884 RID: 153732 RVA: 0x009BC28C File Offset: 0x009BA48C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void MemCount(int NumberOfChannels, int ResolutionX, int ResolutionY)
		{
			NinjaLive_MemoryPoolManager_C.__MemCount_FunctionParams* ptr = stackalloc NinjaLive_MemoryPoolManager_C.__MemCount_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(NinjaLive_MemoryPoolManager_C.__MemCount_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_MemoryPoolManager_C.__MemCount_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NumberOfChannels = NumberOfChannels;
			ptr->ResolutionX = ResolutionX;
			ptr->ResolutionY = ResolutionY;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_MemoryPoolManager_C.__MemCount_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025885 RID: 153733 RVA: 0x009BC2E0 File Offset: 0x009BA4E0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetRenderTargetAttribs(UTextureRenderTarget2D InputPin, bool Clamping, ref UTextureRenderTarget2D RT)
		{
			NinjaLive_MemoryPoolManager_C.__SetRenderTargetAttribs_FunctionParams* ptr = stackalloc NinjaLive_MemoryPoolManager_C.__SetRenderTargetAttribs_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(NinjaLive_MemoryPoolManager_C.__SetRenderTargetAttribs_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_MemoryPoolManager_C.__SetRenderTargetAttribs_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InputPin = ((InputPin != null) ? InputPin.NativePtr : IntPtr.Zero);
			ptr->Clamping = Clamping;
			ref NinjaLive_MemoryPoolManager_C.__SetRenderTargetAttribs_FunctionParams ptr2 = ref *ptr;
			UTextureRenderTarget2D utextureRenderTarget2D = RT;
			ptr2.RT = ((utextureRenderTarget2D != null) ? utextureRenderTarget2D.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_MemoryPoolManager_C.__SetRenderTargetAttribs_NativeFunctionPtr, (void*)ptr);
			RT = BuiltinUtils.GetOrCreateUObjectByNativePointer<UTextureRenderTarget2D>(ptr->RT);
		}

		// Token: 0x06025886 RID: 153734 RVA: 0x009BC361 File Offset: 0x009BA561
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_MemoryPoolManager_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06025887 RID: 153735 RVA: 0x009BC375 File Offset: 0x009BA575
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLive_MemoryPoolManager_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025888 RID: 153736 RVA: 0x009BC38A File Offset: 0x009BA58A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_MemoryPoolManager_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06025889 RID: 153737 RVA: 0x009BC39E File Offset: 0x009BA59E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLive_MemoryPoolManager_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602588A RID: 153738 RVA: 0x009BC3B4 File Offset: 0x009BA5B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			NinjaLive_MemoryPoolManager_C.__ReceiveTick_FunctionParams* ptr = stackalloc NinjaLive_MemoryPoolManager_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLive_MemoryPoolManager_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_MemoryPoolManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_MemoryPoolManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602588B RID: 153739 RVA: 0x009BC3FC File Offset: 0x009BA5FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			NinjaLive_MemoryPoolManager_C.__ReceiveTick_FunctionParams* ptr = stackalloc NinjaLive_MemoryPoolManager_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLive_MemoryPoolManager_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_MemoryPoolManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLive_MemoryPoolManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602588C RID: 153740 RVA: 0x009BC444 File Offset: 0x009BA644
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void PrintMemStatus(UObject Consumer, float MemConsumption, bool TakenOrReturned)
		{
			NinjaLive_MemoryPoolManager_C.__PrintMemStatus_FunctionParams* ptr = stackalloc NinjaLive_MemoryPoolManager_C.__PrintMemStatus_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(NinjaLive_MemoryPoolManager_C.__PrintMemStatus_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_MemoryPoolManager_C.__PrintMemStatus_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Consumer = ((Consumer != null) ? Consumer.NativePtr : IntPtr.Zero);
			ptr->MemConsumption = MemConsumption;
			ptr->TakenOrReturned = TakenOrReturned;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_MemoryPoolManager_C.__PrintMemStatus_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602588D RID: 153741 RVA: 0x009BC4A8 File Offset: 0x009BA6A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_NinjaLive_MemoryPoolManager(int EntryPoint)
		{
			NinjaLive_MemoryPoolManager_C.__ExecuteUbergraph_NinjaLive_MemoryPoolManager_FunctionParams* ptr = stackalloc NinjaLive_MemoryPoolManager_C.__ExecuteUbergraph_NinjaLive_MemoryPoolManager_FunctionParams[(UIntPtr)1207] + 15L / (long)sizeof(NinjaLive_MemoryPoolManager_C.__ExecuteUbergraph_NinjaLive_MemoryPoolManager_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_MemoryPoolManager_C.__ExecuteUbergraph_NinjaLive_MemoryPoolManager_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLive_MemoryPoolManager_C.__ExecuteUbergraph_NinjaLive_MemoryPoolManager_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602588E RID: 153742 RVA: 0x009BC4F2 File Offset: 0x009BA6F2
		protected NinjaLive_MemoryPoolManager_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401359A RID: 79258
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLive_MemoryPoolManager.NinjaLive_MemoryPoolManager_C";

		// Token: 0x0401359B RID: 79259
		private static IntPtr _ClassPtr;

		// Token: 0x0401359C RID: 79260
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401359D RID: 79261
		internal static int __PropertyOffset_0;

		// Token: 0x0401359E RID: 79262
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401359F RID: 79263
		internal static int __PropertyOffset_1;

		// Token: 0x040135A0 RID: 79264
		internal static int __PropertyOffset_2;

		// Token: 0x040135A1 RID: 79265
		internal static int __PropertyOffset_3;

		// Token: 0x040135A2 RID: 79266
		internal static int __PropertyOffset_4;

		// Token: 0x040135A3 RID: 79267
		internal static int __PropertyOffset_5;

		// Token: 0x040135A4 RID: 79268
		internal static int __PropertyOffset_6;

		// Token: 0x040135A5 RID: 79269
		internal static int __PropertyOffset_7;

		// Token: 0x040135A6 RID: 79270
		internal static int __PropertyOffset_8;

		// Token: 0x040135A7 RID: 79271
		internal static int __PropertyOffset_9;

		// Token: 0x040135A8 RID: 79272
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<RenderTargetListItem> _R_RenderTargetsList;

		// Token: 0x040135A9 RID: 79273
		internal static int __PropertyOffset_10;

		// Token: 0x040135AA RID: 79274
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<RenderTargetListItem> _RG_RenderTargetsList;

		// Token: 0x040135AB RID: 79275
		internal static int __PropertyOffset_11;

		// Token: 0x040135AC RID: 79276
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<RenderTargetListItem> _RGBA_RenderTargetsList;

		// Token: 0x040135AD RID: 79277
		internal static int __PropertyOffset_12;

		// Token: 0x040135AE RID: 79278
		internal static int __PropertyOffset_13;

		// Token: 0x040135AF RID: 79279
		internal static int __PropertyOffset_14;

		// Token: 0x040135B0 RID: 79280
		internal static int __PropertyOffset_15;

		// Token: 0x040135B1 RID: 79281
		internal static int __PropertyOffset_16;

		// Token: 0x040135B2 RID: 79282
		internal static int __PropertyOffset_17;

		// Token: 0x040135B3 RID: 79283
		internal static int __PropertyOffset_18;

		// Token: 0x040135B4 RID: 79284
		internal static int __PropertyOffset_19;

		// Token: 0x040135B5 RID: 79285
		internal static int __PropertyOffset_20;

		// Token: 0x040135B6 RID: 79286
		internal static int __PropertyOffset_21;

		// Token: 0x040135B7 RID: 79287
		internal static int __PropertyOffset_22;

		// Token: 0x040135B8 RID: 79288
		private static IntPtr __MemCount_NativeFunctionPtr;

		// Token: 0x040135B9 RID: 79289
		private static IntPtr __SetRenderTargetAttribs_NativeFunctionPtr;

		// Token: 0x040135BA RID: 79290
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040135BB RID: 79291
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040135BC RID: 79292
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040135BD RID: 79293
		private static IntPtr __PrintMemStatus_NativeFunctionPtr;

		// Token: 0x040135BE RID: 79294
		private static IntPtr __ExecuteUbergraph_NinjaLive_MemoryPoolManager_NativeFunctionPtr;

		// Token: 0x02009F11 RID: 40721
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __MemCount_FunctionParams
		{
			// Token: 0x04032A1D RID: 207389
			[FieldOffset(0)]
			public int NumberOfChannels;

			// Token: 0x04032A1E RID: 207390
			[FieldOffset(4)]
			public int ResolutionX;

			// Token: 0x04032A1F RID: 207391
			[FieldOffset(8)]
			public int ResolutionY;
		}

		// Token: 0x02009F12 RID: 40722
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __SetRenderTargetAttribs_FunctionParams
		{
			// Token: 0x04032A20 RID: 207392
			[FieldOffset(0)]
			public IntPtr InputPin;

			// Token: 0x04032A21 RID: 207393
			[FieldOffset(8)]
			public bool Clamping;

			// Token: 0x04032A22 RID: 207394
			[FieldOffset(16)]
			public IntPtr RT;
		}

		// Token: 0x02009F13 RID: 40723
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032A23 RID: 207395
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009F14 RID: 40724
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __PrintMemStatus_FunctionParams
		{
			// Token: 0x04032A24 RID: 207396
			[FieldOffset(0)]
			public IntPtr Consumer;

			// Token: 0x04032A25 RID: 207397
			[FieldOffset(8)]
			public float MemConsumption;

			// Token: 0x04032A26 RID: 207398
			[FieldOffset(12)]
			public bool TakenOrReturned;
		}

		// Token: 0x02009F15 RID: 40725
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1192)]
		protected ref struct __ExecuteUbergraph_NinjaLive_MemoryPoolManager_FunctionParams
		{
			// Token: 0x04032A27 RID: 207399
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
