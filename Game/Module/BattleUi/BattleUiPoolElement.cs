using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F82 RID: 24450
	public class BattleUiPoolElement
	{
		// Token: 0x0603D636 RID: 251446 RVA: 0x00F9D98C File Offset: 0x00F9BB8C
		public void Clear()
		{
			if (this.ActorList != null)
			{
				foreach (AActor actor in this.ActorList)
				{
					Singleton<ActorSystem>.Instance.Put("BattleUiPool.Clear", actor, null);
				}
				this.ActorList.Clear();
			}
			this.Actor = null;
		}

		// Token: 0x040227BF RID: 141247
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<AActor> ActorList;

		// Token: 0x040227C0 RID: 141248
		public bool ExistMulti = true;

		// Token: 0x040227C1 RID: 141249
		[Nullable(2)]
		public AActor Actor;
	}
}
