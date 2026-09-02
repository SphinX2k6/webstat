using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Gameplay.RollBlock
{
	// Token: 0x02003E9D RID: 16029
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/RollBlock/BP_RollBlockGameplaySetting.BP_RollBlockGameplaySetting_C")]
	[UnrealStructLayout(464, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class BP_RollBlockGameplaySetting_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06027C40 RID: 162880 RVA: 0x009F9F74 File Offset: 0x009F8174
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_RollBlockGameplaySetting_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Gameplay/RollBlock/BP_RollBlockGameplaySetting.BP_RollBlockGameplaySetting_C");
			}
			return BP_RollBlockGameplaySetting_C._ClassPtr;
		}

		// Token: 0x06027C41 RID: 162881 RVA: 0x009F9F98 File Offset: 0x009F8198
		public BP_RollBlockGameplaySetting_C() : this(BuiltinUtils.AllocNativeUObject(BP_RollBlockGameplaySetting_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06027C42 RID: 162882 RVA: 0x009F9FC0 File Offset: 0x009F81C0
		public BP_RollBlockGameplaySetting_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_RollBlockGameplaySetting_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005ED1 RID: 24273
		// (get) Token: 0x06027C43 RID: 162883 RVA: 0x009F9FF3 File Offset: 0x009F81F3
		// (set) Token: 0x06027C44 RID: 162884 RVA: 0x009FA003 File Offset: 0x009F8203
		public unsafe float BlockRollTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005ED2 RID: 24274
		// (get) Token: 0x06027C45 RID: 162885 RVA: 0x009FA014 File Offset: 0x009F8214
		// (set) Token: 0x06027C46 RID: 162886 RVA: 0x009FA029 File Offset: 0x009F8229
		public TSoftObjectPtr<UEffectModelGroup> BreakableObstacleLinkEffect
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelGroup>(base.NativePtr + (IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_1, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005ED3 RID: 24275
		// (get) Token: 0x06027C47 RID: 162887 RVA: 0x009FA04E File Offset: 0x009F824E
		// (set) Token: 0x06027C48 RID: 162888 RVA: 0x009FA063 File Offset: 0x009F8263
		public TSoftObjectPtr<UEffectModelGroup> BreakableObstacleDestroyLinkEffect
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelGroup>(base.NativePtr + (IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_2, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_2, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005ED4 RID: 24276
		// (get) Token: 0x06027C49 RID: 162889 RVA: 0x009FA088 File Offset: 0x009F8288
		// (set) Token: 0x06027C4A RID: 162890 RVA: 0x009FA098 File Offset: 0x009F8298
		public unsafe int ShowBlockInterval
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005ED5 RID: 24277
		// (get) Token: 0x06027C4B RID: 162891 RVA: 0x009FA0A9 File Offset: 0x009F82A9
		// (set) Token: 0x06027C4C RID: 162892 RVA: 0x009FA0B9 File Offset: 0x009F82B9
		public unsafe int ShowMistakeTipsCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005ED6 RID: 24278
		// (get) Token: 0x06027C4D RID: 162893 RVA: 0x009FA0CA File Offset: 0x009F82CA
		// (set) Token: 0x06027C4E RID: 162894 RVA: 0x009FA0DE File Offset: 0x009F82DE
		public unsafe string RollBlockErrorTipKey
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_5)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_5)), value);
			}
		}

		// Token: 0x17005ED7 RID: 24279
		// (get) Token: 0x06027C4F RID: 162895 RVA: 0x009FA0F3 File Offset: 0x009F82F3
		// (set) Token: 0x06027C50 RID: 162896 RVA: 0x009FA103 File Offset: 0x009F8303
		public unsafe float DestroyTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005ED8 RID: 24280
		// (get) Token: 0x06027C51 RID: 162897 RVA: 0x009FA114 File Offset: 0x009F8314
		// (set) Token: 0x06027C52 RID: 162898 RVA: 0x009FA128 File Offset: 0x009F8328
		public unsafe string RollBlockMainTipKey
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_7)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_7)), value);
			}
		}

		// Token: 0x17005ED9 RID: 24281
		// (get) Token: 0x06027C53 RID: 162899 RVA: 0x009FA13D File Offset: 0x009F833D
		// (set) Token: 0x06027C54 RID: 162900 RVA: 0x009FA151 File Offset: 0x009F8351
		public unsafe string RollBlockSecondTipKey
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_8)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_8)), value);
			}
		}

		// Token: 0x17005EDA RID: 24282
		// (get) Token: 0x06027C55 RID: 162901 RVA: 0x009FA166 File Offset: 0x009F8366
		// (set) Token: 0x06027C56 RID: 162902 RVA: 0x009FA17A File Offset: 0x009F837A
		public unsafe string RollBlockPhantomTipKey
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_9)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_9)), value);
			}
		}

		// Token: 0x17005EDB RID: 24283
		// (get) Token: 0x06027C57 RID: 162903 RVA: 0x009FA18F File Offset: 0x009F838F
		// (set) Token: 0x06027C58 RID: 162904 RVA: 0x009FA1A4 File Offset: 0x009F83A4
		public TSoftObjectPtr<UEffectModelGroup> LightBeamEffect
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelGroup>(base.NativePtr + (IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_10, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_10, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005EDC RID: 24284
		// (get) Token: 0x06027C59 RID: 162905 RVA: 0x009FA1C9 File Offset: 0x009F83C9
		// (set) Token: 0x06027C5A RID: 162906 RVA: 0x009FA1DE File Offset: 0x009F83DE
		public TSoftObjectPtr<UEffectModelGroup> LightBeamHitEffect
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelGroup>(base.NativePtr + (IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_11, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_11, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005EDD RID: 24285
		// (get) Token: 0x06027C5B RID: 162907 RVA: 0x009FA203 File Offset: 0x009F8403
		// (set) Token: 0x06027C5C RID: 162908 RVA: 0x009FA218 File Offset: 0x009F8418
		public TSoftObjectPtr<UEffectModelGroup> LightBeamHitWallEffect
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelGroup>(base.NativePtr + (IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_12, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_12, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005EDE RID: 24286
		// (get) Token: 0x06027C5D RID: 162909 RVA: 0x009FA23D File Offset: 0x009F843D
		// (set) Token: 0x06027C5E RID: 162910 RVA: 0x009FA252 File Offset: 0x009F8452
		public TSoftObjectPtr<UEffectModelGroup> LightBeamStartEffect
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelGroup>(base.NativePtr + (IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_13, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_13, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005EDF RID: 24287
		// (get) Token: 0x06027C5F RID: 162911 RVA: 0x009FA277 File Offset: 0x009F8477
		// (set) Token: 0x06027C60 RID: 162912 RVA: 0x009FA287 File Offset: 0x009F8487
		public unsafe float VisionBlockRollTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17005EE0 RID: 24288
		// (get) Token: 0x06027C61 RID: 162913 RVA: 0x009FA298 File Offset: 0x009F8498
		// (set) Token: 0x06027C62 RID: 162914 RVA: 0x009FA2A8 File Offset: 0x009F84A8
		public unsafe int BlockDestroyDelayResetTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RollBlockGameplaySetting_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x06027C63 RID: 162915 RVA: 0x009FA2B9 File Offset: 0x009F84B9
		protected BP_RollBlockGameplaySetting_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014DD1 RID: 85457
		public new const string __ObjectPath = "/Game/Aki/Data/Gameplay/RollBlock/BP_RollBlockGameplaySetting.BP_RollBlockGameplaySetting_C";

		// Token: 0x04014DD2 RID: 85458
		private static IntPtr _ClassPtr;

		// Token: 0x04014DD3 RID: 85459
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014DD4 RID: 85460
		internal static int __PropertyOffset_0;

		// Token: 0x04014DD5 RID: 85461
		internal static int __PropertyOffset_1;

		// Token: 0x04014DD6 RID: 85462
		internal static int __PropertyOffset_2;

		// Token: 0x04014DD7 RID: 85463
		internal static int __PropertyOffset_3;

		// Token: 0x04014DD8 RID: 85464
		internal static int __PropertyOffset_4;

		// Token: 0x04014DD9 RID: 85465
		internal static int __PropertyOffset_5;

		// Token: 0x04014DDA RID: 85466
		internal static int __PropertyOffset_6;

		// Token: 0x04014DDB RID: 85467
		internal static int __PropertyOffset_7;

		// Token: 0x04014DDC RID: 85468
		internal static int __PropertyOffset_8;

		// Token: 0x04014DDD RID: 85469
		internal static int __PropertyOffset_9;

		// Token: 0x04014DDE RID: 85470
		internal static int __PropertyOffset_10;

		// Token: 0x04014DDF RID: 85471
		internal static int __PropertyOffset_11;

		// Token: 0x04014DE0 RID: 85472
		internal static int __PropertyOffset_12;

		// Token: 0x04014DE1 RID: 85473
		internal static int __PropertyOffset_13;

		// Token: 0x04014DE2 RID: 85474
		internal static int __PropertyOffset_14;

		// Token: 0x04014DE3 RID: 85475
		internal static int __PropertyOffset_15;
	}
}
