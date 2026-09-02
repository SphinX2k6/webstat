using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063D5 RID: 25557
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeSubViewEvent : RoverlikeActionSubViewBase
	{
		// Token: 0x17009DB8 RID: 40376
		// (get) Token: 0x060402C1 RID: 262849 RVA: 0x01072255 File Offset: 0x01070455
		public override ERoverActionSubViewType SubViewType
		{
			get
			{
				return ERoverActionSubViewType.SelectEvent;
			}
		}

		// Token: 0x17009DB9 RID: 40377
		// (get) Token: 0x060402C2 RID: 262850 RVA: 0x01072258 File Offset: 0x01070458
		public override string ResourceId
		{
			get
			{
				return "UiItem_RoverlikeGameEvent";
			}
		}

		// Token: 0x060402C3 RID: 262851 RVA: 0x01072260 File Offset: 0x01070460
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnBtnConfirmClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060402C4 RID: 262852 RVA: 0x01072348 File Offset: 0x01070548
		protected override void OnStart()
		{
			this.EventChoiceLayout = new GenericScrollViewNew<RoverlikeEventChoiceItem, IRoverlikeEventChoiceData>(base.GetScrollViewWithScrollbar(3), new Func<RoverlikeEventChoiceItem>(this.CreateEventChoiceItem), base.GetItem(1).GetOwner() as AUIBaseActor, false, null);
		}

		// Token: 0x060402C5 RID: 262853 RVA: 0x0107237B File Offset: 0x0107057B
		protected override void OnBeforeDestroy()
		{
			this.ChoiceList.Clear();
			this.SelectedChoiceId = -1;
			this.EventIncId = 0;
		}

		// Token: 0x060402C6 RID: 262854 RVA: 0x01072396 File Offset: 0x01070596
		private void OnBtnConfirmClick()
		{
			base.TryInteractAction(delegate
			{
				if (this.SelectedChoiceId < 0)
				{
					return;
				}
				ControllerBase<RoverlikeController>.Instance.RoverRogueEventSelectRequest(this.EventIncId, this.SelectedChoiceId, delegate(bool isSuccess)
				{
					if (isSuccess)
					{
						ControllerBase<RoverlikeController>.Instance.FinishActionSubView(this.IncId);
					}
				});
			});
		}

		// Token: 0x060402C7 RID: 262855 RVA: 0x010723AB File Offset: 0x010705AB
		private void OnEventChoiceItemSelect(IRoverlikeEventChoiceData data)
		{
			if (data.ConfigId == this.SelectedChoiceId)
			{
				return;
			}
			this.SelectedChoiceId = data.ConfigId;
			this.RefreshEventChoiceSelection();
			this.RefreshButtonState();
		}

		// Token: 0x060402C8 RID: 262856 RVA: 0x010723D4 File Offset: 0x010705D4
		private RoverlikeEventChoiceItem CreateEventChoiceItem()
		{
			RoverlikeEventChoiceItem roverlikeEventChoiceItem = new RoverlikeEventChoiceItem();
			roverlikeEventChoiceItem.BindOnItemSelect(new Action<IRoverlikeEventChoiceData>(this.OnEventChoiceItemSelect));
			return roverlikeEventChoiceItem;
		}

		// Token: 0x060402C9 RID: 262857 RVA: 0x010723F0 File Offset: 0x010705F0
		private void RefreshEventChoiceLayout()
		{
			if (this.ChoiceList.Count == 0)
			{
				return;
			}
			List<IRoverlikeEventChoiceData> list = new List<IRoverlikeEventChoiceData>();
			foreach (int configId in this.ChoiceList)
			{
				RoverlikeEventChoiceData item = new RoverlikeEventChoiceData
				{
					ConfigId = configId
				};
				list.Add(item);
			}
			this.EventChoiceLayout.RefreshByData(list, new Action(this.OnEventChoiceLayoutRefreshed), true);
		}

		// Token: 0x060402CA RID: 262858 RVA: 0x01072480 File Offset: 0x01070680
		private void OnEventChoiceLayoutRefreshed()
		{
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "RoverlikeEvent");
		}

		// Token: 0x060402CB RID: 262859 RVA: 0x01072498 File Offset: 0x01070698
		private void RefreshEventChoiceSelection()
		{
			int num = this.ChoiceList.IndexOf(this.SelectedChoiceId);
			if (num >= 0)
			{
				this.EventChoiceLayout.SelectGridProxy(num, false);
			}
		}

		// Token: 0x060402CC RID: 262860 RVA: 0x010724C8 File Offset: 0x010706C8
		private void RefreshButtonState()
		{
			UUIButtonComponent button = base.GetButton(2);
			if (button == null)
			{
				return;
			}
			button.SetSelfInteractive(this.SelectedChoiceId >= 0);
		}

		// Token: 0x060402CD RID: 262861 RVA: 0x010724E8 File Offset: 0x010706E8
		public override void OnRefreshSubView()
		{
			IRoverlikeEventOpenParam roverlikeEventOpenParam = this.OpenParam as IRoverlikeEventOpenParam;
			if (roverlikeEventOpenParam == null || roverlikeEventOpenParam.ChoiceList.Count == 0)
			{
				return;
			}
			this.EventIncId = roverlikeEventOpenParam.EventIncId;
			this.ChoiceList = roverlikeEventOpenParam.ChoiceList;
			this.SelectedChoiceId = -1;
			this.RefreshEventChoiceLayout();
			this.RefreshButtonState();
		}

		// Token: 0x04024001 RID: 147457
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<RoverlikeEventChoiceItem, IRoverlikeEventChoiceData> EventChoiceLayout;

		// Token: 0x04024002 RID: 147458
		private int EventIncId;

		// Token: 0x04024003 RID: 147459
		private List<int> ChoiceList = new List<int>();

		// Token: 0x04024004 RID: 147460
		private int SelectedChoiceId = -1;

		// Token: 0x0200C438 RID: 50232
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C675 RID: 247413
			public const int TexRole = 0;

			// Token: 0x0403C676 RID: 247414
			public const int ItemEventChoice = 1;

			// Token: 0x0403C677 RID: 247415
			public const int BtnConfirm = 2;

			// Token: 0x0403C678 RID: 247416
			public const int EventScroll = 3;
		}
	}
}
