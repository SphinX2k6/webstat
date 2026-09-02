using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.LevelGamePlay.Common;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.SlidingBlocks.View
{
	// Token: 0x02004F11 RID: 20241
	[NullableContext(1)]
	[Nullable(0)]
	public class PrepareCountDownItem : CommonMarkItem
	{
		// Token: 0x060344FE RID: 214270 RVA: 0x00D16E82 File Offset: 0x00D15082
		public PrepareCountDownItem(FVectorDouble targetPosition) : base(targetPosition, null)
		{
		}

		// Token: 0x060344FF RID: 214271 RVA: 0x00D16EB0 File Offset: 0x00D150B0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06034500 RID: 214272 RVA: 0x00D16EF8 File Offset: 0x00D150F8
		protected override void OnStart()
		{
			this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x06034501 RID: 214273 RVA: 0x00D16F0C File Offset: 0x00D1510C
		protected override UniTask OnShowAsyncImplementImplement()
		{
			PrepareCountDownItem.<OnShowAsyncImplementImplement>d__9 <OnShowAsyncImplementImplement>d__;
			<OnShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnShowAsyncImplementImplement>d__.<>4__this = this;
			<OnShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnShowAsyncImplementImplement>d__.<>t__builder.Start<PrepareCountDownItem.<OnShowAsyncImplementImplement>d__9>(ref <OnShowAsyncImplementImplement>d__);
			return <OnShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06034502 RID: 214274 RVA: 0x00D16F50 File Offset: 0x00D15150
		protected override UniTask OnHideAsyncImplementImplement()
		{
			PrepareCountDownItem.<OnHideAsyncImplementImplement>d__10 <OnHideAsyncImplementImplement>d__;
			<OnHideAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnHideAsyncImplementImplement>d__.<>4__this = this;
			<OnHideAsyncImplementImplement>d__.<>1__state = -1;
			<OnHideAsyncImplementImplement>d__.<>t__builder.Start<PrepareCountDownItem.<OnHideAsyncImplementImplement>d__10>(ref <OnHideAsyncImplementImplement>d__);
			return <OnHideAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06034503 RID: 214275 RVA: 0x00D16F94 File Offset: 0x00D15194
		public override void OnTick(float delta)
		{
			SlidingBlocksGameData gameData = ModelBase<SlidingBlocksModel>.Instance.GameData;
			Tetromino curTetromino = gameData.CurTetromino;
			if (curTetromino == null || curTetromino.GetState() != ETetrominoState.Aiming)
			{
				this.SetShowOrHide(false);
				return;
			}
			this.SetShowOrHide(true);
			double num = Math.Ceiling((double)curTetromino.RemainAimTime * Singleton<TimeUtil>.Instance.Millisecond);
			if (!num.Equals(this.LastSecond) && num <= 5.0)
			{
				LevelSequencePlayer sequencePlayer = this.SequencePlayer;
				if (((sequencePlayer != null) ? sequencePlayer.GetCurrentSequence() : null) == null)
				{
					CustomPromise<bool> stopPromise = new CustomPromise<bool>();
					LevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
					if (sequencePlayer2 != null)
					{
						sequencePlayer2.PlaySequenceAsync("Up", stopPromise, false, false, null, false).Forget();
					}
				}
			}
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.SetText(num.ToString(), true);
			}
			this.LastSecond = num;
			this.GetTargetCoord(curTetromino, this.TargetCoord);
			SlidingBlocksUtil.GetWorldLocationByCoord(this.TargetCoord.X, this.TargetCoord.Y, gameData.OriginTransform, this.TargetWorldLocation);
			this.TargetPosition.Set(this.TargetWorldLocation.X, this.TargetWorldLocation.Y, this.TargetWorldLocation.Z);
			base.OnTick(delta);
		}

		// Token: 0x06034504 RID: 214276 RVA: 0x00D170CD File Offset: 0x00D152CD
		protected override bool ClampToEllipse(Vector2D vector, bool inFront)
		{
			return true;
		}

		// Token: 0x06034505 RID: 214277 RVA: 0x00D170D0 File Offset: 0x00D152D0
		private void GetTargetCoord(Tetromino tetromino, Vector2D @out)
		{
			Mino geometricCenterMino = tetromino.GeometricCenterMino;
			if (geometricCenterMino == null)
			{
				return;
			}
			tetromino.GetMinoCoordInGrid(geometricCenterMino.Coord.X, geometricCenterMino.Coord.Y, @out, null, null);
			if (@out.Y > 2.0)
			{
				return;
			}
			foreach (KeyValuePair<string, Mino> keyValuePair in tetromino.MinoDataMap)
			{
				string text;
				Mino mino;
				keyValuePair.Deconstruct(out text, out mino);
				Mino mino2 = mino;
				tetromino.GetMinoCoordInGrid(mino2.Coord.X, mino2.Coord.Y, this.TempCoord, null, null);
				if (this.TempCoord.X.Equals(@out.X) && this.TempCoord.Y > @out.Y)
				{
					@out.Y = this.TempCoord.Y;
				}
			}
		}

		// Token: 0x06034506 RID: 214278 RVA: 0x00D171F0 File Offset: 0x00D153F0
		private void SetShowOrHide(bool bShow)
		{
			if (bShow)
			{
				if (base.IsShowOrShowing)
				{
					return;
				}
				base.Show(null);
				return;
			}
			else
			{
				if (base.IsHideOrHiding)
				{
					return;
				}
				base.Hide(null);
				return;
			}
		}

		// Token: 0x0401E2D4 RID: 123604
		private readonly Vector TargetWorldLocation = Vector.Create();

		// Token: 0x0401E2D5 RID: 123605
		private readonly Vector2D TargetCoord = Vector2D.Create();

		// Token: 0x0401E2D6 RID: 123606
		private readonly Vector2D TempCoord = Vector2D.Create();

		// Token: 0x0401E2D7 RID: 123607
		private double LastSecond;

		// Token: 0x0401E2D8 RID: 123608
		[Nullable(2)]
		private LevelSequencePlayer SequencePlayer;

		// Token: 0x0200AF41 RID: 44865
		[NullableContext(0)]
		private enum EViewComponent
		{
			// Token: 0x0403662D RID: 222765
			CountDownText
		}
	}
}
