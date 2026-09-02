using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.RoleUi;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066C6 RID: 26310
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorFightRankData
	{
		// Token: 0x1700A071 RID: 41073
		// (get) Token: 0x06041B52 RID: 269138 RVA: 0x010D9C64 File Offset: 0x010D7E64
		// (set) Token: 0x06041B53 RID: 269139 RVA: 0x010D9C6C File Offset: 0x010D7E6C
		public bool IsMyRank { get; set; }

		// Token: 0x06041B54 RID: 269140 RVA: 0x010D9C75 File Offset: 0x010D7E75
		public MotorFightRankData(bool isMyRank = false)
		{
			this.IsMyRank = isMyRank;
		}

		// Token: 0x06041B55 RID: 269141 RVA: 0x010D9CB0 File Offset: 0x010D7EB0
		public void SetDataByConfig(MotorFightRank data)
		{
			RoleInfo? roleConfig = this.GetRoleConfig(data.RoleId);
			this.Name = ConfigMultiTextLang.GetLocalTextNew(roleConfig.Value.Name, null);
			this.TexturePath = roleConfig.Value.FormationRoleCard;
			this.Score = data.Score;
			this.WaveNum = data.WaveNum;
			this.KillNum = data.KillNum;
			this.DisplayThreshold = data.DisplayThreshold;
			this.BuffGateNum = data.BuffGateNum;
			foreach (DicIntInt dicIntInt in data.CollectionItemIter())
			{
				int key = dicIntInt.Key;
				int value = dicIntInt.Value;
				MotorFightItem value2 = ConfigBase<MotorFightConfig>.Instance.GetMotorFightItemConfig(key).Value;
				MotorFightItemData item = new MotorFightItemData(value2, new int?(value));
				this.ItemList.Add(item);
				if (!this.ItemNumMap.ContainsKey(value2.Type))
				{
					this.ItemNumMap[value2.Type] = new Dictionary<int, int>();
				}
				Dictionary<int, int> dictionary = this.ItemNumMap[value2.Type];
				if (!dictionary.ContainsKey(value2.Quality))
				{
					dictionary[value2.Quality] = 0;
				}
				dictionary[value2.Quality] = (dictionary.ContainsKey(value2.Quality) ? dictionary[value2.Quality] : 0) + value;
				this.ItemNumMap[value2.Type] = dictionary;
			}
			this.ItemList.Sort(new Comparison<MotorFightItemData>(this.SortItemList));
			this.HasData = true;
		}

		// Token: 0x06041B56 RID: 269142 RVA: 0x010D9E90 File Offset: 0x010D8090
		[NullableContext(2)]
		public void SetDataByServerInfo(MotorFightPlayerRankingInfo data)
		{
			if (data == null || data.ResultCommon.TotalScore == 0)
			{
				this.Name = ModelBase<FunctionModel>.Instance.GetPlayerName();
				int trialRoleId = ControllerBase<MotorFightController>.Instance.GetMotorFightActivityData().GetMotorFightRoleList()[0].TrialRoleId;
				this.TexturePath = this.GetRoleConfig(ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(trialRoleId).Value.ParentId).Value.FormationRoleCard;
				return;
			}
			this.Name = data.Name;
			this.Score = data.ResultCommon.TotalScore;
			this.KillNum = data.ResultCommon.KillMonsterCount;
			this.WaveNum = data.ResultCommon.PassedWaveNum;
			this.BuffGateNum = data.ResultCommon.SelectedBuffGateCount;
			this.ItemList = new List<MotorFightItemData>();
			foreach (MotorFightCollectItemInfo motorFightCollectItemInfo in data.ResultCommon.Items)
			{
				MotorFightItem value = ConfigBase<MotorFightConfig>.Instance.GetMotorFightItemConfig(motorFightCollectItemInfo.ItemId).Value;
				MotorFightItemData item = new MotorFightItemData(value, new int?(motorFightCollectItemInfo.Count));
				this.ItemList.Add(item);
				if (!this.ItemNumMap.ContainsKey(value.Type))
				{
					this.ItemNumMap[value.Type] = new Dictionary<int, int>();
				}
				Dictionary<int, int> dictionary = this.ItemNumMap[value.Type];
				if (!dictionary.ContainsKey(value.Quality))
				{
					dictionary[value.Quality] = 0;
				}
				dictionary[value.Quality] = (dictionary.ContainsKey(value.Quality) ? dictionary[value.Quality] : 0) + motorFightCollectItemInfo.Count;
				this.ItemNumMap[value.Type] = dictionary;
			}
			this.ItemList.Sort(new Comparison<MotorFightItemData>(this.SortItemList));
			MotorFightRole? motorFightRoleConfig = ConfigBase<MotorFightConfig>.Instance.GetMotorFightRoleConfig(data.ResultCommon.RoleId);
			if (motorFightRoleConfig == null)
			{
				return;
			}
			this.TexturePath = this.GetRoleConfig(ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(motorFightRoleConfig.Value.TrialRole).Value.ParentId).Value.FormationRoleCard;
			this.HasData = true;
		}

		// Token: 0x06041B57 RID: 269143 RVA: 0x010DA134 File Offset: 0x010D8334
		private RoleInfo? GetRoleConfig(int roleId)
		{
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
			if (roleConfig == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MotorFightActivity;
				ELogAuthor author = ELogAuthor.CXJ;
				string message = "摩托战斗排行榜角色数据异常";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", roleId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return roleConfig;
		}

		// Token: 0x06041B58 RID: 269144 RVA: 0x010DA190 File Offset: 0x010D8390
		private int SortItemList(MotorFightItemData a, MotorFightItemData b)
		{
			if (a.Type != b.Type)
			{
				Dictionary<int, int> dictionary = this.ItemNumMap[a.Type];
				Dictionary<int, int> dictionary2 = this.ItemNumMap[b.Type];
				if (dictionary.Count != dictionary2.Count)
				{
					return dictionary2.Count - dictionary.Count;
				}
				for (int i = 5; i >= 3; i--)
				{
					int num = dictionary.ContainsKey(i) ? dictionary[i] : 0;
					int num2 = dictionary2.ContainsKey(i) ? dictionary2[i] : 0;
					if (num != num2)
					{
						return num2 - num;
					}
				}
				return a.Type - b.Type;
			}
			else
			{
				if (a.Quality != b.Quality)
				{
					return b.Quality - a.Quality;
				}
				return a.Id - b.Id;
			}
		}

		// Token: 0x04024AAB RID: 150187
		private const int HIGHEST_QUALITY = 5;

		// Token: 0x04024AAC RID: 150188
		private const int LOWEST_QUALITY = 3;

		// Token: 0x04024AAD RID: 150189
		public string Name = "";

		// Token: 0x04024AAE RID: 150190
		public bool HasData;

		// Token: 0x04024AAF RID: 150191
		public int Score;

		// Token: 0x04024AB0 RID: 150192
		public string TexturePath = "";

		// Token: 0x04024AB1 RID: 150193
		public int KillNum;

		// Token: 0x04024AB2 RID: 150194
		public int WaveNum;

		// Token: 0x04024AB3 RID: 150195
		public int BuffGateNum;

		// Token: 0x04024AB4 RID: 150196
		public int DisplayThreshold;

		// Token: 0x04024AB5 RID: 150197
		public Dictionary<int, Dictionary<int, int>> ItemNumMap = new Dictionary<int, Dictionary<int, int>>();

		// Token: 0x04024AB7 RID: 150199
		public List<MotorFightItemData> ItemList = new List<MotorFightItemData>();
	}
}
