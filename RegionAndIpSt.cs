using System;
using System.Runtime.CompilerServices;

// Token: 0x02002104 RID: 8452
[NullableContext(1)]
[Nullable(0)]
public class RegionAndIpSt
{
	// Token: 0x060102A5 RID: 66213 RVA: 0x00470CCF File Offset: 0x0046EECF
	public void Phrase(string region, string ip)
	{
		this.Region = region;
		this.Ip = ip;
	}

	// Token: 0x04007C2F RID: 31791
	public string Region = string.Empty;

	// Token: 0x04007C30 RID: 31792
	public string Ip = string.Empty;
}
