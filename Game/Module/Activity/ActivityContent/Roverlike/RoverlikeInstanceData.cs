using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063A1 RID: 25505
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeInstanceData
	{
		// Token: 0x17009D6A RID: 40298
		// (get) Token: 0x060400AA RID: 262314 RVA: 0x0106A087 File Offset: 0x01068287
		public int CurLayer
		{
			get
			{
				return this.CurLayerInternal;
			}
		}

		// Token: 0x17009D6B RID: 40299
		// (get) Token: 0x060400AB RID: 262315 RVA: 0x0106A08F File Offset: 0x0106828F
		public int MaxLayer
		{
			get
			{
				return this.MaxLayerInternal;
			}
		}

		// Token: 0x17009D6C RID: 40300
		// (get) Token: 0x060400AC RID: 262316 RVA: 0x0106A097 File Offset: 0x01068297
		public int CurRoomId
		{
			get
			{
				return this.CurRoomIdInternal;
			}
		}

		// Token: 0x17009D6D RID: 40301
		// (get) Token: 0x060400AD RID: 262317 RVA: 0x0106A09F File Offset: 0x0106829F
		public int CurRoomTypeId
		{
			get
			{
				return this.CurRoomTypeIdInternal;
			}
		}

		// Token: 0x060400AE RID: 262318 RVA: 0x0106A0A7 File Offset: 0x010682A7
		public static RoverlikeInstanceData Create()
		{
			return new RoverlikeInstanceData();
		}

		// Token: 0x060400AF RID: 262319 RVA: 0x0106A0B0 File Offset: 0x010682B0
		public void InitFromNotify(RoverRogueInfoNotify notify)
		{
			this.Clear();
			if (notify.Bless != null)
			{
				foreach (RoverRogueGainEntry roverRogueGainEntry in notify.Bless)
				{
					this.IncIdToGainTypeMap[roverRogueGainEntry.IncId] = RoverRogueGainDataType.RoverRogueGainBless;
					this.BlessMap[roverRogueGainEntry.IncId] = new RoverlikeGainEntry(roverRogueGainEntry);
				}
			}
			if (notify.RoleEnhance != null)
			{
				foreach (RoverRogueGainEntry roverRogueGainEntry2 in notify.RoleEnhance)
				{
					this.IncIdToGainTypeMap[roverRogueGainEntry2.IncId] = RoverRogueGainDataType.RoverRogueGainRoleEnhance;
					this.RoleEnhanceMap[roverRogueGainEntry2.IncId] = new RoverlikeGainEntry(roverRogueGainEntry2);
				}
			}
			if (notify.LootItem != null)
			{
				foreach (RoverRogueGainEntry roverRogueGainEntry3 in notify.LootItem)
				{
					this.IncIdToGainTypeMap[roverRogueGainEntry3.IncId] = RoverRogueGainDataType.RoverRogueGainLootItem;
					this.LootItemMap[roverRogueGainEntry3.IncId] = new RoverlikeLootGainEntry(roverRogueGainEntry3);
				}
			}
			if (notify.Item != null)
			{
				foreach (RoverRogueGainEntry roverRogueGainEntry4 in notify.Item)
				{
					this.IncIdToGainTypeMap[roverRogueGainEntry4.IncId] = RoverRogueGainDataType.RoverRogueGainItem;
					this.ItemMap[roverRogueGainEntry4.IncId] = new RoverlikeGainEntry(roverRogueGainEntry4);
				}
			}
			this.RoleType = notify.RoverType;
			this.InitRoadType(notify.RoverRogueRoadType);
		}

		// Token: 0x060400B0 RID: 262320 RVA: 0x0106A27C File Offset: 0x0106847C
		private void InitRoadType(int roadType)
		{
			this.RoadTypeId = roadType;
			IReadOnlyList<RoverRogueRoad> roadByRoadType = ConfigBase<RoverlikeConfig>.Instance.GetRoadByRoadType(roadType);
			int num = -1;
			for (int i = 0; i < roadByRoadType.Count; i++)
			{
				RoverRogueRoad roverRogueRoad = roadByRoadType[i];
				if (roverRogueRoad.Floor != num)
				{
					num = roverRogueRoad.Floor;
					this.RoadLayerIndexList.Add(i);
				}
			}
		}

		// Token: 0x060400B1 RID: 262321 RVA: 0x0106A2D8 File Offset: 0x010684D8
		public unsafe void UpdateRoomUpdateInfo(RoverRogueRoomInfoNotify notify)
		{
			this.CurLayerInternal = notify.CurLayer;
			this.MaxLayerInternal = notify.MaxLayer;
			this.CurRoomIdInternal = notify.RoomId;
			this.CurRoomTypeIdInternal = notify.RoomTypeId;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Roverlike;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "[俯视角肉鸽] 房间信息变更";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("RoomId", this.CurRoomIdInternal);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("RoomTypeId", this.CurRoomTypeIdInternal);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Progress", this.CurLayerInternal.ToString() + "/" + this.MaxLayerInternal.ToString());
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}

		// Token: 0x060400B2 RID: 262322 RVA: 0x0106A3B6 File Offset: 0x010685B6
		public void Clear()
		{
			this.BlessMap.Clear();
			this.RoleEnhanceMap.Clear();
			this.LootItemMap.Clear();
			this.ItemMap.Clear();
			this.BlessVoicePool.Clear();
			this.StopAudio();
		}

		// Token: 0x060400B3 RID: 262323 RVA: 0x0106A3F8 File Offset: 0x010685F8
		public unsafe void PlayBlessRoleVoice(int roleId)
		{
			int? num = this.DrawBlessVoiceId(roleId);
			if (num == null)
			{
				return;
			}
			FavorWord? favorWordConfigById = ConfigBase<RoleFavorConfig>.Instance.GetFavorWordConfigById(num.Value);
			if (favorWordConfigById == null)
			{
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Roverlike;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "[俯视角肉鸽] 祝福角色语音播放";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("RoleId", roleId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("VoiceId", num.Value);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			string voice = favorWordConfigById.Value.Voice;
			if (StringUtils.IsEmpty(voice))
			{
				return;
			}
			this.PlayAudio(voice, null);
		}

		// Token: 0x060400B4 RID: 262324 RVA: 0x0106A4BC File Offset: 0x010686BC
		private int? DrawBlessVoiceId(int roleId)
		{
			List<int> list;
			this.BlessVoicePool.TryGetValue(roleId, out list);
			if (list == null || list.Count == 0)
			{
				RoverRogueBlessRole? blessRoleConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessRoleConfig(roleId);
				int[] array = (blessRoleConfig != null) ? blessRoleConfig.GetValueOrDefault().BlessVoice() : null;
				if (array == null || array.Length == 0)
				{
					return null;
				}
				list = new List<int>();
				foreach (int item in array)
				{
					list.Add(item);
				}
				this.BlessVoicePool[roleId] = list;
			}
			int index = Random.Shared.Next(list.Count);
			int value = list[index];
			list.RemoveAt(index);
			return new int?(value);
		}

		// Token: 0x060400B5 RID: 262325 RVA: 0x0106A57A File Offset: 0x0106877A
		public void PlayAudio(string eventPath, [Nullable(2)] Action finishCallback = null)
		{
			this.DialogLogic.PlayAudio(eventPath, finishCallback);
		}

		// Token: 0x060400B6 RID: 262326 RVA: 0x0106A589 File Offset: 0x01068789
		public void StopAudio()
		{
			this.DialogLogic.Stop();
		}

		// Token: 0x060400B7 RID: 262327 RVA: 0x0106A598 File Offset: 0x01068798
		public void ApplyGainDataUpdate(RoverRogueGainDataUpdateNotify notify)
		{
			foreach (int key in notify.RemoveIncIds)
			{
				RoverRogueGainDataType value;
				RoverRogueGainDataType? type = this.IncIdToGainTypeMap.TryGetValue(key, out value) ? new RoverRogueGainDataType?(value) : null;
				Dictionary<int, RoverlikeGainEntry> gainMapByType = this.GetGainMapByType(type);
				if (gainMapByType != null)
				{
					gainMapByType.Remove(key);
				}
				this.IncIdToGainTypeMap.Remove(key);
			}
			foreach (RoverRogueGainEntry roverRogueGainEntry in notify.Adds)
			{
				RoverRogueGainDataType type2 = roverRogueGainEntry.Type;
				Dictionary<int, RoverlikeGainEntry> gainMapByType2 = this.GetGainMapByType(new RoverRogueGainDataType?(type2));
				RoverlikeGainEntry roverlikeGainEntry = this.CreateGainEntry(roverRogueGainEntry, new RoverRogueGainDataType?(type2));
				if (gainMapByType2 != null)
				{
					gainMapByType2[roverRogueGainEntry.IncId] = roverlikeGainEntry;
				}
				this.IncIdToGainTypeMap[roverRogueGainEntry.IncId] = type2;
				this.ExtraGainNewTipsCheck(roverlikeGainEntry);
			}
			foreach (RoverRogueGainEntry roverRogueGainEntry2 in notify.Updates)
			{
				RoverRogueGainDataType value2;
				RoverRogueGainDataType? type3 = this.IncIdToGainTypeMap.TryGetValue(roverRogueGainEntry2.IncId, out value2) ? new RoverRogueGainDataType?(value2) : null;
				Dictionary<int, RoverlikeGainEntry> gainMapByType3 = this.GetGainMapByType(type3);
				if (gainMapByType3 != null)
				{
					RoverlikeGainEntry roverlikeGainEntry2;
					RoverlikeGainEntry lastEntry = gainMapByType3.TryGetValue(roverRogueGainEntry2.IncId, out roverlikeGainEntry2) ? roverlikeGainEntry2 : null;
					RoverlikeGainEntry roverlikeGainEntry3 = this.CreateGainEntry(roverRogueGainEntry2, type3);
					gainMapByType3[roverRogueGainEntry2.IncId] = roverlikeGainEntry3;
					this.ExtraGainUpdateTipsCheck(lastEntry, roverlikeGainEntry3);
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.RoverlikeGainDataUpdate);
		}

		// Token: 0x060400B8 RID: 262328 RVA: 0x0106A780 File Offset: 0x01068980
		private void ExtraGainNewTipsCheck(RoverlikeGainEntry newEntry)
		{
			if (newEntry.Type == RoverRogueGainDataType.RoverRogueGainBless)
			{
				RoverRogueBless? blessConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessConfig(newEntry.ConfigId);
				if (blessConfig != null && !StringUtils.IsEmpty(blessConfig.Value.TriggerRoleInfo))
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeRoleBlessingTips, newEntry, null);
				}
			}
		}

		// Token: 0x060400B9 RID: 262329 RVA: 0x0106A7D8 File Offset: 0x010689D8
		private void ExtraGainUpdateTipsCheck([Nullable(2)] RoverlikeGainEntry lastEntry, RoverlikeGainEntry newEntry)
		{
			if (lastEntry == null)
			{
				return;
			}
			if (newEntry.Type == RoverRogueGainDataType.RoverRogueGainLootItem && newEntry.ConfigId == lastEntry.ConfigId)
			{
				RoverlikeLootGainEntry roverlikeLootGainEntry = newEntry as RoverlikeLootGainEntry;
				RoverlikeLootGainEntry roverlikeLootGainEntry2 = lastEntry as RoverlikeLootGainEntry;
				if (roverlikeLootGainEntry != null && roverlikeLootGainEntry2 != null && roverlikeLootGainEntry.LootLv > roverlikeLootGainEntry2.LootLv)
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeLootTipsView, roverlikeLootGainEntry, null);
				}
			}
		}

		// Token: 0x060400BA RID: 262330 RVA: 0x0106A833 File Offset: 0x01068A33
		private RoverlikeGainEntry CreateGainEntry(RoverRogueGainEntry proto, RoverRogueGainDataType? type)
		{
			if (type.GetValueOrDefault() == RoverRogueGainDataType.RoverRogueGainLootItem)
			{
				return new RoverlikeLootGainEntry(proto);
			}
			return new RoverlikeGainEntry(proto);
		}

		// Token: 0x060400BB RID: 262331 RVA: 0x0106A84C File Offset: 0x01068A4C
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public Dictionary<int, RoverlikeGainEntry> GetGainMapByType(RoverRogueGainDataType? type)
		{
			if (type != null)
			{
				switch (type.GetValueOrDefault())
				{
				case RoverRogueGainDataType.RoverRogueGainBless:
					return this.BlessMap;
				case RoverRogueGainDataType.RoverRogueGainRoleEnhance:
					return this.RoleEnhanceMap;
				case RoverRogueGainDataType.RoverRogueGainLootItem:
					return this.LootItemMap;
				case RoverRogueGainDataType.RoverRogueGainItem:
					return this.ItemMap;
				}
			}
			return null;
		}

		// Token: 0x060400BC RID: 262332 RVA: 0x0106A8A4 File Offset: 0x01068AA4
		[NullableContext(2)]
		public RoverlikeGainEntry GetGainByIncId(int incId)
		{
			RoverRogueGainDataType value;
			RoverRogueGainDataType? roverRogueGainDataType = this.IncIdToGainTypeMap.TryGetValue(incId, out value) ? new RoverRogueGainDataType?(value) : null;
			if (roverRogueGainDataType != null)
			{
				switch (roverRogueGainDataType.GetValueOrDefault())
				{
				case RoverRogueGainDataType.RoverRogueGainBless:
				{
					RoverlikeGainEntry result;
					if (!this.BlessMap.TryGetValue(incId, out result))
					{
						return null;
					}
					return result;
				}
				case RoverRogueGainDataType.RoverRogueGainRoleEnhance:
				{
					RoverlikeGainEntry result2;
					if (!this.RoleEnhanceMap.TryGetValue(incId, out result2))
					{
						return null;
					}
					return result2;
				}
				case RoverRogueGainDataType.RoverRogueGainLootItem:
				{
					RoverlikeGainEntry result3;
					if (!this.LootItemMap.TryGetValue(incId, out result3))
					{
						return null;
					}
					return result3;
				}
				case RoverRogueGainDataType.RoverRogueGainItem:
				{
					RoverlikeGainEntry result4;
					if (!this.ItemMap.TryGetValue(incId, out result4))
					{
						return null;
					}
					return result4;
				}
				}
			}
			return null;
		}

		// Token: 0x060400BD RID: 262333 RVA: 0x0106A954 File Offset: 0x01068B54
		public List<RoverlikeGainEntry> GetBlessList()
		{
			return new List<RoverlikeGainEntry>(this.BlessMap.Values);
		}

		// Token: 0x060400BE RID: 262334 RVA: 0x0106A968 File Offset: 0x01068B68
		[NullableContext(2)]
		public RoverlikeGainEntry GetSameSlotIdBless(int configId)
		{
			RoverRogueBless? blessConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessConfig(configId);
			if (blessConfig == null || blessConfig.Value.SlotId == 0)
			{
				return null;
			}
			int slotId = blessConfig.Value.SlotId;
			RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
			List<int> list;
			if (instance == null)
			{
				list = null;
			}
			else
			{
				RoverlikeActivityData currentActivityData = instance.GetCurrentActivityData();
				RoverRogueActivity? roverRogueActivity;
				list = ((currentActivityData != null) ? ((currentActivityData.GetParamConfig() != null) ? roverRogueActivity.GetValueOrDefault().SlotList().ToList<int>() : null) : null);
			}
			if (!(list ?? new List<int>()).Contains(slotId))
			{
				return null;
			}
			foreach (RoverlikeGainEntry roverlikeGainEntry in this.BlessMap.Values)
			{
				RoverRogueBless? blessConfig2 = ConfigBase<RoverlikeConfig>.Instance.GetBlessConfig(roverlikeGainEntry.ConfigId);
				if (blessConfig2 != null && blessConfig2.Value.SlotId == slotId)
				{
					return roverlikeGainEntry;
				}
			}
			return null;
		}

		// Token: 0x060400BF RID: 262335 RVA: 0x0106AA80 File Offset: 0x01068C80
		public List<RoverlikeGainEntry> GetRoleEnhanceList()
		{
			return new List<RoverlikeGainEntry>(this.RoleEnhanceMap.Values);
		}

		// Token: 0x060400C0 RID: 262336 RVA: 0x0106AA94 File Offset: 0x01068C94
		public List<RoverlikeLootGainEntry> GetLootItemList()
		{
			List<RoverlikeLootGainEntry> list = new List<RoverlikeLootGainEntry>();
			foreach (RoverlikeGainEntry roverlikeGainEntry in this.LootItemMap.Values)
			{
				list.Add((RoverlikeLootGainEntry)roverlikeGainEntry);
			}
			return list;
		}

		// Token: 0x060400C1 RID: 262337 RVA: 0x0106AAF8 File Offset: 0x01068CF8
		public List<RoverlikeGainEntry> GetItemList()
		{
			return new List<RoverlikeGainEntry>(this.ItemMap.Values);
		}

		// Token: 0x060400C2 RID: 262338 RVA: 0x0106AB0C File Offset: 0x01068D0C
		public int GetGainCountByType(RoverRogueGainDataType type)
		{
			Dictionary<int, RoverlikeGainEntry> gainMapByType = this.GetGainMapByType(new RoverRogueGainDataType?(type));
			if (gainMapByType == null)
			{
				return 0;
			}
			return gainMapByType.Count;
		}

		// Token: 0x060400C3 RID: 262339 RVA: 0x0106AB34 File Offset: 0x01068D34
		private static int GetGainQuality(int configId, RoverRogueGainDataType type)
		{
			if (type != RoverRogueGainDataType.RoverRogueGainBless)
			{
				if (type != RoverRogueGainDataType.RoverRogueGainItem)
				{
					return 0;
				}
				if (ConfigBase<RoverlikeConfig>.Instance.GetItemConfig(configId) == null)
				{
					return 0;
				}
				RoverRogueItem? roverRogueItem;
				return roverRogueItem.GetValueOrDefault().Quality;
			}
			else
			{
				if (ConfigBase<RoverlikeConfig>.Instance.GetBlessConfig(configId) == null)
				{
					return 0;
				}
				RoverRogueBless? roverRogueBless;
				return roverRogueBless.GetValueOrDefault().Quality;
			}
		}

		// Token: 0x060400C4 RID: 262340 RVA: 0x0106AB9A File Offset: 0x01068D9A
		public static void SortGainEntryList(List<RoverlikeGainEntry> list)
		{
			list.Sort(delegate(RoverlikeGainEntry a, RoverlikeGainEntry b)
			{
				int gainQuality = RoverlikeInstanceData.GetGainQuality(a.ConfigId, a.Type);
				int gainQuality2 = RoverlikeInstanceData.GetGainQuality(b.ConfigId, b.Type);
				if (gainQuality != gainQuality2)
				{
					return gainQuality2 - gainQuality;
				}
				if (a.ItemRemainingRooms != b.ItemRemainingRooms)
				{
					return b.ItemRemainingRooms - a.ItemRemainingRooms;
				}
				return a.ConfigId - b.ConfigId;
			});
		}

		// Token: 0x060400C5 RID: 262341 RVA: 0x0106ABC4 File Offset: 0x01068DC4
		public static List<int> SortGainConfigIds(List<int> ids, RoverRogueGainDataType type)
		{
			List<int> list = new List<int>(ids);
			list.Sort(delegate(int a, int b)
			{
				int gainQuality = RoverlikeInstanceData.GetGainQuality(a, type);
				int gainQuality2 = RoverlikeInstanceData.GetGainQuality(b, type);
				if (gainQuality != gainQuality2)
				{
					return gainQuality2 - gainQuality;
				}
				return a - b;
			});
			return list;
		}

		// Token: 0x04023F4A RID: 147274
		public int RoadTypeId;

		// Token: 0x04023F4B RID: 147275
		public List<int> RoadLayerIndexList = new List<int>();

		// Token: 0x04023F4C RID: 147276
		private int CurLayerInternal;

		// Token: 0x04023F4D RID: 147277
		private int MaxLayerInternal;

		// Token: 0x04023F4E RID: 147278
		private int CurRoomIdInternal;

		// Token: 0x04023F4F RID: 147279
		private int CurRoomTypeIdInternal;

		// Token: 0x04023F50 RID: 147280
		private readonly Dictionary<int, RoverlikeGainEntry> BlessMap = new Dictionary<int, RoverlikeGainEntry>();

		// Token: 0x04023F51 RID: 147281
		private readonly Dictionary<int, RoverlikeGainEntry> RoleEnhanceMap = new Dictionary<int, RoverlikeGainEntry>();

		// Token: 0x04023F52 RID: 147282
		private readonly Dictionary<int, RoverlikeGainEntry> LootItemMap = new Dictionary<int, RoverlikeGainEntry>();

		// Token: 0x04023F53 RID: 147283
		private readonly Dictionary<int, RoverlikeGainEntry> ItemMap = new Dictionary<int, RoverlikeGainEntry>();

		// Token: 0x04023F54 RID: 147284
		private readonly Dictionary<int, RoverRogueGainDataType> IncIdToGainTypeMap = new Dictionary<int, RoverRogueGainDataType>();

		// Token: 0x04023F55 RID: 147285
		public int RoleType;

		// Token: 0x04023F56 RID: 147286
		private readonly RoverlikeDialogLogic DialogLogic = new RoverlikeDialogLogic();

		// Token: 0x04023F57 RID: 147287
		private readonly Dictionary<int, List<int>> BlessVoicePool = new Dictionary<int, List<int>>();
	}
}
