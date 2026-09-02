using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.GI;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.VolumeGroupFade
{
	// Token: 0x02003B5D RID: 15197
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/VolumeGroupFade/BP_LightGroup_SyncToMainLight_LaunchScene.BP_LightGroup_SyncToMainLight_LaunchScene_C")]
	[UnrealStructLayout(1480, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1477)]
	public class BP_LightGroup_SyncToMainLight_LaunchScene_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021376 RID: 136054 RVA: 0x00943540 File Offset: 0x00941740
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_LightGroup_SyncToMainLight_LaunchScene_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/VolumeGroupFade/BP_LightGroup_SyncToMainLight_LaunchScene.BP_LightGroup_SyncToMainLight_LaunchScene_C");
			}
			return BP_LightGroup_SyncToMainLight_LaunchScene_C._ClassPtr;
		}

		// Token: 0x06021377 RID: 136055 RVA: 0x00943564 File Offset: 0x00941764
		public BP_LightGroup_SyncToMainLight_LaunchScene_C() : this(BuiltinUtils.AllocNativeUObject(BP_LightGroup_SyncToMainLight_LaunchScene_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021378 RID: 136056 RVA: 0x0094358C File Offset: 0x0094178C
		public BP_LightGroup_SyncToMainLight_LaunchScene_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_LightGroup_SyncToMainLight_LaunchScene_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170039C4 RID: 14788
		// (get) Token: 0x06021379 RID: 136057 RVA: 0x009435C0 File Offset: 0x009417C0
		// (set) Token: 0x0602137A RID: 136058 RVA: 0x009435F9 File Offset: 0x009417F9
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_LaunchScene_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_LaunchScene_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170039C5 RID: 14789
		// (get) Token: 0x0602137B RID: 136059 RVA: 0x0094361A File Offset: 0x0094181A
		// (set) Token: 0x0602137C RID: 136060 RVA: 0x0094362E File Offset: 0x0094182E
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightGroup_SyncToMainLight_LaunchScene_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightGroup_SyncToMainLight_LaunchScene_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170039C6 RID: 14790
		// (get) Token: 0x0602137D RID: 136061 RVA: 0x00943643 File Offset: 0x00941843
		// (set) Token: 0x0602137E RID: 136062 RVA: 0x00943653 File Offset: 0x00941853
		public unsafe bool bEditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_LaunchScene_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_LaunchScene_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x170039C7 RID: 14791
		// (get) Token: 0x0602137F RID: 136063 RVA: 0x00943664 File Offset: 0x00941864
		// (set) Token: 0x06021380 RID: 136064 RVA: 0x00943678 File Offset: 0x00941878
		[Nullable(2)]
		public unsafe BP_GlobalGI_LaunchScene_C CachedGI
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_GlobalGI_LaunchScene_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightGroup_SyncToMainLight_LaunchScene_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightGroup_SyncToMainLight_LaunchScene_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170039C8 RID: 14792
		// (get) Token: 0x06021381 RID: 136065 RVA: 0x00943690 File Offset: 0x00941890
		// (set) Token: 0x06021382 RID: 136066 RVA: 0x009436C9 File Offset: 0x009418C9
		public TMap<ALight, float> LightInstensityMap
		{
			get
			{
				base.FastCheckIsValid();
				TMap<ALight, float> result;
				if ((result = this._LightInstensityMap) == null)
				{
					result = (this._LightInstensityMap = new TMap<ALight, float>(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_LaunchScene_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.LightInstensityMap.CopyAssign(value);
			}
		}

		// Token: 0x170039C9 RID: 14793
		// (get) Token: 0x06021383 RID: 136067 RVA: 0x009436D7 File Offset: 0x009418D7
		// (set) Token: 0x06021384 RID: 136068 RVA: 0x009436E7 File Offset: 0x009418E7
		public unsafe float TargetMainLightIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_LaunchScene_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_LaunchScene_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170039CA RID: 14794
		// (get) Token: 0x06021385 RID: 136069 RVA: 0x009436F8 File Offset: 0x009418F8
		// (set) Token: 0x06021386 RID: 136070 RVA: 0x00943708 File Offset: 0x00941908
		public unsafe int MaxProcessCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_LaunchScene_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_LaunchScene_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170039CB RID: 14795
		// (get) Token: 0x06021387 RID: 136071 RVA: 0x00943719 File Offset: 0x00941919
		// (set) Token: 0x06021388 RID: 136072 RVA: 0x00943729 File Offset: 0x00941929
		public unsafe int NowProcessIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_LaunchScene_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_LaunchScene_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170039CC RID: 14796
		// (get) Token: 0x06021389 RID: 136073 RVA: 0x0094373A File Offset: 0x0094193A
		// (set) Token: 0x0602138A RID: 136074 RVA: 0x0094374E File Offset: 0x0094194E
		public unsafe FLinearColor TargetMainLightColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_LaunchScene_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_LaunchScene_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170039CD RID: 14797
		// (get) Token: 0x0602138B RID: 136075 RVA: 0x00943764 File Offset: 0x00941964
		// (set) Token: 0x0602138C RID: 136076 RVA: 0x0094379D File Offset: 0x0094199D
		public TArray<ALight> Keys
		{
			get
			{
				base.FastCheckIsValid();
				TArray<ALight> result;
				if ((result = this._Keys) == null)
				{
					result = (this._Keys = new TArray<ALight>(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_LaunchScene_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				this.Keys.CopyAssign(value);
			}
		}

		// Token: 0x170039CE RID: 14798
		// (get) Token: 0x0602138D RID: 136077 RVA: 0x009437AB File Offset: 0x009419AB
		// (set) Token: 0x0602138E RID: 136078 RVA: 0x009437BB File Offset: 0x009419BB
		public unsafe int MapLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_LaunchScene_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_LaunchScene_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170039CF RID: 14799
		// (get) Token: 0x0602138F RID: 136079 RVA: 0x009437CC File Offset: 0x009419CC
		// (set) Token: 0x06021390 RID: 136080 RVA: 0x009437DC File Offset: 0x009419DC
		public unsafe bool bLightNotChange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_LaunchScene_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_LaunchScene_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x170039D0 RID: 14800
		// (get) Token: 0x06021391 RID: 136081 RVA: 0x009437ED File Offset: 0x009419ED
		// (set) Token: 0x06021392 RID: 136082 RVA: 0x009437FD File Offset: 0x009419FD
		public unsafe float NightMulti
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_LaunchScene_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_LaunchScene_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170039D1 RID: 14801
		// (get) Token: 0x06021393 RID: 136083 RVA: 0x0094380E File Offset: 0x00941A0E
		// (set) Token: 0x06021394 RID: 136084 RVA: 0x0094381E File Offset: 0x00941A1E
		public unsafe bool TargetBNight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_LaunchScene_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_LaunchScene_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x06021395 RID: 136085 RVA: 0x0094382F File Offset: 0x00941A2F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightGroup_SyncToMainLight_LaunchScene_C.__Update_NativeFunctionPtr, null);
		}

		// Token: 0x06021396 RID: 136086 RVA: 0x00943843 File Offset: 0x00941A43
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightGroup_SyncToMainLight_LaunchScene_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021397 RID: 136087 RVA: 0x00943857 File Offset: 0x00941A57
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightGroup_SyncToMainLight_LaunchScene_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021398 RID: 136088 RVA: 0x0094386C File Offset: 0x00941A6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightGroup_SyncToMainLight_LaunchScene_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x06021399 RID: 136089 RVA: 0x00943880 File Offset: 0x00941A80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightGroup_SyncToMainLight_LaunchScene_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602139A RID: 136090 RVA: 0x00943894 File Offset: 0x00941A94
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightGroup_SyncToMainLight_LaunchScene_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602139B RID: 136091 RVA: 0x009438A9 File Offset: 0x00941AA9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TimeSlicedTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightGroup_SyncToMainLight_LaunchScene_C.__TimeSlicedTick_NativeFunctionPtr, null);
		}

		// Token: 0x0602139C RID: 136092 RVA: 0x009438C0 File Offset: 0x00941AC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_LightGroup_SyncToMainLight_LaunchScene_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LightGroup_SyncToMainLight_LaunchScene_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LightGroup_SyncToMainLight_LaunchScene_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightGroup_SyncToMainLight_LaunchScene_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightGroup_SyncToMainLight_LaunchScene_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602139D RID: 136093 RVA: 0x00943908 File Offset: 0x00941B08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_LightGroup_SyncToMainLight_LaunchScene_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LightGroup_SyncToMainLight_LaunchScene_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LightGroup_SyncToMainLight_LaunchScene_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightGroup_SyncToMainLight_LaunchScene_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightGroup_SyncToMainLight_LaunchScene_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602139E RID: 136094 RVA: 0x00943950 File Offset: 0x00941B50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_LightGroup_SyncToMainLight_LaunchScene(int EntryPoint)
		{
			BP_LightGroup_SyncToMainLight_LaunchScene_C.__ExecuteUbergraph_BP_LightGroup_SyncToMainLight_LaunchScene_FunctionParams* ptr = stackalloc BP_LightGroup_SyncToMainLight_LaunchScene_C.__ExecuteUbergraph_BP_LightGroup_SyncToMainLight_LaunchScene_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_LightGroup_SyncToMainLight_LaunchScene_C.__ExecuteUbergraph_BP_LightGroup_SyncToMainLight_LaunchScene_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightGroup_SyncToMainLight_LaunchScene_C.__ExecuteUbergraph_BP_LightGroup_SyncToMainLight_LaunchScene_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightGroup_SyncToMainLight_LaunchScene_C.__ExecuteUbergraph_BP_LightGroup_SyncToMainLight_LaunchScene_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602139F RID: 136095 RVA: 0x00943997 File Offset: 0x00941B97
		protected BP_LightGroup_SyncToMainLight_LaunchScene_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010B42 RID: 68418
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/VolumeGroupFade/BP_LightGroup_SyncToMainLight_LaunchScene.BP_LightGroup_SyncToMainLight_LaunchScene_C";

		// Token: 0x04010B43 RID: 68419
		private static IntPtr _ClassPtr;

		// Token: 0x04010B44 RID: 68420
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010B45 RID: 68421
		internal static int __PropertyOffset_0;

		// Token: 0x04010B46 RID: 68422
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010B47 RID: 68423
		internal static int __PropertyOffset_1;

		// Token: 0x04010B48 RID: 68424
		internal static int __PropertyOffset_2;

		// Token: 0x04010B49 RID: 68425
		internal static int __PropertyOffset_3;

		// Token: 0x04010B4A RID: 68426
		internal static int __PropertyOffset_4;

		// Token: 0x04010B4B RID: 68427
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<ALight, float> _LightInstensityMap;

		// Token: 0x04010B4C RID: 68428
		internal static int __PropertyOffset_5;

		// Token: 0x04010B4D RID: 68429
		internal static int __PropertyOffset_6;

		// Token: 0x04010B4E RID: 68430
		internal static int __PropertyOffset_7;

		// Token: 0x04010B4F RID: 68431
		internal static int __PropertyOffset_8;

		// Token: 0x04010B50 RID: 68432
		internal static int __PropertyOffset_9;

		// Token: 0x04010B51 RID: 68433
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<ALight> _Keys;

		// Token: 0x04010B52 RID: 68434
		internal static int __PropertyOffset_10;

		// Token: 0x04010B53 RID: 68435
		internal static int __PropertyOffset_11;

		// Token: 0x04010B54 RID: 68436
		internal static int __PropertyOffset_12;

		// Token: 0x04010B55 RID: 68437
		internal static int __PropertyOffset_13;

		// Token: 0x04010B56 RID: 68438
		private static IntPtr __Update_NativeFunctionPtr;

		// Token: 0x04010B57 RID: 68439
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010B58 RID: 68440
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010B59 RID: 68441
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010B5A RID: 68442
		private static IntPtr __TimeSlicedTick_NativeFunctionPtr;

		// Token: 0x04010B5B RID: 68443
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010B5C RID: 68444
		private static IntPtr __ExecuteUbergraph_BP_LightGroup_SyncToMainLight_LaunchScene_NativeFunctionPtr;

		// Token: 0x02009AA0 RID: 39584
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032205 RID: 205317
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009AA1 RID: 39585
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __ExecuteUbergraph_BP_LightGroup_SyncToMainLight_LaunchScene_FunctionParams
		{
			// Token: 0x04032206 RID: 205318
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
