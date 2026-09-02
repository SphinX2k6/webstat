using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001256 RID: 4694
[NullableContext(1)]
[Nullable(0)]
public class BeginnerCarnivalMainView : UiViewBase
{
	// Token: 0x06007D26 RID: 32038 RVA: 0x0020F953 File Offset: 0x0020DB53
	public BeginnerCarnivalMainView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06007D27 RID: 32039 RVA: 0x0020F974 File Offset: 0x0020DB74
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(6, new Action(this.OnClickSelectRoleBtn)),
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickChoseRoleBtn))
		};
	}

	// Token: 0x06007D28 RID: 32040 RVA: 0x0020FABB File Offset: 0x0020DCBB
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshBeginnerCarnivalChoseRole, new Action(this.OnRefreshBeginnerCarnivalChoseRole));
		Singleton<EventSystem>.Instance.Add(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
	}

	// Token: 0x06007D29 RID: 32041 RVA: 0x0020FAF5 File Offset: 0x0020DCF5
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshBeginnerCarnivalChoseRole, new Action(this.OnRefreshBeginnerCarnivalChoseRole));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
	}

	// Token: 0x06007D2A RID: 32042 RVA: 0x0020FB2F File Offset: 0x0020DD2F
	private void OnRefreshBeginnerCarnivalChoseRole()
	{
		this.RefreshView();
	}

	// Token: 0x06007D2B RID: 32043 RVA: 0x0020FB38 File Offset: 0x0020DD38
	protected override UniTask OnBeforeStartAsync()
	{
		BeginnerCarnivalMainView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BeginnerCarnivalMainView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007D2C RID: 32044 RVA: 0x0020FB7C File Offset: 0x0020DD7C
	protected override void OnStart()
	{
		BeginnerCarnivalData beginnerCarnivalData = ControllerBase<BeginnerCarnivalController>.Instance.GetBeginnerCarnivalData();
		int choseRoleId = beginnerCarnivalData.ChoseRoleId;
		if (!beginnerCarnivalData.GetHaveChoseRoleViewEnter() && choseRoleId <= 0)
		{
			this.OnClickChoseRoleBtn();
		}
	}

	// Token: 0x06007D2D RID: 32045 RVA: 0x0020FBAB File Offset: 0x0020DDAB
	protected override void OnBeforeShow()
	{
		this.RefreshView();
	}

	// Token: 0x06007D2E RID: 32046 RVA: 0x0020FBB4 File Offset: 0x0020DDB4
	private void RefreshView()
	{
		int num = 0;
		foreach (BeginnerCarnivalTaskType beginnerCarnivalTaskType in this.TaskTypeList)
		{
			num++;
			beginnerCarnivalTaskType.RefreshItem(num);
		}
		BeginnerCarnivalData beginnerCarnivalData = ControllerBase<BeginnerCarnivalController>.Instance.GetBeginnerCarnivalData();
		ActivityTask taskDataById = beginnerCarnivalData.GetTaskDataById(beginnerCarnivalData.GetRoleTaskId);
		if (taskDataById == null)
		{
			return;
		}
		bool flag = taskDataById.Status == ActivityTaskState.ActivityTaskTaken;
		int choseRoleId = beginnerCarnivalData.ChoseRoleId;
		bool flag2 = choseRoleId > 0;
		base.GetItem(8).SetUIActive(!flag2);
		if (flag2)
		{
			NewbieCarnivalRole value = ConfigBase<BeginnerCarnivalConfig>.Instance.GetNewbieCarnivalRole(choseRoleId).Value;
			foreach (KeyValuePair<int, BeginnerCarnivalSpineItem> keyValuePair in this.SpineItemMap)
			{
				keyValuePair.Value.SetUiActive(false);
			}
			BeginnerCarnivalSpineItem item;
			if (!this.SpineItemMap.TryGetValue(choseRoleId, out item) || item == null)
			{
				item = new BeginnerCarnivalSpineItem();
				item.CreateThenShowByResourceIdAsync(value.MainViewSpineItem, base.GetItem(7), false).ContinueWith(delegate()
				{
					item.SetAnimation(0, ESpineAnimation.Idle.ToString(), true);
				}).Forget();
				this.SpineItemMap[choseRoleId] = item;
			}
			else
			{
				item.SetUiActive(true);
				item.SetAnimation(0, ESpineAnimation.Idle.ToString(), true);
			}
		}
		NewbieCarnivalParam? newbieCarnivalParam = ConfigBase<BeginnerCarnivalConfig>.Instance.GetNewbieCarnivalParam(ControllerBase<BeginnerCarnivalController>.Instance.ActivityId);
		base.GetText(10).SetText("<color=#f5cf47>" + beginnerCarnivalData.GetCurrentItemCount().ToString() + "</color>/" + ((newbieCarnivalParam != null) ? new int?(newbieCarnivalParam.GetValueOrDefault().AllCount) : null).ToString(), true);
		base.GetItem(9).SetUIActive(beginnerCarnivalData.GetRoleGetTaskTabRedDotShow(5));
		base.GetButton(5).RootUIComp.Get().SetUIActive(!flag);
	}

	// Token: 0x06007D2F RID: 32047 RVA: 0x0020FE0C File Offset: 0x0020E00C
	private void OnClickSelectRoleBtn()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BeginnerCarnivalRoleTaskView, null, null);
	}

	// Token: 0x06007D30 RID: 32048 RVA: 0x0020FE1F File Offset: 0x0020E01F
	private void OnClickChoseRoleBtn()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BeginnerCarnivalChoseRoleView, null, delegate(bool success, int viewId)
		{
			base.AddChildViewById(viewId);
		});
	}

	// Token: 0x06007D31 RID: 32049 RVA: 0x0020FE40 File Offset: 0x0020E040
	private void OnActivityClose(IReadOnlySet<int> closeActivities)
	{
		if (closeActivities.Contains(ControllerBase<BeginnerCarnivalController>.Instance.ActivityId))
		{
			Action value = delegate()
			{
				Singleton<UiManager>.Instance.ResetToBattleView(null);
			};
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ActivityEnd);
			confirmBoxDataNew.FunctionMap.Add(1, value);
			confirmBoxDataNew.FunctionMap.Add(0, value);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}
	}

	// Token: 0x04003BE9 RID: 15337
	private const int ROLE_TAB_INDEX = 5;

	// Token: 0x04003BEA RID: 15338
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04003BEB RID: 15339
	private readonly Dictionary<int, BeginnerCarnivalSpineItem> SpineItemMap = new Dictionary<int, BeginnerCarnivalSpineItem>();

	// Token: 0x04003BEC RID: 15340
	private readonly List<BeginnerCarnivalTaskType> TaskTypeList = new List<BeginnerCarnivalTaskType>();
}
