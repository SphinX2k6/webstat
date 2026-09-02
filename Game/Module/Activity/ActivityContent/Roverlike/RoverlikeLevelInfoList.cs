using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006425 RID: 25637
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeLevelInfoList
	{
		// Token: 0x060405A7 RID: 263591 RVA: 0x0107E9AC File Offset: 0x0107CBAC
		public RoverlikeLevelInfoList(UUIScrollViewWithScrollbarComponent scrollView)
		{
			UUILayoutBase layout = scrollView.GetContent().GetComponentByClass(UUILayoutBase.StaticClass()) as UUILayoutBase;
			this.InfoLayout = new GenericLayout<RoverlikeLevelInfoItem, RoverlikeLevelInfoItemData>(layout, () => new RoverlikeLevelInfoItem(), null, false, true);
		}

		// Token: 0x060405A8 RID: 263592 RVA: 0x0107EA14 File Offset: 0x0107CC14
		public void RefreshByConfig(RoverRogueIns? cfg)
		{
			List<RoverlikeLevelInfoItemData> list = this.BuildInfoDataList(cfg);
			List<int> changedIndexList = this.DiffInfoDataList(this.LastInfoDataList, list);
			this.LastInfoDataList = list;
			this.InfoLayout.RefreshByData(list, delegate
			{
				this.PlayInfoItemRefreshAnim(changedIndexList);
			}, false);
		}

		// Token: 0x060405A9 RID: 263593 RVA: 0x0107EA6C File Offset: 0x0107CC6C
		private List<RoverlikeLevelInfoItemData> BuildInfoDataList(RoverRogueIns? cfg)
		{
			List<RoverlikeLevelInfoItemData> list = new List<RoverlikeLevelInfoItemData>();
			if (cfg == null)
			{
				return list;
			}
			RoverRogueIns value = cfg.Value;
			list.Add(new RoverlikeLevelInfoItemData
			{
				TextId = value.LevelRoomNumDesc,
				Params = (value.GetLevelRoomNumParamArray() ?? Array.Empty<int>())
			});
			list.Add(new RoverlikeLevelInfoItemData
			{
				TextId = value.LevelMonsterRateDesc,
				Params = (value.GetLevelMonsterRateParamArray() ?? Array.Empty<int>())
			});
			list.Add(new RoverlikeLevelInfoItemData
			{
				TextId = value.LevelRewardRateDesc,
				Params = (value.GetLevelRewardRateParamArray() ?? Array.Empty<int>())
			});
			for (int i = 0; i < value.LevelDetailDescLength; i++)
			{
				IntArray? intArray = value.LevelDetailParam(i);
				list.Add(new RoverlikeLevelInfoItemData
				{
					TextId = value.LevelDetailDesc(i),
					Params = (((intArray != null) ? intArray.GetValueOrDefault().GetArrayIntArray() : null) ?? Array.Empty<int>())
				});
			}
			return list;
		}

		// Token: 0x060405AA RID: 263594 RVA: 0x0107EB7C File Offset: 0x0107CD7C
		private List<int> DiffInfoDataList(IReadOnlyList<RoverlikeLevelInfoItemData> oldList, IReadOnlyList<RoverlikeLevelInfoItemData> newList)
		{
			List<int> list = new List<int>();
			if (oldList.Count == 0)
			{
				return list;
			}
			for (int i = 0; i < newList.Count; i++)
			{
				RoverlikeLevelInfoItemData roverlikeLevelInfoItemData = newList[i];
				RoverlikeLevelInfoItemData roverlikeLevelInfoItemData2 = (i < oldList.Count) ? oldList[i] : null;
				if (roverlikeLevelInfoItemData2 == null || roverlikeLevelInfoItemData2.TextId != roverlikeLevelInfoItemData.TextId || !this.IsNumberArrayEqual(roverlikeLevelInfoItemData2.Params, roverlikeLevelInfoItemData.Params))
				{
					list.Add(i);
				}
			}
			return list;
		}

		// Token: 0x060405AB RID: 263595 RVA: 0x0107EBF8 File Offset: 0x0107CDF8
		private bool IsNumberArrayEqual(IReadOnlyList<int> a, IReadOnlyList<int> b)
		{
			if (a.Count != b.Count)
			{
				return false;
			}
			for (int i = 0; i < a.Count; i++)
			{
				if (a[i] != b[i])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060405AC RID: 263596 RVA: 0x0107EC3C File Offset: 0x0107CE3C
		private void PlayInfoItemRefreshAnim(IReadOnlyList<int> changedIndexList)
		{
			foreach (int index in changedIndexList)
			{
				RoverlikeLevelInfoItem layoutItemByIndex = this.InfoLayout.GetLayoutItemByIndex(index);
				if (layoutItemByIndex != null)
				{
					layoutItemByIndex.PlayRefreshAnim();
				}
			}
		}

		// Token: 0x040240E9 RID: 147689
		private readonly GenericLayout<RoverlikeLevelInfoItem, RoverlikeLevelInfoItemData> InfoLayout;

		// Token: 0x040240EA RID: 147690
		private List<RoverlikeLevelInfoItemData> LastInfoDataList = new List<RoverlikeLevelInfoItemData>();
	}
}
