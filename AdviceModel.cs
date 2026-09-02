using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Advice;

// Token: 0x02001775 RID: 6005
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class AdviceModel : ModelBase<AdviceModel>
{
	// Token: 0x0600A8F6 RID: 43254 RVA: 0x002CFEF7 File Offset: 0x002CE0F7
	public AdviceCreateActor GetAdviceCreateActor()
	{
		if (this.AdviceCreateActorField == null)
		{
			this.AdviceCreateActorField = new AdviceCreateActor();
			this.AdviceCreateActorField.Init();
		}
		this.AdviceCreateActorField.RefreshPosition();
		return this.AdviceCreateActorField;
	}

	// Token: 0x0600A8F7 RID: 43255 RVA: 0x002CFF28 File Offset: 0x002CE128
	public void OnAdviceCreateActorDestroy()
	{
		this.AdviceCreateActorField = null;
	}

	// Token: 0x0600A8F8 RID: 43256 RVA: 0x002CFF34 File Offset: 0x002CE134
	public AdviceMotionActor GetAdviceMotionActor(int entityId)
	{
		AdviceMotionActor result;
		if (this.PlayingAdviceMotionEntities.TryGetValue(entityId, out result))
		{
			return result;
		}
		AdviceMotionActor adviceMotionActor = null;
		if (this.AdviceMotionActorStack.Count > 0)
		{
			int index = this.AdviceMotionActorStack.Count - 1;
			adviceMotionActor = this.AdviceMotionActorStack[index];
			this.AdviceMotionActorStack.RemoveAt(index);
		}
		if (adviceMotionActor == null)
		{
			return new AdviceMotionActor();
		}
		return adviceMotionActor;
	}

	// Token: 0x0600A8F9 RID: 43257 RVA: 0x002CFF94 File Offset: 0x002CE194
	public void AddPlayingMotionEntity(int entityId, AdviceMotionActor actor)
	{
		this.PlayingAdviceMotionEntities[entityId] = actor;
	}

	// Token: 0x0600A8FA RID: 43258 RVA: 0x002CFFA3 File Offset: 0x002CE1A3
	public void RemovePlayingMotionEntity(int entityId)
	{
		this.PlayingAdviceMotionEntities.Remove(entityId);
	}

	// Token: 0x0600A8FB RID: 43259 RVA: 0x002CFFB2 File Offset: 0x002CE1B2
	public void RecycleMotionActor(AdviceMotionActor actor)
	{
		this.AdviceMotionActorStack.Add(actor);
	}

	// Token: 0x0600A8FC RID: 43260 RVA: 0x002CFFC0 File Offset: 0x002CE1C0
	public void RemoveMotionActor(AdviceMotionActor actor)
	{
		this.AdviceMotionActorStack.Remove(actor);
	}

	// Token: 0x0600A8FD RID: 43261 RVA: 0x002CFFD0 File Offset: 0x002CE1D0
	public void PhraseAdviceData(AdviceResponse response)
	{
		this.UpVoteIds.Clear();
		if (response.UpVoteIds != null)
		{
			foreach (long value in response.UpVoteIds)
			{
				long item = Singleton<MathUtils>.Instance.LongToBigInt(value);
				this.UpVoteIds.Add(item);
			}
		}
		this.AdviceDataMap.Clear();
		if (response.Advices != null)
		{
			foreach (PbAdvice data in response.Advices)
			{
				AdviceData adviceData = new AdviceData();
				adviceData.Phrase(data);
				long? adviceBigId = adviceData.GetAdviceBigId();
				if (adviceBigId != null)
				{
					this.AdviceDataMap[adviceBigId.Value] = adviceData;
				}
			}
		}
		this.DataMapChangeDirty = true;
		Singleton<EventSystem>.Instance.Emit(EEventName.OnReceiveAdviceData);
	}

	// Token: 0x0600A8FE RID: 43262 RVA: 0x002D00D8 File Offset: 0x002CE2D8
	public void PhraseAdviceCreateData(AdviceCreateResponse response)
	{
		AdviceData adviceData = new AdviceData();
		adviceData.Phrase(response.Advice);
		long? adviceBigId = adviceData.GetAdviceBigId();
		if (adviceBigId != null)
		{
			this.AdviceDataMap[adviceBigId.Value] = adviceData;
		}
		this.DataMapChangeDirty = true;
		Singleton<EventSystem>.Instance.Emit(EEventName.OnCreateAdviceSuccess);
	}

	// Token: 0x0600A8FF RID: 43263 RVA: 0x002D0134 File Offset: 0x002CE334
	public void OnAdviceUpdateNotify(AdviceUpdateNotify response)
	{
		this.UpVoteIds.Clear();
		if (response.UpVoteIds != null)
		{
			foreach (long value in response.UpVoteIds)
			{
				long item = Singleton<MathUtils>.Instance.LongToBigInt(value);
				this.UpVoteIds.Add(item);
			}
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnAdviceVoteNotify);
	}

	// Token: 0x0600A900 RID: 43264 RVA: 0x002D01B8 File Offset: 0x002CE3B8
	public void ResetVoteIds()
	{
		this.UpVoteIds.Clear();
		Singleton<EventSystem>.Instance.Emit(EEventName.OnAdviceVoteNotify);
	}

	// Token: 0x0600A901 RID: 43265 RVA: 0x002D01D5 File Offset: 0x002CE3D5
	public void OnRequestVote(long id, PbAdviceVoteType type)
	{
		this.UpVoteIds.Remove(id);
		if (type == PbAdviceVoteType.Up)
		{
			this.UpVoteIds.Add(id);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnAdviceVoteNotify);
	}

	// Token: 0x0600A902 RID: 43266 RVA: 0x002D0204 File Offset: 0x002CE404
	public void OnAdviceVoteUpdate(long id, AdviceVoteUpdateNotify notify)
	{
		AdviceData adviceData;
		if (this.AdviceDataMap.TryGetValue(id, out adviceData))
		{
			adviceData.PhraseUpDownData((long)notify.UpVote);
		}
	}

	// Token: 0x0600A903 RID: 43267 RVA: 0x002D0230 File Offset: 0x002CE430
	public void OnModifyAdvice(long id, AdviceContentData[] adviceContent)
	{
		AdviceData adviceData;
		if (this.AdviceDataMap.TryGetValue(id, out adviceData))
		{
			adviceData.PhraseData(new List<AdviceContentData>(adviceContent));
		}
		this.DataMapChangeDirty = true;
		Singleton<EventSystem>.Instance.Emit<long>(EEventName.OnModifyAdviceSuccess, id);
	}

	// Token: 0x0600A904 RID: 43268 RVA: 0x002D0271 File Offset: 0x002CE471
	public void OnDeleteAdvice(long id)
	{
		this.AdviceDataMap.Remove(id);
		this.DataMapChangeDirty = true;
		Singleton<EventSystem>.Instance.Emit(EEventName.OnDeleteAdviceSuccess);
	}

	// Token: 0x0600A905 RID: 43269 RVA: 0x002D0298 File Offset: 0x002CE498
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public AdviceData[] GetAdviceArray()
	{
		if (this.DataMapChangeDirty)
		{
			List<AdviceData> list = new List<AdviceData>();
			foreach (AdviceData item in this.AdviceDataMap.Values)
			{
				list.Add(item);
			}
			this.AdviceArray = list.ToArray();
			this.DataMapChangeDirty = false;
		}
		return this.AdviceArray;
	}

	// Token: 0x0600A906 RID: 43270 RVA: 0x002D0318 File Offset: 0x002CE518
	public long[] GetUpVoteIds()
	{
		List<long> list = new List<long>();
		foreach (long item in this.UpVoteIds)
		{
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600A907 RID: 43271 RVA: 0x002D0378 File Offset: 0x002CE578
	public bool GetIfCanCreateAdvice(ELineMode mode)
	{
		Dictionary<int, int> currentSentenceWordMap = this.CurrentSentenceWordMap;
		int currentConjunctionId = this.CurrentConjunctionId;
		Dictionary<int, int> currentWordMap = this.CurrentWordMap;
		foreach (KeyValuePair<int, int> keyValuePair in currentSentenceWordMap)
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			int num;
			if ((mode != ELineMode.SingleLine || key != 1) && value > 0 && (!currentWordMap.TryGetValue(key, out num) || num <= 0))
			{
				return false;
			}
		}
		return mode != ELineMode.MutiLine || currentConjunctionId > 0;
	}

	// Token: 0x0600A908 RID: 43272 RVA: 0x002D0418 File Offset: 0x002CE618
	public void SetCurrentEntityId(int entityId)
	{
		this.CurrentInteractEntityId = entityId;
		this.CurrentEntityAdviceData = null;
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		if (entity != null)
		{
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			if (component != null)
			{
				this.CurrentEntityAdviceData = component.GetAdviceInfo();
			}
		}
	}

	// Token: 0x0600A909 RID: 43273 RVA: 0x002D0458 File Offset: 0x002CE658
	[NullableContext(2)]
	public AdviceEntityData GetCurrentEntityAdviceData()
	{
		return this.CurrentEntityAdviceData;
	}

	// Token: 0x0600A90A RID: 43274 RVA: 0x002D0460 File Offset: 0x002CE660
	public int GetCurrentEntityId()
	{
		return this.CurrentInteractEntityId;
	}

	// Token: 0x0600A90B RID: 43275 RVA: 0x002D0468 File Offset: 0x002CE668
	public void ResetWordData()
	{
		this.CurrentWordMap.Clear();
		this.CurrentSentenceWordMap.Clear();
		this.CurrentConjunctionId = 0;
		this.CurrentSelectMotionId = 0;
		this.CurrentSelectSortWordId = 0;
		this.CurrentSelectSortTypeId = 0;
		this.CurrentSelectWordIndex = 0;
		this.CurrentExpressionId = 0;
		this.CurrentSelectRoleId = 0;
		this.CurrentLineModel = ELineMode.SingleLine;
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		int? num;
		if (getCurrentEntity == null)
		{
			num = null;
		}
		else
		{
			WorldEntity entity = getCurrentEntity.Entity;
			if (entity == null)
			{
				num = null;
			}
			else
			{
				CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
				num = ((component != null) ? new int?(component.GetRoleId()) : null);
			}
		}
		int? num2 = num;
		this.PreSelectRoleId = num2.GetValueOrDefault();
		this.CurrentSelectMotionId = 0;
		this.PreSelectMotionId = ConfigBase<AdviceConfig>.Instance.GetAdviceMotionDefaultConfigId();
		IReadOnlyList<AdviceSentence> adviceSentenceConfigs = ConfigBase<AdviceConfig>.Instance.GetAdviceSentenceConfigs();
		int index = (int)Singleton<MathUtils>.Instance.GetRandomRange(0.0, (double)(adviceSentenceConfigs.Count - 1));
		this.CurrentSentenceWordMap[0] = adviceSentenceConfigs[index].Id;
		this.RandomSecondSentenceWord();
	}

	// Token: 0x0600A90C RID: 43276 RVA: 0x002D057F File Offset: 0x002CE77F
	public void SetAdviceShowSetting(bool state)
	{
		this.AdviceShowSetting = state;
		Singleton<EventSystem>.Instance.Emit<EFunction>(EEventName.RefreshMenuSetting, EFunction.ADVICESETTING);
	}

	// Token: 0x0600A90D RID: 43277 RVA: 0x002D059A File Offset: 0x002CE79A
	public bool GetAdviceShowSetting()
	{
		return this.AdviceShowSetting;
	}

	// Token: 0x0600A90E RID: 43278 RVA: 0x002D05A4 File Offset: 0x002CE7A4
	public bool GetCreateAdvicePreConditionState()
	{
		bool flag = true;
		if (!this.CheckIfSystemOpen())
		{
			return false;
		}
		if (ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			return false;
		}
		if (!ModelBase<CreatureModel>.Instance.IsMyWorld())
		{
			return false;
		}
		if (!ControllerBase<AdviceController>.Instance.CheckIfStandAndInValidActor())
		{
			return false;
		}
		BaseTagComponent component = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Entity.GetComponent<BaseTagComponent>();
		return !component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"]) && component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.站立"]) && flag;
	}

	// Token: 0x0600A90F RID: 43279 RVA: 0x002D062F File Offset: 0x002CE82F
	public bool GetCreateConditionState()
	{
		return !ControllerBase<AdviceController>.Instance.CheckBehindAdviceActor() && !ControllerBase<AdviceController>.Instance.CheckInInValidArea() && !this.CheckIfMaxAdvice();
	}

	// Token: 0x0600A910 RID: 43280 RVA: 0x002D0658 File Offset: 0x002CE858
	public bool CheckIfMaxAdvice()
	{
		int valueOrDefault = ConfigCommonParamById.GetIntConfig("AdviceCreateLimit").GetValueOrDefault();
		return ModelBase<AdviceModel>.Instance.GetAdviceArray() != null && ModelBase<AdviceModel>.Instance.GetAdviceArray().Length >= valueOrDefault;
	}

	// Token: 0x0600A911 RID: 43281 RVA: 0x002D0698 File Offset: 0x002CE898
	public string GetCreatePreConditionFailText()
	{
		if (ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			return "CannotPutAdviceInInstanceDungeon";
		}
		if (!this.CheckIfSystemOpen())
		{
			return "FunctionDisable";
		}
		if (!ModelBase<CreatureModel>.Instance.IsMyWorld())
		{
			return "CannotPutAdviceWhenInOtherWorld";
		}
		if (!ControllerBase<AdviceController>.Instance.CheckIfStandAndInValidActor())
		{
			return "CurrentStateCannotPutAdvice";
		}
		BaseTagComponent component = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Entity.GetComponent<BaseTagComponent>();
		if (component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"]))
		{
			return "AdviceCannotOpenOnBattle";
		}
		if (!component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.站立"]))
		{
			return "AdviceJustCanPutWhenStand";
		}
		return "CurrentStateCannotPutAdvice";
	}

	// Token: 0x0600A912 RID: 43282 RVA: 0x002D0740 File Offset: 0x002CE940
	public string GetCreateConditionFailText()
	{
		if (ControllerBase<AdviceController>.Instance.CheckBehindAdviceActor())
		{
			return "AdviceTooClose";
		}
		if (ControllerBase<AdviceController>.Instance.CheckInInValidArea())
		{
			return "AdviceAreaCannotPut";
		}
		int valueOrDefault = ConfigCommonParamById.GetIntConfig("AdviceCreateLimit").GetValueOrDefault();
		if (ModelBase<AdviceModel>.Instance.GetAdviceArray() != null && ModelBase<AdviceModel>.Instance.GetAdviceArray().Length >= valueOrDefault)
		{
			return "OverCreateAdviceMax";
		}
		return "CurrentStateCannotPutAdvice";
	}

	// Token: 0x0600A913 RID: 43283 RVA: 0x002D07AA File Offset: 0x002CE9AA
	private bool CheckIfSystemOpen()
	{
		return ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.Advice) && ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.AdvicePut);
	}

	// Token: 0x0600A914 RID: 43284 RVA: 0x002D07D1 File Offset: 0x002CE9D1
	public void OnChangeSentence(int sentenceKey)
	{
		ModelBase<AdviceModel>.Instance.CurrentWordMap[sentenceKey] = 0;
		Singleton<EventSystem>.Instance.Emit(EEventName.OnSelectAdviceWord);
	}

	// Token: 0x0600A915 RID: 43285 RVA: 0x002D07F4 File Offset: 0x002CE9F4
	public AdviceMotionSelectData[] GetMotionSelectData()
	{
		List<AdviceMotionSelectData> list = new List<AdviceMotionSelectData>();
		int preSelectRoleId = ModelBase<AdviceModel>.Instance.PreSelectRoleId;
		AdviceMotionSelectData item = new AdviceMotionSelectData(ConfigBase<AdviceConfig>.Instance.GetAdviceMotionDefaultConfigId());
		list.Add(item);
		if (preSelectRoleId > 0)
		{
			foreach (Motion motion in ConfigBase<MotionConfig>.Instance.GetMotionConfigsByRoleId(preSelectRoleId))
			{
				AdviceMotionSelectData item2 = new AdviceMotionSelectData(motion.Id);
				list.Add(item2);
			}
		}
		return list.ToArray();
	}

	// Token: 0x0600A916 RID: 43286 RVA: 0x002D0888 File Offset: 0x002CEA88
	public AdviceSelectItemData[] GetAdviceSelectData(ELineMode selectModel)
	{
		List<AdviceSelectItemData> list = new List<AdviceSelectItemData>();
		if (selectModel == ELineMode.SingleLine)
		{
			AdviceSelectItemData item = new AdviceSelectItemData(EAdviceSelectItemEnum.SelectWord1);
			list.Add(item);
		}
		else
		{
			AdviceSelectItemData item2 = new AdviceSelectItemData(EAdviceSelectItemEnum.SelectWord1);
			list.Add(item2);
			AdviceSelectItemData item3 = new AdviceSelectItemData(EAdviceSelectItemEnum.Conjunction);
			list.Add(item3);
			AdviceSelectItemData item4 = new AdviceSelectItemData(EAdviceSelectItemEnum.SelectWord2);
			list.Add(item4);
		}
		AdviceSelectItemData item5 = new AdviceSelectItemData(EAdviceSelectItemEnum.AddExpression);
		list.Add(item5);
		AdviceSelectItemData item6 = new AdviceSelectItemData(EAdviceSelectItemEnum.CutLine);
		list.Add(item6);
		AdviceSelectItemData item7 = new AdviceSelectItemData(EAdviceSelectItemEnum.ChangeWordBtn);
		list.Add(item7);
		AdviceSelectItemData item8 = new AdviceSelectItemData(EAdviceSelectItemEnum.AddOrDecreaseBtn);
		list.Add(item8);
		return list.ToArray();
	}

	// Token: 0x0600A917 RID: 43287 RVA: 0x002D0920 File Offset: 0x002CEB20
	public void RandomSecondSentenceWord()
	{
		IReadOnlyList<AdviceSentence> adviceSentenceConfigs = ConfigBase<AdviceConfig>.Instance.GetAdviceSentenceConfigs();
		int num = (int)Singleton<MathUtils>.Instance.GetRandomRange(0.0, (double)(adviceSentenceConfigs.Count - 1));
		int num2 = ModelBase<AdviceModel>.Instance.CurrentSentenceWordMap[0];
		while (num == num2)
		{
			num = (int)Singleton<MathUtils>.Instance.GetRandomRange(0.0, (double)(adviceSentenceConfigs.Count - 1));
		}
		this.CurrentRandomSecondLineId = num;
		ModelBase<AdviceModel>.Instance.CurrentSentenceWordMap[1] = adviceSentenceConfigs[this.CurrentRandomSecondLineId].Id;
	}

	// Token: 0x0600A918 RID: 43288 RVA: 0x002D09B8 File Offset: 0x002CEBB8
	public string GetFirstLineText()
	{
		List<AdviceContentData> list = new List<AdviceContentData>();
		AdviceContentData adviceContentData = new AdviceContentData();
		adviceContentData.SetData(this.CurrentSentenceWordMap[0], this.CurrentWordMap[0], PbAdviceContentType.Sentence);
		list.Add(adviceContentData);
		AdviceData adviceData = new AdviceData();
		adviceData.PhraseShowText(new List<AdviceContentData>(list), 0L);
		return adviceData.GetAdviceShowText();
	}

	// Token: 0x0600A919 RID: 43289 RVA: 0x002D0A10 File Offset: 0x002CEC10
	public string GetSecondLineText()
	{
		List<AdviceContentData> list = new List<AdviceContentData>();
		AdviceContentData adviceContentData = new AdviceContentData();
		adviceContentData.SetData(this.CurrentConjunctionId, 0, PbAdviceContentType.Conjunction);
		list.Add(adviceContentData);
		AdviceContentData adviceContentData2 = new AdviceContentData();
		adviceContentData2.SetData(this.CurrentSentenceWordMap[1], this.CurrentWordMap[1], PbAdviceContentType.Sentence);
		list.Add(adviceContentData2);
		AdviceData adviceData = new AdviceData();
		adviceData.PhraseShowText(new List<AdviceContentData>(list), 1L);
		return adviceData.GetAdviceShowText();
	}

	// Token: 0x0600A91A RID: 43290 RVA: 0x002D0A84 File Offset: 0x002CEC84
	public string GetCurrentShowText()
	{
		List<AdviceContentData> list = new List<AdviceContentData>();
		if (this.CurrentLineModel == ELineMode.SingleLine)
		{
			AdviceContentData adviceContentData = new AdviceContentData();
			adviceContentData.SetData(this.CurrentSentenceWordMap[0], this.CurrentWordMap[0], PbAdviceContentType.Sentence);
			list.Add(adviceContentData);
		}
		else
		{
			AdviceContentData adviceContentData2 = new AdviceContentData();
			adviceContentData2.SetData(this.CurrentSentenceWordMap[0], this.CurrentWordMap[0], PbAdviceContentType.Sentence);
			list.Add(adviceContentData2);
			AdviceContentData adviceContentData3 = new AdviceContentData();
			adviceContentData3.SetData(this.CurrentConjunctionId, 0, PbAdviceContentType.Conjunction);
			list.Add(adviceContentData3);
			AdviceContentData adviceContentData4 = new AdviceContentData();
			adviceContentData4.SetData(this.CurrentSentenceWordMap[1], this.CurrentWordMap[1], PbAdviceContentType.Sentence);
			list.Add(adviceContentData4);
		}
		AdviceData adviceData = new AdviceData();
		adviceData.PhraseShowText(new List<AdviceContentData>(list), 0L);
		return adviceData.GetAdviceShowText();
	}

	// Token: 0x0600A91B RID: 43291 RVA: 0x002D0B5C File Offset: 0x002CED5C
	public AdviceContentData[] GetCreateAdviceContent()
	{
		List<AdviceContentData> list = new List<AdviceContentData>();
		AdviceModel instance = ModelBase<AdviceModel>.Instance;
		Dictionary<int, int> currentSentenceWordMap = instance.CurrentSentenceWordMap;
		int currentConjunctionId = instance.CurrentConjunctionId;
		Dictionary<int, int> currentWordMap = instance.CurrentWordMap;
		int num = 0;
		foreach (KeyValuePair<int, int> keyValuePair in currentSentenceWordMap)
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			if (value > 0 && (this.CurrentLineModel != ELineMode.SingleLine || key != 1))
			{
				int num2 = currentWordMap[key];
				if (num2 > 0)
				{
					num++;
					AdviceContentData adviceContentData = new AdviceContentData();
					adviceContentData.SetData(value, num2, PbAdviceContentType.Sentence);
					list.Add(adviceContentData);
				}
				if (num == 1 && this.CurrentLineModel != ELineMode.SingleLine && currentConjunctionId > 0)
				{
					AdviceContentData adviceContentData2 = new AdviceContentData();
					adviceContentData2.SetData(currentConjunctionId, 0, PbAdviceContentType.Conjunction);
					list.Add(adviceContentData2);
				}
			}
		}
		if (instance.CurrentExpressionId > 0)
		{
			AdviceContentData adviceContentData3 = new AdviceContentData();
			adviceContentData3.SetData(instance.CurrentExpressionId, 0, PbAdviceContentType.Expression);
			list.Add(adviceContentData3);
		}
		if (instance.CurrentSelectMotionId > 0)
		{
			AdviceContentData adviceContentData4 = new AdviceContentData();
			adviceContentData4.SetData(instance.CurrentSelectMotionId, 0, PbAdviceContentType.Motion);
			list.Add(adviceContentData4);
		}
		return list.ToArray();
	}

	// Token: 0x04004F94 RID: 20372
	public Dictionary<int, int> CurrentSentenceWordMap = new Dictionary<int, int>();

	// Token: 0x04004F95 RID: 20373
	public Dictionary<int, int> CurrentPreSentenceWordMap = new Dictionary<int, int>();

	// Token: 0x04004F96 RID: 20374
	public int CurrentPreSelectWordId;

	// Token: 0x04004F97 RID: 20375
	public int CurrentSelectWordId;

	// Token: 0x04004F98 RID: 20376
	public int CurrentPreSelectSentenceIndex;

	// Token: 0x04004F99 RID: 20377
	public int CurrentConjunctionId;

	// Token: 0x04004F9A RID: 20378
	public EChangeWordType CurrentChangeWordType;

	// Token: 0x04004F9B RID: 20379
	public ELineMode CurrentLineModel;

	// Token: 0x04004F9C RID: 20380
	public int CurrentSentenceSelectIndex;

	// Token: 0x04004F9D RID: 20381
	private int CurrentRandomSecondLineId;

	// Token: 0x04004F9E RID: 20382
	public int PreSelectSortTypeId;

	// Token: 0x04004F9F RID: 20383
	public int PreSelectSortWordId;

	// Token: 0x04004FA0 RID: 20384
	public int CurrentSelectSortWordId;

	// Token: 0x04004FA1 RID: 20385
	public int CurrentSelectSortTypeId;

	// Token: 0x04004FA2 RID: 20386
	public Dictionary<int, int> CurrentWordMap = new Dictionary<int, int>();

	// Token: 0x04004FA3 RID: 20387
	public int CurrentSelectWordIndex;

	// Token: 0x04004FA4 RID: 20388
	public int PreSelectExpressionId;

	// Token: 0x04004FA5 RID: 20389
	public int CurrentExpressionId;

	// Token: 0x04004FA6 RID: 20390
	public int CurrentSelectRoleId;

	// Token: 0x04004FA7 RID: 20391
	public int PreSelectRoleId;

	// Token: 0x04004FA8 RID: 20392
	public int CurrentSelectMotionId;

	// Token: 0x04004FA9 RID: 20393
	public int PreSelectMotionId;

	// Token: 0x04004FAA RID: 20394
	public int PreSelectAdviceItemId;

	// Token: 0x04004FAB RID: 20395
	public long? AdviceViewShowId;

	// Token: 0x04004FAC RID: 20396
	private readonly HashSet<long> UpVoteIds = new HashSet<long>();

	// Token: 0x04004FAD RID: 20397
	private readonly Dictionary<long, AdviceData> AdviceDataMap = new Dictionary<long, AdviceData>();

	// Token: 0x04004FAE RID: 20398
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private AdviceData[] AdviceArray;

	// Token: 0x04004FAF RID: 20399
	private bool DataMapChangeDirty;

	// Token: 0x04004FB0 RID: 20400
	private int CurrentInteractEntityId;

	// Token: 0x04004FB1 RID: 20401
	[Nullable(2)]
	private AdviceEntityData CurrentEntityAdviceData;

	// Token: 0x04004FB2 RID: 20402
	private bool AdviceShowSetting;

	// Token: 0x04004FB3 RID: 20403
	private readonly List<AdviceMotionActor> AdviceMotionActorStack = new List<AdviceMotionActor>();

	// Token: 0x04004FB4 RID: 20404
	private readonly Dictionary<int, AdviceMotionActor> PlayingAdviceMotionEntities = new Dictionary<int, AdviceMotionActor>();

	// Token: 0x04004FB5 RID: 20405
	[Nullable(2)]
	private AdviceCreateActor AdviceCreateActorField;
}
