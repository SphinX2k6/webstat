using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x02006299 RID: 25241
	public interface ICellInstance
	{
		// Token: 0x17009C57 RID: 40023
		// (get) Token: 0x0603F871 RID: 260209
		// (set) Token: 0x0603F872 RID: 260210
		int ColorId { get; set; }

		// Token: 0x17009C58 RID: 40024
		// (get) Token: 0x0603F873 RID: 260211
		// (set) Token: 0x0603F874 RID: 260212
		EGemType GemType { get; set; }
	}
}
