using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x0200308C RID: 12428
[NullableContext(1)]
[Nullable(0)]
public readonly struct AttributeListenerHandle
{
	// Token: 0x17002278 RID: 8824
	// (get) Token: 0x060199F3 RID: 104947 RVA: 0x00772812 File Offset: 0x00770A12
	public EAttributeType Id { get; }

	// Token: 0x17002279 RID: 8825
	// (get) Token: 0x060199F4 RID: 104948 RVA: 0x0077281A File Offset: 0x00770A1A
	public Action<EAttributeType, float, float> Callback { get; }

	// Token: 0x060199F5 RID: 104949 RVA: 0x00772822 File Offset: 0x00770A22
	public AttributeListenerHandle(EAttributeType id, Action<EAttributeType, float, float> callback)
	{
		this.Id = id;
		this.Callback = callback;
	}
}
