using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Map.View.BaseMap.Assistant.MapLifeEvent
{
	// Token: 0x02005802 RID: 22530
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class MapLifeEventListener
	{
		// Token: 0x06039522 RID: 234786 RVA: 0x00E8D902 File Offset: 0x00E8BB02
		protected MapLifeEventListener(BaseMap map)
		{
			this.TargetExpressionMap = map;
		}

		// Token: 0x06039523 RID: 234787 RVA: 0x00E8D911 File Offset: 0x00E8BB11
		public virtual UniTask OnWorldMapBeforeStartAsync()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x06039524 RID: 234788 RVA: 0x00E8D918 File Offset: 0x00E8BB18
		public virtual void OnWorldMapBeforeShow()
		{
		}

		// Token: 0x06039525 RID: 234789 RVA: 0x00E8D91A File Offset: 0x00E8BB1A
		public virtual void OnWorldMapAfterShow()
		{
		}

		// Token: 0x04020960 RID: 133472
		protected readonly BaseMap TargetExpressionMap;
	}
}
