using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using AkiClient.Game.Aki.Data.Gameplay.Tetris;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.Inventory;

namespace CSharpScript.Game.Module.SlidingBlocks
{
	// Token: 0x02004F00 RID: 20224
	[NullableContext(1)]
	[Nullable(0)]
	public class SlidingBlocksGameData
	{
		// Token: 0x17008A16 RID: 35350
		// (get) Token: 0x06034453 RID: 214099 RVA: 0x00D13224 File Offset: 0x00D11424
		// (set) Token: 0x06034454 RID: 214100 RVA: 0x00D1322C File Offset: 0x00D1142C
		[Nullable(2)]
		public Tetromino CurTetromino
		{
			[NullableContext(2)]
			get
			{
				return this.CurTetrominoInternal;
			}
			[NullableContext(2)]
			set
			{
				this.CurTetrominoInternal = value;
			}
		}

		// Token: 0x17008A17 RID: 35351
		// (get) Token: 0x06034455 RID: 214101 RVA: 0x00D13235 File Offset: 0x00D11435
		public double GridMaxX
		{
			get
			{
				return this.GridSize.X - 0.5;
			}
		}

		// Token: 0x17008A18 RID: 35352
		// (get) Token: 0x06034456 RID: 214102 RVA: 0x00D1324C File Offset: 0x00D1144C
		public double GridMinY
		{
			get
			{
				if (this.PlayMode != ETetrisPlayMode.MainLine)
				{
					return (double)SlidingBlocksGlobal.Setting.PrepareAreaMinY + 0.5;
				}
				return 0.5;
			}
		}

		// Token: 0x17008A19 RID: 35353
		// (get) Token: 0x06034457 RID: 214103 RVA: 0x00D13276 File Offset: 0x00D11476
		public double GridMaxY
		{
			get
			{
				return this.GridSize.Y - 0.5;
			}
		}

		// Token: 0x06034458 RID: 214104 RVA: 0x00D1328D File Offset: 0x00D1148D
		public float SingleCellMoveTime()
		{
			return (float)Singleton<TimeUtil>.Instance.InverseMillisecond / this.FallSpeed;
		}

		// Token: 0x06034459 RID: 214105 RVA: 0x00D132A4 File Offset: 0x00D114A4
		public void Init(IFinishTetris config, global::Transform originTransform, Bp_Tetris_C setting, GeneralLogicTreeContext context)
		{
			this.OriginTransform = originTransform;
			this.PlayMode = config.PlayMode.Type;
			this.Score = 0.0;
			Vector2D gridSize = this.GridSize;
			ITetrisIndexedBoard presetBlocks = config.PresetBlocks;
			double inX = Math.Floor((double)((presetBlocks != null) ? presetBlocks.BoardSize.X : setting.DefaultBoardSize.X));
			ITetrisIndexedBoard presetBlocks2 = config.PresetBlocks;
			gridSize.Set(inX, Math.Floor((double)((presetBlocks2 != null) ? presetBlocks2.BoardSize.Y : setting.DefaultBoardSize.Y)));
			switch (config.PlayMode.Type)
			{
			case ETetrisPlayMode.Normal:
			{
				ITetrisPlayModeNormal tetrisPlayModeNormal = config.PlayMode as ITetrisPlayModeNormal;
				this.Time = (double)((tetrisPlayModeNormal != null) ? tetrisPlayModeNormal.Time : 0);
				break;
			}
			case ETetrisPlayMode.Endless:
			{
				ITetrisPlayModeEndless tetrisPlayModeEndless = config.PlayMode as ITetrisPlayModeEndless;
				this.SpeedLevel = ((tetrisPlayModeEndless != null) ? tetrisPlayModeEndless.SpeedLevel : null).GetValueOrDefault(1);
				this.SpeedUpTime = 0.0;
				break;
			}
			case ETetrisPlayMode.MainLine:
			{
				ITetrisPlayModeMainLine tetrisPlayModeMainLine = config.PlayMode as ITetrisPlayModeMainLine;
				this.SequenceEntityPbDataId = tetrisPlayModeMainLine.EntityId;
				this.SequenceEntityInitState = tetrisPlayModeMainLine.EntityState;
				if (tetrisPlayModeMainLine.FieldHeight != null)
				{
					this.GridSize.Y = (double)tetrisPlayModeMainLine.FieldHeight.Value;
				}
				break;
			}
			}
			this.PresetBlocks = null;
			if (config.PresetBlocks != null)
			{
				this.PresetBlocks = config.PresetBlocks.IndexedGrids;
			}
			this.CurSpawnTetrominoList = null;
			this.AllTetrominoList.Clear();
			this.WaitRemoveTetrominoList.Clear();
			this.Direction = config.Direction;
			this.FallSpeed = config.FallSpeed.GetValueOrDefault(1f);
			this.InitPrepareTime = (config.PrepareTime ?? setting.CubeControlTime);
			this.PrepareTime = this.InitPrepareTime;
			this.Context = context;
			this.AreaLoopEffectHandle = 0;
			this.AreaLoop2EffectHandle = 0;
			this.AvailableTetrominoConfigs.Clear();
			List<string> availableCombineBlocks = config.AvailableCombineBlocks;
			if (availableCombineBlocks != null && availableCombineBlocks.Count > 0)
			{
				foreach (string shapeName in config.AvailableCombineBlocks)
				{
					ITetrominoConfig tetrominoConfigByShapeName = SlidingBlocksUtil.GetTetrominoConfigByShapeName(shapeName);
					if (tetrominoConfigByShapeName != null)
					{
						this.AvailableTetrominoConfigs.Add(tetrominoConfigByShapeName);
					}
				}
			}
			this.AudioData.Init();
		}

		// Token: 0x0603445A RID: 214106 RVA: 0x00D13530 File Offset: 0x00D11730
		public void Reset()
		{
			this.ServerData.Reset();
			this.AudioData.Reset();
			this.TickMinos.Clear();
			foreach (KeyValuePair<double, TetrisGridColumn> keyValuePair in this.GridColumns)
			{
				keyValuePair.Value.Clear();
			}
			this.GridColumns.Clear();
			foreach (KeyValuePair<double, TetrisGridRow> keyValuePair2 in this.GridRows)
			{
				keyValuePair2.Value.Clear();
			}
			this.GridRows.Clear();
			this.NextTetrominoSpawnCd = 0.0;
			this.CurTetrominoInternal = null;
			this.MainLineGameCompleteTriggered = false;
			this.MainLineSequenceStart = false;
			this.CurSpawnTetrominoList = null;
			this.CharacterOutlineEffectHandle = 0;
			this.GameEndReason = SlidingBlocksDefine.EGameEndReason.None;
			this.CubeDestroyEffect = null;
		}

		// Token: 0x0603445B RID: 214107 RVA: 0x00D13648 File Offset: 0x00D11848
		public bool AddMinoData(double x, double y, Mino minoData, SlidingBlocksDefine.EAddMinoReason reason)
		{
			bool flag = this.AddColumnData(x, y, minoData);
			bool flag2 = this.AddRowData(x, y, minoData);
			return flag && flag2;
		}

		// Token: 0x0603445C RID: 214108 RVA: 0x00D1366C File Offset: 0x00D1186C
		public bool RemoveMinoData(double x, double y, SlidingBlocksDefine.ERemoveMinoReason reason)
		{
			bool flag = this.RemoveColumnData(x, y);
			bool flag2 = this.RemoveRowData(x, y);
			return flag && flag2;
		}

		// Token: 0x0603445D RID: 214109 RVA: 0x00D13690 File Offset: 0x00D11890
		private bool AddColumnData(double x, double y, Mino minoData)
		{
			if (x < 0.0 || x >= this.GridSize.X || y < 0.0 || y >= this.GridSize.Y)
			{
				return false;
			}
			TetrisGridColumn tetrisGridColumn;
			if (!this.GridColumns.TryGetValue(x, out tetrisGridColumn))
			{
				tetrisGridColumn = new TetrisGridColumn(this, x);
				this.GridColumns[x] = tetrisGridColumn;
			}
			return tetrisGridColumn.AddData(y, minoData);
		}

		// Token: 0x0603445E RID: 214110 RVA: 0x00D13700 File Offset: 0x00D11900
		private bool RemoveColumnData(double x, double y)
		{
			TetrisGridColumn tetrisGridColumn;
			return this.GridColumns.TryGetValue(x, out tetrisGridColumn) && tetrisGridColumn.RemoveData(y);
		}

		// Token: 0x0603445F RID: 214111 RVA: 0x00D13728 File Offset: 0x00D11928
		private bool AddRowData(double x, double y, Mino minoData)
		{
			if (x < 0.0 || x >= this.GridSize.X || y < 0.0 || y >= this.GridSize.Y)
			{
				return false;
			}
			TetrisGridRow tetrisGridRow;
			if (!this.GridRows.TryGetValue(y, out tetrisGridRow))
			{
				tetrisGridRow = new TetrisGridRow(this, y, this.GridSize.X);
				this.GridRows[y] = tetrisGridRow;
			}
			return tetrisGridRow.AddData(x, minoData);
		}

		// Token: 0x06034460 RID: 214112 RVA: 0x00D137A4 File Offset: 0x00D119A4
		private bool RemoveRowData(double x, double y)
		{
			TetrisGridRow tetrisGridRow;
			return this.GridRows.TryGetValue(y, out tetrisGridRow) && tetrisGridRow.RemoveData(x);
		}

		// Token: 0x06034461 RID: 214113 RVA: 0x00D137CA File Offset: 0x00D119CA
		public void RemoveTetromino(Tetromino tetromino)
		{
			this.WaitRemoveTetrominoList.Add(tetromino);
		}

		// Token: 0x06034462 RID: 214114 RVA: 0x00D137D8 File Offset: 0x00D119D8
		public void SetServerData(AvoidBlockRoundInfoNotify notify)
		{
			this.ServerData.Init(notify.InstId, notify.HistoryScore, notify.RewardId.ToArray<int>());
			string rewardTitleTextKey = this.ServerData.RewardTitleTextKey;
			if (rewardTitleTextKey == null || StringUtils.IsBlank(rewardTitleTextKey))
			{
				return;
			}
			this.Targets = new List<ITargetDescribeAndScore>();
			string[] array = rewardTitleTextKey.Split(';', StringSplitOptions.None);
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(',', StringSplitOptions.None);
				int num = int.Parse(array2[1]);
				AvoidBlockReward? config = ConfigAvoidBlockRewardByRewardId.GetConfig(num, true);
				if (config != null)
				{
					TargetDescribeAndScore item = new TargetDescribeAndScore
					{
						DescribeTextKey = array2[0],
						RewardId = num,
						Score = config.Value.TargetScore
					};
					this.Targets.Add(item);
				}
			}
		}

		// Token: 0x06034463 RID: 214115 RVA: 0x00D138A8 File Offset: 0x00D11AA8
		public void SetSettlementData(AvoidBlockSettlementNotify notify)
		{
			if (this.ServerData == null)
			{
				return;
			}
			this.ServerData.IsWin = notify.Win;
			this.ServerData.HistoryScore = notify.HistoryScore;
			this.ServerData.RewardList.Clear();
			foreach (KeyValuePair<int, int> keyValuePair in notify.RewardItemMap)
			{
				this.ServerData.RewardList.Add(new TItem(new InventoryDefine.GetItemData(keyValuePair.Key, 0), keyValuePair.Value));
			}
		}

		// Token: 0x0401E277 RID: 123511
		[Nullable(2)]
		public GeneralLogicTreeContext Context;

		// Token: 0x0401E278 RID: 123512
		public SlidingBlocksDefine.EGameEndReason GameEndReason;

		// Token: 0x0401E279 RID: 123513
		public SlidingBlocksGameServerData ServerData = new SlidingBlocksGameServerData();

		// Token: 0x0401E27A RID: 123514
		public SlidingBlocksGameAudioData AudioData = new SlidingBlocksGameAudioData();

		// Token: 0x0401E27B RID: 123515
		[Nullable(2)]
		public global::Transform OriginTransform;

		// Token: 0x0401E27C RID: 123516
		public ETetrisPlayMode PlayMode;

		// Token: 0x0401E27D RID: 123517
		public ETetrisDirection Direction;

		// Token: 0x0401E27E RID: 123518
		public readonly List<ITetrominoConfig> AvailableTetrominoConfigs = new List<ITetrominoConfig>();

		// Token: 0x0401E27F RID: 123519
		public int SequenceEntityPbDataId;

		// Token: 0x0401E280 RID: 123520
		public string SequenceEntityInitState;

		// Token: 0x0401E281 RID: 123521
		public double Time;

		// Token: 0x0401E282 RID: 123522
		public float FallSpeed;

		// Token: 0x0401E283 RID: 123523
		public float PrepareTime;

		// Token: 0x0401E284 RID: 123524
		public float InitPrepareTime;

		// Token: 0x0401E285 RID: 123525
		public double Score;

		// Token: 0x0401E286 RID: 123526
		public int SpeedLevel = 1;

		// Token: 0x0401E287 RID: 123527
		public double SpeedUpTime;

		// Token: 0x0401E288 RID: 123528
		public readonly Vector2D GridSize = Vector2D.Create();

		// Token: 0x0401E289 RID: 123529
		public readonly Vector2D PlayerCoord = Vector2D.Create();

		// Token: 0x0401E28A RID: 123530
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public IReadOnlyList<ITetrisSingleIndexGrid> PresetBlocks;

		// Token: 0x0401E28B RID: 123531
		public readonly Dictionary<double, TetrisGridColumn> GridColumns = new Dictionary<double, TetrisGridColumn>();

		// Token: 0x0401E28C RID: 123532
		public readonly Dictionary<double, TetrisGridRow> GridRows = new Dictionary<double, TetrisGridRow>();

		// Token: 0x0401E28D RID: 123533
		public readonly List<Tetromino> AllTetrominoList = new List<Tetromino>();

		// Token: 0x0401E28E RID: 123534
		public readonly List<Tetromino> WaitRemoveTetrominoList = new List<Tetromino>();

		// Token: 0x0401E28F RID: 123535
		public readonly List<Mino> TickMinos = new List<Mino>();

		// Token: 0x0401E290 RID: 123536
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ITetrominoConfig> CurSpawnTetrominoList;

		// Token: 0x0401E291 RID: 123537
		public int CurSpawnTetrominoListIndex;

		// Token: 0x0401E292 RID: 123538
		[Nullable(2)]
		private Tetromino CurTetrominoInternal;

		// Token: 0x0401E293 RID: 123539
		public double NextTetrominoSpawnCd;

		// Token: 0x0401E294 RID: 123540
		public bool IsProcessLineClear;

		// Token: 0x0401E295 RID: 123541
		public bool MainLineSequenceStart;

		// Token: 0x0401E296 RID: 123542
		public bool MainLineGameCompleteTriggered;

		// Token: 0x0401E297 RID: 123543
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ITargetDescribeAndScore> Targets;

		// Token: 0x0401E298 RID: 123544
		public int AreaLoopEffectHandle;

		// Token: 0x0401E299 RID: 123545
		public int AreaLoop2EffectHandle;

		// Token: 0x0401E29A RID: 123546
		public int CharacterOutlineEffectHandle;

		// Token: 0x0401E29B RID: 123547
		[Nullable(2)]
		public ItemMaterialControllerActorData CubeDestroyEffect;

		// Token: 0x0401E29C RID: 123548
		public readonly double GridMinX = 0.5;
	}
}
