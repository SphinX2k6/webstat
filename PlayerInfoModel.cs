using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x020025F9 RID: 9721
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class PlayerInfoModel : ModelBase<PlayerInfoModel>
{
	// Token: 0x060130B5 RID: 78005 RVA: 0x00547C66 File Offset: 0x00545E66
	public int? GetId()
	{
		return new int?(this.Id);
	}

	// Token: 0x060130B6 RID: 78006 RVA: 0x00547C74 File Offset: 0x00545E74
	public void SetId(int id)
	{
		this.Id = id;
		LocalStorage.SetGlobal<int>(ELocalStorageGlobalKey.RecentlyLoginUID, id);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Log;
		ELogAuthor author = ELogAuthor.YYZ;
		string message = "设置当前UID";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("UID", id);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.ChangePlayerInfoId, id);
	}

	// Token: 0x060130B7 RID: 78007 RVA: 0x00547CCD File Offset: 0x00545ECD
	public int[] GetIconList()
	{
		return this.IconList;
	}

	// Token: 0x060130B8 RID: 78008 RVA: 0x00547CD5 File Offset: 0x00545ED5
	public void SetIconList(int[] iconList)
	{
		this.IconList = iconList;
	}

	// Token: 0x060130B9 RID: 78009 RVA: 0x00547CDE File Offset: 0x00545EDE
	public int[] GetFrameList()
	{
		return this.FrameList;
	}

	// Token: 0x060130BA RID: 78010 RVA: 0x00547CE6 File Offset: 0x00545EE6
	public void SetFrameList(int[] frameList)
	{
		this.FrameList = frameList;
	}

	// Token: 0x060130BB RID: 78011 RVA: 0x00547CEF File Offset: 0x00545EEF
	public Dictionary<int, int> GetNumberProp()
	{
		return this.NumberProp;
	}

	// Token: 0x060130BC RID: 78012 RVA: 0x00547CF7 File Offset: 0x00545EF7
	public void SetNumberProp(Dictionary<int, int> numberProp)
	{
		this.NumberProp = numberProp;
	}

	// Token: 0x060130BD RID: 78013 RVA: 0x00547D00 File Offset: 0x00545F00
	public Dictionary<int, string> GetStringProp()
	{
		return this.StringProp;
	}

	// Token: 0x060130BE RID: 78014 RVA: 0x00547D08 File Offset: 0x00545F08
	public void SetStringProp(Dictionary<int, string> stringProp)
	{
		this.StringProp = stringProp;
	}

	// Token: 0x060130BF RID: 78015 RVA: 0x00547D11 File Offset: 0x00545F11
	public void SetPlayerName(string name)
	{
		this.ChangeStringProp(7, name);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnNameChange);
	}

	// Token: 0x060130C0 RID: 78016 RVA: 0x00547D2C File Offset: 0x00545F2C
	public void UpdatePlayerAttributeNumberInfo(Dictionary<int, int> attrIntMap)
	{
		int num = 0;
		int? num2 = null;
		if (attrIntMap.ContainsKey(0))
		{
			num = this.GetPlayerLevel().GetValueOrDefault();
		}
		if (attrIntMap.ContainsKey(1))
		{
			num2 = this.GetPlayerExp();
		}
		foreach (KeyValuePair<int, int> keyValuePair in attrIntMap)
		{
			this.ChangeNumberProp(keyValuePair.Key, keyValuePair.Value);
		}
		int valueOrDefault = this.GetPlayerExp().GetValueOrDefault();
		int valueOrDefault2 = this.GetPlayerLevel().GetValueOrDefault();
		FunctionConfig instance = ConfigBase<FunctionConfig>.Instance;
		if (num <= 0 || num >= valueOrDefault2 || num2 == null)
		{
			if (num2 != null)
			{
				int? num3 = num2;
				int num4 = valueOrDefault;
				if (num3.GetValueOrDefault() < num4 & num3 != null)
				{
					int levelExp = instance.GetPlayerLevelConfig(valueOrDefault2).Value.LevelExp;
					Singleton<EventSystem>.Instance.Emit<int, int, int>(EEventName.OnPlayerExpChanged, valueOrDefault, num2.Value, levelExp);
				}
			}
			return;
		}
		IReadOnlyList<PlayerExp> rangePlayerExpConfig = instance.GetRangePlayerExpConfig(num, valueOrDefault2);
		if (rangePlayerExpConfig == null || rangePlayerExpConfig.Count < 1)
		{
			return;
		}
		PlayerExp playerExp = rangePlayerExpConfig[0];
		PlayerExp playerExp2 = rangePlayerExpConfig[rangePlayerExpConfig.Count - 1];
		int levelExp2 = playerExp.LevelExp;
		int totalExp = this.GetTotalExp(rangePlayerExpConfig, num2.Value, valueOrDefault);
		int levelExp3 = playerExp2.LevelExp;
		ControllerBase<KuroSdkController>.Instance.PostKuroSdkEvent(EKuroSdkEventKey.KUROSDKLEVEUPROLE);
		Singleton<EventSystem>.Instance.Emit<int, int, int, int, int, int, int>(EEventName.OnPlayerLevelChanged, num, valueOrDefault2, valueOrDefault, num2.Value, totalExp, levelExp3, levelExp2);
	}

	// Token: 0x060130C1 RID: 78017 RVA: 0x00547EE0 File Offset: 0x005460E0
	public void ChangeNumberProp(int key, int value)
	{
		if (this.NumberProp != null)
		{
			this.NumberProp[key] = value;
		}
		if (key == 13 || key == 2 || key == 3)
		{
			int? playerMoneyItemId = this.GetPlayerMoneyItemId((EPlayerInfoNumber)key);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPlayerCurrencyChange, playerMoneyItemId.Value);
		}
	}

	// Token: 0x060130C2 RID: 78018 RVA: 0x00547F30 File Offset: 0x00546130
	public void ChangeStringProp(int key, string value)
	{
		if (this.StringProp != null)
		{
			this.StringProp[key] = value;
		}
	}

	// Token: 0x060130C3 RID: 78019 RVA: 0x00547F48 File Offset: 0x00546148
	public void UpdatePlayerAttributeStringInfo(Dictionary<int, string> attrStringMap)
	{
		foreach (KeyValuePair<int, string> keyValuePair in attrStringMap)
		{
			this.ChangeStringProp(keyValuePair.Key, keyValuePair.Value);
		}
	}

	// Token: 0x060130C4 RID: 78020 RVA: 0x00547FA4 File Offset: 0x005461A4
	private int GetTotalExp(IReadOnlyList<PlayerExp> playerExpConfigList, int sourceExp, int targetExp)
	{
		int num = 0;
		foreach (PlayerExp playerExp in playerExpConfigList)
		{
			num += playerExp.LevelExp;
		}
		return num - sourceExp + targetExp;
	}

	// Token: 0x060130C5 RID: 78021 RVA: 0x00547FF8 File Offset: 0x005461F8
	public int? GetNumberPropById(EPlayerInfoNumber key)
	{
		if (this.NumberProp == null)
		{
			return null;
		}
		int value;
		if (!this.NumberProp.TryGetValue((int)key, out value))
		{
			return null;
		}
		return new int?(value);
	}

	// Token: 0x060130C6 RID: 78022 RVA: 0x00548037 File Offset: 0x00546237
	public void SetNumberPropById(EPlayerInfoNumber key, int value)
	{
		if (this.NumberProp == null)
		{
			return;
		}
		this.NumberProp[(int)key] = value;
	}

	// Token: 0x060130C7 RID: 78023 RVA: 0x00548050 File Offset: 0x00546250
	[NullableContext(2)]
	public string GetStringPropById(EPlayerInfoNumber key)
	{
		if (this.StringProp == null)
		{
			return null;
		}
		string result;
		if (!this.StringProp.TryGetValue((int)key, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x060130C8 RID: 78024 RVA: 0x0054807C File Offset: 0x0054627C
	public EPlayerGender GetPlayerGender()
	{
		int? numberPropById = this.GetNumberPropById(EPlayerInfoNumber.Sex);
		if (numberPropById == null)
		{
			return EPlayerGender.None;
		}
		return (EPlayerGender)numberPropById.Value;
	}

	// Token: 0x060130C9 RID: 78025 RVA: 0x005480A4 File Offset: 0x005462A4
	public int GetPlayerMoney(int itemId)
	{
		if (itemId == 2)
		{
			return this.GetNumberPropById(EPlayerInfoNumber.MoneyGold).GetValueOrDefault();
		}
		if (itemId == 3)
		{
			return this.GetNumberPropById(EPlayerInfoNumber.MoneyDiamond).GetValueOrDefault();
		}
		if (itemId == 4)
		{
			return this.GetNumberPropById(EPlayerInfoNumber.CashCoin).GetValueOrDefault();
		}
		if (itemId == 5)
		{
			return ModelBase<PowerModel>.Instance.GetPowerDataById(5).GetCurrentPower();
		}
		if (itemId == 6)
		{
			return ModelBase<PowerModel>.Instance.GetPowerDataById(6).GetCurrentPower();
		}
		return 0;
	}

	// Token: 0x060130CA RID: 78026 RVA: 0x0054811C File Offset: 0x0054631C
	public int? GetPlayerMoneyItemId(EPlayerInfoNumber type)
	{
		if (type == EPlayerInfoNumber.MoneyGold)
		{
			return new int?(2);
		}
		if (type == EPlayerInfoNumber.MoneyDiamond)
		{
			return new int?(3);
		}
		if (type == EPlayerInfoNumber.CashCoin)
		{
			return new int?(4);
		}
		return null;
	}

	// Token: 0x060130CB RID: 78027 RVA: 0x00548154 File Offset: 0x00546354
	[NullableContext(2)]
	public string GetAccountName(bool bCheckConfig = true)
	{
		if (this.StringProp == null)
		{
			return null;
		}
		if (!bCheckConfig)
		{
			return ModelBase<FunctionModel>.Instance.GetPlayerName();
		}
		if (!ConfigBase<PlayerInfoConfig>.Instance.GetIsUseAccountName())
		{
			int playerRoleId = this.GetPlayerRoleId();
			return ModelBase<RoleModel>.Instance.GetRoleInstanceById(playerRoleId).GetRoleRealName();
		}
		return ModelBase<FunctionModel>.Instance.GetPlayerName();
	}

	// Token: 0x060130CC RID: 78028 RVA: 0x005481A8 File Offset: 0x005463A8
	public bool IsPlayerId(int roleId, int? playerId = null)
	{
		int? num = playerId;
		int? num2 = (num != null) ? num : this.GetId();
		int playerRoleId = this.GetPlayerRoleId();
		num = num2;
		int? id = this.GetId();
		return (num.GetValueOrDefault() == id.GetValueOrDefault() & num != null == (id != null)) && roleId == playerRoleId;
	}

	// Token: 0x060130CD RID: 78029 RVA: 0x00548204 File Offset: 0x00546404
	public int GetPlayerRoleId()
	{
		return ModelBase<RoleModel>.Instance.GetCurSelectMainRoleId().GetValueOrDefault();
	}

	// Token: 0x060130CE RID: 78030 RVA: 0x00548224 File Offset: 0x00546424
	public string GetPlayerHeadIconBig()
	{
		int? numberPropById = this.GetNumberPropById(EPlayerInfoNumber.HeadPhoto);
		if (numberPropById != null)
		{
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(numberPropById.Value);
			if (roleConfig != null)
			{
				return roleConfig.Value.RoleHeadIconBig;
			}
		}
		return "";
	}

	// Token: 0x060130CF RID: 78031 RVA: 0x00548274 File Offset: 0x00546474
	public string GetPlayerHeadIconLarge()
	{
		int? numberPropById = this.GetNumberPropById(EPlayerInfoNumber.HeadPhoto);
		if (numberPropById != null)
		{
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(numberPropById.Value);
			if (roleConfig != null)
			{
				return roleConfig.Value.RoleHeadIconLarge;
			}
		}
		return "";
	}

	// Token: 0x060130D0 RID: 78032 RVA: 0x005482C4 File Offset: 0x005464C4
	public string GetPlayerHeadIconCircle()
	{
		int? numberPropById = this.GetNumberPropById(EPlayerInfoNumber.HeadPhoto);
		if (numberPropById != null)
		{
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(numberPropById.Value);
			if (roleConfig != null)
			{
				return roleConfig.Value.RoleHeadIconCircle;
			}
		}
		return "";
	}

	// Token: 0x060130D1 RID: 78033 RVA: 0x00548314 File Offset: 0x00546514
	public int GetHeadIconId()
	{
		int? numberPropById = this.GetNumberPropById(EPlayerInfoNumber.HeadPhoto);
		if (numberPropById != null)
		{
			return numberPropById.Value;
		}
		return 0;
	}

	// Token: 0x060130D2 RID: 78034 RVA: 0x0054833C File Offset: 0x0054653C
	[NullableContext(2)]
	public string GetPlayerStand()
	{
		EPlayerGender playerGender = this.GetPlayerGender();
		if (playerGender == EPlayerGender.Male)
		{
			return ConfigBase<PlayerInfoConfig>.Instance.GetMaleStandPath();
		}
		if (playerGender == EPlayerGender.Female)
		{
			return ConfigBase<PlayerInfoConfig>.Instance.GetFemaleStandPath();
		}
		return null;
	}

	// Token: 0x060130D3 RID: 78035 RVA: 0x0054836E File Offset: 0x0054656E
	public int? GetPlayerLevel()
	{
		return this.GetNumberPropById(EPlayerInfoNumber.Level);
	}

	// Token: 0x060130D4 RID: 78036 RVA: 0x00548377 File Offset: 0x00546577
	public int? GetPlayerExp()
	{
		return this.GetNumberPropById(EPlayerInfoNumber.Experience);
	}

	// Token: 0x060130D5 RID: 78037 RVA: 0x00548380 File Offset: 0x00546580
	[NullableContext(2)]
	public string GetPlayerName()
	{
		return this.GetStringPropById(EPlayerInfoNumber.Name);
	}

	// Token: 0x060130D6 RID: 78038 RVA: 0x00548389 File Offset: 0x00546589
	public int GetRandomSeed()
	{
		return this.RandomSeed;
	}

	// Token: 0x060130D7 RID: 78039 RVA: 0x00548394 File Offset: 0x00546594
	public int AdvanceRandomSeed(ERandomReason reason)
	{
		int randomSeed = this.RandomSeed;
		this.RandomSeed = RandomSystem.IterateRandomSeed(randomSeed, reason);
		return randomSeed;
	}

	// Token: 0x060130D8 RID: 78040 RVA: 0x005483B6 File Offset: 0x005465B6
	public void InitThirdPartyId(string userId, string onlineId, string accountId)
	{
		this.UserId = userId;
		this.OnlineId = onlineId;
		this.AccountId = accountId;
		Singleton<EventSystem>.Instance.Emit<string, string, string>(EEventName.TsSyncThirdPartyInfo, userId, onlineId, accountId);
	}

	// Token: 0x060130D9 RID: 78041 RVA: 0x005483E0 File Offset: 0x005465E0
	[NullableContext(2)]
	public string GetThirdPartyUserId()
	{
		return this.UserId;
	}

	// Token: 0x060130DA RID: 78042 RVA: 0x005483E8 File Offset: 0x005465E8
	[NullableContext(2)]
	public string GetThirdPartyOnlineId()
	{
		return this.OnlineId;
	}

	// Token: 0x060130DB RID: 78043 RVA: 0x005483F0 File Offset: 0x005465F0
	[NullableContext(2)]
	public string GetThirdPartyAccountId()
	{
		return this.AccountId;
	}

	// Token: 0x040094A3 RID: 38051
	private int Id;

	// Token: 0x040094A4 RID: 38052
	private int[] IconList = Array.Empty<int>();

	// Token: 0x040094A5 RID: 38053
	private int[] FrameList = Array.Empty<int>();

	// Token: 0x040094A6 RID: 38054
	private Dictionary<int, int> NumberProp = new Dictionary<int, int>();

	// Token: 0x040094A7 RID: 38055
	private Dictionary<int, string> StringProp = new Dictionary<int, string>();

	// Token: 0x040094A8 RID: 38056
	private string UserId = "";

	// Token: 0x040094A9 RID: 38057
	private string OnlineId = "";

	// Token: 0x040094AA RID: 38058
	private string AccountId = "";

	// Token: 0x040094AB RID: 38059
	public int RandomSeed;

	// Token: 0x040094AC RID: 38060
	public bool NewbieGuideV2;
}
