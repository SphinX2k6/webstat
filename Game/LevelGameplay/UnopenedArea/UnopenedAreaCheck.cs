using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.LevelGamePlay.BinTest;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.UnopenedArea
{
	// Token: 0x02006A65 RID: 27237
	[NullableContext(1)]
	[Nullable(0)]
	public class UnopenedAreaCheck
	{
		// Token: 0x06043600 RID: 275968 RVA: 0x0115A680 File Offset: 0x01158880
		public void AreaInit(IReadOnlyDictionary<int, bool> areaStates)
		{
			foreach (KeyValuePair<int, bool> keyValuePair in areaStates)
			{
				int num;
				bool flag;
				keyValuePair.Deconstruct(out num, out flag);
				int areaId = num;
				bool check = flag;
				this.UpdateAreaBinItem(areaId, check);
			}
			if (areaStates.Count == 0)
			{
				Singleton<Log>.Instance.Info(ELogModule.Map, ELogAuthor.CWZ, "初始化区域数量为零", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.FailureCount = 0;
			this.IsSplineInit = true;
		}

		// Token: 0x06043601 RID: 275969 RVA: 0x0115A710 File Offset: 0x01158910
		public unsafe void AreaStatesChange(SceneAreaStateNotify notify)
		{
			this.UpdateAreaBinItem(notify.AreaState.AreaId, notify.AreaState.State);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Map;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "AreaStatesChange更新区域边界状态";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("AreaState.AreaId", notify.AreaState.AreaId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("AreaState.State", notify.AreaState.State);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x06043602 RID: 275970 RVA: 0x0115A7AC File Offset: 0x011589AC
		private unsafe void UpdateAreaBinItem(int areaId, bool check)
		{
			Area? config = ConfigAreaByAreaId.GetConfig(areaId, true);
			if (config == null || string.IsNullOrEmpty(config.Value.EdgeWallName))
			{
				return;
			}
			string filePath = config.Value.EdgeWallName + "_C";
			int mapConfigId = config.Value.MapConfigId;
			int dungeonId = config.Value.DungeonId;
			if (!check)
			{
				HashSet<int> hashSet;
				if (this.AreaPathMap.TryGetValue(filePath, out hashSet) && hashSet.Contains(areaId))
				{
					hashSet.Remove(areaId);
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Map;
					ELogAuthor author = ELogAuthor.CWZ;
					string message = "AreaPathMap区域删除";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("AreaId", areaId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Path", filePath);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				if ((hashSet == null || hashSet.Count == 0) && this.BinMap.ContainsKey(filePath))
				{
					this.BinMap.Remove(filePath);
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Map;
					ELogAuthor author2 = ELogAuthor.CWZ;
					string message2 = "BinMap移除边界";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", filePath);
					instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				HashSet<string> hashSet2;
				if (this.DungeonMap.TryGetValue(dungeonId, out hashSet2) && hashSet2.Remove(filePath) && hashSet2.Count == 0)
				{
					this.DungeonMap.Remove(dungeonId);
					return;
				}
			}
			else
			{
				if (!this.AreaPathMap.ContainsKey(filePath))
				{
					this.AreaPathMap[filePath] = new HashSet<int>();
				}
				if (!this.AreaPathMap[filePath].Contains(areaId))
				{
					this.AreaPathMap[filePath].Add(areaId);
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.Map;
					ELogAuthor author3 = ELogAuthor.CWZ;
					string message3 = "AreaPathMap区域添加";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("AreaId", areaId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Path", filePath);
					instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				}
				if (!this.BinMap.ContainsKey(filePath))
				{
					BinItem newBinItem = new BinItem();
					newBinItem.MapId = mapConfigId;
					newBinItem.DungeonId = dungeonId;
					newBinItem.InitCallback = delegate()
					{
						if (newBinItem == null || newBinItem.BinSet == null || newBinItem.TestPoints == null)
						{
							Log instance4 = Singleton<Log>.Instance;
							ELogModule module4 = ELogModule.Map;
							ELogAuthor author4 = ELogAuthor.CWZ;
							string message4 = "BinMap添加边界出错";
							ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Path", filePath);
							instance4.Info(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
							return;
						}
						this.BinMap[filePath] = newBinItem;
						Log instance5 = Singleton<Log>.Instance;
						ELogModule module5 = ELogModule.Map;
						ELogAuthor author5 = ELogAuthor.CWZ;
						string message5 = "BinMap添加边界";
						ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Path", filePath);
						instance5.Info(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
					};
					newBinItem.Init(filePath);
				}
				HashSet<string> hashSet3;
				if (!this.DungeonMap.TryGetValue(dungeonId, out hashSet3))
				{
					hashSet3 = new HashSet<string>();
					this.DungeonMap[dungeonId] = hashSet3;
				}
				hashSet3.Add(filePath);
			}
		}

		// Token: 0x06043603 RID: 275971 RVA: 0x0115AAA4 File Offset: 0x01158CA4
		public unsafe bool BinTest(IVector2D inputP, int mapId, int dungeonId)
		{
			if (!this.IsSplineInit || this.BinMap.Count == 0)
			{
				if (this.FailureCount <= 7)
				{
					this.FailureCount++;
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Map;
					ELogAuthor author = ELogAuthor.CWZ;
					string message = "检测是否进入未开放区域，检测失败";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("IsSplineInit", this.IsSplineInit);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BinMap.size", this.BinMap.Count);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					if (this.FailureCount == 7)
					{
						Singleton<Log>.Instance.Info(ELogModule.Map, ELogAuthor.CWZ, "检测是否进入未开放区域一直失败，不报Log了", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
				}
				return true;
			}
			if (this.FailureCount != 0)
			{
				this.FailureCount = 0;
				Singleton<Log>.Instance.Info(ELogModule.Map, ELogAuthor.CWZ, "检测是否进入未开放区域，恢复正常检测", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			bool flag = false;
			HashSet<string> hashSet;
			if (this.DungeonMap.TryGetValue(dungeonId, out hashSet) && hashSet.Count > 0)
			{
				foreach (string key in hashSet)
				{
					BinItem binItem;
					if (this.BinMap.TryGetValue(key, out binItem))
					{
						flag = true;
						if (binItem.BinTest(inputP))
						{
							return true;
						}
					}
				}
			}
			if (flag)
			{
				return false;
			}
			foreach (KeyValuePair<string, BinItem> keyValuePair in this.BinMap)
			{
				if (mapId == keyValuePair.Value.MapId)
				{
					flag = true;
					if (keyValuePair.Value.BinTest(inputP))
					{
						return true;
					}
				}
			}
			return !flag;
		}

		// Token: 0x06043604 RID: 275972 RVA: 0x0115AC8C File Offset: 0x01158E8C
		public void Clear()
		{
			this.IsSplineInit = false;
			this.BinMap.Clear();
		}

		// Token: 0x040259E1 RID: 154081
		private const int FAILURE_COUNT = 7;

		// Token: 0x040259E2 RID: 154082
		public bool IsSplineInit;

		// Token: 0x040259E3 RID: 154083
		private int FailureCount;

		// Token: 0x040259E4 RID: 154084
		private readonly Dictionary<string, BinItem> BinMap = new Dictionary<string, BinItem>();

		// Token: 0x040259E5 RID: 154085
		private readonly Dictionary<string, HashSet<int>> AreaPathMap = new Dictionary<string, HashSet<int>>();

		// Token: 0x040259E6 RID: 154086
		private readonly Dictionary<int, HashSet<string>> DungeonMap = new Dictionary<int, HashSet<string>>();
	}
}
