using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.TuningStand.Item
{
	// Token: 0x02006A88 RID: 27272
	[NullableContext(2)]
	[Nullable(0)]
	public class TuningStandGridStartItem : TuningStandGridBase
	{
		// Token: 0x06043745 RID: 276293 RVA: 0x01160CAD File Offset: 0x0115EEAD
		[NullableContext(1)]
		public TuningStandGridStartItem(TuningGridData data) : base(data)
		{
		}

		// Token: 0x06043746 RID: 276294 RVA: 0x01160CB8 File Offset: 0x0115EEB8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem))
			};
		}

		// Token: 0x06043747 RID: 276295 RVA: 0x01160DAD File Offset: 0x0115EFAD
		protected override void OnStart()
		{
			this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
			base.GetItem(2).SetUIActive(false);
			base.GetItem(3).SetUIActive(false);
			this.InitLongPress();
			this.InitGrid();
		}

		// Token: 0x06043748 RID: 276296 RVA: 0x01160DE6 File Offset: 0x0115EFE6
		protected override void OnResetGrid()
		{
			this.StopAllAnim();
		}

		// Token: 0x06043749 RID: 276297 RVA: 0x01160DF0 File Offset: 0x0115EFF0
		protected override void InitGrid()
		{
			this.CurSelected = false;
			bool flag = this.GridType.GetValueOrDefault() == ETuningStandGridType.Start1;
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(!flag);
			}
			UUIItem item2 = base.GetItem(1);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(flag);
		}

		// Token: 0x0604374A RID: 276298 RVA: 0x01160E3C File Offset: 0x0115F03C
		public override void OnRefreshGrid()
		{
			if (ModelBase<TuningStandModel>.Instance.GetIsPressing())
			{
				int? curIndex = ModelBase<TuningStandModel>.Instance.GetCurIndex();
				if (ModelBase<TuningStandModel>.Instance.GetGridList()[curIndex.Value].GetCurGridState().State == base.Data.StaticState.State && !this.CurSelected)
				{
					this.CurSelected = true;
					this.StopAllAnim();
					this.SequencePlayer.PlayOrReplaySequenceByName("Drag", false, null);
					return;
				}
			}
			else
			{
				if (!this.CurSelected && base.Data.StaticState.Next != null)
				{
					this.CurSelected = true;
					this.StopAllAnim();
					this.SequencePlayer.PlayOrReplaySequenceByName("Drag", false, null);
					return;
				}
				if (this.CurSelected && base.Data.StaticState.Next == null)
				{
					this.CurSelected = false;
					this.StopAllAnim();
					this.SequencePlayer.PlayOrReplaySequenceByName("Unfold", false, null);
				}
			}
		}

		// Token: 0x0604374B RID: 276299 RVA: 0x01160F5B File Offset: 0x0115F15B
		protected override void OnToggleHover()
		{
			if (ModelBase<TuningStandModel>.Instance.OnHover(base.Data) == EGridCheckReturnState.Error)
			{
				UUIItem item = base.GetItem(4);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				ModelBase<TuningStandModel>.Instance.TryStartBubbleFlow(ETuningStandBubbleTriggerType.InvalidLink);
			}
		}

		// Token: 0x0604374C RID: 276300 RVA: 0x01160F8F File Offset: 0x0115F18F
		protected override void OnToggleUnHover()
		{
			UUIItem item = base.GetItem(4);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x0604374D RID: 276301 RVA: 0x01160FA3 File Offset: 0x0115F1A3
		protected override void OnTogglePress()
		{
			ModelBase<TuningStandModel>.Instance.OnPress(base.Data);
			this.OnRefreshGrid();
		}

		// Token: 0x0604374E RID: 276302 RVA: 0x01160FBB File Offset: 0x0115F1BB
		protected override void OnToggleRelease()
		{
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			ModelBase<TuningStandModel>.Instance.OnRelease(base.Data);
		}

		// Token: 0x0604374F RID: 276303 RVA: 0x01160FE0 File Offset: 0x0115F1E0
		protected override void OnToggleCancel()
		{
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			ModelBase<TuningStandModel>.Instance.OnRelease(base.Data);
		}

		// Token: 0x06043750 RID: 276304 RVA: 0x01161008 File Offset: 0x0115F208
		protected void InitLongPress()
		{
			this.LongPress = new LongPressButtonItem(null, new LongPressButtonItem.ELongPressConfigId?(LongPressButtonItem.ELongPressConfigId.LongPressOne), null);
			this.LongPress.Initialize(base.GetExtendToggle(5), null, new Action(this.OnTogglePress), new Action(this.OnToggleRelease), new Action(this.OnToggleCancel));
			base.GetExtendToggle(5).OnHover.Add(new Action(this.OnToggleHover));
			base.GetExtendToggle(5).OnUnHover.Add(new Action(this.OnToggleUnHover));
		}

		// Token: 0x06043751 RID: 276305 RVA: 0x011610AC File Offset: 0x0115F2AC
		private void StopAllAnim()
		{
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null && sequencePlayer.IsPlayingSequence("Drag"))
			{
				this.SequencePlayer.StopSequenceByKey("Drag", false, false);
			}
			LevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
			if (sequencePlayer2 != null && sequencePlayer2.IsPlayingSequence("Unfold"))
			{
				this.SequencePlayer.StopSequenceByKey("Unfold", false, false);
			}
			LevelSequencePlayer sequencePlayer3 = this.SequencePlayer;
			if (sequencePlayer3 != null && sequencePlayer3.IsPlayingSequence("UnLoop"))
			{
				this.SequencePlayer.StopSequenceByKey("UnLoop", false, false);
			}
			LevelSequencePlayer sequencePlayer4 = this.SequencePlayer;
			if (sequencePlayer4 != null && sequencePlayer4.IsPlayingSequence("Loop"))
			{
				this.SequencePlayer.StopSequenceByKey("Loop", false, false);
			}
		}

		// Token: 0x06043752 RID: 276306 RVA: 0x01161165 File Offset: 0x0115F365
		public override void PlayInAnim(float dist)
		{
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlayOrReplaySequenceByName("In", true, new float?(dist / 10f + 1f));
		}

		// Token: 0x06043753 RID: 276307 RVA: 0x01161190 File Offset: 0x0115F390
		public override void StartRevolving()
		{
			this.StopAllAnim();
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlayLevelSequenceByName("Up", false, null, false);
		}

		// Token: 0x04025AC8 RID: 154312
		private LongPressButtonItem LongPress;

		// Token: 0x04025AC9 RID: 154313
		protected LevelSequencePlayer SequencePlayer;
	}
}
