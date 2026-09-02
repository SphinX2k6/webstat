using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063EF RID: 25583
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeDetailEnhanceTabView : UiTabViewBase
	{
		// Token: 0x060403BE RID: 263102 RVA: 0x01076574 File Offset: 0x01074774
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
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
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060403BF RID: 263103 RVA: 0x0107670C File Offset: 0x0107490C
		protected override UniTask OnBeforeStartAsync()
		{
			RoverlikeDetailEnhanceTabView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoverlikeDetailEnhanceTabView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060403C0 RID: 263104 RVA: 0x0107674F File Offset: 0x0107494F
		protected override void OnStart()
		{
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			this.RefreshList();
		}

		// Token: 0x060403C1 RID: 263105 RVA: 0x0107676A File Offset: 0x0107496A
		protected override void OnShowUiTabViewFromToggle()
		{
			if (this.MultiList != null)
			{
				this.RefreshList();
			}
		}

		// Token: 0x060403C2 RID: 263106 RVA: 0x0107677A File Offset: 0x0107497A
		protected override void OnBeforeDestroy()
		{
			this.MultiListAnimController = null;
		}

		// Token: 0x060403C3 RID: 263107 RVA: 0x01076784 File Offset: 0x01074984
		private void RefreshList()
		{
			this.ScrollDataList.Clear();
			this.SelectedGridIndex = -1;
			RoverlikeInstanceData instanceData = ModelBase<RoverlikeModel>.Instance.InstanceData;
			List<RoverlikeGainEntry> list = ((instanceData != null) ? instanceData.GetRoleEnhanceList() : null) ?? new List<RoverlikeGainEntry>();
			RoverlikeInstanceData instanceData2 = ModelBase<RoverlikeModel>.Instance.InstanceData;
			List<RoverlikeGainEntry> list2 = ((instanceData2 != null) ? instanceData2.GetItemList() : null) ?? new List<RoverlikeGainEntry>();
			RoverlikeInstanceData.SortGainEntryList(list);
			RoverlikeInstanceData.SortGainEntryList(list2);
			int num = -1;
			this.PushTitle("RoverRogue_SystemShow_Enhance");
			if (list.Count > 0)
			{
				using (List<RoverlikeGainEntry>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						RoverlikeGainEntry entry = enumerator.Current;
						int num2 = this.PushGrid(entry);
						if (num < 0)
						{
							num = num2;
						}
					}
					goto IL_BC;
				}
			}
			this.PushEmpty("RoverRogue_EnhanceNotGet");
			IL_BC:
			this.PushTitle("RoverRogue_SystemShow_Item");
			if (list2.Count > 0)
			{
				using (List<RoverlikeGainEntry>.Enumerator enumerator = list2.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						RoverlikeGainEntry entry2 = enumerator.Current;
						int num3 = this.PushGrid(entry2);
						if (num < 0)
						{
							num = num3;
						}
					}
					goto IL_118;
				}
			}
			this.PushEmpty("RoverRogue_ItemNotGet");
			IL_118:
			MultiTemplateScrollViewRefreshContext multiTemplateScrollViewRefreshContext = new MultiTemplateScrollViewRefreshContext(this.ScrollDataList);
			multiTemplateScrollViewRefreshContext.ScrollToGridIndex = 0;
			this.MultiList.RefreshByData(multiTemplateScrollViewRefreshContext);
			UUIInturnAnimController multiListAnimController = this.MultiListAnimController;
			if (multiListAnimController != null)
			{
				multiListAnimController.Play("", -1, true);
			}
			if (num >= 0)
			{
				this.SelectByGridIndex(num);
				return;
			}
			this.ShowEmptyDetail();
		}

		// Token: 0x060403C4 RID: 263108 RVA: 0x01076910 File Offset: 0x01074B10
		private void PushTitle(string titleKey)
		{
			RoverlikeCollectTitleTemplateData roverlikeCollectTitleTemplateData = new RoverlikeCollectTitleTemplateData();
			roverlikeCollectTitleTemplateData.Data = new RoverlikeCollectTitleData
			{
				TitleKey = titleKey
			};
			this.ScrollDataList.Add(roverlikeCollectTitleTemplateData);
		}

		// Token: 0x060403C5 RID: 263109 RVA: 0x01076944 File Offset: 0x01074B44
		private int PushGrid(RoverlikeGainEntry entry)
		{
			RoverlikeEntryGridItemTemplateData roverlikeEntryGridItemTemplateData = new RoverlikeEntryGridItemTemplateData();
			roverlikeEntryGridItemTemplateData.Data = entry;
			roverlikeEntryGridItemTemplateData.OnClickCb = new Action<RoverlikeGainEntry, int>(this.OnGridClick);
			roverlikeEntryGridItemTemplateData.IsSelected = new Func<RoverlikeGainEntry, int, bool>(this.IsGridSelected);
			this.ScrollDataList.Add(roverlikeEntryGridItemTemplateData);
			return this.ScrollDataList.Count - 1;
		}

		// Token: 0x060403C6 RID: 263110 RVA: 0x0107699C File Offset: 0x01074B9C
		private void PushEmpty(string txt)
		{
			RoverlikeCollectEmptyItemTemplateData roverlikeCollectEmptyItemTemplateData = new RoverlikeCollectEmptyItemTemplateData();
			RoverlikeCollectEmptyData data = new RoverlikeCollectEmptyData
			{
				Txt = txt
			};
			roverlikeCollectEmptyItemTemplateData.Data = data;
			this.ScrollDataList.Add(roverlikeCollectEmptyItemTemplateData);
		}

		// Token: 0x060403C7 RID: 263111 RVA: 0x010769D0 File Offset: 0x01074BD0
		private void SelectByGridIndex(int gridIndex)
		{
			int selectedGridIndex = this.SelectedGridIndex;
			this.SelectedGridIndex = gridIndex;
			if (selectedGridIndex >= 0 && selectedGridIndex != gridIndex)
			{
				this.MultiList.RefreshProxyDirectly(selectedGridIndex);
			}
			this.MultiList.RefreshProxyDirectly(gridIndex);
			RoverlikeGainEntry entry = this.ScrollDataList[gridIndex].Data as RoverlikeGainEntry;
			this.RefreshDetail(entry);
			if (selectedGridIndex >= 0 && selectedGridIndex != gridIndex)
			{
				UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
				if (uiViewSequence == null)
				{
					return;
				}
				uiViewSequence.PlayOrReplaySequenceByName("Switch", false, null);
			}
		}

		// Token: 0x060403C8 RID: 263112 RVA: 0x01076A54 File Offset: 0x01074C54
		[NullableContext(2)]
		private void RefreshDetail(RoverlikeGainEntry entry)
		{
			bool flag = entry != null && entry.Type == RoverRogueGainDataType.RoverRogueGainRoleEnhance;
			UUIItem item = base.GetItem(7);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(10);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UUIItem item3 = base.GetItem(6);
			if (item3 != null)
			{
				item3.SetUIActive(flag);
			}
			UUIItem item4 = base.GetItem(5);
			if (item4 != null)
			{
				item4.SetUIActive(!flag);
			}
			if (entry == null)
			{
				return;
			}
			if (flag)
			{
				RoverlikeReinforcementItemData data = new RoverlikeReinforcementItemData
				{
					ConfigId = entry.ConfigId,
					IncId = new int?(entry.IncId),
					AllowToggleInteract = new bool?(false)
				};
				RoverlikeReinforcementCardItem reinforceCard = this.ReinforceCard;
				if (reinforceCard == null)
				{
					return;
				}
				reinforceCard.Refresh(data, false, 0);
				return;
			}
			else
			{
				RoverlikePropItemData data2 = new RoverlikePropItemData
				{
					ConfigId = entry.ConfigId,
					IsInGame = true,
					IncId = new int?(entry.IncId)
				};
				RoverlikePropCardItem propCard = this.PropCard;
				if (propCard == null)
				{
					return;
				}
				propCard.Refresh(data2, false, 0);
				return;
			}
		}

		// Token: 0x060403C9 RID: 263113 RVA: 0x01076B48 File Offset: 0x01074D48
		private void ShowEmptyDetail()
		{
			UUIItem item = base.GetItem(6);
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
				item3.SetUIActive(false);
			}
			UUIItem item4 = base.GetItem(10);
			if (item4 == null)
			{
				return;
			}
			item4.SetUIActive(true);
		}

		// Token: 0x060403CA RID: 263114 RVA: 0x01076BA1 File Offset: 0x01074DA1
		private void OnGridClick(RoverlikeGainEntry data, int gridIndex)
		{
			if (gridIndex == this.SelectedGridIndex)
			{
				return;
			}
			this.SelectByGridIndex(gridIndex);
		}

		// Token: 0x060403CB RID: 263115 RVA: 0x01076BB4 File Offset: 0x01074DB4
		private bool IsGridSelected(RoverlikeGainEntry data, int gridIndex)
		{
			return gridIndex == this.SelectedGridIndex;
		}

		// Token: 0x04024042 RID: 147522
		[Nullable(2)]
		private MultiTemplateScrollView MultiList;

		// Token: 0x04024043 RID: 147523
		[Nullable(2)]
		private UUIInturnAnimController MultiListAnimController;

		// Token: 0x04024044 RID: 147524
		[Nullable(2)]
		private RoverlikeReinforcementCardItem ReinforceCard;

		// Token: 0x04024045 RID: 147525
		[Nullable(2)]
		private RoverlikePropCardItem PropCard;

		// Token: 0x04024046 RID: 147526
		private readonly List<IMultiTemplateGridData> ScrollDataList = new List<IMultiTemplateGridData>();

		// Token: 0x04024047 RID: 147527
		private int SelectedGridIndex = -1;

		// Token: 0x0200C454 RID: 50260
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x0403C6FE RID: 247550
			SvMulti,
			// Token: 0x0403C6FF RID: 247551
			PanelTitle,
			// Token: 0x0403C700 RID: 247552
			ItemBaseGrid,
			// Token: 0x0403C701 RID: 247553
			PanelEmpty,
			// Token: 0x0403C702 RID: 247554
			ItemBlessDetail,
			// Token: 0x0403C703 RID: 247555
			ItemPropDetail,
			// Token: 0x0403C704 RID: 247556
			ItemReinforceDetail,
			// Token: 0x0403C705 RID: 247557
			PanelEmptySlot,
			// Token: 0x0403C706 RID: 247558
			SprEmptyIcon,
			// Token: 0x0403C707 RID: 247559
			TxtEmptyName,
			// Token: 0x0403C708 RID: 247560
			PanelEmptyGeneral
		}
	}
}
