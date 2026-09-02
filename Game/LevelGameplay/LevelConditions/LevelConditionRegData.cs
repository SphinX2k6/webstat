using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DDC RID: 28124
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelConditionRegData
	{
		// Token: 0x06044603 RID: 280067 RVA: 0x011C350C File Offset: 0x011C170C
		public LevelConditionRegData(LevelConditionGroupRegData owner, Condition conditionConfig, List<EEventName> eventNames)
		{
			this.Owner = owner;
			this.ConditionConfig = conditionConfig;
			this.EventNames = eventNames;
			string type = this.ConditionConfig.Type;
			if (type == ELevelGeneralCondition.PawnInRange.ToEnumString())
			{
				string limitParams = this.ConditionConfig.GetLimitParams("PawnId");
				float range = float.Parse(this.ConditionConfig.GetLimitParams("Distance"));
				Singleton<LevelConditionRegistry>.Instance.AddPawnInRangeMap(limitParams, range);
			}
			if (type == ELevelGeneralCondition.CheckRangeByPbDataId.ToEnumString())
			{
				string limitParams2 = this.ConditionConfig.GetLimitParams("PbDataId");
				float range2 = float.Parse(this.ConditionConfig.GetLimitParams("Distance"));
				Singleton<LevelConditionRegistry>.Instance.AddPbDataInRangeMap(int.Parse(limitParams2), range2);
			}
			if (type == ELevelGeneralCondition.CheckCharacterMotionState.ToEnumString())
			{
				LevelConditionCheckCharacterMotionState.RegisterEvents(new TMotionStateCallback(this.OnEventInvokeCheck));
				return;
			}
			if (type == ELevelGeneralCondition.CheckCharacterTagsRestrict.ToEnumString())
			{
				LevelConditionCheckCharacterTagsRestrict.RegisterEvents(this.ConditionConfig, new TTagChangedCallback(this.OnEventInvokeCheck));
				return;
			}
			for (int i = 0; i < this.EventNames.Count; i++)
			{
				EEventName eeventName = this.EventNames[i];
				if (eeventName == EEventName.OnGlobalGameplayTagChanged)
				{
					AbilityEvent.Instance.Add(SceneTeam.Scene, EAbilityEventName.OnGameplayTagChanged, (long)GameplayTagUtils.GetTagIdByName(this.ConditionConfig.GetLimitParams("Tag")), new Action<int, int, int, int>(this.OnGlobalGameplayTagChanged));
				}
				else if (eeventName == EEventName.OnEntityFightByBpType && type == ELevelGeneralCondition.FightWithMonster.ToEnumString())
				{
					string limitParams3 = this.ConditionConfig.GetLimitParams("MonsterId");
					if (limitParams3 == null)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.LevelCondition;
						ELogAuthor author = ELogAuthor.TL;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 2);
						defaultInterpolatedStringHandler.AppendLiteral("配置错误！条件");
						defaultInterpolatedStringHandler.AppendFormatted<int>(this.ConditionConfig.Id);
						defaultInterpolatedStringHandler.AppendLiteral("的MonsterId参数不符合条件类型");
						defaultInterpolatedStringHandler.AppendFormatted<ELevelGeneralCondition>(ELevelGeneralCondition.FightWithMonster);
						defaultInterpolatedStringHandler.AppendLiteral("的定义");
						instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
					}
					else
					{
						Singleton<EventSystem>.Instance.AddWithCondition<string>(EEventName.OnEntityFightByBpType, new Action<string>(this.OnEntityFightByBpType), limitParams3);
					}
				}
				else
				{
					Singleton<EventSystem>.Instance.Add(eeventName, new GenericEventHandler(this.OnEventInvokeCheck));
				}
			}
		}

		// Token: 0x06044604 RID: 280068 RVA: 0x011C375F File Offset: 0x011C195F
		private void OnGlobalGameplayTagChanged(int entityId, int gameplayTagId, int originTagCount, int newTagCount)
		{
			this.OnEventInvokeCheck(new object[]
			{
				entityId,
				gameplayTagId,
				originTagCount,
				newTagCount
			});
		}

		// Token: 0x06044605 RID: 280069 RVA: 0x011C3792 File Offset: 0x011C1992
		private void OnEntityFightByBpType(string blueprintType)
		{
			this.OnEventInvokeCheck(new object[]
			{
				blueprintType
			});
		}

		// Token: 0x06044606 RID: 280070 RVA: 0x011C37A4 File Offset: 0x011C19A4
		public void Destroy()
		{
			if (this.ConditionConfig.Type == ELevelGeneralCondition.PawnInRange.ToEnumString())
			{
				string limitParams = this.ConditionConfig.GetLimitParams("PawnId");
				Singleton<LevelConditionRegistry>.Instance.RemovePawnInRangeMap(limitParams);
			}
			if (this.ConditionConfig.Type == ELevelGeneralCondition.CheckRangeByPbDataId.ToEnumString())
			{
				string limitParams2 = this.ConditionConfig.GetLimitParams("PbDataId");
				Singleton<LevelConditionRegistry>.Instance.RemovePbDataInRangeMap(int.Parse(limitParams2));
			}
			if (this.ConditionConfig.Type == ELevelGeneralCondition.CheckCharacterMotionState.ToEnumString())
			{
				LevelConditionCheckCharacterMotionState.UnRegisterEvents(new TMotionStateCallback(this.OnEventInvokeCheck));
				return;
			}
			if (this.ConditionConfig.Type == ELevelGeneralCondition.CheckCharacterTagsRestrict.ToEnumString())
			{
				LevelConditionCheckCharacterTagsRestrict.UnRegisterEvents(this.ConditionConfig, new TTagChangedCallback(this.OnEventInvokeCheck));
				return;
			}
			for (int i = 0; i < this.EventNames.Count; i++)
			{
				EEventName eeventName = this.EventNames[i];
				if (eeventName == EEventName.OnGlobalGameplayTagChanged)
				{
					AbilityEvent.Instance.Remove(SceneTeam.Scene, EAbilityEventName.OnGameplayTagChanged, (long)GameplayTagUtils.GetTagIdByName(this.ConditionConfig.GetLimitParams("Tag")), new Action<int, int, int, int>(this.OnGlobalGameplayTagChanged));
				}
				else if (eeventName == EEventName.OnEntityFightByBpType && this.ConditionConfig.Type == ELevelGeneralCondition.FightWithMonster.ToEnumString())
				{
					string limitParams3 = this.ConditionConfig.GetLimitParams("MonsterId");
					if (limitParams3 == null)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.LevelCondition;
						ELogAuthor author = ELogAuthor.TL;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 2);
						defaultInterpolatedStringHandler.AppendLiteral("配置错误！条件");
						defaultInterpolatedStringHandler.AppendFormatted<int>(this.ConditionConfig.Id);
						defaultInterpolatedStringHandler.AppendLiteral("的MonsterId参数不符合条件类型");
						defaultInterpolatedStringHandler.AppendFormatted<ELevelGeneralCondition>(ELevelGeneralCondition.FightWithMonster);
						defaultInterpolatedStringHandler.AppendLiteral("的定义");
						instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
					}
					else
					{
						Singleton<EventSystem>.Instance.RemoveWithCondition<string>(EEventName.OnEntityFightByBpType, new Action<string>(this.OnEntityFightByBpType), limitParams3);
					}
				}
				else
				{
					Singleton<EventSystem>.Instance.Remove(eeventName, new GenericEventHandler(this.OnEventInvokeCheck));
				}
			}
		}

		// Token: 0x06044607 RID: 280071 RVA: 0x011C39CC File Offset: 0x011C1BCC
		private void OnEventInvokeCheck(params object[] eventArgs)
		{
			if (this.OnEventInvokeCheckStat == null)
			{
				this.OnEventInvokeCheckStat = Stat.CreateNoFlameGraph("OnEventInvokeCheckStat_" + this.ConditionConfig.Type, "", "");
			}
			try
			{
				bool conditionReached = this.ConditionReached;
				bool flag = ControllerBase<LevelGeneralController>.Instance.HandleCondition(this.ConditionConfig, null, this.Owner.ConditionGroupId.ToString(), eventArgs);
				if (conditionReached != flag)
				{
					this.ConditionReached = flag;
					if (flag)
					{
						this.Owner.CheckReached();
					}
				}
			}
			finally
			{
			}
		}

		// Token: 0x040260FD RID: 155901
		public LevelConditionGroupRegData Owner;

		// Token: 0x040260FE RID: 155902
		public Condition ConditionConfig;

		// Token: 0x040260FF RID: 155903
		public List<EEventName> EventNames;

		// Token: 0x04026100 RID: 155904
		public bool ConditionReached;

		// Token: 0x04026101 RID: 155905
		[Nullable(2)]
		private Stat OnEventInvokeCheckStat;
	}
}
