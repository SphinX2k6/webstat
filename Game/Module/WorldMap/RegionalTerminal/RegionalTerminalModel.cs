using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.WorldMap.RegionalTerminal.Data;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.WorldMap.RegionalTerminal
{
	// Token: 0x02004BEE RID: 19438
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RegionalTerminalModel : ModelBase<RegionalTerminalModel>
	{
		// Token: 0x17008718 RID: 34584
		// (get) Token: 0x06032B69 RID: 207721 RVA: 0x00CB3DEF File Offset: 0x00CB1FEF
		// (set) Token: 0x06032B6A RID: 207722 RVA: 0x00CB3DF7 File Offset: 0x00CB1FF7
		public int CurrentAreaMapGroupId
		{
			get
			{
				return this.CurrentAreaMapGroupIdInternal;
			}
			set
			{
				int currentAreaMapGroupIdInternal = this.CurrentAreaMapGroupIdInternal;
				this.CurrentAreaMapGroupIdInternal = value;
				if (currentAreaMapGroupIdInternal != value)
				{
					Singleton<EventSystem>.Instance.Emit(EEventName.AreaMapGroupIdChanged);
				}
			}
		}

		// Token: 0x17008719 RID: 34585
		// (get) Token: 0x06032B6B RID: 207723 RVA: 0x00CB3E19 File Offset: 0x00CB2019
		public int CurrentUnlockAreaMapGroupId
		{
			get
			{
				if (this.UnlockAreaMapGroupId.Contains(this.CurrentAreaMapGroupIdInternal))
				{
					return this.CurrentAreaMapGroupIdInternal;
				}
				return 0;
			}
		}

		// Token: 0x06032B6C RID: 207724 RVA: 0x00CB3E38 File Offset: 0x00CB2038
		protected override bool OnInit()
		{
			foreach (AreaTerminal config in ConfigBase<RegionalTerminalConfig>.Instance.GetAllAreaTerminal())
			{
				RegionalTerminalGameplayData item = this.CreateGameplayData(config);
				RegionalTerminalGroupData regionalTerminalGroupData;
				if (!this.GroupDataMap.TryGetValue(config.GroupId, out regionalTerminalGroupData))
				{
					AreaTerminalGroup? areaTerminalGroup = ConfigBase<RegionalTerminalConfig>.Instance.GetAreaTerminalGroup(config.GroupId);
					if (areaTerminalGroup == null)
					{
						continue;
					}
					regionalTerminalGroupData = new RegionalTerminalGroupData();
					regionalTerminalGroupData.GroupId = config.GroupId;
					regionalTerminalGroupData.SortId = areaTerminalGroup.Value.SortId;
					this.GroupDataMap[config.GroupId] = regionalTerminalGroupData;
				}
				regionalTerminalGroupData.GameplayDataList.Add(item);
			}
			return true;
		}

		// Token: 0x06032B6D RID: 207725 RVA: 0x00CB3F0C File Offset: 0x00CB210C
		protected override bool OnClear()
		{
			this.GroupDataMap.Clear();
			this.GameplayDataMap.Clear();
			this.InstanceId2AreaMapGroupId.Clear();
			this.InstanceId2AreaMapGroupIdInit = false;
			return true;
		}

		// Token: 0x06032B6E RID: 207726 RVA: 0x00CB3F38 File Offset: 0x00CB2138
		private RegionalTerminalGameplayData CreateGameplayData(AreaTerminal config)
		{
			RegionalTerminalGameplayData regionalTerminalGameplayData = this.Type2GameplayDataCtor[(ETerminalGameplayType)config.GamePlayType]();
			regionalTerminalGameplayData.Id = config.Id;
			regionalTerminalGameplayData.GameplayId = config.GamePlayId;
			regionalTerminalGameplayData.SortId = config.SortId;
			regionalTerminalGameplayData.GroupId = config.GroupId;
			this.GameplayDataMap[config.Id] = regionalTerminalGameplayData;
			foreach (int key in config.AreaMapGroup())
			{
				List<int> list;
				if (!this.AreaMapGroupId2GameplayIdList.TryGetValue(key, out list))
				{
					list = new List<int>();
					this.AreaMapGroupId2GameplayIdList[key] = list;
				}
				list.Add(config.Id);
			}
			return regionalTerminalGameplayData;
		}

		// Token: 0x06032B6F RID: 207727 RVA: 0x00CB3FF4 File Offset: 0x00CB21F4
		public List<RegionalTerminalGameplayData> GetGameplayDataList(bool withPinGameplay = true)
		{
			HashSet<int> hashSet = new HashSet<int>();
			List<RegionalTerminalGameplayData> list = new List<RegionalTerminalGameplayData>();
			if (withPinGameplay)
			{
				foreach (int item in this.GetPinnedGameplayIds())
				{
					hashSet.Add(item);
				}
			}
			foreach (int item2 in this.AreaMapGroupId2GameplayIdList.GetValueOrDefault(this.CurrentUnlockAreaMapGroupId, new List<int>()))
			{
				hashSet.Add(item2);
			}
			foreach (int key in hashSet)
			{
				RegionalTerminalGameplayData regionalTerminalGameplayData;
				if (this.GameplayDataMap.TryGetValue(key, out regionalTerminalGameplayData) && regionalTerminalGameplayData.GetShowState())
				{
					list.Add(regionalTerminalGameplayData);
				}
			}
			list.Sort(new Comparison<RegionalTerminalGameplayData>(this.SortGameplayData));
			return list;
		}

		// Token: 0x06032B70 RID: 207728 RVA: 0x00CB411C File Offset: 0x00CB231C
		public int SortGameplayData(RegionalTerminalGameplayData a, RegionalTerminalGameplayData b)
		{
			bool flag = this.IsGameplayPin(a.Id);
			bool flag2 = this.IsGameplayPin(b.Id);
			if (flag != flag2)
			{
				if (!flag)
				{
					return 1;
				}
				return -1;
			}
			else
			{
				bool flag3 = !a.GetLockState();
				bool flag4 = !b.GetLockState();
				if (flag3 != flag4)
				{
					if (!flag3)
					{
						return 1;
					}
					return -1;
				}
				else
				{
					if (a.SortId != b.SortId)
					{
						return b.SortId.CompareTo(a.SortId);
					}
					return b.Id.CompareTo(a.Id);
				}
			}
		}

		// Token: 0x06032B71 RID: 207729 RVA: 0x00CB41A0 File Offset: 0x00CB23A0
		public unsafe int? GetAreaMapGroupIdByInstanceId(int instanceId)
		{
			if (!this.InstanceId2AreaMapGroupIdInit)
			{
				foreach (AreaMapGroup areaMapGroup in ConfigBase<RegionalTerminalConfig>.Instance.GetAllAreaMapGroup())
				{
					Span<int> instanceDungeonBytes = areaMapGroup.GetInstanceDungeonBytes();
					for (int i = 0; i < instanceDungeonBytes.Length; i++)
					{
						int key = *instanceDungeonBytes[i];
						this.InstanceId2AreaMapGroupId[key] = areaMapGroup.Id;
					}
				}
				this.InstanceId2AreaMapGroupIdInit = true;
			}
			return this.InstanceId2AreaMapGroupId.GetValueOrNull(instanceId);
		}

		// Token: 0x06032B72 RID: 207730 RVA: 0x00CB4240 File Offset: 0x00CB2440
		public void SetUnlockAreaMapGroupId(int areaMapGroupId)
		{
			this.UnlockAreaMapGroupId.Add(areaMapGroupId);
		}

		// Token: 0x06032B73 RID: 207731 RVA: 0x00CB4250 File Offset: 0x00CB2450
		public void InitGameplayPin(RepeatedField<int> gameplayIdList)
		{
			this.PinnedGameplayIds = new List<int>(gameplayIdList);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Map;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "[RegionalTerminal] 初始化终端信息";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PinnedIdList", gameplayIdList);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x06032B74 RID: 207732 RVA: 0x00CB4290 File Offset: 0x00CB2490
		public void UpdateGameplayPin(int gameplayId, bool isPin)
		{
			int num = this.PinnedGameplayIds.IndexOf(gameplayId);
			if (isPin)
			{
				if (num == -1)
				{
					this.PinnedGameplayIds.Add(gameplayId);
				}
			}
			else if (num != -1)
			{
				this.PinnedGameplayIds.RemoveAt(num);
			}
			Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.RegionalTerminalGameplayPinUpdate, gameplayId, isPin);
		}

		// Token: 0x06032B75 RID: 207733 RVA: 0x00CB42E1 File Offset: 0x00CB24E1
		public bool IsGameplayPin(int gameplayId)
		{
			return this.PinnedGameplayIds.Contains(gameplayId);
		}

		// Token: 0x06032B76 RID: 207734 RVA: 0x00CB42EF File Offset: 0x00CB24EF
		public List<int> GetPinnedGameplayIds()
		{
			return new List<int>(this.PinnedGameplayIds);
		}

		// Token: 0x06032B77 RID: 207735 RVA: 0x00CB42FC File Offset: 0x00CB24FC
		public void StartPinCdTimer()
		{
			this.ClearPinCdTimer();
			this.PinCdTimerHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.ClearPinCdTimer();
			}, 1000f, null, null, true, 1f);
		}

		// Token: 0x06032B78 RID: 207736 RVA: 0x00CB432D File Offset: 0x00CB252D
		public void ClearPinCdTimer()
		{
			if (this.PinCdTimerHandle != null && TimerSystem.GameplayTimeInstance.Has(this.PinCdTimerHandle))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.PinCdTimerHandle);
			}
			this.PinCdTimerHandle = null;
		}

		// Token: 0x1700871A RID: 34586
		// (get) Token: 0x06032B79 RID: 207737 RVA: 0x00CB4361 File Offset: 0x00CB2561
		public bool IsInPinCd
		{
			get
			{
				return this.PinCdTimerHandle != null;
			}
		}

		// Token: 0x1700871B RID: 34587
		// (get) Token: 0x06032B7A RID: 207738 RVA: 0x00CB436C File Offset: 0x00CB256C
		// (set) Token: 0x06032B7B RID: 207739 RVA: 0x00CB4379 File Offset: 0x00CB2579
		public bool BarFoldState
		{
			get
			{
				return LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.RegionalTerminalBarFoldState, false);
			}
			set
			{
				LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.RegionalTerminalBarFoldState, value);
			}
		}

		// Token: 0x06032B7C RID: 207740 RVA: 0x00CB4387 File Offset: 0x00CB2587
		public void UpdateFuncIdConditionFinishedState(int funcId, RepeatedField<int> conditionIdList)
		{
			this.FunctionConditionFinishedStateMap[funcId] = new List<int>(conditionIdList);
		}

		// Token: 0x06032B7D RID: 207741 RVA: 0x00CB439B File Offset: 0x00CB259B
		public bool GetFuncIdConditionFinishedState(int funcId, int conditionId)
		{
			List<int> valueOrDefault = this.FunctionConditionFinishedStateMap.GetValueOrDefault(funcId);
			return valueOrDefault != null && valueOrDefault.Contains(conditionId);
		}

		// Token: 0x06032B7E RID: 207742 RVA: 0x00CB43B8 File Offset: 0x00CB25B8
		public RegionalTerminalModel()
		{
			Dictionary<ETerminalGameplayType, Func<RegionalTerminalGameplayData>> dictionary = new Dictionary<ETerminalGameplayType, Func<RegionalTerminalGameplayData>>();
			dictionary[ETerminalGameplayType.Activity] = (() => new RegionalTerminalActivityData());
			dictionary[ETerminalGameplayType.Function] = (() => new RegionalTerminalFunctionData());
			this.Type2GameplayDataCtor = dictionary;
			this.PinnedGameplayIds = new List<int>();
			this.FunctionConditionFinishedStateMap = new Dictionary<int, List<int>>();
			base..ctor();
		}

		// Token: 0x0401D850 RID: 120912
		public Dictionary<int, RegionalTerminalGroupData> GroupDataMap = new Dictionary<int, RegionalTerminalGroupData>();

		// Token: 0x0401D851 RID: 120913
		public Dictionary<int, RegionalTerminalGameplayData> GameplayDataMap = new Dictionary<int, RegionalTerminalGameplayData>();

		// Token: 0x0401D852 RID: 120914
		private readonly Dictionary<int, List<int>> AreaMapGroupId2GameplayIdList = new Dictionary<int, List<int>>();

		// Token: 0x0401D853 RID: 120915
		private int CurrentAreaMapGroupIdInternal;

		// Token: 0x0401D854 RID: 120916
		private readonly Dictionary<int, int> InstanceId2AreaMapGroupId = new Dictionary<int, int>();

		// Token: 0x0401D855 RID: 120917
		private bool InstanceId2AreaMapGroupIdInit;

		// Token: 0x0401D856 RID: 120918
		private readonly HashSet<int> UnlockAreaMapGroupId = new HashSet<int>();

		// Token: 0x0401D857 RID: 120919
		private readonly Dictionary<ETerminalGameplayType, Func<RegionalTerminalGameplayData>> Type2GameplayDataCtor;

		// Token: 0x0401D858 RID: 120920
		private List<int> PinnedGameplayIds;

		// Token: 0x0401D859 RID: 120921
		private readonly Dictionary<int, List<int>> FunctionConditionFinishedStateMap;

		// Token: 0x0401D85A RID: 120922
		[Nullable(2)]
		private TimerHandle PinCdTimerHandle;
	}
}
