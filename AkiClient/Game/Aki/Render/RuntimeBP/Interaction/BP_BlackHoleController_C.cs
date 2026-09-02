using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Interaction
{
	// Token: 0x02003C74 RID: 15476
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Interaction/BP_BlackHoleController.BP_BlackHoleController_C")]
	[UnrealStructLayout(1352, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1348)]
	public class BP_BlackHoleController_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023E99 RID: 147097 RVA: 0x0098F7D8 File Offset: 0x0098D9D8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BlackHoleController_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Interaction/BP_BlackHoleController.BP_BlackHoleController_C");
			}
			return BP_BlackHoleController_C._ClassPtr;
		}

		// Token: 0x06023E9A RID: 147098 RVA: 0x0098F7FC File Offset: 0x0098D9FC
		public BP_BlackHoleController_C() : this(BuiltinUtils.AllocNativeUObject(BP_BlackHoleController_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023E9B RID: 147099 RVA: 0x0098F824 File Offset: 0x0098DA24
		[NullableContext(1)]
		public BP_BlackHoleController_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BlackHoleController_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170048FE RID: 18686
		// (get) Token: 0x06023E9C RID: 147100 RVA: 0x0098F858 File Offset: 0x0098DA58
		// (set) Token: 0x06023E9D RID: 147101 RVA: 0x0098F891 File Offset: 0x0098DA91
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_BlackHoleController_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_BlackHoleController_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170048FF RID: 18687
		// (get) Token: 0x06023E9E RID: 147102 RVA: 0x0098F8B2 File Offset: 0x0098DAB2
		// (set) Token: 0x06023E9F RID: 147103 RVA: 0x0098F8C6 File Offset: 0x0098DAC6
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BlackHoleController_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BlackHoleController_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004900 RID: 18688
		// (get) Token: 0x06023EA0 RID: 147104 RVA: 0x0098F8DB File Offset: 0x0098DADB
		// (set) Token: 0x06023EA1 RID: 147105 RVA: 0x0098F8EB File Offset: 0x0098DAEB
		public unsafe bool VisualizeTheRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BlackHoleController_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BlackHoleController_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004901 RID: 18689
		// (get) Token: 0x06023EA2 RID: 147106 RVA: 0x0098F8FC File Offset: 0x0098DAFC
		// (set) Token: 0x06023EA3 RID: 147107 RVA: 0x0098F90C File Offset: 0x0098DB0C
		public unsafe float Range
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BlackHoleController_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BlackHoleController_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17004902 RID: 18690
		// (get) Token: 0x06023EA4 RID: 147108 RVA: 0x0098F91D File Offset: 0x0098DB1D
		// (set) Token: 0x06023EA5 RID: 147109 RVA: 0x0098F92D File Offset: 0x0098DB2D
		public unsafe float Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BlackHoleController_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BlackHoleController_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004903 RID: 18691
		// (get) Token: 0x06023EA6 RID: 147110 RVA: 0x0098F93E File Offset: 0x0098DB3E
		// (set) Token: 0x06023EA7 RID: 147111 RVA: 0x0098F94E File Offset: 0x0098DB4E
		public unsafe float TrailSpiralScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BlackHoleController_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BlackHoleController_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17004904 RID: 18692
		// (get) Token: 0x06023EA8 RID: 147112 RVA: 0x0098F95F File Offset: 0x0098DB5F
		// (set) Token: 0x06023EA9 RID: 147113 RVA: 0x0098F96F File Offset: 0x0098DB6F
		public unsafe float TrailSpiraIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BlackHoleController_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BlackHoleController_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x06023EAA RID: 147114 RVA: 0x0098F980 File Offset: 0x0098DB80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BlackHoleController_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023EAB RID: 147115 RVA: 0x0098F994 File Offset: 0x0098DB94
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BlackHoleController_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023EAC RID: 147116 RVA: 0x0098F9AC File Offset: 0x0098DBAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_BlackHoleController_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BlackHoleController_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BlackHoleController_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BlackHoleController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BlackHoleController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023EAD RID: 147117 RVA: 0x0098F9F4 File Offset: 0x0098DBF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_BlackHoleController_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BlackHoleController_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BlackHoleController_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BlackHoleController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BlackHoleController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023EAE RID: 147118 RVA: 0x0098FA3C File Offset: 0x0098DC3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_BlackHoleController_C.__EditorTick_FunctionParams* ptr = stackalloc BP_BlackHoleController_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BlackHoleController_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BlackHoleController_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BlackHoleController_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023EAF RID: 147119 RVA: 0x0098FA84 File Offset: 0x0098DC84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_BlackHoleController_C.__EditorTick_FunctionParams* ptr = stackalloc BP_BlackHoleController_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BlackHoleController_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BlackHoleController_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BlackHoleController_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023EB0 RID: 147120 RVA: 0x0098FACC File Offset: 0x0098DCCC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_BlackHoleController(int EntryPoint)
		{
			BP_BlackHoleController_C.__ExecuteUbergraph_BP_BlackHoleController_FunctionParams* ptr = stackalloc BP_BlackHoleController_C.__ExecuteUbergraph_BP_BlackHoleController_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_BlackHoleController_C.__ExecuteUbergraph_BP_BlackHoleController_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BlackHoleController_C.__ExecuteUbergraph_BP_BlackHoleController_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BlackHoleController_C.__ExecuteUbergraph_BP_BlackHoleController_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023EB1 RID: 147121 RVA: 0x0098FB13 File Offset: 0x0098DD13
		protected BP_BlackHoleController_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012580 RID: 75136
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Interaction/BP_BlackHoleController.BP_BlackHoleController_C";

		// Token: 0x04012581 RID: 75137
		private static IntPtr _ClassPtr;

		// Token: 0x04012582 RID: 75138
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012583 RID: 75139
		internal static int __PropertyOffset_0;

		// Token: 0x04012584 RID: 75140
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012585 RID: 75141
		internal static int __PropertyOffset_1;

		// Token: 0x04012586 RID: 75142
		internal static int __PropertyOffset_2;

		// Token: 0x04012587 RID: 75143
		internal static int __PropertyOffset_3;

		// Token: 0x04012588 RID: 75144
		internal static int __PropertyOffset_4;

		// Token: 0x04012589 RID: 75145
		internal static int __PropertyOffset_5;

		// Token: 0x0401258A RID: 75146
		internal static int __PropertyOffset_6;

		// Token: 0x0401258B RID: 75147
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401258C RID: 75148
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401258D RID: 75149
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401258E RID: 75150
		private static IntPtr __ExecuteUbergraph_BP_BlackHoleController_NativeFunctionPtr;

		// Token: 0x02009D60 RID: 40288
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032755 RID: 206677
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D61 RID: 40289
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032756 RID: 206678
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D62 RID: 40290
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __ExecuteUbergraph_BP_BlackHoleController_FunctionParams
		{
			// Token: 0x04032757 RID: 206679
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
