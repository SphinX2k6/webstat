using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x0200628B RID: 25227
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class ActivityTetrisConfig : ConfigBase<ActivityTetrisConfig>
	{
		// Token: 0x0603F81B RID: 260123 RVA: 0x0104850C File Offset: 0x0104670C
		public List<IShapeConfig> GetAllShape()
		{
			List<IShapeConfig> list = new List<IShapeConfig>();
			foreach (TetrisShape tetrisShape in ConfigTetrisShapeAll.GetConfigList(true))
			{
				list.Add(this.GetTetrisShape(tetrisShape.Id));
			}
			return list;
		}

		// Token: 0x0603F81C RID: 260124 RVA: 0x0104856C File Offset: 0x0104676C
		public IShapeConfig GetTetrisShape(int id)
		{
			TetrisShape value = ConfigTetrisShapeById.GetConfig(id, true).Value;
			string[] array = new string[]
			{
				value.Column1,
				value.Column2,
				value.Column3,
				value.Column4,
				value.Column5
			};
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != null)
				{
					if (array[i].Length > num)
					{
						num = array[i].Length;
					}
					num2 = i + 1;
				}
			}
			if (num == 0)
			{
				return new ShapeConfig
				{
					Id = value.Id,
					Weight = value.Weight,
					Matrix = new int[0][]
				};
			}
			int[][] array2 = new int[num][];
			for (int j = 0; j < num; j++)
			{
				array2[j] = new int[num2];
			}
			for (int k = 0; k < num2; k++)
			{
				string text = array[k];
				for (int l = 0; l < num; l++)
				{
					char c = (text != null && l < text.Length) ? text[l] : '0';
					array2[l][k] = ((c == '1') ? 1 : 0);
				}
			}
			return new ShapeConfig
			{
				Id = value.Id,
				Weight = value.Weight,
				Matrix = array2
			};
		}

		// Token: 0x0603F81D RID: 260125 RVA: 0x010486C8 File Offset: 0x010468C8
		public TetrisBoardItemConfig[][] GetTetrisMap(int id)
		{
			TetrisBoardItemConfig[][] array = new TetrisBoardItemConfig[8][];
			IReadOnlyList<TetrisMap> configList = ConfigTetrisMapByMapId.GetConfigList(id, true);
			for (int i = 0; i < 8; i++)
			{
				array[i] = new TetrisBoardItemConfig[8];
				for (int j = 0; j < 8; j++)
				{
					string name = StringUtils.Format("Column{0}", new string[]
					{
						(j + 1).ToString()
					});
					array[i][j] = (TetrisBoardItemConfig)configList[i].GetType().GetProperty(name).GetValue(configList[i]);
				}
			}
			return array;
		}

		// Token: 0x0603F81E RID: 260126 RVA: 0x01048760 File Offset: 0x01046960
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<IShapeConfig> GetBlocksFromConfig(int levelId, int roundIndex)
		{
			IReadOnlyList<TetrisPreset> configList = ConfigTetrisPresetByLevelIdAndRound.GetConfigList(levelId, roundIndex, true);
			if (configList == null)
			{
				return null;
			}
			List<IShapeConfig> list = new List<IShapeConfig>();
			foreach (TetrisPreset tetrisPreset in configList)
			{
				IShapeConfig tetrisShape = this.GetTetrisShape(tetrisPreset.ShapeId);
				list.Add(tetrisShape);
			}
			return list;
		}

		// Token: 0x0603F81F RID: 260127 RVA: 0x010487D0 File Offset: 0x010469D0
		public List<ITetrisSelectGroupData> GetAllGroupByActivityId(int activityId)
		{
			IReadOnlyList<Tetris> configList = ConfigTetrisByActivityId.GetConfigList(activityId, true);
			if (configList == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Log;
				ELogAuthor author = ELogAuthor.SWC;
				string message = "俄罗斯方块配置找不到对应的活动id";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("activityId", activityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return new List<ITetrisSelectGroupData>();
			}
			Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
			foreach (Tetris tetris in configList)
			{
				if (!dictionary.ContainsKey(tetris.GroupId))
				{
					dictionary.Add(tetris.GroupId, new List<int>());
				}
				dictionary[tetris.GroupId].Add(tetris.Id);
			}
			List<ITetrisSelectGroupData> list = new List<ITetrisSelectGroupData>();
			foreach (KeyValuePair<int, List<int>> keyValuePair in dictionary)
			{
				list.Add(new TetrisSelectGroupData
				{
					GroupId = keyValuePair.Key,
					ChallengeIds = keyValuePair.Value
				});
			}
			return list;
		}

		// Token: 0x0603F820 RID: 260128 RVA: 0x010488F8 File Offset: 0x01046AF8
		public Tetris GetLevelConfig(int id)
		{
			Tetris? config = ConfigTetrisById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Log;
				ELogAuthor author = ELogAuthor.SWC;
				string message = "俄罗斯方块找不到对应关卡配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config.Value;
		}

		// Token: 0x0603F821 RID: 260129 RVA: 0x01048948 File Offset: 0x01046B48
		public unsafe IReadOnlyList<Tetris> GetGroupLevels(int activityId, int groupId)
		{
			IReadOnlyList<Tetris> configList = ConfigTetrisByActivityIdAndGroupId.GetConfigList(activityId, groupId, true);
			if (configList == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Log;
				ELogAuthor author = ELogAuthor.SWC;
				string message = "俄罗斯方块找不到对应关卡配置";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("activityId", activityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("groupId", groupId);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			return configList;
		}

		// Token: 0x0603F822 RID: 260130 RVA: 0x010489BC File Offset: 0x01046BBC
		public TetrisSetting? GetSetting(string key)
		{
			TetrisSetting? config = ConfigTetrisSettingByKey.GetConfig(key, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Log;
				ELogAuthor author = ELogAuthor.SWC;
				string message = "俄罗斯方块找不到对应游戏设置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("key", key);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return new TetrisSetting?(config.Value);
		}

		// Token: 0x0603F823 RID: 260131 RVA: 0x01048A18 File Offset: 0x01046C18
		public TetrisGem? GetGemConfig(int id)
		{
			TetrisGem? config = ConfigTetrisGemById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Log;
				ELogAuthor author = ELogAuthor.SWC;
				string message = "俄罗斯方块找不到对应宝石配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return new TetrisGem?(config.Value);
		}
	}
}
