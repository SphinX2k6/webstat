using System;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058C9 RID: 22729
	public interface IWorldMapNavigate
	{
		// Token: 0x1700935A RID: 37722
		// (get) Token: 0x06039B4E RID: 236366
		int AreaId { get; }

		// Token: 0x1700935B RID: 37723
		// (get) Token: 0x06039B4F RID: 236367
		int? StateId { get; }

		// Token: 0x1700935C RID: 37724
		// (get) Token: 0x06039B50 RID: 236368
		int SortIndex { get; }

		// Token: 0x1700935D RID: 37725
		// (get) Token: 0x06039B51 RID: 236369
		int CountryId { get; }

		// Token: 0x1700935E RID: 37726
		// (get) Token: 0x06039B52 RID: 236370
		int MarkId { get; }

		// Token: 0x1700935F RID: 37727
		// (get) Token: 0x06039B53 RID: 236371
		EMarkType MarkType { get; }
	}
}
