using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x02001BBC RID: 7100
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchBuffData
{
	// Token: 0x0600CE8E RID: 52878 RVA: 0x00370B28 File Offset: 0x0036ED28
	public void RefreshBuffData(FloroRanchPlayBuff buff)
	{
		this.InstanceId = buff.PlayIncId;
		this.ConfigId = buff.Id;
		this.Day = buff.Day;
		this.Plies = buff.Plies;
		this.BuffConfig = ConfigBase<FloroRanchConfig>.Instance.GetFloroRanchBuffById(this.ConfigId).Value;
	}

	// Token: 0x0600CE8F RID: 52879 RVA: 0x00370B83 File Offset: 0x0036ED83
	public string GetBuffName()
	{
		return this.BuffConfig.Name ?? "";
	}

	// Token: 0x1700109D RID: 4253
	// (get) Token: 0x0600CE90 RID: 52880 RVA: 0x00370B99 File Offset: 0x0036ED99
	public int RemindDay
	{
		get
		{
			return this.Day;
		}
	}

	// Token: 0x0600CE91 RID: 52881 RVA: 0x00370BA1 File Offset: 0x0036EDA1
	public int GetPlies()
	{
		return this.Plies;
	}

	// Token: 0x0600CE92 RID: 52882 RVA: 0x00370BA9 File Offset: 0x0036EDA9
	public int GetInstanceId()
	{
		return this.InstanceId;
	}

	// Token: 0x0600CE93 RID: 52883 RVA: 0x00370BB1 File Offset: 0x0036EDB1
	public int GetConfigId()
	{
		return this.ConfigId;
	}

	// Token: 0x1700109E RID: 4254
	// (get) Token: 0x0600CE94 RID: 52884 RVA: 0x00370BB9 File Offset: 0x0036EDB9
	public bool IsShowOnTip
	{
		get
		{
			return this.BuffConfig.IsShowOnTip;
		}
	}

	// Token: 0x1700109F RID: 4255
	// (get) Token: 0x0600CE95 RID: 52885 RVA: 0x00370BC6 File Offset: 0x0036EDC6
	public bool IsShowEffect
	{
		get
		{
			return this.BuffConfig.IsShowEffect;
		}
	}

	// Token: 0x0400627F RID: 25215
	private int InstanceId;

	// Token: 0x04006280 RID: 25216
	private int ConfigId;

	// Token: 0x04006281 RID: 25217
	private int Day;

	// Token: 0x04006282 RID: 25218
	private int Plies;

	// Token: 0x04006283 RID: 25219
	private FloroRanchBuff BuffConfig;
}
