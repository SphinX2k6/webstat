using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005ECC RID: 24268
	[NullableContext(1)]
	[Nullable(0)]
	public class CiacconaGalChapterEntryView : UiViewBase
	{
		// Token: 0x0603CFD9 RID: 249817 RVA: 0x00F7D9AA File Offset: 0x00F7BBAA
		public CiacconaGalChapterEntryView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603CFDA RID: 249818 RVA: 0x00F7D9B4 File Offset: 0x00F7BBB4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603CFDB RID: 249819 RVA: 0x00F7DAA4 File Offset: 0x00F7BCA4
		protected override UniTask OnBeforeStartAsync()
		{
			CiacconaGalChapterEntryView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CiacconaGalChapterEntryView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603CFDC RID: 249820 RVA: 0x00F7DAE7 File Offset: 0x00F7BCE7
		protected override void OnBeforeShow()
		{
			this.RefreshView();
		}

		// Token: 0x0603CFDD RID: 249821 RVA: 0x00F7DAF0 File Offset: 0x00F7BCF0
		private void RefreshView()
		{
			this.Data = (this.OpenParam as CiacconaGalActivityData);
			List<CiacconaGalChapterSlotData> list = new List<CiacconaGalChapterSlotData>();
			foreach (int id in this.Data.SlotIds)
			{
				CiacconaGalChapterSlotData chapterSlotDataById = ModelBase<CiacconaGalModel>.Instance.GetChapterSlotDataById(id);
				if (chapterSlotDataById != null)
				{
					list.Add(chapterSlotDataById);
				}
			}
			this.LayoutChapter.RefreshByData(list, null, false);
			this.CiacconaEndingRewardItem.SetRedDotVisible(ModelBase<CiacconaGalModel>.Instance.HasAnyEndingReward());
			ValueTuple<int, int> endingProgress = ModelBase<CiacconaGalModel>.Instance.GetEndingProgress();
			CiacconaGalRewardButtonItem ciacconaEndingRewardItem = this.CiacconaEndingRewardItem;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(endingProgress.Item1);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(endingProgress.Item2);
			ciacconaEndingRewardItem.SetProgressText(defaultInterpolatedStringHandler.ToStringAndClear());
			this.CiacconaProgressRewardItem.SetRedDotVisible(ModelBase<CiacconaGalModel>.Instance.HasAnyProgressReward());
			this.CiacconaProgressRewardItem.SetUiActive(ModelBase<CiacconaGalModel>.Instance.ActivityData.IsInRewardTime);
			ValueTuple<int, int> progressRewardProgress = ModelBase<CiacconaGalModel>.Instance.GetProgressRewardProgress();
			CiacconaGalRewardButtonItem ciacconaProgressRewardItem = this.CiacconaProgressRewardItem;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(progressRewardProgress.Item1);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(progressRewardProgress.Item2);
			ciacconaProgressRewardItem.SetProgressText(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x0603CFDE RID: 249822 RVA: 0x00F7DC3C File Offset: 0x00F7BE3C
		private CiacconaGalChapterEntryItem GetChapterEntryItem()
		{
			return new CiacconaGalChapterEntryItem();
		}

		// Token: 0x0603CFDF RID: 249823 RVA: 0x00F7DC43 File Offset: 0x00F7BE43
		private void OnEndingRewardClick()
		{
			ControllerBase<CiacconaGalController>.Instance.OpenEndingView();
		}

		// Token: 0x0603CFE0 RID: 249824 RVA: 0x00F7DC4F File Offset: 0x00F7BE4F
		private void OnProgressRewardClick()
		{
			ControllerBase<CiacconaGalController>.Instance.OpenRewardViewByActivityId(this.Data.Id);
		}

		// Token: 0x0603CFE1 RID: 249825 RVA: 0x00F7DC68 File Offset: 0x00F7BE68
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			GenericLayout<CiacconaGalChapterEntryItem, CiacconaGalChapterSlotData> layoutChapter = this.LayoutChapter;
			UUIItem uuiitem = (layoutChapter != null) ? layoutChapter.GetGridByDisplayIndex(0) : null;
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}

		// Token: 0x040223AD RID: 140205
		private PopupCaptionItem Caption;

		// Token: 0x040223AE RID: 140206
		private GenericLayout<CiacconaGalChapterEntryItem, CiacconaGalChapterSlotData> LayoutChapter;

		// Token: 0x040223AF RID: 140207
		private CiacconaTitleInspirationItem CiacconaTitleItem;

		// Token: 0x040223B0 RID: 140208
		private CiacconaGalRewardButtonItem CiacconaEndingRewardItem;

		// Token: 0x040223B1 RID: 140209
		private CiacconaGalRewardButtonItem CiacconaProgressRewardItem;

		// Token: 0x040223B2 RID: 140210
		private CiacconaGalActivityData Data;

		// Token: 0x0200BEC7 RID: 48839
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403AB7E RID: 240510
			public const int ItemCaption = 0;

			// Token: 0x0403AB7F RID: 240511
			public const int LayoutChapter = 1;

			// Token: 0x0403AB80 RID: 240512
			public const int ItemChapter = 2;

			// Token: 0x0403AB81 RID: 240513
			public const int ItemEndingReward = 3;

			// Token: 0x0403AB82 RID: 240514
			public const int ItemProgressReward = 4;

			// Token: 0x0403AB83 RID: 240515
			public const int TextTitle = 5;
		}
	}
}
