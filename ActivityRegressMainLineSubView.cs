using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200153D RID: 5437
[NullableContext(2)]
[Nullable(0)]
public class ActivityRegressMainLineSubView : ActivityRegressMainSubViewBase
{
	// Token: 0x06009889 RID: 39049 RVA: 0x0027F4B0 File Offset: 0x0027D6B0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = ActivityRegressMainViewComponentsInfo.Value;
	}

	// Token: 0x0600988A RID: 39050 RVA: 0x0027F4C0 File Offset: 0x0027D6C0
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityRegressMainLineSubView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityRegressMainLineSubView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600988B RID: 39051 RVA: 0x0027F504 File Offset: 0x0027D704
	protected override void OnStart()
	{
		base.OnStart();
		UUIHorizontalLayout horizontalLayout = base.GetHorizontalLayout(0);
		UUIItem item = base.GetItem(5);
		this.ActivityRecallTabGroupPanel = new ActivityRegressTabGroupPanel(horizontalLayout, item, new Action<int>(this.TabCallBack));
		this.ActivityRecallTabGroupPanel.Init();
		base.GetItem(3).SetUIActive(false);
	}

	// Token: 0x0600988C RID: 39052 RVA: 0x0027F558 File Offset: 0x0027D758
	protected override void OnBeforeDestroy()
	{
		this.ActivityRecallTabGroupPanel.Destroy();
		this.ActivityRecallTabGroupPanel = null;
	}

	// Token: 0x0600988D RID: 39053 RVA: 0x0027F56C File Offset: 0x0027D76C
	protected override void OnUpdate(int subTabIndex)
	{
		IReadOnlyList<RegressBase> lastestRegressBaseConfigList = ModelBase<ActivityRegressModel>.Instance.GetLastestRegressBaseConfigList(EActivityRegressEntranceType.NewMainLine);
		this.TabCommonDataList = new List<ActivityRegressTabSwitchItemCommonData>();
		if (lastestRegressBaseConfigList != null)
		{
			foreach (RegressBase value in lastestRegressBaseConfigList)
			{
				ActivityRegressTabSwitchItemCommonData item = new ActivityRegressTabSwitchItemCommonData
				{
					RecallEntryType = new EActivityRegressEntranceType?(EActivityRegressEntranceType.NewMainLine),
					Config = new RegressBase?(value),
					Title = value.Title
				};
				this.TabCommonDataList.Add(item);
			}
		}
		base.GetItem(7).SetUIActive(this.TabCommonDataList.Count > 1);
		this.ActivityRecallTabGroupPanel.RefreshByData(this.TabCommonDataList, subTabIndex);
	}

	// Token: 0x0600988E RID: 39054 RVA: 0x0027F62C File Offset: 0x0027D82C
	private void TabCallBack(int index)
	{
		RegressBase? config = this.TabCommonDataList[index].Config;
		this.ActivityRecallMainLineActivityInfoPanel.RefreshByData(config.Value);
		this.SequencePlayer.PlaySequence("Start", false, null);
	}

	// Token: 0x04004699 RID: 18073
	private ActivityRegressTabGroupPanel ActivityRecallTabGroupPanel;

	// Token: 0x0400469A RID: 18074
	private ActivityRegressMainLineActivityInfoPanel ActivityRecallMainLineActivityInfoPanel;

	// Token: 0x0400469B RID: 18075
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<ActivityRegressTabSwitchItemCommonData> TabCommonDataList;
}
