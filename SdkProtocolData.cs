using System;
using System.Runtime.CompilerServices;

// Token: 0x0200296B RID: 10603
[NullableContext(1)]
[Nullable(0)]
public class SdkProtocolData
{
	// Token: 0x06015150 RID: 86352 RVA: 0x005D5676 File Offset: 0x005D3876
	public static SdkProtocolData Create(string url, string title)
	{
		return new SdkProtocolData
		{
			Url = url,
			Title = title
		};
	}

	// Token: 0x0400A251 RID: 41553
	public string Url = "";

	// Token: 0x0400A252 RID: 41554
	public string Title = "";
}
