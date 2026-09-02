using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FAB RID: 20395
	public class SheriffCriminalInfo
	{
		// Token: 0x06034A25 RID: 215589 RVA: 0x00D343B0 File Offset: 0x00D325B0
		[NullableContext(1)]
		public void UpdateByProto(SheriffCriminalInfo proto, int? zoneId = null)
		{
			if (zoneId != null)
			{
				this.ZoneId = zoneId.Value;
			}
			this.CriminalId = proto.CriminalId;
			this.Identity = proto.IdentityId;
			this.State = (ESheriffCriminalState)proto.State;
			this.Identity = proto.IdentityId;
			SheriffCriminal? criminalConfigById = ConfigBase<SheriffConfig>.Instance.GetCriminalConfigById(this.CriminalId);
			if (criminalConfigById != null)
			{
				this.AnomalyId = criminalConfigById.Value.SheriffAnomalyId;
			}
		}

		// Token: 0x0401E570 RID: 124272
		public int ZoneId;

		// Token: 0x0401E571 RID: 124273
		public int CriminalId;

		// Token: 0x0401E572 RID: 124274
		public int Identity;

		// Token: 0x0401E573 RID: 124275
		public ESheriffCriminalState State;

		// Token: 0x0401E574 RID: 124276
		public int AnomalyId;
	}
}
