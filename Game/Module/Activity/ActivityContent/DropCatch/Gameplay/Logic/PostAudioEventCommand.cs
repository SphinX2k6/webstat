using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x0200692F RID: 26927
	public class PostAudioEventCommand : IDropCatchCommand
	{
		// Token: 0x06042D55 RID: 273749 RVA: 0x01127508 File Offset: 0x01125708
		[NullableContext(1)]
		public void Execute(ICommandContext context, [Nullable(2)] object @params)
		{
			IPostAudioEventCommandParams postAudioEventCommandParams = (IPostAudioEventCommandParams)@params;
			Singleton<AudioSystem>.Instance.PostEvent(postAudioEventCommandParams.Event);
		}
	}
}
