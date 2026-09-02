using System;
using System.Runtime.CompilerServices;

// Token: 0x02001B2C RID: 6956
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CdnServerDebugConfig : Singleton<CdnServerDebugConfig>
{
	// Token: 0x0600C884 RID: 51332 RVA: 0x0035127B File Offset: 0x0034F47B
	[NullableContext(2)]
	public string TryGetMarqueeDebugUrl(string normalHttp)
	{
		if (this.IsOpenDebug)
		{
			return Singleton<PublicUtil>.Instance.GetMarqueeUrl2(Singleton<PublicUtil>.Instance.GetGameId(), this.Address.MarqueeServerId);
		}
		return normalHttp;
	}

	// Token: 0x0600C885 RID: 51333 RVA: 0x003512A8 File Offset: 0x0034F4A8
	public string TryGetGachaDetailDebugUrl(string urlPattern, string prefix, string serverId)
	{
		if (this.IsOpenDebug)
		{
			string[] array = new string[2];
			int num = 0;
			ICdnServerAddress address = this.Address;
			array[num] = ((address != null) ? address.GachaDetailServerAddressPrefix : null);
			int num2 = 1;
			ICdnServerAddress address2 = this.Address;
			array[num2] = ((address2 != null) ? address2.GachaDetailServerId : null);
			return StringUtils.Format(urlPattern, array);
		}
		return StringUtils.Format(urlPattern, new string[]
		{
			prefix,
			serverId
		});
	}

	// Token: 0x0600C886 RID: 51334 RVA: 0x00351308 File Offset: 0x0034F508
	public string TryGetGachaRecordDebugUrl(string urlPattern, string prefix, string serverId)
	{
		if (this.IsOpenDebug)
		{
			string[] array = new string[2];
			int num = 0;
			ICdnServerAddress address = this.Address;
			array[num] = ((address != null) ? address.GachaRecordServerAddressPrefix : null);
			int num2 = 1;
			ICdnServerAddress address2 = this.Address;
			array[num2] = ((address2 != null) ? address2.GachaRecordServerId : null);
			return StringUtils.Format(urlPattern, array);
		}
		return StringUtils.Format(urlPattern, new string[]
		{
			prefix,
			serverId
		});
	}

	// Token: 0x0600C887 RID: 51335 RVA: 0x00351368 File Offset: 0x0034F568
	public string TryGetGachaInfoDebugUrl(string urlPattern, string prefix, string serverId)
	{
		if (this.IsOpenDebug)
		{
			string[] array = new string[2];
			int num = 0;
			ICdnServerAddress address = this.Address;
			array[num] = ((address != null) ? address.GachaInfoServerPrefixAddress : null);
			int num2 = 1;
			ICdnServerAddress address2 = this.Address;
			array[num2] = ((address2 != null) ? address2.GachaInfoServerId : null);
			return StringUtils.Format(urlPattern, array);
		}
		return StringUtils.Format(urlPattern, new string[]
		{
			prefix,
			serverId
		});
	}

	// Token: 0x0600C888 RID: 51336 RVA: 0x003513C8 File Offset: 0x0034F5C8
	[return: Nullable(2)]
	public string TryGetNoticeServerPrefixAddress(string cdn)
	{
		if (!this.IsOpenDebug)
		{
			return cdn;
		}
		ICdnServerAddress address = this.Address;
		if (address == null)
		{
			return null;
		}
		return address.NoticeServerPrefixAddress;
	}

	// Token: 0x0400603B RID: 24635
	private bool IsOpenDebug;

	// Token: 0x0400603C RID: 24636
	[Nullable(2)]
	private ICdnServerAddress Address;
}
