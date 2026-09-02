using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.RacingBets.View.Item.RacingBetsMatchTable
{
	// Token: 0x020052A0 RID: 21152
	public class RacingBetsMatchItemBase : UiPanelBase
	{
		// Token: 0x06036171 RID: 221553 RVA: 0x00D9E983 File Offset: 0x00D9CB83
		protected override void OnBeforeCreate()
		{
			this.UiLevelSequence = new UiBehaviorLevelSequence(this);
			base.AddUiBehavior(this.UiLevelSequence);
		}

		// Token: 0x06036172 RID: 221554 RVA: 0x00D9E9A0 File Offset: 0x00D9CBA0
		public void PlayAnim()
		{
			UiBehaviorLevelSequence uiLevelSequence = this.UiLevelSequence;
			if (uiLevelSequence != null)
			{
				uiLevelSequence.PlaySequence("Start", false, null);
			}
			GenericLayout<RacingBetsMatchTableDangoItem, IRacingBetsMatchTableDangoItemData> dangoLayout = this.DangoLayout;
			if (dangoLayout == null)
			{
				return;
			}
			dangoLayout.PlayGridAnim();
		}

		// Token: 0x0401F137 RID: 127287
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericLayout<RacingBetsMatchTableDangoItem, IRacingBetsMatchTableDangoItemData> DangoLayout;

		// Token: 0x0401F138 RID: 127288
		[Nullable(2)]
		public UiBehaviorLevelSequence UiLevelSequence;
	}
}
