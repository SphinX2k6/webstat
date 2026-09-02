using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FeiXue
{
	// Token: 0x0200684F RID: 26703
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class FeiXuePreheatTaskItem : GridProxyAbstract<FeiXuePreheatTaskData>
	{
		// Token: 0x060428C7 RID: 272583 RVA: 0x01115044 File Offset: 0x01113244
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(7, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(6, this.OnRewardBtnClick)
			};
		}

		// Token: 0x060428C8 RID: 272584 RVA: 0x01115129 File Offset: 0x01113329
		protected override void OnStart()
		{
			this.RewardScroll = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(4), new Func<CommonItemSmallItemGrid>(this.CreateRewardItem), null, false, null);
		}

		// Token: 0x060428C9 RID: 272585 RVA: 0x0111514C File Offset: 0x0111334C
		public override void Refresh(FeiXuePreheatTaskData data, bool isSelected, int gridIndex)
		{
			this.TaskData = data;
			this.RewardScroll.RefreshByData(data.RewardList, delegate
			{
				this.RewardScroll.ScrollToLeft(0);
			}, false);
			base.GetButton(6).RootUIComp.Get().SetUIActive(data.IsUnclaimed);
			base.GetItem(5).SetUIActive(data.IsUnclaimed);
			base.GetSprite(1).SetUIActive(data.IsFinished);
			base.GetText(0).SetUIActive(data.IsLock || data.IsDoing);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), data.QuestDesc, Array.Empty<object>());
			base.GetText(7).SetUIActive(data.Target != 0);
			UUIText text = base.GetText(7);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.Current);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.Target);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			base.GetItem(2).SetUIActive(data.IsFinished);
		}

		// Token: 0x060428CA RID: 272586 RVA: 0x01115264 File Offset: 0x01113464
		private CommonItemSmallItemGrid CreateRewardItem()
		{
			return new CommonItemSmallItemGrid
			{
				ShowReceivedCallBack = ((TItem data) => this.TaskData.IsFinished)
			};
		}

		// Token: 0x040250DE RID: 151774
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScroll;

		// Token: 0x040250DF RID: 151775
		[Nullable(2)]
		private FeiXuePreheatTaskData TaskData;

		// Token: 0x040250E0 RID: 151776
		public Action OnRewardBtnClick = delegate()
		{
		};
	}
}
