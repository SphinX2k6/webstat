using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001A69 RID: 6761
[NullableContext(1)]
[Nullable(0)]
public class RoleTabItem : CommonTabItem, ITabViewRegister
{
	// Token: 0x0600C195 RID: 49557 RVA: 0x0032F6CC File Offset: 0x0032D8CC
	protected override UniTask OnBeforeStartAsync()
	{
		RoleTabItem.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleTabItem.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C196 RID: 49558 RVA: 0x0032F70F File Offset: 0x0032D90F
	protected override void OnRefresh(CommonTabItemData data, bool isSelected, int gridIndex)
	{
		base.OnRefresh(data, isSelected, gridIndex);
		UiPanelBase warningItem = this.WarningItem;
		if (warningItem == null)
		{
			return;
		}
		warningItem.SetUiActive(this.IsConflict(gridIndex));
	}

	// Token: 0x0600C197 RID: 49559 RVA: 0x0032F736 File Offset: 0x0032D936
	public void RegisterViewModule(UiTabViewBase tabView)
	{
		tabView.AddUiTabViewBehavior<UiTabCamera>().SetTabData((EUiTabViewName)tabView.GetViewName());
		tabView.AddUiTabViewBehavior<UiTabSequence>().SetRootItem(tabView);
	}

	// Token: 0x0600C198 RID: 49560 RVA: 0x0032F75A File Offset: 0x0032D95A
	public override void UnBindRedDot()
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindRedDotAndClearData(this.RedDotName.Value);
			this.RedDotName = null;
		}
	}

	// Token: 0x04005A97 RID: 23191
	[Nullable(2)]
	private UiPanelBase WarningItem;

	// Token: 0x04005A98 RID: 23192
	public Func<int, bool> IsConflict = (int index) => false;
}
