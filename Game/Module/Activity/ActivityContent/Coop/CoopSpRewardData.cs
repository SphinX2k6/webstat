using System;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Coop
{
	// Token: 0x02006987 RID: 27015
	public class CoopSpRewardData
	{
		// Token: 0x1700A1E4 RID: 41444
		// (get) Token: 0x060430A2 RID: 274594 RVA: 0x01137558 File Offset: 0x01135758
		public CoopSpReward? GetConfig
		{
			get
			{
				return ConfigBase<CoopConfig>.Instance.GetCoopSpRewardConfigById(this.Id);
			}
		}

		// Token: 0x060430A3 RID: 274595 RVA: 0x0113756A File Offset: 0x0113576A
		public CoopSpRewardData(int id, ECoopSpRewardState state)
		{
			this.Id = id;
			this.State = state;
		}

		// Token: 0x060430A4 RID: 274596 RVA: 0x01137580 File Offset: 0x01135780
		public void SetState(ECoopSpRewardState state)
		{
			this.State = state;
		}

		// Token: 0x0402554B RID: 152907
		public int Id;

		// Token: 0x0402554C RID: 152908
		public ECoopSpRewardState State;
	}
}
