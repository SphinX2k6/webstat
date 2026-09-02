using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SceneShader.AvisionFoliagre.AvisionFoliageSwitch
{
	// Token: 0x02003B82 RID: 15234
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SceneShader/AvisionFoliagre/AvisionFoliageSwitch/BP_AvisionFoliageSwitch.BP_AvisionFoliageSwitch_C")]
	[UnrealStructLayout(1424, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1418)]
	public class BP_AvisionFoliageSwitch_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021A9C RID: 137884 RVA: 0x0094F68F File Offset: 0x0094D88F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_AvisionFoliageSwitch_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SceneShader/AvisionFoliagre/AvisionFoliageSwitch/BP_AvisionFoliageSwitch.BP_AvisionFoliageSwitch_C");
			}
			return BP_AvisionFoliageSwitch_C._ClassPtr;
		}

		// Token: 0x06021A9D RID: 137885 RVA: 0x0094F6B4 File Offset: 0x0094D8B4
		public BP_AvisionFoliageSwitch_C() : this(BuiltinUtils.AllocNativeUObject(BP_AvisionFoliageSwitch_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021A9E RID: 137886 RVA: 0x0094F6DC File Offset: 0x0094D8DC
		[NullableContext(1)]
		public BP_AvisionFoliageSwitch_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_AvisionFoliageSwitch_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003C60 RID: 15456
		// (get) Token: 0x06021A9F RID: 137887 RVA: 0x0094F710 File Offset: 0x0094D910
		// (set) Token: 0x06021AA0 RID: 137888 RVA: 0x0094F749 File Offset: 0x0094D949
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_AvisionFoliageSwitch_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_AvisionFoliageSwitch_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003C61 RID: 15457
		// (get) Token: 0x06021AA1 RID: 137889 RVA: 0x0094F76A File Offset: 0x0094D96A
		// (set) Token: 0x06021AA2 RID: 137890 RVA: 0x0094F77E File Offset: 0x0094D97E
		public unsafe UStaticMeshComponent CommonFoliage
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AvisionFoliageSwitch_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AvisionFoliageSwitch_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003C62 RID: 15458
		// (get) Token: 0x06021AA3 RID: 137891 RVA: 0x0094F793 File Offset: 0x0094D993
		// (set) Token: 0x06021AA4 RID: 137892 RVA: 0x0094F7A7 File Offset: 0x0094D9A7
		public unsafe UStaticMeshComponent AvisionFoliage
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AvisionFoliageSwitch_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AvisionFoliageSwitch_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003C63 RID: 15459
		// (get) Token: 0x06021AA5 RID: 137893 RVA: 0x0094F7BC File Offset: 0x0094D9BC
		// (set) Token: 0x06021AA6 RID: 137894 RVA: 0x0094F7D0 File Offset: 0x0094D9D0
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AvisionFoliageSwitch_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AvisionFoliageSwitch_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003C64 RID: 15460
		// (get) Token: 0x06021AA7 RID: 137895 RVA: 0x0094F7E5 File Offset: 0x0094D9E5
		// (set) Token: 0x06021AA8 RID: 137896 RVA: 0x0094F7F9 File Offset: 0x0094D9F9
		public unsafe UStaticMesh SM_AvisionFoliage
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AvisionFoliageSwitch_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AvisionFoliageSwitch_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003C65 RID: 15461
		// (get) Token: 0x06021AA9 RID: 137897 RVA: 0x0094F80E File Offset: 0x0094DA0E
		// (set) Token: 0x06021AAA RID: 137898 RVA: 0x0094F822 File Offset: 0x0094DA22
		public unsafe UStaticMesh SM_CommonFoliage
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AvisionFoliageSwitch_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AvisionFoliageSwitch_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003C66 RID: 15462
		// (get) Token: 0x06021AAB RID: 137899 RVA: 0x0094F837 File Offset: 0x0094DA37
		// (set) Token: 0x06021AAC RID: 137900 RVA: 0x0094F847 File Offset: 0x0094DA47
		public unsafe float Width
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AvisionFoliageSwitch_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AvisionFoliageSwitch_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003C67 RID: 15463
		// (get) Token: 0x06021AAD RID: 137901 RVA: 0x0094F858 File Offset: 0x0094DA58
		// (set) Token: 0x06021AAE RID: 137902 RVA: 0x0094F868 File Offset: 0x0094DA68
		public unsafe float Progress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AvisionFoliageSwitch_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AvisionFoliageSwitch_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003C68 RID: 15464
		// (get) Token: 0x06021AAF RID: 137903 RVA: 0x0094F879 File Offset: 0x0094DA79
		// (set) Token: 0x06021AB0 RID: 137904 RVA: 0x0094F88D File Offset: 0x0094DA8D
		public unsafe FLinearColor LeafDissolve_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AvisionFoliageSwitch_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AvisionFoliageSwitch_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003C69 RID: 15465
		// (get) Token: 0x06021AB1 RID: 137905 RVA: 0x0094F8A2 File Offset: 0x0094DAA2
		// (set) Token: 0x06021AB2 RID: 137906 RVA: 0x0094F8B6 File Offset: 0x0094DAB6
		public unsafe UMaterialInstanceDynamic AvisionFoliage_DMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AvisionFoliageSwitch_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AvisionFoliageSwitch_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17003C6A RID: 15466
		// (get) Token: 0x06021AB3 RID: 137907 RVA: 0x0094F8CB File Offset: 0x0094DACB
		// (set) Token: 0x06021AB4 RID: 137908 RVA: 0x0094F8DF File Offset: 0x0094DADF
		public unsafe UMaterialInstanceDynamic CommonFoliage_DMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AvisionFoliageSwitch_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AvisionFoliageSwitch_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17003C6B RID: 15467
		// (get) Token: 0x06021AB5 RID: 137909 RVA: 0x0094F8F4 File Offset: 0x0094DAF4
		// (set) Token: 0x06021AB6 RID: 137910 RVA: 0x0094F908 File Offset: 0x0094DB08
		public unsafe UMaterialInstanceDynamic CommonFoliage_LOD1_DMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AvisionFoliageSwitch_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AvisionFoliageSwitch_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17003C6C RID: 15468
		// (get) Token: 0x06021AB7 RID: 137911 RVA: 0x0094F91D File Offset: 0x0094DB1D
		// (set) Token: 0x06021AB8 RID: 137912 RVA: 0x0094F92D File Offset: 0x0094DB2D
		public unsafe bool HasToggled_Close
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AvisionFoliageSwitch_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AvisionFoliageSwitch_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003C6D RID: 15469
		// (get) Token: 0x06021AB9 RID: 137913 RVA: 0x0094F93E File Offset: 0x0094DB3E
		// (set) Token: 0x06021ABA RID: 137914 RVA: 0x0094F94E File Offset: 0x0094DB4E
		public unsafe bool HasToggled_Open
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AvisionFoliageSwitch_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AvisionFoliageSwitch_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x06021ABB RID: 137915 RVA: 0x0094F95F File Offset: 0x0094DB5F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_Collision()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AvisionFoliageSwitch_C.__Set_Collision_NativeFunctionPtr, null);
		}

		// Token: 0x06021ABC RID: 137916 RVA: 0x0094F973 File Offset: 0x0094DB73
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AvisionFoliageSwitch_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021ABD RID: 137917 RVA: 0x0094F987 File Offset: 0x0094DB87
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AvisionFoliageSwitch_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021ABE RID: 137918 RVA: 0x0094F99C File Offset: 0x0094DB9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AvisionFoliageSwitch_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021ABF RID: 137919 RVA: 0x0094F9B0 File Offset: 0x0094DBB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AvisionFoliageSwitch_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021AC0 RID: 137920 RVA: 0x0094F9C8 File Offset: 0x0094DBC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_AvisionFoliageSwitch_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_AvisionFoliageSwitch_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_AvisionFoliageSwitch_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AvisionFoliageSwitch_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AvisionFoliageSwitch_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021AC1 RID: 137921 RVA: 0x0094FA10 File Offset: 0x0094DC10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_AvisionFoliageSwitch_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_AvisionFoliageSwitch_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_AvisionFoliageSwitch_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AvisionFoliageSwitch_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AvisionFoliageSwitch_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021AC2 RID: 137922 RVA: 0x0094FA58 File Offset: 0x0094DC58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_AvisionFoliageSwitch(int EntryPoint)
		{
			BP_AvisionFoliageSwitch_C.__ExecuteUbergraph_BP_AvisionFoliageSwitch_FunctionParams* ptr = stackalloc BP_AvisionFoliageSwitch_C.__ExecuteUbergraph_BP_AvisionFoliageSwitch_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_AvisionFoliageSwitch_C.__ExecuteUbergraph_BP_AvisionFoliageSwitch_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AvisionFoliageSwitch_C.__ExecuteUbergraph_BP_AvisionFoliageSwitch_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AvisionFoliageSwitch_C.__ExecuteUbergraph_BP_AvisionFoliageSwitch_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021AC3 RID: 137923 RVA: 0x0094FA9F File Offset: 0x0094DC9F
		protected BP_AvisionFoliageSwitch_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010F7A RID: 69498
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SceneShader/AvisionFoliagre/AvisionFoliageSwitch/BP_AvisionFoliageSwitch.BP_AvisionFoliageSwitch_C";

		// Token: 0x04010F7B RID: 69499
		private static IntPtr _ClassPtr;

		// Token: 0x04010F7C RID: 69500
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010F7D RID: 69501
		internal static int __PropertyOffset_0;

		// Token: 0x04010F7E RID: 69502
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010F7F RID: 69503
		internal static int __PropertyOffset_1;

		// Token: 0x04010F80 RID: 69504
		internal static int __PropertyOffset_2;

		// Token: 0x04010F81 RID: 69505
		internal static int __PropertyOffset_3;

		// Token: 0x04010F82 RID: 69506
		internal static int __PropertyOffset_4;

		// Token: 0x04010F83 RID: 69507
		internal static int __PropertyOffset_5;

		// Token: 0x04010F84 RID: 69508
		internal static int __PropertyOffset_6;

		// Token: 0x04010F85 RID: 69509
		internal static int __PropertyOffset_7;

		// Token: 0x04010F86 RID: 69510
		internal static int __PropertyOffset_8;

		// Token: 0x04010F87 RID: 69511
		internal static int __PropertyOffset_9;

		// Token: 0x04010F88 RID: 69512
		internal static int __PropertyOffset_10;

		// Token: 0x04010F89 RID: 69513
		internal static int __PropertyOffset_11;

		// Token: 0x04010F8A RID: 69514
		internal static int __PropertyOffset_12;

		// Token: 0x04010F8B RID: 69515
		internal static int __PropertyOffset_13;

		// Token: 0x04010F8C RID: 69516
		private static IntPtr __Set_Collision_NativeFunctionPtr;

		// Token: 0x04010F8D RID: 69517
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010F8E RID: 69518
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010F8F RID: 69519
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010F90 RID: 69520
		private static IntPtr __ExecuteUbergraph_BP_AvisionFoliageSwitch_NativeFunctionPtr;

		// Token: 0x02009B13 RID: 39699
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040322C3 RID: 205507
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B14 RID: 39700
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_AvisionFoliageSwitch_FunctionParams
		{
			// Token: 0x040322C4 RID: 205508
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
