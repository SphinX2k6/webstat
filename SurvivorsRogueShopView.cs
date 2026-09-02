using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002B84 RID: 11140
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueShopView : UiViewBase, ISurvivorsRogueCommandView
{
	// Token: 0x17001CE4 RID: 7396
	// (get) Token: 0x060162DD RID: 90845 RVA: 0x006275FB File Offset: 0x006257FB
	int ISurvivorsRogueCommandView.CommandIncId
	{
		get
		{
			return this.CommandIncId;
		}
	}

	// Token: 0x17001CE5 RID: 7397
	// (get) Token: 0x060162DE RID: 90846 RVA: 0x00627603 File Offset: 0x00625803
	SurvivorsRogueCommandBase ISurvivorsRogueCommandView.Command
	{
		get
		{
			return this.Command;
		}
	}

	// Token: 0x060162DF RID: 90847 RVA: 0x0062760B File Offset: 0x0062580B
	public SurvivorsRogueShopView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x060162E0 RID: 90848 RVA: 0x0062761C File Offset: 0x0062581C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUITexture)),
			new ValueTuple<int, Type>(6, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickBtnRefresh)),
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickBtnConfirm))
		};
	}

	// Token: 0x060162E1 RID: 90849 RVA: 0x00627709 File Offset: 0x00625909
	public void CloseView()
	{
		base.CloseMe(null);
	}

	// Token: 0x060162E2 RID: 90850 RVA: 0x00627714 File Offset: 0x00625914
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.SurvivorsRogueRoleGainUpdate, new Action<int>(this.RefreshRoleGain));
		Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.SurvivorsRogueWeaponGainUpdate, new Action<int, bool>(this.RefreshWeaponGain));
		ModelBase<SurvivorsRogueModel>.Instance.BattleData.BehaviorDelegate.AddTreeVarUpdateDelegate(ESurvivorsRougeSystemVarType.Gold.ToEnumString(), new TTreeVarUpdateDelegate(this.RefreshCurrency));
	}

	// Token: 0x060162E3 RID: 90851 RVA: 0x00627780 File Offset: 0x00625980
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.SurvivorsRogueRoleGainUpdate, new Action<int>(this.RefreshRoleGain));
		Singleton<EventSystem>.Instance.Remove<int, bool>(EEventName.SurvivorsRogueWeaponGainUpdate, new Action<int, bool>(this.RefreshWeaponGain));
		ModelBase<SurvivorsRogueModel>.Instance.BattleData.BehaviorDelegate.RemoveTreeVarUpdateDelegate(ESurvivorsRougeSystemVarType.Gold.ToEnumString(), new TTreeVarUpdateDelegate(this.RefreshCurrency));
	}

	// Token: 0x060162E4 RID: 90852 RVA: 0x006277EB File Offset: 0x006259EB
	private void OnPurchase(GoodsDetail data)
	{
		if (this.Command.IsFinished)
		{
			return;
		}
		this.Command.RequestCommand(new int[]
		{
			data.SurvivorsGainData.IncId
		}, null);
	}

	// Token: 0x060162E5 RID: 90853 RVA: 0x0062781C File Offset: 0x00625A1C
	private void OnLock(GoodsDetail data, bool bLock)
	{
		this.Command.RequestLock(data.SurvivorsGainData.IncId, bLock, delegate(bool success)
		{
			if (!success)
			{
				return;
			}
			data.IsLock = bLock;
			GenericLayout<SurvivorsRogueCardShopItem, GoodsDetail> cardList = this.CardList;
			if (cardList == null)
			{
				return;
			}
			SurvivorsRogueCardShopItem layoutItemByKey = cardList.GetLayoutItemByKey(data.SurvivorsGainData.IncId);
			if (layoutItemByKey == null)
			{
				return;
			}
			SurvivorsRogueCardBase cardItem = layoutItemByKey.CardItem;
			if (cardItem == null)
			{
				return;
			}
			cardItem.SetLock(bLock);
		});
	}

	// Token: 0x060162E6 RID: 90854 RVA: 0x00627874 File Offset: 0x00625A74
	private void OnClickBtnRefresh()
	{
		ISurvivorsShopViewInfo viewInfo = this.Command.GetViewInfo();
		if (ModelBase<SurvivorsRogueModel>.Instance.BattleData.GetCurrencyCount() < viewInfo.RefreshCost)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("SurvivorsStore_InsufficientCurrencyTips", Array.Empty<object>());
			return;
		}
		this.RefreshDirty = true;
		this.Command.RequestCommand(new int[]
		{
			-1
		}, null);
	}

	// Token: 0x060162E7 RID: 90855 RVA: 0x006278DC File Offset: 0x00625ADC
	private void OnClickBtnConfirm()
	{
		if (!ModelBase<SurvivorsRogueModel>.Instance.NotTipsShopPurchaseAvailable && this.Command.IsShopPurchaseAvailable())
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ShopPurchaseAvailableConfirm);
			confirmBoxDataNew.HasToggle = true;
			confirmBoxDataNew.ToggleTextKey = "SurvivorsShopConfirmationDialog_PrompText";
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				this.Command.Execute();
			};
			confirmBoxDataNew.SetToggleFunction(delegate(bool isSelectOn)
			{
				ModelBase<SurvivorsRogueModel>.Instance.NotTipsShopPurchaseAvailable = isSelectOn;
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		this.Command.Execute();
	}

	// Token: 0x060162E8 RID: 90856 RVA: 0x00627974 File Offset: 0x00625B74
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsRogueShopView.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsRogueShopView.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060162E9 RID: 90857 RVA: 0x006279B7 File Offset: 0x00625BB7
	protected override void OnBeforeDestroy()
	{
		SurvivorsRogueCommandShop command = this.Command;
		if (command == null)
		{
			return;
		}
		command.BindView(null);
	}

	// Token: 0x060162EA RID: 90858 RVA: 0x006279CA File Offset: 0x00625BCA
	private SurvivorsRogueCardShopItem CreateCardItem()
	{
		return new SurvivorsRogueCardShopItem
		{
			OnPurchaseBtnClickCallback = new Action<GoodsDetail>(this.OnPurchase),
			OnClickLockCallback = new Action<GoodsDetail, bool>(this.OnLock),
			OnStateChangeCallback = new Action<GoodsDetail, bool>(this.OnStateChangeCallback)
		};
	}

	// Token: 0x060162EB RID: 90859 RVA: 0x00627A07 File Offset: 0x00625C07
	private void OnStateChangeCallback(GoodsDetail data, bool bChosen)
	{
		this.CardList.DeselectCurrentGridProxy();
		this.OnCurrentSelectGoodsStateChange(false);
		if (bChosen)
		{
			this.CardList.SelectGridProxy(data.Index, false);
			this.CurrentSelectGoodsInfo = data;
			this.OnCurrentSelectGoodsStateChange(true);
		}
	}

	// Token: 0x060162EC RID: 90860 RVA: 0x00627A40 File Offset: 0x00625C40
	public void Refresh()
	{
		UiAsyncTask task = new UiAsyncTask("SurvivorsRogueShopView.Refresh", delegate()
		{
			SurvivorsRogueShopView.<<Refresh>b__24_0>d <<Refresh>b__24_0>d;
			<<Refresh>b__24_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<Refresh>b__24_0>d.<>4__this = this;
			<<Refresh>b__24_0>d.<>1__state = -1;
			<<Refresh>b__24_0>d.<>t__builder.Start<SurvivorsRogueShopView.<<Refresh>b__24_0>d>(ref <<Refresh>b__24_0>d);
			return <<Refresh>b__24_0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task);
	}

	// Token: 0x060162ED RID: 90861 RVA: 0x00627A70 File Offset: 0x00625C70
	private UniTask RefreshAsync()
	{
		SurvivorsRogueShopView.<RefreshAsync>d__25 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<SurvivorsRogueShopView.<RefreshAsync>d__25>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060162EE RID: 90862 RVA: 0x00627AB3 File Offset: 0x00625CB3
	private void RefreshCurrency(VarDefinePb lastVarDefine, VarDefinePb newVarDefine)
	{
		this.RefreshCurrency();
	}

	// Token: 0x060162EF RID: 90863 RVA: 0x00627ABC File Offset: 0x00625CBC
	private void RefreshCurrency()
	{
		bool flag = ModelBase<SurvivorsRogueModel>.Instance.BattleData.GetCurrencyCount() >= this.RefreshCurrencyCount;
		UUIText text = base.GetText(6);
		UUIItem uuiitem = text;
		bool bUseChangeColor = !flag;
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
	}

	// Token: 0x060162F0 RID: 90864 RVA: 0x00627B04 File Offset: 0x00625D04
	private void OnCurrentSelectGoodsStateChange(bool bSelected)
	{
		if (this.CurrentSelectGoodsInfo != null)
		{
			Aki.Protocol.SurvivorsGainData survivorsGainData = this.CurrentSelectGoodsInfo.SurvivorsGainData;
			string a = survivorsGainData.DataCase.ToString();
			if (!(a == "Proto_SurvivorsRoleLv"))
			{
				if (!(a == "Proto_SurvivorsWeaponLv"))
				{
					return;
				}
				int weaponId = survivorsGainData.SurvivorsWeaponLv.WeaponId;
				SurvivorsWeapon survivorsWeapon = survivorsGainData.SurvivorsWeaponLv.SurvivorsWeapon;
				if (bSelected && (survivorsWeapon.Level == survivorsWeapon.MaxLevel || this.CurrentSelectGoodsInfo.IsSell))
				{
					return;
				}
				SurvivorsRogueWeaponStateGrid weaponGrid = this.BaseItem.RoleStatePanel.GetWeaponGrid(weaponId);
				if (weaponGrid == null)
				{
					return;
				}
				weaponGrid.SetSelectOn(bSelected);
			}
			else
			{
				SurvivorsRole survivorsRole = survivorsGainData.SurvivorsRoleLv.SurvivorsRole;
				if (bSelected && (survivorsRole.Level == survivorsRole.MaxLevel || this.CurrentSelectGoodsInfo.IsSell))
				{
					return;
				}
				SurvivorsRogueRoleInfoGrid roleGrid = this.BaseItem.RoleStatePanel.RoleGrid;
				if (roleGrid == null)
				{
					return;
				}
				roleGrid.SetSelectOn(bSelected);
				return;
			}
		}
	}

	// Token: 0x060162F1 RID: 90865 RVA: 0x00627BF7 File Offset: 0x00625DF7
	private void RefreshRoleGain(int roleId)
	{
		SurvivorsRogueRoleInfoGrid roleGrid = this.BaseItem.RoleStatePanel.RoleGrid;
		if (roleGrid == null)
		{
			return;
		}
		roleGrid.SetLevelUp();
	}

	// Token: 0x060162F2 RID: 90866 RVA: 0x00627C13 File Offset: 0x00625E13
	private void RefreshWeaponGain(int weaponId, bool isLevelUp)
	{
		if (!isLevelUp)
		{
			return;
		}
		SurvivorsRogueWeaponStateGrid weaponGrid = this.BaseItem.RoleStatePanel.GetWeaponGrid(weaponId);
		if (weaponGrid == null)
		{
			return;
		}
		weaponGrid.SetLevelUp();
	}

	// Token: 0x060162F3 RID: 90867 RVA: 0x00627C34 File Offset: 0x00625E34
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
		string a = configParams[0];
		if (a == "ShopCardLock")
		{
			GenericLayout<SurvivorsRogueCardShopItem, GoodsDetail> cardList = this.CardList;
			SurvivorsRogueCardShopItem survivorsRogueCardShopItem = (cardList != null) ? cardList.GetLayoutItemByIndex(0) : null;
			UUIItem uuiitem;
			if (survivorsRogueCardShopItem == null)
			{
				uuiitem = null;
			}
			else
			{
				SurvivorsRogueCardBase cardItem = survivorsRogueCardShopItem.CardItem;
				uuiitem = ((cardItem != null) ? cardItem.GetGuideUiItem("0") : null);
			}
			UUIItem uuiitem2 = uuiitem;
			if (uuiitem2 == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem2,
				uuiitem2
			};
		}
		else
		{
			if (a == "SurvivorFightInfo")
			{
				if (configParams.Length < 3)
				{
					return null;
				}
				string a2 = configParams[2];
				if (a2 == "FirstWeapon")
				{
					SurvivorsRogueViewBase baseItem = this.BaseItem;
					if (baseItem == null)
					{
						return null;
					}
					SurvivorsRogueRoleStatePanel roleStatePanel = baseItem.RoleStatePanel;
					if (roleStatePanel == null)
					{
						return null;
					}
					return roleStatePanel.GetGuideUiItemAndUiItemForShowEx(configParams);
				}
				else if (a2 == "FirstTwoWeapon")
				{
					UUIItem guideUiItem = base.GetGuideUiItem("3");
					if (guideUiItem == null)
					{
						return null;
					}
					return new UUIItem[]
					{
						guideUiItem,
						guideUiItem
					};
				}
			}
			if (!(a == "EvolveBar"))
			{
				return null;
			}
			GenericLayout<SurvivorsRogueCardShopItem, GoodsDetail> cardList2 = this.CardList;
			SurvivorsRogueCardShopItem survivorsRogueCardShopItem2 = (cardList2 != null) ? cardList2.GetLayoutItemByIndex(0) : null;
			if (survivorsRogueCardShopItem2 == null)
			{
				return null;
			}
			return survivorsRogueCardShopItem2.GetGuideUiItemAndUiItemForShowEx(configParams);
		}
	}

	// Token: 0x0400ABB0 RID: 43952
	public int CommandIncId;

	// Token: 0x0400ABB1 RID: 43953
	public SurvivorsRogueCommandShop Command;

	// Token: 0x0400ABB2 RID: 43954
	[Nullable(2)]
	private SurvivorsRogueViewBase BaseItem;

	// Token: 0x0400ABB3 RID: 43955
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<SurvivorsRogueCardShopItem, GoodsDetail> CardList;

	// Token: 0x0400ABB4 RID: 43956
	private bool RefreshDirty = true;

	// Token: 0x0400ABB5 RID: 43957
	[Nullable(2)]
	private GoodsDetail CurrentSelectGoodsInfo;

	// Token: 0x0400ABB6 RID: 43958
	private int RefreshCurrencyCount;
}
