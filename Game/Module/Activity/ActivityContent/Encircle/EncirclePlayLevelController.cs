using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Encircle
{
	// Token: 0x0200686D RID: 26733
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class EncirclePlayLevelController : Singleton<EncirclePlayLevelController>
	{
		// Token: 0x060429E4 RID: 272868 RVA: 0x011190D0 File Offset: 0x011172D0
		public EncirclePlayLevelController()
		{
			this.StateHandlers = new Dictionary<EPlayStates, Action>
			{
				{
					EPlayStates.START,
					new Action(this.HandleStart)
				},
				{
					EPlayStates.MONSTERMOVE,
					new Action(this.HandleMonsterMove)
				},
				{
					EPlayStates.MAPCHECK,
					new Action(this.HandleMapCheck)
				},
				{
					EPlayStates.END,
					new Action(this.HandleEnd)
				}
			};
		}

		// Token: 0x060429E5 RID: 272869 RVA: 0x0111917F File Offset: 0x0111737F
		public int GetCurrentDifficulty()
		{
			return this.CurrentDifficulty;
		}

		// Token: 0x060429E6 RID: 272870 RVA: 0x01119187 File Offset: 0x01117387
		public int GetCurrentRound()
		{
			return this.Round;
		}

		// Token: 0x060429E7 RID: 272871 RVA: 0x0111918F File Offset: 0x0111738F
		public bool GetGmLog()
		{
			return this.GmLog;
		}

		// Token: 0x060429E8 RID: 272872 RVA: 0x01119197 File Offset: 0x01117397
		public int GetTotalRound()
		{
			return this.Round + this.DifficultyRound;
		}

		// Token: 0x060429E9 RID: 272873 RVA: 0x011191A6 File Offset: 0x011173A6
		public void SetGmLog(bool value)
		{
			this.GmLog = value;
		}

		// Token: 0x060429EA RID: 272874 RVA: 0x011191B0 File Offset: 0x011173B0
		private bool PushNextState()
		{
			EPlayStates currentState;
			if (this.StateTransitions.TryGetValue(this.CurrentState, out currentState))
			{
				this.CurrentState = currentState;
				this.ExecuteStateHandler();
				return true;
			}
			return false;
		}

		// Token: 0x060429EB RID: 272875 RVA: 0x011191E2 File Offset: 0x011173E2
		private bool AddObstacle(int? x, int? y)
		{
			if (!this.EncirclePlayDataManagerField.CheckCanAddObstacle(x, y))
			{
				return false;
			}
			this.EncirclePlayDataManagerField.AddObstacle(x, y);
			return true;
		}

		// Token: 0x060429EC RID: 272876 RVA: 0x01119203 File Offset: 0x01117403
		public bool ClickMapItem(int? x, int? y)
		{
			if (this.CurrentState != EPlayStates.START)
			{
				return false;
			}
			if (this.AddObstacle(x, y))
			{
				this.IncreaseRound();
				this.PushNextState();
				return true;
			}
			return false;
		}

		// Token: 0x060429ED RID: 272877 RVA: 0x0111922C File Offset: 0x0111742C
		private bool TryChangeLevelDifficulty()
		{
			EncirclePlayLevelController.<>c__DisplayClass21_0 CS$<>8__locals1 = new EncirclePlayLevelController.<>c__DisplayClass21_0();
			CS$<>8__locals1.<>4__this = this;
			EncircleChallengeGroup? encircleGroup = ConfigBase<ActivityEncircleConfig>.Instance.GetEncircleGroup(this.GroupId);
			if (encircleGroup.Value.ReduceDiffCnt() == null)
			{
				return false;
			}
			bool flag = false;
			CS$<>8__locals1.targetDifficulty = 0;
			for (int i = this.CurrentDifficulty; i < encircleGroup.Value.ReduceDiffCntIter().Count<int>(); i++)
			{
				int num = encircleGroup.Value.ReduceDiffCnt(i);
				if (this.LoseCount >= num)
				{
					CS$<>8__locals1.targetDifficulty = i + 1;
					flag = true;
				}
			}
			if (flag)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.EncircleDifficultyChangeConfirm);
				confirmBoxDataNew.FunctionMap.Add(1, new Action(this.DoResetEncircle));
				confirmBoxDataNew.FunctionMap.Add(2, new Action(CS$<>8__locals1.<TryChangeLevelDifficulty>g__ConfirmCallback|0));
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			}
			return flag;
		}

		// Token: 0x060429EE RID: 272878 RVA: 0x01119313 File Offset: 0x01117513
		public int GetCurrentChallengeId()
		{
			return this.ChallengeId;
		}

		// Token: 0x060429EF RID: 272879 RVA: 0x0111931B File Offset: 0x0111751B
		[NullableContext(2)]
		public LimitWall GetLimitWallByPosKey(int posKey)
		{
			return this.EncirclePlayDataManagerField.GetLimitWall(posKey);
		}

		// Token: 0x060429F0 RID: 272880 RVA: 0x0111932C File Offset: 0x0111752C
		public void EnterPlay(int groupId, int challengeId)
		{
			EncircleChallengeStartRequest encircleChallengeStartRequest = EncircleChallengeStartRequest.Create();
			encircleChallengeStartRequest.ChallengeId = challengeId;
			ActivityEncircleController.SendEnterRequest(encircleChallengeStartRequest, delegate
			{
				this.InitMap(groupId, challengeId);
			});
		}

		// Token: 0x060429F1 RID: 272881 RVA: 0x01119378 File Offset: 0x01117578
		private void InitMap(int groupId, int challengeId)
		{
			this.GroupId = groupId;
			this.ChallengeId = challengeId;
			this.CurrentDifficulty = 0;
			this.ClearMap();
			Dictionary<int, IHexData> hexes = this.EncirclePlayDataManagerField.InitHexMap(challengeId);
			EncircleArgs param = new EncircleArgs
			{
				Hexes = hexes,
				Height = this.EncirclePlayDataManagerField.GetMapHeight(),
				Width = this.EncirclePlayDataManagerField.GetMapWidth()
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.EncirclePlayView, param, delegate(bool _, int __)
			{
				this.TryShowMonsterMoveEffect();
			});
		}

		// Token: 0x060429F2 RID: 272882 RVA: 0x011193F8 File Offset: 0x011175F8
		public void ClearMap()
		{
			this.CurrentState = EPlayStates.START;
			this.Round = 0;
			this.LoseCount = 0;
			this.DifficultyRound = 0;
			this.ChallengeStartTime = Singleton<TimeUtil>.Instance.GetServerTime();
			this.EncirclePlayDataManagerField.Clear();
		}

		// Token: 0x060429F3 RID: 272883 RVA: 0x01119434 File Offset: 0x01117634
		private void ExecuteStateHandler()
		{
			Action action;
			if (this.StateHandlers.TryGetValue(this.CurrentState, out action))
			{
				action();
			}
		}

		// Token: 0x060429F4 RID: 272884 RVA: 0x0111945C File Offset: 0x0111765C
		private void HandleStart()
		{
			this.TryShowMonsterMoveEffect();
		}

		// Token: 0x060429F5 RID: 272885 RVA: 0x01119464 File Offset: 0x01117664
		public void TryShowMonsterMoveEffect()
		{
			this.EncirclePlayDataManagerField.TryShowMonsterMoveEffect();
		}

		// Token: 0x060429F6 RID: 272886 RVA: 0x01119474 File Offset: 0x01117674
		public void ShowItemMoveEffect(IHexPos monsterPos, bool value)
		{
			EncirclePlayView encirclePlayView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.EncirclePlayView) as EncirclePlayView;
			if (encirclePlayView != null)
			{
				encirclePlayView.ShowItemMoveEffect(Singleton<EncircleUtils>.Instance.HexPosToKey(monsterPos), value);
			}
		}

		// Token: 0x060429F7 RID: 272887 RVA: 0x011194AC File Offset: 0x011176AC
		public void IncreaseRound()
		{
			this.Round++;
			EncirclePlayView encirclePlayView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.EncirclePlayView) as EncirclePlayView;
			if (encirclePlayView != null)
			{
				encirclePlayView.SetCurrentStepText(this.Round);
			}
		}

		// Token: 0x060429F8 RID: 272888 RVA: 0x011194EC File Offset: 0x011176EC
		public void IncreaseDifficultyRound()
		{
			this.DifficultyRound++;
			EncirclePlayView encirclePlayView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.EncirclePlayView) as EncirclePlayView;
			if (encirclePlayView != null)
			{
				encirclePlayView.SetDifficultyStepTxt(this.DifficultyRound);
			}
		}

		// Token: 0x060429F9 RID: 272889 RVA: 0x0111952B File Offset: 0x0111772B
		public void ExecuteWin()
		{
			this.TryCompleteRequest();
		}

		// Token: 0x060429FA RID: 272890 RVA: 0x01119534 File Offset: 0x01117734
		private void ExecuteLose()
		{
			RewardData<IEncircleRewardInfo> rewardData = new RewardData<IEncircleRewardInfo>(null, null);
			EncircleRewardInfo rewardInfo = new EncircleRewardInfo
			{
				ViewName = EUiViewName.EncircleResultView,
				IsSuccess = false,
				Type = ERewardInfoType.Common,
				Score = new int?(this.Round + this.DifficultyRound)
			};
			rewardData.SetRewardInfo(rewardInfo);
			ControllerBase<ActivityEncircleController>.Instance.SendCompleteRequest(this.GenRequestData(0), delegate
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.EncircleResultView, rewardData, null);
			});
		}

		// Token: 0x060429FB RID: 272891 RVA: 0x011195B4 File Offset: 0x011177B4
		private void ShowAgainWinWindow()
		{
			RewardData<IEncircleRewardInfo> rewardData = new RewardData<IEncircleRewardInfo>(null, null);
			EncircleRewardInfo rewardInfo = new EncircleRewardInfo
			{
				ViewName = EUiViewName.EncircleResultView,
				IsSuccess = true,
				Type = ERewardInfoType.Common,
				Score = new int?(this.Round + this.DifficultyRound),
				RecordScore = new int?(ControllerBase<ActivityEncircleController>.Instance.GetEncircleData().GetChallengeRecord(this.ChallengeId))
			};
			rewardData.SetRewardInfo(rewardInfo);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.EncircleResultView, rewardData, null);
		}

		// Token: 0x060429FC RID: 272892 RVA: 0x01119638 File Offset: 0x01117838
		private void TryCompleteRequest()
		{
			ActivityEncircleData encircleData = ControllerBase<ActivityEncircleController>.Instance.GetEncircleData();
			if (encircleData != null && encircleData.CheckChallengeComplete(this.ChallengeId))
			{
				this.ShowAgainWinWindow();
			}
			ControllerBase<ActivityEncircleController>.Instance.SendCompleteRequest(this.GenRequestData(1), new Action(this.ClearMap));
		}

		// Token: 0x060429FD RID: 272893 RVA: 0x01119684 File Offset: 0x01117884
		public void SetAllMonsterDead()
		{
			EncirclePlayView encirclePlayView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.EncirclePlayView) as EncirclePlayView;
			if (encirclePlayView != null)
			{
				encirclePlayView.SetAllMonsterDead(this.EncirclePlayDataManagerField.GetAllMonsterId());
			}
		}

		// Token: 0x060429FE RID: 272894 RVA: 0x011196BA File Offset: 0x011178BA
		public void CloseEncircle()
		{
			ControllerBase<ActivityEncircleController>.Instance.SendCompleteRequest(this.GenRequestData(2), delegate
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.EncirclePlayView, null);
			});
		}

		// Token: 0x060429FF RID: 272895 RVA: 0x011196EC File Offset: 0x011178EC
		public void ResetEncircle()
		{
			EncircleChallengeStartRequest encircleChallengeStartRequest = EncircleChallengeStartRequest.Create();
			encircleChallengeStartRequest.ChallengeId = this.ChallengeId;
			ActivityEncircleController.SendEnterRequest(encircleChallengeStartRequest, delegate
			{
				this.LoseCount++;
				if (!this.TryChangeLevelDifficulty())
				{
					this.DoResetEncircle();
				}
			});
		}

		// Token: 0x06042A00 RID: 272896 RVA: 0x01119710 File Offset: 0x01117910
		private void DoResetEncircle()
		{
			this.CurrentState = EPlayStates.START;
			this.Round = 0;
			this.DifficultyRound = 0;
			this.ChallengeStartTime = Singleton<TimeUtil>.Instance.GetServerTime();
			this.EncirclePlayDataManagerField.Clear();
			Dictionary<int, IHexData> p = this.EncirclePlayDataManagerField.InitHexMap(this.ChallengeId);
			Singleton<EventSystem>.Instance.Emit<Dictionary<int, IHexData>>(EEventName.EncircleReset, p);
			this.TryShowMonsterMoveEffect();
		}

		// Token: 0x06042A01 RID: 272897 RVA: 0x01119778 File Offset: 0x01117978
		public void ChangeViewMapType(int mapItemId, IHexPos currentPos, [Nullable(2)] IHexPos oldPos)
		{
			EncirclePlayView encirclePlayView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.EncirclePlayView) as EncirclePlayView;
			if (encirclePlayView != null)
			{
				encirclePlayView.ChangeEncircleMap(mapItemId, currentPos, oldPos);
			}
		}

		// Token: 0x06042A02 RID: 272898 RVA: 0x011197A6 File Offset: 0x011179A6
		private void HandleMonsterMove()
		{
			if (!this.EncirclePlayDataManagerField.TryMoveMonster())
			{
				this.SetAllMonsterDead();
			}
		}

		// Token: 0x06042A03 RID: 272899 RVA: 0x011197BB File Offset: 0x011179BB
		private void HandleMapCheck()
		{
			this.PushWallLimit();
			if (this.CheckMonsterEscape())
			{
				this.ExecuteLose();
				return;
			}
			this.PushNextState();
		}

		// Token: 0x06042A04 RID: 272900 RVA: 0x011197D9 File Offset: 0x011179D9
		public void TryPushMoveToNextState()
		{
			if (this.CurrentState != EPlayStates.MONSTERMOVE)
			{
				return;
			}
			this.PushNextState();
		}

		// Token: 0x06042A05 RID: 272901 RVA: 0x011197EC File Offset: 0x011179EC
		public void SetMonsterDead(int monsterId)
		{
			EncirclePlayView encirclePlayView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.EncirclePlayView) as EncirclePlayView;
			if (encirclePlayView != null)
			{
				encirclePlayView.SetMonsterDead(monsterId);
			}
		}

		// Token: 0x06042A06 RID: 272902 RVA: 0x01119818 File Offset: 0x01117A18
		private void HandleEnd()
		{
			this.PushNextState();
		}

		// Token: 0x06042A07 RID: 272903 RVA: 0x01119821 File Offset: 0x01117A21
		private bool CheckMonsterEscape()
		{
			return this.EncirclePlayDataManagerField.CheckMonsterEscape();
		}

		// Token: 0x06042A08 RID: 272904 RVA: 0x01119830 File Offset: 0x01117A30
		public EPlayStates GetNextState()
		{
			EPlayStates result;
			this.StateTransitions.TryGetValue(this.CurrentState, out result);
			return result;
		}

		// Token: 0x06042A09 RID: 272905 RVA: 0x01119852 File Offset: 0x01117A52
		private void PushWallLimit()
		{
			this.EncirclePlayDataManagerField.PushWallLimit();
		}

		// Token: 0x06042A0A RID: 272906 RVA: 0x0111985F File Offset: 0x01117A5F
		public bool CheckIsBoundary(IHexPos pos)
		{
			return this.EncirclePlayDataManagerField.CheckIsBoundary(pos);
		}

		// Token: 0x06042A0B RID: 272907 RVA: 0x01119870 File Offset: 0x01117A70
		private EncircleChallengeCompleteRequest GenRequestData(int result)
		{
			EncircleChallengeCompleteRequest encircleChallengeCompleteRequest = EncircleChallengeCompleteRequest.Create();
			encircleChallengeCompleteRequest.ChallengeId = this.ChallengeId;
			encircleChallengeCompleteRequest.Step = this.Round + this.DifficultyRound;
			encircleChallengeCompleteRequest.Result = result;
			encircleChallengeCompleteRequest.ReducedDifficulty = (this.CurrentDifficulty > 0);
			encircleChallengeCompleteRequest.GameSeconds = (int)(Singleton<TimeUtil>.Instance.GetServerTime() - this.ChallengeStartTime);
			return encircleChallengeCompleteRequest;
		}

		// Token: 0x04025135 RID: 151861
		private readonly EncirclePlayDataManager EncirclePlayDataManagerField = new EncirclePlayDataManager();

		// Token: 0x04025136 RID: 151862
		private readonly Dictionary<EPlayStates, EPlayStates> StateTransitions = new Dictionary<EPlayStates, EPlayStates>
		{
			{
				EPlayStates.START,
				EPlayStates.MONSTERMOVE
			},
			{
				EPlayStates.MONSTERMOVE,
				EPlayStates.MAPCHECK
			},
			{
				EPlayStates.MAPCHECK,
				EPlayStates.END
			},
			{
				EPlayStates.END,
				EPlayStates.START
			}
		};

		// Token: 0x04025137 RID: 151863
		private readonly Dictionary<EPlayStates, Action> StateHandlers;

		// Token: 0x04025138 RID: 151864
		private EPlayStates CurrentState;

		// Token: 0x04025139 RID: 151865
		private int CurrentDifficulty;

		// Token: 0x0402513A RID: 151866
		private int LoseCount;

		// Token: 0x0402513B RID: 151867
		private int Round;

		// Token: 0x0402513C RID: 151868
		private int GroupId;

		// Token: 0x0402513D RID: 151869
		private int ChallengeId;

		// Token: 0x0402513E RID: 151870
		private int DifficultyRound;

		// Token: 0x0402513F RID: 151871
		private double ChallengeStartTime = -1.0;

		// Token: 0x04025140 RID: 151872
		private bool GmLog;
	}
}
