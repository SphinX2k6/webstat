using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005180 RID: 20864
	public class RoguelikeActivityTabView : UiTabViewBase
	{
		// Token: 0x06035AE9 RID: 219881 RVA: 0x00D7C21C File Offset: 0x00D7A41C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035AEA RID: 219882 RVA: 0x00D7C30C File Offset: 0x00D7A50C
		protected override void OnStart()
		{
			this.ScrollView = new GenericScrollView<RoguelikeActivityTabInstanceItem>(base.GetScrollViewWithScrollbar(0), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<RoguelikeActivityTabInstanceItem>(this.CreateItem), null);
			IReadOnlyList<RogueSeason> rogueSeasonConfigList = ConfigBase<RoguelikeConfig>.Instance.GetRogueSeasonConfigList();
			for (int i = 0; i < rogueSeasonConfigList.Count; i++)
			{
				RoguelikeActivityTabItem roguelikeActivityTabItem = new RoguelikeActivityTabItem(rogueSeasonConfigList[i].Id, i);
				UUIItem uuiitem = Singleton<LguiUtil>.Instance.CopyItem(base.GetItem(5), base.GetItem(4));
				roguelikeActivityTabItem.SetRootActor(uuiitem.GetOwner(), true);
				this.TabList.Add(roguelikeActivityTabItem);
				if (i == 0)
				{
					roguelikeActivityTabItem.SetToggleState(EToggleState.ETT_Checked);
					this.OnSelectSeason(rogueSeasonConfigList[i].Id, i);
				}
			}
			base.GetItem(5).SetUIActive(false);
		}

		// Token: 0x06035AEB RID: 219883 RVA: 0x00D7C3CC File Offset: 0x00D7A5CC
		[NullableContext(1)]
		private ILayoutItem<RoguelikeActivityTabInstanceItem> CreateItem(object data, UUIItem uiItem, int index)
		{
			RoguelikeActivityTabInstanceItem roguelikeActivityTabInstanceItem = new RoguelikeActivityTabInstanceItem((int)data);
			roguelikeActivityTabInstanceItem.SetRootActor(uiItem.GetOwner(), true);
			return new LayoutItem<RoguelikeActivityTabInstanceItem>
			{
				Key = index,
				Value = roguelikeActivityTabInstanceItem
			};
		}

		// Token: 0x06035AEC RID: 219884 RVA: 0x00D7C40A File Offset: 0x00D7A60A
		protected override void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.RoguelikeSelectSeason, new Action<int, int>(this.OnSelectSeason));
		}

		// Token: 0x06035AED RID: 219885 RVA: 0x00D7C428 File Offset: 0x00D7A628
		protected override void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.RoguelikeSelectSeason, new Action<int, int>(this.OnSelectSeason));
		}

		// Token: 0x06035AEE RID: 219886 RVA: 0x00D7C448 File Offset: 0x00D7A648
		protected void OnSelectSeason(int seasonId, int selectIndex)
		{
			RoguelikeActivityTabItem roguelikeActivityTabItem = this.TabList[this.SelectIndex];
			if (roguelikeActivityTabItem != null)
			{
				roguelikeActivityTabItem.SetToggleState(EToggleState.ETT_UnChecked);
			}
			this.SelectIndex = selectIndex;
			RogueSeason? rogueSeasonConfigById = ConfigBase<RoguelikeConfig>.Instance.GetRogueSeasonConfigById(seasonId);
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(rogueSeasonConfigById.Value.PointItem, 0);
			RogueParam? paramConfigBySeasonId = ModelBase<RoguelikeModel>.Instance.GetParamConfigBySeasonId(new int?(seasonId));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "Roguelike_ActivityTab_Currency", new <>z__ReadOnlyArray<object>(new object[]
			{
				itemCountByConfigId,
				paramConfigBySeasonId.Value.PointItemMaxCount
			}));
			InstanceDungeonEntrance? config = ConfigBase<InstanceDungeonEntranceConfig>.Instance.GetConfig(rogueSeasonConfigById.Value.InstanceDungeonEntrance);
			this.ScrollView.RefreshByData<int>(config.Value.InstanceDungeonList().ToList<int>(), new int?(config.Value.InstanceDungeonListLength));
		}

		// Token: 0x06035AEF RID: 219887 RVA: 0x00D7C544 File Offset: 0x00D7A744
		protected override void OnBeforeShow()
		{
			this.OnSelectSeason(this.TabList[this.SelectIndex].SeasonId, this.SelectIndex);
		}

		// Token: 0x0401ED03 RID: 126211
		[Nullable(1)]
		public List<RoguelikeActivityTabItem> TabList = new List<RoguelikeActivityTabItem>();

		// Token: 0x0401ED04 RID: 126212
		public int SelectIndex;

		// Token: 0x0401ED05 RID: 126213
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public GenericScrollView<RoguelikeActivityTabInstanceItem> ScrollView;

		// Token: 0x0200B138 RID: 45368
		private class ERoguelikeActivityTabViewDefine
		{
			// Token: 0x04036F67 RID: 225127
			public const int DungeonScrollView = 0;

			// Token: 0x04036F68 RID: 225128
			public const int DungeonScrollViewItem = 1;

			// Token: 0x04036F69 RID: 225129
			public const int TxtItemCount = 2;

			// Token: 0x04036F6A RID: 225130
			public const int TxtTime = 3;

			// Token: 0x04036F6B RID: 225131
			public const int TabContent = 4;

			// Token: 0x04036F6C RID: 225132
			public const int TabContentItem = 5;
		}
	}
}
