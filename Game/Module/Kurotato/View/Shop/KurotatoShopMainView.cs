using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Kurotato.View.AttrSelect;
using CSharpScript.Game.Module.Kurotato.View.Components;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Shop
{
	// Token: 0x02005A72 RID: 23154
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoShopMainView : UiViewBase
	{
		// Token: 0x0603A961 RID: 239969 RVA: 0x00ED62AB File Offset: 0x00ED44AB
		public KurotatoShopMainView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603A962 RID: 239970 RVA: 0x00ED62EC File Offset: 0x00ED44EC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 17;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickRefresh));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClickGo));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A963 RID: 239971 RVA: 0x00ED65B0 File Offset: 0x00ED47B0
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoShopMainView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoShopMainView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A964 RID: 239972 RVA: 0x00ED65F4 File Offset: 0x00ED47F4
		private UniTask CreatePopupPanel()
		{
			KurotatoShopMainView.<CreatePopupPanel>d__9 <CreatePopupPanel>d__;
			<CreatePopupPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreatePopupPanel>d__.<>4__this = this;
			<CreatePopupPanel>d__.<>1__state = -1;
			<CreatePopupPanel>d__.<>t__builder.Start<KurotatoShopMainView.<CreatePopupPanel>d__9>(ref <CreatePopupPanel>d__);
			return <CreatePopupPanel>d__.<>t__builder.Task;
		}

		// Token: 0x0603A965 RID: 239973 RVA: 0x00ED6637 File Offset: 0x00ED4837
		private void CreateItemSelectLayout()
		{
			this.ItemSelectLayout = new GenericLayout<KurotatoShopSelectCard, IKurotatoShopSelectCardData>(base.GetHorizontalLayout(4), delegate()
			{
				KurotatoShopSelectCard kurotatoShopSelectCard = new KurotatoShopSelectCard();
				kurotatoShopSelectCard.SetConfirmCb(new Action<int>(this.OnClickSelectConfirm));
				kurotatoShopSelectCard.SetBuildTagClickCb(new Action<int, EToggleState>(this.OnClickBuildTag));
				kurotatoShopSelectCard.SetAttrPreviewCb(new Action<int, bool, IReadOnlyList<IKurotatoAttrPreviewDelta>>(this.OnCardAttrPreview));
				return kurotatoShopSelectCard;
			}, null, false, true);
		}

		// Token: 0x0603A966 RID: 239974 RVA: 0x00ED665A File Offset: 0x00ED485A
		private void CreateItemLayout()
		{
			this.WeaponLayout = new GenericLayout<KurotatoWeaponSmallItemGrid, IKurotatoSmallItemGridData>(base.GetHorizontalLayout(13), delegate()
			{
				KurotatoWeaponSmallItemGrid kurotatoWeaponSmallItemGrid = new KurotatoWeaponSmallItemGrid(true);
				kurotatoWeaponSmallItemGrid.BindCallback(new Action<IKurotatoSmallItemGridData, EToggleState, int>(this.OnClickWeaponGrid));
				return kurotatoWeaponSmallItemGrid;
			}, null, false, true);
		}

		// Token: 0x0603A967 RID: 239975 RVA: 0x00ED6680 File Offset: 0x00ED4880
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.KurotatoOnShopDataChanged, new Action(this.OnUpgradeRewardChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.KurotatoOnWeaponUpdate, new Action(this.OnUpdateWeapon));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.KurotatoOnWeaponRefined, new Action<int>(this.OnWeaponRefined));
			Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.KurotatoOnItemUpdate, new Action<int, bool>(this.OnItemUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.KurotatoOnNextWaveTypeUpdate, new Action(this.OnNextWaveTypeUpdate));
			ModelBase<KurotatoModel>.Instance.BattleData.BehaviorDelegate.AddTreeVarUpdateDelegate(EKurotatoSystemVarType.Gold.ToEnumString(), new TTreeVarUpdateDelegate(this.OnCurrencyUpdate));
		}

		// Token: 0x0603A968 RID: 239976 RVA: 0x00ED6740 File Offset: 0x00ED4940
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.KurotatoOnShopDataChanged, new Action(this.OnUpgradeRewardChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.KurotatoOnWeaponUpdate, new Action(this.OnUpdateWeapon));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.KurotatoOnWeaponRefined, new Action<int>(this.OnWeaponRefined));
			Singleton<EventSystem>.Instance.Remove<int, bool>(EEventName.KurotatoOnItemUpdate, new Action<int, bool>(this.OnItemUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.KurotatoOnNextWaveTypeUpdate, new Action(this.OnNextWaveTypeUpdate));
			ModelBase<KurotatoModel>.Instance.BattleData.BehaviorDelegate.RemoveTreeVarUpdateDelegate(EKurotatoSystemVarType.Gold.ToEnumString(), new TTreeVarUpdateDelegate(this.OnCurrencyUpdate));
		}

		// Token: 0x0603A969 RID: 239977 RVA: 0x00ED67FF File Offset: 0x00ED49FF
		protected override void OnStart()
		{
			this.PendingShopRefreshAnim = true;
			this.RefreshWave();
			this.CommonPopupPanel.SetTitleLocalText("Kurotato_Shop_Title");
		}

		// Token: 0x0603A96A RID: 239978 RVA: 0x00ED681E File Offset: 0x00ED4A1E
		protected override void OnBeforeShow()
		{
			this.CommonPopupPanel.HideAttrChangeFx();
			this.OnUpgradeRewardChanged();
		}

		// Token: 0x0603A96B RID: 239979 RVA: 0x00ED6834 File Offset: 0x00ED4A34
		private void RefreshSelectLayout()
		{
			KurotatoModel instance = ModelBase<KurotatoModel>.Instance;
			List<KurotatoShopProductPbData> shopData = instance.GetShopData();
			List<IKurotatoShopSelectCardData> list = new List<IKurotatoShopSelectCardData>();
			foreach (KurotatoShopProductPbData kurotatoShopProductPbData in shopData)
			{
				EKurotatoCardType ekurotatoCardType = (kurotatoShopProductPbData.ItemData != null) ? EKurotatoCardType.Item : EKurotatoCardType.Weapon;
				int num = (ekurotatoCardType == EKurotatoCardType.Item) ? kurotatoShopProductPbData.ItemData.ItemId : kurotatoShopProductPbData.WeaponData.WeaponId;
				list.Add(new KurotatoShopSelectCardData
				{
					Id = num,
					SelectionId = kurotatoShopProductPbData.SelectionId,
					OriginalCost = kurotatoShopProductPbData.OriginalCost,
					Cost = kurotatoShopProductPbData.Cost,
					CardType = ekurotatoCardType,
					HasBuy = kurotatoShopProductPbData.IsBought,
					IsRecommend = ((ekurotatoCardType == EKurotatoCardType.Item) ? instance.IsRecommendItem(num) : instance.IsRecommendWeapon(num)),
					IsLock = kurotatoShopProductPbData.IsLocked
				});
			}
			if (this.IsSelectDataSame(list))
			{
				return;
			}
			this.CommonPopupPanel.ClearAttrPreview();
			GenericLayout<KurotatoShopSelectCard, IKurotatoShopSelectCardData> itemSelectLayout = this.ItemSelectLayout;
			foreach (KurotatoShopSelectCard kurotatoShopSelectCard in (((itemSelectLayout != null) ? itemSelectLayout.GetLayoutItemList() : null) ?? new List<KurotatoShopSelectCard>()))
			{
				kurotatoShopSelectCard.CloseBuildInfo();
				kurotatoShopSelectCard.ClearAttrPreviewSelection();
			}
			bool flag = list.Count > 0;
			this.ItemSelectLayout.RefreshByData(list, delegate
			{
				this.RefreshCardsComposeState();
			}, this.PendingShopRefreshAnim && flag);
			if (flag)
			{
				this.PendingShopRefreshAnim = false;
				this.RefreshWeaponLayout(null);
			}
		}

		// Token: 0x0603A96C RID: 239980 RVA: 0x00ED69F0 File Offset: 0x00ED4BF0
		private bool IsSelectDataSame(List<IKurotatoShopSelectCardData> newData)
		{
			IReadOnlyList<IKurotatoShopSelectCardData> datas = this.ItemSelectLayout.GetDatas();
			if (datas.Count != newData.Count)
			{
				return false;
			}
			for (int i = 0; i < newData.Count; i++)
			{
				IKurotatoShopSelectCardData kurotatoShopSelectCardData = datas[i];
				IKurotatoShopSelectCardData kurotatoShopSelectCardData2 = newData[i];
				if (kurotatoShopSelectCardData.Id != kurotatoShopSelectCardData2.Id || kurotatoShopSelectCardData.SelectionId != kurotatoShopSelectCardData2.SelectionId || kurotatoShopSelectCardData.OriginalCost != kurotatoShopSelectCardData2.OriginalCost || kurotatoShopSelectCardData.Cost != kurotatoShopSelectCardData2.Cost || kurotatoShopSelectCardData.CardType != kurotatoShopSelectCardData2.CardType || kurotatoShopSelectCardData.HasBuy != kurotatoShopSelectCardData2.HasBuy || kurotatoShopSelectCardData.IsRecommend != kurotatoShopSelectCardData2.IsRecommend || kurotatoShopSelectCardData.IsLock != kurotatoShopSelectCardData2.IsLock)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0603A96D RID: 239981 RVA: 0x00ED6AB4 File Offset: 0x00ED4CB4
		private void RefreshWave()
		{
			KurotatoModel instance = ModelBase<KurotatoModel>.Instance;
			UUIText text = base.GetText(3);
			if (instance.GetIsSpecialWave())
			{
				text.ShowTextNew("Kurotato_Special_Boss");
				return;
			}
			UUIText uuitext = text;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(instance.BattleData.GetBatch());
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(instance.BattleData.GetMaxBatch());
			uuitext.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x0603A96E RID: 239982 RVA: 0x00ED6B2C File Offset: 0x00ED4D2C
		private void RefreshRefreshInfo()
		{
			KurotatoModel instance = ModelBase<KurotatoModel>.Instance;
			int refreshCost = instance.GetRefreshCost();
			UUIText text = base.GetText(7);
			UUIText uuitext = text;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(refreshCost);
			uuitext.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			base.GetText(8).SetUIActive(false);
			bool flag = instance.BattleData.GetCurrencyCount() < refreshCost;
			base.GetButton(6).SetSelfInteractive(!flag);
			UUIItem uuiitem = text;
			bool bUseChangeColor = flag;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		}

		// Token: 0x0603A96F RID: 239983 RVA: 0x00ED6BB0 File Offset: 0x00ED4DB0
		private void RefreshWeaponLayout(int? composeIncId = null)
		{
			List<IKurotatoWeaponData> holdWeaponData = ModelBase<KurotatoModel>.Instance.GetHoldWeaponData();
			this.ComposeHighlight = ModelBase<KurotatoModel>.Instance.GetComposeHighlight();
			HashSet<int> arrowIncIds = this.ComposeHighlight.ArrowIncIds;
			List<IKurotatoSmallItemGridData> list = new List<IKurotatoSmallItemGridData>();
			foreach (IKurotatoWeaponData kurotatoWeaponData in holdWeaponData)
			{
				list.Add(new KurotatoSmallItemGridData
				{
					Type = EKurotatoCardType.Weapon,
					Id = kurotatoWeaponData.WeaponId,
					IncId = kurotatoWeaponData.IncId,
					Count = 1,
					PlayComposeFx = new bool?(composeIncId != null && kurotatoWeaponData.IncId == composeIncId.Value),
					ShowArrow = new bool?(arrowIncIds.Contains(kurotatoWeaponData.IncId))
				});
			}
			if (composeIncId == null && this.IsWeaponDataSame(list))
			{
				return;
			}
			this.WeaponLayout.RefreshByData(list, null, false);
		}

		// Token: 0x0603A970 RID: 239984 RVA: 0x00ED6CB4 File Offset: 0x00ED4EB4
		private bool IsWeaponDataSame(List<IKurotatoSmallItemGridData> newData)
		{
			IReadOnlyList<IKurotatoSmallItemGridData> datas = this.WeaponLayout.GetDatas();
			if (datas.Count != newData.Count)
			{
				return false;
			}
			int i = 0;
			while (i < newData.Count)
			{
				if (datas[i].Id == newData[i].Id && datas[i].IncId == newData[i].IncId)
				{
					bool? showArrow = datas[i].ShowArrow;
					bool? showArrow2 = newData[i].ShowArrow;
					if (showArrow.GetValueOrDefault() == showArrow2.GetValueOrDefault() & showArrow != null == (showArrow2 != null))
					{
						i++;
						continue;
					}
				}
				return false;
			}
			return true;
		}

		// Token: 0x0603A971 RID: 239985 RVA: 0x00ED6D64 File Offset: 0x00ED4F64
		private void RefreshWaveTip()
		{
			KurotatoModel instance = ModelBase<KurotatoModel>.Instance;
			KurotatoConfig instance2 = ConfigBase<KurotatoConfig>.Instance;
			int curLevelId = instance.GetCurLevelId();
			int batch = instance.BattleData.GetBatch();
			List<KurotatoWave> list = instance2.GetWaveByLevelId(curLevelId) ?? new List<KurotatoWave>();
			int nextWaveNum = instance.GetNextWaveNum();
			int num = (nextWaveNum != 0) ? nextWaveNum : (batch + 1);
			KurotatoWave? kurotatoWave = null;
			foreach (KurotatoWave value in list)
			{
				if (value.Wave == num)
				{
					kurotatoWave = new KurotatoWave?(value);
					break;
				}
			}
			bool flag = kurotatoWave != null && instance2.WaveHasRiskType(kurotatoWave.Value, EKurotatoRiskType.BOSS);
			bool isNextWaveSpecial = instance.GetIsNextWaveSpecial();
			int num2 = 0;
			foreach (KurotatoWave kurotatoWave2 in list)
			{
				if (kurotatoWave2.Wave >= num && kurotatoWave2.IsPowerWave)
				{
					num2 = kurotatoWave2.Wave;
					break;
				}
			}
			bool flag2 = num2 == num;
			bool flag3 = num2 > num;
			base.GetItem(15).SetUIActive(isNextWaveSpecial);
			base.GetItem(11).SetUIActive(!isNextWaveSpecial && flag);
			base.GetItem(16).SetUIActive(!isNextWaveSpecial && !flag && flag2);
			base.GetItem(10).SetUIActive(!isNextWaveSpecial && !flag && !flag2 && flag3);
			if (flag3)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), "PrefabTextItem_3621275509_Text", new <>z__ReadOnlySingleElementList<object>(num2.ToString()));
			}
		}

		// Token: 0x0603A972 RID: 239986 RVA: 0x00ED6F28 File Offset: 0x00ED5128
		private void OnClickSelectConfirm(int selectionId)
		{
			List<KurotatoShopProductPbData> shopData = ModelBase<KurotatoModel>.Instance.GetShopData();
			if (shopData.Any((KurotatoShopProductPbData item) => item.SelectionId == selectionId && item.IsBought))
			{
				return;
			}
			KurotatoShopProductPbData kurotatoShopProductPbData = shopData.FirstOrDefault((KurotatoShopProductPbData item) => item.SelectionId == selectionId);
			if (((kurotatoShopProductPbData != null) ? kurotatoShopProductPbData.ItemData : null) != null && this.IsShopItemQuantityMax(kurotatoShopProductPbData.ItemData.ItemId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Kurotato_Item_Quantity_Max", Array.Empty<object>());
				return;
			}
			if (((kurotatoShopProductPbData != null) ? kurotatoShopProductPbData.WeaponData : null) != null)
			{
				List<IKurotatoWeaponData> holdWeaponData = ModelBase<KurotatoModel>.Instance.GetHoldWeaponData();
				KurotatoActivityConfig? kurotatoActivityConfig;
				int num = (ModelBase<KurotatoModel>.Instance.GetActivityConfig() != null) ? kurotatoActivityConfig.GetValueOrDefault().WeaponCount : holdWeaponData.Count;
				int weaponId = kurotatoShopProductPbData.WeaponData.WeaponId;
				if (holdWeaponData.Count >= num && !ModelBase<KurotatoModel>.Instance.CanComposeWeapon(weaponId))
				{
					string textId = this.CanComposeAnyHoldWeapon() ? "Kurotato_Weapon_CouldSynthesis" : "Kurotato_Weapon_Quantity_Max";
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(textId, Array.Empty<object>());
					return;
				}
			}
			ControllerBase<KurotatoController>.Instance.RequestKurotatoShopProductSelect(selectionId).Forget<bool>();
		}

		// Token: 0x0603A973 RID: 239987 RVA: 0x00ED7058 File Offset: 0x00ED5258
		private bool IsShopItemQuantityMax(int itemId)
		{
			KurotatoItem? itemConfigByItemId = ConfigBase<KurotatoConfig>.Instance.GetItemConfigByItemId(itemId);
			return itemConfigByItemId != null && ModelBase<KurotatoModel>.Instance.GetHoldItemCount(itemId) >= itemConfigByItemId.Value.MaxStackCount;
		}

		// Token: 0x0603A974 RID: 239988 RVA: 0x00ED709C File Offset: 0x00ED529C
		private bool CanComposeAnyHoldWeapon()
		{
			KurotatoConfig instance = ConfigBase<KurotatoConfig>.Instance;
			List<IKurotatoWeaponData> holdWeaponData = ModelBase<KurotatoModel>.Instance.GetHoldWeaponData();
			for (int i = 0; i < holdWeaponData.Count; i++)
			{
				KurotatoWeapon? weaponConfigByWeaponId = instance.GetWeaponConfigByWeaponId(holdWeaponData[i].WeaponId);
				if (weaponConfigByWeaponId != null)
				{
					int maxQualityByGroupId = instance.GetMaxQualityByGroupId(weaponConfigByWeaponId.Value.GroupId);
					if (weaponConfigByWeaponId.Value.Quality < maxQualityByGroupId)
					{
						for (int j = i + 1; j < holdWeaponData.Count; j++)
						{
							KurotatoWeapon? weaponConfigByWeaponId2 = instance.GetWeaponConfigByWeaponId(holdWeaponData[j].WeaponId);
							if (weaponConfigByWeaponId2 != null && weaponConfigByWeaponId2.Value.GroupId == weaponConfigByWeaponId.Value.GroupId && weaponConfigByWeaponId2.Value.Quality == weaponConfigByWeaponId.Value.Quality)
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0603A975 RID: 239989 RVA: 0x00ED7198 File Offset: 0x00ED5398
		private void OnUpgradeRewardChanged()
		{
			this.RefreshSelectLayout();
			this.RefreshRefreshInfo();
			this.RefreshWaveTip();
		}

		// Token: 0x0603A976 RID: 239990 RVA: 0x00ED71AC File Offset: 0x00ED53AC
		private void OnUpdateWeapon()
		{
			this.RefreshWeaponLayout(null);
			this.RefreshSelectLayout();
			this.RefreshCardsComposeState();
			this.RefreshCardsBuildTagLevel();
		}

		// Token: 0x0603A977 RID: 239991 RVA: 0x00ED71DA File Offset: 0x00ED53DA
		private void OnWeaponRefined(int newWeaponIncId)
		{
			this.RefreshWeaponLayout(new int?(newWeaponIncId));
			this.RefreshCardsComposeState();
		}

		// Token: 0x0603A978 RID: 239992 RVA: 0x00ED71F0 File Offset: 0x00ED53F0
		private void OnItemUpdate(int itemId, bool bIsAdd)
		{
			this.RefreshWaveTip();
			GenericLayout<KurotatoShopSelectCard, IKurotatoShopSelectCardData> itemSelectLayout = this.ItemSelectLayout;
			foreach (KurotatoShopSelectCard kurotatoShopSelectCard in (((itemSelectLayout != null) ? itemSelectLayout.GetLayoutItemList() : null) ?? new List<KurotatoShopSelectCard>()))
			{
				kurotatoShopSelectCard.RefreshHoldNum();
			}
		}

		// Token: 0x0603A979 RID: 239993 RVA: 0x00ED725C File Offset: 0x00ED545C
		private void OnNextWaveTypeUpdate()
		{
			this.RefreshWaveTip();
		}

		// Token: 0x0603A97A RID: 239994 RVA: 0x00ED7264 File Offset: 0x00ED5464
		private void RefreshCardsComposeState()
		{
			HashSet<int> upgradeSelectionIds = this.ComposeHighlight.UpgradeSelectionIds;
			GenericLayout<KurotatoShopSelectCard, IKurotatoShopSelectCardData> itemSelectLayout = this.ItemSelectLayout;
			foreach (KurotatoShopSelectCard kurotatoShopSelectCard in (((itemSelectLayout != null) ? itemSelectLayout.GetLayoutItemList() : null) ?? new List<KurotatoShopSelectCard>()))
			{
				kurotatoShopSelectCard.SetComposeUpgradeVisible(upgradeSelectionIds.Contains(kurotatoShopSelectCard.GetSelectionId()));
			}
		}

		// Token: 0x0603A97B RID: 239995 RVA: 0x00ED72E4 File Offset: 0x00ED54E4
		private void RefreshCardsBuildTagLevel()
		{
			GenericLayout<KurotatoShopSelectCard, IKurotatoShopSelectCardData> itemSelectLayout = this.ItemSelectLayout;
			foreach (KurotatoShopSelectCard kurotatoShopSelectCard in (((itemSelectLayout != null) ? itemSelectLayout.GetLayoutItemList() : null) ?? new List<KurotatoShopSelectCard>()))
			{
				kurotatoShopSelectCard.RefreshBuildTagLevel();
			}
		}

		// Token: 0x0603A97C RID: 239996 RVA: 0x00ED734C File Offset: 0x00ED554C
		private void OnCurrencyUpdate([Nullable(2)] VarDefinePb lastVarDefine, VarDefinePb newVarDefine)
		{
			GenericLayout<KurotatoShopSelectCard, IKurotatoShopSelectCardData> itemSelectLayout = this.ItemSelectLayout;
			foreach (KurotatoShopSelectCard kurotatoShopSelectCard in (((itemSelectLayout != null) ? itemSelectLayout.GetLayoutItemList() : null) ?? new List<KurotatoShopSelectCard>()))
			{
				kurotatoShopSelectCard.RefreshCurrencyState();
			}
			this.RefreshRefreshInfo();
		}

		// Token: 0x0603A97D RID: 239997 RVA: 0x00ED73B8 File Offset: 0x00ED55B8
		private void OnClickRefresh()
		{
			KurotatoModel instance = ModelBase<KurotatoModel>.Instance;
			List<KurotatoShopProductPbData> shopData = instance.GetShopData();
			if (shopData.Count > 0)
			{
				if (shopData.All((KurotatoShopProductPbData item) => !item.IsBought && item.IsLocked))
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ErrorCode_KurotatoShopReflashFail_Text", Array.Empty<object>());
					return;
				}
			}
			if (instance.BattleData.GetCurrencyCount() < instance.GetRefreshCost())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Kurotato_Insufficient_Gold_Coins", Array.Empty<object>());
				return;
			}
			this.PendingShopRefreshAnim = true;
			ControllerBase<KurotatoController>.Instance.RequestKurotatoShopRewardRefresh().ContinueWith(delegate(bool success)
			{
				if (!success)
				{
					this.PendingShopRefreshAnim = false;
				}
			}).Forget();
		}

		// Token: 0x0603A97E RID: 239998 RVA: 0x00ED7468 File Offset: 0x00ED5668
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length < 2)
			{
				return null;
			}
			string a = configParams[0];
			int num;
			if (!int.TryParse(configParams[1], out num))
			{
				return null;
			}
			int num2 = num - 1;
			if (num2 < 0)
			{
				return null;
			}
			if (a == "WeaponSlot")
			{
				GenericLayout<KurotatoWeaponSmallItemGrid, IKurotatoSmallItemGridData> weaponLayout = this.WeaponLayout;
				KurotatoWeaponSmallItemGrid kurotatoWeaponSmallItemGrid = (weaponLayout != null) ? weaponLayout.GetLayoutItemByIndex(num2) : null;
				UUIItem uuiitem = (kurotatoWeaponSmallItemGrid != null) ? kurotatoWeaponSmallItemGrid.GetRootItem() : null;
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
			else if (a == "ShopCard" || a == "ShopCardLock" || a == "ShopCardDes")
			{
				GenericLayout<KurotatoShopSelectCard, IKurotatoShopSelectCardData> itemSelectLayout = this.ItemSelectLayout;
				KurotatoShopSelectCard kurotatoShopSelectCard = (itemSelectLayout != null) ? itemSelectLayout.GetLayoutItemByIndex(num2) : null;
				if (kurotatoShopSelectCard == null)
				{
					return null;
				}
				if (!(a == "ShopCard"))
				{
					return kurotatoShopSelectCard.GetGuideUiItemAndUiItemForShowEx(configParams);
				}
				UUIItem rootItem = kurotatoShopSelectCard.GetRootItem();
				if (rootItem == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					rootItem,
					rootItem
				};
			}
			else if (a == "ShopRecommend")
			{
				KurotatoShopSelectCard nthRecommendCard = this.GetNthRecommendCard(num2);
				if (nthRecommendCard == null)
				{
					return null;
				}
				return nthRecommendCard.GetGuideUiItemAndUiItemForShowEx(configParams);
			}
			else
			{
				if (!(a == "ShopBuildTag"))
				{
					return null;
				}
				KurotatoShopSelectCard nthBuildTagCard = this.GetNthBuildTagCard(num2);
				if (nthBuildTagCard == null)
				{
					return null;
				}
				return nthBuildTagCard.GetGuideUiItemAndUiItemForShowEx(configParams);
			}
		}

		// Token: 0x0603A97F RID: 239999 RVA: 0x00ED7598 File Offset: 0x00ED5798
		[NullableContext(2)]
		private KurotatoShopSelectCard GetNthRecommendCard(int idx)
		{
			GenericLayout<KurotatoShopSelectCard, IKurotatoShopSelectCardData> itemSelectLayout = this.ItemSelectLayout;
			List<KurotatoShopSelectCard> list = (itemSelectLayout != null) ? itemSelectLayout.GetLayoutItemList() : null;
			if (list == null)
			{
				return null;
			}
			int num = 0;
			foreach (KurotatoShopSelectCard kurotatoShopSelectCard in list)
			{
				if (kurotatoShopSelectCard.IsRecommend())
				{
					if (num == idx)
					{
						return kurotatoShopSelectCard;
					}
					num++;
				}
			}
			return null;
		}

		// Token: 0x0603A980 RID: 240000 RVA: 0x00ED7614 File Offset: 0x00ED5814
		[NullableContext(2)]
		private KurotatoShopSelectCard GetNthBuildTagCard(int idx)
		{
			GenericLayout<KurotatoShopSelectCard, IKurotatoShopSelectCardData> itemSelectLayout = this.ItemSelectLayout;
			List<KurotatoShopSelectCard> list = (itemSelectLayout != null) ? itemSelectLayout.GetLayoutItemList() : null;
			if (list == null)
			{
				return null;
			}
			int num = 0;
			foreach (KurotatoShopSelectCard kurotatoShopSelectCard in list)
			{
				if (kurotatoShopSelectCard.HasBuildTag())
				{
					if (num == idx)
					{
						return kurotatoShopSelectCard;
					}
					num++;
				}
			}
			return null;
		}

		// Token: 0x0603A981 RID: 240001 RVA: 0x00ED7690 File Offset: 0x00ED5890
		private bool HasAvailableShopItem()
		{
			KurotatoModel instance = ModelBase<KurotatoModel>.Instance;
			int currencyCount = instance.BattleData.GetCurrencyCount();
			return instance.GetShopData().Any((KurotatoShopProductPbData item) => !item.IsBought && currencyCount >= item.Cost);
		}

		// Token: 0x0603A982 RID: 240002 RVA: 0x00ED76D4 File Offset: 0x00ED58D4
		private void OpenNotBuyConfirm(bool isEndLess)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.KurotatoNotBuyConfirm);
			confirmBoxDataNew.HasToggle = true;
			confirmBoxDataNew.ToggleTextKey = "Text_ItemRecycleConfirmToggle_text";
			confirmBoxDataNew.SetToggleFunction(new Action<bool>(this.OnToggleNotBuyConfirm));
			Action value = delegate()
			{
				ModelBase<KurotatoModel>.Instance.HideShopNotBuyConfirmBox = false;
			};
			confirmBoxDataNew.FunctionMap[0] = value;
			confirmBoxDataNew.FunctionMap[1] = value;
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				ControllerBase<KurotatoController>.Instance.RequestKurotatoEndShopStep(isEndLess).Forget<bool>();
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603A983 RID: 240003 RVA: 0x00ED777B File Offset: 0x00ED597B
		private void OnClickGo()
		{
			if (ModelBase<KurotatoModel>.Instance.HideShopNotBuyConfirmBox || !this.HasAvailableShopItem())
			{
				ControllerBase<KurotatoController>.Instance.RequestKurotatoEndShopStep(false).Forget<bool>();
				return;
			}
			this.OpenNotBuyConfirm(false);
		}

		// Token: 0x0603A984 RID: 240004 RVA: 0x00ED77A9 File Offset: 0x00ED59A9
		private void OnToggleNotBuyConfirm(bool isSelectedOn)
		{
			ModelBase<KurotatoModel>.Instance.HideShopNotBuyConfirmBox = isSelectedOn;
		}

		// Token: 0x0603A985 RID: 240005 RVA: 0x00ED77B8 File Offset: 0x00ED59B8
		private void OnClickWeaponGrid(IKurotatoSmallItemGridData data, EToggleState state, int gridIndex)
		{
			KurotatoWeaponSmallItemGrid layoutItemByIndex = this.WeaponLayout.GetLayoutItemByIndex(gridIndex);
			if (layoutItemByIndex != null)
			{
				layoutItemByIndex.SetSelected(false, false);
			}
			List<IKurotatoWeaponData> holdWeaponData = ModelBase<KurotatoModel>.Instance.GetHoldWeaponData();
			List<KurotatoCardTip> list = new List<KurotatoCardTip>();
			foreach (IKurotatoWeaponData kurotatoWeaponData in holdWeaponData)
			{
				list.Add(new KurotatoCardTip
				{
					CardType = EKurotatoCardType.Weapon,
					SelectId = kurotatoWeaponData.IncId
				});
			}
			List<int> list2 = new List<int>();
			foreach (IKurotatoWeaponData kurotatoWeaponData2 in holdWeaponData)
			{
				list2.Add(kurotatoWeaponData2.SellPrice);
			}
			int index = 0;
			for (int i = 0; i < holdWeaponData.Count; i++)
			{
				if (holdWeaponData[i].IncId == data.IncId)
				{
					index = i;
					break;
				}
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoPopupItemDetailView, new KurotatoPopupItemDetailOpenParam
			{
				Index = index,
				CardData = list,
				Price = list2
			}, delegate(bool success, int viewId)
			{
				if (success)
				{
					base.AddChildViewById(viewId);
				}
			});
		}

		// Token: 0x0603A986 RID: 240006 RVA: 0x00ED78FC File Offset: 0x00ED5AFC
		private void OnClickBuildTag(int selectionId, EToggleState state)
		{
			if (state != EToggleState.ETT_Checked)
			{
				return;
			}
			foreach (KurotatoShopSelectCard kurotatoShopSelectCard in this.ItemSelectLayout.GetLayoutItemList())
			{
				if (kurotatoShopSelectCard.GetSelectionId() != selectionId)
				{
					kurotatoShopSelectCard.ClearBuildTagSelection();
				}
			}
		}

		// Token: 0x0603A987 RID: 240007 RVA: 0x00ED7964 File Offset: 0x00ED5B64
		private void OnCardAttrPreview(int selectionId, bool active, IReadOnlyList<IKurotatoAttrPreviewDelta> deltas)
		{
			if (!active)
			{
				this.CommonPopupPanel.ClearAttrPreview();
				return;
			}
			this.CommonPopupPanel.ShowAttrPreview(deltas);
			GenericLayout<KurotatoShopSelectCard, IKurotatoShopSelectCardData> itemSelectLayout = this.ItemSelectLayout;
			foreach (KurotatoShopSelectCard kurotatoShopSelectCard in (((itemSelectLayout != null) ? itemSelectLayout.GetLayoutItemList() : null) ?? new List<KurotatoShopSelectCard>()))
			{
				if (kurotatoShopSelectCard.GetSelectionId() != selectionId)
				{
					kurotatoShopSelectCard.ClearAttrPreviewSelection();
				}
			}
		}

		// Token: 0x04021271 RID: 135793
		private readonly KurotatoCommonPopupPanel CommonPopupPanel = new KurotatoCommonPopupPanel();

		// Token: 0x04021272 RID: 135794
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<KurotatoShopSelectCard, IKurotatoShopSelectCardData> ItemSelectLayout;

		// Token: 0x04021273 RID: 135795
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<KurotatoWeaponSmallItemGrid, IKurotatoSmallItemGridData> WeaponLayout;

		// Token: 0x04021274 RID: 135796
		private bool PendingShopRefreshAnim;

		// Token: 0x04021275 RID: 135797
		private IKurotatoComposeHighlight ComposeHighlight = new KurotatoComposeHighlight
		{
			UpgradeSelectionIds = new HashSet<int>(),
			ArrowIncIds = new HashSet<int>(),
			BagPairArrowIncIds = new HashSet<int>()
		};

		// Token: 0x0200BA33 RID: 47667
		[NullableContext(0)]
		private class EChildComp
		{
			// Token: 0x04039807 RID: 235527
			public const int CommonPopupPanel = 0;

			// Token: 0x04039808 RID: 235528
			public const int TipItem = 1;

			// Token: 0x04039809 RID: 235529
			public const int PanelWave = 2;

			// Token: 0x0403980A RID: 235530
			public const int TextWaveNum = 3;

			// Token: 0x0403980B RID: 235531
			public const int HorizontalLayoutCard = 4;

			// Token: 0x0403980C RID: 235532
			public const int CardItem = 5;

			// Token: 0x0403980D RID: 235533
			public const int ButtonRefresh = 6;

			// Token: 0x0403980E RID: 235534
			public const int TextRefreshNum = 7;

			// Token: 0x0403980F RID: 235535
			public const int TextRefreshDiscount = 8;

			// Token: 0x04039810 RID: 235536
			public const int ButtonGo = 9;

			// Token: 0x04039811 RID: 235537
			public const int PanelTipGoNormal = 10;

			// Token: 0x04039812 RID: 235538
			public const int PanelTipGoBoss = 11;

			// Token: 0x04039813 RID: 235539
			public const int TextBtnGoTip = 12;

			// Token: 0x04039814 RID: 235540
			public const int HorizontalLayoutItem = 13;

			// Token: 0x04039815 RID: 235541
			public const int ItemBase = 14;

			// Token: 0x04039816 RID: 235542
			public const int PanelTipSpecial = 15;

			// Token: 0x04039817 RID: 235543
			public const int PanelTipGoElite = 16;
		}
	}
}
