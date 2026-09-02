using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053DA RID: 21466
	public class TransitionPopupView : UiViewBase
	{
		// Token: 0x06036CBD RID: 224445 RVA: 0x00DE65F3 File Offset: 0x00DE47F3
		[NullableContext(1)]
		public TransitionPopupView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06036CBE RID: 224446 RVA: 0x00DE65FC File Offset: 0x00DE47FC
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

		// Token: 0x06036CBF RID: 224447 RVA: 0x00DE6668 File Offset: 0x00DE4868
		protected override void OnStart()
		{
			TransitionPopupViewParams transitionPopupViewParams = this.OpenParam as TransitionPopupViewParams;
			UUIText text = base.GetText(0);
			UUIText text2 = base.GetText(1);
			if (((transitionPopupViewParams != null) ? transitionPopupViewParams.Style : null) != null)
			{
				ValueTuple<string, string> styleTexts = this.GetStyleTexts(transitionPopupViewParams.Style);
				string item = styleTexts.Item1;
				string item2 = styleTexts.Item2;
				this.ShowText(text, item);
				this.ShowText(text2, item2);
			}
			else
			{
				TransitionPopup? transitionPopup = (transitionPopupViewParams != null && transitionPopupViewParams.BoardId != null) ? ConfigTransitionPopupById.GetConfig(transitionPopupViewParams.BoardId.Value, true) : null;
				if (transitionPopup != null)
				{
					this.ShowText(text, transitionPopup.Value.Title);
					this.ShowText(text2, transitionPopup.Value.ContentText);
				}
				else
				{
					if (text != null)
					{
						text.SetUIActive(false);
					}
					if (text2 != null)
					{
						text2.SetUIActive(false);
					}
				}
			}
			if (transitionPopupViewParams == null || !transitionPopupViewParams.InPlot)
			{
				ModelBase<BattleUiModel>.Instance.ChildViewData.HideBattleView(EBattleUiVisibleReason.Plot, null, 1);
				this.IsHideBattleView = true;
				this.IsLimitOperation = true;
			}
			this.Duration = (((transitionPopupViewParams != null) ? transitionPopupViewParams.Duration : null) ?? ModelBase<PlotModel>.Instance.PlotGlobalConfig.TransitionPopupTime);
		}

		// Token: 0x06036CC0 RID: 224448 RVA: 0x00DE67C4 File Offset: 0x00DE49C4
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			0,
			2,
			2
		})]
		private ValueTuple<string, string> GetStyleTexts(ITransitionPopupStyle style)
		{
			ITransitionPopupLeftTopTip transitionPopupLeftTopTip = style as ITransitionPopupLeftTopTip;
			ValueTuple<string, string> result;
			if (transitionPopupLeftTopTip == null)
			{
				ITransitionPopupLeftBottomTransition transitionPopupLeftBottomTransition = style as ITransitionPopupLeftBottomTransition;
				if (transitionPopupLeftBottomTransition == null)
				{
					result = new ValueTuple<string, string>(null, null);
				}
				else
				{
					result = new ValueTuple<string, string>(transitionPopupLeftBottomTransition.TitleText, transitionPopupLeftBottomTransition.ContentText);
				}
			}
			else
			{
				result = new ValueTuple<string, string>(transitionPopupLeftTopTip.TitleText, transitionPopupLeftTopTip.ContentText);
			}
			return result;
		}

		// Token: 0x06036CC1 RID: 224449 RVA: 0x00DE6818 File Offset: 0x00DE4A18
		[NullableContext(2)]
		private void ShowText(UUIText textWidget, string tid)
		{
			if (!string.IsNullOrEmpty(tid))
			{
				if (textWidget != null)
				{
					textWidget.ShowTextNew(tid);
					return;
				}
			}
			else if (textWidget != null)
			{
				textWidget.SetUIActive(false);
			}
		}

		// Token: 0x06036CC2 RID: 224450 RVA: 0x00DE6837 File Offset: 0x00DE4A37
		protected override void OnAfterShow()
		{
			TimerSystem.Instance.Delay(delegate(float _)
			{
				base.CloseMe(null);
			}, this.Duration * 1000f, null, null, true, 1f);
		}

		// Token: 0x06036CC3 RID: 224451 RVA: 0x00DE6864 File Offset: 0x00DE4A64
		protected override void OnBeforeDestroy()
		{
			if (this.IsHideBattleView)
			{
				ModelBase<BattleUiModel>.Instance.ChildViewData.ShowBattleView(EBattleUiVisibleReason.Plot, 1);
			}
			this.IsLimitOperation = false;
			this.IsHideBattleView = false;
		}

		// Token: 0x0401F8E6 RID: 129254
		private bool IsHideBattleView;

		// Token: 0x0401F8E7 RID: 129255
		public bool IsLimitOperation;

		// Token: 0x0401F8E8 RID: 129256
		private float Duration;

		// Token: 0x0200B385 RID: 45957
		private static class EChildComp
		{
			// Token: 0x0403799A RID: 227738
			public const int TitleText = 0;

			// Token: 0x0403799B RID: 227739
			public const int ContentText = 1;
		}
	}
}
