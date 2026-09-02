using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.InstanceDungeon.ExchangeReward;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BCF RID: 23503
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class InstanceTipGrid : GridProxyAbstract<IInstanceTipGridData>
	{
		// Token: 0x0603B82B RID: 243755 RVA: 0x00F16506 File Offset: 0x00F14706
		public void Initialize(UUIItem uiItem)
		{
			this.CreateThenShowByActor(uiItem.GetOwner());
		}

		// Token: 0x0603B82C RID: 243756 RVA: 0x00F16514 File Offset: 0x00F14714
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B82D RID: 243757 RVA: 0x00F165E0 File Offset: 0x00F147E0
		protected override void OnBeforeDestroy()
		{
			foreach (CommonItemSmallItemGrid commonItemSmallItemGrid in this.ItemGridList)
			{
				commonItemSmallItemGrid.Destroy(null);
			}
			this.ItemGridList.Clear();
		}

		// Token: 0x0603B82E RID: 243758 RVA: 0x00F1663C File Offset: 0x00F1483C
		public override void Refresh(IInstanceTipGridData gridData, bool isSelected, int gridIndex)
		{
			this.InstanceId = gridData.InstanceId;
			this.IsDouble = gridData.IsDouble;
			this.UpdateRewardPreview();
			this.UpdateButtonState();
			this.UpdateRewardText();
		}

		// Token: 0x0603B82F RID: 243759 RVA: 0x00F16668 File Offset: 0x00F14868
		public void ClearGrid()
		{
			foreach (CommonItemSmallItemGrid commonItemSmallItemGrid in this.ItemGridList)
			{
				commonItemSmallItemGrid.Destroy(null);
			}
			this.ItemGridList.Clear();
		}

		// Token: 0x0603B830 RID: 243760 RVA: 0x00F166C4 File Offset: 0x00F148C4
		private void UpdateRewardPreview()
		{
			InstanceDungeonConfig instance = ConfigBase<InstanceDungeonConfig>.Instance;
			InstanceDungeon? instanceDungeon = (instance != null) ? instance.GetConfig(this.InstanceId) : null;
			if (instanceDungeon == null)
			{
				return;
			}
			List<int> list = new List<int>();
			list.AddRange(instanceDungeon.Value.GetCustomTypesBytes());
			ActivityDoubleRewardController instance2 = ControllerBase<ActivityDoubleRewardController>.Instance;
			ActivityDoubleRewardData activityDoubleRewardData = (instance2 != null) ? instance2.GetDungeonUpActivity(list, true) : null;
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(activityDoubleRewardData != null || this.IsDouble);
			}
			int? instanceRewardId = ConfigBase<InstanceDungeonConfig>.Instance.GetInstanceRewardId(this.InstanceId);
			this.RewardItemList = ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeRewardPreviewRewardList(instanceRewardId.GetValueOrDefault(), null);
			this.IsShowReward = (this.RewardItemList != null && this.RewardItemList.Count > 0);
			UUIItem item2 = base.GetItem(2);
			AActor actor = (item2 != null) ? item2.GetOwner() : null;
			UUIItem item3 = base.GetItem(1);
			int num = 0;
			ExchangeRewardModel instance3 = ModelBase<ExchangeRewardModel>.Instance;
			bool flag;
			if (instance3 == null || !instance3.IsFinishInstance(this.InstanceId))
			{
				ExchangeRewardModel instance4 = ModelBase<ExchangeRewardModel>.Instance;
				flag = (instance4 != null && instance4.IsFinishInstanceCompatible(this.InstanceId));
			}
			else
			{
				flag = true;
			}
			bool receivedVisible = flag;
			if (this.RewardItemList != null)
			{
				foreach (TItem data in this.RewardItemList)
				{
					CommonItemSmallItemGrid commonItemSmallItemGrid;
					if (num < this.ItemGridList.Count)
					{
						commonItemSmallItemGrid = this.ItemGridList[num];
					}
					else
					{
						commonItemSmallItemGrid = new CommonItemSmallItemGrid();
						AActor aactor = Singleton<LguiUtil>.Instance.DuplicateActor(actor, item3);
						if (aactor != null)
						{
							commonItemSmallItemGrid.Initialize(aactor);
							this.ItemGridList.Add(commonItemSmallItemGrid);
						}
					}
					num++;
					commonItemSmallItemGrid.Refresh(data);
					commonItemSmallItemGrid.SetReceivedVisible(receivedVisible);
					commonItemSmallItemGrid.SetActive(true);
				}
			}
			for (int i = num; i < this.ItemGridList.Count; i++)
			{
				this.ItemGridList[i].SetActive(false);
			}
			UUIItem item4 = base.GetItem(2);
			if (item4 == null)
			{
				return;
			}
			item4.SetUIActive(false);
		}

		// Token: 0x0603B831 RID: 243761 RVA: 0x00F168F8 File Offset: 0x00F14AF8
		private void UpdateButtonState()
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetUIActive(this.IsShowReward && this.IsShowDetail);
		}

		// Token: 0x0603B832 RID: 243762 RVA: 0x00F1691C File Offset: 0x00F14B1C
		private void UpdateRewardText()
		{
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(this.InstanceId);
			if (config == null)
			{
				return;
			}
			if (config.Value.InstSubType == 11)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), config.Value.MapName, Array.Empty<object>());
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "Text_ProbReward_Text", Array.Empty<object>());
		}

		// Token: 0x04021844 RID: 137284
		private int InstanceId;

		// Token: 0x04021845 RID: 137285
		private bool IsDouble;

		// Token: 0x04021846 RID: 137286
		[Nullable(2)]
		private List<TItem> RewardItemList;

		// Token: 0x04021847 RID: 137287
		private readonly bool IsShowDetail = true;

		// Token: 0x04021848 RID: 137288
		private bool IsShowReward;

		// Token: 0x04021849 RID: 137289
		private readonly List<CommonItemSmallItemGrid> ItemGridList = new List<CommonItemSmallItemGrid>();

		// Token: 0x0200BC39 RID: 48185
		[NullableContext(0)]
		public static class EChildCom
		{
			// Token: 0x0403A0E1 RID: 237793
			public const int UiTextInstanceTitle = 0;

			// Token: 0x0403A0E2 RID: 237794
			public const int UiItemContainer = 1;

			// Token: 0x0403A0E3 RID: 237795
			public const int UiItemItem = 2;

			// Token: 0x0403A0E4 RID: 237796
			public const int BtnPreView = 3;

			// Token: 0x0403A0E5 RID: 237797
			public const int DoubleLabel = 4;
		}
	}
}
