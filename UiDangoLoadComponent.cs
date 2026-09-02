using System;
using System.Runtime.CompilerServices;

// Token: 0x02002C97 RID: 11415
[NullableContext(2)]
[Nullable(0)]
public class UiDangoLoadComponent : UiModelLoadComponent
{
	// Token: 0x06016E89 RID: 93833 RVA: 0x0065A1AF File Offset: 0x006583AF
	protected override void OnInit()
	{
		base.OnInit();
		this.UiDangoDataComponent = base.Owner.CheckGetComponent<UiDangoDataComponent>();
	}

	// Token: 0x06016E8A RID: 93834 RVA: 0x0065A1C8 File Offset: 0x006583C8
	protected override void OnEnd()
	{
		base.OnEnd();
		this.UiDangoDataComponent = null;
	}

	// Token: 0x06016E8B RID: 93835 RVA: 0x0065A1D8 File Offset: 0x006583D8
	public void LoadModelByDangoId(int id, bool waitMeshStreaming, Action loadFinishCallBack = null)
	{
		this.UiDangoDataComponent.DangoId = id;
		DangoData dangoData = Singleton<DangoManager>.Instance.GetDangoData(id);
		this.UiModelDataComponent.ModelConfigId = dangoData.ModelId;
		this.LoadFinishCallBack = loadFinishCallBack;
		base.LoadModel(waitMeshStreaming, null, 1);
	}

	// Token: 0x0400B0AE RID: 45230
	private UiDangoDataComponent UiDangoDataComponent;
}
