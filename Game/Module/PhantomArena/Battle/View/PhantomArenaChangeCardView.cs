using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhantomArena.Battle.Card;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Battle.Process;
using CSharpScript.Game.Module.PhantomArena.Battle.View.Panel;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View
{
	// Token: 0x020055B3 RID: 21939
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaChangeCardView : UiViewBase, IUiViewResource
	{
		// Token: 0x06037DBD RID: 228797 RVA: 0x00E27526 File Offset: 0x00E25726
		public PhantomArenaChangeCardView(UiViewInfo uiViewInfo) : base(uiViewInfo)
		{
		}

		// Token: 0x06037DBE RID: 228798 RVA: 0x00E27544 File Offset: 0x00E25744
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(2, new Action(this.ConfirmClick)),
				new ValueTuple<int, Delegate>(3, new Action(this.EmptyClick))
			};
		}

		// Token: 0x06037DBF RID: 228799 RVA: 0x00E27608 File Offset: 0x00E25808
		private UniTask InitTipsItem()
		{
			PhantomArenaChangeCardView.<InitTipsItem>d__7 <InitTipsItem>d__;
			<InitTipsItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTipsItem>d__.<>4__this = this;
			<InitTipsItem>d__.<>1__state = -1;
			<InitTipsItem>d__.<>t__builder.Start<PhantomArenaChangeCardView.<InitTipsItem>d__7>(ref <InitTipsItem>d__);
			return <InitTipsItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037DC0 RID: 228800 RVA: 0x00E2764C File Offset: 0x00E2584C
		private UniTask InitLayout()
		{
			PhantomArenaChangeCardView.<InitLayout>d__8 <InitLayout>d__;
			<InitLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitLayout>d__.<>4__this = this;
			<InitLayout>d__.<>1__state = -1;
			<InitLayout>d__.<>t__builder.Start<PhantomArenaChangeCardView.<InitLayout>d__8>(ref <InitLayout>d__);
			return <InitLayout>d__.<>t__builder.Task;
		}

		// Token: 0x06037DC1 RID: 228801 RVA: 0x00E27690 File Offset: 0x00E25890
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaChangeCardView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaChangeCardView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037DC2 RID: 228802 RVA: 0x00E276D3 File Offset: 0x00E258D3
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.ReplaceCardFinish, new Action(this.JumpToBattleView));
		}

		// Token: 0x06037DC3 RID: 228803 RVA: 0x00E276F1 File Offset: 0x00E258F1
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.ReplaceCardFinish, new Action(this.JumpToBattleView));
		}

		// Token: 0x06037DC4 RID: 228804 RVA: 0x00E2770F File Offset: 0x00E2590F
		private PhantomArenaReplaceCard InitCard()
		{
			return new PhantomArenaReplaceCard
			{
				ClickCallback = new Action<int, bool>(this.CardClick)
			};
		}

		// Token: 0x06037DC5 RID: 228805 RVA: 0x00E27728 File Offset: 0x00E25928
		private void ConfirmClick()
		{
			PhantomArenaBattleController.RequestPhantomBattleDealCardReplace(new List<int>(this.ReplaceIdSet));
		}

		// Token: 0x06037DC6 RID: 228806 RVA: 0x00E2773B File Offset: 0x00E2593B
		private void EmptyClick()
		{
			this.CancelSelectState();
		}

		// Token: 0x06037DC7 RID: 228807 RVA: 0x00E27743 File Offset: 0x00E25943
		private void CardClick(int id, bool isReplace)
		{
			if (isReplace)
			{
				this.ReplaceIdSet.Add(id);
			}
			else
			{
				this.ReplaceIdSet.Remove(id);
			}
			this.HandleSelectState(id);
		}

		// Token: 0x06037DC8 RID: 228808 RVA: 0x00E2776B File Offset: 0x00E2596B
		private void JumpToBattleView()
		{
			base.CloseMe(delegate(bool _)
			{
				ControllerBase<PhantomArenaBattleController>.Instance.SwitchPhantomArenaBattleViewState(EPlayingCardProcessState.BothDrawCard);
			});
		}

		// Token: 0x06037DC9 RID: 228809 RVA: 0x00E27794 File Offset: 0x00E25994
		private void HandleSelectState(int selectId)
		{
			if (this.CurrentSelectId == selectId)
			{
				return;
			}
			if (this.CurrentSelectId != -1)
			{
				PhantomArenaReplaceCard layoutItemByKey = this.Layout.GetLayoutItemByKey(this.CurrentSelectId);
				if (layoutItemByKey != null)
				{
					layoutItemByKey.SetSelectState(false);
				}
			}
			PhantomArenaReplaceCard layoutItemByKey2 = this.Layout.GetLayoutItemByKey(selectId);
			if (layoutItemByKey2 != null)
			{
				layoutItemByKey2.SetSelectState(true);
				this.TipsItem.RefreshTips(layoutItemByKey2.Card.Data, false);
				this.TipsItem.SetTipsActive(true);
			}
			this.CurrentSelectId = selectId;
		}

		// Token: 0x06037DCA RID: 228810 RVA: 0x00E2781C File Offset: 0x00E25A1C
		private void CancelSelectState()
		{
			if (this.CurrentSelectId == -1)
			{
				return;
			}
			PhantomArenaReplaceCard layoutItemByKey = this.Layout.GetLayoutItemByKey(this.CurrentSelectId);
			if (layoutItemByKey != null)
			{
				layoutItemByKey.SetSelectState(false);
			}
			this.CurrentSelectId = -1;
			this.TipsItem.SetTipsActive(false);
		}

		// Token: 0x06037DCB RID: 228811 RVA: 0x00E27868 File Offset: 0x00E25A68
		public string GetExtraResourceId(object param = null)
		{
			if (!ModelBase<PhantomArenaBattleModel>.Instance.IsOldBvb)
			{
				return "UiView_CardChageNew";
			}
			return "UiView_CardChage";
		}

		// Token: 0x0401FF93 RID: 130963
		protected GenericLayout<PhantomArenaReplaceCard, PhantomCardData> Layout;

		// Token: 0x0401FF94 RID: 130964
		private PhantomArenaBattleTips TipsItem;

		// Token: 0x0401FF95 RID: 130965
		private readonly HashSet<int> ReplaceIdSet = new HashSet<int>();

		// Token: 0x0401FF96 RID: 130966
		private int CurrentSelectId = -1;

		// Token: 0x0200B56D RID: 46445
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04038261 RID: 229985
			public const int Layout = 0;

			// Token: 0x04038262 RID: 229986
			public const int LayoutItem = 1;

			// Token: 0x04038263 RID: 229987
			public const int ConfirmBtn = 2;

			// Token: 0x04038264 RID: 229988
			public const int EmptyBtn = 3;

			// Token: 0x04038265 RID: 229989
			public const int TipsItem = 4;
		}
	}
}
