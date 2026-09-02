using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.InstanceDungeon.Define.InstanceDungeonExitHandler
{
	// Token: 0x02005C3C RID: 23612
	public class LordGymExitHandler : InstanceDungeonExitHandlerBase
	{
		// Token: 0x0603BA7B RID: 244347 RVA: 0x00F1CD50 File Offset: 0x00F1AF50
		public override bool Checker()
		{
			return ControllerBase<LordGymController>.Instance.IsInLordGymDungeon();
		}

		// Token: 0x0603BA7C RID: 244348 RVA: 0x00F1CD5C File Offset: 0x00F1AF5C
		[NullableContext(2)]
		public override void HandleExit(InstanceDungeonExitHandlerData data)
		{
			LordGymExitHandler.<>c__DisplayClass1_0 CS$<>8__locals1 = new LordGymExitHandler.<>c__DisplayClass1_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.data = data;
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(this.GetExitConfirmBoxId());
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			Dictionary<int, Action> functionMap = confirmBoxDataNew.FunctionMap;
			int key = 0;
			InstanceDungeonExitHandlerData data2 = CS$<>8__locals1.data;
			functionMap[key] = ((data2 != null) ? data2.CancelBack : null);
			confirmBoxDataNew.FunctionMap[1] = new Action(CS$<>8__locals1.<HandleExit>g__Leave|0);
			confirmBoxDataNew.FunctionMap[2] = new Action(CS$<>8__locals1.<HandleExit>g__ReChallenge|1);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603BA7D RID: 244349 RVA: 0x00F1CDEC File Offset: 0x00F1AFEC
		private void OpenDifficultySelectViewOnLeave()
		{
			ELordGymVersion? curLordGymVersion = this.GetCurLordGymVersion();
			if (curLordGymVersion == null)
			{
				return;
			}
			LordGymDifficultyViewInfo? difficultyViewInfo = this.GetDifficultyViewInfo(curLordGymVersion.Value);
			if (difficultyViewInfo == null)
			{
				return;
			}
			int curLordGymEntranceId = this.GetCurLordGymEntranceId();
			if (curLordGymEntranceId <= 0)
			{
				return;
			}
			ControllerBase<TowerController>.Instance.ClearAllHatredInTower();
			LordGymDifficultySelectViewParam param = new LordGymDifficultySelectViewParam
			{
				LordEntranceSetId = difficultyViewInfo.Value.EntranceSetId,
				LordEntranceId = curLordGymEntranceId,
				IsPlaySpecialSequence = true,
				DefaultLordId = ModelBase<LordGymModel>.Instance.CurrentChallengeLordGymId
			};
			Singleton<UiManager>.Instance.OpenView(difficultyViewInfo.Value.ViewName, param, null);
		}

		// Token: 0x0603BA7E RID: 244350 RVA: 0x00F1CE88 File Offset: 0x00F1B088
		private LordGymDifficultyViewInfo? GetDifficultyViewInfo(ELordGymVersion version)
		{
			switch (version)
			{
			case ELordGymVersion.First:
				return new LordGymDifficultyViewInfo?(new LordGymDifficultyViewInfo
				{
					ViewName = EUiViewName.LordGymFirstDifficultySelectView,
					EntranceSetId = 200105
				});
			case ELordGymVersion.Second:
				return new LordGymDifficultyViewInfo?(new LordGymDifficultyViewInfo
				{
					ViewName = EUiViewName.LordGymSecondDifficultySelectView,
					EntranceSetId = 200102
				});
			case ELordGymVersion.Third:
				return new LordGymDifficultyViewInfo?(new LordGymDifficultyViewInfo
				{
					ViewName = EUiViewName.LordGymThirdDifficultySelectView,
					EntranceSetId = 200103
				});
			case ELordGymVersion.Third5:
				return new LordGymDifficultyViewInfo?(new LordGymDifficultyViewInfo
				{
					ViewName = EUiViewName.LordGymThird5DifficultySelectView,
					EntranceSetId = 200104
				});
			default:
				return null;
			}
		}

		// Token: 0x0603BA7F RID: 244351 RVA: 0x00F1CF58 File Offset: 0x00F1B158
		private int GetCurLordGymEntranceId()
		{
			int currentChallengeLordGymId = ModelBase<LordGymModel>.Instance.CurrentChallengeLordGymId;
			if (currentChallengeLordGymId > 0)
			{
				int entranceIdByLordId = ModelBase<LordGymModel>.Instance.GetEntranceIdByLordId(currentChallengeLordGymId);
				if (entranceIdByLordId > 0)
				{
					return entranceIdByLordId;
				}
			}
			return ModelBase<LordGymModel>.Instance.EntranceEntityId;
		}

		// Token: 0x0603BA80 RID: 244352 RVA: 0x00F1CF90 File Offset: 0x00F1B190
		private EConfirmBoxConfigId GetExitConfirmBoxId()
		{
			ELordGymVersion? curLordGymVersion = this.GetCurLordGymVersion();
			if (curLordGymVersion != null)
			{
				switch (curLordGymVersion.GetValueOrDefault())
				{
				case ELordGymVersion.First:
					return EConfirmBoxConfigId.GuideLordGymExitDungeonConfirm;
				case ELordGymVersion.Second:
					return EConfirmBoxConfigId.GuideLordGymExitDungeonConfirm;
				case ELordGymVersion.Third:
					return EConfirmBoxConfigId.LordGymExitConfirm;
				case ELordGymVersion.Third5:
					return EConfirmBoxConfigId.LordGymThird5ExitConfirm;
				}
			}
			return EConfirmBoxConfigId.LordGymExitConfirm;
		}

		// Token: 0x0603BA81 RID: 244353 RVA: 0x00F1CFEC File Offset: 0x00F1B1EC
		private ELordGymVersion? GetCurLordGymVersion()
		{
			int currentChallengeLordGymId = ModelBase<LordGymModel>.Instance.CurrentChallengeLordGymId;
			if (currentChallengeLordGymId <= 0)
			{
				return null;
			}
			LordGym? lordGymConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymConfig(currentChallengeLordGymId);
			if (lordGymConfig == null)
			{
				return null;
			}
			return new ELordGymVersion?((ELordGymVersion)lordGymConfig.Value.Version);
		}
	}
}
