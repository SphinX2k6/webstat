using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A7A RID: 14970
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_CulledPointLight.BP_CulledPointLight_C")]
	[UnrealStructLayout(1392, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1385)]
	public class BP_CulledPointLight_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject, IInterface_KuroLightBP, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0601F423 RID: 128035 RVA: 0x0090D0B4 File Offset: 0x0090B2B4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CulledPointLight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_CulledPointLight.BP_CulledPointLight_C");
			}
			return BP_CulledPointLight_C._ClassPtr;
		}

		// Token: 0x0601F424 RID: 128036 RVA: 0x0090D0D8 File Offset: 0x0090B2D8
		int IInterface_KuroLightBP.InterfaceOffset()
		{
			return BP_CulledPointLight_C.__InterfaceOffset_IInterface_KuroLightBP;
		}

		// Token: 0x0601F425 RID: 128037 RVA: 0x0090D0E0 File Offset: 0x0090B2E0
		public BP_CulledPointLight_C() : this(BuiltinUtils.AllocNativeUObject(BP_CulledPointLight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F426 RID: 128038 RVA: 0x0090D108 File Offset: 0x0090B308
		[NullableContext(1)]
		public BP_CulledPointLight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CulledPointLight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002ED0 RID: 11984
		// (get) Token: 0x0601F427 RID: 128039 RVA: 0x0090D13C File Offset: 0x0090B33C
		// (set) Token: 0x0601F428 RID: 128040 RVA: 0x0090D175 File Offset: 0x0090B375
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CulledPointLight_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CulledPointLight_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002ED1 RID: 11985
		// (get) Token: 0x0601F429 RID: 128041 RVA: 0x0090D196 File Offset: 0x0090B396
		// (set) Token: 0x0601F42A RID: 128042 RVA: 0x0090D1AA File Offset: 0x0090B3AA
		public unsafe UPointLightComponent PointLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledPointLight_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledPointLight_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002ED2 RID: 11986
		// (get) Token: 0x0601F42B RID: 128043 RVA: 0x0090D1BF File Offset: 0x0090B3BF
		// (set) Token: 0x0601F42C RID: 128044 RVA: 0x0090D1D3 File Offset: 0x0090B3D3
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledPointLight_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledPointLight_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002ED3 RID: 11987
		// (get) Token: 0x0601F42D RID: 128045 RVA: 0x0090D1E8 File Offset: 0x0090B3E8
		// (set) Token: 0x0601F42E RID: 128046 RVA: 0x0090D1FC File Offset: 0x0090B3FC
		public unsafe UChildActorComponent PointC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledPointLight_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledPointLight_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002ED4 RID: 11988
		// (get) Token: 0x0601F42F RID: 128047 RVA: 0x0090D211 File Offset: 0x0090B411
		// (set) Token: 0x0601F430 RID: 128048 RVA: 0x0090D225 File Offset: 0x0090B425
		public unsafe UChildActorComponent PointB
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledPointLight_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledPointLight_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002ED5 RID: 11989
		// (get) Token: 0x0601F431 RID: 128049 RVA: 0x0090D23A File Offset: 0x0090B43A
		// (set) Token: 0x0601F432 RID: 128050 RVA: 0x0090D24E File Offset: 0x0090B44E
		public unsafe UChildActorComponent PointA
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledPointLight_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledPointLight_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17002ED6 RID: 11990
		// (get) Token: 0x0601F433 RID: 128051 RVA: 0x0090D263 File Offset: 0x0090B463
		// (set) Token: 0x0601F434 RID: 128052 RVA: 0x0090D277 File Offset: 0x0090B477
		public unsafe UChildActorComponent PointO
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledPointLight_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledPointLight_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17002ED7 RID: 11991
		// (get) Token: 0x0601F435 RID: 128053 RVA: 0x0090D28C File Offset: 0x0090B48C
		// (set) Token: 0x0601F436 RID: 128054 RVA: 0x0090D2A0 File Offset: 0x0090B4A0
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledPointLight_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledPointLight_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17002ED8 RID: 11992
		// (get) Token: 0x0601F437 RID: 128055 RVA: 0x0090D2B5 File Offset: 0x0090B4B5
		// (set) Token: 0x0601F438 RID: 128056 RVA: 0x0090D2C5 File Offset: 0x0090B4C5
		public unsafe bool bDirty
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CulledPointLight_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CulledPointLight_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601F439 RID: 128057 RVA: 0x0090D2D8 File Offset: 0x0090B4D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual int GetPlacementSortOrder()
		{
			BP_CulledPointLight_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_CulledPointLight_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CulledPointLight_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CulledPointLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CulledPointLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601F43A RID: 128058 RVA: 0x0090D320 File Offset: 0x0090B520
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual int GetPlacementSortOrder_Implementation()
		{
			BP_CulledPointLight_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_CulledPointLight_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CulledPointLight_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CulledPointLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CulledPointLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601F43B RID: 128059 RVA: 0x0090D368 File Offset: 0x0090B568
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_CulledPointLight_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CulledPointLight_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CulledPointLight_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CulledPointLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CulledPointLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F43C RID: 128060 RVA: 0x0090D3B0 File Offset: 0x0090B5B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_CulledPointLight_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CulledPointLight_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CulledPointLight_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CulledPointLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CulledPointLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F43D RID: 128061 RVA: 0x0090D3F8 File Offset: 0x0090B5F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CulledPointLight(int EntryPoint)
		{
			BP_CulledPointLight_C.__ExecuteUbergraph_BP_CulledPointLight_FunctionParams* ptr = stackalloc BP_CulledPointLight_C.__ExecuteUbergraph_BP_CulledPointLight_FunctionParams[(UIntPtr)383] + 15L / (long)sizeof(BP_CulledPointLight_C.__ExecuteUbergraph_BP_CulledPointLight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CulledPointLight_C.__ExecuteUbergraph_BP_CulledPointLight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CulledPointLight_C.__ExecuteUbergraph_BP_CulledPointLight_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F43E RID: 128062 RVA: 0x0090D442 File Offset: 0x0090B642
		protected BP_CulledPointLight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F824 RID: 63524
		internal static int __InterfaceOffset_IInterface_KuroLightBP;

		// Token: 0x0400F825 RID: 63525
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_CulledPointLight.BP_CulledPointLight_C";

		// Token: 0x0400F826 RID: 63526
		private static IntPtr _ClassPtr;

		// Token: 0x0400F827 RID: 63527
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F828 RID: 63528
		internal static int __PropertyOffset_0;

		// Token: 0x0400F829 RID: 63529
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F82A RID: 63530
		internal static int __PropertyOffset_1;

		// Token: 0x0400F82B RID: 63531
		internal static int __PropertyOffset_2;

		// Token: 0x0400F82C RID: 63532
		internal static int __PropertyOffset_3;

		// Token: 0x0400F82D RID: 63533
		internal static int __PropertyOffset_4;

		// Token: 0x0400F82E RID: 63534
		internal static int __PropertyOffset_5;

		// Token: 0x0400F82F RID: 63535
		internal static int __PropertyOffset_6;

		// Token: 0x0400F830 RID: 63536
		internal static int __PropertyOffset_7;

		// Token: 0x0400F831 RID: 63537
		internal static int __PropertyOffset_8;

		// Token: 0x0400F832 RID: 63538
		private static IntPtr __GetPlacementSortOrder_NativeFunctionPtr;

		// Token: 0x0400F833 RID: 63539
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400F834 RID: 63540
		private static IntPtr __ExecuteUbergraph_BP_CulledPointLight_NativeFunctionPtr;

		// Token: 0x020098B9 RID: 39097
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetPlacementSortOrder_FunctionParams
		{
			// Token: 0x04031F0A RID: 204554
			[FieldOffset(0)]
			public int __Result;
		}

		// Token: 0x020098BA RID: 39098
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031F0B RID: 204555
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098BB RID: 39099
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 368)]
		protected ref struct __ExecuteUbergraph_BP_CulledPointLight_FunctionParams
		{
			// Token: 0x04031F0C RID: 204556
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
