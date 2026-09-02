using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Bvb
{
	// Token: 0x020055DA RID: 21978
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleVsView : UiViewBase
	{
		// Token: 0x06038023 RID: 229411 RVA: 0x00E307B6 File Offset: 0x00E2E9B6
		public PhantomArenaBattleVsView(UiViewInfo uiViewInfo) : base(uiViewInfo)
		{
		}

		// Token: 0x06038024 RID: 229412 RVA: 0x00E307BF File Offset: 0x00E2E9BF
		protected override void OnStart()
		{
			this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.SequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnAnimStop), false);
		}

		// Token: 0x06038025 RID: 229413 RVA: 0x00E307EA File Offset: 0x00E2E9EA
		protected override void OnAfterShow()
		{
			if (Singleton<UiManager>.Instance.IsViewHide(EUiViewName.PhantomArenaBattleLoading))
			{
				this.OnLoadingHide();
			}
		}

		// Token: 0x06038026 RID: 229414 RVA: 0x00E30803 File Offset: 0x00E2EA03
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaBattleLoadingHide, new Action(this.OnLoadingHide));
		}

		// Token: 0x06038027 RID: 229415 RVA: 0x00E30821 File Offset: 0x00E2EA21
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaBattleLoadingHide, new Action(this.OnLoadingHide));
		}

		// Token: 0x06038028 RID: 229416 RVA: 0x00E30840 File Offset: 0x00E2EA40
		private void OnAnimStop(string _)
		{
			PhantomArenaBattleDetailsViewProxy param = new PhantomArenaBattleDetailsViewProxy();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomArenaBattleDetailsView, param, delegate(bool _, int _)
			{
				PhantomArenaBattleController.RequestBvbLoadingFinish();
				base.CloseMe(null);
			});
		}

		// Token: 0x06038029 RID: 229417 RVA: 0x00E30870 File Offset: 0x00E2EA70
		private void OnLoadingHide()
		{
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.PlayLevelSequenceByName("Start01", false, null, false);
			}
			Singleton<AudioSystem>.Instance.SetState("arena_battle", "battle_3d", true);
		}

		// Token: 0x0603802A RID: 229418 RVA: 0x00E308B3 File Offset: 0x00E2EAB3
		protected override string OnGetLoopAudioEvent()
		{
			if (ModelBase<PhantomArenaBattleModel>.Instance.IsOldBvb)
			{
				return this.ViewInfo.LoopAudioEvent;
			}
			return "play_ui_music_3_0_arena_card_battle";
		}

		// Token: 0x04020069 RID: 131177
		protected LevelSequencePlayer SequencePlayer;

		// Token: 0x0200B5E4 RID: 46564
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04038475 RID: 230517
			public const int OwnArea = 0;

			// Token: 0x04038476 RID: 230518
			public const int OpponentArea = 1;

			// Token: 0x04038477 RID: 230519
			public const int BackBtn = 2;

			// Token: 0x04038478 RID: 230520
			public const int SkipBtn = 3;

			// Token: 0x04038479 RID: 230521
			public const int DraggableComponent = 4;

			// Token: 0x0403847A RID: 230522
			public const int NiagaraPoint = 5;

			// Token: 0x0403847B RID: 230523
			public const int TxtSpeed = 6;

			// Token: 0x0403847C RID: 230524
			public const int NiagaraPointMe = 7;

			// Token: 0x0403847D RID: 230525
			public const int CameraMoveItem = 8;

			// Token: 0x0403847E RID: 230526
			public const int DamageStatisticsItem = 9;
		}
	}
}
