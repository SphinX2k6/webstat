using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu
{
	// Token: 0x0200575E RID: 22366
	[NullableContext(1)]
	public interface IChangeKeyModeRow
	{
		// Token: 0x17009173 RID: 37235
		// (get) Token: 0x06038EBB RID: 233147
		// (set) Token: 0x06038EBC RID: 233148
		string RowSpriteResourceId { get; set; }

		// Token: 0x17009174 RID: 37236
		// (get) Token: 0x06038EBD RID: 233149
		// (set) Token: 0x06038EBE RID: 233150
		string DescriptionA { get; set; }

		// Token: 0x17009175 RID: 37237
		// (get) Token: 0x06038EBF RID: 233151
		// (set) Token: 0x06038EC0 RID: 233152
		[Nullable(new byte[]
		{
			2,
			1
		})]
		object[] DescriptionParametersA { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17009176 RID: 37238
		// (get) Token: 0x06038EC1 RID: 233153
		// (set) Token: 0x06038EC2 RID: 233154
		string DescriptionB { get; set; }

		// Token: 0x17009177 RID: 37239
		// (get) Token: 0x06038EC3 RID: 233155
		// (set) Token: 0x06038EC4 RID: 233156
		[Nullable(new byte[]
		{
			2,
			1
		})]
		object[] DescriptionParametersB { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }
	}
}
