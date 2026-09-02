using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Common.NumberSelect;
using CSharpScript.Game.Module.Cook;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Manufacture.Common;
using CSharpScript.Game.Module.Manufacture.Common.Item;
using CSharpScript.Game.Module.Manufacture.Compose;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Forging.View
{
	// Token: 0x020059AE RID: 22958
	[NullableContext(1)]
	[Nullable(0)]
	public class ForgingIngredientsVerticalView : UiPanelBase
	{
		// Token: 0x0603A1D8 RID: 238040 RVA: 0x00EB55A3 File Offset: 0x00EB37A3
		public int GetManufactureCount()
		{
			return this.Count;
		}

		// Token: 0x0603A1D9 RID: 238041 RVA: 0x00EB55AC File Offset: 0x00EB37AC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 21;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
		}

		// Token: 0x0603A1DA RID: 238042 RVA: 0x00EB58A4 File Offset: 0x00EB3AA4
		protected override UniTask OnBeforeStartAsync()
		{
			ForgingIngredientsVerticalView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ForgingIngredientsVerticalView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A1DB RID: 238043 RVA: 0x00EB58E8 File Offset: 0x00EB3AE8
		protected override void OnStart()
		{
			base.GetItem(1).SetUIActive(false);
			base.GetText(17).ShowTextNew("PrefabTextItem_MaterialChoose_Text");
			base.GetText(23).ShowTextNew("NeedMaterialTitleText");
			this.UnlockMaterialComponent = new MediumItemGrid();
			this.UnlockMaterialComponent.Initialize(base.GetItem(21).GetOwner());
			this.UnlockMaterialComponent.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
			this.UnlockMaterialComponent.BindOnExtendToggleClicked(delegate(MediumItemGridExtendCallback callbackParameter)
			{
				int itemId = (int)callbackParameter.Data;
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(itemId, true, null);
			});
			UUIItem item = base.GetItem(8);
			this.NumberSelect = new NumberSelectComponent(item);
			INumberSelectData data = new INumberSelectData
			{
				MaxNumber = 0,
				ValueChangeFunction = new Action<int>(this.SetSum)
			};
			this.NumberSelect.Init(data);
			this.NumberSelect.SetNumberSelectTipsVisible(false);
			this.NumberSelect.SetAddReduceButtonActive(true);
			this.SvInfoView.ChangeRoleClickDelegate = new Action(this.OnClickChangeRole);
			this.SvInfoView.SetTypeNameVisible(false);
			base.GetText(12).SetUIActive(false);
		}

		// Token: 0x0603A1DC RID: 238044 RVA: 0x00EB5A25 File Offset: 0x00EB3C25
		protected override void OnBeforeDestroy()
		{
			this.SvInfoView.Destroy(null);
		}

		// Token: 0x0603A1DD RID: 238045 RVA: 0x00EB5A33 File Offset: 0x00EB3C33
		public void BindChangeClickCall(Action func)
		{
			this.ChangeRoleClickCall = func;
		}

		// Token: 0x0603A1DE RID: 238046 RVA: 0x00EB5A3C File Offset: 0x00EB3C3C
		private void OnClickChangeRole()
		{
			if (this.ChangeRoleClickCall != null)
			{
				this.ChangeRoleClickCall();
			}
		}

		// Token: 0x0603A1DF RID: 238047 RVA: 0x00EB5A54 File Offset: 0x00EB3C54
		private ManufactureMaterialItem OnMaterialItemCreate()
		{
			ManufactureMaterialItem manufactureMaterialItem = new ManufactureMaterialItem();
			manufactureMaterialItem.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
			manufactureMaterialItem.BindOnExtendToggleClicked(delegate(MediumItemGridExtendCallback callbackParameter)
			{
				ISingleItemInfo singleItemInfo = (ISingleItemInfo)callbackParameter.Data;
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(singleItemInfo.Proto_ItemId, true, null);
			});
			return manufactureMaterialItem;
		}

		// Token: 0x0603A1E0 RID: 238048 RVA: 0x00EB5AB0 File Offset: 0x00EB3CB0
		private void SetSum(int sum)
		{
			this.Count = sum;
			if (this.ItemData != null)
			{
				int maxCreateCount = ControllerBase<ForgingController>.Instance.GetMaxCreateCount(this.ItemData.ItemId);
				this.NumberSelect.SetAddButtonInteractive(sum < maxCreateCount);
				this.NumberSelect.SetReduceButtonInteractive(sum > 1);
			}
			this.RefreshMaterialNeedNum();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "Text_ItemSelectForgeQuantityTip_text", new <>z__ReadOnlySingleElementList<object>(this.Count));
		}

		// Token: 0x0603A1E1 RID: 238049 RVA: 0x00EB5B30 File Offset: 0x00EB3D30
		private void RefreshMaterialNeedNum()
		{
			this.RefreshCost(this.HasCoin, this.SingleNeedCoinCount * this.Count);
			GenericScrollViewNew<ManufactureMaterialItem, ISingleItemInfo> materialScrollView = this.MaterialScrollView;
			List<ManufactureMaterialItem> list = (materialScrollView != null) ? materialScrollView.GetScrollItemList() : null;
			if (list == null)
			{
				return;
			}
			foreach (ManufactureMaterialItem manufactureMaterialItem in list)
			{
				manufactureMaterialItem.SetTimes(this.Count);
			}
		}

		// Token: 0x0603A1E2 RID: 238050 RVA: 0x00EB5BB4 File Offset: 0x00EB3DB4
		private void RefreshCommon(IWeaponForgingData data)
		{
			this.ItemData = data;
			this.Count = 1;
			int maxCreateCount = Singleton<CommonManager>.Instance.GetMaxCreateCount(this.ItemData.ItemId);
			this.NumberSelect.Refresh(maxCreateCount);
			this.NumberSelect.SetAddReduceButtonActive(true);
			this.NumberSelect.SetReduceButtonInteractive(false);
			this.SvInfoView.SetDescVisible(true);
			this.SvInfoView.SetDescBgVisible(false);
			ForgeFormula? forgeFormulaById = ConfigBase<ForgingConfig>.Instance.GetForgeFormulaById(data.ItemId);
			WeaponConf? weaponItemConfig = ConfigBase<InventoryConfig>.Instance.GetWeaponItemConfig(forgeFormulaById.Value.ItemId);
			string[] weaponConfigDescParams = ModelBase<WeaponModel>.Instance.GetWeaponConfigDescParams(weaponItemConfig.Value, 1);
			string desc = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew(weaponItemConfig.Value.Desc, null), weaponConfigDescParams);
			string descBg = StringUtils.IsEmpty(forgeFormulaById.Value.Background) ? "" : ConfigBase<CookConfig>.Instance.GetLocalText(forgeFormulaById.Value.Background);
			this.SvInfoView.SetDesc(desc);
			this.SvInfoView.SetDescBg(descBg);
			this.ProficiencyViewComponent.SetExpNumVisible(false);
		}

		// Token: 0x0603A1E3 RID: 238051 RVA: 0x00EB5CE0 File Offset: 0x00EB3EE0
		[return: TupleElementNames(new string[]
		{
			"hasCoin",
			"coinCount",
			"list"
		})]
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		private ValueTuple<bool, int, List<ISingleItemInfo>> FilterMaterialList(List<ISingleItemInfo> list)
		{
			bool hasCoin = false;
			int coinCount = 0;
			List<ISingleItemInfo> item = list.Where(delegate(ISingleItemInfo value)
			{
				if (value.Proto_ItemId != ControllerBase<ComposeController>.Instance.ComposeCoinId)
				{
					return true;
				}
				hasCoin = true;
				coinCount = value.Proto_ItemNum;
				return false;
			}).ToList<ISingleItemInfo>();
			return new ValueTuple<bool, int, List<ISingleItemInfo>>(hasCoin, coinCount, item);
		}

		// Token: 0x0603A1E4 RID: 238052 RVA: 0x00EB5D2C File Offset: 0x00EB3F2C
		private void RefreshMaterial()
		{
			if (this.ItemData.IsUnlock > 0)
			{
				base.GetItem(20).SetUIActive(false);
				base.GetItem(18).SetUIActive(true);
				List<ISingleItemInfo> forgingMaterialList = ModelBase<ForgingModel>.Instance.GetForgingMaterialList(this.ItemData.ItemId);
				ValueTuple<bool, int, List<ISingleItemInfo>> valueTuple = this.FilterMaterialList(forgingMaterialList);
				this.MaterialScrollView.RefreshByData(valueTuple.Item3, new Action(this.RefreshMaterialNeedNum), false);
				this.HasCoin = valueTuple.Item1;
				this.SingleNeedCoinCount = valueTuple.Item2;
				return;
			}
			base.GetItem(20).SetUIActive(true);
			base.GetItem(18).SetUIActive(false);
			ForgeFormula? forgeFormulaById = ConfigBase<ForgingConfig>.Instance.GetForgeFormulaById(this.ItemData.ItemId);
			ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(forgeFormulaById.Value.FormulaItemId);
			if (itemConfig == null)
			{
				return;
			}
			PropMediumItemGrid parameters = new PropMediumItemGrid
			{
				Data = forgeFormulaById.Value.FormulaItemId,
				ItemConfigId = new int?(forgeFormulaById.Value.FormulaItemId),
				BottomTextId = itemConfig.Value.Name,
				IsProhibit = new bool?(true),
				IsOmitBottomText = new bool?(true)
			};
			this.UnlockMaterialComponent.Apply<PropMediumItemGrid>(parameters);
		}

		// Token: 0x0603A1E5 RID: 238053 RVA: 0x00EB5E88 File Offset: 0x00EB4088
		private bool CheckDataValid(IWeaponForgingData itemData)
		{
			if (itemData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Compose, ELogAuthor.LK, "缺少itemData数据", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			return true;
		}

		// Token: 0x0603A1E6 RID: 238054 RVA: 0x00EB5EBC File Offset: 0x00EB40BC
		private void SetSelectedRoleTexture()
		{
			int value = Singleton<CommonManager>.Instance.GetCurrentRoleId().Value;
			if (value == 0)
			{
				return;
			}
			this.ProficiencyViewComponent.SetRoleTexture(value);
		}

		// Token: 0x0603A1E7 RID: 238055 RVA: 0x00EB5EEC File Offset: 0x00EB40EC
		private void SetRecommendedRoleTexture(IWeaponForgingData itemData)
		{
			if (!this.CheckDataValid(itemData))
			{
				return;
			}
			int num = Singleton<CommonManager>.Instance.GetCurrentRoleId().Value;
			if (num == 0)
			{
				num = ModelBase<PlayerInfoModel>.Instance.GetPlayerRoleId();
				Singleton<CommonManager>.Instance.SetCurrentRoleId(num);
			}
			if (num == 0)
			{
				return;
			}
			this.ProficiencyViewComponent.SetRoleTexture(num);
		}

		// Token: 0x0603A1E8 RID: 238056 RVA: 0x00EB5F3F File Offset: 0x00EB413F
		public void RefreshHelpRole()
		{
			this.SetSelectedRoleTexture();
		}

		// Token: 0x0603A1E9 RID: 238057 RVA: 0x00EB5F47 File Offset: 0x00EB4147
		public void OnSecondTimerRefresh()
		{
			if (this.ItemData == null)
			{
				return;
			}
			this.RefreshLimitTime(this.ItemData);
		}

		// Token: 0x0603A1EA RID: 238058 RVA: 0x00EB5F60 File Offset: 0x00EB4160
		private void RefreshLimitTime(IWeaponForgingData itemData)
		{
			if (itemData.ExistEndTime <= 0.0)
			{
				base.GetItem(24).SetUIActive(false);
				this.NumberSelect.ResetLimitMaxValue();
				return;
			}
			base.GetItem(24).SetUIActive(true);
			global::CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat(itemData.ExistEndTime - Singleton<TimeUtil>.Instance.GetServerTime());
			base.GetText(25).SetText(remainTimeDataFormat.CountDownText, true);
		}

		// Token: 0x0603A1EB RID: 238059 RVA: 0x00EB5FD8 File Offset: 0x00EB41D8
		private void RefreshLimitCount(IWeaponForgingData itemData)
		{
			if (itemData.TotalMakeCountInLimitTime <= 0)
			{
				base.GetItem(3).SetUIActive(false);
				this.NumberSelect.ResetLimitMaxValue();
				return;
			}
			int num = itemData.TotalMakeCountInLimitTime - itemData.MadeCountInLimitTime;
			this.NumberSelect.SetLimitMaxValue(Math.Max(1, num));
			string text = num.ToString();
			if (num == 0)
			{
				text = StringUtils.Format("<color=#c25757>{0}</color>", new string[]
				{
					num.ToString()
				});
			}
			base.GetItem(3).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "MakeLimit", new <>z__ReadOnlyArray<object>(new object[]
			{
				text,
				itemData.TotalMakeCountInLimitTime
			}));
		}

		// Token: 0x0603A1EC RID: 238060 RVA: 0x00EB6090 File Offset: 0x00EB4290
		private void RefreshCost(bool hasCoin, int count)
		{
			base.GetText(12).GetParentAsUIItem().SetUIActive(hasCoin);
			if (hasCoin)
			{
				int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(ControllerBase<ComposeController>.Instance.ComposeCoinId, 0);
				ItemInfo? config = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetConfig(ControllerBase<ComposeController>.Instance.ComposeCoinId);
				if (itemCountByConfigId < count)
				{
					base.GetText(11).SetText(StringUtils.Format("<color=#c25757>{0}</color>", new string[]
					{
						count.ToString()
					}), true);
				}
				else
				{
					base.GetText(11).SetText(count.ToString(), true);
				}
				base.SetTextureByPath(config.Value.IconSmall, base.GetTexture(13), null, null);
			}
		}

		// Token: 0x0603A1ED RID: 238061 RVA: 0x00EB614C File Offset: 0x00EB434C
		public void RefreshForging(IWeaponForgingData data)
		{
			this.RefreshLimitTime(data);
			this.RefreshLimitCount(data);
			this.RefreshCommon(data);
			this.RefreshMaterial();
			this.SvInfoView.SetWeaponAttribute(data);
			if (data.IsUnlock > 0)
			{
				this.ProficiencyViewComponent.SetActive(false);
				this.SetRecommendedRoleTexture(this.ItemData);
				this.NumberSelect.SetActive(true);
				base.GetItem(22).SetUIActive(false);
				base.GetItem(16).SetUIActive(true);
				base.GetItem(9).SetUIActive(true);
				return;
			}
			this.ProficiencyViewComponent.SetActive(false);
			this.NumberSelect.SetActive(false);
			base.GetItem(22).SetUIActive(true);
			base.GetItem(16).SetUIActive(false);
			base.GetItem(9).SetUIActive(false);
		}

		// Token: 0x04020F64 RID: 135012
		private int Count = 1;

		// Token: 0x04020F65 RID: 135013
		[Nullable(2)]
		private SvInfo SvInfoView;

		// Token: 0x04020F66 RID: 135014
		[Nullable(2)]
		private NumberSelectComponent NumberSelect;

		// Token: 0x04020F67 RID: 135015
		[Nullable(2)]
		private IWeaponForgingData ItemData;

		// Token: 0x04020F68 RID: 135016
		[Nullable(2)]
		private MediumItemGrid UnlockMaterialComponent;

		// Token: 0x04020F69 RID: 135017
		[Nullable(2)]
		private Action ChangeRoleClickCall;

		// Token: 0x04020F6A RID: 135018
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<ManufactureMaterialItem, ISingleItemInfo> MaterialScrollView;

		// Token: 0x04020F6B RID: 135019
		[Nullable(2)]
		private ProficiencyView ProficiencyViewComponent;

		// Token: 0x04020F6C RID: 135020
		private bool HasCoin;

		// Token: 0x04020F6D RID: 135021
		private int SingleNeedCoinCount;

		// Token: 0x0200B96A RID: 47466
		[NullableContext(0)]
		private class EVerticalGroupComponents
		{
			// Token: 0x04039445 RID: 234565
			public const int SvInfo = 0;

			// Token: 0x04039446 RID: 234566
			public const int PnlLimit = 1;

			// Token: 0x04039447 RID: 234567
			public const int TxtLimitNum = 2;

			// Token: 0x04039448 RID: 234568
			public const int PnlQuota = 3;

			// Token: 0x04039449 RID: 234569
			public const int TxtQuotaNum = 4;

			// Token: 0x0403944A RID: 234570
			public const int AmountItem = 8;

			// Token: 0x0403944B RID: 234571
			public const int PnlCost = 9;

			// Token: 0x0403944C RID: 234572
			public const int MakeCount = 10;

			// Token: 0x0403944D RID: 234573
			public const int TxtCost = 11;

			// Token: 0x0403944E RID: 234574
			public const int TxtPlace = 12;

			// Token: 0x0403944F RID: 234575
			public const int ImgCostIcon = 13;

			// Token: 0x04039450 RID: 234576
			public const int PnlTitle = 16;

			// Token: 0x04039451 RID: 234577
			public const int TxtMaterialBarTitle = 17;

			// Token: 0x04039452 RID: 234578
			public const int PnlLeftItem = 18;

			// Token: 0x04039453 RID: 234579
			public const int MaterialScrollView = 19;

			// Token: 0x04039454 RID: 234580
			public const int PnlCenterItem = 20;

			// Token: 0x04039455 RID: 234581
			public const int LockGrid = 21;

			// Token: 0x04039456 RID: 234582
			public const int PnlLock = 22;

			// Token: 0x04039457 RID: 234583
			public const int TxtLock = 23;

			// Token: 0x04039458 RID: 234584
			public const int PnlLimitedTime = 24;

			// Token: 0x04039459 RID: 234585
			public const int TxtTime = 25;

			// Token: 0x0403945A RID: 234586
			public const int ProficiencyView = 26;
		}
	}
}
