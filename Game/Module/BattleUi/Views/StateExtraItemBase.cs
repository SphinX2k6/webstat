using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006110 RID: 24848
	[NullableContext(1)]
	[Nullable(0)]
	public class StateExtraItemBase : UiPanelBase
	{
		// Token: 0x0603EC4A RID: 257098 RVA: 0x01012F05 File Offset: 0x01011105
		public EExtraItemType GetExtraItemType()
		{
			return this.Type;
		}

		// Token: 0x0603EC4B RID: 257099 RVA: 0x01012F0D File Offset: 0x0101110D
		public void InitExtraItemType(EExtraItemType type)
		{
			this.Type = type;
		}

		// Token: 0x0603EC4C RID: 257100 RVA: 0x01012F16 File Offset: 0x01011116
		public void InitExtraParams(ExtraItemParams paramsObj)
		{
			this.OnInitExtraParams(paramsObj);
		}

		// Token: 0x0603EC4D RID: 257101 RVA: 0x01012F1F File Offset: 0x0101111F
		protected virtual void OnInitExtraParams(ExtraItemParams paramsObj)
		{
		}

		// Token: 0x04023351 RID: 144209
		private EExtraItemType Type;
	}
}
