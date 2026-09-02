using System;

namespace CSharpScript.Game.Module.Cook
{
	// Token: 0x02005E06 RID: 24070
	public interface ICookerInfoData
	{
		// Token: 0x1700990C RID: 39180
		// (get) Token: 0x0603C932 RID: 248114
		// (set) Token: 0x0603C933 RID: 248115
		int CookingLevel { get; set; }

		// Token: 0x1700990D RID: 39181
		// (get) Token: 0x0603C934 RID: 248116
		// (set) Token: 0x0603C935 RID: 248117
		int TotalProficiencys { get; set; }

		// Token: 0x1700990E RID: 39182
		// (get) Token: 0x0603C936 RID: 248118
		// (set) Token: 0x0603C937 RID: 248119
		int AddExp { get; set; }
	}
}
