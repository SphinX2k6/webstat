using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.KuroSimpleCombat;
using CSharpScript.Game.LevelGamePlay.Common;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DBB RID: 19899
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseMapModel
	{
		// Token: 0x17008830 RID: 34864
		// (get) Token: 0x0603389A RID: 211098 RVA: 0x00CE38B5 File Offset: 0x00CE1AB5
		// (set) Token: 0x0603389B RID: 211099 RVA: 0x00CE38BD File Offset: 0x00CE1ABD
		public int MapId
		{
			get
			{
				return this.MapIdInner;
			}
			set
			{
				this.MapIdInner = value;
			}
		}

		// Token: 0x17008831 RID: 34865
		// (get) Token: 0x0603389C RID: 211100 RVA: 0x00CE38C8 File Offset: 0x00CE1AC8
		public global::Vector CampPosition
		{
			get
			{
				if (this.PhantomRoutes.Count == 0)
				{
					return global::Vector.Create(0.0, 0.0, 0.0);
				}
				List<global::Vector> list = null;
				using (Dictionary<int, List<global::Vector>>.ValueCollection.Enumerator enumerator = this.PhantomRoutes.Values.GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						list = enumerator.Current;
					}
				}
				if (list == null || list.Count == 0)
				{
					return global::Vector.Create(0.0, 0.0, 0.0);
				}
				return list[list.Count - 1];
			}
		}

		// Token: 0x0603389D RID: 211101 RVA: 0x00CE3988 File Offset: 0x00CE1B88
		public static TrapDefenseMapModel Create()
		{
			return new TrapDefenseMapModel();
		}

		// Token: 0x0603389E RID: 211102 RVA: 0x00CE3990 File Offset: 0x00CE1B90
		public TrapDefenseMarkItem GetDynamicMarkInfoByMarkId(int markId)
		{
			TrapDefenseMarkItem result;
			this.DynamicMarks.TryGetValue(markId, out result);
			return result;
		}

		// Token: 0x0603389F RID: 211103 RVA: 0x00CE39B0 File Offset: 0x00CE1BB0
		public List<T> GetDynamicMarksByMarkType<[Nullable(0)] T>(TrapDefenseDefine.ETrapDefenseMarkType markType) where T : TrapDefenseMarkItem
		{
			List<TrapDefenseMarkItem> list;
			if (this.MarksByType.TryGetValue(markType, out list))
			{
				List<T> list2 = new List<T>();
				foreach (TrapDefenseMarkItem trapDefenseMarkItem in list)
				{
					list2.Add((T)((object)trapDefenseMarkItem));
				}
				return list2;
			}
			return new List<T>();
		}

		// Token: 0x060338A0 RID: 211104 RVA: 0x00CE3A20 File Offset: 0x00CE1C20
		public Dictionary<int, TrapDefenseMarkItem> GetAllDynamicMarkInfo()
		{
			return this.DynamicMarks;
		}

		// Token: 0x060338A1 RID: 211105 RVA: 0x00CE3A28 File Offset: 0x00CE1C28
		public void SetDynamicMarkInfoByMarkId(TrapDefenseMarkItem info)
		{
			this.DynamicMarks[info.MarkId] = info;
			if (!this.MarksByType.ContainsKey(info.MarkType))
			{
				this.MarksByType[info.MarkType] = new List<TrapDefenseMarkItem>();
			}
			this.MarksByType[info.MarkType].Add(info);
		}

		// Token: 0x060338A2 RID: 211106 RVA: 0x00CE3A88 File Offset: 0x00CE1C88
		public void RemoveDynamicMarkInfoByMarkId(int markId)
		{
			TrapDefenseMarkItem trapDefenseMarkItem;
			if (this.DynamicMarks.TryGetValue(markId, out trapDefenseMarkItem))
			{
				this.DynamicMarks.Remove(markId);
				List<TrapDefenseMarkItem> list;
				if (this.MarksByType.TryGetValue(trapDefenseMarkItem.MarkType, out list))
				{
					list.Remove(trapDefenseMarkItem);
				}
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.TrapDefenseMapMarkRemoved, markId);
			}
		}

		// Token: 0x060338A3 RID: 211107 RVA: 0x00CE3AE0 File Offset: 0x00CE1CE0
		public void ClearDynamicMarks()
		{
			this.DynamicMarks.Clear();
			this.MarksByType.Clear();
		}

		// Token: 0x060338A4 RID: 211108 RVA: 0x00CE3AF8 File Offset: 0x00CE1CF8
		public void AddMark(ITrapDefenseMarkInfo createInfo)
		{
			TrapDefenseMarkItem trapDefenseMarkItem;
			if (!this.DynamicMarks.TryGetValue(createInfo.MarkId, out trapDefenseMarkItem))
			{
				switch (createInfo.MarkType)
				{
				case TrapDefenseDefine.ETrapDefenseMarkType.Player:
					trapDefenseMarkItem = new TrapDefensePlayerMarkItem(createInfo.MarkId, createInfo.ExtraParam);
					break;
				case TrapDefenseDefine.ETrapDefenseMarkType.PhantomPoint:
					trapDefenseMarkItem = new TrapDefensePhantomPointMarkItem(createInfo.MarkId, createInfo.ExtraParam);
					break;
				case TrapDefenseDefine.ETrapDefenseMarkType.Phantom:
					trapDefenseMarkItem = new TrapDefenseMonsterMarkItem(createInfo.MarkId, createInfo.ExtraParam);
					break;
				case TrapDefenseDefine.ETrapDefenseMarkType.Camp:
					trapDefenseMarkItem = new TrapDefenseCampMarkItem(createInfo.MarkId, createInfo.ExtraParam);
					break;
				default:
					return;
				}
				this.DynamicMarks[createInfo.MarkId] = trapDefenseMarkItem;
				if (!this.MarksByType.ContainsKey(createInfo.MarkType))
				{
					this.MarksByType[createInfo.MarkType] = new List<TrapDefenseMarkItem>();
				}
				this.MarksByType[createInfo.MarkType].Add(trapDefenseMarkItem);
			}
		}

		// Token: 0x060338A5 RID: 211109 RVA: 0x00CE3BE0 File Offset: 0x00CE1DE0
		public void CreateMarks()
		{
			List<ITrapDefenseMarkInfo> list = new List<ITrapDefenseMarkInfo>();
			list.Add(new TrapDefenseMarkInfo
			{
				MarkId = 0,
				MarkType = TrapDefenseDefine.ETrapDefenseMarkType.Player
			});
			list.Add(new TrapDefenseMarkInfo
			{
				MarkId = 1,
				MarkType = TrapDefenseDefine.ETrapDefenseMarkType.Camp
			});
			foreach (KeyValuePair<int, List<global::Vector>> keyValuePair in this.PhantomRoutes)
			{
				int key = keyValuePair.Key;
				List<global::Vector> value = keyValuePair.Value;
				list.Add(new TrapDefenseMarkInfo
				{
					MarkId = key + 10000,
					MarkType = TrapDefenseDefine.ETrapDefenseMarkType.PhantomPoint,
					ExtraParam = new object[]
					{
						key,
						value
					}
				});
			}
			foreach (ITrapDefenseMarkInfo createInfo in list)
			{
				this.AddMark(createInfo);
			}
		}

		// Token: 0x060338A6 RID: 211110 RVA: 0x00CE3CF8 File Offset: 0x00CE1EF8
		public void InitMapData()
		{
			TrapDefenseLevelData curInstToLevelData = ModelBase<TrapDefenseModel>.Instance.GetCurInstToLevelData();
			if (curInstToLevelData == null)
			{
				return;
			}
			if (curInstToLevelData.Config.WorldKillZ != 0)
			{
				if (Singleton<KscEnv>.Instance.KscWorld != null)
				{
					Singleton<KscEnv>.Instance.KscWorld.SetWorldAttr(EKSC_WorldAttrType.WorldKillZ, curInstToLevelData.Config.WorldKillZ);
				}
				else
				{
					Singleton<KscEnv>.Instance.CacheWorldKillZ((float)curInstToLevelData.Config.WorldKillZ);
				}
			}
			if (curInstToLevelData.Config.ObstacleSegments() != null)
			{
				TArray<FKSC_Segment> tarray = new TArray<FKSC_Segment>();
				foreach (IntArray intArray in curInstToLevelData.Config.ObstacleSegmentsIter())
				{
					if (intArray.ArrayInt() != null && intArray.ArrayIntLength == 4)
					{
						tarray.Add(new FKSC_Segment(new FVector((float)intArray.ArrayInt(0), (float)intArray.ArrayInt(1), 0f), new FVector((float)intArray.ArrayInt(2), (float)intArray.ArrayInt(3), 0f)));
					}
					else
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.TowerDefense;
						ELogAuthor author = ELogAuthor.ZWY;
						string message = "[塔防地图] 初始化障碍物配置错误";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", curInstToLevelData.Config.Name);
						instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					}
				}
				if (Singleton<KscEnv>.Instance.KscWorld != null)
				{
					Singleton<KscEnv>.Instance.KscWorld.SetObstacleSegments(tarray);
				}
				else
				{
					Singleton<KscEnv>.Instance.CacheObstacleSegments(tarray);
				}
			}
			this.InitSplineData();
			if (!this.MapChanged)
			{
				this.MapId = ModelBase<TrapDefenseModel>.Instance.GetCurrentBatchData().Value.MapId;
			}
			this.ClearDynamicMarks();
			this.CreateMarks();
		}

		// Token: 0x060338A7 RID: 211111 RVA: 0x00CE3EAC File Offset: 0x00CE20AC
		public void ChangeMap(int mapId)
		{
			this.MapId = mapId;
			this.MapChanged = true;
		}

		// Token: 0x060338A8 RID: 211112 RVA: 0x00CE3EBC File Offset: 0x00CE20BC
		public void InitSplineData()
		{
			TrapDefenseLevelData curInstToLevelData = ModelBase<TrapDefenseModel>.Instance.GetCurInstToLevelData();
			int[] array = ((curInstToLevelData != null) ? curInstToLevelData.Config.SplineList() : null) ?? Array.Empty<int>();
			this.PhantomRoutes.Clear();
			this.ClearAllSpline();
			foreach (int num in array)
			{
				USplineComponent splineComponent = this.GetSplineComponent(num);
				List<global::Vector> list = new List<global::Vector>();
				float splineLength = splineComponent.GetSplineLength();
				FVectorDouble fvectorDouble = splineComponent.D_GetLocationAtDistanceAlongSpline(0f, ESplineCoordinateSpace.World);
				FVectorDouble fvectorDouble2 = splineComponent.D_GetLocationAtDistanceAlongSpline(splineLength, ESplineCoordinateSpace.World);
				list.Add(global::Vector.Create(fvectorDouble.X, fvectorDouble.Y, fvectorDouble.Z));
				list.Add(global::Vector.Create(fvectorDouble2.X, fvectorDouble2.Y, fvectorDouble2.Z));
				this.PhantomRoutes[num] = list;
			}
		}

		// Token: 0x060338A9 RID: 211113 RVA: 0x00CE3F94 File Offset: 0x00CE2194
		public void UpdateEnemyPositions(List<FKSC_MiniMapContext> positions)
		{
			List<TrapDefenseMonsterMarkItem> dynamicMarksByMarkType = this.GetDynamicMarksByMarkType<TrapDefenseMonsterMarkItem>(TrapDefenseDefine.ETrapDefenseMarkType.Phantom);
			for (int i = 0; i < positions.Count; i++)
			{
				if (i < dynamicMarksByMarkType.Count)
				{
					FVectorDouble location = positions[i].Location;
					dynamicMarksByMarkType[i].SetWorldPosition((float)location.X, (float)location.Y, (float)location.Z);
					dynamicMarksByMarkType[i].EnemyType = (ETrapDefenseEnemyType)positions[i].EnemyType;
				}
				else
				{
					this.AddMark(new TrapDefenseMarkInfo
					{
						MarkId = this.DynamicMarks.Count + 20000,
						MarkType = TrapDefenseDefine.ETrapDefenseMarkType.Phantom,
						ExtraParam = positions[i].EnemyType
					});
				}
			}
			List<TrapDefenseMonsterMarkItem> list = new List<TrapDefenseMonsterMarkItem>();
			for (int j = positions.Count; j < dynamicMarksByMarkType.Count; j++)
			{
				list.Add(dynamicMarksByMarkType[j]);
			}
			foreach (TrapDefenseMonsterMarkItem trapDefenseMonsterMarkItem in list)
			{
				this.RemoveDynamicMarkInfoByMarkId(trapDefenseMonsterMarkItem.MarkId);
			}
		}

		// Token: 0x060338AA RID: 211114 RVA: 0x00CE40C8 File Offset: 0x00CE22C8
		public USplineComponent GetSplineComponent(int splineId)
		{
			if (this.SplineComMap.ContainsKey(splineId))
			{
				return this.SplineComMap[splineId];
			}
			this.LoadSplineComponent(splineId);
			return this.SplineComMap[splineId];
		}

		// Token: 0x060338AB RID: 211115 RVA: 0x00CE40F8 File Offset: 0x00CE22F8
		public Dictionary<int, USplineComponent> GetAllSplineComponent()
		{
			return this.SplineComMap;
		}

		// Token: 0x060338AC RID: 211116 RVA: 0x00CE4100 File Offset: 0x00CE2300
		private void LoadSplineComponent(int splineId)
		{
			if (this.SplineComMap.ContainsKey(splineId))
			{
				return;
			}
			USplineComponent value = ModelBase<GameSplineModel>.Instance.LoadAndGetSplineComponent(splineId, this.SplineUid, EIdType.SimpleCombatPreviewId);
			this.SplineComMap[splineId] = value;
			this.SplineUidMap[splineId] = this.SplineUid;
			this.SplineUid++;
		}

		// Token: 0x060338AD RID: 211117 RVA: 0x00CE415C File Offset: 0x00CE235C
		public void ClearAllSpline()
		{
			foreach (KeyValuePair<int, USplineComponent> keyValuePair in this.SplineComMap)
			{
				USplineComponent value = keyValuePair.Value;
				int key = keyValuePair.Key;
				int num;
				this.SplineUidMap.TryGetValue(key, out num);
				ModelBase<GameSplineModel>.Instance.ReleaseSpline(key, (long)num, EIdType.SimpleCombatPreviewId);
			}
			this.SplineComMap.Clear();
			this.SplineUidMap.Clear();
			this.SplineUid = 0;
		}

		// Token: 0x060338AE RID: 211118 RVA: 0x00CE41F4 File Offset: 0x00CE23F4
		public void ClearMapChanged()
		{
			this.MapChanged = false;
		}

		// Token: 0x0401DD68 RID: 122216
		private int MapIdInner;

		// Token: 0x0401DD69 RID: 122217
		private bool MapChanged;

		// Token: 0x0401DD6A RID: 122218
		private Dictionary<int, TrapDefenseMarkItem> DynamicMarks = new Dictionary<int, TrapDefenseMarkItem>();

		// Token: 0x0401DD6B RID: 122219
		private Dictionary<TrapDefenseDefine.ETrapDefenseMarkType, List<TrapDefenseMarkItem>> MarksByType = new Dictionary<TrapDefenseDefine.ETrapDefenseMarkType, List<TrapDefenseMarkItem>>();

		// Token: 0x0401DD6C RID: 122220
		public Dictionary<int, List<global::Vector>> PhantomRoutes = new Dictionary<int, List<global::Vector>>();

		// Token: 0x0401DD6D RID: 122221
		public Dictionary<int, USplineComponent> SplineComMap = new Dictionary<int, USplineComponent>();

		// Token: 0x0401DD6E RID: 122222
		private Dictionary<int, int> SplineUidMap = new Dictionary<int, int>();

		// Token: 0x0401DD6F RID: 122223
		private int SplineUid;
	}
}
