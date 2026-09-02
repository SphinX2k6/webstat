using System;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Activity.ActivityContent.LineCross
{
	// Token: 0x02006761 RID: 26465
	public class LineCrossChallengeRedDot : RedDotBase
	{
		// Token: 0x06041F9A RID: 270234 RVA: 0x010ED8A1 File Offset: 0x010EBAA1
		protected override void AddCheckEvent()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshLineCrossChallengeRedDot, new Action<int>(base.EventCheckWithUid));
		}

		// Token: 0x06041F9B RID: 270235 RVA: 0x010ED8BF File Offset: 0x010EBABF
		protected override void RemoveCheckEvent()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshLineCrossChallengeRedDot, new Action<int>(base.EventCheckWithUid));
		}

		// Token: 0x06041F9C RID: 270236 RVA: 0x010ED8DD File Offset: 0x010EBADD
		protected override bool OnCheck(int challengeId = 0)
		{
			return ModelBase<LineCrossModel>.Instance.GetChallengeRedDotState(challengeId);
		}
	}
}
