using System;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FunPlay
{
	// Token: 0x0200677B RID: 26491
	public class RedDotActivityFunPlay : RedDotBase
	{
		// Token: 0x060420A5 RID: 270501 RVA: 0x010F1E61 File Offset: 0x010F0061
		protected override void AddCheckEvent()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshActivityFunPlayRedDot, new Action<int>(base.EventCheckWithUid));
		}

		// Token: 0x060420A6 RID: 270502 RVA: 0x010F1E7F File Offset: 0x010F007F
		protected override void RemoveCheckEvent()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshActivityFunPlayRedDot, new Action<int>(base.EventCheckWithUid));
		}

		// Token: 0x060420A7 RID: 270503 RVA: 0x010F1EA0 File Offset: 0x010F00A0
		protected override bool OnCheck(int challengeId)
		{
			ActivityFunPlayChallengeData challengeData = ModelBase<ActivityFunPlayModel>.Instance.GetChallengeData(challengeId);
			return challengeData != null && challengeData.GetRedPoint();
		}
	}
}
