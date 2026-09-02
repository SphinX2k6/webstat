using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap.SubViews.WorldMapNote
{
	// Token: 0x02004B77 RID: 19319
	[NullableContext(1)]
	[Nullable(0)]
	public class WorldMapNoteItemData
	{
		// Token: 0x0401D71D RID: 120605
		public int Id;

		// Token: 0x0401D71E RID: 120606
		public string IconRes = "";

		// Token: 0x0401D71F RID: 120607
		public string DescId = "";

		// Token: 0x0401D720 RID: 120608
		public EMapNoteStyle NoteStyle;

		// Token: 0x0401D721 RID: 120609
		[Nullable(2)]
		public Action<int> ClickCallback;

		// Token: 0x0401D722 RID: 120610
		[Nullable(2)]
		public string CustomDesc;
	}
}
