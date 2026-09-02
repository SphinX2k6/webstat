using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.BP;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI
{
	// Token: 0x02003C9A RID: 15514
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/BP_SeqControlClouds.BP_SeqControlClouds_C")]
	[UnrealStructLayout(1712, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1712)]
	public class BP_SeqControlClouds_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060247BC RID: 149436 RVA: 0x0099EF30 File Offset: 0x0099D130
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SeqControlClouds_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/BP_SeqControlClouds.BP_SeqControlClouds_C");
			}
			return BP_SeqControlClouds_C._ClassPtr;
		}

		// Token: 0x060247BD RID: 149437 RVA: 0x0099EF54 File Offset: 0x0099D154
		public BP_SeqControlClouds_C() : this(BuiltinUtils.AllocNativeUObject(BP_SeqControlClouds_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060247BE RID: 149438 RVA: 0x0099EF7C File Offset: 0x0099D17C
		[NullableContext(1)]
		public BP_SeqControlClouds_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SeqControlClouds_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004C52 RID: 19538
		// (get) Token: 0x060247BF RID: 149439 RVA: 0x0099EFB0 File Offset: 0x0099D1B0
		// (set) Token: 0x060247C0 RID: 149440 RVA: 0x0099EFE9 File Offset: 0x0099D1E9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004C53 RID: 19539
		// (get) Token: 0x060247C1 RID: 149441 RVA: 0x0099F00A File Offset: 0x0099D20A
		// (set) Token: 0x060247C2 RID: 149442 RVA: 0x0099F01E File Offset: 0x0099D21E
		public unsafe UStaticMeshComponent BackgroundHighFog
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqControlClouds_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqControlClouds_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004C54 RID: 19540
		// (get) Token: 0x060247C3 RID: 149443 RVA: 0x0099F033 File Offset: 0x0099D233
		// (set) Token: 0x060247C4 RID: 149444 RVA: 0x0099F047 File Offset: 0x0099D247
		public unsafe UChildActorComponent Cloud02
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqControlClouds_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqControlClouds_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004C55 RID: 19541
		// (get) Token: 0x060247C5 RID: 149445 RVA: 0x0099F05C File Offset: 0x0099D25C
		// (set) Token: 0x060247C6 RID: 149446 RVA: 0x0099F070 File Offset: 0x0099D270
		public unsafe UChildActorComponent Cloud01
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqControlClouds_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqControlClouds_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004C56 RID: 19542
		// (get) Token: 0x060247C7 RID: 149447 RVA: 0x0099F085 File Offset: 0x0099D285
		// (set) Token: 0x060247C8 RID: 149448 RVA: 0x0099F099 File Offset: 0x0099D299
		public unsafe USceneComponent BaseScale
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqControlClouds_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqControlClouds_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004C57 RID: 19543
		// (get) Token: 0x060247C9 RID: 149449 RVA: 0x0099F0AE File Offset: 0x0099D2AE
		// (set) Token: 0x060247CA RID: 149450 RVA: 0x0099F0C2 File Offset: 0x0099D2C2
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqControlClouds_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqControlClouds_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004C58 RID: 19544
		// (get) Token: 0x060247CB RID: 149451 RVA: 0x0099F0D7 File Offset: 0x0099D2D7
		// (set) Token: 0x060247CC RID: 149452 RVA: 0x0099F0EC File Offset: 0x0099D2EC
		[Nullable(1)]
		public TSoftObjectPtr<PD_CloudPrefab_C> CloudAssetInSeq1
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_6, this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_6, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004C59 RID: 19545
		// (get) Token: 0x060247CD RID: 149453 RVA: 0x0099F111 File Offset: 0x0099D311
		// (set) Token: 0x060247CE RID: 149454 RVA: 0x0099F126 File Offset: 0x0099D326
		[Nullable(1)]
		public TSoftObjectPtr<PD_CloudPrefab_C> CloudAssetInSeq2
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_7, this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_7, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004C5A RID: 19546
		// (get) Token: 0x060247CF RID: 149455 RVA: 0x0099F14B File Offset: 0x0099D34B
		// (set) Token: 0x060247D0 RID: 149456 RVA: 0x0099F15B File Offset: 0x0099D35B
		public unsafe bool GIControlSeqClouds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004C5B RID: 19547
		// (get) Token: 0x060247D1 RID: 149457 RVA: 0x0099F16C File Offset: 0x0099D36C
		// (set) Token: 0x060247D2 RID: 149458 RVA: 0x0099F17C File Offset: 0x0099D37C
		public unsafe int Cloud01TransSortPriorityAdd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004C5C RID: 19548
		// (get) Token: 0x060247D3 RID: 149459 RVA: 0x0099F18D File Offset: 0x0099D38D
		// (set) Token: 0x060247D4 RID: 149460 RVA: 0x0099F19D File Offset: 0x0099D39D
		public unsafe float ChangeSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17004C5D RID: 19549
		// (get) Token: 0x060247D5 RID: 149461 RVA: 0x0099F1AE File Offset: 0x0099D3AE
		// (set) Token: 0x060247D6 RID: 149462 RVA: 0x0099F1BE File Offset: 0x0099D3BE
		public unsafe bool Override_Cloud_Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004C5E RID: 19550
		// (get) Token: 0x060247D7 RID: 149463 RVA: 0x0099F1CF File Offset: 0x0099D3CF
		// (set) Token: 0x060247D8 RID: 149464 RVA: 0x0099F1DF File Offset: 0x0099D3DF
		public unsafe float Cloud_Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17004C5F RID: 19551
		// (get) Token: 0x060247D9 RID: 149465 RVA: 0x0099F1F0 File Offset: 0x0099D3F0
		// (set) Token: 0x060247DA RID: 149466 RVA: 0x0099F200 File Offset: 0x0099D400
		public unsafe float Cloud_Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17004C60 RID: 19552
		// (get) Token: 0x060247DB RID: 149467 RVA: 0x0099F211 File Offset: 0x0099D411
		// (set) Token: 0x060247DC RID: 149468 RVA: 0x0099F226 File Offset: 0x0099D426
		[Nullable(1)]
		public TSoftObjectPtr<PD_CloudPrefab_C> CloudAssetInSeq1_Temp
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_14, this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_14, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004C61 RID: 19553
		// (get) Token: 0x060247DD RID: 149469 RVA: 0x0099F24B File Offset: 0x0099D44B
		// (set) Token: 0x060247DE RID: 149470 RVA: 0x0099F260 File Offset: 0x0099D460
		[Nullable(1)]
		public TSoftObjectPtr<PD_CloudPrefab_C> CloudAssetInSeq2_Temp
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_15, this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_15, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004C62 RID: 19554
		// (get) Token: 0x060247DF RID: 149471 RVA: 0x0099F285 File Offset: 0x0099D485
		// (set) Token: 0x060247E0 RID: 149472 RVA: 0x0099F295 File Offset: 0x0099D495
		public unsafe int Cloud01TransSortPriorityAdd_Temp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17004C63 RID: 19555
		// (get) Token: 0x060247E1 RID: 149473 RVA: 0x0099F2A6 File Offset: 0x0099D4A6
		// (set) Token: 0x060247E2 RID: 149474 RVA: 0x0099F2B6 File Offset: 0x0099D4B6
		public unsafe float Cloud1Opacity_Temp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17004C64 RID: 19556
		// (get) Token: 0x060247E3 RID: 149475 RVA: 0x0099F2C7 File Offset: 0x0099D4C7
		// (set) Token: 0x060247E4 RID: 149476 RVA: 0x0099F2D7 File Offset: 0x0099D4D7
		public unsafe float Cloud2Opacity_Temp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17004C65 RID: 19557
		// (get) Token: 0x060247E5 RID: 149477 RVA: 0x0099F2E8 File Offset: 0x0099D4E8
		// (set) Token: 0x060247E6 RID: 149478 RVA: 0x0099F2F8 File Offset: 0x0099D4F8
		public unsafe bool IsReversed_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004C66 RID: 19558
		// (get) Token: 0x060247E7 RID: 149479 RVA: 0x0099F309 File Offset: 0x0099D509
		// (set) Token: 0x060247E8 RID: 149480 RVA: 0x0099F319 File Offset: 0x0099D519
		public unsafe float ReversedZHeightBias
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17004C67 RID: 19559
		// (get) Token: 0x060247E9 RID: 149481 RVA: 0x0099F32A File Offset: 0x0099D52A
		// (set) Token: 0x060247EA RID: 149482 RVA: 0x0099F33A File Offset: 0x0099D53A
		public unsafe bool IsHiddenClouds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004C68 RID: 19560
		// (get) Token: 0x060247EB RID: 149483 RVA: 0x0099F34B File Offset: 0x0099D54B
		// (set) Token: 0x060247EC RID: 149484 RVA: 0x0099F35B File Offset: 0x0099D55B
		public unsafe bool DoOnce
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004C69 RID: 19561
		// (get) Token: 0x060247ED RID: 149485 RVA: 0x0099F36C File Offset: 0x0099D56C
		// (set) Token: 0x060247EE RID: 149486 RVA: 0x0099F380 File Offset: 0x0099D580
		public unsafe FLinearColor BG_TopColor_Temp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17004C6A RID: 19562
		// (get) Token: 0x060247EF RID: 149487 RVA: 0x0099F395 File Offset: 0x0099D595
		// (set) Token: 0x060247F0 RID: 149488 RVA: 0x0099F3A9 File Offset: 0x0099D5A9
		public unsafe FLinearColor BG_DownColor_Temp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17004C6B RID: 19563
		// (get) Token: 0x060247F1 RID: 149489 RVA: 0x0099F3BE File Offset: 0x0099D5BE
		// (set) Token: 0x060247F2 RID: 149490 RVA: 0x0099F3CE File Offset: 0x0099D5CE
		public unsafe float BG_HighFade_Temp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17004C6C RID: 19564
		// (get) Token: 0x060247F3 RID: 149491 RVA: 0x0099F3DF File Offset: 0x0099D5DF
		// (set) Token: 0x060247F4 RID: 149492 RVA: 0x0099F3EF File Offset: 0x0099D5EF
		public unsafe float BG_HighPos_Temp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17004C6D RID: 19565
		// (get) Token: 0x060247F5 RID: 149493 RVA: 0x0099F400 File Offset: 0x0099D600
		// (set) Token: 0x060247F6 RID: 149494 RVA: 0x0099F410 File Offset: 0x0099D610
		public unsafe float BG_Opacity_Temp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17004C6E RID: 19566
		// (get) Token: 0x060247F7 RID: 149495 RVA: 0x0099F421 File Offset: 0x0099D621
		// (set) Token: 0x060247F8 RID: 149496 RVA: 0x0099F431 File Offset: 0x0099D631
		public unsafe bool IsCloudsChange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004C6F RID: 19567
		// (get) Token: 0x060247F9 RID: 149497 RVA: 0x0099F442 File Offset: 0x0099D642
		// (set) Token: 0x060247FA RID: 149498 RVA: 0x0099F452 File Offset: 0x0099D652
		public unsafe bool IsBGChange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_29) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_29) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004C70 RID: 19568
		// (get) Token: 0x060247FB RID: 149499 RVA: 0x0099F463 File Offset: 0x0099D663
		// (set) Token: 0x060247FC RID: 149500 RVA: 0x0099F473 File Offset: 0x0099D673
		public unsafe bool IsSetDA
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_30) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_30) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004C71 RID: 19569
		// (get) Token: 0x060247FD RID: 149501 RVA: 0x0099F484 File Offset: 0x0099D684
		// (set) Token: 0x060247FE RID: 149502 RVA: 0x0099F494 File Offset: 0x0099D694
		public unsafe float Cloud1Opacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17004C72 RID: 19570
		// (get) Token: 0x060247FF RID: 149503 RVA: 0x0099F4A5 File Offset: 0x0099D6A5
		// (set) Token: 0x06024800 RID: 149504 RVA: 0x0099F4B5 File Offset: 0x0099D6B5
		public unsafe float Cloud2Opacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17004C73 RID: 19571
		// (get) Token: 0x06024801 RID: 149505 RVA: 0x0099F4C6 File Offset: 0x0099D6C6
		// (set) Token: 0x06024802 RID: 149506 RVA: 0x0099F4DA File Offset: 0x0099D6DA
		public unsafe FLinearColor BG_TopColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17004C74 RID: 19572
		// (get) Token: 0x06024803 RID: 149507 RVA: 0x0099F4EF File Offset: 0x0099D6EF
		// (set) Token: 0x06024804 RID: 149508 RVA: 0x0099F503 File Offset: 0x0099D703
		public unsafe FLinearColor BG_DownColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17004C75 RID: 19573
		// (get) Token: 0x06024805 RID: 149509 RVA: 0x0099F518 File Offset: 0x0099D718
		// (set) Token: 0x06024806 RID: 149510 RVA: 0x0099F528 File Offset: 0x0099D728
		public unsafe float BG_HighFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x17004C76 RID: 19574
		// (get) Token: 0x06024807 RID: 149511 RVA: 0x0099F539 File Offset: 0x0099D739
		// (set) Token: 0x06024808 RID: 149512 RVA: 0x0099F549 File Offset: 0x0099D749
		public unsafe float BG_HighPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17004C77 RID: 19575
		// (get) Token: 0x06024809 RID: 149513 RVA: 0x0099F55A File Offset: 0x0099D75A
		// (set) Token: 0x0602480A RID: 149514 RVA: 0x0099F56A File Offset: 0x0099D76A
		public unsafe float BG_Opacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqControlClouds_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17004C78 RID: 19576
		// (get) Token: 0x0602480B RID: 149515 RVA: 0x0099F57B File Offset: 0x0099D77B
		// (set) Token: 0x0602480C RID: 149516 RVA: 0x0099F58F File Offset: 0x0099D78F
		public unsafe UMaterialInstanceDynamic BG_DMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqControlClouds_C.__PropertyOffset_38);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqControlClouds_C.__PropertyOffset_38, value);
			}
		}

		// Token: 0x0602480D RID: 149517 RVA: 0x0099F5A4 File Offset: 0x0099D7A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CloudMainParamsUpdate()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqControlClouds_C.__CloudMainParamsUpdate_NativeFunctionPtr, null);
		}

		// Token: 0x0602480E RID: 149518 RVA: 0x0099F5B8 File Offset: 0x0099D7B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetCloudParameters(PD_CloudPrefab_C CloudPrefeb, UChildActorComponent CloudActorComponent)
		{
			BP_SeqControlClouds_C.__SetCloudParameters_FunctionParams* ptr = stackalloc BP_SeqControlClouds_C.__SetCloudParameters_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_SeqControlClouds_C.__SetCloudParameters_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqControlClouds_C.__SetCloudParameters_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CloudPrefeb = ((CloudPrefeb != null) ? CloudPrefeb.NativePtr : IntPtr.Zero);
			ptr->CloudActorComponent = ((CloudActorComponent != null) ? CloudActorComponent.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqControlClouds_C.__SetCloudParameters_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602480F RID: 149519 RVA: 0x0099F623 File Offset: 0x0099D823
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void IsChangeDataAsset()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqControlClouds_C.__IsChangeDataAsset_NativeFunctionPtr, null);
		}

		// Token: 0x06024810 RID: 149520 RVA: 0x0099F637 File Offset: 0x0099D837
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EndPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqControlClouds_C.__EndPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024811 RID: 149521 RVA: 0x0099F64C File Offset: 0x0099D84C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Update(bool IsEditor)
		{
			BP_SeqControlClouds_C.__Update_FunctionParams* ptr = stackalloc BP_SeqControlClouds_C.__Update_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_SeqControlClouds_C.__Update_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqControlClouds_C.__Update_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsEditor = IsEditor;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqControlClouds_C.__Update_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024812 RID: 149522 RVA: 0x0099F692 File Offset: 0x0099D892
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitTemp()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqControlClouds_C.__InitTemp_NativeFunctionPtr, null);
		}

		// Token: 0x06024813 RID: 149523 RVA: 0x0099F6A6 File Offset: 0x0099D8A6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqControlClouds_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06024814 RID: 149524 RVA: 0x0099F6BA File Offset: 0x0099D8BA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqControlClouds_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024815 RID: 149525 RVA: 0x0099F6D0 File Offset: 0x0099D8D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnLoaded_07220899417863CFE3A4D6848578EF8B(UObject Loaded)
		{
			BP_SeqControlClouds_C.__OnLoaded_07220899417863CFE3A4D6848578EF8B_FunctionParams* ptr = stackalloc BP_SeqControlClouds_C.__OnLoaded_07220899417863CFE3A4D6848578EF8B_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SeqControlClouds_C.__OnLoaded_07220899417863CFE3A4D6848578EF8B_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqControlClouds_C.__OnLoaded_07220899417863CFE3A4D6848578EF8B_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Loaded = ((Loaded != null) ? Loaded.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqControlClouds_C.__OnLoaded_07220899417863CFE3A4D6848578EF8B_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024816 RID: 149526 RVA: 0x0099F728 File Offset: 0x0099D928
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnLoaded_7C9A4D6E488C90912903E68A1CA2EF4E(UObject Loaded)
		{
			BP_SeqControlClouds_C.__OnLoaded_7C9A4D6E488C90912903E68A1CA2EF4E_FunctionParams* ptr = stackalloc BP_SeqControlClouds_C.__OnLoaded_7C9A4D6E488C90912903E68A1CA2EF4E_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SeqControlClouds_C.__OnLoaded_7C9A4D6E488C90912903E68A1CA2EF4E_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqControlClouds_C.__OnLoaded_7C9A4D6E488C90912903E68A1CA2EF4E_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Loaded = ((Loaded != null) ? Loaded.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqControlClouds_C.__OnLoaded_7C9A4D6E488C90912903E68A1CA2EF4E_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024817 RID: 149527 RVA: 0x0099F780 File Offset: 0x0099D980
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_SeqControlClouds_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_SeqControlClouds_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_SeqControlClouds_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqControlClouds_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqControlClouds_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024818 RID: 149528 RVA: 0x0099F7CC File Offset: 0x0099D9CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_SeqControlClouds_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_SeqControlClouds_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_SeqControlClouds_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqControlClouds_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqControlClouds_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024819 RID: 149529 RVA: 0x0099F818 File Offset: 0x0099DA18
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void LoadAndSwitch(bool IsInEditor, bool IsReversed, float ReversedZHeightBias)
		{
			BP_SeqControlClouds_C.__LoadAndSwitch_FunctionParams* ptr = stackalloc BP_SeqControlClouds_C.__LoadAndSwitch_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SeqControlClouds_C.__LoadAndSwitch_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqControlClouds_C.__LoadAndSwitch_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsInEditor = IsInEditor;
			ptr->IsReversed = IsReversed;
			ptr->ReversedZHeightBias = ReversedZHeightBias;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqControlClouds_C.__LoadAndSwitch_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602481A RID: 149530 RVA: 0x0099F86C File Offset: 0x0099DA6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SeqControlClouds_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SeqControlClouds_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SeqControlClouds_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqControlClouds_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqControlClouds_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602481B RID: 149531 RVA: 0x0099F8B4 File Offset: 0x0099DAB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SeqControlClouds_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SeqControlClouds_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SeqControlClouds_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqControlClouds_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqControlClouds_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602481C RID: 149532 RVA: 0x0099F8FB File Offset: 0x0099DAFB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqControlClouds_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602481D RID: 149533 RVA: 0x0099F90F File Offset: 0x0099DB0F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqControlClouds_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602481E RID: 149534 RVA: 0x0099F924 File Offset: 0x0099DB24
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_SeqControlClouds_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SeqControlClouds_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SeqControlClouds_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqControlClouds_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqControlClouds_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602481F RID: 149535 RVA: 0x0099F96C File Offset: 0x0099DB6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_SeqControlClouds_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SeqControlClouds_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SeqControlClouds_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqControlClouds_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqControlClouds_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024820 RID: 149536 RVA: 0x0099F9B4 File Offset: 0x0099DBB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SeqControlClouds(int EntryPoint)
		{
			BP_SeqControlClouds_C.__ExecuteUbergraph_BP_SeqControlClouds_FunctionParams* ptr = stackalloc BP_SeqControlClouds_C.__ExecuteUbergraph_BP_SeqControlClouds_FunctionParams[(UIntPtr)535] + 15L / (long)sizeof(BP_SeqControlClouds_C.__ExecuteUbergraph_BP_SeqControlClouds_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqControlClouds_C.__ExecuteUbergraph_BP_SeqControlClouds_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqControlClouds_C.__ExecuteUbergraph_BP_SeqControlClouds_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024821 RID: 149537 RVA: 0x0099F9FE File Offset: 0x0099DBFE
		protected BP_SeqControlClouds_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012B0C RID: 76556
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/BP_SeqControlClouds.BP_SeqControlClouds_C";

		// Token: 0x04012B0D RID: 76557
		private static IntPtr _ClassPtr;

		// Token: 0x04012B0E RID: 76558
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012B0F RID: 76559
		internal static int __PropertyOffset_0;

		// Token: 0x04012B10 RID: 76560
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012B11 RID: 76561
		internal static int __PropertyOffset_1;

		// Token: 0x04012B12 RID: 76562
		internal static int __PropertyOffset_2;

		// Token: 0x04012B13 RID: 76563
		internal static int __PropertyOffset_3;

		// Token: 0x04012B14 RID: 76564
		internal static int __PropertyOffset_4;

		// Token: 0x04012B15 RID: 76565
		internal static int __PropertyOffset_5;

		// Token: 0x04012B16 RID: 76566
		internal static int __PropertyOffset_6;

		// Token: 0x04012B17 RID: 76567
		internal static int __PropertyOffset_7;

		// Token: 0x04012B18 RID: 76568
		internal static int __PropertyOffset_8;

		// Token: 0x04012B19 RID: 76569
		internal static int __PropertyOffset_9;

		// Token: 0x04012B1A RID: 76570
		internal static int __PropertyOffset_10;

		// Token: 0x04012B1B RID: 76571
		internal static int __PropertyOffset_11;

		// Token: 0x04012B1C RID: 76572
		internal static int __PropertyOffset_12;

		// Token: 0x04012B1D RID: 76573
		internal static int __PropertyOffset_13;

		// Token: 0x04012B1E RID: 76574
		internal static int __PropertyOffset_14;

		// Token: 0x04012B1F RID: 76575
		internal static int __PropertyOffset_15;

		// Token: 0x04012B20 RID: 76576
		internal static int __PropertyOffset_16;

		// Token: 0x04012B21 RID: 76577
		internal static int __PropertyOffset_17;

		// Token: 0x04012B22 RID: 76578
		internal static int __PropertyOffset_18;

		// Token: 0x04012B23 RID: 76579
		internal static int __PropertyOffset_19;

		// Token: 0x04012B24 RID: 76580
		internal static int __PropertyOffset_20;

		// Token: 0x04012B25 RID: 76581
		internal static int __PropertyOffset_21;

		// Token: 0x04012B26 RID: 76582
		internal static int __PropertyOffset_22;

		// Token: 0x04012B27 RID: 76583
		internal static int __PropertyOffset_23;

		// Token: 0x04012B28 RID: 76584
		internal static int __PropertyOffset_24;

		// Token: 0x04012B29 RID: 76585
		internal static int __PropertyOffset_25;

		// Token: 0x04012B2A RID: 76586
		internal static int __PropertyOffset_26;

		// Token: 0x04012B2B RID: 76587
		internal static int __PropertyOffset_27;

		// Token: 0x04012B2C RID: 76588
		internal static int __PropertyOffset_28;

		// Token: 0x04012B2D RID: 76589
		internal static int __PropertyOffset_29;

		// Token: 0x04012B2E RID: 76590
		internal static int __PropertyOffset_30;

		// Token: 0x04012B2F RID: 76591
		internal static int __PropertyOffset_31;

		// Token: 0x04012B30 RID: 76592
		internal static int __PropertyOffset_32;

		// Token: 0x04012B31 RID: 76593
		internal static int __PropertyOffset_33;

		// Token: 0x04012B32 RID: 76594
		internal static int __PropertyOffset_34;

		// Token: 0x04012B33 RID: 76595
		internal static int __PropertyOffset_35;

		// Token: 0x04012B34 RID: 76596
		internal static int __PropertyOffset_36;

		// Token: 0x04012B35 RID: 76597
		internal static int __PropertyOffset_37;

		// Token: 0x04012B36 RID: 76598
		internal static int __PropertyOffset_38;

		// Token: 0x04012B37 RID: 76599
		private static IntPtr __CloudMainParamsUpdate_NativeFunctionPtr;

		// Token: 0x04012B38 RID: 76600
		private static IntPtr __SetCloudParameters_NativeFunctionPtr;

		// Token: 0x04012B39 RID: 76601
		private static IntPtr __IsChangeDataAsset_NativeFunctionPtr;

		// Token: 0x04012B3A RID: 76602
		private static IntPtr __EndPlay_NativeFunctionPtr;

		// Token: 0x04012B3B RID: 76603
		private static IntPtr __Update_NativeFunctionPtr;

		// Token: 0x04012B3C RID: 76604
		private static IntPtr __InitTemp_NativeFunctionPtr;

		// Token: 0x04012B3D RID: 76605
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012B3E RID: 76606
		private static IntPtr __OnLoaded_07220899417863CFE3A4D6848578EF8B_NativeFunctionPtr;

		// Token: 0x04012B3F RID: 76607
		private static IntPtr __OnLoaded_7C9A4D6E488C90912903E68A1CA2EF4E_NativeFunctionPtr;

		// Token: 0x04012B40 RID: 76608
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04012B41 RID: 76609
		private static IntPtr __LoadAndSwitch_NativeFunctionPtr;

		// Token: 0x04012B42 RID: 76610
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012B43 RID: 76611
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012B44 RID: 76612
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04012B45 RID: 76613
		private static IntPtr __ExecuteUbergraph_BP_SeqControlClouds_NativeFunctionPtr;

		// Token: 0x02009DF8 RID: 40440
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __SetCloudParameters_FunctionParams
		{
			// Token: 0x04032839 RID: 206905
			[FieldOffset(0)]
			public IntPtr CloudPrefeb;

			// Token: 0x0403283A RID: 206906
			[FieldOffset(8)]
			public IntPtr CloudActorComponent;
		}

		// Token: 0x02009DF9 RID: 40441
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __Update_FunctionParams
		{
			// Token: 0x0403283B RID: 206907
			[FieldOffset(0)]
			public bool IsEditor;
		}

		// Token: 0x02009DFA RID: 40442
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __OnLoaded_07220899417863CFE3A4D6848578EF8B_FunctionParams
		{
			// Token: 0x0403283C RID: 206908
			[FieldOffset(0)]
			public IntPtr Loaded;
		}

		// Token: 0x02009DFB RID: 40443
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __OnLoaded_7C9A4D6E488C90912903E68A1CA2EF4E_FunctionParams
		{
			// Token: 0x0403283D RID: 206909
			[FieldOffset(0)]
			public IntPtr Loaded;
		}

		// Token: 0x02009DFC RID: 40444
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x0403283E RID: 206910
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009DFD RID: 40445
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __LoadAndSwitch_FunctionParams
		{
			// Token: 0x0403283F RID: 206911
			[FieldOffset(0)]
			public bool IsInEditor;

			// Token: 0x04032840 RID: 206912
			[FieldOffset(1)]
			public bool IsReversed;

			// Token: 0x04032841 RID: 206913
			[FieldOffset(4)]
			public float ReversedZHeightBias;
		}

		// Token: 0x02009DFE RID: 40446
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032842 RID: 206914
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009DFF RID: 40447
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032843 RID: 206915
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E00 RID: 40448
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 520)]
		protected ref struct __ExecuteUbergraph_BP_SeqControlClouds_FunctionParams
		{
			// Token: 0x04032844 RID: 206916
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
