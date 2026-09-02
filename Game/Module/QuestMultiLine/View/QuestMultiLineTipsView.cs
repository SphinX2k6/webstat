using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuestMultiLine.View
{
	// Token: 0x02005324 RID: 21284
	[NullableContext(1)]
	[Nullable(0)]
	public class QuestMultiLineTipsView : UiTickViewBase
	{
		// Token: 0x06036502 RID: 222466 RVA: 0x00DB04F1 File Offset: 0x00DAE6F1
		public QuestMultiLineTipsView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06036503 RID: 222467 RVA: 0x00DB04FC File Offset: 0x00DAE6FC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06036504 RID: 222468 RVA: 0x00DB0608 File Offset: 0x00DAE808
		protected override UniTask OnBeforeStartAsync()
		{
			QuestMultiLineTipsView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<QuestMultiLineTipsView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036505 RID: 222469 RVA: 0x00DB064C File Offset: 0x00DAE84C
		protected override void OnStart()
		{
			this.TimePointId = ((QuestMultiLineTipsParam)this.OpenParam).TimePointId;
			this.EnableAnimation = ((QuestMultiLineTipsParam)this.OpenParam).EnableAnimation;
			this.CountDownTime = 0f;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "QuestBranch_OpenTips_Content", Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "QuestBranch_OpenTips_Title", Array.Empty<object>());
			this.UiViewSequence.AddSequenceFinishEvent("StartTips", new Action<string>(this.OnStartSeqFinish), false);
			this.UiViewSequence.AddSequenceFinishEvent("CloseTips", new Action<string>(this.OnCloseSeqFinish), false);
		}

		// Token: 0x06036506 RID: 222470 RVA: 0x00DB0700 File Offset: 0x00DAE900
		protected override void OnAfterShow()
		{
			this.UiViewSequence.PlaySequence("StartTips", false, null);
		}

		// Token: 0x06036507 RID: 222471 RVA: 0x00DB0728 File Offset: 0x00DAE928
		protected override void OnTick(float delta)
		{
			if (this.TimePointId == 0 || !this.StartTick)
			{
				return;
			}
			if (this.CountDownTime >= 1000f)
			{
				this.UiViewSequence.PlaySequence("CloseTips", true, null);
				this.StartTick = false;
				return;
			}
			UUISprite sprite = base.GetSprite(3);
			this.CountDownTime += delta;
			float num = Math.Max(1000f - this.CountDownTime, 0f);
			if (sprite == null)
			{
				return;
			}
			sprite.SetFillAmount(num / 1000f);
		}

		// Token: 0x06036508 RID: 222472 RVA: 0x00DB07B4 File Offset: 0x00DAE9B4
		private void OnClick()
		{
			ControllerBase<QuestMultiLineController>.Instance.OpenQuestMultiLineView(this.TimePointId, this.EnableAnimation, false);
			this.UiViewSequence.PlaySequence("CloseTips", true, null);
		}

		// Token: 0x06036509 RID: 222473 RVA: 0x00DB07F4 File Offset: 0x00DAE9F4
		private void OnStartSeqFinish(string _)
		{
			this.UiViewSequence.PlaySequence("StartAtOnce", false, null);
			this.StartTick = true;
		}

		// Token: 0x0603650A RID: 222474 RVA: 0x00DB0822 File Offset: 0x00DAEA22
		private void OnCloseSeqFinish(string _)
		{
			this.StartTick = false;
			base.CloseMe(null);
		}

		// Token: 0x0401F39E RID: 127902
		private int TimePointId;

		// Token: 0x0401F39F RID: 127903
		private bool EnableAnimation;

		// Token: 0x0401F3A0 RID: 127904
		private float CountDownTime;

		// Token: 0x0401F3A1 RID: 127905
		private bool StartTick;

		// Token: 0x0200B24F RID: 45647
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x040374A0 RID: 226464
			public const int TextName = 0;

			// Token: 0x040374A1 RID: 226465
			public const int SpriteIcon = 1;

			// Token: 0x040374A2 RID: 226466
			public const int ButtonTips = 2;

			// Token: 0x040374A3 RID: 226467
			public const int SpriteTimeBar = 3;

			// Token: 0x040374A4 RID: 226468
			public const int TextTitle = 4;
		}
	}
}
