using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Net;

// Token: 0x02000BCB RID: 3019
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class NetInfo : Singleton<NetInfo>
{
	// Token: 0x170000B5 RID: 181
	// (get) Token: 0x06003191 RID: 12689 RVA: 0x0001E324 File Offset: 0x0001C524
	public float RttMs
	{
		get
		{
			return this.RttMsInternal;
		}
	}

	// Token: 0x06003192 RID: 12690 RVA: 0x0001E32C File Offset: 0x0001C52C
	public void SetRttMs(int rttMs)
	{
		if ((float)rttMs < this.RttMsInternal)
		{
			this.RttMsInternal = (float)rttMs;
		}
		else
		{
			this.RttMsInternal = this.RttMsInternal * 0.9f + (float)rttMs * 0.1f;
		}
		if (Singleton<PerfSight>.Instance.IsEnable)
		{
			Singleton<PerfSight>.Instance.PostNetworkLatency(rttMs, null, null);
		}
	}

	// Token: 0x170000B6 RID: 182
	// (get) Token: 0x06003193 RID: 12691 RVA: 0x0001E381 File Offset: 0x0001C581
	// (set) Token: 0x06003194 RID: 12692 RVA: 0x0001E389 File Offset: 0x0001C589
	public string LoginTraceId { get; set; }

	// Token: 0x170000B7 RID: 183
	// (get) Token: 0x06003195 RID: 12693 RVA: 0x0001E392 File Offset: 0x0001C592
	// (set) Token: 0x06003196 RID: 12694 RVA: 0x0001E39A File Offset: 0x0001C59A
	public string Token { get; set; }

	// Token: 0x170000B8 RID: 184
	// (get) Token: 0x06003197 RID: 12695 RVA: 0x0001E3A3 File Offset: 0x0001C5A3
	// (set) Token: 0x06003198 RID: 12696 RVA: 0x0001E3AB File Offset: 0x0001C5AB
	public string DeviceId { get; set; }

	// Token: 0x170000B9 RID: 185
	// (get) Token: 0x06003199 RID: 12697 RVA: 0x0001E3B4 File Offset: 0x0001C5B4
	// (set) Token: 0x0600319A RID: 12698 RVA: 0x0001E3BC File Offset: 0x0001C5BC
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<NetHostInfo> UdpHosts { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x170000BA RID: 186
	// (get) Token: 0x0600319B RID: 12699 RVA: 0x0001E3C5 File Offset: 0x0001C5C5
	// (set) Token: 0x0600319C RID: 12700 RVA: 0x0001E3CD File Offset: 0x0001C5CD
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<NetHostInfo> TcpHosts { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x170000BB RID: 187
	// (get) Token: 0x0600319D RID: 12701 RVA: 0x0001E3D6 File Offset: 0x0001C5D6
	// (set) Token: 0x0600319E RID: 12702 RVA: 0x0001E3DE File Offset: 0x0001C5DE
	public int TcpRatio { get; set; }

	// Token: 0x170000BC RID: 188
	// (get) Token: 0x0600319F RID: 12703 RVA: 0x0001E3E7 File Offset: 0x0001C5E7
	// (set) Token: 0x060031A0 RID: 12704 RVA: 0x0001E3EF File Offset: 0x0001C5EF
	public int TcpRetry { get; set; }

	// Token: 0x170000BD RID: 189
	// (get) Token: 0x060031A1 RID: 12705 RVA: 0x0001E3F8 File Offset: 0x0001C5F8
	// (set) Token: 0x060031A2 RID: 12706 RVA: 0x0001E400 File Offset: 0x0001C600
	public bool DisableCrc { get; set; }

	// Token: 0x04000487 RID: 1159
	private float RttMsInternal;

	// Token: 0x0400048F RID: 1167
	public readonly int TcpMaxRetry = 1;
}
