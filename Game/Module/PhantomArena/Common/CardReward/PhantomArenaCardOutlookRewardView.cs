using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardReward
{
	// Token: 0x02005526 RID: 21798
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaCardOutlookRewardView : UiViewBase
	{
		// Token: 0x060379B5 RID: 227765 RVA: 0x00E1C212 File Offset: 0x00E1A412
		public PhantomArenaCardOutlookRewardView(UiViewInfo uiViewInfo) : base(uiViewInfo)
		{
		}

		// Token: 0x060379B6 RID: 227766 RVA: 0x00E1C21C File Offset: 0x00E1A41C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action(this.OnCloseButtonClick))
			};
		}

		// Token: 0x060379B7 RID: 227767 RVA: 0x00E1C2C8 File Offset: 0x00E1A4C8
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaCardOutlookRewardView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaCardOutlookRewardView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060379B8 RID: 227768 RVA: 0x00E1C30C File Offset: 0x00E1A50C
		protected override void OnStart()
		{
			base.GetItem(3).SetUIActive(true);
			base.GetItem(4).SetUIActive(false);
			this.CardId = ModelBase<PhantomArenaModel>.Instance.CardOutlookUnlockQueue[0];
			ModelBase<PhantomArenaModel>.Instance.CardOutlookUnlockQueue.RemoveAt(0);
			this.RefreshByCardId(this.CardId);
		}

		// Token: 0x060379B9 RID: 227769 RVA: 0x00E1C365 File Offset: 0x00E1A565
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnSeqEvent));
		}

		// Token: 0x060379BA RID: 227770 RVA: 0x00E1C383 File Offset: 0x00E1A583
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnSeqEvent));
		}

		// Token: 0x060379BB RID: 227771 RVA: 0x00E1C3A1 File Offset: 0x00E1A5A1
		public void RefreshByCardId(int cardId)
		{
			this.CardItem.Refresh(cardId);
		}

		// Token: 0x060379BC RID: 227772 RVA: 0x00E1C3B0 File Offset: 0x00E1A5B0
		public void ShowNext()
		{
			UiAsyncTask task = new UiAsyncTask("PhantomArenaCardOutlookRewardView", delegate()
			{
				PhantomArenaCardOutlookRewardView.<<ShowNext>b__11_0>d <<ShowNext>b__11_0>d;
				<<ShowNext>b__11_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<ShowNext>b__11_0>d.<>4__this = this;
				<<ShowNext>b__11_0>d.<>1__state = -1;
				<<ShowNext>b__11_0>d.<>t__builder.Start<PhantomArenaCardOutlookRewardView.<<ShowNext>b__11_0>d>(ref <<ShowNext>b__11_0>d);
				return <<ShowNext>b__11_0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task).Forget();
		}

		// Token: 0x060379BD RID: 227773 RVA: 0x00E1C3E4 File Offset: 0x00E1A5E4
		public UniTask ShowNextAsync()
		{
			PhantomArenaCardOutlookRewardView.<ShowNextAsync>d__12 <ShowNextAsync>d__;
			<ShowNextAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowNextAsync>d__.<>4__this = this;
			<ShowNextAsync>d__.<>1__state = -1;
			<ShowNextAsync>d__.<>t__builder.Start<PhantomArenaCardOutlookRewardView.<ShowNextAsync>d__12>(ref <ShowNextAsync>d__);
			return <ShowNextAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060379BE RID: 227774 RVA: 0x00E1C427 File Offset: 0x00E1A627
		private void OnCloseButtonClick()
		{
			if (ModelBase<PhantomArenaModel>.Instance.CardOutlookUnlockQueue.Count > 0)
			{
				this.ShowNext();
				return;
			}
			base.CloseMe(null);
		}

		// Token: 0x060379BF RID: 227775 RVA: 0x00E1C449 File Offset: 0x00E1A649
		protected override void OnAfterDestroy()
		{
			ControllerBase<PhantomArenaController>.Instance.PostUnlockView();
		}

		// Token: 0x060379C0 RID: 227776 RVA: 0x00E1C456 File Offset: 0x00E1A656
		private void OnSeqEvent(string seqName)
		{
			if (seqName == "Change" && this.IsWaitingChange)
			{
				this.RefreshByCardId(this.CardId);
			}
		}

		// Token: 0x0401FE12 RID: 130578
		private UnlockViewCardItem CardItem;

		// Token: 0x0401FE13 RID: 130579
		protected int CardId;

		// Token: 0x0401FE14 RID: 130580
		protected bool IsWaitingChange;

		// Token: 0x0200B4C0 RID: 46272
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04037F5E RID: 229214
			public const int TitleText = 0;

			// Token: 0x04037F5F RID: 229215
			public const int CloseButton = 1;

			// Token: 0x04037F60 RID: 229216
			public const int CardItem = 2;

			// Token: 0x04037F61 RID: 229217
			public const int PanelCard = 3;

			// Token: 0x04037F62 RID: 229218
			public const int PanelCards = 4;
		}
	}
}
