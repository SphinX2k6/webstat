using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029E6 RID: 10726
[NullableContext(1)]
[Nullable(0)]
public class ShipTowerTeamTabItem : CommonTabItemBase, ITabViewRegister
{
	// Token: 0x0601560C RID: 87564 RVA: 0x005EC7F0 File Offset: 0x005EA9F0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnExtendToggleToggle))
		};
	}

	// Token: 0x0601560D RID: 87565 RVA: 0x005EC870 File Offset: 0x005EAA70
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerTeamTabItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerTeamTabItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601560E RID: 87566 RVA: 0x005EC8B3 File Offset: 0x005EAAB3
	public void RegisterViewModule(UiTabViewBase tabView)
	{
		tabView.AddUiTabViewBehavior<UiTabSequence>().SetRootItem(tabView);
	}

	// Token: 0x0601560F RID: 87567 RVA: 0x005EC8C1 File Offset: 0x005EAAC1
	private void OnExtendToggleToggle(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.SelectedCallBack(base.GridIndex);
		}
	}

	// Token: 0x06015610 RID: 87568 RVA: 0x005EC8DA File Offset: 0x005EAADA
	protected override void OnSetToggleState(EToggleState state, bool bFire)
	{
		this.GetTabToggle().SetToggleStateForce(state, bFire, false, false);
	}

	// Token: 0x06015611 RID: 87569 RVA: 0x005EC8EB File Offset: 0x005EAAEB
	protected override void OnRefresh(CommonTabItemData data, bool isSelected, int gridIndex)
	{
		if (data.Data != null)
		{
			base.UpdateTabIcon(data.Data.GetIcon() ?? "");
		}
	}

	// Token: 0x06015612 RID: 87570 RVA: 0x005EC90F File Offset: 0x005EAB0F
	protected override void OnUpdateTabIcon(string iconPath)
	{
	}

	// Token: 0x06015613 RID: 87571 RVA: 0x005EC911 File Offset: 0x005EAB11
	protected override UUIExtendToggle GetTabToggle()
	{
		return base.GetExtendToggle(0);
	}

	// Token: 0x06015614 RID: 87572 RVA: 0x005EC91A File Offset: 0x005EAB1A
	public void UpdateName(string name)
	{
		base.GetText(1).ShowTextNew(name);
	}

	// Token: 0x06015615 RID: 87573 RVA: 0x005EC929 File Offset: 0x005EAB29
	public void UpdateNameText(string name)
	{
		base.GetText(1).SetText(name, true);
	}

	// Token: 0x06015616 RID: 87574 RVA: 0x005EC939 File Offset: 0x005EAB39
	public void UpdateRedDotVisible(bool visible)
	{
		this.GetRedDotItem().SetUIActive(visible);
	}

	// Token: 0x06015617 RID: 87575 RVA: 0x005EC947 File Offset: 0x005EAB47
	private UUIItem GetRedDotItem()
	{
		return base.GetItem(2);
	}

	// Token: 0x06015618 RID: 87576 RVA: 0x005EC950 File Offset: 0x005EAB50
	public void BindRedDot(ERedDotName redDotName, int uId = 0)
	{
		this.UnBindRedDot();
		this.RedDotName = new ERedDotName?(redDotName);
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(this.RedDotName.Value, this.GetRedDotItem(), null, uId);
		}
	}

	// Token: 0x06015619 RID: 87577 RVA: 0x005EC98E File Offset: 0x005EAB8E
	public void BindGivenUid(ERedDotName redDotName, int uId)
	{
		this.RedDotName = new ERedDotName?(redDotName);
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(this.RedDotName.Value, this.GetRedDotItem(), null, uId);
		}
	}

	// Token: 0x0601561A RID: 87578 RVA: 0x005EC9C6 File Offset: 0x005EABC6
	public void UnBindGivenUid(int uId)
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, this.GetRedDotItem(), uId);
		}
	}

	// Token: 0x0601561B RID: 87579 RVA: 0x005EC9F1 File Offset: 0x005EABF1
	public void UnBindRedDot()
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindRedDot(this.RedDotName.Value);
			this.RedDotName = null;
		}
	}

	// Token: 0x0601561C RID: 87580 RVA: 0x005ECA21 File Offset: 0x005EAC21
	protected override void OnBeforeDestroy()
	{
		this.UnBindGivenUid(0);
	}

	// Token: 0x0400A49A RID: 42138
	private ERedDotName? RedDotName;

	// Token: 0x02008D58 RID: 36184
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F874 RID: 194676
		public const int SwitchToggle = 0;

		// Token: 0x0402F875 RID: 194677
		public const int Name = 1;

		// Token: 0x0402F876 RID: 194678
		public const int RedDot = 2;
	}
}
