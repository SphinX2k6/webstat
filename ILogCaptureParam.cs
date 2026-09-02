using System;
using System.Runtime.CompilerServices;

// Token: 0x0200004D RID: 77
[NullableContext(1)]
public interface ILogCaptureParam
{
	// Token: 0x17000016 RID: 22
	// (get) Token: 0x06000148 RID: 328
	ELogLevel LogLevel { get; }

	// Token: 0x17000017 RID: 23
	// (get) Token: 0x06000149 RID: 329
	TLogCaptureCallback Callback { get; }
}
