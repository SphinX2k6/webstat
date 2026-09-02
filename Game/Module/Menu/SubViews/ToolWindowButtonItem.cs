using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x02005794 RID: 22420
	[NullableContext(1)]
	[Nullable(0)]
	public class ToolWindowButtonItem : ButtonAndTextItem
	{
		// Token: 0x0603905A RID: 233562 RVA: 0x00E7300F File Offset: 0x00E7120F
		public ToolWindowButtonItem(UUIItem uiItem) : base(uiItem)
		{
		}

		// Token: 0x0603905B RID: 233563 RVA: 0x00E73018 File Offset: 0x00E71218
		protected override void OnRegisterComponent()
		{
			base.OnRegisterComponent();
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(2, typeof(UUISprite)));
		}

		// Token: 0x0603905C RID: 233564 RVA: 0x00E7303B File Offset: 0x00E7123B
		protected override void OnStart()
		{
			this.SetIconVisible(false);
		}

		// Token: 0x0603905D RID: 233565 RVA: 0x00E73044 File Offset: 0x00E71244
		public void RefreshIcon(string iconPath, [Nullable(2)] Action<bool> callback = null)
		{
			this.SetSpriteByPath(iconPath, base.GetSprite(2), false, null, callback);
		}

		// Token: 0x0603905E RID: 233566 RVA: 0x00E7306A File Offset: 0x00E7126A
		public void SetIconVisible(bool bVisible)
		{
			base.GetSprite(2).SetUIActive(bVisible);
		}
	}
}
