using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B4D RID: 23373
	public class RewardExploreAccumulatedScoreItem : UiPanelBase
	{
		// Token: 0x0603B231 RID: 242225 RVA: 0x00EF63E0 File Offset: 0x00EF45E0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B232 RID: 242226 RVA: 0x00EF64D0 File Offset: 0x00EF46D0
		protected override void OnStart()
		{
			this.DetailScoreLayout = new GenericLayout<RewardExploreAccumulatedScoreItem.ScoreItem, IAccumulatedScoreLineData>(base.GetVerticalLayout(0), new Func<RewardExploreAccumulatedScoreItem.ScoreItem>(this.CreateScoreItem), null, false, true);
			this.TotalScoreLayout = new GenericLayout<RewardExploreAccumulatedScoreItem.ScoreItem, IAccumulatedScoreLineData>(base.GetVerticalLayout(2), new Func<RewardExploreAccumulatedScoreItem.ScoreItem>(this.CreateScoreItem), null, false, true);
		}

		// Token: 0x0603B233 RID: 242227 RVA: 0x00EF651F File Offset: 0x00EF471F
		[NullableContext(1)]
		private RewardExploreAccumulatedScoreItem.ScoreItem CreateScoreItem()
		{
			return new RewardExploreAccumulatedScoreItem.ScoreItem();
		}

		// Token: 0x0603B234 RID: 242228 RVA: 0x00EF6528 File Offset: 0x00EF4728
		[NullableContext(1)]
		public void Refresh(AccumulatedScoreData data)
		{
			List<IAccumulatedScoreLineData> list = data.DetailScoreDataList;
			if (list != null)
			{
				GenericLayout<RewardExploreAccumulatedScoreItem.ScoreItem, IAccumulatedScoreLineData> detailScoreLayout = this.DetailScoreLayout;
				if (detailScoreLayout != null)
				{
					detailScoreLayout.RefreshByData(list, null, false);
				}
			}
			list = data.TotalScoreDataList;
			if (list != null)
			{
				GenericLayout<RewardExploreAccumulatedScoreItem.ScoreItem, IAccumulatedScoreLineData> totalScoreLayout = this.TotalScoreLayout;
				if (totalScoreLayout != null)
				{
					totalScoreLayout.RefreshByData(list, null, false);
				}
			}
			int curScore = data.CurScore;
			int maxScore = data.MaxScore;
			bool flag = curScore >= maxScore;
			if (!flag)
			{
				UUIText text = base.GetText(4);
				if (text != null)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
					defaultInterpolatedStringHandler.AppendFormatted<int>(curScore);
					defaultInterpolatedStringHandler.AppendLiteral("/");
					defaultInterpolatedStringHandler.AppendFormatted<int>(maxScore);
					text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				}
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "riskofrain_UIScore", new <>z__ReadOnlyArray<object>(new object[]
				{
					curScore,
					maxScore
				}));
			}
			base.GetItem(5).SetUIActive(flag);
		}

		// Token: 0x04021573 RID: 136563
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RewardExploreAccumulatedScoreItem.ScoreItem, IAccumulatedScoreLineData> DetailScoreLayout;

		// Token: 0x04021574 RID: 136564
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RewardExploreAccumulatedScoreItem.ScoreItem, IAccumulatedScoreLineData> TotalScoreLayout;

		// Token: 0x0200BB4A RID: 47946
		private class EChildType
		{
			// Token: 0x04039CCF RID: 236751
			public const int DetailScoreLayout = 0;

			// Token: 0x04039CD0 RID: 236752
			public const int DetailScoreTemplateItem = 1;

			// Token: 0x04039CD1 RID: 236753
			public const int TotalScoreLayout = 2;

			// Token: 0x04039CD2 RID: 236754
			public const int TotalScoreTemplateItem = 3;

			// Token: 0x04039CD3 RID: 236755
			public const int LimitScoreText = 4;

			// Token: 0x04039CD4 RID: 236756
			public const int ArriveMaxScoreItem = 5;
		}

		// Token: 0x0200BB4B RID: 47947
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public class ScoreItem : GridProxyAbstract<IAccumulatedScoreLineData>
		{
			// Token: 0x0604D9AB RID: 317867 RVA: 0x0157000C File Offset: 0x0156E20C
			protected unsafe override void OnRegisterComponent()
			{
				int num = 2;
				List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
				CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
				Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
				int num2 = 0;
				*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
				this.ComponentRegisterInfos = list;
			}

			// Token: 0x0604D9AC RID: 317868 RVA: 0x01570075 File Offset: 0x0156E275
			[NullableContext(1)]
			public override void Refresh(IAccumulatedScoreLineData data, bool isSelected, int gridIndex)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.DescTextId, Array.Empty<object>());
				base.GetText(1).SetText(data.ScoreText, true);
			}

			// Token: 0x0200CF3C RID: 53052
			private class EScoreItemComponent
			{
				// Token: 0x0403FD74 RID: 261492
				public const int DescText = 0;

				// Token: 0x0403FD75 RID: 261493
				public const int ScoreText = 1;
			}
		}
	}
}
