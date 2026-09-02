using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.Scene
{
	// Token: 0x02003D31 RID: 15665
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/Scene/BP_Fx_RandomLightening_New.BP_Fx_RandomLightening_New_C")]
	[UnrealStructLayout(1680, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1674)]
	public class BP_Fx_RandomLightening_New_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025F64 RID: 155492 RVA: 0x009C9B30 File Offset: 0x009C7D30
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Fx_RandomLightening_New_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/Scene/BP_Fx_RandomLightening_New.BP_Fx_RandomLightening_New_C");
			}
			return BP_Fx_RandomLightening_New_C._ClassPtr;
		}

		// Token: 0x06025F65 RID: 155493 RVA: 0x009C9B54 File Offset: 0x009C7D54
		public BP_Fx_RandomLightening_New_C() : this(BuiltinUtils.AllocNativeUObject(BP_Fx_RandomLightening_New_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025F66 RID: 155494 RVA: 0x009C9B7C File Offset: 0x009C7D7C
		[NullableContext(1)]
		public BP_Fx_RandomLightening_New_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Fx_RandomLightening_New_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170054C0 RID: 21696
		// (get) Token: 0x06025F67 RID: 155495 RVA: 0x009C9BB0 File Offset: 0x009C7DB0
		// (set) Token: 0x06025F68 RID: 155496 RVA: 0x009C9BE9 File Offset: 0x009C7DE9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_New_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Fx_RandomLightening_New_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170054C1 RID: 21697
		// (get) Token: 0x06025F69 RID: 155497 RVA: 0x009C9C0A File Offset: 0x009C7E0A
		// (set) Token: 0x06025F6A RID: 155498 RVA: 0x009C9C1E File Offset: 0x009C7E1E
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_RandomLightening_New_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_RandomLightening_New_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170054C2 RID: 21698
		// (get) Token: 0x06025F6B RID: 155499 RVA: 0x009C9C33 File Offset: 0x009C7E33
		// (set) Token: 0x06025F6C RID: 155500 RVA: 0x009C9C47 File Offset: 0x009C7E47
		public unsafe UPointLightComponent PointLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_RandomLightening_New_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_RandomLightening_New_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170054C3 RID: 21699
		// (get) Token: 0x06025F6D RID: 155501 RVA: 0x009C9C5C File Offset: 0x009C7E5C
		// (set) Token: 0x06025F6E RID: 155502 RVA: 0x009C9C70 File Offset: 0x009C7E70
		public unsafe UNiagaraComponent Niagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_RandomLightening_New_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_RandomLightening_New_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170054C4 RID: 21700
		// (get) Token: 0x06025F6F RID: 155503 RVA: 0x009C9C85 File Offset: 0x009C7E85
		// (set) Token: 0x06025F70 RID: 155504 RVA: 0x009C9C95 File Offset: 0x009C7E95
		public unsafe float IntervalMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_New_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_New_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170054C5 RID: 21701
		// (get) Token: 0x06025F71 RID: 155505 RVA: 0x009C9CA6 File Offset: 0x009C7EA6
		// (set) Token: 0x06025F72 RID: 155506 RVA: 0x009C9CB6 File Offset: 0x009C7EB6
		public unsafe float IntervalMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_New_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_New_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170054C6 RID: 21702
		// (get) Token: 0x06025F73 RID: 155507 RVA: 0x009C9CC8 File Offset: 0x009C7EC8
		// (set) Token: 0x06025F74 RID: 155508 RVA: 0x009C9D01 File Offset: 0x009C7F01
		[Nullable(1)]
		public FKuroCurveFloat LightCurve
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._LightCurve) == null)
				{
					result = (this._LightCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_New_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_Fx_RandomLightening_New_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170054C7 RID: 21703
		// (get) Token: 0x06025F75 RID: 155509 RVA: 0x009C9D24 File Offset: 0x009C7F24
		// (set) Token: 0x06025F76 RID: 155510 RVA: 0x009C9D5D File Offset: 0x009C7F5D
		[Nullable(1)]
		public FKuroCurveFloat PostProcessCurve
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._PostProcessCurve) == null)
				{
					result = (this._PostProcessCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_New_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_Fx_RandomLightening_New_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170054C8 RID: 21704
		// (get) Token: 0x06025F77 RID: 155511 RVA: 0x009C9D7E File Offset: 0x009C7F7E
		// (set) Token: 0x06025F78 RID: 155512 RVA: 0x009C9D8E File Offset: 0x009C7F8E
		public unsafe float Counter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_New_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_New_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170054C9 RID: 21705
		// (get) Token: 0x06025F79 RID: 155513 RVA: 0x009C9D9F File Offset: 0x009C7F9F
		// (set) Token: 0x06025F7A RID: 155514 RVA: 0x009C9DAF File Offset: 0x009C7FAF
		public unsafe float Age
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_New_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_New_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170054CA RID: 21706
		// (get) Token: 0x06025F7B RID: 155515 RVA: 0x009C9DC0 File Offset: 0x009C7FC0
		// (set) Token: 0x06025F7C RID: 155516 RVA: 0x009C9DD0 File Offset: 0x009C7FD0
		public unsafe float Delta
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_New_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_New_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170054CB RID: 21707
		// (get) Token: 0x06025F7D RID: 155517 RVA: 0x009C9DE1 File Offset: 0x009C7FE1
		// (set) Token: 0x06025F7E RID: 155518 RVA: 0x009C9DF5 File Offset: 0x009C7FF5
		public unsafe UNiagaraSystem NiagaraAsset
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_RandomLightening_New_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_RandomLightening_New_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x170054CC RID: 21708
		// (get) Token: 0x06025F7F RID: 155519 RVA: 0x009C9E0A File Offset: 0x009C800A
		// (set) Token: 0x06025F80 RID: 155520 RVA: 0x009C9E1E File Offset: 0x009C801E
		public unsafe UAkAudioEvent AudioEvent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_RandomLightening_New_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_RandomLightening_New_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x170054CD RID: 21709
		// (get) Token: 0x06025F81 RID: 155521 RVA: 0x009C9E33 File Offset: 0x009C8033
		// (set) Token: 0x06025F82 RID: 155522 RVA: 0x009C9E43 File Offset: 0x009C8043
		public unsafe bool UsePostprocess
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_New_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_New_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x170054CE RID: 21710
		// (get) Token: 0x06025F83 RID: 155523 RVA: 0x009C9E54 File Offset: 0x009C8054
		// (set) Token: 0x06025F84 RID: 155524 RVA: 0x009C9E64 File Offset: 0x009C8064
		public unsafe bool UsePointLight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_New_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_New_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x06025F85 RID: 155525 RVA: 0x009C9E75 File Offset: 0x009C8075
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Spawn()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_RandomLightening_New_C.__Spawn_NativeFunctionPtr, null);
		}

		// Token: 0x06025F86 RID: 155526 RVA: 0x009C9E89 File Offset: 0x009C8089
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_RandomLightening_New_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06025F87 RID: 155527 RVA: 0x009C9E9D File Offset: 0x009C809D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Fx_RandomLightening_New_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025F88 RID: 155528 RVA: 0x009C9EB4 File Offset: 0x009C80B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Fx_RandomLightening_New_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Fx_RandomLightening_New_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Fx_RandomLightening_New_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_RandomLightening_New_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_RandomLightening_New_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025F89 RID: 155529 RVA: 0x009C9EFC File Offset: 0x009C80FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Fx_RandomLightening_New_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Fx_RandomLightening_New_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Fx_RandomLightening_New_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_RandomLightening_New_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Fx_RandomLightening_New_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025F8A RID: 155530 RVA: 0x009C9F44 File Offset: 0x009C8144
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_Fx_RandomLightening_New_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Fx_RandomLightening_New_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Fx_RandomLightening_New_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_RandomLightening_New_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_RandomLightening_New_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025F8B RID: 155531 RVA: 0x009C9F8C File Offset: 0x009C818C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_Fx_RandomLightening_New_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Fx_RandomLightening_New_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Fx_RandomLightening_New_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_RandomLightening_New_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Fx_RandomLightening_New_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025F8C RID: 155532 RVA: 0x009C9FD4 File Offset: 0x009C81D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Fx_RandomLightening_New(int EntryPoint)
		{
			BP_Fx_RandomLightening_New_C.__ExecuteUbergraph_BP_Fx_RandomLightening_New_FunctionParams* ptr = stackalloc BP_Fx_RandomLightening_New_C.__ExecuteUbergraph_BP_Fx_RandomLightening_New_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_Fx_RandomLightening_New_C.__ExecuteUbergraph_BP_Fx_RandomLightening_New_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_RandomLightening_New_C.__ExecuteUbergraph_BP_Fx_RandomLightening_New_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Fx_RandomLightening_New_C.__ExecuteUbergraph_BP_Fx_RandomLightening_New_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025F8D RID: 155533 RVA: 0x009CA01B File Offset: 0x009C821B
		protected BP_Fx_RandomLightening_New_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013A12 RID: 80402
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/Scene/BP_Fx_RandomLightening_New.BP_Fx_RandomLightening_New_C";

		// Token: 0x04013A13 RID: 80403
		private static IntPtr _ClassPtr;

		// Token: 0x04013A14 RID: 80404
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013A15 RID: 80405
		internal static int __PropertyOffset_0;

		// Token: 0x04013A16 RID: 80406
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013A17 RID: 80407
		internal static int __PropertyOffset_1;

		// Token: 0x04013A18 RID: 80408
		internal static int __PropertyOffset_2;

		// Token: 0x04013A19 RID: 80409
		internal static int __PropertyOffset_3;

		// Token: 0x04013A1A RID: 80410
		internal static int __PropertyOffset_4;

		// Token: 0x04013A1B RID: 80411
		internal static int __PropertyOffset_5;

		// Token: 0x04013A1C RID: 80412
		internal static int __PropertyOffset_6;

		// Token: 0x04013A1D RID: 80413
		private FKuroCurveFloat _LightCurve;

		// Token: 0x04013A1E RID: 80414
		internal static int __PropertyOffset_7;

		// Token: 0x04013A1F RID: 80415
		private FKuroCurveFloat _PostProcessCurve;

		// Token: 0x04013A20 RID: 80416
		internal static int __PropertyOffset_8;

		// Token: 0x04013A21 RID: 80417
		internal static int __PropertyOffset_9;

		// Token: 0x04013A22 RID: 80418
		internal static int __PropertyOffset_10;

		// Token: 0x04013A23 RID: 80419
		internal static int __PropertyOffset_11;

		// Token: 0x04013A24 RID: 80420
		internal static int __PropertyOffset_12;

		// Token: 0x04013A25 RID: 80421
		internal static int __PropertyOffset_13;

		// Token: 0x04013A26 RID: 80422
		internal static int __PropertyOffset_14;

		// Token: 0x04013A27 RID: 80423
		private static IntPtr __Spawn_NativeFunctionPtr;

		// Token: 0x04013A28 RID: 80424
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04013A29 RID: 80425
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013A2A RID: 80426
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04013A2B RID: 80427
		private static IntPtr __ExecuteUbergraph_BP_Fx_RandomLightening_New_NativeFunctionPtr;

		// Token: 0x02009FD4 RID: 40916
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032B8C RID: 207756
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009FD5 RID: 40917
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032B8D RID: 207757
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009FD6 RID: 40918
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __ExecuteUbergraph_BP_Fx_RandomLightening_New_FunctionParams
		{
			// Token: 0x04032B8E RID: 207758
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
