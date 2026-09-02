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
	// Token: 0x02003B39 RID: 15161
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Rain2/BP_RainComponent_CommonReverse.BP_RainComponent_CommonReverse_C")]
	[UnrealStructLayout(1008, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1000)]
	public class BP_RainComponent_CommonReverse_C : UKuroRainComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020C55 RID: 134229 RVA: 0x00936743 File Offset: 0x00934943
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_RainComponent_CommonReverse_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Rain2/BP_RainComponent_CommonReverse.BP_RainComponent_CommonReverse_C");
			}
			return BP_RainComponent_CommonReverse_C._ClassPtr;
		}

		// Token: 0x06020C56 RID: 134230 RVA: 0x00936768 File Offset: 0x00934968
		public BP_RainComponent_CommonReverse_C() : this(BuiltinUtils.AllocNativeUObject(BP_RainComponent_CommonReverse_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020C57 RID: 134231 RVA: 0x00936790 File Offset: 0x00934990
		public BP_RainComponent_CommonReverse_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_RainComponent_CommonReverse_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003727 RID: 14119
		// (get) Token: 0x06020C58 RID: 134232 RVA: 0x009367C4 File Offset: 0x009349C4
		// (set) Token: 0x06020C59 RID: 134233 RVA: 0x009367FD File Offset: 0x009349FD
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003728 RID: 14120
		// (get) Token: 0x06020C5A RID: 134234 RVA: 0x0093681E File Offset: 0x00934A1E
		// (set) Token: 0x06020C5B RID: 134235 RVA: 0x0093682E File Offset: 0x00934A2E
		public unsafe int RandomSpawnerHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17003729 RID: 14121
		// (get) Token: 0x06020C5C RID: 134236 RVA: 0x0093683F File Offset: 0x00934A3F
		// (set) Token: 0x06020C5D RID: 134237 RVA: 0x0093684F File Offset: 0x00934A4F
		public unsafe int ArraySpawnerHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700372A RID: 14122
		// (get) Token: 0x06020C5E RID: 134238 RVA: 0x00936860 File Offset: 0x00934A60
		// (set) Token: 0x06020C5F RID: 134239 RVA: 0x00936870 File Offset: 0x00934A70
		public unsafe int CycleBoxHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700372B RID: 14123
		// (get) Token: 0x06020C60 RID: 134240 RVA: 0x00936881 File Offset: 0x00934A81
		// (set) Token: 0x06020C61 RID: 134241 RVA: 0x00936895 File Offset: 0x00934A95
		public unsafe FVectorDouble Center
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700372C RID: 14124
		// (get) Token: 0x06020C62 RID: 134242 RVA: 0x009368AA File Offset: 0x00934AAA
		// (set) Token: 0x06020C63 RID: 134243 RVA: 0x009368BA File Offset: 0x00934ABA
		public unsafe int WindHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700372D RID: 14125
		// (get) Token: 0x06020C64 RID: 134244 RVA: 0x009368CB File Offset: 0x00934ACB
		// (set) Token: 0x06020C65 RID: 134245 RVA: 0x009368DB File Offset: 0x00934ADB
		public unsafe int GravityHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700372E RID: 14126
		// (get) Token: 0x06020C66 RID: 134246 RVA: 0x009368EC File Offset: 0x00934AEC
		// (set) Token: 0x06020C67 RID: 134247 RVA: 0x009368FC File Offset: 0x00934AFC
		public unsafe int DragHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700372F RID: 14127
		// (get) Token: 0x06020C68 RID: 134248 RVA: 0x0093690D File Offset: 0x00934B0D
		// (set) Token: 0x06020C69 RID: 134249 RVA: 0x00936921 File Offset: 0x00934B21
		public unsafe FVector TempSpawnSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003730 RID: 14128
		// (get) Token: 0x06020C6A RID: 134250 RVA: 0x00936936 File Offset: 0x00934B36
		// (set) Token: 0x06020C6B RID: 134251 RVA: 0x0093694A File Offset: 0x00934B4A
		[Nullable(2)]
		public unsafe PDA_RainConfig_CommonReverse_C RainConfig
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_RainConfig_CommonReverse_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RainComponent_CommonReverse_C.__PropertyOffset_9);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RainComponent_CommonReverse_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17003731 RID: 14129
		// (get) Token: 0x06020C6C RID: 134252 RVA: 0x00936960 File Offset: 0x00934B60
		// (set) Token: 0x06020C6D RID: 134253 RVA: 0x00936999 File Offset: 0x00934B99
		public TMap<int, int> ArraySpawnerHandles
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, int> result;
				if ((result = this._ArraySpawnerHandles) == null)
				{
					result = (this._ArraySpawnerHandles = new TMap<int, int>(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				this.ArraySpawnerHandles.CopyAssign(value);
			}
		}

		// Token: 0x17003732 RID: 14130
		// (get) Token: 0x06020C6E RID: 134254 RVA: 0x009369A8 File Offset: 0x00934BA8
		// (set) Token: 0x06020C6F RID: 134255 RVA: 0x009369E1 File Offset: 0x00934BE1
		public TMap<int, int> RandomSpawnerHandles
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, int> result;
				if ((result = this._RandomSpawnerHandles) == null)
				{
					result = (this._RandomSpawnerHandles = new TMap<int, int>(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				this.RandomSpawnerHandles.CopyAssign(value);
			}
		}

		// Token: 0x17003733 RID: 14131
		// (get) Token: 0x06020C70 RID: 134256 RVA: 0x009369EF File Offset: 0x00934BEF
		// (set) Token: 0x06020C71 RID: 134257 RVA: 0x009369FF File Offset: 0x00934BFF
		public unsafe float PassTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003734 RID: 14132
		// (get) Token: 0x06020C72 RID: 134258 RVA: 0x00936A10 File Offset: 0x00934C10
		// (set) Token: 0x06020C73 RID: 134259 RVA: 0x00936A24 File Offset: 0x00934C24
		public unsafe FVector PerformanceGravity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003735 RID: 14133
		// (get) Token: 0x06020C74 RID: 134260 RVA: 0x00936A39 File Offset: 0x00934C39
		// (set) Token: 0x06020C75 RID: 134261 RVA: 0x00936A49 File Offset: 0x00934C49
		public unsafe float PerformanceDrag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17003736 RID: 14134
		// (get) Token: 0x06020C76 RID: 134262 RVA: 0x00936A5A File Offset: 0x00934C5A
		// (set) Token: 0x06020C77 RID: 134263 RVA: 0x00936A6E File Offset: 0x00934C6E
		public unsafe FVector PerformanceWind
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17003737 RID: 14135
		// (get) Token: 0x06020C78 RID: 134264 RVA: 0x00936A83 File Offset: 0x00934C83
		// (set) Token: 0x06020C79 RID: 134265 RVA: 0x00936A93 File Offset: 0x00934C93
		public unsafe float PerformanceSpawnScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17003738 RID: 14136
		// (get) Token: 0x06020C7A RID: 134266 RVA: 0x00936AA4 File Offset: 0x00934CA4
		// (set) Token: 0x06020C7B RID: 134267 RVA: 0x00936AB4 File Offset: 0x00934CB4
		public unsafe float Shape
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17003739 RID: 14137
		// (get) Token: 0x06020C7C RID: 134268 RVA: 0x00936AC5 File Offset: 0x00934CC5
		// (set) Token: 0x06020C7D RID: 134269 RVA: 0x00936AD5 File Offset: 0x00934CD5
		public unsafe int CustomRandomHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700373A RID: 14138
		// (get) Token: 0x06020C7E RID: 134270 RVA: 0x00936AE6 File Offset: 0x00934CE6
		// (set) Token: 0x06020C7F RID: 134271 RVA: 0x00936AF6 File Offset: 0x00934CF6
		public unsafe long GravityCurveSampleTaskHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x1700373B RID: 14139
		// (get) Token: 0x06020C80 RID: 134272 RVA: 0x00936B07 File Offset: 0x00934D07
		// (set) Token: 0x06020C81 RID: 134273 RVA: 0x00936B17 File Offset: 0x00934D17
		public unsafe long WindCurveSampleTaskHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x1700373C RID: 14140
		// (get) Token: 0x06020C82 RID: 134274 RVA: 0x00936B28 File Offset: 0x00934D28
		// (set) Token: 0x06020C83 RID: 134275 RVA: 0x00936B38 File Offset: 0x00934D38
		public unsafe long DragCurveSampleTaskHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x1700373D RID: 14141
		// (get) Token: 0x06020C84 RID: 134276 RVA: 0x00936B49 File Offset: 0x00934D49
		// (set) Token: 0x06020C85 RID: 134277 RVA: 0x00936B59 File Offset: 0x00934D59
		public unsafe long SpawnCurveSampleTaskHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x1700373E RID: 14142
		// (get) Token: 0x06020C86 RID: 134278 RVA: 0x00936B6A File Offset: 0x00934D6A
		// (set) Token: 0x06020C87 RID: 134279 RVA: 0x00936B7A File Offset: 0x00934D7A
		public unsafe float SpawnScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x1700373F RID: 14143
		// (get) Token: 0x06020C88 RID: 134280 RVA: 0x00936B8B File Offset: 0x00934D8B
		// (set) Token: 0x06020C89 RID: 134281 RVA: 0x00936B9B File Offset: 0x00934D9B
		public unsafe bool IsPendingDeactivate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003740 RID: 14144
		// (get) Token: 0x06020C8A RID: 134282 RVA: 0x00936BAC File Offset: 0x00934DAC
		// (set) Token: 0x06020C8B RID: 134283 RVA: 0x00936BC0 File Offset: 0x00934DC0
		public unsafe FVectorDouble ActualSpawnCenter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17003741 RID: 14145
		// (get) Token: 0x06020C8C RID: 134284 RVA: 0x00936BD5 File Offset: 0x00934DD5
		// (set) Token: 0x06020C8D RID: 134285 RVA: 0x00936BE9 File Offset: 0x00934DE9
		public unsafe FVector GlobalWind
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17003742 RID: 14146
		// (get) Token: 0x06020C8E RID: 134286 RVA: 0x00936BFE File Offset: 0x00934DFE
		// (set) Token: 0x06020C8F RID: 134287 RVA: 0x00936C0E File Offset: 0x00934E0E
		public unsafe float GlobalDensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17003743 RID: 14147
		// (get) Token: 0x06020C90 RID: 134288 RVA: 0x00936C1F File Offset: 0x00934E1F
		// (set) Token: 0x06020C91 RID: 134289 RVA: 0x00936C2F File Offset: 0x00934E2F
		public unsafe long TimeDilationCurveSampleTaskHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17003744 RID: 14148
		// (get) Token: 0x06020C92 RID: 134290 RVA: 0x00936C40 File Offset: 0x00934E40
		// (set) Token: 0x06020C93 RID: 134291 RVA: 0x00936C50 File Offset: 0x00934E50
		public unsafe float VelocitySpawnScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17003745 RID: 14149
		// (get) Token: 0x06020C94 RID: 134292 RVA: 0x00936C61 File Offset: 0x00934E61
		// (set) Token: 0x06020C95 RID: 134293 RVA: 0x00936C75 File Offset: 0x00934E75
		[Nullable(2)]
		public unsafe UNiagaraComponent NiagaraComponent
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RainComponent_CommonReverse_C.__PropertyOffset_30);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RainComponent_CommonReverse_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x17003746 RID: 14150
		// (get) Token: 0x06020C96 RID: 134294 RVA: 0x00936C8A File Offset: 0x00934E8A
		// (set) Token: 0x06020C97 RID: 134295 RVA: 0x00936C9A File Offset: 0x00934E9A
		public unsafe bool NiagaraValid
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_31) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_31) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003747 RID: 14151
		// (get) Token: 0x06020C98 RID: 134296 RVA: 0x00936CAB File Offset: 0x00934EAB
		// (set) Token: 0x06020C99 RID: 134297 RVA: 0x00936CBB File Offset: 0x00934EBB
		public unsafe float RainFogDensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RainComponent_CommonReverse_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x06020C9A RID: 134298 RVA: 0x00936CCC File Offset: 0x00934ECC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DeactivateRain()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RainComponent_CommonReverse_C.__DeactivateRain_NativeFunctionPtr, null);
		}

		// Token: 0x06020C9B RID: 134299 RVA: 0x00936CE0 File Offset: 0x00934EE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StopRain()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RainComponent_CommonReverse_C.__StopRain_NativeFunctionPtr, null);
		}

		// Token: 0x06020C9C RID: 134300 RVA: 0x00936CF4 File Offset: 0x00934EF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Start_Rain()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RainComponent_CommonReverse_C.__Start_Rain_NativeFunctionPtr, null);
		}

		// Token: 0x06020C9D RID: 134301 RVA: 0x00936D08 File Offset: 0x00934F08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void PreSolveRainParticles(float DeltaSeconds)
		{
			BP_RainComponent_CommonReverse_C.__PreSolveRainParticles_FunctionParams* ptr = stackalloc BP_RainComponent_CommonReverse_C.__PreSolveRainParticles_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_RainComponent_CommonReverse_C.__PreSolveRainParticles_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RainComponent_CommonReverse_C.__PreSolveRainParticles_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RainComponent_CommonReverse_C.__PreSolveRainParticles_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020C9E RID: 134302 RVA: 0x00936D50 File Offset: 0x00934F50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void PreSolveRainParticles_Implementation(float DeltaSeconds)
		{
			BP_RainComponent_CommonReverse_C.__PreSolveRainParticles_FunctionParams* ptr = stackalloc BP_RainComponent_CommonReverse_C.__PreSolveRainParticles_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_RainComponent_CommonReverse_C.__PreSolveRainParticles_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RainComponent_CommonReverse_C.__PreSolveRainParticles_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RainComponent_CommonReverse_C.__PreSolveRainParticles_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020C9F RID: 134303 RVA: 0x00936D97 File Offset: 0x00934F97
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void SetupRainEmitters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RainComponent_CommonReverse_C.__SetupRainEmitters_NativeFunctionPtr, null);
		}

		// Token: 0x06020CA0 RID: 134304 RVA: 0x00936DAB File Offset: 0x00934FAB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void SetupRainEmitters_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RainComponent_CommonReverse_C.__SetupRainEmitters_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020CA1 RID: 134305 RVA: 0x00936DC0 File Offset: 0x00934FC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_RainComponent_CommonReverse_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_RainComponent_CommonReverse_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_RainComponent_CommonReverse_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RainComponent_CommonReverse_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RainComponent_CommonReverse_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020CA2 RID: 134306 RVA: 0x00936E0C File Offset: 0x0093500C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_RainComponent_CommonReverse_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_RainComponent_CommonReverse_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_RainComponent_CommonReverse_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RainComponent_CommonReverse_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RainComponent_CommonReverse_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020CA3 RID: 134307 RVA: 0x00936E58 File Offset: 0x00935058
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_RainComponent_CommonReverse(int EntryPoint)
		{
			BP_RainComponent_CommonReverse_C.__ExecuteUbergraph_BP_RainComponent_CommonReverse_FunctionParams* ptr = stackalloc BP_RainComponent_CommonReverse_C.__ExecuteUbergraph_BP_RainComponent_CommonReverse_FunctionParams[(UIntPtr)767] + 15L / (long)sizeof(BP_RainComponent_CommonReverse_C.__ExecuteUbergraph_BP_RainComponent_CommonReverse_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RainComponent_CommonReverse_C.__ExecuteUbergraph_BP_RainComponent_CommonReverse_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RainComponent_CommonReverse_C.__ExecuteUbergraph_BP_RainComponent_CommonReverse_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020CA4 RID: 134308 RVA: 0x00936EA2 File Offset: 0x009350A2
		protected BP_RainComponent_CommonReverse_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040106D2 RID: 67282
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Rain2/BP_RainComponent_CommonReverse.BP_RainComponent_CommonReverse_C";

		// Token: 0x040106D3 RID: 67283
		private static IntPtr _ClassPtr;

		// Token: 0x040106D4 RID: 67284
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040106D5 RID: 67285
		internal static int __PropertyOffset_0;

		// Token: 0x040106D6 RID: 67286
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040106D7 RID: 67287
		internal static int __PropertyOffset_1;

		// Token: 0x040106D8 RID: 67288
		internal static int __PropertyOffset_2;

		// Token: 0x040106D9 RID: 67289
		internal static int __PropertyOffset_3;

		// Token: 0x040106DA RID: 67290
		internal static int __PropertyOffset_4;

		// Token: 0x040106DB RID: 67291
		internal static int __PropertyOffset_5;

		// Token: 0x040106DC RID: 67292
		internal static int __PropertyOffset_6;

		// Token: 0x040106DD RID: 67293
		internal static int __PropertyOffset_7;

		// Token: 0x040106DE RID: 67294
		internal static int __PropertyOffset_8;

		// Token: 0x040106DF RID: 67295
		internal static int __PropertyOffset_9;

		// Token: 0x040106E0 RID: 67296
		internal static int __PropertyOffset_10;

		// Token: 0x040106E1 RID: 67297
		[Nullable(2)]
		private TMap<int, int> _ArraySpawnerHandles;

		// Token: 0x040106E2 RID: 67298
		internal static int __PropertyOffset_11;

		// Token: 0x040106E3 RID: 67299
		[Nullable(2)]
		private TMap<int, int> _RandomSpawnerHandles;

		// Token: 0x040106E4 RID: 67300
		internal static int __PropertyOffset_12;

		// Token: 0x040106E5 RID: 67301
		internal static int __PropertyOffset_13;

		// Token: 0x040106E6 RID: 67302
		internal static int __PropertyOffset_14;

		// Token: 0x040106E7 RID: 67303
		internal static int __PropertyOffset_15;

		// Token: 0x040106E8 RID: 67304
		internal static int __PropertyOffset_16;

		// Token: 0x040106E9 RID: 67305
		internal static int __PropertyOffset_17;

		// Token: 0x040106EA RID: 67306
		internal static int __PropertyOffset_18;

		// Token: 0x040106EB RID: 67307
		internal static int __PropertyOffset_19;

		// Token: 0x040106EC RID: 67308
		internal static int __PropertyOffset_20;

		// Token: 0x040106ED RID: 67309
		internal static int __PropertyOffset_21;

		// Token: 0x040106EE RID: 67310
		internal static int __PropertyOffset_22;

		// Token: 0x040106EF RID: 67311
		internal static int __PropertyOffset_23;

		// Token: 0x040106F0 RID: 67312
		internal static int __PropertyOffset_24;

		// Token: 0x040106F1 RID: 67313
		internal static int __PropertyOffset_25;

		// Token: 0x040106F2 RID: 67314
		internal static int __PropertyOffset_26;

		// Token: 0x040106F3 RID: 67315
		internal static int __PropertyOffset_27;

		// Token: 0x040106F4 RID: 67316
		internal static int __PropertyOffset_28;

		// Token: 0x040106F5 RID: 67317
		internal static int __PropertyOffset_29;

		// Token: 0x040106F6 RID: 67318
		internal static int __PropertyOffset_30;

		// Token: 0x040106F7 RID: 67319
		internal static int __PropertyOffset_31;

		// Token: 0x040106F8 RID: 67320
		internal static int __PropertyOffset_32;

		// Token: 0x040106F9 RID: 67321
		private static IntPtr __DeactivateRain_NativeFunctionPtr;

		// Token: 0x040106FA RID: 67322
		private static IntPtr __StopRain_NativeFunctionPtr;

		// Token: 0x040106FB RID: 67323
		private static IntPtr __Start_Rain_NativeFunctionPtr;

		// Token: 0x040106FC RID: 67324
		private static IntPtr __PreSolveRainParticles_NativeFunctionPtr;

		// Token: 0x040106FD RID: 67325
		private static IntPtr __SetupRainEmitters_NativeFunctionPtr;

		// Token: 0x040106FE RID: 67326
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x040106FF RID: 67327
		private static IntPtr __ExecuteUbergraph_BP_RainComponent_CommonReverse_NativeFunctionPtr;

		// Token: 0x02009A2A RID: 39466
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __PreSolveRainParticles_FunctionParams
		{
			// Token: 0x04032121 RID: 205089
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A2B RID: 39467
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04032122 RID: 205090
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009A2C RID: 39468
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 752)]
		protected ref struct __ExecuteUbergraph_BP_RainComponent_CommonReverse_FunctionParams
		{
			// Token: 0x04032123 RID: 205091
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
