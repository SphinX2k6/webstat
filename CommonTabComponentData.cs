using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02001A5A RID: 6746
[NullableContext(1)]
[Nullable(0)]
public class CommonTabComponentData<[Nullable(0)] TTabItem> where TTabItem : CommonTabItemBase
{
	// Token: 0x0600C0D9 RID: 49369 RVA: 0x0032DBF2 File Offset: 0x0032BDF2
	public CommonTabComponentData([Nullable(new byte[]
	{
		1,
		2,
		1
	})] Func<UUIItem, int?, TTabItem> proxyCreate, Action<int> toggleCallBack, [Nullable(new byte[]
	{
		1,
		2
	})] Func<int, CommonTabData> getCommonData)
	{
		this.ProxyCreate = proxyCreate;
		this.ToggleCallBack = toggleCallBack;
		this.GetCommonData = getCommonData;
	}

	// Token: 0x17000FD4 RID: 4052
	// (get) Token: 0x0600C0DA RID: 49370 RVA: 0x0032DC0F File Offset: 0x0032BE0F
	[Nullable(new byte[]
	{
		1,
		2,
		1
	})]
	public Func<UUIItem, int?, TTabItem> ProxyCreate { [return: Nullable(new byte[]
	{
		1,
		2,
		1
	})] get; }

	// Token: 0x17000FD5 RID: 4053
	// (get) Token: 0x0600C0DB RID: 49371 RVA: 0x0032DC17 File Offset: 0x0032BE17
	public Action<int> ToggleCallBack { get; }

	// Token: 0x17000FD6 RID: 4054
	// (get) Token: 0x0600C0DC RID: 49372 RVA: 0x0032DC1F File Offset: 0x0032BE1F
	[Nullable(new byte[]
	{
		1,
		2
	})]
	public Func<int, CommonTabData> GetCommonData { [return: Nullable(new byte[]
	{
		1,
		2
	})] get; }
}
