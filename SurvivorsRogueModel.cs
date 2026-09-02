using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02002B8A RID: 11146
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class SurvivorsRogueModel : ModelBase<SurvivorsRogueModel>
{
	// Token: 0x17001CE6 RID: 7398
	// (get) Token: 0x06016343 RID: 90947 RVA: 0x00628F13 File Offset: 0x00627113
	// (set) Token: 0x06016344 RID: 90948 RVA: 0x00628F1C File Offset: 0x0062711C
	public int CurLevelId
	{
		get
		{
			return this.CurLevelIdInternal;
		}
		set
		{
			this.CurLevelIdInternal = value;
			this.MaxWaveNum = ConfigBase<SurvivorsRogueConfig>.Instance.GetMaxWaveNumByLevelId(value);
			this.WaveTypeArray = new int[this.MaxWaveNum];
			for (int i = 0; i < this.MaxWaveNum; i++)
			{
				this.WaveTypeArray[i] = ConfigBase<SurvivorsRogueConfig>.Instance.GetWaveType(value, i + 1);
			}
			this.CurComboConfig = ConfigBase<SurvivorsRogueConfig>.Instance.GetComboConfig(value);
		}
	}

	// Token: 0x17001CE7 RID: 7399
	// (get) Token: 0x06016345 RID: 90949 RVA: 0x00628F8A File Offset: 0x0062718A
	public int CurRoleId
	{
		get
		{
			SurvivorsRoleGainData roleGainData = this.GainData.GetRoleGainData();
			if (roleGainData == null)
			{
				return 0;
			}
			return roleGainData.ConfigId;
		}
	}

	// Token: 0x17001CE8 RID: 7400
	// (get) Token: 0x06016346 RID: 90950 RVA: 0x00628FA2 File Offset: 0x006271A2
	public int CurRoleLevel
	{
		get
		{
			SurvivorsRoleGainData roleGainData = this.GainData.GetRoleGainData();
			if (roleGainData == null)
			{
				return 0;
			}
			return roleGainData.Data.Level;
		}
	}

	// Token: 0x17001CE9 RID: 7401
	// (get) Token: 0x06016347 RID: 90951 RVA: 0x00628FBF File Offset: 0x006271BF
	public int CurWaveRemainTime
	{
		get
		{
			return ConfigBase<SurvivorsRogueConfig>.Instance.GetWaveDuration(this.CurLevelId, this.CurWaveNum);
		}
	}

	// Token: 0x17001CEA RID: 7402
	// (get) Token: 0x06016348 RID: 90952 RVA: 0x00628FD7 File Offset: 0x006271D7
	public bool IsEndlessWave
	{
		get
		{
			return ConfigBase<SurvivorsRogueConfig>.Instance.GetWaveType(this.CurLevelId, this.CurWaveNum) == 2 && this.BattleData.EndlessWaveEnabled;
		}
	}

	// Token: 0x17001CEB RID: 7403
	// (get) Token: 0x06016349 RID: 90953 RVA: 0x00628FFF File Offset: 0x006271FF
	public bool IsBonusWave
	{
		get
		{
			return ConfigBase<SurvivorsRogueConfig>.Instance.IsBonusWave(this.CurLevelId, this.CurWaveNum);
		}
	}

	// Token: 0x17001CEC RID: 7404
	// (get) Token: 0x0601634A RID: 90954 RVA: 0x00629017 File Offset: 0x00627217
	public int CurWaveNum
	{
		get
		{
			return this.BattleData.GetBatch();
		}
	}

	// Token: 0x0601634B RID: 90955 RVA: 0x00629024 File Offset: 0x00627224
	public unsafe void InitComboEnhanceCfg(IList<ComboParamInfo> params_)
	{
		if (params_ == null || params_.Count != 4)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SurvivorsRogue;
			ELogAuthor author = ELogAuthor.CK;
			string message = "幸存者连杀等级配置数量不匹配";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("合法数量", 4);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("实际数量", (params_ != null) ? params_.Count : 0);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		for (int i = 0; i < 4; i++)
		{
			this.ComboTimerFreezeTimeCfg[i] = params_[i].KeepTime;
			this.ComboDurationAdditionCfg[i] = params_[i].AddTime;
		}
	}

	// Token: 0x17001CED RID: 7405
	// (get) Token: 0x0601634C RID: 90956 RVA: 0x006290DD File Offset: 0x006272DD
	// (set) Token: 0x0601634D RID: 90957 RVA: 0x006290E8 File Offset: 0x006272E8
	public SurvivorsRogueModel.EWaveTipsState WaveTipsState
	{
		get
		{
			return this.WaveTipsStateInternal;
		}
		set
		{
			if (this.WaveTipsStateInternal == value)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SurvivorsRogue;
				ELogAuthor author = ELogAuthor.CK;
				string message = "重复设置WaveTipsState, 直接跳过";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("State", value);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.WaveTipsStateInternal = value;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.SurvivorsRogueSwitchWaveTipsState, (int)value);
		}
	}

	// Token: 0x17001CEE RID: 7406
	// (get) Token: 0x0601634E RID: 90958 RVA: 0x00629146 File Offset: 0x00627346
	public bool NeedOpenActivityMainView
	{
		get
		{
			bool hasNewSettle = this.HasNewSettle;
			this.HasNewSettle = false;
			return hasNewSettle;
		}
	}

	// Token: 0x0601634F RID: 90959 RVA: 0x00629155 File Offset: 0x00627355
	public void SetCurrentActivityId(int id)
	{
		this.CurrentActivityIdInternal = id;
	}

	// Token: 0x06016350 RID: 90960 RVA: 0x0062915E File Offset: 0x0062735E
	public bool IsActivityOn()
	{
		return this.CurrentActivityIdInternal != 0;
	}

	// Token: 0x17001CEF RID: 7407
	// (get) Token: 0x06016351 RID: 90961 RVA: 0x00629169 File Offset: 0x00627369
	[Nullable(2)]
	public global::SurvivorsActivityData ActivityData
	{
		[NullableContext(2)]
		get
		{
			if (this.CurrentActivityIdInternal == 0)
			{
				return null;
			}
			return ModelBase<ActivityModel>.Instance.GetActivityById(this.CurrentActivityIdInternal) as global::SurvivorsActivityData;
		}
	}

	// Token: 0x06016352 RID: 90962 RVA: 0x0062918A File Offset: 0x0062738A
	public void InitCommandQueue()
	{
		this.ClearCommandQueue();
		this.CommandQueue = new SurvivorsRogueCommandQueue();
	}

	// Token: 0x06016353 RID: 90963 RVA: 0x0062919D File Offset: 0x0062739D
	public void ClearCommandQueue()
	{
		if (this.CommandQueue != null)
		{
			this.CommandQueue.Clear();
			this.CommandQueue = null;
		}
	}

	// Token: 0x06016354 RID: 90964 RVA: 0x006291BC File Offset: 0x006273BC
	public void ClearGlobal()
	{
		this.ClearCommandQueue();
		this.BattleData.Clear();
		this.GainData.Clear();
		this.SelectLevelInfo = null;
		this.CurLevelIdInternal = 0;
		this.MaxWaveNum = 0;
		this.WaveTypeArray = Array.Empty<int>();
		this.WaveTipsStateInternal = SurvivorsRogueModel.EWaveTipsState.Default;
		this.NotTipsShopPurchaseAvailable = false;
		for (int i = 0; i < 4; i++)
		{
			this.ComboTimerFreezeTimeCfg[i] = 0;
			this.ComboDurationAdditionCfg[i] = 0;
		}
	}

	// Token: 0x06016355 RID: 90965 RVA: 0x00629234 File Offset: 0x00627434
	public int GetRogueCurrencyItemId()
	{
		if (this.GetRogueActivityConfig() == null)
		{
			return 0;
		}
		SurvivorsActivityConfig? survivorsActivityConfig;
		return survivorsActivityConfig.GetValueOrDefault().CurrencyItemId;
	}

	// Token: 0x06016356 RID: 90966 RVA: 0x00629264 File Offset: 0x00627464
	public SurvivorsActivityConfig? GetRogueActivityConfig()
	{
		if (!this.IsActivityOn())
		{
			return null;
		}
		return ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsActivityConfigByActivityId(this.CurrentActivityIdInternal);
	}

	// Token: 0x06016357 RID: 90967 RVA: 0x00629293 File Offset: 0x00627493
	public bool GetDebugMode()
	{
		return this.DebugMode;
	}

	// Token: 0x06016358 RID: 90968 RVA: 0x0062929B File Offset: 0x0062749B
	public void SetDebugMode(bool bOn)
	{
		this.DebugMode = bOn;
	}

	// Token: 0x06016359 RID: 90969 RVA: 0x006292A4 File Offset: 0x006274A4
	public void SaveCacheHandbookClickedMap()
	{
		if (this.HandbookClickedMap != null)
		{
			LocalStorage.SetPlayer<Dictionary<int, Dictionary<int, HashSet<int>>>>(ELocalStoragePlayerKey.SurvivorsHandbookClicked, this.HandbookClickedMap);
		}
	}

	// Token: 0x0601635A RID: 90970 RVA: 0x006292C0 File Offset: 0x006274C0
	public bool GetItemIsNew(ESurvivorsRogueItemType type, int id)
	{
		if (this.HandbookClickedMap == null)
		{
			this.HandbookClickedMap = LocalStorage.GetPlayer<Dictionary<int, Dictionary<int, HashSet<int>>>>(ELocalStoragePlayerKey.SurvivorsHandbookClicked, null);
		}
		Dictionary<int, HashSet<int>> dictionary;
		HashSet<int> hashSet;
		return !this.GetItemIsLock(type, id) && (this.HandbookClickedMap == null || !this.HandbookClickedMap.TryGetValue(this.CurrentActivityIdInternal, out dictionary) || !dictionary.TryGetValue((int)type, out hashSet) || !hashSet.Contains(id));
	}

	// Token: 0x0601635B RID: 90971 RVA: 0x0062932C File Offset: 0x0062752C
	public void SetItemClicked(ESurvivorsRogueItemType type, int id)
	{
		if (this.HandbookClickedMap == null)
		{
			this.HandbookClickedMap = new Dictionary<int, Dictionary<int, HashSet<int>>>();
		}
		if (this.GetItemIsLock(type, id))
		{
			return;
		}
		int currentActivityIdInternal = this.CurrentActivityIdInternal;
		Dictionary<int, HashSet<int>> dictionary;
		if (!this.HandbookClickedMap.TryGetValue(currentActivityIdInternal, out dictionary))
		{
			dictionary = new Dictionary<int, HashSet<int>>();
			this.HandbookClickedMap[currentActivityIdInternal] = dictionary;
		}
		HashSet<int> hashSet;
		if (!dictionary.TryGetValue((int)type, out hashSet))
		{
			hashSet = new HashSet<int>();
			dictionary[(int)type] = hashSet;
		}
		hashSet.Add(id);
	}

	// Token: 0x0601635C RID: 90972 RVA: 0x006293A4 File Offset: 0x006275A4
	public bool GetItemIsLock(ESurvivorsRogueItemType type, int id)
	{
		IReadOnlyDictionary<int, bool> readOnlyDictionary = null;
		if (type == ESurvivorsRogueItemType.Normal)
		{
			global::SurvivorsActivityData activityData = this.ActivityData;
			readOnlyDictionary = ((activityData != null) ? activityData.ItemMap : null);
		}
		else if (type == ESurvivorsRogueItemType.Character)
		{
			global::SurvivorsActivityData activityData2 = this.ActivityData;
			readOnlyDictionary = ((activityData2 != null) ? activityData2.RoleMap : null);
		}
		else if (type == ESurvivorsRogueItemType.Weapon)
		{
			global::SurvivorsActivityData activityData3 = this.ActivityData;
			readOnlyDictionary = ((activityData3 != null) ? activityData3.WeaponMap : null);
		}
		bool flag;
		return readOnlyDictionary == null || !readOnlyDictionary.TryGetValue(id, out flag) || !flag;
	}

	// Token: 0x0601635D RID: 90973 RVA: 0x00629414 File Offset: 0x00627614
	public List<ISurvivorsAttributeUiData> GetRoleDefaultAttributeList(int roleId, [Nullable(2)] IList<int> propertyIds)
	{
		Aki.Config.SurvivorsRole? survivorsRole = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsRole(roleId);
		int propId = survivorsRole.Value.PropId;
		int[] recommendPropertyArray = survivorsRole.Value.GetRecommendPropertyArray();
		Dictionary<EKSC_AttrType, float> attrsDataByPropertyConfig = KscUtil.GetAttrsDataByPropertyConfig(ConfigKSCBasePropertyById.GetConfig(propId, true).Value);
		List<ISurvivorsAttributeUiData> list = new List<ISurvivorsAttributeUiData>();
		if (propertyIds == null)
		{
			return list;
		}
		for (int i = 0; i < propertyIds.Count; i++)
		{
			int num = propertyIds[i];
			SurvivorsProperty? propertyConfig = ConfigBase<SurvivorsRogueConfig>.Instance.GetPropertyConfig(num);
			float num3;
			float num2 = (attrsDataByPropertyConfig != null && attrsDataByPropertyConfig.TryGetValue((EKSC_AttrType)num, out num3)) ? num3 : 0f;
			bool isRecommend = recommendPropertyArray != null && recommendPropertyArray.Contains(num);
			SurvivorsAttributeUiData item = new SurvivorsAttributeUiData
			{
				AttrId = propertyConfig.Value.Id,
				Value = (double)(propertyConfig.Value.IsBasePermyriad ? (num2 / 10000f) : num2),
				IsRecommend = isRecommend
			};
			list.Add(item);
		}
		list.Sort(delegate(ISurvivorsAttributeUiData dataA, ISurvivorsAttributeUiData dataB)
		{
			bool isRecommend2 = dataA.IsRecommend;
			bool isRecommend3 = dataB.IsRecommend;
			if (isRecommend2 == isRecommend3)
			{
				return dataA.AttrId - dataB.AttrId;
			}
			if (isRecommend2)
			{
				return -1;
			}
			return 1;
		});
		return list;
	}

	// Token: 0x0400ABC8 RID: 43976
	public const int COMBO_LEVEL_CONFIG_LENGTH = 4;

	// Token: 0x0400ABC9 RID: 43977
	public const int PERMYRIAD_RATIO = 10000;

	// Token: 0x0400ABCA RID: 43978
	private int CurLevelIdInternal;

	// Token: 0x0400ABCB RID: 43979
	public SurvivorsCombo? CurComboConfig;

	// Token: 0x0400ABCC RID: 43980
	public int MaxWaveNum;

	// Token: 0x0400ABCD RID: 43981
	public int[] WaveTypeArray = Array.Empty<int>();

	// Token: 0x0400ABCE RID: 43982
	public readonly int[] ComboTimerFreezeTimeCfg = new int[4];

	// Token: 0x0400ABCF RID: 43983
	public readonly int[] ComboDurationAdditionCfg = new int[4];

	// Token: 0x0400ABD0 RID: 43984
	private SurvivorsRogueModel.EWaveTipsState WaveTipsStateInternal;

	// Token: 0x0400ABD1 RID: 43985
	public bool HasNewSettle;

	// Token: 0x0400ABD2 RID: 43986
	private int CurrentActivityIdInternal;

	// Token: 0x0400ABD3 RID: 43987
	[Nullable(2)]
	public SurvivorsActivityDefine.SurvivorsLevelInfo SelectLevelInfo;

	// Token: 0x0400ABD4 RID: 43988
	public bool NotTipsShopPurchaseAvailable;

	// Token: 0x0400ABD5 RID: 43989
	public SurvivorsRogueBattleData BattleData = SurvivorsRogueBattleData.Create();

	// Token: 0x0400ABD6 RID: 43990
	public SurvivorsRogueGainData GainData = SurvivorsRogueGainData.Create();

	// Token: 0x0400ABD7 RID: 43991
	[Nullable(2)]
	public SurvivorsRogueCommandQueue CommandQueue;

	// Token: 0x0400ABD8 RID: 43992
	private bool DebugMode;

	// Token: 0x0400ABD9 RID: 43993
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Dictionary<int, Dictionary<int, HashSet<int>>> HandbookClickedMap;

	// Token: 0x02008EA7 RID: 36519
	[NullableContext(0)]
	public enum EWaveTipsState
	{
		// Token: 0x0402FF0D RID: 196365
		Default,
		// Token: 0x0402FF0E RID: 196366
		PopWaveTips,
		// Token: 0x0402FF0F RID: 196367
		ResidentWaveTips,
		// Token: 0x0402FF10 RID: 196368
		WaveCompleteTips
	}
}
