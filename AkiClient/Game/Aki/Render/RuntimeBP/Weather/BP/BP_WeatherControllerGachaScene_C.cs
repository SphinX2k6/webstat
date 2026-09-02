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
	// Token: 0x020039FD RID: 14845
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Weather/BP/BP_WeatherControllerGachaScene.BP_WeatherControllerGachaScene_C")]
	[UnrealStructLayout(1408, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1401)]
	public class BP_WeatherControllerGachaScene_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E397 RID: 123799 RVA: 0x008EFF8F File Offset: 0x008EE18F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WeatherControllerGachaScene_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Weather/BP/BP_WeatherControllerGachaScene.BP_WeatherControllerGachaScene_C");
			}
			return BP_WeatherControllerGachaScene_C._ClassPtr;
		}

		// Token: 0x0601E398 RID: 123800 RVA: 0x008EFFB4 File Offset: 0x008EE1B4
		public BP_WeatherControllerGachaScene_C() : this(BuiltinUtils.AllocNativeUObject(BP_WeatherControllerGachaScene_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E399 RID: 123801 RVA: 0x008EFFDC File Offset: 0x008EE1DC
		[NullableContext(1)]
		public BP_WeatherControllerGachaScene_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WeatherControllerGachaScene_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002912 RID: 10514
		// (get) Token: 0x0601E39A RID: 123802 RVA: 0x008F0010 File Offset: 0x008EE210
		// (set) Token: 0x0601E39B RID: 123803 RVA: 0x008F0049 File Offset: 0x008EE249
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_WeatherControllerGachaScene_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_WeatherControllerGachaScene_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002913 RID: 10515
		// (get) Token: 0x0601E39C RID: 123804 RVA: 0x008F006A File Offset: 0x008EE26A
		// (set) Token: 0x0601E39D RID: 123805 RVA: 0x008F007E File Offset: 0x008EE27E
		public unsafe UKuroGameBudgetComponent KuroGameBudget
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroGameBudgetComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeatherControllerGachaScene_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeatherControllerGachaScene_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002914 RID: 10516
		// (get) Token: 0x0601E39E RID: 123806 RVA: 0x008F0093 File Offset: 0x008EE293
		// (set) Token: 0x0601E39F RID: 123807 RVA: 0x008F00A7 File Offset: 0x008EE2A7
		public unsafe UChildActorComponent SurfaceRipple
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeatherControllerGachaScene_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeatherControllerGachaScene_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002915 RID: 10517
		// (get) Token: 0x0601E3A0 RID: 123808 RVA: 0x008F00BC File Offset: 0x008EE2BC
		// (set) Token: 0x0601E3A1 RID: 123809 RVA: 0x008F00D0 File Offset: 0x008EE2D0
		public unsafe UChildActorComponent RainDrop
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeatherControllerGachaScene_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeatherControllerGachaScene_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002916 RID: 10518
		// (get) Token: 0x0601E3A2 RID: 123810 RVA: 0x008F00E5 File Offset: 0x008EE2E5
		// (set) Token: 0x0601E3A3 RID: 123811 RVA: 0x008F00F9 File Offset: 0x008EE2F9
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeatherControllerGachaScene_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeatherControllerGachaScene_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002917 RID: 10519
		// (get) Token: 0x0601E3A4 RID: 123812 RVA: 0x008F010E File Offset: 0x008EE30E
		// (set) Token: 0x0601E3A5 RID: 123813 RVA: 0x008F0122 File Offset: 0x008EE322
		public unsafe BP_GlobalGI_C GlobalGI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_GlobalGI_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeatherControllerGachaScene_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeatherControllerGachaScene_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17002918 RID: 10520
		// (get) Token: 0x0601E3A6 RID: 123814 RVA: 0x008F0137 File Offset: 0x008EE337
		// (set) Token: 0x0601E3A7 RID: 123815 RVA: 0x008F0147 File Offset: 0x008EE347
		public unsafe bool GlobalGI_Legality
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WeatherControllerGachaScene_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WeatherControllerGachaScene_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002919 RID: 10521
		// (get) Token: 0x0601E3A8 RID: 123816 RVA: 0x008F0158 File Offset: 0x008EE358
		// (set) Token: 0x0601E3A9 RID: 123817 RVA: 0x008F0168 File Offset: 0x008EE368
		public unsafe float RainIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WeatherControllerGachaScene_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WeatherControllerGachaScene_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700291A RID: 10522
		// (get) Token: 0x0601E3AA RID: 123818 RVA: 0x008F0179 File Offset: 0x008EE379
		// (set) Token: 0x0601E3AB RID: 123819 RVA: 0x008F0189 File Offset: 0x008EE389
		public unsafe float Gravity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WeatherControllerGachaScene_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WeatherControllerGachaScene_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700291B RID: 10523
		// (get) Token: 0x0601E3AC RID: 123820 RVA: 0x008F019A File Offset: 0x008EE39A
		// (set) Token: 0x0601E3AD RID: 123821 RVA: 0x008F01AA File Offset: 0x008EE3AA
		public unsafe bool IsInCave
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WeatherControllerGachaScene_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WeatherControllerGachaScene_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700291C RID: 10524
		// (get) Token: 0x0601E3AE RID: 123822 RVA: 0x008F01BB File Offset: 0x008EE3BB
		// (set) Token: 0x0601E3AF RID: 123823 RVA: 0x008F01CF File Offset: 0x008EE3CF
		public unsafe FVectorDouble PostCharacterPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WeatherControllerGachaScene_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WeatherControllerGachaScene_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700291D RID: 10525
		// (get) Token: 0x0601E3B0 RID: 123824 RVA: 0x008F01E4 File Offset: 0x008EE3E4
		// (set) Token: 0x0601E3B1 RID: 123825 RVA: 0x008F01F4 File Offset: 0x008EE3F4
		public unsafe bool EditorUpdateDroplets
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WeatherControllerGachaScene_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WeatherControllerGachaScene_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601E3B2 RID: 123826 RVA: 0x008F0205 File Offset: 0x008EE405
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnRep_GlobalGI()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeatherControllerGachaScene_C.__OnRep_GlobalGI_NativeFunctionPtr, null);
		}

		// Token: 0x0601E3B3 RID: 123827 RVA: 0x008F0219 File Offset: 0x008EE419
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeatherControllerGachaScene_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601E3B4 RID: 123828 RVA: 0x008F022D File Offset: 0x008EE42D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WeatherControllerGachaScene_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E3B5 RID: 123829 RVA: 0x008F0242 File Offset: 0x008EE442
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeatherControllerGachaScene_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601E3B6 RID: 123830 RVA: 0x008F0256 File Offset: 0x008EE456
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WeatherControllerGachaScene_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E3B7 RID: 123831 RVA: 0x008F026C File Offset: 0x008EE46C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_WeatherControllerGachaScene_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WeatherControllerGachaScene_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WeatherControllerGachaScene_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeatherControllerGachaScene_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeatherControllerGachaScene_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E3B8 RID: 123832 RVA: 0x008F02B4 File Offset: 0x008EE4B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_WeatherControllerGachaScene_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WeatherControllerGachaScene_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WeatherControllerGachaScene_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeatherControllerGachaScene_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WeatherControllerGachaScene_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E3B9 RID: 123833 RVA: 0x008F02FC File Offset: 0x008EE4FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_WeatherControllerGachaScene_C.__EditorTick_FunctionParams* ptr = stackalloc BP_WeatherControllerGachaScene_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WeatherControllerGachaScene_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeatherControllerGachaScene_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeatherControllerGachaScene_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E3BA RID: 123834 RVA: 0x008F0344 File Offset: 0x008EE544
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_WeatherControllerGachaScene_C.__EditorTick_FunctionParams* ptr = stackalloc BP_WeatherControllerGachaScene_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WeatherControllerGachaScene_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeatherControllerGachaScene_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WeatherControllerGachaScene_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E3BB RID: 123835 RVA: 0x008F038B File Offset: 0x008EE58B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TracingCave()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeatherControllerGachaScene_C.__TracingCave_NativeFunctionPtr, null);
		}

		// Token: 0x0601E3BC RID: 123836 RVA: 0x008F03A0 File Offset: 0x008EE5A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_WeatherControllerGachaScene(int EntryPoint)
		{
			BP_WeatherControllerGachaScene_C.__ExecuteUbergraph_BP_WeatherControllerGachaScene_FunctionParams* ptr = stackalloc BP_WeatherControllerGachaScene_C.__ExecuteUbergraph_BP_WeatherControllerGachaScene_FunctionParams[(UIntPtr)319] + 15L / (long)sizeof(BP_WeatherControllerGachaScene_C.__ExecuteUbergraph_BP_WeatherControllerGachaScene_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeatherControllerGachaScene_C.__ExecuteUbergraph_BP_WeatherControllerGachaScene_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WeatherControllerGachaScene_C.__ExecuteUbergraph_BP_WeatherControllerGachaScene_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E3BD RID: 123837 RVA: 0x008F03EA File Offset: 0x008EE5EA
		protected BP_WeatherControllerGachaScene_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EDB6 RID: 60854
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Weather/BP/BP_WeatherControllerGachaScene.BP_WeatherControllerGachaScene_C";

		// Token: 0x0400EDB7 RID: 60855
		private static IntPtr _ClassPtr;

		// Token: 0x0400EDB8 RID: 60856
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400EDB9 RID: 60857
		internal static int __PropertyOffset_0;

		// Token: 0x0400EDBA RID: 60858
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400EDBB RID: 60859
		internal static int __PropertyOffset_1;

		// Token: 0x0400EDBC RID: 60860
		internal static int __PropertyOffset_2;

		// Token: 0x0400EDBD RID: 60861
		internal static int __PropertyOffset_3;

		// Token: 0x0400EDBE RID: 60862
		internal static int __PropertyOffset_4;

		// Token: 0x0400EDBF RID: 60863
		internal static int __PropertyOffset_5;

		// Token: 0x0400EDC0 RID: 60864
		internal static int __PropertyOffset_6;

		// Token: 0x0400EDC1 RID: 60865
		internal static int __PropertyOffset_7;

		// Token: 0x0400EDC2 RID: 60866
		internal static int __PropertyOffset_8;

		// Token: 0x0400EDC3 RID: 60867
		internal static int __PropertyOffset_9;

		// Token: 0x0400EDC4 RID: 60868
		internal static int __PropertyOffset_10;

		// Token: 0x0400EDC5 RID: 60869
		internal static int __PropertyOffset_11;

		// Token: 0x0400EDC6 RID: 60870
		private static IntPtr __OnRep_GlobalGI_NativeFunctionPtr;

		// Token: 0x0400EDC7 RID: 60871
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400EDC8 RID: 60872
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400EDC9 RID: 60873
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400EDCA RID: 60874
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400EDCB RID: 60875
		private static IntPtr __TracingCave_NativeFunctionPtr;

		// Token: 0x0400EDCC RID: 60876
		private static IntPtr __ExecuteUbergraph_BP_WeatherControllerGachaScene_NativeFunctionPtr;

		// Token: 0x0200978D RID: 38797
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031D48 RID: 204104
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200978E RID: 38798
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031D49 RID: 204105
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200978F RID: 38799
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 304)]
		protected ref struct __ExecuteUbergraph_BP_WeatherControllerGachaScene_FunctionParams
		{
			// Token: 0x04031D4A RID: 204106
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
