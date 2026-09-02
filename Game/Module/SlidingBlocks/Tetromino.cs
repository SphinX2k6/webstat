using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Data.Gameplay.Tetris;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.SlidingBlocks
{
	// Token: 0x02004F06 RID: 20230
	[NullableContext(1)]
	[Nullable(0)]
	public class Tetromino
	{
		// Token: 0x17008A1C RID: 35356
		// (get) Token: 0x0603449B RID: 214171 RVA: 0x00D1480C File Offset: 0x00D12A0C
		public Dictionary<string, Mino> MinoDataMap { get; } = new Dictionary<string, Mino>();

		// Token: 0x17008A1D RID: 35357
		// (get) Token: 0x0603449C RID: 214172 RVA: 0x00D14814 File Offset: 0x00D12A14
		public Transform OriginTransform
		{
			get
			{
				return ModelBase<SlidingBlocksModel>.Instance.GameData.OriginTransform;
			}
		}

		// Token: 0x17008A1E RID: 35358
		// (get) Token: 0x0603449D RID: 214173 RVA: 0x00D14825 File Offset: 0x00D12A25
		// (set) Token: 0x0603449E RID: 214174 RVA: 0x00D1482D File Offset: 0x00D12A2D
		public float RemainAimTime { get; private set; }

		// Token: 0x17008A1F RID: 35359
		// (get) Token: 0x0603449F RID: 214175 RVA: 0x00D14836 File Offset: 0x00D12A36
		// (set) Token: 0x060344A0 RID: 214176 RVA: 0x00D1483E File Offset: 0x00D12A3E
		public SlidingBlocksDefine.ETetrominoRotateState RotateState { get; private set; }

		// Token: 0x17008A20 RID: 35360
		// (get) Token: 0x060344A1 RID: 214177 RVA: 0x00D14847 File Offset: 0x00D12A47
		// (set) Token: 0x060344A2 RID: 214178 RVA: 0x00D1484F File Offset: 0x00D12A4F
		[Nullable(2)]
		public Mino GeometricCenterMino { [NullableContext(2)] get; [NullableContext(2)] private set; }

		// Token: 0x060344A3 RID: 214179 RVA: 0x00D14858 File Offset: 0x00D12A58
		public Tetromino(SlidingBlocksDefine.ETetrominoType tetrominoType, SlidingBlocksDefine.ETetrominoBorad boardType, SlidingBlocksDefine.ETetrominoRotateState initRotateState, float initFallSpeed, float fallAcceleration, ETetrominoState initState, float prepareTime)
		{
			this.TetrominoType = tetrominoType;
			this.BoardType = boardType;
			this.InitRotateState = initRotateState;
			this.InitFallSpeed = initFallSpeed;
			this.FallAcceleration = fallAcceleration;
			this.InitState = initState;
			this.RemainAimTime = prepareTime * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			this.CurFallSpeed = (double)this.InitFallSpeed;
		}

		// Token: 0x060344A4 RID: 214180 RVA: 0x00D14914 File Offset: 0x00D12B14
		public void Clear()
		{
			foreach (Mino mino in this.MinoDataMap.Values)
			{
				SlidingBlocksUtil.DestroyCube(mino.CubeActor);
			}
			this.MinoDataMap.Clear();
			this.GeometricCenterMino = null;
		}

		// Token: 0x060344A5 RID: 214181 RVA: 0x00D14984 File Offset: 0x00D12B84
		public void Init(ITetrisBoard boardConfig, double geometricMinoX, double? geometricMinoY = null)
		{
			this.InitAnchorLocalCoordinate();
			this.InitGeometricConfigCoord();
			this.InitAnchorCoordinate(geometricMinoX, geometricMinoY);
			SlidingBlocksUtil.FillMinoMapByGridConfig(boardConfig.Grids, boardConfig.BoardSize.X, new Action<string, double, double>(this.AddMino));
			while (this.RotateState != this.InitRotateState)
			{
				this.Rotate(false);
			}
			this.KickWall(null, null);
			this.CreateAndPlaySpawnEffect().Forget();
			foreach (KeyValuePair<string, Mino> keyValuePair in this.MinoDataMap)
			{
				keyValuePair.Value.CubeActor.SetActorHiddenInGame(false);
			}
			this.State = this.InitState;
		}

		// Token: 0x060344A6 RID: 214182 RVA: 0x00D14A60 File Offset: 0x00D12C60
		private void InitAnchorLocalCoordinate()
		{
			switch (this.BoardType)
			{
			case SlidingBlocksDefine.ETetrominoBorad.二乘二:
				this.AnchorLocalCoord.Set(1.0, 1.0);
				return;
			case SlidingBlocksDefine.ETetrominoBorad.三乘三:
				this.AnchorLocalCoord.Set(1.5, 1.5);
				return;
			case SlidingBlocksDefine.ETetrominoBorad.四乘四:
				this.AnchorLocalCoord.Set(2.0, 2.0);
				return;
			case SlidingBlocksDefine.ETetrominoBorad.五乘五:
				this.AnchorLocalCoord.Set(2.5, 2.5);
				return;
			default:
				return;
			}
		}

		// Token: 0x060344A7 RID: 214183 RVA: 0x00D14B04 File Offset: 0x00D12D04
		private void InitGeometricConfigCoord()
		{
			switch (this.BoardType)
			{
			case SlidingBlocksDefine.ETetrominoBorad.二乘二:
				this.GeometricConfigCoord.Set(0.0, 1.0);
				break;
			case SlidingBlocksDefine.ETetrominoBorad.三乘三:
				this.GeometricConfigCoord.Set(1.0, 1.0);
				break;
			case SlidingBlocksDefine.ETetrominoBorad.四乘四:
				this.GeometricConfigCoord.Set(1.0, 1.0);
				break;
			case SlidingBlocksDefine.ETetrominoBorad.五乘五:
				this.GeometricConfigCoord.Set(2.0, 2.0);
				break;
			}
			if (this.TetrominoType == SlidingBlocksDefine.ETetrominoType.五连V块)
			{
				this.GeometricConfigCoord.Set(0.0, 2.0);
			}
			this.GeometricConfigCoord.X = SlidingBlocksUtil.ConvertConfigCoordToSmooth(this.GeometricConfigCoord.X);
			this.GeometricConfigCoord.Y = SlidingBlocksUtil.ConvertConfigCoordToSmooth(this.GeometricConfigCoord.Y);
		}

		// Token: 0x060344A8 RID: 214184 RVA: 0x00D14C0C File Offset: 0x00D12E0C
		private void InitAnchorCoordinate(double geometricMinoX, double? geometricMinoY = null)
		{
			switch (this.BoardType)
			{
			case SlidingBlocksDefine.ETetrominoBorad.二乘二:
				this.AnchorCoord.Set(Math.Ceiling(geometricMinoX), (geometricMinoY != null) ? Math.Ceiling(geometricMinoY.Value) : -1.0);
				return;
			case SlidingBlocksDefine.ETetrominoBorad.三乘三:
				this.AnchorCoord.Set(geometricMinoX, geometricMinoY.GetValueOrDefault(-0.5));
				return;
			case SlidingBlocksDefine.ETetrominoBorad.四乘四:
				this.AnchorCoord.Set(Math.Ceiling(geometricMinoX), (geometricMinoY != null) ? Math.Ceiling(geometricMinoY.Value) : 0.0);
				return;
			case SlidingBlocksDefine.ETetrominoBorad.五乘五:
				this.AnchorCoord.Set(geometricMinoX, geometricMinoY.GetValueOrDefault(-0.5));
				return;
			default:
				return;
			}
		}

		// Token: 0x060344A9 RID: 214185 RVA: 0x00D14CD8 File Offset: 0x00D12ED8
		private UniTask CreateAndPlaySpawnEffect()
		{
			Tetromino.<CreateAndPlaySpawnEffect>d__41 <CreateAndPlaySpawnEffect>d__;
			<CreateAndPlaySpawnEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateAndPlaySpawnEffect>d__.<>4__this = this;
			<CreateAndPlaySpawnEffect>d__.<>1__state = -1;
			<CreateAndPlaySpawnEffect>d__.<>t__builder.Start<Tetromino.<CreateAndPlaySpawnEffect>d__41>(ref <CreateAndPlaySpawnEffect>d__);
			return <CreateAndPlaySpawnEffect>d__.<>t__builder.Task;
		}

		// Token: 0x060344AA RID: 214186 RVA: 0x00D14D1C File Offset: 0x00D12F1C
		private void CreateTrailEffect()
		{
			string moveTrailEffectPath = SlidingBlocksGlobal.GetMoveTrailEffectPath(ModelBase<SlidingBlocksModel>.Instance.GameData.PlayMode);
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			UObject world = GlobalData.World;
			FTransformDouble? ftransformDouble = new FTransformDouble?(this.OriginTransform.ToUeTransform());
			this.MoveTrailEffectHandle = instance.SpawnEffect(world, ftransformDouble, moveTrailEffectPath, "Tetromino.Init", null, EEffectType.Scene, null, null, null, false, false);
			Singleton<EffectSystem>.Instance.RegisterCustomCheckOwnerFunc(this.MoveTrailEffectHandle, (int _) => this.State >= ETetrominoState.PlayLockEffect);
		}

		// Token: 0x060344AB RID: 214187 RVA: 0x00D14D90 File Offset: 0x00D12F90
		private unsafe void AddMino(string styleName, double x, double y)
		{
			double num = x - this.AnchorLocalCoord.X;
			double num2 = y - this.AnchorLocalCoord.Y;
			SlidingBlocksModel instance = ModelBase<SlidingBlocksModel>.Instance;
			this.GetMinoCoordInGrid(num, num2, this.CacheVector2D, null, null);
			AActor aactor = SlidingBlocksUtil.CreateDynamicCube(styleName, this.CacheVector2D.X, this.CacheVector2D.Y, this.OriginTransform, instance.BoxMeshCache);
			if (aactor == null || !aactor.IsValid())
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SlidingBlocks;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "Tetromino.AddMino：创建cubeActor失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("styleName", styleName);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
				string item = "coord";
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
				defaultInterpolatedStringHandler.AppendLiteral("(");
				defaultInterpolatedStringHandler.AppendFormatted<double>(num);
				defaultInterpolatedStringHandler.AppendLiteral(",");
				defaultInterpolatedStringHandler.AppendFormatted<double>(num2);
				defaultInterpolatedStringHandler.AppendLiteral(")");
				ptr = new ValueTuple<string, object>(item, defaultInterpolatedStringHandler.ToStringAndClear());
				instance2.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			aactor.SetActorHiddenInGame(true);
			Mino mino = new Mino(styleName, Vector2D.Create(num, num2), aactor, SlidingBlocksDefine.EMinoParent.Tetromino);
			this.MinoDataMap.Add(SlidingBlocksUtil.GetCoordKey(num, num2), mino);
			if (this.GeometricConfigCoord.X == x && this.GeometricConfigCoord.Y == y)
			{
				this.GeometricCenterMino = mino;
			}
		}

		// Token: 0x060344AC RID: 214188 RVA: 0x00D14F08 File Offset: 0x00D13108
		public void OnTick(float delta, SlidingBlocksGameData gameData)
		{
			this.UpdateByState(delta, gameData);
		}

		// Token: 0x060344AD RID: 214189 RVA: 0x00D14F14 File Offset: 0x00D13114
		private void UpdateByState(float delta, SlidingBlocksGameData gameData)
		{
			switch (this.State)
			{
			case ETetrominoState.Init:
			case ETetrominoState.WaitFallingEvent:
			case ETetrominoState.Lock:
				break;
			case ETetrominoState.Aiming:
				this.UpdateAiming(delta, gameData);
				return;
			case ETetrominoState.InitFallData:
				gameData.Score += Math.Floor((double)this.RemainAimTime * Singleton<TimeUtil>.Instance.Millisecond);
				this.InitFallData(this.AnchorCoord.Y + 1.0);
				SlidingBlocksController.OpenAudio(gameData.AudioData.TetrominoStartFallAudio);
				return;
			case ETetrominoState.Falling:
				this.UpdateFalling(delta, gameData);
				return;
			case ETetrominoState.PlayLockEffect:
				this.OnFallingFinished(gameData).Forget();
				break;
			default:
				return;
			}
		}

		// Token: 0x060344AE RID: 214190 RVA: 0x00D14FBB File Offset: 0x00D131BB
		private void UpdateAiming(float delta, SlidingBlocksGameData gameData)
		{
			this.UpdateCoordByPlayer(gameData);
			if (gameData.IsProcessLineClear)
			{
				return;
			}
			this.RemainAimTime -= delta;
			if (this.RemainAimTime > 0f)
			{
				return;
			}
			this.RemainAimTime = 0f;
			this.SetState(ETetrominoState.InitFallData);
		}

		// Token: 0x060344AF RID: 214191 RVA: 0x00D14FFC File Offset: 0x00D131FC
		private void UpdateCoordByPlayer(SlidingBlocksGameData gameData)
		{
			double num = SlidingBlocksUtil.StandardSmoothCoordToCellCenter(gameData.PlayerCoord.X);
			Mino geometricCenterMino = this.GeometricCenterMino;
			Vector2D vector2D = (geometricCenterMino != null) ? geometricCenterMino.Coord : null;
			if (vector2D != null)
			{
				this.GetMinoCoordInGrid(vector2D.X, vector2D.Y, this.CacheVector2D, null, null);
			}
			double num2 = num - this.CacheVector2D.X;
			double value = this.AnchorCoord.X + num2;
			this.CalculateKickWallMoveOffset(this.CacheVector2D, new double?(value), new double?(this.AnchorCoord.Y));
			if (this.MoveByStep(num2 + this.CacheVector2D.X, this.CacheVector2D.Y))
			{
				SlidingBlocksController.OpenAudio(gameData.AudioData.RotateAudio);
			}
		}

		// Token: 0x060344B0 RID: 214192 RVA: 0x00D150C7 File Offset: 0x00D132C7
		public void SkipAimingStage()
		{
			this.SetState(ETetrominoState.InitFallData);
		}

		// Token: 0x060344B1 RID: 214193 RVA: 0x00D150D0 File Offset: 0x00D132D0
		private bool InitFallData(double nextStep)
		{
			if (this.CheckCanMove(this.AnchorCoord.X, nextStep) != SlidingBlocksDefine.ECheckCanMoveResult.None)
			{
				this.SetState(ETetrominoState.PlayLockEffect);
				return false;
			}
			this.AnchorFallingTargetCoordY = nextStep;
			this.SetState(ETetrominoState.Falling);
			return true;
		}

		// Token: 0x060344B2 RID: 214194 RVA: 0x00D15100 File Offset: 0x00D13300
		private void UpdateFalling(float delta, SlidingBlocksGameData gameData)
		{
			double num = MathCommon.Clamp(this.UpdateFallSpeed(delta) * (double)delta * Singleton<TimeUtil>.Instance.Millisecond, 0.0, 1.0);
			double num2 = this.AnchorCoord.Y + num;
			if (num2 < this.AnchorFallingTargetCoordY)
			{
				if (this.CheckSqueezePlayer(gameData.PlayerCoord, this.AnchorCoord.X, this.AnchorFallingTargetCoordY))
				{
					Singleton<EventSystem>.Instance.Emit(EEventName.SlidingBlockSqueezePlayer);
				}
				this.AnchorCoord.Y = num2;
			}
			else
			{
				double anchorFallingTargetCoordY = this.AnchorFallingTargetCoordY;
				this.AnchorCoord.Y = ((!this.InitFallData(this.AnchorFallingTargetCoordY + 1.0)) ? anchorFallingTargetCoordY : num2);
			}
			this.UpdateTetrominoWorldLocation();
			this.UpdateTrailEffectPosition();
			if (this.State == ETetrominoState.PlayLockEffect)
			{
				this.UpdateByState(delta, gameData);
			}
		}

		// Token: 0x060344B3 RID: 214195 RVA: 0x00D151DC File Offset: 0x00D133DC
		private void UpdateTrailEffectPosition()
		{
			OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(this.MoveTrailEffectHandle);
			if (!effectActor.IsValid())
			{
				return;
			}
			SlidingBlocksUtil.GetWorldLocationByCoord(this.AnchorCoord.X, this.AnchorCoord.Y, this.OriginTransform, this.CacheVector);
			OneOf<KuroEffectActorHandle, AActor> self = effectActor;
			FVectorDouble fvectorDouble = this.CacheVector.ToUeVector(false);
			self.D_K2_SetActorLocation(fvectorDouble, false, ref WorldGlobal.SweepHitResult, false);
		}

		// Token: 0x060344B4 RID: 214196 RVA: 0x00D15248 File Offset: 0x00D13448
		private double UpdateFallSpeed(float delta)
		{
			if (this.FallAcceleration == 0f)
			{
				return (double)this.InitFallSpeed;
			}
			this.CurFallSpeed += (double)(delta * this.FallAcceleration) * Singleton<TimeUtil>.Instance.Millisecond;
			return this.CurFallSpeed;
		}

		// Token: 0x060344B5 RID: 214197 RVA: 0x00D15288 File Offset: 0x00D13488
		private UniTask OnFallingFinished(SlidingBlocksGameData gameData)
		{
			Tetromino.<OnFallingFinished>d__53 <OnFallingFinished>d__;
			<OnFallingFinished>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnFallingFinished>d__.<>4__this = this;
			<OnFallingFinished>d__.gameData = gameData;
			<OnFallingFinished>d__.<>1__state = -1;
			<OnFallingFinished>d__.<>t__builder.Start<Tetromino.<OnFallingFinished>d__53>(ref <OnFallingFinished>d__);
			return <OnFallingFinished>d__.<>t__builder.Task;
		}

		// Token: 0x060344B6 RID: 214198 RVA: 0x00D152D4 File Offset: 0x00D134D4
		private static UniTask CheckAndSpawnLockEffect(SlidingBlocksGameData gameData, double x, double y)
		{
			Tetromino.<CheckAndSpawnLockEffect>d__54 <CheckAndSpawnLockEffect>d__;
			<CheckAndSpawnLockEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CheckAndSpawnLockEffect>d__.gameData = gameData;
			<CheckAndSpawnLockEffect>d__.x = x;
			<CheckAndSpawnLockEffect>d__.y = y;
			<CheckAndSpawnLockEffect>d__.<>1__state = -1;
			<CheckAndSpawnLockEffect>d__.<>t__builder.Start<Tetromino.<CheckAndSpawnLockEffect>d__54>(ref <CheckAndSpawnLockEffect>d__);
			return <CheckAndSpawnLockEffect>d__.<>t__builder.Task;
		}

		// Token: 0x060344B7 RID: 214199 RVA: 0x00D15327 File Offset: 0x00D13527
		private bool MoveByStep(double x, double y)
		{
			if (!this.CheckCanMoveByMoveStep(x, y))
			{
				return false;
			}
			this.AnchorCoord.X += x;
			this.AnchorCoord.Y += y;
			this.UpdateTetrominoWorldLocation();
			return true;
		}

		// Token: 0x060344B8 RID: 214200 RVA: 0x00D15362 File Offset: 0x00D13562
		private bool CheckCanMoveByMoveStep(double x, double y)
		{
			return (x != 0.0 || y != 0.0) && this.CheckCanMove(this.AnchorCoord.X + x, this.AnchorCoord.Y + y) == SlidingBlocksDefine.ECheckCanMoveResult.None;
		}

		// Token: 0x060344B9 RID: 214201 RVA: 0x00D153A4 File Offset: 0x00D135A4
		private SlidingBlocksDefine.ECheckCanMoveResult CheckCanMove(double anchorCoordX, double anchorCoordY)
		{
			SlidingBlocksModel instance = ModelBase<SlidingBlocksModel>.Instance;
			foreach (Mino mino in this.MinoDataMap.Values)
			{
				this.GetMinoCoordInGrid(mino.Coord.X, mino.Coord.Y, this.TempMinoCoord, new double?(anchorCoordX), new double?(anchorCoordY));
				if (instance.CheckBeyondGrid(this.TempMinoCoord.X, this.TempMinoCoord.Y))
				{
					return SlidingBlocksDefine.ECheckCanMoveResult.BeyondGrid;
				}
				if (instance.CheckGridOccupied(this.TempMinoCoord.X, this.TempMinoCoord.Y))
				{
					return SlidingBlocksDefine.ECheckCanMoveResult.Occupation;
				}
			}
			return SlidingBlocksDefine.ECheckCanMoveResult.None;
		}

		// Token: 0x060344BA RID: 214202 RVA: 0x00D15474 File Offset: 0x00D13674
		private void UpdateTetrominoWorldLocation()
		{
			foreach (Mino mino in this.MinoDataMap.Values)
			{
				this.GetMinoCoordInGrid(mino.Coord.X, mino.Coord.Y, this.TempMinoCoord, null, null);
				this.UpdateMinoWorldLocation(mino, this.TempMinoCoord.X, this.TempMinoCoord.Y);
			}
		}

		// Token: 0x060344BB RID: 214203 RVA: 0x00D15518 File Offset: 0x00D13718
		private bool CheckSqueezePlayer(Vector2D playerCoord, double nextStepAnchorCoordX, double nextStepAnchorCoordY)
		{
			Mino nextStepOverlapPlayerMino = this.GetNextStepOverlapPlayerMino(playerCoord, nextStepAnchorCoordX, nextStepAnchorCoordY);
			if (ModelBase<SlidingBlocksModel>.Instance.CheckGridOccupiedUnderPlayer())
			{
				return nextStepOverlapPlayerMino != null;
			}
			if (nextStepOverlapPlayerMino == null)
			{
				return false;
			}
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			object obj;
			if (getCurrentEntity == null)
			{
				obj = null;
			}
			else
			{
				WorldEntity entity = getCurrentEntity.Entity;
				obj = ((entity != null) ? entity.GetComponent(typeof(CharacterClimbComponent)) : null);
			}
			CharacterClimbComponent characterClimbComponent = obj as CharacterClimbComponent;
			if (characterClimbComponent == null)
			{
				return false;
			}
			CSharpScript.Game.NewWorld.Character.Common.Component.Move.SClimbState tsClimbState = characterClimbComponent.GetTsClimbState();
			EClimbState eclimbState = (tsClimbState != null) ? tsClimbState.攀爬状态 : EClimbState.无;
			if (eclimbState != EClimbState.攀爬中 && eclimbState != EClimbState.进入攀爬)
			{
				return false;
			}
			characterClimbComponent.ClimbPress(false);
			return false;
		}

		// Token: 0x060344BC RID: 214204 RVA: 0x00D155A4 File Offset: 0x00D137A4
		[return: Nullable(2)]
		private Mino GetNextStepOverlapPlayerMino(Vector2D playerCoord, double nextStepAnchorCoordX, double nextStepAnchorCoordY)
		{
			foreach (Mino mino in from kv in this.MinoDataMap
			select kv.Value)
			{
				this.GetMinoCoordInGrid(mino.Coord.X, mino.Coord.Y, this.TempMinoCoord, new double?(nextStepAnchorCoordX), new double?(nextStepAnchorCoordY));
				this.TempMinoCoord.Set(this.TempMinoCoord.X, this.TempMinoCoord.Y);
				if (playerCoord.Equals(this.TempMinoCoord, 9.999999747378752E-05))
				{
					return mino;
				}
			}
			return null;
		}

		// Token: 0x060344BD RID: 214205 RVA: 0x00D1567C File Offset: 0x00D1387C
		public bool Rotate(bool bKickWall = true)
		{
			bool flag = this.CheckCanRotate();
			if (flag)
			{
				this.TempMinoDataMap.Clear();
				foreach (Mino mino in this.MinoDataMap.Values)
				{
					this.GetMinoAfterRotateOffset(mino, this.TempMinoCoord);
					mino.Coord.Set(this.TempMinoCoord.X, this.TempMinoCoord.Y);
					string coordKey = SlidingBlocksUtil.GetCoordKey(this.TempMinoCoord.X, this.TempMinoCoord.Y);
					this.TempMinoDataMap[coordKey] = mino;
				}
				this.MinoDataMap.Clear();
				foreach (KeyValuePair<string, Mino> keyValuePair in this.TempMinoDataMap)
				{
					string text;
					Mino mino2;
					keyValuePair.Deconstruct(out text, out mino2);
					string key = text;
					Mino mino3 = mino2;
					this.MinoDataMap.Add(key, mino3);
					this.GetMinoCoordInGrid(mino3.Coord.X, mino3.Coord.Y, this.TempMinoCoord, null, null);
				}
				if (bKickWall)
				{
					this.KickWall(null, null);
				}
				this.UpdateTetrominoWorldLocation();
			}
			this.RotateState = (this.RotateState + 1) % (SlidingBlocksDefine.ETetrominoRotateState)4;
			return flag;
		}

		// Token: 0x060344BE RID: 214206 RVA: 0x00D15814 File Offset: 0x00D13A14
		private bool CheckCanRotate()
		{
			return this.TetrominoType != SlidingBlocksDefine.ETetrominoType.O块;
		}

		// Token: 0x060344BF RID: 214207 RVA: 0x00D15824 File Offset: 0x00D13A24
		public void GetMinoAfterRotateOffset(Mino minoData, Vector2D @out)
		{
			if (this.TetrominoType == SlidingBlocksDefine.ETetrominoType.I块)
			{
				this.GetOffsetBeforeRotateForI(this.CacheVector2D);
				double localCoordX = minoData.Coord.X - this.CacheVector2D.X;
				double localCoordY = minoData.Coord.Y - this.CacheVector2D.Y;
				Tetromino.RotateWithLocalCoord(localCoordX, localCoordY, @out, true);
				Tetromino.RotateWithLocalCoord(this.CacheVector2D.X, this.CacheVector2D.Y, this.CacheVector2D, true);
				@out.AdditionEqual(this.CacheVector2D);
				return;
			}
			Tetromino.RotateWithLocalCoord(minoData.Coord.X, minoData.Coord.Y, @out, true);
		}

		// Token: 0x060344C0 RID: 214208 RVA: 0x00D158CC File Offset: 0x00D13ACC
		private void GetOffsetBeforeRotateForI(Vector2D outVec)
		{
			switch (this.RotateState)
			{
			case SlidingBlocksDefine.ETetrominoRotateState.角度0:
				outVec.Set(0.0, 0.5);
				return;
			case SlidingBlocksDefine.ETetrominoRotateState.角度90:
				outVec.Set(-0.5, 0.0);
				return;
			case SlidingBlocksDefine.ETetrominoRotateState.角度180:
				outVec.Set(0.0, -0.5);
				return;
			case SlidingBlocksDefine.ETetrominoRotateState.角度270:
				outVec.Set(0.5, 0.0);
				return;
			default:
				return;
			}
		}

		// Token: 0x060344C1 RID: 214209 RVA: 0x00D1595A File Offset: 0x00D13B5A
		private static void RotateWithLocalCoord(double localCoordX, double localCoordY, Vector2D outVec, bool bClockwise = true)
		{
			if (bClockwise)
			{
				outVec.Set(-localCoordY, localCoordX);
				return;
			}
			outVec.Set(localCoordY, -localCoordX);
		}

		// Token: 0x060344C2 RID: 214210 RVA: 0x00D15974 File Offset: 0x00D13B74
		private void CalculateKickWallMoveOffset(Vector2D @out, double? anchorCoordX = null, double? anchorCoordY = null)
		{
			Bp_Tetris_C setting = SlidingBlocksGlobal.Setting;
			SlidingBlocksGameData gameData = ModelBase<SlidingBlocksModel>.Instance.GameData;
			double gridMinX = gameData.GridMinX;
			double gridMaxX = gameData.GridMaxX;
			double num = gameData.GridMinY;
			double num2 = (double)setting.PrepareAreaMaxY - 0.5;
			bool flag = gameData.PlayMode == ETetrisPlayMode.MainLine;
			if (flag)
			{
				num = 0.5;
				num2 = gameData.GridSize.Y - 0.5;
			}
			double num3 = 0.0;
			double num4 = 0.0;
			foreach (KeyValuePair<string, Mino> keyValuePair in this.MinoDataMap)
			{
				string text;
				Mino mino;
				keyValuePair.Deconstruct(out text, out mino);
				Mino mino2 = mino;
				this.GetMinoCoordInGrid(mino2.Coord.X, mino2.Coord.Y, this.TempMinoCoord, anchorCoordX, anchorCoordY);
				double num5 = 0.0;
				if (this.TempMinoCoord.X < gridMinX)
				{
					num5 = gridMinX - this.TempMinoCoord.X;
				}
				else if (this.TempMinoCoord.X > gridMaxX)
				{
					num5 = gridMaxX - this.TempMinoCoord.X;
				}
				if (Math.Abs(num5) > Math.Abs(num3))
				{
					num3 = num5;
				}
				double num6 = 0.0;
				if (this.TempMinoCoord.Y < num)
				{
					num6 = num - this.TempMinoCoord.Y;
				}
				else if (this.TempMinoCoord.Y > num2)
				{
					num6 = num2 - this.TempMinoCoord.Y;
				}
				if (Math.Abs(num6) > Math.Abs(num4))
				{
					num4 = num6;
				}
			}
			@out.Set(num3, num4);
			if (!flag)
			{
				double num7 = this.AttachBottom(anchorCoordX, anchorCoordY);
				@out.Y += num7;
			}
		}

		// Token: 0x060344C3 RID: 214211 RVA: 0x00D15B6C File Offset: 0x00D13D6C
		private double AttachBottom(double? anchorCoordX, double? anchorCoordY)
		{
			Bp_Tetris_C setting = SlidingBlocksGlobal.Setting;
			double num = (double)setting.PrepareAreaMinY + 0.5;
			foreach (KeyValuePair<string, Mino> keyValuePair in this.MinoDataMap)
			{
				string text;
				Mino mino;
				keyValuePair.Deconstruct(out text, out mino);
				Mino mino2 = mino;
				this.GetMinoCoordInGrid(mino2.Coord.X, mino2.Coord.Y, this.TempMinoCoord, anchorCoordX, anchorCoordY);
				if (this.TempMinoCoord.Y > num)
				{
					num = this.TempMinoCoord.Y;
				}
			}
			double num2 = (double)setting.PrepareAreaMaxY - 0.5;
			if (num >= num2)
			{
				return 0.0;
			}
			return num2 - num;
		}

		// Token: 0x060344C4 RID: 214212 RVA: 0x00D15C44 File Offset: 0x00D13E44
		private bool KickWall(double? anchorCoordX = null, double? anchorCoordY = null)
		{
			this.CalculateKickWallMoveOffset(this.CacheVector2D, anchorCoordX, anchorCoordY);
			return this.MoveByStep(this.CacheVector2D.X, this.CacheVector2D.Y);
		}

		// Token: 0x060344C5 RID: 214213 RVA: 0x00D15C70 File Offset: 0x00D13E70
		public void GetMinoCoordInGrid(double minoLocalCoordX, double minoLocalCoordY, Vector2D outVec, double? anchorCoordX = null, double? anchorCoordY = null)
		{
			double num = anchorCoordX ?? this.AnchorCoord.X;
			double num2 = anchorCoordY ?? this.AnchorCoord.Y;
			outVec.Set(num + minoLocalCoordX, num2 + minoLocalCoordY);
		}

		// Token: 0x060344C6 RID: 214214 RVA: 0x00D15CCB File Offset: 0x00D13ECB
		public void UpdateMinoWorldLocation(Mino minoData, double coordX, double coordY)
		{
			SlidingBlocksUtil.GetWorldLocationByCoord(coordX, coordY, this.OriginTransform, this.CacheVector);
			AActor cubeActor = minoData.CubeActor;
			if (cubeActor == null)
			{
				return;
			}
			cubeActor.D_K2_SetActorLocation(this.CacheVector.ToUeVector(false), true, ref WorldGlobal.SweepHitResult, false);
		}

		// Token: 0x060344C7 RID: 214215 RVA: 0x00D15D05 File Offset: 0x00D13F05
		public ETetrominoState GetState()
		{
			return this.State;
		}

		// Token: 0x060344C8 RID: 214216 RVA: 0x00D15D0D File Offset: 0x00D13F0D
		public void SetState(ETetrominoState value)
		{
			this.State = value;
		}

		// Token: 0x0401E2B3 RID: 123571
		private ETetrominoState State;

		// Token: 0x0401E2B4 RID: 123572
		private SlidingBlocksDefine.ETetrominoBorad BoardType;

		// Token: 0x0401E2B6 RID: 123574
		public readonly Vector2D AnchorCoord = Vector2D.Create();

		// Token: 0x0401E2B7 RID: 123575
		public readonly Vector2D AnchorLocalCoord = Vector2D.Create();

		// Token: 0x0401E2B8 RID: 123576
		public readonly Vector2D GeometricConfigCoord = Vector2D.Create();

		// Token: 0x0401E2B9 RID: 123577
		private double AnchorFallingTargetCoordY;

		// Token: 0x0401E2BA RID: 123578
		private double CurFallSpeed;

		// Token: 0x0401E2BB RID: 123579
		private int MoveTrailEffectHandle;

		// Token: 0x0401E2BC RID: 123580
		private bool ExecutedFallFinished;

		// Token: 0x0401E2BD RID: 123581
		private readonly Vector2D TempMinoCoord = Vector2D.Create();

		// Token: 0x0401E2BE RID: 123582
		private readonly Dictionary<string, Mino> TempMinoDataMap = new Dictionary<string, Mino>();

		// Token: 0x0401E2BF RID: 123583
		private readonly Vector CacheVector = Vector.Create();

		// Token: 0x0401E2C0 RID: 123584
		private readonly Vector2D CacheVector2D = Vector2D.Create();

		// Token: 0x0401E2C4 RID: 123588
		public readonly SlidingBlocksDefine.ETetrominoType TetrominoType;

		// Token: 0x0401E2C5 RID: 123589
		private readonly SlidingBlocksDefine.ETetrominoRotateState InitRotateState;

		// Token: 0x0401E2C6 RID: 123590
		private readonly float InitFallSpeed;

		// Token: 0x0401E2C7 RID: 123591
		private readonly float FallAcceleration;

		// Token: 0x0401E2C8 RID: 123592
		private readonly ETetrominoState InitState;
	}
}
