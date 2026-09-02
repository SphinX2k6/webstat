using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Plot.PlotView.PlotComponent
{
	// Token: 0x020053E1 RID: 21473
	public class PlotAvgCharacterMoveComponent
	{
		// Token: 0x06036D39 RID: 224569 RVA: 0x00DE7B5C File Offset: 0x00DE5D5C
		public UniTask<bool> PlayCharacterMoveAsync([Nullable(1)] IPlotAvgMoveComponentPlayContext context)
		{
			PlotAvgCharacterMoveComponent.<PlayCharacterMoveAsync>d__7 <PlayCharacterMoveAsync>d__;
			<PlayCharacterMoveAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PlayCharacterMoveAsync>d__.<>4__this = this;
			<PlayCharacterMoveAsync>d__.context = context;
			<PlayCharacterMoveAsync>d__.<>1__state = -1;
			<PlayCharacterMoveAsync>d__.<>t__builder.Start<PlotAvgCharacterMoveComponent.<PlayCharacterMoveAsync>d__7>(ref <PlayCharacterMoveAsync>d__);
			return <PlayCharacterMoveAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036D3A RID: 224570 RVA: 0x00DE7BA7 File Offset: 0x00DE5DA7
		public void StopCharacterMove()
		{
			this.ResetMove(false);
			this.Tweener.KillTween();
		}

		// Token: 0x06036D3B RID: 224571 RVA: 0x00DE7BBB File Offset: 0x00DE5DBB
		private void OnValueUpdate(float value)
		{
			IPlotAvgCharacterMove movingCharacter = this.MovingCharacter;
			if (movingCharacter == null)
			{
				return;
			}
			movingCharacter.SetPosition(value);
		}

		// Token: 0x06036D3C RID: 224572 RVA: 0x00DE7BCE File Offset: 0x00DE5DCE
		private void OnMoveComplete()
		{
			this.ResetMove(true);
		}

		// Token: 0x06036D3D RID: 224573 RVA: 0x00DE7BD8 File Offset: 0x00DE5DD8
		private void ResetMove(bool bComplete)
		{
			this.IsMoving = false;
			this.MovingCharacter = null;
			this.MoveDuration = 0f;
			this.MoveStartPosition = 0f;
			this.MoveEndPosition = 0f;
			this.Tweener.KillTween();
			CustomPromise<bool> movingPromise = this.MovingPromise;
			if (movingPromise != null)
			{
				movingPromise.SetResult(bComplete);
			}
			this.MovingPromise = null;
		}

		// Token: 0x06036D3E RID: 224574 RVA: 0x00DE7C38 File Offset: 0x00DE5E38
		public void Clear()
		{
			this.ResetMove(false);
			this.Tweener.Destroy();
		}

		// Token: 0x06036D3F RID: 224575 RVA: 0x00DE7C4C File Offset: 0x00DE5E4C
		public bool GetIsMoving()
		{
			return this.IsMoving;
		}

		// Token: 0x0401F916 RID: 129302
		[Nullable(2)]
		private IPlotAvgCharacterMove MovingCharacter;

		// Token: 0x0401F917 RID: 129303
		private bool IsMoving;

		// Token: 0x0401F918 RID: 129304
		private float MoveDuration;

		// Token: 0x0401F919 RID: 129305
		private float MoveStartPosition;

		// Token: 0x0401F91A RID: 129306
		private float MoveEndPosition;

		// Token: 0x0401F91B RID: 129307
		[Nullable(1)]
		private readonly LguiFloatTween Tweener = new LguiFloatTween();

		// Token: 0x0401F91C RID: 129308
		[Nullable(2)]
		private CustomPromise<bool> MovingPromise;
	}
}
