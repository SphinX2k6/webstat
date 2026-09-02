using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063EE RID: 25582
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeDetailBlessTabView : UiTabViewBase
	{
		// Token: 0x060403AD RID: 263085 RVA: 0x01075CAC File Offset: 0x01073EAC
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
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060403AE RID: 263086 RVA: 0x01075E44 File Offset: 0x01074044
		protected override UniTask OnBeforeStartAsync()
		{
			RoverlikeDetailBlessTabView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoverlikeDetailBlessTabView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060403AF RID: 263087 RVA: 0x01075E87 File Offset: 0x01074087
		protected override void OnStart()
		{
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(6);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			this.RefreshList();
		}

		// Token: 0x060403B0 RID: 263088 RVA: 0x01075EB5 File Offset: 0x010740B5
		protected override void OnShowUiTabViewFromToggle()
		{
			if (this.MultiList != null)
			{
				this.RefreshList();
			}
		}

		// Token: 0x060403B1 RID: 263089 RVA: 0x01075EC5 File Offset: 0x010740C5
		protected override void OnBeforeDestroy()
		{
			this.MultiListAnimController = null;
		}

		// Token: 0x060403B2 RID: 263090 RVA: 0x01075ED0 File Offset: 0x010740D0
		private void RefreshList()
		{
			this.ScrollDataList.Clear();
			this.SelectedGridIndex = -1;
			RoverlikeInstanceData instanceData = ModelBase<RoverlikeModel>.Instance.InstanceData;
			List<RoverlikeGainEntry> list = ((instanceData != null) ? instanceData.GetBlessList() : null) ?? new List<RoverlikeGainEntry>();
			RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
			int[] array;
			if (instance == null)
			{
				array = null;
			}
			else
			{
				RoverlikeActivityData currentActivityData = instance.GetCurrentActivityData();
				array = ((currentActivityData != null) ? currentActivityData.GetParamConfig().Value.SlotList() : null);
			}
			int[] array2 = array ?? Array.Empty<int>();
			HashSet<int> hashSet = new HashSet<int>(array2);
			Dictionary<int, RoverlikeGainEntry> dictionary = new Dictionary<int, RoverlikeGainEntry>();
			List<RoverlikeGainEntry> list2 = new List<RoverlikeGainEntry>();
			foreach (RoverlikeGainEntry roverlikeGainEntry in list)
			{
				RoverRogueBless? blessConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessConfig(roverlikeGainEntry.ConfigId);
				if (blessConfig != null && hashSet.Contains(blessConfig.Value.SlotId))
				{
					dictionary[blessConfig.Value.SlotId] = roverlikeGainEntry;
				}
				else
				{
					list2.Add(roverlikeGainEntry);
				}
			}
			this.PushTitle("RoverRogue_SystemShow_CoreBlessing");
			int count = this.ScrollDataList.Count;
			this.SlotList = new List<int>(array2);
			this.FirstSlotIndex = count;
			foreach (int key in array2)
			{
				RoverlikeGainEntry roverlikeGainEntry2;
				dictionary.TryGetValue(key, out roverlikeGainEntry2);
				RoverlikeGainEntry entry = roverlikeGainEntry2 ?? new RoverlikeGainEntry();
				this.PushGrid(entry, true);
			}
			RoverlikeInstanceData.SortGainEntryList(list2);
			this.PushTitle("RoverRogue_SystemShow_NormalBlessing");
			if (list2.Count > 0)
			{
				using (List<RoverlikeGainEntry>.Enumerator enumerator = list2.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						RoverlikeGainEntry entry2 = enumerator.Current;
						this.PushGrid(entry2, false);
					}
					goto IL_1C4;
				}
			}
			this.PushEmpty("RoverRogue_BlessingNotGet");
			IL_1C4:
			MultiTemplateScrollViewRefreshContext multiTemplateScrollViewRefreshContext = new MultiTemplateScrollViewRefreshContext(this.ScrollDataList);
			multiTemplateScrollViewRefreshContext.ScrollToGridIndex = 0;
			this.MultiList.RefreshByData(multiTemplateScrollViewRefreshContext);
			UUIInturnAnimController multiListAnimController = this.MultiListAnimController;
			if (multiListAnimController != null)
			{
				multiListAnimController.Play("", -1, true);
			}
			this.SelectByGridIndex(count);
		}

		// Token: 0x060403B3 RID: 263091 RVA: 0x01076100 File Offset: 0x01074300
		private void PushTitle(string titleKey)
		{
			RoverlikeCollectTitleTemplateData roverlikeCollectTitleTemplateData = new RoverlikeCollectTitleTemplateData();
			roverlikeCollectTitleTemplateData.Data = new RoverlikeCollectTitleData
			{
				TitleKey = titleKey
			};
			this.ScrollDataList.Add(roverlikeCollectTitleTemplateData);
		}

		// Token: 0x060403B4 RID: 263092 RVA: 0x01076134 File Offset: 0x01074334
		private int PushGrid(RoverlikeGainEntry entry, bool isSlotGroup = false)
		{
			RoverlikeEntryGridItemTemplateData roverlikeEntryGridItemTemplateData = new RoverlikeEntryGridItemTemplateData();
			roverlikeEntryGridItemTemplateData.Data = entry;
			roverlikeEntryGridItemTemplateData.OnClickCb = new Action<RoverlikeGainEntry, int>(this.OnGridClick);
			roverlikeEntryGridItemTemplateData.IsSelected = new Func<RoverlikeGainEntry, int, bool>(this.IsGridSelected);
			if (isSlotGroup)
			{
				roverlikeEntryGridItemTemplateData.GetSlotId = new Func<int, int>(this.GetSlotIdByGridIndex);
			}
			this.ScrollDataList.Add(roverlikeEntryGridItemTemplateData);
			return this.ScrollDataList.Count - 1;
		}

		// Token: 0x060403B5 RID: 263093 RVA: 0x010761A0 File Offset: 0x010743A0
		private int GetSlotIdByGridIndex(int gridIndex)
		{
			int num = gridIndex - this.FirstSlotIndex;
			if (this.FirstSlotIndex < 0 || num < 0 || num >= this.SlotList.Count)
			{
				return 0;
			}
			return this.SlotList[num];
		}

		// Token: 0x060403B6 RID: 263094 RVA: 0x010761E0 File Offset: 0x010743E0
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

		// Token: 0x060403B7 RID: 263095 RVA: 0x01076214 File Offset: 0x01074414
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

		// Token: 0x060403B8 RID: 263096 RVA: 0x01076298 File Offset: 0x01074498
		[NullableContext(2)]
		private void RefreshDetail(RoverlikeGainEntry entry)
		{
			if (entry == null || entry.ConfigId <= 0)
			{
				int num = this.SelectedGridIndex - this.FirstSlotIndex;
				if (this.FirstSlotIndex >= 0 && num >= 0 && num < this.SlotList.Count)
				{
					this.ShowSlotEmptyDetail(this.SlotList[num]);
					return;
				}
				this.ShowEmptyDetail();
				return;
			}
			else
			{
				UUIItem item = base.GetItem(4);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				UUIItem item2 = base.GetItem(7);
				if (item2 != null)
				{
					item2.SetUIActive(false);
				}
				UUIItem item3 = base.GetItem(10);
				if (item3 != null)
				{
					item3.SetUIActive(false);
				}
				RoverlikeBlessingItemData data = new RoverlikeBlessingItemData
				{
					BlessId = entry.ConfigId,
					IncId = new int?(entry.IncId),
					AllowToggleInteract = new bool?(false)
				};
				RoverlikeBlessingCardItem detailCard = this.DetailCard;
				if (detailCard == null)
				{
					return;
				}
				detailCard.Refresh(data, false, 0);
				return;
			}
		}

		// Token: 0x060403B9 RID: 263097 RVA: 0x01076370 File Offset: 0x01074570
		private void ShowSlotEmptyDetail(int slotId)
		{
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(10);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UUIItem item3 = base.GetItem(7);
			if (item3 != null)
			{
				item3.SetUIActive(true);
			}
			RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
			RoverRogueActivity? roverRogueActivity;
			if (instance == null)
			{
				roverRogueActivity = null;
			}
			else
			{
				RoverlikeActivityData currentActivityData = instance.GetCurrentActivityData();
				roverRogueActivity = ((currentActivityData != null) ? currentActivityData.GetParamConfig() : null);
			}
			RoverRogueActivity? roverRogueActivity2 = roverRogueActivity;
			if (roverRogueActivity2 == null)
			{
				return;
			}
			RoverRogueActivity value = roverRogueActivity2.Value;
			string text = null;
			for (int i = 0; i < value.SlotEmptyIconLength; i++)
			{
				DicIntString? dicIntString = value.SlotEmptyIcon(i);
				if (dicIntString != null && dicIntString.GetValueOrDefault().Key == slotId)
				{
					text = dicIntString.Value.Value;
					break;
				}
			}
			UUITexture texture = base.GetTexture(8);
			if (texture != null)
			{
				if (text != null)
				{
					base.SetTextureShowUntilLoaded(text, texture, null);
				}
				else
				{
					texture.SetUIActive(false);
				}
			}
			string text2 = null;
			for (int j = 0; j < value.SlotNameLength; j++)
			{
				DicIntString? dicIntString2 = value.SlotName(j);
				if (dicIntString2 != null && dicIntString2.GetValueOrDefault().Key == slotId)
				{
					text2 = dicIntString2.Value.Value;
					break;
				}
			}
			UUIText text3 = base.GetText(9);
			if (text3 != null && text2 != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text3, text2, Array.Empty<object>());
			}
		}

		// Token: 0x060403BA RID: 263098 RVA: 0x010764EE File Offset: 0x010746EE
		private void ShowEmptyDetail()
		{
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(7);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UUIItem item3 = base.GetItem(10);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(true);
		}

		// Token: 0x060403BB RID: 263099 RVA: 0x01076529 File Offset: 0x01074729
		private void OnGridClick(RoverlikeGainEntry data, int gridIndex)
		{
			if (gridIndex == this.SelectedGridIndex)
			{
				return;
			}
			this.SelectByGridIndex(gridIndex);
		}

		// Token: 0x060403BC RID: 263100 RVA: 0x0107653C File Offset: 0x0107473C
		private bool IsGridSelected(RoverlikeGainEntry data, int gridIndex)
		{
			return gridIndex == this.SelectedGridIndex;
		}

		// Token: 0x0402403B RID: 147515
		[Nullable(2)]
		private MultiTemplateScrollView MultiList;

		// Token: 0x0402403C RID: 147516
		[Nullable(2)]
		private UUIInturnAnimController MultiListAnimController;

		// Token: 0x0402403D RID: 147517
		[Nullable(2)]
		private RoverlikeBlessingCardItem DetailCard;

		// Token: 0x0402403E RID: 147518
		private readonly List<IMultiTemplateGridData> ScrollDataList = new List<IMultiTemplateGridData>();

		// Token: 0x0402403F RID: 147519
		private int SelectedGridIndex = -1;

		// Token: 0x04024040 RID: 147520
		private List<int> SlotList = new List<int>();

		// Token: 0x04024041 RID: 147521
		private int FirstSlotIndex = -1;

		// Token: 0x0200C452 RID: 50258
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x0403C6EE RID: 247534
			SvMulti,
			// Token: 0x0403C6EF RID: 247535
			PanelTitle,
			// Token: 0x0403C6F0 RID: 247536
			ItemBaseGrid,
			// Token: 0x0403C6F1 RID: 247537
			PanelEmpty,
			// Token: 0x0403C6F2 RID: 247538
			ItemBlessDetail,
			// Token: 0x0403C6F3 RID: 247539
			ItemPropDetail,
			// Token: 0x0403C6F4 RID: 247540
			ItemReinforceDetail,
			// Token: 0x0403C6F5 RID: 247541
			PanelEmptySlot,
			// Token: 0x0403C6F6 RID: 247542
			TexEmptyIcon,
			// Token: 0x0403C6F7 RID: 247543
			TxtEmptyName,
			// Token: 0x0403C6F8 RID: 247544
			PanelEmptyGeneral
		}
	}
}
