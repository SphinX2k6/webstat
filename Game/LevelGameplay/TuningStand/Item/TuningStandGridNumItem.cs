using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.TuningStand.Item
{
	// Token: 0x02006A86 RID: 27270
	[NullableContext(2)]
	[Nullable(0)]
	public class TuningStandGridNumItem : TuningStandGridBase
	{
		// Token: 0x06043732 RID: 276274 RVA: 0x0116066C File Offset: 0x0115E86C
		[NullableContext(1)]
		public TuningStandGridNumItem(TuningGridData data) : base(data)
		{
		}

		// Token: 0x06043733 RID: 276275 RVA: 0x01160678 File Offset: 0x0115E878
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUISprite)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIItem))
			};
		}

		// Token: 0x06043734 RID: 276276 RVA: 0x011607CC File Offset: 0x0115E9CC
		protected override UniTask OnBeforeStartAsync()
		{
			TuningStandGridNumItem.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TuningStandGridNumItem.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06043735 RID: 276277 RVA: 0x0116080F File Offset: 0x0115EA0F
		protected override void OnStart()
		{
			this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.InitLongPress();
			base.GetItem(4).SetUIActive(false);
			base.GetItem(7).SetUIActive(false);
			this.InitGrid();
		}

		// Token: 0x06043736 RID: 276278 RVA: 0x01160848 File Offset: 0x0115EA48
		protected override void OnBeforeDestroy()
		{
			this.LineLeft = null;
			this.LineRight = null;
			this.LineTop = null;
			this.LineBottom = null;
		}

		// Token: 0x06043737 RID: 276279 RVA: 0x01160868 File Offset: 0x0115EA68
		protected override void InitGrid()
		{
			string[] array;
			if (!TuningStandDefine.gridSpriteMap.TryGetValue(this.GridType.Value, out array))
			{
				return;
			}
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(array[0]);
			this.SetSpriteByPath(resourcePath, base.GetSprite(1), false, null, null);
			string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(array[2]);
			this.SetSpriteByPath(resourcePath2, base.GetSprite(3), false, null, null);
			string resourcePath3 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(array[1]);
			this.SetSpriteByPath(resourcePath3, base.GetSprite(6), false, null, null);
			this.OnRefreshGrid();
		}

		// Token: 0x06043738 RID: 276280 RVA: 0x0116090D File Offset: 0x0115EB0D
		protected override void OnResetGrid()
		{
			this.ResetLine();
			this.OnRefreshGrid();
		}

		// Token: 0x06043739 RID: 276281 RVA: 0x0116091C File Offset: 0x0115EB1C
		public override void OnRefreshGrid()
		{
			EGridBelongType state = base.Data.GetCurGridState().State;
			this.RefreshLine();
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(state == EGridBelongType.Empty);
			}
			UUIItem item2 = base.GetItem(5);
			if (item2 != null)
			{
				item2.SetUIActive(state == EGridBelongType.Type1);
			}
			UUIItem item3 = base.GetItem(2);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(state == EGridBelongType.Type2);
		}

		// Token: 0x0604373A RID: 276282 RVA: 0x01160984 File Offset: 0x0115EB84
		protected override void OnToggleHover()
		{
			EGridCheckReturnState egridCheckReturnState = ModelBase<TuningStandModel>.Instance.OnHover(base.Data);
			if (egridCheckReturnState == EGridCheckReturnState.Error)
			{
				UUIItem item = base.GetItem(8);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				ModelBase<TuningStandModel>.Instance.TryStartBubbleFlow(ETuningStandBubbleTriggerType.InvalidLink);
				return;
			}
			if (egridCheckReturnState == EGridCheckReturnState.Valid)
			{
				this.OnRefreshGrid();
			}
		}

		// Token: 0x0604373B RID: 276283 RVA: 0x011609D0 File Offset: 0x0115EBD0
		protected override void OnToggleUnHover()
		{
			UUIItem item = base.GetItem(8);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x0604373C RID: 276284 RVA: 0x011609E4 File Offset: 0x0115EBE4
		protected override void OnTogglePress()
		{
			ModelBase<TuningStandModel>.Instance.OnPress(base.Data);
		}

		// Token: 0x0604373D RID: 276285 RVA: 0x011609F6 File Offset: 0x0115EBF6
		protected override void OnToggleRelease()
		{
			UUIItem item = base.GetItem(8);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			ModelBase<TuningStandModel>.Instance.OnRelease(base.Data);
		}

		// Token: 0x0604373E RID: 276286 RVA: 0x01160A1B File Offset: 0x0115EC1B
		protected override void OnToggleCancel()
		{
			UUIItem item = base.GetItem(8);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			ModelBase<TuningStandModel>.Instance.OnRelease(base.Data);
		}

		// Token: 0x0604373F RID: 276287 RVA: 0x01160A40 File Offset: 0x0115EC40
		protected void InitLongPress()
		{
			this.LongPress = new LongPressButtonItem(null, new LongPressButtonItem.ELongPressConfigId?(LongPressButtonItem.ELongPressConfigId.LongPressOne), null);
			this.LongPress.Initialize(base.GetExtendToggle(9), null, new Action(this.OnTogglePress), new Action(this.OnToggleRelease), new Action(this.OnToggleCancel));
			base.GetExtendToggle(9).OnHover.Add(new Action(this.OnToggleHover));
			base.GetExtendToggle(9).OnUnHover.Add(new Action(this.OnToggleUnHover));
		}

		// Token: 0x06043740 RID: 276288 RVA: 0x01160AE6 File Offset: 0x0115ECE6
		public override void PlayInAnim(float dist)
		{
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlayOrReplaySequenceByName("In", true, new float?(dist / 10f + 1f));
		}

		// Token: 0x06043741 RID: 276289 RVA: 0x01160B10 File Offset: 0x0115ED10
		private void RefreshLine()
		{
			ETuningStandPrevDirect prevDirection = base.GetPrevDirection();
			this.LineLeft.Refresh(prevDirection == ETuningStandPrevDirect.Left, base.Data.GetCurGridState().State);
			this.LineRight.Refresh(prevDirection == ETuningStandPrevDirect.Right, base.Data.GetCurGridState().State);
			this.LineTop.Refresh(prevDirection == ETuningStandPrevDirect.Top, base.Data.GetCurGridState().State);
			this.LineBottom.Refresh(prevDirection == ETuningStandPrevDirect.Bottom, base.Data.GetCurGridState().State);
		}

		// Token: 0x06043742 RID: 276290 RVA: 0x01160BA0 File Offset: 0x0115EDA0
		private void ResetLine()
		{
			this.LineLeft.HideLine();
			this.LineRight.HideLine();
			this.LineTop.HideLine();
			this.LineBottom.HideLine();
		}

		// Token: 0x06043743 RID: 276291 RVA: 0x01160BD0 File Offset: 0x0115EDD0
		public override void OnLinkMiss(bool isEnd)
		{
			if (!isEnd)
			{
				LevelSequencePlayer sequencePlayer = this.SequencePlayer;
				if (sequencePlayer != null && sequencePlayer.IsPlayingSequence("Loop"))
				{
					LevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
					if (sequencePlayer2 == null)
					{
						return;
					}
					sequencePlayer2.StopSequenceByKey("Loop", false, true);
				}
				return;
			}
			LevelSequencePlayer sequencePlayer3 = this.SequencePlayer;
			if (sequencePlayer3 == null)
			{
				return;
			}
			sequencePlayer3.PlayOrReplaySequenceByName("Loop", false, null);
		}

		// Token: 0x06043744 RID: 276292 RVA: 0x01160C30 File Offset: 0x0115EE30
		public override void StartRevolving()
		{
			this.LineLeft.Refresh(false, base.Data.GetCurGridState().State);
			this.LineRight.Refresh(false, base.Data.GetCurGridState().State);
			this.LineTop.Refresh(false, base.Data.GetCurGridState().State);
			this.LineBottom.Refresh(false, base.Data.GetCurGridState().State);
		}

		// Token: 0x04025AB7 RID: 154295
		private LongPressButtonItem LongPress;

		// Token: 0x04025AB8 RID: 154296
		protected LevelSequencePlayer SequencePlayer;

		// Token: 0x04025AB9 RID: 154297
		private TuningStandGridLine LineLeft;

		// Token: 0x04025ABA RID: 154298
		private TuningStandGridLine LineRight;

		// Token: 0x04025ABB RID: 154299
		private TuningStandGridLine LineTop;

		// Token: 0x04025ABC RID: 154300
		private TuningStandGridLine LineBottom;
	}
}
