using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004E98 RID: 20120
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class TowerDefenseRankItemUtil : Singleton<TowerDefenseRankItemUtil>
	{
		// Token: 0x06033FE7 RID: 212967 RVA: 0x00D01A21 File Offset: 0x00CFFC21
		public string GetPosTexture(int index)
		{
			if (index == 0)
			{
				return "FormationOnline1PIcon";
			}
			if (index == 1)
			{
				return "FormationOnline2PIcon";
			}
			return "FormationOnline3PIcon";
		}

		// Token: 0x0401E0D0 RID: 123088
		public const string FIRSTPLAYER_ICON = "FormationOnline1PIcon";

		// Token: 0x0401E0D1 RID: 123089
		public const string SECONDPLAYER_ICON = "FormationOnline2PIcon";

		// Token: 0x0401E0D2 RID: 123090
		public const string THIRDPLAYER_ICON = "FormationOnline3PIcon";
	}
}
