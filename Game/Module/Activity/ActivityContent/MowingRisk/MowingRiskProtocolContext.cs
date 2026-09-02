using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x0200666C RID: 26220
	[NullableContext(1)]
	[Nullable(0)]
	public class MowingRiskProtocolContext : ActivityBaseData, IMowingRiskContextDisposable
	{
		// Token: 0x060417F9 RID: 268281 RVA: 0x010D02A4 File Offset: 0x010CE4A4
		protected override void OnInit(ActivityData data)
		{
			ModelBase<MowingRiskModel>.Instance.InitContext();
		}

		// Token: 0x060417FA RID: 268282 RVA: 0x010D02B0 File Offset: 0x010CE4B0
		public void Dispose()
		{
		}

		// Token: 0x060417FB RID: 268283 RVA: 0x010D02B4 File Offset: 0x010CE4B4
		protected override void PhraseEx(ActivityData data)
		{
			RiskHarvestActivityInfo riskHarvestActivityInfo = data.RiskHarvestActivityInfo;
			if (riskHarvestActivityInfo != null)
			{
				this.ParseActivityInfo(riskHarvestActivityInfo);
			}
		}

		// Token: 0x060417FC RID: 268284 RVA: 0x010D02D4 File Offset: 0x010CE4D4
		public override bool GetExDataRedPointShowState()
		{
			MowingRiskModel instance = ModelBase<MowingRiskModel>.Instance;
			return instance.HasAnyReward || instance.IsNewInstanceOpen;
		}

		// Token: 0x060417FD RID: 268285 RVA: 0x010D02F7 File Offset: 0x010CE4F7
		public void ParseRiskHarvestEndNotify(RiskHarvestEndNotify msg)
		{
		}

		// Token: 0x060417FE RID: 268286 RVA: 0x010D02F9 File Offset: 0x010CE4F9
		public void ParseRiskHarvestInstUpdateNotify(RiskHarvestInstUpdateNotify msg)
		{
			this.ParseInstInfosIncremental(msg.InstInfos.ToArray<RiskHarvestInstInfo>());
		}

		// Token: 0x060417FF RID: 268287 RVA: 0x010D030C File Offset: 0x010CE50C
		public void ParseRiskHarvestArtifactNotify(RiskHarvestArtifactNotify msg)
		{
			this.ParseArtifactInfo(msg.ArtifactInfo);
		}

		// Token: 0x06041800 RID: 268288 RVA: 0x010D031A File Offset: 0x010CE51A
		public void ParseRiskHarvestBuffUpdateNotify(RiskHarvestBuffUpdateNotify msg)
		{
			this.ParseArtifactInfo(msg.ArtifactInfo);
		}

		// Token: 0x06041801 RID: 268289 RVA: 0x010D0328 File Offset: 0x010CE528
		public void ParseRiskHarvestBuffUnlockNotify(RiskHarvestBuffUnlockNotify msg)
		{
			this.ParseUnlockBuffGroup(msg.UnlockBuffGroup.ToArray<int>());
		}

		// Token: 0x06041802 RID: 268290 RVA: 0x010D033C File Offset: 0x010CE53C
		public void ParseRiskHarvestActivityUpdateNotify(RiskHarvestActivityUpdateNotify msg)
		{
			RiskHarvestActivityInfo activityInfo = msg.ActivityInfo;
			if (activityInfo == null)
			{
				return;
			}
			this.ParseActivityInfo(activityInfo);
		}

		// Token: 0x06041803 RID: 268291 RVA: 0x010D035C File Offset: 0x010CE55C
		private void ParseInstInfosIncremental(RiskHarvestInstInfo[] data)
		{
			foreach (RiskHarvestInstInfo riskHarvestInstInfo in data)
			{
				RiskHarvestInstInfo riskHarvestInstInfo2;
				if (this.InstanceInfoCache.TryGetValue(riskHarvestInstInfo.Id, out riskHarvestInstInfo2))
				{
					this.TotalScoreCache -= riskHarvestInstInfo2.Score;
				}
				this.InstanceInfoCache[riskHarvestInstInfo.Id] = riskHarvestInstInfo;
				this.TotalScoreCache += riskHarvestInstInfo.Score;
			}
		}

		// Token: 0x06041804 RID: 268292 RVA: 0x010D03CC File Offset: 0x010CE5CC
		private void ParseInstInfosAll(RiskHarvestInstInfo[] data)
		{
			this.TotalScoreCache = 0;
			foreach (RiskHarvestInstInfo riskHarvestInstInfo in data)
			{
				this.InstanceInfoCache[riskHarvestInstInfo.Id] = riskHarvestInstInfo;
				this.TotalScoreCache += riskHarvestInstInfo.Score;
			}
		}

		// Token: 0x06041805 RID: 268293 RVA: 0x010D041C File Offset: 0x010CE61C
		private void ParseRewardedScores(int[] data)
		{
			this.RewardedScoreCache.Clear();
			foreach (int item in data)
			{
				this.RewardedScoreCache.Add(item);
			}
		}

		// Token: 0x06041806 RID: 268294 RVA: 0x010D0458 File Offset: 0x010CE658
		private void ParseUnlockBuffGroup(int[] data)
		{
			foreach (int item in data)
			{
				this.UnlockBuffCache.Add(item);
			}
		}

		// Token: 0x06041807 RID: 268295 RVA: 0x010D0488 File Offset: 0x010CE688
		[NullableContext(2)]
		private void ParseArtifactInfo(RiskHarvestInstArtifactInfo data)
		{
			if (data == null)
			{
				return;
			}
			this.ArtifactInfoCache = data;
			this.BasicBuffInfoInBattleCache.Clear();
			foreach (RiskHarvestInstBuffInfo riskHarvestInstBuffInfo in data.Buffs)
			{
				this.BasicBuffInfoInBattleCache[riskHarvestInstBuffInfo.Id] = riskHarvestInstBuffInfo.Count;
			}
		}

		// Token: 0x06041808 RID: 268296 RVA: 0x010D04FC File Offset: 0x010CE6FC
		private void ParseActivityInfo(RiskHarvestActivityInfo data)
		{
			this.ParseInstInfosAll(data.InstInfos.ToArray<RiskHarvestInstInfo>());
			this.ParseRewardedScores(data.RewardedScores.ToArray<int>());
			this.ParseUnlockBuffGroup(data.UnlockBuffGroups.ToArray<int>());
		}

		// Token: 0x17009F93 RID: 40851
		// (get) Token: 0x06041809 RID: 268297 RVA: 0x010D0531 File Offset: 0x010CE731
		public Dictionary<int, RiskHarvestInstInfo> InstanceInfo
		{
			get
			{
				return this.InstanceInfoCache;
			}
		}

		// Token: 0x17009F94 RID: 40852
		// (get) Token: 0x0604180A RID: 268298 RVA: 0x010D053C File Offset: 0x010CE73C
		[Nullable(2)]
		public RiskHarvestInstArtifactInfo ArtifactInfo
		{
			[NullableContext(2)]
			get
			{
				if (this.ArtifactInfoCache == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.MowingRisk, ELogAuthor.WZ, "尚未获得割草局内buff数据", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				return this.ArtifactInfoCache;
			}
		}

		// Token: 0x17009F95 RID: 40853
		// (get) Token: 0x0604180B RID: 268299 RVA: 0x010D0576 File Offset: 0x010CE776
		public int ArtifactId
		{
			get
			{
				RiskHarvestInstArtifactInfo artifactInfoCache = this.ArtifactInfoCache;
				if (artifactInfoCache == null)
				{
					return 0;
				}
				return artifactInfoCache.Id;
			}
		}

		// Token: 0x17009F96 RID: 40854
		// (get) Token: 0x0604180C RID: 268300 RVA: 0x010D0589 File Offset: 0x010CE789
		public int ArtifactBasicBuffTotalCount
		{
			get
			{
				RiskHarvestInstArtifactInfo artifactInfoCache = this.ArtifactInfoCache;
				if (artifactInfoCache == null)
				{
					return 0;
				}
				return artifactInfoCache.Progress;
			}
		}

		// Token: 0x17009F97 RID: 40855
		// (get) Token: 0x0604180D RID: 268301 RVA: 0x010D059C File Offset: 0x010CE79C
		public Dictionary<int, int> BasicBuffInfoInBattle
		{
			get
			{
				return this.BasicBuffInfoInBattleCache;
			}
		}

		// Token: 0x17009F98 RID: 40856
		// (get) Token: 0x0604180E RID: 268302 RVA: 0x010D05A4 File Offset: 0x010CE7A4
		public int TotalScore
		{
			get
			{
				return this.TotalScoreCache;
			}
		}

		// Token: 0x17009F99 RID: 40857
		// (get) Token: 0x0604180F RID: 268303 RVA: 0x010D05AC File Offset: 0x010CE7AC
		public int UnlockBuffTotalCount
		{
			get
			{
				return this.UnlockBuffCache.Count;
			}
		}

		// Token: 0x17009F9A RID: 40858
		// (get) Token: 0x06041810 RID: 268304 RVA: 0x010D05B9 File Offset: 0x010CE7B9
		public HashSet<int> UnlockBuff
		{
			get
			{
				return this.UnlockBuffCache;
			}
		}

		// Token: 0x06041811 RID: 268305 RVA: 0x010D05C1 File Offset: 0x010CE7C1
		public bool IsBuffUnlocked(int id)
		{
			return this.UnlockBuffCache.Contains(id);
		}

		// Token: 0x06041812 RID: 268306 RVA: 0x010D05D0 File Offset: 0x010CE7D0
		public int? GetBuffCountInBattleById(int id)
		{
			int value;
			if (!this.BasicBuffInfoInBattleCache.TryGetValue(id, out value))
			{
				return null;
			}
			return new int?(value);
		}

		// Token: 0x06041813 RID: 268307 RVA: 0x010D0600 File Offset: 0x010CE800
		public int GetScoreById(int id)
		{
			RiskHarvestInstInfo riskHarvestInstInfo;
			if (!this.InstanceInfoCache.TryGetValue(id, out riskHarvestInstInfo))
			{
				return 0;
			}
			return riskHarvestInstInfo.Score;
		}

		// Token: 0x06041814 RID: 268308 RVA: 0x010D0628 File Offset: 0x010CE828
		public bool IsInstanceUnlockedById(int id)
		{
			RiskHarvestInstInfo riskHarvestInstInfo;
			return this.InstanceInfoCache.TryGetValue(id, out riskHarvestInstInfo) && riskHarvestInstInfo.IsUnlock;
		}

		// Token: 0x06041815 RID: 268309 RVA: 0x010D0650 File Offset: 0x010CE850
		public bool IsInstancePlayedById(int id)
		{
			RiskHarvestInstInfo riskHarvestInstInfo;
			return this.InstanceInfoCache.TryGetValue(id, out riskHarvestInstInfo) && riskHarvestInstInfo.Pass;
		}

		// Token: 0x06041816 RID: 268310 RVA: 0x010D0678 File Offset: 0x010CE878
		public double GetInstanceUnlockTimestampById(int id)
		{
			RiskHarvestInstInfo riskHarvestInstInfo;
			this.InstanceInfoCache.TryGetValue(id, out riskHarvestInstInfo);
			long? num = (riskHarvestInstInfo != null) ? new long?(riskHarvestInstInfo.UnlockTime) : null;
			if (num == null)
			{
				return double.MaxValue;
			}
			return (double)num.Value;
		}

		// Token: 0x06041817 RID: 268311 RVA: 0x010D06C9 File Offset: 0x010CE8C9
		public bool IsInstancePassUnlockTimeById(int id)
		{
			return Singleton<TimeUtil>.Instance.GetServerTimeStamp() >= this.GetInstanceUnlockTimestampById(id);
		}

		// Token: 0x06041818 RID: 268312 RVA: 0x010D06E1 File Offset: 0x010CE8E1
		public void ResetCacheInBattle()
		{
			this.ArtifactInfoCache = null;
			this.BasicBuffInfoInBattleCache.Clear();
			this.InBattleRecordData.Clear();
		}

		// Token: 0x06041819 RID: 268313 RVA: 0x010D0700 File Offset: 0x010CE900
		public bool HasScoreRewarded(int id)
		{
			return this.RewardedScoreCache.Contains(id);
		}

		// Token: 0x0604181A RID: 268314 RVA: 0x010D070E File Offset: 0x010CE90E
		public void RecordBuffId(int buffId)
		{
			this.InBattleRecordData.BasicBuffRecord.Add(buffId);
		}

		// Token: 0x0604181B RID: 268315 RVA: 0x010D0722 File Offset: 0x010CE922
		public HashSet<int> GetRecordBuffIdSet()
		{
			return this.InBattleRecordData.BasicBuffRecord;
		}

		// Token: 0x0604181C RID: 268316 RVA: 0x010D072F File Offset: 0x010CE92F
		public void RecordProgressPanelBasicBuffCount(int count)
		{
			this.InBattleRecordData.ProgressPanelBasicBuffCountRecord = count;
		}

		// Token: 0x0604181D RID: 268317 RVA: 0x010D073D File Offset: 0x010CE93D
		public int GetProgressPanelBasicBuffCountRecord()
		{
			return this.InBattleRecordData.ProgressPanelBasicBuffCountRecord;
		}

		// Token: 0x040249A6 RID: 149926
		private readonly Dictionary<int, RiskHarvestInstInfo> InstanceInfoCache = new Dictionary<int, RiskHarvestInstInfo>();

		// Token: 0x040249A7 RID: 149927
		[Nullable(2)]
		private RiskHarvestInstArtifactInfo ArtifactInfoCache;

		// Token: 0x040249A8 RID: 149928
		private readonly Dictionary<int, int> BasicBuffInfoInBattleCache = new Dictionary<int, int>();

		// Token: 0x040249A9 RID: 149929
		private readonly MowingRiskInBattleRecordData InBattleRecordData = new MowingRiskInBattleRecordData();

		// Token: 0x040249AA RID: 149930
		private readonly HashSet<int> RewardedScoreCache = new HashSet<int>();

		// Token: 0x040249AB RID: 149931
		private readonly HashSet<int> UnlockBuffCache = new HashSet<int>();

		// Token: 0x040249AC RID: 149932
		private int TotalScoreCache;
	}
}
