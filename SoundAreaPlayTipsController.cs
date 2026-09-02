using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002A83 RID: 10883
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class SoundAreaPlayTipsController : UiControllerBase<SoundAreaPlayTipsController>
{
	// Token: 0x06015C97 RID: 89239 RVA: 0x0060B29C File Offset: 0x0060949C
	public UniTask<bool> OpenSoundAreaPlayTips(int configId)
	{
		SoundAreaPlayTipsController.<OpenSoundAreaPlayTips>d__0 <OpenSoundAreaPlayTips>d__;
		<OpenSoundAreaPlayTips>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OpenSoundAreaPlayTips>d__.configId = configId;
		<OpenSoundAreaPlayTips>d__.<>1__state = -1;
		<OpenSoundAreaPlayTips>d__.<>t__builder.Start<SoundAreaPlayTipsController.<OpenSoundAreaPlayTips>d__0>(ref <OpenSoundAreaPlayTips>d__);
		return <OpenSoundAreaPlayTips>d__.<>t__builder.Task;
	}
}
