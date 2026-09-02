using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200518D RID: 20877
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoguelikeMemoryRewardItem : GridProxyAbstract<RoguelikeMemoryRewardItemData>
	{
		// Token: 0x06035B53 RID: 219987 RVA: 0x00D7E740 File Offset: 0x00D7C940
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnBtnRewardClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035B54 RID: 219988 RVA: 0x00D7E84C File Offset: 0x00D7CA4C
		private void OnBtnRewardClick()
		{
			int pointItem = ModelBase<RoguelikeModel>.Instance.GetParamConfigBySeasonId(null).Value.PointItem;
			if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(pointItem, 0) < this.Data.Config.Value.Point)
			{
				return;
			}
			RoguelikeController instance = ControllerBase<RoguelikeController>.Instance;
			List<int> list = new List<int>();
			RoguelikeMemoryRewardItemData data = this.Data;
			list.Add(((data != null) ? ((data.Config != null) ? new int?(data.Config.GetValueOrDefault().Index) : null) : null).GetValueOrDefault());
			instance.RoguelikeSeasonRewardReceiveRequest(list, null).ContinueWith(delegate(bool task)
			{
			});
		}

		// Token: 0x06035B55 RID: 219989 RVA: 0x00D7E936 File Offset: 0x00D7CB36
		protected override void OnStart()
		{
			if (this.GridItem == null)
			{
				this.GridItem = new CommonItemSmallItemGrid();
				this.GridItem.Initialize(base.GetItem(0).GetOwner());
			}
			this.GridItem.SetActive(false);
		}

		// Token: 0x06035B56 RID: 219990 RVA: 0x00D7E970 File Offset: 0x00D7CB70
		[NullableContext(1)]
		public override void Refresh(RoguelikeMemoryRewardItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			int pointItem = ModelBase<RoguelikeModel>.Instance.GetParamConfigBySeasonId(null).Value.PointItem;
			bool flag = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(pointItem, 0) >= data.Config.Value.Point;
			if (flag)
			{
				SeasonReward seasonReward = data.SeasonReward;
				if (seasonReward == null || !seasonReward.IsReceive)
				{
					base.GetButton(4).SetActive(true, false);
					goto IL_8C;
				}
			}
			base.GetButton(4).SetActive(false, false);
			IL_8C:
			this.GridItem.SetActive(true);
			List<KeyValuePair<int, int>> list = ConfigBase<RewardConfig>.Instance.GetDropPackagePreview(data.Config.Value.DropId).ToList<KeyValuePair<int, int>>();
			TItem data2 = new TItem(new InventoryDefine.GetItemData(list[0].Key, 0), list[0].Value);
			this.GridItem.Refresh(data2);
			base.GetText(1).SetText(data.Config.Value.Index.ToString(), true);
			base.GetSprite(2).useChangeColor = flag;
			base.GetSprite(3).useChangeColor = flag;
			base.GetSprite(3).SetUIActive(gridIndex != 0);
		}

		// Token: 0x0401ED27 RID: 126247
		public CommonItemSmallItemGrid GridItem;

		// Token: 0x0401ED28 RID: 126248
		public RoguelikeMemoryRewardItemData Data;
	}
}
