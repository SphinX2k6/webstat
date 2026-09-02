using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200147F RID: 5247
[NullableContext(1)]
[Nullable(0)]
public class NewPlayerAdventureV2View : UiViewBase
{
	// Token: 0x060092DD RID: 37597 RVA: 0x0026BBBB File Offset: 0x00269DBB
	public NewPlayerAdventureV2View(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x060092DE RID: 37598 RVA: 0x0026BBE0 File Offset: 0x00269DE0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIItem))
		};
	}

	// Token: 0x060092DF RID: 37599 RVA: 0x0026BCD8 File Offset: 0x00269ED8
	protected override UniTask OnBeforeStartAsync()
	{
		NewPlayerAdventureV2View.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<NewPlayerAdventureV2View.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060092E0 RID: 37600 RVA: 0x0026BD14 File Offset: 0x00269F14
	protected override void OnStart()
	{
		this.RoleLayout = new GenericLayout<NewPlayerAdventureV2RoleItem, int>(base.GetHorizontalLayout(0), new Func<NewPlayerAdventureV2RoleItem>(this.InitRoleItem), null, false, true);
		this.AdventureLayout = new GenericLayout<NewPlayerAdventureV2AdventureItem, int>(base.GetVerticalLayout(2), new Func<NewPlayerAdventureV2AdventureItem>(this.InitAdventureItem), base.GetItem(3).GetOwner() as AUIBaseActor, false, true);
		this.AdventureLayout2 = new GenericLayout<NewPlayerAdventureV2AdventureItem, int>(base.GetVerticalLayout(4), new Func<NewPlayerAdventureV2AdventureItem>(this.InitAdventureItem), base.GetItem(3).GetOwner() as AUIBaseActor, false, true);
		this.CaptionItem = new PopupCaptionItem(base.GetItem(7));
		this.CaptionItem.SetCloseCallBack(new Action(this.OnClickCloseBtn));
		this.RefreshTime(0f);
		this.RefreshTimer = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.RefreshTime), 1000f, 1f, null, null, true);
		this.RefreshRolePanelState();
	}

	// Token: 0x060092E1 RID: 37601 RVA: 0x0026BE07 File Offset: 0x0026A007
	protected override void OnBeforeDestroy()
	{
		if (this.RefreshTimer != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.RefreshTimer);
			this.RefreshTimer = null;
		}
	}

	// Token: 0x060092E2 RID: 37602 RVA: 0x0026BE29 File Offset: 0x0026A029
	private void RefreshTime(float delta)
	{
		base.GetText(8).SetText(this.GetRemainTimeText(), true);
	}

	// Token: 0x060092E3 RID: 37603 RVA: 0x0026BE40 File Offset: 0x0026A040
	private string GetRemainTimeText()
	{
		ActivityNewPlayerSupportActivityV2Controller activityController = this.GetActivityController();
		ActivityNewPlayerSupportActivityV2Data activityNewPlayerSupportActivityV2Data = (activityController != null) ? activityController.ActivityData : null;
		if (activityNewPlayerSupportActivityV2Data == null)
		{
			return "";
		}
		long displayRemainEndTime = activityNewPlayerSupportActivityV2Data.GetDisplayRemainEndTime();
		if (displayRemainEndTime <= 0L || !activityNewPlayerSupportActivityV2Data.CheckIfInShowTime())
		{
			return "";
		}
		return ModelBase<ActivityModel>.Instance.GetRemainTimeText(displayRemainEndTime, this.RemainTimeFormat) ?? "";
	}

	// Token: 0x060092E4 RID: 37604 RVA: 0x0026BE9D File Offset: 0x0026A09D
	[NullableContext(2)]
	private ActivityNewPlayerSupportActivityV2Controller GetActivityController()
	{
		return ActivityManager.GetActivityController(ActivityType.NewPlayerSupportActivityV2) as ActivityNewPlayerSupportActivityV2Controller;
	}

	// Token: 0x060092E5 RID: 37605 RVA: 0x0026BEAB File Offset: 0x0026A0AB
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x060092E6 RID: 37606 RVA: 0x0026BEB4 File Offset: 0x0026A0B4
	private List<int> GetRoleIdList()
	{
		INewPlayerAdventureV2ViewOpenData newPlayerAdventureV2ViewOpenData = this.OpenParam as INewPlayerAdventureV2ViewOpenData;
		return ((newPlayerAdventureV2ViewOpenData != null) ? newPlayerAdventureV2ViewOpenData.RoleIdList : null) ?? new List<int>();
	}

	// Token: 0x060092E7 RID: 37607 RVA: 0x0026BED8 File Offset: 0x0026A0D8
	private void RefreshRolePanelState()
	{
		List<int> roleList = this.GetRoleIdList();
		bool flag = roleList.Count > 0;
		base.GetItem(5).SetUIActive(flag);
		base.GetItem(6).SetUIActive(!flag);
		if (!flag)
		{
			this.CurrentSelectRoleId = 0;
			this.CurrentSelectToggle = null;
			GenericLayout<NewPlayerAdventureV2AdventureItem, int> adventureLayout = this.AdventureLayout;
			if (adventureLayout != null)
			{
				adventureLayout.RefreshByData(new List<int>(), null, true);
			}
			GenericLayout<NewPlayerAdventureV2AdventureItem, int> adventureLayout2 = this.AdventureLayout2;
			if (adventureLayout2 == null)
			{
				return;
			}
			adventureLayout2.RefreshByData(new List<int>(), null, true);
			return;
		}
		else
		{
			GenericLayout<NewPlayerAdventureV2RoleItem, int> roleLayout = this.RoleLayout;
			if (roleLayout == null)
			{
				return;
			}
			roleLayout.RefreshByData(roleList, delegate
			{
				int num = (this.CurrentSelectRoleId != 0) ? roleList.IndexOf(this.CurrentSelectRoleId) : 0;
				GenericLayout<NewPlayerAdventureV2RoleItem, int> roleLayout2 = this.RoleLayout;
				if (roleLayout2 == null)
				{
					return;
				}
				NewPlayerAdventureV2RoleItem layoutItemByIndex = roleLayout2.GetLayoutItemByIndex((num >= 0) ? num : 0);
				if (layoutItemByIndex == null)
				{
					return;
				}
				layoutItemByIndex.SelectToggle();
			}, false);
			return;
		}
	}

	// Token: 0x060092E8 RID: 37608 RVA: 0x0026BF8E File Offset: 0x0026A18E
	private NewPlayerAdventureV2RoleItem InitRoleItem()
	{
		return new NewPlayerAdventureV2RoleItem
		{
			OnClickToggleCallBack = new Action<int, UUIExtendToggle>(this.OnClickRoleToggleCallBack)
		};
	}

	// Token: 0x060092E9 RID: 37609 RVA: 0x0026BFA7 File Offset: 0x0026A1A7
	private NewPlayerAdventureV2AdventureItem InitAdventureItem()
	{
		return new NewPlayerAdventureV2AdventureItem
		{
			OnClickJumpToCallBack = new Action(this.RefreshRolePanelState)
		};
	}

	// Token: 0x060092EA RID: 37610 RVA: 0x0026BFC0 File Offset: 0x0026A1C0
	private void OnClickRoleToggleCallBack(int roleId, UUIExtendToggle toggle)
	{
		this.RefreshRolePanelState();
		base.PlayOrReplaySequence("Switch", false, null);
		if (this.CurrentSelectRoleId == roleId)
		{
			return;
		}
		this.CurrentSelectRoleId = roleId;
		UUIExtendToggle currentSelectToggle = this.CurrentSelectToggle;
		if (currentSelectToggle != null)
		{
			currentSelectToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentSelectToggle = toggle;
		IReadOnlyList<GachaRoleDevelopIns> gachaRoleDevelopInsByRoleId = ConfigBase<ActivityRegressConfig>.Instance.GetGachaRoleDevelopInsByRoleId(roleId);
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		if (gachaRoleDevelopInsByRoleId != null)
		{
			for (int i = 0; i < gachaRoleDevelopInsByRoleId.Count; i++)
			{
				GachaRoleDevelopIns gachaRoleDevelopIns = gachaRoleDevelopInsByRoleId[i];
				if (gachaRoleDevelopIns.Type == 1)
				{
					list.Add(gachaRoleDevelopIns.Id);
				}
				if (gachaRoleDevelopIns.Type == 2)
				{
					list2.Add(gachaRoleDevelopIns.Id);
				}
			}
		}
		GenericLayout<NewPlayerAdventureV2AdventureItem, int> adventureLayout = this.AdventureLayout;
		if (adventureLayout != null)
		{
			adventureLayout.RefreshByData(list, null, true);
		}
		GenericLayout<NewPlayerAdventureV2AdventureItem, int> adventureLayout2 = this.AdventureLayout2;
		if (adventureLayout2 == null)
		{
			return;
		}
		adventureLayout2.RefreshByData(list2, null, true);
	}

	// Token: 0x040043F9 RID: 17401
	private const int TimerIntervalMs = 1000;

	// Token: 0x040043FA RID: 17402
	private int CurrentSelectRoleId;

	// Token: 0x040043FB RID: 17403
	[Nullable(2)]
	private UUIExtendToggle CurrentSelectToggle;

	// Token: 0x040043FC RID: 17404
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<NewPlayerAdventureV2RoleItem, int> RoleLayout;

	// Token: 0x040043FD RID: 17405
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<NewPlayerAdventureV2AdventureItem, int> AdventureLayout;

	// Token: 0x040043FE RID: 17406
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<NewPlayerAdventureV2AdventureItem, int> AdventureLayout2;

	// Token: 0x040043FF RID: 17407
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04004400 RID: 17408
	[Nullable(2)]
	private TimerHandle RefreshTimer;

	// Token: 0x04004401 RID: 17409
	private readonly string RemainTimeFormat = ConfigMultiTextLang.GetLocalTextNew("ActivityRemainingTime", null) ?? "";
}
