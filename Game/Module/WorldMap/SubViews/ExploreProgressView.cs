using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews
{
	// Token: 0x02004B56 RID: 19286
	public class ExploreProgressView : UiViewBase
	{
		// Token: 0x0603261D RID: 206365 RVA: 0x00C9B99D File Offset: 0x00C99B9D
		[NullableContext(1)]
		public ExploreProgressView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603261E RID: 206366 RVA: 0x00C9B9A8 File Offset: 0x00C99BA8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClose));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603261F RID: 206367 RVA: 0x00C9BA90 File Offset: 0x00C99C90
		protected override void OnStart()
		{
			this.ExploreProgressItemScrollView = new GenericScrollView<ExploreProgressView.ExploreProgressItem>(base.GetScrollViewWithScrollbar(3), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<ExploreProgressView.ExploreProgressItem>(this.InitExploreProgressItem), null);
		}

		// Token: 0x06032620 RID: 206368 RVA: 0x00C9BAB4 File Offset: 0x00C99CB4
		[NullableContext(1)]
		private ILayoutItem<ExploreProgressView.ExploreProgressItem> InitExploreProgressItem(object rawData, UUIItem item, int index)
		{
			IOneExploreItemData oneExploreItemData = rawData as IOneExploreItemData;
			ExploreProgressView.ExploreProgressItem exploreProgressItem = new ExploreProgressView.ExploreProgressItem(item);
			exploreProgressItem.Update(new object[]
			{
				oneExploreItemData
			});
			return new LayoutItem<ExploreProgressView.ExploreProgressItem>
			{
				Key = index,
				Value = exploreProgressItem
			};
		}

		// Token: 0x06032621 RID: 206369 RVA: 0x00C9BAF7 File Offset: 0x00C99CF7
		protected override void OnBeforeDestroy()
		{
			GenericScrollView<ExploreProgressView.ExploreProgressItem> exploreProgressItemScrollView = this.ExploreProgressItemScrollView;
			if (exploreProgressItemScrollView != null)
			{
				exploreProgressItemScrollView.ClearChildren();
			}
			this.ExploreProgressItemScrollView = null;
		}

		// Token: 0x06032622 RID: 206370 RVA: 0x00C9BB14 File Offset: 0x00C99D14
		protected override void OnAfterShow()
		{
			IAreaExploreInfoData areaExploreInfo = ModelBase<WorldMapModel>.Instance.GetAreaExploreInfo();
			if (areaExploreInfo == null)
			{
				return;
			}
			AreaConfig instance = ConfigBase<AreaConfig>.Instance;
			Area? area = (instance != null) ? instance.GetAreaInfo(areaExploreInfo.AreaId) : null;
			if (area == null)
			{
				return;
			}
			AreaConfig instance2 = ConfigBase<AreaConfig>.Instance;
			string newText = (instance2 != null) ? instance2.GetAreaLocalName(area.Value.Title) : null;
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.SetText(newText, true);
			}
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), "ExplorationDegree", new <>z__ReadOnlySingleElementList<object>(areaExploreInfo.ExplorePercent));
			IAreaExploreInfoData areaExploreInfo2 = ModelBase<WorldMapModel>.Instance.GetAreaExploreInfo();
			if (((areaExploreInfo2 != null) ? areaExploreInfo2.ExploreProgress : null) != null)
			{
				GenericScrollView<ExploreProgressView.ExploreProgressItem> exploreProgressItemScrollView = this.ExploreProgressItemScrollView;
				if (exploreProgressItemScrollView == null)
				{
					return;
				}
				exploreProgressItemScrollView.RefreshByData<IOneExploreItemData>(areaExploreInfo2.ExploreProgress, null);
			}
		}

		// Token: 0x06032623 RID: 206371 RVA: 0x00C9BBF0 File Offset: 0x00C99DF0
		private void OnClose()
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.ExploreProgressView, null);
		}

		// Token: 0x0401D6A4 RID: 120484
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollView<ExploreProgressView.ExploreProgressItem> ExploreProgressItemScrollView;

		// Token: 0x0200AC25 RID: 44069
		public static class EExploreProgressDefine
		{
			// Token: 0x040358A4 RID: 219300
			public const int ConfirmButton = 0;

			// Token: 0x040358A5 RID: 219301
			public const int AreaText = 1;

			// Token: 0x040358A6 RID: 219302
			public const int ProgressText = 2;

			// Token: 0x040358A7 RID: 219303
			public const int ExploreProgressScrollView = 3;
		}

		// Token: 0x0200AC26 RID: 44070
		public class ExploreProgressItem : UiPanelBase
		{
			// Token: 0x0604BCB1 RID: 310449 RVA: 0x014A32B2 File Offset: 0x014A14B2
			[NullableContext(1)]
			public ExploreProgressItem(UUIItem uiItem)
			{
				base.CreateThenShowByActor(uiItem.GetOwner(), null);
			}

			// Token: 0x0604BCB2 RID: 310450 RVA: 0x014A32C8 File Offset: 0x014A14C8
			protected unsafe override void OnRegisterComponent()
			{
				int num = 3;
				List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
				CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
				Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
				int num2 = 0;
				*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
				this.ComponentRegisterInfos = list;
			}

			// Token: 0x0604BCB3 RID: 310451 RVA: 0x014A3354 File Offset: 0x014A1554
			[NullableContext(1)]
			public void Update(params object[] param)
			{
				if (param.Length != 0)
				{
					IOneExploreItemData oneExploreItemData = param[0] as IOneExploreItemData;
					if (oneExploreItemData != null)
					{
						WorldMapConfig instance = ConfigBase<WorldMapConfig>.Instance;
						ExploreProgress? exploreProgress = (instance != null) ? instance.GetExploreProgressInfoById(oneExploreItemData.ExploreProgressId) : null;
						if (exploreProgress == null)
						{
							return;
						}
						ExploreProgressConfig instance2 = ConfigBase<ExploreProgressConfig>.Instance;
						ExploreType? exploreType = (instance2 != null) ? instance2.GetExploreTypeByType(exploreProgress.Value.ExploreType) : null;
						if (exploreType == null)
						{
							return;
						}
						Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), exploreType.Value.Name, Array.Empty<object>());
						float num = 0f;
						if (oneExploreItemData.ExplorePercent > 0f)
						{
							num = oneExploreItemData.ExplorePercent;
						}
						Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "ExplorationDegree", new <>z__ReadOnlySingleElementList<object>(num));
						double floatPointFloor = Singleton<MathUtils>.Instance.GetFloatPointFloor(Singleton<MathUtils>.Instance.SafeDivide((double)num, 100.0), 2);
						UUISprite sprite = base.GetSprite(2);
						if (sprite == null)
						{
							return;
						}
						sprite.SetFillAmount((float)floatPointFloor);
					}
				}
			}

			// Token: 0x040358A8 RID: 219304
			private const int ONEHUNDRED = 100;

			// Token: 0x0200CED6 RID: 52950
			public static class EExploreProgressItemDefine
			{
				// Token: 0x0403FBCB RID: 261067
				public const int NameText = 0;

				// Token: 0x0403FBCC RID: 261068
				public const int PercentText = 1;

				// Token: 0x0403FBCD RID: 261069
				public const int ExpSprite = 2;
			}
		}
	}
}
