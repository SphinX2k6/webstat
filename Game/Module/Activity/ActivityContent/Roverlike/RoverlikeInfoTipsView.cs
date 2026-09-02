using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200640C RID: 25612
	public class RoverlikeInfoTipsView : UiTickViewBase
	{
		// Token: 0x060404D4 RID: 263380 RVA: 0x0107B366 File Offset: 0x01079566
		[NullableContext(1)]
		public RoverlikeInfoTipsView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060404D5 RID: 263381 RVA: 0x0107B370 File Offset: 0x01079570
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060404D6 RID: 263382 RVA: 0x0107B3B8 File Offset: 0x010795B8
		protected override void OnStart()
		{
			if (ModelBase<RoverlikeModel>.Instance.IsFloatTextEmpty)
			{
				base.CloseMe(null);
				return;
			}
			UUIItem item = base.GetItem(1);
			item.SetUIActive(false);
			this.ListSlideControl = new ListSliderControl<FloatTipsItem>(new ListSliderControlData<FloatTipsItem>(base.GetRootItem(), new Func<FloatTipsItem>(this.CreateProxyFunction), new Func<bool>(this.CheckNext))
			{
				ChildTemplate = item,
				MaxShowCount = new int?(2),
				AddItemTime = new float?((float)200),
				ItemShowTime = new float?((float)1500),
				ItemSliderTime = new float?((float)200),
				TickMode = new ETickItemMode?(ETickItemMode.TickOnlyTop),
				FinishCallback = new Action(this.FinishCallback)
			});
			this.ListSlideControl.DisEnableParentLayout();
		}

		// Token: 0x060404D7 RID: 263383 RVA: 0x0107B487 File Offset: 0x01079687
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x060404D8 RID: 263384 RVA: 0x0107B489 File Offset: 0x01079689
		protected override void OnTick(float delta)
		{
			ListSliderControl<FloatTipsItem> listSlideControl = this.ListSlideControl;
			if (listSlideControl == null)
			{
				return;
			}
			listSlideControl.Tick(delta);
		}

		// Token: 0x060404D9 RID: 263385 RVA: 0x0107B49C File Offset: 0x0107969C
		[NullableContext(1)]
		private FloatTipsItem CreateProxyFunction()
		{
			return new FloatTipsItem();
		}

		// Token: 0x060404DA RID: 263386 RVA: 0x0107B4A3 File Offset: 0x010796A3
		private bool CheckNext()
		{
			return !ModelBase<RoverlikeModel>.Instance.IsFloatTextEmpty;
		}

		// Token: 0x060404DB RID: 263387 RVA: 0x0107B4B2 File Offset: 0x010796B2
		private void FinishCallback()
		{
			base.CloseMe(null);
		}

		// Token: 0x040240A6 RID: 147622
		private const int MAX_LIST_COUNT = 2;

		// Token: 0x040240A7 RID: 147623
		private const int ITEM_INTERVAL_TIME = 200;

		// Token: 0x040240A8 RID: 147624
		private const int ITEM_SLIDER_TIME = 200;

		// Token: 0x040240A9 RID: 147625
		private const int ITEM_SHOW_TIME = 1500;

		// Token: 0x040240AA RID: 147626
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private ListSliderControl<FloatTipsItem> ListSlideControl;

		// Token: 0x0200C474 RID: 50292
		private class EComponents
		{
			// Token: 0x0403C787 RID: 247687
			public const int RootItem = 0;

			// Token: 0x0403C788 RID: 247688
			public const int FloatTipsItem = 1;
		}
	}
}
