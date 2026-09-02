using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelPickControl
{
	// Token: 0x02006B4F RID: 27471
	public class PickInteractionView : UiViewBase
	{
		// Token: 0x06043DFF RID: 278015 RVA: 0x0118CA93 File Offset: 0x0118AC93
		[NullableContext(1)]
		public PickInteractionView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06043E00 RID: 278016 RVA: 0x0118CA9C File Offset: 0x0118AC9C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickResetBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickBackBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickHelpInfoBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06043E01 RID: 278017 RVA: 0x0118CBAC File Offset: 0x0118ADAC
		protected override void OnStart()
		{
			ControllerBase<LevelPickInteractController>.Instance.OnClosingView = new Action(this.OnClosingView);
			ControllerBase<LevelPickInteractController>.Instance.OnViewPiecePostMoveEventStart = new Action(this.OnViewPiecePostMoveEventStart);
			ControllerBase<LevelPickInteractController>.Instance.OnViewPiecePostMoveEventEnd = new Action(this.OnViewPiecePostMoveEventEnd);
			this.IsDoingPostMoveEvent = false;
		}

		// Token: 0x06043E02 RID: 278018 RVA: 0x0118CC04 File Offset: 0x0118AE04
		private void OnClosingView()
		{
			base.GetButton(0).RootUIComp.Get().SetUIActive(false);
			base.GetButton(1).RootUIComp.Get().SetUIActive(false);
			base.GetButton(2).RootUIComp.Get().SetUIActive(false);
		}

		// Token: 0x06043E03 RID: 278019 RVA: 0x0118CC5F File Offset: 0x0118AE5F
		private void OnViewPiecePostMoveEventStart()
		{
			this.IsDoingPostMoveEvent = true;
		}

		// Token: 0x06043E04 RID: 278020 RVA: 0x0118CC68 File Offset: 0x0118AE68
		private void OnViewPiecePostMoveEventEnd()
		{
			this.IsDoingPostMoveEvent = false;
		}

		// Token: 0x06043E05 RID: 278021 RVA: 0x0118CC71 File Offset: 0x0118AE71
		private void OnClickResetBtn()
		{
			ControllerBase<LevelPickInteractController>.Instance.ResetPickInteractGame();
		}

		// Token: 0x06043E06 RID: 278022 RVA: 0x0118CC7D File Offset: 0x0118AE7D
		private void OnClickBackBtn()
		{
			this.OnClosingView();
			ControllerBase<LevelPickInteractController>.Instance.ExitPickInteractModel(false);
		}

		// Token: 0x06043E07 RID: 278023 RVA: 0x0118CC90 File Offset: 0x0118AE90
		private void OnClickHelpInfoBtn()
		{
			if (this.IsDoingPostMoveEvent)
			{
				return;
			}
			int? intConfig = ConfigCommonParamById.GetIntConfig("PickInteractionViewTutorialId");
			if (intConfig != null)
			{
				ControllerBase<HelpController>.Instance.OpenHelpById(intConfig.Value);
			}
		}

		// Token: 0x04025F7F RID: 155519
		private bool IsDoingPostMoveEvent;

		// Token: 0x0200CA3C RID: 51772
		public enum EPickInteractionViewComponent
		{
			// Token: 0x0403E1D6 RID: 254422
			ResetBtn,
			// Token: 0x0403E1D7 RID: 254423
			CloseBtn,
			// Token: 0x0403E1D8 RID: 254424
			HelpInfoBtn
		}
	}
}
