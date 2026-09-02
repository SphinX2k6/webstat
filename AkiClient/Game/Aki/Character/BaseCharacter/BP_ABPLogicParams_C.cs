using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041C4 RID: 16836
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/BP_ABPLogicParams.BP_ABPLogicParams_C")]
	[UnrealStructLayout(368, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 361)]
	public class BP_ABPLogicParams_C : UObject, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CBB4 RID: 183220 RVA: 0x00AAE148 File Offset: 0x00AAC348
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ABPLogicParams_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/BP_ABPLogicParams.BP_ABPLogicParams_C");
			}
			return BP_ABPLogicParams_C._ClassPtr;
		}

		// Token: 0x0602CBB5 RID: 183221 RVA: 0x00AAE16C File Offset: 0x00AAC36C
		public BP_ABPLogicParams_C() : this(BuiltinUtils.AllocNativeUObject(BP_ABPLogicParams_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CBB6 RID: 183222 RVA: 0x00AAE194 File Offset: 0x00AAC394
		[NullableContext(1)]
		public BP_ABPLogicParams_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ABPLogicParams_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170078AB RID: 30891
		// (get) Token: 0x0602CBB7 RID: 183223 RVA: 0x00AAE1C7 File Offset: 0x00AAC3C7
		// (set) Token: 0x0602CBB8 RID: 183224 RVA: 0x00AAE1D7 File Offset: 0x00AAC3D7
		public unsafe bool AcceptedNewBeHitRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078AC RID: 30892
		// (get) Token: 0x0602CBB9 RID: 183225 RVA: 0x00AAE1E8 File Offset: 0x00AAC3E8
		// (set) Token: 0x0602CBBA RID: 183226 RVA: 0x00AAE1FC File Offset: 0x00AAC3FC
		public unsafe TEnumAsByte<EHitAnim> BeHitAnimRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170078AD RID: 30893
		// (get) Token: 0x0602CBBB RID: 183227 RVA: 0x00AAE211 File Offset: 0x00AAC411
		// (set) Token: 0x0602CBBC RID: 183228 RVA: 0x00AAE221 File Offset: 0x00AAC421
		public unsafe bool EnterFkRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078AE RID: 30894
		// (get) Token: 0x0602CBBD RID: 183229 RVA: 0x00AAE232 File Offset: 0x00AAC432
		// (set) Token: 0x0602CBBE RID: 183230 RVA: 0x00AAE242 File Offset: 0x00AAC442
		public unsafe bool DoubleHitInAirRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078AF RID: 30895
		// (get) Token: 0x0602CBBF RID: 183231 RVA: 0x00AAE253 File Offset: 0x00AAC453
		// (set) Token: 0x0602CBC0 RID: 183232 RVA: 0x00AAE267 File Offset: 0x00AAC467
		public unsafe FVector BeHitDirectRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170078B0 RID: 30896
		// (get) Token: 0x0602CBC1 RID: 183233 RVA: 0x00AAE27C File Offset: 0x00AAC47C
		// (set) Token: 0x0602CBC2 RID: 183234 RVA: 0x00AAE290 File Offset: 0x00AAC490
		public unsafe FVector BeHitLocationRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170078B1 RID: 30897
		// (get) Token: 0x0602CBC3 RID: 183235 RVA: 0x00AAE2A5 File Offset: 0x00AAC4A5
		// (set) Token: 0x0602CBC4 RID: 183236 RVA: 0x00AAE2B9 File Offset: 0x00AAC4B9
		public unsafe TEnumAsByte<ECharState> CharMoveStateRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170078B2 RID: 30898
		// (get) Token: 0x0602CBC5 RID: 183237 RVA: 0x00AAE2CE File Offset: 0x00AAC4CE
		// (set) Token: 0x0602CBC6 RID: 183238 RVA: 0x00AAE2E2 File Offset: 0x00AAC4E2
		public unsafe TEnumAsByte<ECharParentMoveState> CharPositionStateRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170078B3 RID: 30899
		// (get) Token: 0x0602CBC7 RID: 183239 RVA: 0x00AAE2F7 File Offset: 0x00AAC4F7
		// (set) Token: 0x0602CBC8 RID: 183240 RVA: 0x00AAE30B File Offset: 0x00AAC50B
		public unsafe TEnumAsByte<ECharViewDirectionState> CharCameraStateRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170078B4 RID: 30900
		// (get) Token: 0x0602CBC9 RID: 183241 RVA: 0x00AAE320 File Offset: 0x00AAC520
		// (set) Token: 0x0602CBCA RID: 183242 RVA: 0x00AAE330 File Offset: 0x00AAC530
		public unsafe float BattleIdleTimeRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170078B5 RID: 30901
		// (get) Token: 0x0602CBCB RID: 183243 RVA: 0x00AAE341 File Offset: 0x00AAC541
		// (set) Token: 0x0602CBCC RID: 183244 RVA: 0x00AAE351 File Offset: 0x00AAC551
		public unsafe float DegMovementSlopeRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170078B6 RID: 30902
		// (get) Token: 0x0602CBCD RID: 183245 RVA: 0x00AAE362 File Offset: 0x00AAC562
		// (set) Token: 0x0602CBCE RID: 183246 RVA: 0x00AAE376 File Offset: 0x00AAC576
		public unsafe FVector SightDirectRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170078B7 RID: 30903
		// (get) Token: 0x0602CBCF RID: 183247 RVA: 0x00AAE38B File Offset: 0x00AAC58B
		// (set) Token: 0x0602CBD0 RID: 183248 RVA: 0x00AAE39B File Offset: 0x00AAC59B
		public unsafe bool RagQuitStateRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078B8 RID: 30904
		// (get) Token: 0x0602CBD1 RID: 183249 RVA: 0x00AAE3AC File Offset: 0x00AAC5AC
		// (set) Token: 0x0602CBD2 RID: 183250 RVA: 0x00AAE3BC File Offset: 0x00AAC5BC
		public unsafe bool IsJumpRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078B9 RID: 30905
		// (get) Token: 0x0602CBD3 RID: 183251 RVA: 0x00AAE3CD File Offset: 0x00AAC5CD
		// (set) Token: 0x0602CBD4 RID: 183252 RVA: 0x00AAE3E1 File Offset: 0x00AAC5E1
		public unsafe FVector AccelerationRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170078BA RID: 30906
		// (get) Token: 0x0602CBD5 RID: 183253 RVA: 0x00AAE3F6 File Offset: 0x00AAC5F6
		// (set) Token: 0x0602CBD6 RID: 183254 RVA: 0x00AAE406 File Offset: 0x00AAC606
		public unsafe bool IsMovingRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078BB RID: 30907
		// (get) Token: 0x0602CBD7 RID: 183255 RVA: 0x00AAE417 File Offset: 0x00AAC617
		// (set) Token: 0x0602CBD8 RID: 183256 RVA: 0x00AAE427 File Offset: 0x00AAC627
		public unsafe float SpeedRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170078BC RID: 30908
		// (get) Token: 0x0602CBD9 RID: 183257 RVA: 0x00AAE438 File Offset: 0x00AAC638
		// (set) Token: 0x0602CBDA RID: 183258 RVA: 0x00AAE44C File Offset: 0x00AAC64C
		public unsafe FVector InputDirectRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170078BD RID: 30909
		// (get) Token: 0x0602CBDB RID: 183259 RVA: 0x00AAE461 File Offset: 0x00AAC661
		// (set) Token: 0x0602CBDC RID: 183260 RVA: 0x00AAE471 File Offset: 0x00AAC671
		public unsafe bool IsFallingIntoWaterRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078BE RID: 30910
		// (get) Token: 0x0602CBDD RID: 183261 RVA: 0x00AAE482 File Offset: 0x00AAC682
		// (set) Token: 0x0602CBDE RID: 183262 RVA: 0x00AAE492 File Offset: 0x00AAC692
		public unsafe float GroundedTimeRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170078BF RID: 30911
		// (get) Token: 0x0602CBDF RID: 183263 RVA: 0x00AAE4A3 File Offset: 0x00AAC6A3
		// (set) Token: 0x0602CBE0 RID: 183264 RVA: 0x00AAE4B3 File Offset: 0x00AAC6B3
		public unsafe bool HasMoveInputRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078C0 RID: 30912
		// (get) Token: 0x0602CBE1 RID: 183265 RVA: 0x00AAE4C4 File Offset: 0x00AAC6C4
		// (set) Token: 0x0602CBE2 RID: 183266 RVA: 0x00AAE4D8 File Offset: 0x00AAC6D8
		public unsafe SClimbInfo ClimbInfoRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x170078C1 RID: 30913
		// (get) Token: 0x0602CBE3 RID: 183267 RVA: 0x00AAE4ED File Offset: 0x00AAC6ED
		// (set) Token: 0x0602CBE4 RID: 183268 RVA: 0x00AAE501 File Offset: 0x00AAC701
		public unsafe SClimbState ClimbStateRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x170078C2 RID: 30914
		// (get) Token: 0x0602CBE5 RID: 183269 RVA: 0x00AAE516 File Offset: 0x00AAC716
		// (set) Token: 0x0602CBE6 RID: 183270 RVA: 0x00AAE526 File Offset: 0x00AAC726
		public unsafe float ClimbRadiusRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x170078C3 RID: 30915
		// (get) Token: 0x0602CBE7 RID: 183271 RVA: 0x00AAE537 File Offset: 0x00AAC737
		// (set) Token: 0x0602CBE8 RID: 183272 RVA: 0x00AAE54B File Offset: 0x00AAC74B
		public unsafe FRotator InputRotatorRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x170078C4 RID: 30916
		// (get) Token: 0x0602CBE9 RID: 183273 RVA: 0x00AAE560 File Offset: 0x00AAC760
		// (set) Token: 0x0602CBEA RID: 183274 RVA: 0x00AAE570 File Offset: 0x00AAC770
		public unsafe float ClimbOnWallAngleRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x170078C5 RID: 30917
		// (get) Token: 0x0602CBEB RID: 183275 RVA: 0x00AAE581 File Offset: 0x00AAC781
		// (set) Token: 0x0602CBEC RID: 183276 RVA: 0x00AAE591 File Offset: 0x00AAC791
		public unsafe float SprintSwimOffsetRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x170078C6 RID: 30918
		// (get) Token: 0x0602CBED RID: 183277 RVA: 0x00AAE5A2 File Offset: 0x00AAC7A2
		// (set) Token: 0x0602CBEE RID: 183278 RVA: 0x00AAE5B2 File Offset: 0x00AAC7B2
		public unsafe float SprintSwimOffsetLerpSpeedRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x170078C7 RID: 30919
		// (get) Token: 0x0602CBEF RID: 183279 RVA: 0x00AAE5C3 File Offset: 0x00AAC7C3
		// (set) Token: 0x0602CBF0 RID: 183280 RVA: 0x00AAE5D7 File Offset: 0x00AAC7D7
		public unsafe FVector SlideForwardRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x170078C8 RID: 30920
		// (get) Token: 0x0602CBF1 RID: 183281 RVA: 0x00AAE5EC File Offset: 0x00AAC7EC
		// (set) Token: 0x0602CBF2 RID: 183282 RVA: 0x00AAE5FC File Offset: 0x00AAC7FC
		public unsafe bool SlideSwitchThisFrameRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_29) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_29) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078C9 RID: 30921
		// (get) Token: 0x0602CBF3 RID: 183283 RVA: 0x00AAE60D File Offset: 0x00AAC80D
		// (set) Token: 0x0602CBF4 RID: 183284 RVA: 0x00AAE61D File Offset: 0x00AAC81D
		public unsafe bool SlideStandModeRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_30) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_30) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078CA RID: 30922
		// (get) Token: 0x0602CBF5 RID: 183285 RVA: 0x00AAE62E File Offset: 0x00AAC82E
		// (set) Token: 0x0602CBF6 RID: 183286 RVA: 0x00AAE63E File Offset: 0x00AAC83E
		public unsafe float JumpUpRateRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x170078CB RID: 30923
		// (get) Token: 0x0602CBF7 RID: 183287 RVA: 0x00AAE64F File Offset: 0x00AAC84F
		// (set) Token: 0x0602CBF8 RID: 183288 RVA: 0x00AAE663 File Offset: 0x00AAC863
		public unsafe FVector2D LookAtRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x170078CC RID: 30924
		// (get) Token: 0x0602CBF9 RID: 183289 RVA: 0x00AAE678 File Offset: 0x00AAC878
		// (set) Token: 0x0602CBFA RID: 183290 RVA: 0x00AAE688 File Offset: 0x00AAC888
		public unsafe bool EnableBlendSpaceLookAtRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_33) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_33) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078CD RID: 30925
		// (get) Token: 0x0602CBFB RID: 183291 RVA: 0x00AAE699 File Offset: 0x00AAC899
		// (set) Token: 0x0602CBFC RID: 183292 RVA: 0x00AAE6A9 File Offset: 0x00AAC8A9
		public unsafe bool IsDriver
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_34) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_34) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078CE RID: 30926
		// (get) Token: 0x0602CBFD RID: 183293 RVA: 0x00AAE6BA File Offset: 0x00AAC8BA
		// (set) Token: 0x0602CBFE RID: 183294 RVA: 0x00AAE6CA File Offset: 0x00AAC8CA
		public unsafe bool IsOnVehicle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_35) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_35) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078CF RID: 30927
		// (get) Token: 0x0602CBFF RID: 183295 RVA: 0x00AAE6DC File Offset: 0x00AAC8DC
		// (set) Token: 0x0602CC00 RID: 183296 RVA: 0x00AAE715 File Offset: 0x00AAC915
		[Nullable(1)]
		public FIKTarget LeftHandIKTargetCS
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FIKTarget result;
				if ((result = this._LeftHandIKTargetCS) == null)
				{
					result = (this._LeftHandIKTargetCS = new FIKTarget(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_36, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FIKTarget.StaticStruct(), base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_36, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170078D0 RID: 30928
		// (get) Token: 0x0602CC01 RID: 183297 RVA: 0x00AAE738 File Offset: 0x00AAC938
		// (set) Token: 0x0602CC02 RID: 183298 RVA: 0x00AAE771 File Offset: 0x00AAC971
		[Nullable(1)]
		public FIKTarget RightHandIKTargetCS
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FIKTarget result;
				if ((result = this._RightHandIKTargetCS) == null)
				{
					result = (this._RightHandIKTargetCS = new FIKTarget(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_37, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FIKTarget.StaticStruct(), base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_37, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170078D1 RID: 30929
		// (get) Token: 0x0602CC03 RID: 183299 RVA: 0x00AAE792 File Offset: 0x00AAC992
		// (set) Token: 0x0602CC04 RID: 183300 RVA: 0x00AAE7A2 File Offset: 0x00AAC9A2
		public unsafe bool StateLowerBlend
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_38) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_38) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078D2 RID: 30930
		// (get) Token: 0x0602CC05 RID: 183301 RVA: 0x00AAE7B3 File Offset: 0x00AAC9B3
		// (set) Token: 0x0602CC06 RID: 183302 RVA: 0x00AAE7C3 File Offset: 0x00AAC9C3
		public unsafe bool StateLeftArmBlend
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_39) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_39) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078D3 RID: 30931
		// (get) Token: 0x0602CC07 RID: 183303 RVA: 0x00AAE7D4 File Offset: 0x00AAC9D4
		// (set) Token: 0x0602CC08 RID: 183304 RVA: 0x00AAE7E4 File Offset: 0x00AAC9E4
		public unsafe bool StateRightArmBlend
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_40) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_40) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078D4 RID: 30932
		// (get) Token: 0x0602CC09 RID: 183305 RVA: 0x00AAE7F5 File Offset: 0x00AAC9F5
		// (set) Token: 0x0602CC0A RID: 183306 RVA: 0x00AAE805 File Offset: 0x00AACA05
		public unsafe bool IsHoldingHands
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_41) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_41) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078D5 RID: 30933
		// (get) Token: 0x0602CC0B RID: 183307 RVA: 0x00AAE816 File Offset: 0x00AACA16
		// (set) Token: 0x0602CC0C RID: 183308 RVA: 0x00AAE826 File Offset: 0x00AACA26
		public unsafe bool IsBeHoldingHands
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_42) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_42) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078D6 RID: 30934
		// (get) Token: 0x0602CC0D RID: 183309 RVA: 0x00AAE837 File Offset: 0x00AACA37
		// (set) Token: 0x0602CC0E RID: 183310 RVA: 0x00AAE847 File Offset: 0x00AACA47
		public unsafe bool IsHoldingHandsReachable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_43) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_43) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078D7 RID: 30935
		// (get) Token: 0x0602CC0F RID: 183311 RVA: 0x00AAE858 File Offset: 0x00AACA58
		// (set) Token: 0x0602CC10 RID: 183312 RVA: 0x00AAE868 File Offset: 0x00AACA68
		public unsafe bool IsAcceptingInvitation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_44) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_44) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078D8 RID: 30936
		// (get) Token: 0x0602CC11 RID: 183313 RVA: 0x00AAE879 File Offset: 0x00AACA79
		// (set) Token: 0x0602CC12 RID: 183314 RVA: 0x00AAE889 File Offset: 0x00AACA89
		public unsafe bool DisableBlinkRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_45) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_45) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078D9 RID: 30937
		// (get) Token: 0x0602CC13 RID: 183315 RVA: 0x00AAE89A File Offset: 0x00AACA9A
		// (set) Token: 0x0602CC14 RID: 183316 RVA: 0x00AAE8AA File Offset: 0x00AACAAA
		public unsafe bool IsOnVehicleWithOther
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_46) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_46) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078DA RID: 30938
		// (get) Token: 0x0602CC15 RID: 183317 RVA: 0x00AAE8BB File Offset: 0x00AACABB
		// (set) Token: 0x0602CC16 RID: 183318 RVA: 0x00AAE8CB File Offset: 0x00AACACB
		public unsafe int VehicleType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x170078DB RID: 30939
		// (get) Token: 0x0602CC17 RID: 183319 RVA: 0x00AAE8DC File Offset: 0x00AACADC
		// (set) Token: 0x0602CC18 RID: 183320 RVA: 0x00AAE8EC File Offset: 0x00AACAEC
		public unsafe bool IgnoreMontageBlinkCurve
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_48) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_48) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078DC RID: 30940
		// (get) Token: 0x0602CC19 RID: 183321 RVA: 0x00AAE8FD File Offset: 0x00AACAFD
		// (set) Token: 0x0602CC1A RID: 183322 RVA: 0x00AAE90D File Offset: 0x00AACB0D
		public unsafe bool IsRegionMoveModeRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_49) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_49) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078DD RID: 30941
		// (get) Token: 0x0602CC1B RID: 183323 RVA: 0x00AAE91E File Offset: 0x00AACB1E
		// (set) Token: 0x0602CC1C RID: 183324 RVA: 0x00AAE92E File Offset: 0x00AACB2E
		public unsafe bool DisableHumanIkRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_50) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_50) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078DE RID: 30942
		// (get) Token: 0x0602CC1D RID: 183325 RVA: 0x00AAE93F File Offset: 0x00AACB3F
		// (set) Token: 0x0602CC1E RID: 183326 RVA: 0x00AAE94F File Offset: 0x00AACB4F
		public unsafe float TurnYawRateRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x170078DF RID: 30943
		// (get) Token: 0x0602CC1F RID: 183327 RVA: 0x00AAE960 File Offset: 0x00AACB60
		// (set) Token: 0x0602CC20 RID: 183328 RVA: 0x00AAE970 File Offset: 0x00AACB70
		public unsafe bool EnableAdditiveTurnRef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_52) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ABPLogicParams_C.__PropertyOffset_52) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602CC21 RID: 183329 RVA: 0x00AAE981 File Offset: 0x00AACB81
		protected BP_ABPLogicParams_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018ECC RID: 102092
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/BP_ABPLogicParams.BP_ABPLogicParams_C";

		// Token: 0x04018ECD RID: 102093
		private static IntPtr _ClassPtr;

		// Token: 0x04018ECE RID: 102094
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018ECF RID: 102095
		internal static int __PropertyOffset_0;

		// Token: 0x04018ED0 RID: 102096
		internal static int __PropertyOffset_1;

		// Token: 0x04018ED1 RID: 102097
		internal static int __PropertyOffset_2;

		// Token: 0x04018ED2 RID: 102098
		internal static int __PropertyOffset_3;

		// Token: 0x04018ED3 RID: 102099
		internal static int __PropertyOffset_4;

		// Token: 0x04018ED4 RID: 102100
		internal static int __PropertyOffset_5;

		// Token: 0x04018ED5 RID: 102101
		internal static int __PropertyOffset_6;

		// Token: 0x04018ED6 RID: 102102
		internal static int __PropertyOffset_7;

		// Token: 0x04018ED7 RID: 102103
		internal static int __PropertyOffset_8;

		// Token: 0x04018ED8 RID: 102104
		internal static int __PropertyOffset_9;

		// Token: 0x04018ED9 RID: 102105
		internal static int __PropertyOffset_10;

		// Token: 0x04018EDA RID: 102106
		internal static int __PropertyOffset_11;

		// Token: 0x04018EDB RID: 102107
		internal static int __PropertyOffset_12;

		// Token: 0x04018EDC RID: 102108
		internal static int __PropertyOffset_13;

		// Token: 0x04018EDD RID: 102109
		internal static int __PropertyOffset_14;

		// Token: 0x04018EDE RID: 102110
		internal static int __PropertyOffset_15;

		// Token: 0x04018EDF RID: 102111
		internal static int __PropertyOffset_16;

		// Token: 0x04018EE0 RID: 102112
		internal static int __PropertyOffset_17;

		// Token: 0x04018EE1 RID: 102113
		internal static int __PropertyOffset_18;

		// Token: 0x04018EE2 RID: 102114
		internal static int __PropertyOffset_19;

		// Token: 0x04018EE3 RID: 102115
		internal static int __PropertyOffset_20;

		// Token: 0x04018EE4 RID: 102116
		internal static int __PropertyOffset_21;

		// Token: 0x04018EE5 RID: 102117
		internal static int __PropertyOffset_22;

		// Token: 0x04018EE6 RID: 102118
		internal static int __PropertyOffset_23;

		// Token: 0x04018EE7 RID: 102119
		internal static int __PropertyOffset_24;

		// Token: 0x04018EE8 RID: 102120
		internal static int __PropertyOffset_25;

		// Token: 0x04018EE9 RID: 102121
		internal static int __PropertyOffset_26;

		// Token: 0x04018EEA RID: 102122
		internal static int __PropertyOffset_27;

		// Token: 0x04018EEB RID: 102123
		internal static int __PropertyOffset_28;

		// Token: 0x04018EEC RID: 102124
		internal static int __PropertyOffset_29;

		// Token: 0x04018EED RID: 102125
		internal static int __PropertyOffset_30;

		// Token: 0x04018EEE RID: 102126
		internal static int __PropertyOffset_31;

		// Token: 0x04018EEF RID: 102127
		internal static int __PropertyOffset_32;

		// Token: 0x04018EF0 RID: 102128
		internal static int __PropertyOffset_33;

		// Token: 0x04018EF1 RID: 102129
		internal static int __PropertyOffset_34;

		// Token: 0x04018EF2 RID: 102130
		internal static int __PropertyOffset_35;

		// Token: 0x04018EF3 RID: 102131
		internal static int __PropertyOffset_36;

		// Token: 0x04018EF4 RID: 102132
		[Nullable(2)]
		private FIKTarget _LeftHandIKTargetCS;

		// Token: 0x04018EF5 RID: 102133
		internal static int __PropertyOffset_37;

		// Token: 0x04018EF6 RID: 102134
		[Nullable(2)]
		private FIKTarget _RightHandIKTargetCS;

		// Token: 0x04018EF7 RID: 102135
		internal static int __PropertyOffset_38;

		// Token: 0x04018EF8 RID: 102136
		internal static int __PropertyOffset_39;

		// Token: 0x04018EF9 RID: 102137
		internal static int __PropertyOffset_40;

		// Token: 0x04018EFA RID: 102138
		internal static int __PropertyOffset_41;

		// Token: 0x04018EFB RID: 102139
		internal static int __PropertyOffset_42;

		// Token: 0x04018EFC RID: 102140
		internal static int __PropertyOffset_43;

		// Token: 0x04018EFD RID: 102141
		internal static int __PropertyOffset_44;

		// Token: 0x04018EFE RID: 102142
		internal static int __PropertyOffset_45;

		// Token: 0x04018EFF RID: 102143
		internal static int __PropertyOffset_46;

		// Token: 0x04018F00 RID: 102144
		internal static int __PropertyOffset_47;

		// Token: 0x04018F01 RID: 102145
		internal static int __PropertyOffset_48;

		// Token: 0x04018F02 RID: 102146
		internal static int __PropertyOffset_49;

		// Token: 0x04018F03 RID: 102147
		internal static int __PropertyOffset_50;

		// Token: 0x04018F04 RID: 102148
		internal static int __PropertyOffset_51;

		// Token: 0x04018F05 RID: 102149
		internal static int __PropertyOffset_52;
	}
}
