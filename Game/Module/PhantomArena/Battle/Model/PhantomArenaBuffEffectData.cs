using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhantomArena.Battle.SkillInteract;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Model
{
	// Token: 0x020055FE RID: 22014
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBuffEffectData
	{
		// Token: 0x0603819D RID: 229789 RVA: 0x00E35688 File Offset: 0x00E33888
		private void CreateBuffEffectData(PhantomBattleSkillTriggerInfo skillTriggerInfo, ENotifyMessageId? notifyId = null)
		{
			IBuffEffectData buffData = this.NewBuffEffectData(skillTriggerInfo, notifyId);
			this.PushBuffEffectData(buffData);
		}

		// Token: 0x0603819E RID: 229790 RVA: 0x00E356A5 File Offset: 0x00E338A5
		private void PushBuffEffectData(IBuffEffectData buffData)
		{
			this.BuffEffectDataList.Add(buffData);
			this.HandleReconstructCardEffect(buffData);
		}

		// Token: 0x0603819F RID: 229791 RVA: 0x00E356BC File Offset: 0x00E338BC
		private void HandleReconstructCardEffect(IBuffEffectData buffData)
		{
			PhantomBattleEffectResultInfo effect = buffData.Effect;
			if (((effect != null) ? effect.PhantomBattleReconstruct : null) != null)
			{
				PhantomBattleReconstruct phantomBattleReconstruct = buffData.Effect.PhantomBattleReconstruct;
				if (phantomBattleReconstruct.Camp == PhantomBattleEffectCardCamp.GamerFighterPlayer)
				{
					ModelBase<PhantomArenaBattleModel>.Instance.AddWaitReconstructCardIdList(phantomBattleReconstruct.CardUid.ToList<int>());
				}
			}
		}

		// Token: 0x060381A0 RID: 229792 RVA: 0x00E35708 File Offset: 0x00E33908
		public void PushBuffEffectDataBySkillList(PhantomBattleSkillTriggerInfo[] skillTriggerInfoList, ENotifyMessageId notifyId)
		{
			foreach (PhantomBattleSkillTriggerInfo skillTriggerInfo in skillTriggerInfoList)
			{
				this.CreateBuffEffectData(skillTriggerInfo, new ENotifyMessageId?(notifyId));
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.PhantomArenaTriggerSkillEffect);
		}

		// Token: 0x060381A1 RID: 229793 RVA: 0x00E35748 File Offset: 0x00E33948
		public void PushBuffEffectDataBySkill(PhantomBattleSkillTriggerInfo skillTriggerInfo)
		{
			this.CreateBuffEffectData(skillTriggerInfo, null);
			Singleton<EventSystem>.Instance.Emit(EEventName.PhantomArenaTriggerSkillEffect);
		}

		// Token: 0x060381A2 RID: 229794 RVA: 0x00E35778 File Offset: 0x00E33978
		private void PushBuffEffectDataByEffect(PhantomBattleBuffTriggerInfo buffTriggerInfo, ENotifyMessageId notifyId)
		{
			BuffEffectData buffData = new BuffEffectData
			{
				SourceFightId = buffTriggerInfo.SourceFighterUId,
				SkillId = buffTriggerInfo.PhantomBattleBuffId,
				SelectFightIdList = new List<int>(buffTriggerInfo.SelectFighterUId),
				Effect = buffTriggerInfo.PhantomBattleEffectResultInfo,
				NotifyId = new ENotifyMessageId?(notifyId)
			};
			this.PushBuffEffectData(buffData);
		}

		// Token: 0x060381A3 RID: 229795 RVA: 0x00E357D4 File Offset: 0x00E339D4
		public void PushBuffEffectDataByEffectList(PhantomBattleBuffTriggerInfo[] buffTriggerInfoList, ENotifyMessageId notifyId)
		{
			foreach (PhantomBattleBuffTriggerInfo buffTriggerInfo in buffTriggerInfoList)
			{
				this.PushBuffEffectDataByEffect(buffTriggerInfo, notifyId);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.PhantomArenaTriggerSkillEffect);
		}

		// Token: 0x060381A4 RID: 229796 RVA: 0x00E35810 File Offset: 0x00E33A10
		public void PushBuffEffectDataByNpc(int fightId, NpcPhantomBattleCardSkillInfo info, ENotifyMessageId notifyId, bool isWaitEffect)
		{
			BuffEffectData buffData = new BuffEffectData
			{
				SourceFightId = fightId,
				SkillId = info.SkillId,
				SelectFightIdList = new List<int>(info.SelectFighterUId),
				Effect = info.PhantomBattleEffectResultInfo,
				NotifyId = new ENotifyMessageId?(notifyId)
			};
			this.PushBuffEffectData(buffData);
			if (isWaitEffect)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.PhantomArenaTriggerSkillEffect);
			}
		}

		// Token: 0x060381A5 RID: 229797 RVA: 0x00E3587C File Offset: 0x00E33A7C
		public void PushBuffEffectDataByNpc(int fightId, NpcPhantomBattleCardDurableSkillInfo info, ENotifyMessageId notifyId, bool isWaitEffect)
		{
			BuffEffectData buffData = new BuffEffectData
			{
				SourceFightId = fightId,
				SkillId = info.SkillId,
				SelectFightIdList = new List<int>(info.SelectFighterUId),
				Effect = info.PhantomBattleEffectResultInfo,
				NotifyId = new ENotifyMessageId?(notifyId)
			};
			this.PushBuffEffectData(buffData);
			if (isWaitEffect)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.PhantomArenaTriggerSkillEffect);
			}
		}

		// Token: 0x060381A6 RID: 229798 RVA: 0x00E358E6 File Offset: 0x00E33AE6
		public IBuffEffectData PopBuffEffectData()
		{
			if (this.BuffEffectDataList.Count > 0)
			{
				IBuffEffectData result = this.BuffEffectDataList[0];
				this.BuffEffectDataList.RemoveAt(0);
				return result;
			}
			return null;
		}

		// Token: 0x060381A7 RID: 229799 RVA: 0x00E35910 File Offset: 0x00E33B10
		public void SetCardSkillTriggerInfo(EPhantomArenaBuffEffectType effectType, List<int> fightIdList, int selectNum, int cardId, bool isFight, int skillId, bool isClickInteract)
		{
			this.CardSkillTriggerInfo = new SkillTriggerInfo
			{
				InteractType = effectType,
				SelectFightIdList = fightIdList,
				SelectNum = selectNum,
				SkillId = new int?(skillId),
				DataId = new int?(cardId),
				IsRole = false,
				IsPassive = false,
				IsFight = isFight,
				IsClickInteract = isClickInteract
			};
		}

		// Token: 0x060381A8 RID: 229800 RVA: 0x00E35978 File Offset: 0x00E33B78
		public void SetRoleSkillTriggerInfo(EPhantomArenaBuffEffectType effectType, List<int> fightIdList, int selectNum, int skillId)
		{
			this.RoleSkillTriggerInfo = new SkillTriggerInfo
			{
				InteractType = effectType,
				SelectFightIdList = fightIdList,
				SelectNum = selectNum,
				DataId = new int?(skillId),
				IsRole = true,
				IsPassive = false,
				IsFight = false,
				IsClickInteract = false
			};
		}

		// Token: 0x060381A9 RID: 229801 RVA: 0x00E359D0 File Offset: 0x00E33BD0
		public IBuffEffectData NewBuffEffectData(PhantomBattleSkillTriggerInfo skillTriggerInfo, ENotifyMessageId? notifyId = null)
		{
			return new BuffEffectData
			{
				SourceFightId = skillTriggerInfo.SourceFighterUId,
				SkillId = skillTriggerInfo.SkillId,
				SelectFightIdList = new List<int>(skillTriggerInfo.SelectFighterUId),
				Effect = skillTriggerInfo.PhantomBattleEffectResultInfo,
				NotifyId = notifyId
			};
		}

		// Token: 0x0402010E RID: 131342
		private readonly List<IBuffEffectData> BuffEffectDataList = new List<IBuffEffectData>();

		// Token: 0x0402010F RID: 131343
		public ISkillTriggerInfo CardSkillTriggerInfo;

		// Token: 0x04020110 RID: 131344
		public ISkillTriggerInfo RoleSkillTriggerInfo;
	}
}
