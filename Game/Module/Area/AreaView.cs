using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Area
{
	// Token: 0x0200617B RID: 24955
	public class AreaView : UiTickViewBase
	{
		// Token: 0x0603F12F RID: 258351 RVA: 0x0102D150 File Offset: 0x0102B350
		[NullableContext(1)]
		public AreaView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603F130 RID: 258352 RVA: 0x0102D15C File Offset: 0x0102B35C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603F131 RID: 258353 RVA: 0x0102D1C5 File Offset: 0x0102B3C5
		protected override void OnStart()
		{
			this.UiViewSequence.AddSequenceFinishEvent("Start", delegate(string _)
			{
				this.IsCanClose = true;
			}, false);
		}

		// Token: 0x0603F132 RID: 258354 RVA: 0x0102D1E4 File Offset: 0x0102B3E4
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.UpdateAreaView, new Action(this.UpdateAreaView));
		}

		// Token: 0x0603F133 RID: 258355 RVA: 0x0102D202 File Offset: 0x0102B402
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.UpdateAreaView, new Action(this.UpdateAreaView));
		}

		// Token: 0x0603F134 RID: 258356 RVA: 0x0102D220 File Offset: 0x0102B420
		private void SetName()
		{
			if (base.GetText(0) != null && !string.IsNullOrEmpty(ModelBase<AreaModel>.Instance.AreaHintName))
			{
				base.GetText(0).SetText(ModelBase<AreaModel>.Instance.AreaHintName, true);
			}
		}

		// Token: 0x0603F135 RID: 258357 RVA: 0x0102D253 File Offset: 0x0102B453
		protected override void OnBeforeShow()
		{
			this.SetName();
		}

		// Token: 0x0603F136 RID: 258358 RVA: 0x0102D25B File Offset: 0x0102B45B
		protected override void OnTick(float delta)
		{
			if (this.IsCanClose && base.IsShow)
			{
				this.IsCanClose = false;
				base.CloseMe(null);
			}
		}

		// Token: 0x0603F137 RID: 258359 RVA: 0x0102D27B File Offset: 0x0102B47B
		private void UpdateAreaView()
		{
			this.UiViewSequence.ReplaySequence("Start");
			this.SetName();
		}

		// Token: 0x04023605 RID: 144901
		private bool IsCanClose;

		// Token: 0x0200C2F8 RID: 49912
		private enum EChildCom
		{
			// Token: 0x0403C19F RID: 246175
			AreaNameText,
			// Token: 0x0403C1A0 RID: 246176
			Bg
		}
	}
}
