using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DCC RID: 19916
	[NullableContext(2)]
	[Nullable(0)]
	public class TrapDefenseDevelopOpenParam : ITrapDefenseDevelopOpenParam
	{
		// Token: 0x17008841 RID: 34881
		// (get) Token: 0x060338E1 RID: 211169 RVA: 0x00CE46DB File Offset: 0x00CE28DB
		// (set) Token: 0x060338E2 RID: 211170 RVA: 0x00CE46E3 File Offset: 0x00CE28E3
		public bool IsInDungeon { get; set; }

		// Token: 0x17008842 RID: 34882
		// (get) Token: 0x060338E3 RID: 211171 RVA: 0x00CE46EC File Offset: 0x00CE28EC
		// (set) Token: 0x060338E4 RID: 211172 RVA: 0x00CE46F4 File Offset: 0x00CE28F4
		public int SelectedIndex { get; set; }

		// Token: 0x17008843 RID: 34883
		// (get) Token: 0x060338E5 RID: 211173 RVA: 0x00CE46FD File Offset: 0x00CE28FD
		// (set) Token: 0x060338E6 RID: 211174 RVA: 0x00CE4705 File Offset: 0x00CE2905
		public TrapDefenseLevelData LevelData { get; set; }
	}
}
