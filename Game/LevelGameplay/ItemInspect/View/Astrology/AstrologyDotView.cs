using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.ItemInspect.View.Astrology
{
	// Token: 0x02006E4C RID: 28236
	public class AstrologyDotView : UiPanelBase
	{
		// Token: 0x06044872 RID: 280690 RVA: 0x011D0466 File Offset: 0x011CE666
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x06044873 RID: 280691 RVA: 0x011D049F File Offset: 0x011CE69F
		protected override void OnStart()
		{
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
			this.SequencePlayer.BindOnEndSequenceEvent(new Action<string>(this.SequenceEnd));
		}

		// Token: 0x06044874 RID: 280692 RVA: 0x011D04C9 File Offset: 0x011CE6C9
		protected override void OnBeforeDestroy()
		{
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
		}

		// Token: 0x06044875 RID: 280693 RVA: 0x011D04E3 File Offset: 0x011CE6E3
		[NullableContext(1)]
		private void SequenceEnd(string sequenceName)
		{
			if (sequenceName == "Close")
			{
				this.SetActive(false);
			}
		}

		// Token: 0x06044876 RID: 280694 RVA: 0x011D04FC File Offset: 0x011CE6FC
		public void SetDotActive(bool isActive, int? pointTagId = null)
		{
			if (isActive == this.IsActive)
			{
				return;
			}
			this.IsActive = isActive;
			this.PointTagId = pointTagId;
			this.SequencePlayer.StopPrevSequence(false, true);
			if (isActive)
			{
				this.SetActive(true);
				this.SequencePlayer.PlaySequencePurely("Start", false, false);
				this.SequencePlayer.PlaySequencePurely("Loop", false, false);
				return;
			}
			this.SequencePlayer.PlaySequencePurely("Close", false, false);
		}

		// Token: 0x06044877 RID: 280695 RVA: 0x011D056F File Offset: 0x011CE76F
		public void SetChecked(bool isChecked)
		{
			base.GetItem(0).SetUIActive(!isChecked);
			base.GetItem(1).SetUIActive(isChecked);
		}

		// Token: 0x06044878 RID: 280696 RVA: 0x011D058E File Offset: 0x011CE78E
		public int? GetPointTagId()
		{
			return this.PointTagId;
		}

		// Token: 0x04026254 RID: 156244
		[Nullable(2)]
		private UiSequencePlayer SequencePlayer;

		// Token: 0x04026255 RID: 156245
		private bool IsActive;

		// Token: 0x04026256 RID: 156246
		private int? PointTagId;

		// Token: 0x0200CB39 RID: 52025
		private class EComponentType
		{
			// Token: 0x0403E604 RID: 255492
			public const int YellowItem = 0;

			// Token: 0x0403E605 RID: 255493
			public const int WhiteItem = 1;
		}
	}
}
