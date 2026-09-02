using System;
using System.Collections.Generic;
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
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Compose.View
{
	// Token: 0x020059C8 RID: 22984
	[NullableContext(1)]
	[Nullable(0)]
	public class ComposeIngredientsVerticalView : UiPanelBase
	{
		// Token: 0x0603A38F RID: 238479 RVA: 0x00EC018A File Offset: 0x00EBE38A
		public int GetManufactureCount()
		{
			return this.Count;
		}

		// Token: 0x0603A390 RID: 238480 RVA: 0x00EC0194 File Offset: 0x00EBE394
		protected unsafe override void OnRegisterComponent()
		{
			int num = 22;
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
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

		// Token: 0x0603A391 RID: 238481 RVA: 0x00EC04B0 File Offset: 0x00EBE6B0
		protected override UniTask OnBeforeStartAsync()
		{
			ComposeIngredientsVerticalView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ComposeIngredientsVerticalView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A392 RID: 238482 RVA: 0x00EC04F4 File Offset: 0x00EBE6F4
		protected override void OnStart()
		{
			this.SvInfoView.SetActive(true);
			base.GetItem(1).SetUIActive(false);
			base.GetItem(9).SetUIActive(true);
			base.GetItem(22).SetUIActive(false);
			base.GetItem(16).SetUIActive(true);
			base.GetText(23).ShowTextNew("NeedMaterialTitleText");
			base.GetText(17).ShowTextNew("PrefabTextItem_MaterialChoose_Text");
			base.GetItem(18).SetUIActive(true);
			UUIItem item = base.GetItem(8);
			this.NumberSelect = new NumberSelectComponent(item);
			INumberSelectData data = new INumberSelectData
			{
				MaxNumber = 0,
				ValueChangeFunction = new Action<int>(this.SetSum)
			};
			this.NumberSelect.Init(data);
			this.NumberSelect.SetUiActive(true);
			this.NumberSelect.SetNumberSelectTipsVisible(false);
			this.NumberSelect.SetAddReduceButtonActive(true);
			base.GetText(12).SetUIActive(false);
			this.UnlockMaterialComponent = new MediumItemGrid();
			this.UnlockMaterialComponent.Initialize(base.GetItem(21).GetOwner());
			this.UnlockMaterialComponent.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
			this.UnlockMaterialComponent.BindOnExtendToggleClicked(delegate(MediumItemGridExtendCallback callbackParameter)
			{
				int itemId = (int)callbackParameter.Data;
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(itemId, true, null);
			});
		}

		// Token: 0x0603A393 RID: 238483 RVA: 0x00EC0660 File Offset: 0x00EBE860
		private void SetSum(int sum)
		{
			this.Count = sum;
			this.RefreshMaterialNeedNum();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "Text_ItemSelectSynthesisQuantityTip_text", new <>z__ReadOnlySingleElementList<object>(this.Count));
			if (this.ItemData != null && this.ItemData is IReagentProductionData)
			{
				int maxCreateCount = ControllerBase<ComposeController>.Instance.GetMaxCreateCount(this.ItemData.ConfigId, null);
				this.NumberSelect.SetAddButtonInteractive(sum < maxCreateCount);
				this.NumberSelect.SetReduceButtonInteractive(sum > 1);
				this.RefreshProficiency((IReagentProductionData)this.ItemData);
			}
		}

		// Token: 0x0603A394 RID: 238484 RVA: 0x00EC06FC File Offset: 0x00EBE8FC
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

		// Token: 0x0603A395 RID: 238485 RVA: 0x00EC0780 File Offset: 0x00EBE980
		protected override void OnBeforeDestroy()
		{
			this.SvInfoView = null;
		}

		// Token: 0x0603A396 RID: 238486 RVA: 0x00EC0789 File Offset: 0x00EBE989
		private void OnClickChangeRole()
		{
			if (this.ChangeRoleClickCall != null)
			{
				this.ChangeRoleClickCall();
			}
		}

		// Token: 0x0603A397 RID: 238487 RVA: 0x00EC07A0 File Offset: 0x00EBE9A0
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

		// Token: 0x0603A398 RID: 238488 RVA: 0x00EC07FC File Offset: 0x00EBE9FC
		private void SetTypeName(string tag)
		{
			string textById = ConfigBase<TextConfig>.Instance.GetTextById(tag);
			this.SvInfoView.SetTypeName(null);
			this.ProficiencyViewComponent.SetTypeContent(textById);
		}

		// Token: 0x0603A399 RID: 238489 RVA: 0x00EC082D File Offset: 0x00EBEA2D
		private void SetExpNum(int count, int single, int sum, int times)
		{
			this.ProficiencyViewComponent.SetExpNum(count, single, sum, times);
		}

		// Token: 0x0603A39A RID: 238490 RVA: 0x00EC0840 File Offset: 0x00EBEA40
		private bool CheckDataValid(IBaseItemData itemData)
		{
			if (itemData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Compose, ELogAuthor.LK, "缺少itemData数据", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			return true;
		}

		// Token: 0x0603A39B RID: 238491 RVA: 0x00EC0874 File Offset: 0x00EBEA74
		private void SetSelectedRoleTexture(int itemId)
		{
			int? currentRoleId = Singleton<CommonManager>.Instance.GetCurrentRoleId();
			if (currentRoleId == null)
			{
				return;
			}
			this.ProficiencyViewComponent.SetRoleTexture(currentRoleId.Value, itemId);
		}

		// Token: 0x0603A39C RID: 238492 RVA: 0x00EC08AC File Offset: 0x00EBEAAC
		private void SetRecommendedRoleTexture(IBaseItemData itemData)
		{
			if (!this.CheckDataValid(itemData))
			{
				return;
			}
			int num = Singleton<CommonManager>.Instance.GetCurrentRoleId().Value;
			if (num == 0)
			{
				num = Singleton<CommonManager>.Instance.GetManufactureRoleId(itemData.ConfigId).Value;
				Singleton<CommonManager>.Instance.SetCurrentRoleId(num);
			}
			if (num == 0)
			{
				num = ModelBase<PlayerInfoModel>.Instance.GetPlayerRoleId();
				Singleton<CommonManager>.Instance.SetCurrentRoleId(num);
			}
			if (num == 0)
			{
				return;
			}
			this.ProficiencyViewComponent.SetRoleTexture(num, itemData.ConfigId);
		}

		// Token: 0x0603A39D RID: 238493 RVA: 0x00EC092C File Offset: 0x00EBEB2C
		[return: TupleElementNames(new string[]
		{
			"hasCoin",
			"coinCount",
			"ret"
		})]
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		private ValueTuple<bool, int, List<ISingleItemInfo>> FilterMaterialList(List<ISingleItemInfo> list)
		{
			bool item = false;
			int item2 = 0;
			List<ISingleItemInfo> list2 = new List<ISingleItemInfo>();
			foreach (ISingleItemInfo singleItemInfo in list)
			{
				if (singleItemInfo.Proto_ItemId != ControllerBase<ComposeController>.Instance.ComposeCoinId)
				{
					list2.Add(singleItemInfo);
				}
				else
				{
					item = true;
					item2 = singleItemInfo.Proto_ItemNum;
				}
			}
			return new ValueTuple<bool, int, List<ISingleItemInfo>>(item, item2, list2);
		}

		// Token: 0x0603A39E RID: 238494 RVA: 0x00EC09B0 File Offset: 0x00EBEBB0
		private void RefreshCommon(IBaseItemData data)
		{
			if (this.ItemData != null && this.ItemData.ConfigId != data.ConfigId)
			{
				ModelBase<ComposeModel>.Instance.CurrentComposeRoleId = 0;
			}
			this.ItemData = data;
			this.Count = 1;
			int maxCreateCount = ControllerBase<ComposeController>.Instance.GetMaxCreateCount(this.ItemData.ConfigId, null);
			this.NumberSelect.Refresh(maxCreateCount);
			this.NumberSelect.SetAddReduceButtonActive(true);
			this.NumberSelect.SetReduceButtonInteractive(false);
			SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(data.ConfigId);
			this.SvInfoView.SetDescVisible(true);
			this.SvInfoView.SetDescBgVisible(false);
			string desc = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetItemAttributeDesc(synthesisFormulaById.Value.ItemId) ?? string.Empty;
			string descBg = StringUtils.IsEmpty(synthesisFormulaById.Value.ComposeBackground) ? "" : ConfigBase<CookConfig>.Instance.GetLocalText(synthesisFormulaById.Value.ComposeBackground);
			this.SvInfoView.SetDesc(desc);
			this.SvInfoView.SetDescBg(descBg);
			this.NumberSelect.SetUiActive(data.IsUnlock > 0);
			base.GetItem(9).SetUIActive(data.IsUnlock > 0);
			if (data.IsUnlock > 0)
			{
				base.GetItem(20).SetUIActive(false);
				base.GetItem(18).SetUIActive(true);
				List<ISingleItemInfo> composeMaterialList = ModelBase<ComposeModel>.Instance.GetComposeMaterialList(data.ConfigId);
				ValueTuple<bool, int, List<ISingleItemInfo>> valueTuple = this.FilterMaterialList(composeMaterialList);
				bool item = valueTuple.Item1;
				int item2 = valueTuple.Item2;
				List<ISingleItemInfo> item3 = valueTuple.Item3;
				this.HasCoin = item;
				this.SingleNeedCoinCount = item2;
				this.MaterialScrollView.RefreshByData(item3, new Action(this.RefreshMaterialNeedNum), false);
				return;
			}
			base.GetItem(20).SetUIActive(true);
			base.GetItem(18).SetUIActive(false);
			SynthesisFormula? synthesisFormulaById2 = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(this.ItemData.ConfigId);
			ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(synthesisFormulaById2.Value.FormulaItemId);
			if (itemConfig == null)
			{
				return;
			}
			PropMediumItemGrid parameters = new PropMediumItemGrid
			{
				Data = synthesisFormulaById2.Value.FormulaItemId,
				ItemConfigId = new int?(synthesisFormulaById2.Value.FormulaItemId),
				BottomTextId = itemConfig.Value.Name,
				IsProhibit = new bool?(true),
				IsOmitBottomText = new bool?(true)
			};
			this.UnlockMaterialComponent.Apply<PropMediumItemGrid>(parameters);
		}

		// Token: 0x0603A39F RID: 238495 RVA: 0x00EC0C46 File Offset: 0x00EBEE46
		public void BindChangeClickCall(Action func)
		{
			this.ChangeRoleClickCall = func;
		}

		// Token: 0x0603A3A0 RID: 238496 RVA: 0x00EC0C50 File Offset: 0x00EBEE50
		private void RefreshProficiency(IReagentProductionData data)
		{
			SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(data.ConfigId);
			int proficiency = synthesisFormulaById.Value.Proficiency;
			int maxProficiencyCount = synthesisFormulaById.Value.MaxProficiencyCount;
			this.SetExpNum(data.ComposeCount, proficiency, maxProficiencyCount, this.Count);
		}

		// Token: 0x0603A3A1 RID: 238497 RVA: 0x00EC0CA2 File Offset: 0x00EBEEA2
		public void OnSecondTimerRefresh()
		{
			if (this.ItemData == null)
			{
				return;
			}
			this.RefreshLimitTime(this.ItemData);
		}

		// Token: 0x0603A3A2 RID: 238498 RVA: 0x00EC0CB9 File Offset: 0x00EBEEB9
		public void RefreshProficiencyAndHelpRole(IReagentProductionData data)
		{
			this.RefreshProficiency(data);
			this.SetSelectedRoleTexture(data.ConfigId);
		}

		// Token: 0x0603A3A3 RID: 238499 RVA: 0x00EC0CCE File Offset: 0x00EBEECE
		public void RefreshHelpRole()
		{
			this.SetSelectedRoleTexture(this.ItemData.ConfigId);
		}

		// Token: 0x0603A3A4 RID: 238500 RVA: 0x00EC0CE4 File Offset: 0x00EBEEE4
		private void RefreshLimitTime(IBaseItemData itemData)
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

		// Token: 0x0603A3A5 RID: 238501 RVA: 0x00EC0D5C File Offset: 0x00EBEF5C
		private void RefreshLimitCount(IBaseItemData itemData)
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

		// Token: 0x0603A3A6 RID: 238502 RVA: 0x00EC0E14 File Offset: 0x00EBF014
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

		// Token: 0x0603A3A7 RID: 238503 RVA: 0x00EC0ECD File Offset: 0x00EBF0CD
		private void SetProficiencyViewVisible(bool visible, bool keepShowRole = false)
		{
			if (keepShowRole)
			{
				this.ProficiencyViewComponent.SetExpVisible(visible);
				return;
			}
			this.ProficiencyViewComponent.SetActive(visible);
		}

		// Token: 0x0603A3A8 RID: 238504 RVA: 0x00EC0EEB File Offset: 0x00EBF0EB
		public void RefreshReagentProduction(IReagentProductionData data)
		{
			this.RefreshLimitTime(data);
			this.RefreshLimitCount(data);
			this.RefreshCommon(data);
			this.SetProficiencyViewVisible(true, true);
			this.SetTypeName("Material");
			this.RefreshProficiency(data);
			this.SetRecommendedRoleTexture(data);
		}

		// Token: 0x0603A3A9 RID: 238505 RVA: 0x00EC0F23 File Offset: 0x00EBF123
		public void RefreshStructure(IStructureData data)
		{
			this.RefreshLimitTime(data);
			this.RefreshLimitCount(data);
			this.RefreshCommon(data);
			this.SetTypeName("Prop");
			this.SetProficiencyViewVisible(false, true);
			this.SetRecommendedRoleTexture(data);
		}

		// Token: 0x0603A3AA RID: 238506 RVA: 0x00EC0F54 File Offset: 0x00EBF154
		public void RefreshPurification(IPurificationData data)
		{
			this.RefreshLimitTime(data);
			this.RefreshLimitCount(data);
			this.RefreshCommon(data);
			this.SetTypeName("Material");
			this.SetProficiencyViewVisible(false, true);
			this.SetRecommendedRoleTexture(data);
			if (data.IsUnlock <= 0)
			{
				this.NumberSelect.Refresh(0);
			}
		}

		// Token: 0x04021012 RID: 135186
		[Nullable(2)]
		private SvInfo SvInfoView;

		// Token: 0x04021013 RID: 135187
		[Nullable(2)]
		private IBaseItemData ItemData;

		// Token: 0x04021014 RID: 135188
		private int Count = 1;

		// Token: 0x04021015 RID: 135189
		[Nullable(2)]
		private NumberSelectComponent NumberSelect;

		// Token: 0x04021016 RID: 135190
		[Nullable(2)]
		private Action ChangeRoleClickCall;

		// Token: 0x04021017 RID: 135191
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<ManufactureMaterialItem, ISingleItemInfo> MaterialScrollView;

		// Token: 0x04021018 RID: 135192
		private bool HasCoin;

		// Token: 0x04021019 RID: 135193
		private int SingleNeedCoinCount;

		// Token: 0x0402101A RID: 135194
		[Nullable(2)]
		private MediumItemGrid UnlockMaterialComponent;

		// Token: 0x0402101B RID: 135195
		[Nullable(2)]
		private ProficiencyView ProficiencyViewComponent;

		// Token: 0x0200B994 RID: 47508
		[NullableContext(0)]
		private class EVerticalGroupComponents
		{
			// Token: 0x04039565 RID: 234853
			public const int SvInfo = 0;

			// Token: 0x04039566 RID: 234854
			public const int PnlLimit = 1;

			// Token: 0x04039567 RID: 234855
			public const int TxtLimitNum = 2;

			// Token: 0x04039568 RID: 234856
			public const int PnlQuota = 3;

			// Token: 0x04039569 RID: 234857
			public const int TxtQuotaNum = 4;

			// Token: 0x0403956A RID: 234858
			public const int AmountItem = 8;

			// Token: 0x0403956B RID: 234859
			public const int PnlCost = 9;

			// Token: 0x0403956C RID: 234860
			public const int MakeCount = 10;

			// Token: 0x0403956D RID: 234861
			public const int TxtCost = 11;

			// Token: 0x0403956E RID: 234862
			public const int TxtPlace = 12;

			// Token: 0x0403956F RID: 234863
			public const int ImgCostIcon = 13;

			// Token: 0x04039570 RID: 234864
			public const int PnlTitle = 16;

			// Token: 0x04039571 RID: 234865
			public const int TxtMaterialBarTitle = 17;

			// Token: 0x04039572 RID: 234866
			public const int PnlLeftItem = 18;

			// Token: 0x04039573 RID: 234867
			public const int MaterialScrollView = 19;

			// Token: 0x04039574 RID: 234868
			public const int PnlCenterItem = 20;

			// Token: 0x04039575 RID: 234869
			public const int LockGrid = 21;

			// Token: 0x04039576 RID: 234870
			public const int PnlLock = 22;

			// Token: 0x04039577 RID: 234871
			public const int TxtLock = 23;

			// Token: 0x04039578 RID: 234872
			public const int PnlLimitedTime = 24;

			// Token: 0x04039579 RID: 234873
			public const int TxtTime = 25;

			// Token: 0x0403957A RID: 234874
			public const int ProficiencyView = 26;
		}
	}
}
