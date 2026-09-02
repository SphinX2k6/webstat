using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FunPlay
{
	// Token: 0x02006770 RID: 26480
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class ActivityFunPlayConfig : ConfigBase<ActivityFunPlayConfig>
	{
		// Token: 0x0604202A RID: 270378 RVA: 0x010EFC59 File Offset: 0x010EDE59
		public FunPlayActivityChallenge? GetFunPlayActivityChallenge(int challengeId)
		{
			return ConfigFunPlayActivityChallengeById.GetConfig(challengeId, true);
		}

		// Token: 0x0604202B RID: 270379 RVA: 0x010EFC62 File Offset: 0x010EDE62
		public FunPlaySharpComment? GetFunPlaySharpComment(int commentId)
		{
			return ConfigFunPlaySharpCommentById.GetConfig(commentId, true);
		}
	}
}
