using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

// Token: 0x02002558 RID: 9560
[NullableContext(2)]
public interface IPhoneMsgChatItem
{
	// Token: 0x060129DF RID: 76255
	UniTask PlayVoicePlayingAnimationAsync();

	// Token: 0x060129E0 RID: 76256
	UniTask ShowVoiceTextPanel(Action afterShow = null);

	// Token: 0x060129E1 RID: 76257
	void SkipVoicePlayingAnimation();

	// Token: 0x060129E2 RID: 76258
	void StopVoicePlayingAnimation();
}
