using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoleSkinReward
{
	// Token: 0x0200647F RID: 25727
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityRoleSkinRewardData : ActivityBaseData
	{
		// Token: 0x0604089B RID: 264347 RVA: 0x0108AD34 File Offset: 0x01088F34
		protected override void PhraseEx(ActivityData data)
		{
			SkinRewardActivityData skinRewardActivityData = data.SkinRewardActivityData;
			foreach (SkinRewardActivityRewardInfo skinRewardActivityRewardInfo in ((skinRewardActivityData != null) ? skinRewardActivityData.RewardInfos : null))
			{
				this.SkinRewardData[skinRewardActivityRewardInfo.ConfigId] = skinRewardActivityRewardInfo.State;
			}
		}

		// Token: 0x0604089C RID: 264348 RVA: 0x0108ADA0 File Offset: 0x01088FA0
		public void UpdateSkinRewardState(int configId, SkinRewardActivityRewardState state)
		{
			this.SkinRewardData[configId] = state;
		}

		// Token: 0x0604089D RID: 264349 RVA: 0x0108ADB0 File Offset: 0x01088FB0
		public SkinRewardActivityRewardState? GetSkinRewardState(int configId)
		{
			SkinRewardActivityRewardState value;
			if (this.SkinRewardData.TryGetValue(configId, out value))
			{
				return new SkinRewardActivityRewardState?(value);
			}
			return null;
		}

		// Token: 0x0604089E RID: 264350 RVA: 0x0108ADE0 File Offset: 0x01088FE0
		public bool CheckTransitionCondition(int configId)
		{
			SkinRewardActivityRewardState skinRewardActivityRewardState;
			return this.SkinRewardData.TryGetValue(configId, out skinRewardActivityRewardState) && skinRewardActivityRewardState == SkinRewardActivityRewardState.InitState;
		}

		// Token: 0x0604089F RID: 264351 RVA: 0x0108AE04 File Offset: 0x01089004
		public bool CheckRewarded(int configId)
		{
			SkinRewardActivityRewardState skinRewardActivityRewardState;
			return this.SkinRewardData.TryGetValue(configId, out skinRewardActivityRewardState) && skinRewardActivityRewardState == SkinRewardActivityRewardState.TaskRewarded;
		}

		// Token: 0x060408A0 RID: 264352 RVA: 0x0108AE28 File Offset: 0x01089028
		protected override bool GetExDataFinishShowState()
		{
			int activityId = ControllerBase<ActivityRoleSkinRewardController>.Instance.ActivityId;
			SkinRewardActivityReward? activityConfig = ConfigBase<ActivityRoleSkinRewardConfig>.Instance.GetActivityConfig(activityId);
			SkinRewardActivityRewardState skinRewardActivityRewardState;
			return this.SkinRewardData.TryGetValue(activityConfig.Value.Id, out skinRewardActivityRewardState) && skinRewardActivityRewardState == SkinRewardActivityRewardState.TaskRewarded;
		}

		// Token: 0x060408A1 RID: 264353 RVA: 0x0108AE70 File Offset: 0x01089070
		public override bool GetExDataRedPointShowState()
		{
			int activityId = ControllerBase<ActivityRoleSkinRewardController>.Instance.ActivityId;
			SkinRewardActivityReward? activityConfig = ConfigBase<ActivityRoleSkinRewardConfig>.Instance.GetActivityConfig(activityId);
			SkinRewardActivityRewardState skinRewardActivityRewardState;
			return this.SkinRewardData.TryGetValue(activityConfig.Value.Id, out skinRewardActivityRewardState) && skinRewardActivityRewardState == SkinRewardActivityRewardState.TaskComplete;
		}

		// Token: 0x040241DF RID: 147935
		private readonly Dictionary<int, SkinRewardActivityRewardState> SkinRewardData = new Dictionary<int, SkinRewardActivityRewardState>();
	}
}
