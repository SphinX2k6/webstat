using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.Activity.ActivityContent.ChessGameplay.StackableChess;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.RacingBets.Data;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RacingBets
{
	// Token: 0x0200529A RID: 21146
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class RacingBetsModel : ModelBase<RacingBetsModel>
	{
		// Token: 0x060360EF RID: 221423 RVA: 0x00D9BEF3 File Offset: 0x00D9A0F3
		protected override bool OnClear()
		{
			this.ClearDungeonEffects();
			this.RemoveRankTimer();
			return true;
		}

		// Token: 0x060360F0 RID: 221424 RVA: 0x00D9BF04 File Offset: 0x00D9A104
		public void OnPlayerInfoUpdate(RacingBetPlayerInfo playerInfo)
		{
			if (this.SeasonData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.RacingBets, ELogAuthor.BB, "OnPlayerInfoUpdate SeasonData is not undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.SeasonData.RefreshPlayerData(playerInfo);
		}

		// Token: 0x060360F1 RID: 221425 RVA: 0x00D9BF45 File Offset: 0x00D9A145
		public void OnRacingBetsTaskNotify(RacingBetsTaskNotify message)
		{
			if (this.SeasonData == null)
			{
				return;
			}
			this.SeasonData.RefreshRewardData(message.TaskDatas.ToList<ConditionTaskData>());
		}

		// Token: 0x060360F2 RID: 221426 RVA: 0x00D9BF66 File Offset: 0x00D9A166
		public void OnRacingBetsMatchInfoRefresh(RacingBetsMatchInfoResponse message)
		{
			if (this.SeasonData == null)
			{
				return;
			}
			this.SeasonData.RefreshMatchInfo(message);
		}

		// Token: 0x060360F3 RID: 221427 RVA: 0x00D9BF80 File Offset: 0x00D9A180
		public void OnRacingBetsMatchResultNotify(RacingBetLegMatchResultNotify message)
		{
			if (this.SeasonData == null)
			{
				return;
			}
			this.LegMatchResult = message;
			if (message != null)
			{
				int legMatchId = message.LegMatchId;
				RacingBetsLegMatchData legMatchData = this.SeasonData.GetLegMatchData(legMatchId);
				if (legMatchData != null)
				{
					legMatchData.RefreshLegMatchResultNotify(message);
				}
			}
		}

		// Token: 0x060360F4 RID: 221428 RVA: 0x00D9BFC0 File Offset: 0x00D9A1C0
		public void OnRacingBetsOddsUpdate(RacingBetsUpdateOddsResponse message)
		{
			if (this.SeasonData == null)
			{
				return;
			}
			RacingBetsLegMatchData legMatchData = this.SeasonData.GetLegMatchData(message.LegMatchId);
			if (legMatchData == null)
			{
				return;
			}
			legMatchData.RefreshDangoOdds(message);
		}

		// Token: 0x060360F5 RID: 221429 RVA: 0x00D9BFF3 File Offset: 0x00D9A1F3
		public void OnRacingBetsCloseSettleMenu(int legMatchId)
		{
			if (this.SeasonData == null)
			{
				return;
			}
			this.SeasonData.AddCloseSettleLegMatchId(legMatchId);
		}

		// Token: 0x060360F6 RID: 221430 RVA: 0x00D9C00C File Offset: 0x00D9A20C
		public void RefreshLegMatchResult(MatchResult matchResult)
		{
			if (this.SeasonData == null)
			{
				return;
			}
			RacingBetsLegMatchData legMatchData = this.SeasonData.GetLegMatchData(matchResult.LegMatchId);
			if (legMatchData == null)
			{
				return;
			}
			legMatchData.RefreshLegMatchResult(matchResult);
			if (matchResult.PromoteNum > 0)
			{
				legMatchData.ParentGroupMatchData.RefreshGroupMatchResult(matchResult);
			}
			this.CheckMatchRedDot();
		}

		// Token: 0x060360F7 RID: 221431 RVA: 0x00D9C05A File Offset: 0x00D9A25A
		[NullableContext(2)]
		public RacingBetsSeasonData GetRacingBetsSeasonData()
		{
			return this.SeasonData;
		}

		// Token: 0x060360F8 RID: 221432 RVA: 0x00D9C064 File Offset: 0x00D9A264
		public void SetRacingBetsSeasonData(RacingBetsSeasonData data)
		{
			if (this.SeasonData != null)
			{
				Singleton<Log>.Instance.Error(ELogModule.RacingBets, ELogAuthor.BB, "SetRacingBetsSeasonData SeasonData is not undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.SeasonData = data;
		}

		// Token: 0x060360F9 RID: 221433 RVA: 0x00D9C0A0 File Offset: 0x00D9A2A0
		[NullableContext(2)]
		public RacingBetsLegMatchData GetRacingBetsLegMatchData(int legMatchId)
		{
			if (this.SeasonData == null)
			{
				return null;
			}
			return this.SeasonData.GetLegMatchData(legMatchId);
		}

		// Token: 0x060360FA RID: 221434 RVA: 0x00D9C0B8 File Offset: 0x00D9A2B8
		[NullableContext(2)]
		public RacingBetLegMatchResultNotify GetLegMatchResultData()
		{
			return this.LegMatchResult;
		}

		// Token: 0x060360FB RID: 221435 RVA: 0x00D9C0C0 File Offset: 0x00D9A2C0
		[NullableContext(2)]
		public void SetLegMatchResultData(RacingBetLegMatchResultNotify data)
		{
			this.LegMatchResult = data;
		}

		// Token: 0x060360FC RID: 221436 RVA: 0x00D9C0C9 File Offset: 0x00D9A2C9
		[NullableContext(2)]
		public RacingBetsGroupMatchData GetRacingBetsGroupMatchData(int matchId)
		{
			if (this.SeasonData == null)
			{
				return null;
			}
			return this.SeasonData.GetGroupMatchData(matchId);
		}

		// Token: 0x060360FD RID: 221437 RVA: 0x00D9C0E1 File Offset: 0x00D9A2E1
		[NullableContext(2)]
		public IReadOnlyList<RacingBettingGear> GetRacingBetsGearList()
		{
			if (this.SeasonData == null)
			{
				return null;
			}
			return ConfigBase<RacingBetsConfig>.Instance.GetRacingBettingGearList(this.SeasonData.Id);
		}

		// Token: 0x060360FE RID: 221438 RVA: 0x00D9C104 File Offset: 0x00D9A304
		public List<RacingBetsBulletScreen> GetRacingBetsBulletScreen(ERacingBetsBulletScreenType bulletType)
		{
			if (this.SeasonData == null)
			{
				return new List<RacingBetsBulletScreen>();
			}
			List<RacingBetsBulletScreen> list = new List<RacingBetsBulletScreen>();
			foreach (RacingBetsBulletScreen item in ConfigBase<RacingBetsConfig>.Instance.GetRacingBetsBulletScreenList(this.SeasonData.Id))
			{
				if (item.Type == (int)bulletType)
				{
					if (item.DangoId == 0)
					{
						list.Add(item);
					}
					else if (this.GetDungeonDangoInfo(item.DangoId) != null)
					{
						list.Add(item);
					}
				}
			}
			return list;
		}

		// Token: 0x060360FF RID: 221439 RVA: 0x00D9C1A0 File Offset: 0x00D9A3A0
		public bool IsFinalLegMatch(int legMatchId)
		{
			return this.SeasonData != null && this.SeasonData.IsFinalLegMatch(legMatchId);
		}

		// Token: 0x06036100 RID: 221440 RVA: 0x00D9C1B8 File Offset: 0x00D9A3B8
		public void RacingBetsMatchStart(int legMatchId, RacingBetMatchActionResponse message)
		{
			if (this.IsDungeonPlaying)
			{
				Singleton<Log>.Instance.Error(ELogModule.RacingBets, ELogAuthor.BB, "RacingBets玩法重复开始", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.IsDungeonPlaying = true;
			this.DungeonMatchId = legMatchId;
			this.IsReplayDungeon = message.Replay;
			this.InitDungeonDangoInfo(message.DangoInfo.ToList<RacingBetsInstanceDangoInfo>());
			this.RefreshDangoDungeonAudio(legMatchId);
			this.CommandQueue.Init();
			this.CommandQueue.BindCommandQueueEndCallBack(delegate(bool isAborted)
			{
				this.OnDangoDungeonEnd(isAborted).Forget();
			});
			this.PushDungeonInitCommand(this.DungeonAllDangoList);
			this.PushOpenGamePlayViewCommand();
			for (int i = 0; i < message.Rounds.Count; i++)
			{
				RacingBetsMatchRoundInfo roundData = message.Rounds[i];
				this.RacingBetsMatchRoundRefresh(legMatchId, roundData, i == message.Rounds.Count - 1);
			}
			this.CommandQueue.Execute().Forget();
		}

		// Token: 0x06036101 RID: 221441 RVA: 0x00D9C2A0 File Offset: 0x00D9A4A0
		private void InitDungeonDangoInfo(List<RacingBetsInstanceDangoInfo> dangoInfoList)
		{
			this.DungeonDangoSortList = new List<RacingBetsDungeonDangoInfo>();
			this.DungeonDangoMap.Clear();
			List<RacingBetsDungeonDangoInfo> list = new List<RacingBetsDungeonDangoInfo>();
			foreach (RacingBetsInstanceDangoInfo message in dangoInfoList)
			{
				RacingBetsDungeonDangoInfo racingBetsDungeonDangoInfo = new RacingBetsDungeonDangoInfo(message);
				this.DungeonDangoMap.Add(racingBetsDungeonDangoInfo.DangoId, racingBetsDungeonDangoInfo);
				if (racingBetsDungeonDangoInfo.IsAbuDango())
				{
					list.Add(racingBetsDungeonDangoInfo);
				}
				else
				{
					this.DungeonDangoSortList.Add(racingBetsDungeonDangoInfo);
				}
			}
			this.DungeonDangoSortList.Sort(delegate(RacingBetsDungeonDangoInfo a, RacingBetsDungeonDangoInfo b)
			{
				if (a.CurPoint != b.CurPoint)
				{
					return b.CurPoint.CompareTo(a.CurPoint);
				}
				return b.High.CompareTo(a.High);
			});
			for (int i = 0; i < this.DungeonDangoSortList.Count; i++)
			{
				this.DungeonDangoSortList[i].Rank = i + 1;
			}
			this.DungeonAllDangoList = new List<RacingBetsDungeonDangoInfo>(this.DungeonDangoSortList);
			this.DungeonAllDangoList.AddRange(list);
		}

		// Token: 0x06036102 RID: 221442 RVA: 0x00D9C3A8 File Offset: 0x00D9A5A8
		public void RacingBetsMatchRoundRefresh(int legMatchId, RacingBetsMatchRoundInfo roundData, bool needRequireNextRound)
		{
			this.RacingBetsMatchRoundActionRefresh(roundData);
			if (roundData.IsFinalRound)
			{
				this.RefreshLegMatchResult(roundData.Result);
				RacingBetsLegMatchData legMatchData = this.SeasonData.GetLegMatchData(legMatchId);
				this.PushOpenRacingBetsDungeonResultViewCommand(legMatchData);
				return;
			}
			if (needRequireNextRound)
			{
				this.PushRacingBetsNextRoundRequestCommand(this.SeasonData.Id, legMatchId, roundData.RoundRank + 1);
			}
		}

		// Token: 0x06036103 RID: 221443 RVA: 0x00D9C404 File Offset: 0x00D9A604
		public void RacingBetsMatchPreview(int legMatchId, RacingBetMatchInfoResponse message)
		{
			if (this.IsDungeonPlaying)
			{
				Singleton<Log>.Instance.Error(ELogModule.RacingBets, ELogAuthor.BB, "RacingBets玩法重复开始", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.IsDungeonPlaying = true;
			this.DungeonMatchId = legMatchId;
			this.InitDungeonDangoInfo(message.DangoInfo.ToList<RacingBetsInstanceDangoInfo>());
			this.RefreshDangoDungeonAudio(legMatchId);
			this.CommandQueue.Init();
			this.CommandQueue.BindCommandQueueEndCallBack(new Action<bool>(this.OnDangoDungeonPreviewEnd));
			RacingBetsLegMatchData racingBetsLegMatchData = this.GetRacingBetsLegMatchData(legMatchId);
			bool flag = racingBetsLegMatchData != null && racingBetsLegMatchData.Type == 1;
			List<RacingBetsDungeonDangoInfo> list = new List<RacingBetsDungeonDangoInfo>();
			if (flag)
			{
				using (List<RacingBetsDungeonDangoInfo>.Enumerator enumerator = this.DungeonAllDangoList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						RacingBetsDungeonDangoInfo racingBetsDungeonDangoInfo = enumerator.Current;
						if (racingBetsDungeonDangoInfo.IsAbuDango())
						{
							list.Add(racingBetsDungeonDangoInfo);
						}
					}
					goto IL_D3;
				}
			}
			list = this.DungeonAllDangoList;
			IL_D3:
			this.PushDungeonInitCommand(list);
			this.PushOpenGamePlayerPreviewViewCommand(true);
			this.CommandQueue.Execute().Forget();
		}

		// Token: 0x06036104 RID: 221444 RVA: 0x00D9C514 File Offset: 0x00D9A714
		public void RacingBetsMatchRoundActionRefresh(RacingBetsMatchRoundInfo roundData)
		{
			foreach (RacingBetsInstanceRoundAction racingBetsInstanceRoundAction in roundData.RoundAction)
			{
				RacingBetsCommandBase racingBetsCommandBase = null;
				switch (racingBetsInstanceRoundAction.ActionType)
				{
				case RacingBetsRoundActionType.MatchStart:
					racingBetsCommandBase = this.PushRacingBetsDungeonBeginCommand();
					break;
				case RacingBetsRoundActionType.RoundStart:
					racingBetsCommandBase = this.PushRacingBetsRoundStartCommand();
					break;
				case RacingBetsRoundActionType.DangoRoundStart:
					racingBetsCommandBase = this.PushRacingBetsDangoRoundStartCommand(racingBetsInstanceRoundAction.DangoStart.DangoId);
					break;
				case RacingBetsRoundActionType.MatchRoundDice:
					racingBetsCommandBase = this.PushRacingBetsDiceCommand(roundData.RoundRank, racingBetsInstanceRoundAction.DiceInfo.DiceInfo.ToList<DangoIdToDiceNum>());
					break;
				case RacingBetsRoundActionType.DangoMove:
					racingBetsCommandBase = this.PushRacingBetsDangoMoveCommand(racingBetsInstanceRoundAction.Move);
					break;
				case RacingBetsRoundActionType.DangoSkill:
					racingBetsCommandBase = this.PushRacingBetsSkillCommand(racingBetsInstanceRoundAction.Skill);
					break;
				case RacingBetsRoundActionType.DangoChangeHigh:
					racingBetsCommandBase = this.PushRacingBetsDangoChangeHighCommand(racingBetsInstanceRoundAction.ChangeHigh);
					break;
				case RacingBetsRoundActionType.CameraMove:
					racingBetsCommandBase = this.PushRacingBetsChangeDangoCameraBlendCommand(racingBetsInstanceRoundAction.CameraMove.DangoId);
					break;
				case RacingBetsRoundActionType.Destination:
					racingBetsCommandBase = this.PushRacingBetsDangoDestinationCommand(racingBetsInstanceRoundAction.Destination.DangoId);
					break;
				case RacingBetsRoundActionType.UpdateRank:
					racingBetsCommandBase = this.PushRacingBetsDangoRankChangeCommand(racingBetsInstanceRoundAction.UpdateRank.DangoId.ToList<int>());
					break;
				case RacingBetsRoundActionType.Transmit:
					racingBetsCommandBase = this.PushRacingBetsDangoTransmitCommand(racingBetsInstanceRoundAction.Transmit);
					break;
				case RacingBetsRoundActionType.OrganEffect:
					racingBetsCommandBase = this.PushRacingBetsOrganEffectCommand(racingBetsInstanceRoundAction.OrganEffect);
					break;
				case RacingBetsRoundActionType.BlackHoleTransmit:
					racingBetsCommandBase = this.PushRacingBetsBlackHoleTransmitCommand(racingBetsInstanceRoundAction.BlackHoleTransmit);
					break;
				}
				racingBetsCommandBase.ActionIndex = racingBetsInstanceRoundAction.ActionIndex;
				racingBetsCommandBase.PushBulletScreenTimes(racingBetsInstanceRoundAction.BulletScreenTimes.ToList<BulletScreenTimes>());
			}
		}

		// Token: 0x06036105 RID: 221445 RVA: 0x00D9C6C0 File Offset: 0x00D9A8C0
		public bool RefreshBetsDangoRankInfo(List<int> dangoRankList)
		{
			bool flag = false;
			int num = 1;
			foreach (int key in dangoRankList)
			{
				RacingBetsDungeonDangoInfo racingBetsDungeonDangoInfo;
				if (this.DungeonDangoMap.TryGetValue(key, out racingBetsDungeonDangoInfo) && !racingBetsDungeonDangoInfo.IsAbuDango())
				{
					if (racingBetsDungeonDangoInfo.Rank != num)
					{
						flag = true;
					}
					racingBetsDungeonDangoInfo.LastRank = racingBetsDungeonDangoInfo.Rank;
					racingBetsDungeonDangoInfo.Rank = num;
					num++;
				}
			}
			if (flag)
			{
				this.DungeonDangoSortList.Sort((RacingBetsDungeonDangoInfo a, RacingBetsDungeonDangoInfo b) => a.Rank.CompareTo(b.Rank));
			}
			return flag;
		}

		// Token: 0x06036106 RID: 221446 RVA: 0x00D9C778 File Offset: 0x00D9A978
		private RacingBetsCommandBase PushDungeonInitCommand(List<RacingBetsDungeonDangoInfo> dangoInfoList)
		{
			int id = this.SeasonData.Id;
			IReadOnlyList<RacingBetMapPoint> racingBetMapPointList = ConfigBase<RacingBetsConfig>.Instance.GetRacingBetMapPointList(id);
			RacingBetsCommandBase racingBetsCommandBase = DangoDungeonCommandFactory.CreateRacingBetsInitDungeonCommand(dangoInfoList, racingBetMapPointList, id);
			this.CommandQueue.AddCommand(racingBetsCommandBase);
			return racingBetsCommandBase;
		}

		// Token: 0x06036107 RID: 221447 RVA: 0x00D9C7B4 File Offset: 0x00D9A9B4
		private RacingBetsCommandBase PushOpenGamePlayViewCommand()
		{
			RacingBetsCommandBase racingBetsCommandBase = DangoDungeonCommandFactory.CreateOpenRacingBetsGameplayView();
			this.CommandQueue.AddCommand(racingBetsCommandBase);
			return racingBetsCommandBase;
		}

		// Token: 0x06036108 RID: 221448 RVA: 0x00D9C7D4 File Offset: 0x00D9A9D4
		private RacingBetsCommandBase PushOpenGamePlayerPreviewViewCommand(bool canCameraInput = false)
		{
			RacingBetsCommandBase racingBetsCommandBase = DangoDungeonCommandFactory.CreateOpenRacingBetsGamePlayPreviewView(canCameraInput);
			this.CommandQueue.AddCommand(racingBetsCommandBase);
			return racingBetsCommandBase;
		}

		// Token: 0x06036109 RID: 221449 RVA: 0x00D9C7F8 File Offset: 0x00D9A9F8
		private RacingBetsCommandBase PushRacingBetsDungeonBeginCommand()
		{
			RacingBetsCommandBase racingBetsCommandBase = DangoDungeonCommandFactory.CreateRacingBetsDungeonBeginCommand();
			this.CommandQueue.AddCommand(racingBetsCommandBase);
			return racingBetsCommandBase;
		}

		// Token: 0x0603610A RID: 221450 RVA: 0x00D9C818 File Offset: 0x00D9AA18
		private RacingBetsCommandBase PushRacingBetsRoundStartCommand()
		{
			RacingBetsCommandBase racingBetsCommandBase = DangoDungeonCommandFactory.CreateRacingBetsRoundStartCommand();
			this.CommandQueue.AddCommand(racingBetsCommandBase);
			return racingBetsCommandBase;
		}

		// Token: 0x0603610B RID: 221451 RVA: 0x00D9C838 File Offset: 0x00D9AA38
		private RacingBetsCommandBase PushRacingBetsDangoRoundStartCommand(int dangoId)
		{
			RacingBetsDangoRoundStartCommand racingBetsDangoRoundStartCommand = DangoDungeonCommandFactory.CreateRacingBetsDangoRoundStartCommand(dangoId);
			this.CommandQueue.AddCommand(racingBetsDangoRoundStartCommand);
			return racingBetsDangoRoundStartCommand;
		}

		// Token: 0x0603610C RID: 221452 RVA: 0x00D9C85C File Offset: 0x00D9AA5C
		private RacingBetsCommandBase PushRacingBetsDiceCommand(int round, List<DangoIdToDiceNum> dangoDiceList)
		{
			RacingBetsCommandBase racingBetsCommandBase = DangoDungeonCommandFactory.CreateRacingBetsDiceCommand(round, dangoDiceList);
			this.CommandQueue.AddCommand(racingBetsCommandBase);
			return racingBetsCommandBase;
		}

		// Token: 0x0603610D RID: 221453 RVA: 0x00D9C880 File Offset: 0x00D9AA80
		private RacingBetsCommandBase PushRacingBetsSkillCommand(RacingBetsDangoActionSkill skillAction)
		{
			RacingBetsCommandBase racingBetsCommandBase = DangoDungeonCommandFactory.CreateRacingBetsSkillCommand(skillAction);
			this.CommandQueue.AddCommand(racingBetsCommandBase);
			return racingBetsCommandBase;
		}

		// Token: 0x0603610E RID: 221454 RVA: 0x00D9C8A4 File Offset: 0x00D9AAA4
		private RacingBetsCommandBase PushRacingBetsDangoMoveCommand(RacingBetsDangoActionMove moveAction)
		{
			RacingBetsCommandBase racingBetsCommandBase = DangoDungeonCommandFactory.CreateRacingBetsDangoMoveCommand(moveAction);
			this.CommandQueue.AddCommand(racingBetsCommandBase);
			return racingBetsCommandBase;
		}

		// Token: 0x0603610F RID: 221455 RVA: 0x00D9C8C8 File Offset: 0x00D9AAC8
		private RacingBetsCommandBase PushRacingBetsDangoChangeHighCommand(RacingBetsDangoActionChangeHigh changeHighAction)
		{
			RacingBetsCommandBase racingBetsCommandBase = DangoDungeonCommandFactory.CreateRacingBetsDangoChangeHighCommand(changeHighAction);
			this.CommandQueue.AddCommand(racingBetsCommandBase);
			return racingBetsCommandBase;
		}

		// Token: 0x06036110 RID: 221456 RVA: 0x00D9C8EC File Offset: 0x00D9AAEC
		private RacingBetsCommandBase PushRacingBetsChangeDangoCameraBlendCommand(int dangoId)
		{
			RacingBetsCommandBase racingBetsCommandBase = DangoDungeonCommandFactory.CreateRacingBetsChangeDangoCameraBlendCommand(dangoId);
			this.CommandQueue.AddCommand(racingBetsCommandBase);
			return racingBetsCommandBase;
		}

		// Token: 0x06036111 RID: 221457 RVA: 0x00D9C910 File Offset: 0x00D9AB10
		private RacingBetsCommandBase PushRacingBetsNextRoundRequestCommand(int activityId, int legMatchId, int roundId)
		{
			RacingBetsNextRoundRequestCommand racingBetsNextRoundRequestCommand = DangoDungeonCommandFactory.CreateRacingBetsNextRoundRequestCommand(activityId, legMatchId, roundId);
			this.CommandQueue.AddCommand(racingBetsNextRoundRequestCommand);
			return racingBetsNextRoundRequestCommand;
		}

		// Token: 0x06036112 RID: 221458 RVA: 0x00D9C934 File Offset: 0x00D9AB34
		private RacingBetsCommandBase PushOpenRacingBetsDungeonResultViewCommand(RacingBetsLegMatchData legMatchData)
		{
			OpenRacingBetsDungeonResultViewCommand openRacingBetsDungeonResultViewCommand = DangoDungeonCommandFactory.CreateOpenRacingBetsDungeonResultView(legMatchData);
			this.CommandQueue.AddCommand(openRacingBetsDungeonResultViewCommand);
			return openRacingBetsDungeonResultViewCommand;
		}

		// Token: 0x06036113 RID: 221459 RVA: 0x00D9C958 File Offset: 0x00D9AB58
		private RacingBetsCommandBase PushRacingBetsDangoDestinationCommand(int dangoId)
		{
			RacingBetsDangoDestinationCommand racingBetsDangoDestinationCommand = DangoDungeonCommandFactory.CreateRacingBetsDangoDestinationCommand(dangoId);
			this.CommandQueue.AddCommand(racingBetsDangoDestinationCommand);
			return racingBetsDangoDestinationCommand;
		}

		// Token: 0x06036114 RID: 221460 RVA: 0x00D9C97C File Offset: 0x00D9AB7C
		private RacingBetsCommandBase PushRacingBetsDangoRankChangeCommand(List<int> rankList)
		{
			RacingBetsDangoRankChangeCommand racingBetsDangoRankChangeCommand = DangoDungeonCommandFactory.CreateRacingBetsDangoRankChangeCommand(rankList);
			this.CommandQueue.AddCommand(racingBetsDangoRankChangeCommand);
			return racingBetsDangoRankChangeCommand;
		}

		// Token: 0x06036115 RID: 221461 RVA: 0x00D9C9A0 File Offset: 0x00D9ABA0
		private RacingBetsCommandBase PushRacingBetsDangoTransmitCommand(RacingBetsDangoActionTransmit transmitAction)
		{
			RacingBetsCommandBase racingBetsCommandBase = DangoDungeonCommandFactory.CreateRacingBetsDangoTransmitCommand(transmitAction);
			this.CommandQueue.AddCommand(racingBetsCommandBase);
			return racingBetsCommandBase;
		}

		// Token: 0x06036116 RID: 221462 RVA: 0x00D9C9C4 File Offset: 0x00D9ABC4
		private RacingBetsCommandBase PushRacingBetsBlackHoleTransmitCommand(RacingBetsDangoActionBlackHoleTransmit transmitAction)
		{
			RacingBetsCommandBase racingBetsCommandBase = DangoDungeonCommandFactory.CreateRacingBetsBlackHoleTransmitCommand(transmitAction);
			this.CommandQueue.AddCommand(racingBetsCommandBase);
			return racingBetsCommandBase;
		}

		// Token: 0x06036117 RID: 221463 RVA: 0x00D9C9E8 File Offset: 0x00D9ABE8
		private RacingBetsCommandBase PushRacingBetsOrganEffectCommand(RacingBetsOrganEffect organEffectAction)
		{
			RacingBetsCommandBase racingBetsCommandBase = DangoDungeonCommandFactory.CreateRacingBetsOrganEffectCommand(organEffectAction);
			this.CommandQueue.AddCommand(racingBetsCommandBase);
			return racingBetsCommandBase;
		}

		// Token: 0x06036118 RID: 221464 RVA: 0x00D9CA0C File Offset: 0x00D9AC0C
		public UniTask OnDangoDungeonEnd(bool isAborted)
		{
			RacingBetsModel.<OnDangoDungeonEnd>d__53 <OnDangoDungeonEnd>d__;
			<OnDangoDungeonEnd>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnDangoDungeonEnd>d__.<>4__this = this;
			<OnDangoDungeonEnd>d__.<>1__state = -1;
			<OnDangoDungeonEnd>d__.<>t__builder.Start<RacingBetsModel.<OnDangoDungeonEnd>d__53>(ref <OnDangoDungeonEnd>d__);
			return <OnDangoDungeonEnd>d__.<>t__builder.Task;
		}

		// Token: 0x06036119 RID: 221465 RVA: 0x00D9CA4F File Offset: 0x00D9AC4F
		public void OnDangoDungeonPreviewEnd(bool isAborted)
		{
			if (this.LeaveDungeonOnEnd)
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeonRequest(LeaveInstWay.Default).Forget<bool>();
			}
		}

		// Token: 0x0603611A RID: 221466 RVA: 0x00D9CA6C File Offset: 0x00D9AC6C
		public void CloseDangoGamePlayPreviewView()
		{
			Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.RacingBetsGamePlayPreviewView.ToString(), true);
			UiSceneDangoActorManager.SetAllActorVisible(true);
			this.RefreshDangoActivityAudio();
			Singleton<UiManager>.Instance.CloseView(EUiViewName.RacingBetsGamePlayPreviewView, delegate(bool _)
			{
				this.ClearDungeonEffects();
				this.IsDungeonPlaying = false;
				this.HideAllDangoEntity();
				Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.RacingBetsGamePlayPreviewView.ToString(), false);
			});
		}

		// Token: 0x0603611B RID: 221467 RVA: 0x00D9CABC File Offset: 0x00D9ACBC
		private void HideAllDangoEntity()
		{
			ModelBase<ChessModel>.Instance.ClearAll();
			foreach (RacingBetsDungeonDangoInfo racingBetsDungeonDangoInfo in this.DungeonDangoMap.Values)
			{
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(racingBetsDungeonDangoInfo.EntityId);
				if (entity != null)
				{
					ControllerBase<CreatureController>.Instance.SetEntityEnable(entity.Entity, false, "RacingBetsModel inactive dango", false);
				}
			}
		}

		// Token: 0x0603611C RID: 221468 RVA: 0x00D9CB44 File Offset: 0x00D9AD44
		public void RacingBetsAbortDungeon()
		{
			DangoDungeonCommandQueue commandQueue = this.CommandQueue;
			if (commandQueue == null)
			{
				return;
			}
			commandQueue.Abort();
		}

		// Token: 0x0603611D RID: 221469 RVA: 0x00D9CB58 File Offset: 0x00D9AD58
		private void RefreshDangoDungeonAudio(int dungeonMatchId)
		{
			RacingBetsLegMatchData legMatchData = this.SeasonData.GetLegMatchData(dungeonMatchId);
			if (legMatchData.GroupMatchType == ERacingBetsGroupMatchType.Final)
			{
				Singleton<AudioSystem>.Instance.SetState("dungeon_2_3_race_music", ERacingBetsAudioState.RaceFinals.ToString(), true);
				return;
			}
			if (legMatchData.Type == 1)
			{
				Singleton<AudioSystem>.Instance.SetState("dungeon_2_3_race_music", ERacingBetsAudioState.RaceGroupStage.ToString(), true);
				return;
			}
			Singleton<AudioSystem>.Instance.SetState("dungeon_2_3_race_music", ERacingBetsAudioState.RaceMatchPoint.ToString(), true);
		}

		// Token: 0x0603611E RID: 221470 RVA: 0x00D9CBE8 File Offset: 0x00D9ADE8
		private void RefreshDangoActivityAudio()
		{
			if (this.SeasonData.GetCurLegMatchData().GetLegMatchState() == ERacingBetsLegMatchState.EndOfMatch)
			{
				Singleton<AudioSystem>.Instance.SetState("dungeon_2_3_race_music", ERacingBetsAudioState.RaceFinals.ToString(), true);
				return;
			}
			Singleton<AudioSystem>.Instance.SetState("dungeon_2_3_race_music", ERacingBetsAudioState.None.ToString(), true);
		}

		// Token: 0x0603611F RID: 221471 RVA: 0x00D9CC49 File Offset: 0x00D9AE49
		public List<RacingBetsDungeonDangoInfo> GetDungeonRankDangoList()
		{
			return this.DungeonDangoSortList;
		}

		// Token: 0x06036120 RID: 221472 RVA: 0x00D9CC54 File Offset: 0x00D9AE54
		public List<RacingBetsDungeonDangoInfo> GetDungeonDangoListForGamePreview(RacingBetsLegMatchData legMatchData)
		{
			if (legMatchData.Type == 2)
			{
				return this.GetDungeonRankDangoList();
			}
			List<RacingBetsDungeonDangoInfo> list = new List<RacingBetsDungeonDangoInfo>();
			foreach (IRacingBetsDangoActorData racingBetsDangoActorData in legMatchData.GetAllDangoActorDataList())
			{
				if (!racingBetsDangoActorData.IsAbuDango)
				{
					RacingBetsDungeonDangoInfo dungeonDangoInfo = this.GetDungeonDangoInfo(racingBetsDangoActorData.DangoId);
					if (dungeonDangoInfo != null)
					{
						list.Add(dungeonDangoInfo);
					}
				}
			}
			return list;
		}

		// Token: 0x06036121 RID: 221473 RVA: 0x00D9CCD8 File Offset: 0x00D9AED8
		[NullableContext(2)]
		public RacingBetsDungeonDangoInfo GetDungeonDangoInfo(int dangoId)
		{
			RacingBetsDungeonDangoInfo result;
			if (this.DungeonDangoMap.TryGetValue(dangoId, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x06036122 RID: 221474 RVA: 0x00D9CCF8 File Offset: 0x00D9AEF8
		public int GetDungeonDangoEntityId(int dangoId)
		{
			RacingBetsDungeonDangoInfo racingBetsDungeonDangoInfo;
			if (!this.DungeonDangoMap.TryGetValue(dangoId, out racingBetsDungeonDangoInfo))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RacingBets;
				ELogAuthor author = ELogAuthor.BB;
				string message = "团子副本无团子数据";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("dangoId", dangoId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return 0;
			}
			return (int)racingBetsDungeonDangoInfo.EntityId;
		}

		// Token: 0x06036123 RID: 221475 RVA: 0x00D9CD50 File Offset: 0x00D9AF50
		public bool IsDungeonBettingDango(int dangoId)
		{
			RacingBetsLegMatchData racingBetsLegMatchData = this.GetRacingBetsLegMatchData(this.DungeonMatchId);
			return racingBetsLegMatchData != null && racingBetsLegMatchData.BetDangoId == dangoId;
		}

		// Token: 0x06036124 RID: 221476 RVA: 0x00D9CD78 File Offset: 0x00D9AF78
		public int GetCommandActionIndex()
		{
			return this.CommandQueue.CurCommandActionIndex;
		}

		// Token: 0x06036125 RID: 221477 RVA: 0x00D9CD88 File Offset: 0x00D9AF88
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public UniTask<UMaterialParameterCollection> LoadDiceMaterialParameterCollection()
		{
			RacingBetsModel.<LoadDiceMaterialParameterCollection>d__66 <LoadDiceMaterialParameterCollection>d__;
			<LoadDiceMaterialParameterCollection>d__.<>t__builder = AsyncUniTaskMethodBuilder<UMaterialParameterCollection>.Create();
			<LoadDiceMaterialParameterCollection>d__.<>4__this = this;
			<LoadDiceMaterialParameterCollection>d__.<>1__state = -1;
			<LoadDiceMaterialParameterCollection>d__.<>t__builder.Start<RacingBetsModel.<LoadDiceMaterialParameterCollection>d__66>(ref <LoadDiceMaterialParameterCollection>d__);
			return <LoadDiceMaterialParameterCollection>d__.<>t__builder.Task;
		}

		// Token: 0x06036126 RID: 221478 RVA: 0x00D9CDCC File Offset: 0x00D9AFCC
		public bool CheckInRacingBetsDungeon()
		{
			InstanceDungeonConfig instance = ConfigBase<InstanceDungeonConfig>.Instance;
			InstanceDungeon? instanceDungeon;
			return instance != null && ((instance.GetConfig(ModelBase<CreatureModel>.Instance.GetInstanceId()) != null) ? new int?(instanceDungeon.GetValueOrDefault().InstSubType) : null).GetValueOrDefault() == 31 && ControllerBase<GameModeController>.Instance.IsInInstance();
		}

		// Token: 0x06036127 RID: 221479 RVA: 0x00D9CE37 File Offset: 0x00D9B037
		public void AddDungeonEffectHandle(int effectId)
		{
			if (effectId != 0)
			{
				this.DungeonEffectHandles.Add(effectId);
			}
		}

		// Token: 0x06036128 RID: 221480 RVA: 0x00D9CE48 File Offset: 0x00D9B048
		public void AddPointEffect(int pointId, IRacingBetsEffectData effectData)
		{
			if (effectData.Handle != 0)
			{
				List<IRacingBetsEffectData> list;
				if (!this.DungeonPointEffectMap.TryGetValue(pointId, out list))
				{
					list = new List<IRacingBetsEffectData>();
					this.DungeonPointEffectMap[pointId] = list;
				}
				list.Add(effectData);
			}
		}

		// Token: 0x06036129 RID: 221481 RVA: 0x00D9CE88 File Offset: 0x00D9B088
		public void RefreshPointDynamicEffect(int pointId)
		{
			List<IRacingBetsEffectData> list;
			if (!this.DungeonPointEffectMap.TryGetValue(pointId, out list) || list.Count == 0)
			{
				return;
			}
			IRacingBetsEffectData racingBetsEffectData = null;
			foreach (IRacingBetsEffectData racingBetsEffectData2 in list)
			{
				if (Singleton<EffectSystem>.Instance.IsValid(racingBetsEffectData2.Handle) && racingBetsEffectData2.Type == ERacingBetsEffectType.Dynamic)
				{
					racingBetsEffectData = racingBetsEffectData2;
					break;
				}
			}
			if (racingBetsEffectData == null)
			{
				return;
			}
			StackableChessboardPoint stackableChessboardPoint = ModelBase<ChessModel>.Instance.GetChessboardPoint(pointId) as StackableChessboardPoint;
			if (stackableChessboardPoint == null)
			{
				return;
			}
			bool flag = stackableChessboardPoint.HasItem();
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			int handle = racingBetsEffectData.Handle;
			bool bHidden = flag;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(45, 2);
			defaultInterpolatedStringHandler.AppendLiteral("[RefreshPointDynamicEffect] Point ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(pointId);
			defaultInterpolatedStringHandler.AppendLiteral(" has item: ");
			defaultInterpolatedStringHandler.AppendFormatted<bool>(flag);
			instance.SetEffectHidden(handle, bHidden, defaultInterpolatedStringHandler.ToStringAndClear(), false);
		}

		// Token: 0x0603612A RID: 221482 RVA: 0x00D9CF7C File Offset: 0x00D9B17C
		public void SetActivePointEffect(int pointId, ERacingBetsEffectType type, bool isActive)
		{
			List<IRacingBetsEffectData> list;
			if (!this.DungeonPointEffectMap.TryGetValue(pointId, out list) || list.Count == 0)
			{
				return;
			}
			IRacingBetsEffectData racingBetsEffectData = null;
			foreach (IRacingBetsEffectData racingBetsEffectData2 in list)
			{
				if (Singleton<EffectSystem>.Instance.IsValid(racingBetsEffectData2.Handle) && racingBetsEffectData2.Type == type)
				{
					racingBetsEffectData = racingBetsEffectData2;
					break;
				}
			}
			if (racingBetsEffectData == null)
			{
				return;
			}
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			int handle = racingBetsEffectData.Handle;
			bool bHidden = !isActive;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(48, 2);
			defaultInterpolatedStringHandler.AppendLiteral("[SetActivePointDynamicEffect] Point ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(pointId);
			defaultInterpolatedStringHandler.AppendLiteral(" is active: ");
			defaultInterpolatedStringHandler.AppendFormatted<bool>(isActive);
			instance.SetEffectHidden(handle, bHidden, defaultInterpolatedStringHandler.ToStringAndClear(), false);
		}

		// Token: 0x0603612B RID: 221483 RVA: 0x00D9D050 File Offset: 0x00D9B250
		public void RefreshPointsDynamicEffects(List<int> pointIds)
		{
			foreach (int pointId in new HashSet<int>(pointIds))
			{
				this.RefreshPointDynamicEffect(pointId);
			}
		}

		// Token: 0x0603612C RID: 221484 RVA: 0x00D9D0A4 File Offset: 0x00D9B2A4
		[NullableContext(2)]
		public IRacingBetsEffectData GetPointEffectByType(int pointId, ERacingBetsEffectType type)
		{
			List<IRacingBetsEffectData> list;
			if (!this.DungeonPointEffectMap.TryGetValue(pointId, out list) || list.Count == 0)
			{
				return null;
			}
			foreach (IRacingBetsEffectData racingBetsEffectData in list)
			{
				if (racingBetsEffectData.Type == type)
				{
					return racingBetsEffectData;
				}
			}
			return null;
		}

		// Token: 0x0603612D RID: 221485 RVA: 0x00D9D118 File Offset: 0x00D9B318
		private void ClearDungeonEffects()
		{
			foreach (int num in this.DungeonEffectHandles)
			{
				if (Singleton<EffectSystem>.Instance.IsValid(num))
				{
					Singleton<EffectSystem>.Instance.StopEffectById(num, "[RacingBetsModel.ClearDungeonEffects]", true, null);
				}
			}
			this.DungeonEffectHandles.Clear();
			this.DungeonPointEffectMap.Clear();
		}

		// Token: 0x0603612E RID: 221486 RVA: 0x00D9D1A4 File Offset: 0x00D9B3A4
		public bool GetIsFromActivityOpenDungeon()
		{
			bool isFromActivityOpenDungeon = this.IsFromActivityOpenDungeon;
			this.IsFromActivityOpenDungeon = false;
			return isFromActivityOpenDungeon;
		}

		// Token: 0x0603612F RID: 221487 RVA: 0x00D9D1B3 File Offset: 0x00D9B3B3
		public void SetIsFromActivityOpenDungeon()
		{
			this.IsFromActivityOpenDungeon = true;
		}

		// Token: 0x06036130 RID: 221488 RVA: 0x00D9D1BC File Offset: 0x00D9B3BC
		public List<IRacingBetsRankData> GetRankData()
		{
			return this.RankData;
		}

		// Token: 0x06036131 RID: 221489 RVA: 0x00D9D1C4 File Offset: 0x00D9B3C4
		[NullableContext(2)]
		public IRacingBetsSelfRankData GetSelfRank()
		{
			return this.SelfRankData;
		}

		// Token: 0x06036132 RID: 221490 RVA: 0x00D9D1CC File Offset: 0x00D9B3CC
		public void RacingBetsRankRefresh(RacingBetsRankResponse data)
		{
			this.RankData = new List<IRacingBetsRankData>();
			if (data.SelfData == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RacingBets;
				ELogAuthor author = ELogAuthor.LRC;
				string message = "团子排行榜数据异常，没有自身数据";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("data", data);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			RacingBetsRankStatus status = data.Status;
			this.SelfRankData = new RacingBetsSelfRankData
			{
				RankStatus = status,
				RankNum = 0,
				HeadIcon = data.SelfData.HeadIcon,
				Name = data.SelfData.Name,
				HitNum = data.SelfData.HitNum,
				CashNum = data.SelfData.Cash
			};
			if (status == RacingBetsRankStatus.Top50)
			{
				this.SelfRankData.RankNum = data.PercentScore;
			}
			PlayerInfoModel instance2 = ModelBase<PlayerInfoModel>.Instance;
			int? num = (instance2 != null) ? instance2.GetId() : null;
			foreach (RacingBetRankPlayerInfo racingBetRankPlayerInfo in data.PlayerInfo)
			{
				RacingBetsRankData racingBetsRankData = new RacingBetsRankData
				{
					PlayerId = racingBetRankPlayerInfo.PlayerId,
					PlayerHeadPhoto = racingBetRankPlayerInfo.HeadIcon,
					RankNum = racingBetRankPlayerInfo.Rank,
					Name = racingBetRankPlayerInfo.Name,
					HitNum = racingBetRankPlayerInfo.HitNum,
					CashNum = racingBetRankPlayerInfo.Cash
				};
				if (status == RacingBetsRankStatus.Rank)
				{
					int playerId = racingBetsRankData.PlayerId;
					int? num2 = num;
					if (playerId == num2.GetValueOrDefault() & num2 != null)
					{
						this.SelfRankData.RankNum = racingBetsRankData.RankNum;
					}
				}
				this.RankData.Add(racingBetsRankData);
			}
		}

		// Token: 0x06036133 RID: 221491 RVA: 0x00D9D384 File Offset: 0x00D9B584
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<RacingBetsLegMatchData> GetRacingBetsHistoryData()
		{
			if (this.SeasonData == null)
			{
				return null;
			}
			List<RacingBetsLegMatchData> reverseLegMatchList = this.SeasonData.GetReverseLegMatchList();
			List<RacingBetsLegMatchData> list = new List<RacingBetsLegMatchData>();
			foreach (RacingBetsLegMatchData racingBetsLegMatchData in reverseLegMatchList)
			{
				if (racingBetsLegMatchData.GetLegMatchState() != ERacingBetsLegMatchState.NotOpen)
				{
					list.Add(racingBetsLegMatchData);
				}
			}
			return list;
		}

		// Token: 0x06036134 RID: 221492 RVA: 0x00D9D3F8 File Offset: 0x00D9B5F8
		public void SetViewRedDotState(ELocalStoragePlayerKey localStorageKey)
		{
			RacingBetsRedDotState racingBetsRedDotState = LocalStorage.GetPlayer<RacingBetsRedDotState>(localStorageKey, null);
			if (racingBetsRedDotState != null)
			{
				racingBetsRedDotState.HasViewed = true;
			}
			else
			{
				racingBetsRedDotState = this.CreateDefaultRedDotState();
			}
			LocalStorage.SetPlayer<RacingBetsRedDotState>(localStorageKey, racingBetsRedDotState);
		}

		// Token: 0x06036135 RID: 221493 RVA: 0x00D9D428 File Offset: 0x00D9B628
		public RacingBetsRedDotState CreateDefaultRedDotState()
		{
			return new RacingBetsRedDotState
			{
				HasViewed = true,
				LastViewedData = 0L
			};
		}

		// Token: 0x06036136 RID: 221494 RVA: 0x00D9D43E File Offset: 0x00D9B63E
		[NullableContext(2)]
		private static object GetSettlementMainViewRecordRaw()
		{
			return LocalStorage.GetPlayer<object>(ELocalStoragePlayerKey.RacingBetsSettlementMainViewRecord, null);
		}

		// Token: 0x06036137 RID: 221495 RVA: 0x00D9D44C File Offset: 0x00D9B64C
		[NullableContext(2)]
		private static IRacingBetsSettlementMainViewRecord ParseSettlementMainViewRecord(object raw)
		{
			if (raw != null)
			{
				Dictionary<string, object> dictionary = raw as Dictionary<string, object>;
				if (dictionary != null)
				{
					object obj;
					if (dictionary.TryGetValue("SeasonId", out obj) && obj is int)
					{
						int seasonId = (int)obj;
						object obj2;
						if (dictionary.TryGetValue("ViewedLegMatchIds", out obj2))
						{
							IList list = obj2 as IList;
							if (list != null)
							{
								List<int> list2 = new List<int>();
								foreach (object obj3 in list)
								{
									if (obj3 is int)
									{
										int item = (int)obj3;
										list2.Add(item);
									}
								}
								return new RacingBetsSettlementMainViewRecord
								{
									SeasonId = seasonId,
									ViewedLegMatchIds = list2
								};
							}
						}
						return null;
					}
					return null;
				}
			}
			return null;
		}

		// Token: 0x06036138 RID: 221496 RVA: 0x00D9D524 File Offset: 0x00D9B724
		public bool HasViewedSettlementMainView(int seasonId, int legMatchId)
		{
			IRacingBetsSettlementMainViewRecord racingBetsSettlementMainViewRecord = RacingBetsModel.ParseSettlementMainViewRecord(RacingBetsModel.GetSettlementMainViewRecordRaw());
			return racingBetsSettlementMainViewRecord != null && racingBetsSettlementMainViewRecord.SeasonId == seasonId && racingBetsSettlementMainViewRecord.ViewedLegMatchIds.Contains(legMatchId);
		}

		// Token: 0x06036139 RID: 221497 RVA: 0x00D9D558 File Offset: 0x00D9B758
		public void MarkSettlementMainViewViewed(int seasonId, int legMatchId)
		{
			IRacingBetsSettlementMainViewRecord racingBetsSettlementMainViewRecord = RacingBetsModel.ParseSettlementMainViewRecord(RacingBetsModel.GetSettlementMainViewRecordRaw());
			if (racingBetsSettlementMainViewRecord == null || racingBetsSettlementMainViewRecord.SeasonId != seasonId)
			{
				racingBetsSettlementMainViewRecord = new RacingBetsSettlementMainViewRecord
				{
					SeasonId = seasonId,
					ViewedLegMatchIds = new List<int>()
				};
			}
			if (!racingBetsSettlementMainViewRecord.ViewedLegMatchIds.Contains(legMatchId))
			{
				racingBetsSettlementMainViewRecord.ViewedLegMatchIds.Add(legMatchId);
				LocalStorage.SetPlayer<IRacingBetsSettlementMainViewRecord>(ELocalStoragePlayerKey.RacingBetsSettlementMainViewRecord, racingBetsSettlementMainViewRecord);
			}
		}

		// Token: 0x0603613A RID: 221498 RVA: 0x00D9D5BA File Offset: 0x00D9B7BA
		[NullableContext(2)]
		private static object GetBettingMainViewRecordRaw()
		{
			return LocalStorage.GetPlayer<object>(ELocalStoragePlayerKey.RacingBetsBettingMainViewRecord, null);
		}

		// Token: 0x0603613B RID: 221499 RVA: 0x00D9D5C8 File Offset: 0x00D9B7C8
		public bool HasEnteredBettingMainView(int seasonId, int legMatchId)
		{
			IRacingBetsSettlementMainViewRecord racingBetsSettlementMainViewRecord = RacingBetsModel.ParseSettlementMainViewRecord(RacingBetsModel.GetBettingMainViewRecordRaw());
			return racingBetsSettlementMainViewRecord != null && racingBetsSettlementMainViewRecord.SeasonId == seasonId && racingBetsSettlementMainViewRecord.ViewedLegMatchIds.Contains(legMatchId);
		}

		// Token: 0x0603613C RID: 221500 RVA: 0x00D9D5FC File Offset: 0x00D9B7FC
		public void MarkBettingMainViewEntered(int seasonId, int legMatchId)
		{
			IRacingBetsSettlementMainViewRecord racingBetsSettlementMainViewRecord = RacingBetsModel.ParseSettlementMainViewRecord(RacingBetsModel.GetBettingMainViewRecordRaw());
			if (racingBetsSettlementMainViewRecord == null || racingBetsSettlementMainViewRecord.SeasonId != seasonId)
			{
				racingBetsSettlementMainViewRecord = new RacingBetsSettlementMainViewRecord
				{
					SeasonId = seasonId,
					ViewedLegMatchIds = new List<int>()
				};
			}
			if (!racingBetsSettlementMainViewRecord.ViewedLegMatchIds.Contains(legMatchId))
			{
				racingBetsSettlementMainViewRecord.ViewedLegMatchIds.Add(legMatchId);
				LocalStorage.SetPlayer<IRacingBetsSettlementMainViewRecord>(ELocalStoragePlayerKey.RacingBetsBettingMainViewRecord, racingBetsSettlementMainViewRecord);
			}
		}

		// Token: 0x0603613D RID: 221501 RVA: 0x00D9D65E File Offset: 0x00D9B85E
		private void SetRankRedDotTimer(int delayTime)
		{
			this.RankTimerHandle = TimerSystem.RealTimeInstance.EmitOnTime(delegate(float _)
			{
				this.CheckRankRedDot();
			}, (double)(delayTime * Singleton<TimeUtil>.Instance.InverseMillisecond + 20), null, null, true, 1f);
		}

		// Token: 0x0603613E RID: 221502 RVA: 0x00D9D694 File Offset: 0x00D9B894
		private void RemoveRankTimer()
		{
			if (this.RankTimerHandle != null)
			{
				TimerSystem.RealTimeInstance.Remove(this.RankTimerHandle);
				this.RankTimerHandle = null;
			}
		}

		// Token: 0x0603613F RID: 221503 RVA: 0x00D9D6B8 File Offset: 0x00D9B8B8
		public void CheckRankRedDot()
		{
			if (this.SeasonData == null)
			{
				return;
			}
			this.RemoveRankTimer();
			RacingBetsRedDotState racingBetsRedDotState = LocalStorage.GetPlayer<RacingBetsRedDotState>(ELocalStoragePlayerKey.RacingBetsRankViewRecord, null) ?? ModelBase<RacingBetsModel>.Instance.CreateDefaultRedDotState();
			ValueTuple<int, int> curLegMatchRankOpenTime = this.SeasonData.GetCurLegMatchRankOpenTime();
			int item = curLegMatchRankOpenTime.Item1;
			int item2 = curLegMatchRankOpenTime.Item2;
			double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
			bool hasViewed = racingBetsRedDotState.HasViewed;
			long lastViewedData = racingBetsRedDotState.LastViewedData;
			if ((long)item > lastViewedData)
			{
				if ((double)item > serverTimeStamp)
				{
					this.SetRankRedDotTimer((int)((double)item - serverTimeStamp + 1.0));
					return;
				}
				racingBetsRedDotState.HasViewed = false;
				racingBetsRedDotState.LastViewedData = (long)item;
				LocalStorage.SetPlayer<RacingBetsRedDotState>(ELocalStoragePlayerKey.RacingBetsRankViewRecord, racingBetsRedDotState);
				Singleton<EventSystem>.Instance.Emit(EEventName.OnRacingBetsRedDotUpdate);
				if (item2 != 0 && (double)item2 > serverTimeStamp)
				{
					this.SetRankRedDotTimer((int)((double)item2 - serverTimeStamp + 1.0));
					return;
				}
			}
			else if (hasViewed && item2 != 0 && (double)item2 > serverTimeStamp)
			{
				this.SetRankRedDotTimer((int)((double)item2 - serverTimeStamp + 1.0));
			}
		}

		// Token: 0x06036140 RID: 221504 RVA: 0x00D9D7AC File Offset: 0x00D9B9AC
		public void CheckMatchRedDot()
		{
			if (this.SeasonData == null)
			{
				return;
			}
			RacingBetsRedDotState racingBetsRedDotState = LocalStorage.GetPlayer<RacingBetsRedDotState>(ELocalStoragePlayerKey.RacingBetsMatchViewRecord, null) ?? ModelBase<RacingBetsModel>.Instance.CreateDefaultRedDotState();
			int num = 0;
			RacingBetsLegMatchData curLegMatchData = this.SeasonData.GetCurLegMatchData();
			if (curLegMatchData != null)
			{
				int id = curLegMatchData.Id;
				if (curLegMatchData.IsLegMatchFinished())
				{
					num = id;
				}
				else
				{
					num = Math.Max(0, id - 1);
				}
			}
			if (!racingBetsRedDotState.HasViewed || (long)num > racingBetsRedDotState.LastViewedData)
			{
				racingBetsRedDotState.HasViewed = false;
				racingBetsRedDotState.LastViewedData = (long)num;
				LocalStorage.SetPlayer<RacingBetsRedDotState>(ELocalStoragePlayerKey.RacingBetsMatchViewRecord, racingBetsRedDotState);
				Singleton<EventSystem>.Instance.Emit(EEventName.OnRacingBetsRedDotUpdate);
			}
		}

		// Token: 0x06036141 RID: 221505 RVA: 0x00D9D847 File Offset: 0x00D9BA47
		public int GetRacingBetsBulletScreenAlpha()
		{
			return LocalStorage.GetPlayer<int>(ELocalStoragePlayerKey.RacingBetsBulletScreenAlphaRecord, 100);
		}

		// Token: 0x06036142 RID: 221506 RVA: 0x00D9D855 File Offset: 0x00D9BA55
		public void SetRacingBetsBulletScreenAlpha(int alpha)
		{
			LocalStorage.SetPlayer<int>(ELocalStoragePlayerKey.RacingBetsBulletScreenAlphaRecord, alpha);
		}

		// Token: 0x06036143 RID: 221507 RVA: 0x00D9D863 File Offset: 0x00D9BA63
		public int GetRacingBetsBulletScreenShowType()
		{
			return LocalStorage.GetPlayer<int>(ELocalStoragePlayerKey.RacingBetsBulletScreenShowTypeRecord, 2);
		}

		// Token: 0x06036144 RID: 221508 RVA: 0x00D9D870 File Offset: 0x00D9BA70
		public void SetRacingBetsBulletScreenShowType(int showType)
		{
			LocalStorage.SetPlayer<int>(ELocalStoragePlayerKey.RacingBetsBulletScreenShowTypeRecord, showType);
		}

		// Token: 0x17008CF4 RID: 36084
		// (get) Token: 0x06036145 RID: 221509 RVA: 0x00D9D87E File Offset: 0x00D9BA7E
		public int RayTracingShadowsValue
		{
			get
			{
				return this.RayTracingShadowsValueInternal;
			}
		}

		// Token: 0x17008CF5 RID: 36085
		// (get) Token: 0x06036146 RID: 221510 RVA: 0x00D9D886 File Offset: 0x00D9BA86
		public int DlssValue
		{
			get
			{
				return this.DlssValueInternal;
			}
		}

		// Token: 0x06036147 RID: 221511 RVA: 0x00D9D88E File Offset: 0x00D9BA8E
		public void SetVisionValue(int rayTracingValue, int dlssValue)
		{
			this.RayTracingShadowsValueInternal = rayTracingValue;
			this.DlssValueInternal = dlssValue;
		}

		// Token: 0x06036148 RID: 221512 RVA: 0x00D9D8A0 File Offset: 0x00D9BAA0
		public List<int> GetAdvanceMatchDangoList(ERacingBetsMatchTableType matchType)
		{
			List<int> list = new List<int>();
			foreach (int matchId in ConfigBase<RacingBetsConfig>.Instance.GetMatchTableConfigById((int)matchType).Value.GetAdvancedDangoIdSourceGroupMatchListArray())
			{
				RacingBetsGroupMatchData racingBetsGroupMatchData = this.GetRacingBetsGroupMatchData(matchId);
				list.AddRange(racingBetsGroupMatchData.GetPromoteDangoList());
			}
			return list;
		}

		// Token: 0x0401F110 RID: 127248
		[Nullable(2)]
		private RacingBetsSeasonData SeasonData;

		// Token: 0x0401F111 RID: 127249
		[Nullable(2)]
		private RacingBetLegMatchResultNotify LegMatchResult;

		// Token: 0x0401F112 RID: 127250
		public bool UseGmState;

		// Token: 0x0401F113 RID: 127251
		private readonly Dictionary<int, RacingBetsDungeonDangoInfo> DungeonDangoMap = new Dictionary<int, RacingBetsDungeonDangoInfo>();

		// Token: 0x0401F114 RID: 127252
		private List<RacingBetsDungeonDangoInfo> DungeonDangoSortList = new List<RacingBetsDungeonDangoInfo>();

		// Token: 0x0401F115 RID: 127253
		private List<RacingBetsDungeonDangoInfo> DungeonAllDangoList = new List<RacingBetsDungeonDangoInfo>();

		// Token: 0x0401F116 RID: 127254
		private readonly DangoDungeonCommandQueue CommandQueue = new DangoDungeonCommandQueue();

		// Token: 0x0401F117 RID: 127255
		[Nullable(2)]
		private UMaterialParameterCollection DiceMaterialParameterCollection;

		// Token: 0x0401F118 RID: 127256
		public bool IsDungeonPlaying;

		// Token: 0x0401F119 RID: 127257
		public int DungeonMatchId;

		// Token: 0x0401F11A RID: 127258
		public bool IsReplayDungeon;

		// Token: 0x0401F11B RID: 127259
		public bool LeaveDungeonOnEnd;

		// Token: 0x0401F11C RID: 127260
		private readonly List<int> DungeonEffectHandles = new List<int>();

		// Token: 0x0401F11D RID: 127261
		private readonly Dictionary<int, List<IRacingBetsEffectData>> DungeonPointEffectMap = new Dictionary<int, List<IRacingBetsEffectData>>();

		// Token: 0x0401F11E RID: 127262
		private List<IRacingBetsRankData> RankData = new List<IRacingBetsRankData>();

		// Token: 0x0401F11F RID: 127263
		[Nullable(2)]
		private IRacingBetsSelfRankData SelfRankData;

		// Token: 0x0401F120 RID: 127264
		[Nullable(2)]
		private TimerHandle RankTimerHandle;

		// Token: 0x0401F121 RID: 127265
		private bool IsFromActivityOpenDungeon;

		// Token: 0x0401F122 RID: 127266
		private int RayTracingShadowsValueInternal;

		// Token: 0x0401F123 RID: 127267
		private int DlssValueInternal;
	}
}
