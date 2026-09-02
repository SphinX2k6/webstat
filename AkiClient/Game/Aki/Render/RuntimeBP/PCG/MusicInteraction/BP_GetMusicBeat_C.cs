using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MusicInteraction
{
	// Token: 0x02003BBB RID: 15291
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MusicInteraction/BP_GetMusicBeat.BP_GetMusicBeat_C")]
	[UnrealStructLayout(1384, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1384)]
	public class BP_GetMusicBeat_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022434 RID: 140340 RVA: 0x009604FB File Offset: 0x0095E6FB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_GetMusicBeat_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MusicInteraction/BP_GetMusicBeat.BP_GetMusicBeat_C");
			}
			return BP_GetMusicBeat_C._ClassPtr;
		}

		// Token: 0x06022435 RID: 140341 RVA: 0x00960520 File Offset: 0x0095E720
		public BP_GetMusicBeat_C() : this(BuiltinUtils.AllocNativeUObject(BP_GetMusicBeat_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022436 RID: 140342 RVA: 0x00960548 File Offset: 0x0095E748
		[NullableContext(1)]
		public BP_GetMusicBeat_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_GetMusicBeat_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003FEE RID: 16366
		// (get) Token: 0x06022437 RID: 140343 RVA: 0x0096057C File Offset: 0x0095E77C
		// (set) Token: 0x06022438 RID: 140344 RVA: 0x009605B5 File Offset: 0x0095E7B5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_GetMusicBeat_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_GetMusicBeat_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003FEF RID: 16367
		// (get) Token: 0x06022439 RID: 140345 RVA: 0x009605D6 File Offset: 0x0095E7D6
		// (set) Token: 0x0602243A RID: 140346 RVA: 0x009605EA File Offset: 0x0095E7EA
		[Nullable(2)]
		public unsafe UBoxComponent AreaBox
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GetMusicBeat_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GetMusicBeat_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003FF0 RID: 16368
		// (get) Token: 0x0602243B RID: 140347 RVA: 0x009605FF File Offset: 0x0095E7FF
		// (set) Token: 0x0602243C RID: 140348 RVA: 0x00960613 File Offset: 0x0095E813
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GetMusicBeat_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GetMusicBeat_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003FF1 RID: 16369
		// (get) Token: 0x0602243D RID: 140349 RVA: 0x00960628 File Offset: 0x0095E828
		// (set) Token: 0x0602243E RID: 140350 RVA: 0x00960638 File Offset: 0x0095E838
		public unsafe bool Activate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GetMusicBeat_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GetMusicBeat_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003FF2 RID: 16370
		// (get) Token: 0x0602243F RID: 140351 RVA: 0x00960649 File Offset: 0x0095E849
		// (set) Token: 0x06022440 RID: 140352 RVA: 0x00960659 File Offset: 0x0095E859
		public unsafe float Delta_Seconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GetMusicBeat_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GetMusicBeat_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003FF3 RID: 16371
		// (get) Token: 0x06022441 RID: 140353 RVA: 0x0096066A File Offset: 0x0095E86A
		// (set) Token: 0x06022442 RID: 140354 RVA: 0x0096067E File Offset: 0x0095E87E
		public unsafe FVector AreaExtent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GetMusicBeat_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GetMusicBeat_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003FF4 RID: 16372
		// (get) Token: 0x06022443 RID: 140355 RVA: 0x00960693 File Offset: 0x0095E893
		// (set) Token: 0x06022444 RID: 140356 RVA: 0x009606A3 File Offset: 0x0095E8A3
		public unsafe bool DoubleBeat
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GetMusicBeat_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GetMusicBeat_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003FF5 RID: 16373
		// (get) Token: 0x06022445 RID: 140357 RVA: 0x009606B4 File Offset: 0x0095E8B4
		// (set) Token: 0x06022446 RID: 140358 RVA: 0x009606C4 File Offset: 0x0095E8C4
		public unsafe float BeatTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GetMusicBeat_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GetMusicBeat_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003FF6 RID: 16374
		// (get) Token: 0x06022447 RID: 140359 RVA: 0x009606D5 File Offset: 0x0095E8D5
		// (set) Token: 0x06022448 RID: 140360 RVA: 0x009606E5 File Offset: 0x0095E8E5
		public unsafe float DoubleBeatTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GetMusicBeat_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GetMusicBeat_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003FF7 RID: 16375
		// (get) Token: 0x06022449 RID: 140361 RVA: 0x009606F6 File Offset: 0x0095E8F6
		// (set) Token: 0x0602244A RID: 140362 RVA: 0x00960706 File Offset: 0x0095E906
		public unsafe float 单拍时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GetMusicBeat_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GetMusicBeat_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003FF8 RID: 16376
		// (get) Token: 0x0602244B RID: 140363 RVA: 0x00960717 File Offset: 0x0095E917
		// (set) Token: 0x0602244C RID: 140364 RVA: 0x00960727 File Offset: 0x0095E927
		public unsafe float LoopTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GetMusicBeat_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GetMusicBeat_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x0602244D RID: 140365 RVA: 0x00960738 File Offset: 0x0095E938
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GetMusicBeat_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602244E RID: 140366 RVA: 0x0096074C File Offset: 0x0095E94C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GetMusicBeat_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602244F RID: 140367 RVA: 0x00960761 File Offset: 0x0095E961
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GetMusicBeat_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022450 RID: 140368 RVA: 0x00960775 File Offset: 0x0095E975
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GetMusicBeat_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022451 RID: 140369 RVA: 0x0096078C File Offset: 0x0095E98C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_GetMusicBeat_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_GetMusicBeat_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GetMusicBeat_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GetMusicBeat_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GetMusicBeat_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022452 RID: 140370 RVA: 0x009607D4 File Offset: 0x0095E9D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_GetMusicBeat_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_GetMusicBeat_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GetMusicBeat_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GetMusicBeat_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GetMusicBeat_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022453 RID: 140371 RVA: 0x0096081C File Offset: 0x0095EA1C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 音乐节拍事件触发时_Event_0(string MusicEventType)
		{
			BP_GetMusicBeat_C.__音乐节拍事件触发时_Event_0_FunctionParams* ptr = stackalloc BP_GetMusicBeat_C.__音乐节拍事件触发时_Event_0_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_GetMusicBeat_C.__音乐节拍事件触发时_Event_0_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GetMusicBeat_C.__音乐节拍事件触发时_Event_0_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->MusicEventType), MusicEventType);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GetMusicBeat_C.__音乐节拍事件触发时_Event_0_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_GetMusicBeat_C.__音乐节拍事件触发时_Event_0_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06022454 RID: 140372 RVA: 0x0096087C File Offset: 0x0095EA7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_GetMusicBeat_C.__EditorTick_FunctionParams* ptr = stackalloc BP_GetMusicBeat_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GetMusicBeat_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GetMusicBeat_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GetMusicBeat_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022455 RID: 140373 RVA: 0x009608C4 File Offset: 0x0095EAC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_GetMusicBeat_C.__EditorTick_FunctionParams* ptr = stackalloc BP_GetMusicBeat_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GetMusicBeat_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GetMusicBeat_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GetMusicBeat_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022456 RID: 140374 RVA: 0x0096090C File Offset: 0x0095EB0C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_GetMusicBeat(int EntryPoint)
		{
			BP_GetMusicBeat_C.__ExecuteUbergraph_BP_GetMusicBeat_FunctionParams* ptr = stackalloc BP_GetMusicBeat_C.__ExecuteUbergraph_BP_GetMusicBeat_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BP_GetMusicBeat_C.__ExecuteUbergraph_BP_GetMusicBeat_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GetMusicBeat_C.__ExecuteUbergraph_BP_GetMusicBeat_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GetMusicBeat_C.__ExecuteUbergraph_BP_GetMusicBeat_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022457 RID: 140375 RVA: 0x00960956 File Offset: 0x0095EB56
		protected BP_GetMusicBeat_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011532 RID: 70962
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MusicInteraction/BP_GetMusicBeat.BP_GetMusicBeat_C";

		// Token: 0x04011533 RID: 70963
		private static IntPtr _ClassPtr;

		// Token: 0x04011534 RID: 70964
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011535 RID: 70965
		internal static int __PropertyOffset_0;

		// Token: 0x04011536 RID: 70966
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011537 RID: 70967
		internal static int __PropertyOffset_1;

		// Token: 0x04011538 RID: 70968
		internal static int __PropertyOffset_2;

		// Token: 0x04011539 RID: 70969
		internal static int __PropertyOffset_3;

		// Token: 0x0401153A RID: 70970
		internal static int __PropertyOffset_4;

		// Token: 0x0401153B RID: 70971
		internal static int __PropertyOffset_5;

		// Token: 0x0401153C RID: 70972
		internal static int __PropertyOffset_6;

		// Token: 0x0401153D RID: 70973
		internal static int __PropertyOffset_7;

		// Token: 0x0401153E RID: 70974
		internal static int __PropertyOffset_8;

		// Token: 0x0401153F RID: 70975
		internal static int __PropertyOffset_9;

		// Token: 0x04011540 RID: 70976
		internal static int __PropertyOffset_10;

		// Token: 0x04011541 RID: 70977
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011542 RID: 70978
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011543 RID: 70979
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011544 RID: 70980
		private static IntPtr __音乐节拍事件触发时_Event_0_NativeFunctionPtr;

		// Token: 0x04011545 RID: 70981
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04011546 RID: 70982
		private static IntPtr __ExecuteUbergraph_BP_GetMusicBeat_NativeFunctionPtr;

		// Token: 0x02009BB1 RID: 39857
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040323E4 RID: 205796
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BB2 RID: 39858
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __音乐节拍事件触发时_Event_0_FunctionParams
		{
			// Token: 0x040323E5 RID: 205797
			[FieldOffset(0)]
			public FString MusicEventType;
		}

		// Token: 0x02009BB3 RID: 39859
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040323E6 RID: 205798
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BB4 RID: 39860
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __ExecuteUbergraph_BP_GetMusicBeat_FunctionParams
		{
			// Token: 0x040323E7 RID: 205799
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
