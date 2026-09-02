using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.GPUNPC.BP.CrowdAi;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Gameplay.SunSpirit
{
	// Token: 0x02003E9C RID: 16028
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/SunSpirit/BP_SunSpiritConfig.BP_SunSpiritConfig_C")]
	[UnrealStructLayout(256, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 256)]
	public class BP_SunSpiritConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06027C06 RID: 162822 RVA: 0x009F9B2D File Offset: 0x009F7D2D
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SunSpiritConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Gameplay/SunSpirit/BP_SunSpiritConfig.BP_SunSpiritConfig_C");
			}
			return BP_SunSpiritConfig_C._ClassPtr;
		}

		// Token: 0x06027C07 RID: 162823 RVA: 0x009F9B54 File Offset: 0x009F7D54
		public BP_SunSpiritConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_SunSpiritConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06027C08 RID: 162824 RVA: 0x009F9B7C File Offset: 0x009F7D7C
		public BP_SunSpiritConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SunSpiritConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005EB6 RID: 24246
		// (get) Token: 0x06027C09 RID: 162825 RVA: 0x009F9BAF File Offset: 0x009F7DAF
		// (set) Token: 0x06027C0A RID: 162826 RVA: 0x009F9BC3 File Offset: 0x009F7DC3
		[Nullable(2)]
		public unsafe BP_CrowdAiConfig_C CrowdAiConfig
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_CrowdAiConfig_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SunSpiritConfig_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SunSpiritConfig_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17005EB7 RID: 24247
		// (get) Token: 0x06027C0B RID: 162827 RVA: 0x009F9BD8 File Offset: 0x009F7DD8
		// (set) Token: 0x06027C0C RID: 162828 RVA: 0x009F9BE8 File Offset: 0x009F7DE8
		public unsafe int CrowdAiSystemIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005EB8 RID: 24248
		// (get) Token: 0x06027C0D RID: 162829 RVA: 0x009F9BF9 File Offset: 0x009F7DF9
		// (set) Token: 0x06027C0E RID: 162830 RVA: 0x009F9C09 File Offset: 0x009F7E09
		public unsafe float AroundPlayerPosQueryRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005EB9 RID: 24249
		// (get) Token: 0x06027C0F RID: 162831 RVA: 0x009F9C1A File Offset: 0x009F7E1A
		// (set) Token: 0x06027C10 RID: 162832 RVA: 0x009F9C2A File Offset: 0x009F7E2A
		public unsafe float AroundPlayerPosQueryBoidRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005EBA RID: 24250
		// (get) Token: 0x06027C11 RID: 162833 RVA: 0x009F9C3B File Offset: 0x009F7E3B
		// (set) Token: 0x06027C12 RID: 162834 RVA: 0x009F9C4B File Offset: 0x009F7E4B
		public unsafe int AroundPlayerPosQueryMaxTryCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005EBB RID: 24251
		// (get) Token: 0x06027C13 RID: 162835 RVA: 0x009F9C5C File Offset: 0x009F7E5C
		// (set) Token: 0x06027C14 RID: 162836 RVA: 0x009F9C6C File Offset: 0x009F7E6C
		public unsafe float FlyingEffectMaxDist
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005EBC RID: 24252
		// (get) Token: 0x06027C15 RID: 162837 RVA: 0x009F9C7D File Offset: 0x009F7E7D
		// (set) Token: 0x06027C16 RID: 162838 RVA: 0x009F9C8D File Offset: 0x009F7E8D
		public unsafe float FlyingEffectMinDist
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005EBD RID: 24253
		// (get) Token: 0x06027C17 RID: 162839 RVA: 0x009F9C9E File Offset: 0x009F7E9E
		// (set) Token: 0x06027C18 RID: 162840 RVA: 0x009F9CAE File Offset: 0x009F7EAE
		public unsafe float FlyingEffectUpdateFailMaxTimeSec
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005EBE RID: 24254
		// (get) Token: 0x06027C19 RID: 162841 RVA: 0x009F9CBF File Offset: 0x009F7EBF
		// (set) Token: 0x06027C1A RID: 162842 RVA: 0x009F9CCF File Offset: 0x009F7ECF
		public unsafe int FlyingEffectUpdateFailMaxCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005EBF RID: 24255
		// (get) Token: 0x06027C1B RID: 162843 RVA: 0x009F9CE0 File Offset: 0x009F7EE0
		// (set) Token: 0x06027C1C RID: 162844 RVA: 0x009F9CF0 File Offset: 0x009F7EF0
		public unsafe float FlyingEffectMaxFlyingDuration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005EC0 RID: 24256
		// (get) Token: 0x06027C1D RID: 162845 RVA: 0x009F9D01 File Offset: 0x009F7F01
		// (set) Token: 0x06027C1E RID: 162846 RVA: 0x009F9D16 File Offset: 0x009F7F16
		public TSoftObjectPtr<UEffectModelBase> FlyingEffectDa
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_10, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_10, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005EC1 RID: 24257
		// (get) Token: 0x06027C1F RID: 162847 RVA: 0x009F9D3B File Offset: 0x009F7F3B
		// (set) Token: 0x06027C20 RID: 162848 RVA: 0x009F9D4B File Offset: 0x009F7F4B
		public unsafe bool FlyFromPlayerToGearInOrderFromMinToMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005EC2 RID: 24258
		// (get) Token: 0x06027C21 RID: 162849 RVA: 0x009F9D5C File Offset: 0x009F7F5C
		// (set) Token: 0x06027C22 RID: 162850 RVA: 0x009F9D6C File Offset: 0x009F7F6C
		public unsafe float FlyFromPlayerToGearDelayInterval
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17005EC3 RID: 24259
		// (get) Token: 0x06027C23 RID: 162851 RVA: 0x009F9D7D File Offset: 0x009F7F7D
		// (set) Token: 0x06027C24 RID: 162852 RVA: 0x009F9D8D File Offset: 0x009F7F8D
		public unsafe float FlyFromPlayerToGearWaitTimeBeforeFly
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17005EC4 RID: 24260
		// (get) Token: 0x06027C25 RID: 162853 RVA: 0x009F9D9E File Offset: 0x009F7F9E
		// (set) Token: 0x06027C26 RID: 162854 RVA: 0x009F9DAE File Offset: 0x009F7FAE
		public unsafe float FlyFromPlayerToGearSpeedForCalc
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17005EC5 RID: 24261
		// (get) Token: 0x06027C27 RID: 162855 RVA: 0x009F9DBF File Offset: 0x009F7FBF
		// (set) Token: 0x06027C28 RID: 162856 RVA: 0x009F9DCF File Offset: 0x009F7FCF
		public unsafe float FlyFromPlayerToGearDefaultDuration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17005EC6 RID: 24262
		// (get) Token: 0x06027C29 RID: 162857 RVA: 0x009F9DE0 File Offset: 0x009F7FE0
		// (set) Token: 0x06027C2A RID: 162858 RVA: 0x009F9DF0 File Offset: 0x009F7FF0
		public unsafe bool FlyFromGearToPlayerInOrderFromMinToMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005EC7 RID: 24263
		// (get) Token: 0x06027C2B RID: 162859 RVA: 0x009F9E01 File Offset: 0x009F8001
		// (set) Token: 0x06027C2C RID: 162860 RVA: 0x009F9E11 File Offset: 0x009F8011
		public unsafe float FlyFromGearToPlayerDelayInterval
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17005EC8 RID: 24264
		// (get) Token: 0x06027C2D RID: 162861 RVA: 0x009F9E22 File Offset: 0x009F8022
		// (set) Token: 0x06027C2E RID: 162862 RVA: 0x009F9E32 File Offset: 0x009F8032
		public unsafe float FlyFromGearToPlayerWaitTimeBeforeFly
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17005EC9 RID: 24265
		// (get) Token: 0x06027C2F RID: 162863 RVA: 0x009F9E43 File Offset: 0x009F8043
		// (set) Token: 0x06027C30 RID: 162864 RVA: 0x009F9E53 File Offset: 0x009F8053
		public unsafe float FlyFromGearToPlayerSpeedForCalc
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17005ECA RID: 24266
		// (get) Token: 0x06027C31 RID: 162865 RVA: 0x009F9E64 File Offset: 0x009F8064
		// (set) Token: 0x06027C32 RID: 162866 RVA: 0x009F9E74 File Offset: 0x009F8074
		public unsafe float FlyFromGearToPlayerDefaultDuration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17005ECB RID: 24267
		// (get) Token: 0x06027C33 RID: 162867 RVA: 0x009F9E85 File Offset: 0x009F8085
		// (set) Token: 0x06027C34 RID: 162868 RVA: 0x009F9E95 File Offset: 0x009F8095
		public unsafe float FlyFromGearToPlayerMaxOffsetForReQueryTargetLoc
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17005ECC RID: 24268
		// (get) Token: 0x06027C35 RID: 162869 RVA: 0x009F9EA6 File Offset: 0x009F80A6
		// (set) Token: 0x06027C36 RID: 162870 RVA: 0x009F9EBA File Offset: 0x009F80BA
		public unsafe FVector2D LauncherHintUiAnchorOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17005ECD RID: 24269
		// (get) Token: 0x06027C37 RID: 162871 RVA: 0x009F9ECF File Offset: 0x009F80CF
		// (set) Token: 0x06027C38 RID: 162872 RVA: 0x009F9EE3 File Offset: 0x009F80E3
		public unsafe FVector2D LauncherHintUiPosLerpSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17005ECE RID: 24270
		// (get) Token: 0x06027C39 RID: 162873 RVA: 0x009F9EF8 File Offset: 0x009F80F8
		// (set) Token: 0x06027C3A RID: 162874 RVA: 0x009F9F0C File Offset: 0x009F810C
		public unsafe FVector2D CharacterHintUiAnchorOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17005ECF RID: 24271
		// (get) Token: 0x06027C3B RID: 162875 RVA: 0x009F9F21 File Offset: 0x009F8121
		// (set) Token: 0x06027C3C RID: 162876 RVA: 0x009F9F35 File Offset: 0x009F8135
		public unsafe FVector2D CharacterHintUiPosLerpSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17005ED0 RID: 24272
		// (get) Token: 0x06027C3D RID: 162877 RVA: 0x009F9F4A File Offset: 0x009F814A
		// (set) Token: 0x06027C3E RID: 162878 RVA: 0x009F9F5A File Offset: 0x009F815A
		public unsafe float CharacterHintUiShowDurationWhenUpdate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SunSpiritConfig_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x06027C3F RID: 162879 RVA: 0x009F9F6B File Offset: 0x009F816B
		protected BP_SunSpiritConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014DB3 RID: 85427
		public new const string __ObjectPath = "/Game/Aki/Data/Gameplay/SunSpirit/BP_SunSpiritConfig.BP_SunSpiritConfig_C";

		// Token: 0x04014DB4 RID: 85428
		private static IntPtr _ClassPtr;

		// Token: 0x04014DB5 RID: 85429
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014DB6 RID: 85430
		internal static int __PropertyOffset_0;

		// Token: 0x04014DB7 RID: 85431
		internal static int __PropertyOffset_1;

		// Token: 0x04014DB8 RID: 85432
		internal static int __PropertyOffset_2;

		// Token: 0x04014DB9 RID: 85433
		internal static int __PropertyOffset_3;

		// Token: 0x04014DBA RID: 85434
		internal static int __PropertyOffset_4;

		// Token: 0x04014DBB RID: 85435
		internal static int __PropertyOffset_5;

		// Token: 0x04014DBC RID: 85436
		internal static int __PropertyOffset_6;

		// Token: 0x04014DBD RID: 85437
		internal static int __PropertyOffset_7;

		// Token: 0x04014DBE RID: 85438
		internal static int __PropertyOffset_8;

		// Token: 0x04014DBF RID: 85439
		internal static int __PropertyOffset_9;

		// Token: 0x04014DC0 RID: 85440
		internal static int __PropertyOffset_10;

		// Token: 0x04014DC1 RID: 85441
		internal static int __PropertyOffset_11;

		// Token: 0x04014DC2 RID: 85442
		internal static int __PropertyOffset_12;

		// Token: 0x04014DC3 RID: 85443
		internal static int __PropertyOffset_13;

		// Token: 0x04014DC4 RID: 85444
		internal static int __PropertyOffset_14;

		// Token: 0x04014DC5 RID: 85445
		internal static int __PropertyOffset_15;

		// Token: 0x04014DC6 RID: 85446
		internal static int __PropertyOffset_16;

		// Token: 0x04014DC7 RID: 85447
		internal static int __PropertyOffset_17;

		// Token: 0x04014DC8 RID: 85448
		internal static int __PropertyOffset_18;

		// Token: 0x04014DC9 RID: 85449
		internal static int __PropertyOffset_19;

		// Token: 0x04014DCA RID: 85450
		internal static int __PropertyOffset_20;

		// Token: 0x04014DCB RID: 85451
		internal static int __PropertyOffset_21;

		// Token: 0x04014DCC RID: 85452
		internal static int __PropertyOffset_22;

		// Token: 0x04014DCD RID: 85453
		internal static int __PropertyOffset_23;

		// Token: 0x04014DCE RID: 85454
		internal static int __PropertyOffset_24;

		// Token: 0x04014DCF RID: 85455
		internal static int __PropertyOffset_25;

		// Token: 0x04014DD0 RID: 85456
		internal static int __PropertyOffset_26;
	}
}
