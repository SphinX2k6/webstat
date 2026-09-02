using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.SceneItem.ExploreInteractiveCondition
{
	// Token: 0x02004865 RID: 18533
	public abstract class CustomConditionListener
	{
		// Token: 0x06030375 RID: 197493 RVA: 0x00BB8B0A File Offset: 0x00BB6D0A
		[NullableContext(1)]
		public CustomConditionListener(Action<bool> onConditionChange)
		{
			this.OnConditionChange = onConditionChange;
		}

		// Token: 0x06030376 RID: 197494
		public abstract bool CheckCondition();

		// Token: 0x06030377 RID: 197495
		public abstract void SetListenerEnable(bool enable);

		// Token: 0x06030378 RID: 197496 RVA: 0x00BB8B19 File Offset: 0x00BB6D19
		public void Clear()
		{
			this.SetListenerEnable(false);
			this.OnConditionChange = null;
		}

		// Token: 0x0401BAFF RID: 113407
		[Nullable(2)]
		protected Action<bool> OnConditionChange;
	}
}
