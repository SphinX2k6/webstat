using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.GI;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Weather.BP
{
	// Token: 0x020039FE RID: 14846
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Weather/BP/BP_WeatherController.BP_WeatherController_C")]
	[UnrealStructLayout(1400, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1393)]
	public class BP_WeatherController_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E3BE RID: 123838 RVA: 0x008F03F3 File Offset: 0x008EE5F3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WeatherController_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Weather/BP/BP_WeatherController.BP_WeatherController_C");
			}
			return BP_WeatherController_C._ClassPtr;
		}

		// Token: 0x0601E3BF RID: 123839 RVA: 0x008F0418 File Offset: 0x008EE618
		public BP_WeatherController_C() : this(BuiltinUtils.AllocNativeUObject(BP_WeatherController_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E3C0 RID: 123840 RVA: 0x008F0440 File Offset: 0x008EE640
		[NullableContext(1)]
		public BP_WeatherController_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WeatherController_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700291E RID: 10526
		// (get) Token: 0x0601E3C1 RID: 123841 RVA: 0x008F0474 File Offset: 0x008EE674
		// (set) Token: 0x0601E3C2 RID: 123842 RVA: 0x008F04AD File Offset: 0x008EE6AD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_WeatherController_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_WeatherController_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700291F RID: 10527
		// (get) Token: 0x0601E3C3 RID: 123843 RVA: 0x008F04CE File Offset: 0x008EE6CE
		// (set) Token: 0x0601E3C4 RID: 123844 RVA: 0x008F04E2 File Offset: 0x008EE6E2
		public unsafe UChildActorComponent SurfaceRipple
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeatherController_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeatherController_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002920 RID: 10528
		// (get) Token: 0x0601E3C5 RID: 123845 RVA: 0x008F04F7 File Offset: 0x008EE6F7
		// (set) Token: 0x0601E3C6 RID: 123846 RVA: 0x008F050B File Offset: 0x008EE70B
		public unsafe UChildActorComponent RainDrop
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeatherController_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeatherController_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002921 RID: 10529
		// (get) Token: 0x0601E3C7 RID: 123847 RVA: 0x008F0520 File Offset: 0x008EE720
		// (set) Token: 0x0601E3C8 RID: 123848 RVA: 0x008F0534 File Offset: 0x008EE734
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeatherController_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeatherController_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002922 RID: 10530
		// (get) Token: 0x0601E3C9 RID: 123849 RVA: 0x008F0549 File Offset: 0x008EE749
		// (set) Token: 0x0601E3CA RID: 123850 RVA: 0x008F055D File Offset: 0x008EE75D
		public unsafe BP_GlobalGI_C GlobalGI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_GlobalGI_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeatherController_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeatherController_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002923 RID: 10531
		// (get) Token: 0x0601E3CB RID: 123851 RVA: 0x008F0572 File Offset: 0x008EE772
		// (set) Token: 0x0601E3CC RID: 123852 RVA: 0x008F0582 File Offset: 0x008EE782
		public unsafe bool GlobalGI_Legality
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WeatherController_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WeatherController_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002924 RID: 10532
		// (get) Token: 0x0601E3CD RID: 123853 RVA: 0x008F0593 File Offset: 0x008EE793
		// (set) Token: 0x0601E3CE RID: 123854 RVA: 0x008F05A3 File Offset: 0x008EE7A3
		public unsafe float RainIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WeatherController_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WeatherController_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17002925 RID: 10533
		// (get) Token: 0x0601E3CF RID: 123855 RVA: 0x008F05B4 File Offset: 0x008EE7B4
		// (set) Token: 0x0601E3D0 RID: 123856 RVA: 0x008F05C4 File Offset: 0x008EE7C4
		public unsafe float Gravity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WeatherController_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WeatherController_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17002926 RID: 10534
		// (get) Token: 0x0601E3D1 RID: 123857 RVA: 0x008F05D5 File Offset: 0x008EE7D5
		// (set) Token: 0x0601E3D2 RID: 123858 RVA: 0x008F05E5 File Offset: 0x008EE7E5
		public unsafe bool IsInCave
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WeatherController_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WeatherController_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002927 RID: 10535
		// (get) Token: 0x0601E3D3 RID: 123859 RVA: 0x008F05F6 File Offset: 0x008EE7F6
		// (set) Token: 0x0601E3D4 RID: 123860 RVA: 0x008F060A File Offset: 0x008EE80A
		public unsafe FVectorDouble PostCharacterPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WeatherController_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WeatherController_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002928 RID: 10536
		// (get) Token: 0x0601E3D5 RID: 123861 RVA: 0x008F061F File Offset: 0x008EE81F
		// (set) Token: 0x0601E3D6 RID: 123862 RVA: 0x008F062F File Offset: 0x008EE82F
		public unsafe bool EditorUpdateDroplets
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WeatherController_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WeatherController_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601E3D7 RID: 123863 RVA: 0x008F0640 File Offset: 0x008EE840
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnRep_GlobalGI()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeatherController_C.__OnRep_GlobalGI_NativeFunctionPtr, null);
		}

		// Token: 0x0601E3D8 RID: 123864 RVA: 0x008F0654 File Offset: 0x008EE854
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeatherController_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601E3D9 RID: 123865 RVA: 0x008F0668 File Offset: 0x008EE868
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WeatherController_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E3DA RID: 123866 RVA: 0x008F067D File Offset: 0x008EE87D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeatherController_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601E3DB RID: 123867 RVA: 0x008F0691 File Offset: 0x008EE891
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WeatherController_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E3DC RID: 123868 RVA: 0x008F06A8 File Offset: 0x008EE8A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_WeatherController_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WeatherController_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WeatherController_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeatherController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeatherController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E3DD RID: 123869 RVA: 0x008F06F0 File Offset: 0x008EE8F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_WeatherController_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WeatherController_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WeatherController_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeatherController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WeatherController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E3DE RID: 123870 RVA: 0x008F0738 File Offset: 0x008EE938
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_WeatherController_C.__EditorTick_FunctionParams* ptr = stackalloc BP_WeatherController_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WeatherController_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeatherController_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeatherController_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E3DF RID: 123871 RVA: 0x008F0780 File Offset: 0x008EE980
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_WeatherController_C.__EditorTick_FunctionParams* ptr = stackalloc BP_WeatherController_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WeatherController_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeatherController_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WeatherController_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E3E0 RID: 123872 RVA: 0x008F07C7 File Offset: 0x008EE9C7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TracingCave()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeatherController_C.__TracingCave_NativeFunctionPtr, null);
		}

		// Token: 0x0601E3E1 RID: 123873 RVA: 0x008F07DC File Offset: 0x008EE9DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_WeatherController(int EntryPoint)
		{
			BP_WeatherController_C.__ExecuteUbergraph_BP_WeatherController_FunctionParams* ptr = stackalloc BP_WeatherController_C.__ExecuteUbergraph_BP_WeatherController_FunctionParams[(UIntPtr)319] + 15L / (long)sizeof(BP_WeatherController_C.__ExecuteUbergraph_BP_WeatherController_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeatherController_C.__ExecuteUbergraph_BP_WeatherController_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WeatherController_C.__ExecuteUbergraph_BP_WeatherController_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E3E2 RID: 123874 RVA: 0x008F0826 File Offset: 0x008EEA26
		protected BP_WeatherController_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EDCD RID: 60877
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Weather/BP/BP_WeatherController.BP_WeatherController_C";

		// Token: 0x0400EDCE RID: 60878
		private static IntPtr _ClassPtr;

		// Token: 0x0400EDCF RID: 60879
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400EDD0 RID: 60880
		internal static int __PropertyOffset_0;

		// Token: 0x0400EDD1 RID: 60881
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400EDD2 RID: 60882
		internal static int __PropertyOffset_1;

		// Token: 0x0400EDD3 RID: 60883
		internal static int __PropertyOffset_2;

		// Token: 0x0400EDD4 RID: 60884
		internal static int __PropertyOffset_3;

		// Token: 0x0400EDD5 RID: 60885
		internal static int __PropertyOffset_4;

		// Token: 0x0400EDD6 RID: 60886
		internal static int __PropertyOffset_5;

		// Token: 0x0400EDD7 RID: 60887
		internal static int __PropertyOffset_6;

		// Token: 0x0400EDD8 RID: 60888
		internal static int __PropertyOffset_7;

		// Token: 0x0400EDD9 RID: 60889
		internal static int __PropertyOffset_8;

		// Token: 0x0400EDDA RID: 60890
		internal static int __PropertyOffset_9;

		// Token: 0x0400EDDB RID: 60891
		internal static int __PropertyOffset_10;

		// Token: 0x0400EDDC RID: 60892
		private static IntPtr __OnRep_GlobalGI_NativeFunctionPtr;

		// Token: 0x0400EDDD RID: 60893
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400EDDE RID: 60894
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400EDDF RID: 60895
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400EDE0 RID: 60896
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400EDE1 RID: 60897
		private static IntPtr __TracingCave_NativeFunctionPtr;

		// Token: 0x0400EDE2 RID: 60898
		private static IntPtr __ExecuteUbergraph_BP_WeatherController_NativeFunctionPtr;

		// Token: 0x02009790 RID: 38800
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031D4B RID: 204107
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009791 RID: 38801
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031D4C RID: 204108
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009792 RID: 38802
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 304)]
		protected ref struct __ExecuteUbergraph_BP_WeatherController_FunctionParams
		{
			// Token: 0x04031D4D RID: 204109
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
