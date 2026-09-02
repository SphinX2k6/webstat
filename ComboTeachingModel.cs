using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol.Summon;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;

// Token: 0x02001876 RID: 6262
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class ComboTeachingModel : ModelBase<ComboTeachingModel>
{
	// Token: 0x17000EA5 RID: 3749
	// (get) Token: 0x0600B36B RID: 45931 RVA: 0x002FDD65 File Offset: 0x002FBF65
	// (set) Token: 0x0600B36C RID: 45932 RVA: 0x002FDD6D File Offset: 0x002FBF6D
	public float BeforeJumpTime
	{
		get
		{
			return this.BeforeJumpTimeInternal;
		}
		set
		{
			this.BeforeJumpTimeInternal = value;
		}
	}

	// Token: 0x17000EA6 RID: 3750
	// (get) Token: 0x0600B36D RID: 45933 RVA: 0x002FDD76 File Offset: 0x002FBF76
	// (set) Token: 0x0600B36E RID: 45934 RVA: 0x002FDD7E File Offset: 0x002FBF7E
	public bool IsClose
	{
		get
		{
			return this.IsCloseInternal;
		}
		set
		{
			this.IsCloseInternal = value;
		}
	}

	// Token: 0x17000EA7 RID: 3751
	// (get) Token: 0x0600B36F RID: 45935 RVA: 0x002FDD87 File Offset: 0x002FBF87
	// (set) Token: 0x0600B370 RID: 45936 RVA: 0x002FDD8F File Offset: 0x002FBF8F
	public bool IsEmit
	{
		get
		{
			return this.IsEmitInternal;
		}
		set
		{
			this.IsEmitInternal = value;
		}
	}

	// Token: 0x17000EA8 RID: 3752
	// (get) Token: 0x0600B371 RID: 45937 RVA: 0x002FDD98 File Offset: 0x002FBF98
	// (set) Token: 0x0600B372 RID: 45938 RVA: 0x002FDDA0 File Offset: 0x002FBFA0
	public int RecoveryComboId
	{
		get
		{
			return this.RecoveryComboIdInternal;
		}
		set
		{
			this.RecoveryComboIdInternal = value;
		}
	}

	// Token: 0x17000EA9 RID: 3753
	// (get) Token: 0x0600B373 RID: 45939 RVA: 0x002FDDA9 File Offset: 0x002FBFA9
	public List<long> AddBuffList
	{
		get
		{
			return this.AddBuffListInternal;
		}
	}

	// Token: 0x17000EAA RID: 3754
	// (get) Token: 0x0600B374 RID: 45940 RVA: 0x002FDDB1 File Offset: 0x002FBFB1
	public List<string> AddTagList
	{
		get
		{
			return this.AddTagListInternal;
		}
	}

	// Token: 0x17000EAB RID: 3755
	// (get) Token: 0x0600B375 RID: 45941 RVA: 0x002FDDB9 File Offset: 0x002FBFB9
	// (set) Token: 0x0600B376 RID: 45942 RVA: 0x002FDDC1 File Offset: 0x002FBFC1
	public long NextAttrSkillId
	{
		get
		{
			return this.NextAttrSkillIdInternal;
		}
		set
		{
			this.NextAttrSkillIdInternal = value;
		}
	}

	// Token: 0x17000EAC RID: 3756
	// (get) Token: 0x0600B378 RID: 45944 RVA: 0x002FDDD3 File Offset: 0x002FBFD3
	// (set) Token: 0x0600B377 RID: 45943 RVA: 0x002FDDCA File Offset: 0x002FBFCA
	public long UseSkillId
	{
		get
		{
			return this.UseSkillIdInternal;
		}
		set
		{
			this.UseSkillIdInternal = value;
		}
	}

	// Token: 0x17000EAD RID: 3757
	// (get) Token: 0x0600B37A RID: 45946 RVA: 0x002FDDE4 File Offset: 0x002FBFE4
	// (set) Token: 0x0600B379 RID: 45945 RVA: 0x002FDDDB File Offset: 0x002FBFDB
	public float UseSkillTime
	{
		get
		{
			return this.UseSkillTimeInternal;
		}
		set
		{
			this.UseSkillTimeInternal = value;
		}
	}

	// Token: 0x17000EAE RID: 3758
	// (get) Token: 0x0600B37C RID: 45948 RVA: 0x002FDDF5 File Offset: 0x002FBFF5
	// (set) Token: 0x0600B37B RID: 45947 RVA: 0x002FDDEC File Offset: 0x002FBFEC
	public bool PreNextAttr
	{
		get
		{
			return this.PreNextAttrInternal;
		}
		set
		{
			this.PreNextAttrInternal = value;
		}
	}

	// Token: 0x17000EAF RID: 3759
	// (get) Token: 0x0600B37E RID: 45950 RVA: 0x002FDE12 File Offset: 0x002FC012
	// (set) Token: 0x0600B37D RID: 45949 RVA: 0x002FDDFD File Offset: 0x002FBFFD
	public bool NextAttr
	{
		get
		{
			return this.NextAttrInternal;
		}
		set
		{
			this.PreNextAttrInternal = this.NextAttrInternal;
			this.NextAttrInternal = value;
		}
	}

	// Token: 0x17000EB0 RID: 3760
	// (get) Token: 0x0600B380 RID: 45952 RVA: 0x002FDE33 File Offset: 0x002FC033
	// (set) Token: 0x0600B37F RID: 45951 RVA: 0x002FDE1A File Offset: 0x002FC01A
	public int CurrentNodeIndex
	{
		get
		{
			return this.CurrentNodeIndexInternal;
		}
		set
		{
			this.CurrentNodeIndexInternal = value;
			Singleton<EventSystem>.Instance.Emit(EEventName.ComboTeachingIndexUpdate);
		}
	}

	// Token: 0x17000EB1 RID: 3761
	// (get) Token: 0x0600B381 RID: 45953 RVA: 0x002FDE3B File Offset: 0x002FC03B
	// (set) Token: 0x0600B382 RID: 45954 RVA: 0x002FDE4A File Offset: 0x002FC04A
	public bool InitStart
	{
		get
		{
			bool initStartInternal = this.InitStartInternal;
			this.InitStartInternal = false;
			return initStartInternal;
		}
		set
		{
			this.InitStartInternal = value;
		}
	}

	// Token: 0x0600B383 RID: 45955 RVA: 0x002FDE54 File Offset: 0x002FC054
	public void RefreshComboList(int comboId)
	{
		this.CurrentNodeIndex = 0;
		ComboTeaching? comboTeachingConfig = ConfigBase<ComboTeachingConfig>.Instance.GetComboTeachingConfig(comboId);
		int entityIdNoBlueprint = Global.BaseCharacter.GetEntityIdNoBlueprint();
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityIdNoBlueprint);
		BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
		CharacterBuffComponent characterBuffComponent = (entity != null) ? entity.GetComponent<CharacterBuffComponent>() : null;
		foreach (string tagName in this.AddTagList)
		{
			if (baseTagComponent != null)
			{
				baseTagComponent.RemoveTag(new int?(GameplayTagUtils.GetTagIdByName(tagName)));
			}
		}
		this.AddTagList.Clear();
		foreach (KeyValuePair<string, List<string>> keyValuePair in ComboTeachingDefine.banKeyMap)
		{
			if (!comboTeachingConfig.Value.InputEnums().Contains(keyValuePair.Key))
			{
				this.AddTagList.AddRange(keyValuePair.Value);
			}
		}
		foreach (string tagName2 in this.AddTagList)
		{
			int tagIdByName = GameplayTagUtils.GetTagIdByName(tagName2);
			if (baseTagComponent != null && !baseTagComponent.HasTag(tagIdByName) && baseTagComponent != null)
			{
				baseTagComponent.AddTag(new int?(tagIdByName));
			}
		}
		foreach (long buffId in this.AddBuffList)
		{
			if (characterBuffComponent != null && characterBuffComponent.GetBuffTotalStackById(buffId, false) > 0 && characterBuffComponent != null)
			{
				characterBuffComponent.RemoveBuff(buffId, -1, "ComboTeachingView.RefreshComboList", null, null, null);
			}
		}
		this.AddBuffList.Clear();
		foreach (long item in comboTeachingConfig.Value.AddBuffIDIter())
		{
			this.AddBuffList.Add(item);
		}
		foreach (long buffId2 in this.AddBuffList)
		{
			if (characterBuffComponent != null)
			{
				characterBuffComponent.AddBuff(buffId2, new AddBuffParam
				{
					InstigatorId = ((characterBuffComponent != null) ? characterBuffComponent.CreatureDataId : 0L),
					Reason = "CombatTeachingView.RefreshComboList"
				});
			}
		}
		foreach (int guideId in comboTeachingConfig.Value.GuideIDIter())
		{
			ControllerBase<GuideController>.Instance.TryStartGuide(guideId);
		}
	}

	// Token: 0x0600B384 RID: 45956 RVA: 0x002FE168 File Offset: 0x002FC368
	public void OnComboListEnd()
	{
		if (Global.BaseCharacter == null)
		{
			this.AddBuffList.Clear();
			this.AddTagList.Clear();
			return;
		}
		int entityIdNoBlueprint = Global.BaseCharacter.GetEntityIdNoBlueprint();
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityIdNoBlueprint);
		BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
		foreach (string tagName in this.AddTagList)
		{
			if (baseTagComponent != null)
			{
				baseTagComponent.RemoveTag(new int?(GameplayTagUtils.GetTagIdByName(tagName)));
			}
		}
		this.AddTagList.Clear();
		CharacterBuffComponent characterBuffComponent = (entity != null) ? entity.GetComponent<CharacterBuffComponent>() : null;
		foreach (long buffId in this.AddBuffList)
		{
			if (characterBuffComponent != null && characterBuffComponent.GetBuffTotalStackById(buffId, false) > 0 && characterBuffComponent != null)
			{
				characterBuffComponent.RemoveBuff(buffId, -1, "ComboTeachingView.OnBeforeDestroy", null, null, null);
			}
		}
		this.AddBuffList.Clear();
	}

	// Token: 0x0600B385 RID: 45957 RVA: 0x002FE2AC File Offset: 0x002FC4AC
	public IComboTeachingInfo CreateComboNodeInfo(int index, ComboTeaching comboConfig)
	{
		ComboTeachingCondition value = ConfigBase<ComboTeachingConfig>.Instance.GetComboTeachingConditionConfig(comboConfig.CommandID()[index]).Value;
		BaseCheckCondition successChecker = ControllerBase<ComboTeachingController>.Instance.GetSuccessChecker(value.CompleteCondition, value.CompleteParam);
		List<BaseCheckCondition> list = new List<BaseCheckCondition>();
		List<BaseCheckCondition> list2 = new List<BaseCheckCondition>();
		for (int i = 0; i < value.FailedCondition().Length; i++)
		{
			int type = value.FailedCondition()[i];
			string conditionString = (value.FailedParamLength > i) ? value.FailedParam()[i] : "";
			BaseCheckCondition failChecker = ControllerBase<ComboTeachingController>.Instance.GetFailChecker(type, conditionString);
			EComboTeachingCheckType type2 = failChecker.Type;
			if (type2 != EComboTeachingCheckType.Event)
			{
				if (type2 == EComboTeachingCheckType.Update)
				{
					list.Add(failChecker);
				}
			}
			else
			{
				list2.Add(failChecker);
			}
		}
		bool flag = index >= comboConfig.KeyIDLength || string.IsNullOrEmpty(comboConfig.KeyID(index));
		ComboTeachingInfo comboTeachingInfo = new ComboTeachingInfo
		{
			Index = index,
			Config = comboConfig,
			HoldTotalTime = 0f,
			SuccessCondition = successChecker,
			FailUpdateCondition = list,
			FailEventCondition = list2,
			IsEmit = false,
			IsHoldAction = false,
			IsShowTag = false,
			ActionInfo = "",
			NeedTickSummon = true,
			SuccessDelay = (float)value.CompleteDelay,
			FailDelay = (float)value.FailDelay
		};
		if (flag)
		{
			return comboTeachingInfo;
		}
		string text = comboConfig.KeyID(index).Split(';', StringSplitOptions.None)[0];
		bool flag2 = text.Contains('#');
		bool isShowTag = comboConfig.IconTagTextLength > index && comboConfig.IconTagText(index) != "";
		float holdTotalTime = flag2 ? float.Parse(text.Split('#', StringSplitOptions.None)[1]) : 0f;
		comboTeachingInfo.IsHoldAction = flag2;
		comboTeachingInfo.IsShowTag = isShowTag;
		comboTeachingInfo.HoldTotalTime = holdTotalTime;
		comboTeachingInfo.ActionInfo = (flag2 ? text.Split('#', StringSplitOptions.None)[0] : text);
		return comboTeachingInfo;
	}

	// Token: 0x0600B386 RID: 45958 RVA: 0x002FE4A0 File Offset: 0x002FC6A0
	public void ResetComboConfig()
	{
		this.UseSkillId = 0L;
		this.UseSkillTime = 0f;
		this.NextAttr = false;
		this.PreNextAttr = false;
	}

	// Token: 0x0600B387 RID: 45959 RVA: 0x002FE4C4 File Offset: 0x002FC6C4
	public bool CheckFailCondition(IComboTeachingInfo data, EComboTeachingFailCondition condition)
	{
		ComboTeaching config = data.Config;
		int index = data.Index;
		return ConfigBase<ComboTeachingConfig>.Instance.GetComboTeachingConditionConfig(config.CommandID()[index]).Value.FailedCondition().Contains((int)condition);
	}

	// Token: 0x0600B388 RID: 45960 RVA: 0x002FE508 File Offset: 0x002FC708
	public void OnCurIndexChanged(IComboTeachingInfo data)
	{
		ComboTeaching config = data.Config;
		int index = data.Index;
		ComboTeachingCondition value = ConfigBase<ComboTeachingConfig>.Instance.GetComboTeachingConditionConfig(config.CommandID()[index]).Value;
		int entityIdNoBlueprint = Global.BaseCharacter.GetEntityIdNoBlueprint();
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityIdNoBlueprint);
		if (value.RemoveBuff().Length != 0)
		{
			CharacterBuffComponent characterBuffComponent = (entity != null) ? entity.GetComponent<CharacterBuffComponent>() : null;
			foreach (int num in value.RemoveBuff())
			{
				if (characterBuffComponent != null && characterBuffComponent.GetBuffTotalStackById((long)num, false) > 0 && characterBuffComponent != null)
				{
					characterBuffComponent.RemoveBuff((long)num, -1, "ComboTeachingView.OnNodeStart", null, null, null);
				}
			}
		}
		if (value.RemoveBullet().Length != 0)
		{
			OrderedDictionary<int, BulletEntity> bulletEntityMap = ModelBase<BulletModel>.Instance.GetBulletEntityMap();
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			foreach (KeyValuePair<int, BulletEntity> keyValuePair in bulletEntityMap)
			{
				dictionary[keyValuePair.Value.GetBulletInfo().BulletRowName] = keyValuePair.Value.Id;
			}
			foreach (string text in value.RemoveBullet())
			{
				bool summonChild = false;
				string key;
				if (text.Contains(';'))
				{
					string[] array3 = text.Split(';', StringSplitOptions.None);
					key = array3[0];
					summonChild = bool.Parse(array3[1]);
				}
				else
				{
					key = text;
				}
				int id;
				if (dictionary.TryGetValue(key, out id))
				{
					ControllerBase<BulletController>.Instance.DestroyBullet(id, summonChild, EBulletDestroyReason.Normal, false);
				}
			}
		}
		if (value.SummonPos != 0 && data.NeedTickSummon)
		{
			this.CheckSummonBuffAdd(data);
			return;
		}
		data.NeedTickSummon = false;
	}

	// Token: 0x0600B389 RID: 45961 RVA: 0x002FE6EC File Offset: 0x002FC8EC
	public void CheckSummonBuffAdd(IComboTeachingInfo data)
	{
		ComboTeaching config = data.Config;
		int index = data.Index;
		ComboTeachingCondition value = ConfigBase<ComboTeachingConfig>.Instance.GetComboTeachingConditionConfig(config.CommandID()[index]).Value;
		int summonPos = value.SummonPos;
		if (summonPos == 0)
		{
			data.NeedTickSummon = false;
			return;
		}
		EntityHandle summonedEntityByOwnerId = PhantomUtil.GetSummonedEntityByOwnerId(Global.BaseCharacter.GetEntityIdNoBlueprint(), ESummonType.ConcomitantCustom, summonPos);
		if (summonedEntityByOwnerId == null)
		{
			return;
		}
		WorldEntity entity = summonedEntityByOwnerId.Entity;
		CharacterBuffComponent characterBuffComponent = (entity != null) ? entity.GetComponent<CharacterBuffComponent>() : null;
		if (characterBuffComponent != null)
		{
			foreach (int num in value.SummonRemoveBuff())
			{
				characterBuffComponent.RemoveBuff((long)num, -1, "ComboTeachingView.SummonRemoveBuff", null, null, null);
			}
			foreach (int num2 in value.SummonAddBuff())
			{
				characterBuffComponent.AddBuff((long)num2, new AddBuffParam
				{
					InstigatorId = characterBuffComponent.CreatureDataId,
					Reason = "CombatTeachingView.SummonAddBuff"
				});
			}
		}
		data.NeedTickSummon = false;
	}

	// Token: 0x040054EC RID: 21740
	private long UseSkillIdInternal;

	// Token: 0x040054ED RID: 21741
	private float UseSkillTimeInternal;

	// Token: 0x040054EE RID: 21742
	private bool PreNextAttrInternal;

	// Token: 0x040054EF RID: 21743
	private bool NextAttrInternal;

	// Token: 0x040054F0 RID: 21744
	private int CurrentNodeIndexInternal;

	// Token: 0x040054F1 RID: 21745
	private long NextAttrSkillIdInternal;

	// Token: 0x040054F2 RID: 21746
	private readonly List<long> AddBuffListInternal = new List<long>();

	// Token: 0x040054F3 RID: 21747
	private readonly List<string> AddTagListInternal = new List<string>();

	// Token: 0x040054F4 RID: 21748
	private int RecoveryComboIdInternal;

	// Token: 0x040054F5 RID: 21749
	private bool IsEmitInternal;

	// Token: 0x040054F6 RID: 21750
	private bool IsCloseInternal;

	// Token: 0x040054F7 RID: 21751
	private float BeforeJumpTimeInternal;

	// Token: 0x040054F8 RID: 21752
	private bool InitStartInternal;
}
