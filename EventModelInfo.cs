using System;
using System.Runtime.CompilerServices;

// Token: 0x02000E72 RID: 3698
[NullableContext(1)]
[Nullable(0)]
public class EventModelInfo : IAudioInfo
{
	// Token: 0x17000659 RID: 1625
	// (get) Token: 0x060059F4 RID: 23028 RVA: 0x00160E5D File Offset: 0x0015F05D
	// (set) Token: 0x060059F5 RID: 23029 RVA: 0x00160E65 File Offset: 0x0015F065
	public bool Start { get; set; }

	// Token: 0x060059F6 RID: 23030 RVA: 0x00160E6E File Offset: 0x0015F06E
	public EventModelInfo(string @event)
	{
		this.Event = @event;
		this.Start = false;
	}

	// Token: 0x060059F7 RID: 23031 RVA: 0x00160E8F File Offset: 0x0015F08F
	[NullableContext(2)]
	public string GetName()
	{
		return this.Event;
	}

	// Token: 0x060059F8 RID: 23032 RVA: 0x00160E97 File Offset: 0x0015F097
	[NullableContext(2)]
	public string GetAudioEvent()
	{
		return this.Event;
	}

	// Token: 0x060059F9 RID: 23033 RVA: 0x00160E9F File Offset: 0x0015F09F
	public bool IsValid()
	{
		return this.Event != "";
	}

	// Token: 0x060059FA RID: 23034 RVA: 0x00160EB1 File Offset: 0x0015F0B1
	public bool IsAudioEventValid()
	{
		return this.Event != "";
	}

	// Token: 0x060059FB RID: 23035 RVA: 0x00160EC3 File Offset: 0x0015F0C3
	public object GetCompare()
	{
		return this.Event;
	}

	// Token: 0x040029B4 RID: 10676
	public string Event = "";
}
