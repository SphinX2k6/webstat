using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Model
{
	// Token: 0x020055F9 RID: 22009
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class PhantomArenaBattleModel : ModelBase<PhantomArenaBattleModel>
	{
		// Token: 0x17009005 RID: 36869
		// (get) Token: 0x06038139 RID: 229689 RVA: 0x00E34A4F File Offset: 0x00E32C4F
		public int Round
		{
			get
			{
				return this.RoundInternal;
			}
		}

		// Token: 0x17009006 RID: 36870
		// (get) Token: 0x0603813A RID: 229690 RVA: 0x00E34A57 File Offset: 0x00E32C57
		public int ChallengeId
		{
			get
			{
				return this.ChallengeIdInternal;
			}
		}

		// Token: 0x0603813B RID: 229691 RVA: 0x00E34A60 File Offset: 0x00E32C60
		public PhantomArenaBattleModel()
		{
			this.SpeedList = ConfigBase<CommonConfig>.Instance.GetPhantomArenaBattleSpeed().ToList<float>();
		}

		// Token: 0x0603813C RID: 229692 RVA: 0x00E34AB0 File Offset: 0x00E32CB0
		public void InitData()
		{
			this.RoundInternal = 1;
			this.ReplaceCardData = new PhantomArenaReplaceCardData();
			this.OwnData = new PhantomArenaOwnData();
			this.OpponentData = new PhantomArenaOpponentData();
			this.BattleData = new PhantomArenaBattleData();
			this.BuffEffectData = new PhantomArenaBuffEffectData();
			this.SelectCardData = new PhantomArenaSelectCardData();
		}

		// Token: 0x0603813D RID: 229693 RVA: 0x00E34B08 File Offset: 0x00E32D08
		public void SetChallengeId(int challengeId)
		{
			this.ChallengeIdInternal = challengeId;
			PhantomBattleChallenge phantomBattleChallenge = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallenge(challengeId);
			Activity? activityConfig = ConfigBase<ActivityConfig>.Instance.GetActivityConfig(phantomBattleChallenge.ActivityId);
			this.IsOldBvb = (activityConfig != null && activityConfig.GetValueOrDefault().Type == 52);
		}

		// Token: 0x0603813E RID: 229694 RVA: 0x00E34B5F File Offset: 0x00E32D5F
		public void SetRound(int round)
		{
			this.RoundInternal = round;
			Singleton<EventSystem>.Instance.Emit(EEventName.RefreshRound);
		}

		// Token: 0x0603813F RID: 229695 RVA: 0x00E34B78 File Offset: 0x00E32D78
		public void SetReplaceCardToHandCard(PhantomBattleDealCardReplaceResponse response)
		{
			this.ReplaceCardData.ClearReplaceCardData();
			this.OwnData.RefreshCardLibraryNum(response.CurCardLibraryNum);
			this.OwnData.InitHandData(response.PhantomBattleHandCardInfos.ToArray<PhantomBattleHandCardInfo>());
			Singleton<EventSystem>.Instance.Emit(EEventName.ReplaceCardFinish);
		}

		// Token: 0x06038140 RID: 229696 RVA: 0x00E34BC7 File Offset: 0x00E32DC7
		public void SetReplaceCardToHandCardWithoutChange(IReadOnlyList<PhantomBattleHandCardInfo> dataList)
		{
			this.OwnData.InitHandData(dataList.ToArray<PhantomBattleHandCardInfo>());
		}

		// Token: 0x06038141 RID: 229697 RVA: 0x00E34BDC File Offset: 0x00E32DDC
		public void RefreshFighterAttr(int fightId, Dictionary<int, int> battleAttrMap)
		{
			if (fightId == this.OwnData.FightId)
			{
				this.OwnData.RefreshBattleAttr(battleAttrMap);
				return;
			}
			if (fightId == this.OpponentData.FightId)
			{
				this.OpponentData.RefreshBattleAttr(battleAttrMap);
				return;
			}
			this.OpponentData.RefreshCardAttr(fightId, battleAttrMap);
			this.OwnData.RefreshCardAttr(fightId, battleAttrMap);
		}

		// Token: 0x06038142 RID: 229698 RVA: 0x00E34C3C File Offset: 0x00E32E3C
		public void InitTaskData(IReadOnlyList<PhantomBattleGamerFourCTaskInfo> dataList)
		{
			foreach (PhantomBattleGamerFourCTaskInfo phantomBattleGamerFourCTaskInfo in dataList)
			{
				if (phantomBattleGamerFourCTaskInfo.GamerIndex == 0)
				{
					this.OpponentData.InitTaskData(phantomBattleGamerFourCTaskInfo);
				}
				else
				{
					this.OwnData.InitTaskData(phantomBattleGamerFourCTaskInfo);
				}
			}
		}

		// Token: 0x06038143 RID: 229699 RVA: 0x00E34CA0 File Offset: 0x00E32EA0
		public void InitFieldData()
		{
			this.OpponentData.InitFieldData();
			this.OwnData.InitFieldData();
		}

		// Token: 0x06038144 RID: 229700 RVA: 0x00E34CB8 File Offset: 0x00E32EB8
		public void InitRecycleData()
		{
			this.OpponentData.InitRecycleData();
			this.OwnData.InitRecycleData();
		}

		// Token: 0x06038145 RID: 229701 RVA: 0x00E34CD0 File Offset: 0x00E32ED0
		public void RefreshFieldAndRecycleLockData(IReadOnlyList<AreaSealInfo> sealInfos)
		{
			foreach (AreaSealInfo areaSealInfo in sealInfos)
			{
				if (areaSealInfo.AreaType == BattleAreaType.Retrieve)
				{
					if (areaSealInfo.UId == this.OpponentData.FightId)
					{
						this.OpponentData.RefreshRecycleLockData(areaSealInfo.UnLockRound);
					}
					else
					{
						this.OwnData.RefreshRecycleLockData(areaSealInfo.UnLockRound, true);
					}
				}
				else if (areaSealInfo.AreaType == BattleAreaType.Area)
				{
					if (areaSealInfo.UId == this.OpponentData.FightId)
					{
						this.OpponentData.RefreshFieldLockData(areaSealInfo.UnLockRound, true);
					}
					else
					{
						this.OwnData.RefreshFieldLockData(areaSealInfo.UnLockRound);
					}
				}
			}
		}

		// Token: 0x06038146 RID: 229702 RVA: 0x00E34D9C File Offset: 0x00E32F9C
		public void RefreshTaskData(IReadOnlyList<PhantomBattleGamerFourCTaskInfo> dataList)
		{
			foreach (PhantomBattleGamerFourCTaskInfo phantomBattleGamerFourCTaskInfo in dataList)
			{
				if (phantomBattleGamerFourCTaskInfo.GamerIndex == 0)
				{
					this.OpponentData.RefreshTaskData(phantomBattleGamerFourCTaskInfo);
				}
				else if (phantomBattleGamerFourCTaskInfo.GamerIndex == 1)
				{
					this.OwnData.RefreshTaskData(phantomBattleGamerFourCTaskInfo);
				}
			}
		}

		// Token: 0x06038147 RID: 229703 RVA: 0x00E34E08 File Offset: 0x00E33008
		public bool CheckSkillEnoughCost(int skillId)
		{
			int battleStatusValue = this.OwnData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleCostPoint);
			int costConsume = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleSkillConfig(skillId).CostConsume;
			return battleStatusValue - costConsume >= 0;
		}

		// Token: 0x06038148 RID: 229704 RVA: 0x00E34E3D File Offset: 0x00E3303D
		public List<int> GetFightIdList(List<int> cardIdList)
		{
			List<int> list = new List<int>();
			list.AddRange(this.OwnData.GetFightIdList(cardIdList));
			list.AddRange(this.OpponentData.GetFightIdList(cardIdList));
			return list;
		}

		// Token: 0x06038149 RID: 229705 RVA: 0x00E34E68 File Offset: 0x00E33068
		public void SetSpeedUp()
		{
			this.SpeedUpIndex++;
			if (this.SpeedUpIndex >= this.SpeedList.Count)
			{
				this.SpeedUpIndex = 0;
			}
			this.ApplySpeedUp();
		}

		// Token: 0x0603814A RID: 229706 RVA: 0x00E34E98 File Offset: 0x00E33098
		public void ApplySpeedUp()
		{
			if (!this.IsInBattle)
			{
				return;
			}
			ControllerBase<GameModeController>.Instance.SetTimeDilation(this.SpeedList[this.SpeedUpIndex], ETimeDilationType.PhantomBattleArena);
			this.ApplySpeedBuff(this.SpeedList[this.SpeedUpIndex]);
		}

		// Token: 0x0603814B RID: 229707 RVA: 0x00E34ED6 File Offset: 0x00E330D6
		public float GetSpeedUpText()
		{
			if (this.SpeedUpIndex < this.SpeedList.Count)
			{
				return this.SpeedList[this.SpeedUpIndex];
			}
			return 1f;
		}

		// Token: 0x0603814C RID: 229708 RVA: 0x00E34F02 File Offset: 0x00E33102
		public void SetNormalSpeed()
		{
			this.ApplySpeedBuff(1f);
			ControllerBase<GameModeController>.Instance.SetTimeDilation(1f, ETimeDilationType.PhantomBattleArena);
		}

		// Token: 0x0603814D RID: 229709 RVA: 0x00E34F20 File Offset: 0x00E33120
		protected void ApplySpeedBuff(float speed)
		{
			float timeScale = 1f / speed;
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null || !UKismetSystemLibrary.IsValid(baseCharacter))
			{
				return;
			}
			int entityId = baseCharacter.EntityId;
			PawnTimeScaleComponent component = Singleton<EntitySystem>.Instance.GetComponent<PawnTimeScaleComponent>(entityId);
			if (component != null)
			{
				component.SetForeverTimeScale(ETimeScaleSourceType.PhantomArenaBattle, timeScale, 0, false);
			}
		}

		// Token: 0x0603814E RID: 229710 RVA: 0x00E34F69 File Offset: 0x00E33169
		public void SetIsInBattle(bool inBattle)
		{
			this.IsInBattle = inBattle;
			if (inBattle)
			{
				this.SetTurnCountResultEnd(false);
				this.SetDealCardNotify(null);
				this.SetPhantomBattleBoardSettleNotify(null);
				this.ApplySpeedUp();
				return;
			}
			this.SetNormalSpeed();
		}

		// Token: 0x0603814F RID: 229711 RVA: 0x00E34F97 File Offset: 0x00E33197
		public bool GetTurnCountResultEnd()
		{
			return this.TurnCountResultEnd;
		}

		// Token: 0x06038150 RID: 229712 RVA: 0x00E34F9F File Offset: 0x00E3319F
		public void SetTurnCountResultEnd(bool value)
		{
			this.TurnCountResultEnd = value;
		}

		// Token: 0x06038151 RID: 229713 RVA: 0x00E34FA8 File Offset: 0x00E331A8
		[NullableContext(2)]
		public void SetDealCardNotify(PhantomBattleDealCardNotify notify)
		{
			this.PhantomBattleDealCardNotify = notify;
		}

		// Token: 0x06038152 RID: 229714 RVA: 0x00E34FB1 File Offset: 0x00E331B1
		[NullableContext(2)]
		public void SetPhantomBattleBoardSettleNotify(PhantomBattleBoardSettleNotify notify)
		{
			this.PhantomBattleSettleNotify = notify;
			if (notify != null)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.PhantomBattleBoardSettleNotify);
			}
		}

		// Token: 0x06038153 RID: 229715 RVA: 0x00E34FCD File Offset: 0x00E331CD
		[NullableContext(2)]
		public PhantomBattleDealCardNotify GetDealCardNotify()
		{
			return this.PhantomBattleDealCardNotify;
		}

		// Token: 0x06038154 RID: 229716 RVA: 0x00E34FD5 File Offset: 0x00E331D5
		[NullableContext(2)]
		public PhantomBattleBoardSettleNotify GetPhantomBattleSettleNotify()
		{
			return this.PhantomBattleSettleNotify;
		}

		// Token: 0x06038155 RID: 229717 RVA: 0x00E34FE0 File Offset: 0x00E331E0
		public void TryPhantomBattleDealCardNotify()
		{
			this.SetTurnCountResultEnd(true);
			PhantomBattleDealCardNotify dealCardNotify = this.GetDealCardNotify();
			PhantomBattleBoardSettleNotify phantomBattleSettleNotify = this.GetPhantomBattleSettleNotify();
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.WHJ;
			string message = "声骸竞技场BvB结算表现结束";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("canNext", dealCardNotify != null || phantomBattleSettleNotify != null);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (dealCardNotify != null)
			{
				PhantomArenaBattleController.PhantomBattleDealCardNotify(dealCardNotify, null);
				return;
			}
			if (phantomBattleSettleNotify != null)
			{
				PhantomArenaBattleController.TriggerPhantomBattleBoardSettle();
			}
		}

		// Token: 0x06038156 RID: 229718 RVA: 0x00E35050 File Offset: 0x00E33250
		public void OnClickExitButtonConfirm()
		{
			this.SetIsInBattle(false);
			Singleton<AudioSystem>.Instance.ExecuteAction("play_music_arena_battle", EAudioActionType.Stop, null);
		}

		// Token: 0x06038157 RID: 229719 RVA: 0x00E35080 File Offset: 0x00E33280
		public Dictionary<int, int> GetPhantomTagMap()
		{
			if (this.PhantomTagInited)
			{
				return this.PhantomTagMap;
			}
			this.PhantomTagInited = true;
			foreach (PhantomBattleFactor phantomBattleFactor in ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleAllFactor())
			{
				if (!phantomBattleFactor.IsBeforeBattle && !StringUtils.IsBlank(phantomBattleFactor.Tag))
				{
					int tagIdByName = GameplayTagUtils.GetTagIdByName(phantomBattleFactor.Tag);
					this.PhantomTagMap[tagIdByName] = phantomBattleFactor.Id;
				}
			}
			return this.PhantomTagMap;
		}

		// Token: 0x06038158 RID: 229720 RVA: 0x00E35120 File Offset: 0x00E33320
		public unsafe void AddWaitCallCardIdList(List<int> cardIdList)
		{
			foreach (int num in cardIdList)
			{
				PhantomCardData battleCardByCardId = this.OwnData.GetBattleCardByCardId(num);
				this.WaitCallCardIdMap[num] = battleCardByCardId.Index;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "添加等待召唤卡牌ID列表";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CardIdList", cardIdList);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("WaitCallCardIdMap", this.WaitCallCardIdMap.Count);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x06038159 RID: 229721 RVA: 0x00E351EC File Offset: 0x00E333EC
		public unsafe void RemoveWaitCallCardIdList(List<int> cardIdList)
		{
			foreach (int key in cardIdList)
			{
				this.WaitCallCardIdMap.Remove(key);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "移除等待召唤卡牌ID列表";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CardIdList", cardIdList);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("WaitCallCardIdMap", this.WaitCallCardIdMap.Count);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x0603815A RID: 229722 RVA: 0x00E352A8 File Offset: 0x00E334A8
		public bool InWaitCallCardIdList(int cardId)
		{
			return this.WaitCallCardIdMap.ContainsKey(cardId);
		}

		// Token: 0x0603815B RID: 229723 RVA: 0x00E352B8 File Offset: 0x00E334B8
		private void ClearWaitCallCardIdList()
		{
			this.WaitCallCardIdMap.Clear();
			Singleton<Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "清空等待召唤卡牌ID列表", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0603815C RID: 229724 RVA: 0x00E352F0 File Offset: 0x00E334F0
		public unsafe void AddWaitReconstructCardIdList(List<int> cardIdList)
		{
			foreach (int num in cardIdList)
			{
				PhantomCardData battleCardByCardId = this.OwnData.GetBattleCardByCardId(num);
				this.WaitReconstructCardIdMap[num] = battleCardByCardId.Index;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "添加等待重构卡牌ID列表";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CardIdList", cardIdList);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("WaitReconstructCardIdSet", this.WaitReconstructCardIdMap.Count);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x0603815D RID: 229725 RVA: 0x00E353BC File Offset: 0x00E335BC
		public unsafe void RemoveWaitReconstructCardIdList(List<int> cardIdList)
		{
			foreach (int key in cardIdList)
			{
				this.WaitReconstructCardIdMap.Remove(key);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "移除等待重构卡牌ID列表";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CardIdList", cardIdList);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("WaitReconstructCardIdMap", this.WaitReconstructCardIdMap.Count);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x0603815E RID: 229726 RVA: 0x00E35478 File Offset: 0x00E33678
		public bool InWaitReconstructCardIdList(int cardId)
		{
			return this.WaitReconstructCardIdMap.ContainsKey(cardId);
		}

		// Token: 0x0603815F RID: 229727 RVA: 0x00E35488 File Offset: 0x00E33688
		private void ClearWaitReconstructCardIdList()
		{
			this.WaitReconstructCardIdMap.Clear();
			Singleton<Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "清空等待重构卡牌ID列表", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06038160 RID: 229728 RVA: 0x00E354C0 File Offset: 0x00E336C0
		public bool CanSetSlotIndex(int slotIndex)
		{
			using (Dictionary<int, int>.ValueCollection.Enumerator enumerator = this.WaitCallCardIdMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current == slotIndex)
					{
						return false;
					}
				}
			}
			using (Dictionary<int, int>.ValueCollection.Enumerator enumerator = this.WaitReconstructCardIdMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current == slotIndex)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06038161 RID: 229729 RVA: 0x00E35560 File Offset: 0x00E33760
		public bool CanDragCard(int cardId)
		{
			return !this.InWaitCallCardIdList(cardId) && !this.InWaitReconstructCardIdList(cardId);
		}

		// Token: 0x06038162 RID: 229730 RVA: 0x00E35579 File Offset: 0x00E33779
		public void ClearWaitBattleData()
		{
			this.ClearWaitCallCardIdList();
			this.ClearWaitReconstructCardIdList();
		}

		// Token: 0x040200E8 RID: 131304
		[Nullable(2)]
		public PhantomBattleEnterCtx LoadingConfig;

		// Token: 0x040200E9 RID: 131305
		public int InstId;

		// Token: 0x040200EA RID: 131306
		public PhantomArenaReplaceCardData ReplaceCardData;

		// Token: 0x040200EB RID: 131307
		public PhantomArenaOwnData OwnData;

		// Token: 0x040200EC RID: 131308
		public PhantomArenaOpponentData OpponentData;

		// Token: 0x040200ED RID: 131309
		public PhantomArenaBattleData BattleData;

		// Token: 0x040200EE RID: 131310
		public PhantomArenaBuffEffectData BuffEffectData;

		// Token: 0x040200EF RID: 131311
		public PhantomArenaSelectCardData SelectCardData;

		// Token: 0x040200F0 RID: 131312
		public bool IsNeedShowTimeEndConfirm = true;

		// Token: 0x040200F1 RID: 131313
		private int RoundInternal;

		// Token: 0x040200F2 RID: 131314
		private int SpeedUpIndex;

		// Token: 0x040200F3 RID: 131315
		private readonly List<float> SpeedList;

		// Token: 0x040200F4 RID: 131316
		private bool IsInBattle;

		// Token: 0x040200F5 RID: 131317
		private bool TurnCountResultEnd;

		// Token: 0x040200F6 RID: 131318
		[Nullable(2)]
		private PhantomBattleDealCardNotify PhantomBattleDealCardNotify;

		// Token: 0x040200F7 RID: 131319
		[Nullable(2)]
		private PhantomBattleBoardSettleNotify PhantomBattleSettleNotify;

		// Token: 0x040200F8 RID: 131320
		private bool PhantomTagInited;

		// Token: 0x040200F9 RID: 131321
		private readonly Dictionary<int, int> PhantomTagMap = new Dictionary<int, int>();

		// Token: 0x040200FA RID: 131322
		private int ChallengeIdInternal;

		// Token: 0x040200FB RID: 131323
		public bool IsOldBvb;

		// Token: 0x040200FC RID: 131324
		public bool IsBattleLoading;

		// Token: 0x040200FD RID: 131325
		public int CurrentLoading;

		// Token: 0x040200FE RID: 131326
		private readonly Dictionary<int, int> WaitCallCardIdMap = new Dictionary<int, int>();

		// Token: 0x040200FF RID: 131327
		private readonly Dictionary<int, int> WaitReconstructCardIdMap = new Dictionary<int, int>();
	}
}
