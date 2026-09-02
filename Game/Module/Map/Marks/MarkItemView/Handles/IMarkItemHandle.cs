using System;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles
{
	// Token: 0x0200588F RID: 22671
	public interface IMarkItemHandle
	{
		// Token: 0x06039A0D RID: 236045
		void Init();

		// Token: 0x06039A0E RID: 236046
		void Update();

		// Token: 0x06039A0F RID: 236047
		void ApplyModified();

		// Token: 0x06039A10 RID: 236048
		void SetVisible(bool active);

		// Token: 0x06039A11 RID: 236049
		void Dispose();

		// Token: 0x06039A12 RID: 236050
		void UpdateNoCheck();

		// Token: 0x06039A13 RID: 236051
		void ApplyModifiedNoCheck();
	}
}
