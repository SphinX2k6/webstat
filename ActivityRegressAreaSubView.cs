using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001523 RID: 5411
[NullableContext(2)]
[Nullable(0)]
public class ActivityRegressAreaSubView : ActivityRegressMainSubViewBase
{
	// Token: 0x060097AA RID: 38826 RVA: 0x0027C079 File Offset: 0x0027A279
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = ActivityRegressMainViewComponentsInfo.Value;
	}

	// Token: 0x060097AB RID: 38827 RVA: 0x0027C088 File Offset: 0x0027A288
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityRegressAreaSubView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityRegressAreaSubView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060097AC RID: 38828 RVA: 0x0027C0CC File Offset: 0x0027A2CC
	protected override void OnStart()
	{
		base.OnStart();
		UUIHorizontalLayout horizontalLayout = base.GetHorizontalLayout(0);
		UUIItem item = base.GetItem(5);
		this.ActivityRegressTabGroupPanel = new ActivityRegressTabGroupPanel(horizontalLayout, item, new Action<int>(this.TabCallBack));
		this.ActivityRegressTabGroupPanel.Init();
		base.GetItem(3).SetUIActive(false);
	}

	// Token: 0x060097AD RID: 38829 RVA: 0x0027C120 File Offset: 0x0027A320
	protected override void OnBeforeDestroy()
	{
		this.ActivityRegressTabGroupPanel.Destroy();
		this.ActivityRegressTabGroupPanel = null;
	}

	// Token: 0x060097AE RID: 38830 RVA: 0x0027C134 File Offset: 0x0027A334
	protected override void OnUpdate(int subTabIndex)
	{
		IReadOnlyList<RegressBase> lastestRegressBaseConfigList = ModelBase<ActivityRegressModel>.Instance.GetLastestRegressBaseConfigList(EActivityRegressEntranceType.NewArea);
		this.TabCommonDataList = new List<ActivityRegressTabSwitchItemCommonData>();
		if (lastestRegressBaseConfigList != null)
		{
			foreach (RegressBase value in lastestRegressBaseConfigList)
			{
				ActivityRegressTabSwitchItemCommonData item = new ActivityRegressTabSwitchItemCommonData
				{
					RecallEntryType = new EActivityRegressEntranceType?(EActivityRegressEntranceType.NewArea),
					Config = new RegressBase?(value),
					Title = value.Title
				};
				this.TabCommonDataList.Add(item);
			}
		}
		base.GetItem(7).SetUIActive(this.TabCommonDataList.Count > 1);
		this.ActivityRegressTabGroupPanel.RefreshByData(this.TabCommonDataList, subTabIndex);
	}

	// Token: 0x060097AF RID: 38831 RVA: 0x0027C1F4 File Offset: 0x0027A3F4
	private void TabCallBack(int index)
	{
		RegressBase? config = this.TabCommonDataList[index].Config;
		this.ActivityRegressAreaActivityInfoPanel.RefreshByData(config.Value);
		this.SequencePlayer.PlaySequence("Start", false, null);
	}

	// Token: 0x04004655 RID: 18005
	private ActivityRegressTabGroupPanel ActivityRegressTabGroupPanel;

	// Token: 0x04004656 RID: 18006
	private ActivityRegressAreaActivityInfoPanel ActivityRegressAreaActivityInfoPanel;

	// Token: 0x04004657 RID: 18007
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<ActivityRegressTabSwitchItemCommonData> TabCommonDataList;
}
