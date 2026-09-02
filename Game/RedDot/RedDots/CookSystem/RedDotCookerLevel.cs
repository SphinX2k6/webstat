using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Cook;

namespace CSharpScript.Game.RedDot.RedDots.CookSystem
{
	// Token: 0x0200479F RID: 18335
	public class RedDotCookerLevel : RedDotBase
	{
		// Token: 0x0602F933 RID: 194867 RVA: 0x00B56B84 File Offset: 0x00B54D84
		protected override void AddCheckEvent()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.UpdateCookerInfo, new Action(base.EventCheck));
			Singleton<EventSystem>.Instance.Add(EEventName.GetCookData, new Action(base.EventCheck));
			Singleton<EventSystem>.Instance.Add(EEventName.CookSuccess, new Action(base.EventCheck));
			Singleton<EventSystem>.Instance.Add(EEventName.MachiningSuccess, new Action(base.EventCheck));
			Singleton<EventSystem>.Instance.Add(EEventName.UpgradeCookerLevel, new Action(base.EventCheck));
		}

		// Token: 0x0602F934 RID: 194868 RVA: 0x00B56C20 File Offset: 0x00B54E20
		protected override void RemoveCheckEvent()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.UpdateCookerInfo, new Action(base.EventCheck));
			Singleton<EventSystem>.Instance.Remove(EEventName.GetCookData, new Action(base.EventCheck));
			Singleton<EventSystem>.Instance.Remove(EEventName.CookSuccess, new Action(base.EventCheck));
			Singleton<EventSystem>.Instance.Remove(EEventName.MachiningSuccess, new Action(base.EventCheck));
			Singleton<EventSystem>.Instance.Remove(EEventName.UpgradeCookerLevel, new Action(base.EventCheck));
		}

		// Token: 0x0602F935 RID: 194869 RVA: 0x00B56CB9 File Offset: 0x00B54EB9
		protected override bool OnCheck(int id = 0)
		{
			return ControllerBase<CookController>.Instance.CheckCanGetCookerLevel();
		}
	}
}
