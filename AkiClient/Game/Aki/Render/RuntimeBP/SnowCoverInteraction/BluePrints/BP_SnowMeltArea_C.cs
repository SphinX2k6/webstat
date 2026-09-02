using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.SnowCoverInteraction.BluePrints
{
	// Token: 0x02003A52 RID: 14930
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/SnowCoverInteraction/BluePrints/BP_SnowMeltArea.BP_SnowMeltArea_C")]
	[UnrealStructLayout(1352, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1349)]
	public class BP_SnowMeltArea_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EF1F RID: 126751 RVA: 0x00902EA8 File Offset: 0x009010A8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SnowMeltArea_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/SnowCoverInteraction/BluePrints/BP_SnowMeltArea.BP_SnowMeltArea_C");
			}
			return BP_SnowMeltArea_C._ClassPtr;
		}

		// Token: 0x0601EF20 RID: 126752 RVA: 0x00902ECC File Offset: 0x009010CC
		public BP_SnowMeltArea_C() : this(BuiltinUtils.AllocNativeUObject(BP_SnowMeltArea_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EF21 RID: 126753 RVA: 0x00902EF4 File Offset: 0x009010F4
		[NullableContext(1)]
		public BP_SnowMeltArea_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SnowMeltArea_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002D41 RID: 11585
		// (get) Token: 0x0601EF22 RID: 126754 RVA: 0x00902F28 File Offset: 0x00901128
		// (set) Token: 0x0601EF23 RID: 126755 RVA: 0x00902F61 File Offset: 0x00901161
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SnowMeltArea_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SnowMeltArea_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002D42 RID: 11586
		// (get) Token: 0x0601EF24 RID: 126756 RVA: 0x00902F82 File Offset: 0x00901182
		// (set) Token: 0x0601EF25 RID: 126757 RVA: 0x00902F96 File Offset: 0x00901196
		public unsafe USphereComponent Sphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USphereComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowMeltArea_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowMeltArea_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002D43 RID: 11587
		// (get) Token: 0x0601EF26 RID: 126758 RVA: 0x00902FAB File Offset: 0x009011AB
		// (set) Token: 0x0601EF27 RID: 126759 RVA: 0x00902FBF File Offset: 0x009011BF
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowMeltArea_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowMeltArea_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002D44 RID: 11588
		// (get) Token: 0x0601EF28 RID: 126760 RVA: 0x00902FD4 File Offset: 0x009011D4
		// (set) Token: 0x0601EF29 RID: 126761 RVA: 0x00902FE4 File Offset: 0x009011E4
		public unsafe float 融化程度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowMeltArea_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowMeltArea_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17002D45 RID: 11589
		// (get) Token: 0x0601EF2A RID: 126762 RVA: 0x00902FF5 File Offset: 0x009011F5
		// (set) Token: 0x0601EF2B RID: 126763 RVA: 0x00903005 File Offset: 0x00901205
		public unsafe float 融化范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowMeltArea_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowMeltArea_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17002D46 RID: 11590
		// (get) Token: 0x0601EF2C RID: 126764 RVA: 0x00903016 File Offset: 0x00901216
		// (set) Token: 0x0601EF2D RID: 126765 RVA: 0x00903026 File Offset: 0x00901226
		public unsafe float 融化过渡距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowMeltArea_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowMeltArea_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17002D47 RID: 11591
		// (get) Token: 0x0601EF2E RID: 126766 RVA: 0x00903037 File Offset: 0x00901237
		// (set) Token: 0x0601EF2F RID: 126767 RVA: 0x00903047 File Offset: 0x00901247
		public unsafe bool OnMeltPlay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowMeltArea_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowMeltArea_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601EF30 RID: 126768 RVA: 0x00903058 File Offset: 0x00901258
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetMPC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowMeltArea_C.__SetMPC_NativeFunctionPtr, null);
		}

		// Token: 0x0601EF31 RID: 126769 RVA: 0x0090306C File Offset: 0x0090126C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowMeltArea_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601EF32 RID: 126770 RVA: 0x00903080 File Offset: 0x00901280
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SnowMeltArea_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EF33 RID: 126771 RVA: 0x00903098 File Offset: 0x00901298
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SnowMeltArea_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SnowMeltArea_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SnowMeltArea_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowMeltArea_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowMeltArea_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EF34 RID: 126772 RVA: 0x009030E0 File Offset: 0x009012E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SnowMeltArea_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SnowMeltArea_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SnowMeltArea_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowMeltArea_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SnowMeltArea_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EF35 RID: 126773 RVA: 0x00903128 File Offset: 0x00901328
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_SnowMeltArea_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SnowMeltArea_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SnowMeltArea_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowMeltArea_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowMeltArea_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EF36 RID: 126774 RVA: 0x00903170 File Offset: 0x00901370
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_SnowMeltArea_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SnowMeltArea_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SnowMeltArea_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowMeltArea_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SnowMeltArea_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EF37 RID: 126775 RVA: 0x009031B8 File Offset: 0x009013B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SnowMeltArea(int EntryPoint)
		{
			BP_SnowMeltArea_C.__ExecuteUbergraph_BP_SnowMeltArea_FunctionParams* ptr = stackalloc BP_SnowMeltArea_C.__ExecuteUbergraph_BP_SnowMeltArea_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_SnowMeltArea_C.__ExecuteUbergraph_BP_SnowMeltArea_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowMeltArea_C.__ExecuteUbergraph_BP_SnowMeltArea_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SnowMeltArea_C.__ExecuteUbergraph_BP_SnowMeltArea_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EF38 RID: 126776 RVA: 0x009031FF File Offset: 0x009013FF
		protected BP_SnowMeltArea_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F4D0 RID: 62672
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/SnowCoverInteraction/BluePrints/BP_SnowMeltArea.BP_SnowMeltArea_C";

		// Token: 0x0400F4D1 RID: 62673
		private static IntPtr _ClassPtr;

		// Token: 0x0400F4D2 RID: 62674
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F4D3 RID: 62675
		internal static int __PropertyOffset_0;

		// Token: 0x0400F4D4 RID: 62676
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F4D5 RID: 62677
		internal static int __PropertyOffset_1;

		// Token: 0x0400F4D6 RID: 62678
		internal static int __PropertyOffset_2;

		// Token: 0x0400F4D7 RID: 62679
		internal static int __PropertyOffset_3;

		// Token: 0x0400F4D8 RID: 62680
		internal static int __PropertyOffset_4;

		// Token: 0x0400F4D9 RID: 62681
		internal static int __PropertyOffset_5;

		// Token: 0x0400F4DA RID: 62682
		internal static int __PropertyOffset_6;

		// Token: 0x0400F4DB RID: 62683
		private static IntPtr __SetMPC_NativeFunctionPtr;

		// Token: 0x0400F4DC RID: 62684
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F4DD RID: 62685
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F4DE RID: 62686
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400F4DF RID: 62687
		private static IntPtr __ExecuteUbergraph_BP_SnowMeltArea_NativeFunctionPtr;

		// Token: 0x02009824 RID: 38948
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031E43 RID: 204355
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009825 RID: 38949
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031E44 RID: 204356
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009826 RID: 38950
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_SnowMeltArea_FunctionParams
		{
			// Token: 0x04031E45 RID: 204357
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
