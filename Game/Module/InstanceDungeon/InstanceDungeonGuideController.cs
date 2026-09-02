using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.JoinTeam;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BC1 RID: 23489
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class InstanceDungeonGuideController : ControllerBase<InstanceDungeonGuideController>
	{
		// Token: 0x0603B770 RID: 243568 RVA: 0x00F13165 File Offset: 0x00F11365
		protected override bool OnInit()
		{
			InstanceDungeonGuideController.AddEvent();
			return true;
		}

		// Token: 0x0603B771 RID: 243569 RVA: 0x00F1316D File Offset: 0x00F1136D
		protected override bool OnClear()
		{
			InstanceDungeonGuideController.RemoveEvent();
			return true;
		}

		// Token: 0x0603B772 RID: 243570 RVA: 0x00F13175 File Offset: 0x00F11375
		private static void AddEvent()
		{
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.WorldDoneAndCloseLoading;
			Action handle;
			if ((handle = InstanceDungeonGuideController.<>O.<0>__OnWorldDone) == null)
			{
				handle = (InstanceDungeonGuideController.<>O.<0>__OnWorldDone = new Action(InstanceDungeonGuideController.OnWorldDone));
			}
			instance.Add(name, handle);
		}

		// Token: 0x0603B773 RID: 243571 RVA: 0x00F131A2 File Offset: 0x00F113A2
		private static void RemoveEvent()
		{
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.WorldDoneAndCloseLoading;
			Action handle;
			if ((handle = InstanceDungeonGuideController.<>O.<0>__OnWorldDone) == null)
			{
				handle = (InstanceDungeonGuideController.<>O.<0>__OnWorldDone = new Action(InstanceDungeonGuideController.OnWorldDone));
			}
			instance.Remove(name, handle);
		}

		// Token: 0x0603B774 RID: 243572 RVA: 0x00F131CF File Offset: 0x00F113CF
		public static void StartReplayGuide()
		{
			ModelBase<GuideModel>.Instance.ClearAllGroup();
			InstanceDungeonGuideController.CheckAndRunGuide();
		}

		// Token: 0x0603B775 RID: 243573 RVA: 0x00F131E0 File Offset: 0x00F113E0
		private static void CheckAndRunGuide()
		{
			int currentInstanceDungeonGuideType = ModelBase<InstanceDungeonGuideModel>.Instance.GetCurrentInstanceDungeonGuideType();
			int currentInstanceDungeonGuideValue = ModelBase<InstanceDungeonGuideModel>.Instance.GetCurrentInstanceDungeonGuideValue();
			switch (currentInstanceDungeonGuideType)
			{
			case 0:
				break;
			case 1:
				ControllerBase<JoinTeamController>.Instance.OpenJoinTeamView(currentInstanceDungeonGuideValue, false);
				return;
			case 2:
				Singleton<UiManager>.Instance.OpenView(EUiViewName.InstanceDungeonGuideView, null, null);
				return;
			case 3:
				if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.GuideTutorialTipsView))
				{
					ControllerBase<GuideController>.Instance.TryStartGuide(currentInstanceDungeonGuideValue);
					return;
				}
				break;
			case 4:
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleIntroductionView, currentInstanceDungeonGuideValue, null);
				break;
			default:
				return;
			}
		}

		// Token: 0x0603B776 RID: 243574 RVA: 0x00F13272 File Offset: 0x00F11472
		private static void OnWorldDone()
		{
			ModelBase<InstanceDungeonGuideModel>.Instance.RefreshCurrentDungeonGuide();
			if (ModelBase<InstanceDungeonGuideModel>.Instance.GetHaveGuide())
			{
				InstanceDungeonGuideController.StartReplayGuide();
			}
		}

		// Token: 0x0603B777 RID: 243575 RVA: 0x00F1328F File Offset: 0x00F1148F
		public static bool GetHaveGuide()
		{
			return ModelBase<InstanceDungeonGuideModel>.Instance.GetCurrentInstanceDungeonGuideType() != 0;
		}

		// Token: 0x0200BC2C RID: 48172
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403A0AC RID: 237740
			public static Action <0>__OnWorldDone;
		}
	}
}
