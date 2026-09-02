using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Rain2.Configs;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Rain2
{
	// Token: 0x02003B38 RID: 15160
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Rain2/BP_RainComponent_CommonDrop.BP_RainComponent_CommonDrop_C")]
	[UnrealStructLayout(944, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 944)]
	public class BP_RainComponent_CommonDrop_C : UKuroRainComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020C17 RID: 134167 RVA: 0x00936103 File Offset: 0x00934303
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_RainComponent_CommonDrop_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Rain2/BP_RainComponent_CommonDrop.BP_RainComponent_CommonDrop_C");
			}
			return BP_RainComponent_CommonDrop_C._ClassPtr;
		}

		// Token: 0x06020C18 RID: 134168 RVA: 0x00936128 File Offset: 0x00934328
		public BP_RainComponent_CommonDrop_C() : this(BuiltinUtils.AllocNativeUObject(BP_RainComponent_CommonDrop_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020C19 RID: 134169 RVA: 0x00936150 File Offset: 0x00934350
		public BP_RainComponent_CommonDrop_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_RainComponent_CommonDrop_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700370F RID: 14095
		// (get) Token: 0x06020C1A RID: 134170 RVA: 0x00936184 File Offset: 0x00934384
		// (set) Token: 0x06020C1B RID: 134171 RVA: 0x009361BD File Offset: 0x009343BD
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003710 RID: 14096
		// (get) Token: 0x06020C1C RID: 134172 RVA: 0x009361DE File Offset: 0x009343DE
		// (set) Token: 0x06020C1D RID: 134173 RVA: 0x009361EE File Offset: 0x009343EE
		public unsafe int RandomSpawnerHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17003711 RID: 14097
		// (get) Token: 0x06020C1E RID: 134174 RVA: 0x009361FF File Offset: 0x009343FF
		// (set) Token: 0x06020C1F RID: 134175 RVA: 0x0093620F File Offset: 0x0093440F
		public unsafe int ArraySpawnerHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17003712 RID: 14098
		// (get) Token: 0x06020C20 RID: 134176 RVA: 0x00936220 File Offset: 0x00934420
		// (set) Token: 0x06020C21 RID: 134177 RVA: 0x00936230 File Offset: 0x00934430
		public unsafe int CycleBoxHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17003713 RID: 14099
		// (get) Token: 0x06020C22 RID: 134178 RVA: 0x00936241 File Offset: 0x00934441
		// (set) Token: 0x06020C23 RID: 134179 RVA: 0x00936255 File Offset: 0x00934455
		public unsafe FVectorDouble Center
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003714 RID: 14100
		// (get) Token: 0x06020C24 RID: 134180 RVA: 0x0093626A File Offset: 0x0093446A
		// (set) Token: 0x06020C25 RID: 134181 RVA: 0x0093627A File Offset: 0x0093447A
		public unsafe float Drag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003715 RID: 14101
		// (get) Token: 0x06020C26 RID: 134182 RVA: 0x0093628B File Offset: 0x0093448B
		// (set) Token: 0x06020C27 RID: 134183 RVA: 0x0093629F File Offset: 0x0093449F
		public unsafe FVector Gravity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003716 RID: 14102
		// (get) Token: 0x06020C28 RID: 134184 RVA: 0x009362B4 File Offset: 0x009344B4
		// (set) Token: 0x06020C29 RID: 134185 RVA: 0x009362C8 File Offset: 0x009344C8
		public unsafe FVector Wind
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003717 RID: 14103
		// (get) Token: 0x06020C2A RID: 134186 RVA: 0x009362DD File Offset: 0x009344DD
		// (set) Token: 0x06020C2B RID: 134187 RVA: 0x009362ED File Offset: 0x009344ED
		public unsafe int WindHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003718 RID: 14104
		// (get) Token: 0x06020C2C RID: 134188 RVA: 0x009362FE File Offset: 0x009344FE
		// (set) Token: 0x06020C2D RID: 134189 RVA: 0x0093630E File Offset: 0x0093450E
		public unsafe int GravityHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003719 RID: 14105
		// (get) Token: 0x06020C2E RID: 134190 RVA: 0x0093631F File Offset: 0x0093451F
		// (set) Token: 0x06020C2F RID: 134191 RVA: 0x0093632F File Offset: 0x0093452F
		public unsafe int DragHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700371A RID: 14106
		// (get) Token: 0x06020C30 RID: 134192 RVA: 0x00936340 File Offset: 0x00934540
		// (set) Token: 0x06020C31 RID: 134193 RVA: 0x00936354 File Offset: 0x00934554
		public unsafe FVector TempSpawnSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x1700371B RID: 14107
		// (get) Token: 0x06020C32 RID: 134194 RVA: 0x00936369 File Offset: 0x00934569
		// (set) Token: 0x06020C33 RID: 134195 RVA: 0x0093637D File Offset: 0x0093457D
		[Nullable(2)]
		public unsafe PDA_RainConfig_CommonDrop_C RainConfig
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_RainConfig_CommonDrop_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RainComponent_CommonDrop_C.__PropertyOffset_12);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RainComponent_CommonDrop_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x1700371C RID: 14108
		// (get) Token: 0x06020C34 RID: 134196 RVA: 0x00936394 File Offset: 0x00934594
		// (set) Token: 0x06020C35 RID: 134197 RVA: 0x009363CD File Offset: 0x009345CD
		public TMap<int, int> ArraySpawnerHandles
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, int> result;
				if ((result = this._ArraySpawnerHandles) == null)
				{
					result = (this._ArraySpawnerHandles = new TMap<int, int>(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				this.ArraySpawnerHandles.CopyAssign(value);
			}
		}

		// Token: 0x1700371D RID: 14109
		// (get) Token: 0x06020C36 RID: 134198 RVA: 0x009363DC File Offset: 0x009345DC
		// (set) Token: 0x06020C37 RID: 134199 RVA: 0x00936415 File Offset: 0x00934615
		public TMap<int, int> RandomSpawnerHandles
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, int> result;
				if ((result = this._RandomSpawnerHandles) == null)
				{
					result = (this._RandomSpawnerHandles = new TMap<int, int>(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				this.RandomSpawnerHandles.CopyAssign(value);
			}
		}

		// Token: 0x1700371E RID: 14110
		// (get) Token: 0x06020C38 RID: 134200 RVA: 0x00936423 File Offset: 0x00934623
		// (set) Token: 0x06020C39 RID: 134201 RVA: 0x00936433 File Offset: 0x00934633
		public unsafe float PassTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700371F RID: 14111
		// (get) Token: 0x06020C3A RID: 134202 RVA: 0x00936444 File Offset: 0x00934644
		// (set) Token: 0x06020C3B RID: 134203 RVA: 0x00936454 File Offset: 0x00934654
		public unsafe float SpawnScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17003720 RID: 14112
		// (get) Token: 0x06020C3C RID: 134204 RVA: 0x00936465 File Offset: 0x00934665
		// (set) Token: 0x06020C3D RID: 134205 RVA: 0x00936475 File Offset: 0x00934675
		public unsafe bool IsPendingDeactivate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003721 RID: 14113
		// (get) Token: 0x06020C3E RID: 134206 RVA: 0x00936486 File Offset: 0x00934686
		// (set) Token: 0x06020C3F RID: 134207 RVA: 0x0093649A File Offset: 0x0093469A
		public unsafe FVectorDouble ActualSpawnCenter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17003722 RID: 14114
		// (get) Token: 0x06020C40 RID: 134208 RVA: 0x009364AF File Offset: 0x009346AF
		// (set) Token: 0x06020C41 RID: 134209 RVA: 0x009364C3 File Offset: 0x009346C3
		public unsafe FVector GlobalWind
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17003723 RID: 14115
		// (get) Token: 0x06020C42 RID: 134210 RVA: 0x009364D8 File Offset: 0x009346D8
		// (set) Token: 0x06020C43 RID: 134211 RVA: 0x009364E8 File Offset: 0x009346E8
		public unsafe float GlobalDensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17003724 RID: 14116
		// (get) Token: 0x06020C44 RID: 134212 RVA: 0x009364F9 File Offset: 0x009346F9
		// (set) Token: 0x06020C45 RID: 134213 RVA: 0x0093650D File Offset: 0x0093470D
		[Nullable(2)]
		public unsafe UNiagaraComponent NiagaraComponent
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RainComponent_CommonDrop_C.__PropertyOffset_21);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RainComponent_CommonDrop_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17003725 RID: 14117
		// (get) Token: 0x06020C46 RID: 134214 RVA: 0x00936522 File Offset: 0x00934722
		// (set) Token: 0x06020C47 RID: 134215 RVA: 0x00936532 File Offset: 0x00934732
		public unsafe bool NiagaraValid
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003726 RID: 14118
		// (get) Token: 0x06020C48 RID: 134216 RVA: 0x00936543 File Offset: 0x00934743
		// (set) Token: 0x06020C49 RID: 134217 RVA: 0x00936553 File Offset: 0x00934753
		public unsafe float RainFogDensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonDrop_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x06020C4A RID: 134218 RVA: 0x00936564 File Offset: 0x00934764
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DeactivateRain()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RainComponent_CommonDrop_C.__DeactivateRain_NativeFunctionPtr, null);
		}

		// Token: 0x06020C4B RID: 134219 RVA: 0x00936578 File Offset: 0x00934778
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StopRain()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RainComponent_CommonDrop_C.__StopRain_NativeFunctionPtr, null);
		}

		// Token: 0x06020C4C RID: 134220 RVA: 0x0093658C File Offset: 0x0093478C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Start_Rain()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RainComponent_CommonDrop_C.__Start_Rain_NativeFunctionPtr, null);
		}

		// Token: 0x06020C4D RID: 134221 RVA: 0x009365A0 File Offset: 0x009347A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void PreSolveRainParticles(float DeltaSeconds)
		{
			BP_RainComponent_CommonDrop_C.__PreSolveRainParticles_FunctionParams* ptr = stackalloc BP_RainComponent_CommonDrop_C.__PreSolveRainParticles_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_RainComponent_CommonDrop_C.__PreSolveRainParticles_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RainComponent_CommonDrop_C.__PreSolveRainParticles_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RainComponent_CommonDrop_C.__PreSolveRainParticles_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020C4E RID: 134222 RVA: 0x009365E8 File Offset: 0x009347E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void PreSolveRainParticles_Implementation(float DeltaSeconds)
		{
			BP_RainComponent_CommonDrop_C.__PreSolveRainParticles_FunctionParams* ptr = stackalloc BP_RainComponent_CommonDrop_C.__PreSolveRainParticles_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_RainComponent_CommonDrop_C.__PreSolveRainParticles_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RainComponent_CommonDrop_C.__PreSolveRainParticles_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RainComponent_CommonDrop_C.__PreSolveRainParticles_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020C4F RID: 134223 RVA: 0x0093662F File Offset: 0x0093482F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void SetupRainEmitters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RainComponent_CommonDrop_C.__SetupRainEmitters_NativeFunctionPtr, null);
		}

		// Token: 0x06020C50 RID: 134224 RVA: 0x00936643 File Offset: 0x00934843
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void SetupRainEmitters_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RainComponent_CommonDrop_C.__SetupRainEmitters_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020C51 RID: 134225 RVA: 0x00936658 File Offset: 0x00934858
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_RainComponent_CommonDrop_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_RainComponent_CommonDrop_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_RainComponent_CommonDrop_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RainComponent_CommonDrop_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RainComponent_CommonDrop_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020C52 RID: 134226 RVA: 0x009366A4 File Offset: 0x009348A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_RainComponent_CommonDrop_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_RainComponent_CommonDrop_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_RainComponent_CommonDrop_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RainComponent_CommonDrop_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RainComponent_CommonDrop_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020C53 RID: 134227 RVA: 0x009366F0 File Offset: 0x009348F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_RainComponent_CommonDrop(int EntryPoint)
		{
			BP_RainComponent_CommonDrop_C.__ExecuteUbergraph_BP_RainComponent_CommonDrop_FunctionParams* ptr = stackalloc BP_RainComponent_CommonDrop_C.__ExecuteUbergraph_BP_RainComponent_CommonDrop_FunctionParams[(UIntPtr)647] + 15L / (long)sizeof(BP_RainComponent_CommonDrop_C.__ExecuteUbergraph_BP_RainComponent_CommonDrop_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RainComponent_CommonDrop_C.__ExecuteUbergraph_BP_RainComponent_CommonDrop_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RainComponent_CommonDrop_C.__ExecuteUbergraph_BP_RainComponent_CommonDrop_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020C54 RID: 134228 RVA: 0x0093673A File Offset: 0x0093493A
		protected BP_RainComponent_CommonDrop_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040106AD RID: 67245
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Rain2/BP_RainComponent_CommonDrop.BP_RainComponent_CommonDrop_C";

		// Token: 0x040106AE RID: 67246
		private static IntPtr _ClassPtr;

		// Token: 0x040106AF RID: 67247
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040106B0 RID: 67248
		internal static int __PropertyOffset_0;

		// Token: 0x040106B1 RID: 67249
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040106B2 RID: 67250
		internal static int __PropertyOffset_1;

		// Token: 0x040106B3 RID: 67251
		internal static int __PropertyOffset_2;

		// Token: 0x040106B4 RID: 67252
		internal static int __PropertyOffset_3;

		// Token: 0x040106B5 RID: 67253
		internal static int __PropertyOffset_4;

		// Token: 0x040106B6 RID: 67254
		internal static int __PropertyOffset_5;

		// Token: 0x040106B7 RID: 67255
		internal static int __PropertyOffset_6;

		// Token: 0x040106B8 RID: 67256
		internal static int __PropertyOffset_7;

		// Token: 0x040106B9 RID: 67257
		internal static int __PropertyOffset_8;

		// Token: 0x040106BA RID: 67258
		internal static int __PropertyOffset_9;

		// Token: 0x040106BB RID: 67259
		internal static int __PropertyOffset_10;

		// Token: 0x040106BC RID: 67260
		internal static int __PropertyOffset_11;

		// Token: 0x040106BD RID: 67261
		internal static int __PropertyOffset_12;

		// Token: 0x040106BE RID: 67262
		internal static int __PropertyOffset_13;

		// Token: 0x040106BF RID: 67263
		[Nullable(2)]
		private TMap<int, int> _ArraySpawnerHandles;

		// Token: 0x040106C0 RID: 67264
		internal static int __PropertyOffset_14;

		// Token: 0x040106C1 RID: 67265
		[Nullable(2)]
		private TMap<int, int> _RandomSpawnerHandles;

		// Token: 0x040106C2 RID: 67266
		internal static int __PropertyOffset_15;

		// Token: 0x040106C3 RID: 67267
		internal static int __PropertyOffset_16;

		// Token: 0x040106C4 RID: 67268
		internal static int __PropertyOffset_17;

		// Token: 0x040106C5 RID: 67269
		internal static int __PropertyOffset_18;

		// Token: 0x040106C6 RID: 67270
		internal static int __PropertyOffset_19;

		// Token: 0x040106C7 RID: 67271
		internal static int __PropertyOffset_20;

		// Token: 0x040106C8 RID: 67272
		internal static int __PropertyOffset_21;

		// Token: 0x040106C9 RID: 67273
		internal static int __PropertyOffset_22;

		// Token: 0x040106CA RID: 67274
		internal static int __PropertyOffset_23;

		// Token: 0x040106CB RID: 67275
		private static IntPtr __DeactivateRain_NativeFunctionPtr;

		// Token: 0x040106CC RID: 67276
		private static IntPtr __StopRain_NativeFunctionPtr;

		// Token: 0x040106CD RID: 67277
		private static IntPtr __Start_Rain_NativeFunctionPtr;

		// Token: 0x040106CE RID: 67278
		private static IntPtr __PreSolveRainParticles_NativeFunctionPtr;

		// Token: 0x040106CF RID: 67279
		private static IntPtr __SetupRainEmitters_NativeFunctionPtr;

		// Token: 0x040106D0 RID: 67280
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x040106D1 RID: 67281
		private static IntPtr __ExecuteUbergraph_BP_RainComponent_CommonDrop_NativeFunctionPtr;

		// Token: 0x02009A27 RID: 39463
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __PreSolveRainParticles_FunctionParams
		{
			// Token: 0x0403211E RID: 205086
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A28 RID: 39464
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x0403211F RID: 205087
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009A29 RID: 39465
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 632)]
		protected ref struct __ExecuteUbergraph_BP_RainComponent_CommonDrop_FunctionParams
		{
			// Token: 0x04032120 RID: 205088
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
