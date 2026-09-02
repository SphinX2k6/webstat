using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Spring25
{
	// Token: 0x02006365 RID: 25445
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ContentItem : GridProxyAbstract<Spring25InfoContentData>
	{
		// Token: 0x17009CD7 RID: 40151
		// (get) Token: 0x0603FE30 RID: 261680 RVA: 0x010633F3 File Offset: 0x010615F3
		// (set) Token: 0x0603FE31 RID: 261681 RVA: 0x010633FB File Offset: 0x010615FB
		private Spring25InfoContentData DataCache { get; set; }

		// Token: 0x17009CD8 RID: 40152
		// (get) Token: 0x0603FE32 RID: 261682 RVA: 0x01063404 File Offset: 0x01061604
		// (set) Token: 0x0603FE33 RID: 261683 RVA: 0x0106340C File Offset: 0x0106160C
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> ItemScrollView { get; set; }

		// Token: 0x17009CD9 RID: 40153
		// (get) Token: 0x0603FE34 RID: 261684 RVA: 0x01063415 File Offset: 0x01061615
		// (set) Token: 0x0603FE35 RID: 261685 RVA: 0x0106341D File Offset: 0x0106161D
		private ButtonItem ConfirmButtonItem { get; set; }

		// Token: 0x0603FE36 RID: 261686 RVA: 0x01063428 File Offset: 0x01061628
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603FE37 RID: 261687 RVA: 0x01063538 File Offset: 0x01061738
		protected override UniTask OnBeforeStartAsync()
		{
			ContentItem.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ContentItem.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FE38 RID: 261688 RVA: 0x0106357C File Offset: 0x0106177C
		public override void Refresh(Spring25InfoContentData data, bool isSelected, int gridIndex)
		{
			this.DataCache = data;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), data.NameTextId, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), data.SubtitleTextId, data.SubtitleTextArgs);
			this.ItemScrollView.RefreshByData(data.ItemList, null, false);
			UUIText text = base.GetText(2);
			if (data.RightTextId == null)
			{
				if (text != null)
				{
					text.SetUIActive(false);
				}
			}
			else
			{
				if (text != null)
				{
					text.SetUIActive(true);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.RightTextId, Array.Empty<object>());
			}
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(data.IsDone);
			}
			UUIItem item2 = base.GetItem(1);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(data.CanReward);
		}

		// Token: 0x0603FE39 RID: 261689 RVA: 0x01063647 File Offset: 0x01061847
		private CommonItemSmallItemGrid BuildItem()
		{
			return new CommonItemSmallItemGrid();
		}

		// Token: 0x0603FE3A RID: 261690 RVA: 0x0106364E File Offset: 0x0106184E
		private void HandleOnClick(int index)
		{
			Spring25InfoContentData dataCache = this.DataCache;
			bool flag;
			if (dataCache == null)
			{
				flag = false;
			}
			else
			{
				int taskId = dataCache.TaskId;
				flag = true;
			}
			if (flag)
			{
				ControllerBase<ActivitySpring25Controller>.Instance.RequestSpringSignDrawRewardRequest(this.DataCache.TaskId);
			}
		}

		// Token: 0x0200C3CB RID: 50123
		[NullableContext(0)]
		private class EContentComponent
		{
			// Token: 0x0403C4F5 RID: 247029
			public const int ConfirmEItem = 0;

			// Token: 0x0403C4F6 RID: 247030
			public const int ConfirmBItem = 1;

			// Token: 0x0403C4F7 RID: 247031
			public const int RightText = 2;

			// Token: 0x0403C4F8 RID: 247032
			public const int DoneItem = 3;

			// Token: 0x0403C4F9 RID: 247033
			public const int NameText = 4;

			// Token: 0x0403C4FA RID: 247034
			public const int NumText = 5;

			// Token: 0x0403C4FB RID: 247035
			public const int ItemScrollView = 6;
		}
	}
}
