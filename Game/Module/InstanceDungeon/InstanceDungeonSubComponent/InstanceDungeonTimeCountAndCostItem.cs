using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.InstanceDungeon.ExchangeReward;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonSubComponent
{
	// Token: 0x02005BF9 RID: 23545
	public class InstanceDungeonTimeCountAndCostItem : UiPanelBase
	{
		// Token: 0x0603B94E RID: 244046 RVA: 0x00F1AB1C File Offset: 0x00F18D1C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B94F RID: 244047 RVA: 0x00F1ABA8 File Offset: 0x00F18DA8
		public void RefreshItem(TItem item, int instanceId)
		{
			int rewardId = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId).Value.RewardId;
			ExchangeReward? exchangeReward;
			int? id = (ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeRewardConfig(new int?(rewardId)) != null) ? new int?(exchangeReward.GetValueOrDefault().SharedId) : null;
			if (id != null && id.Value != 0)
			{
				ExchangeShared? exchangeShareConfig = ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeShareConfig(id);
				int exchangeRewardShareCount = ModelBase<ExchangeRewardModel>.Instance.GetExchangeRewardShareCount(id.Value);
				int maxCount = exchangeShareConfig.Value.MaxCount;
				int num = maxCount - exchangeRewardShareCount;
				int num2 = (num >= 0) ? num : 0;
				if (num2 == 0)
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "InstanceCanRewardTimesDepleted", new <>z__ReadOnlyArray<object>(new object[]
					{
						num2,
						maxCount
					}));
				}
				else
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "InstanceCanRewardTimes", new <>z__ReadOnlySingleElementList<object>(num2.ToString() + "/" + maxCount.ToString()));
				}
			}
			bool flag = item.ItemData.ItemId == 5 && !ModelBase<PowerModel>.Instance.IsPowerEnough(new int?(item.Count));
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.SetText("x" + item.Count.ToString(), true);
			}
			if (text != null)
			{
				UUIItem uuiitem = text;
				bool bUseChangeColor = flag;
				FColor? fcolor = new FColor?(text.changeColor);
				uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			}
			base.SetItemIcon(base.GetTexture(0), item.ItemData.ItemId, null, null);
		}

		// Token: 0x0200BC6F RID: 48239
		private enum EChildType
		{
			// Token: 0x0403A1A4 RID: 237988
			ItemIconTex,
			// Token: 0x0403A1A5 RID: 237989
			TimeCountTxt,
			// Token: 0x0403A1A6 RID: 237990
			ItemCountNumTxt
		}
	}
}
