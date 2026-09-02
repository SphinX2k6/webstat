using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200125A RID: 4698
[NullableContext(1)]
[Nullable(0)]
public class BeginnerCarnivalRoleTaskView : UiViewBase
{
	// Token: 0x06007D39 RID: 32057 RVA: 0x00210057 File Offset: 0x0020E257
	public BeginnerCarnivalRoleTaskView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06007D3A RID: 32058 RVA: 0x0021006C File Offset: 0x0020E26C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIText)),
			new ValueTuple<int, Type>(13, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickSwitchBtn)),
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickGetBtn))
		};
	}

	// Token: 0x06007D3B RID: 32059 RVA: 0x002101F8 File Offset: 0x0020E3F8
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshBeginnerCarnivalChoseRole, new Action(this.OnRefreshBeginnerCarnivalChoseRole));
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshBeginnerCarnivalTask, new Action<int>(this.RefreshBeginnerCarnivalTask));
		Singleton<EventSystem>.Instance.Add(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
	}

	// Token: 0x06007D3C RID: 32060 RVA: 0x0021025C File Offset: 0x0020E45C
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshBeginnerCarnivalChoseRole, new Action(this.OnRefreshBeginnerCarnivalChoseRole));
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshBeginnerCarnivalTask, new Action<int>(this.RefreshBeginnerCarnivalTask));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
	}

	// Token: 0x06007D3D RID: 32061 RVA: 0x002102C0 File Offset: 0x0020E4C0
	protected override UniTask OnBeforeStartAsync()
	{
		BeginnerCarnivalRoleTaskView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BeginnerCarnivalRoleTaskView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007D3E RID: 32062 RVA: 0x00210303 File Offset: 0x0020E503
	private BeginnerCarnivalTaskItem CreateItem()
	{
		return new BeginnerCarnivalTaskItem();
	}

	// Token: 0x06007D3F RID: 32063 RVA: 0x0021030C File Offset: 0x0020E50C
	protected override void OnStart()
	{
		BeginnerCarnivalData beginnerCarnivalData = ControllerBase<BeginnerCarnivalController>.Instance.GetBeginnerCarnivalData();
		int choseRoleId = beginnerCarnivalData.ChoseRoleId;
		if (!beginnerCarnivalData.GetHaveChoseRoleViewEnter() && choseRoleId <= 0)
		{
			this.OnClickSwitchBtn();
		}
	}

	// Token: 0x06007D40 RID: 32064 RVA: 0x0021033B File Offset: 0x0020E53B
	protected override void OnBeforeShow()
	{
		this.RefreshView();
	}

	// Token: 0x06007D41 RID: 32065 RVA: 0x00210344 File Offset: 0x0020E544
	private void RefreshView()
	{
		BeginnerCarnivalData data = ControllerBase<BeginnerCarnivalController>.Instance.GetBeginnerCarnivalData();
		List<int> taskIdListByTypeId = data.GetTaskIdListByTypeId(5);
		taskIdListByTypeId.Sort(delegate(int a, int b)
		{
			ActivityTaskState status = data.GetTaskDataById(a).Status;
			ActivityTaskState status2 = data.GetTaskDataById(b).Status;
			if (status == status2)
			{
				return a - b;
			}
			int num = (status == ActivityTaskState.ActivityTaskFinish) ? 0 : ((status == ActivityTaskState.ActivityTaskTaken) ? 2 : 1);
			int num2 = (status2 == ActivityTaskState.ActivityTaskFinish) ? 0 : ((status2 == ActivityTaskState.ActivityTaskTaken) ? 2 : 1);
			return num - num2;
		});
		this.ScrollView.RefreshByData(taskIdListByTypeId, null, false);
		int choseRoleId = data.ChoseRoleId;
		bool flag = choseRoleId > 0;
		this.RoleDescribeComponent.SetUiActive(flag);
		if (flag)
		{
			this.RoleDescribeComponent.Update(choseRoleId);
		}
		NewbieCarnivalRole value = ConfigBase<BeginnerCarnivalConfig>.Instance.GetNewbieCarnivalRole(flag ? choseRoleId : 1000).Value;
		foreach (KeyValuePair<int, BeginnerCarnivalSpineItem> keyValuePair in this.SpineItemMap)
		{
			keyValuePair.Value.SetUiActive(false);
		}
		BeginnerCarnivalSpineItem item;
		if (!this.SpineItemMap.TryGetValue(choseRoleId, out item) || item == null)
		{
			item = new BeginnerCarnivalSpineItem();
			item.CreateThenShowByResourceIdAsync(value.RoleViewSpineItem, base.GetItem(1), false).ContinueWith(delegate()
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
		string item2 = (data.ChoseRoleId != 0) ? ConfigBase<TextConfig>.Instance.GetMultiTextByKey(ConfigBase<RoleConfig>.Instance.GetRoleConfig(data.ChoseRoleId).Value.Name) : string.Empty;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "BeginnerCarnivalGetRoleDes", new <>z__ReadOnlySingleElementList<object>(item2));
		ActivityTask taskDataById = data.GetTaskDataById(data.GetRoleTaskId);
		if (taskDataById == null)
		{
			return;
		}
		bool flag2 = taskDataById.Status == ActivityTaskState.ActivityTaskTaken;
		bool uiactive = taskDataById.Status == ActivityTaskState.ActivityTaskFinish;
		bool uiactive2 = taskDataById.Status == ActivityTaskState.ActivityTaskRunning;
		base.GetItem(10).SetUIActive(flag2);
		base.GetItem(11).SetUIActive(uiactive2);
		base.GetButton(5).RootUIComp.Get().SetUIActive(uiactive);
		base.GetItem(13).SetUIActive(uiactive);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "BeginnerCarnivalCurrentProgress", new <>z__ReadOnlyArray<object>(new object[]
		{
			taskDataById.Current,
			taskDataById.Target
		}));
		base.GetSprite(4).SetFillAmount((taskDataById.Target == 0) ? 0f : ((float)(taskDataById.Current / taskDataById.Target)));
		base.GetButton(2).RootUIComp.Get().SetUIActive(!flag2);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), "BeginnerCarnivalAllCount", new <>z__ReadOnlySingleElementList<object>(ControllerBase<BeginnerCarnivalController>.Instance.GetBeginnerCarnivalData().GetCurrentItemCount()));
	}

	// Token: 0x06007D42 RID: 32066 RVA: 0x0021066C File Offset: 0x0020E86C
	private void OnRefreshBeginnerCarnivalChoseRole()
	{
		this.RefreshView();
	}

	// Token: 0x06007D43 RID: 32067 RVA: 0x00210674 File Offset: 0x0020E874
	private void RefreshBeginnerCarnivalTask(int index)
	{
		this.RefreshView();
	}

	// Token: 0x06007D44 RID: 32068 RVA: 0x0021067C File Offset: 0x0020E87C
	private void OnClickSwitchBtn()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BeginnerCarnivalChoseRoleView, null, delegate(bool success, int viewId)
		{
			base.AddChildViewById(viewId);
		});
	}

	// Token: 0x06007D45 RID: 32069 RVA: 0x0021069C File Offset: 0x0020E89C
	private void OnClickGetBtn()
	{
		BeginnerCarnivalData data = ControllerBase<BeginnerCarnivalController>.Instance.GetBeginnerCarnivalData();
		if (data.ChoseRoleId > 0)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.BeginnerCarnivalGetRole);
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(ConfigBase<RoleConfig>.Instance.GetRoleConfig(data.ChoseRoleId).Value.Name);
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				multiTextByKey ?? string.Empty
			});
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				ControllerBase<BeginnerCarnivalController>.Instance.NewbieCarnivalAwardRequest(data.GetRoleTaskId);
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew2 = new ConfirmBoxDataNew(EConfirmBoxConfigId.BeginnerCarnivalNoRole);
		TOpenViewCallBack <>9__2;
		confirmBoxDataNew2.FunctionMap.Add(2, delegate
		{
			UiManager instance = Singleton<UiManager>.Instance;
			EUiViewName beginnerCarnivalChoseRoleView = EUiViewName.BeginnerCarnivalChoseRoleView;
			object param = null;
			TOpenViewCallBack finishCallback;
			if ((finishCallback = <>9__2) == null)
			{
				finishCallback = (<>9__2 = delegate(bool success, int viewId)
				{
					this.AddChildViewById(viewId);
				});
			}
			instance.OpenView(beginnerCarnivalChoseRoleView, param, finishCallback);
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew2);
	}

	// Token: 0x06007D46 RID: 32070 RVA: 0x00210780 File Offset: 0x0020E980
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

	// Token: 0x04003C02 RID: 15362
	private const int ROLE_TYPE_ID = 5;

	// Token: 0x04003C03 RID: 15363
	private const int ABU_ID = 1000;

	// Token: 0x04003C04 RID: 15364
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04003C05 RID: 15365
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<BeginnerCarnivalTaskItem, int> ScrollView;

	// Token: 0x04003C06 RID: 15366
	private readonly Dictionary<int, BeginnerCarnivalSpineItem> SpineItemMap = new Dictionary<int, BeginnerCarnivalSpineItem>();

	// Token: 0x04003C07 RID: 15367
	[Nullable(2)]
	private ActivityRoleDescribeComponent RoleDescribeComponent;
}
