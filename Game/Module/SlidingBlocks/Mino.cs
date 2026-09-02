using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.SlidingBlocks
{
	// Token: 0x02004EF6 RID: 20214
	[NullableContext(1)]
	[Nullable(0)]
	public class Mino : IStaticVariableResetter
	{
		// Token: 0x060343D2 RID: 213970 RVA: 0x00D10BEB File Offset: 0x00D0EDEB
		static Mino()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(Mino.CreateStaticDefaultValue), new Action(Mino.ResetStaticDefaultValue));
		}

		// Token: 0x17008A06 RID: 35334
		// (get) Token: 0x060343D3 RID: 213971 RVA: 0x00D10C0A File Offset: 0x00D0EE0A
		public string StyleName { get; }

		// Token: 0x17008A07 RID: 35335
		// (get) Token: 0x060343D4 RID: 213972 RVA: 0x00D10C12 File Offset: 0x00D0EE12
		// (set) Token: 0x060343D5 RID: 213973 RVA: 0x00D10C1A File Offset: 0x00D0EE1A
		public Vector2D Coord { get; set; }

		// Token: 0x17008A08 RID: 35336
		// (get) Token: 0x060343D6 RID: 213974 RVA: 0x00D10C23 File Offset: 0x00D0EE23
		// (set) Token: 0x060343D7 RID: 213975 RVA: 0x00D10C2B File Offset: 0x00D0EE2B
		public AActor CubeActor { get; set; }

		// Token: 0x060343D8 RID: 213976 RVA: 0x00D10C34 File Offset: 0x00D0EE34
		public Mino(string styleName, Vector2D coord, AActor cubeActor, SlidingBlocksDefine.EMinoParent parent)
		{
			this.StyleName = styleName;
			this.Coord = coord;
			this.CubeActor = cubeActor;
			this.Id = Mino._minoIndex;
			Mino._minoIndex++;
		}

		// Token: 0x060343D9 RID: 213977 RVA: 0x00D10C8C File Offset: 0x00D0EE8C
		[NullableContext(0)]
		public UniTask<bool> TryFall(double targetY)
		{
			Mino.<TryFall>d__22 <TryFall>d__;
			<TryFall>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TryFall>d__.<>4__this = this;
			<TryFall>d__.targetY = targetY;
			<TryFall>d__.<>1__state = -1;
			<TryFall>d__.<>t__builder.Start<Mino.<TryFall>d__22>(ref <TryFall>d__);
			return <TryFall>d__.<>t__builder.Task;
		}

		// Token: 0x060343DA RID: 213978 RVA: 0x00D10CD8 File Offset: 0x00D0EED8
		private void ResetMoveData()
		{
			this.StartFallingAnchorCoord.Set(this.Coord.X, this.Coord.Y);
			float num = ModelBase<SlidingBlocksModel>.Instance.GameData.SingleCellMoveTime();
			this.CurFallingTime = MathCommon.Clamp(this.CurFallingTime - num, 0f, num);
		}

		// Token: 0x060343DB RID: 213979 RVA: 0x00D10D2F File Offset: 0x00D0EF2F
		private void RegisterTick()
		{
			ModelBase<SlidingBlocksModel>.Instance.RegisterMinoTick(this);
		}

		// Token: 0x060343DC RID: 213980 RVA: 0x00D10D3C File Offset: 0x00D0EF3C
		private void UnRegisterTick()
		{
			ModelBase<SlidingBlocksModel>.Instance.UnRegisterMinoTick(this);
		}

		// Token: 0x060343DD RID: 213981 RVA: 0x00D10D4C File Offset: 0x00D0EF4C
		public void OnTick(float delta)
		{
			if (this.State != Mino.EMinoState.Moving)
			{
				return;
			}
			if (this.CheckSqueezePlayer(this.StartFallingAnchorCoord.X, this.StartFallingAnchorCoord.Y + 1.0))
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.SlidingBlockSqueezePlayer);
				return;
			}
			this.CurFallingTime += delta;
			float num = MathCommon.Clamp(this.CurFallingTime / ModelBase<SlidingBlocksModel>.Instance.GameData.SingleCellMoveTime(), 0f, 1f);
			float num2 = MathCommon.Lerp(0f, 1f, num);
			this.Coord.Y = this.StartFallingAnchorCoord.Y + (double)num2;
			this.UpdateMinoWorldLocation();
			if (num >= 1f)
			{
				this.ResetMoveData();
				if (!this.CheckCanMove(0, 1))
				{
					this.OnMoveFinished();
				}
			}
		}

		// Token: 0x060343DE RID: 213982 RVA: 0x00D10E20 File Offset: 0x00D0F020
		private bool CheckCanMove(int x, int y)
		{
			if (x == 0 && y == 0)
			{
				return false;
			}
			if (this.Coord.Y.Equals(this.MoveTargetY))
			{
				return false;
			}
			double x2 = this.Coord.X + (double)x;
			double y2 = this.Coord.Y + (double)y;
			return !ModelBase<SlidingBlocksModel>.Instance.CheckBeyondGrid(x2, y2);
		}

		// Token: 0x060343DF RID: 213983 RVA: 0x00D10E7E File Offset: 0x00D0F07E
		private void OnMoveFinished()
		{
			this.State = Mino.EMinoState.Static;
			this.CurFallingTime = 0f;
			this.UnRegisterTick();
			CustomPromise<bool> fallPromise = this.FallPromise;
			if (fallPromise == null)
			{
				return;
			}
			fallPromise.SetResult(true);
		}

		// Token: 0x060343E0 RID: 213984 RVA: 0x00D10EAC File Offset: 0x00D0F0AC
		private bool CheckSqueezePlayer(double minoNextCoordX, double minoNextCoordY)
		{
			SlidingBlocksModel instance = ModelBase<SlidingBlocksModel>.Instance;
			if (!instance.CheckGridOccupiedUnderPlayer())
			{
				return false;
			}
			Vector2D playerCoord = instance.GameData.PlayerCoord;
			return playerCoord.X.Equals(minoNextCoordX) && playerCoord.Y.Equals(minoNextCoordY);
		}

		// Token: 0x060343E1 RID: 213985 RVA: 0x00D10EF4 File Offset: 0x00D0F0F4
		private void UpdateMinoWorldLocation()
		{
			AActor cubeActor = this.CubeActor;
			if (cubeActor == null || !cubeActor.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SlidingBlocks;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "更新Cube坐标失败：CubeActor不存在";
				string item = "coordinate";
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<double>(this.Coord.X);
				defaultInterpolatedStringHandler.AppendLiteral(",");
				defaultInterpolatedStringHandler.AppendFormatted<double>(this.Coord.Y);
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, defaultInterpolatedStringHandler.ToStringAndClear());
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			Transform originTransform = ModelBase<SlidingBlocksModel>.Instance.GameData.OriginTransform;
			SlidingBlocksUtil.GetWorldLocationByCoord(this.Coord.X, this.Coord.Y, originTransform, this.CacheVector);
			this.CubeActor.D_K2_SetActorLocation(this.CacheVector.ToUeVector(false), true, ref WorldGlobal.SweepHitResult, false);
		}

		// Token: 0x060343E2 RID: 213986 RVA: 0x00D10FD4 File Offset: 0x00D0F1D4
		public static void CreateStaticDefaultValue()
		{
			Mino._minoIndex = 0;
		}

		// Token: 0x060343E3 RID: 213987 RVA: 0x00D10FDC File Offset: 0x00D0F1DC
		public static void ResetStaticDefaultValue()
		{
			Mino._minoIndex = 0;
		}

		// Token: 0x0401E24C RID: 123468
		private static int _minoIndex;

		// Token: 0x0401E24D RID: 123469
		public readonly int Id;

		// Token: 0x0401E24E RID: 123470
		public Mino.EMinoState State;

		// Token: 0x0401E24F RID: 123471
		private readonly Vector2D StartFallingAnchorCoord = Vector2D.Create();

		// Token: 0x0401E250 RID: 123472
		private float CurFallingTime;

		// Token: 0x0401E251 RID: 123473
		private double MoveTargetY;

		// Token: 0x0401E252 RID: 123474
		[Nullable(2)]
		private CustomPromise<bool> FallPromise;

		// Token: 0x0401E253 RID: 123475
		private readonly Vector CacheVector = Vector.Create();

		// Token: 0x0200AEF3 RID: 44787
		[NullableContext(0)]
		public enum EMinoState
		{
			// Token: 0x040364D8 RID: 222424
			Static,
			// Token: 0x040364D9 RID: 222425
			Moving
		}
	}
}
