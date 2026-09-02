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
	// Token: 0x02003CF6 RID: 15606
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLive_InterfaceController.NinjaLive_InterfaceController_C")]
	[UnrealStructLayout(1120, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1116)]
	public class NinjaLive_InterfaceController_C : AActor, IUnrealUObject, IUnrealObject, INinjaLiveInterface_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x06025830 RID: 153648 RVA: 0x009BB9F7 File Offset: 0x009B9BF7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NinjaLive_InterfaceController_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLive_InterfaceController.NinjaLive_InterfaceController_C");
			}
			return NinjaLive_InterfaceController_C._ClassPtr;
		}

		// Token: 0x06025831 RID: 153649 RVA: 0x009BBA1C File Offset: 0x009B9C1C
		public NinjaLive_InterfaceController_C() : this(BuiltinUtils.AllocNativeUObject(NinjaLive_InterfaceController_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025832 RID: 153650 RVA: 0x009BBA44 File Offset: 0x009B9C44
		public NinjaLive_InterfaceController_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NinjaLive_InterfaceController_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005246 RID: 21062
		// (get) Token: 0x06025833 RID: 153651 RVA: 0x009BBA78 File Offset: 0x009B9C78
		// (set) Token: 0x06025834 RID: 153652 RVA: 0x009BBAB1 File Offset: 0x009B9CB1
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)NinjaLive_InterfaceController_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)NinjaLive_InterfaceController_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005247 RID: 21063
		// (get) Token: 0x06025835 RID: 153653 RVA: 0x009BBAD2 File Offset: 0x009B9CD2
		// (set) Token: 0x06025836 RID: 153654 RVA: 0x009BBAE6 File Offset: 0x009B9CE6
		[Nullable(2)]
		public unsafe USceneComponent Scene
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_InterfaceController_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_InterfaceController_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005248 RID: 21064
		// (get) Token: 0x06025837 RID: 153655 RVA: 0x009BBAFB File Offset: 0x009B9CFB
		// (set) Token: 0x06025838 RID: 153656 RVA: 0x009BBB0F File Offset: 0x009B9D0F
		[Nullable(2)]
		public unsafe UBillboardComponent Billboard
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_InterfaceController_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_InterfaceController_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005249 RID: 21065
		// (get) Token: 0x06025839 RID: 153657 RVA: 0x009BBB24 File Offset: 0x009B9D24
		// (set) Token: 0x0602583A RID: 153658 RVA: 0x009BBB34 File Offset: 0x009B9D34
		public unsafe bool DisableCommandbasedControl
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_InterfaceController_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_InterfaceController_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700524A RID: 21066
		// (get) Token: 0x0602583B RID: 153659 RVA: 0x009BBB45 File Offset: 0x009B9D45
		// (set) Token: 0x0602583C RID: 153660 RVA: 0x009BBB55 File Offset: 0x009B9D55
		public unsafe bool EnableOnTickControl
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_InterfaceController_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_InterfaceController_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700524B RID: 21067
		// (get) Token: 0x0602583D RID: 153661 RVA: 0x009BBB68 File Offset: 0x009B9D68
		// (set) Token: 0x0602583E RID: 153662 RVA: 0x009BBBA1 File Offset: 0x009B9DA1
		public TArray<AActor> InterfaceTargetActors
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._InterfaceTargetActors) == null)
				{
					result = (this._InterfaceTargetActors = new TArray<AActor>(base.NativePtr + (IntPtr)NinjaLive_InterfaceController_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				this.InterfaceTargetActors.CopyAssign(value);
			}
		}

		// Token: 0x1700524C RID: 21068
		// (get) Token: 0x0602583F RID: 153663 RVA: 0x009BBBB0 File Offset: 0x009B9DB0
		// (set) Token: 0x06025840 RID: 153664 RVA: 0x009BBBE9 File Offset: 0x009B9DE9
		public TArray<FName> InterfaceCommands
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._InterfaceCommands) == null)
				{
					result = (this._InterfaceCommands = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLive_InterfaceController_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				this.InterfaceCommands.CopyAssign(value);
			}
		}

		// Token: 0x1700524D RID: 21069
		// (get) Token: 0x06025841 RID: 153665 RVA: 0x009BBBF7 File Offset: 0x009B9DF7
		// (set) Token: 0x06025842 RID: 153666 RVA: 0x009BBC07 File Offset: 0x009B9E07
		public unsafe int CommandToBeExecuted
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_InterfaceController_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_InterfaceController_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700524E RID: 21070
		// (get) Token: 0x06025843 RID: 153667 RVA: 0x009BBC18 File Offset: 0x009B9E18
		// (set) Token: 0x06025844 RID: 153668 RVA: 0x009BBC28 File Offset: 0x009B9E28
		public unsafe float DelayBeforeExecutingCommand
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_InterfaceController_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_InterfaceController_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700524F RID: 21071
		// (get) Token: 0x06025845 RID: 153669 RVA: 0x009BBC39 File Offset: 0x009B9E39
		// (set) Token: 0x06025846 RID: 153670 RVA: 0x009BBC49 File Offset: 0x009B9E49
		public unsafe float Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_InterfaceController_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_InterfaceController_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005250 RID: 21072
		// (get) Token: 0x06025847 RID: 153671 RVA: 0x009BBC5A File Offset: 0x009B9E5A
		// (set) Token: 0x06025848 RID: 153672 RVA: 0x009BBC6A File Offset: 0x009B9E6A
		public unsafe float FadeTimeOfBrush
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_InterfaceController_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_InterfaceController_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005251 RID: 21073
		// (get) Token: 0x06025849 RID: 153673 RVA: 0x009BBC7B File Offset: 0x009B9E7B
		// (set) Token: 0x0602584A RID: 153674 RVA: 0x009BBC8B File Offset: 0x009B9E8B
		public unsafe float FadeTimeOfCanvas
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_InterfaceController_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_InterfaceController_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x0602584B RID: 153675 RVA: 0x009BBC9C File Offset: 0x009B9E9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void LiveActivation(FName ParamName, float FadeTimeOfBrush, float FadeTimeOfCanvas)
		{
			NinjaLive_InterfaceController_C.__LiveActivation_FunctionParams* ptr = stackalloc NinjaLive_InterfaceController_C.__LiveActivation_FunctionParams[(UIntPtr)35] + 15L / (long)sizeof(NinjaLive_InterfaceController_C.__LiveActivation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_InterfaceController_C.__LiveActivation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ParamName = ParamName;
			ptr->FadeTimeOfBrush = FadeTimeOfBrush;
			ptr->FadeTimeOfCanvas = FadeTimeOfCanvas;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_InterfaceController_C.__LiveActivation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602584C RID: 153676 RVA: 0x009BBCF0 File Offset: 0x009B9EF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void LiveFluidParams(float BrushSize)
		{
			NinjaLive_InterfaceController_C.__LiveFluidParams_FunctionParams* ptr = stackalloc NinjaLive_InterfaceController_C.__LiveFluidParams_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLive_InterfaceController_C.__LiveFluidParams_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_InterfaceController_C.__LiveFluidParams_NativeFunctionPtr, (void*)ptr, 1);
			ptr->BrushSize = BrushSize;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_InterfaceController_C.__LiveFluidParams_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602584D RID: 153677 RVA: 0x009BBD36 File Offset: 0x009B9F36
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_InterfaceController_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602584E RID: 153678 RVA: 0x009BBD4A File Offset: 0x009B9F4A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLive_InterfaceController_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602584F RID: 153679 RVA: 0x009BBD60 File Offset: 0x009B9F60
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			NinjaLive_InterfaceController_C.__ReceiveTick_FunctionParams* ptr = stackalloc NinjaLive_InterfaceController_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLive_InterfaceController_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_InterfaceController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_InterfaceController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025850 RID: 153680 RVA: 0x009BBDA8 File Offset: 0x009B9FA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			NinjaLive_InterfaceController_C.__ReceiveTick_FunctionParams* ptr = stackalloc NinjaLive_InterfaceController_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLive_InterfaceController_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_InterfaceController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLive_InterfaceController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025851 RID: 153681 RVA: 0x009BBDF0 File Offset: 0x009B9FF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_NinjaLive_InterfaceController(int EntryPoint)
		{
			NinjaLive_InterfaceController_C.__ExecuteUbergraph_NinjaLive_InterfaceController_FunctionParams* ptr = stackalloc NinjaLive_InterfaceController_C.__ExecuteUbergraph_NinjaLive_InterfaceController_FunctionParams[(UIntPtr)167] + 15L / (long)sizeof(NinjaLive_InterfaceController_C.__ExecuteUbergraph_NinjaLive_InterfaceController_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_InterfaceController_C.__ExecuteUbergraph_NinjaLive_InterfaceController_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLive_InterfaceController_C.__ExecuteUbergraph_NinjaLive_InterfaceController_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025852 RID: 153682 RVA: 0x009BBE3A File Offset: 0x009BA03A
		protected NinjaLive_InterfaceController_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013583 RID: 79235
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLive_InterfaceController.NinjaLive_InterfaceController_C";

		// Token: 0x04013584 RID: 79236
		private static IntPtr _ClassPtr;

		// Token: 0x04013585 RID: 79237
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013586 RID: 79238
		internal static int __PropertyOffset_0;

		// Token: 0x04013587 RID: 79239
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013588 RID: 79240
		internal static int __PropertyOffset_1;

		// Token: 0x04013589 RID: 79241
		internal static int __PropertyOffset_2;

		// Token: 0x0401358A RID: 79242
		internal static int __PropertyOffset_3;

		// Token: 0x0401358B RID: 79243
		internal static int __PropertyOffset_4;

		// Token: 0x0401358C RID: 79244
		internal static int __PropertyOffset_5;

		// Token: 0x0401358D RID: 79245
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _InterfaceTargetActors;

		// Token: 0x0401358E RID: 79246
		internal static int __PropertyOffset_6;

		// Token: 0x0401358F RID: 79247
		[Nullable(2)]
		private TArray<FName> _InterfaceCommands;

		// Token: 0x04013590 RID: 79248
		internal static int __PropertyOffset_7;

		// Token: 0x04013591 RID: 79249
		internal static int __PropertyOffset_8;

		// Token: 0x04013592 RID: 79250
		internal static int __PropertyOffset_9;

		// Token: 0x04013593 RID: 79251
		internal static int __PropertyOffset_10;

		// Token: 0x04013594 RID: 79252
		internal static int __PropertyOffset_11;

		// Token: 0x04013595 RID: 79253
		private static IntPtr __LiveActivation_NativeFunctionPtr;

		// Token: 0x04013596 RID: 79254
		private static IntPtr __LiveFluidParams_NativeFunctionPtr;

		// Token: 0x04013597 RID: 79255
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04013598 RID: 79256
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013599 RID: 79257
		private static IntPtr __ExecuteUbergraph_NinjaLive_InterfaceController_NativeFunctionPtr;

		// Token: 0x02009F0D RID: 40717
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 20)]
		protected ref struct __LiveActivation_FunctionParams
		{
			// Token: 0x04032A17 RID: 207383
			[FieldOffset(0)]
			public FName ParamName;

			// Token: 0x04032A18 RID: 207384
			[FieldOffset(12)]
			public float FadeTimeOfBrush;

			// Token: 0x04032A19 RID: 207385
			[FieldOffset(16)]
			public float FadeTimeOfCanvas;
		}

		// Token: 0x02009F0E RID: 40718
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __LiveFluidParams_FunctionParams
		{
			// Token: 0x04032A1A RID: 207386
			[FieldOffset(0)]
			public float BrushSize;
		}

		// Token: 0x02009F0F RID: 40719
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032A1B RID: 207387
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009F10 RID: 40720
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 152)]
		protected ref struct __ExecuteUbergraph_NinjaLive_InterfaceController_FunctionParams
		{
			// Token: 0x04032A1C RID: 207388
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
