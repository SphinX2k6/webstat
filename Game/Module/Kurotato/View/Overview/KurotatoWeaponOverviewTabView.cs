using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Overview
{
	// Token: 0x02005AA1 RID: 23201
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoWeaponOverviewTabView : UiTabViewBase
	{
		// Token: 0x0603AB1F RID: 240415 RVA: 0x00EE040C File Offset: 0x00EDE60C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIMultiTemplateScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603AB20 RID: 240416 RVA: 0x00EE04FC File Offset: 0x00EDE6FC
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoWeaponOverviewTabView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoWeaponOverviewTabView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AB21 RID: 240417 RVA: 0x00EE0540 File Offset: 0x00EDE740
		private UniTask CreateWeaponTipAsync()
		{
			KurotatoWeaponOverviewTabView.<CreateWeaponTipAsync>d__10 <CreateWeaponTipAsync>d__;
			<CreateWeaponTipAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateWeaponTipAsync>d__.<>4__this = this;
			<CreateWeaponTipAsync>d__.<>1__state = -1;
			<CreateWeaponTipAsync>d__.<>t__builder.Start<KurotatoWeaponOverviewTabView.<CreateWeaponTipAsync>d__10>(ref <CreateWeaponTipAsync>d__);
			return <CreateWeaponTipAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AB22 RID: 240418 RVA: 0x00EE0584 File Offset: 0x00EDE784
		private void CreateItemMultiTemplateScrollViewAsync()
		{
			this.ItemMultiTemplateScrollView = new MultiTemplateScrollView(base.GetMultiTemplateScrollViewComponent(0));
			KurotatoInstInfo saveInstInfo = this.ExtraParams as KurotatoInstInfo;
			this.InitScrollViewData(saveInstInfo);
			MultiTemplateScrollViewRefreshContext multiTemplateScrollViewRefreshContext = new MultiTemplateScrollViewRefreshContext(this.ScrollDataList);
			multiTemplateScrollViewRefreshContext.ScrollToGridIndex = 0;
			this.ItemMultiTemplateScrollView.RefreshByData(multiTemplateScrollViewRefreshContext);
		}

		// Token: 0x0603AB23 RID: 240419 RVA: 0x00EE05D8 File Offset: 0x00EDE7D8
		protected override void OnShowUiTabViewFromToggle()
		{
			UiTabSequence tabBehavior = base.GetTabBehavior<UiTabSequence>();
			if (tabBehavior != null)
			{
				tabBehavior.PlaySequence("Switch");
			}
			if (this.ItemMultiTemplateScrollView == null)
			{
				return;
			}
			KurotatoInstInfo saveInstInfo = this.ExtraParams as KurotatoInstInfo;
			WeaponGridItem selectedItem = this.SelectedItem;
			if (selectedItem != null)
			{
				selectedItem.SetSelected(false, false);
			}
			this.SelectedId = 0;
			this.SelectedItem = null;
			this.InitScrollViewData(saveInstInfo);
			MultiTemplateScrollViewRefreshContext multiTemplateScrollViewRefreshContext = new MultiTemplateScrollViewRefreshContext(this.ScrollDataList);
			multiTemplateScrollViewRefreshContext.ScrollToGridIndex = 0;
			this.ItemMultiTemplateScrollView.RefreshByData(multiTemplateScrollViewRefreshContext);
			this.RefreshItemTip();
			this.RefreshSelectItem();
		}

		// Token: 0x0603AB24 RID: 240420 RVA: 0x00EE0664 File Offset: 0x00EDE864
		[NullableContext(2)]
		private void InitScrollViewData(KurotatoInstInfo saveInstInfo)
		{
			KurotatoConfig kurotatoConfig = ConfigBase<KurotatoConfig>.Instance;
			KurotatoModel instance = ModelBase<KurotatoModel>.Instance;
			this.ScrollDataList.Clear();
			bool flag = false;
			Dictionary<int, int> itemQuality = new Dictionary<int, int>();
			List<IKurotatoItemData> list;
			if (saveInstInfo != null)
			{
				KurotatoItemPanelPbData itemPanelPbData = saveInstInfo.ItemPanelPbData;
				list = new List<IKurotatoItemData>((from d in ((itemPanelPbData != null) ? itemPanelPbData.ItemPbDatas : null) ?? new RepeatedField<KurotatoItemPbData>()
				select new KurotatoItemData
				{
					ItemId = d.ItemId,
					Count = d.Count
				}).Where(delegate(KurotatoItemData a)
				{
					KurotatoItem? kurotatoItem;
					return kurotatoConfig.GetItemConfigByItemId(a.ItemId) != null && kurotatoItem.GetValueOrDefault().Type == 2;
				}).ToList<KurotatoItemData>());
			}
			else
			{
				list = instance.GetHoldItemData().Where(delegate(IKurotatoItemData a)
				{
					KurotatoItem? kurotatoItem;
					return kurotatoConfig.GetItemConfigByItemId(a.ItemId) != null && kurotatoItem.GetValueOrDefault().Type == 2;
				}).ToList<IKurotatoItemData>();
			}
			List<IKurotatoWeaponData> list2;
			if (saveInstInfo != null)
			{
				KurotatoWeaponPanelPbData weaponPanelPbData = saveInstInfo.WeaponPanelPbData;
				list2 = new List<IKurotatoWeaponData>((from d in ((weaponPanelPbData != null) ? weaponPanelPbData.WeaponPbDatas : null) ?? new RepeatedField<KurotatoWeaponPbData>()
				select new KurotatoWeaponData
				{
					WeaponId = d.WeaponId,
					IncId = d.IncId,
					SellPrice = d.SellPrice,
					PreWaveDealtDamage = d.PreWaveDealtDamage
				}).ToList<KurotatoWeaponData>());
			}
			else
			{
				list2 = instance.GetHoldWeaponData().Cast<IKurotatoWeaponData>().ToList<IKurotatoWeaponData>();
			}
			list.Sort(delegate(IKurotatoItemData a, IKurotatoItemData b)
			{
				if (!itemQuality.ContainsKey(a.ItemId))
				{
					itemQuality[a.ItemId] = kurotatoConfig.GetItemConfigByItemId(a.ItemId).Value.Quality;
				}
				if (!itemQuality.ContainsKey(b.ItemId))
				{
					itemQuality[b.ItemId] = kurotatoConfig.GetItemConfigByItemId(b.ItemId).Value.Quality;
				}
				int valueOrDefault = itemQuality.GetValueOrDefault(a.ItemId, 0);
				return itemQuality.GetValueOrDefault(b.ItemId, 0) - valueOrDefault;
			});
			KurotatoActivityConfig? kurotatoActivityConfig;
			int num = (instance.GetActivityConfig() != null) ? kurotatoActivityConfig.GetValueOrDefault().WeaponCount : list2.Count;
			GridTitleItemData gridTitleItemData = new GridTitleItemData();
			MultiTemplateGridDataBase<GridTitleItemDataInner, GridTitleItem> multiTemplateGridDataBase = gridTitleItemData;
			GridTitleItemDataInner gridTitleItemDataInner = new GridTitleItemDataInner();
			gridTitleItemDataInner.Title = "Kurotato_prefabTilte_weapon";
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(list2.Count);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(num);
			gridTitleItemDataInner.Num = defaultInterpolatedStringHandler.ToStringAndClear();
			multiTemplateGridDataBase.Data = gridTitleItemDataInner;
			this.ScrollDataList.Add(gridTitleItemData);
			foreach (IKurotatoWeaponData kurotatoWeaponData in list2)
			{
				if (!flag)
				{
					flag = true;
					this.SelectedId = kurotatoWeaponData.IncId;
					this.SelectedType = EKurotatoCardType.Weapon;
					this.SelectedPreWaveDealtDamage = new int?(kurotatoWeaponData.PreWaveDealtDamage);
				}
				OverviewGridItemData overviewGridItemData = new OverviewGridItemData();
				overviewGridItemData.Data = new KurotatoMediumItemGridData
				{
					Type = EKurotatoCardType.Weapon,
					Id = kurotatoWeaponData.WeaponId,
					IncId = kurotatoWeaponData.IncId,
					Count = 1,
					PreWaveDealtDamage = new int?(kurotatoWeaponData.PreWaveDealtDamage)
				};
				overviewGridItemData.OnClickCb = new Action<WeaponGridItem, bool>(this.OnClickGridItem);
				overviewGridItemData.IsSelectedCb = new Func<IKurotatoMediumItemGridData, bool>(this.IsGridDataSelected);
				this.ScrollDataList.Add(overviewGridItemData);
			}
			for (int i = list2.Count; i < num; i++)
			{
				OverviewGridItemData overviewGridItemData2 = new OverviewGridItemData();
				overviewGridItemData2.Data = new KurotatoMediumItemGridData
				{
					Type = EKurotatoCardType.None,
					Id = 0,
					IncId = 0,
					Count = 0
				};
				overviewGridItemData2.OnClickCb = new Action<WeaponGridItem, bool>(this.OnClickGridItem);
				overviewGridItemData2.IsSelectedCb = new Func<IKurotatoMediumItemGridData, bool>(this.IsGridDataSelected);
				this.ScrollDataList.Add(overviewGridItemData2);
			}
			GridTitleItemData gridTitleItemData2 = new GridTitleItemData();
			int num2 = list.Sum((IKurotatoItemData item) => item.Count);
			gridTitleItemData2.Data = new GridTitleItemDataInner
			{
				Title = "Kurotato_prefabTilte_item",
				Num = num2.ToString()
			};
			this.ScrollDataList.Add(gridTitleItemData2);
			foreach (IKurotatoItemData kurotatoItemData in list)
			{
				if (!flag)
				{
					flag = true;
					this.SelectedId = kurotatoItemData.ItemId;
					this.SelectedType = EKurotatoCardType.Item;
				}
				OverviewGridItemData overviewGridItemData3 = new OverviewGridItemData();
				overviewGridItemData3.Data = new KurotatoMediumItemGridData
				{
					Type = EKurotatoCardType.Item,
					Id = kurotatoItemData.ItemId,
					IncId = 0,
					Count = kurotatoItemData.Count
				};
				overviewGridItemData3.OnClickCb = new Action<WeaponGridItem, bool>(this.OnClickGridItem);
				overviewGridItemData3.IsSelectedCb = new Func<IKurotatoMediumItemGridData, bool>(this.IsGridDataSelected);
				this.ScrollDataList.Add(overviewGridItemData3);
			}
			if (list.Count <= 0)
			{
				this.ScrollDataList.Add(new OverviewEmptyGridData());
			}
		}

		// Token: 0x0603AB25 RID: 240421 RVA: 0x00EE0AC8 File Offset: 0x00EDECC8
		protected override void OnStart()
		{
			this.RefreshItemTip();
			this.RefreshSelectItem();
		}

		// Token: 0x0603AB26 RID: 240422 RVA: 0x00EE0AD8 File Offset: 0x00EDECD8
		private void RefreshSelectItem()
		{
			this.SelectedItem = null;
			bool flag = false;
			for (int i = 0; i < this.ScrollDataList.Count; i++)
			{
				OverviewGridItemData overviewGridItemData = this.ScrollDataList[i] as OverviewGridItemData;
				if (overviewGridItemData != null)
				{
					flag = true;
					if (this.IsGridDataSelected(overviewGridItemData.Data))
					{
						MultiTemplateScrollView itemMultiTemplateScrollView = this.ItemMultiTemplateScrollView;
						this.SelectedItem = (((itemMultiTemplateScrollView != null) ? itemMultiTemplateScrollView.GetProxyByGridIndex(i) : null) as WeaponGridItem);
						break;
					}
				}
			}
			UUIItem uuiitem = base.GetMultiTemplateScrollViewComponent(0).RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(flag);
			}
			base.GetItem(3).SetUIActive(!flag);
		}

		// Token: 0x0603AB27 RID: 240423 RVA: 0x00EE0B7C File Offset: 0x00EDED7C
		private void RefreshItemTip()
		{
			if (this.SelectedId <= 0)
			{
				this.ItemTip.SetUiActive(false);
				return;
			}
			this.ItemTip.SetUiActive(true);
			if (this.ItemTip.IsOutside && this.SelectedType == EKurotatoCardType.Weapon)
			{
				using (List<IMultiTemplateGridData>.Enumerator enumerator = this.ScrollDataList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						IMultiTemplateGridData multiTemplateGridData = enumerator.Current;
						OverviewGridItemData overviewGridItemData = multiTemplateGridData as OverviewGridItemData;
						if (overviewGridItemData != null && overviewGridItemData.Data.IncId == this.SelectedId)
						{
							this.SelectedPreWaveDealtDamage = overviewGridItemData.Data.PreWaveDealtDamage;
							this.ItemTip.Refresh(this.SelectedType, overviewGridItemData.Data.Id, true, false, this.SelectedPreWaveDealtDamage);
							break;
						}
					}
					return;
				}
			}
			this.ItemTip.Refresh(this.SelectedType, this.SelectedId, true, false, this.SelectedPreWaveDealtDamage);
		}

		// Token: 0x0603AB28 RID: 240424 RVA: 0x00EE0C78 File Offset: 0x00EDEE78
		private bool IsGridDataSelected(IKurotatoMediumItemGridData data)
		{
			if (this.SelectedType != data.Type)
			{
				return false;
			}
			if (data.Type == EKurotatoCardType.Weapon)
			{
				return this.SelectedId == data.IncId;
			}
			return this.SelectedId == data.Id;
		}

		// Token: 0x0603AB29 RID: 240425 RVA: 0x00EE0CB0 File Offset: 0x00EDEEB0
		private void OnClickGridItem(WeaponGridItem item, bool selected)
		{
			if (!selected)
			{
				return;
			}
			IKurotatoMediumItemGridData data = item.Data;
			if (data.Type == EKurotatoCardType.None)
			{
				return;
			}
			for (int i = 0; i < this.ScrollDataList.Count; i++)
			{
				MultiTemplateScrollView itemMultiTemplateScrollView = this.ItemMultiTemplateScrollView;
				WeaponGridItem weaponGridItem = ((itemMultiTemplateScrollView != null) ? itemMultiTemplateScrollView.GetProxyByGridIndex(i) : null) as WeaponGridItem;
				if (weaponGridItem != null && this.IsGridDataSelected(weaponGridItem.Data))
				{
					weaponGridItem.SetSelected(false, false);
					break;
				}
			}
			this.SelectedType = data.Type;
			if (data.Type == EKurotatoCardType.Weapon)
			{
				this.SelectedId = data.IncId;
				this.SelectedPreWaveDealtDamage = data.PreWaveDealtDamage;
			}
			else
			{
				this.SelectedId = data.Id;
				this.SelectedPreWaveDealtDamage = null;
			}
			this.SelectedItem = item;
			item.SetSelected(true, false);
			this.RefreshItemTip();
		}

		// Token: 0x040212FE RID: 135934
		private EKurotatoCardType SelectedType;

		// Token: 0x040212FF RID: 135935
		private int SelectedId;

		// Token: 0x04021300 RID: 135936
		private int? SelectedPreWaveDealtDamage;

		// Token: 0x04021301 RID: 135937
		[Nullable(2)]
		private WeaponGridItem SelectedItem;

		// Token: 0x04021302 RID: 135938
		private readonly KurotatoItemInfoTipPanel ItemTip = new KurotatoItemInfoTipPanel();

		// Token: 0x04021303 RID: 135939
		[Nullable(2)]
		private MultiTemplateScrollView ItemMultiTemplateScrollView;

		// Token: 0x04021304 RID: 135940
		private readonly List<IMultiTemplateGridData> ScrollDataList = new List<IMultiTemplateGridData>();

		// Token: 0x0200BAA2 RID: 47778
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x040399FB RID: 236027
			MultiTemplateScrollViewInfo,
			// Token: 0x040399FC RID: 236028
			PanelTitle,
			// Token: 0x040399FD RID: 236029
			PanelItem,
			// Token: 0x040399FE RID: 236030
			PanelEmpty,
			// Token: 0x040399FF RID: 236031
			ItemBase,
			// Token: 0x04039A00 RID: 236032
			TipItem
		}
	}
}
