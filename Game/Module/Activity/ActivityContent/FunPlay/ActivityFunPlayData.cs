using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FunPlay
{
	// Token: 0x02006772 RID: 26482
	public class ActivityFunPlayData : ActivityBaseData
	{
		// Token: 0x0604203A RID: 270394 RVA: 0x010EFF74 File Offset: 0x010EE174
		[NullableContext(1)]
		protected override void PhraseEx(ActivityData data)
		{
			FunPlayActivityInfo funPlayActivityInfo = data.FunPlayActivityInfo;
			RepeatedField<FunPlayChallengeInfo> repeatedField = (funPlayActivityInfo != null) ? funPlayActivityInfo.FunPlayChallengeInfos : null;
			if (repeatedField == null)
			{
				return;
			}
			ModelBase<ActivityFunPlayModel>.Instance.CreateChallengeData(repeatedField.ToArray<FunPlayChallengeInfo>(), base.Id);
		}

		// Token: 0x0604203B RID: 270395 RVA: 0x010EFFAE File Offset: 0x010EE1AE
		public bool CheckRedDot()
		{
			if (!base.GetPreGuideQuestFinishState())
			{
				return this.CheckPreQuestUnFinishRedDot();
			}
			return this.CheckPreQuestFinishedRedDot();
		}

		// Token: 0x0604203C RID: 270396 RVA: 0x010EFFC5 File Offset: 0x010EE1C5
		public bool CheckPreQuestFinishedRedDot()
		{
			return this.GetClickRedDotState(100) || ModelBase<ActivityFunPlayModel>.Instance.GetHasInternalRedDot();
		}

		// Token: 0x0604203D RID: 270397 RVA: 0x010EFFDD File Offset: 0x010EE1DD
		public bool CheckPreQuestUnFinishRedDot()
		{
			return this.GetClickRedDotState(200);
		}

		// Token: 0x0604203E RID: 270398 RVA: 0x010EFFEF File Offset: 0x010EE1EF
		public bool GetClickRedDotState(int key)
		{
			return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, key, 0, 0) == 0;
		}

		// Token: 0x0604203F RID: 270399 RVA: 0x010F0008 File Offset: 0x010EE208
		public void SetClickRedDotState()
		{
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 100, 0, 0, 1);
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 200, 0, 0, 1);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x06042040 RID: 270400 RVA: 0x010F0058 File Offset: 0x010EE258
		public override bool GetExDataRedPointShowState()
		{
			return this.CheckRedDot();
		}

		// Token: 0x06042041 RID: 270401 RVA: 0x010F0060 File Offset: 0x010EE260
		protected override bool GetExDataFinishShowState()
		{
			return base.IsUnLock() && base.GetPreGuideQuestFinishState() && ModelBase<ActivityFunPlayModel>.Instance.IsAllRewardClaimed();
		}

		// Token: 0x04024D05 RID: 150789
		public const int CLICKKEY = 100;

		// Token: 0x04024D06 RID: 150790
		public const int CLICKQUESTKEY = 200;
	}
}
