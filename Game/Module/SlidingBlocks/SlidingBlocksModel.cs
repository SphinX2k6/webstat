using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.LevelGamePlay;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.SlidingBlocks
{
	// Token: 0x02004F01 RID: 20225
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class SlidingBlocksModel : ModelBase<SlidingBlocksModel>
	{
		// Token: 0x17008A1A RID: 35354
		// (get) Token: 0x06034465 RID: 214117 RVA: 0x00D139EC File Offset: 0x00D11BEC
		public bool IsInGame
		{
			get
			{
				SlidingBlocksDefine.EGameStage gameStage = this.GameStage;
				return gameStage > SlidingBlocksDefine.EGameStage.None && gameStage <= SlidingBlocksDefine.EGameStage.Settlement;
			}
		}

		// Token: 0x17008A1B RID: 35355
		// (get) Token: 0x06034466 RID: 214118 RVA: 0x00D13A0D File Offset: 0x00D11C0D
		public bool IsGameRunning
		{
			get
			{
				return this.GameStage == SlidingBlocksDefine.EGameStage.GameRunning;
			}
		}

		// Token: 0x06034467 RID: 214119 RVA: 0x00D13A18 File Offset: 0x00D11C18
		protected override bool OnLeaveLevel()
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.GameData.AreaLoopEffectHandle, "SlidingBlocksModel.OnLeaveLevel", true, null);
			this.GameData.AreaLoopEffectHandle = 0;
			return true;
		}

		// Token: 0x06034468 RID: 214120 RVA: 0x00D13A57 File Offset: 0x00D11C57
		protected override bool OnClear()
		{
			this.BoxMeshCache = null;
			return true;
		}

		// Token: 0x06034469 RID: 214121 RVA: 0x00D13A64 File Offset: 0x00D11C64
		[return: Nullable(0)]
		public UniTask<bool> InitGameData(IFinishTetris config, Transform originTransform, GeneralLogicTreeContext context)
		{
			SlidingBlocksModel.<InitGameData>d__10 <InitGameData>d__;
			<InitGameData>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<InitGameData>d__.<>4__this = this;
			<InitGameData>d__.config = config;
			<InitGameData>d__.originTransform = originTransform;
			<InitGameData>d__.context = context;
			<InitGameData>d__.<>1__state = -1;
			<InitGameData>d__.<>t__builder.Start<SlidingBlocksModel.<InitGameData>d__10>(ref <InitGameData>d__);
			return <InitGameData>d__.<>t__builder.Task;
		}

		// Token: 0x0603446A RID: 214122 RVA: 0x00D13ABF File Offset: 0x00D11CBF
		public void OnGameOver()
		{
			this.SwitchStage(SlidingBlocksDefine.EGameStage.None, false);
			this.GameData.Reset();
			SlidingBlocksGlobal.ClearSettingData();
		}

		// Token: 0x0603446B RID: 214123 RVA: 0x00D13ADC File Offset: 0x00D11CDC
		public unsafe bool AddMino(string styleName, double x, double y, SlidingBlocksDefine.EAddMinoReason reason)
		{
			AActor aactor = SlidingBlocksUtil.CreateDynamicCube(styleName, x, y, this.GameData.OriginTransform, this.BoxMeshCache);
			if (aactor == null || !aactor.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SlidingBlocks;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "SlidingBlocksModel.AddMino：创建cubeActor失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("styleName", styleName);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
				string item = "coord";
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
				defaultInterpolatedStringHandler.AppendLiteral("(");
				defaultInterpolatedStringHandler.AppendFormatted<double>(x);
				defaultInterpolatedStringHandler.AppendLiteral(",");
				defaultInterpolatedStringHandler.AppendFormatted<double>(y);
				defaultInterpolatedStringHandler.AppendLiteral(")");
				ptr = new ValueTuple<string, object>(item, defaultInterpolatedStringHandler.ToStringAndClear());
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			Mino minoData = new Mino(styleName, Vector2D.Create(x, y), aactor, SlidingBlocksDefine.EMinoParent.Board);
			this.GameData.AddMinoData(x, y, minoData, reason);
			return true;
		}

		// Token: 0x0603446C RID: 214124 RVA: 0x00D13BD4 File Offset: 0x00D11DD4
		public void EnterNextStage()
		{
			this.GameStage++;
			Singleton<EventSystem>.Instance.Emit(EEventName.SlidingBlockGameStageChanged);
		}

		// Token: 0x0603446D RID: 214125 RVA: 0x00D13BF4 File Offset: 0x00D11DF4
		public void SwitchStage(SlidingBlocksDefine.EGameStage stage, bool bFireEvent = true)
		{
			this.GameStage = stage;
			if (bFireEvent)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.SlidingBlockGameStageChanged);
			}
		}

		// Token: 0x0603446E RID: 214126 RVA: 0x00D13C10 File Offset: 0x00D11E10
		[NullableContext(2)]
		public void SetCurTetromino(Tetromino tetromino)
		{
			if (tetromino != null)
			{
				this.GameData.CurTetromino = tetromino;
				this.GameData.AllTetrominoList.Add(tetromino);
				return;
			}
			this.GameData.CurTetromino = null;
		}

		// Token: 0x0603446F RID: 214127 RVA: 0x00D13C40 File Offset: 0x00D11E40
		public bool CheckGridOccupied(double x, double y)
		{
			TetrisGridColumn tetrisGridColumn;
			return this.GameData.GridColumns.TryGetValue(x, out tetrisGridColumn) && tetrisGridColumn.CheckOccupied(y);
		}

		// Token: 0x06034470 RID: 214128 RVA: 0x00D13C6C File Offset: 0x00D11E6C
		public double FindUnoccupiedGrid(double x, double y)
		{
			TetrisGridColumn tetrisGridColumn;
			if (!this.GameData.GridColumns.TryGetValue(x, out tetrisGridColumn))
			{
				return this.GameData.GridMaxY;
			}
			return tetrisGridColumn.FindUnoccupiedGrid(y);
		}

		// Token: 0x06034471 RID: 214129 RVA: 0x00D13CA4 File Offset: 0x00D11EA4
		public bool CheckGridOccupiedUnderPlayer()
		{
			Vector2D playerCoord = this.GameData.PlayerCoord;
			return this.CheckGridOccupiedUnderCoord(playerCoord.X, playerCoord.Y);
		}

		// Token: 0x06034472 RID: 214130 RVA: 0x00D13CCF File Offset: 0x00D11ECF
		public bool CheckGridOccupiedUnderCoord(double x, double y)
		{
			return y.Equals(this.GameData.GridMaxY) || this.CheckGridOccupied(x, y + 1.0);
		}

		// Token: 0x06034473 RID: 214131 RVA: 0x00D13CFC File Offset: 0x00D11EFC
		public bool CheckBeyondGrid(double x, double y)
		{
			double gridMinX = this.GameData.GridMinX;
			double gridMaxX = this.GameData.GridMaxX;
			double gridMinY = this.GameData.GridMinY;
			double gridMaxY = this.GameData.GridMaxY;
			return x < gridMinX || x > gridMaxX || y < gridMinY || y > gridMaxY;
		}

		// Token: 0x06034474 RID: 214132 RVA: 0x00D13D4B File Offset: 0x00D11F4B
		public void RegisterMinoTick(Mino mino)
		{
			if (!this.GameData.TickMinos.Contains(mino))
			{
				this.GameData.TickMinos.Add(mino);
			}
		}

		// Token: 0x06034475 RID: 214133 RVA: 0x00D13D71 File Offset: 0x00D11F71
		public void UnRegisterMinoTick(Mino mino)
		{
			this.GameData.TickMinos.Remove(mino);
		}

		// Token: 0x0401E29D RID: 123549
		public readonly bool EnableDebug;

		// Token: 0x0401E29E RID: 123550
		[Nullable(2)]
		public UStaticMesh BoxMeshCache;

		// Token: 0x0401E29F RID: 123551
		public readonly SlidingBlocksGameData GameData = new SlidingBlocksGameData();

		// Token: 0x0401E2A0 RID: 123552
		public SlidingBlocksDefine.EGameStage GameStage;
	}
}
