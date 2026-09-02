using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EDC RID: 24284
	[NullableContext(1)]
	[Nullable(0)]
	public class CiacconaActivityRewardView : UiTickViewBase
	{
		// Token: 0x0603D048 RID: 249928 RVA: 0x00F7F808 File Offset: 0x00F7DA08
		public CiacconaActivityRewardView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603D049 RID: 249929 RVA: 0x00F7F814 File Offset: 0x00F7DA14
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D04A RID: 249930 RVA: 0x00F7F904 File Offset: 0x00F7DB04
		protected override UniTask OnBeforeStartAsync()
		{
			CiacconaActivityRewardView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CiacconaActivityRewardView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D04B RID: 249931 RVA: 0x00F7F948 File Offset: 0x00F7DB48
		protected override void OnStart()
		{
			this.ScrollView = new GenericScrollViewNew<CiacconaActivityRewardItem, CiacconaGalRewardData>(base.GetScrollViewWithScrollbar(3), new Func<CiacconaActivityRewardItem>(this.CreateItem), null, false, null);
			this.Refresh();
			GenericScrollViewNew<CiacconaActivityRewardItem, CiacconaGalRewardData> scrollView = this.ScrollView;
			if (scrollView != null)
			{
				scrollView.PlayTurnAnimation();
			}
			Singleton<EventSystem>.Instance.Add(EEventName.OnCiacconaRewardDataUpdate, new Action(this.OnDataUpdate));
		}

		// Token: 0x0603D04C RID: 249932 RVA: 0x00F7F9A9 File Offset: 0x00F7DBA9
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCiacconaRewardDataUpdate, new Action(this.OnDataUpdate));
		}

		// Token: 0x0603D04D RID: 249933 RVA: 0x00F7F9C7 File Offset: 0x00F7DBC7
		protected override void OnTick(float _)
		{
			this.RefreshTimeStr();
		}

		// Token: 0x0603D04E RID: 249934 RVA: 0x00F7F9D0 File Offset: 0x00F7DBD0
		private void Refresh()
		{
			CiacconaGalRewardData[] allRewardDataByActivityId = ModelBase<CiacconaGalModel>.Instance.GetAllRewardDataByActivityId(this.ActivityData.Id);
			GenericScrollViewNew<CiacconaActivityRewardItem, CiacconaGalRewardData> scrollView = this.ScrollView;
			if (scrollView != null)
			{
				scrollView.RefreshByData(allRewardDataByActivityId.ToList<CiacconaGalRewardData>(), null, false);
			}
			ValueTuple<int, int> progressRewardProgress = ModelBase<CiacconaGalModel>.Instance.GetProgressRewardProgress();
			int item = progressRewardProgress.Item1;
			int item2 = progressRewardProgress.Item2;
			UUIText text = base.GetText(1);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(item);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(item2);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			base.GetSprite(2).fillAmount = (float)item * 1f / (float)((item2 == 0) ? 1 : item2);
		}

		// Token: 0x0603D04F RID: 249935 RVA: 0x00F7FA7C File Offset: 0x00F7DC7C
		private void RefreshTimeStr()
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("Xkjsx_Rewards_Timeless", null);
			string rewardRemainTimeStr = this.ActivityData.RewardRemainTimeStr;
			string newText = localTextNew + " " + rewardRemainTimeStr;
			UUIText text = base.GetText(5);
			if (text == null)
			{
				return;
			}
			text.SetText(newText, true);
		}

		// Token: 0x0603D050 RID: 249936 RVA: 0x00F7FABF File Offset: 0x00F7DCBF
		private CiacconaActivityRewardItem CreateItem()
		{
			return new CiacconaActivityRewardItem();
		}

		// Token: 0x0603D051 RID: 249937 RVA: 0x00F7FAC6 File Offset: 0x00F7DCC6
		private void OnDataUpdate()
		{
			this.Refresh();
		}

		// Token: 0x040223DB RID: 140251
		private PopupCaptionItem ItemCaption;

		// Token: 0x040223DC RID: 140252
		private GenericScrollViewNew<CiacconaActivityRewardItem, CiacconaGalRewardData> ScrollView;

		// Token: 0x040223DD RID: 140253
		private CiacconaGalActivityData ActivityData;

		// Token: 0x0200BEDC RID: 48860
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403ABDF RID: 240607
			public const int ItemCaption = 0;

			// Token: 0x0403ABE0 RID: 240608
			public const int TextNum = 1;

			// Token: 0x0403ABE1 RID: 240609
			public const int SpriteProgress = 2;

			// Token: 0x0403ABE2 RID: 240610
			public const int ScrollView = 3;

			// Token: 0x0403ABE3 RID: 240611
			public const int ItemTask = 4;

			// Token: 0x0403ABE4 RID: 240612
			public const int TextTime = 5;
		}
	}
}
