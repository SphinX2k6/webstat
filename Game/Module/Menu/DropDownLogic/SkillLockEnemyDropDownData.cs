using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu.DropDownLogic
{
	// Token: 0x020057D3 RID: 22483
	public class SkillLockEnemyDropDownData
	{
		// Token: 0x06039252 RID: 234066 RVA: 0x00E7D4DC File Offset: 0x00E7B6DC
		[NullableContext(1)]
		public SkillLockEnemyDropDownData(int index, string textId)
		{
			this.Index = index;
			this.TextId = textId;
		}

		// Token: 0x0402085E RID: 133214
		public int Index;

		// Token: 0x0402085F RID: 133215
		[Nullable(2)]
		public string TextId;
	}
}
