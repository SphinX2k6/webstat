using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.TimeTrackControl
{
	// Token: 0x02006A96 RID: 27286
	[NullableContext(1)]
	[Nullable(0)]
	public class TimeTrackControlPoint : UiPanelBase
	{
		// Token: 0x06043797 RID: 276375 RVA: 0x01162381 File Offset: 0x01160581
		public TimeTrackControlPoint(UUIItem uiItem, int index, float angle)
		{
			this.Index = index;
			this.Rotator = Rotator.Create(0f, angle, 0f);
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
			this.SequencePlayer = new LevelSequencePlayer(uiItem);
		}

		// Token: 0x06043798 RID: 276376 RVA: 0x011623C0 File Offset: 0x011605C0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
		}

		// Token: 0x06043799 RID: 276377 RVA: 0x01162430 File Offset: 0x01160630
		protected override void OnStart()
		{
			base.GetItem(2).SetUIActive(true);
			base.GetItem(3).SetUIActive(false);
			if (this.Rotator != null)
			{
				UUIItem item = base.GetItem(0);
				if (item != null)
				{
					FRotator frotator = this.Rotator.ToUeRotator();
					item.SetUIRelativeRotation(frotator);
				}
			}
			this.AddEvent();
		}

		// Token: 0x0604379A RID: 276378 RVA: 0x01162485 File Offset: 0x01160685
		public void HandleDisplay(bool inShow)
		{
		}

		// Token: 0x0604379B RID: 276379 RVA: 0x01162487 File Offset: 0x01160687
		protected override void OnBeforeDestroy()
		{
			this.Rotator = null;
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
			this.RemoveEvent();
			base.Destroy(null);
		}

		// Token: 0x0604379C RID: 276380 RVA: 0x011624B5 File Offset: 0x011606B5
		public void AddEvent()
		{
		}

		// Token: 0x0604379D RID: 276381 RVA: 0x011624B7 File Offset: 0x011606B7
		public void RemoveEvent()
		{
		}

		// Token: 0x0604379E RID: 276382 RVA: 0x011624B9 File Offset: 0x011606B9
		public void UpdateState(bool inEnable)
		{
			if (inEnable)
			{
				base.GetItem(2).SetUIActive(true);
				base.GetItem(3).SetUIActive(false);
				return;
			}
			base.GetItem(2).SetUIActive(false);
			base.GetItem(3).SetUIActive(true);
		}

		// Token: 0x0604379F RID: 276383 RVA: 0x011624F4 File Offset: 0x011606F4
		public void ToggleSelected(bool isSelected)
		{
			if (this.SequencePlayer == null)
			{
				return;
			}
			this.SequencePlayer.StopCurrentSequence(false, true);
			if (isSelected)
			{
				this.SequencePlayer.PlaySequencePurely("Show", false, false, null, null, false);
				return;
			}
			this.SequencePlayer.PlaySequencePurely("Hide", false, false, null, null, false);
		}

		// Token: 0x04025AF0 RID: 154352
		public const string SHOW = "Show";

		// Token: 0x04025AF1 RID: 154353
		public const string HIDE = "Hide";

		// Token: 0x04025AF2 RID: 154354
		[Nullable(2)]
		private Rotator Rotator;

		// Token: 0x04025AF3 RID: 154355
		public int Index;

		// Token: 0x04025AF4 RID: 154356
		[Nullable(2)]
		public LevelSequencePlayer SequencePlayer;

		// Token: 0x0200C9D6 RID: 51670
		[NullableContext(0)]
		public enum ETimeTrackControlPoint
		{
			// Token: 0x0403E072 RID: 254066
			Point,
			// Token: 0x0403E073 RID: 254067
			Panel,
			// Token: 0x0403E074 RID: 254068
			Normal,
			// Token: 0x0403E075 RID: 254069
			Disable
		}
	}
}
