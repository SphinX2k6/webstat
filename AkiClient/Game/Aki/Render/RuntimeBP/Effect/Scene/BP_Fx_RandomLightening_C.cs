using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.Scene
{
	// Token: 0x02003D30 RID: 15664
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/Scene/BP_Fx_RandomLightening.BP_Fx_RandomLightening_C")]
	[UnrealStructLayout(1392, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1392)]
	public class BP_Fx_RandomLightening_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025F40 RID: 155456 RVA: 0x009C9710 File Offset: 0x009C7910
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Fx_RandomLightening_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/Scene/BP_Fx_RandomLightening.BP_Fx_RandomLightening_C");
			}
			return BP_Fx_RandomLightening_C._ClassPtr;
		}

		// Token: 0x06025F41 RID: 155457 RVA: 0x009C9734 File Offset: 0x009C7934
		public BP_Fx_RandomLightening_C() : this(BuiltinUtils.AllocNativeUObject(BP_Fx_RandomLightening_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025F42 RID: 155458 RVA: 0x009C975C File Offset: 0x009C795C
		[NullableContext(1)]
		public BP_Fx_RandomLightening_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Fx_RandomLightening_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170054B3 RID: 21683
		// (get) Token: 0x06025F43 RID: 155459 RVA: 0x009C9790 File Offset: 0x009C7990
		// (set) Token: 0x06025F44 RID: 155460 RVA: 0x009C97C9 File Offset: 0x009C79C9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Fx_RandomLightening_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170054B4 RID: 21684
		// (get) Token: 0x06025F45 RID: 155461 RVA: 0x009C97EA File Offset: 0x009C79EA
		// (set) Token: 0x06025F46 RID: 155462 RVA: 0x009C97FE File Offset: 0x009C79FE
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_RandomLightening_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_RandomLightening_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170054B5 RID: 21685
		// (get) Token: 0x06025F47 RID: 155463 RVA: 0x009C9813 File Offset: 0x009C7A13
		// (set) Token: 0x06025F48 RID: 155464 RVA: 0x009C9827 File Offset: 0x009C7A27
		public unsafe UPointLightComponent PointLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_RandomLightening_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_RandomLightening_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170054B6 RID: 21686
		// (get) Token: 0x06025F49 RID: 155465 RVA: 0x009C983C File Offset: 0x009C7A3C
		// (set) Token: 0x06025F4A RID: 155466 RVA: 0x009C9850 File Offset: 0x009C7A50
		public unsafe UNiagaraComponent Niagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_RandomLightening_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_RandomLightening_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170054B7 RID: 21687
		// (get) Token: 0x06025F4B RID: 155467 RVA: 0x009C9865 File Offset: 0x009C7A65
		// (set) Token: 0x06025F4C RID: 155468 RVA: 0x009C9875 File Offset: 0x009C7A75
		public unsafe float IntervalMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170054B8 RID: 21688
		// (get) Token: 0x06025F4D RID: 155469 RVA: 0x009C9886 File Offset: 0x009C7A86
		// (set) Token: 0x06025F4E RID: 155470 RVA: 0x009C9896 File Offset: 0x009C7A96
		public unsafe float IntervalMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170054B9 RID: 21689
		// (get) Token: 0x06025F4F RID: 155471 RVA: 0x009C98A8 File Offset: 0x009C7AA8
		// (set) Token: 0x06025F50 RID: 155472 RVA: 0x009C98E1 File Offset: 0x009C7AE1
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
					result = (this._LightCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_Fx_RandomLightening_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170054BA RID: 21690
		// (get) Token: 0x06025F51 RID: 155473 RVA: 0x009C9904 File Offset: 0x009C7B04
		// (set) Token: 0x06025F52 RID: 155474 RVA: 0x009C993D File Offset: 0x009C7B3D
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
					result = (this._PostProcessCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_Fx_RandomLightening_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170054BB RID: 21691
		// (get) Token: 0x06025F53 RID: 155475 RVA: 0x009C995E File Offset: 0x009C7B5E
		// (set) Token: 0x06025F54 RID: 155476 RVA: 0x009C996E File Offset: 0x009C7B6E
		public unsafe float Counter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170054BC RID: 21692
		// (get) Token: 0x06025F55 RID: 155477 RVA: 0x009C997F File Offset: 0x009C7B7F
		// (set) Token: 0x06025F56 RID: 155478 RVA: 0x009C998F File Offset: 0x009C7B8F
		public unsafe float Age
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170054BD RID: 21693
		// (get) Token: 0x06025F57 RID: 155479 RVA: 0x009C99A0 File Offset: 0x009C7BA0
		// (set) Token: 0x06025F58 RID: 155480 RVA: 0x009C99B0 File Offset: 0x009C7BB0
		public unsafe float Delta
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_RandomLightening_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170054BE RID: 21694
		// (get) Token: 0x06025F59 RID: 155481 RVA: 0x009C99C1 File Offset: 0x009C7BC1
		// (set) Token: 0x06025F5A RID: 155482 RVA: 0x009C99D5 File Offset: 0x009C7BD5
		public unsafe UNiagaraSystem NiagaraAsset
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_RandomLightening_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_RandomLightening_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x170054BF RID: 21695
		// (get) Token: 0x06025F5B RID: 155483 RVA: 0x009C99EA File Offset: 0x009C7BEA
		// (set) Token: 0x06025F5C RID: 155484 RVA: 0x009C99FE File Offset: 0x009C7BFE
		public unsafe UAkAudioEvent AudioEvent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_RandomLightening_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_RandomLightening_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x06025F5D RID: 155485 RVA: 0x009C9A13 File Offset: 0x009C7C13
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Spawn()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_RandomLightening_C.__Spawn_NativeFunctionPtr, null);
		}

		// Token: 0x06025F5E RID: 155486 RVA: 0x009C9A27 File Offset: 0x009C7C27
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_RandomLightening_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06025F5F RID: 155487 RVA: 0x009C9A3B File Offset: 0x009C7C3B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Fx_RandomLightening_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025F60 RID: 155488 RVA: 0x009C9A50 File Offset: 0x009C7C50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Fx_RandomLightening_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Fx_RandomLightening_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Fx_RandomLightening_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_RandomLightening_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_RandomLightening_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025F61 RID: 155489 RVA: 0x009C9A98 File Offset: 0x009C7C98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Fx_RandomLightening_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Fx_RandomLightening_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Fx_RandomLightening_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_RandomLightening_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Fx_RandomLightening_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025F62 RID: 155490 RVA: 0x009C9AE0 File Offset: 0x009C7CE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Fx_RandomLightening(int EntryPoint)
		{
			BP_Fx_RandomLightening_C.__ExecuteUbergraph_BP_Fx_RandomLightening_FunctionParams* ptr = stackalloc BP_Fx_RandomLightening_C.__ExecuteUbergraph_BP_Fx_RandomLightening_FunctionParams[(UIntPtr)51] + 15L / (long)sizeof(BP_Fx_RandomLightening_C.__ExecuteUbergraph_BP_Fx_RandomLightening_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_RandomLightening_C.__ExecuteUbergraph_BP_Fx_RandomLightening_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Fx_RandomLightening_C.__ExecuteUbergraph_BP_Fx_RandomLightening_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025F63 RID: 155491 RVA: 0x009C9B27 File Offset: 0x009C7D27
		protected BP_Fx_RandomLightening_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040139FB RID: 80379
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/Scene/BP_Fx_RandomLightening.BP_Fx_RandomLightening_C";

		// Token: 0x040139FC RID: 80380
		private static IntPtr _ClassPtr;

		// Token: 0x040139FD RID: 80381
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040139FE RID: 80382
		internal static int __PropertyOffset_0;

		// Token: 0x040139FF RID: 80383
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013A00 RID: 80384
		internal static int __PropertyOffset_1;

		// Token: 0x04013A01 RID: 80385
		internal static int __PropertyOffset_2;

		// Token: 0x04013A02 RID: 80386
		internal static int __PropertyOffset_3;

		// Token: 0x04013A03 RID: 80387
		internal static int __PropertyOffset_4;

		// Token: 0x04013A04 RID: 80388
		internal static int __PropertyOffset_5;

		// Token: 0x04013A05 RID: 80389
		internal static int __PropertyOffset_6;

		// Token: 0x04013A06 RID: 80390
		private FKuroCurveFloat _LightCurve;

		// Token: 0x04013A07 RID: 80391
		internal static int __PropertyOffset_7;

		// Token: 0x04013A08 RID: 80392
		private FKuroCurveFloat _PostProcessCurve;

		// Token: 0x04013A09 RID: 80393
		internal static int __PropertyOffset_8;

		// Token: 0x04013A0A RID: 80394
		internal static int __PropertyOffset_9;

		// Token: 0x04013A0B RID: 80395
		internal static int __PropertyOffset_10;

		// Token: 0x04013A0C RID: 80396
		internal static int __PropertyOffset_11;

		// Token: 0x04013A0D RID: 80397
		internal static int __PropertyOffset_12;

		// Token: 0x04013A0E RID: 80398
		private static IntPtr __Spawn_NativeFunctionPtr;

		// Token: 0x04013A0F RID: 80399
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04013A10 RID: 80400
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013A11 RID: 80401
		private static IntPtr __ExecuteUbergraph_BP_Fx_RandomLightening_NativeFunctionPtr;

		// Token: 0x02009FD2 RID: 40914
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032B8A RID: 207754
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009FD3 RID: 40915
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 36)]
		protected ref struct __ExecuteUbergraph_BP_Fx_RandomLightening_FunctionParams
		{
			// Token: 0x04032B8B RID: 207755
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
