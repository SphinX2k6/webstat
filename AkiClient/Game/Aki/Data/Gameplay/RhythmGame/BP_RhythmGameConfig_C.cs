using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Gameplay.RhythmGame
{
	// Token: 0x02003E9E RID: 16030
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/RhythmGame/BP_RhythmGameConfig.BP_RhythmGameConfig_C")]
	[UnrealStructLayout(520, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 520)]
	public class BP_RhythmGameConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06027C64 RID: 162916 RVA: 0x009FA2C2 File Offset: 0x009F84C2
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_RhythmGameConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Gameplay/RhythmGame/BP_RhythmGameConfig.BP_RhythmGameConfig_C");
			}
			return BP_RhythmGameConfig_C._ClassPtr;
		}

		// Token: 0x06027C65 RID: 162917 RVA: 0x009FA2E8 File Offset: 0x009F84E8
		public BP_RhythmGameConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_RhythmGameConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06027C66 RID: 162918 RVA: 0x009FA310 File Offset: 0x009F8510
		public BP_RhythmGameConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_RhythmGameConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005EE1 RID: 24289
		// (get) Token: 0x06027C67 RID: 162919 RVA: 0x009FA344 File Offset: 0x009F8544
		// (set) Token: 0x06027C68 RID: 162920 RVA: 0x009FA37D File Offset: 0x009F857D
		public FKuroRhythmGameConfig Config
		{
			get
			{
				base.FastCheckIsValid();
				FKuroRhythmGameConfig result;
				if ((result = this._Config) == null)
				{
					result = (this._Config = new FKuroRhythmGameConfig(base.NativePtr + (IntPtr)BP_RhythmGameConfig_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroRhythmGameConfig.StaticStruct(), base.NativePtr + (IntPtr)BP_RhythmGameConfig_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005EE2 RID: 24290
		// (get) Token: 0x06027C69 RID: 162921 RVA: 0x009FA3A0 File Offset: 0x009F85A0
		// (set) Token: 0x06027C6A RID: 162922 RVA: 0x009FA3D9 File Offset: 0x009F85D9
		public TArray<RhythmGameSpeedLevelConfig> SpeedLevelConfig
		{
			get
			{
				base.FastCheckIsValid();
				TArray<RhythmGameSpeedLevelConfig> result;
				if ((result = this._SpeedLevelConfig) == null)
				{
					result = (this._SpeedLevelConfig = new TArray<RhythmGameSpeedLevelConfig>(base.NativePtr + (IntPtr)BP_RhythmGameConfig_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.SpeedLevelConfig.CopyAssign(value);
			}
		}

		// Token: 0x17005EE3 RID: 24291
		// (get) Token: 0x06027C6B RID: 162923 RVA: 0x009FA3E7 File Offset: 0x009F85E7
		// (set) Token: 0x06027C6C RID: 162924 RVA: 0x009FA3FB File Offset: 0x009F85FB
		public unsafe RhythmGamePerformanceCameraConfig StartCameraConfig
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RhythmGameConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RhythmGameConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005EE4 RID: 24292
		// (get) Token: 0x06027C6D RID: 162925 RVA: 0x009FA410 File Offset: 0x009F8610
		// (set) Token: 0x06027C6E RID: 162926 RVA: 0x009FA424 File Offset: 0x009F8624
		public unsafe RhythmGamePerformanceCameraConfig EndCameraConfig
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RhythmGameConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RhythmGameConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005EE5 RID: 24293
		// (get) Token: 0x06027C6F RID: 162927 RVA: 0x009FA43C File Offset: 0x009F863C
		// (set) Token: 0x06027C70 RID: 162928 RVA: 0x009FA475 File Offset: 0x009F8675
		public RhythmGameFreeFlyCameraConfig FreeFlyCameraConfig
		{
			get
			{
				base.FastCheckIsValid();
				RhythmGameFreeFlyCameraConfig result;
				if ((result = this._FreeFlyCameraConfig) == null)
				{
					result = (this._FreeFlyCameraConfig = new RhythmGameFreeFlyCameraConfig(base.NativePtr + (IntPtr)BP_RhythmGameConfig_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(RhythmGameFreeFlyCameraConfig.StaticStruct(), base.NativePtr + (IntPtr)BP_RhythmGameConfig_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06027C71 RID: 162929 RVA: 0x009FA496 File Offset: 0x009F8696
		protected BP_RhythmGameConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014DE4 RID: 85476
		public new const string __ObjectPath = "/Game/Aki/Data/Gameplay/RhythmGame/BP_RhythmGameConfig.BP_RhythmGameConfig_C";

		// Token: 0x04014DE5 RID: 85477
		private static IntPtr _ClassPtr;

		// Token: 0x04014DE6 RID: 85478
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014DE7 RID: 85479
		internal static int __PropertyOffset_0;

		// Token: 0x04014DE8 RID: 85480
		[Nullable(2)]
		private FKuroRhythmGameConfig _Config;

		// Token: 0x04014DE9 RID: 85481
		internal static int __PropertyOffset_1;

		// Token: 0x04014DEA RID: 85482
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<RhythmGameSpeedLevelConfig> _SpeedLevelConfig;

		// Token: 0x04014DEB RID: 85483
		internal static int __PropertyOffset_2;

		// Token: 0x04014DEC RID: 85484
		internal static int __PropertyOffset_3;

		// Token: 0x04014DED RID: 85485
		internal static int __PropertyOffset_4;

		// Token: 0x04014DEE RID: 85486
		[Nullable(2)]
		private RhythmGameFreeFlyCameraConfig _FreeFlyCameraConfig;
	}
}
