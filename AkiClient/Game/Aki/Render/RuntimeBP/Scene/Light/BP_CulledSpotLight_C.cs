using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A7C RID: 14972
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_CulledSpotLight.BP_CulledSpotLight_C")]
	[UnrealStructLayout(1392, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1385)]
	public class BP_CulledSpotLight_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject, IInterface_KuroLightBP, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0601F45B RID: 128091 RVA: 0x0090D7E3 File Offset: 0x0090B9E3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CulledSpotLight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_CulledSpotLight.BP_CulledSpotLight_C");
			}
			return BP_CulledSpotLight_C._ClassPtr;
		}

		// Token: 0x0601F45C RID: 128092 RVA: 0x0090D807 File Offset: 0x0090BA07
		int IInterface_KuroLightBP.InterfaceOffset()
		{
			return BP_CulledSpotLight_C.__InterfaceOffset_IInterface_KuroLightBP;
		}

		// Token: 0x0601F45D RID: 128093 RVA: 0x0090D810 File Offset: 0x0090BA10
		public BP_CulledSpotLight_C() : this(BuiltinUtils.AllocNativeUObject(BP_CulledSpotLight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F45E RID: 128094 RVA: 0x0090D838 File Offset: 0x0090BA38
		[NullableContext(1)]
		public BP_CulledSpotLight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CulledSpotLight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002EE2 RID: 12002
		// (get) Token: 0x0601F45F RID: 128095 RVA: 0x0090D86C File Offset: 0x0090BA6C
		// (set) Token: 0x0601F460 RID: 128096 RVA: 0x0090D8A5 File Offset: 0x0090BAA5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CulledSpotLight_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CulledSpotLight_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002EE3 RID: 12003
		// (get) Token: 0x0601F461 RID: 128097 RVA: 0x0090D8C6 File Offset: 0x0090BAC6
		// (set) Token: 0x0601F462 RID: 128098 RVA: 0x0090D8DA File Offset: 0x0090BADA
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledSpotLight_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledSpotLight_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002EE4 RID: 12004
		// (get) Token: 0x0601F463 RID: 128099 RVA: 0x0090D8EF File Offset: 0x0090BAEF
		// (set) Token: 0x0601F464 RID: 128100 RVA: 0x0090D903 File Offset: 0x0090BB03
		public unsafe USpotLightComponent SpotLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpotLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledSpotLight_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledSpotLight_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002EE5 RID: 12005
		// (get) Token: 0x0601F465 RID: 128101 RVA: 0x0090D918 File Offset: 0x0090BB18
		// (set) Token: 0x0601F466 RID: 128102 RVA: 0x0090D92C File Offset: 0x0090BB2C
		public unsafe UChildActorComponent PointC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledSpotLight_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledSpotLight_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002EE6 RID: 12006
		// (get) Token: 0x0601F467 RID: 128103 RVA: 0x0090D941 File Offset: 0x0090BB41
		// (set) Token: 0x0601F468 RID: 128104 RVA: 0x0090D955 File Offset: 0x0090BB55
		public unsafe UChildActorComponent PointB
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledSpotLight_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledSpotLight_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002EE7 RID: 12007
		// (get) Token: 0x0601F469 RID: 128105 RVA: 0x0090D96A File Offset: 0x0090BB6A
		// (set) Token: 0x0601F46A RID: 128106 RVA: 0x0090D97E File Offset: 0x0090BB7E
		public unsafe UChildActorComponent PointA
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledSpotLight_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledSpotLight_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17002EE8 RID: 12008
		// (get) Token: 0x0601F46B RID: 128107 RVA: 0x0090D993 File Offset: 0x0090BB93
		// (set) Token: 0x0601F46C RID: 128108 RVA: 0x0090D9A7 File Offset: 0x0090BBA7
		public unsafe UChildActorComponent PointO
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledSpotLight_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledSpotLight_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17002EE9 RID: 12009
		// (get) Token: 0x0601F46D RID: 128109 RVA: 0x0090D9BC File Offset: 0x0090BBBC
		// (set) Token: 0x0601F46E RID: 128110 RVA: 0x0090D9D0 File Offset: 0x0090BBD0
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledSpotLight_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CulledSpotLight_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17002EEA RID: 12010
		// (get) Token: 0x0601F46F RID: 128111 RVA: 0x0090D9E5 File Offset: 0x0090BBE5
		// (set) Token: 0x0601F470 RID: 128112 RVA: 0x0090D9F5 File Offset: 0x0090BBF5
		public unsafe bool bDirty
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CulledSpotLight_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CulledSpotLight_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601F471 RID: 128113 RVA: 0x0090DA08 File Offset: 0x0090BC08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual int GetPlacementSortOrder()
		{
			BP_CulledSpotLight_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_CulledSpotLight_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CulledSpotLight_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CulledSpotLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CulledSpotLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601F472 RID: 128114 RVA: 0x0090DA50 File Offset: 0x0090BC50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual int GetPlacementSortOrder_Implementation()
		{
			BP_CulledSpotLight_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_CulledSpotLight_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CulledSpotLight_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CulledSpotLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CulledSpotLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601F473 RID: 128115 RVA: 0x0090DA98 File Offset: 0x0090BC98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_CulledSpotLight_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CulledSpotLight_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CulledSpotLight_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CulledSpotLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CulledSpotLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F474 RID: 128116 RVA: 0x0090DAE0 File Offset: 0x0090BCE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_CulledSpotLight_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CulledSpotLight_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CulledSpotLight_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CulledSpotLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CulledSpotLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F475 RID: 128117 RVA: 0x0090DB28 File Offset: 0x0090BD28
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CulledSpotLight(int EntryPoint)
		{
			BP_CulledSpotLight_C.__ExecuteUbergraph_BP_CulledSpotLight_FunctionParams* ptr = stackalloc BP_CulledSpotLight_C.__ExecuteUbergraph_BP_CulledSpotLight_FunctionParams[(UIntPtr)383] + 15L / (long)sizeof(BP_CulledSpotLight_C.__ExecuteUbergraph_BP_CulledSpotLight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CulledSpotLight_C.__ExecuteUbergraph_BP_CulledSpotLight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CulledSpotLight_C.__ExecuteUbergraph_BP_CulledSpotLight_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F476 RID: 128118 RVA: 0x0090DB72 File Offset: 0x0090BD72
		protected BP_CulledSpotLight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F846 RID: 63558
		internal static int __InterfaceOffset_IInterface_KuroLightBP;

		// Token: 0x0400F847 RID: 63559
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_CulledSpotLight.BP_CulledSpotLight_C";

		// Token: 0x0400F848 RID: 63560
		private static IntPtr _ClassPtr;

		// Token: 0x0400F849 RID: 63561
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F84A RID: 63562
		internal static int __PropertyOffset_0;

		// Token: 0x0400F84B RID: 63563
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F84C RID: 63564
		internal static int __PropertyOffset_1;

		// Token: 0x0400F84D RID: 63565
		internal static int __PropertyOffset_2;

		// Token: 0x0400F84E RID: 63566
		internal static int __PropertyOffset_3;

		// Token: 0x0400F84F RID: 63567
		internal static int __PropertyOffset_4;

		// Token: 0x0400F850 RID: 63568
		internal static int __PropertyOffset_5;

		// Token: 0x0400F851 RID: 63569
		internal static int __PropertyOffset_6;

		// Token: 0x0400F852 RID: 63570
		internal static int __PropertyOffset_7;

		// Token: 0x0400F853 RID: 63571
		internal static int __PropertyOffset_8;

		// Token: 0x0400F854 RID: 63572
		private static IntPtr __GetPlacementSortOrder_NativeFunctionPtr;

		// Token: 0x0400F855 RID: 63573
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400F856 RID: 63574
		private static IntPtr __ExecuteUbergraph_BP_CulledSpotLight_NativeFunctionPtr;

		// Token: 0x020098BF RID: 39103
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetPlacementSortOrder_FunctionParams
		{
			// Token: 0x04031F10 RID: 204560
			[FieldOffset(0)]
			public int __Result;
		}

		// Token: 0x020098C0 RID: 39104
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031F11 RID: 204561
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098C1 RID: 39105
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 368)]
		protected ref struct __ExecuteUbergraph_BP_CulledSpotLight_FunctionParams
		{
			// Token: 0x04031F12 RID: 204562
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
