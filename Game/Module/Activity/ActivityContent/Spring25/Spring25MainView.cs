using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Spring25
{
	// Token: 0x02006369 RID: 25449
	[NullableContext(1)]
	[Nullable(0)]
	public class Spring25MainView : UiViewBase
	{
		// Token: 0x0603FE5D RID: 261725 RVA: 0x01063CC6 File Offset: 0x01061EC6
		public Spring25MainView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603FE5E RID: 261726 RVA: 0x01063CDC File Offset: 0x01061EDC
		protected unsafe override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIItem)),
				new ValueTuple<int, Type>(14, typeof(UUIItem)),
				new ValueTuple<int, Type>(15, typeof(UUIItem)),
				new ValueTuple<int, Type>(16, typeof(UUIItem))
			};
			int num = 3;
			List<ValueTuple<int, Delegate>> list = new List<ValueTuple<int, Delegate>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list, num);
			Span<ValueTuple<int, Delegate>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Delegate>(2, new Action(this.HandleInviteClick));
			num2++;
			*span[num2] = new ValueTuple<int, Delegate>(3, new Action(this.HandleGiftClick));
			num2++;
			*span[num2] = new ValueTuple<int, Delegate>(4, new Action(this.HandleLetterClick));
			this.BtnBindInfo = list;
		}

		// Token: 0x0603FE5F RID: 261727 RVA: 0x01063EF8 File Offset: 0x010620F8
		protected override UniTask OnBeforeStartAsync()
		{
			Spring25MainView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<Spring25MainView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FE60 RID: 261728 RVA: 0x01063F3C File Offset: 0x0106213C
		protected override void OnStart()
		{
			this.RefreshByOpenParam();
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.Spring25AllLetter, base.GetItem(15), null, 0);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.Spring25Reward, base.GetItem(14), null, 0);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.Spring25Invite, base.GetItem(16), null, 0);
			this.SelfItem.RefreshByInvitedAsync(!ModelBase<Spring25Model>.Instance.NeedStartDialog, false);
		}

		// Token: 0x0603FE61 RID: 261729 RVA: 0x01063FB4 File Offset: 0x010621B4
		protected override void OnBeforeDestroy()
		{
			ControllerBase<ActivitySpring25Controller>.Instance.HandleResetCurrentSignId();
			ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.Spring25AllLetter);
			ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.Spring25Reward);
			ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.Spring25Invite);
		}

		// Token: 0x0603FE62 RID: 261730 RVA: 0x01063FF0 File Offset: 0x010621F0
		protected override void OnBeforeShow()
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.Spring25AllLetter, base.GetItem(15), null, 0);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.Spring25Reward, base.GetItem(14), null, 0);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.Spring25Invite, base.GetItem(16), null, 0);
		}

		// Token: 0x0603FE63 RID: 261731 RVA: 0x01064048 File Offset: 0x01062248
		protected override void OnAfterHide()
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.Spring25AllLetter, base.GetItem(15), 0);
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.Spring25Reward, base.GetItem(14), 0);
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.Spring25Invite, base.GetItem(16), 0);
		}

		// Token: 0x0603FE64 RID: 261732 RVA: 0x010640A0 File Offset: 0x010622A0
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.Spring25InviteDone, new Action(this.HandleSpring25InviteDone));
			Singleton<EventSystem>.Instance.Add(EEventName.Spring25ActivityParseDone, new Action(this.HandleSpring25ActivityParseDone));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.HandleCloseEnvelopeView));
			Singleton<EventSystem>.Instance.Add(EEventName.Spring25UnlockAnimDone, new Action(this.HandleSpring25UnlockAnimDone));
		}

		// Token: 0x0603FE65 RID: 261733 RVA: 0x0106411C File Offset: 0x0106231C
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.Spring25InviteDone, new Action(this.HandleSpring25InviteDone));
			Singleton<EventSystem>.Instance.Remove(EEventName.Spring25ActivityParseDone, new Action(this.HandleSpring25ActivityParseDone));
			Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.HandleCloseEnvelopeView));
			Singleton<EventSystem>.Instance.Remove(EEventName.Spring25UnlockAnimDone, new Action(this.HandleSpring25UnlockAnimDone));
		}

		// Token: 0x0603FE66 RID: 261734 RVA: 0x01064196 File Offset: 0x01062396
		protected override void OnAfterPlayStartSequence()
		{
			this.TryPlayOpening();
		}

		// Token: 0x0603FE67 RID: 261735 RVA: 0x010641A0 File Offset: 0x010623A0
		private UniTask TryPlayOpening()
		{
			Spring25MainView.<TryPlayOpening>d__15 <TryPlayOpening>d__;
			<TryPlayOpening>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TryPlayOpening>d__.<>4__this = this;
			<TryPlayOpening>d__.<>1__state = -1;
			<TryPlayOpening>d__.<>t__builder.Start<Spring25MainView.<TryPlayOpening>d__15>(ref <TryPlayOpening>d__);
			return <TryPlayOpening>d__.<>t__builder.Task;
		}

		// Token: 0x0603FE68 RID: 261736 RVA: 0x010641E4 File Offset: 0x010623E4
		private unsafe void RefreshByOpenParam()
		{
			Spring25MainViewData spring25MainViewData = this.OpenParam as Spring25MainViewData;
			if (spring25MainViewData == null)
			{
				return;
			}
			if (spring25MainViewData.CharacterInvitedMap.Count != this.CharacterItemCache.Count)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Spring25;
				ELogAuthor author = ELogAuthor.WZ;
				string message = "春节活动角色信息和UI节点不符，隐藏全部节点";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("data count", spring25MainViewData.CharacterInvitedMap.Count);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("item count", this.CharacterItemCache.Count);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				foreach (ItemInMain itemInMain in this.CharacterItemCache.Values)
				{
					itemInMain.SetUiActive(false);
				}
				return;
			}
			foreach (KeyValuePair<ESpring25RoleType, bool> keyValuePair in spring25MainViewData.CharacterInvitedMap)
			{
				ItemInMain itemInMain2;
				if (this.CharacterItemCache.TryGetValue(keyValuePair.Key, out itemInMain2))
				{
					ItemInMain itemInMain3 = itemInMain2;
					bool value = keyValuePair.Value;
					ESpring25RoleType key = keyValuePair.Key;
					ESpring25RoleType? newRoleType = spring25MainViewData.NewRoleType;
					itemInMain3.RefreshByInvitedAsync(value, key == newRoleType.GetValueOrDefault() & newRoleType != null);
				}
			}
			this.CaptionItem.SetTitleByTextIdAndArgNew(spring25MainViewData.TitleTextId, Array.Empty<object>());
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.SetText(spring25MainViewData.InviteRemainCount.ToString(), true);
		}

		// Token: 0x0603FE69 RID: 261737 RVA: 0x01064390 File Offset: 0x01062590
		private void HandleInviteClick()
		{
			if (this.ClickLock)
			{
				return;
			}
			this.ClickLock = true;
			ControllerBase<ActivitySpring25Controller>.Instance.HandleInviteClickInMainView();
		}

		// Token: 0x0603FE6A RID: 261738 RVA: 0x010643AD File Offset: 0x010625AD
		private void HandleGiftClick()
		{
			if (this.ClickLock)
			{
				return;
			}
			ControllerBase<ActivitySpring25Controller>.Instance.HandleGiftClickInMainView();
		}

		// Token: 0x0603FE6B RID: 261739 RVA: 0x010643C2 File Offset: 0x010625C2
		private void HandleLetterClick()
		{
			if (this.ClickLock)
			{
				return;
			}
			ControllerBase<ActivitySpring25Controller>.Instance.HandleLetterClickInMainView();
		}

		// Token: 0x0603FE6C RID: 261740 RVA: 0x010643D7 File Offset: 0x010625D7
		private void HandleOnCloseClick()
		{
			if (this.ClickLock)
			{
				return;
			}
			base.CloseMe(null);
		}

		// Token: 0x0603FE6D RID: 261741 RVA: 0x010643E9 File Offset: 0x010625E9
		private void HandleOnHelpClick()
		{
			ControllerBase<ActivitySpring25Controller>.Instance.HandleHelpClick();
		}

		// Token: 0x0603FE6E RID: 261742 RVA: 0x010643F5 File Offset: 0x010625F5
		private void HandleSpring25InviteDone()
		{
			this.OpenParam = ModelBase<Spring25Model>.Instance.BuildMainViewData(false);
			this.RefreshByOpenParam();
		}

		// Token: 0x0603FE6F RID: 261743 RVA: 0x0106440E File Offset: 0x0106260E
		private void HandleSpring25ActivityParseDone()
		{
			this.OpenParam = ModelBase<Spring25Model>.Instance.BuildMainViewData(true);
			this.RefreshByOpenParam();
		}

		// Token: 0x0603FE70 RID: 261744 RVA: 0x01064427 File Offset: 0x01062627
		private void HandleCloseEnvelopeView(EUiViewName viewName, int i)
		{
			if (viewName == EUiViewName.Spring25EnvelopeView)
			{
				ControllerBase<ActivitySpring25Controller>.Instance.HandleTryOpenShareViewAsync();
			}
		}

		// Token: 0x0603FE71 RID: 261745 RVA: 0x01064441 File Offset: 0x01062641
		private void HandleSpring25UnlockAnimDone()
		{
			this.ClickLock = false;
		}

		// Token: 0x04023E7C RID: 147068
		private readonly Dictionary<ESpring25RoleType, ItemInMain> CharacterItemCache = new Dictionary<ESpring25RoleType, ItemInMain>();

		// Token: 0x04023E7D RID: 147069
		private ItemInMain SelfItem;

		// Token: 0x04023E7E RID: 147070
		private PopupCaptionItem CaptionItem;

		// Token: 0x04023E7F RID: 147071
		private bool ClickLock;

		// Token: 0x0200C3D4 RID: 50132
		[NullableContext(0)]
		private static class EComponent
		{
			// Token: 0x0403C51C RID: 247068
			public const int CaptionItem = 0;

			// Token: 0x0403C51D RID: 247069
			public const int TicketCountText = 1;

			// Token: 0x0403C51E RID: 247070
			public const int InviteButton = 2;

			// Token: 0x0403C51F RID: 247071
			public const int GiftButton = 3;

			// Token: 0x0403C520 RID: 247072
			public const int LetterButton = 4;

			// Token: 0x0403C521 RID: 247073
			public const int AbuItem = 5;

			// Token: 0x0403C522 RID: 247074
			public const int SanhuaItem = 6;

			// Token: 0x0403C523 RID: 247075
			public const int MaleItem = 7;

			// Token: 0x0403C524 RID: 247076
			public const int FemaleItem = 8;

			// Token: 0x0403C525 RID: 247077
			public const int BulanteItem = 9;

			// Token: 0x0403C526 RID: 247078
			public const int LuokekeItem = 10;

			// Token: 0x0403C527 RID: 247079
			public const int ChangliItem = 11;

			// Token: 0x0403C528 RID: 247080
			public const int KelaitaItem = 12;

			// Token: 0x0403C529 RID: 247081
			public const int JinxiItem = 13;

			// Token: 0x0403C52A RID: 247082
			public const int RewardRedDotItem = 14;

			// Token: 0x0403C52B RID: 247083
			public const int LetterRedDotItem = 15;

			// Token: 0x0403C52C RID: 247084
			public const int InviteRedDotItem = 16;
		}
	}
}
