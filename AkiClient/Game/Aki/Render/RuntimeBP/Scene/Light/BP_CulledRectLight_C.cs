using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A7B RID: 14971
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_CulledRectLight.BP_CulledRectLight_C")]
	[UnrealStructLayout(1392, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1385)]
	public class BP_CulledRectLight_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject, IInterface_KuroLightBP, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0601F43F RID: 128063 RVA: 0x0090D44B File Offset: 0x0090B64B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CulledRectLight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_CulledRectLight.BP_CulledRectLight_C");
			}
			return BP_CulledRectLight_C._ClassPtr;
		}

		// Token: 0x0601F440 RID: 128064 RVA: 0x0090D46F File Offset: 0x0090B66F
		int IInterface_KuroLightBP.InterfaceOffset()
		{
			return BP_CulledRectLight_C.__InterfaceOffset_IInterface_KuroLightBP;
		}

		// Token: 0x0601F441 RID: 128065 RVA: 0x0090D478 File Offset: 0x0090B678
		public BP_CulledRectLight_C() : this(BuiltinUtils.AllocNativeUObject(BP_CulledRectLight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F442 RID: 128066 RVA: 0x0090D4A0 File Offset: 0x0090B6A0
		[NullableContext(1)]
		public BP_CulledRectLight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CulledRectLight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002ED9 RID: 11993
		// (get) Token: 0x0601F443 RID: 128067 RVA: 0x0090D4D4 File Offset: 0x0090B6D4
		// (set) Token: 0x0601F444 RID: 128068 RVA: 0x0090D50D File Offset: 0x0090B70D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CulledRectLight_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CulledRectLight_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002EDA RID: 11994
		// (get) Token: 0x0601F445 RID: 128069 RVA: 0x0090D52E File Offset: 0x0090B72E
		// (set) Token: 0x0601F446 RID: 128070 RVA: 0x0090D542 File Offset: 0x0090B742
		public unsafe URectLightComponent RectLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<URectLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledRectLight_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledRectLight_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002EDB RID: 11995
		// (get) Token: 0x0601F447 RID: 128071 RVA: 0x0090D557 File Offset: 0x0090B757
		// (set) Token: 0x0601F448 RID: 128072 RVA: 0x0090D56B File Offset: 0x0090B76B
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledRectLight_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledRectLight_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002EDC RID: 11996
		// (get) Token: 0x0601F449 RID: 128073 RVA: 0x0090D580 File Offset: 0x0090B780
		// (set) Token: 0x0601F44A RID: 128074 RVA: 0x0090D594 File Offset: 0x0090B794
		public unsafe UChildActorComponent PointC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledRectLight_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledRectLight_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002EDD RID: 11997
		// (get) Token: 0x0601F44B RID: 128075 RVA: 0x0090D5A9 File Offset: 0x0090B7A9
		// (set) Token: 0x0601F44C RID: 128076 RVA: 0x0090D5BD File Offset: 0x0090B7BD
		public unsafe UChildActorComponent PointB
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledRectLight_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledRectLight_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002EDE RID: 11998
		// (get) Token: 0x0601F44D RID: 128077 RVA: 0x0090D5D2 File Offset: 0x0090B7D2
		// (set) Token: 0x0601F44E RID: 128078 RVA: 0x0090D5E6 File Offset: 0x0090B7E6
		public unsafe UChildActorComponent PointA
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledRectLight_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledRectLight_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17002EDF RID: 11999
		// (get) Token: 0x0601F44F RID: 128079 RVA: 0x0090D5FB File Offset: 0x0090B7FB
		// (set) Token: 0x0601F450 RID: 128080 RVA: 0x0090D60F File Offset: 0x0090B80F
		public unsafe UChildActorComponent PointO
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledRectLight_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledRectLight_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17002EE0 RID: 12000
		// (get) Token: 0x0601F451 RID: 128081 RVA: 0x0090D624 File Offset: 0x0090B824
		// (set) Token: 0x0601F452 RID: 128082 RVA: 0x0090D638 File Offset: 0x0090B838
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledRectLight_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledRectLight_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17002EE1 RID: 12001
		// (get) Token: 0x0601F453 RID: 128083 RVA: 0x0090D64D File Offset: 0x0090B84D
		// (set) Token: 0x0601F454 RID: 128084 RVA: 0x0090D65D File Offset: 0x0090B85D
		public unsafe bool bDirty
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CulledRectLight_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CulledRectLight_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601F455 RID: 128085 RVA: 0x0090D670 File Offset: 0x0090B870
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual int GetPlacementSortOrder()
		{
			BP_CulledRectLight_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_CulledRectLight_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CulledRectLight_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CulledRectLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CulledRectLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601F456 RID: 128086 RVA: 0x0090D6B8 File Offset: 0x0090B8B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual int GetPlacementSortOrder_Implementation()
		{
			BP_CulledRectLight_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_CulledRectLight_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CulledRectLight_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CulledRectLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CulledRectLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601F457 RID: 128087 RVA: 0x0090D700 File Offset: 0x0090B900
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_CulledRectLight_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CulledRectLight_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CulledRectLight_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CulledRectLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CulledRectLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F458 RID: 128088 RVA: 0x0090D748 File Offset: 0x0090B948
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_CulledRectLight_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CulledRectLight_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CulledRectLight_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CulledRectLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CulledRectLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F459 RID: 128089 RVA: 0x0090D790 File Offset: 0x0090B990
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CulledRectLight(int EntryPoint)
		{
			BP_CulledRectLight_C.__ExecuteUbergraph_BP_CulledRectLight_FunctionParams* ptr = stackalloc BP_CulledRectLight_C.__ExecuteUbergraph_BP_CulledRectLight_FunctionParams[(UIntPtr)383] + 15L / (long)sizeof(BP_CulledRectLight_C.__ExecuteUbergraph_BP_CulledRectLight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CulledRectLight_C.__ExecuteUbergraph_BP_CulledRectLight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CulledRectLight_C.__ExecuteUbergraph_BP_CulledRectLight_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F45A RID: 128090 RVA: 0x0090D7DA File Offset: 0x0090B9DA
		protected BP_CulledRectLight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F835 RID: 63541
		internal static int __InterfaceOffset_IInterface_KuroLightBP;

		// Token: 0x0400F836 RID: 63542
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_CulledRectLight.BP_CulledRectLight_C";

		// Token: 0x0400F837 RID: 63543
		private static IntPtr _ClassPtr;

		// Token: 0x0400F838 RID: 63544
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F839 RID: 63545
		internal static int __PropertyOffset_0;

		// Token: 0x0400F83A RID: 63546
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F83B RID: 63547
		internal static int __PropertyOffset_1;

		// Token: 0x0400F83C RID: 63548
		internal static int __PropertyOffset_2;

		// Token: 0x0400F83D RID: 63549
		internal static int __PropertyOffset_3;

		// Token: 0x0400F83E RID: 63550
		internal static int __PropertyOffset_4;

		// Token: 0x0400F83F RID: 63551
		internal static int __PropertyOffset_5;

		// Token: 0x0400F840 RID: 63552
		internal static int __PropertyOffset_6;

		// Token: 0x0400F841 RID: 63553
		internal static int __PropertyOffset_7;

		// Token: 0x0400F842 RID: 63554
		internal static int __PropertyOffset_8;

		// Token: 0x0400F843 RID: 63555
		private static IntPtr __GetPlacementSortOrder_NativeFunctionPtr;

		// Token: 0x0400F844 RID: 63556
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400F845 RID: 63557
		private static IntPtr __ExecuteUbergraph_BP_CulledRectLight_NativeFunctionPtr;

		// Token: 0x020098BC RID: 39100
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetPlacementSortOrder_FunctionParams
		{
			// Token: 0x04031F0D RID: 204557
			[FieldOffset(0)]
			public int __Result;
		}

		// Token: 0x020098BD RID: 39101
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031F0E RID: 204558
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098BE RID: 39102
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 368)]
		protected ref struct __ExecuteUbergraph_BP_CulledRectLight_FunctionParams
		{
			// Token: 0x04031F0F RID: 204559
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
