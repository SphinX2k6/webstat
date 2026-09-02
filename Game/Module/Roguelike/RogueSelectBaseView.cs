using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051B1 RID: 20913
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueSelectBaseView : UiViewBase
	{
		// Token: 0x06035C49 RID: 220233 RVA: 0x00D85E58 File Offset: 0x00D84058
		public RogueSelectBaseView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06035C4A RID: 220234 RVA: 0x00D85E64 File Offset: 0x00D84064
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RoguelikeDataUpdate, new Action(this.OnDescModelChange));
			Singleton<EventSystem>.Instance.Add(EEventName.RoguelikeCloseGainSelectView, new Action(this.CloseMySelf));
			Singleton<EventSystem>.Instance.Add(EEventName.RoguelikeChooseDataResult, new Action<RogueGainEntry, RogueGainEntry, bool, int, RoguelikeChooseDataResultResponse>(this.RoguelikeChooseDataResult));
			Singleton<EventSystem>.Instance.Add(EEventName.RoguelikeRefreshGain, new Action<int>(this.RoguelikeRefreshGain));
		}

		// Token: 0x06035C4B RID: 220235 RVA: 0x00D85EE4 File Offset: 0x00D840E4
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RoguelikeDataUpdate, new Action(this.OnDescModelChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.RoguelikeCloseGainSelectView, new Action(this.CloseMySelf));
			Singleton<EventSystem>.Instance.Remove(EEventName.RoguelikeChooseDataResult, new Action<RogueGainEntry, RogueGainEntry, bool, int, RoguelikeChooseDataResultResponse>(this.RoguelikeChooseDataResult));
			Singleton<EventSystem>.Instance.Remove(EEventName.RoguelikeRefreshGain, new Action<int>(this.RoguelikeRefreshGain));
		}

		// Token: 0x06035C4C RID: 220236 RVA: 0x00D85F64 File Offset: 0x00D84164
		protected virtual void OnDescModelChange()
		{
		}

		// Token: 0x06035C4D RID: 220237 RVA: 0x00D85F66 File Offset: 0x00D84166
		protected void CloseMySelf()
		{
			base.CloseMe(null);
		}

		// Token: 0x06035C4E RID: 220238 RVA: 0x00D85F6F File Offset: 0x00D8416F
		protected virtual void RoguelikeChooseDataResult(RogueGainEntry newRogueGainEntry, RogueGainEntry oldRogueGainEntry, bool isSuccess, int bindId, RoguelikeChooseDataResultResponse response)
		{
		}

		// Token: 0x06035C4F RID: 220239 RVA: 0x00D85F71 File Offset: 0x00D84171
		protected virtual void RoguelikeRefreshGain(int index)
		{
		}

		// Token: 0x06035C50 RID: 220240 RVA: 0x00D85F73 File Offset: 0x00D84173
		protected void RecycleUiPoolActor()
		{
			if (this.UiPoolActorPrivate != null)
			{
				Singleton<UiActorPool>.Instance.RecycleAsync(this.UiPoolActorPrivate, this.UiPoolActorPrivate.Path);
			}
		}

		// Token: 0x0401EDA5 RID: 126373
		[Nullable(2)]
		protected UiPoolActor UiPoolActorPrivate;
	}
}
