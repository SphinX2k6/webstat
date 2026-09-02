using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.WorldMap.SubViews.Common;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout
{
	// Token: 0x02004B60 RID: 19296
	[NullableContext(2)]
	[Nullable(0)]
	public class WorldMapSecondaryUiContext
	{
		// Token: 0x1700869F RID: 34463
		// (get) Token: 0x06032687 RID: 206471 RVA: 0x00C9CBEF File Offset: 0x00C9ADEF
		// (set) Token: 0x06032688 RID: 206472 RVA: 0x00C9CBF7 File Offset: 0x00C9ADF7
		public MarkItem MarkItem { get; set; }

		// Token: 0x170086A0 RID: 34464
		// (get) Token: 0x06032689 RID: 206473 RVA: 0x00C9CC00 File Offset: 0x00C9AE00
		// (set) Token: 0x0603268A RID: 206474 RVA: 0x00C9CC08 File Offset: 0x00C9AE08
		public TSetSpriteByPathAction SetSpriteByPathAction { get; set; }

		// Token: 0x170086A1 RID: 34465
		// (get) Token: 0x0603268B RID: 206475 RVA: 0x00C9CC11 File Offset: 0x00C9AE11
		// (set) Token: 0x0603268C RID: 206476 RVA: 0x00C9CC19 File Offset: 0x00C9AE19
		public UUISprite Icon { get; set; }

		// Token: 0x170086A2 RID: 34466
		// (get) Token: 0x0603268D RID: 206477 RVA: 0x00C9CC22 File Offset: 0x00C9AE22
		// (set) Token: 0x0603268E RID: 206478 RVA: 0x00C9CC2A File Offset: 0x00C9AE2A
		public UUIText Title { get; set; }

		// Token: 0x170086A3 RID: 34467
		// (get) Token: 0x0603268F RID: 206479 RVA: 0x00C9CC33 File Offset: 0x00C9AE33
		// (set) Token: 0x06032690 RID: 206480 RVA: 0x00C9CC3B File Offset: 0x00C9AE3B
		public UUIText AreaText { get; set; }

		// Token: 0x170086A4 RID: 34468
		// (get) Token: 0x06032691 RID: 206481 RVA: 0x00C9CC44 File Offset: 0x00C9AE44
		// (set) Token: 0x06032692 RID: 206482 RVA: 0x00C9CC4C File Offset: 0x00C9AE4C
		public UUIItem AreaIconItem { get; set; }

		// Token: 0x170086A5 RID: 34469
		// (get) Token: 0x06032693 RID: 206483 RVA: 0x00C9CC55 File Offset: 0x00C9AE55
		// (set) Token: 0x06032694 RID: 206484 RVA: 0x00C9CC5D File Offset: 0x00C9AE5D
		public UUIText DescriptionText { get; set; }

		// Token: 0x170086A6 RID: 34470
		// (get) Token: 0x06032695 RID: 206485 RVA: 0x00C9CC66 File Offset: 0x00C9AE66
		// (set) Token: 0x06032696 RID: 206486 RVA: 0x00C9CC6E File Offset: 0x00C9AE6E
		public ButtonItem TrackButtonItem { get; set; }

		// Token: 0x170086A7 RID: 34471
		// (get) Token: 0x06032697 RID: 206487 RVA: 0x00C9CC77 File Offset: 0x00C9AE77
		// (set) Token: 0x06032698 RID: 206488 RVA: 0x00C9CC7F File Offset: 0x00C9AE7F
		public UUISprite DownStateIcon { get; set; }

		// Token: 0x170086A8 RID: 34472
		// (get) Token: 0x06032699 RID: 206489 RVA: 0x00C9CC88 File Offset: 0x00C9AE88
		// (set) Token: 0x0603269A RID: 206490 RVA: 0x00C9CC90 File Offset: 0x00C9AE90
		public UUIItem PanelProgressItem { get; set; }

		// Token: 0x170086A9 RID: 34473
		// (get) Token: 0x0603269B RID: 206491 RVA: 0x00C9CC99 File Offset: 0x00C9AE99
		// (set) Token: 0x0603269C RID: 206492 RVA: 0x00C9CCA1 File Offset: 0x00C9AEA1
		public UUIVerticalLayout PanelListLayout { get; set; }

		// Token: 0x170086AA RID: 34474
		// (get) Token: 0x0603269D RID: 206493 RVA: 0x00C9CCAA File Offset: 0x00C9AEAA
		// (set) Token: 0x0603269E RID: 206494 RVA: 0x00C9CCB2 File Offset: 0x00C9AEB2
		public UUIButtonComponent DelButton { get; set; }

		// Token: 0x170086AB RID: 34475
		// (get) Token: 0x0603269F RID: 206495 RVA: 0x00C9CCBB File Offset: 0x00C9AEBB
		// (set) Token: 0x060326A0 RID: 206496 RVA: 0x00C9CCC3 File Offset: 0x00C9AEC3
		public MapTipsActivateTipPanel MapTipsActivateTipPanel { get; set; }

		// Token: 0x170086AC RID: 34476
		// (get) Token: 0x060326A1 RID: 206497 RVA: 0x00C9CCCC File Offset: 0x00C9AECC
		// (set) Token: 0x060326A2 RID: 206498 RVA: 0x00C9CCD4 File Offset: 0x00C9AED4
		public bool TakeAction { get; set; }

		// Token: 0x060326A3 RID: 206499 RVA: 0x00C9CCDD File Offset: 0x00C9AEDD
		[NullableContext(1)]
		public void SetConfirmBtnItem(ButtonItem item)
		{
			this.ConfirmButtonItem = item;
		}

		// Token: 0x060326A4 RID: 206500 RVA: 0x00C9CCE6 File Offset: 0x00C9AEE6
		public void SetConfirmBtnActive(bool active)
		{
			ButtonItem confirmButtonItem = this.ConfirmButtonItem;
			if (confirmButtonItem != null)
			{
				confirmButtonItem.SetActive(active);
			}
			this.IsConfirmBtnActiveInner = active;
		}

		// Token: 0x060326A5 RID: 206501 RVA: 0x00C9CD01 File Offset: 0x00C9AF01
		public bool GetIsConfirmBtnActive()
		{
			return this.ConfirmButtonItem != null && this.IsConfirmBtnActiveInner;
		}

		// Token: 0x060326A6 RID: 206502 RVA: 0x00C9CD13 File Offset: 0x00C9AF13
		[NullableContext(1)]
		public void SetConfirmBtnText([Nullable(2)] string textId, params object[] args)
		{
			if (textId == null)
			{
				return;
			}
			ButtonItem confirmButtonItem = this.ConfirmButtonItem;
			if (confirmButtonItem == null)
			{
				return;
			}
			confirmButtonItem.TrySetLocalTextNew(textId, args);
		}

		// Token: 0x060326A7 RID: 206503 RVA: 0x00C9CD2B File Offset: 0x00C9AF2B
		public void SetConfirmBtnEnableClick(bool state)
		{
			ButtonItem confirmButtonItem = this.ConfirmButtonItem;
			if (confirmButtonItem == null)
			{
				return;
			}
			confirmButtonItem.SetEnableClick(state);
		}

		// Token: 0x0401D6C2 RID: 120514
		private ButtonItem ConfirmButtonItem;

		// Token: 0x0401D6CA RID: 120522
		private bool IsConfirmBtnActiveInner = true;
	}
}
