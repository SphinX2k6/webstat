using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui.Common
{
	// Token: 0x02004A62 RID: 19042
	[NullableContext(1)]
	[Nullable(0)]
	public class UiSequenceOncePlayPanel : UiPanelBase
	{
		// Token: 0x06031BA2 RID: 203682 RVA: 0x00C73901 File Offset: 0x00C71B01
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new UiSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindOnEndSequenceEvent(new Action<string>(this.OnEndSequence));
		}

		// Token: 0x06031BA3 RID: 203683 RVA: 0x00C7392B File Offset: 0x00C71B2B
		private void OnEndSequence(string sequenceName)
		{
			if (sequenceName == this.SequenceType)
			{
				base.Destroy(null);
			}
		}

		// Token: 0x06031BA4 RID: 203684 RVA: 0x00C73944 File Offset: 0x00C71B44
		protected override void OnAfterShow()
		{
			UiSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlaySequence(this.SequenceType, false, null);
		}

		// Token: 0x06031BA5 RID: 203685 RVA: 0x00C73971 File Offset: 0x00C71B71
		protected override void OnBeforeDestroyImplement()
		{
			CustomPromise destroyPromise = this.DestroyPromise;
			if (destroyPromise == null)
			{
				return;
			}
			destroyPromise.SetResult();
		}

		// Token: 0x06031BA6 RID: 203686 RVA: 0x00C73984 File Offset: 0x00C71B84
		public static UniTask PlayAsync(string resourceId, UUIItem parentItem, string sequenceType)
		{
			UiSequenceOncePlayPanel.<PlayAsync>d__7 <PlayAsync>d__;
			<PlayAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayAsync>d__.resourceId = resourceId;
			<PlayAsync>d__.parentItem = parentItem;
			<PlayAsync>d__.sequenceType = sequenceType;
			<PlayAsync>d__.<>1__state = -1;
			<PlayAsync>d__.<>t__builder.Start<UiSequenceOncePlayPanel.<PlayAsync>d__7>(ref <PlayAsync>d__);
			return <PlayAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0401D1C8 RID: 119240
		[Nullable(2)]
		private UiSequencePlayer LevelSequencePlayer;

		// Token: 0x0401D1C9 RID: 119241
		private string SequenceType = "Start";

		// Token: 0x0401D1CA RID: 119242
		[Nullable(2)]
		public CustomPromise DestroyPromise;
	}
}
