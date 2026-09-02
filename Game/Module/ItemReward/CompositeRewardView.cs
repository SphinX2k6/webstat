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
	// Token: 0x02005B4A RID: 23370
	public class CompositeRewardView : UiTickViewBase
	{
		// Token: 0x0603B1D4 RID: 242132 RVA: 0x00EF4B8B File Offset: 0x00EF2D8B
		[NullableContext(1)]
		public CompositeRewardView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603B1D5 RID: 242133 RVA: 0x00EF4B94 File Offset: 0x00EF2D94
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedMaskButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603B1D6 RID: 242134 RVA: 0x00EF4D00 File Offset: 0x00EF2F00
		private void OnClickedMaskButton()
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.CompositeRewardView, null);
		}

		// Token: 0x0603B1D7 RID: 242135 RVA: 0x00EF4D12 File Offset: 0x00EF2F12
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<IReadOnlyList<RewardItemData>>(EEventName.OnRefreshRewardViewItemList, new Action<IReadOnlyList<RewardItemData>>(this.OnRefreshRewardItemList));
			Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshRewardProgressBar, new Action(this.OnRefreshRewardProgressBar));
		}

		// Token: 0x0603B1D8 RID: 242136 RVA: 0x00EF4D4C File Offset: 0x00EF2F4C
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshRewardViewItemList, new Action<IReadOnlyList<RewardItemData>>(this.OnRefreshRewardItemList));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshRewardProgressBar, new Action(this.OnRefreshRewardProgressBar));
		}

		// Token: 0x0603B1D9 RID: 242137 RVA: 0x00EF4D86 File Offset: 0x00EF2F86
		[NullableContext(1)]
		private void OnRefreshRewardItemList(IReadOnlyList<RewardItemData> itemList)
		{
			if (this.RefreshItemListVisible())
			{
				this.RefreshItemList();
			}
		}

		// Token: 0x0603B1DA RID: 242138 RVA: 0x00EF4D96 File Offset: 0x00EF2F96
		private void OnRefreshRewardProgressBar()
		{
			if (this.RefreshProgressVisible())
			{
				this.RefreshProgressBar();
			}
		}

		// Token: 0x0603B1DB RID: 242139 RVA: 0x00EF4DA8 File Offset: 0x00EF2FA8
		protected override UniTask OnBeforeStartAsync()
		{
			CompositeRewardView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CompositeRewardView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B1DC RID: 242140 RVA: 0x00EF4DEC File Offset: 0x00EF2FEC
		protected override void OnStart()
		{
			this.RewardData = (this.OpenParam as RewardData<ICompositeRewardInfo>);
			if (this.RefreshTitleVisible())
			{
				this.RefreshTitle();
			}
			if (this.RefreshTitleTextureVisible())
			{
				this.RefreshTitleTexture();
			}
			if (this.RefreshContinueTextVisible())
			{
				this.RefreshContinueText();
			}
			if (this.RefreshItemListVisible())
			{
				this.RefreshItemList();
			}
			if (this.RefreshProgressVisible())
			{
				this.RefreshProgressBar();
			}
			string audioId = this.RewardData.GetRewardInfo().AudioId;
			ControllerBase<ItemRewardController>.Instance.PlayAudio(audioId, null);
		}

		// Token: 0x0603B1DD RID: 242141 RVA: 0x00EF4E70 File Offset: 0x00EF3070
		protected override void OnAfterShow()
		{
			if (this.RewardData.GetRewardInfo().IsSuccess)
			{
				this.UiViewSequence.PlaySequence("Success", true, null);
			}
			else
			{
				this.UiViewSequence.PlaySequence("Fail", true, null);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnShowRewardView);
		}

		// Token: 0x0603B1DE RID: 242142 RVA: 0x00EF4ED5 File Offset: 0x00EF30D5
		protected override void OnBeforeDestroy()
		{
			this.RewardProgressBar = null;
			this.RewardData = null;
			ModelBase<ItemRewardModel>.Instance.ClearCurrentRewardData();
		}

		// Token: 0x0603B1DF RID: 242143 RVA: 0x00EF4EEF File Offset: 0x00EF30EF
		protected override void OnTick(float delta)
		{
			this.RewardProgressBar.Tick(delta);
		}

		// Token: 0x0603B1E0 RID: 242144 RVA: 0x00EF4F00 File Offset: 0x00EF3100
		private bool RefreshTitleVisible()
		{
			bool flag = !StringUtils.IsEmpty(this.RewardData.GetRewardInfo().Title);
			base.GetItem(4).SetUIActive(flag);
			return flag;
		}

		// Token: 0x0603B1E1 RID: 242145 RVA: 0x00EF4F34 File Offset: 0x00EF3134
		private void RefreshTitle()
		{
			string title = this.RewardData.GetRewardInfo().Title;
			if (StringUtils.IsEmpty(title))
			{
				return;
			}
			UUIText text = base.GetText(1);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, title, Array.Empty<object>());
		}

		// Token: 0x0603B1E2 RID: 242146 RVA: 0x00EF4F74 File Offset: 0x00EF3174
		private bool RefreshTitleTextureVisible()
		{
			bool flag = !StringUtils.IsEmpty(this.RewardData.GetRewardInfo().TitleIconPath);
			UUITexture texture = base.GetTexture(2);
			UUIItem texture2 = base.GetTexture(3);
			texture.SetUIActive(flag);
			texture2.SetUIActive(flag);
			return flag;
		}

		// Token: 0x0603B1E3 RID: 242147 RVA: 0x00EF4FB8 File Offset: 0x00EF31B8
		private void RefreshTitleTexture()
		{
			string titleIconPath = this.RewardData.GetRewardInfo().TitleIconPath;
			if (StringUtils.IsEmpty(titleIconPath))
			{
				return;
			}
			UUITexture titleTexture = base.GetTexture(2);
			titleTexture.SetUIActive(false);
			base.SetTextureByPath(titleIconPath, titleTexture, null, delegate(bool _)
			{
				titleTexture.SetUIActive(true);
			});
		}

		// Token: 0x0603B1E4 RID: 242148 RVA: 0x00EF5020 File Offset: 0x00EF3220
		private bool RefreshContinueTextVisible()
		{
			bool flag = !StringUtils.IsEmpty(this.RewardData.GetRewardInfo().ContinueText);
			base.GetItem(7).SetUIActive(flag);
			return flag;
		}

		// Token: 0x0603B1E5 RID: 242149 RVA: 0x00EF5054 File Offset: 0x00EF3254
		private void RefreshContinueText()
		{
			string continueText = this.RewardData.GetRewardInfo().ContinueText;
			if (StringUtils.IsEmpty(continueText))
			{
				return;
			}
			UUIText text = base.GetText(7);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, continueText, Array.Empty<object>());
		}

		// Token: 0x0603B1E6 RID: 242150 RVA: 0x00EF5094 File Offset: 0x00EF3294
		private bool RefreshItemListVisible()
		{
			bool isItemVisible = this.RewardData.GetRewardInfo().IsItemVisible;
			List<RewardItemData> itemList = this.RewardData.GetItemList();
			bool flag = isItemVisible && itemList != null && itemList != null && itemList.Count > 0;
			if (this.RewardItemList.GetActive() != flag)
			{
				this.RewardItemList.SetActive(flag);
			}
			return flag;
		}

		// Token: 0x0603B1E7 RID: 242151 RVA: 0x00EF50F0 File Offset: 0x00EF32F0
		private void RefreshItemList()
		{
			this.RewardItemList.Refresh(this.RewardData.GetItemList(), true);
		}

		// Token: 0x0603B1E8 RID: 242152 RVA: 0x00EF510C File Offset: 0x00EF330C
		private bool RefreshProgressVisible()
		{
			ICompositeRewardInfo rewardInfo = this.RewardData.GetRewardInfo();
			IExtendRewardInfo extendRewardInfo = this.RewardData.GetExtendRewardInfo();
			bool isProgressVisible = rewardInfo.IsProgressVisible;
			List<IRewardProgress> progressQueue = extendRewardInfo.ProgressQueue;
			bool flag = isProgressVisible && progressQueue != null && progressQueue != null && progressQueue.Count > 0;
			this.RewardProgressBar.SetActive(flag);
			return flag;
		}

		// Token: 0x0603B1E9 RID: 242153 RVA: 0x00EF5164 File Offset: 0x00EF3364
		private void RefreshProgressBar()
		{
			ICompositeRewardInfo rewardInfo = this.RewardData.GetRewardInfo();
			List<IRewardProgress> progressQueue = this.RewardData.GetExtendRewardInfo().ProgressQueue;
			if (progressQueue == null || progressQueue.Count == 0)
			{
				return;
			}
			this.RewardProgressBar.Refresh(rewardInfo.ProgressBarTitle, progressQueue, (float)rewardInfo.ProgressBarAnimationTime);
		}

		// Token: 0x04021559 RID: 136537
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private RewardData<ICompositeRewardInfo> RewardData;

		// Token: 0x0402155A RID: 136538
		[Nullable(2)]
		private RewardItemList RewardItemList;

		// Token: 0x0402155B RID: 136539
		[Nullable(2)]
		private RewardProgressBar RewardProgressBar;

		// Token: 0x0200BB31 RID: 47921
		private class EChildType
		{
			// Token: 0x04039C50 RID: 236624
			public const int MaskButton = 0;

			// Token: 0x04039C51 RID: 236625
			public const int TitleText = 1;

			// Token: 0x04039C52 RID: 236626
			public const int TitleTexture = 2;

			// Token: 0x04039C53 RID: 236627
			public const int TitleBgTexture = 3;

			// Token: 0x04039C54 RID: 236628
			public const int TitlePanelItem = 4;

			// Token: 0x04039C55 RID: 236629
			public const int RewardItemListItem = 5;

			// Token: 0x04039C56 RID: 236630
			public const int RewardProgressBarItem = 6;

			// Token: 0x04039C57 RID: 236631
			public const int ContinueText = 7;
		}
	}
}
