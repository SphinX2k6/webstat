using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.RogueBattle;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002772 RID: 10098
[NullableContext(2)]
[Nullable(0)]
public class RogueBattleBuyRoleItem : UiPanelBase
{
	// Token: 0x06013EC5 RID: 81605 RVA: 0x0058D564 File Offset: 0x0058B764
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUITexture)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggleSelf))
		};
	}

	// Token: 0x06013EC6 RID: 81606 RVA: 0x0058D6EF File Offset: 0x0058B8EF
	protected override void OnStart()
	{
		base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.OnCanExecuteChange));
		this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
	}

	// Token: 0x06013EC7 RID: 81607 RVA: 0x0058D720 File Offset: 0x0058B920
	protected override UniTask OnBeforeStartAsync()
	{
		RogueBattleBuyRoleItem.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattleBuyRoleItem.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013EC8 RID: 81608 RVA: 0x0058D764 File Offset: 0x0058B964
	private bool OnCanExecuteChange()
	{
		EToggleState toggleState = base.GetExtendToggle(0).GetToggleState();
		RogueResGainData data = this.Data;
		return data == null || !data.RogueResRole.IsSell || toggleState != EToggleState.ETT_UnChecked;
	}

	// Token: 0x06013EC9 RID: 81609 RVA: 0x0058D79D File Offset: 0x0058B99D
	private void OnClickToggleSelf(EToggleState state)
	{
		if (this.Data != null)
		{
			Action<int, RogueResGainData> onSelectCallback = this.OnSelectCallback;
			if (onSelectCallback == null)
			{
				return;
			}
			onSelectCallback(this.GridIndex, this.Data);
		}
	}

	// Token: 0x06013ECA RID: 81610 RVA: 0x0058D7C4 File Offset: 0x0058B9C4
	public void Refresh(RogueResGainData data, bool isSelected, int gridIndex)
	{
		RogueBattleBuyRoleItem.<>c__DisplayClass12_0 CS$<>8__locals1 = new RogueBattleBuyRoleItem.<>c__DisplayClass12_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.isSelected = isSelected;
		this.GridIndex = gridIndex;
		this.Data = data;
		base.GetExtendToggle(0).RootUIComp.Get().SetUIActive(data != null);
		base.GetItem(12).SetUIActive(data == null);
		if (data == null)
		{
			return;
		}
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(data.RogueResRole.RoleIdOrTrialRoleId, true);
		if (roleDataById == null)
		{
			return;
		}
		RogueResRole roleInfoById = ModelBase<RogueBattleModel>.Instance.GetRoleInfoById(data.RogueResRole.RoleIdOrTrialRoleId);
		CS$<>8__locals1.roleConfig = roleDataById.GetRoleConfig();
		int roleSkinId = roleDataById.GetRoleSkinId();
		RoleSkin? roleSkinConfig = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(roleSkinId);
		bool isSell = data.RogueResRole.IsSell;
		CS$<>8__locals1.roleMaxStar = ModelBase<RogueBattleModel>.Instance.MaxRoleStar;
		CS$<>8__locals1.roleCurStar = ((roleInfoById != null) ? roleInfoById.Level : 0);
		CS$<>8__locals1.roleUpStar = ((!isSell) ? data.RogueResRole.Level : 0);
		base.GetExtendToggle(0).SetToggleState(CS$<>8__locals1.isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		base.SetTextureShowUntilLoaded(roleSkinConfig.Value.FormationRoleCard, base.GetTexture(1), null);
		this.ElementItem.Refresh(CS$<>8__locals1.roleConfig.ElementId, false, 0);
		base.GetItem(2).SetUIActive(CS$<>8__locals1.roleCurStar == 0 && !isSell);
		base.GetItem(13).SetUIActive(CS$<>8__locals1.roleCurStar > 0 && !isSell);
		base.GetItem(11).SetUIActive(isSell);
		int curPrice = data.RogueResRole.CurPrice;
		int sourcePrice = data.RogueResRole.SourcePrice;
		UUIText text = base.GetText(9);
		UUIText text2 = base.GetText(10);
		int itemId = data.RogueResRole.ItemId;
		text.SetText(curPrice.ToString(), true);
		text2.SetUIActive(curPrice != sourcePrice);
		text2.SetText(sourcePrice.ToString(), true);
		int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(itemId, 0);
		UUIItem uuiitem = text;
		bool bUseChangeColor = itemCountByConfigId < curPrice;
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		base.GetItem(7).SetUIActive(!isSell);
		base.SetItemIcon(base.GetTexture(8), itemId, null, null);
		UiAsyncTask task = new UiAsyncTask("RogueBattleBuyRoleItem.Refresh", delegate()
		{
			RogueBattleBuyRoleItem.<>c__DisplayClass12_0.<<Refresh>b__0>d <<Refresh>b__0>d;
			<<Refresh>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<Refresh>b__0>d.<>4__this = CS$<>8__locals1;
			<<Refresh>b__0>d.<>1__state = -1;
			<<Refresh>b__0>d.<>t__builder.Start<RogueBattleBuyRoleItem.<>c__DisplayClass12_0.<<Refresh>b__0>d>(ref <<Refresh>b__0>d);
			return <<Refresh>b__0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task);
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
	}

	// Token: 0x06013ECB RID: 81611 RVA: 0x0058DA57 File Offset: 0x0058BC57
	public void OnSelected()
	{
		if (this.Data == null)
		{
			return;
		}
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		this.SetFetterSelectOn(true);
		this.SetStarLayoutSelectOn(true);
	}

	// Token: 0x06013ECC RID: 81612 RVA: 0x0058DA81 File Offset: 0x0058BC81
	public void OnDeselected()
	{
		if (this.Data == null)
		{
			return;
		}
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		this.SetFetterSelectOn(false);
		this.SetStarLayoutSelectOn(false);
	}

	// Token: 0x06013ECD RID: 81613 RVA: 0x0058DAAC File Offset: 0x0058BCAC
	private void SetFetterSelectOn(bool bOn)
	{
		foreach (RogueBattleFetterIconItem rogueBattleFetterIconItem in this.FetterLayout.GetLayoutItemList())
		{
			rogueBattleFetterIconItem.RefreshSelectState(bOn);
		}
	}

	// Token: 0x06013ECE RID: 81614 RVA: 0x0058DB04 File Offset: 0x0058BD04
	private void SetStarLayoutSelectOn(bool bOn)
	{
		if (this.Data == null)
		{
			return;
		}
		if (this.Data.RogueResRole.IsSell)
		{
			return;
		}
		RogueResRole roleInfoById = ModelBase<RogueBattleModel>.Instance.GetRoleInfoById(this.Data.RogueResRole.RoleIdOrTrialRoleId);
		int maxRoleStar = ModelBase<RogueBattleModel>.Instance.MaxRoleStar;
		int level = this.Data.RogueResRole.Level;
		int num = (roleInfoById != null) ? roleInfoById.Level : 0;
		int num2 = Math.Min(num + level, maxRoleStar);
		for (int i = num; i < num2; i++)
		{
			RogueBattleStarItem layoutItemByIndex = this.StarLayout.GetLayoutItemByIndex(i);
			if (layoutItemByIndex != null)
			{
				layoutItemByIndex.SetPreviewAnimOn(bOn);
			}
		}
	}

	// Token: 0x06013ECF RID: 81615 RVA: 0x0058DB9C File Offset: 0x0058BD9C
	public override UUIItem GetOriginalItem()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return null;
		}
		return extendToggle.GetRootComponent();
	}

	// Token: 0x06013ED0 RID: 81616 RVA: 0x0058DBB0 File Offset: 0x0058BDB0
	[NullableContext(1)]
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length == 0)
		{
			return null;
		}
		if (!(configParams[0] == "FirstRole"))
		{
			return null;
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		UUIItem uuiitem = (extendToggle != null) ? extendToggle.GetRootComponent() : null;
		if (uuiitem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uuiitem,
			uuiitem
		};
	}

	// Token: 0x04009B0D RID: 39693
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04009B0E RID: 39694
	private RogueResGainData Data;

	// Token: 0x04009B0F RID: 39695
	private int GridIndex = -1;

	// Token: 0x04009B10 RID: 39696
	private RogueBattleTokenElement ElementItem;

	// Token: 0x04009B11 RID: 39697
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<RogueBattleFetterIconItem, RogueBattleRoleBondUpdateInfo> FetterLayout;

	// Token: 0x04009B12 RID: 39698
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<RogueBattleStarItem, bool> StarLayout;

	// Token: 0x04009B13 RID: 39699
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<int, RogueResGainData> OnSelectCallback;

	// Token: 0x02008B2B RID: 35627
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0402EEC5 RID: 192197
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Comparison<RogueBattleRoleBondUpdateInfo> <0>__SortRogueBattleRoleBondUpdateInfo;
	}
}
