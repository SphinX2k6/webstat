using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.LevelGamePlay.Common
{
	// Token: 0x02006F2B RID: 28459
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class LevelGamePlayConfig : ConfigBase<LevelGamePlayConfig>
	{
		// Token: 0x06044E96 RID: 282262 RVA: 0x011F0B84 File Offset: 0x011EED84
		protected override bool OnInit()
		{
			this.ScanInfoCache = new Dictionary<int, GamePlayScan>();
			this.ScanMaxDistance = ConfigCommonParamById.GetIntConfig("scan_max_distance").GetValueOrDefault();
			this.ScanShowInteractionEffectMaxDistance = ConfigCommonParamById.GetIntConfig("scan_interaction_effect_max_distance").GetValueOrDefault();
			this.ScanDetectConcealedDistance = ConfigCommonParamById.GetIntConfig("scan_detect_concealed_distance").GetValueOrDefault();
			this.InteractInputCacheTime = ConfigCommonParamById.GetIntConfig("interact_input_cache_time").GetValueOrDefault();
			this.GenExtraGuideEffectMaxDist = ConfigCommonParamById.GetIntConfig("MaxNavigateToGuideEffectDist").GetValueOrDefault();
			this.GenExtraGuideEffectMinDist = ConfigCommonParamById.GetIntConfig("MinNavigateToGuideEffectDist").GetValueOrDefault();
			this.ExtraGuideEffectRaiseDist = ConfigCommonParamById.GetIntConfig("GuideEffectRaiseDist").GetValueOrDefault();
			return true;
		}

		// Token: 0x06044E97 RID: 282263 RVA: 0x011F0C45 File Offset: 0x011EEE45
		protected override bool OnClear()
		{
			this.ScanInfoCache = null;
			return true;
		}

		// Token: 0x06044E98 RID: 282264 RVA: 0x011F0C50 File Offset: 0x011EEE50
		public GamePlayScan? GetScanInfoById(int id)
		{
			GamePlayScan value = default(GamePlayScan);
			Dictionary<int, GamePlayScan> scanInfoCache = this.ScanInfoCache;
			if (scanInfoCache != null && scanInfoCache.TryGetValue(id, out value))
			{
				return new GamePlayScan?(value);
			}
			GamePlayScan? config = ConfigGamePlayScanByUid.GetConfig(id, true);
			if (config != null)
			{
				value = config.Value;
				this.ScanInfoCache[id] = value;
			}
			return new GamePlayScan?(value);
		}

		// Token: 0x040266C3 RID: 157379
		private Dictionary<int, GamePlayScan> ScanInfoCache;

		// Token: 0x040266C4 RID: 157380
		public int ScanMaxDistance;

		// Token: 0x040266C5 RID: 157381
		public int ScanShowInteractionEffectMaxDistance;

		// Token: 0x040266C6 RID: 157382
		public int ScanDetectConcealedDistance;

		// Token: 0x040266C7 RID: 157383
		public int InteractInputCacheTime;

		// Token: 0x040266C8 RID: 157384
		public int GenExtraGuideEffectMaxDist;

		// Token: 0x040266C9 RID: 157385
		public int GenExtraGuideEffectMinDist;

		// Token: 0x040266CA RID: 157386
		public int ExtraGuideEffectRaiseDist;
	}
}
