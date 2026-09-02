using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062AD RID: 25261
	[NullableContext(1)]
	[Nullable(0)]
	public class TetrisPlayController
	{
		// Token: 0x0603F8EE RID: 260334 RVA: 0x010495AC File Offset: 0x010477AC
		public void InitLevel(int id)
		{
			this.LevelStartTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
			this.ResetTraceId();
			this.PlaceCount = 0;
			this.FirstRefillHandShapesSerialized = "";
			this.CurrentRoundRefillHandShapesSerialized = "";
			this.CurrentStageIndex = 1;
			this.CurrentRoundIndex = 1;
			this.InitLevelConfig(id);
			this.InitBoard(id);
			this.InitGenerateShape();
			this.SendStartLogData();
		}

		// Token: 0x0603F8EF RID: 260335 RVA: 0x01049617 File Offset: 0x01047817
		public void SetUseDialogWinOnly(bool value)
		{
			this.UseDialogWinOnly = value;
		}

		// Token: 0x0603F8F0 RID: 260336 RVA: 0x01049620 File Offset: 0x01047820
		public void ResetLevel(int id)
		{
			this.LevelStartTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
			this.ResetTraceId();
			this.PlaceCount = 0;
			this.FirstRefillHandShapesSerialized = "";
			this.CurrentRoundRefillHandShapesSerialized = "";
			this.CurrentStageIndex = 1;
			this.CurrentRoundIndex = 1;
			this.GridModel.Reset();
			this.ScoreModel.Reset();
			this.GemModel.Reset();
			this.HandShapes = new List<BlockInstance>();
			this.IsGameOver = false;
			this.TakeBackCount = 0;
			this.TakeBackSnapshot = null;
			this.InitBoard(id);
			this.SendStartLogData();
		}

		// Token: 0x0603F8F1 RID: 260337 RVA: 0x010496BF File Offset: 0x010478BF
		public void ClearCallBack()
		{
			this.OnDataUpdate = null;
			this.OnRefillHandShapes = null;
			this.OnPlaceAnimation = null;
			this.OnRemoveAnimation = null;
			this.OnCleanAnimation = null;
			this.OnLoseBoardAnimation = null;
			this.OnCombo = null;
		}

		// Token: 0x0603F8F2 RID: 260338 RVA: 0x010496F2 File Offset: 0x010478F2
		private void InitLevelConfig(int id)
		{
			this.CurrentLevelConfig = new Tetris?(ConfigBase<ActivityTetrisConfig>.Instance.GetLevelConfig(id));
		}

		// Token: 0x0603F8F3 RID: 260339 RVA: 0x0104970A File Offset: 0x0104790A
		public Tetris? GetCurrentConfig()
		{
			return this.CurrentLevelConfig;
		}

		// Token: 0x0603F8F4 RID: 260340 RVA: 0x01049712 File Offset: 0x01047912
		public EGameMode GetGameMode()
		{
			return TetrisUtils.CheckLevelMode(this.CurrentLevelConfig.Value);
		}

		// Token: 0x0603F8F5 RID: 260341 RVA: 0x01049724 File Offset: 0x01047924
		public Dictionary<int, int> GetCurrentTarget()
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			IntIntMap value = this.CurrentLevelConfig.Value.TargetResults((int)this.CurrentDifficulty).Value;
			int mapIntIntLength = value.MapIntIntLength;
			for (int i = 0; i < mapIntIntLength; i++)
			{
				DicIntInt value2 = value.MapIntInt(i).Value;
				dictionary[value2.Key] = value2.Value;
			}
			return dictionary;
		}

		// Token: 0x0603F8F6 RID: 260342 RVA: 0x0104979C File Offset: 0x0104799C
		public Dictionary<int, int> GetCurrentTargetRecord()
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			foreach (KeyValuePair<int, int> keyValuePair in this.GetCurrentTarget())
			{
				dictionary[keyValuePair.Key] = keyValuePair.Value;
			}
			return dictionary;
		}

		// Token: 0x0603F8F7 RID: 260343 RVA: 0x01049804 File Offset: 0x01047A04
		public void OnPlayerDropShape(int handIndex, int targetR, int targetC)
		{
			if (this.IsGameOver)
			{
				return;
			}
			if (this.IsAnimating)
			{
				return;
			}
			BlockInstance blockInstance = this.HandShapes[handIndex];
			if (blockInstance == null)
			{
				return;
			}
			if (!this.CanPlaceShape(blockInstance.Offsets, targetR, targetC))
			{
				return;
			}
			this.PlaceShape(blockInstance, targetR, targetC);
			this.PlaceCount++;
			int count = blockInstance.Offsets.Count;
			this.HandShapes[handIndex] = null;
			this.ProcessElimination(count);
			this.UpdateHandShapes();
			this.NotifyUi(false, false);
			List<ValueTuple<int, int>> list = new List<ValueTuple<int, int>>();
			foreach (ValueTuple<int, int> valueTuple in blockInstance.Offsets)
			{
				list.Add(new ValueTuple<int, int>(targetR + valueTuple.Item1, targetC + valueTuple.Item2));
			}
			Action<List<ValueTuple<int, int>>, TTimerAction> onPlaceAnimation = this.OnPlaceAnimation;
			if (onPlaceAnimation == null)
			{
				return;
			}
			onPlaceAnimation(list, new TTimerAction(this.<OnPlayerDropShape>g__doAfterPlaceAnimation|36_0));
		}

		// Token: 0x0603F8F8 RID: 260344 RVA: 0x01049910 File Offset: 0x01047B10
		private void ProcessElimination(int placedBlockCount)
		{
			ValueTuple<int, List<EGemType>, List<ValueTuple<int, int, int>>, List<ValueTuple<int, int, int>>, List<int>, List<int>> valueTuple = this.CheckAndClear();
			bool flag = this.IsBoardEmpty();
			int num = this.Calculate(valueTuple.Item1, flag, this.CurrentRoundIndex);
			if (num != 0)
			{
				this.EmitScoreChanged();
			}
			Dictionary<EGemType, int> dictionary = new Dictionary<EGemType, int>();
			if (valueTuple.Item2.Count > 0)
			{
				foreach (EGemType egemType in valueTuple.Item2)
				{
					this.GemModel.AddGem(egemType, 1);
					int num2;
					if (!dictionary.TryGetValue(egemType, out num2))
					{
						num2 = 0;
					}
					dictionary[egemType] = num2 + 1;
				}
			}
			if (valueTuple.Item1 > 0 && this.OnCombo != null)
			{
				int comboCount = this.ScoreModel.GetComboCount();
				int clearedLines = valueTuple.Item5.Count + valueTuple.Item6.Count;
				List<ITetrisGemGetData> list = new List<ITetrisGemGetData>();
				foreach (KeyValuePair<EGemType, int> keyValuePair in dictionary)
				{
					list.Add(new TetrisGemGetData
					{
						GemId = (int)keyValuePair.Key,
						GetGemCount = keyValuePair.Value
					});
				}
				ComboData obj = new ComboData
				{
					ClearedLines = clearedLines,
					IsBoardEmpty = flag,
					ComboCount = comboCount,
					Score = num,
					GemList = list,
					ClearedRows = valueTuple.Item5,
					ClearedCols = valueTuple.Item6,
					GameMode = this.GetGameMode()
				};
				this.OnCombo(obj);
			}
			if ((valueTuple.Item3.Count > 0 || valueTuple.Item4.Count > 0) && this.OnRemoveAnimation != null)
			{
				TetrisPlayController.<>c__DisplayClass37_0 CS$<>8__locals1 = new TetrisPlayController.<>c__DisplayClass37_0();
				CS$<>8__locals1.<>4__this = this;
				this.IsAnimating = true;
				CS$<>8__locals1.hasCleanAnimation = (flag && this.OnCleanAnimation != null);
				this.OnRemoveAnimation(valueTuple.Item3, valueTuple.Item4, valueTuple.Item5, valueTuple.Item6, CS$<>8__locals1.hasCleanAnimation, new Action(CS$<>8__locals1.<ProcessElimination>g__onRemoveComplete|0));
			}
		}

		// Token: 0x0603F8F9 RID: 260345 RVA: 0x01049B50 File Offset: 0x01047D50
		public void UpdateGameState()
		{
			if (this.CheckWinCondition())
			{
				this.IsGameOver = true;
				this.OnGameWin();
				this.SendResultLogData(1);
				return;
			}
			if (this.CheckLossCondition())
			{
				this.IsGameOver = true;
				this.OnGameLose();
			}
		}

		// Token: 0x0603F8FA RID: 260346 RVA: 0x01049B84 File Offset: 0x01047D84
		private void UpdateHandShapes()
		{
			bool flag = true;
			using (List<BlockInstance>.Enumerator enumerator = this.HandShapes.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current != null)
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				this.CurrentStageIndex++;
				this.RefillHandShapes();
				Action onRefillHandShapes = this.OnRefillHandShapes;
				if (onRefillHandShapes == null)
				{
					return;
				}
				onRefillHandShapes();
			}
		}

		// Token: 0x0603F8FB RID: 260347 RVA: 0x01049C00 File Offset: 0x01047E00
		public void RefillHandShapes()
		{
			this.HandShapes = this.GenerateBlocks(this.CurrentLevelConfig.Value.BlockNum);
			string text = this.SerializeHandShapes(this.HandShapes);
			if (this.FirstRefillHandShapesSerialized == "")
			{
				this.FirstRefillHandShapesSerialized = text;
			}
			this.CurrentRoundRefillHandShapesSerialized = text;
			this.SaveTakeBackSnapshot();
			this.SendRoundLogData();
		}

		// Token: 0x0603F8FC RID: 260348 RVA: 0x01049C68 File Offset: 0x01047E68
		private void SaveTakeBackSnapshot()
		{
			this.TakeBackSnapshot = new TetrisGameSnapshot
			{
				BoardCells = this.GridModel.CloneCells(),
				HandShapes = this.CloneHandShapes(),
				ScoreSnapshot = this.ScoreModel.CreateSnapshot(),
				GemSnapshot = this.GemModel.CreateSnapshot(),
				CurrentRoundIndex = this.CurrentRoundIndex,
				CurrentStageIndex = this.CurrentStageIndex,
				PlaceCount = this.PlaceCount
			};
		}

		// Token: 0x0603F8FD RID: 260349 RVA: 0x01049CE4 File Offset: 0x01047EE4
		[return: Nullable(new byte[]
		{
			1,
			2
		})]
		private List<BlockInstance> CloneHandShapes()
		{
			List<BlockInstance> list = new List<BlockInstance>();
			foreach (BlockInstance blockInstance in this.HandShapes)
			{
				if (blockInstance == null)
				{
					list.Add(null);
				}
				else
				{
					List<ValueTuple<int, int>> list2 = new List<ValueTuple<int, int>>();
					foreach (ValueTuple<int, int> valueTuple in blockInstance.Offsets)
					{
						list2.Add(new ValueTuple<int, int>(valueTuple.Item1, valueTuple.Item2));
					}
					list.Add(new BlockInstance
					{
						ConfigId = blockInstance.ConfigId,
						Offsets = list2,
						ColorId = blockInstance.ColorId,
						GemType = blockInstance.GemType,
						GemFill = blockInstance.GemFill,
						GemOffSet = blockInstance.GemOffSet
					});
				}
			}
			return list;
		}

		// Token: 0x0603F8FE RID: 260350 RVA: 0x01049DF8 File Offset: 0x01047FF8
		private bool CheckWinCondition()
		{
			if (this.CurrentLevelConfig == null)
			{
				return false;
			}
			if (this.UseDialogWinOnly)
			{
				return false;
			}
			EGameMode gameMode = this.GetGameMode();
			if (gameMode == EGameMode.Score)
			{
				return this.GetCurrentScore() >= this.GetCurrentTarget()[0];
			}
			if (gameMode == EGameMode.GemCollection)
			{
				foreach (KeyValuePair<int, int> keyValuePair in this.GetCurrentTarget())
				{
					if (this.GemModel.GetGem((EGemType)keyValuePair.Key) < keyValuePair.Value)
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		// Token: 0x0603F8FF RID: 260351 RVA: 0x01049EAC File Offset: 0x010480AC
		private bool CheckLossCondition()
		{
			foreach (BlockInstance blockInstance in this.HandShapes)
			{
				if (blockInstance != null)
				{
					for (int i = 0; i < 8; i++)
					{
						for (int j = 0; j < 8; j++)
						{
							if (this.CanPlaceShape(blockInstance.Offsets, i, j))
							{
								return false;
							}
						}
					}
				}
			}
			return true;
		}

		// Token: 0x0603F900 RID: 260352 RVA: 0x01049F2C File Offset: 0x0104812C
		public void NotifyUi(bool isInit = false, bool isTakeBack = false)
		{
			Action<bool, bool> onDataUpdate = this.OnDataUpdate;
			if (onDataUpdate == null)
			{
				return;
			}
			onDataUpdate(isInit, isTakeBack);
		}

		// Token: 0x0603F901 RID: 260353 RVA: 0x01049F40 File Offset: 0x01048140
		public TetrisBoardData GetGridModel()
		{
			return this.GridModel;
		}

		// Token: 0x0603F902 RID: 260354 RVA: 0x01049F48 File Offset: 0x01048148
		[return: Nullable(new byte[]
		{
			1,
			2
		})]
		public List<BlockInstance> GetHandShapes()
		{
			return this.HandShapes;
		}

		// Token: 0x0603F903 RID: 260355 RVA: 0x01049F50 File Offset: 0x01048150
		private void OnGameLose()
		{
			if (this.CanTakeBack())
			{
				this.ShowTakeBackConfirm();
				return;
			}
			this.SetEmptyCellsColorIdFixed();
			Action<Action> onLoseBoardAnimation = this.OnLoseBoardAnimation;
			if (onLoseBoardAnimation == null)
			{
				return;
			}
			onLoseBoardAnimation(new Action(this.<OnGameLose>g__deferLoseAnimation|48_0));
		}

		// Token: 0x0603F904 RID: 260356 RVA: 0x01049F84 File Offset: 0x01048184
		private void SetEmptyCellsColorIdFixed()
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					TetrisCellData tetrisCellData = this.GridModel.Cells[i][j];
					tetrisCellData.Reset();
					tetrisCellData.ColorId = 7;
				}
			}
		}

		// Token: 0x0603F905 RID: 260357 RVA: 0x01049FC4 File Offset: 0x010481C4
		public void OnLoseReset()
		{
			this.TryChangeLevelDifficulty();
			this.DoResetTetris();
		}

		// Token: 0x0603F906 RID: 260358 RVA: 0x01049FD3 File Offset: 0x010481D3
		public void OnGameWin()
		{
			this.DoOnGameWin(this.GenRequestMsg());
		}

		// Token: 0x0603F907 RID: 260359 RVA: 0x01049FE1 File Offset: 0x010481E1
		public void OnGameWinQuickComplete()
		{
			this.DoOnGameWin(this.GenRequestMsgWithTargetResult());
		}

		// Token: 0x0603F908 RID: 260360 RVA: 0x01049FF0 File Offset: 0x010481F0
		[NullableContext(2)]
		public void DoOnGameWin(TetrisUpdateRequest requestMsg)
		{
			TetrisPlayController.<>c__DisplayClass53_0 CS$<>8__locals1 = new TetrisPlayController.<>c__DisplayClass53_0();
			CS$<>8__locals1.levelId = this.CurrentLevelConfig.Value.Id;
			CS$<>8__locals1.isHardLevel = TetrisUtils.IsHardLevel(this.CurrentLevelConfig.Value);
			CS$<>8__locals1.isEggLevel = TetrisUtils.IsEggLevel(this.CurrentLevelConfig.Value);
			TetrisPlayController.<>c__DisplayClass53_0 CS$<>8__locals2 = CS$<>8__locals1;
			ActivityTetrisData tetrisData = ControllerBase<ActivityTetrisController>.Instance.GetTetrisData();
			CS$<>8__locals2.isAlreadyComplete = ((tetrisData != null) ? new bool?(tetrisData.CheckChallengeComplete(CS$<>8__locals1.levelId)) : null);
			CS$<>8__locals1.msgToSend = (CS$<>8__locals1.isAlreadyComplete.GetValueOrDefault() ? null : requestMsg);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TetrisTipsWinView, new Action(CS$<>8__locals1.<DoOnGameWin>g__onWinCallback|0), null);
		}

		// Token: 0x0603F909 RID: 260361 RVA: 0x0104A0AC File Offset: 0x010482AC
		private bool CanTakeBack()
		{
			if (this.CurrentLevelConfig == null)
			{
				return false;
			}
			int takeBackCnt = this.CurrentLevelConfig.Value.TakeBackCnt;
			return this.TakeBackCount < takeBackCnt && this.TakeBackSnapshot != null;
		}

		// Token: 0x0603F90A RID: 260362 RVA: 0x0104A0F4 File Offset: 0x010482F4
		private void ShowTakeBackConfirm()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.TetrisTakeBackConfirm);
			confirmBoxDataNew.FunctionMap.Add(1, new Action(this.<ShowTakeBackConfirm>g__cancelCallback|55_0));
			confirmBoxDataNew.FunctionMap.Add(2, new Action(this.<ShowTakeBackConfirm>g__confirmCallback|55_1));
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603F90B RID: 260363 RVA: 0x0104A148 File Offset: 0x01048348
		public void DoTakeBack()
		{
			if (this.TakeBackSnapshot == null)
			{
				return;
			}
			this.TakeBackCount++;
			int currentScore = this.GetCurrentScore();
			this.GridModel.RestoreFromSnapshot(this.TakeBackSnapshot.BoardCells);
			this.HandShapes = this.CloneSnapshotHandShapes(this.TakeBackSnapshot.HandShapes);
			this.ScoreModel.RestoreFromSnapshot(this.TakeBackSnapshot.ScoreSnapshot);
			this.GemModel.RestoreFromSnapshot(this.TakeBackSnapshot.GemSnapshot);
			this.CurrentRoundIndex = this.TakeBackSnapshot.CurrentRoundIndex;
			this.CurrentStageIndex = this.TakeBackSnapshot.CurrentStageIndex;
			this.PlaceCount = this.TakeBackSnapshot.PlaceCount;
			this.IsGameOver = false;
			if (currentScore != this.GetCurrentScore())
			{
				this.EmitScoreChanged();
			}
			this.NotifyUi(false, true);
		}

		// Token: 0x0603F90C RID: 260364 RVA: 0x0104A21C File Offset: 0x0104841C
		[return: Nullable(new byte[]
		{
			1,
			2
		})]
		private List<BlockInstance> CloneSnapshotHandShapes([Nullable(new byte[]
		{
			1,
			2
		})] List<BlockInstance> snapshotShapes)
		{
			List<BlockInstance> list = new List<BlockInstance>();
			foreach (BlockInstance blockInstance in snapshotShapes)
			{
				if (blockInstance == null)
				{
					list.Add(null);
				}
				else
				{
					List<ValueTuple<int, int>> list2 = new List<ValueTuple<int, int>>();
					foreach (ValueTuple<int, int> valueTuple in blockInstance.Offsets)
					{
						list2.Add(new ValueTuple<int, int>(valueTuple.Item1, valueTuple.Item2));
					}
					list.Add(new BlockInstance
					{
						ConfigId = blockInstance.ConfigId,
						Offsets = list2,
						ColorId = blockInstance.ColorId,
						GemType = blockInstance.GemType,
						GemFill = blockInstance.GemFill,
						GemOffSet = blockInstance.GemOffSet
					});
				}
			}
			return list;
		}

		// Token: 0x0603F90D RID: 260365 RVA: 0x0104A32C File Offset: 0x0104852C
		public int GetRemainingTakeBackCount()
		{
			if (this.CurrentLevelConfig == null)
			{
				return 0;
			}
			return Math.Max(0, this.CurrentLevelConfig.Value.TakeBackCnt - this.TakeBackCount);
		}

		// Token: 0x0603F90E RID: 260366 RVA: 0x0104A368 File Offset: 0x01048568
		public void DoResetTetris()
		{
			if (this.OnCleanAnimation != null)
			{
				this.IsAnimating = true;
				this.OnCleanAnimation(delegate
				{
					this.IsAnimating = false;
					this.ExecuteReset();
				});
				return;
			}
			this.ExecuteReset();
		}

		// Token: 0x0603F90F RID: 260367 RVA: 0x0104A398 File Offset: 0x01048598
		private void ExecuteReset()
		{
			this.SendResultLogData(3);
			this.ResetLevel(this.CurrentLevelConfig.Value.Id);
			this.RefillHandShapes();
			Action onRefillHandShapes = this.OnRefillHandShapes;
			if (onRefillHandShapes != null)
			{
				onRefillHandShapes();
			}
			this.NotifyUi(true, false);
		}

		// Token: 0x0603F910 RID: 260368 RVA: 0x0104A3E4 File Offset: 0x010485E4
		private bool TryChangeLevelDifficulty()
		{
			TetrisPlayController.<>c__DisplayClass61_0 CS$<>8__locals1 = new TetrisPlayController.<>c__DisplayClass61_0();
			CS$<>8__locals1.<>4__this = this;
			bool flag = false;
			CS$<>8__locals1.targetDifficulty = 0;
			for (int i = (int)this.CurrentDifficulty; i < this.CurrentLevelConfig.Value.ReduceDiffCntLength; i++)
			{
				int num = this.CurrentLevelConfig.Value.ReduceDiffCnt(i);
				if (this.LoseCount >= num)
				{
					CS$<>8__locals1.targetDifficulty = i + 1;
					flag = true;
				}
			}
			if (flag)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.TetrisDifficultyChangeConfirm);
				confirmBoxDataNew.FunctionMap.Add(1, new Action(TetrisPlayController.<TryChangeLevelDifficulty>g__cancelCallback|61_0));
				confirmBoxDataNew.FunctionMap.Add(2, new Action(CS$<>8__locals1.<TryChangeLevelDifficulty>g__confirmCallback|1));
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			}
			return flag;
		}

		// Token: 0x0603F911 RID: 260369 RVA: 0x0104A4A4 File Offset: 0x010486A4
		public TetrisUpdateRequest GenRequestMsg()
		{
			TetrisUpdateRequest tetrisUpdateRequest = TetrisUpdateRequest.Create();
			tetrisUpdateRequest.ActivityId = ControllerBase<ActivityTetrisController>.Instance.ActivityId;
			tetrisUpdateRequest.TetrisLevelInfo = new TetrisLevelInfo
			{
				Id = this.CurrentLevelConfig.Value.Id,
				State = TetrisState.TetrisUnlocked,
				DifficultyIdx = (int)this.CurrentDifficulty
			};
			tetrisUpdateRequest.TetrisLevelInfo.Results.MergeFrom(this.GenResult());
			return tetrisUpdateRequest;
		}

		// Token: 0x0603F912 RID: 260370 RVA: 0x0104A514 File Offset: 0x01048714
		public TetrisUpdateRequest GenRequestMsgWithTargetResult()
		{
			TetrisUpdateRequest tetrisUpdateRequest = TetrisUpdateRequest.Create();
			tetrisUpdateRequest.ActivityId = ControllerBase<ActivityTetrisController>.Instance.ActivityId;
			tetrisUpdateRequest.TetrisLevelInfo = new TetrisLevelInfo
			{
				Id = this.CurrentLevelConfig.Value.Id,
				State = TetrisState.TetrisUnlocked,
				DifficultyIdx = (int)this.CurrentDifficulty
			};
			tetrisUpdateRequest.TetrisLevelInfo.Results.MergeFrom(this.GetCurrentTargetRecord());
			return tetrisUpdateRequest;
		}

		// Token: 0x0603F913 RID: 260371 RVA: 0x0104A584 File Offset: 0x01048784
		public TetrisFinishRequest GenInfiniteRequestMsg()
		{
			TetrisFinishRequest tetrisFinishRequest = TetrisFinishRequest.Create();
			tetrisFinishRequest.HostPlayerId = ModelBase<CreatureModel>.Instance.GetWorldOwner();
			tetrisFinishRequest.EntityId = ControllerBase<TetrisController>.Instance.GetEntityId();
			int? num = this.GetCurrentTarget().ContainsKey(0) ? new int?(this.GetCurrentTarget()[0]) : null;
			tetrisFinishRequest.Score = ((num != null) ? Math.Min(this.ScoreModel.GetScore(), num.Value) : this.ScoreModel.GetScore());
			return tetrisFinishRequest;
		}

		// Token: 0x0603F914 RID: 260372 RVA: 0x0104A614 File Offset: 0x01048814
		public Dictionary<int, int> GenResult()
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			foreach (KeyValuePair<int, int> keyValuePair in this.GetCurrentTarget())
			{
				int val = (keyValuePair.Key == 0) ? this.ScoreModel.GetScore() : this.GemModel.GetGem((EGemType)keyValuePair.Key);
				dictionary[keyValuePair.Key] = Math.Min(val, keyValuePair.Value);
			}
			return dictionary;
		}

		// Token: 0x0603F915 RID: 260373 RVA: 0x0104A6AC File Offset: 0x010488AC
		private void InitGenerateShape()
		{
			this.AllShapes = ConfigBase<ActivityTetrisConfig>.Instance.GetAllShape();
		}

		// Token: 0x0603F916 RID: 260374 RVA: 0x0104A6C0 File Offset: 0x010488C0
		public List<BlockInstance> GenerateBlocks(int count)
		{
			List<BlockInstance> list = new List<BlockInstance>();
			bool[][] boardOccupancy = this.GetBoardOccupancy();
			List<IShapeConfig> blocksFromConfig = ConfigBase<ActivityTetrisConfig>.Instance.GetBlocksFromConfig(this.CurrentLevelConfig.Value.Id, this.CurrentRoundIndex);
			List<int> generatedShapeIds = new List<int>();
			Predicate<IShapeConfig> <>9__0;
			for (int i = 0; i < count; i++)
			{
				IShapeConfig shapeConfig;
				if (blocksFromConfig != null && i < blocksFromConfig.Count && blocksFromConfig[i] != null)
				{
					shapeConfig = blocksFromConfig[i];
				}
				else
				{
					List<IShapeConfig> placeAbleShapes = this.GetPlaceAbleShapes(boardOccupancy);
					if (placeAbleShapes.Count == 0)
					{
						shapeConfig = this.GetRandomShapeFromList(this.AllShapes);
					}
					else
					{
						List<IShapeConfig> list2 = placeAbleShapes;
						Predicate<IShapeConfig> match;
						if ((match = <>9__0) == null)
						{
							match = (<>9__0 = ((IShapeConfig shape) => !generatedShapeIds.Contains(shape.Id)));
						}
						List<IShapeConfig> list3 = list2.FindAll(match);
						if (list3.Count > 0)
						{
							shapeConfig = this.GetRandomShapeFromList(list3);
						}
						else
						{
							shapeConfig = this.GetRandomShapeFromList(placeAbleShapes);
						}
					}
				}
				if (shapeConfig != null)
				{
					generatedShapeIds.Add(shapeConfig.Id);
				}
				BlockInstance item = Singleton<TetrisUtils>.Instance.CreateInstance(shapeConfig);
				this.OccupyVirtualGrid(boardOccupancy, shapeConfig);
				list.Add(item);
			}
			this.ApplyGemsAndColors(list);
			return list;
		}

		// Token: 0x0603F917 RID: 260375 RVA: 0x0104A7F8 File Offset: 0x010489F8
		private List<IShapeConfig> GetPlaceAbleShapes(bool[][] virtualGrid)
		{
			List<IShapeConfig> list = new List<IShapeConfig>();
			int rows = virtualGrid.Length;
			int cols = virtualGrid[0].Length;
			foreach (IShapeConfig shapeConfig in this.AllShapes)
			{
				if (this.CheckShapeCanFitAnywhere(virtualGrid, shapeConfig, rows, cols))
				{
					list.Add(shapeConfig);
				}
			}
			return list;
		}

		// Token: 0x0603F918 RID: 260376 RVA: 0x0104A86C File Offset: 0x01048A6C
		private bool CheckShapeCanFitAnywhere(bool[][] grid, IShapeConfig shape, int rows, int cols)
		{
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					if (this.CanPlaceOnVirtual(grid, shape.Matrix, i, j))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603F919 RID: 260377 RVA: 0x0104A8A8 File Offset: 0x01048AA8
		private bool CanPlaceOnVirtual(bool[][] grid, int[][] matrix, int startR, int startC)
		{
			int num = matrix.Length;
			if (num == 0)
			{
				return true;
			}
			int num2 = matrix[0].Length;
			int num3 = grid.Length;
			int num4 = grid[0].Length;
			if (startR + num > num3 || startC + num2 > num4)
			{
				return false;
			}
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					if (matrix[i][j] == 1 && grid[startR + i][startC + j])
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x0603F91A RID: 260378 RVA: 0x0104A918 File Offset: 0x01048B18
		private void OccupyVirtualGrid(bool[][] grid, IShapeConfig config)
		{
			int num = grid.Length;
			int num2 = grid[0].Length;
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					if (this.CanPlaceOnVirtual(grid, config.Matrix, i, j))
					{
						int num3 = config.Matrix.Length;
						int num4 = config.Matrix[0].Length;
						for (int k = 0; k < num3; k++)
						{
							for (int l = 0; l < num4; l++)
							{
								if (config.Matrix[k][l] == 1)
								{
									grid[i + k][j + l] = true;
								}
							}
						}
						return;
					}
				}
			}
		}

		// Token: 0x0603F91B RID: 260379 RVA: 0x0104A9AC File Offset: 0x01048BAC
		private IShapeConfig GetRandomShapeFromList(List<IShapeConfig> list)
		{
			if (list == null || list.Count == 0)
			{
				return this.AllShapes[0];
			}
			int num = 0;
			foreach (IShapeConfig shapeConfig in list)
			{
				num += shapeConfig.Weight;
			}
			if (num <= 0)
			{
				int index = (int)Math.Floor(new Random().NextDouble() * (double)list.Count);
				return list[index];
			}
			double num2 = new Random().NextDouble() * (double)num;
			foreach (IShapeConfig shapeConfig2 in list)
			{
				num2 -= (double)shapeConfig2.Weight;
				if (num2 < 0.0)
				{
					return shapeConfig2;
				}
			}
			return list[list.Count - 1];
		}

		// Token: 0x0603F91C RID: 260380 RVA: 0x0104AAB0 File Offset: 0x01048CB0
		private void ApplyGemsAndColors(List<BlockInstance> blocks)
		{
			Random random = new Random();
			if (this.GetGameMode() != EGameMode.GemCollection)
			{
				foreach (BlockInstance blockInstance in blocks)
				{
					blockInstance.ColorId = (int)Math.Floor(random.NextDouble() * 6.0) + 1;
					blockInstance.GemType = EGemType.None;
				}
				return;
			}
			List<EGemType> list = this.CalcRestGems();
			if (list == null)
			{
				return;
			}
			List<int> randomIndices = Singleton<TetrisUtils>.Instance.GetRandomIndices(list.Count, (int)Math.Floor(random.NextDouble() * (double)list.Count) + 1);
			for (int i = 0; i < blocks.Count; i++)
			{
				if (randomIndices.Contains(i))
				{
					if (blocks[i] != null)
					{
						EGemType nextGemType = this.GetNextGemType(list);
						blocks[i].GemType = nextGemType;
						blocks[i].ColorId = (int)nextGemType;
						blocks[i].GemFill = this.GetGemFillType(nextGemType);
					}
					if (blocks[i].GemFill == EGemFillType.Single)
					{
						int gemOffSet = (int)Math.Floor(random.NextDouble() * (double)blocks[i].Offsets.Count);
						blocks[i].GemOffSet = gemOffSet;
					}
				}
				else
				{
					blocks[i].ColorId = (int)Math.Floor(random.NextDouble() * 6.0) + 1;
					blocks[i].GemType = EGemType.None;
				}
			}
		}

		// Token: 0x0603F91D RID: 260381 RVA: 0x0104AC38 File Offset: 0x01048E38
		private EGemType GetNextGemType(List<EGemType> neededGems)
		{
			this.GemModel.CurrentGemBag = this.GemModel.CurrentGemBag.FindAll(new Predicate<EGemType>(neededGems.Contains));
			if (this.GemModel.CurrentGemBag.Count == 0)
			{
				List<EGemType> list = new List<EGemType>(neededGems);
				Random random = new Random();
				for (int i = list.Count - 1; i > 0; i--)
				{
					int index = random.Next(i + 1);
					EGemType value = list[i];
					list[i] = list[index];
					list[index] = value;
				}
				this.GemModel.CurrentGemBag = list;
			}
			EGemType result = this.GemModel.CurrentGemBag[this.GemModel.CurrentGemBag.Count - 1];
			this.GemModel.CurrentGemBag.RemoveAt(this.GemModel.CurrentGemBag.Count - 1);
			return result;
		}

		// Token: 0x0603F91E RID: 260382 RVA: 0x0104AD1C File Offset: 0x01048F1C
		private EGemFillType GetGemFillType(EGemType gemType)
		{
			int num = this.GemModel.GetSpawnCount(gemType);
			num++;
			this.GemModel.SetSpawnCount(gemType, num);
			if (num % 5 == 0)
			{
				return EGemFillType.Full;
			}
			return EGemFillType.Single;
		}

		// Token: 0x0603F91F RID: 260383 RVA: 0x0104AD50 File Offset: 0x01048F50
		[NullableContext(2)]
		private List<EGemType> CalcRestGems()
		{
			Dictionary<int, int> currentTarget = this.GetCurrentTarget();
			if (currentTarget == null || currentTarget.Count == 0)
			{
				return null;
			}
			List<EGemType> list = new List<EGemType>();
			foreach (KeyValuePair<int, int> keyValuePair in currentTarget)
			{
				if (keyValuePair.Value - this.GemModel.GetGem((EGemType)keyValuePair.Key) > 0)
				{
					list.Add((EGemType)keyValuePair.Key);
				}
			}
			return list;
		}

		// Token: 0x0603F920 RID: 260384 RVA: 0x0104ADDC File Offset: 0x01048FDC
		public Dictionary<EGemType, int> GetCurrentGems()
		{
			return this.GemModel.GetCurrentGem();
		}

		// Token: 0x0603F921 RID: 260385 RVA: 0x0104ADEC File Offset: 0x01048FEC
		public int GetCurrentGem(int gemId)
		{
			int result;
			if (!this.GemModel.GetCurrentGem().TryGetValue((EGemType)gemId, out result))
			{
				return 0;
			}
			return result;
		}

		// Token: 0x0603F922 RID: 260386 RVA: 0x0104AE11 File Offset: 0x01049011
		public int GetCurrentScore()
		{
			return this.ScoreModel.GetScore();
		}

		// Token: 0x0603F923 RID: 260387 RVA: 0x0104AE20 File Offset: 0x01049020
		private void EmitScoreChanged()
		{
			int? num = (this.CurrentLevelConfig != null) ? new int?(this.CurrentLevelConfig.GetValueOrDefault().Id) : null;
			if (num == null)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnTetrisScoreChanged, num.Value, this.GetCurrentScore());
		}

		// Token: 0x0603F924 RID: 260388 RVA: 0x0104AE81 File Offset: 0x01049081
		public void SetComboCount(int count)
		{
			this.ScoreModel.SetComboCount(count, this.CurrentRoundIndex);
		}

		// Token: 0x0603F925 RID: 260389 RVA: 0x0104AE95 File Offset: 0x01049095
		public TetrisScoreData GetScoreModel()
		{
			return this.ScoreModel;
		}

		// Token: 0x0603F926 RID: 260390 RVA: 0x0104AE9D File Offset: 0x0104909D
		public int Calculate(int linesCleared, bool isBoardEmpty, int currentTurn)
		{
			return this.ScoreModel.Calculate(linesCleared, isBoardEmpty, currentTurn);
		}

		// Token: 0x0603F927 RID: 260391 RVA: 0x0104AEB0 File Offset: 0x010490B0
		private void InitBoard(int id)
		{
			TetrisBoardItemConfig[][] tetrisMap = ConfigBase<ActivityTetrisConfig>.Instance.GetTetrisMap(id);
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					this.GridModel.Cells[i][j] = this.ParseSingleCell(tetrisMap[i][j]);
				}
			}
		}

		// Token: 0x0603F928 RID: 260392 RVA: 0x0104AF00 File Offset: 0x01049100
		private TetrisCellData ParseSingleCell(TetrisBoardItemConfig itemData)
		{
			TetrisCellData tetrisCellData = new TetrisCellData();
			if (itemData.Block)
			{
				tetrisCellData.Type = ECellType.Fixed;
				tetrisCellData.ColorId = 7;
			}
			else if (itemData.Color == 0)
			{
				tetrisCellData.Type = ECellType.Empty;
			}
			else
			{
				tetrisCellData.Type = ECellType.Normal;
				tetrisCellData.GemType = (EGemType)itemData.Gem;
				tetrisCellData.ColorId = itemData.Color;
				tetrisCellData.SealState = (ESealState)itemData.Seal;
			}
			return tetrisCellData;
		}

		// Token: 0x0603F929 RID: 260393 RVA: 0x0104AF70 File Offset: 0x01049170
		public bool CanPlaceShape([TupleElementNames(new string[]
		{
			"Row",
			"Column"
		})] [Nullable(new byte[]
		{
			1,
			0
		})] List<ValueTuple<int, int>> shapeOffsets, int targetR, int targetC)
		{
			foreach (ValueTuple<int, int> valueTuple in shapeOffsets)
			{
				int num = targetR + valueTuple.Item1;
				int num2 = targetC + valueTuple.Item2;
				if (num < 0 || num >= 8 || num2 < 0 || num2 >= 8)
				{
					return false;
				}
				if (this.GridModel.Cells[num][num2].IsOccupied)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0603F92A RID: 260394 RVA: 0x0104B000 File Offset: 0x01049200
		public bool PlaceShape(BlockInstance shape, int targetR, int targetC)
		{
			if (!this.CanPlaceShape(shape.Offsets, targetR, targetC))
			{
				return false;
			}
			for (int i = 0; i < shape.Offsets.Count; i++)
			{
				ValueTuple<int, int> valueTuple = shape.Offsets[i];
				TetrisCellData tetrisCellData = this.GridModel.Cells[targetR + valueTuple.Item1][targetC + valueTuple.Item2];
				tetrisCellData.Type = ECellType.Normal;
				tetrisCellData.ColorId = shape.ColorId;
				if (shape.GemFill == EGemFillType.Full || (shape.GemFill == EGemFillType.Single && i == shape.GemOffSet))
				{
					tetrisCellData.GemType = shape.GemType;
				}
			}
			return true;
		}

		// Token: 0x0603F92B RID: 260395 RVA: 0x0104B09C File Offset: 0x0104929C
		[return: TupleElementNames(new string[]
		{
			"Lines",
			"CollectedGems",
			"ClearedPositions",
			"SealChangePositions",
			"ClearedRows",
			"ClearedCols",
			"Row",
			"Column",
			"ColorId",
			"Row",
			"Column",
			"ColorId"
		})]
		[return: Nullable(new byte[]
		{
			0,
			1,
			1,
			0,
			1,
			0,
			1,
			1
		})]
		public ValueTuple<int, List<EGemType>, List<ValueTuple<int, int, int>>, List<ValueTuple<int, int, int>>, List<int>, List<int>> CheckAndClear()
		{
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			List<EGemType> list3 = new List<EGemType>();
			List<ValueTuple<int, int, int>> list4 = new List<ValueTuple<int, int, int>>();
			List<ValueTuple<int, int, int>> list5 = new List<ValueTuple<int, int, int>>();
			for (int i = 0; i < 8; i++)
			{
				bool flag = true;
				for (int j = 0; j < 8; j++)
				{
					if (!this.GridModel.Cells[i][j].IsOccupied)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					list.Add(i);
				}
			}
			for (int k = 0; k < 8; k++)
			{
				bool flag2 = true;
				for (int l = 0; l < 8; l++)
				{
					if (!this.GridModel.Cells[l][k].IsOccupied)
					{
						flag2 = false;
						break;
					}
				}
				if (flag2)
				{
					list2.Add(k);
				}
			}
			HashSet<int> hashSet = new HashSet<int>();
			foreach (int row in list)
			{
				for (int m = 0; m < 8; m++)
				{
					hashSet.Add(TetrisUtils.GenPosKey(row, m));
				}
			}
			foreach (int column in list2)
			{
				for (int n = 0; n < 8; n++)
				{
					hashSet.Add(TetrisUtils.GenPosKey(n, column));
				}
			}
			foreach (int key in hashSet)
			{
				ValueTuple<int, int> valueTuple = TetrisUtils.ParsePosKey(key);
				TetrisCellData tetrisCellData = this.GridModel.Cells[valueTuple.Item1][valueTuple.Item2];
				if (tetrisCellData.Type != ECellType.Fixed)
				{
					if (tetrisCellData.SealState == ESealState.Layer2)
					{
						list5.Add(new ValueTuple<int, int, int>(valueTuple.Item1, valueTuple.Item2, tetrisCellData.ColorId));
						tetrisCellData.SealState = ESealState.Layer1;
					}
					else if (tetrisCellData.SealState == ESealState.Layer1)
					{
						list5.Add(new ValueTuple<int, int, int>(valueTuple.Item1, valueTuple.Item2, tetrisCellData.ColorId));
						tetrisCellData.SealState = ESealState.None;
					}
					else
					{
						if (tetrisCellData.GemType != EGemType.None)
						{
							list3.Add(tetrisCellData.GemType);
						}
						list4.Add(new ValueTuple<int, int, int>(valueTuple.Item1, valueTuple.Item2, tetrisCellData.ColorId));
						tetrisCellData.Reset();
					}
				}
			}
			return new ValueTuple<int, List<EGemType>, List<ValueTuple<int, int, int>>, List<ValueTuple<int, int, int>>, List<int>, List<int>>(list.Count + list2.Count, list3, list4, list5, list, list2);
		}

		// Token: 0x0603F92C RID: 260396 RVA: 0x0104B34C File Offset: 0x0104954C
		public bool IsBoardEmpty()
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					if (this.GridModel.Cells[i][j].Type == ECellType.Normal)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x0603F92D RID: 260397 RVA: 0x0104B38B File Offset: 0x0104958B
		public bool[][] GetBoardOccupancy()
		{
			return this.GridModel.GetBoardOccupancy();
		}

		// Token: 0x0603F92E RID: 260398 RVA: 0x0104B398 File Offset: 0x01049598
		[return: TupleElementNames(new string[]
		{
			"Rows",
			"Cols"
		})]
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public ValueTuple<List<int>, List<int>> GetClearAbleRowsAndColsIfPlace([TupleElementNames(new string[]
		{
			"Row",
			"Column"
		})] [Nullable(new byte[]
		{
			1,
			0
		})] List<ValueTuple<int, int>> positions)
		{
			bool[][] boardOccupancy = this.GridModel.GetBoardOccupancy();
			bool[][] array = new bool[8][];
			for (int i = 0; i < 8; i++)
			{
				array[i] = new bool[8];
				for (int j = 0; j < 8; j++)
				{
					array[i][j] = boardOccupancy[i][j];
				}
			}
			foreach (ValueTuple<int, int> valueTuple in positions)
			{
				if (valueTuple.Item1 >= 0 && valueTuple.Item1 < 8 && valueTuple.Item2 >= 0 && valueTuple.Item2 < 8)
				{
					array[valueTuple.Item1][valueTuple.Item2] = true;
				}
			}
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			for (int k = 0; k < 8; k++)
			{
				bool flag = true;
				for (int l = 0; l < 8; l++)
				{
					if (!array[k][l])
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					list.Add(k);
				}
			}
			for (int m = 0; m < 8; m++)
			{
				bool flag2 = true;
				for (int n = 0; n < 8; n++)
				{
					if (!array[n][m])
					{
						flag2 = false;
						break;
					}
				}
				if (flag2)
				{
					list2.Add(m);
				}
			}
			return new ValueTuple<List<int>, List<int>>(list, list2);
		}

		// Token: 0x0603F92F RID: 260399 RVA: 0x0104B4F4 File Offset: 0x010496F4
		private List<string> SerializeBoardLines()
		{
			List<string> list = new List<string>();
			TetrisCellData[][] cells = this.GridModel.Cells;
			for (int i = 0; i < 8; i++)
			{
				string text = "";
				for (int j = 0; j < 8; j++)
				{
					text += (cells[i][j].IsOccupied ? "1" : "0");
				}
				list.Add(text);
			}
			return list;
		}

		// Token: 0x0603F930 RID: 260400 RVA: 0x0104B560 File Offset: 0x01049760
		private int GetLevelCostTimeSeconds()
		{
			if (this.LevelStartTime <= 0L)
			{
				return 0;
			}
			return (int)Math.Round((double)(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - this.LevelStartTime) / 1000.0);
		}

		// Token: 0x0603F931 RID: 260401 RVA: 0x0104B5A0 File Offset: 0x010497A0
		private void ResetTraceId()
		{
			PlayerInfoModel instance = ModelBase<PlayerInfoModel>.Instance;
			int valueOrDefault = ((instance != null) ? instance.GetId() : null).GetValueOrDefault();
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(valueOrDefault);
			defaultInterpolatedStringHandler.AppendLiteral("_");
			defaultInterpolatedStringHandler.AppendFormatted<long>(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
			this.CurrentTraceId = defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0603F932 RID: 260402 RVA: 0x0104B60D File Offset: 0x0104980D
		private string GetTraceId()
		{
			if (this.CurrentTraceId.Length <= 0)
			{
				this.ResetTraceId();
			}
			return this.CurrentTraceId;
		}

		// Token: 0x0603F933 RID: 260403 RVA: 0x0104B62C File Offset: 0x0104982C
		private string SerializeHandShapes([Nullable(new byte[]
		{
			1,
			2
		})] List<BlockInstance> shapes)
		{
			List<string> list = new List<string>();
			foreach (BlockInstance blockInstance in shapes)
			{
				if (blockInstance != null)
				{
					list.Add(blockInstance.ConfigId.ToString());
				}
			}
			return string.Join(",", list);
		}

		// Token: 0x0603F934 RID: 260404 RVA: 0x0104B69C File Offset: 0x0104989C
		private string SerializeGemReward()
		{
			if (this.GetGameMode() != EGameMode.GemCollection)
			{
				return "-1";
			}
			Dictionary<EGemType, int> currentGem = this.GemModel.GetCurrentGem();
			List<string> list = new List<string>();
			foreach (KeyValuePair<EGemType, int> keyValuePair in currentGem)
			{
				if (keyValuePair.Value > 0)
				{
					List<string> list2 = list;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
					defaultInterpolatedStringHandler.AppendFormatted<int>((int)keyValuePair.Key);
					defaultInterpolatedStringHandler.AppendLiteral(":");
					defaultInterpolatedStringHandler.AppendFormatted<int>(keyValuePair.Value);
					list2.Add(defaultInterpolatedStringHandler.ToStringAndClear());
				}
			}
			return string.Join(",", list);
		}

		// Token: 0x0603F935 RID: 260405 RVA: 0x0104B754 File Offset: 0x01049954
		public void SendStartLogData()
		{
			TetrisStartLogEvent tetrisStartLogEvent = new TetrisStartLogEvent();
			Tetris? currentLevelConfig = this.CurrentLevelConfig;
			if (currentLevelConfig != null)
			{
				int id = currentLevelConfig.Value.Id;
				tetrisStartLogEvent.i_activity_id = ControllerBase<ActivityTetrisController>.Instance.ActivityId;
				tetrisStartLogEvent.i_inst_id = id;
				tetrisStartLogEvent.i_type = currentLevelConfig.Value.Mode;
				TetrisStartLogEvent tetrisStartLogEvent2 = tetrisStartLogEvent;
				ActivityTetrisData tetrisData = ControllerBase<ActivityTetrisController>.Instance.GetTetrisData();
				tetrisStartLogEvent2.i_first_pass = (((tetrisData != null && tetrisData.CheckChallengeComplete(id)) > false) ? 1 : 0);
				tetrisStartLogEvent.s_trace_id = this.GetTraceId();
			}
			ControllerBase<LogReportController>.Instance.LogReport(tetrisStartLogEvent);
		}

		// Token: 0x0603F936 RID: 260406 RVA: 0x0104B7EC File Offset: 0x010499EC
		public void SendResultLogData(int operation)
		{
			TetrisResultLogEvent tetrisResultLogEvent = new TetrisResultLogEvent();
			Tetris? currentLevelConfig = this.CurrentLevelConfig;
			if (currentLevelConfig != null)
			{
				int id = currentLevelConfig.Value.Id;
				List<string> list = this.SerializeBoardLines();
				tetrisResultLogEvent.i_activity_id = ControllerBase<ActivityTetrisController>.Instance.ActivityId;
				tetrisResultLogEvent.i_inst_id = id;
				tetrisResultLogEvent.i_type = currentLevelConfig.Value.Mode;
				TetrisResultLogEvent tetrisResultLogEvent2 = tetrisResultLogEvent;
				ActivityTetrisData tetrisData = ControllerBase<ActivityTetrisController>.Instance.GetTetrisData();
				tetrisResultLogEvent2.i_first_pass = (((tetrisData != null && tetrisData.CheckChallengeComplete(id)) > false) ? 1 : 0);
				tetrisResultLogEvent.s_trace_id = this.GetTraceId();
				tetrisResultLogEvent.i_if_back = ((this.TakeBackCount > 0) ? 1 : 0);
				tetrisResultLogEvent.i_inst_diff = (int)this.CurrentDifficulty;
				tetrisResultLogEvent.i_result = operation;
				tetrisResultLogEvent.i_display_mode = ((this.GetGameMode() == EGameMode.GemCollection) ? 2 : 1);
				tetrisResultLogEvent.i_get_score = this.ScoreModel.GetScore();
				tetrisResultLogEvent.i_combo_max = this.ScoreModel.GetMaxComboCount();
				tetrisResultLogEvent.o_reward_items_new = this.SerializeGemReward();
				tetrisResultLogEvent.i_round = this.CurrentStageIndex;
				tetrisResultLogEvent.i_count = this.PlaceCount;
				tetrisResultLogEvent.i_cost_time = this.GetLevelCostTimeSeconds();
				tetrisResultLogEvent.i_first_tab = this.FirstRefillHandShapesSerialized;
				tetrisResultLogEvent.i_second_tab = this.CurrentRoundRefillHandShapesSerialized;
				tetrisResultLogEvent.o_line_end1 = ((list.Count > 0) ? list[0] : "");
				tetrisResultLogEvent.o_line_end2 = ((list.Count > 1) ? list[1] : "");
				tetrisResultLogEvent.o_line_end3 = ((list.Count > 2) ? list[2] : "");
				tetrisResultLogEvent.o_line_end4 = ((list.Count > 3) ? list[3] : "");
				tetrisResultLogEvent.o_line_end5 = ((list.Count > 4) ? list[4] : "");
				tetrisResultLogEvent.o_line_end6 = ((list.Count > 5) ? list[5] : "");
			}
			ControllerBase<LogReportController>.Instance.LogReport(tetrisResultLogEvent);
		}

		// Token: 0x0603F937 RID: 260407 RVA: 0x0104B9DC File Offset: 0x01049BDC
		private void FillRoundLogBoardLines(TetrisRoundLogEvent logData, List<string> boardLines)
		{
			string text = "";
			logData.o_line_start1 = ((boardLines.Count > 0) ? boardLines[0] : text);
			logData.o_line_start2 = ((boardLines.Count > 1) ? boardLines[1] : text);
			logData.o_line_start3 = ((boardLines.Count > 2) ? boardLines[2] : text);
			logData.o_line_start4 = ((boardLines.Count > 3) ? boardLines[3] : text);
			logData.o_line_start5 = ((boardLines.Count > 4) ? boardLines[4] : text);
			logData.o_line_start6 = ((boardLines.Count > 5) ? boardLines[5] : text);
			logData.o_line_start7 = ((boardLines.Count > 6) ? boardLines[6] : text);
			logData.o_line_start8 = ((boardLines.Count > 7) ? boardLines[7] : text);
			logData.o_line_end1 = ((boardLines.Count > 0) ? boardLines[0] : text);
			logData.o_line_end2 = ((boardLines.Count > 1) ? boardLines[1] : text);
			logData.o_line_end3 = ((boardLines.Count > 2) ? boardLines[2] : text);
			logData.o_line_end4 = ((boardLines.Count > 3) ? boardLines[3] : text);
			logData.o_line_end5 = ((boardLines.Count > 4) ? boardLines[4] : text);
			logData.o_line_end6 = ((boardLines.Count > 5) ? boardLines[5] : text);
			logData.o_line_end7 = ((boardLines.Count > 6) ? boardLines[6] : text);
			logData.o_line_end8 = ((boardLines.Count > 7) ? boardLines[7] : text);
		}

		// Token: 0x0603F938 RID: 260408 RVA: 0x0104BB80 File Offset: 0x01049D80
		public void SendRoundLogData()
		{
			TetrisRoundLogEvent tetrisRoundLogEvent = new TetrisRoundLogEvent();
			Tetris? currentLevelConfig = this.CurrentLevelConfig;
			if (currentLevelConfig != null)
			{
				int id = currentLevelConfig.Value.Id;
				List<string> boardLines = this.SerializeBoardLines();
				tetrisRoundLogEvent.i_activity_id = ControllerBase<ActivityTetrisController>.Instance.ActivityId;
				tetrisRoundLogEvent.i_inst_id = id;
				tetrisRoundLogEvent.i_type = (int)this.GetGameMode();
				TetrisRoundLogEvent tetrisRoundLogEvent2 = tetrisRoundLogEvent;
				ActivityTetrisData tetrisData = ControllerBase<ActivityTetrisController>.Instance.GetTetrisData();
				tetrisRoundLogEvent2.i_first_pass = (((tetrisData != null && tetrisData.CheckChallengeComplete(id)) > false) ? 1 : 0);
				tetrisRoundLogEvent.s_trace_id = this.GetTraceId();
				tetrisRoundLogEvent.i_if_back = ((this.TakeBackCount > 0) ? 1 : 0);
				tetrisRoundLogEvent.i_inst_diff = (int)this.CurrentDifficulty;
				tetrisRoundLogEvent.i_round = this.CurrentStageIndex;
				tetrisRoundLogEvent.i_result = 0;
				tetrisRoundLogEvent.i_display_mode = ((this.GetGameMode() == EGameMode.GemCollection) ? 2 : 1);
				tetrisRoundLogEvent.i_get_score = this.ScoreModel.GetScore();
				tetrisRoundLogEvent.if_con_combo = ((this.ScoreModel.GetComboCount() > 0) ? 1 : 0);
				tetrisRoundLogEvent.i_combo_max = this.ScoreModel.GetComboCount();
				tetrisRoundLogEvent.o_reward_items_new = this.SerializeGemReward();
				tetrisRoundLogEvent.i_first_tab = this.CurrentRoundRefillHandShapesSerialized;
				tetrisRoundLogEvent.i_count = this.PlaceCount;
				tetrisRoundLogEvent.i_cost_time = this.GetLevelCostTimeSeconds();
				this.FillRoundLogBoardLines(tetrisRoundLogEvent, boardLines);
			}
			ControllerBase<LogReportController>.Instance.LogReport(tetrisRoundLogEvent);
		}

		// Token: 0x0603F93A RID: 260410 RVA: 0x0104BD33 File Offset: 0x01049F33
		[CompilerGenerated]
		private void <OnPlayerDropShape>g__doAfterPlaceAnimation|36_0(float _)
		{
			this.UpdateGameState();
			this.CurrentRoundIndex++;
		}

		// Token: 0x0603F93C RID: 260412 RVA: 0x0104BD54 File Offset: 0x01049F54
		[CompilerGenerated]
		private void <OnGameLose>g__deferLoseAnimation|48_0()
		{
			this.LoseCount++;
			if (this.GetGameMode() == EGameMode.Infinite)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.TetrisTipsEndLessEndView, this.ScoreModel.GetScore(), null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TetrisTipsLoseView, null, null);
		}

		// Token: 0x0603F93D RID: 260413 RVA: 0x0104BDAC File Offset: 0x01049FAC
		[CompilerGenerated]
		private void <ShowTakeBackConfirm>g__cancelCallback|55_0()
		{
			this.LoseCount++;
			if (this.GetGameMode() == EGameMode.Infinite)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.TetrisTipsEndLessEndView, this.ScoreModel.GetScore(), null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TetrisTipsLoseView, null, null);
		}

		// Token: 0x0603F93E RID: 260414 RVA: 0x0104BE02 File Offset: 0x0104A002
		[CompilerGenerated]
		private void <ShowTakeBackConfirm>g__confirmCallback|55_1()
		{
			this.DoTakeBack();
		}

		// Token: 0x0603F940 RID: 260416 RVA: 0x0104BE19 File Offset: 0x0104A019
		[CompilerGenerated]
		internal static void <TryChangeLevelDifficulty>g__cancelCallback|61_0()
		{
		}

		// Token: 0x04023ADD RID: 146141
		private readonly TetrisBoardData GridModel = new TetrisBoardData();

		// Token: 0x04023ADE RID: 146142
		private readonly TetrisScoreData ScoreModel = new TetrisScoreData();

		// Token: 0x04023ADF RID: 146143
		private readonly TetrisGemData GemModel = new TetrisGemData();

		// Token: 0x04023AE0 RID: 146144
		private List<IShapeConfig> AllShapes = new List<IShapeConfig>();

		// Token: 0x04023AE1 RID: 146145
		[Nullable(new byte[]
		{
			1,
			2
		})]
		public List<BlockInstance> HandShapes = new List<BlockInstance>();

		// Token: 0x04023AE2 RID: 146146
		public Tetris? CurrentLevelConfig;

		// Token: 0x04023AE3 RID: 146147
		public bool IsGameOver;

		// Token: 0x04023AE4 RID: 146148
		public int CurrentRoundIndex;

		// Token: 0x04023AE5 RID: 146149
		private int LoseCount;

		// Token: 0x04023AE6 RID: 146150
		public ETetrisDifficulty CurrentDifficulty;

		// Token: 0x04023AE7 RID: 146151
		private int TakeBackCount;

		// Token: 0x04023AE8 RID: 146152
		[Nullable(2)]
		private ITetrisGameSnapshot TakeBackSnapshot;

		// Token: 0x04023AE9 RID: 146153
		private long LevelStartTime;

		// Token: 0x04023AEA RID: 146154
		private string CurrentTraceId = "";

		// Token: 0x04023AEB RID: 146155
		private int PlaceCount;

		// Token: 0x04023AEC RID: 146156
		private string FirstRefillHandShapesSerialized = "";

		// Token: 0x04023AED RID: 146157
		private string CurrentRoundRefillHandShapesSerialized = "";

		// Token: 0x04023AEE RID: 146158
		private int CurrentStageIndex;

		// Token: 0x04023AEF RID: 146159
		private bool IsAnimating;

		// Token: 0x04023AF0 RID: 146160
		private bool UseDialogWinOnly;

		// Token: 0x04023AF1 RID: 146161
		[Nullable(2)]
		public Action<bool, bool> OnDataUpdate;

		// Token: 0x04023AF2 RID: 146162
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<IComboData> OnCombo;

		// Token: 0x04023AF3 RID: 146163
		[Nullable(2)]
		public Action OnRefillHandShapes;

		// Token: 0x04023AF4 RID: 146164
		[TupleElementNames(new string[]
		{
			"Row",
			"Column"
		})]
		[Nullable(new byte[]
		{
			2,
			1,
			0,
			2
		})]
		public Action<List<ValueTuple<int, int>>, TTimerAction> OnPlaceAnimation;

		// Token: 0x04023AF5 RID: 146165
		[TupleElementNames(new string[]
		{
			"Row",
			"Column",
			"ColorId",
			"Row",
			"Column",
			"ColorId"
		})]
		[Nullable(new byte[]
		{
			2,
			1,
			0,
			1,
			0,
			1,
			1,
			2
		})]
		public Action<List<ValueTuple<int, int, int>>, List<ValueTuple<int, int, int>>, List<int>, List<int>, bool, Action> OnRemoveAnimation;

		// Token: 0x04023AF6 RID: 146166
		[Nullable(2)]
		public Action<Action> OnCleanAnimation;

		// Token: 0x04023AF7 RID: 146167
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<Action> OnLoseBoardAnimation;
	}
}
