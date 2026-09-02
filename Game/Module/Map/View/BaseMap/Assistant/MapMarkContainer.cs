using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Mark.Component;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.Misc;
using CSharpScript.Game.Module.Map.View.BaseMap.Assistant.MapFrameTaskQueue;
using CSharpScript.Game.Module.WorldMap;

namespace CSharpScript.Game.Module.Map.View.BaseMap.Assistant
{
	// Token: 0x020057F1 RID: 22513
	[NullableContext(1)]
	[Nullable(0)]
	public class MapMarkContainer
	{
		// Token: 0x0603941A RID: 234522 RVA: 0x00E85D2F File Offset: 0x00E83F2F
		public void Tick()
		{
			this.MapMarkPreemptiveFrameQueue.Process();
		}

		// Token: 0x0603941B RID: 234523 RVA: 0x00E85D3C File Offset: 0x00E83F3C
		public void ClearMarkItems(EMarkType? type, bool? recycleToPoolImmediately)
		{
			if (type != null && type.Value != EMarkType.None)
			{
				Dictionary<int, MarkItem> dictionary;
				if (this.MarkItems.TryGetValue(type.Value, out dictionary))
				{
					foreach (MarkItem markItem in dictionary.Values.ToList<MarkItem>())
					{
						this.NeedUpdateMark.Remove(markItem.MarkId);
						markItem.Destroy(recycleToPoolImmediately.GetValueOrDefault(true));
						this.DeleteItemInGrid(markItem);
					}
					dictionary.Clear();
				}
				Dictionary<int, MarkItem> dictionary2;
				if (this.DiffMapMarkItems.TryGetValue(type.Value, out dictionary2))
				{
					foreach (MarkItem markItem2 in dictionary2.Values.ToList<MarkItem>())
					{
						markItem2.Destroy(recycleToPoolImmediately.GetValueOrDefault(true));
					}
					dictionary2.Clear();
				}
				this.MapMarkPreemptiveFrameQueue.CancelMapTaskByType(type.Value);
				return;
			}
			this.RemoveMarkItems(this.MarkItems, recycleToPoolImmediately);
			this.RemoveMarkItems(this.DiffMapMarkItems, recycleToPoolImmediately);
			this.MarkItemTracking.Clear();
			this.MarkItems.Clear();
			this.DiffMapMarkItems.Clear();
			this.MarkItemInGrid.Clear();
			this.MapMarkPreemptiveFrameQueue.Dispose();
		}

		// Token: 0x0603941C RID: 234524 RVA: 0x00E85EB4 File Offset: 0x00E840B4
		public unsafe void AddMarkItem(EMarkType markType, MarkItem markItem)
		{
			if (markItem == null)
			{
				return;
			}
			if (markItem.IsTracked && markItem.MarkType != EMarkType.Quest)
			{
				TrackMapMarkParams trackMapMarkParams = new TrackMapMarkParams
				{
					MarkType = markItem.MarkType,
					MarkId = markItem.MarkId,
					Track = true
				};
				if (!ModelBase<MapModel>.Instance.IsEqualToCurTrack(trackMapMarkParams))
				{
					ModelBase<MapModel>.Instance.SetCurTrackMark(trackMapMarkParams);
				}
				this.MarkItemTracking.Add(markItem);
			}
			if (markItem.IsInConsistentDistrict(false))
			{
				ELogAuthor author = ELogAuthor.LYX;
				string message = "标记系统->MapMarkContainer.AddMarkItem, 被添加到跨地图列表，将不会显示在地图上";
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("markType", markType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("markId", markItem.MarkId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("MapType", markItem.MapType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("InstanceDungeonId", markItem.InstanceDungeonId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("MapId", markItem.MapId);
				MapLogger.Debug(author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
				this.AddDiffMapMarkItem(markType, markItem);
				return;
			}
			Dictionary<int, MarkItem> dictionary;
			if (!this.MarkItems.TryGetValue(markType, out dictionary))
			{
				dictionary = new Dictionary<int, MarkItem>();
				this.MarkItems[markType] = dictionary;
			}
			if (dictionary.TryAdd(markItem.MarkId, markItem))
			{
				this.AddItemInGrid(markItem);
				ELogAuthor author2 = ELogAuthor.LYX;
				string message2 = "标记系统->MapMarkContainer.AddMarkItem";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("markType", markType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("markId", markItem.MarkId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("MapType", markItem.MapType);
				MapLogger.Debug(author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				Singleton<EventSystem>.Instance.Emit<MarkItem>(EEventName.AddMapMark, markItem);
				return;
			}
			if (ModelBase<WorldMapModel>.Instance.EnableDebug)
			{
				object key = markItem.MarkId;
				ELogAuthor author3 = ELogAuthor.LYX;
				string message3 = "重复添加标记_MarkMgr";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MarkId", markItem.MarkId);
				MapLogger.ErrorOnce(key, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x0603941D RID: 234525 RVA: 0x00E86108 File Offset: 0x00E84308
		private void AddDiffMapMarkItem(EMarkType markType, MarkItem markItem)
		{
			Dictionary<int, MarkItem> dictionary;
			if (!this.DiffMapMarkItems.TryGetValue(markType, out dictionary))
			{
				dictionary = new Dictionary<int, MarkItem>();
				this.DiffMapMarkItems[markType] = dictionary;
			}
			dictionary[markItem.MarkId] = markItem;
		}

		// Token: 0x0603941E RID: 234526 RVA: 0x00E86148 File Offset: 0x00E84348
		[NullableContext(2)]
		public unsafe MarkItem RemoveMarkItem(EMarkType markType, int markId)
		{
			this.MapMarkPreemptiveFrameQueue.CancelMapTask(markType, markId);
			Dictionary<int, MarkItem> dictionary;
			if (!this.MarkItems.TryGetValue(markType, out dictionary) || dictionary.Count == 0)
			{
				return null;
			}
			MarkItem markItem;
			if (dictionary.Remove(markId, out markItem))
			{
				this.NeedUpdateMark.Remove(markId);
				this.DeleteItemInGrid(markItem);
				ELogAuthor author = ELogAuthor.LYX;
				string message = "标记系统->MapMarkContainer.RemoveMarkItem";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("markType", markType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("markId", markId);
				MapLogger.Debug(author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return markItem;
			}
			return null;
		}

		// Token: 0x0603941F RID: 234527 RVA: 0x00E861F4 File Offset: 0x00E843F4
		private void RemoveMarkItems(Dictionary<EMarkType, Dictionary<int, MarkItem>> markItemMap, bool? recycleToPoolImmediately)
		{
			foreach (Dictionary<int, MarkItem> dictionary in markItemMap.Values)
			{
				foreach (MarkItem markItem in dictionary.Values.ToList<MarkItem>())
				{
					this.NeedUpdateMark.Remove(markItem.MarkId);
					markItem.Destroy(recycleToPoolImmediately.GetValueOrDefault(true));
				}
			}
		}

		// Token: 0x06039420 RID: 234528 RVA: 0x00E862A0 File Offset: 0x00E844A0
		private void AddItemInGrid(MarkItem mark)
		{
			int num = MapUtil.ConvertWorldPositionToIndex(mark.WorldPosition);
			HashSet<MarkItem> markSet;
			if (!this.MarkItemInGrid.TryGetValue(num, out markSet))
			{
				HashSet<MarkItem> value = new HashSet<MarkItem>
				{
					mark
				};
				this.MarkItemInGrid[num] = value;
			}
			else
			{
				this.ApplyAddItemToGridSet(markSet, mark);
			}
			mark.GridId = num;
		}

		// Token: 0x06039421 RID: 234529 RVA: 0x00E862F8 File Offset: 0x00E844F8
		private void ApplyAddItemToGridSet(HashSet<MarkItem> markSet, MarkItem mark)
		{
			if (!markSet.Add(mark))
			{
				object key = mark.MarkId;
				ELogAuthor author = ELogAuthor.LYX;
				string message = "重复添加标记到格子集合中_MarkMarkContainer";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MarkId", mark.MarkId);
				MapLogger.ErrorOnce(key, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x06039422 RID: 234530 RVA: 0x00E86344 File Offset: 0x00E84544
		private void DeleteItemInGrid(MarkItem mark)
		{
			int gridId = mark.GridId;
			HashSet<MarkItem> hashSet;
			if (this.MarkItemInGrid.TryGetValue(gridId, out hashSet))
			{
				hashSet.Remove(mark);
			}
		}

		// Token: 0x06039423 RID: 234531 RVA: 0x00E86370 File Offset: 0x00E84570
		public bool ExistMarkItem(EMarkType markType, int markId)
		{
			return this.GetMarkItemPurely(markType, markId) != null;
		}

		// Token: 0x06039424 RID: 234532 RVA: 0x00E8637D File Offset: 0x00E8457D
		public bool ExistMarkItemTask(EMarkType markType, int markId)
		{
			return this.MapMarkPreemptiveFrameQueue.HasTask(markType, markId);
		}

		// Token: 0x06039425 RID: 234533 RVA: 0x00E8638C File Offset: 0x00E8458C
		[NullableContext(2)]
		public MarkItem GetMarkItem(EMarkType markType, int markId)
		{
			this.MapMarkPreemptiveFrameQueue.ForceExecuteTask(markType, markId);
			return this.GetMarkItemPurely(markType, markId);
		}

		// Token: 0x06039426 RID: 234534 RVA: 0x00E863A4 File Offset: 0x00E845A4
		[NullableContext(2)]
		public MarkItem GetMarkItemPurely(EMarkType markType, int markId)
		{
			if (markType == EMarkType.None)
			{
				return this.GetMarkItemById(markId, false);
			}
			Dictionary<int, MarkItem> markItemsByType = this.GetMarkItemsByType(markType, true);
			if (markItemsByType == null)
			{
				return null;
			}
			MarkItem result;
			if (markItemsByType.TryGetValue(markId, out result))
			{
				return result;
			}
			return this.GetDifferMapMarkItem(markType, markId);
		}

		// Token: 0x06039427 RID: 234535 RVA: 0x00E863E0 File Offset: 0x00E845E0
		[NullableContext(2)]
		public MarkItem GetMarkItemById(int markId, bool withCrossMap = false)
		{
			MapMarkContainer.<>c__DisplayClass24_0 CS$<>8__locals1;
			CS$<>8__locals1.markId = markId;
			MarkItem markItem = MapMarkContainer.<GetMarkItemById>g__FindMarkItemFunc|24_0(this.MarkItems, ref CS$<>8__locals1);
			if (markItem == null && withCrossMap)
			{
				markItem = MapMarkContainer.<GetMarkItemById>g__FindMarkItemFunc|24_0(this.DiffMapMarkItems, ref CS$<>8__locals1);
			}
			return markItem;
		}

		// Token: 0x06039428 RID: 234536 RVA: 0x00E8641C File Offset: 0x00E8461C
		[NullableContext(2)]
		public MarkItem GetDifferMapMarkItem(EMarkType markType, int markId)
		{
			Dictionary<int, MarkItem> dictionary;
			if (this.DiffMapMarkItems.TryGetValue(markType, out dictionary))
			{
				MarkItem result;
				dictionary.TryGetValue(markId, out result);
				return result;
			}
			return null;
		}

		// Token: 0x06039429 RID: 234537 RVA: 0x00E86448 File Offset: 0x00E84648
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public Dictionary<int, MarkItem> GetMarkItemsByType(EMarkType markType, bool withCrossMap = true)
		{
			Dictionary<int, MarkItem> dictionary;
			this.MarkItems.TryGetValue(markType, out dictionary);
			if ((dictionary == null || dictionary.Count <= 0) && withCrossMap)
			{
				return this.GetDifferMapMarkItemsByType(markType);
			}
			return dictionary;
		}

		// Token: 0x0603942A RID: 234538 RVA: 0x00E86484 File Offset: 0x00E84684
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public Dictionary<int, MarkItem> GetDifferMapMarkItemsByType(EMarkType markType)
		{
			Dictionary<int, MarkItem> result;
			this.DiffMapMarkItems.TryGetValue(markType, out result);
			return result;
		}

		// Token: 0x0603942B RID: 234539 RVA: 0x00E864A1 File Offset: 0x00E846A1
		public Dictionary<EMarkType, Dictionary<int, MarkItem>> GetAllMarkItems()
		{
			return this.MarkItems;
		}

		// Token: 0x0603942C RID: 234540 RVA: 0x00E864A9 File Offset: 0x00E846A9
		public Dictionary<EMarkType, Dictionary<int, MarkItem>> GetAllDiffMapMarkItems()
		{
			return this.DiffMapMarkItems;
		}

		// Token: 0x0603942D RID: 234541 RVA: 0x00E864B4 File Offset: 0x00E846B4
		public List<MarkItem> GetMarkItemsByClickPosition(global::Vector position, int cellRadius = 1)
		{
			HashSet<int> aroundIndexByCellRadius = MapUtil.GetAroundIndexByCellRadius(MapUtil.ConvertWorldPositionToIndex(MapUtil.UiPosition2WorldPosition(position, null)), cellRadius);
			List<MarkItem> list = new List<MarkItem>();
			foreach (int key in aroundIndexByCellRadius)
			{
				HashSet<MarkItem> collection;
				if (this.MarkItemInGrid.TryGetValue(key, out collection))
				{
					list.AddRange(collection);
				}
			}
			return list;
		}

		// Token: 0x0603942E RID: 234542 RVA: 0x00E8652C File Offset: 0x00E8472C
		public void UpdateNearbyMarkItem(global::Vector center, Action<MarkItem> updateFunction, Action<MarkItem> onExitFunction)
		{
			this.MapMarkPreemptiveFrameQueue.Flush();
			HashSet<int> updateAroundIndex = MapUtil.GetUpdateAroundIndex(MapUtil.ConvertWorldPositionToIndex(center));
			foreach (int key in updateAroundIndex)
			{
				HashSet<MarkItem> hashSet;
				if (this.MarkItemInGrid.TryGetValue(key, out hashSet))
				{
					foreach (MarkItem markItem in hashSet)
					{
						if (!this.NeedUpdateMark.ContainsKey(markItem.MarkId) && markItem.MarkType != EMarkType.OtherPlayers)
						{
							this.NeedUpdateMark[markItem.MarkId] = markItem;
						}
					}
				}
			}
			this.UpdatePermanentMarkItemsInMiniMap();
			this.TempNeedUpdateList.Clear();
			this.TempNeedUpdateList.AddRange(this.NeedUpdateMark.Values);
			foreach (MarkItem markItem2 in this.TempNeedUpdateList)
			{
				updateFunction(markItem2);
				int gridId = markItem2.GridId;
				if (!this.TempMiniMapPermanentUpdateMarkIdSet.Contains(markItem2.MarkId) && (!markItem2.IsCanShowView || !updateAroundIndex.Contains(gridId)))
				{
					this.TrackDeleteItems.Add(markItem2);
					this.NeedUpdateMark.Remove(markItem2.MarkId);
				}
			}
			this.TempTrackingList.Clear();
			this.TempTrackingList.AddRange(this.MarkItemTracking);
			foreach (MarkItem obj in this.TempTrackingList)
			{
				updateFunction(obj);
			}
			if (this.TrackDeleteItems.Count != 0)
			{
				this.TempDeleteList.Clear();
				this.TempDeleteList.AddRange(this.TrackDeleteItems);
				foreach (MarkItem markItem3 in this.TempDeleteList)
				{
					if (!markItem3.IsDestroy)
					{
						onExitFunction(markItem3);
					}
				}
				this.TrackDeleteItems.Clear();
			}
			foreach (int key2 in updateAroundIndex)
			{
				HashSet<MarkItem> hashSet2;
				if (this.MarkItemInGrid.TryGetValue(key2, out hashSet2))
				{
					foreach (MarkItem obj2 in hashSet2)
					{
						updateFunction(obj2);
					}
				}
			}
		}

		// Token: 0x0603942F RID: 234543 RVA: 0x00E86830 File Offset: 0x00E84A30
		private void UpdatePermanentMarkItemsInMiniMap()
		{
			this.TempMiniMapPermanentUpdateMarkIdSet.Clear();
			foreach (EMarkType markType in MarkDefine.PermanentUpdateTypeSet)
			{
				Dictionary<int, MarkItem> markItemsByType = this.GetMarkItemsByType(markType, true);
				if (markItemsByType != null)
				{
					foreach (MarkItem markItem in markItemsByType.Values)
					{
						this.NeedUpdateMark[markItem.MarkId] = markItem;
						this.TempMiniMapPermanentUpdateMarkIdSet.Add(markItem.MarkId);
					}
				}
			}
		}

		// Token: 0x06039430 RID: 234544 RVA: 0x00E868F8 File Offset: 0x00E84AF8
		[return: Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public List<ValueTuple<MarkItem, double>> FindNearbyMarkItems(MarkItem markItem, float searchRadius, [Nullable(2)] TFilterMarkFunction filterFunction = null)
		{
			this.MapMarkPreemptiveFrameQueue.Flush();
			HashSet<int> queryNearestIndexSet = MapUtil.GetQueryNearestIndexSet(markItem.WorldPosition, searchRadius);
			List<ValueTuple<MarkItem, double>> list = new List<ValueTuple<MarkItem, double>>();
			float num = searchRadius * searchRadius;
			foreach (int key in queryNearestIndexSet)
			{
				HashSet<MarkItem> hashSet;
				if (this.MarkItemInGrid.TryGetValue(key, out hashSet))
				{
					foreach (MarkItem markItem2 in hashSet)
					{
						if (filterFunction == null || filterFunction(markItem2))
						{
							double num2;
							if ((markItem.MarkType == EMarkType.Custom || markItem.MarkType == EMarkType.EnrichmentArea) && Singleton<MathUtils>.Instance.IsNearlyZero(markItem.WorldPosition.Z, null))
							{
								Vector2D a2 = Vector2D.Create(markItem2.WorldPosition.X, markItem2.WorldPosition.Y);
								Vector2D b2 = Vector2D.Create(markItem.WorldPosition.X, markItem.WorldPosition.Y);
								num2 = Vector2D.DistSquared(a2, b2);
							}
							else
							{
								num2 = global::Vector.DistSquared(markItem2.WorldPosition, markItem.WorldPosition);
							}
							if (num2 <= (double)num)
							{
								list.Add(new ValueTuple<MarkItem, double>(markItem2, num2));
							}
						}
					}
				}
			}
			if (list.Count > 0)
			{
				list.Sort(([Nullable(new byte[]
				{
					0,
					1
				})] ValueTuple<MarkItem, double> a, [Nullable(new byte[]
				{
					0,
					1
				})] ValueTuple<MarkItem, double> b) => a.Item2.CompareTo(b.Item2));
			}
			return list;
		}

		// Token: 0x06039431 RID: 234545 RVA: 0x00E86AB4 File Offset: 0x00E84CB4
		public void RemoveDynamicMark(EMarkType markType, int markId)
		{
			MarkItem markItem = this.GetMarkItem(markType, markId);
			if (markItem == null)
			{
				return;
			}
			this.TrackMapMark(markType, markItem.MarkId, false, false);
			this.NeedUpdateMark.Remove(markId);
			MarkItem markItem2 = this.RemoveMarkItem(markType, markId);
			if (markItem2 != null)
			{
				markItem2.Destroy(true);
			}
		}

		// Token: 0x06039432 RID: 234546 RVA: 0x00E86B00 File Offset: 0x00E84D00
		public void TrackMapMark(EMarkType markType, int markId, bool isTrack, bool forceTrack = false)
		{
			ITrackData trackData = ModelBase<TrackModel>.Instance.GetTrackData(ETrackSource.MapMark, markId);
			MarkItem markItem = this.GetMarkItem(markType, markId);
			if (markItem == null && trackData == null)
			{
				return;
			}
			ETrackSource type = ETrackSource.None;
			if (trackData != null)
			{
				type = trackData.TrackSource;
				trackData.IconPath = (((markItem != null) ? markItem.IconPath : null) ?? trackData.IconPath);
			}
			if (markItem != null)
			{
				type = markItem.TrackSource;
			}
			bool flag = ModelBase<TrackModel>.Instance.IsTracking(type, markId);
			if (!forceTrack && flag == isTrack)
			{
				if (markItem != null)
				{
					Singleton<EventSystem>.Instance.Emit<MarkItem>(EEventName.OnMarkItemTrackStateChange, markItem);
				}
				return;
			}
			if (isTrack)
			{
				if (markItem != null)
				{
					MarkConfigComponent component = markItem.MarkItemEntity.GetComponent<MarkConfigComponent>(EMapComponent.MarkConfig);
					OneOf<MapMark, DynamicMapMark, TreasureBoxDetectorMark>? oneOf = (component != null) ? new OneOf<MapMark, DynamicMapMark, TreasureBoxDetectorMark>?(component.Config) : null;
					if (markItem.MarkType == EMarkType.HonamiScanItem)
					{
						HonamiScanItemMarkItem honamiScanItemMarkItem = markItem as HonamiScanItemMarkItem;
						MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(honamiScanItemMarkItem.ConfigId);
						oneOf = ((configMark != null) ? new OneOf<MapMark, DynamicMapMark, TreasureBoxDetectorMark>?(configMark.GetValueOrDefault()) : null);
					}
					ControllerBase<TrackController>.Instance.StartTrack(new TrackData
					{
						TrackSource = markItem.TrackSource,
						Id = markId,
						MarkType = new EMarkType?(markType),
						IconPath = markItem.IconPath,
						TrackTarget = markItem.TrackTarget,
						TrackInstanceId = markItem.RelativeInstanceDungeonId,
						TrackHudEnable = new bool?(oneOf != null && oneOf.GetValueOrDefault().TrackHudEnable().GetValueOrDefault() == 1),
						TrackAutoCancelDistance = ((oneOf != null) ? oneOf.GetValueOrDefault().TrackAutoCancelDistance() : null)
					}, true);
					this.MarkItemTracking.Add(markItem);
					Singleton<EventSystem>.Instance.Emit<MarkItem>(EEventName.OnMarkItemTrackStateChange, markItem);
					return;
				}
			}
			else
			{
				ControllerBase<TrackController>.Instance.EndTrack(type, markId);
				if (markItem != null)
				{
					this.TrackDeleteItems.Add(markItem);
					this.MarkItemTracking.Remove(markItem);
					Singleton<EventSystem>.Instance.Emit<MarkItem>(EEventName.OnMarkItemTrackStateChange, markItem);
				}
			}
		}

		// Token: 0x06039433 RID: 234547 RVA: 0x00E86D0C File Offset: 0x00E84F0C
		public void TrackMark(ITrackData trackData)
		{
			MarkItem markItem = this.GetMarkItem(trackData.MarkType.GetValueOrDefault(), trackData.Id);
			if (markItem != null && !markItem.IsTracked)
			{
				markItem.LogicUpdate(Singleton<GeneralLogicTreeUtil>.Instance.GetPlayerLocation());
			}
			if (((markItem != null) ? markItem.View : null) != null || (markItem != null && markItem.IsTracked))
			{
				this.MarkItemTracking.Add(markItem);
			}
		}

		// Token: 0x06039434 RID: 234548 RVA: 0x00E86D78 File Offset: 0x00E84F78
		public void UnTrackMark(ITrackData trackData)
		{
			MarkItem markItem = this.GetMarkItem(trackData.MarkType.GetValueOrDefault(), trackData.Id);
			if (markItem != null)
			{
				this.MarkItemTracking.Remove(markItem);
				this.TrackDeleteItems.Add(markItem);
			}
		}

		// Token: 0x06039435 RID: 234549 RVA: 0x00E86DC0 File Offset: 0x00E84FC0
		public void ClearTrackMark()
		{
			foreach (MarkItem markItem in this.MarkItemTracking.ToList<MarkItem>())
			{
				if (((markItem != null) ? markItem.View : null) != null)
				{
					this.TrackDeleteItems.Add(markItem);
				}
			}
			this.MarkItemTracking.Clear();
		}

		// Token: 0x06039436 RID: 234550 RVA: 0x00E86E38 File Offset: 0x00E85038
		public List<MarkItem> GetTrackMenuMarkList()
		{
			List<MarkItem> list = new List<MarkItem>();
			Dictionary<int, MarkItem> markItemsByType = this.GetMarkItemsByType(EMarkType.OtherPlayers, false);
			if (markItemsByType != null)
			{
				list.AddRange(markItemsByType.Values);
			}
			Dictionary<int, MarkItem> markItemsByType2 = this.GetMarkItemsByType(EMarkType.Quest, false);
			if (markItemsByType2 != null)
			{
				foreach (MarkItem item in from m in markItemsByType2.Values
				where m.IsTracked
				select m)
				{
					list.Add(item);
				}
			}
			foreach (MarkItem item2 in from m in this.MarkItemTracking
			where m.IsTracked && !m.IsInConsistentDistrict(false)
			select m)
			{
				list.Add(item2);
			}
			return list;
		}

		// Token: 0x06039437 RID: 234551 RVA: 0x00E86F3C File Offset: 0x00E8513C
		public List<MarkItem> GetNavigateMarkList()
		{
			List<MarkItem> list = new List<MarkItem>();
			int currentWorldMapConfigId = ModelBase<WorldMapModel>.Instance.CurrentWorldMapConfigId;
			Dictionary<int, MarkItem> markItemsByType = this.GetMarkItemsByType(EMarkType.OtherPlayers, false);
			int? num2;
			if (markItemsByType != null)
			{
				foreach (MarkItem markItem in markItemsByType.Values)
				{
					int? dungeonLocateWorldMapId = ModelBase<MapModel>.Instance.GetDungeonLocateWorldMapId(markItem.InstanceDungeonOrMapConfigId);
					int num = currentWorldMapConfigId;
					num2 = dungeonLocateWorldMapId;
					if (num == num2.GetValueOrDefault() & num2 != null)
					{
						list.Add(markItem);
					}
				}
			}
			Dictionary<int, MarkItem> differMapMarkItemsByType = this.GetDifferMapMarkItemsByType(EMarkType.OtherPlayers);
			if (differMapMarkItemsByType != null)
			{
				foreach (MarkItem markItem2 in differMapMarkItemsByType.Values)
				{
					int? dungeonLocateWorldMapId2 = ModelBase<MapModel>.Instance.GetDungeonLocateWorldMapId(markItem2.InstanceDungeonOrMapConfigId);
					if (ConfigBase<WorldMapConfig>.Instance.IsMapInWorld(dungeonLocateWorldMapId2 ?? markItem2.MapId))
					{
						list.Add(markItem2);
					}
				}
			}
			global::Quest curTrackedQuest = ModelBase<QuestNewModel>.Instance.GetCurTrackedQuest();
			int? num3;
			if (curTrackedQuest == null)
			{
				num3 = null;
			}
			else
			{
				BehaviorNodeBase currentActiveChildQuestNode = curTrackedQuest.GetCurrentActiveChildQuestNode();
				num3 = ((currentActiveChildQuestNode != null) ? new int?(currentActiveChildQuestNode.NodeId) : null);
			}
			num2 = num3;
			int valueOrDefault = num2.GetValueOrDefault();
			int valueOrDefault2 = ((curTrackedQuest != null) ? curTrackedQuest.GetDefaultMark(valueOrDefault) : null).GetValueOrDefault();
			MarkItem markItem3 = this.GetMarkItem(EMarkType.Quest, valueOrDefault2);
			TaskMarkItem taskMarkItem = markItem3 as TaskMarkItem;
			if (taskMarkItem != null && taskMarkItem.IsBtTypeQuest())
			{
				list.Add(markItem3);
			}
			return list;
		}

		// Token: 0x06039438 RID: 234552 RVA: 0x00E870FC File Offset: 0x00E852FC
		public void RemoveNeedUpdateMark(int markId)
		{
			this.NeedUpdateMark.Remove(markId);
		}

		// Token: 0x06039439 RID: 234553 RVA: 0x00E8710C File Offset: 0x00E8530C
		public void AddCreateMarkTask(bool inMap, EMarkType markType, int markId, TPreemptiveExecuteMethod executeMethod)
		{
			int priority = (!inMap) ? 1 : 0;
			MapMarkPreemptiveFrameTask task = new MapMarkPreemptiveFrameTask
			{
				Priority = priority,
				MarkType = markType,
				MarkId = markId,
				Execute = executeMethod
			};
			this.MapMarkPreemptiveFrameQueue.AddTask(task);
		}

		// Token: 0x0603943A RID: 234554 RVA: 0x00E87150 File Offset: 0x00E85350
		[return: Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public List<ValueTuple<MarkItem, double>> FindNearbyMarkItemsByPosition(global::Vector position, float searchRadius, [Nullable(new byte[]
		{
			2,
			1
		})] Func<MarkItem, bool> filterFunction = null)
		{
			this.MapMarkPreemptiveFrameQueue.Flush();
			HashSet<int> queryNearestIndexSet = MapUtil.GetQueryNearestIndexSet(position, searchRadius);
			List<ValueTuple<MarkItem, double>> list = new List<ValueTuple<MarkItem, double>>();
			double num = (double)searchRadius * (double)searchRadius;
			foreach (int key in queryNearestIndexSet)
			{
				HashSet<MarkItem> hashSet;
				if (this.MarkItemInGrid.TryGetValue(key, out hashSet))
				{
					foreach (MarkItem markItem in hashSet)
					{
						if (filterFunction == null || filterFunction(markItem))
						{
							double num2 = global::Vector.DistSquared(markItem.WorldPosition, position);
							if (num2 <= num)
							{
								list.Add(new ValueTuple<MarkItem, double>(markItem, num2));
							}
						}
					}
				}
			}
			if (list.Count > 0)
			{
				list.Sort(([Nullable(new byte[]
				{
					0,
					1
				})] ValueTuple<MarkItem, double> a, [Nullable(new byte[]
				{
					0,
					1
				})] ValueTuple<MarkItem, double> b) => a.Item2.CompareTo(b.Item2));
			}
			return list;
		}

		// Token: 0x0603943C RID: 234556 RVA: 0x00E872F4 File Offset: 0x00E854F4
		[CompilerGenerated]
		[return: Nullable(2)]
		internal static MarkItem <GetMarkItemById>g__FindMarkItemFunc|24_0(Dictionary<EMarkType, Dictionary<int, MarkItem>> allMarkItemMap, ref MapMarkContainer.<>c__DisplayClass24_0 A_1)
		{
			using (Dictionary<EMarkType, Dictionary<int, MarkItem>>.ValueCollection.Enumerator enumerator = allMarkItemMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					MarkItem result;
					if (enumerator.Current.TryGetValue(A_1.markId, out result))
					{
						return result;
					}
				}
			}
			return null;
		}

		// Token: 0x040208DC RID: 133340
		private readonly MapMarkPreemptiveFrameQueue MapMarkPreemptiveFrameQueue = new MapMarkPreemptiveFrameQueue(50, 0);

		// Token: 0x040208DD RID: 133341
		private readonly Dictionary<EMarkType, Dictionary<int, MarkItem>> MarkItems = new Dictionary<EMarkType, Dictionary<int, MarkItem>>();

		// Token: 0x040208DE RID: 133342
		private readonly Dictionary<EMarkType, Dictionary<int, MarkItem>> DiffMapMarkItems = new Dictionary<EMarkType, Dictionary<int, MarkItem>>();

		// Token: 0x040208DF RID: 133343
		private readonly Dictionary<int, HashSet<MarkItem>> MarkItemInGrid = new Dictionary<int, HashSet<MarkItem>>();

		// Token: 0x040208E0 RID: 133344
		private readonly Dictionary<int, MarkItem> NeedUpdateMark = new Dictionary<int, MarkItem>();

		// Token: 0x040208E1 RID: 133345
		private readonly HashSet<MarkItem> MarkItemTracking = new HashSet<MarkItem>();

		// Token: 0x040208E2 RID: 133346
		private readonly HashSet<MarkItem> TrackDeleteItems = new HashSet<MarkItem>();

		// Token: 0x040208E3 RID: 133347
		private readonly HashSet<int> TempMiniMapPermanentUpdateMarkIdSet = new HashSet<int>();

		// Token: 0x040208E4 RID: 133348
		private readonly List<MarkItem> TempNeedUpdateList = new List<MarkItem>();

		// Token: 0x040208E5 RID: 133349
		private readonly List<MarkItem> TempTrackingList = new List<MarkItem>();

		// Token: 0x040208E6 RID: 133350
		private readonly List<MarkItem> TempDeleteList = new List<MarkItem>();
	}
}
