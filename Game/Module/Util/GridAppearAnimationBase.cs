using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Module.Util
{
	// Token: 0x02004C5D RID: 19549
	[NullableContext(2)]
	[Nullable(0)]
	public abstract class GridAppearAnimationBase
	{
		// Token: 0x06032EF0 RID: 208624 RVA: 0x00CC2A50 File Offset: 0x00CC0C50
		public GridAppearAnimationBase(IGridPreserver gridPreserver)
		{
			if (gridPreserver == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.ScrollViewGrid, ELogAuthor.WY, "设置错误，gridPreserver为空!", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.GridPreserver = gridPreserver;
		}

		// Token: 0x06032EF1 RID: 208625 RVA: 0x00CC2A9B File Offset: 0x00CC0C9B
		public bool IsGridControlValid()
		{
			return !this.IsInGridAppearAnimation;
		}

		// Token: 0x06032EF2 RID: 208626 RVA: 0x00CC2AA8 File Offset: 0x00CC0CA8
		public void PlayGridAnim(int showLength, bool isScrollViewItem = false)
		{
			if (this.AnimController != null)
			{
				this.GridPreserver.NotifyAnimationStart();
				this.AnimController.Play("", showLength, isScrollViewItem);
				return;
			}
			if (this.GridPreserver.GetGridAnimationInterval() <= 0f && this.GridPreserver.GetGridAnimationStartTime() <= 0f)
			{
				this.GridPreserver.NotifyAnimationEnd();
				return;
			}
			this.Interrupt();
			this.Start();
		}

		// Token: 0x06032EF3 RID: 208627 RVA: 0x00CC2B18 File Offset: 0x00CC0D18
		public void Clear()
		{
			if (this.AnimController != null)
			{
				this.AnimController.OnFinish.Unbind();
				this.GridPreserver.NotifyAnimationEnd();
				return;
			}
			if (this.GridPreserver.GetGridAnimationInterval() <= 0f && this.GridPreserver.GetGridAnimationStartTime() <= 0f)
			{
				return;
			}
			this.Interrupt();
		}

		// Token: 0x06032EF4 RID: 208628 RVA: 0x00CC2B74 File Offset: 0x00CC0D74
		public void RegisterAnimController()
		{
			this.AnimController = this.GridPreserver.GetUiAnimController();
			if (this.AnimController != null)
			{
				this.AnimController.SetTickableWhenPaused(true);
				this.AnimController.OnFinish.Bind(new Action(this.OnAnimFinish));
			}
		}

		// Token: 0x06032EF5 RID: 208629 RVA: 0x00CC2BC2 File Offset: 0x00CC0DC2
		private void OnAnimFinish()
		{
			this.GridPreserver.NotifyAnimationEnd();
		}

		// Token: 0x06032EF6 RID: 208630 RVA: 0x00CC2BCF File Offset: 0x00CC0DCF
		private void Interrupt()
		{
			this.GridPreserver.NotifyAnimationEnd();
			this.RemoveTimer();
			this.OnInterrupt();
		}

		// Token: 0x06032EF7 RID: 208631 RVA: 0x00CC2BE8 File Offset: 0x00CC0DE8
		private void Start()
		{
			this.DisplayGridNum = this.GridPreserver.GetDisplayGridNum();
			this.StartTimer();
			this.OnStart();
		}

		// Token: 0x06032EF8 RID: 208632 RVA: 0x00CC2C07 File Offset: 0x00CC0E07
		protected virtual void OnStart()
		{
		}

		// Token: 0x06032EF9 RID: 208633 RVA: 0x00CC2C09 File Offset: 0x00CC0E09
		public void Tick(float deltaTimeMilliseconds)
		{
			this.OnUpdate(deltaTimeMilliseconds);
		}

		// Token: 0x06032EFA RID: 208634 RVA: 0x00CC2C12 File Offset: 0x00CC0E12
		protected virtual void OnUpdate(float deltaTimeMilliseconds)
		{
		}

		// Token: 0x06032EFB RID: 208635 RVA: 0x00CC2C14 File Offset: 0x00CC0E14
		protected void GridsForEach([Nullable(new byte[]
		{
			1,
			2
		})] Action<int, UUIItem> gridUpdateCallback)
		{
			int num = this.GridPreserver.GetPreservedGridNum() - 1;
			for (int i = 0; i <= num; i++)
			{
				UUIItem gridByDisplayIndex = this.GridPreserver.GetGridByDisplayIndex(i);
				gridUpdateCallback(i, gridByDisplayIndex);
			}
		}

		// Token: 0x06032EFC RID: 208636 RVA: 0x00CC2C50 File Offset: 0x00CC0E50
		protected void End()
		{
			this.RemoveTimer();
			this.OnEnd();
		}

		// Token: 0x06032EFD RID: 208637 RVA: 0x00CC2C5E File Offset: 0x00CC0E5E
		protected virtual void OnEnd()
		{
		}

		// Token: 0x06032EFE RID: 208638 RVA: 0x00CC2C60 File Offset: 0x00CC0E60
		protected virtual void OnInterrupt()
		{
			foreach (LevelSequencePlayer levelSequencePlayer in this.ItemLevelSequenceMap.Values)
			{
				levelSequencePlayer.StopSequenceByKey("Start".ToString(), false, false);
				levelSequencePlayer.Clear();
			}
			this.ItemLevelSequenceMap.Clear();
		}

		// Token: 0x06032EFF RID: 208639 RVA: 0x00CC2CD4 File Offset: 0x00CC0ED4
		[NullableContext(1)]
		protected void ShowGrid(UUIItem grid, int gridIndex)
		{
			grid.SetUIActive(true);
			LevelSequencePlayer levelSequencePlayer;
			if (!this.ItemLevelSequenceMap.TryGetValue(grid, out levelSequencePlayer))
			{
				levelSequencePlayer = new LevelSequencePlayer(grid);
				this.ItemLevelSequenceMap[grid] = levelSequencePlayer;
			}
			levelSequencePlayer.StopSequenceByKey("Start".ToString(), false, false);
			levelSequencePlayer.PlayLevelSequenceByName("Start".ToString(), false, null, false);
			Singleton<EventSystem>.Instance.Emit<int, UUIItem>(EEventName.OnShowGridAnimation, gridIndex, grid);
		}

		// Token: 0x06032F00 RID: 208640 RVA: 0x00CC2D4B File Offset: 0x00CC0F4B
		private void StartTimer()
		{
			if (this.TickId != -1)
			{
				return;
			}
			this.TickId = Singleton<TickSystem>.Instance.Add(new Action<float>(this.Tick), "GridAppearAnimation", ETickingGroup.TG_PrePhysics, true, 0, true).Id;
		}

		// Token: 0x06032F01 RID: 208641 RVA: 0x00CC2D81 File Offset: 0x00CC0F81
		protected void RemoveTimer()
		{
			if (this.TickId == -1)
			{
				return;
			}
			Singleton<TickSystem>.Instance.Remove(this.TickId);
			this.TickId = -1;
		}

		// Token: 0x0401DA5F RID: 121439
		protected readonly IGridPreserver GridPreserver;

		// Token: 0x0401DA60 RID: 121440
		private UUIInturnAnimController AnimController;

		// Token: 0x0401DA61 RID: 121441
		protected int DisplayGridNum;

		// Token: 0x0401DA62 RID: 121442
		private int TickId = -1;

		// Token: 0x0401DA63 RID: 121443
		protected bool IsInGridAppearAnimation;

		// Token: 0x0401DA64 RID: 121444
		protected bool HasShowFirstGrid;

		// Token: 0x0401DA65 RID: 121445
		[Nullable(1)]
		private readonly Dictionary<UUIItem, LevelSequencePlayer> ItemLevelSequenceMap = new Dictionary<UUIItem, LevelSequencePlayer>();
	}
}
