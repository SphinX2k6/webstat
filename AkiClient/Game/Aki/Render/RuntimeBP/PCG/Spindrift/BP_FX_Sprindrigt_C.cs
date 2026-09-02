using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.Spindrift
{
	// Token: 0x02003B66 RID: 15206
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/Spindrift/BP_FX_Sprindrigt.BP_FX_Sprindrigt_C")]
	[UnrealStructLayout(1416, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1410)]
	public class BP_FX_Sprindrigt_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject, IBPI_EffectInterface_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x060216C2 RID: 136898 RVA: 0x00948B80 File Offset: 0x00946D80
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FX_Sprindrigt_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/Spindrift/BP_FX_Sprindrigt.BP_FX_Sprindrigt_C");
			}
			return BP_FX_Sprindrigt_C._ClassPtr;
		}

		// Token: 0x060216C3 RID: 136899 RVA: 0x00948BA4 File Offset: 0x00946DA4
		public BP_FX_Sprindrigt_C() : this(BuiltinUtils.AllocNativeUObject(BP_FX_Sprindrigt_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060216C4 RID: 136900 RVA: 0x00948BCC File Offset: 0x00946DCC
		[NullableContext(1)]
		public BP_FX_Sprindrigt_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FX_Sprindrigt_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003B15 RID: 15125
		// (get) Token: 0x060216C5 RID: 136901 RVA: 0x00948C00 File Offset: 0x00946E00
		// (set) Token: 0x060216C6 RID: 136902 RVA: 0x00948C39 File Offset: 0x00946E39
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_FX_Sprindrigt_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_FX_Sprindrigt_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003B16 RID: 15126
		// (get) Token: 0x060216C7 RID: 136903 RVA: 0x00948C5A File Offset: 0x00946E5A
		// (set) Token: 0x060216C8 RID: 136904 RVA: 0x00948C6E File Offset: 0x00946E6E
		public unsafe UArrowComponent Arrow
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UArrowComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FX_Sprindrigt_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FX_Sprindrigt_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003B17 RID: 15127
		// (get) Token: 0x060216C9 RID: 136905 RVA: 0x00948C83 File Offset: 0x00946E83
		// (set) Token: 0x060216CA RID: 136906 RVA: 0x00948C97 File Offset: 0x00946E97
		public unsafe UNiagaraComponent Niagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FX_Sprindrigt_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FX_Sprindrigt_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003B18 RID: 15128
		// (get) Token: 0x060216CB RID: 136907 RVA: 0x00948CAC File Offset: 0x00946EAC
		// (set) Token: 0x060216CC RID: 136908 RVA: 0x00948CC0 File Offset: 0x00946EC0
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FX_Sprindrigt_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FX_Sprindrigt_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003B19 RID: 15129
		// (get) Token: 0x060216CD RID: 136909 RVA: 0x00948CD5 File Offset: 0x00946ED5
		// (set) Token: 0x060216CE RID: 136910 RVA: 0x00948CE9 File Offset: 0x00946EE9
		public unsafe UNiagaraSystem 粒子特效
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FX_Sprindrigt_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FX_Sprindrigt_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003B1A RID: 15130
		// (get) Token: 0x060216CF RID: 136911 RVA: 0x00948CFE File Offset: 0x00946EFE
		// (set) Token: 0x060216D0 RID: 136912 RVA: 0x00948D0E File Offset: 0x00946F0E
		public unsafe int 全局时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FX_Sprindrigt_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FX_Sprindrigt_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003B1B RID: 15131
		// (get) Token: 0x060216D1 RID: 136913 RVA: 0x00948D1F File Offset: 0x00946F1F
		// (set) Token: 0x060216D2 RID: 136914 RVA: 0x00948D2F File Offset: 0x00946F2F
		public unsafe int 浪花数量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FX_Sprindrigt_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FX_Sprindrigt_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003B1C RID: 15132
		// (get) Token: 0x060216D3 RID: 136915 RVA: 0x00948D40 File Offset: 0x00946F40
		// (set) Token: 0x060216D4 RID: 136916 RVA: 0x00948D50 File Offset: 0x00946F50
		public unsafe float 浪花范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FX_Sprindrigt_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FX_Sprindrigt_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003B1D RID: 15133
		// (get) Token: 0x060216D5 RID: 136917 RVA: 0x00948D61 File Offset: 0x00946F61
		// (set) Token: 0x060216D6 RID: 136918 RVA: 0x00948D75 File Offset: 0x00946F75
		public unsafe FLinearColor 浪花颜色_白天_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FX_Sprindrigt_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FX_Sprindrigt_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003B1E RID: 15134
		// (get) Token: 0x060216D7 RID: 136919 RVA: 0x00948D8A File Offset: 0x00946F8A
		// (set) Token: 0x060216D8 RID: 136920 RVA: 0x00948D9E File Offset: 0x00946F9E
		public unsafe FLinearColor 浪花颜色_夜晚_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FX_Sprindrigt_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FX_Sprindrigt_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003B1F RID: 15135
		// (get) Token: 0x060216D9 RID: 136921 RVA: 0x00948DB3 File Offset: 0x00946FB3
		// (set) Token: 0x060216DA RID: 136922 RVA: 0x00948DC3 File Offset: 0x00946FC3
		public unsafe float 浪花周期
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FX_Sprindrigt_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FX_Sprindrigt_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003B20 RID: 15136
		// (get) Token: 0x060216DB RID: 136923 RVA: 0x00948DD4 File Offset: 0x00946FD4
		// (set) Token: 0x060216DC RID: 136924 RVA: 0x00948DE8 File Offset: 0x00946FE8
		public unsafe FVector2D 周期偏移_白天_夜晚_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FX_Sprindrigt_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FX_Sprindrigt_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003B21 RID: 15137
		// (get) Token: 0x060216DD RID: 136925 RVA: 0x00948DFD File Offset: 0x00946FFD
		// (set) Token: 0x060216DE RID: 136926 RVA: 0x00948E0D File Offset: 0x0094700D
		public unsafe bool Activate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FX_Sprindrigt_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FX_Sprindrigt_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003B22 RID: 15138
		// (get) Token: 0x060216DF RID: 136927 RVA: 0x00948E1E File Offset: 0x0094701E
		// (set) Token: 0x060216E0 RID: 136928 RVA: 0x00948E2E File Offset: 0x0094702E
		public unsafe bool IsDayTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FX_Sprindrigt_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FX_Sprindrigt_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x060216E1 RID: 136929 RVA: 0x00948E40 File Offset: 0x00947040
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetHandle(ref int Handle)
		{
			BP_FX_Sprindrigt_C.__GetHandle_FunctionParams* ptr = stackalloc BP_FX_Sprindrigt_C.__GetHandle_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FX_Sprindrigt_C.__GetHandle_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FX_Sprindrigt_C.__GetHandle_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Handle = Handle;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FX_Sprindrigt_C.__GetHandle_NativeFunctionPtr, (void*)ptr);
			Handle = ptr->Handle;
		}

		// Token: 0x060216E2 RID: 136930 RVA: 0x00948E90 File Offset: 0x00947090
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void DayAndNight(bool IsDayTime)
		{
			BP_FX_Sprindrigt_C.__DayAndNight_FunctionParams* ptr = stackalloc BP_FX_Sprindrigt_C.__DayAndNight_FunctionParams[(UIntPtr)247] + 15L / (long)sizeof(BP_FX_Sprindrigt_C.__DayAndNight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FX_Sprindrigt_C.__DayAndNight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsDayTime = IsDayTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FX_Sprindrigt_C.__DayAndNight_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060216E3 RID: 136931 RVA: 0x00948ED9 File Offset: 0x009470D9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FX_Sprindrigt_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060216E4 RID: 136932 RVA: 0x00948EED File Offset: 0x009470ED
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FX_Sprindrigt_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060216E5 RID: 136933 RVA: 0x00948F04 File Offset: 0x00947104
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetHandle(int Handle)
		{
			BP_FX_Sprindrigt_C.__SetHandle_FunctionParams* ptr = stackalloc BP_FX_Sprindrigt_C.__SetHandle_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FX_Sprindrigt_C.__SetHandle_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FX_Sprindrigt_C.__SetHandle_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Handle = Handle;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FX_Sprindrigt_C.__SetHandle_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060216E6 RID: 136934 RVA: 0x00948F4A File Offset: 0x0094714A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RemoveHandle()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FX_Sprindrigt_C.__RemoveHandle_NativeFunctionPtr, null);
		}

		// Token: 0x060216E7 RID: 136935 RVA: 0x00948F5E File Offset: 0x0094715E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FX_Sprindrigt_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060216E8 RID: 136936 RVA: 0x00948F72 File Offset: 0x00947172
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FX_Sprindrigt_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060216E9 RID: 136937 RVA: 0x00948F88 File Offset: 0x00947188
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_FX_Sprindrigt_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FX_Sprindrigt_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FX_Sprindrigt_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FX_Sprindrigt_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FX_Sprindrigt_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060216EA RID: 136938 RVA: 0x00948FD0 File Offset: 0x009471D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_FX_Sprindrigt_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FX_Sprindrigt_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FX_Sprindrigt_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FX_Sprindrigt_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FX_Sprindrigt_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060216EB RID: 136939 RVA: 0x00949018 File Offset: 0x00947218
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_FX_Sprindrigt_C.__EditorTick_FunctionParams* ptr = stackalloc BP_FX_Sprindrigt_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FX_Sprindrigt_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FX_Sprindrigt_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FX_Sprindrigt_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060216EC RID: 136940 RVA: 0x00949060 File Offset: 0x00947260
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_FX_Sprindrigt_C.__EditorTick_FunctionParams* ptr = stackalloc BP_FX_Sprindrigt_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FX_Sprindrigt_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FX_Sprindrigt_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FX_Sprindrigt_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060216ED RID: 136941 RVA: 0x009490A8 File Offset: 0x009472A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_FX_Sprindrigt(int EntryPoint)
		{
			BP_FX_Sprindrigt_C.__ExecuteUbergraph_BP_FX_Sprindrigt_FunctionParams* ptr = stackalloc BP_FX_Sprindrigt_C.__ExecuteUbergraph_BP_FX_Sprindrigt_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(BP_FX_Sprindrigt_C.__ExecuteUbergraph_BP_FX_Sprindrigt_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FX_Sprindrigt_C.__ExecuteUbergraph_BP_FX_Sprindrigt_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FX_Sprindrigt_C.__ExecuteUbergraph_BP_FX_Sprindrigt_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060216EE RID: 136942 RVA: 0x009490EF File Offset: 0x009472EF
		protected BP_FX_Sprindrigt_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010D32 RID: 68914
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/Spindrift/BP_FX_Sprindrigt.BP_FX_Sprindrigt_C";

		// Token: 0x04010D33 RID: 68915
		private static IntPtr _ClassPtr;

		// Token: 0x04010D34 RID: 68916
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010D35 RID: 68917
		internal static int __PropertyOffset_0;

		// Token: 0x04010D36 RID: 68918
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010D37 RID: 68919
		internal static int __PropertyOffset_1;

		// Token: 0x04010D38 RID: 68920
		internal static int __PropertyOffset_2;

		// Token: 0x04010D39 RID: 68921
		internal static int __PropertyOffset_3;

		// Token: 0x04010D3A RID: 68922
		internal static int __PropertyOffset_4;

		// Token: 0x04010D3B RID: 68923
		internal static int __PropertyOffset_5;

		// Token: 0x04010D3C RID: 68924
		internal static int __PropertyOffset_6;

		// Token: 0x04010D3D RID: 68925
		internal static int __PropertyOffset_7;

		// Token: 0x04010D3E RID: 68926
		internal static int __PropertyOffset_8;

		// Token: 0x04010D3F RID: 68927
		internal static int __PropertyOffset_9;

		// Token: 0x04010D40 RID: 68928
		internal static int __PropertyOffset_10;

		// Token: 0x04010D41 RID: 68929
		internal static int __PropertyOffset_11;

		// Token: 0x04010D42 RID: 68930
		internal static int __PropertyOffset_12;

		// Token: 0x04010D43 RID: 68931
		internal static int __PropertyOffset_13;

		// Token: 0x04010D44 RID: 68932
		private static IntPtr __GetHandle_NativeFunctionPtr;

		// Token: 0x04010D45 RID: 68933
		private static IntPtr __DayAndNight_NativeFunctionPtr;

		// Token: 0x04010D46 RID: 68934
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010D47 RID: 68935
		private static IntPtr __SetHandle_NativeFunctionPtr;

		// Token: 0x04010D48 RID: 68936
		private static IntPtr __RemoveHandle_NativeFunctionPtr;

		// Token: 0x04010D49 RID: 68937
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010D4A RID: 68938
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010D4B RID: 68939
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010D4C RID: 68940
		private static IntPtr __ExecuteUbergraph_BP_FX_Sprindrigt_NativeFunctionPtr;

		// Token: 0x02009AD4 RID: 39636
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetHandle_FunctionParams
		{
			// Token: 0x04032258 RID: 205400
			[FieldOffset(0)]
			public int Handle;
		}

		// Token: 0x02009AD5 RID: 39637
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 232)]
		protected ref struct __DayAndNight_FunctionParams
		{
			// Token: 0x04032259 RID: 205401
			[FieldOffset(0)]
			public bool IsDayTime;
		}

		// Token: 0x02009AD6 RID: 39638
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __SetHandle_FunctionParams
		{
			// Token: 0x0403225A RID: 205402
			[FieldOffset(0)]
			public int Handle;
		}

		// Token: 0x02009AD7 RID: 39639
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403225B RID: 205403
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009AD8 RID: 39640
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x0403225C RID: 205404
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009AD9 RID: 39641
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __ExecuteUbergraph_BP_FX_Sprindrigt_FunctionParams
		{
			// Token: 0x0403225D RID: 205405
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
