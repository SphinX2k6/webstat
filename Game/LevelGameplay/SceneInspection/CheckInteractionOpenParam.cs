using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.SceneInspection
{
	// Token: 0x02006B15 RID: 27413
	[RequiredMember]
	public class CheckInteractionOpenParam
	{
		// Token: 0x06043BD9 RID: 277465 RVA: 0x0117AB3D File Offset: 0x01178D3D
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public CheckInteractionOpenParam()
		{
		}

		// Token: 0x04025DF4 RID: 155124
		[Nullable(1)]
		[RequiredMember]
		public ISceneInspection Config;

		// Token: 0x04025DF5 RID: 155125
		[Nullable(2)]
		public GeneralContext Context;
	}
}
