using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Util
{
	// Token: 0x02004C5E RID: 19550
	[NullableContext(2)]
	[Nullable(0)]
	public class InTurnGridAppearAnimation : GridAppearAnimationBase
	{
		// Token: 0x06032F02 RID: 208642 RVA: 0x00CC2DA5 File Offset: 0x00CC0FA5
		public InTurnGridAppearAnimation(IGridPreserver gridPreserver) : base(gridPreserver)
		{
		}

		// Token: 0x06032F03 RID: 208643 RVA: 0x00CC2DB9 File Offset: 0x00CC0FB9
		protected override void OnStart()
		{
			if (!this.IsInGridAppearAnimation)
			{
				this.StartPlayGridAppearAnimation();
			}
		}

		// Token: 0x06032F04 RID: 208644 RVA: 0x00CC2DC9 File Offset: 0x00CC0FC9
		protected override void OnEnd()
		{
			this.IsInGridAppearAnimation = false;
			this.GridAppearLastTime = 0f;
			this.GridAppearCurrentTime = 0f;
			this.CurrentAppearGridIndex = 0;
		}

		// Token: 0x06032F05 RID: 208645 RVA: 0x00CC2DEF File Offset: 0x00CC0FEF
		protected override void OnInterrupt()
		{
			base.OnInterrupt();
			this.IsInGridAppearAnimation = false;
			this.GridAppearLastTime = 0f;
			this.GridAppearCurrentTime = 0f;
			this.CurrentAppearGridIndex = 0;
		}

		// Token: 0x06032F06 RID: 208646 RVA: 0x00CC2E1B File Offset: 0x00CC101B
		protected override void OnUpdate(float deltaTimeMilliseconds)
		{
			if (this.IsInGridAppearAnimation)
			{
				this.UpdatePlayGridAppearAnimation(deltaTimeMilliseconds);
			}
		}

		// Token: 0x06032F07 RID: 208647 RVA: 0x00CC2E2C File Offset: 0x00CC102C
		private void StartPlayGridAppearAnimation()
		{
			if ((this.GridPreserver.GetGridAnimationInterval() <= 0f && this.GridPreserver.GetGridAnimationStartTime() <= 0f) || this.DisplayGridNum <= 0)
			{
				base.RemoveTimer();
				return;
			}
			this.GridPreserver.NotifyAnimationStart();
			this.IsInGridAppearAnimation = true;
			this.GridAppearLastTime = 0f;
			this.GridAppearCurrentTime = 0f;
			this.HasShowFirstGrid = false;
			this.CurrentAppearGridIndex = this.GridPreserver.GetDisplayGridStartIndex();
			base.GridsForEach(new Action<int, UUIItem>(this.HideGrid));
		}

		// Token: 0x06032F08 RID: 208648 RVA: 0x00CC2EBF File Offset: 0x00CC10BF
		private void ResetAnim()
		{
			this.GridAppearLastTime = 0f;
			this.GridAppearCurrentTime = 0f;
			this.HasShowFirstGrid = false;
			this.CurrentAppearGridIndex = this.GridPreserver.GetDisplayGridStartIndex();
		}

		// Token: 0x06032F09 RID: 208649 RVA: 0x00CC2EEF File Offset: 0x00CC10EF
		private void HideGrid(int index, UUIItem grid)
		{
			grid.SetUIActive(false);
		}

		// Token: 0x06032F0A RID: 208650 RVA: 0x00CC2EF8 File Offset: 0x00CC10F8
		private void UpdatePlayGridAppearAnimation(float deltaTimeMilliseconds)
		{
			USequencerManager sequencerManager = ALGUIManagerActor.GetSequencerManager(GlobalData.World);
			float? num = (sequencerManager != null) ? new float?(sequencerManager.GetGlobalPlayRate()) : null;
			if (num != null && num.Value != 0f)
			{
				deltaTimeMilliseconds *= num.Value;
			}
			this.GridAppearCurrentTime += deltaTimeMilliseconds / this.MillisecondToSecond;
			if (!this.HasShowFirstGrid && this.GridAppearCurrentTime < this.GridPreserver.GetGridAnimationStartTime())
			{
				return;
			}
			if (this.HasShowFirstGrid && this.GridAppearCurrentTime - this.GridAppearLastTime < this.GridPreserver.GetGridAnimationInterval())
			{
				return;
			}
			this.HasShowFirstGrid = true;
			this.GridAppearLastTime = this.GridAppearCurrentTime;
			this.ShowGridByDisplayIndexAndMoveNext();
		}

		// Token: 0x06032F0B RID: 208651 RVA: 0x00CC2FB8 File Offset: 0x00CC11B8
		private void ShowGridByDisplayIndexAndMoveNext()
		{
			if (this.CurrentAppearGridIndex < this.GridPreserver.GetDisplayGridStartIndex() || this.CurrentAppearGridIndex > this.GridPreserver.GetDisplayGridEndIndex())
			{
				this.ResetAnim();
				return;
			}
			UUIItem grid = this.GridPreserver.GetGrid(this.CurrentAppearGridIndex);
			if (grid == null || !grid.IsValid())
			{
				base.End();
				return;
			}
			base.ShowGrid(grid, this.CurrentAppearGridIndex);
			this.CurrentAppearGridIndex++;
			if (this.CurrentAppearGridIndex > this.GridPreserver.GetDisplayGridEndIndex())
			{
				base.End();
				this.GridPreserver.NotifyAnimationEnd();
			}
		}

		// Token: 0x0401DA66 RID: 121446
		private float GridAppearLastTime;

		// Token: 0x0401DA67 RID: 121447
		private float GridAppearCurrentTime;

		// Token: 0x0401DA68 RID: 121448
		private int CurrentAppearGridIndex;

		// Token: 0x0401DA69 RID: 121449
		private readonly float MillisecondToSecond = 1000f;
	}
}
