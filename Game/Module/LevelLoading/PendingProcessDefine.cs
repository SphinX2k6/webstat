using System;

namespace CSharpScript.Game.Module.LevelLoading
{
	// Token: 0x02005A12 RID: 23058
	public class PendingProcessDefine : IStaticVariableResetter
	{
		// Token: 0x0603A62F RID: 239151 RVA: 0x00ECDE31 File Offset: 0x00ECC031
		static PendingProcessDefine()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(PendingProcessDefine.CreateStaticDefaultValue), new Action(PendingProcessDefine.ResetStaticDefaultValue));
		}

		// Token: 0x0603A630 RID: 239152 RVA: 0x00ECDE50 File Offset: 0x00ECC050
		public static void CreateStaticDefaultValue()
		{
			PendingProcessDefine.Id = 0;
		}

		// Token: 0x0603A631 RID: 239153 RVA: 0x00ECDE58 File Offset: 0x00ECC058
		public static void ResetStaticDefaultValue()
		{
			PendingProcessDefine.Id = 0;
		}

		// Token: 0x04021103 RID: 135427
		public static int Id;
	}
}
