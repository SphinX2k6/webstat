using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Activity
{
	// Token: 0x02005AE3 RID: 23267
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoNormalRewardView : UiViewBase
	{
		// Token: 0x0603AD25 RID: 240933 RVA: 0x00EEAF7F File Offset: 0x00EE917F
		public KurotatoNormalRewardView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603AD26 RID: 240934 RVA: 0x00EEAF9C File Offset: 0x00EE919C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603AD27 RID: 240935 RVA: 0x00EEB026 File Offset: 0x00EE9226
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshKurotatoNormalRewardData, new Action(this.RefreshView));
		}

		// Token: 0x0603AD28 RID: 240936 RVA: 0x00EEB044 File Offset: 0x00EE9244
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshKurotatoNormalRewardData, new Action(this.RefreshView));
		}

		// Token: 0x0603AD29 RID: 240937 RVA: 0x00EEB064 File Offset: 0x00EE9264
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoNormalRewardView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoNormalRewardView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AD2A RID: 240938 RVA: 0x00EEB0A7 File Offset: 0x00EE92A7
		protected override void OnBeforeShow()
		{
			this.RefreshView();
		}

		// Token: 0x0603AD2B RID: 240939 RVA: 0x00EEB0AF File Offset: 0x00EE92AF
		private void InitQuestScroll()
		{
			this.QuestScroll = new GenericLayout<KurotatoRewardItem, KurotatoRewardItemData>(base.GetVerticalLayout(1), new Func<KurotatoRewardItem>(this.CreateQuestItem), null, false, true);
		}

		// Token: 0x0603AD2C RID: 240940 RVA: 0x00EEB0D4 File Offset: 0x00EE92D4
		private void RefreshQuestScroll()
		{
			List<KurotatoNormalRewardItemData> normalRewardDataList = ControllerBase<KurotatoActivityController>.Instance.GetActivityData().GetNormalRewardDataList();
			normalRewardDataList.Sort((KurotatoNormalRewardItemData a, KurotatoNormalRewardItemData b) => Array.IndexOf<EKurotatoRewardStatus>(this.StatusOrder, a.Status) - Array.IndexOf<EKurotatoRewardStatus>(this.StatusOrder, b.Status));
			GenericLayout<KurotatoRewardItem, KurotatoRewardItemData> questScroll = this.QuestScroll;
			if (questScroll == null)
			{
				return;
			}
			questScroll.RefreshByData(normalRewardDataList.Cast<KurotatoRewardItemData>().ToList<KurotatoRewardItemData>(), null, true);
		}

		// Token: 0x0603AD2D RID: 240941 RVA: 0x00EEB120 File Offset: 0x00EE9320
		private KurotatoRewardItem CreateQuestItem()
		{
			KurotatoRewardItem kurotatoRewardItem = new KurotatoRewardItem();
			kurotatoRewardItem.SetReceiveClickCallback(new Action(this.OnClickTaskReceive));
			return kurotatoRewardItem;
		}

		// Token: 0x0603AD2E RID: 240942 RVA: 0x00EEB13C File Offset: 0x00EE933C
		private void OnClickTaskReceive()
		{
			List<int> normalRewardCanClaimableIdList = ControllerBase<KurotatoActivityController>.Instance.GetActivityData().GetNormalRewardCanClaimableIdList();
			if (normalRewardCanClaimableIdList.Count <= 0)
			{
				return;
			}
			ControllerBase<KurotatoActivityController>.Instance.RequestNormalReward(normalRewardCanClaimableIdList);
		}

		// Token: 0x0603AD2F RID: 240943 RVA: 0x00EEB16E File Offset: 0x00EE936E
		private void RefreshView()
		{
			this.RefreshQuestScroll();
		}

		// Token: 0x0603AD30 RID: 240944 RVA: 0x00EEB176 File Offset: 0x00EE9376
		private void OnCloseClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x040213CE RID: 136142
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x040213CF RID: 136143
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<KurotatoRewardItem, KurotatoRewardItemData> QuestScroll;

		// Token: 0x040213D0 RID: 136144
		private readonly EKurotatoRewardStatus[] StatusOrder = new EKurotatoRewardStatus[]
		{
			EKurotatoRewardStatus.CanReceive,
			EKurotatoRewardStatus.Doing,
			EKurotatoRewardStatus.Taken
		};

		// Token: 0x0200BB15 RID: 47893
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x04039BE2 RID: 236514
			Caption,
			// Token: 0x04039BE3 RID: 236515
			QuestScroll,
			// Token: 0x04039BE4 RID: 236516
			QuestItem
		}
	}
}
