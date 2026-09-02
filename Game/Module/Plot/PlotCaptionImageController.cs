using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot.PlotView;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x02005352 RID: 21330
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class PlotCaptionImageController : ControllerBase<PlotCaptionImageController>
	{
		// Token: 0x06036685 RID: 222853 RVA: 0x00DB80AC File Offset: 0x00DB62AC
		[NullableContext(1)]
		public UniTask OpenAsync(string uiPrefabId, float duration, [Nullable(2)] IUiAnimConfig uiAnimConfig)
		{
			PlotCaptionImageController.<OpenAsync>d__2 <OpenAsync>d__;
			<OpenAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenAsync>d__.<>4__this = this;
			<OpenAsync>d__.uiPrefabId = uiPrefabId;
			<OpenAsync>d__.duration = duration;
			<OpenAsync>d__.uiAnimConfig = uiAnimConfig;
			<OpenAsync>d__.<>1__state = -1;
			<OpenAsync>d__.<>t__builder.Start<PlotCaptionImageController.<OpenAsync>d__2>(ref <OpenAsync>d__);
			return <OpenAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036686 RID: 222854 RVA: 0x00DB8108 File Offset: 0x00DB6308
		private UniTask WaitCloseAsync(float duration, IUiAnimConfig uiAnimConfig)
		{
			PlotCaptionImageController.<WaitCloseAsync>d__3 <WaitCloseAsync>d__;
			<WaitCloseAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitCloseAsync>d__.<>4__this = this;
			<WaitCloseAsync>d__.duration = duration;
			<WaitCloseAsync>d__.uiAnimConfig = uiAnimConfig;
			<WaitCloseAsync>d__.<>1__state = -1;
			<WaitCloseAsync>d__.<>t__builder.Start<PlotCaptionImageController.<WaitCloseAsync>d__3>(ref <WaitCloseAsync>d__);
			return <WaitCloseAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036687 RID: 222855 RVA: 0x00DB815C File Offset: 0x00DB635C
		private UniTask WaitDurationAsync(float duration)
		{
			PlotCaptionImageController.<WaitDurationAsync>d__4 <WaitDurationAsync>d__;
			<WaitDurationAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitDurationAsync>d__.duration = duration;
			<WaitDurationAsync>d__.<>1__state = -1;
			<WaitDurationAsync>d__.<>t__builder.Start<PlotCaptionImageController.<WaitDurationAsync>d__4>(ref <WaitDurationAsync>d__);
			return <WaitDurationAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036688 RID: 222856 RVA: 0x00DB819F File Offset: 0x00DB639F
		private void DestroyPanel()
		{
			if (this.CurrentPanel != null)
			{
				this.CurrentPanel.Destroy(null);
				this.CurrentPanel = null;
				Singleton<EventSystem>.Instance.Emit<EUiViewName>(EEventName.ClosePlotCaptionImageView, EUiViewName.PlotCaptionImageView);
			}
			this.IsInPlotCaption = false;
		}

		// Token: 0x06036689 RID: 222857 RVA: 0x00DB81D8 File Offset: 0x00DB63D8
		protected override bool OnClear()
		{
			this.DestroyPanel();
			return true;
		}

		// Token: 0x0401F491 RID: 128145
		private PlotCaptionImagePanel CurrentPanel;

		// Token: 0x0401F492 RID: 128146
		public bool IsInPlotCaption;
	}
}
