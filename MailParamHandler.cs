using System;
using System.Runtime.CompilerServices;

// Token: 0x0200221F RID: 8735
[NullableContext(1)]
[Nullable(0)]
public class MailParamHandler : IMailParamHandler
{
	// Token: 0x06010788 RID: 67464 RVA: 0x0047F754 File Offset: 0x0047D954
	public MailParamHandler(Action<MailData, string> handler)
	{
		this._handler = handler;
	}

	// Token: 0x06010789 RID: 67465 RVA: 0x0047F763 File Offset: 0x0047D963
	public void Handler(MailData instance, string value)
	{
		this._handler(instance, value);
	}

	// Token: 0x040081B3 RID: 33203
	private readonly Action<MailData, string> _handler;
}
