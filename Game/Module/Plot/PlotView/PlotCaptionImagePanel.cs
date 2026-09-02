using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053B6 RID: 21430
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotCaptionImagePanel : UiPanelBase
	{
		// Token: 0x06036A71 RID: 223857 RVA: 0x00DD8887 File Offset: 0x00DD6A87
		protected override void OnRegisterComponent()
		{
		}

		// Token: 0x06036A72 RID: 223858 RVA: 0x00DD8889 File Offset: 0x00DD6A89
		protected override void OnStart()
		{
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
		}

		// Token: 0x06036A73 RID: 223859 RVA: 0x00DD889C File Offset: 0x00DD6A9C
		protected override void OnBeforeDestroy()
		{
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
		}

		// Token: 0x06036A74 RID: 223860 RVA: 0x00DD88B8 File Offset: 0x00DD6AB8
		public UniTask PlaySequenceAsync(string sequenceName)
		{
			PlotCaptionImagePanel.<PlaySequenceAsync>d__4 <PlaySequenceAsync>d__;
			<PlaySequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlaySequenceAsync>d__.<>4__this = this;
			<PlaySequenceAsync>d__.sequenceName = sequenceName;
			<PlaySequenceAsync>d__.<>1__state = -1;
			<PlaySequenceAsync>d__.<>t__builder.Start<PlotCaptionImagePanel.<PlaySequenceAsync>d__4>(ref <PlaySequenceAsync>d__);
			return <PlaySequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0401F7B7 RID: 128951
		private UiSequencePlayer SequencePlayer;
	}
}
