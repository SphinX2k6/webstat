using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Define;

namespace CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Interface
{
	// Token: 0x02006AE9 RID: 27369
	[NullableContext(1)]
	public interface IDragModeStrategy
	{
		// Token: 0x1700A2F5 RID: 41717
		// (get) Token: 0x06043ACB RID: 277195
		EKuroSplineConstrainedDragMode Mode { get; }

		// Token: 0x06043ACC RID: 277196
		void OnActivate(IKuroSplineConstrainedDrag host);

		// Token: 0x06043ACD RID: 277197
		void OnDeactivate();

		// Token: 0x06043ACE RID: 277198
		void BeginDrag();

		// Token: 0x06043ACF RID: 277199
		void SetCurrentScreenPosition(Vector screenPosition);

		// Token: 0x06043AD0 RID: 277200
		void ApplyScreenDelta(Vector screenDelta);

		// Token: 0x06043AD1 RID: 277201
		void EndDrag();
	}
}
