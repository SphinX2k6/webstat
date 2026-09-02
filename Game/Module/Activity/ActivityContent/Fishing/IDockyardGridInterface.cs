using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006798 RID: 26520
	public interface IDockyardGridInterface
	{
		// Token: 0x0604222B RID: 270891
		void OnItemBlockClick(int id);

		// Token: 0x0604222C RID: 270892
		bool CanDrag(int id);

		// Token: 0x0604222D RID: 270893
		bool DragBegin(int id);

		// Token: 0x0604222E RID: 270894
		bool DragEnd(int id);
	}
}
