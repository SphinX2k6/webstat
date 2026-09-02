using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200590E RID: 22798
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class MapRogueModel : ModelBase<MapRogueModel>
	{
		// Token: 0x06039DDB RID: 237019 RVA: 0x00EA6CA0 File Offset: 0x00EA4EA0
		public void RefreshGameInfo(IGameInfoInitData gameInfo)
		{
			if (this.GameInfo == null)
			{
				this.GameInfo = new MapRogueGameInfo();
			}
			this.GameInfo.Refresh(gameInfo);
			this.CurrencyItemId = gameInfo.CurrencyItemId;
			this.RoleLevel = gameInfo.RoleLevel;
			this.RoleMaxStar = gameInfo.RoleMaxStar;
		}

		// Token: 0x06039DDC RID: 237020 RVA: 0x00EA6CF0 File Offset: 0x00EA4EF0
		public void ResetGameInfo()
		{
			MapRogueGameInfo gameInfo = this.GameInfo;
			if (gameInfo != null)
			{
				gameInfo.Clear();
			}
			this.GameInfo = null;
			this.GameOpList.Clear();
		}

		// Token: 0x06039DDD RID: 237021 RVA: 0x00EA6D18 File Offset: 0x00EA4F18
		public void GenerateOpList(IList<RogueResOpData> dataList)
		{
			this.GameOpList.Clear();
			foreach (RogueResOpData data in dataList)
			{
				this.AddOpData(data, false);
			}
			this.GameOpList.Sort(new Comparison<MapRogueOp>(this.SortOpData));
			this.PrintAllOpList();
		}

		// Token: 0x06039DDE RID: 237022 RVA: 0x00EA6D8C File Offset: 0x00EA4F8C
		public unsafe void PrintAllOpList()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RogueBattle;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "[MapRogue] 指令队列打印开始";
			string item = "InBattle";
			MapRogueGameInfo gameInfo = this.GameInfo;
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (gameInfo != null) ? new bool?(gameInfo.InBattle) : null);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			for (int i = 0; i < this.GameOpList.Count; i++)
			{
				MapRogueOp mapRogueOp = this.GameOpList[i];
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.RogueBattle;
				ELogAuthor author2 = ELogAuthor.YYZ;
				string message2 = "[MapRogue] 指令";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Index", i);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Data", mapRogueOp.ToString());
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}

		// Token: 0x06039DDF RID: 237023 RVA: 0x00EA6E70 File Offset: 0x00EA5070
		public unsafe void AddOpData(RogueResOpData data, bool emitSort = true)
		{
			MapRogueOp mapRogueOp = null;
			switch (data.RogueResOpType)
			{
			case RogueResOpType.Move:
			{
				MapRogueGameInfo gameInfo = this.GameInfo;
				mapRogueOp = new MapRogueOpMove((gameInfo != null) ? gameInfo.PlayerGridIndex : 0);
				break;
			}
			case RogueResOpType.GridEvent:
				mapRogueOp = new MapRogueOpGridEvent();
				break;
			case RogueResOpType.SelectView:
				mapRogueOp = new MapRogueOpSelectView();
				break;
			case RogueResOpType.ShowView:
				mapRogueOp = new MapRogueOpShowView();
				break;
			case RogueResOpType.RogueGotoLevelPlay:
				mapRogueOp = new MapRogueOpGotoLevelPlay();
				break;
			case RogueResOpType.RollBuffBondLinkId:
				mapRogueOp = new MapRogueOpRoleBuffBondLinkId();
				break;
			case RogueResOpType.FallbackView:
				mapRogueOp = new MapRogueOpFallback();
				break;
			case RogueResOpType.LightBlockByLocationEffect:
				mapRogueOp = new MapRogueOpGridFocus();
				break;
			case RogueResOpType.MapTeleportByLocationEffect:
				mapRogueOp = new MapRogueOpTeleport();
				break;
			case RogueResOpType.ChangeEventByPos:
				mapRogueOp = new MapRogueOpChangeEvent();
				break;
			}
			if (mapRogueOp != null)
			{
				mapRogueOp.Update(data, this.GameInfo);
				this.GameOpList.Add(mapRogueOp);
				this.GameOpMap[data.IncId] = mapRogueOp;
				if (emitSort)
				{
					this.GameOpList.Sort(new Comparison<MapRogueOp>(this.SortOpData));
				}
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RogueBattle;
				ELogAuthor author = ELogAuthor.YYZ;
				string message = "[MapRogue] 新增指令";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Index", this.GameOpList.Count - 1);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Data", mapRogueOp.ToString());
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}

		// Token: 0x06039DE0 RID: 237024 RVA: 0x00EA6FD8 File Offset: 0x00EA51D8
		public unsafe void RemoveOpData(int incId)
		{
			if (this.GameInfo == null)
			{
				return;
			}
			MapRogueOp mapRogueOp;
			if (!this.GameOpMap.TryGetValue(incId, out mapRogueOp))
			{
				return;
			}
			mapRogueOp.Delete(this.GameInfo);
			int num = this.GameOpList.FindIndex((MapRogueOp op) => op.IncId == incId);
			if (num != -1)
			{
				this.GameOpList.RemoveAt(num);
			}
			this.GameOpMap.Remove(incId);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RogueBattle;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "[MapRogue] 删除指令";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Index", num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IncId", incId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x06039DE1 RID: 237025 RVA: 0x00EA70BC File Offset: 0x00EA52BC
		public void UpdateOpData(RogueResOpData data)
		{
			MapRogueOp mapRogueOp;
			if (!this.GameOpMap.TryGetValue(data.IncId, out mapRogueOp))
			{
				return;
			}
			mapRogueOp.Update(data, this.GameInfo);
		}

		// Token: 0x06039DE2 RID: 237026 RVA: 0x00EA70EC File Offset: 0x00EA52EC
		private int SortOpData(MapRogueOp opA, MapRogueOp opB)
		{
			return opB.Priority - opA.Priority;
		}

		// Token: 0x06039DE3 RID: 237027 RVA: 0x00EA70FC File Offset: 0x00EA52FC
		[NullableContext(2)]
		public MapRogueOp GetOpData(int incId)
		{
			MapRogueOp result;
			this.GameOpMap.TryGetValue(incId, out result);
			return result;
		}

		// Token: 0x06039DE4 RID: 237028 RVA: 0x00EA7119 File Offset: 0x00EA5319
		public List<MapRogueOp> GetAllOpData()
		{
			return this.GameOpList;
		}

		// Token: 0x06039DE5 RID: 237029 RVA: 0x00EA7124 File Offset: 0x00EA5324
		public List<MapRogueOp> GetOpDataByType(RogueResOpType type)
		{
			List<MapRogueOp> list = new List<MapRogueOp>();
			foreach (MapRogueOp mapRogueOp in this.GameOpList)
			{
				if (mapRogueOp.Type == type)
				{
					list.Add(mapRogueOp);
				}
			}
			return list;
		}

		// Token: 0x06039DE6 RID: 237030 RVA: 0x00EA7188 File Offset: 0x00EA5388
		[NullableContext(2)]
		public void ExecuteOpData(int incId, Action<bool> callback = null)
		{
			if (this.GameInfo == null)
			{
				return;
			}
			MapRogueOp mapRogueOp;
			if (this.GameOpMap.TryGetValue(incId, out mapRogueOp) && mapRogueOp != null)
			{
				mapRogueOp.Execute(this.GameInfo, callback);
			}
		}

		// Token: 0x06039DE7 RID: 237031 RVA: 0x00EA71C0 File Offset: 0x00EA53C0
		public void ExecuteOpDataList()
		{
			if (this.GameInfo == null)
			{
				return;
			}
			if (this.GameOpList.Count > 0)
			{
				MapRogueOp mapRogueOp = this.GameOpList[this.GameOpList.Count - 1];
				this.GameInfo.GameStage = EMapRogueGameStage.Wait;
				mapRogueOp.StartExecute(this.GameInfo);
				return;
			}
			this.GameInfo.GameStage = EMapRogueGameStage.Norm;
		}

		// Token: 0x06039DE8 RID: 237032 RVA: 0x00EA7220 File Offset: 0x00EA5420
		public List<MapGridData> CreateMapGridDataList(IList<RogueResGridData> dataList, int randomSeed)
		{
			SeedRandomUtil seedRandomUtil = new SeedRandomUtil();
			seedRandomUtil.SetSeed((long)randomSeed);
			List<MapGridData> list = new List<MapGridData>();
			for (int i = 0; i < dataList.Count; i++)
			{
				RogueResGridData data = dataList[i];
				MapGridData mapGridData = new MapGridData();
				mapGridData.RefreshByServer(data);
				mapGridData.GridIndex = i;
				this.SetGridType(mapGridData, seedRandomUtil);
				list.Add(mapGridData);
			}
			return list;
		}

		// Token: 0x06039DE9 RID: 237033 RVA: 0x00EA7284 File Offset: 0x00EA5484
		public void RefreshMapGridData(int index, RogueResGridData data)
		{
			if (index >= this.GameInfo.MapGrids.Count)
			{
				return;
			}
			MapGridData mapGridData = this.GameInfo.MapGrids[index];
			if (mapGridData == null)
			{
				return;
			}
			int gridTypeId = mapGridData.GridTypeId;
			bool isExplore = mapGridData.IsExplore;
			mapGridData.RefreshByServer(data);
			if (gridTypeId != mapGridData.GridTypeId)
			{
				SeedRandomUtil seedRandomUtil = new SeedRandomUtil();
				seedRandomUtil.SetSeed((long)this.GameInfo.RandomSeed);
				this.SetGridType(mapGridData, seedRandomUtil);
			}
			this.GameInfo.RefreshGrid(index, isExplore != mapGridData.IsExplore);
		}

		// Token: 0x06039DEA RID: 237034 RVA: 0x00EA7310 File Offset: 0x00EA5510
		private void SetGridType(MapGridData gridData, SeedRandomUtil seedRandomUtil)
		{
			RogueResGridMapType? gridMapTypeConfigById = ConfigBase<MapRogueConfig>.Instance.GetGridMapTypeConfigById(gridData.GridTypeId);
			if (gridMapTypeConfigById == null)
			{
				return;
			}
			List<int> weights = new List<int>(gridMapTypeConfigById.Value.GroundPath().Values);
			gridData.GroundPathIndex = seedRandomUtil.WeightedRandom(weights);
			Dictionary<string, int> dictionary = gridMapTypeConfigById.Value.DecorationPath();
			if (dictionary != null && dictionary.Count > 0)
			{
				List<int> weights2 = new List<int>(dictionary.Values);
				gridData.ExtraPathIndex = seedRandomUtil.WeightedRandom(weights2);
				return;
			}
			gridData.ExtraPathIndex = -1;
		}

		// Token: 0x06039DEB RID: 237035 RVA: 0x00EA739E File Offset: 0x00EA559E
		[NullableContext(2)]
		public IRogueGetListItemData ShiftGetItemData()
		{
			if (this.GameInfo == null)
			{
				return null;
			}
			return this.GameInfo.ShiftGetItemData();
		}

		// Token: 0x06039DEC RID: 237036 RVA: 0x00EA73B5 File Offset: 0x00EA55B5
		public int GetRogueCurrencyItemId()
		{
			return this.CurrencyItemId;
		}

		// Token: 0x06039DED RID: 237037 RVA: 0x00EA73BD File Offset: 0x00EA55BD
		public int GetRogueRoleLevel()
		{
			return this.RoleLevel;
		}

		// Token: 0x06039DEE RID: 237038 RVA: 0x00EA73C5 File Offset: 0x00EA55C5
		public void SetRoleLevel(int level)
		{
			this.RoleLevel = level;
		}

		// Token: 0x06039DEF RID: 237039 RVA: 0x00EA73CE File Offset: 0x00EA55CE
		public int GetRogueRoleMaxStar()
		{
			return this.RoleMaxStar;
		}

		// Token: 0x06039DF0 RID: 237040 RVA: 0x00EA73D8 File Offset: 0x00EA55D8
		public int GetExploredGridCount()
		{
			int num = 0;
			foreach (MapGridData mapGridData in this.GameInfo.MapGrids)
			{
				num += ((mapGridData.IsExplore > false) ? 1 : 0);
			}
			return num;
		}

		// Token: 0x06039DF1 RID: 237041 RVA: 0x00EA7438 File Offset: 0x00EA5638
		public bool GetDebugMode()
		{
			return this.DebugMode;
		}

		// Token: 0x06039DF2 RID: 237042 RVA: 0x00EA7440 File Offset: 0x00EA5640
		public void SetDebugMode(bool bOn)
		{
			this.DebugMode = bOn;
		}

		// Token: 0x04020CA0 RID: 134304
		[Nullable(2)]
		public MapRogueGameInfo GameInfo;

		// Token: 0x04020CA1 RID: 134305
		protected List<MapRogueOp> GameOpList = new List<MapRogueOp>();

		// Token: 0x04020CA2 RID: 134306
		protected Dictionary<int, MapRogueOp> GameOpMap = new Dictionary<int, MapRogueOp>();

		// Token: 0x04020CA3 RID: 134307
		private int CurrencyItemId;

		// Token: 0x04020CA4 RID: 134308
		private int RoleLevel;

		// Token: 0x04020CA5 RID: 134309
		private int RoleMaxStar;

		// Token: 0x04020CA6 RID: 134310
		private bool DebugMode;
	}
}
