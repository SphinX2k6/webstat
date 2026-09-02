using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Interaction
{
	// Token: 0x02003C81 RID: 15489
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Interaction/BP_JiJiaJiaShi.BP_JiJiaJiaShi_C")]
	[UnrealStructLayout(1392, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1388)]
	public class BP_JiJiaJiaShi_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024045 RID: 147525 RVA: 0x0099279C File Offset: 0x0099099C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_JiJiaJiaShi_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Interaction/BP_JiJiaJiaShi.BP_JiJiaJiaShi_C");
			}
			return BP_JiJiaJiaShi_C._ClassPtr;
		}

		// Token: 0x06024046 RID: 147526 RVA: 0x009927C0 File Offset: 0x009909C0
		public BP_JiJiaJiaShi_C() : this(BuiltinUtils.AllocNativeUObject(BP_JiJiaJiaShi_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024047 RID: 147527 RVA: 0x009927E8 File Offset: 0x009909E8
		[NullableContext(1)]
		public BP_JiJiaJiaShi_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_JiJiaJiaShi_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004987 RID: 18823
		// (get) Token: 0x06024048 RID: 147528 RVA: 0x0099281C File Offset: 0x00990A1C
		// (set) Token: 0x06024049 RID: 147529 RVA: 0x00992855 File Offset: 0x00990A55
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_JiJiaJiaShi_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_JiJiaJiaShi_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004988 RID: 18824
		// (get) Token: 0x0602404A RID: 147530 RVA: 0x00992876 File Offset: 0x00990A76
		// (set) Token: 0x0602404B RID: 147531 RVA: 0x0099288A File Offset: 0x00990A8A
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_JiJiaJiaShi_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_JiJiaJiaShi_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004989 RID: 18825
		// (get) Token: 0x0602404C RID: 147532 RVA: 0x0099289F File Offset: 0x00990A9F
		// (set) Token: 0x0602404D RID: 147533 RVA: 0x009928B3 File Offset: 0x00990AB3
		public unsafe FVector BeforeVector_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_JiJiaJiaShi_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_JiJiaJiaShi_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700498A RID: 18826
		// (get) Token: 0x0602404E RID: 147534 RVA: 0x009928C8 File Offset: 0x00990AC8
		// (set) Token: 0x0602404F RID: 147535 RVA: 0x009928DC File Offset: 0x00990ADC
		public unsafe FName LifePlay_Position
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_JiJiaJiaShi_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_JiJiaJiaShi_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700498B RID: 18827
		// (get) Token: 0x06024050 RID: 147536 RVA: 0x009928F1 File Offset: 0x00990AF1
		// (set) Token: 0x06024051 RID: 147537 RVA: 0x00992905 File Offset: 0x00990B05
		public unsafe FVector V_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_JiJiaJiaShi_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_JiJiaJiaShi_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700498C RID: 18828
		// (get) Token: 0x06024052 RID: 147538 RVA: 0x0099291A File Offset: 0x00990B1A
		// (set) Token: 0x06024053 RID: 147539 RVA: 0x0099292E File Offset: 0x00990B2E
		public unsafe UNiagaraSystem NewVar_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_JiJiaJiaShi_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_JiJiaJiaShi_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700498D RID: 18829
		// (get) Token: 0x06024054 RID: 147540 RVA: 0x00992943 File Offset: 0x00990B43
		// (set) Token: 0x06024055 RID: 147541 RVA: 0x00992957 File Offset: 0x00990B57
		public unsafe FVector BeforeVector__Editor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_JiJiaJiaShi_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_JiJiaJiaShi_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x06024056 RID: 147542 RVA: 0x0099296C File Offset: 0x00990B6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DisableTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_JiJiaJiaShi_C.__DisableTick_NativeFunctionPtr, null);
		}

		// Token: 0x06024057 RID: 147543 RVA: 0x00992980 File Offset: 0x00990B80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EnableTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_JiJiaJiaShi_C.__EnableTick_NativeFunctionPtr, null);
		}

		// Token: 0x06024058 RID: 147544 RVA: 0x00992994 File Offset: 0x00990B94
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_JiJiaJiaShi_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06024059 RID: 147545 RVA: 0x009929A8 File Offset: 0x00990BA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_JiJiaJiaShi_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602405A RID: 147546 RVA: 0x009929BD File Offset: 0x00990BBD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_JiJiaJiaShi_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602405B RID: 147547 RVA: 0x009929D1 File Offset: 0x00990BD1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_JiJiaJiaShi_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602405C RID: 147548 RVA: 0x009929E8 File Offset: 0x00990BE8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_JiJiaJiaShi_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_JiJiaJiaShi_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_JiJiaJiaShi_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_JiJiaJiaShi_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_JiJiaJiaShi_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602405D RID: 147549 RVA: 0x00992A30 File Offset: 0x00990C30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_JiJiaJiaShi_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_JiJiaJiaShi_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_JiJiaJiaShi_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_JiJiaJiaShi_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_JiJiaJiaShi_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602405E RID: 147550 RVA: 0x00992A78 File Offset: 0x00990C78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_JiJiaJiaShi_C.__EditorTick_FunctionParams* ptr = stackalloc BP_JiJiaJiaShi_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_JiJiaJiaShi_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_JiJiaJiaShi_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_JiJiaJiaShi_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602405F RID: 147551 RVA: 0x00992AC0 File Offset: 0x00990CC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_JiJiaJiaShi_C.__EditorTick_FunctionParams* ptr = stackalloc BP_JiJiaJiaShi_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_JiJiaJiaShi_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_JiJiaJiaShi_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_JiJiaJiaShi_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024060 RID: 147552 RVA: 0x00992B08 File Offset: 0x00990D08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_JiJiaJiaShi(int EntryPoint)
		{
			BP_JiJiaJiaShi_C.__ExecuteUbergraph_BP_JiJiaJiaShi_FunctionParams* ptr = stackalloc BP_JiJiaJiaShi_C.__ExecuteUbergraph_BP_JiJiaJiaShi_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_JiJiaJiaShi_C.__ExecuteUbergraph_BP_JiJiaJiaShi_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_JiJiaJiaShi_C.__ExecuteUbergraph_BP_JiJiaJiaShi_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_JiJiaJiaShi_C.__ExecuteUbergraph_BP_JiJiaJiaShi_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024061 RID: 147553 RVA: 0x00992B4F File Offset: 0x00990D4F
		protected BP_JiJiaJiaShi_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012687 RID: 75399
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Interaction/BP_JiJiaJiaShi.BP_JiJiaJiaShi_C";

		// Token: 0x04012688 RID: 75400
		private static IntPtr _ClassPtr;

		// Token: 0x04012689 RID: 75401
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401268A RID: 75402
		internal static int __PropertyOffset_0;

		// Token: 0x0401268B RID: 75403
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401268C RID: 75404
		internal static int __PropertyOffset_1;

		// Token: 0x0401268D RID: 75405
		internal static int __PropertyOffset_2;

		// Token: 0x0401268E RID: 75406
		internal static int __PropertyOffset_3;

		// Token: 0x0401268F RID: 75407
		internal static int __PropertyOffset_4;

		// Token: 0x04012690 RID: 75408
		internal static int __PropertyOffset_5;

		// Token: 0x04012691 RID: 75409
		internal static int __PropertyOffset_6;

		// Token: 0x04012692 RID: 75410
		private static IntPtr __DisableTick_NativeFunctionPtr;

		// Token: 0x04012693 RID: 75411
		private static IntPtr __EnableTick_NativeFunctionPtr;

		// Token: 0x04012694 RID: 75412
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012695 RID: 75413
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012696 RID: 75414
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012697 RID: 75415
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04012698 RID: 75416
		private static IntPtr __ExecuteUbergraph_BP_JiJiaJiaShi_NativeFunctionPtr;

		// Token: 0x02009D7C RID: 40316
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032771 RID: 206705
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D7D RID: 40317
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032772 RID: 206706
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D7E RID: 40318
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_JiJiaJiaShi_FunctionParams
		{
			// Token: 0x04032773 RID: 206707
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
