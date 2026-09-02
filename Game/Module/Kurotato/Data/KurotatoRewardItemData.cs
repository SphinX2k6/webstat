using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Kurotato.Data
{
	// Token: 0x02005AF2 RID: 23282
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoRewardItemData
	{
		// Token: 0x170095DF RID: 38367
		// (get) Token: 0x0603AE12 RID: 241170 RVA: 0x00EEE893 File Offset: 0x00EECA93
		// (set) Token: 0x0603AE13 RID: 241171 RVA: 0x00EEE89B File Offset: 0x00EECA9B
		public int Id { get; set; }

		// Token: 0x170095E0 RID: 38368
		// (get) Token: 0x0603AE14 RID: 241172 RVA: 0x00EEE8A4 File Offset: 0x00EECAA4
		// (set) Token: 0x0603AE15 RID: 241173 RVA: 0x00EEE8AC File Offset: 0x00EECAAC
		public int Current { get; set; }

		// Token: 0x170095E1 RID: 38369
		// (get) Token: 0x0603AE16 RID: 241174 RVA: 0x00EEE8B5 File Offset: 0x00EECAB5
		// (set) Token: 0x0603AE17 RID: 241175 RVA: 0x00EEE8BD File Offset: 0x00EECABD
		public int Target { get; set; }

		// Token: 0x170095E2 RID: 38370
		// (get) Token: 0x0603AE18 RID: 241176 RVA: 0x00EEE8C6 File Offset: 0x00EECAC6
		// (set) Token: 0x0603AE19 RID: 241177 RVA: 0x00EEE8CE File Offset: 0x00EECACE
		public EKurotatoRewardStatus Status { get; set; }

		// Token: 0x170095E3 RID: 38371
		// (get) Token: 0x0603AE1A RID: 241178 RVA: 0x00EEE8D7 File Offset: 0x00EECAD7
		// (set) Token: 0x0603AE1B RID: 241179 RVA: 0x00EEE8DF File Offset: 0x00EECADF
		public KurotatoResAward? NormalConfig { get; set; }

		// Token: 0x170095E4 RID: 38372
		// (get) Token: 0x0603AE1C RID: 241180 RVA: 0x00EEE8E8 File Offset: 0x00EECAE8
		// (set) Token: 0x0603AE1D RID: 241181 RVA: 0x00EEE8F0 File Offset: 0x00EECAF0
		public KurotatoLimitAward? LimitConfig { get; set; }

		// Token: 0x0603AE1E RID: 241182 RVA: 0x00EEE8F9 File Offset: 0x00EECAF9
		public KurotatoRewardItemData(int id, int current, int target, int status)
		{
			this.Id = id;
			this.Current = current;
			this.Target = target;
			this.Status = (EKurotatoRewardStatus)status;
		}

		// Token: 0x0603AE1F RID: 241183 RVA: 0x00EEE91E File Offset: 0x00EECB1E
		public void Refresh(ConditionTask data)
		{
			this.Current = data.Current;
			this.Target = data.Target;
			this.Status = (EKurotatoRewardStatus)data.Status;
		}

		// Token: 0x0603AE20 RID: 241184 RVA: 0x00EEE944 File Offset: 0x00EECB44
		public virtual string GetTitle()
		{
			if (this.NormalConfig != null)
			{
				return this.NormalConfig.Value.Desc;
			}
			return this.LimitConfig.Value.Desc;
		}

		// Token: 0x0603AE21 RID: 241185 RVA: 0x00EEE990 File Offset: 0x00EECB90
		public virtual int GetDropId()
		{
			if (this.NormalConfig != null)
			{
				return this.NormalConfig.Value.DropId;
			}
			return this.LimitConfig.Value.DropId;
		}
	}
}
