using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BE4 RID: 27620
	internal class NotifyData
	{
		// Token: 0x0402606C RID: 155756
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<AiController> Entities;

		// Token: 0x0402606D RID: 155757
		[Nullable(2)]
		public BaseActorComponent Target;
	}
}
