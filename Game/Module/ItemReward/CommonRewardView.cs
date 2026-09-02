using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B49 RID: 23369
	public class CommonRewardView : UiViewBase, ICommonRewardComponentUiAccessor, ICommonRewardComponentChildType, ICommonRewardComponentCallbacks
	{
		// Token: 0x0603B1B6 RID: 242102 RVA: 0x00EF478C File Offset: 0x00EF298C
		[NullableContext(2)]
		public UUIItem GetItemForComponent(int childType)
		{
			return base.GetItem(childType);
		}

		// Token: 0x0603B1B7 RID: 242103 RVA: 0x00EF4795 File Offset: 0x00EF2995
		[NullableContext(2)]
		public UUIText GetTextForComponent(int childType)
		{
			return base.GetText(childType);
		}

		// Token: 0x0603B1B8 RID: 242104 RVA: 0x00EF479E File Offset: 0x00EF299E
		[NullableContext(2)]
		public UUIGridLayout GetGridLayoutForComponent(int childType)
		{
			return base.GetGridLayout(childType);
		}

		// Token: 0x0603B1B9 RID: 242105 RVA: 0x00EF47A7 File Offset: 0x00EF29A7
		[NullableContext(2)]
		public UUIButtonComponent GetButtonForComponent(int childType)
		{
			return base.GetButton(childType);
		}

		// Token: 0x1700973D RID: 38717
		// (get) Token: 0x0603B1BA RID: 242106 RVA: 0x00EF47B0 File Offset: 0x00EF29B0
		public int TitleText
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700973E RID: 38718
		// (get) Token: 0x0603B1BB RID: 242107 RVA: 0x00EF47B3 File Offset: 0x00EF29B3
		public int TitlePanelItem
		{
			get
			{
				return 2;
			}
		}

		// Token: 0x1700973F RID: 38719
		// (get) Token: 0x0603B1BC RID: 242108 RVA: 0x00EF47B6 File Offset: 0x00EF29B6
		public int RewardItemListItem
		{
			get
			{
				return 3;
			}
		}

		// Token: 0x17009740 RID: 38720
		// (get) Token: 0x0603B1BD RID: 242109 RVA: 0x00EF47B9 File Offset: 0x00EF29B9
		public int ContinueText
		{
			get
			{
				return 4;
			}
		}

		// Token: 0x17009741 RID: 38721
		// (get) Token: 0x0603B1BE RID: 242110 RVA: 0x00EF47BC File Offset: 0x00EF29BC
		public int LeftButton
		{
			get
			{
				return 5;
			}
		}

		// Token: 0x17009742 RID: 38722
		// (get) Token: 0x0603B1BF RID: 242111 RVA: 0x00EF47BF File Offset: 0x00EF29BF
		public int RightButton
		{
			get
			{
				return 6;
			}
		}

		// Token: 0x17009743 RID: 38723
		// (get) Token: 0x0603B1C0 RID: 242112 RVA: 0x00EF47C2 File Offset: 0x00EF29C2
		public int RewardItemLoopListItem
		{
			get
			{
				return 7;
			}
		}

		// Token: 0x17009744 RID: 38724
		// (get) Token: 0x0603B1C1 RID: 242113 RVA: 0x00EF47C5 File Offset: 0x00EF29C5
		public int ListContentItem
		{
			get
			{
				return 8;
			}
		}

		// Token: 0x17009745 RID: 38725
		// (get) Token: 0x0603B1C2 RID: 242114 RVA: 0x00EF47C8 File Offset: 0x00EF29C8
		public int MaskButton
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x0603B1C3 RID: 242115 RVA: 0x00EF47CB File Offset: 0x00EF29CB
		void ICommonRewardComponentCallbacks.OnCloseView()
		{
			this.OnCloseView();
		}

		// Token: 0x0603B1C4 RID: 242116 RVA: 0x00EF47D3 File Offset: 0x00EF29D3
		void ICommonRewardComponentCallbacks.OnRefreshView()
		{
			this.OnRefreshView();
		}

		// Token: 0x0603B1C5 RID: 242117 RVA: 0x00EF47DB File Offset: 0x00EF29DB
		[NullableContext(1)]
		public CommonRewardView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603B1C6 RID: 242118 RVA: 0x00EF47E4 File Offset: 0x00EF29E4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIGridLayout));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedMaskButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603B1C7 RID: 242119 RVA: 0x00EF4972 File Offset: 0x00EF2B72
		protected override void OnAddEventListener()
		{
			CommonRewardComponent commonRewardComponent = this.CommonRewardComponent;
			if (commonRewardComponent != null)
			{
				commonRewardComponent.AddEventListener();
			}
			Singleton<EventSystem>.Instance.Add<IRewardDataInterface>(EEventName.OnRefreshRewardView, new Action<IRewardDataInterface>(this.OnRefreshRewardView));
		}

		// Token: 0x0603B1C8 RID: 242120 RVA: 0x00EF49A1 File Offset: 0x00EF2BA1
		protected override void OnRemoveEventListener()
		{
			CommonRewardComponent commonRewardComponent = this.CommonRewardComponent;
			if (commonRewardComponent != null)
			{
				commonRewardComponent.RemoveEventListener();
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshRewardView, new Action<IRewardDataInterface>(this.OnRefreshRewardView));
		}

		// Token: 0x0603B1C9 RID: 242121 RVA: 0x00EF49D0 File Offset: 0x00EF2BD0
		[NullableContext(1)]
		private void OnRefreshRewardView(IRewardDataInterface rewardData)
		{
			CommonRewardComponent commonRewardComponent = this.CommonRewardComponent;
			if (commonRewardComponent == null)
			{
				return;
			}
			commonRewardComponent.OnRefreshRewardView(rewardData);
		}

		// Token: 0x0603B1CA RID: 242122 RVA: 0x00EF49E4 File Offset: 0x00EF2BE4
		protected override UniTask OnCreateAsync()
		{
			CommonRewardView.<OnCreateAsync>d__31 <OnCreateAsync>d__;
			<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnCreateAsync>d__.<>4__this = this;
			<OnCreateAsync>d__.<>1__state = -1;
			<OnCreateAsync>d__.<>t__builder.Start<CommonRewardView.<OnCreateAsync>d__31>(ref <OnCreateAsync>d__);
			return <OnCreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B1CB RID: 242123 RVA: 0x00EF4A28 File Offset: 0x00EF2C28
		protected override UniTask OnBeforeStartAsync()
		{
			CommonRewardView.<OnBeforeStartAsync>d__32 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CommonRewardView.<OnBeforeStartAsync>d__32>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B1CC RID: 242124 RVA: 0x00EF4A6C File Offset: 0x00EF2C6C
		protected override void OnStart()
		{
			RewardData<ICommonRewardInfo> rewardData = this.OpenParam as RewardData<ICommonRewardInfo>;
			CommonRewardComponent commonRewardComponent = this.CommonRewardComponent;
			if (commonRewardComponent != null)
			{
				commonRewardComponent.Refresh(rewardData);
			}
			string audioId = rewardData.GetRewardInfo().AudioId;
			ControllerBase<ItemRewardController>.Instance.PlayAudio(audioId, null);
		}

		// Token: 0x0603B1CD RID: 242125 RVA: 0x00EF4AB0 File Offset: 0x00EF2CB0
		protected override void OnAfterPlayStartSequence()
		{
			this.UiViewSequence.PlaySequence("Switch", false, null);
		}

		// Token: 0x0603B1CE RID: 242126 RVA: 0x00EF4AD7 File Offset: 0x00EF2CD7
		protected override void OnAfterShow()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnShowRewardView);
		}

		// Token: 0x0603B1CF RID: 242127 RVA: 0x00EF4AE9 File Offset: 0x00EF2CE9
		protected override void OnBeforePlayCloseSequence()
		{
			this.UiViewSequence.StopSequenceByKey("Switch", false, false);
		}

		// Token: 0x0603B1D0 RID: 242128 RVA: 0x00EF4B00 File Offset: 0x00EF2D00
		protected override void OnBeforeDestroy()
		{
			CommonRewardComponent commonRewardComponent = this.CommonRewardComponent;
			if (commonRewardComponent != null)
			{
				commonRewardComponent.HandleCloseCallback();
			}
			CommonRewardComponent commonRewardComponent2 = this.CommonRewardComponent;
			if (commonRewardComponent2 != null)
			{
				commonRewardComponent2.Destroy();
			}
			this.CommonRewardComponent = null;
			Singleton<EventSystem>.Instance.Emit(EEventName.OnCloseRewardView);
			ModelBase<ItemRewardModel>.Instance.ClearCurrentRewardData();
		}

		// Token: 0x0603B1D1 RID: 242129 RVA: 0x00EF4B50 File Offset: 0x00EF2D50
		private void OnCloseView()
		{
			UiInteractLogReport.ReportSpaceKeyInteract(EUiInteractSpaceKeyType.Reward);
			base.CloseMe(null);
		}

		// Token: 0x0603B1D2 RID: 242130 RVA: 0x00EF4B60 File Offset: 0x00EF2D60
		private void OnRefreshView()
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PlaySequencePurely("Start01", true, false);
		}

		// Token: 0x0603B1D3 RID: 242131 RVA: 0x00EF4B79 File Offset: 0x00EF2D79
		private void OnClickedMaskButton()
		{
			CommonRewardComponent commonRewardComponent = this.CommonRewardComponent;
			if (commonRewardComponent == null)
			{
				return;
			}
			commonRewardComponent.OnClickMaskButton();
		}

		// Token: 0x04021558 RID: 136536
		[Nullable(2)]
		private CommonRewardComponent CommonRewardComponent;

		// Token: 0x0200BB2E RID: 47918
		private class EChildType
		{
			// Token: 0x04039C3F RID: 236607
			public const int MaskButton = 0;

			// Token: 0x04039C40 RID: 236608
			public const int TitleText = 1;

			// Token: 0x04039C41 RID: 236609
			public const int TitlePanelItem = 2;

			// Token: 0x04039C42 RID: 236610
			public const int RewardItemListItem = 3;

			// Token: 0x04039C43 RID: 236611
			public const int ContinueText = 4;

			// Token: 0x04039C44 RID: 236612
			public const int LeftButton = 5;

			// Token: 0x04039C45 RID: 236613
			public const int RightButton = 6;

			// Token: 0x04039C46 RID: 236614
			public const int RewardItemLoopListItem = 7;

			// Token: 0x04039C47 RID: 236615
			public const int ListContentItem = 8;
		}
	}
}
