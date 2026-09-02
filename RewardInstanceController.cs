using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001411 RID: 5137
[NullableContext(1)]
[Nullable(0)]
public class RewardInstanceController
{
	// Token: 0x06008E56 RID: 36438 RVA: 0x0025663E File Offset: 0x0025483E
	public void RegisterMainView(RewardMainView mainView)
	{
		this.MainView = mainView;
	}

	// Token: 0x06008E57 RID: 36439 RVA: 0x00256648 File Offset: 0x00254848
	public UniTask InitMainView()
	{
		RewardInstanceController.<InitMainView>d__4 <InitMainView>d__;
		<InitMainView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitMainView>d__.<>4__this = this;
		<InitMainView>d__.<>1__state = -1;
		<InitMainView>d__.<>t__builder.Start<RewardInstanceController.<InitMainView>d__4>(ref <InitMainView>d__);
		return <InitMainView>d__.<>t__builder.Task;
	}

	// Token: 0x06008E58 RID: 36440 RVA: 0x0025668B File Offset: 0x0025488B
	public void RefreshTabList()
	{
		ModelBase<MoonChasingModel>.Instance.GetRewardTabList();
		this.TabDataList = new List<UiDynamicTab>();
		this.MainView.SetTabState(0, true, true);
	}

	// Token: 0x06008E59 RID: 36441 RVA: 0x002566B4 File Offset: 0x002548B4
	public void TabItemToggleClick(int index)
	{
		if (index != this.CurrentTabIndex)
		{
			this.MainView.SetTabState(this.CurrentTabIndex, false, true);
		}
		this.CurrentTabIndex = index;
		UiDynamicTab data = this.TabDataList[index];
		this.MainView.SwitchTabView(data, index);
	}

	// Token: 0x04004259 RID: 16985
	private RewardMainView MainView;

	// Token: 0x0400425A RID: 16986
	protected List<UiDynamicTab> TabDataList = new List<UiDynamicTab>();

	// Token: 0x0400425B RID: 16987
	private int CurrentTabIndex;
}
