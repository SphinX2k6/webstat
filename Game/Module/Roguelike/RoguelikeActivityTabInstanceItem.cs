using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.InstanceDungeon.ExchangeReward;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200517E RID: 20862
	public class RoguelikeActivityTabInstanceItem : UiPanelBase
	{
		// Token: 0x06035ADF RID: 219871 RVA: 0x00D7BE04 File Offset: 0x00D7A004
		public RoguelikeActivityTabInstanceItem(int instanceId)
		{
			this.InstanceId = instanceId;
		}

		// Token: 0x06035AE0 RID: 219872 RVA: 0x00D7BE2C File Offset: 0x00D7A02C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035AE1 RID: 219873 RVA: 0x00D7BEF8 File Offset: 0x00D7A0F8
		protected override void OnStart()
		{
			this.Update(this.InstanceId);
		}

		// Token: 0x06035AE2 RID: 219874 RVA: 0x00D7BF08 File Offset: 0x00D7A108
		protected void Update(int instanceId)
		{
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), config.Value.MapName, Array.Empty<object>());
			int? instanceRewardId = ConfigBase<InstanceDungeonConfig>.Instance.GetInstanceRewardId(instanceId);
			List<TItem> exchangeRewardPreviewRewardList = ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeRewardPreviewRewardList(instanceRewardId.GetValueOrDefault(), null);
			this.RewardItemList = exchangeRewardPreviewRewardList;
			this.IsShowReward = (this.RewardItemList != null && this.RewardItemList.Count > 0);
			AActor owner = base.GetItem(3).GetOwner();
			UUIItem item = base.GetItem(2);
			bool receivedVisible = !ModelBase<ExchangeRewardModel>.Instance.GetInstanceDungeonIfCanExchange(instanceId);
			for (int i = 0; i < this.RewardItemList.Count; i++)
			{
				TItem data = this.RewardItemList[i];
				CommonItemSmallItemGrid commonItemSmallItemGrid = null;
				if (i < this.ItemGridList.Count)
				{
					commonItemSmallItemGrid = this.ItemGridList[i];
				}
				if (commonItemSmallItemGrid == null)
				{
					commonItemSmallItemGrid = new CommonItemSmallItemGrid();
					commonItemSmallItemGrid.Initialize(Singleton<LguiUtil>.Instance.DuplicateActor(owner, item));
					this.ItemGridList.Add(commonItemSmallItemGrid);
				}
				commonItemSmallItemGrid.Refresh(data);
				commonItemSmallItemGrid.SetReceivedVisible(receivedVisible);
				commonItemSmallItemGrid.SetActive(true);
			}
			for (int j = this.RewardItemList.Count; j < this.ItemGridList.Count; j++)
			{
				this.ItemGridList[j].SetActive(false);
			}
			base.GetItem(3).SetUIActive(false);
		}

		// Token: 0x0401ECFD RID: 126205
		public int InstanceId;

		// Token: 0x0401ECFE RID: 126206
		[Nullable(1)]
		public List<CommonItemSmallItemGrid> ItemGridList = new List<CommonItemSmallItemGrid>();

		// Token: 0x0401ECFF RID: 126207
		public bool IsShowReward;

		// Token: 0x0401ED00 RID: 126208
		[Nullable(1)]
		public List<TItem> RewardItemList = new List<TItem>();

		// Token: 0x0200B136 RID: 45366
		private class ERoguelikeActivityTabInstanceItemDefine
		{
			// Token: 0x04036F5F RID: 225119
			public const int SpriteIcon = 0;

			// Token: 0x04036F60 RID: 225120
			public const int TxtName = 1;

			// Token: 0x04036F61 RID: 225121
			public const int RewardContent = 2;

			// Token: 0x04036F62 RID: 225122
			public const int RewardItem = 3;

			// Token: 0x04036F63 RID: 225123
			public const int BtnConfirm = 4;
		}
	}
}
