using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk
{
	// Token: 0x0200696B RID: 26987
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class CyberPunkConfig : ConfigBase<CyberPunkConfig>
	{
		// Token: 0x06042F63 RID: 274275 RVA: 0x0113112C File Offset: 0x0112F32C
		public EdgeRunnerUnlock? GetEdgeRunnerUnlockConfigById(int id)
		{
			return ConfigEdgeRunnerUnlockById.GetConfig(id, true);
		}

		// Token: 0x06042F64 RID: 274276 RVA: 0x01131135 File Offset: 0x0112F335
		public IReadOnlyList<EdgeRunnerUnlock> GetAllEdgeRunnerUnlockConfigList()
		{
			return ConfigEdgeRunnerUnlockAll.GetConfigList(true) ?? new EdgeRunnerUnlock[0];
		}

		// Token: 0x06042F65 RID: 274277 RVA: 0x01131147 File Offset: 0x0112F347
		public EdgeRunner? GetEdgeRunnerConfigById(int id)
		{
			return ConfigEdgeRunnerById.GetConfig(id, true);
		}

		// Token: 0x06042F66 RID: 274278 RVA: 0x01131150 File Offset: 0x0112F350
		public EdgeRunnerTrial? GetEdgeRunnerTrialConfigById(int id)
		{
			return ConfigEdgeRunnerTrialById.GetConfig(id, true);
		}

		// Token: 0x06042F67 RID: 274279 RVA: 0x01131159 File Offset: 0x0112F359
		public IReadOnlyList<EdgeRunnerTrial> GetEdgeRunnerTrialConfigListByActivityId(int activityId)
		{
			return ConfigEdgeRunnerTrialByActivityId.GetConfigList(activityId, true) ?? new EdgeRunnerTrial[0];
		}

		// Token: 0x06042F68 RID: 274280 RVA: 0x0113116C File Offset: 0x0112F36C
		public EdgeRunnerScoreReward? GetEdgeRunnerScoreRewardConfigById(int id)
		{
			return ConfigEdgeRunnerScoreRewardById.GetConfig(id, true);
		}

		// Token: 0x06042F69 RID: 274281 RVA: 0x01131175 File Offset: 0x0112F375
		public EdgeRunnerReward? GetEdgeRunnerRewardConfigById(int id)
		{
			return ConfigEdgeRunnerRewardById.GetConfig(id, true);
		}

		// Token: 0x06042F6A RID: 274282 RVA: 0x0113117E File Offset: 0x0112F37E
		public IReadOnlyList<EdgeRunnerReward> GetAllEdgeRunnerRewardConfigList()
		{
			return ConfigEdgeRunnerRewardAll.GetConfigList(true) ?? new EdgeRunnerReward[0];
		}

		// Token: 0x06042F6B RID: 274283 RVA: 0x01131190 File Offset: 0x0112F390
		public EdgeRunnerLordGym? GetEdgeRunnerLordGymConfigById(int id)
		{
			return ConfigEdgeRunnerLordGymById.GetConfig(id, true);
		}

		// Token: 0x06042F6C RID: 274284 RVA: 0x01131199 File Offset: 0x0112F399
		public IReadOnlyList<EdgeRunnerLordGym> GetEdgeRunnerLordGymConfigListByActivityId(int activityId)
		{
			return ConfigEdgeRunnerLordGymByActivityId.GetConfigList(activityId, true) ?? new EdgeRunnerLordGym[0];
		}

		// Token: 0x06042F6D RID: 274285 RVA: 0x011311AC File Offset: 0x0112F3AC
		public EdgeRunnerLordGym? GetStageConfig(int stageId)
		{
			EdgeRunnerLordGym? config = ConfigEdgeRunnerLordGymById.GetConfig(stageId, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Activity;
				ELogAuthor author = ELogAuthor.SWC;
				string message = "[AdamSmasherConfig] 找不到关卡配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("stageId", stageId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return config;
		}

		// Token: 0x06042F6E RID: 274286 RVA: 0x01131204 File Offset: 0x0112F404
		[NullableContext(2)]
		public IReadOnlyList<EdgeRunnerLordGym> GetStageConfigList(int activityId)
		{
			return ConfigEdgeRunnerLordGymByActivityId.GetConfigList(activityId, true);
		}

		// Token: 0x06042F6F RID: 274287 RVA: 0x01131210 File Offset: 0x0112F410
		public int GetFirstRewardPreview(int stageId)
		{
			if (this.GetStageConfig(stageId) == null)
			{
				return 0;
			}
			EdgeRunnerLordGym? edgeRunnerLordGym;
			return edgeRunnerLordGym.GetValueOrDefault().RewardId;
		}

		// Token: 0x06042F70 RID: 274288 RVA: 0x0113123F File Offset: 0x0112F43F
		[NullableContext(2)]
		public IReadOnlyList<EdgeRunnerTrial> GetTrialRoleListByTrialActivityId(int activityId)
		{
			return ConfigEdgeRunnerTrialByActivityId.GetConfigList(activityId, true);
		}

		// Token: 0x06042F71 RID: 274289 RVA: 0x01131248 File Offset: 0x0112F448
		[NullableContext(2)]
		public IReadOnlyList<EdgeRunnerTrial> GetTrialRoleListByCyberPunkActivityId(int activityId)
		{
			return ConfigEdgeRunnerTrialByCyberPunkActivityId.GetConfigList(activityId, true);
		}
	}
}
