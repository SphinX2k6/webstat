using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleDev;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002845 RID: 10309
[NullableContext(2)]
[Nullable(0)]
public class RoleDevWeaponViewItem : UiPanelBase
{
	// Token: 0x0601473F RID: 83775 RVA: 0x005AE24C File Offset: 0x005AC44C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06014740 RID: 83776 RVA: 0x005AE288 File Offset: 0x005AC488
	protected override UniTask OnBeforeStartAsync()
	{
		RoleDevWeaponViewItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleDevWeaponViewItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014741 RID: 83777 RVA: 0x005AE2CB File Offset: 0x005AC4CB
	protected override void OnBeforeCreateImplement()
	{
		this.UiViewSequence = new UiBehaviorLevelSequence(this);
		base.AddUiBehavior(this.UiViewSequence);
	}

	// Token: 0x06014742 RID: 83778 RVA: 0x005AE2E5 File Offset: 0x005AC4E5
	[NullableContext(1)]
	public void RefreshByData(RoleDevWeaponViewItemDataBase data)
	{
		this.Data = data;
		this.Refresh();
	}

	// Token: 0x06014743 RID: 83779 RVA: 0x005AE2F4 File Offset: 0x005AC4F4
	public void Refresh()
	{
		ERoleDevWeaponTabType tabType = this.Data.TabType;
		if (tabType == ERoleDevWeaponTabType.WeaponDev)
		{
			this.WeaponDevItem.Refresh(this.Data.DevItemData);
			base.GetItem(0).SetUIActive(true);
			base.GetItem(1).SetUIActive(false);
		}
		if (tabType == ERoleDevWeaponTabType.WeaponRecommend)
		{
			this.WeaponRecommendItem.Refresh(this.Data.RecommendItemData);
			base.GetItem(0).SetUIActive(false);
			base.GetItem(1).SetUIActive(true);
		}
	}

	// Token: 0x06014744 RID: 83780 RVA: 0x005AE373 File Offset: 0x005AC573
	public void SetType(ERoleDevWeaponTabType type)
	{
		this.Data.TabType = type;
		if (type == ERoleDevWeaponTabType.WeaponRecommend)
		{
			ControllerBase<RoleDevController>.Instance.LogRoleDevSubPageClick(this.Data.RoleId, ERoleDevMainPage.Weapon, ERoleDevSubPageButton.ViewRecommendedWeapons);
		}
		this.Refresh();
	}

	// Token: 0x04009E21 RID: 40481
	public UiBehaviorLevelSequence UiViewSequence;

	// Token: 0x04009E22 RID: 40482
	private RoleDevWeaponDevItem WeaponDevItem;

	// Token: 0x04009E23 RID: 40483
	private RoleDevWeaponRecommendItem WeaponRecommendItem;

	// Token: 0x04009E24 RID: 40484
	private RoleDevWeaponViewItemDataBase Data;

	// Token: 0x02008BCF RID: 35791
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402F1BD RID: 192957
		PlanWeaponDevelop,
		// Token: 0x0402F1BE RID: 192958
		PlanWeaponRecommend
	}
}
