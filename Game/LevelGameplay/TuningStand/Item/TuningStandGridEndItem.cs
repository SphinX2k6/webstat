using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.TuningStand.Item
{
	// Token: 0x02006A83 RID: 27267
	[NullableContext(2)]
	[Nullable(0)]
	public class TuningStandGridEndItem : TuningStandGridBase
	{
		// Token: 0x06043716 RID: 276246 RVA: 0x0115FDBF File Offset: 0x0115DFBF
		[NullableContext(1)]
		public TuningStandGridEndItem(TuningGridData data) : base(data)
		{
		}

		// Token: 0x06043717 RID: 276247 RVA: 0x0115FDC8 File Offset: 0x0115DFC8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
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

		// Token: 0x06043718 RID: 276248 RVA: 0x0115FF1C File Offset: 0x0115E11C
		protected override UniTask OnBeforeStartAsync()
		{
			TuningStandGridEndItem.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TuningStandGridEndItem.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06043719 RID: 276249 RVA: 0x0115FF5F File Offset: 0x0115E15F
		protected override void OnStart()
		{
			this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
			base.GetItem(5).SetUIActive(false);
			base.GetItem(7).SetUIActive(false);
			this.InitLongPress();
			this.InitGrid();
		}

		// Token: 0x0604371A RID: 276250 RVA: 0x0115FF98 File Offset: 0x0115E198
		protected override void OnBeforeDestroy()
		{
			this.LineLeft = null;
			this.LineRight = null;
			this.LineTop = null;
			this.LineBottom = null;
		}

		// Token: 0x0604371B RID: 276251 RVA: 0x0115FFB6 File Offset: 0x0115E1B6
		protected override void OnResetGrid()
		{
			this.ResetLine();
			this.StopAllAnim();
			this.RefreshLine();
		}

		// Token: 0x0604371C RID: 276252 RVA: 0x0115FFCC File Offset: 0x0115E1CC
		protected override void InitGrid()
		{
			string[] array;
			if (!TuningStandDefine.gridSpriteMap.TryGetValue(this.GridType.Value, out array))
			{
				return;
			}
			this.CurSelected = false;
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(array[0]);
			this.SetSpriteByPath(resourcePath, base.GetSprite(1), false, null, null);
			this.SetSpriteByPath(resourcePath, base.GetSprite(3), false, null, null);
			string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(array[2]);
			this.SetSpriteByPath(resourcePath2, base.GetSprite(4), false, null, null);
			string resourcePath3 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(array[1]);
			this.SetSpriteByPath(resourcePath3, base.GetSprite(6), false, null, null);
			ETuningStandGridType gridType = base.Data.GridType;
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(gridType == ETuningStandGridType.End1);
			}
			UUIItem item2 = base.GetItem(0);
			if (item2 != null)
			{
				item2.SetUIActive(gridType == ETuningStandGridType.End2);
			}
			this.OnRefreshGrid();
		}

		// Token: 0x0604371D RID: 276253 RVA: 0x011600D0 File Offset: 0x0115E2D0
		public override void OnRefreshGrid()
		{
			bool state = base.Data.GetCurGridState().State != EGridBelongType.Empty;
			this.RefreshLine();
			if (!state)
			{
				if (this.CurSelected)
				{
					this.CurSelected = false;
					this.StopAllAnim();
					LevelSequencePlayer sequencePlayer = this.SequencePlayer;
					if (sequencePlayer == null)
					{
						return;
					}
					sequencePlayer.PlayLevelSequenceByName("Move", false, null, false);
					return;
				}
			}
			else if (!this.CurSelected)
			{
				this.CurSelected = true;
				this.StopAllAnim();
				LevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
				if (sequencePlayer2 == null)
				{
					return;
				}
				sequencePlayer2.PlayLevelSequenceByName("Select", false, null, false);
			}
		}

		// Token: 0x0604371E RID: 276254 RVA: 0x01160160 File Offset: 0x0115E360
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

		// Token: 0x0604371F RID: 276255 RVA: 0x011601AC File Offset: 0x0115E3AC
		protected override void OnToggleUnHover()
		{
			UUIItem item = base.GetItem(8);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x06043720 RID: 276256 RVA: 0x011601C0 File Offset: 0x0115E3C0
		protected override void OnTogglePress()
		{
		}

		// Token: 0x06043721 RID: 276257 RVA: 0x011601C2 File Offset: 0x0115E3C2
		protected override void OnToggleRelease()
		{
			UUIItem item = base.GetItem(8);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			ModelBase<TuningStandModel>.Instance.OnRelease(base.Data);
		}

		// Token: 0x06043722 RID: 276258 RVA: 0x011601E7 File Offset: 0x0115E3E7
		protected override void OnToggleCancel()
		{
			UUIItem item = base.GetItem(8);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			ModelBase<TuningStandModel>.Instance.OnRelease(base.Data);
		}

		// Token: 0x06043723 RID: 276259 RVA: 0x0116020C File Offset: 0x0115E40C
		protected void InitLongPress()
		{
			this.LongPress = new LongPressButtonItem(null, new LongPressButtonItem.ELongPressConfigId?(LongPressButtonItem.ELongPressConfigId.LongPressOne), null);
			this.LongPress.Initialize(base.GetExtendToggle(9), null, new Action(this.OnTogglePress), new Action(this.OnToggleRelease), new Action(this.OnToggleCancel));
			base.GetExtendToggle(9).OnHover.Add(new Action(this.OnToggleHover));
			base.GetExtendToggle(9).OnUnHover.Add(new Action(this.OnToggleUnHover));
		}

		// Token: 0x06043724 RID: 276260 RVA: 0x011602B4 File Offset: 0x0115E4B4
		private void StopAllAnim()
		{
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null && sequencePlayer.IsPlayingSequence("Move"))
			{
				this.SequencePlayer.StopSequenceByKey("Move", false, false);
			}
			LevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
			if (sequencePlayer2 != null && sequencePlayer2.IsPlayingSequence("Select"))
			{
				this.SequencePlayer.StopSequenceByKey("Select", false, false);
			}
		}

		// Token: 0x06043725 RID: 276261 RVA: 0x01160317 File Offset: 0x0115E517
		public override void PlayInAnim(float dist)
		{
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlayOrReplaySequenceByName("In", true, new float?(dist / 10f + 1f));
		}

		// Token: 0x06043726 RID: 276262 RVA: 0x01160344 File Offset: 0x0115E544
		private void RefreshLine()
		{
			ETuningStandPrevDirect prevDirection = base.GetPrevDirection();
			this.LineLeft.Refresh(prevDirection == ETuningStandPrevDirect.Left, base.Data.GetCurGridState().State);
			this.LineRight.Refresh(prevDirection == ETuningStandPrevDirect.Right, base.Data.GetCurGridState().State);
			this.LineTop.Refresh(prevDirection == ETuningStandPrevDirect.Top, base.Data.GetCurGridState().State);
			this.LineBottom.Refresh(prevDirection == ETuningStandPrevDirect.Bottom, base.Data.GetCurGridState().State);
		}

		// Token: 0x06043727 RID: 276263 RVA: 0x011603D4 File Offset: 0x0115E5D4
		private void ResetLine()
		{
			this.LineLeft.HideLine();
			this.LineRight.HideLine();
			this.LineTop.HideLine();
			this.LineBottom.HideLine();
		}

		// Token: 0x06043728 RID: 276264 RVA: 0x01160404 File Offset: 0x0115E604
		public override void StartRevolving()
		{
			this.LineLeft.Refresh(false, base.Data.GetCurGridState().State);
			this.LineRight.Refresh(false, base.Data.GetCurGridState().State);
			this.LineTop.Refresh(false, base.Data.GetCurGridState().State);
			this.LineBottom.Refresh(false, base.Data.GetCurGridState().State);
		}

		// Token: 0x04025A9F RID: 154271
		private LongPressButtonItem LongPress;

		// Token: 0x04025AA0 RID: 154272
		protected LevelSequencePlayer SequencePlayer;

		// Token: 0x04025AA1 RID: 154273
		private TuningStandGridLine LineLeft;

		// Token: 0x04025AA2 RID: 154274
		private TuningStandGridLine LineRight;

		// Token: 0x04025AA3 RID: 154275
		private TuningStandGridLine LineTop;

		// Token: 0x04025AA4 RID: 154276
		private TuningStandGridLine LineBottom;
	}
}
