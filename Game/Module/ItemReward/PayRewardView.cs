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
	// Token: 0x02005B4C RID: 23372
	public class PayRewardView : UiViewBase, ICommonRewardComponentUiAccessor, ICommonRewardComponentChildType, ICommonRewardComponentCallbacks
	{
		// Token: 0x0603B212 RID: 242194 RVA: 0x00EF5FC4 File Offset: 0x00EF41C4
		[NullableContext(2)]
		public UUIItem GetItemForComponent(int childType)
		{
			return base.GetItem(childType);
		}

		// Token: 0x0603B213 RID: 242195 RVA: 0x00EF5FCD File Offset: 0x00EF41CD
		[NullableContext(2)]
		public UUIText GetTextForComponent(int childType)
		{
			return base.GetText(childType);
		}

		// Token: 0x0603B214 RID: 242196 RVA: 0x00EF5FD6 File Offset: 0x00EF41D6
		[NullableContext(2)]
		public UUIGridLayout GetGridLayoutForComponent(int childType)
		{
			return base.GetGridLayout(childType);
		}

		// Token: 0x0603B215 RID: 242197 RVA: 0x00EF5FDF File Offset: 0x00EF41DF
		[NullableContext(2)]
		public UUIButtonComponent GetButtonForComponent(int childType)
		{
			return base.GetButton(childType);
		}

		// Token: 0x17009746 RID: 38726
		// (get) Token: 0x0603B216 RID: 242198 RVA: 0x00EF5FE8 File Offset: 0x00EF41E8
		public int TitleText
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17009747 RID: 38727
		// (get) Token: 0x0603B217 RID: 242199 RVA: 0x00EF5FEB File Offset: 0x00EF41EB
		public int TitlePanelItem
		{
			get
			{
				return 2;
			}
		}

		// Token: 0x17009748 RID: 38728
		// (get) Token: 0x0603B218 RID: 242200 RVA: 0x00EF5FEE File Offset: 0x00EF41EE
		public int RewardItemListItem
		{
			get
			{
				return 3;
			}
		}

		// Token: 0x17009749 RID: 38729
		// (get) Token: 0x0603B219 RID: 242201 RVA: 0x00EF5FF1 File Offset: 0x00EF41F1
		public int ContinueText
		{
			get
			{
				return 4;
			}
		}

		// Token: 0x1700974A RID: 38730
		// (get) Token: 0x0603B21A RID: 242202 RVA: 0x00EF5FF4 File Offset: 0x00EF41F4
		public int LeftButton
		{
			get
			{
				return 5;
			}
		}

		// Token: 0x1700974B RID: 38731
		// (get) Token: 0x0603B21B RID: 242203 RVA: 0x00EF5FF7 File Offset: 0x00EF41F7
		public int RightButton
		{
			get
			{
				return 6;
			}
		}

		// Token: 0x1700974C RID: 38732
		// (get) Token: 0x0603B21C RID: 242204 RVA: 0x00EF5FFA File Offset: 0x00EF41FA
		public int RewardItemLoopListItem
		{
			get
			{
				return 7;
			}
		}

		// Token: 0x1700974D RID: 38733
		// (get) Token: 0x0603B21D RID: 242205 RVA: 0x00EF5FFD File Offset: 0x00EF41FD
		public int ListContentItem
		{
			get
			{
				return 8;
			}
		}

		// Token: 0x1700974E RID: 38734
		// (get) Token: 0x0603B21E RID: 242206 RVA: 0x00EF6000 File Offset: 0x00EF4200
		public int MaskButton
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x0603B21F RID: 242207 RVA: 0x00EF6003 File Offset: 0x00EF4203
		void ICommonRewardComponentCallbacks.OnCloseView()
		{
			this.OnCloseView();
		}

		// Token: 0x0603B220 RID: 242208 RVA: 0x00EF600B File Offset: 0x00EF420B
		void ICommonRewardComponentCallbacks.OnRefreshView()
		{
			this.OnRefreshView();
		}

		// Token: 0x0603B221 RID: 242209 RVA: 0x00EF6013 File Offset: 0x00EF4213
		[NullableContext(1)]
		public PayRewardView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603B222 RID: 242210 RVA: 0x00EF601C File Offset: 0x00EF421C
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

		// Token: 0x0603B223 RID: 242211 RVA: 0x00EF61AA File Offset: 0x00EF43AA
		protected override void OnAddEventListener()
		{
			CommonRewardComponent commonRewardComponent = this.CommonRewardComponent;
			if (commonRewardComponent == null)
			{
				return;
			}
			commonRewardComponent.AddEventListener();
		}

		// Token: 0x0603B224 RID: 242212 RVA: 0x00EF61BC File Offset: 0x00EF43BC
		protected override void OnRemoveEventListener()
		{
			CommonRewardComponent commonRewardComponent = this.CommonRewardComponent;
			if (commonRewardComponent == null)
			{
				return;
			}
			commonRewardComponent.RemoveEventListener();
		}

		// Token: 0x0603B225 RID: 242213 RVA: 0x00EF61D0 File Offset: 0x00EF43D0
		protected override UniTask OnCreateAsync()
		{
			PayRewardView.<OnCreateAsync>d__30 <OnCreateAsync>d__;
			<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnCreateAsync>d__.<>4__this = this;
			<OnCreateAsync>d__.<>1__state = -1;
			<OnCreateAsync>d__.<>t__builder.Start<PayRewardView.<OnCreateAsync>d__30>(ref <OnCreateAsync>d__);
			return <OnCreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B226 RID: 242214 RVA: 0x00EF6214 File Offset: 0x00EF4414
		protected override UniTask OnBeforeStartAsync()
		{
			PayRewardView.<OnBeforeStartAsync>d__31 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PayRewardView.<OnBeforeStartAsync>d__31>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B227 RID: 242215 RVA: 0x00EF6258 File Offset: 0x00EF4458
		protected override void OnStart()
		{
			RewardData<ICommonRewardInfo> rewardData = this.PickLastRewardData();
			if (rewardData == null)
			{
				return;
			}
			this.RefreshDisplay(rewardData);
		}

		// Token: 0x0603B228 RID: 242216 RVA: 0x00EF6278 File Offset: 0x00EF4478
		[NullableContext(1)]
		private void RefreshDisplay(RewardData<ICommonRewardInfo> rewardData)
		{
			CommonRewardComponent commonRewardComponent = this.CommonRewardComponent;
			if (commonRewardComponent != null)
			{
				commonRewardComponent.OnRefreshRewardView(rewardData);
			}
			string audioId = rewardData.GetRewardInfo().AudioId;
			ControllerBase<ItemRewardController>.Instance.PlayAudio(audioId, null);
		}

		// Token: 0x0603B229 RID: 242217 RVA: 0x00EF62B0 File Offset: 0x00EF44B0
		protected override void OnAfterPlayStartSequence()
		{
			this.UiViewSequence.PlaySequence("Switch", false, null);
		}

		// Token: 0x0603B22A RID: 242218 RVA: 0x00EF62D7 File Offset: 0x00EF44D7
		protected override void OnAfterShow()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnShowRewardView);
		}

		// Token: 0x0603B22B RID: 242219 RVA: 0x00EF62E9 File Offset: 0x00EF44E9
		protected override void OnBeforePlayCloseSequence()
		{
			this.UiViewSequence.StopSequenceByKey("Switch", false, false);
		}

		// Token: 0x0603B22C RID: 242220 RVA: 0x00EF6300 File Offset: 0x00EF4500
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

		// Token: 0x0603B22D RID: 242221 RVA: 0x00EF6350 File Offset: 0x00EF4550
		private void OnCloseView()
		{
			RewardData<ICommonRewardInfo> rewardData = this.PickLastRewardData();
			if (rewardData == null)
			{
				UiInteractLogReport.ReportSpaceKeyInteract(EUiInteractSpaceKeyType.Reward);
				base.CloseMe(null);
				return;
			}
			this.RefreshDisplay(rewardData);
		}

		// Token: 0x0603B22E RID: 242222 RVA: 0x00EF637D File Offset: 0x00EF457D
		private void OnRefreshView()
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PlaySequencePurely("Start01", true, false);
		}

		// Token: 0x0603B22F RID: 242223 RVA: 0x00EF6396 File Offset: 0x00EF4596
		private void OnClickedMaskButton()
		{
			CommonRewardComponent commonRewardComponent = this.CommonRewardComponent;
			if (commonRewardComponent == null)
			{
				return;
			}
			commonRewardComponent.OnClickMaskButton();
		}

		// Token: 0x0603B230 RID: 242224 RVA: 0x00EF63A8 File Offset: 0x00EF45A8
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private RewardData<ICommonRewardInfo> PickLastRewardData()
		{
			List<RewardData<ICommonRewardInfo>> cacheCommonRewardDataList = ModelBase<ItemRewardModel>.Instance.CacheCommonRewardDataList;
			if (cacheCommonRewardDataList.Count > 0)
			{
				RewardData<ICommonRewardInfo> rewardData = cacheCommonRewardDataList[0];
				cacheCommonRewardDataList.RemoveAt(0);
				if (rewardData != null)
				{
					return rewardData;
				}
			}
			return null;
		}

		// Token: 0x04021572 RID: 136562
		[Nullable(2)]
		private CommonRewardComponent CommonRewardComponent;

		// Token: 0x0200BB47 RID: 47943
		private class EChildType
		{
			// Token: 0x04039CBE RID: 236734
			public const int MaskButton = 0;

			// Token: 0x04039CBF RID: 236735
			public const int TitleText = 1;

			// Token: 0x04039CC0 RID: 236736
			public const int TitlePanelItem = 2;

			// Token: 0x04039CC1 RID: 236737
			public const int RewardItemListItem = 3;

			// Token: 0x04039CC2 RID: 236738
			public const int ContinueText = 4;

			// Token: 0x04039CC3 RID: 236739
			public const int LeftButton = 5;

			// Token: 0x04039CC4 RID: 236740
			public const int RightButton = 6;

			// Token: 0x04039CC5 RID: 236741
			public const int RewardItemLoopListItem = 7;

			// Token: 0x04039CC6 RID: 236742
			public const int ListContentItem = 8;
		}
	}
}
