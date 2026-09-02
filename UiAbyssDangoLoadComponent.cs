using System;
using System.Runtime.CompilerServices;

// Token: 0x02002C94 RID: 11412
[NullableContext(2)]
[Nullable(0)]
public class UiAbyssDangoLoadComponent : UiModelLoadComponent
{
	// Token: 0x06016E7C RID: 93820 RVA: 0x00659FBE File Offset: 0x006581BE
	protected override void OnInit()
	{
		base.OnInit();
		this.UiDangoDataComponent = base.Owner.CheckGetComponent<UiDangoDataComponent>();
	}

	// Token: 0x06016E7D RID: 93821 RVA: 0x00659FD7 File Offset: 0x006581D7
	protected override void OnEnd()
	{
		base.OnEnd();
		this.UiDangoDataComponent = null;
	}

	// Token: 0x06016E7E RID: 93822 RVA: 0x00659FE6 File Offset: 0x006581E6
	public void LoadModelByDangoId(int dangoId, int meshId, bool waitMeshStreaming, Action loadFinishCallBack = null)
	{
		this.UiDangoDataComponent.DangoId = dangoId;
		this.UiModelDataComponent.ModelConfigId = meshId;
		this.LoadFinishCallBack = loadFinishCallBack;
		base.LoadModel(waitMeshStreaming, null, 1);
	}

	// Token: 0x0400B0A9 RID: 45225
	private UiDangoDataComponent UiDangoDataComponent;
}
