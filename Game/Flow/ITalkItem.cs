using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Flow
{
	// Token: 0x0200702A RID: 28714
	[NullableContext(1)]
	public interface ITalkItem
	{
		// Token: 0x1700A4FB RID: 42235
		// (get) Token: 0x06045874 RID: 284788
		// (set) Token: 0x06045875 RID: 284789
		int Id { get; set; }

		// Token: 0x1700A4FC RID: 42236
		// (get) Token: 0x06045876 RID: 284790
		// (set) Token: 0x06045877 RID: 284791
		string Name { get; set; }

		// Token: 0x1700A4FD RID: 42237
		// (get) Token: 0x06045878 RID: 284792
		// (set) Token: 0x06045879 RID: 284793
		int WhoId { get; set; }

		// Token: 0x1700A4FE RID: 42238
		// (get) Token: 0x0604587A RID: 284794
		// (set) Token: 0x0604587B RID: 284795
		int TextId { get; set; }

		// Token: 0x1700A4FF RID: 42239
		// (get) Token: 0x0604587C RID: 284796
		// (set) Token: 0x0604587D RID: 284797
		double? WaitTime { get; set; }

		// Token: 0x1700A500 RID: 42240
		// (get) Token: 0x0604587E RID: 284798
		// (set) Token: 0x0604587F RID: 284799
		[Nullable(new byte[]
		{
			2,
			1
		})]
		IActionInfo[] Actions { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x1700A501 RID: 42241
		// (get) Token: 0x06045880 RID: 284800
		// (set) Token: 0x06045881 RID: 284801
		[Nullable(new byte[]
		{
			2,
			1
		})]
		ITalkOption[] Options { [return: Nullable(new byte[]
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
