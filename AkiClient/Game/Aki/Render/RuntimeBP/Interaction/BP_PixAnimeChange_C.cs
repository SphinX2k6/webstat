using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Interaction
{
	// Token: 0x02003C85 RID: 15493
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Interaction/BP_PixAnimeChange.BP_PixAnimeChange_C")]
	[UnrealStructLayout(1368, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1368)]
	public class BP_PixAnimeChange_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024107 RID: 147719 RVA: 0x00993C5C File Offset: 0x00991E5C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PixAnimeChange_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Interaction/BP_PixAnimeChange.BP_PixAnimeChange_C");
			}
			return BP_PixAnimeChange_C._ClassPtr;
		}

		// Token: 0x06024108 RID: 147720 RVA: 0x00993C80 File Offset: 0x00991E80
		public BP_PixAnimeChange_C() : this(BuiltinUtils.AllocNativeUObject(BP_PixAnimeChange_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024109 RID: 147721 RVA: 0x00993CA8 File Offset: 0x00991EA8
		[NullableContext(1)]
		public BP_PixAnimeChange_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PixAnimeChange_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170049C6 RID: 18886
		// (get) Token: 0x0602410A RID: 147722 RVA: 0x00993CDC File Offset: 0x00991EDC
		// (set) Token: 0x0602410B RID: 147723 RVA: 0x00993D15 File Offset: 0x00991F15
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PixAnimeChange_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PixAnimeChange_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170049C7 RID: 18887
		// (get) Token: 0x0602410C RID: 147724 RVA: 0x00993D36 File Offset: 0x00991F36
		// (set) Token: 0x0602410D RID: 147725 RVA: 0x00993D4A File Offset: 0x00991F4A
		public unsafe UStaticMeshComponent Plane
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PixAnimeChange_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PixAnimeChange_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170049C8 RID: 18888
		// (get) Token: 0x0602410E RID: 147726 RVA: 0x00993D5F File Offset: 0x00991F5F
		// (set) Token: 0x0602410F RID: 147727 RVA: 0x00993D73 File Offset: 0x00991F73
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PixAnimeChange_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PixAnimeChange_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170049C9 RID: 18889
		// (get) Token: 0x06024110 RID: 147728 RVA: 0x00993D88 File Offset: 0x00991F88
		// (set) Token: 0x06024111 RID: 147729 RVA: 0x00993D98 File Offset: 0x00991F98
		public unsafe bool bIsPlaying
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PixAnimeChange_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PixAnimeChange_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x170049CA RID: 18890
		// (get) Token: 0x06024112 RID: 147730 RVA: 0x00993DA9 File Offset: 0x00991FA9
		// (set) Token: 0x06024113 RID: 147731 RVA: 0x00993DB9 File Offset: 0x00991FB9
		public unsafe int PlayingRow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PixAnimeChange_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PixAnimeChange_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170049CB RID: 18891
		// (get) Token: 0x06024114 RID: 147732 RVA: 0x00993DCA File Offset: 0x00991FCA
		// (set) Token: 0x06024115 RID: 147733 RVA: 0x00993DDA File Offset: 0x00991FDA
		public unsafe int LastPlayingRow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PixAnimeChange_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PixAnimeChange_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170049CC RID: 18892
		// (get) Token: 0x06024116 RID: 147734 RVA: 0x00993DEB File Offset: 0x00991FEB
		// (set) Token: 0x06024117 RID: 147735 RVA: 0x00993DFB File Offset: 0x00991FFB
		public unsafe float PlayingSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PixAnimeChange_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PixAnimeChange_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170049CD RID: 18893
		// (get) Token: 0x06024118 RID: 147736 RVA: 0x00993E0C File Offset: 0x0099200C
		// (set) Token: 0x06024119 RID: 147737 RVA: 0x00993E20 File Offset: 0x00992020
		public unsafe UMaterialInstanceDynamic NewVar_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PixAnimeChange_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PixAnimeChange_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170049CE RID: 18894
		// (get) Token: 0x0602411A RID: 147738 RVA: 0x00993E35 File Offset: 0x00992035
		// (set) Token: 0x0602411B RID: 147739 RVA: 0x00993E45 File Offset: 0x00992045
		public unsafe float AccumulatedTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PixAnimeChange_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PixAnimeChange_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170049CF RID: 18895
		// (get) Token: 0x0602411C RID: 147740 RVA: 0x00993E56 File Offset: 0x00992056
		// (set) Token: 0x0602411D RID: 147741 RVA: 0x00993E66 File Offset: 0x00992066
		public unsafe float EmissionIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PixAnimeChange_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PixAnimeChange_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x0602411E RID: 147742 RVA: 0x00993E77 File Offset: 0x00992077
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PixAnimeChange_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602411F RID: 147743 RVA: 0x00993E8B File Offset: 0x0099208B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PixAnimeChange_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024120 RID: 147744 RVA: 0x00993EA0 File Offset: 0x009920A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_PixAnimeChange_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PixAnimeChange_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PixAnimeChange_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PixAnimeChange_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PixAnimeChange_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024121 RID: 147745 RVA: 0x00993EE8 File Offset: 0x009920E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_PixAnimeChange_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PixAnimeChange_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PixAnimeChange_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PixAnimeChange_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PixAnimeChange_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024122 RID: 147746 RVA: 0x00993F30 File Offset: 0x00992130
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_PixAnimeChange_C.__EditorTick_FunctionParams* ptr = stackalloc BP_PixAnimeChange_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PixAnimeChange_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PixAnimeChange_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PixAnimeChange_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024123 RID: 147747 RVA: 0x00993F78 File Offset: 0x00992178
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_PixAnimeChange_C.__EditorTick_FunctionParams* ptr = stackalloc BP_PixAnimeChange_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PixAnimeChange_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PixAnimeChange_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PixAnimeChange_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024124 RID: 147748 RVA: 0x00993FC0 File Offset: 0x009921C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PixAnimeChange(int EntryPoint)
		{
			BP_PixAnimeChange_C.__ExecuteUbergraph_BP_PixAnimeChange_FunctionParams* ptr = stackalloc BP_PixAnimeChange_C.__ExecuteUbergraph_BP_PixAnimeChange_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_PixAnimeChange_C.__ExecuteUbergraph_BP_PixAnimeChange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PixAnimeChange_C.__ExecuteUbergraph_BP_PixAnimeChange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PixAnimeChange_C.__ExecuteUbergraph_BP_PixAnimeChange_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024125 RID: 147749 RVA: 0x00994007 File Offset: 0x00992207
		protected BP_PixAnimeChange_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040126FB RID: 75515
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Interaction/BP_PixAnimeChange.BP_PixAnimeChange_C";

		// Token: 0x040126FC RID: 75516
		private static IntPtr _ClassPtr;

		// Token: 0x040126FD RID: 75517
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040126FE RID: 75518
		internal static int __PropertyOffset_0;

		// Token: 0x040126FF RID: 75519
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012700 RID: 75520
		internal static int __PropertyOffset_1;

		// Token: 0x04012701 RID: 75521
		internal static int __PropertyOffset_2;

		// Token: 0x04012702 RID: 75522
		internal static int __PropertyOffset_3;

		// Token: 0x04012703 RID: 75523
		internal static int __PropertyOffset_4;

		// Token: 0x04012704 RID: 75524
		internal static int __PropertyOffset_5;

		// Token: 0x04012705 RID: 75525
		internal static int __PropertyOffset_6;

		// Token: 0x04012706 RID: 75526
		internal static int __PropertyOffset_7;

		// Token: 0x04012707 RID: 75527
		internal static int __PropertyOffset_8;

		// Token: 0x04012708 RID: 75528
		internal static int __PropertyOffset_9;

		// Token: 0x04012709 RID: 75529
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401270A RID: 75530
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401270B RID: 75531
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401270C RID: 75532
		private static IntPtr __ExecuteUbergraph_BP_PixAnimeChange_NativeFunctionPtr;

		// Token: 0x02009D88 RID: 40328
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403277D RID: 206717
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D89 RID: 40329
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x0403277E RID: 206718
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D8A RID: 40330
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __ExecuteUbergraph_BP_PixAnimeChange_FunctionParams
		{
			// Token: 0x0403277F RID: 206719
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
