using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Interface
{
	// Token: 0x02006AE5 RID: 27365
	[NullableContext(1)]
	public interface IKeyPointState
	{
		// Token: 0x1700A2EB RID: 41707
		// (get) Token: 0x06043AB5 RID: 277173
		// (set) Token: 0x06043AB6 RID: 277174
		IDragActorPlayKeyPointConfig Config { get; set; }

		// Token: 0x1700A2EC RID: 41708
		// (get) Token: 0x06043AB7 RID: 277175
		// (set) Token: 0x06043AB8 RID: 277176
		Vector Position { get; set; }

		// Token: 0x1700A2ED RID: 41709
		// (get) Token: 0x06043AB9 RID: 277177
		// (set) Token: 0x06043ABA RID: 277178
		bool IsInside { get; set; }
	}
}
