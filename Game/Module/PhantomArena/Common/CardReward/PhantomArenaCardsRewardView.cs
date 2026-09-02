using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardReward
{
	// Token: 0x02005527 RID: 21799
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaCardsRewardView : UiViewBase, IUiViewResource
	{
		// Token: 0x060379C2 RID: 227778 RVA: 0x00E1C4BF File Offset: 0x00E1A6BF
		public PhantomArenaCardsRewardView(UiViewInfo uiViewInfo) : base(uiViewInfo)
		{
		}

		// Token: 0x060379C3 RID: 227779 RVA: 0x00E1C4D4 File Offset: 0x00E1A6D4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action(this.OnCloseButtonClick))
			};
		}

		// Token: 0x060379C4 RID: 227780 RVA: 0x00E1C57D File Offset: 0x00E1A77D
		private RewardGridCardItem CreateCardItem()
		{
			return new RewardGridCardItem
			{
				IsNewPhantomArenaActivity = this.IsNewPhantomArenaActivity
			};
		}

		// Token: 0x060379C5 RID: 227781 RVA: 0x00E1C590 File Offset: 0x00E1A790
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaCardsRewardView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaCardsRewardView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060379C6 RID: 227782 RVA: 0x00E1C5D4 File Offset: 0x00E1A7D4
		protected UniTask RefreshCardList()
		{
			PhantomArenaCardsRewardView.<RefreshCardList>d__11 <RefreshCardList>d__;
			<RefreshCardList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshCardList>d__.<>4__this = this;
			<RefreshCardList>d__.<>1__state = -1;
			<RefreshCardList>d__.<>t__builder.Start<PhantomArenaCardsRewardView.<RefreshCardList>d__11>(ref <RefreshCardList>d__);
			return <RefreshCardList>d__.<>t__builder.Task;
		}

		// Token: 0x060379C7 RID: 227783 RVA: 0x00E1C617 File Offset: 0x00E1A817
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnSeqEvent));
		}

		// Token: 0x060379C8 RID: 227784 RVA: 0x00E1C635 File Offset: 0x00E1A835
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnSeqEvent));
		}

		// Token: 0x060379C9 RID: 227785 RVA: 0x00E1C653 File Offset: 0x00E1A853
		private void OnSeqEvent(string seqName)
		{
			if (seqName == "CardChange")
			{
				this.RefreshCardList().Forget();
			}
		}

		// Token: 0x060379CA RID: 227786 RVA: 0x00E1C66D File Offset: 0x00E1A86D
		private void OnCloseButtonClick()
		{
			if (this.CardIdList.Count > 0)
			{
				base.PlaySequence("Switch", null, true);
				return;
			}
			base.CloseMe(delegate(bool _)
			{
				this.CallbackOnClose();
			});
		}

		// Token: 0x060379CB RID: 227787 RVA: 0x00E1C69D File Offset: 0x00E1A89D
		public string GetExtraResourceId(object param = null)
		{
			BattleResultCardsViewOpenParam battleResultCardsViewOpenParam = param as BattleResultCardsViewOpenParam;
			if (battleResultCardsViewOpenParam != null && battleResultCardsViewOpenParam.IsNewPhantomArenaActivity)
			{
				return "UiView_CardUnlockNew";
			}
			return "UiView_CardUnlock";
		}

		// Token: 0x0401FE15 RID: 130581
		private const int MAX_CARD_NUM = 5;

		// Token: 0x0401FE16 RID: 130582
		private RewardGridCardItem CardItem;

		// Token: 0x0401FE17 RID: 130583
		private GenericLayout<RewardGridCardItem, CollectGridCardData> CardLayout;

		// Token: 0x0401FE18 RID: 130584
		private Action CallbackOnClose;

		// Token: 0x0401FE19 RID: 130585
		private List<int> CardIdList = new List<int>();

		// Token: 0x0401FE1A RID: 130586
		private bool IsNewPhantomArenaActivity;

		// Token: 0x0200B4C4 RID: 46276
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04037F6F RID: 229231
			public const int TitleText = 0;

			// Token: 0x04037F70 RID: 229232
			public const int CloseButton = 1;

			// Token: 0x04037F71 RID: 229233
			public const int CardItem = 2;

			// Token: 0x04037F72 RID: 229234
			public const int PanelCard = 3;

			// Token: 0x04037F73 RID: 229235
			public const int PanelCards = 4;
		}
	}
}
