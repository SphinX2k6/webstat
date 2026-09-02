using System;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006066 RID: 24678
	public abstract class TPendingProcess : IStaticVariableResetter
	{
		// Token: 0x17009ABE RID: 39614
		// (get) Token: 0x0603E3E4 RID: 254948
		public abstract EMissionProcessType ProcessType { get; }

		// Token: 0x17009ABF RID: 39615
		// (get) Token: 0x0603E3E5 RID: 254949
		public abstract bool IsSkipAnim { get; }

		// Token: 0x0603E3E6 RID: 254950 RVA: 0x00FE3F94 File Offset: 0x00FE2194
		protected TPendingProcess()
		{
			this.ProcessId = ++TPendingProcess.Id;
		}

		// Token: 0x0603E3E7 RID: 254951 RVA: 0x00FE3FAF File Offset: 0x00FE21AF
		static TPendingProcess()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(TPendingProcess.CreateStaticDefaultValue), new Action(TPendingProcess.ResetStaticDefaultValue));
		}

		// Token: 0x0603E3E8 RID: 254952 RVA: 0x00FE3FCE File Offset: 0x00FE21CE
		public static void CreateStaticDefaultValue()
		{
			TPendingProcess.Id = 0;
		}

		// Token: 0x0603E3E9 RID: 254953 RVA: 0x00FE3FD6 File Offset: 0x00FE21D6
		public static void ResetStaticDefaultValue()
		{
			TPendingProcess.Id = 0;
		}

		// Token: 0x04022E3C RID: 142908
		private static int Id;

		// Token: 0x04022E3D RID: 142909
		public readonly int ProcessId;
	}
}
