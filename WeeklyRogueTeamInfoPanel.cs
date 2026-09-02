using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002D3E RID: 11582
public class WeeklyRogueTeamInfoPanel : UiPanelBase
{
	// Token: 0x060175D7 RID: 95703 RVA: 0x0067A8E8 File Offset: 0x00678AE8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnBtnDetail))
		};
	}

	// Token: 0x060175D8 RID: 95704 RVA: 0x0067A994 File Offset: 0x00678B94
	protected override UniTask OnBeforeStartAsync()
	{
		WeeklyRogueTeamInfoPanel.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WeeklyRogueTeamInfoPanel.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060175D9 RID: 95705 RVA: 0x0067A9D7 File Offset: 0x00678BD7
	[NullableContext(1)]
	private WeeklyRogueInfoViewRoleItem CreateRoleItem()
	{
		return new WeeklyRogueInfoViewRoleItem
		{
			OnSelectedCallback = new Action<int>(this.OnSelectRole)
		};
	}

	// Token: 0x060175DA RID: 95706 RVA: 0x0067A9F0 File Offset: 0x00678BF0
	private void OnSelectRole(int index)
	{
		List<SceneTeamItem> teamItems = ModelBase<SceneTeamModel>.Instance.GetTeamItems(false);
		if (teamItems.Count <= 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.WeeklyRogue, ELogAuthor.LPH, "肉鸽属性展示面板, 找不到主控角色实体!", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(teamItems[index].GetConfigId, true);
		ControllerBase<RoleController>.Instance.OnSelectedRoleChange(roleDataById.GetRoleConfig().Id, roleDataById.GetRoleSkinId());
		GenericLayout<WeeklyRogueInfoViewRoleItem, int> roleListLayout = this.RoleListLayout;
		if (roleListLayout != null)
		{
			roleListLayout.SelectGridProxy(index, false);
		}
		this.UpdateAttribute();
	}

	// Token: 0x060175DB RID: 95707 RVA: 0x0067AA84 File Offset: 0x00678C84
	private void OnBtnDetail()
	{
		List<SceneTeamItem> teamItems = ModelBase<SceneTeamModel>.Instance.GetTeamItems(false);
		if (teamItems.Count <= 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.WeeklyRogue, ELogAuthor.LPH, "肉鸽属性展示面板, 找不到主控角色实体!", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(teamItems[this.RoleListLayout.GetSelectedGridIndex()].GetConfigId, true);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WeeklyRogueAttributeDetailView, roleDataById.GetShowAttrList(), null);
	}

	// Token: 0x060175DC RID: 95708 RVA: 0x0067AB00 File Offset: 0x00678D00
	private UniTask InitAttributeItemList()
	{
		WeeklyRogueTeamInfoPanel.<InitAttributeItemList>d__8 <InitAttributeItemList>d__;
		<InitAttributeItemList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitAttributeItemList>d__.<>4__this = this;
		<InitAttributeItemList>d__.<>1__state = -1;
		<InitAttributeItemList>d__.<>t__builder.Start<WeeklyRogueTeamInfoPanel.<InitAttributeItemList>d__8>(ref <InitAttributeItemList>d__);
		return <InitAttributeItemList>d__.<>t__builder.Task;
	}

	// Token: 0x060175DD RID: 95709 RVA: 0x0067AB44 File Offset: 0x00678D44
	protected void UpdateAttribute()
	{
		List<SceneTeamItem> teamItems = ModelBase<SceneTeamModel>.Instance.GetTeamItems(false);
		if (teamItems.Count <= 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.WeeklyRogue, ELogAuthor.LPH, "肉鸽属性展示面板, 找不到主控角色实体!", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(teamItems[this.RoleListLayout.GetSelectedGridIndex()].GetConfigId, true);
		IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("RoleAttributeDisplay6");
		for (int i = 0; i < this.AttributeItemList.Count; i++)
		{
			AttributeItem attributeItem = this.AttributeItemList[i];
			int id = intArrayConfig[i];
			float showAttributeValueById = roleDataById.GetShowAttributeValueById(id);
			attributeItem.SetCurrentValue(showAttributeValueById);
			attributeItem.SetActive(true);
		}
	}

	// Token: 0x0400B36A RID: 45930
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public GenericLayout<WeeklyRogueInfoViewRoleItem, int> RoleListLayout;

	// Token: 0x0400B36B RID: 45931
	[Nullable(1)]
	public List<AttributeItem> AttributeItemList = new List<AttributeItem>();

	// Token: 0x02009001 RID: 36865
	private enum EWeeklyRogueTeamInfoPanelDefine
	{
		// Token: 0x04030510 RID: 197904
		RoleListLayout,
		// Token: 0x04030511 RID: 197905
		AttrPanelItem,
		// Token: 0x04030512 RID: 197906
		AttrItem,
		// Token: 0x04030513 RID: 197907
		BtnDetail,
		// Token: 0x04030514 RID: 197908
		TxtBuffDesc
	}
}
