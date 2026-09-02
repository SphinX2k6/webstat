using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.SwingInteraction
{
	// Token: 0x02003A3F RID: 14911
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/SwingInteraction/BP_Crane.BP_Crane_C")]
	[UnrealStructLayout(1560, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1556)]
	public class BP_Crane_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EC38 RID: 126008 RVA: 0x008FDF5E File Offset: 0x008FC15E
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Crane_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/SwingInteraction/BP_Crane.BP_Crane_C");
			}
			return BP_Crane_C._ClassPtr;
		}

		// Token: 0x0601EC39 RID: 126009 RVA: 0x008FDF84 File Offset: 0x008FC184
		public BP_Crane_C() : this(BuiltinUtils.AllocNativeUObject(BP_Crane_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EC3A RID: 126010 RVA: 0x008FDFAC File Offset: 0x008FC1AC
		[NullableContext(1)]
		public BP_Crane_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Crane_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002C44 RID: 11332
		// (get) Token: 0x0601EC3B RID: 126011 RVA: 0x008FDFE0 File Offset: 0x008FC1E0
		// (set) Token: 0x0601EC3C RID: 126012 RVA: 0x008FE019 File Offset: 0x008FC219
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002C45 RID: 11333
		// (get) Token: 0x0601EC3D RID: 126013 RVA: 0x008FE03A File Offset: 0x008FC23A
		// (set) Token: 0x0601EC3E RID: 126014 RVA: 0x008FE04E File Offset: 0x008FC24E
		public unsafe UStaticMeshComponent SM_Hook
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Crane_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Crane_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002C46 RID: 11334
		// (get) Token: 0x0601EC3F RID: 126015 RVA: 0x008FE063 File Offset: 0x008FC263
		// (set) Token: 0x0601EC40 RID: 126016 RVA: 0x008FE077 File Offset: 0x008FC277
		public unsafe UStaticMeshComponent SM_SwingSingleRopeR
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Crane_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Crane_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002C47 RID: 11335
		// (get) Token: 0x0601EC41 RID: 126017 RVA: 0x008FE08C File Offset: 0x008FC28C
		// (set) Token: 0x0601EC42 RID: 126018 RVA: 0x008FE0A0 File Offset: 0x008FC2A0
		public unsafe UStaticMeshComponent SM_SwingSingleRopeL
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Crane_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Crane_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002C48 RID: 11336
		// (get) Token: 0x0601EC43 RID: 126019 RVA: 0x008FE0B5 File Offset: 0x008FC2B5
		// (set) Token: 0x0601EC44 RID: 126020 RVA: 0x008FE0C9 File Offset: 0x008FC2C9
		public unsafe UStaticMeshComponent SM_SwingTop
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Crane_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Crane_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002C49 RID: 11337
		// (get) Token: 0x0601EC45 RID: 126021 RVA: 0x008FE0DE File Offset: 0x008FC2DE
		// (set) Token: 0x0601EC46 RID: 126022 RVA: 0x008FE0F2 File Offset: 0x008FC2F2
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Crane_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Crane_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17002C4A RID: 11338
		// (get) Token: 0x0601EC47 RID: 126023 RVA: 0x008FE108 File Offset: 0x008FC308
		// (set) Token: 0x0601EC48 RID: 126024 RVA: 0x008FE141 File Offset: 0x008FC341
		[Nullable(1)]
		public TArray<FName> NameList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._NameList) == null)
				{
					result = (this._NameList = new TArray<FName>(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.NameList.CopyAssign(value);
			}
		}

		// Token: 0x17002C4B RID: 11339
		// (get) Token: 0x0601EC49 RID: 126025 RVA: 0x008FE14F File Offset: 0x008FC34F
		// (set) Token: 0x0601EC4A RID: 126026 RVA: 0x008FE15F File Offset: 0x008FC35F
		public unsafe bool debugDraw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002C4C RID: 11340
		// (get) Token: 0x0601EC4B RID: 126027 RVA: 0x008FE170 File Offset: 0x008FC370
		// (set) Token: 0x0601EC4C RID: 126028 RVA: 0x008FE180 File Offset: 0x008FC380
		public unsafe bool bUseConstantDt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002C4D RID: 11341
		// (get) Token: 0x0601EC4D RID: 126029 RVA: 0x008FE191 File Offset: 0x008FC391
		// (set) Token: 0x0601EC4E RID: 126030 RVA: 0x008FE1A1 File Offset: 0x008FC3A1
		public unsafe float ConstantDt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002C4E RID: 11342
		// (get) Token: 0x0601EC4F RID: 126031 RVA: 0x008FE1B2 File Offset: 0x008FC3B2
		// (set) Token: 0x0601EC50 RID: 126032 RVA: 0x008FE1C6 File Offset: 0x008FC3C6
		public unsafe FVector StartOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002C4F RID: 11343
		// (get) Token: 0x0601EC51 RID: 126033 RVA: 0x008FE1DB File Offset: 0x008FC3DB
		// (set) Token: 0x0601EC52 RID: 126034 RVA: 0x008FE1EB File Offset: 0x008FC3EB
		public unsafe int particleCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17002C50 RID: 11344
		// (get) Token: 0x0601EC53 RID: 126035 RVA: 0x008FE1FC File Offset: 0x008FC3FC
		// (set) Token: 0x0601EC54 RID: 126036 RVA: 0x008FE20C File Offset: 0x008FC40C
		public unsafe float linkDis
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17002C51 RID: 11345
		// (get) Token: 0x0601EC55 RID: 126037 RVA: 0x008FE21D File Offset: 0x008FC41D
		// (set) Token: 0x0601EC56 RID: 126038 RVA: 0x008FE231 File Offset: 0x008FC431
		public unsafe FVector accel_ext
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17002C52 RID: 11346
		// (get) Token: 0x0601EC57 RID: 126039 RVA: 0x008FE246 File Offset: 0x008FC446
		// (set) Token: 0x0601EC58 RID: 126040 RVA: 0x008FE256 File Offset: 0x008FC456
		public unsafe float collisionR
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17002C53 RID: 11347
		// (get) Token: 0x0601EC59 RID: 126041 RVA: 0x008FE267 File Offset: 0x008FC467
		// (set) Token: 0x0601EC5A RID: 126042 RVA: 0x008FE277 File Offset: 0x008FC477
		public unsafe float volDamping
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17002C54 RID: 11348
		// (get) Token: 0x0601EC5B RID: 126043 RVA: 0x008FE288 File Offset: 0x008FC488
		// (set) Token: 0x0601EC5C RID: 126044 RVA: 0x008FE29C File Offset: 0x008FC49C
		public unsafe FVector startPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17002C55 RID: 11349
		// (get) Token: 0x0601EC5D RID: 126045 RVA: 0x008FE2B1 File Offset: 0x008FC4B1
		// (set) Token: 0x0601EC5E RID: 126046 RVA: 0x008FE2C5 File Offset: 0x008FC4C5
		public unsafe FVector endPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17002C56 RID: 11350
		// (get) Token: 0x0601EC5F RID: 126047 RVA: 0x008FE2DA File Offset: 0x008FC4DA
		// (set) Token: 0x0601EC60 RID: 126048 RVA: 0x008FE2EE File Offset: 0x008FC4EE
		public unsafe FVector leftPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17002C57 RID: 11351
		// (get) Token: 0x0601EC61 RID: 126049 RVA: 0x008FE303 File Offset: 0x008FC503
		// (set) Token: 0x0601EC62 RID: 126050 RVA: 0x008FE317 File Offset: 0x008FC517
		public unsafe FVector rightPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17002C58 RID: 11352
		// (get) Token: 0x0601EC63 RID: 126051 RVA: 0x008FE32C File Offset: 0x008FC52C
		// (set) Token: 0x0601EC64 RID: 126052 RVA: 0x008FE340 File Offset: 0x008FC540
		public unsafe FVector leftNorm
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17002C59 RID: 11353
		// (get) Token: 0x0601EC65 RID: 126053 RVA: 0x008FE358 File Offset: 0x008FC558
		// (set) Token: 0x0601EC66 RID: 126054 RVA: 0x008FE391 File Offset: 0x008FC591
		[Nullable(1)]
		public TArray<FParticle_QiuQian> particleArr
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FParticle_QiuQian> result;
				if ((result = this._particleArr) == null)
				{
					result = (this._particleArr = new TArray<FParticle_QiuQian>(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_21, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.particleArr.CopyAssign(value);
			}
		}

		// Token: 0x17002C5A RID: 11354
		// (get) Token: 0x0601EC67 RID: 126055 RVA: 0x008FE39F File Offset: 0x008FC59F
		// (set) Token: 0x0601EC68 RID: 126056 RVA: 0x008FE3B3 File Offset: 0x008FC5B3
		public unsafe FVector rightNorm
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17002C5B RID: 11355
		// (get) Token: 0x0601EC69 RID: 126057 RVA: 0x008FE3C8 File Offset: 0x008FC5C8
		// (set) Token: 0x0601EC6A RID: 126058 RVA: 0x008FE3D8 File Offset: 0x008FC5D8
		public unsafe float pushStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17002C5C RID: 11356
		// (get) Token: 0x0601EC6B RID: 126059 RVA: 0x008FE3E9 File Offset: 0x008FC5E9
		// (set) Token: 0x0601EC6C RID: 126060 RVA: 0x008FE3F9 File Offset: 0x008FC5F9
		public unsafe float endParticleMassScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17002C5D RID: 11357
		// (get) Token: 0x0601EC6D RID: 126061 RVA: 0x008FE40A File Offset: 0x008FC60A
		// (set) Token: 0x0601EC6E RID: 126062 RVA: 0x008FE41A File Offset: 0x008FC61A
		public unsafe float debugDrawDuration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17002C5E RID: 11358
		// (get) Token: 0x0601EC6F RID: 126063 RVA: 0x008FE42B File Offset: 0x008FC62B
		// (set) Token: 0x0601EC70 RID: 126064 RVA: 0x008FE43B File Offset: 0x008FC63B
		public unsafe bool IsEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_26) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_26) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002C5F RID: 11359
		// (get) Token: 0x0601EC71 RID: 126065 RVA: 0x008FE44C File Offset: 0x008FC64C
		// (set) Token: 0x0601EC72 RID: 126066 RVA: 0x008FE45C File Offset: 0x008FC65C
		public unsafe bool IsPC
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002C60 RID: 11360
		// (get) Token: 0x0601EC73 RID: 126067 RVA: 0x008FE46D File Offset: 0x008FC66D
		// (set) Token: 0x0601EC74 RID: 126068 RVA: 0x008FE481 File Offset: 0x008FC681
		public unsafe UMaterialInstanceDynamic DMI_RopeL
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Crane_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Crane_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x17002C61 RID: 11361
		// (get) Token: 0x0601EC75 RID: 126069 RVA: 0x008FE496 File Offset: 0x008FC696
		// (set) Token: 0x0601EC76 RID: 126070 RVA: 0x008FE4AA File Offset: 0x008FC6AA
		public unsafe UMaterialInstanceDynamic DMI_RopeR
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Crane_C.__PropertyOffset_29);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Crane_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x17002C62 RID: 11362
		// (get) Token: 0x0601EC77 RID: 126071 RVA: 0x008FE4BF File Offset: 0x008FC6BF
		// (set) Token: 0x0601EC78 RID: 126072 RVA: 0x008FE4CF File Offset: 0x008FC6CF
		public unsafe float MaxDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17002C63 RID: 11363
		// (get) Token: 0x0601EC79 RID: 126073 RVA: 0x008FE4E0 File Offset: 0x008FC6E0
		// (set) Token: 0x0601EC7A RID: 126074 RVA: 0x008FE4F0 File Offset: 0x008FC6F0
		public unsafe bool IsWarm
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_31) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_31) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002C64 RID: 11364
		// (get) Token: 0x0601EC7B RID: 126075 RVA: 0x008FE501 File Offset: 0x008FC701
		// (set) Token: 0x0601EC7C RID: 126076 RVA: 0x008FE511 File Offset: 0x008FC711
		public unsafe float WarmTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Crane_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x0601EC7D RID: 126077 RVA: 0x008FE522 File Offset: 0x008FC722
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitializeParticleArr()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Crane_C.__InitializeParticleArr_NativeFunctionPtr, null);
		}

		// Token: 0x0601EC7E RID: 126078 RVA: 0x008FE538 File Offset: 0x008FC738
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetDMIOffsetEnable(bool OffsetEnable)
		{
			BP_Crane_C.__SetDMIOffsetEnable_FunctionParams* ptr = stackalloc BP_Crane_C.__SetDMIOffsetEnable_FunctionParams[(UIntPtr)20] + 15L / (long)sizeof(BP_Crane_C.__SetDMIOffsetEnable_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Crane_C.__SetDMIOffsetEnable_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OffsetEnable = OffsetEnable;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Crane_C.__SetDMIOffsetEnable_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EC7F RID: 126079 RVA: 0x008FE57E File Offset: 0x008FC77E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateaDMI()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Crane_C.__UpdateaDMI_NativeFunctionPtr, null);
		}

		// Token: 0x0601EC80 RID: 126080 RVA: 0x008FE592 File Offset: 0x008FC792
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitializeDMI()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Crane_C.__InitializeDMI_NativeFunctionPtr, null);
		}

		// Token: 0x0601EC81 RID: 126081 RVA: 0x008FE5A8 File Offset: 0x008FC7A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void solve(bool isPinned, FVector pos, FVector linkPos, float targetLen, FVector emitterOriginPos, ref FVector pos_new)
		{
			BP_Crane_C.__solve_FunctionParams* ptr = stackalloc BP_Crane_C.__solve_FunctionParams[(UIntPtr)131] + 15L / (long)sizeof(BP_Crane_C.__solve_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Crane_C.__solve_NativeFunctionPtr, (void*)ptr, 1);
			ptr->isPinned = isPinned;
			ptr->pos = pos;
			ptr->linkPos = linkPos;
			ptr->targetLen = targetLen;
			ptr->emitterOriginPos = emitterOriginPos;
			ptr->pos_new = pos_new;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Crane_C.__solve_NativeFunctionPtr, (void*)ptr);
			pos_new = ptr->pos_new;
		}

		// Token: 0x0601EC82 RID: 126082 RVA: 0x008FE629 File Offset: 0x008FC829
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Crane_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601EC83 RID: 126083 RVA: 0x008FE63D File Offset: 0x008FC83D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Crane_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EC84 RID: 126084 RVA: 0x008FE652 File Offset: 0x008FC852
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Crane_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601EC85 RID: 126085 RVA: 0x008FE666 File Offset: 0x008FC866
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Crane_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EC86 RID: 126086 RVA: 0x008FE67C File Offset: 0x008FC87C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Crane_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Crane_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Crane_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Crane_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Crane_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EC87 RID: 126087 RVA: 0x008FE6C4 File Offset: 0x008FC8C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Crane_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Crane_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Crane_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Crane_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Crane_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EC88 RID: 126088 RVA: 0x008FE70B File Offset: 0x008FC90B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void place_plank_event()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Crane_C.__place_plank_event_NativeFunctionPtr, null);
		}

		// Token: 0x0601EC89 RID: 126089 RVA: 0x008FE71F File Offset: 0x008FC91F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicEnable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Crane_C.__OnLogicEnable_NativeFunctionPtr, null);
		}

		// Token: 0x0601EC8A RID: 126090 RVA: 0x008FE733 File Offset: 0x008FC933
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicEnable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Crane_C.__OnLogicEnable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EC8B RID: 126091 RVA: 0x008FE748 File Offset: 0x008FC948
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicDisable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Crane_C.__OnLogicDisable_NativeFunctionPtr, null);
		}

		// Token: 0x0601EC8C RID: 126092 RVA: 0x008FE75C File Offset: 0x008FC95C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicDisable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Crane_C.__OnLogicDisable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EC8D RID: 126093 RVA: 0x008FE774 File Offset: 0x008FC974
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Crane(int EntryPoint)
		{
			BP_Crane_C.__ExecuteUbergraph_BP_Crane_FunctionParams* ptr = stackalloc BP_Crane_C.__ExecuteUbergraph_BP_Crane_FunctionParams[(UIntPtr)1839] + 15L / (long)sizeof(BP_Crane_C.__ExecuteUbergraph_BP_Crane_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Crane_C.__ExecuteUbergraph_BP_Crane_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Crane_C.__ExecuteUbergraph_BP_Crane_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EC8E RID: 126094 RVA: 0x008FE7BE File Offset: 0x008FC9BE
		protected BP_Crane_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F2FF RID: 62207
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/SwingInteraction/BP_Crane.BP_Crane_C";

		// Token: 0x0400F300 RID: 62208
		private static IntPtr _ClassPtr;

		// Token: 0x0400F301 RID: 62209
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F302 RID: 62210
		internal static int __PropertyOffset_0;

		// Token: 0x0400F303 RID: 62211
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F304 RID: 62212
		internal static int __PropertyOffset_1;

		// Token: 0x0400F305 RID: 62213
		internal static int __PropertyOffset_2;

		// Token: 0x0400F306 RID: 62214
		internal static int __PropertyOffset_3;

		// Token: 0x0400F307 RID: 62215
		internal static int __PropertyOffset_4;

		// Token: 0x0400F308 RID: 62216
		internal static int __PropertyOffset_5;

		// Token: 0x0400F309 RID: 62217
		internal static int __PropertyOffset_6;

		// Token: 0x0400F30A RID: 62218
		private TArray<FName> _NameList;

		// Token: 0x0400F30B RID: 62219
		internal static int __PropertyOffset_7;

		// Token: 0x0400F30C RID: 62220
		internal static int __PropertyOffset_8;

		// Token: 0x0400F30D RID: 62221
		internal static int __PropertyOffset_9;

		// Token: 0x0400F30E RID: 62222
		internal static int __PropertyOffset_10;

		// Token: 0x0400F30F RID: 62223
		internal static int __PropertyOffset_11;

		// Token: 0x0400F310 RID: 62224
		internal static int __PropertyOffset_12;

		// Token: 0x0400F311 RID: 62225
		internal static int __PropertyOffset_13;

		// Token: 0x0400F312 RID: 62226
		internal static int __PropertyOffset_14;

		// Token: 0x0400F313 RID: 62227
		internal static int __PropertyOffset_15;

		// Token: 0x0400F314 RID: 62228
		internal static int __PropertyOffset_16;

		// Token: 0x0400F315 RID: 62229
		internal static int __PropertyOffset_17;

		// Token: 0x0400F316 RID: 62230
		internal static int __PropertyOffset_18;

		// Token: 0x0400F317 RID: 62231
		internal static int __PropertyOffset_19;

		// Token: 0x0400F318 RID: 62232
		internal static int __PropertyOffset_20;

		// Token: 0x0400F319 RID: 62233
		internal static int __PropertyOffset_21;

		// Token: 0x0400F31A RID: 62234
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FParticle_QiuQian> _particleArr;

		// Token: 0x0400F31B RID: 62235
		internal static int __PropertyOffset_22;

		// Token: 0x0400F31C RID: 62236
		internal static int __PropertyOffset_23;

		// Token: 0x0400F31D RID: 62237
		internal static int __PropertyOffset_24;

		// Token: 0x0400F31E RID: 62238
		internal static int __PropertyOffset_25;

		// Token: 0x0400F31F RID: 62239
		internal static int __PropertyOffset_26;

		// Token: 0x0400F320 RID: 62240
		internal static int __PropertyOffset_27;

		// Token: 0x0400F321 RID: 62241
		internal static int __PropertyOffset_28;

		// Token: 0x0400F322 RID: 62242
		internal static int __PropertyOffset_29;

		// Token: 0x0400F323 RID: 62243
		internal static int __PropertyOffset_30;

		// Token: 0x0400F324 RID: 62244
		internal static int __PropertyOffset_31;

		// Token: 0x0400F325 RID: 62245
		internal static int __PropertyOffset_32;

		// Token: 0x0400F326 RID: 62246
		private static IntPtr __InitializeParticleArr_NativeFunctionPtr;

		// Token: 0x0400F327 RID: 62247
		private static IntPtr __SetDMIOffsetEnable_NativeFunctionPtr;

		// Token: 0x0400F328 RID: 62248
		private static IntPtr __UpdateaDMI_NativeFunctionPtr;

		// Token: 0x0400F329 RID: 62249
		private static IntPtr __InitializeDMI_NativeFunctionPtr;

		// Token: 0x0400F32A RID: 62250
		private static IntPtr __solve_NativeFunctionPtr;

		// Token: 0x0400F32B RID: 62251
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F32C RID: 62252
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F32D RID: 62253
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F32E RID: 62254
		private static IntPtr __place_plank_event_NativeFunctionPtr;

		// Token: 0x0400F32F RID: 62255
		private static IntPtr __OnLogicEnable_NativeFunctionPtr;

		// Token: 0x0400F330 RID: 62256
		private static IntPtr __OnLogicDisable_NativeFunctionPtr;

		// Token: 0x0400F331 RID: 62257
		private static IntPtr __ExecuteUbergraph_BP_Crane_NativeFunctionPtr;

		// Token: 0x020097FF RID: 38911
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 5)]
		protected ref struct __SetDMIOffsetEnable_FunctionParams
		{
			// Token: 0x04031DF4 RID: 204276
			[FieldOffset(0)]
			public bool OffsetEnable;
		}

		// Token: 0x02009800 RID: 38912
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 116)]
		protected ref struct __solve_FunctionParams
		{
			// Token: 0x04031DF5 RID: 204277
			[FieldOffset(0)]
			public bool isPinned;

			// Token: 0x04031DF6 RID: 204278
			[FieldOffset(4)]
			public FVector pos;

			// Token: 0x04031DF7 RID: 204279
			[FieldOffset(16)]
			public FVector linkPos;

			// Token: 0x04031DF8 RID: 204280
			[FieldOffset(28)]
			public float targetLen;

			// Token: 0x04031DF9 RID: 204281
			[FieldOffset(32)]
			public FVector emitterOriginPos;

			// Token: 0x04031DFA RID: 204282
			[FieldOffset(44)]
			public FVector pos_new;
		}

		// Token: 0x02009801 RID: 38913
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031DFB RID: 204283
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009802 RID: 38914
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1824)]
		protected ref struct __ExecuteUbergraph_BP_Crane_FunctionParams
		{
			// Token: 0x04031DFC RID: 204284
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
