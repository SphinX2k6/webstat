using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x0200691C RID: 26908
	[NullableContext(1)]
	[Nullable(0)]
	public class DropCatchGameplayAttribute : IDropCatchGameplayAttribute
	{
		// Token: 0x06042D22 RID: 273698 RVA: 0x01126C86 File Offset: 0x01124E86
		public DropCatchGameplayAttribute(string attrName, float baseValue)
		{
			this.AttrName = attrName;
			this.BaseValue = baseValue;
			this.FinalValue = this.BaseValue;
		}

		// Token: 0x06042D23 RID: 273699 RVA: 0x01126CA8 File Offset: 0x01124EA8
		public float GetBaseValue()
		{
			return this.BaseValue;
		}

		// Token: 0x06042D24 RID: 273700 RVA: 0x01126CB0 File Offset: 0x01124EB0
		public float GetFinalValue()
		{
			return this.FinalValue;
		}

		// Token: 0x06042D25 RID: 273701 RVA: 0x01126CB8 File Offset: 0x01124EB8
		public void SetFinalValue(float value)
		{
			this.FinalValue = value;
		}

		// Token: 0x06042D26 RID: 273702 RVA: 0x01126CC1 File Offset: 0x01124EC1
		public string GetAttrName()
		{
			return this.AttrName;
		}

		// Token: 0x06042D27 RID: 273703 RVA: 0x01126CC9 File Offset: 0x01124EC9
		public void Reset()
		{
			this.FinalValue = this.BaseValue;
		}

		// Token: 0x040253D8 RID: 152536
		private float FinalValue;

		// Token: 0x040253D9 RID: 152537
		private readonly string AttrName;

		// Token: 0x040253DA RID: 152538
		private readonly float BaseValue;
	}
}
