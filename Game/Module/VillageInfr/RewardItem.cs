using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C1D RID: 19485
	internal class RewardItem : GridProxyAbstract<int>
	{
		// Token: 0x06032D20 RID: 208160 RVA: 0x00CBBE0C File Offset: 0x00CBA00C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x06032D21 RID: 208161 RVA: 0x00CBBE68 File Offset: 0x00CBA068
		protected override void OnStart()
		{
			this.RewardItemGrid.Initialize(base.GetItem(2).GetOwner());
			this.RewardItemGrid.BindOnCanExecuteChange((object _, bool isOn, EToggleState toggleState) => false);
			this.RewardItemGrid.BindOnExtendToggleClicked(delegate(MediumItemGridExtendCallback callbackParameter)
			{
				InfrV2ScoreReward? scoreRewardById = ConfigBase<VillageInfrConfig>.Instance.GetScoreRewardById(this.Id);
				bool flag = ModelBase<VillageInfrModel>.Instance.GetRewardScore() >= scoreRewardById.Value.Score;
				if (!ModelBase<VillageInfrModel>.Instance.IsScoreRewardReceived(this.Id) && flag)
				{
					ControllerBase<VillageInfrController>.Instance.RequestInfrV2ScoreReward().Forget<bool>();
					return;
				}
				TItem? titem = callbackParameter.Data as TItem?;
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(titem.Value.ItemData.ItemId, true, null);
			});
		}

		// Token: 0x06032D22 RID: 208162 RVA: 0x00CBBED0 File Offset: 0x00CBA0D0
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.Id = data;
			InfrV2ScoreReward? scoreRewardById = ConfigBase<VillageInfrConfig>.Instance.GetScoreRewardById(this.Id);
			TItem titem = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(scoreRewardById.Value.DropId)[0];
			bool flag = ModelBase<VillageInfrModel>.Instance.GetRewardScore() >= scoreRewardById.Value.Score;
			bool flag2 = ModelBase<VillageInfrModel>.Instance.IsScoreRewardReceived(this.Id);
			this.RewardItemGrid.Apply<PropSmallItemGrid>(new PropSmallItemGrid
			{
				Data = titem,
				ItemConfigId = new int?(titem.ItemData.ItemId),
				IsReceivedVisible = new bool?(flag2),
				IsRedDotVisible = new bool?(flag && !flag2),
				IsReceivableVisible = new bool?(flag && !flag2),
				BottomText = titem.Count.ToString()
			});
			base.GetText(1).SetText(scoreRewardById.Value.Score.ToString(), true);
		}

		// Token: 0x0401D94D RID: 121165
		private int Id;

		// Token: 0x0401D94E RID: 121166
		[Nullable(1)]
		private readonly SmallItemGrid RewardItemGrid = new SmallItemGrid();
	}
}
