using System;
using System.Runtime.CompilerServices;

// Token: 0x02002CBD RID: 11453
[NullableContext(1)]
[Nullable(0)]
public class UiModelCreateData
{
	// Token: 0x06016FBC RID: 94140 RVA: 0x0065EEFB File Offset: 0x0065D0FB
	public UiModelCreateData(EUiModelType modelType, EUiModelActorType modelActorType, EUiModelUseWay modelUseWay, Type[] components)
	{
		this.ModelType = modelType;
		this.ModelActorType = modelActorType;
		this.ModelUseWay = modelUseWay;
		this.Components = components;
	}

	// Token: 0x0400B138 RID: 45368
	public EUiModelType ModelType;

	// Token: 0x0400B139 RID: 45369
	public EUiModelActorType ModelActorType;

	// Token: 0x0400B13A RID: 45370
	public EUiModelUseWay ModelUseWay;

	// Token: 0x0400B13B RID: 45371
	public Type[] Components;
}
