using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.MapRogue;
using CSharpScript.Game.Module.PermanentRogue;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Module.InstanceDungeon;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005258 RID: 21080
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class RogueBattleModel : ModelBase<RogueBattleModel>
	{
		// Token: 0x17008CED RID: 36077
		// (get) Token: 0x06035F53 RID: 221011 RVA: 0x00D92374 File Offset: 0x00D90574
		// (set) Token: 0x06035F54 RID: 221012 RVA: 0x00D92381 File Offset: 0x00D90581
		public string CurrentRoomMusicState
		{
			get
			{
				return this.CurrentRoomMusicStateInternal.State;
			}
			set
			{
				this.CurrentRoomMusicStateInternal.State = (value ?? "none");
			}
		}

		// Token: 0x06035F55 RID: 221013 RVA: 0x00D92398 File Offset: 0x00D90598
		public void ChangeDescMode()
		{
			this.DescMode = ((this.DescMode == EDescModel.SIMPLE) ? EDescModel.DETAIL : EDescModel.SIMPLE);
			Singleton<EventSystem>.Instance.Emit(EEventName.RogueBattleDescModeChange);
		}

		// Token: 0x06035F56 RID: 221014 RVA: 0x00D923BC File Offset: 0x00D905BC
		[NullableContext(2)]
		public RogueResOption GetOptionDataById(int index)
		{
			RogueResOption result;
			if (!this.OptionMap.TryGetValue(index, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x06035F57 RID: 221015 RVA: 0x00D923DC File Offset: 0x00D905DC
		public void SetOptionData(int bindId, RogueResOption data)
		{
			this.OptionMap[bindId] = data;
		}

		// Token: 0x06035F58 RID: 221016 RVA: 0x00D923EB File Offset: 0x00D905EB
		[NullableContext(2)]
		public RogueResFormation GetFormationDataByIndex(int index)
		{
			if (index < 0 || index >= this.FormationData.Count)
			{
				return null;
			}
			return this.FormationData[index];
		}

		// Token: 0x06035F59 RID: 221017 RVA: 0x00D92410 File Offset: 0x00D90610
		public void UpdateFormationData(int index, RogueResFormation data)
		{
			if (index < 0)
			{
				return;
			}
			if (index < this.FormationData.Count)
			{
				this.FormationData[index] = data;
				return;
			}
			while (this.FormationData.Count < index)
			{
				this.FormationData.Add(new RogueResFormation());
			}
			this.FormationData.Add(data);
		}

		// Token: 0x06035F5A RID: 221018 RVA: 0x00D92468 File Offset: 0x00D90668
		[NullableContext(2)]
		public RogueResGainData GetPhantomData()
		{
			if (!this.TotalGainDataMap.ContainsKey(RogueResDataType.Phantom))
			{
				return null;
			}
			using (Dictionary<int, RogueResGainData>.ValueCollection.Enumerator enumerator = this.TotalGainDataMap[RogueResDataType.Phantom].Values.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					return enumerator.Current;
				}
			}
			return null;
		}

		// Token: 0x06035F5B RID: 221019 RVA: 0x00D924D4 File Offset: 0x00D906D4
		public List<RogueResGainData> GetTokenData()
		{
			List<RogueResGainData> list = new List<RogueResGainData>();
			if (!this.TotalGainDataMap.ContainsKey(RogueResDataType.Token))
			{
				return list;
			}
			foreach (RogueResGainData item in this.TotalGainDataMap[RogueResDataType.Token].Values)
			{
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06035F5C RID: 221020 RVA: 0x00D9254C File Offset: 0x00D9074C
		[NullableContext(2)]
		public RogueResRole GetRoleInfoById(int id)
		{
			Dictionary<int, RogueResGainData> dictionary;
			if (!this.TotalGainDataMap.TryGetValue(RogueResDataType.Role, out dictionary))
			{
				Singleton<Log>.Instance.Error(ELogModule.RogueBattle, ELogAuthor.LPH, "没有角色数据", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			RogueResGainData rogueResGainData;
			if (dictionary.TryGetValue(id, out rogueResGainData))
			{
				return rogueResGainData.RogueResRole;
			}
			return null;
		}

		// Token: 0x06035F5D RID: 221021 RVA: 0x00D925A0 File Offset: 0x00D907A0
		public int GetIncIdByRoleId(int roleId)
		{
			Dictionary<int, RogueResGainData> dictionary;
			if (!this.TotalGainDataMap.TryGetValue(RogueResDataType.Role, out dictionary))
			{
				return 0;
			}
			foreach (KeyValuePair<int, RogueResGainData> keyValuePair in dictionary)
			{
				RogueResRole rogueResRole = keyValuePair.Value.RogueResRole;
				if (rogueResRole != null && rogueResRole.RoleIdOrTrialRoleId == roleId)
				{
					return keyValuePair.Key;
				}
			}
			return 0;
		}

		// Token: 0x06035F5E RID: 221022 RVA: 0x00D92624 File Offset: 0x00D90824
		public List<RoleDataBase> GetRoleList()
		{
			Dictionary<int, RogueResGainData> dictionary;
			if (!this.TotalGainDataMap.TryGetValue(RogueResDataType.Role, out dictionary))
			{
				Singleton<Log>.Instance.Error(ELogModule.RogueBattle, ELogAuthor.LPH, "没有角色数据", default(ReadOnlySpan<ValueTuple<string, object>>));
				return new List<RoleDataBase>();
			}
			List<RoleDataBase> list = new List<RoleDataBase>();
			foreach (RogueResGainData rogueResGainData in dictionary.Values)
			{
				int roleIdOrTrialRoleId = rogueResGainData.RogueResRole.RoleIdOrTrialRoleId;
				RoleDataBase roleDataBase;
				if (roleIdOrTrialRoleId > 100000)
				{
					roleDataBase = new RoleRobotData(roleIdOrTrialRoleId);
				}
				else
				{
					roleDataBase = new RogueBattleRoleData(roleIdOrTrialRoleId);
				}
				roleDataBase.GetLevelData().SetLevel(ModelBase<MapRogueModel>.Instance.GetRogueRoleLevel());
				list.Add(roleDataBase);
			}
			return list;
		}

		// Token: 0x06035F5F RID: 221023 RVA: 0x00D926F4 File Offset: 0x00D908F4
		public bool IsRoleGot(int roleId)
		{
			Dictionary<int, RogueResGainData> dictionary;
			if (!this.TotalGainDataMap.TryGetValue(RogueResDataType.Role, out dictionary))
			{
				Singleton<Log>.Instance.Error(ELogModule.RogueBattle, ELogAuthor.LPH, "没有角色数据", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			using (Dictionary<int, RogueResGainData>.ValueCollection.Enumerator enumerator = dictionary.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.RogueResRole.RoleIdOrTrialRoleId == roleId)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06035F60 RID: 221024 RVA: 0x00D92784 File Offset: 0x00D90984
		public RoleBondInfo GetRoleBondDataById(int id)
		{
			if (!this.RoleFetterMap.ContainsKey(id))
			{
				RogueResBond? rogueResBond = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBond(id);
				int valueOrDefault = ((rogueResBond != null) ? rogueResBond.GetValueOrDefault().GetStarMap(1) : null).GetValueOrDefault();
				return new RoleBondInfo
				{
					ConfigId = id,
					CurStar = 0,
					TargetStar = valueOrDefault,
					Level = 0
				};
			}
			return this.RoleFetterMap[id];
		}

		// Token: 0x06035F61 RID: 221025 RVA: 0x00D92808 File Offset: 0x00D90A08
		public RoleBondInfo GetRoleBondPreviewDataById(int bondId, int upStar = 0, int? designatedLv = null, int? designatedStar = null)
		{
			RogueResBond? rogueResBond = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBond(bondId);
			RoleBondInfo roleBondInfo = null;
			if (this.RoleFetterMap.ContainsKey(bondId))
			{
				roleBondInfo = this.RoleFetterMap[bondId];
			}
			int num = 0;
			int i;
			int num3;
			if (designatedLv != null && designatedStar != null)
			{
				num = designatedLv.Value;
				i = designatedStar.Value + upStar;
				int num2 = num + 1;
				if (num2 > this.MaxRoleStar)
				{
					num2 = this.MaxRoleStar;
				}
				num3 = rogueResBond.Value.GetStarMap(num2).Value;
			}
			else if (roleBondInfo != null)
			{
				num = roleBondInfo.Level;
				i = roleBondInfo.CurStar + upStar;
				num3 = roleBondInfo.TargetStar;
			}
			else
			{
				i = upStar;
				num3 = rogueResBond.Value.GetStarMap(1).Value;
			}
			while (i >= num3)
			{
				num = Math.Min(num + 1, this.MaxRoleStar);
				int num4 = num + 1;
				if (num4 > this.MaxRoleStar)
				{
					num4 = this.MaxRoleStar;
				}
				num3 = rogueResBond.Value.GetStarMap(num4).Value;
				if (num == this.MaxRoleStar)
				{
					break;
				}
			}
			return new RoleBondInfo
			{
				ConfigId = bondId,
				CurStar = i,
				TargetStar = num3,
				Level = num
			};
		}

		// Token: 0x06035F62 RID: 221026 RVA: 0x00D92954 File Offset: 0x00D90B54
		public int GetBondRoleCount(int bondId)
		{
			IReadOnlyList<RogueResBondRole> allRogueResBondRole = ConfigBase<RogueBattleConfig>.Instance.GetAllRogueResBondRole();
			if (allRogueResBondRole == null)
			{
				return 0;
			}
			int num = 0;
			foreach (RogueResBondRole rogueResBondRole in allRogueResBondRole)
			{
				bool flag = false;
				for (int i = 0; i < rogueResBondRole.BondIdsLength; i++)
				{
					if (rogueResBondRole.BondIds(i) == bondId)
					{
						flag = true;
						break;
					}
				}
				if (flag && (this.IsRoleGot(rogueResBondRole.RoleId) || this.IsRoleGot(rogueResBondRole.TrialRoleId)))
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06035F63 RID: 221027 RVA: 0x00D929F8 File Offset: 0x00D90BF8
		public int GetLinkIdByRoleList(List<RoleDataBase> roleDataList)
		{
			List<int> list = new List<int>();
			foreach (RoleDataBase roleDataBase in roleDataList)
			{
				list.Add(roleDataBase.GetRoleId());
			}
			return this.GetLinkIdByRoleIdList(list);
		}

		// Token: 0x06035F64 RID: 221028 RVA: 0x00D92A58 File Offset: 0x00D90C58
		public int GetLinkIdByRoleIdList(List<int> roleIdList)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			HashSet<int> hashSet = new HashSet<int>();
			foreach (int id in roleIdList)
			{
				RogueResBondRole? rogueResBondRole = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBondRole(id);
				if (rogueResBondRole != null)
				{
					for (int i = 0; i < rogueResBondRole.Value.BondIdsLength; i++)
					{
						int num = rogueResBondRole.Value.BondIds(i);
						hashSet.Add(num);
						int num2 = 0;
						if (dictionary.ContainsKey(num))
						{
							num2 = dictionary[num];
						}
						dictionary[num] = num2 + 1;
					}
				}
			}
			foreach (int num3 in hashSet)
			{
				RoleBondInfo roleBondDataById = this.GetRoleBondDataById(num3);
				RogueResBond value = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBond(num3).Value;
				int num4 = value.LinkRule(0);
				if (roleBondDataById.Level >= num4)
				{
					int num5 = 0;
					if (dictionary.ContainsKey(num3))
					{
						num5 = dictionary[num3];
					}
					if (num5 == value.ActLinkNum)
					{
						return num3;
					}
				}
			}
			return 0;
		}

		// Token: 0x06035F65 RID: 221029 RVA: 0x00D92BBC File Offset: 0x00D90DBC
		public bool IsBondLinkCanActivate(int bondId)
		{
			RoleBondInfo roleBondDataById = this.GetRoleBondDataById(bondId);
			RogueResBond? rogueResBond = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBond(bondId);
			if (rogueResBond == null)
			{
				return false;
			}
			if (this.GetBondRoleCount(bondId) < rogueResBond.Value.ActLinkNum)
			{
				return false;
			}
			int num = rogueResBond.Value.LinkRule(0);
			return roleBondDataById.Level >= num;
		}

		// Token: 0x06035F66 RID: 221030 RVA: 0x00D92C20 File Offset: 0x00D90E20
		public bool IsAnyBondLinkCanActivate()
		{
			foreach (RoleBondInfo roleBondInfo in this.GetAllOwnedRoleBondData())
			{
				if (this.IsBondLinkCanActivate(roleBondInfo.ConfigId))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06035F67 RID: 221031 RVA: 0x00D92C84 File Offset: 0x00D90E84
		public List<RoleBondInfo> GetAllOwnedRoleBondData()
		{
			List<RoleBondInfo> list = new List<RoleBondInfo>();
			foreach (RoleBondInfo item in this.RoleFetterMap.Values)
			{
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06035F68 RID: 221032 RVA: 0x00D92CE4 File Offset: 0x00D90EE4
		public void UpdateOptionData(RogueResInstOptionsUpdateNotify data)
		{
			foreach (KeyValuePair<int, RogueResOption> keyValuePair in data.Adds)
			{
				int key = keyValuePair.Key;
				RogueResOption value = keyValuePair.Value;
				this.SetOptionData(key, value);
			}
			foreach (int key2 in data.Removes)
			{
				this.OptionMap.Remove(key2);
			}
			foreach (KeyValuePair<int, RogueResOption> keyValuePair2 in data.Updates)
			{
				int key3 = keyValuePair2.Key;
				RogueResOption value2 = keyValuePair2.Value;
				this.SetOptionData(key3, value2);
			}
		}

		// Token: 0x06035F69 RID: 221033 RVA: 0x00D92DE0 File Offset: 0x00D90FE0
		public void UpdateGainData(RogueResGainDataUpdateNotify data)
		{
			foreach (RogueResGainData rogueResGainData in data.Adds)
			{
				int key = rogueResGainData.IncId;
				if (rogueResGainData.RogueResDataType == RogueResDataType.Role)
				{
					key = rogueResGainData.RogueResRole.RoleIdOrTrialRoleId;
					this.SetRogueResNewRoleFlag(true);
				}
				this.GainDataMap[rogueResGainData.IncId] = rogueResGainData;
				if (!this.TotalGainDataMap.ContainsKey(rogueResGainData.RogueResDataType))
				{
					this.TotalGainDataMap[rogueResGainData.RogueResDataType] = new Dictionary<int, RogueResGainData>();
				}
				this.TotalGainDataMap[rogueResGainData.RogueResDataType][key] = rogueResGainData;
			}
			foreach (RogueResGainData rogueResGainData2 in data.Updates)
			{
				int key2 = rogueResGainData2.IncId;
				if (rogueResGainData2.RogueResDataType == RogueResDataType.Role)
				{
					key2 = rogueResGainData2.RogueResRole.RoleIdOrTrialRoleId;
				}
				this.GainDataMap[rogueResGainData2.IncId] = rogueResGainData2;
				if (!this.TotalGainDataMap.ContainsKey(rogueResGainData2.RogueResDataType))
				{
					this.TotalGainDataMap[rogueResGainData2.RogueResDataType] = new Dictionary<int, RogueResGainData>();
				}
				this.TotalGainDataMap[rogueResGainData2.RogueResDataType][key2] = rogueResGainData2;
			}
			foreach (int key3 in data.Removes)
			{
				RogueResGainData rogueResGainData3;
				if (this.GainDataMap.TryGetValue(key3, out rogueResGainData3))
				{
					this.GainDataMap.Remove(key3);
					Dictionary<int, RogueResGainData> dictionary;
					if (this.TotalGainDataMap.TryGetValue(rogueResGainData3.RogueResDataType, out dictionary))
					{
						if (rogueResGainData3.RogueResDataType == RogueResDataType.Role)
						{
							int roleIdOrTrialRoleId = rogueResGainData3.RogueResRole.RoleIdOrTrialRoleId;
							dictionary.Remove(roleIdOrTrialRoleId);
						}
						else
						{
							dictionary.Remove(key3);
						}
					}
				}
			}
		}

		// Token: 0x06035F6A RID: 221034 RVA: 0x00D92FE8 File Offset: 0x00D911E8
		public void UpdateElementData(RogueResElementUpdateNotify notify)
		{
			foreach (ElementUnit elementUnit in notify.ElementUnits)
			{
				this.ElementMap[elementUnit.ElementId] = elementUnit;
			}
		}

		// Token: 0x06035F6B RID: 221035 RVA: 0x00D93040 File Offset: 0x00D91240
		public void UpdateFetterData(RogueResRoleBondUpdateNotify notify)
		{
			foreach (RoleBondInfo roleBondInfo in notify.RoleBondInfos)
			{
				this.RoleFetterMap[roleBondInfo.ConfigId] = roleBondInfo;
			}
		}

		// Token: 0x06035F6C RID: 221036 RVA: 0x00D93098 File Offset: 0x00D91298
		public void InitOptionData(RogueResInstOptionsNotify data)
		{
			foreach (KeyValuePair<int, RogueResOption> keyValuePair in data.RogueResOptionDict)
			{
				int key = keyValuePair.Key;
				RogueResOption value = keyValuePair.Value;
				this.SetOptionData(key, value);
			}
		}

		// Token: 0x06035F6D RID: 221037 RVA: 0x00D930F8 File Offset: 0x00D912F8
		public void InitGainData(RogueResGainDataTotalNotify data)
		{
			this.RoleFetterMap.Clear();
			this.TotalGainDataMap.Clear();
			this.GainDataMap.Clear();
			this.RoleFetterMap.Clear();
			this.ElementMap.Clear();
			foreach (RogueResGainData rogueResGainData in data.RogueResGainDatas)
			{
				if (!this.TotalGainDataMap.ContainsKey(rogueResGainData.RogueResDataType))
				{
					this.TotalGainDataMap[rogueResGainData.RogueResDataType] = new Dictionary<int, RogueResGainData>();
				}
				if (rogueResGainData.RogueResDataType == RogueResDataType.Role)
				{
					this.TotalGainDataMap[rogueResGainData.RogueResDataType][rogueResGainData.RogueResRole.RoleIdOrTrialRoleId] = rogueResGainData;
				}
				else
				{
					this.TotalGainDataMap[rogueResGainData.RogueResDataType][rogueResGainData.IncId] = rogueResGainData;
				}
				this.GainDataMap[rogueResGainData.IncId] = rogueResGainData;
			}
			this.ElementMap[1] = new ElementUnit
			{
				ElementId = 1,
				Count = 0
			};
			this.ElementMap[2] = new ElementUnit
			{
				ElementId = 2,
				Count = 0
			};
			this.ElementMap[3] = new ElementUnit
			{
				ElementId = 3,
				Count = 0
			};
			this.ElementMap[4] = new ElementUnit
			{
				ElementId = 4,
				Count = 0
			};
			foreach (ElementUnit elementUnit in data.ElementUnits)
			{
				this.ElementMap[elementUnit.ElementId] = elementUnit;
			}
			foreach (RoleBondInfo roleBondInfo in data.RoleBondInfos)
			{
				this.RoleFetterMap[roleBondInfo.ConfigId] = roleBondInfo;
			}
		}

		// Token: 0x06035F6E RID: 221038 RVA: 0x00D93314 File Offset: 0x00D91514
		public void InitFormationData(List<RogueResFormation> data)
		{
			this.FormationData = data;
		}

		// Token: 0x06035F6F RID: 221039 RVA: 0x00D93320 File Offset: 0x00D91520
		protected override bool OnClear()
		{
			this.OptionMap.Clear();
			this.TotalGainDataMap.Clear();
			this.GainDataMap.Clear();
			this.ElementMap.Clear();
			this.SelectGainData = null;
			this.CurrentBindId = 0;
			this.CurrentRoomTypeId = string.Empty;
			this.CurrentRoomId = 0;
			this.CurrentRoomMusicState = "none";
			return true;
		}

		// Token: 0x06035F70 RID: 221040 RVA: 0x00D93388 File Offset: 0x00D91588
		public List<IRogueBattleElementInfo> GetTotalElementInfo([Nullable(new byte[]
		{
			2,
			1
		})] List<ElementUnit> addElement = null)
		{
			Dictionary<int, IRogueBattleElementInfo> dictionary = new Dictionary<int, IRogueBattleElementInfo>();
			if (addElement != null)
			{
				foreach (ElementUnit elementUnit in addElement)
				{
					RogueBattleElementInfo value = new RogueBattleElementInfo
					{
						ElementId = elementUnit.ElementId,
						Count = elementUnit.Count,
						IsPreview = true
					};
					dictionary[elementUnit.ElementId] = value;
				}
			}
			foreach (ElementUnit elementUnit2 in this.ElementMap.Values)
			{
				if (!dictionary.ContainsKey(elementUnit2.ElementId))
				{
					RogueBattleElementInfo value2 = new RogueBattleElementInfo
					{
						ElementId = elementUnit2.ElementId,
						Count = elementUnit2.Count,
						IsPreview = false
					};
					dictionary[elementUnit2.ElementId] = value2;
				}
				else
				{
					dictionary[elementUnit2.ElementId].Count += elementUnit2.Count;
				}
			}
			List<IRogueBattleElementInfo> list = new List<IRogueBattleElementInfo>();
			foreach (IRogueBattleElementInfo item in dictionary.Values)
			{
				list.Add(item);
			}
			for (int i = 0; i < list.Count - 1; i++)
			{
				for (int j = i + 1; j < list.Count; j++)
				{
					if (list[i].ElementId > list[j].ElementId)
					{
						IRogueBattleElementInfo value3 = list[i];
						list[i] = list[j];
						list[j] = value3;
					}
				}
			}
			return list;
		}

		// Token: 0x06035F71 RID: 221041 RVA: 0x00D93574 File Offset: 0x00D91774
		public int GetTotalElementCount()
		{
			int num = 0;
			foreach (ElementUnit elementUnit in this.ElementMap.Values)
			{
				num += elementUnit.Count;
			}
			return num;
		}

		// Token: 0x06035F72 RID: 221042 RVA: 0x00D935D4 File Offset: 0x00D917D4
		[NullableContext(2)]
		public IRogueBattleElementInfo GetElementInfoById(int id)
		{
			ElementUnit elementUnit;
			if (this.ElementMap.TryGetValue(id, out elementUnit))
			{
				return new RogueBattleElementInfo
				{
					ElementId = elementUnit.ElementId,
					Count = elementUnit.Count,
					IsPreview = false
				};
			}
			return null;
		}

		// Token: 0x06035F73 RID: 221043 RVA: 0x00D93618 File Offset: 0x00D91818
		public bool CheckPhantomAffixCanUnlock(PhantomAffixInfo data)
		{
			bool result = true;
			foreach (ElementUnit elementUnit in data.ElementUnits)
			{
				ElementUnit elementUnit2;
				if (!this.ElementMap.TryGetValue(elementUnit.ElementId, out elementUnit2) || elementUnit2.Count < elementUnit.Count)
				{
					result = false;
					break;
				}
			}
			return result;
		}

		// Token: 0x06035F74 RID: 221044 RVA: 0x00D93688 File Offset: 0x00D91888
		public int GetCurrentSeasonId()
		{
			int instanceId = ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId;
			if (instanceId == 0)
			{
				return 0;
			}
			RogueResDungeonConfig? config = ConfigRogueResDungeonConfigById.GetConfig(instanceId, true);
			if (config == null)
			{
				return ModelBase<ActivityPermanentRogueModel>.Instance.GetNewSeasonId();
			}
			return config.Value.SeasonId;
		}

		// Token: 0x06035F75 RID: 221045 RVA: 0x00D936D0 File Offset: 0x00D918D0
		public List<IRogueBattleMapRoleGridInfo> GetRoleListByBond(int bondId)
		{
			if (this.BondAllRoleMap.Count == 0)
			{
				IReadOnlyList<RogueResBondRole> allRogueResBondRole = ConfigBase<RogueBattleConfig>.Instance.GetAllRogueResBondRole();
				if (allRogueResBondRole != null)
				{
					foreach (RogueResBondRole rogueResBondRole in allRogueResBondRole)
					{
						for (int i = 0; i < rogueResBondRole.BondIdsLength; i++)
						{
							int key = rogueResBondRole.BondIds(i);
							if (!this.BondAllRoleMap.ContainsKey(key))
							{
								this.BondAllRoleMap[key] = new List<int>();
							}
							this.BondAllRoleMap[key].Add(rogueResBondRole.RoleId);
						}
					}
				}
			}
			List<int> list;
			if (!this.BondAllRoleMap.TryGetValue(bondId, out list))
			{
				return new List<IRogueBattleMapRoleGridInfo>();
			}
			List<IRogueBattleMapRoleGridInfo> list2 = new List<IRogueBattleMapRoleGridInfo>();
			List<IRogueBattleMapRoleGridInfo> list3 = new List<IRogueBattleMapRoleGridInfo>();
			int currentSeasonId = this.GetCurrentSeasonId();
			List<int> trailRole = ModelBase<ActivityPermanentRogueModel>.Instance.GetTrailRole(currentSeasonId, ERogueResTrialType.Static);
			List<int> trailRole2 = ModelBase<ActivityPermanentRogueModel>.Instance.GetTrailRole(currentSeasonId, ERogueResTrialType.Dynamic);
			foreach (int num in list)
			{
				if (this.IsRoleGot(num))
				{
					RogueBattleMapRoleGridInfo item = new RogueBattleMapRoleGridInfo
					{
						IsGain = true,
						ConfigId = num,
						NeedLevel = false
					};
					list2.Add(item);
				}
				else if (!ModelBase<RoleModel>.Instance.IsMainRole(num))
				{
					RogueResBondRole value = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBondRole(num).Value;
					if (this.IsRoleGot(value.TrialRoleId))
					{
						RogueBattleMapRoleGridInfo item2 = new RogueBattleMapRoleGridInfo
						{
							IsGain = true,
							ConfigId = value.TrialRoleId,
							NeedLevel = false
						};
						list2.Add(item2);
					}
					else
					{
						bool flag = trailRole.Contains(value.TrialRoleId);
						bool flag2 = trailRole2.Contains(value.TrialRoleId);
						int configId;
						if (flag || flag2)
						{
							configId = value.TrialRoleId;
						}
						else
						{
							configId = num;
						}
						RogueBattleMapRoleGridInfo item3 = new RogueBattleMapRoleGridInfo
						{
							IsGain = false,
							ConfigId = configId,
							NeedLevel = false
						};
						list3.Add(item3);
					}
				}
			}
			for (int j = 0; j < list2.Count - 1; j++)
			{
				for (int k = j + 1; k < list2.Count; k++)
				{
					RogueResRole roleInfoById = this.GetRoleInfoById(list2[j].ConfigId);
					bool roleIsRogueTrial = this.GetRoleIsRogueTrial(list2[j].ConfigId);
					RogueResRole roleInfoById2 = this.GetRoleInfoById(list2[k].ConfigId);
					bool roleIsRogueTrial2 = this.GetRoleIsRogueTrial(list2[k].ConfigId);
					bool flag3 = false;
					if (roleInfoById.Level == roleInfoById2.Level)
					{
						if (roleIsRogueTrial != roleIsRogueTrial2)
						{
							flag3 = !roleIsRogueTrial;
						}
						else if (list2[j].ConfigId > list2[k].ConfigId)
						{
							flag3 = true;
						}
					}
					else if (roleInfoById2.Level > roleInfoById.Level)
					{
						flag3 = true;
					}
					if (flag3)
					{
						IRogueBattleMapRoleGridInfo value2 = list2[j];
						list2[j] = list2[k];
						list2[k] = value2;
					}
				}
			}
			for (int l = 0; l < list3.Count - 1; l++)
			{
				for (int m = l + 1; m < list3.Count; m++)
				{
					bool roleIsRogueTrial3 = this.GetRoleIsRogueTrial(list3[l].ConfigId);
					bool roleCantGet = this.GetRoleCantGet(list3[l].ConfigId);
					bool roleIsRogueTrial4 = this.GetRoleIsRogueTrial(list3[m].ConfigId);
					bool roleCantGet2 = this.GetRoleCantGet(list3[m].ConfigId);
					bool flag4 = false;
					if (roleIsRogueTrial3 != roleIsRogueTrial4)
					{
						flag4 = !roleIsRogueTrial3;
					}
					else if (roleCantGet != roleCantGet2)
					{
						flag4 = (roleCantGet && !roleCantGet2);
					}
					else if (list3[l].ConfigId > list3[m].ConfigId)
					{
						flag4 = true;
					}
					if (flag4)
					{
						IRogueBattleMapRoleGridInfo value3 = list3[l];
						list3[l] = list3[m];
						list3[m] = value3;
					}
				}
			}
			List<IRogueBattleMapRoleGridInfo> list4 = new List<IRogueBattleMapRoleGridInfo>();
			list4.AddRange(list2);
			list4.AddRange(list3);
			return list4;
		}

		// Token: 0x06035F76 RID: 221046 RVA: 0x00D93B40 File Offset: 0x00D91D40
		public bool GetRoleCantGet(int roleRogueId)
		{
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleRogueId);
			return !ConfigBase<RoleConfig>.Instance.IsTrialRole(roleRogueId) && ModelBase<RoleModel>.Instance.GetRoleInstanceById(roleConfig.Value.Id) == null;
		}

		// Token: 0x06035F77 RID: 221047 RVA: 0x00D93B84 File Offset: 0x00D91D84
		public bool GetRoleIsRogueTrial(int roleRogueId)
		{
			RoleInfo value = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleRogueId).Value;
			return ConfigBase<RoleConfig>.Instance.IsTrialRole(roleRogueId) && ModelBase<RoleModel>.Instance.GetRoleInstanceById(value.Id) == null;
		}

		// Token: 0x06035F78 RID: 221048 RVA: 0x00D93BC8 File Offset: 0x00D91DC8
		public List<IRogueBattleMapGridEffectInfo> GetEffectList()
		{
			Dictionary<string, IRogueBattleMapGridEffectInfo> dictionary = new Dictionary<string, IRogueBattleMapGridEffectInfo>();
			this.GetTeamStaticEffect(dictionary);
			this.GetTeamEffectList(dictionary);
			this.GetBondExploreEffect(dictionary);
			List<IRogueBattleMapGridEffectInfo> list = new List<IRogueBattleMapGridEffectInfo>();
			foreach (KeyValuePair<string, IRogueBattleMapGridEffectInfo> keyValuePair in dictionary)
			{
				list.Add(keyValuePair.Value);
			}
			return list;
		}

		// Token: 0x06035F79 RID: 221049 RVA: 0x00D93C40 File Offset: 0x00D91E40
		private void GetTeamEffectList(Dictionary<string, IRogueBattleMapGridEffectInfo> infoMap)
		{
			int teamLv = ModelBase<MapRogueModel>.Instance.GameInfo.TeamLv;
			IReadOnlyList<RogueResTeamLvRule> allRogueResTeamLvRule = ConfigBase<RogueBattleConfig>.Instance.GetAllRogueResTeamLvRule();
			if (allRogueResTeamLvRule == null)
			{
				return;
			}
			foreach (RogueResTeamLvRule rogueResTeamLvRule in allRogueResTeamLvRule)
			{
				if (rogueResTeamLvRule.LevelRangeLength == 2 && rogueResTeamLvRule.RangeEffectsLength > 0 && teamLv >= rogueResTeamLvRule.LevelRange(0))
				{
					for (int i = 0; i < rogueResTeamLvRule.RangeEffectsLength; i++)
					{
						int id = rogueResTeamLvRule.RangeEffects(i);
						RogueResEffect? rogueResEffectById = ConfigBase<RogueBattleConfig>.Instance.GetRogueResEffectById(id);
						if (rogueResEffectById != null)
						{
							RogueResEffectTag? rogueResEffectTagById = ConfigBase<RogueBattleConfig>.Instance.GetRogueResEffectTagById(rogueResEffectById.Value.Tag);
							if (rogueResEffectTagById != null)
							{
								int num = (teamLv >= rogueResTeamLvRule.LevelRange(1)) ? (rogueResTeamLvRule.LevelRange(1) - rogueResTeamLvRule.LevelRange(0) + 1) : (teamLv - rogueResTeamLvRule.LevelRange(0) + 1);
								if (!infoMap.ContainsKey(rogueResEffectTagById.Value.Text))
								{
									RogueBattleMapGridEffectInfo value = new RogueBattleMapGridEffectInfo
									{
										TagKey = rogueResEffectTagById.Value.Text,
										Count = num * rogueResEffectById.Value.DescIntParam,
										IsRatio = rogueResEffectTagById.Value.IsRatio,
										Icon = rogueResEffectTagById.Value.Icon
									};
									infoMap[rogueResEffectTagById.Value.Text] = value;
								}
								else
								{
									infoMap[rogueResEffectTagById.Value.Text].Count += num * rogueResEffectById.Value.DescIntParam;
								}
							}
						}
					}
				}
				if (rogueResTeamLvRule.TargetLevel != 0 && teamLv >= rogueResTeamLvRule.TargetLevel && rogueResTeamLvRule.TargetEffectsLength > 0)
				{
					for (int j = 0; j < rogueResTeamLvRule.TargetEffectsLength; j++)
					{
						int id2 = rogueResTeamLvRule.TargetEffects(j);
						RogueResEffect? rogueResEffectById2 = ConfigBase<RogueBattleConfig>.Instance.GetRogueResEffectById(id2);
						if (rogueResEffectById2 != null)
						{
							RogueResEffectTag? rogueResEffectTagById2 = ConfigBase<RogueBattleConfig>.Instance.GetRogueResEffectTagById(rogueResEffectById2.Value.Tag);
							if (rogueResEffectTagById2 != null)
							{
								if (!infoMap.ContainsKey(rogueResEffectTagById2.Value.Text))
								{
									RogueBattleMapGridEffectInfo value2 = new RogueBattleMapGridEffectInfo
									{
										TagKey = rogueResEffectTagById2.Value.Text,
										Count = rogueResEffectById2.Value.DescIntParam,
										IsRatio = rogueResEffectTagById2.Value.IsRatio,
										Icon = rogueResEffectTagById2.Value.Icon
									};
									infoMap[rogueResEffectTagById2.Value.Text] = value2;
								}
								else
								{
									infoMap[rogueResEffectTagById2.Value.Text].Count += rogueResEffectById2.Value.DescIntParam;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06035F7A RID: 221050 RVA: 0x00D93F8C File Offset: 0x00D9218C
		private void GetTeamStaticEffect(Dictionary<string, IRogueBattleMapGridEffectInfo> infoMap)
		{
			int teamLv = ModelBase<MapRogueModel>.Instance.GameInfo.TeamLv;
			IReadOnlyList<RogueResTeamLvRule> allRogueResTeamLvRule = ConfigBase<RogueBattleConfig>.Instance.GetAllRogueResTeamLvRule();
			if (allRogueResTeamLvRule == null)
			{
				return;
			}
			RogueResEffectTag value = ConfigBase<RogueBattleConfig>.Instance.GetRogueResEffectTagById(34).Value;
			RogueBattleMapGridEffectInfo rogueBattleMapGridEffectInfo = new RogueBattleMapGridEffectInfo
			{
				TagKey = value.Text,
				Count = 0,
				IsRatio = false,
				Icon = value.Icon
			};
			RogueResEffectTag value2 = ConfigBase<RogueBattleConfig>.Instance.GetRogueResEffectTagById(32).Value;
			RogueBattleMapGridEffectInfo rogueBattleMapGridEffectInfo2 = new RogueBattleMapGridEffectInfo
			{
				TagKey = value2.Text,
				Count = 0,
				IsRatio = false,
				Icon = value2.Icon
			};
			foreach (RogueResTeamLvRule rogueResTeamLvRule in allRogueResTeamLvRule)
			{
				if (rogueResTeamLvRule.LevelRangeLength == 2 && rogueResTeamLvRule.RoleLevel > 0 && teamLv >= rogueResTeamLvRule.LevelRange(0))
				{
					int num = (teamLv >= rogueResTeamLvRule.LevelRange(1)) ? (rogueResTeamLvRule.LevelRange(1) - rogueResTeamLvRule.LevelRange(0) + 1) : (teamLv - rogueResTeamLvRule.LevelRange(0) + 1);
					rogueBattleMapGridEffectInfo.Count += num * rogueResTeamLvRule.RoleLevel;
				}
			}
			rogueBattleMapGridEffectInfo2.Count = rogueBattleMapGridEffectInfo.Count;
			List<RogueResSkillLvRule> list = new List<RogueResSkillLvRule>(ConfigBase<RogueBattleConfig>.Instance.GetAllRogueResSkillLvRule() ?? new List<RogueResSkillLvRule>());
			list.Sort(delegate(RogueResSkillLvRule a, RogueResSkillLvRule b)
			{
				if (a.Level == b.Level)
				{
					return 0;
				}
				if (a.Level <= b.Level)
				{
					return -1;
				}
				return 1;
			});
			RogueResEffectTag value3 = ConfigBase<RogueBattleConfig>.Instance.GetRogueResEffectTagById(33).Value;
			RogueBattleMapGridEffectInfo rogueBattleMapGridEffectInfo3 = new RogueBattleMapGridEffectInfo
			{
				TagKey = value3.Text,
				Count = 0,
				IsRatio = false,
				Icon = value3.Icon
			};
			for (int i = list.Count - 1; i >= 0; i--)
			{
				if (teamLv >= list[i].Level)
				{
					int count = 0;
					for (int j = 0; j < list[i].SkillLevelLength; j++)
					{
						if (list[i].SkillLevel(j).Value.Key == teamLv)
						{
							count = list[i].SkillLevel(j).Value.Value;
							break;
						}
					}
					rogueBattleMapGridEffectInfo3.Count = count;
					break;
				}
			}
			infoMap[value.Text] = rogueBattleMapGridEffectInfo;
			infoMap[value2.Text] = rogueBattleMapGridEffectInfo2;
			infoMap[value3.Text] = rogueBattleMapGridEffectInfo3;
		}

		// Token: 0x06035F7B RID: 221051 RVA: 0x00D94258 File Offset: 0x00D92458
		private void GetBondExploreEffect(Dictionary<string, IRogueBattleMapGridEffectInfo> infoMap)
		{
			foreach (RoleBondInfo roleBondInfo in this.GetAllOwnedRoleBondData())
			{
				if (roleBondInfo.Level != 0)
				{
					RogueResBond? rogueResBond = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBond(roleBondInfo.ConfigId);
					if (rogueResBond != null && rogueResBond.Value.ExploreEffectLength != 0)
					{
						for (int i = 0; i < rogueResBond.Value.ExploreEffectLength; i++)
						{
							DicIntInt? dicIntInt = rogueResBond.Value.ExploreEffect(i);
							int key = dicIntInt.Value.Key;
							int value = dicIntInt.Value.Value;
							if (roleBondInfo.Level >= key)
							{
								RogueResEffect? rogueResEffectById = ConfigBase<RogueBattleConfig>.Instance.GetRogueResEffectById(value);
								if (rogueResEffectById != null)
								{
									RogueResEffectTag? rogueResEffectTagById = ConfigBase<RogueBattleConfig>.Instance.GetRogueResEffectTagById(rogueResEffectById.Value.Tag);
									if (rogueResEffectTagById != null)
									{
										if (!infoMap.ContainsKey(rogueResEffectTagById.Value.Text))
										{
											RogueBattleMapGridEffectInfo value2 = new RogueBattleMapGridEffectInfo
											{
												TagKey = rogueResEffectTagById.Value.Text,
												Count = rogueResEffectById.Value.DescIntParam,
												IsRatio = rogueResEffectTagById.Value.IsRatio,
												Icon = rogueResEffectTagById.Value.Icon
											};
											infoMap[rogueResEffectTagById.Value.Text] = value2;
										}
										else
										{
											infoMap[rogueResEffectTagById.Value.Text].Count += rogueResEffectById.Value.DescIntParam;
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06035F7C RID: 221052 RVA: 0x00D94460 File Offset: 0x00D92660
		public bool GetRogueResNewRoleFlag()
		{
			return LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.RogueResNewRoleFlag, false);
		}

		// Token: 0x06035F7D RID: 221053 RVA: 0x00D9446D File Offset: 0x00D9266D
		public void SetRogueResNewRoleFlag(bool bNew)
		{
			if (LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.RogueResNewRoleFlag, false) == bNew)
			{
				return;
			}
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.RogueResNewRoleFlag, bNew);
			Singleton<EventSystem>.Instance.Emit(EEventName.RogueResNewRoleFlagChange);
		}

		// Token: 0x06035F7E RID: 221054 RVA: 0x00D9449C File Offset: 0x00D9269C
		public void ClearData()
		{
			this.TotalGainDataMap.Clear();
			this.BondAllRoleMap.Clear();
			this.GainDataMap.Clear();
			this.ElementMap.Clear();
			this.RoleFetterMap.Clear();
			this.FormationData = new List<RogueResFormation>();
		}

		// Token: 0x0401EFEC RID: 126956
		public Dictionary<RogueResDataType, Dictionary<int, RogueResGainData>> TotalGainDataMap = new Dictionary<RogueResDataType, Dictionary<int, RogueResGainData>>();

		// Token: 0x0401EFED RID: 126957
		public Dictionary<int, RogueResGainData> GainDataMap = new Dictionary<int, RogueResGainData>();

		// Token: 0x0401EFEE RID: 126958
		public Dictionary<int, ElementUnit> ElementMap = new Dictionary<int, ElementUnit>();

		// Token: 0x0401EFEF RID: 126959
		public Dictionary<int, RoleBondInfo> RoleFetterMap = new Dictionary<int, RoleBondInfo>();

		// Token: 0x0401EFF0 RID: 126960
		public Dictionary<int, List<int>> BondAllRoleMap = new Dictionary<int, List<int>>();

		// Token: 0x0401EFF1 RID: 126961
		public List<RogueResFormation> FormationData = new List<RogueResFormation>();

		// Token: 0x0401EFF2 RID: 126962
		public EDescModel DescMode;

		// Token: 0x0401EFF3 RID: 126963
		[Nullable(2)]
		public RogueResGainData SelectGainData;

		// Token: 0x0401EFF4 RID: 126964
		public int CurrentBindId;

		// Token: 0x0401EFF5 RID: 126965
		public string CurrentRoomTypeId = string.Empty;

		// Token: 0x0401EFF6 RID: 126966
		public int CurrentRoomId;

		// Token: 0x0401EFF7 RID: 126967
		public int CurrentMapSummaryBond;

		// Token: 0x0401EFF8 RID: 126968
		public bool IsMapSummaryBondJumping;

		// Token: 0x0401EFF9 RID: 126969
		public int MaxRoleStar;

		// Token: 0x0401EFFA RID: 126970
		public List<int> SummaryRoleList = new List<int>();

		// Token: 0x0401EFFB RID: 126971
		private readonly StateRef CurrentRoomMusicStateInternal = new StateRef("game_rogue_room_type", "none");

		// Token: 0x0401EFFC RID: 126972
		private readonly Dictionary<int, RogueResOption> OptionMap = new Dictionary<int, RogueResOption>();
	}
}
