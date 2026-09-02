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
	// Token: 0x02003B3A RID: 15162
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Rain2/BP_RainComponent_CommonReverse_Sequence.BP_RainComponent_CommonReverse_Sequence_C")]
	[UnrealStructLayout(944, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 941)]
	public class BP_RainComponent_CommonReverse_Sequence_C : UKuroRainComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020CA5 RID: 134309 RVA: 0x00936EAB File Offset: 0x009350AB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_RainComponent_CommonReverse_Sequence_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Rain2/BP_RainComponent_CommonReverse_Sequence.BP_RainComponent_CommonReverse_Sequence_C");
			}
			return BP_RainComponent_CommonReverse_Sequence_C._ClassPtr;
		}

		// Token: 0x06020CA6 RID: 134310 RVA: 0x00936ED0 File Offset: 0x009350D0
		public BP_RainComponent_CommonReverse_Sequence_C() : this(BuiltinUtils.AllocNativeUObject(BP_RainComponent_CommonReverse_Sequence_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020CA7 RID: 134311 RVA: 0x00936EF8 File Offset: 0x009350F8
		public BP_RainComponent_CommonReverse_Sequence_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_RainComponent_CommonReverse_Sequence_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003748 RID: 14152
		// (get) Token: 0x06020CA8 RID: 134312 RVA: 0x00936F2C File Offset: 0x0093512C
		// (set) Token: 0x06020CA9 RID: 134313 RVA: 0x00936F65 File Offset: 0x00935165
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003749 RID: 14153
		// (get) Token: 0x06020CAA RID: 134314 RVA: 0x00936F86 File Offset: 0x00935186
		// (set) Token: 0x06020CAB RID: 134315 RVA: 0x00936F96 File Offset: 0x00935196
		public unsafe int RandomSpawnerHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700374A RID: 14154
		// (get) Token: 0x06020CAC RID: 134316 RVA: 0x00936FA7 File Offset: 0x009351A7
		// (set) Token: 0x06020CAD RID: 134317 RVA: 0x00936FB7 File Offset: 0x009351B7
		public unsafe int ArraySpawnerHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700374B RID: 14155
		// (get) Token: 0x06020CAE RID: 134318 RVA: 0x00936FC8 File Offset: 0x009351C8
		// (set) Token: 0x06020CAF RID: 134319 RVA: 0x00936FD8 File Offset: 0x009351D8
		public unsafe int CycleBoxHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700374C RID: 14156
		// (get) Token: 0x06020CB0 RID: 134320 RVA: 0x00936FE9 File Offset: 0x009351E9
		// (set) Token: 0x06020CB1 RID: 134321 RVA: 0x00936FFD File Offset: 0x009351FD
		public unsafe FVector Center
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700374D RID: 14157
		// (get) Token: 0x06020CB2 RID: 134322 RVA: 0x00937012 File Offset: 0x00935212
		// (set) Token: 0x06020CB3 RID: 134323 RVA: 0x00937022 File Offset: 0x00935222
		public unsafe int WindHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700374E RID: 14158
		// (get) Token: 0x06020CB4 RID: 134324 RVA: 0x00937033 File Offset: 0x00935233
		// (set) Token: 0x06020CB5 RID: 134325 RVA: 0x00937043 File Offset: 0x00935243
		public unsafe int GravityHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700374F RID: 14159
		// (get) Token: 0x06020CB6 RID: 134326 RVA: 0x00937054 File Offset: 0x00935254
		// (set) Token: 0x06020CB7 RID: 134327 RVA: 0x00937064 File Offset: 0x00935264
		public unsafe int DragHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003750 RID: 14160
		// (get) Token: 0x06020CB8 RID: 134328 RVA: 0x00937075 File Offset: 0x00935275
		// (set) Token: 0x06020CB9 RID: 134329 RVA: 0x00937089 File Offset: 0x00935289
		public unsafe FVector TempSpawnSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003751 RID: 14161
		// (get) Token: 0x06020CBA RID: 134330 RVA: 0x0093709E File Offset: 0x0093529E
		// (set) Token: 0x06020CBB RID: 134331 RVA: 0x009370B2 File Offset: 0x009352B2
		[Nullable(2)]
		public unsafe PDA_RainConfig_CommonReverse_C RainConfig
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_RainConfig_CommonReverse_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_9);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17003752 RID: 14162
		// (get) Token: 0x06020CBC RID: 134332 RVA: 0x009370C8 File Offset: 0x009352C8
		// (set) Token: 0x06020CBD RID: 134333 RVA: 0x00937101 File Offset: 0x00935301
		public TMap<int, int> ArraySpawnerHandles
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, int> result;
				if ((result = this._ArraySpawnerHandles) == null)
				{
					result = (this._ArraySpawnerHandles = new TMap<int, int>(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				this.ArraySpawnerHandles.CopyAssign(value);
			}
		}

		// Token: 0x17003753 RID: 14163
		// (get) Token: 0x06020CBE RID: 134334 RVA: 0x00937110 File Offset: 0x00935310
		// (set) Token: 0x06020CBF RID: 134335 RVA: 0x00937149 File Offset: 0x00935349
		public TMap<int, int> RandomSpawnerHandles
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, int> result;
				if ((result = this._RandomSpawnerHandles) == null)
				{
					result = (this._RandomSpawnerHandles = new TMap<int, int>(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				this.RandomSpawnerHandles.CopyAssign(value);
			}
		}

		// Token: 0x17003754 RID: 14164
		// (get) Token: 0x06020CC0 RID: 134336 RVA: 0x00937157 File Offset: 0x00935357
		// (set) Token: 0x06020CC1 RID: 134337 RVA: 0x0093716B File Offset: 0x0093536B
		public unsafe FVector PerformanceGravity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003755 RID: 14165
		// (get) Token: 0x06020CC2 RID: 134338 RVA: 0x00937180 File Offset: 0x00935380
		// (set) Token: 0x06020CC3 RID: 134339 RVA: 0x00937190 File Offset: 0x00935390
		public unsafe float PerformanceDrag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003756 RID: 14166
		// (get) Token: 0x06020CC4 RID: 134340 RVA: 0x009371A1 File Offset: 0x009353A1
		// (set) Token: 0x06020CC5 RID: 134341 RVA: 0x009371B5 File Offset: 0x009353B5
		public unsafe FVector PerformanceWind
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17003757 RID: 14167
		// (get) Token: 0x06020CC6 RID: 134342 RVA: 0x009371CA File Offset: 0x009353CA
		// (set) Token: 0x06020CC7 RID: 134343 RVA: 0x009371DA File Offset: 0x009353DA
		public unsafe float PerformanceSpawnScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17003758 RID: 14168
		// (get) Token: 0x06020CC8 RID: 134344 RVA: 0x009371EB File Offset: 0x009353EB
		// (set) Token: 0x06020CC9 RID: 134345 RVA: 0x009371FB File Offset: 0x009353FB
		public unsafe int CustomRandomHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17003759 RID: 14169
		// (get) Token: 0x06020CCA RID: 134346 RVA: 0x0093720C File Offset: 0x0093540C
		// (set) Token: 0x06020CCB RID: 134347 RVA: 0x0093721C File Offset: 0x0093541C
		public unsafe long GravityCurveSampleTaskHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x1700375A RID: 14170
		// (get) Token: 0x06020CCC RID: 134348 RVA: 0x0093722D File Offset: 0x0093542D
		// (set) Token: 0x06020CCD RID: 134349 RVA: 0x0093723D File Offset: 0x0093543D
		public unsafe long WindCurveSampleTaskHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700375B RID: 14171
		// (get) Token: 0x06020CCE RID: 134350 RVA: 0x0093724E File Offset: 0x0093544E
		// (set) Token: 0x06020CCF RID: 134351 RVA: 0x0093725E File Offset: 0x0093545E
		public unsafe long DragCurveSampleTaskHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x1700375C RID: 14172
		// (get) Token: 0x06020CD0 RID: 134352 RVA: 0x0093726F File Offset: 0x0093546F
		// (set) Token: 0x06020CD1 RID: 134353 RVA: 0x0093727F File Offset: 0x0093547F
		public unsafe long SpawnCurveSampleTaskHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x1700375D RID: 14173
		// (get) Token: 0x06020CD2 RID: 134354 RVA: 0x00937290 File Offset: 0x00935490
		// (set) Token: 0x06020CD3 RID: 134355 RVA: 0x009372A0 File Offset: 0x009354A0
		public unsafe float SpawnScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x1700375E RID: 14174
		// (get) Token: 0x06020CD4 RID: 134356 RVA: 0x009372B1 File Offset: 0x009354B1
		// (set) Token: 0x06020CD5 RID: 134357 RVA: 0x009372C1 File Offset: 0x009354C1
		public unsafe bool IsPendingDeactivate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700375F RID: 14175
		// (get) Token: 0x06020CD6 RID: 134358 RVA: 0x009372D2 File Offset: 0x009354D2
		// (set) Token: 0x06020CD7 RID: 134359 RVA: 0x009372E6 File Offset: 0x009354E6
		public unsafe FVector ActualSpawnCenter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17003760 RID: 14176
		// (get) Token: 0x06020CD8 RID: 134360 RVA: 0x009372FB File Offset: 0x009354FB
		// (set) Token: 0x06020CD9 RID: 134361 RVA: 0x0093730B File Offset: 0x0093550B
		public unsafe long TimeDilationCurveSampleTaskHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17003761 RID: 14177
		// (get) Token: 0x06020CDA RID: 134362 RVA: 0x0093731C File Offset: 0x0093551C
		// (set) Token: 0x06020CDB RID: 134363 RVA: 0x0093732C File Offset: 0x0093552C
		public unsafe float VelocitySpawnScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17003762 RID: 14178
		// (get) Token: 0x06020CDC RID: 134364 RVA: 0x0093733D File Offset: 0x0093553D
		// (set) Token: 0x06020CDD RID: 134365 RVA: 0x0093734D File Offset: 0x0093554D
		public unsafe float RainFogDensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17003763 RID: 14179
		// (get) Token: 0x06020CDE RID: 134366 RVA: 0x0093735E File Offset: 0x0093555E
		// (set) Token: 0x06020CDF RID: 134367 RVA: 0x0093736E File Offset: 0x0093556E
		public unsafe float PerformanceTimeDilation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17003764 RID: 14180
		// (get) Token: 0x06020CE0 RID: 134368 RVA: 0x0093737F File Offset: 0x0093557F
		// (set) Token: 0x06020CE1 RID: 134369 RVA: 0x0093738F File Offset: 0x0093558F
		public unsafe bool StartOnBeginPlay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_Sequence_C.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x06020CE2 RID: 134370 RVA: 0x009373A0 File Offset: 0x009355A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DeactivateRain()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RainComponent_CommonReverse_Sequence_C.__DeactivateRain_NativeFunctionPtr, null);
		}

		// Token: 0x06020CE3 RID: 134371 RVA: 0x009373B4 File Offset: 0x009355B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StopRain()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RainComponent_CommonReverse_Sequence_C.__StopRain_NativeFunctionPtr, null);
		}

		// Token: 0x06020CE4 RID: 134372 RVA: 0x009373C8 File Offset: 0x009355C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Start_Rain()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RainComponent_CommonReverse_Sequence_C.__Start_Rain_NativeFunctionPtr, null);
		}

		// Token: 0x06020CE5 RID: 134373 RVA: 0x009373DC File Offset: 0x009355DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void PreSolveRainParticles(float DeltaSeconds)
		{
			BP_RainComponent_CommonReverse_Sequence_C.__PreSolveRainParticles_FunctionParams* ptr = stackalloc BP_RainComponent_CommonReverse_Sequence_C.__PreSolveRainParticles_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_RainComponent_CommonReverse_Sequence_C.__PreSolveRainParticles_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RainComponent_CommonReverse_Sequence_C.__PreSolveRainParticles_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RainComponent_CommonReverse_Sequence_C.__PreSolveRainParticles_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020CE6 RID: 134374 RVA: 0x00937424 File Offset: 0x00935624
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void PreSolveRainParticles_Implementation(float DeltaSeconds)
		{
			BP_RainComponent_CommonReverse_Sequence_C.__PreSolveRainParticles_FunctionParams* ptr = stackalloc BP_RainComponent_CommonReverse_Sequence_C.__PreSolveRainParticles_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_RainComponent_CommonReverse_Sequence_C.__PreSolveRainParticles_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RainComponent_CommonReverse_Sequence_C.__PreSolveRainParticles_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RainComponent_CommonReverse_Sequence_C.__PreSolveRainParticles_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020CE7 RID: 134375 RVA: 0x0093746B File Offset: 0x0093566B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void SetupRainEmitters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RainComponent_CommonReverse_Sequence_C.__SetupRainEmitters_NativeFunctionPtr, null);
		}

		// Token: 0x06020CE8 RID: 134376 RVA: 0x0093747F File Offset: 0x0093567F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void SetupRainEmitters_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RainComponent_CommonReverse_Sequence_C.__SetupRainEmitters_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020CE9 RID: 134377 RVA: 0x00937494 File Offset: 0x00935694
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_RainComponent_CommonReverse_Sequence_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_RainComponent_CommonReverse_Sequence_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_RainComponent_CommonReverse_Sequence_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RainComponent_CommonReverse_Sequence_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RainComponent_CommonReverse_Sequence_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020CEA RID: 134378 RVA: 0x009374E0 File Offset: 0x009356E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_RainComponent_CommonReverse_Sequence_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_RainComponent_CommonReverse_Sequence_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_RainComponent_CommonReverse_Sequence_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RainComponent_CommonReverse_Sequence_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RainComponent_CommonReverse_Sequence_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020CEB RID: 134379 RVA: 0x0093752C File Offset: 0x0093572C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RainComponent_CommonReverse_Sequence_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020CEC RID: 134380 RVA: 0x00937540 File Offset: 0x00935740
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RainComponent_CommonReverse_Sequence_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020CED RID: 134381 RVA: 0x00937558 File Offset: 0x00935758
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_RainComponent_CommonReverse_Sequence(int EntryPoint)
		{
			BP_RainComponent_CommonReverse_Sequence_C.__ExecuteUbergraph_BP_RainComponent_CommonReverse_Sequence_FunctionParams* ptr = stackalloc BP_RainComponent_CommonReverse_Sequence_C.__ExecuteUbergraph_BP_RainComponent_CommonReverse_Sequence_FunctionParams[(UIntPtr)383] + 15L / (long)sizeof(BP_RainComponent_CommonReverse_Sequence_C.__ExecuteUbergraph_BP_RainComponent_CommonReverse_Sequence_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RainComponent_CommonReverse_Sequence_C.__ExecuteUbergraph_BP_RainComponent_CommonReverse_Sequence_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RainComponent_CommonReverse_Sequence_C.__ExecuteUbergraph_BP_RainComponent_CommonReverse_Sequence_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020CEE RID: 134382 RVA: 0x009375A2 File Offset: 0x009357A2
		protected BP_RainComponent_CommonReverse_Sequence_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010700 RID: 67328
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Rain2/BP_RainComponent_CommonReverse_Sequence.BP_RainComponent_CommonReverse_Sequence_C";

		// Token: 0x04010701 RID: 67329
		private static IntPtr _ClassPtr;

		// Token: 0x04010702 RID: 67330
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010703 RID: 67331
		internal static int __PropertyOffset_0;

		// Token: 0x04010704 RID: 67332
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010705 RID: 67333
		internal static int __PropertyOffset_1;

		// Token: 0x04010706 RID: 67334
		internal static int __PropertyOffset_2;

		// Token: 0x04010707 RID: 67335
		internal static int __PropertyOffset_3;

		// Token: 0x04010708 RID: 67336
		internal static int __PropertyOffset_4;

		// Token: 0x04010709 RID: 67337
		internal static int __PropertyOffset_5;

		// Token: 0x0401070A RID: 67338
		internal static int __PropertyOffset_6;

		// Token: 0x0401070B RID: 67339
		internal static int __PropertyOffset_7;

		// Token: 0x0401070C RID: 67340
		internal static int __PropertyOffset_8;

		// Token: 0x0401070D RID: 67341
		internal static int __PropertyOffset_9;

		// Token: 0x0401070E RID: 67342
		internal static int __PropertyOffset_10;

		// Token: 0x0401070F RID: 67343
		[Nullable(2)]
		private TMap<int, int> _ArraySpawnerHandles;

		// Token: 0x04010710 RID: 67344
		internal static int __PropertyOffset_11;

		// Token: 0x04010711 RID: 67345
		[Nullable(2)]
		private TMap<int, int> _RandomSpawnerHandles;

		// Token: 0x04010712 RID: 67346
		internal static int __PropertyOffset_12;

		// Token: 0x04010713 RID: 67347
		internal static int __PropertyOffset_13;

		// Token: 0x04010714 RID: 67348
		internal static int __PropertyOffset_14;

		// Token: 0x04010715 RID: 67349
		internal static int __PropertyOffset_15;

		// Token: 0x04010716 RID: 67350
		internal static int __PropertyOffset_16;

		// Token: 0x04010717 RID: 67351
		internal static int __PropertyOffset_17;

		// Token: 0x04010718 RID: 67352
		internal static int __PropertyOffset_18;

		// Token: 0x04010719 RID: 67353
		internal static int __PropertyOffset_19;

		// Token: 0x0401071A RID: 67354
		internal static int __PropertyOffset_20;

		// Token: 0x0401071B RID: 67355
		internal static int __PropertyOffset_21;

		// Token: 0x0401071C RID: 67356
		internal static int __PropertyOffset_22;

		// Token: 0x0401071D RID: 67357
		internal static int __PropertyOffset_23;

		// Token: 0x0401071E RID: 67358
		internal static int __PropertyOffset_24;

		// Token: 0x0401071F RID: 67359
		internal static int __PropertyOffset_25;

		// Token: 0x04010720 RID: 67360
		internal static int __PropertyOffset_26;

		// Token: 0x04010721 RID: 67361
		internal static int __PropertyOffset_27;

		// Token: 0x04010722 RID: 67362
		internal static int __PropertyOffset_28;

		// Token: 0x04010723 RID: 67363
		private static IntPtr __DeactivateRain_NativeFunctionPtr;

		// Token: 0x04010724 RID: 67364
		private static IntPtr __StopRain_NativeFunctionPtr;

		// Token: 0x04010725 RID: 67365
		private static IntPtr __Start_Rain_NativeFunctionPtr;

		// Token: 0x04010726 RID: 67366
		private static IntPtr __PreSolveRainParticles_NativeFunctionPtr;

		// Token: 0x04010727 RID: 67367
		private static IntPtr __SetupRainEmitters_NativeFunctionPtr;

		// Token: 0x04010728 RID: 67368
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04010729 RID: 67369
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401072A RID: 67370
		private static IntPtr __ExecuteUbergraph_BP_RainComponent_CommonReverse_Sequence_NativeFunctionPtr;

		// Token: 0x02009A2D RID: 39469
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __PreSolveRainParticles_FunctionParams
		{
			// Token: 0x04032124 RID: 205092
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A2E RID: 39470
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04032125 RID: 205093
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009A2F RID: 39471
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 368)]
		protected ref struct __ExecuteUbergraph_BP_RainComponent_CommonReverse_Sequence_FunctionParams
		{
			// Token: 0x04032126 RID: 205094
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
