using System;
using System.Runtime.CompilerServices;

// Token: 0x02002973 RID: 10611
[NullableContext(1)]
[Nullable(0)]
public class SdkPayProductInformationViewData
{
	// Token: 0x06015163 RID: 86371 RVA: 0x005D58C1 File Offset: 0x005D3AC1
	[NullableContext(2)]
	[return: Nullable(1)]
	public static SdkPayProductInformationViewData Create(string productName, string contentName, string productId, [Nullable(1)] Action<string> onClickConfirmBtn)
	{
		return new SdkPayProductInformationViewData
		{
			ProductName = (productName ?? ""),
			ContentName = (contentName ?? ""),
			ProductId = (productId ?? ""),
			OnClickConfirmBtn = onClickConfirmBtn
		};
	}

	// Token: 0x0400A268 RID: 41576
	public string ProductName = "";

	// Token: 0x0400A269 RID: 41577
	public string ContentName = "";

	// Token: 0x0400A26A RID: 41578
	public string ProductId = "";

	// Token: 0x0400A26B RID: 41579
	public Action<string> OnClickConfirmBtn = delegate(string productId)
	{
	};
}
