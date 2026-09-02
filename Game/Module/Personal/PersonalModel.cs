using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;

namespace CSharpScript.Game.Module.Personal
{
	// Token: 0x0200564F RID: 22095
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class PersonalModel : ModelBase<PersonalModel>
	{
		// Token: 0x060384E9 RID: 230633 RVA: 0x00E410EE File Offset: 0x00E3F2EE
		protected override bool OnInit()
		{
			if (this.PersonalInfoData == null)
			{
				this.PersonalInfoData = new PersonalInfoData();
			}
			return true;
		}

		// Token: 0x060384EA RID: 230634 RVA: 0x00E41104 File Offset: 0x00E3F304
		public void InitPlayerHeadData(int[] playerHeadIds)
		{
			this.PlayerHeadDataMap.Clear();
			IReadOnlyList<PlayerHeadRe> allPlayerHeadConfig = ConfigBase<PersonalConfig>.Instance.GetAllPlayerHeadConfig();
			if (allPlayerHeadConfig == null)
			{
				return;
			}
			foreach (PlayerHeadRe config in allPlayerHeadConfig)
			{
				PlayerHeadData playerHeadData = new PlayerHeadData(config);
				this.PlayerHeadDataMap[playerHeadData.Id] = playerHeadData;
			}
			this.InitMainRoleSkinToHeadDataMap();
			this.UpdatePlayerHeadData(playerHeadIds);
		}

		// Token: 0x060384EB RID: 230635 RVA: 0x00E41184 File Offset: 0x00E3F384
		private void InitMainRoleSkinToHeadDataMap()
		{
			this.HeadDataToMainRoleSkinMap.Clear();
			foreach (KeyValuePair<int, PlayerHeadData> keyValuePair in this.PlayerHeadDataMap)
			{
				PlayerHeadData value = keyValuePair.Value;
				int roleSkinId = value.Config.RoleSkinId;
				if (roleSkinId > 0)
				{
					RoleSkinData roleSkinData = ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(roleSkinId);
					if (roleSkinData != null && ModelBase<RoleModel>.Instance.IsMainRole(roleSkinData.GetRoleId()))
					{
						this.HeadDataToMainRoleSkinMap[value.Id] = roleSkinData.GetRoleId();
					}
				}
			}
		}

		// Token: 0x060384EC RID: 230636 RVA: 0x00E41234 File Offset: 0x00E3F434
		public void UpdatePlayerHeadData(int[] playerHeadIds)
		{
			foreach (int playerHeadId in playerHeadIds)
			{
				this.UnLockPlayerHeadData(playerHeadId);
			}
		}

		// Token: 0x060384ED RID: 230637 RVA: 0x00E4125C File Offset: 0x00E3F45C
		public void UnLockPlayerHeadData(int playerHeadId)
		{
			PlayerHeadData playerHeadData = this.GetPlayerHeadData(playerHeadId, true);
			if (playerHeadData == null)
			{
				return;
			}
			playerHeadData.Lock = false;
		}

		// Token: 0x060384EE RID: 230638 RVA: 0x00E4127D File Offset: 0x00E3F47D
		protected override bool OnClear()
		{
			this.PersonalInfoData = null;
			ModelBase<NewFlagModel>.Instance.SaveNewFlagConfig(ELocalStoragePlayerKey.PersonalDataItem);
			return true;
		}

		// Token: 0x060384EF RID: 230639 RVA: 0x00E41294 File Offset: 0x00E3F494
		[NullableContext(2)]
		public PersonalInfoData GetPersonalInfoData()
		{
			return this.PersonalInfoData;
		}

		// Token: 0x060384F0 RID: 230640 RVA: 0x00E4129C File Offset: 0x00E3F49C
		public void SetRoleShowList(List<Aki.Protocol.RoleShowEntry> roleShowEntry)
		{
			this.PersonalInfoData.RoleShowList = new List<global::RoleShowEntry>();
			int count = roleShowEntry.Count;
			for (int i = 0; i < count; i++)
			{
				Aki.Protocol.RoleShowEntry roleShowEntry2 = roleShowEntry[i];
				this.PersonalInfoData.RoleShowList.Add(new global::RoleShowEntry(roleShowEntry2.RoleId, roleShowEntry2.Level));
			}
		}

		// Token: 0x060384F1 RID: 230641 RVA: 0x00E412F8 File Offset: 0x00E3F4F8
		public void UpdateRoleShowList(int[] roleIdList)
		{
			this.PersonalInfoData.RoleShowList = new List<global::RoleShowEntry>();
			int num = roleIdList.Length;
			for (int i = 0; i < num; i++)
			{
				int num2 = roleIdList[i];
				RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(num2, true);
				RoleLevelData roleLevelData = (roleDataById != null) ? roleDataById.GetLevelData() : null;
				if (roleLevelData != null)
				{
					this.PersonalInfoData.RoleShowList.Add(new global::RoleShowEntry(num2, roleLevelData.GetLevel()));
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRoleShowListChange);
		}

		// Token: 0x060384F2 RID: 230642 RVA: 0x00E41371 File Offset: 0x00E3F571
		public List<global::RoleShowEntry> GetRoleShowList()
		{
			return this.PersonalInfoData.RoleShowList;
		}

		// Token: 0x060384F3 RID: 230643 RVA: 0x00E4137E File Offset: 0x00E3F57E
		public void SetCardShowList(List<int> cardShowList)
		{
			this.PersonalInfoData.CardShowList = cardShowList;
		}

		// Token: 0x060384F4 RID: 230644 RVA: 0x00E4138C File Offset: 0x00E3F58C
		public List<int> GetCardShowList()
		{
			return this.PersonalInfoData.CardShowList;
		}

		// Token: 0x060384F5 RID: 230645 RVA: 0x00E41399 File Offset: 0x00E3F599
		public void SetCurCardId(int cardId)
		{
			this.PersonalInfoData.CurCardId = new int?(cardId);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnCardChange);
		}

		// Token: 0x060384F6 RID: 230646 RVA: 0x00E413BC File Offset: 0x00E3F5BC
		public int GetCurCardId()
		{
			if (this.PersonalInfoData.CurCardId != null)
			{
				int? curCardId = this.PersonalInfoData.CurCardId;
				int num = 0;
				if (curCardId.GetValueOrDefault() > num & curCardId != null)
				{
					return this.PersonalInfoData.CurCardId.Value;
				}
			}
			return ConfigBase<FriendConfig>.Instance.GetDefaultBackgroundCardId();
		}

		// Token: 0x060384F7 RID: 230647 RVA: 0x00E41418 File Offset: 0x00E3F618
		public void SetBirthday(int birthday)
		{
			this.PersonalInfoData.Birthday = birthday;
			Singleton<EventSystem>.Instance.Emit(EEventName.OnBirthChange);
		}

		// Token: 0x060384F8 RID: 230648 RVA: 0x00E41436 File Offset: 0x00E3F636
		public void SetBirthdayDisplay(bool display)
		{
			this.PersonalInfoData.IsBirthdayDisplay = display;
			Singleton<EventSystem>.Instance.Emit(EEventName.OnBirthDisplayChange);
		}

		// Token: 0x060384F9 RID: 230649 RVA: 0x00E41454 File Offset: 0x00E3F654
		public void SetName(string name)
		{
			this.PersonalInfoData.Name = name;
		}

		// Token: 0x060384FA RID: 230650 RVA: 0x00E41462 File Offset: 0x00E3F662
		public void SetPlayerId(int uid)
		{
			this.PersonalInfoData.PlayerId = uid;
		}

		// Token: 0x060384FB RID: 230651 RVA: 0x00E41470 File Offset: 0x00E3F670
		public void SetModifyNameInfo(long lastModifyNameTime, string modifyName)
		{
			this.PersonalInfoData.LastModifyNameTime = (int)Singleton<MathUtils>.Instance.LongToBigInt(lastModifyNameTime);
			this.PersonalInfoData.ModifyName = modifyName;
			Singleton<EventSystem>.Instance.Emit(EEventName.OnModifyNameStateChange);
		}

		// Token: 0x060384FC RID: 230652 RVA: 0x00E414A5 File Offset: 0x00E3F6A5
		public int GetBirthday()
		{
			return this.PersonalInfoData.Birthday;
		}

		// Token: 0x060384FD RID: 230653 RVA: 0x00E414B2 File Offset: 0x00E3F6B2
		public bool GetBirthdayDisplay()
		{
			return this.PersonalInfoData.IsBirthdayDisplay;
		}

		// Token: 0x060384FE RID: 230654 RVA: 0x00E414BF File Offset: 0x00E3F6BF
		public void SetSignature(string sign)
		{
			this.PersonalInfoData.Signature = sign;
			ModelBase<PlayerInfoModel>.Instance.ChangeStringProp(8, sign);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnSignChange);
		}

		// Token: 0x060384FF RID: 230655 RVA: 0x00E414E9 File Offset: 0x00E3F6E9
		public string GetSignature()
		{
			return this.PersonalInfoData.Signature;
		}

		// Token: 0x06038500 RID: 230656 RVA: 0x00E414F6 File Offset: 0x00E3F6F6
		public void SetHeadPhotoId(int headPhotoId)
		{
			this.PersonalInfoData.HeadPhotoId = new int?(headPhotoId);
			ModelBase<PlayerInfoModel>.Instance.ChangeNumberProp(4, headPhotoId);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnHeadIconChange, headPhotoId);
		}

		// Token: 0x06038501 RID: 230657 RVA: 0x00E41528 File Offset: 0x00E3F728
		public int GetHeadPhotoId()
		{
			if (this.PersonalInfoData.HeadPhotoId == null)
			{
				int? numberPropById = ModelBase<PlayerInfoModel>.Instance.GetNumberPropById(EPlayerInfoNumber.HeadPhoto);
				this.PersonalInfoData.HeadPhotoId = numberPropById;
			}
			return this.PersonalInfoData.HeadPhotoId.Value;
		}

		// Token: 0x06038502 RID: 230658 RVA: 0x00E4156F File Offset: 0x00E3F76F
		[NullableContext(2)]
		public string GetThirdUserId()
		{
			return this.PersonalInfoData.ThirdUserId;
		}

		// Token: 0x06038503 RID: 230659 RVA: 0x00E4157C File Offset: 0x00E3F77C
		public void SetCardUnlockList(CardShowEntry[] cardShowEntryList)
		{
			this.InitCardDataList();
			int num = cardShowEntryList.Length;
			for (int i = 0; i < num; i++)
			{
				CardShowEntry cardShowEntry = cardShowEntryList[i];
				PersonalCardData cardDataById = this.GetCardDataById(cardShowEntry.CardId);
				if (cardDataById == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Personal;
					ELogAuthor author = ELogAuthor.BB;
					string message = "初始化卡牌,无效CardId";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("cardId", cardShowEntry.CardId);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					cardDataById.RefreshData(cardShowEntry.IsRead, true);
				}
			}
		}

		// Token: 0x06038504 RID: 230660 RVA: 0x00E415F8 File Offset: 0x00E3F7F8
		private void InitCardDataList()
		{
			this.PersonalInfoData.CardDataList = new List<PersonalCardData>();
			foreach (BackgroundCard backgroundCard in ConfigBackgroundCardAll.GetConfigList(true))
			{
				this.PersonalInfoData.CardDataList.Add(new PersonalCardData(backgroundCard.Id, false, false));
			}
		}

		// Token: 0x06038505 RID: 230661 RVA: 0x00E4166C File Offset: 0x00E3F86C
		[NullableContext(2)]
		private PersonalCardData GetCardDataById(int cardId)
		{
			foreach (PersonalCardData personalCardData in this.PersonalInfoData.CardDataList)
			{
				if (personalCardData.CardId == cardId)
				{
					return personalCardData;
				}
			}
			return null;
		}

		// Token: 0x06038506 RID: 230662 RVA: 0x00E416D0 File Offset: 0x00E3F8D0
		public void UpdateCardUnlockList(int cardId, bool isRead)
		{
			int count = this.PersonalInfoData.CardDataList.Count;
			for (int i = 0; i < count; i++)
			{
				PersonalCardData personalCardData = this.PersonalInfoData.CardDataList[i];
				if (personalCardData.CardId == cardId)
				{
					personalCardData.IsRead = isRead;
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPersonalCardRead, cardId);
					Singleton<EventSystem>.Instance.Emit(EEventName.OnPersonalCardRefreshRedDot);
					return;
				}
			}
		}

		// Token: 0x06038507 RID: 230663 RVA: 0x00E41740 File Offset: 0x00E3F940
		public void AddCardUnlockList(int cardId, bool isRead)
		{
			PersonalCardData cardDataById = this.GetCardDataById(cardId);
			if (cardDataById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Personal;
				ELogAuthor author = ELogAuthor.BB;
				string message = "新解锁卡牌,无效CardId";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("cardId", cardId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			cardDataById.RefreshData(isRead, true);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnPersonalCardRefreshRedDot);
		}

		// Token: 0x06038508 RID: 230664 RVA: 0x00E4179D File Offset: 0x00E3F99D
		public List<PersonalCardData> GetCardDataList()
		{
			return this.PersonalInfoData.CardDataList;
		}

		// Token: 0x06038509 RID: 230665 RVA: 0x00E417AC File Offset: 0x00E3F9AC
		public bool GetPersonalCardRedDotState()
		{
			foreach (PersonalCardData personalCardData in this.PersonalInfoData.CardDataList)
			{
				if (personalCardData.IsUnLock && !personalCardData.IsRead)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603850A RID: 230666 RVA: 0x00E41814 File Offset: 0x00E3FA14
		public bool GetPersonalTitleRedDotState()
		{
			if (!ModelBase<FunctionModel>.Instance.IsOpen(10082))
			{
				return false;
			}
			if (LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.PlayerTitleUnlockRedDot, true))
			{
				return true;
			}
			Dictionary<int, bool> player = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.PlayerTitleRecord, null);
			if (player != null)
			{
				foreach (KeyValuePair<int, bool> keyValuePair in player)
				{
					if (keyValuePair.Value)
					{
						PersonalPlayerTitleData personalPlayerTitleData = this.PlayerTitleDataMap.ContainsKey(keyValuePair.Key) ? this.PlayerTitleDataMap[keyValuePair.Key] : null;
						if (personalPlayerTitleData == null || !personalPlayerTitleData.IsExpired())
						{
							return true;
						}
					}
				}
				return false;
			}
			return false;
		}

		// Token: 0x0603850B RID: 230667 RVA: 0x00E418D0 File Offset: 0x00E3FAD0
		public EModifyNameState GetPersonalModifyNameState()
		{
			if (this.PersonalInfoData.ModifyName != "")
			{
				return EModifyNameState.UnderModification;
			}
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			int? intConfig = ConfigCommonParamById.GetIntConfig("NameModifyCd");
			int? num = this.PersonalInfoData.LastModifyNameTime + intConfig;
			double num2 = serverTime;
			int? num3 = num;
			double? num4 = (num3 != null) ? new double?((double)num3.GetValueOrDefault()) : null;
			if (num2 > num4.GetValueOrDefault() & num4 != null)
			{
				return EModifyNameState.CanBeModified;
			}
			return EModifyNameState.UnModifiable;
		}

		// Token: 0x0603850C RID: 230668 RVA: 0x00E4197A File Offset: 0x00E3FB7A
		public void SetLevel(int level)
		{
			this.PersonalInfoData.Level = level;
		}

		// Token: 0x0603850D RID: 230669 RVA: 0x00E41988 File Offset: 0x00E3FB88
		public void SetWorldLevel(int worldLevel)
		{
			this.PersonalInfoData.WorldLevel = worldLevel;
		}

		// Token: 0x0603850E RID: 230670 RVA: 0x00E41998 File Offset: 0x00E3FB98
		public bool CheckCanShowPersonalTip()
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig("IndividualizationReddotConditionGroup");
			return ControllerBase<LevelGeneralController>.Instance.CheckCondition(intConfig.ToString(), null, true, Array.Empty<object>()) && LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.ShowPersonalTip, true);
		}

		// Token: 0x0603850F RID: 230671 RVA: 0x00E419DA File Offset: 0x00E3FBDA
		public void SetPersonalTipState(bool state)
		{
			if (this.CheckCanShowPersonalTip() == state)
			{
				return;
			}
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.ShowPersonalTip, state);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnPersonalTipStateSet);
		}

		// Token: 0x06038510 RID: 230672 RVA: 0x00E41A00 File Offset: 0x00E3FC00
		[NullableContext(2)]
		public PlayerHeadData GetPlayerHeadData(int playerHeadId, bool needLog = true)
		{
			PlayerHeadData playerHeadData;
			this.PlayerHeadDataMap.TryGetValue(playerHeadId, out playerHeadData);
			if (playerHeadData == null && needLog)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Personal;
				ELogAuthor author = ELogAuthor.BB;
				string message = "获取玩家头像数据失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("playerHeadId", playerHeadId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return playerHeadData;
		}

		// Token: 0x06038511 RID: 230673 RVA: 0x00E41A54 File Offset: 0x00E3FC54
		public List<PlayerHeadData> GetPlayerShowHeadDataList()
		{
			List<PlayerHeadData> list = new List<PlayerHeadData>();
			int? curSelectMainRoleId = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleId();
			int sex = this.GetSex();
			foreach (KeyValuePair<int, PlayerHeadData> keyValuePair in this.PlayerHeadDataMap)
			{
				PlayerHeadData value = keyValuePair.Value;
				int num;
				if (!this.HeadDataToMainRoleSkinMap.TryGetValue(value.Id, out num) || (curSelectMainRoleId != null && curSelectMainRoleId.Value == num))
				{
					int gender = value.Config.Gender;
					if (gender == -1 || gender == sex)
					{
						list.Add(value);
					}
				}
			}
			list.Sort(new Comparison<PlayerHeadData>(this.SortPlayerHeadList));
			return list;
		}

		// Token: 0x06038512 RID: 230674 RVA: 0x00E41B24 File Offset: 0x00E3FD24
		private int SortPlayerHeadList(PlayerHeadData playerHeadA, PlayerHeadData playerHeadB)
		{
			int num = (playerHeadA.Lock > false) ? 1 : 0;
			int num2 = (playerHeadB.Lock > false) ? 1 : 0;
			if (num != num2)
			{
				return num - num2;
			}
			if (playerHeadB.Config.SortIndex != playerHeadA.Config.SortIndex)
			{
				return playerHeadB.Config.SortIndex - playerHeadA.Config.SortIndex;
			}
			return playerHeadB.Config.Id - playerHeadA.Config.Id;
		}

		// Token: 0x06038513 RID: 230675 RVA: 0x00E41BA8 File Offset: 0x00E3FDA8
		public int GetUnlockHeadNum()
		{
			int num = 0;
			using (List<PlayerHeadData>.Enumerator enumerator = this.GetPlayerShowHeadDataList().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.Lock)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x06038514 RID: 230676 RVA: 0x00E41C04 File Offset: 0x00E3FE04
		public void SetSex(int sex)
		{
			this.PersonalInfoData.Sex = sex;
		}

		// Token: 0x06038515 RID: 230677 RVA: 0x00E41C12 File Offset: 0x00E3FE12
		public int GetSex()
		{
			return this.PersonalInfoData.Sex;
		}

		// Token: 0x06038516 RID: 230678 RVA: 0x00E41C20 File Offset: 0x00E3FE20
		public void InitPlayerTitleData(PlayerTitleInfo[] playerTitleInfoList, PlayerTitleLimitInfo[] playerTitleLimitInfoList = null)
		{
			this.PlayerTitleDataMap.Clear();
			foreach (PlayerTitleInfo playerTitleInfo in playerTitleInfoList)
			{
				PersonalPlayerTitleData personalPlayerTitleData = new PersonalPlayerTitleData(playerTitleInfo.PlayerTitleId, playerTitleInfo.IsUnlock);
				if (playerTitleInfo.ConditionTask != null)
				{
					if (playerTitleInfo.ConditionTask.Status == ConditionTaskState.ConditionTaskFinish)
					{
						personalPlayerTitleData.SetUnLockProgress(playerTitleInfo.ConditionTask.Target, playerTitleInfo.ConditionTask.Target);
					}
					else
					{
						personalPlayerTitleData.SetUnLockProgress(playerTitleInfo.ConditionTask.Current, playerTitleInfo.ConditionTask.Target);
					}
				}
				if (playerTitleInfo.ExtraInfo != 0)
				{
					personalPlayerTitleData.SetStarLevel(playerTitleInfo.ExtraInfo);
				}
				if (playerTitleInfo.UnlockTime != 0L)
				{
					long num = Singleton<MathUtils>.Instance.LongToNumber(playerTitleInfo.UnlockTime);
					personalPlayerTitleData.SetUnlockTime((double)num);
				}
				this.PlayerTitleDataMap[playerTitleInfo.PlayerTitleId] = personalPlayerTitleData;
			}
			if (playerTitleLimitInfoList != null)
			{
				foreach (PlayerTitleLimitInfo playerTitleLimitInfo in playerTitleLimitInfoList)
				{
					if (this.PlayerTitleDataMap.ContainsKey(playerTitleLimitInfo.PlayerTitleId))
					{
						PersonalPlayerTitleData personalPlayerTitleData2 = this.PlayerTitleDataMap[playerTitleLimitInfo.PlayerTitleId];
						if (playerTitleLimitInfo.BeginTime != 0L && playerTitleLimitInfo.EndTime != 0L)
						{
							double startTime = (double)Singleton<MathUtils>.Instance.LongToNumber(playerTitleLimitInfo.BeginTime);
							double endTime = (double)Singleton<MathUtils>.Instance.LongToNumber(playerTitleLimitInfo.EndTime);
							personalPlayerTitleData2.SetTimeLimit(startTime, endTime);
						}
					}
				}
			}
			this.PersonalInfoData.PlayerTitleDataList = this.PlayerTitleDataMap.Values.ToList<PersonalPlayerTitleData>();
			Singleton<EventSystem>.Instance.Emit(EEventName.OnPlayerTitleRefreshRedDot);
		}

		// Token: 0x06038517 RID: 230679 RVA: 0x00E41DB4 File Offset: 0x00E3FFB4
		public void SetDressedPlayerTitle(int playerTitleId, int? starLevel = null)
		{
			this.PersonalInfoData.CurPlayerTitleId = new int?(playerTitleId);
			this.PersonalInfoData.CurPlayerTitleLevel = starLevel;
			PersonalPlayerTitleData personalPlayerTitleData;
			this.PlayerTitleDataMap.TryGetValue(playerTitleId, out personalPlayerTitleData);
			if (personalPlayerTitleData != null && starLevel != null)
			{
				personalPlayerTitleData.StarLevel = starLevel;
			}
			if (playerTitleId > 0 && personalPlayerTitleData != null && personalPlayerTitleData.IsExpired())
			{
				this.PersonalInfoData.CurPlayerTitleId = new int?(0);
				this.PersonalInfoData.CurPlayerTitleLevel = new int?(0);
				ModelBase<PlayerInfoModel>.Instance.ChangeNumberProp(15, 0);
			}
			else
			{
				ModelBase<PlayerInfoModel>.Instance.ChangeNumberProp(15, playerTitleId);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnPlayerTitleChange);
		}

		// Token: 0x06038518 RID: 230680 RVA: 0x00E41E60 File Offset: 0x00E40060
		public void UpdateUnDressedPlayerTitleList(PlayerTitleInfo[] playerTitleInfoList)
		{
			foreach (PlayerTitleInfo playerTitleInfo in playerTitleInfoList)
			{
				PersonalPlayerTitleData personalPlayerTitleData;
				this.PlayerTitleDataMap.TryGetValue(playerTitleInfo.PlayerTitleId, out personalPlayerTitleData);
				if (personalPlayerTitleData == null)
				{
					return;
				}
				if (playerTitleInfo.ExtraInfo != 0)
				{
					personalPlayerTitleData.SetStarLevel(playerTitleInfo.ExtraInfo);
				}
				if (playerTitleInfo.ConditionTask != null)
				{
					if (playerTitleInfo.ConditionTask.Status == ConditionTaskState.ConditionTaskFinish)
					{
						personalPlayerTitleData.SetUnLockProgress(playerTitleInfo.ConditionTask.Target, playerTitleInfo.ConditionTask.Target);
					}
					else
					{
						personalPlayerTitleData.SetUnLockProgress(playerTitleInfo.ConditionTask.Current, playerTitleInfo.ConditionTask.Target);
					}
				}
				if (playerTitleInfo.IsUnlock != personalPlayerTitleData.IsUnLock)
				{
					this.CurrentNewUnLockTitleArray.Add(personalPlayerTitleData);
					long num = Singleton<MathUtils>.Instance.LongToNumber(playerTitleInfo.UnlockTime);
					personalPlayerTitleData.UnLock((double)num);
					Dictionary<int, bool> dictionary = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.PlayerTitleRecord, null) ?? new Dictionary<int, bool>();
					dictionary[playerTitleInfo.PlayerTitleId] = true;
					LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.PlayerTitleRecord, dictionary);
					Singleton<EventSystem>.Instance.Emit(EEventName.OnPlayerTitleRefreshRedDot);
					Singleton<EventSystem>.Instance.Emit(EEventName.OnPlayerTitleUnlock);
				}
			}
		}

		// Token: 0x06038519 RID: 230681 RVA: 0x00E41F84 File Offset: 0x00E40184
		[NullableContext(2)]
		public PersonalPlayerTitleData GetDressedPlayerTitleData()
		{
			int key = 0;
			if (this.PersonalInfoData.CurPlayerTitleId != null)
			{
				int? curPlayerTitleId = this.PersonalInfoData.CurPlayerTitleId;
				int num = 0;
				if (curPlayerTitleId.GetValueOrDefault() > num & curPlayerTitleId != null)
				{
					key = this.PersonalInfoData.CurPlayerTitleId.Value;
				}
			}
			PersonalPlayerTitleData result;
			this.PlayerTitleDataMap.TryGetValue(key, out result);
			return result;
		}

		// Token: 0x0603851A RID: 230682 RVA: 0x00E41FE8 File Offset: 0x00E401E8
		public int GetDressedPlayerTitleId()
		{
			if (this.PersonalInfoData.CurPlayerTitleId != null)
			{
				int? curPlayerTitleId = this.PersonalInfoData.CurPlayerTitleId;
				int num = 0;
				if (curPlayerTitleId.GetValueOrDefault() > num & curPlayerTitleId != null)
				{
					PersonalPlayerTitleData personalPlayerTitleData;
					this.PlayerTitleDataMap.TryGetValue(this.PersonalInfoData.CurPlayerTitleId.Value, out personalPlayerTitleData);
					if (personalPlayerTitleData != null && personalPlayerTitleData.IsExpired())
					{
						return 0;
					}
					return this.PersonalInfoData.CurPlayerTitleId.Value;
				}
			}
			return 0;
		}

		// Token: 0x0603851B RID: 230683 RVA: 0x00E42068 File Offset: 0x00E40268
		public int GetDressedPlayerTitleLevel()
		{
			if (this.PersonalInfoData.CurPlayerTitleLevel != null)
			{
				int? curPlayerTitleLevel = this.PersonalInfoData.CurPlayerTitleLevel;
				int num = 0;
				if (curPlayerTitleLevel.GetValueOrDefault() > num & curPlayerTitleLevel != null)
				{
					return this.PersonalInfoData.CurPlayerTitleLevel.Value;
				}
			}
			return 0;
		}

		// Token: 0x0603851C RID: 230684 RVA: 0x00E420BC File Offset: 0x00E402BC
		[NullableContext(2)]
		public PersonalPlayerTitleData GetPlayerTitleData(int playerTitleId)
		{
			PersonalPlayerTitleData result;
			this.PlayerTitleDataMap.TryGetValue(playerTitleId, out result);
			return result;
		}

		// Token: 0x0603851D RID: 230685 RVA: 0x00E420DC File Offset: 0x00E402DC
		public int GetPlayerTitleStarLevel(int playerTitleId)
		{
			PersonalPlayerTitleData personalPlayerTitleData;
			this.PlayerTitleDataMap.TryGetValue(playerTitleId, out personalPlayerTitleData);
			if (personalPlayerTitleData == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Personal;
				ELogAuthor author = ELogAuthor.CXJ;
				string message = "称号id无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("playerTitleId", playerTitleId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return 0;
			}
			return personalPlayerTitleData.StarLevel.GetValueOrDefault();
		}

		// Token: 0x0603851E RID: 230686 RVA: 0x00E42134 File Offset: 0x00E40334
		public List<PersonalPlayerTitleData> GetPlayerTitleList()
		{
			List<PersonalPlayerTitleData> list = (from playerTitleData in this.PlayerTitleDataMap.Values
			where !playerTitleData.IsExpired()
			select playerTitleData).ToList<PersonalPlayerTitleData>();
			list.Sort(delegate(PersonalPlayerTitleData playerTitleDataA, PersonalPlayerTitleData playerTitleDataB)
			{
				bool flag = playerTitleDataA.IsEffective();
				bool flag2 = playerTitleDataB.IsEffective();
				if (flag != flag2)
				{
					return ((flag2 > false) - (flag > false)) ? 1 : 0;
				}
				PlayerTitle? config = ConfigPlayerTitleById.GetConfig(playerTitleDataA.PlayerTitleId, true);
				PlayerTitle? config2 = ConfigPlayerTitleById.GetConfig(playerTitleDataB.PlayerTitleId, true);
				if (config == null || config2 == null)
				{
					return 0;
				}
				if (config != null && config2 != null && config.Value.SortIndex != config2.Value.SortIndex)
				{
					return config2.Value.SortIndex - config.Value.SortIndex;
				}
				return playerTitleDataB.PlayerTitleId - playerTitleDataA.PlayerTitleId;
			});
			return list;
		}

		// Token: 0x0603851F RID: 230687 RVA: 0x00E4219C File Offset: 0x00E4039C
		public int GetUnlockTitleDataCount()
		{
			int num = 0;
			using (List<PersonalPlayerTitleData>.Enumerator enumerator = this.GetPlayerTitleList().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsEffective())
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x06038520 RID: 230688 RVA: 0x00E421F8 File Offset: 0x00E403F8
		public string GetPlayerTitleInfoString(int playerTitleId, int playerTitleStarLevel, bool isNeedLineBreaks = false)
		{
			PlayerTitle? config = ConfigPlayerTitleById.GetConfig(playerTitleId, true);
			string text = null;
			if (!string.IsNullOrEmpty((config != null) ? config.GetValueOrDefault().ActvityName : null))
			{
				text = ConfigMultiTextLang.GetLocalTextNew(config.Value.ActvityName, null);
			}
			string text2 = null;
			if (!string.IsNullOrEmpty((config != null) ? config.GetValueOrDefault().SeasonName : null))
			{
				text2 = ConfigMultiTextLang.GetLocalTextNew(config.Value.SeasonName, null);
			}
			string text3 = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew(config.Value.HonorDescription, null), new string[]
			{
				playerTitleStarLevel.ToString()
			});
			if (string.IsNullOrEmpty(text) && string.IsNullOrEmpty(text2))
			{
				return text3;
			}
			string text4 = isNeedLineBreaks ? "\n" : "";
			string result;
			if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text2))
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 4);
				defaultInterpolatedStringHandler.AppendFormatted(text);
				defaultInterpolatedStringHandler.AppendLiteral("·");
				defaultInterpolatedStringHandler.AppendFormatted(text2);
				defaultInterpolatedStringHandler.AppendLiteral("——");
				defaultInterpolatedStringHandler.AppendFormatted(text4);
				defaultInterpolatedStringHandler.AppendFormatted(text3);
				result = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			else
			{
				result = ((!string.IsNullOrEmpty(text)) ? text : text2) + "——" + text4 + text3;
			}
			return result;
		}

		// Token: 0x0402020A RID: 131594
		[Nullable(2)]
		public PersonalInfoData UiCachePersonalData;

		// Token: 0x0402020B RID: 131595
		[Nullable(2)]
		private PersonalInfoData PersonalInfoData;

		// Token: 0x0402020C RID: 131596
		private readonly Dictionary<int, PlayerHeadData> PlayerHeadDataMap = new Dictionary<int, PlayerHeadData>();

		// Token: 0x0402020D RID: 131597
		private readonly Dictionary<int, int> HeadDataToMainRoleSkinMap = new Dictionary<int, int>();

		// Token: 0x0402020E RID: 131598
		private readonly Dictionary<int, PersonalPlayerTitleData> PlayerTitleDataMap = new Dictionary<int, PersonalPlayerTitleData>();

		// Token: 0x0402020F RID: 131599
		public List<PersonalPlayerTitleData> CurrentNewUnLockTitleArray = new List<PersonalPlayerTitleData>();
	}
}
