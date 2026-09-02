using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200592C RID: 22828
	[NullableContext(1)]
	public interface IToggleItemData
	{
		// Token: 0x17009434 RID: 37940
		// (get) Token: 0x06039ED0 RID: 237264
		// (set) Token: 0x06039ED1 RID: 237265
		int Id { get; set; }

		// Token: 0x17009435 RID: 37941
		// (get) Token: 0x06039ED2 RID: 237266
		// (set) Token: 0x06039ED3 RID: 237267
		string Icon { get; set; }

		// Token: 0x17009436 RID: 37942
		// (get) Token: 0x06039ED4 RID: 237268
		// (set) Token: 0x06039ED5 RID: 237269
		string TitleId { get; set; }

		// Token: 0x17009437 RID: 37943
		// (get) Token: 0x06039ED6 RID: 237270
		// (set) Token: 0x06039ED7 RID: 237271
		string DescId { get; set; }

		// Token: 0x17009438 RID: 37944
		// (get) Token: 0x06039ED8 RID: 237272
		// (set) Token: 0x06039ED9 RID: 237273
		[Nullable(new byte[]
		{
			2,
			1
		})]
		string[] DescParams { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17009439 RID: 37945
		// (get) Token: 0x06039EDA RID: 237274
		// (set) Token: 0x06039EDB RID: 237275
		[Nullable(2)]
		string ProgressId { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700943A RID: 37946
		// (get) Token: 0x06039EDC RID: 237276
		// (set) Token: 0x06039EDD RID: 237277
		[Nullable(new byte[]
		{
			2,
			1
		})]
		string[] ProgressParams { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x1700943B RID: 37947
		// (get) Token: 0x06039EDE RID: 237278
		// (set) Token: 0x06039EDF RID: 237279
		bool IsDisabled { get; set; }
	}
}
