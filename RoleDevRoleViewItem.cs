using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleDev;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002824 RID: 10276
[NullableContext(1)]
[Nullable(0)]
public class RoleDevRoleViewItem : UiPanelBase
{
	// Token: 0x060144FC RID: 83196 RVA: 0x005A6B44 File Offset: 0x005A4D44
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(6, new Action(this.OnClickCallJumpButton))
		};
	}

	// Token: 0x060144FD RID: 83197 RVA: 0x005A6C74 File Offset: 0x005A4E74
	protected override UniTask OnBeforeStartAsync()
	{
		RoleDevRoleViewItem.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleDevRoleViewItem.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060144FE RID: 83198 RVA: 0x005A6CB7 File Offset: 0x005A4EB7
	protected override void OnBeforeCreateImplement()
	{
		this.UiViewSequence = new UiBehaviorLevelSequence(this);
		base.AddUiBehavior(this.UiViewSequence);
	}

	// Token: 0x060144FF RID: 83199 RVA: 0x005A6CD1 File Offset: 0x005A4ED1
	public void Refresh(RoleDevRoleViewItemDataBase data)
	{
		this.Data = data;
		this.RefreshRoleItemGrid(data);
		this.RefreshName(data);
		this.RefreshCallButton(data);
		this.RefreshGoalLevelAndPanel(data);
		this.RefreshDetailList(data);
	}

	// Token: 0x06014500 RID: 83200 RVA: 0x005A6D00 File Offset: 0x005A4F00
	private void RefreshRoleItemGrid(RoleDevRoleViewItemDataBase data)
	{
		if (RoleDevUtils.GetRoleTypeTagByRoleId(data.RoleId) == global::ERoleTypeTag.Forecast)
		{
			ForecastCharacterSmallItemGrid parameters = new ForecastCharacterSmallItemGrid
			{
				Data = data,
				RoleId = new int?(data.RoleId)
			};
			this.RoleItemGrid.Apply<ForecastCharacterSmallItemGrid>(parameters);
			return;
		}
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(data.RoleId);
		if (roleConfig == null)
		{
			return;
		}
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(data.RoleId);
		int value = (roleInstanceById != null) ? roleInstanceById.GetRoleSkinId() : 0;
		int roleLevel = data.RoleLevel;
		CharacterSmallItemGrid parameters2 = new CharacterSmallItemGrid
		{
			ItemConfigId = new int?(data.RoleId),
			SkinId = new int?(value),
			BottomTextId = "Text_LevelShow_Text",
			BottomTextParameter = new object[]
			{
				roleLevel
			},
			ElementId = new int?(roleConfig.Value.ElementId),
			Data = data
		};
		this.RoleItemGrid.Apply<CharacterSmallItemGrid>(parameters2);
	}

	// Token: 0x06014501 RID: 83201 RVA: 0x005A6E04 File Offset: 0x005A5004
	private void RefreshName(RoleDevRoleViewItemDataBase data)
	{
		base.GetText(1).SetText(data.RoleName, true);
	}

	// Token: 0x06014502 RID: 83202 RVA: 0x005A6E1C File Offset: 0x005A501C
	private void RefreshCallButton(RoleDevRoleViewItemDataBase data)
	{
		base.GetButton(6).RootUIComp.Get().SetUIActive(data.IsCall);
	}

	// Token: 0x06014503 RID: 83203 RVA: 0x005A6E48 File Offset: 0x005A5048
	private void RefreshGoalLevelAndPanel(RoleDevRoleViewItemDataBase data)
	{
		this.SetGoalLevelTextAndPanel(data);
	}

	// Token: 0x06014504 RID: 83204 RVA: 0x005A6E51 File Offset: 0x005A5051
	private void RefreshDetailList(RoleDevRoleViewItemDataBase data)
	{
		this.DetailVerticalLayout.RefreshByData(data.DetailItems, null, false);
	}

	// Token: 0x06014505 RID: 83205 RVA: 0x005A6E68 File Offset: 0x005A5068
	private void SetGoalLevelTextAndPanel(RoleDevRoleViewItemDataBase data)
	{
		base.GetItem(3).SetUIActive(true);
		if (ModelBase<RoleModel>.Instance.GetRoleInstanceById(data.RoleId) == null)
		{
			base.GetText(2).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "RoleProject_TargetLevel", new object[]
			{
				data.RoleGoalUpgradeLevel
			});
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(5);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UUIItem item3 = base.GetItem(7);
			if (item3 != null)
			{
				item3.SetUIActive(true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "RoleProject_Tips07", Array.Empty<object>());
		}
		else if (data.RoleLevel == data.RoleGoalUpgradeLevel && !data.RoleLevelIsMax)
		{
			base.GetText(2).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "RoleProject_Tips04", Array.Empty<object>());
			this.UpdateButtonStateByConditionAndMaterialEnough(data);
			UUIItem item4 = base.GetItem(7);
			if (item4 != null)
			{
				item4.SetUIActive(false);
			}
		}
		else if (data.RoleLevelIsMax)
		{
			base.GetText(2).SetUIActive(false);
			UUIItem item5 = base.GetItem(4);
			if (item5 != null)
			{
				item5.SetUIActive(false);
			}
			UUIItem item6 = base.GetItem(5);
			if (item6 != null)
			{
				item6.SetUIActive(false);
			}
			base.GetItem(7).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "RoleProject_Tips06", Array.Empty<object>());
		}
		else
		{
			base.GetText(2).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "RoleProject_TargetLevel", new object[]
			{
				data.RoleGoalUpgradeLevel
			});
			this.UpdateButtonStateByConditionAndMaterialEnough(data);
			UUIItem item7 = base.GetItem(7);
			if (item7 != null)
			{
				item7.SetUIActive(false);
			}
		}
		if (data.IsForecast)
		{
			base.GetItem(3).SetUIActive(false);
			base.GetText(2).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "RoleProject_TargetLevel", new object[]
			{
				data.RoleGoalUpgradeLevel
			});
		}
	}

	// Token: 0x06014506 RID: 83206 RVA: 0x005A7090 File Offset: 0x005A5290
	private void UpdateButtonStateByConditionAndMaterialEnough(RoleDevRoleViewItemDataBase data)
	{
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(data.RoleId);
		if (roleInstanceById == null)
		{
			return;
		}
		if (!roleInstanceById.GetLevelData().GetRoleNeedBreakUp())
		{
			this.UpdateButtonByMaterialEnough(data);
			return;
		}
		if (ModelBase<RoleModel>.Instance.GetRoleBreachState(data.RoleId) != ERoleBreachState.NoEnoughCondition)
		{
			this.UpdateButtonByMaterialEnough(data);
			return;
		}
		base.GetItem(4).SetUIActive(true);
		base.GetItem(5).SetUIActive(false);
		ButtonItem normalButtonItem = this.NormalButtonItem;
		if (normalButtonItem == null)
		{
			return;
		}
		normalButtonItem.SetLocalTextNew("RoleProject_Button02", Array.Empty<object>());
	}

	// Token: 0x06014507 RID: 83207 RVA: 0x005A711C File Offset: 0x005A531C
	private void UpdateButtonByMaterialEnough(RoleDevRoleViewItemDataBase data)
	{
		if (data.IsAllMaterialEnough)
		{
			base.GetItem(4).SetUIActive(false);
			base.GetItem(5).SetUIActive(true);
			ButtonItem highLightButtonItem = this.HighLightButtonItem;
			if (highLightButtonItem == null)
			{
				return;
			}
			highLightButtonItem.SetLocalTextNew("RoleProject_Button01", Array.Empty<object>());
			return;
		}
		else
		{
			base.GetItem(4).SetUIActive(true);
			base.GetItem(5).SetUIActive(false);
			ButtonItem normalButtonItem = this.NormalButtonItem;
			if (normalButtonItem == null)
			{
				return;
			}
			normalButtonItem.SetLocalTextNew("RoleProject_Button01", Array.Empty<object>());
			return;
		}
	}

	// Token: 0x06014508 RID: 83208 RVA: 0x005A719A File Offset: 0x005A539A
	private RoleDevDetailItem CreateDetailItem()
	{
		return new RoleDevDetailItem();
	}

	// Token: 0x06014509 RID: 83209 RVA: 0x005A71A4 File Offset: 0x005A53A4
	private void InitRoleItemGrid()
	{
		this.RoleItemGrid = new SmallItemGrid();
		this.RoleItemGrid.Initialize(base.GetItem(0).GetOwner());
		this.RoleItemGrid.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.CanExecuteChange));
		this.RoleItemGrid.SetExtendToggleEnable(false, false);
		this.RoleItemGrid.SetToggleInteractive(false);
	}

	// Token: 0x0601450A RID: 83210 RVA: 0x005A7203 File Offset: 0x005A5403
	private void InitDetailVerticalLayout()
	{
		this.DetailVerticalLayout = new GenericLayout<RoleDevDetailItem, global::IRoleDevDetailItemData>(base.GetVerticalLayout(8), new Func<RoleDevDetailItem>(this.CreateDetailItem), null, false, true);
	}

	// Token: 0x0601450B RID: 83211 RVA: 0x005A7226 File Offset: 0x005A5426
	private void InitBtnJumpItem()
	{
		this.NormalButtonItem = new ButtonItem(base.GetItem(4));
		this.NormalButtonItem.SetLocalTextNew("RoleProject_Button01", Array.Empty<object>());
		this.NormalButtonItem.SetFunction(delegate(int _)
		{
			this.OnClickJumpButton();
		});
	}

	// Token: 0x0601450C RID: 83212 RVA: 0x005A7266 File Offset: 0x005A5466
	private void InitBtnPerfectJumpItem()
	{
		this.HighLightButtonItem = new ButtonItem(base.GetItem(5));
		this.HighLightButtonItem.SetLocalTextNew("RoleProject_Button01", Array.Empty<object>());
		this.HighLightButtonItem.SetFunction(delegate(int _)
		{
			this.OnClickJumpButton();
		});
	}

	// Token: 0x0601450D RID: 83213 RVA: 0x005A72A8 File Offset: 0x005A54A8
	private void OnClickJumpButton()
	{
		int roleId = this.Data.RoleId;
		if (ModelBase<RoleModel>.Instance.GetRoleInstanceById(roleId) == null)
		{
			return;
		}
		ControllerBase<RoleDevController>.Instance.LogRoleDevSubPageClick(roleId, ERoleDevMainPage.Role, ERoleDevSubPageButton.RoleGoToCultivation);
		RoleViewViewModel roleViewViewModel = new RoleViewViewModel(roleId, false, ERoleViewSource.Normal);
		roleViewViewModel.FadeInCurveId = ERoleFadeCurveDefine.RoleFadeInCurve;
		roleViewViewModel.FadeOutCurveId = ERoleFadeCurveDefine.RoleFadeOutCurve;
		roleViewViewModel.NeedShowOnViewPlayingStartSequence = true;
		roleViewViewModel.NeedHideOnViewPlayingCloseSequence = true;
		if (this.Data.IsCanUpgrade)
		{
			ControllerBase<RoleController>.Instance.OpenRoleViewByViewModel(EUiViewName.RoleLevelUpView, roleViewViewModel);
			return;
		}
		if (this.Data.IsCanBreach)
		{
			ControllerBase<RoleController>.Instance.OpenRoleViewByViewModel(EUiViewName.RoleBreachView, roleViewViewModel);
		}
	}

	// Token: 0x0601450E RID: 83214 RVA: 0x005A7347 File Offset: 0x005A5547
	private void OnClickCallJumpButton()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.GachaMainView, this.Data.GachaId, null);
	}

	// Token: 0x0601450F RID: 83215 RVA: 0x005A7369 File Offset: 0x005A5569
	[NullableContext(2)]
	private bool CanExecuteChange(object _1, bool _2, EToggleState _3)
	{
		return false;
	}

	// Token: 0x04009DA8 RID: 40360
	[Nullable(2)]
	public UiBehaviorLevelSequence UiViewSequence;

	// Token: 0x04009DA9 RID: 40361
	[Nullable(2)]
	private SmallItemGrid RoleItemGrid;

	// Token: 0x04009DAA RID: 40362
	[Nullable(2)]
	public Action<int> OnClickToggleCallBack;

	// Token: 0x04009DAB RID: 40363
	[Nullable(2)]
	public Func<int, bool> CanClickCallBack;

	// Token: 0x04009DAC RID: 40364
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<RoleDevDetailItem, global::IRoleDevDetailItemData> DetailVerticalLayout;

	// Token: 0x04009DAD RID: 40365
	[Nullable(2)]
	private RoleDevRoleViewItemDataBase Data;

	// Token: 0x04009DAE RID: 40366
	[Nullable(2)]
	private ButtonItem NormalButtonItem;

	// Token: 0x04009DAF RID: 40367
	[Nullable(2)]
	private ButtonItem HighLightButtonItem;

	// Token: 0x02008BB0 RID: 35760
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402F115 RID: 192789
		SmallRoleItem,
		// Token: 0x0402F116 RID: 192790
		TxtRoleName,
		// Token: 0x0402F117 RID: 192791
		TxtGoalLevel,
		// Token: 0x0402F118 RID: 192792
		PanelItemRight,
		// Token: 0x0402F119 RID: 192793
		NormalButtonItem,
		// Token: 0x0402F11A RID: 192794
		HighLightButtonItem,
		// Token: 0x0402F11B RID: 192795
		BtnCallJump,
		// Token: 0x0402F11C RID: 192796
		PanelItemNotObtained,
		// Token: 0x0402F11D RID: 192797
		PanelItemDetailLayout,
		// Token: 0x0402F11E RID: 192798
		PanelItemList,
		// Token: 0x0402F11F RID: 192799
		TxtNotObtained
	}
}
