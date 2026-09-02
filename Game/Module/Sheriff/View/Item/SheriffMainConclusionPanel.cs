using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View.Item
{
	// Token: 0x02004FE8 RID: 20456
	public class SheriffMainConclusionPanel : UiTabViewBase
	{
		// Token: 0x06034BD1 RID: 216017 RVA: 0x00D3B1A0 File Offset: 0x00D393A0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickBtnSkyEyeConfirm));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickBtnSkyEyeConfirmWhile));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06034BD2 RID: 216018 RVA: 0x00D3B2AC File Offset: 0x00D394AC
		protected override void OnStart()
		{
			this.Proxy = (this.ExtraParams as SheriffMainProxy);
			UUIButtonComponent button = base.GetButton(2);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(false);
			}
			this.InfoScrollView = new GenericScrollViewNew<SheriffMainConclusionInfo, int>(base.GetScrollViewWithScrollbar(0), new Func<SheriffMainConclusionInfo>(this.CreateInfoItem), null, false, null);
			List<int> questionList = this.Proxy.GetQuestionList();
			this.InfoScrollView.RefreshByData(questionList, null, true);
		}

		// Token: 0x06034BD3 RID: 216019 RVA: 0x00D3B328 File Offset: 0x00D39528
		protected override void OnBeforeShow()
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PlayOrReplaySequenceByName("Start", false, null);
		}

		// Token: 0x06034BD4 RID: 216020 RVA: 0x00D3B354 File Offset: 0x00D39554
		[NullableContext(1)]
		private SheriffMainConclusionInfo CreateInfoItem()
		{
			return new SheriffMainConclusionInfo(this.Proxy);
		}

		// Token: 0x06034BD5 RID: 216021 RVA: 0x00D3B361 File Offset: 0x00D39561
		private void OnClickBtnSkyEyeConfirm()
		{
			this.Proxy.RestartGameplay();
		}

		// Token: 0x06034BD6 RID: 216022 RVA: 0x00D3B36E File Offset: 0x00D3956E
		private void OnClickBtnSkyEyeConfirmWhile()
		{
			this.Proxy.RequestConfirm().Then(delegate(bool value)
			{
				if (value)
				{
					this.Proxy.CloseGameplay();
				}
			});
		}

		// Token: 0x0401E639 RID: 124473
		[Nullable(2)]
		protected SheriffMainProxy Proxy;

		// Token: 0x0401E63A RID: 124474
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<SheriffMainConclusionInfo, int> InfoScrollView;

		// Token: 0x0200AFC3 RID: 44995
		private static class EDefine
		{
			// Token: 0x0403689A RID: 223386
			public const int SvMulti = 0;

			// Token: 0x0403689B RID: 223387
			public const int PanelClue = 1;

			// Token: 0x0403689C RID: 223388
			public const int BtnSkyEyeConfirm = 2;

			// Token: 0x0403689D RID: 223389
			public const int BtnSkyEyeConfirmWhile = 3;
		}
	}
}
