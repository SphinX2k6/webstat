using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.View.BaseMap;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.ViewComponent
{
	// Token: 0x02004B51 RID: 19281
	[NullableContext(1)]
	[Nullable(0)]
	public class WorldMapSecondaryUi : UiPanelBase
	{
		// Token: 0x1700867E RID: 34430
		// (get) Token: 0x060325AA RID: 206250 RVA: 0x00C99B31 File Offset: 0x00C97D31
		public bool IsUiOpen
		{
			get
			{
				return this.SecondaryUiState == ESecondaryPanelState.Open;
			}
		}

		// Token: 0x1700867F RID: 34431
		// (get) Token: 0x060325AB RID: 206251 RVA: 0x00C99B3C File Offset: 0x00C97D3C
		public bool IsUiCloseComplete
		{
			get
			{
				return this.SecondaryUiState == ESecondaryPanelState.CloseComplete;
			}
		}

		// Token: 0x17008680 RID: 34432
		// (get) Token: 0x060325AC RID: 206252 RVA: 0x00C99B47 File Offset: 0x00C97D47
		public bool IsUiClose
		{
			get
			{
				return this.SecondaryUiState == ESecondaryPanelState.Close;
			}
		}

		// Token: 0x17008681 RID: 34433
		// (get) Token: 0x060325AD RID: 206253 RVA: 0x00C99B54 File Offset: 0x00C97D54
		private LevelSequencePlayer LevelSequencePlayer
		{
			get
			{
				if (this.InterLevelSequencePlayer == null)
				{
					PopupTypeRightItem uiBgItem = this.UiBgItem;
					UUIItem uiItem = ((uiBgItem != null) ? uiBgItem.GetRootItem() : null) ?? base.GetRootItem();
					this.InterLevelSequencePlayer = new LevelSequencePlayer(uiItem);
					this.InterLevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.FinishSequenceEvent), false);
				}
				return this.InterLevelSequencePlayer;
			}
		}

		// Token: 0x060325AE RID: 206254 RVA: 0x00C99BB0 File Offset: 0x00C97DB0
		protected override void OnBeforeCreate()
		{
			if (!this.GetNeedBgItem())
			{
				return;
			}
			this.UiBgItem = this.GetPopupRightItem();
		}

		// Token: 0x060325AF RID: 206255 RVA: 0x00C99BC7 File Offset: 0x00C97DC7
		protected virtual PopupTypeRightItem GetPopupRightItem()
		{
			return new PopupTypeRightItem();
		}

		// Token: 0x060325B0 RID: 206256 RVA: 0x00C99BCE File Offset: 0x00C97DCE
		protected virtual void OnBeforeDestroyImplementImplement()
		{
		}

		// Token: 0x060325B1 RID: 206257 RVA: 0x00C99BD0 File Offset: 0x00C97DD0
		protected override void OnBeforeDestroyImplement()
		{
			this.OnBeforeDestroyImplementImplement();
			LevelSequencePlayer interLevelSequencePlayer = this.InterLevelSequencePlayer;
			if (interLevelSequencePlayer != null)
			{
				interLevelSequencePlayer.Clear();
			}
			this.InterLevelSequencePlayer = null;
		}

		// Token: 0x060325B2 RID: 206258 RVA: 0x00C99BF0 File Offset: 0x00C97DF0
		protected override UniTask OnBeforeStartAsync()
		{
			WorldMapSecondaryUi.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<WorldMapSecondaryUi.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060325B3 RID: 206259 RVA: 0x00C99C33 File Offset: 0x00C97E33
		private void FinishSequenceEvent(string sequenceName)
		{
			if (sequenceName == "Close")
			{
				this.HandleClose(false);
			}
		}

		// Token: 0x060325B4 RID: 206260 RVA: 0x00C99C49 File Offset: 0x00C97E49
		private void HandleClose(bool bIsForce = false)
		{
			this.SetActive(false);
			this.OnClose(bIsForce);
		}

		// Token: 0x060325B5 RID: 206261 RVA: 0x00C99C59 File Offset: 0x00C97E59
		private void OnClose(bool bIsForce = false)
		{
			this.OnCloseWorldMapSecondaryUi();
			this.SecondaryUiState = ESecondaryPanelState.CloseComplete;
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.WorldMapSecondaryUiClosed, bIsForce);
			Action currentCloseCall = this.CurrentCloseCall;
			if (currentCloseCall == null)
			{
				return;
			}
			currentCloseCall();
		}

		// Token: 0x060325B6 RID: 206262 RVA: 0x00C99C89 File Offset: 0x00C97E89
		protected override void OnBeforeHide()
		{
			if (this.LevelSequencePlayer.IsPlayingSequence("Close"))
			{
				this.LevelSequencePlayer.StopCurrentSequence(false, false);
				this.OnClose(false);
			}
		}

		// Token: 0x060325B7 RID: 206263 RVA: 0x00C99CB1 File Offset: 0x00C97EB1
		public void MarkForOpen()
		{
			this.SecondaryUiState = ESecondaryPanelState.Open;
		}

		// Token: 0x060325B8 RID: 206264 RVA: 0x00C99CBC File Offset: 0x00C97EBC
		public UniTask ShowPanel(BaseMap map, params object[] parameters)
		{
			WorldMapSecondaryUi.<ShowPanel>d__23 <ShowPanel>d__;
			<ShowPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowPanel>d__.<>4__this = this;
			<ShowPanel>d__.map = map;
			<ShowPanel>d__.parameters = parameters;
			<ShowPanel>d__.<>1__state = -1;
			<ShowPanel>d__.<>t__builder.Start<WorldMapSecondaryUi.<ShowPanel>d__23>(ref <ShowPanel>d__);
			return <ShowPanel>d__.<>t__builder.Task;
		}

		// Token: 0x060325B9 RID: 206265 RVA: 0x00C99D0F File Offset: 0x00C97F0F
		protected override void OnAfterShow()
		{
			this.OnAfterShowWorldMapSecondaryUi();
		}

		// Token: 0x060325BA RID: 206266 RVA: 0x00C99D17 File Offset: 0x00C97F17
		public void UpdateMap(BaseMap map)
		{
			this.Map = map;
		}

		// Token: 0x060325BB RID: 206267 RVA: 0x00C99D20 File Offset: 0x00C97F20
		[NullableContext(2)]
		public void CloseWithCallBack(Action callback, bool playSequence = true)
		{
			this.CurrentCloseCall = callback;
			this.SecondaryUiState = ESecondaryPanelState.Close;
			if (playSequence)
			{
				this.LevelSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
				return;
			}
			this.HandleClose(false);
		}

		// Token: 0x060325BC RID: 206268 RVA: 0x00C99D61 File Offset: 0x00C97F61
		public void Close()
		{
			this.CloseWithCallBack(null, true);
		}

		// Token: 0x060325BD RID: 206269 RVA: 0x00C99D6B File Offset: 0x00C97F6B
		protected virtual UniTask OnBeforeShowWorldMapSecondaryUiAsync(params object[] parameters)
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x060325BE RID: 206270 RVA: 0x00C99D72 File Offset: 0x00C97F72
		protected virtual void SetupWorldMapSecondaryUiLayout()
		{
		}

		// Token: 0x060325BF RID: 206271 RVA: 0x00C99D74 File Offset: 0x00C97F74
		protected virtual void OnShowWorldMapSecondaryUi(params object[] parameters)
		{
		}

		// Token: 0x060325C0 RID: 206272 RVA: 0x00C99D76 File Offset: 0x00C97F76
		protected virtual void OnCloseWorldMapSecondaryUi()
		{
		}

		// Token: 0x060325C1 RID: 206273 RVA: 0x00C99D78 File Offset: 0x00C97F78
		public virtual string GetResourceId()
		{
			return "";
		}

		// Token: 0x060325C2 RID: 206274 RVA: 0x00C99D7F File Offset: 0x00C97F7F
		[NullableContext(2)]
		public virtual UUIItem GetGuideFocusUiItem()
		{
			return null;
		}

		// Token: 0x060325C3 RID: 206275 RVA: 0x00C99D82 File Offset: 0x00C97F82
		protected virtual bool GetNeedBgItem()
		{
			return true;
		}

		// Token: 0x060325C4 RID: 206276 RVA: 0x00C99D85 File Offset: 0x00C97F85
		protected void CheckAndShowCrossMapTips(MarkItem markItem)
		{
			if (!markItem.IsTracked)
			{
				MapHelper.CheckAndShowCrossMapTips(markItem.MarkId, markItem.MarkType, markItem.TrackAreaId, markItem.WorldPosition);
			}
		}

		// Token: 0x060325C5 RID: 206277 RVA: 0x00C99DAC File Offset: 0x00C97FAC
		protected virtual void OnAfterShowWorldMapSecondaryUi()
		{
		}

		// Token: 0x0401D694 RID: 120468
		[Nullable(2)]
		protected PopupTypeRightItem UiBgItem;

		// Token: 0x0401D695 RID: 120469
		[Nullable(2)]
		private LevelSequencePlayer InterLevelSequencePlayer;

		// Token: 0x0401D696 RID: 120470
		private ESecondaryPanelState SecondaryUiState;

		// Token: 0x0401D697 RID: 120471
		[Nullable(2)]
		protected BaseMap Map;

		// Token: 0x0401D698 RID: 120472
		[Nullable(2)]
		private Action CurrentCloseCall;
	}
}
