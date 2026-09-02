using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005151 RID: 20817
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeEntranceViewModel
	{
		// Token: 0x0603594F RID: 219471 RVA: 0x00D745DC File Offset: 0x00D727DC
		public UniTask InitAsync(int instanceId)
		{
			RoguelikeEntranceViewModel.<InitAsync>d__1 <InitAsync>d__;
			<InitAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitAsync>d__.<>4__this = this;
			<InitAsync>d__.instanceId = instanceId;
			<InitAsync>d__.<>1__state = -1;
			<InitAsync>d__.<>t__builder.Start<RoguelikeEntranceViewModel.<InitAsync>d__1>(ref <InitAsync>d__);
			return <InitAsync>d__.<>t__builder.Task;
		}

		// Token: 0x17008C77 RID: 35959
		// (get) Token: 0x06035950 RID: 219472 RVA: 0x00D74627 File Offset: 0x00D72827
		// (set) Token: 0x06035951 RID: 219473 RVA: 0x00D74630 File Offset: 0x00D72830
		public int CurrentEntriesGroupIndex
		{
			get
			{
				return this.CurrentEntriesGroupIndexInternal;
			}
			set
			{
				if (!this.EntriesDataGroupList[value].IsUnlock)
				{
					RogueInst value2 = ConfigBase<RoguelikeConfig>.Instance.GetRogueInstConfig(this.InstanceId).Value;
					int id = this.EntriesDataGroupList[value].Id;
					string textId = null;
					for (int i = 0; i < value2.UnlockTipsLength; i++)
					{
						DicIntString? dicIntString = value2.UnlockTips(i);
						if (dicIntString != null && dicIntString.Value.Key == id)
						{
							textId = dicIntString.Value.Value;
							break;
						}
					}
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(textId, Array.Empty<object>());
					return;
				}
				this.CurrentEntriesGroupIndexInternal = value;
				this.UpdateCurrentActiveOverviewId();
				for (int j = 0; j < this.EntriesDataGroupList.Count; j++)
				{
					this.EntriesDataGroupList[j].IsActive = (j <= value);
					this.EntriesDataGroupList[j].IsFocus = (j == this.CurrentEntriesGroupIndexInternal);
				}
				Dictionary<int, int> dictionary = LocalStorage.GetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.RoguelikeInstanceSelectGroupIndex, null);
				if (dictionary == null)
				{
					dictionary = new Dictionary<int, int>();
				}
				dictionary[this.InstanceId] = this.CurrentEntriesGroupIndex;
				LocalStorage.SetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.RoguelikeInstanceSelectGroupIndex, dictionary);
			}
		}

		// Token: 0x17008C78 RID: 35960
		// (get) Token: 0x06035952 RID: 219474 RVA: 0x00D74772 File Offset: 0x00D72972
		public RoguelikeEntriesGroupData CurrentEntriesGroupData
		{
			get
			{
				return this.EntriesDataGroupList[this.CurrentEntriesGroupIndex];
			}
		}

		// Token: 0x17008C79 RID: 35961
		// (get) Token: 0x06035953 RID: 219475 RVA: 0x00D74785 File Offset: 0x00D72985
		public bool IsReduceMultiplierAvailable
		{
			get
			{
				return this.CurrentEntriesGroupIndex > this.EntriesGroupAvailableIndexRange.Item1;
			}
		}

		// Token: 0x17008C7A RID: 35962
		// (get) Token: 0x06035954 RID: 219476 RVA: 0x00D7479A File Offset: 0x00D7299A
		public bool IsAddMultiplierAvailable
		{
			get
			{
				return this.CurrentEntriesGroupIndex < this.EntriesGroupAvailableIndexRange.Item2;
			}
		}

		// Token: 0x06035955 RID: 219477 RVA: 0x00D747AF File Offset: 0x00D729AF
		[NullableContext(2)]
		public void SetCurrentSelectEntryData(RoguelikeEntryData entryData)
		{
			this.CurrentSelectEntryData = entryData;
		}

		// Token: 0x06035956 RID: 219478 RVA: 0x00D747B8 File Offset: 0x00D729B8
		private void InitEntries(RogueHotEntryInfo info)
		{
			RepeatedField<int> visibleHotEntryGroupIds = info.VisibleHotEntryGroupIds;
			RepeatedField<int> unlockHotEntryGroupIds = info.UnlockHotEntryGroupIds;
			RepeatedField<int> selectableHotEntryGroupIds = info.SelectableHotEntryGroupIds;
			int item = (selectableHotEntryGroupIds.Count > 0) ? visibleHotEntryGroupIds.IndexOf(selectableHotEntryGroupIds[0]) : -1;
			int item2;
			if (selectableHotEntryGroupIds.Count <= 0)
			{
				item2 = -1;
			}
			else
			{
				RepeatedField<int> repeatedField = visibleHotEntryGroupIds;
				RepeatedField<int> repeatedField2 = selectableHotEntryGroupIds;
				item2 = repeatedField.IndexOf(repeatedField2[repeatedField2.Count - 1]);
			}
			this.EntriesGroupAvailableIndexRange = new ValueTuple<int, int>(item, item2);
			Dictionary<int, int> player = LocalStorage.GetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.RoguelikeInstanceSelectGroupIndex, null);
			int value;
			int? num = (player != null && player.TryGetValue(this.InstanceId, out value)) ? new int?(value) : null;
			int num2 = this.EntriesGroupAvailableIndexRange.Item1;
			if (num != null && num.Value >= this.EntriesGroupAvailableIndexRange.Item1 && num.Value <= this.EntriesGroupAvailableIndexRange.Item2 && unlockHotEntryGroupIds.Contains(visibleHotEntryGroupIds[num.Value]))
			{
				num2 = num.Value;
			}
			int num3 = -1;
			bool flag = false;
			this.CurrentEntriesGroupIndexInternal = num2;
			for (int i = 0; i < visibleHotEntryGroupIds.Count; i++)
			{
				int num4 = visibleHotEntryGroupIds[i];
				RoguelikeEntriesGroupData roguelikeEntriesGroupData = new RoguelikeEntriesGroupData();
				roguelikeEntriesGroupData.Index = i;
				roguelikeEntriesGroupData.Id = num4;
				roguelikeEntriesGroupData.IsUnlock = unlockHotEntryGroupIds.Contains(num4);
				roguelikeEntriesGroupData.IsActive = (i <= num2);
				roguelikeEntriesGroupData.IsFocus = (i == num2);
				RogueHotEntryGroup? rogueHotEntryGroupConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueHotEntryGroupConfig(num4);
				if (rogueHotEntryGroupConfig != null)
				{
					ValueTuple<IReadOnlyList<int>, ERoguelikeEntryType, List<RoguelikeEntryData>>[] array = new ValueTuple<IReadOnlyList<int>, ERoguelikeEntryType, List<RoguelikeEntryData>>[]
					{
						new ValueTuple<IReadOnlyList<int>, ERoguelikeEntryType, List<RoguelikeEntryData>>(rogueHotEntryGroupConfig.Value.Group1(), ERoguelikeEntryType.Type1, roguelikeEntriesGroupData.GroupDataListRow1),
						new ValueTuple<IReadOnlyList<int>, ERoguelikeEntryType, List<RoguelikeEntryData>>(rogueHotEntryGroupConfig.Value.Group2(), ERoguelikeEntryType.Type2, roguelikeEntriesGroupData.GroupDataListRow2),
						new ValueTuple<IReadOnlyList<int>, ERoguelikeEntryType, List<RoguelikeEntryData>>(rogueHotEntryGroupConfig.Value.Group3(), ERoguelikeEntryType.Type3, roguelikeEntriesGroupData.GroupDataListRow3)
					};
					if (roguelikeEntriesGroupData.IsActive)
					{
						int num5 = 0;
						using (IEnumerator<IReadOnlyList<int>> enumerator = (from x in array
						select x.Item1).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								IReadOnlyList<int> readOnlyList = enumerator.Current;
								if (readOnlyList.Count != 0)
								{
									int num6 = readOnlyList.Count<int>() - 1;
									if (num5 <= num6)
									{
										num5 = num6;
										num3 = readOnlyList[num6];
									}
								}
							}
							goto IL_2CA;
						}
						goto IL_261;
					}
					goto IL_261;
					IL_2CA:
					foreach (ValueTuple<IReadOnlyList<int>, ERoguelikeEntryType, List<RoguelikeEntryData>> valueTuple in array)
					{
						IReadOnlyList<int> item3 = valueTuple.Item1;
						ERoguelikeEntryType item4 = valueTuple.Item2;
						List<RoguelikeEntryData> item5 = valueTuple.Item3;
						foreach (int num7 in item3)
						{
							RogueHotEntry? rogueHotEntryConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueHotEntryConfig(num7);
							if (rogueHotEntryConfig != null)
							{
								RoguelikeEntryData roguelikeEntryData = new RoguelikeEntryData();
								roguelikeEntryData.Id = num7;
								roguelikeEntryData.GroupId = num4;
								roguelikeEntryData.Type = item4;
								roguelikeEntryData.OverviewId = rogueHotEntryConfig.Value.OverviewId;
								roguelikeEntryData.OverviewParam = rogueHotEntryConfig.Value.OverviewShowParam().ToList<int>();
								item5.Add(roguelikeEntryData);
								if (num7 == num3)
								{
									this.CurrentSelectEntryData = roguelikeEntryData;
								}
							}
						}
					}
					this.EntriesDataGroupMap[num4] = roguelikeEntriesGroupData;
					this.EntriesDataGroupList.Add(roguelikeEntriesGroupData);
					goto IL_3D7;
					IL_261:
					if (!flag)
					{
						foreach (IReadOnlyList<int> readOnlyList2 in from x in array
						select x.Item1)
						{
							if (readOnlyList2.Count != 0)
							{
								num3 = readOnlyList2[0];
							}
						}
						flag = true;
						goto IL_2CA;
					}
					goto IL_2CA;
				}
				IL_3D7:;
			}
			this.UpdateCurrentActiveOverviewId();
		}

		// Token: 0x06035957 RID: 219479 RVA: 0x00D74BE0 File Offset: 0x00D72DE0
		public bool GetEntryDataActiveState(RoguelikeEntryData entryData)
		{
			RoguelikeEntriesGroupData roguelikeEntriesGroupData2;
			RoguelikeEntriesGroupData roguelikeEntriesGroupData = this.EntriesDataGroupMap.TryGetValue(entryData.GroupId, out roguelikeEntriesGroupData2) ? roguelikeEntriesGroupData2 : null;
			return roguelikeEntriesGroupData != null && roguelikeEntriesGroupData.IsActive;
		}

		// Token: 0x06035958 RID: 219480 RVA: 0x00D74C14 File Offset: 0x00D72E14
		public bool HasMultiAvailableEntriesGroup()
		{
			int num = 0;
			for (int i = this.EntriesGroupAvailableIndexRange.Item1; i <= this.EntriesGroupAvailableIndexRange.Item2; i++)
			{
				if (this.EntriesDataGroupList[i].IsUnlock)
				{
					if (num > 0)
					{
						return true;
					}
					num++;
				}
			}
			return false;
		}

		// Token: 0x06035959 RID: 219481 RVA: 0x00D74C64 File Offset: 0x00D72E64
		private void UpdateCurrentActiveOverviewId()
		{
			this.CurrentActiveOverviewId.Clear();
			for (int i = 0; i <= this.CurrentEntriesGroupIndex; i++)
			{
				foreach (RoguelikeEntryData roguelikeEntryData in this.EntriesDataGroupList[i].GetAllEntryDataList())
				{
					this.CurrentActiveOverviewId.Add(roguelikeEntryData.OverviewId);
				}
			}
		}

		// Token: 0x0603595A RID: 219482 RVA: 0x00D74CEC File Offset: 0x00D72EEC
		public bool GetOverviewIdActiveState(int overviewId)
		{
			return this.CurrentActiveOverviewId.Contains(overviewId);
		}

		// Token: 0x0603595B RID: 219483 RVA: 0x00D74CFC File Offset: 0x00D72EFC
		public List<int> GetEntriesOverviewIdList()
		{
			HashSet<int> hashSet = new HashSet<int>();
			for (int i = 0; i <= this.EntriesGroupAvailableIndexRange.Item2; i++)
			{
				foreach (RoguelikeEntryData roguelikeEntryData in this.EntriesDataGroupList[i].GetAllEntryDataList())
				{
					hashSet.Add(roguelikeEntryData.OverviewId);
				}
			}
			List<int> list = hashSet.ToList<int>();
			list.Sort(delegate(int a, int b)
			{
				RogueHotEntryOverview value = ConfigBase<RoguelikeConfig>.Instance.GetRogueHotEntryOverviewConfig(a).Value;
				RogueHotEntryOverview value2 = ConfigBase<RoguelikeConfig>.Instance.GetRogueHotEntryOverviewConfig(b).Value;
				return value.SortId - value2.SortId;
			});
			return list;
		}

		// Token: 0x0603595C RID: 219484 RVA: 0x00D74DA8 File Offset: 0x00D72FA8
		public List<int> GetEntriesOverviewIdParam(int overviewId)
		{
			List<int> list = new List<int>();
			for (int i = 0; i <= this.CurrentEntriesGroupIndex; i++)
			{
				foreach (RoguelikeEntryData roguelikeEntryData in this.EntriesDataGroupList[i].GetAllEntryDataList())
				{
					if (overviewId == roguelikeEntryData.OverviewId)
					{
						if (list.Count == 0)
						{
							list = roguelikeEntryData.OverviewParam.ToList<int>();
						}
						else
						{
							int num = 0;
							while (num < list.Count && num < roguelikeEntryData.OverviewParam.Count)
							{
								List<int> list2 = list;
								int index = num;
								list2[index] += roguelikeEntryData.OverviewParam[num];
								num++;
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0603595D RID: 219485 RVA: 0x00D74E88 File Offset: 0x00D73088
		public int GetEntriesOverviewIdCount(int overviewId)
		{
			int num = 0;
			for (int i = 0; i <= this.CurrentEntriesGroupIndex; i++)
			{
				foreach (RoguelikeEntryData roguelikeEntryData in this.EntriesDataGroupList[i].GetAllEntryDataList())
				{
					if (overviewId == roguelikeEntryData.OverviewId)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x0603595E RID: 219486 RVA: 0x00D74F00 File Offset: 0x00D73100
		private void InitFormation(RogueHotEntryInfo info, IReadOnlyList<int> validRoleList)
		{
			this.VisibleRoleList = info.VisibleRoleIds.ToList<int>();
			this.ValidRoleList = (from roleId in validRoleList
			where this.VisibleRoleList.Contains(roleId)
			select roleId).ToList<int>();
			this.RoleShowLevel = info.RoleShowLevel;
			foreach (int num in this.ValidRoleList)
			{
				RogueCharacter? rogueCharacterConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueCharacterConfig(num);
				if (rogueCharacterConfig == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Roguelike;
					ELogAuthor author = ELogAuthor.YYZ;
					string message = "RoguelikeEntranceViewModel初始化失败,角色配置不存在";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RogueRoleId", num);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					this.RoleId2ValidRoleId[rogueCharacterConfig.Value.RoleId] = num;
					this.RoleTrialId2ValidRoleId[rogueCharacterConfig.Value.TrialRoleId] = num;
				}
			}
			this.InitFormationIdList();
			this.ShowNewUnlockRole = this.HasNewUnlockRoleId();
		}

		// Token: 0x0603595F RID: 219487 RVA: 0x00D7501C File Offset: 0x00D7321C
		private void InitFormationIdList()
		{
			this.FormationIdList = new List<int>(new int[3]);
			List<int> player = LocalStorage.GetPlayer<List<int>>(ELocalStoragePlayerKey.RoguelikeFormationIdList, null);
			if (player == null)
			{
				return;
			}
			for (int i = 0; i < player.Count<int>(); i++)
			{
				int num = player[i];
				if (num != 0)
				{
					bool flag = this.RoleId2ValidRoleId.ContainsKey(num);
					bool flag2 = this.RoleTrialId2ValidRoleId.ContainsKey(num);
					if (!flag && !flag2)
					{
						player[i] = 0;
					}
					else if (ModelBase<RoleModel>.Instance.IsMainRole(num))
					{
						int num2 = num;
						int? curSelectMainRoleId = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleId();
						if (!(num2 == curSelectMainRoleId.GetValueOrDefault() & curSelectMainRoleId != null))
						{
							player[i] = 0;
						}
					}
					else if (flag2 && !flag)
					{
						int id = this.RoleTrialId2ValidRoleId[num];
						RogueCharacter? rogueCharacterConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueCharacterConfig(id);
						if (rogueCharacterConfig != null)
						{
							RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(rogueCharacterConfig.Value.RoleId);
							if (roleInstanceById != null)
							{
								player[i] = roleInstanceById.GetRoleId();
							}
						}
					}
				}
			}
			this.FormationIdList = player.ToList<int>();
		}

		// Token: 0x06035960 RID: 219488 RVA: 0x00D7513B File Offset: 0x00D7333B
		public void CacheRoleSelect()
		{
			LocalStorage.SetPlayer<List<int>>(ELocalStoragePlayerKey.RoguelikeFormationIdList, this.FormationIdList);
		}

		// Token: 0x06035961 RID: 219489 RVA: 0x00D75150 File Offset: 0x00D73350
		public List<RoleDataBase> GetFormationRoleDataList()
		{
			HashSet<RoleDataBase> hashSet = new HashSet<RoleDataBase>();
			foreach (int rogueRoleId in this.ValidRoleList)
			{
				RoleDataBase roguelikeRoleData = ModelBase<RoguelikeModel>.Instance.GetRoguelikeRoleData(rogueRoleId);
				if (roguelikeRoleData != null && (!ModelBase<RoleModel>.Instance.IsMainRole(roguelikeRoleData.GetRoleId()) || !roguelikeRoleData.IsTrialRole()))
				{
					hashSet.Add(roguelikeRoleData);
				}
			}
			return hashSet.ToList<RoleDataBase>();
		}

		// Token: 0x06035962 RID: 219490 RVA: 0x00D751DC File Offset: 0x00D733DC
		public List<TeamRoleSkillData> GetSupportCustomSkillShowData(int roleId)
		{
			List<TeamRoleSkillData> list = new List<TeamRoleSkillData>();
			int num2;
			int num3;
			int num = this.RoleId2ValidRoleId.TryGetValue(roleId, out num2) ? num2 : (this.RoleTrialId2ValidRoleId.TryGetValue(roleId, out num3) ? num3 : 0);
			if (num == 0)
			{
				return new List<TeamRoleSkillData>();
			}
			RoguelikeConfig instance = ConfigBase<RoguelikeConfig>.Instance;
			RogueCharacter? rogueCharacter = (instance != null) ? instance.GetRogueCharacterConfig(num) : null;
			if (rogueCharacter == null)
			{
				return new List<TeamRoleSkillData>();
			}
			foreach (int id in rogueCharacter.Value.SupportSkillListIter())
			{
				RogueSkill? rogueSkillConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueSkillConfig(id);
				if (rogueSkillConfig != null)
				{
					list.Add(new TeamRoleSkillData
					{
						SkillName = rogueSkillConfig.Value.SkillName,
						SkillIcon = rogueSkillConfig.Value.Icon,
						SkillTypeText = ConfigMultiTextLang.GetLocalTextNew(rogueSkillConfig.Value.SkillTypeText, null),
						SkillDesc = rogueSkillConfig.Value.SkillDesc,
						SkillDescNum = rogueSkillConfig.Value.SkillDescParam(),
						SkillResume = rogueSkillConfig.Value.SkillResume,
						SkillResumeNum = rogueSkillConfig.Value.SkillResumeParam()
					});
				}
			}
			return list;
		}

		// Token: 0x06035963 RID: 219491 RVA: 0x00D7536C File Offset: 0x00D7356C
		public bool HasNewUnlockRoleId()
		{
			ServerStorageSet serverStorageSet = (ServerStorageSet)ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.RoguelikeNewCharacterUnlock);
			foreach (int num in this.ValidRoleList)
			{
				RogueCharacter? rogueCharacterConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueCharacterConfig(num);
				if (rogueCharacterConfig != null && rogueCharacterConfig.Value.UnlockInst != 0 && !serverStorageSet.Has(num))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06035964 RID: 219492 RVA: 0x00D75404 File Offset: 0x00D73604
		public void CacheNewUnlockRoleId()
		{
			ServerStorageSet serverStorageSet = (ServerStorageSet)ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.RoguelikeNewCharacterUnlock);
			foreach (int num in this.ValidRoleList)
			{
				RogueCharacter? rogueCharacterConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueCharacterConfig(num);
				if (rogueCharacterConfig != null && rogueCharacterConfig.Value.UnlockInst != 0 && !serverStorageSet.Has(num))
				{
					serverStorageSet.Add(num);
				}
			}
			this.ShowNewUnlockRole = false;
		}

		// Token: 0x06035965 RID: 219493 RVA: 0x00D754A0 File Offset: 0x00D736A0
		[NullableContext(0)]
		public ValueTuple<int, int>? GetNewUnlockEntriesGroupId()
		{
			RogueInst? rogueInstConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueInstConfig(this.InstanceId);
			if (rogueInstConfig.Value.FirstReadEntrys() == null || rogueInstConfig.Value.FirstReadEntrysLength == 0)
			{
				return null;
			}
			ServerStorageMap serverStorageMap = (ServerStorageMap)ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.RoguelikeNewEntriesGroupUnlock);
			int num = serverStorageMap.Has(this.InstanceId) ? serverStorageMap.Get(this.InstanceId).GetValueOrDefault() : 0;
			if (num == 0)
			{
				int[] array = rogueInstConfig.Value.FirstReadEntrys();
				serverStorageMap.Set(this.InstanceId, array[1]);
				return new ValueTuple<int, int>?(new ValueTuple<int, int>(array[0], array[1]));
			}
			int num2 = -1;
			foreach (RoguelikeEntriesGroupData roguelikeEntriesGroupData in this.EntriesDataGroupList)
			{
				if (roguelikeEntriesGroupData.IsUnlock)
				{
					num2 = roguelikeEntriesGroupData.Id;
				}
			}
			if (num2 == -1)
			{
				return null;
			}
			if (num == num2)
			{
				return null;
			}
			serverStorageMap.Set(this.InstanceId, num2);
			return new ValueTuple<int, int>?(new ValueTuple<int, int>(num, num2));
		}

		// Token: 0x0401EC72 RID: 126066
		public int InstanceId;

		// Token: 0x0401EC73 RID: 126067
		public Dictionary<int, RoguelikeEntriesGroupData> EntriesDataGroupMap = new Dictionary<int, RoguelikeEntriesGroupData>();

		// Token: 0x0401EC74 RID: 126068
		public List<RoguelikeEntriesGroupData> EntriesDataGroupList = new List<RoguelikeEntriesGroupData>();

		// Token: 0x0401EC75 RID: 126069
		[Nullable(2)]
		public RoguelikeEntryData CurrentSelectEntryData;

		// Token: 0x0401EC76 RID: 126070
		[Nullable(0)]
		private ValueTuple<int, int> EntriesGroupAvailableIndexRange = new ValueTuple<int, int>(0, 0);

		// Token: 0x0401EC77 RID: 126071
		private int CurrentEntriesGroupIndexInternal = -1;

		// Token: 0x0401EC78 RID: 126072
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<bool, RoguelikeEntryData> OnClickEntry;

		// Token: 0x0401EC79 RID: 126073
		private HashSet<int> CurrentActiveOverviewId = new HashSet<int>();

		// Token: 0x0401EC7A RID: 126074
		public List<int> FormationIdList = new List<int>();

		// Token: 0x0401EC7B RID: 126075
		public List<int> VisibleRoleList = new List<int>();

		// Token: 0x0401EC7C RID: 126076
		public List<int> ValidRoleList = new List<int>();

		// Token: 0x0401EC7D RID: 126077
		public Dictionary<int, int> RoleId2ValidRoleId = new Dictionary<int, int>();

		// Token: 0x0401EC7E RID: 126078
		public Dictionary<int, int> RoleTrialId2ValidRoleId = new Dictionary<int, int>();

		// Token: 0x0401EC7F RID: 126079
		public int RoleShowLevel;

		// Token: 0x0401EC80 RID: 126080
		public bool ShowNewUnlockRole;
	}
}
