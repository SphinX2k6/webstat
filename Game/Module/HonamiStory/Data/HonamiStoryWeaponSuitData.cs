using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.HonamiStory.Data
{
	// Token: 0x02005C9D RID: 23709
	[NullableContext(1)]
	[Nullable(0)]
	public class HonamiStoryWeaponSuitData
	{
		// Token: 0x0603BDA8 RID: 245160 RVA: 0x00F2BB0C File Offset: 0x00F29D0C
		public HonamiStoryWeaponSuitData(int suitId)
		{
			HonamiStoryWeaponSuit value = ConfigBase<HonamiStoryConfig>.Instance.GetWeaponSuit(suitId).Value;
			this.Name = value.Name;
			this.Desc = value.Desc;
			this.Args = value.DescArgs();
			this.DescSimple = value.DescSimple;
			this.ArgsSimple = value.DescSimpleArgs();
			this.WeaponPluginType = value.WeaponPluginType;
			this.Enhance = value.EnhanceLevel;
			this.NeedNum = value.NeedNum;
		}

		// Token: 0x04021A65 RID: 137829
		public string Name;

		// Token: 0x04021A66 RID: 137830
		public string Desc;

		// Token: 0x04021A67 RID: 137831
		public string DescSimple;

		// Token: 0x04021A68 RID: 137832
		public string[] Args;

		// Token: 0x04021A69 RID: 137833
		public string[] ArgsSimple;

		// Token: 0x04021A6A RID: 137834
		public int WeaponPluginType;

		// Token: 0x04021A6B RID: 137835
		public int Enhance;

		// Token: 0x04021A6C RID: 137836
		public int NeedNum;
	}
}
