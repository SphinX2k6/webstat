using System;

namespace GuideLineProcess
{
	// Token: 0x020043B9 RID: 17337
	public class PendingProcess : IStaticVariableResetter
	{
		// Token: 0x0602E1BE RID: 188862 RVA: 0x00AD7142 File Offset: 0x00AD5342
		public PendingProcess(EProcessType processType)
		{
			this.ProcessType = processType;
			this.ProcessId = ++PendingProcess.Id;
		}

		// Token: 0x0602E1BF RID: 188863 RVA: 0x00AD7164 File Offset: 0x00AD5364
		static PendingProcess()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(PendingProcess.CreateStaticDefaultValue), new Action(PendingProcess.ResetStaticDefaultValue));
		}

		// Token: 0x0602E1C0 RID: 188864 RVA: 0x00AD7183 File Offset: 0x00AD5383
		public static void CreateStaticDefaultValue()
		{
		}

		// Token: 0x0602E1C1 RID: 188865 RVA: 0x00AD7185 File Offset: 0x00AD5385
		public static void ResetStaticDefaultValue()
		{
			PendingProcess.Id = 0;
		}

		// Token: 0x0401A113 RID: 106771
		public static int Id;

		// Token: 0x0401A114 RID: 106772
		public int ProcessId;

		// Token: 0x0401A115 RID: 106773
		public bool Finished;

		// Token: 0x0401A116 RID: 106774
		public readonly EProcessType ProcessType;
	}
}
