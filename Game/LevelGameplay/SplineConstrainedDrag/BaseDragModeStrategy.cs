using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Define;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Interface;

namespace CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag
{
	// Token: 0x02006ADB RID: 27355
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class BaseDragModeStrategy : IDragModeStrategy
	{
		// Token: 0x1700A2CC RID: 41676
		// (get) Token: 0x06043A0C RID: 277004
		public abstract EKuroSplineConstrainedDragMode Mode { get; }

		// Token: 0x06043A0D RID: 277005 RVA: 0x0117210F File Offset: 0x0117030F
		public virtual void OnActivate(IKuroSplineConstrainedDrag host)
		{
			this.Host = host;
		}

		// Token: 0x06043A0E RID: 277006 RVA: 0x01172118 File Offset: 0x01170318
		public virtual void OnDeactivate()
		{
		}

		// Token: 0x06043A0F RID: 277007 RVA: 0x0117211A File Offset: 0x0117031A
		public virtual void BeginDrag()
		{
			IKuroSplineConstrainedDrag host = this.Host;
			if (host == null)
			{
				return;
			}
			host.RunCommonBeginDrag();
		}

		// Token: 0x06043A10 RID: 277008 RVA: 0x0117212C File Offset: 0x0117032C
		public virtual void EndDrag()
		{
		}

		// Token: 0x06043A11 RID: 277009
		public abstract void SetCurrentScreenPosition(Vector screenPosition);

		// Token: 0x06043A12 RID: 277010
		public abstract void ApplyScreenDelta(Vector screenDelta);

		// Token: 0x04025C95 RID: 154773
		[Nullable(2)]
		protected IKuroSplineConstrainedDrag Host;
	}
}
