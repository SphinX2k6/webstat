using System;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Activity.ActivityContent.LineCross
{
	// Token: 0x0200676C RID: 26476
	public class LineCrossGroupRedDot : RedDotBase
	{
		// Token: 0x06041FFA RID: 270330 RVA: 0x010EF081 File Offset: 0x010ED281
		protected override void AddCheckEvent()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshLineCrossGroupRedDot, new Action<int>(base.EventCheckWithUid));
		}

		// Token: 0x06041FFB RID: 270331 RVA: 0x010EF09F File Offset: 0x010ED29F
		protected override void RemoveCheckEvent()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshLineCrossGroupRedDot, new Action<int>(base.EventCheckWithUid));
		}

		// Token: 0x06041FFC RID: 270332 RVA: 0x010EF0BD File Offset: 0x010ED2BD
		protected override bool OnCheck(int groupId)
		{
			return ModelBase<LineCrossModel>.Instance.GetGroupRedDotState(groupId);
		}
	}
}
