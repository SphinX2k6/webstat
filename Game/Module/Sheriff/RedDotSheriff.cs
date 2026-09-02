using System;
using System.Linq;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FA4 RID: 20388
	public class RedDotSheriff : RedDotBase
	{
		// Token: 0x060349E7 RID: 215527 RVA: 0x00D334B7 File Offset: 0x00D316B7
		protected override ERedDotName? OnGetParentName()
		{
			return new ERedDotName?(ERedDotName.FunctionMap);
		}

		// Token: 0x060349E8 RID: 215528 RVA: 0x00D334C0 File Offset: 0x00D316C0
		protected override void AddCheckEvent()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(base.EventCheckWithUid));
		}

		// Token: 0x060349E9 RID: 215529 RVA: 0x00D334DE File Offset: 0x00D316DE
		protected override void RemoveCheckEvent()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(base.EventCheckWithUid));
		}

		// Token: 0x060349EA RID: 215530 RVA: 0x00D334FC File Offset: 0x00D316FC
		protected override bool IsAllEventParamAsUId()
		{
			return false;
		}

		// Token: 0x060349EB RID: 215531 RVA: 0x00D334FF File Offset: 0x00D316FF
		protected override bool OnCheck(int uId = 0)
		{
			SheriffActivityData sheriffActivityData = ModelBase<ActivityModel>.Instance.GetActivitiesByType(106).FirstOrDefault<ActivityBaseData>() as SheriffActivityData;
			return sheriffActivityData != null && sheriffActivityData.GetTerminalRedPointShowState();
		}
	}
}
