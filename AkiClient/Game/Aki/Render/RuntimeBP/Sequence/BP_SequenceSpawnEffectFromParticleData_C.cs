using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Sequence
{
	// Token: 0x02003A5F RID: 14943
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Sequence/BP_SequenceSpawnEffectFromParticleData.BP_SequenceSpawnEffectFromParticleData_C")]
	[UnrealStructLayout(1120, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1116)]
	public class BP_SequenceSpawnEffectFromParticleData_C : AActor, IUnrealUObject, IUnrealObject, INiagaraParticleCallbackHandler, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0601F107 RID: 127239 RVA: 0x0090696B File Offset: 0x00904B6B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SequenceSpawnEffectFromParticleData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Sequence/BP_SequenceSpawnEffectFromParticleData.BP_SequenceSpawnEffectFromParticleData_C");
			}
			return BP_SequenceSpawnEffectFromParticleData_C._ClassPtr;
		}

		// Token: 0x0601F108 RID: 127240 RVA: 0x0090698F File Offset: 0x00904B8F
		int INiagaraParticleCallbackHandler.InterfaceOffset()
		{
			return BP_SequenceSpawnEffectFromParticleData_C.__InterfaceOffset_INiagaraParticleCallbackHandler;
		}

		// Token: 0x0601F109 RID: 127241 RVA: 0x00906998 File Offset: 0x00904B98
		public BP_SequenceSpawnEffectFromParticleData_C() : this(BuiltinUtils.AllocNativeUObject(BP_SequenceSpawnEffectFromParticleData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F10A RID: 127242 RVA: 0x009069C0 File Offset: 0x00904BC0
		[NullableContext(1)]
		public BP_SequenceSpawnEffectFromParticleData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SequenceSpawnEffectFromParticleData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002DE0 RID: 11744
		// (get) Token: 0x0601F10B RID: 127243 RVA: 0x009069F4 File Offset: 0x00904BF4
		// (set) Token: 0x0601F10C RID: 127244 RVA: 0x00906A2D File Offset: 0x00904C2D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SequenceSpawnEffectFromParticleData_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SequenceSpawnEffectFromParticleData_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002DE1 RID: 11745
		// (get) Token: 0x0601F10D RID: 127245 RVA: 0x00906A4E File Offset: 0x00904C4E
		// (set) Token: 0x0601F10E RID: 127246 RVA: 0x00906A62 File Offset: 0x00904C62
		public unsafe UNiagaraComponent NiagaraSystem
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceSpawnEffectFromParticleData_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceSpawnEffectFromParticleData_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002DE2 RID: 11746
		// (get) Token: 0x0601F10F RID: 127247 RVA: 0x00906A77 File Offset: 0x00904C77
		// (set) Token: 0x0601F110 RID: 127248 RVA: 0x00906A8B File Offset: 0x00904C8B
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceSpawnEffectFromParticleData_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceSpawnEffectFromParticleData_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002DE3 RID: 11747
		// (get) Token: 0x0601F111 RID: 127249 RVA: 0x00906AA0 File Offset: 0x00904CA0
		// (set) Token: 0x0601F112 RID: 127250 RVA: 0x00906AD9 File Offset: 0x00904CD9
		[Nullable(1)]
		public TArray<int> EffectComponents
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._EffectComponents) == null)
				{
					result = (this._EffectComponents = new TArray<int>(base.NativePtr + (IntPtr)BP_SequenceSpawnEffectFromParticleData_C.__PropertyOffset_3, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.EffectComponents.CopyAssign(value);
			}
		}

		// Token: 0x17002DE4 RID: 11748
		// (get) Token: 0x0601F113 RID: 127251 RVA: 0x00906AE7 File Offset: 0x00904CE7
		// (set) Token: 0x0601F114 RID: 127252 RVA: 0x00906AFB File Offset: 0x00904CFB
		public unsafe UNiagaraSystem SourceNiagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceSpawnEffectFromParticleData_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceSpawnEffectFromParticleData_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002DE5 RID: 11749
		// (get) Token: 0x0601F115 RID: 127253 RVA: 0x00906B10 File Offset: 0x00904D10
		// (set) Token: 0x0601F116 RID: 127254 RVA: 0x00906B24 File Offset: 0x00904D24
		public unsafe UNiagaraSystem TargetNiagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceSpawnEffectFromParticleData_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceSpawnEffectFromParticleData_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17002DE6 RID: 11750
		// (get) Token: 0x0601F117 RID: 127255 RVA: 0x00906B3C File Offset: 0x00904D3C
		// (set) Token: 0x0601F118 RID: 127256 RVA: 0x00906B75 File Offset: 0x00904D75
		[Nullable(1)]
		public TArray<ANiagaraActor> Actors
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<ANiagaraActor> result;
				if ((result = this._Actors) == null)
				{
					result = (this._Actors = new TArray<ANiagaraActor>(base.NativePtr + (IntPtr)BP_SequenceSpawnEffectFromParticleData_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Actors.CopyAssign(value);
			}
		}

		// Token: 0x17002DE7 RID: 11751
		// (get) Token: 0x0601F119 RID: 127257 RVA: 0x00906B83 File Offset: 0x00904D83
		// (set) Token: 0x0601F11A RID: 127258 RVA: 0x00906B97 File Offset: 0x00904D97
		public unsafe FName ParameterName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceSpawnEffectFromParticleData_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceSpawnEffectFromParticleData_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x0601F11B RID: 127259 RVA: 0x00906BAC File Offset: 0x00904DAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ReceiveParticleData([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<FBasicParticleData> Data, UNiagaraSystem NiagaraSystem)
		{
			BP_SequenceSpawnEffectFromParticleData_C.__ReceiveParticleData_FunctionParams* ptr = stackalloc BP_SequenceSpawnEffectFromParticleData_C.__ReceiveParticleData_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_SequenceSpawnEffectFromParticleData_C.__ReceiveParticleData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SequenceSpawnEffectFromParticleData_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
			object obj = Data;
			if (obj != null)
			{
				obj.MoveTo(&ptr->Data);
			}
			ptr->NiagaraSystem = ((NiagaraSystem != null) ? NiagaraSystem.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SequenceSpawnEffectFromParticleData_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr);
			object obj2 = Data;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->Data);
			}
			UnrealReflectionUtils.DestroyStruct(BP_SequenceSpawnEffectFromParticleData_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601F11C RID: 127260 RVA: 0x00906C3C File Offset: 0x00904E3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveParticleData_Implementation([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<FBasicParticleData> Data, UNiagaraSystem NiagaraSystem)
		{
			BP_SequenceSpawnEffectFromParticleData_C.__ReceiveParticleData_FunctionParams* ptr = stackalloc BP_SequenceSpawnEffectFromParticleData_C.__ReceiveParticleData_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_SequenceSpawnEffectFromParticleData_C.__ReceiveParticleData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SequenceSpawnEffectFromParticleData_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
			object obj = Data;
			if (obj != null)
			{
				obj.MoveTo(&ptr->Data);
			}
			ptr->NiagaraSystem = ((NiagaraSystem != null) ? NiagaraSystem.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SequenceSpawnEffectFromParticleData_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 0);
			object obj2 = Data;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->Data);
			}
			UnrealReflectionUtils.DestroyStruct(BP_SequenceSpawnEffectFromParticleData_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601F11D RID: 127261 RVA: 0x00906CCB File Offset: 0x00904ECB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SequenceSpawnEffectFromParticleData_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F11E RID: 127262 RVA: 0x00906CDF File Offset: 0x00904EDF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SequenceSpawnEffectFromParticleData_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F11F RID: 127263 RVA: 0x00906CF4 File Offset: 0x00904EF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_SequenceSpawnEffectFromParticleData_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_SequenceSpawnEffectFromParticleData_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_SequenceSpawnEffectFromParticleData_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SequenceSpawnEffectFromParticleData_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SequenceSpawnEffectFromParticleData_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F120 RID: 127264 RVA: 0x00906D40 File Offset: 0x00904F40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_SequenceSpawnEffectFromParticleData_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_SequenceSpawnEffectFromParticleData_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_SequenceSpawnEffectFromParticleData_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SequenceSpawnEffectFromParticleData_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SequenceSpawnEffectFromParticleData_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F121 RID: 127265 RVA: 0x00906D8C File Offset: 0x00904F8C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SequenceSpawnEffectFromParticleData(int EntryPoint)
		{
			BP_SequenceSpawnEffectFromParticleData_C.__ExecuteUbergraph_BP_SequenceSpawnEffectFromParticleData_FunctionParams* ptr = stackalloc BP_SequenceSpawnEffectFromParticleData_C.__ExecuteUbergraph_BP_SequenceSpawnEffectFromParticleData_FunctionParams[(UIntPtr)447] + 15L / (long)sizeof(BP_SequenceSpawnEffectFromParticleData_C.__ExecuteUbergraph_BP_SequenceSpawnEffectFromParticleData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SequenceSpawnEffectFromParticleData_C.__ExecuteUbergraph_BP_SequenceSpawnEffectFromParticleData_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SequenceSpawnEffectFromParticleData_C.__ExecuteUbergraph_BP_SequenceSpawnEffectFromParticleData_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F122 RID: 127266 RVA: 0x00906DD6 File Offset: 0x00904FD6
		protected BP_SequenceSpawnEffectFromParticleData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F602 RID: 62978
		internal static int __InterfaceOffset_INiagaraParticleCallbackHandler;

		// Token: 0x0400F603 RID: 62979
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Sequence/BP_SequenceSpawnEffectFromParticleData.BP_SequenceSpawnEffectFromParticleData_C";

		// Token: 0x0400F604 RID: 62980
		private static IntPtr _ClassPtr;

		// Token: 0x0400F605 RID: 62981
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F606 RID: 62982
		internal static int __PropertyOffset_0;

		// Token: 0x0400F607 RID: 62983
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F608 RID: 62984
		internal static int __PropertyOffset_1;

		// Token: 0x0400F609 RID: 62985
		internal static int __PropertyOffset_2;

		// Token: 0x0400F60A RID: 62986
		internal static int __PropertyOffset_3;

		// Token: 0x0400F60B RID: 62987
		private TArray<int> _EffectComponents;

		// Token: 0x0400F60C RID: 62988
		internal static int __PropertyOffset_4;

		// Token: 0x0400F60D RID: 62989
		internal static int __PropertyOffset_5;

		// Token: 0x0400F60E RID: 62990
		internal static int __PropertyOffset_6;

		// Token: 0x0400F60F RID: 62991
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<ANiagaraActor> _Actors;

		// Token: 0x0400F610 RID: 62992
		internal static int __PropertyOffset_7;

		// Token: 0x0400F611 RID: 62993
		private static IntPtr __ReceiveParticleData_NativeFunctionPtr;

		// Token: 0x0400F612 RID: 62994
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F613 RID: 62995
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x0400F614 RID: 62996
		private static IntPtr __ExecuteUbergraph_BP_SequenceSpawnEffectFromParticleData_NativeFunctionPtr;

		// Token: 0x02009853 RID: 38995
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ReceiveParticleData_FunctionParams
		{
			// Token: 0x04031E86 RID: 204422
			[FieldOffset(0)]
			public byte Data;

			// Token: 0x04031E87 RID: 204423
			[FieldOffset(16)]
			public IntPtr NiagaraSystem;
		}

		// Token: 0x02009854 RID: 38996
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04031E88 RID: 204424
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009855 RID: 38997
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 432)]
		protected ref struct __ExecuteUbergraph_BP_SequenceSpawnEffectFromParticleData_FunctionParams
		{
			// Token: 0x04031E89 RID: 204425
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
