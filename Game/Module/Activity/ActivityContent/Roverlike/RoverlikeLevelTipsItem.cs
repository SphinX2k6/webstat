using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063FF RID: 25599
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeLevelTipsItem : UiPanelBase
	{
		// Token: 0x0604045F RID: 263263 RVA: 0x01078E48 File Offset: 0x01077048
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040460 RID: 263264 RVA: 0x01078F38 File Offset: 0x01077138
		protected override UniTask OnBeforeStartAsync()
		{
			RoverlikeLevelTipsItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoverlikeLevelTipsItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040461 RID: 263265 RVA: 0x01078F7C File Offset: 0x0107717C
		protected override void OnStart()
		{
			this.LineLayout = new GenericLayout<RoverlikeRogueLevelLineItem, IRoverlikeRogueLevelLineData>(base.GetHorizontalLayout(1), new Func<RoverlikeRogueLevelLineItem>(this.CreateLevelLineItem), base.GetItem(2).GetOwner() as AUIBaseActor, false, true);
			base.GetItem(5).SetUIActive(false);
			base.GetText(4).SetUIActive(true);
		}

		// Token: 0x06040462 RID: 263266 RVA: 0x01078FD4 File Offset: 0x010771D4
		private RoverlikeRogueLevelLineItem CreateLevelLineItem()
		{
			return new RoverlikeRogueLevelLineItem();
		}

		// Token: 0x06040463 RID: 263267 RVA: 0x01078FDC File Offset: 0x010771DC
		public void Refresh(RoverlikeInstanceData instanceData, bool combinationText, [Nullable(2)] Action callback = null)
		{
			List<IRoverlikeRogueLevelLineData> dataList = this.BuildLevelLineDataList(instanceData);
			this.RefreshTips(instanceData, combinationText);
			this.RefreshLines(dataList, callback);
		}

		// Token: 0x06040464 RID: 263268 RVA: 0x01079001 File Offset: 0x01077201
		public void PlayCurrentLevelSequence(string sequenceName)
		{
			RoverlikeRogueLevelLineItem levelLineItem = this.GetLevelLineItem(this.CurrentLevelIndex);
			if (levelLineItem == null)
			{
				return;
			}
			levelLineItem.PlayCurrentNodeSequence(sequenceName);
		}

		// Token: 0x06040465 RID: 263269 RVA: 0x0107901A File Offset: 0x0107721A
		public void SetEffectPanelVisible(bool bVisible)
		{
			base.GetItem(5).SetUIActive(bVisible);
		}

		// Token: 0x06040466 RID: 263270 RVA: 0x0107902C File Offset: 0x0107722C
		private void RefreshTips(RoverlikeInstanceData instanceData, bool combinationText)
		{
			RoverRogueRoomType? roomTypeConfig = ConfigBase<RoverlikeConfig>.Instance.GetRoomTypeConfig(instanceData.CurRoomTypeId);
			string text = (roomTypeConfig != null) ? (ConfigMultiTextLang.GetLocalTextNew(roomTypeConfig.Value.Name, null) ?? "") : "";
			IReadOnlyList<RoverRogueRoad> roadByRoadType = ConfigBase<RoverlikeConfig>.Instance.GetRoadByRoadType(instanceData.RoadTypeId);
			int count = roadByRoadType.Count;
			int num = instanceData.CurLayer - 1;
			ValueTuple<int, int> currentFloorRange = this.GetCurrentFloorRange(instanceData, num, count);
			int item = currentFloorRange.Item1;
			int item2 = currentFloorRange.Item2;
			int num2 = num - item + 1;
			int num3 = item2 - item;
			int currentFloorNumber = this.GetCurrentFloorNumber(instanceData, num);
			if (combinationText)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "RoverRogue_ProcessingFloor", new <>z__ReadOnlyArray<object>(new object[]
				{
					num2,
					num3,
					currentFloorNumber,
					text
				}));
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "RoverRogue_RoomTypeTitle", new <>z__ReadOnlyArray<object>(new object[]
				{
					currentFloorNumber,
					text
				}));
			}
			int? num4 = (num >= 0 && num < roadByRoadType.Count) ? new int?(roadByRoadType[num].LayerType) : null;
			if (num4.GetValueOrDefault() == 2)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "RoverRogue_RoomProcessTitleLittleBoss", Array.Empty<object>());
				return;
			}
			if (num4.GetValueOrDefault() == 3)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "RoverRogue_RoomProcessTitleBigBoss", Array.Empty<object>());
			}
		}

		// Token: 0x06040467 RID: 263271 RVA: 0x010791C4 File Offset: 0x010773C4
		private void RefreshLines(List<IRoverlikeRogueLevelLineData> dataList, [Nullable(2)] Action callback = null)
		{
			if (dataList.Count == 0)
			{
				this.CurrentLevelIndex = -1;
				if (callback != null)
				{
					callback();
				}
				return;
			}
			int num = dataList.Count - 1;
			this.CurrentLevelIndex = dataList.FindIndex((IRoverlikeRogueLevelLineData data) => data.IsCurrent);
			GenericLayout<RoverlikeRogueLevelLineItem, IRoverlikeRogueLevelLineData> lineLayout = this.LineLayout;
			if (lineLayout != null)
			{
				lineLayout.RefreshByData(dataList.GetRange(0, num), callback, false);
			}
			RoverlikeRogueLevelLineItem lastNode = this.LastNode;
			if (lastNode != null)
			{
				lastNode.Refresh(dataList[num], false, num);
			}
			RoverlikeRogueLevelLineItem lastNode2 = this.LastNode;
			if (lastNode2 == null)
			{
				return;
			}
			lastNode2.SetActive(true);
		}

		// Token: 0x06040468 RID: 263272 RVA: 0x01079264 File Offset: 0x01077464
		[NullableContext(2)]
		private RoverlikeRogueLevelLineItem GetLevelLineItem(int index)
		{
			if (index < 0)
			{
				return null;
			}
			GenericLayout<RoverlikeRogueLevelLineItem, IRoverlikeRogueLevelLineData> lineLayout = this.LineLayout;
			IReadOnlyList<IRoverlikeRogueLevelLineData> readOnlyList = (lineLayout != null) ? lineLayout.GetDatas() : null;
			if (readOnlyList == null || index >= readOnlyList.Count)
			{
				return this.LastNode;
			}
			GenericLayout<RoverlikeRogueLevelLineItem, IRoverlikeRogueLevelLineData> lineLayout2 = this.LineLayout;
			if (lineLayout2 == null)
			{
				return null;
			}
			return lineLayout2.GetLayoutItemByIndex(index);
		}

		// Token: 0x06040469 RID: 263273 RVA: 0x010792B0 File Offset: 0x010774B0
		private List<IRoverlikeRogueLevelLineData> BuildLevelLineDataList(RoverlikeInstanceData instanceData)
		{
			List<IRoverlikeRogueLevelLineData> list = new List<IRoverlikeRogueLevelLineData>();
			IReadOnlyList<RoverRogueRoad> roadByRoadType = ConfigBase<RoverlikeConfig>.Instance.GetRoadByRoadType(instanceData.RoadTypeId);
			int count = roadByRoadType.Count;
			if (roadByRoadType.Count == 0 || count == 0)
			{
				return list;
			}
			int num = instanceData.CurLayer - 1;
			ValueTuple<int, int> currentFloorRange = this.GetCurrentFloorRange(instanceData, num, count);
			int item = currentFloorRange.Item1;
			int item2 = currentFloorRange.Item2;
			for (int i = item; i < item2; i++)
			{
				if (i < roadByRoadType.Count)
				{
					RoverRogueRoad roverRogueRoad = roadByRoadType[i];
					RoverlikeRogueLevelLineData item3 = new RoverlikeRogueLevelLineData
					{
						LayerType = (ERoverlikeRoadLayerType)roverRogueRoad.LayerType,
						IsCurrent = (i == num),
						IsPassed = (i < num),
						ShowCurrent = this.ShowCurrentNode
					};
					list.Add(item3);
				}
			}
			return list;
		}

		// Token: 0x0604046A RID: 263274 RVA: 0x01079370 File Offset: 0x01077570
		[NullableContext(0)]
		private ValueTuple<int, int> GetCurrentFloorRange([Nullable(1)] RoverlikeInstanceData instanceData, int curIndex, int total)
		{
			List<int> roadLayerIndexList = instanceData.RoadLayerIndexList;
			for (int i = roadLayerIndexList.Count - 1; i >= 0; i--)
			{
				if (curIndex >= roadLayerIndexList[i])
				{
					int item = roadLayerIndexList[i];
					int item2 = (i + 1 < roadLayerIndexList.Count) ? roadLayerIndexList[i + 1] : total;
					return new ValueTuple<int, int>(item, item2);
				}
			}
			return new ValueTuple<int, int>(0, total);
		}

		// Token: 0x0604046B RID: 263275 RVA: 0x010793D0 File Offset: 0x010775D0
		private int GetCurrentFloorNumber(RoverlikeInstanceData instanceData, int curIndex)
		{
			List<int> roadLayerIndexList = instanceData.RoadLayerIndexList;
			for (int i = roadLayerIndexList.Count - 1; i >= 0; i--)
			{
				if (curIndex >= roadLayerIndexList[i])
				{
					return i + 1;
				}
			}
			return 1;
		}

		// Token: 0x04024086 RID: 147590
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoverlikeRogueLevelLineItem, IRoverlikeRogueLevelLineData> LineLayout;

		// Token: 0x04024087 RID: 147591
		[Nullable(2)]
		private RoverlikeRogueLevelLineItem LastNode;

		// Token: 0x04024088 RID: 147592
		private int CurrentLevelIndex = -1;

		// Token: 0x04024089 RID: 147593
		public bool ShowCurrentNode = true;

		// Token: 0x0200C464 RID: 50276
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C742 RID: 247618
			public const int TxtTips = 0;

			// Token: 0x0403C743 RID: 247619
			public const int LineLayout = 1;

			// Token: 0x0403C744 RID: 247620
			public const int ItemLevelLine = 2;

			// Token: 0x0403C745 RID: 247621
			public const int ItemLastLine = 3;

			// Token: 0x0403C746 RID: 247622
			public const int TxtLevelProgress = 4;

			// Token: 0x0403C747 RID: 247623
			public const int PanelEffect = 5;
		}
	}
}
