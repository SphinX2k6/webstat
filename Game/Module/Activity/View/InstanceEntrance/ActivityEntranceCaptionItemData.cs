using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.View.InstanceEntrance
{
	// Token: 0x020061DC RID: 25052
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityEntranceCaptionItemData
	{
		// Token: 0x0603F381 RID: 258945 RVA: 0x0103A392 File Offset: 0x01038592
		public string GetName()
		{
			return this.Name;
		}

		// Token: 0x0603F382 RID: 258946 RVA: 0x0103A39A File Offset: 0x0103859A
		public string GetTitleSpritePath()
		{
			return this.TitleSpritePath;
		}

		// Token: 0x0603F383 RID: 258947 RVA: 0x0103A3A2 File Offset: 0x010385A2
		public int GetHelpId()
		{
			return this.HelpId;
		}

		// Token: 0x0603F384 RID: 258948 RVA: 0x0103A3AA File Offset: 0x010385AA
		public static ActivityEntranceCaptionItemData Create(string name, string titleSpritePath, int helpId)
		{
			return new ActivityEntranceCaptionItemData
			{
				Name = name,
				TitleSpritePath = titleSpritePath,
				HelpId = helpId
			};
		}

		// Token: 0x040237F5 RID: 145397
		private string Name = string.Empty;

		// Token: 0x040237F6 RID: 145398
		private string TitleSpritePath = string.Empty;

		// Token: 0x040237F7 RID: 145399
		private int HelpId;
	}
}
