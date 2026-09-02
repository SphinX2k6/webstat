using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005ED8 RID: 24280
	[NullableContext(2)]
	[Nullable(0)]
	public class CiacconaGalEndingView : UiViewBase
	{
		// Token: 0x0603D023 RID: 249891 RVA: 0x00F7EEA9 File Offset: 0x00F7D0A9
		[NullableContext(1)]
		public CiacconaGalEndingView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603D024 RID: 249892 RVA: 0x00F7EEB4 File Offset: 0x00F7D0B4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D025 RID: 249893 RVA: 0x00F7EF80 File Offset: 0x00F7D180
		protected override UniTask OnBeforeStartAsync()
		{
			CiacconaGalEndingView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CiacconaGalEndingView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D026 RID: 249894 RVA: 0x00F7EFC3 File Offset: 0x00F7D1C3
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<RewardPopupData>(EEventName.RefreshRewardPopUp, new Action<RewardPopupData>(this.OnRefreshRewardPopUp));
		}

		// Token: 0x0603D027 RID: 249895 RVA: 0x00F7EFE1 File Offset: 0x00F7D1E1
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshRewardPopUp, new Action<RewardPopupData>(this.OnRefreshRewardPopUp));
		}

		// Token: 0x0603D028 RID: 249896 RVA: 0x00F7EFFF File Offset: 0x00F7D1FF
		[NullableContext(1)]
		private void OnRefreshRewardPopUp(RewardPopupData data)
		{
			CommonRewardPopup rewardPreviewPopup = this.RewardPreviewPopup;
			if (rewardPreviewPopup != null)
			{
				rewardPreviewPopup.SetUiActive(true);
			}
			CommonRewardPopup rewardPreviewPopup2 = this.RewardPreviewPopup;
			if (rewardPreviewPopup2 == null)
			{
				return;
			}
			rewardPreviewPopup2.Refresh(data);
		}

		// Token: 0x040223CC RID: 140236
		private CiacconaGalEndingItem EndingItem1;

		// Token: 0x040223CD RID: 140237
		private CiacconaGalEndingItem EndingItem2;

		// Token: 0x040223CE RID: 140238
		private CiacconaGalEndingItem EndingItem3;

		// Token: 0x040223CF RID: 140239
		private PopupCaptionItem Caption;

		// Token: 0x040223D0 RID: 140240
		private CommonRewardPopup RewardPreviewPopup;

		// Token: 0x0200BED4 RID: 48852
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403ABBC RID: 240572
			public const int ItemCaption = 0;

			// Token: 0x0403ABBD RID: 240573
			public const int ItemEnding1 = 1;

			// Token: 0x0403ABBE RID: 240574
			public const int ItemEnding2 = 2;

			// Token: 0x0403ABBF RID: 240575
			public const int ItemEnding3 = 3;

			// Token: 0x0403ABC0 RID: 240576
			public const int TextTitle = 4;
		}
	}
}
