using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Manufacture.Compose;

namespace CSharpScript.Game.RedDot.RedDots.ComposeSystem
{
	// Token: 0x020047A0 RID: 18336
	public class RedDotComposeLevel : RedDotBase
	{
		// Token: 0x0602F937 RID: 194871 RVA: 0x00B56CD0 File Offset: 0x00B54ED0
		protected override void AddCheckEvent()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.UpdateComposeInfo, new Action(base.EventCheck));
			Singleton<EventSystem>.Instance.Add(EEventName.GetComposeData, new Action(base.EventCheck));
			Singleton<EventSystem>.Instance.Add(EEventName.ComposeSuccess, new Action(base.EventCheck));
			Singleton<EventSystem>.Instance.Add(EEventName.UpgradeComposeLevel, new Action(base.EventCheck));
		}

		// Token: 0x0602F938 RID: 194872 RVA: 0x00B56D50 File Offset: 0x00B54F50
		protected override void RemoveCheckEvent()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.UpdateComposeInfo, new Action(base.EventCheck));
			Singleton<EventSystem>.Instance.Remove(EEventName.GetComposeData, new Action(base.EventCheck));
			Singleton<EventSystem>.Instance.Remove(EEventName.ComposeSuccess, new Action(base.EventCheck));
			Singleton<EventSystem>.Instance.Remove(EEventName.UpgradeComposeLevel, new Action(base.EventCheck));
		}

		// Token: 0x0602F939 RID: 194873 RVA: 0x00B56DCD File Offset: 0x00B54FCD
		protected override bool OnCheck(int uId = 0)
		{
			return ControllerBase<ComposeController>.Instance.CheckCanGetComposeLevel();
		}
	}
}
