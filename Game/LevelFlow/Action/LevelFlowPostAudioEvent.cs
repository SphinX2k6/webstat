using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006FA0 RID: 28576
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelFlowPostAudioEvent : LevelFlowActionBase
	{
		// Token: 0x060451F9 RID: 283129 RVA: 0x01208D9D File Offset: 0x01206F9D
		public LevelFlowPostAudioEvent Init(string audioEventName)
		{
			this.AudioEventName = audioEventName;
			return this;
		}

		// Token: 0x060451FA RID: 283130 RVA: 0x01208DA7 File Offset: 0x01206FA7
		protected override void OnExecute()
		{
			Singleton<AudioSystem>.Instance.PostEvent(this.AudioEventName);
			base.FinishExecute(true);
		}

		// Token: 0x04026915 RID: 157973
		private string AudioEventName = string.Empty;
	}
}
