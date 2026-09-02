using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x0200679D RID: 26525
	public interface IDockyardLeftTipsInterface
	{
		// Token: 0x1700A0DF RID: 41183
		// (get) Token: 0x0604224E RID: 270926
		// (set) Token: 0x0604224F RID: 270927
		bool LockState { get; set; }

		// Token: 0x06042250 RID: 270928
		void SetPanelVisible(bool bVisible);
	}
}
