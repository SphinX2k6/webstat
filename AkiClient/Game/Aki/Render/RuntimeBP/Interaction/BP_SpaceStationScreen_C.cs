using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Interaction
{
	// Token: 0x02003C86 RID: 15494
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Interaction/BP_SpaceStationScreen.BP_SpaceStationScreen_C")]
	[UnrealStructLayout(1392, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1388)]
	public class BP_SpaceStationScreen_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024126 RID: 147750 RVA: 0x00994010 File Offset: 0x00992210
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SpaceStationScreen_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Interaction/BP_SpaceStationScreen.BP_SpaceStationScreen_C");
			}
			return BP_SpaceStationScreen_C._ClassPtr;
		}

		// Token: 0x06024127 RID: 147751 RVA: 0x00994034 File Offset: 0x00992234
		public BP_SpaceStationScreen_C() : this(BuiltinUtils.AllocNativeUObject(BP_SpaceStationScreen_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024128 RID: 147752 RVA: 0x0099405C File Offset: 0x0099225C
		[NullableContext(1)]
		public BP_SpaceStationScreen_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SpaceStationScreen_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170049D0 RID: 18896
		// (get) Token: 0x06024129 RID: 147753 RVA: 0x00994090 File Offset: 0x00992290
		// (set) Token: 0x0602412A RID: 147754 RVA: 0x009940C9 File Offset: 0x009922C9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SpaceStationScreen_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SpaceStationScreen_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170049D1 RID: 18897
		// (get) Token: 0x0602412B RID: 147755 RVA: 0x009940EA File Offset: 0x009922EA
		// (set) Token: 0x0602412C RID: 147756 RVA: 0x009940FE File Offset: 0x009922FE
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpaceStationScreen_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpaceStationScreen_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170049D2 RID: 18898
		// (get) Token: 0x0602412D RID: 147757 RVA: 0x00994113 File Offset: 0x00992313
		// (set) Token: 0x0602412E RID: 147758 RVA: 0x00994127 File Offset: 0x00992327
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpaceStationScreen_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpaceStationScreen_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170049D3 RID: 18899
		// (get) Token: 0x0602412F RID: 147759 RVA: 0x0099413C File Offset: 0x0099233C
		// (set) Token: 0x06024130 RID: 147760 RVA: 0x00994150 File Offset: 0x00992350
		public unsafe UStaticMesh 静态网格体
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpaceStationScreen_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpaceStationScreen_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170049D4 RID: 18900
		// (get) Token: 0x06024131 RID: 147761 RVA: 0x00994165 File Offset: 0x00992365
		// (set) Token: 0x06024132 RID: 147762 RVA: 0x00994179 File Offset: 0x00992379
		public unsafe UMaterialInstanceDynamic DynamicMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpaceStationScreen_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpaceStationScreen_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170049D5 RID: 18901
		// (get) Token: 0x06024133 RID: 147763 RVA: 0x0099418E File Offset: 0x0099238E
		// (set) Token: 0x06024134 RID: 147764 RVA: 0x0099419E File Offset: 0x0099239E
		public unsafe float MasterSwitch
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SpaceStationScreen_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SpaceStationScreen_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170049D6 RID: 18902
		// (get) Token: 0x06024135 RID: 147765 RVA: 0x009941AF File Offset: 0x009923AF
		// (set) Token: 0x06024136 RID: 147766 RVA: 0x009941BF File Offset: 0x009923BF
		public unsafe float R_BSwitch
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SpaceStationScreen_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SpaceStationScreen_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170049D7 RID: 18903
		// (get) Token: 0x06024137 RID: 147767 RVA: 0x009941D0 File Offset: 0x009923D0
		// (set) Token: 0x06024138 RID: 147768 RVA: 0x009941E0 File Offset: 0x009923E0
		public unsafe float AMSwitch
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SpaceStationScreen_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SpaceStationScreen_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170049D8 RID: 18904
		// (get) Token: 0x06024139 RID: 147769 RVA: 0x009941F1 File Offset: 0x009923F1
		// (set) Token: 0x0602413A RID: 147770 RVA: 0x00994205 File Offset: 0x00992405
		public unsafe FVector ScreenContent_Tile
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SpaceStationScreen_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SpaceStationScreen_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170049D9 RID: 18905
		// (get) Token: 0x0602413B RID: 147771 RVA: 0x0099421A File Offset: 0x0099241A
		// (set) Token: 0x0602413C RID: 147772 RVA: 0x0099422E File Offset: 0x0099242E
		public unsafe FVector ScreenContent_Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SpaceStationScreen_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SpaceStationScreen_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x0602413D RID: 147773 RVA: 0x00994243 File Offset: 0x00992443
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SpaceStationScreen_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602413E RID: 147774 RVA: 0x00994257 File Offset: 0x00992457
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SpaceStationScreen_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602413F RID: 147775 RVA: 0x0099426C File Offset: 0x0099246C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SpaceStationScreen_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024140 RID: 147776 RVA: 0x00994280 File Offset: 0x00992480
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SpaceStationScreen_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024141 RID: 147777 RVA: 0x00994298 File Offset: 0x00992498
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SpaceStationScreen_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SpaceStationScreen_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SpaceStationScreen_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SpaceStationScreen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SpaceStationScreen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024142 RID: 147778 RVA: 0x009942E0 File Offset: 0x009924E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SpaceStationScreen_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SpaceStationScreen_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SpaceStationScreen_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SpaceStationScreen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SpaceStationScreen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024143 RID: 147779 RVA: 0x00994328 File Offset: 0x00992528
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_SpaceStationScreen_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SpaceStationScreen_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SpaceStationScreen_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SpaceStationScreen_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SpaceStationScreen_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024144 RID: 147780 RVA: 0x00994370 File Offset: 0x00992570
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_SpaceStationScreen_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SpaceStationScreen_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SpaceStationScreen_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SpaceStationScreen_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SpaceStationScreen_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024145 RID: 147781 RVA: 0x009943B8 File Offset: 0x009925B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SpaceStationScreen(int EntryPoint)
		{
			BP_SpaceStationScreen_C.__ExecuteUbergraph_BP_SpaceStationScreen_FunctionParams* ptr = stackalloc BP_SpaceStationScreen_C.__ExecuteUbergraph_BP_SpaceStationScreen_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_SpaceStationScreen_C.__ExecuteUbergraph_BP_SpaceStationScreen_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SpaceStationScreen_C.__ExecuteUbergraph_BP_SpaceStationScreen_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SpaceStationScreen_C.__ExecuteUbergraph_BP_SpaceStationScreen_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024146 RID: 147782 RVA: 0x009943FF File Offset: 0x009925FF
		protected BP_SpaceStationScreen_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401270D RID: 75533
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Interaction/BP_SpaceStationScreen.BP_SpaceStationScreen_C";

		// Token: 0x0401270E RID: 75534
		private static IntPtr _ClassPtr;

		// Token: 0x0401270F RID: 75535
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012710 RID: 75536
		internal static int __PropertyOffset_0;

		// Token: 0x04012711 RID: 75537
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012712 RID: 75538
		internal static int __PropertyOffset_1;

		// Token: 0x04012713 RID: 75539
		internal static int __PropertyOffset_2;

		// Token: 0x04012714 RID: 75540
		internal static int __PropertyOffset_3;

		// Token: 0x04012715 RID: 75541
		internal static int __PropertyOffset_4;

		// Token: 0x04012716 RID: 75542
		internal static int __PropertyOffset_5;

		// Token: 0x04012717 RID: 75543
		internal static int __PropertyOffset_6;

		// Token: 0x04012718 RID: 75544
		internal static int __PropertyOffset_7;

		// Token: 0x04012719 RID: 75545
		internal static int __PropertyOffset_8;

		// Token: 0x0401271A RID: 75546
		internal static int __PropertyOffset_9;

		// Token: 0x0401271B RID: 75547
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401271C RID: 75548
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401271D RID: 75549
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401271E RID: 75550
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401271F RID: 75551
		private static IntPtr __ExecuteUbergraph_BP_SpaceStationScreen_NativeFunctionPtr;

		// Token: 0x02009D8B RID: 40331
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032780 RID: 206720
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D8C RID: 40332
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032781 RID: 206721
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D8D RID: 40333
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __ExecuteUbergraph_BP_SpaceStationScreen_FunctionParams
		{
			// Token: 0x04032782 RID: 206722
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
