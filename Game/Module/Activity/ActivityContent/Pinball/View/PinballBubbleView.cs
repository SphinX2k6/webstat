using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View
{
	// Token: 0x02006593 RID: 26003
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballBubbleView : UiViewBase
	{
		// Token: 0x06040F9D RID: 266141 RVA: 0x010ABD49 File Offset: 0x010A9F49
		public PinballBubbleView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x17009EBC RID: 40636
		// (get) Token: 0x06040F9E RID: 266142 RVA: 0x010ABD52 File Offset: 0x010A9F52
		[Nullable(2)]
		private new CustomPromise OpenParam
		{
			[NullableContext(2)]
			get
			{
				return this.OpenParam as CustomPromise;
			}
		}

		// Token: 0x06040F9F RID: 266143 RVA: 0x010ABD5F File Offset: 0x010A9F5F
		protected override void OnStart()
		{
			this.RootActor.OnSequencePlayEvent.Bind(new Action<string, string>(this.OnEventSequence));
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.AddSequenceFinishEvent("Bubble_In", delegate(string _)
			{
				this.OnEndSequence();
			}, false);
		}

		// Token: 0x06040FA0 RID: 266144 RVA: 0x010ABD9F File Offset: 0x010A9F9F
		private void OnEndSequence()
		{
			base.CloseMe(null);
		}

		// Token: 0x06040FA1 RID: 266145 RVA: 0x010ABDA8 File Offset: 0x010A9FA8
		protected override void OnAfterShow()
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PlaySequence("Bubble_In", false, null);
		}

		// Token: 0x06040FA2 RID: 266146 RVA: 0x010ABDD4 File Offset: 0x010A9FD4
		private void OnEventSequence(string sequenceName, string eventName)
		{
			if (eventName == "Sequence_Bubble_Switch_In")
			{
				CustomPromise openParam = this.OpenParam;
				if (openParam == null)
				{
					return;
				}
				openParam.SetResult();
			}
		}
	}
}
