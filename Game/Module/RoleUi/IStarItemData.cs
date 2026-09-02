using System;

namespace CSharpScript.Game.Module.RoleUi
{
	// Token: 0x02005061 RID: 20577
	public interface IStarItemData
	{
		// Token: 0x17008B62 RID: 35682
		// (get) Token: 0x06034FEF RID: 217071
		// (set) Token: 0x06034FF0 RID: 217072
		bool StarOnActive { get; set; }

		// Token: 0x17008B63 RID: 35683
		// (get) Token: 0x06034FF1 RID: 217073
		// (set) Token: 0x06034FF2 RID: 217074
		bool StarOffActive { get; set; }

		// Token: 0x17008B64 RID: 35684
		// (get) Token: 0x06034FF3 RID: 217075
		// (set) Token: 0x06034FF4 RID: 217076
		bool StarNextActive { get; set; }

		// Token: 0x17008B65 RID: 35685
		// (get) Token: 0x06034FF5 RID: 217077
		// (set) Token: 0x06034FF6 RID: 217078
		bool StarLoopActive { get; set; }

		// Token: 0x17008B66 RID: 35686
		// (get) Token: 0x06034FF7 RID: 217079
		// (set) Token: 0x06034FF8 RID: 217080
		bool PlayLoopSequence { get; set; }

		// Token: 0x17008B67 RID: 35687
		// (get) Token: 0x06034FF9 RID: 217081
		// (set) Token: 0x06034FFA RID: 217082
		bool PlayActivateSequence { get; set; }
	}
}
