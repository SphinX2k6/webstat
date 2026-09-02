using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002CA3 RID: 11427
[NullableContext(2)]
[Nullable(0)]
public class UiMotorStickerComponent : UiModelComponentBase
{
	// Token: 0x06016EED RID: 93933 RVA: 0x0065B549 File Offset: 0x00659749
	protected override void OnInit()
	{
		this.LoadComponent = base.Owner.CheckGetComponent<UiModelLoadComponent>();
		this.RenderingMaterialComponent = base.Owner.CheckGetComponent<UiModelRenderingMaterialComponent>();
	}

	// Token: 0x06016EEE RID: 93934 RVA: 0x0065B570 File Offset: 0x00659770
	public void RemoveStickerMaterial(int stickerPart)
	{
		int materialId;
		if (!this.MotorStickerMaterialIdMap.TryGetValue(stickerPart, out materialId))
		{
			return;
		}
		if (this.RenderingMaterialComponent == null)
		{
			return;
		}
		this.RenderingMaterialComponent.RemoveRenderingMaterial(materialId);
		this.MotorStickerMaterialIdMap.Remove(stickerPart);
	}

	// Token: 0x06016EEF RID: 93935 RVA: 0x0065B5B0 File Offset: 0x006597B0
	public void AddStickerMaterial(int stickerId)
	{
		MotorSticker? motorStickerConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerConfig(stickerId);
		if (motorStickerConfig == null)
		{
			return;
		}
		PD_CharacterControllerData_C pd_CharacterControllerData_C = this.LoadComponent.GetLoadedResource(motorStickerConfig.Value.MaterialDA) as PD_CharacterControllerData_C;
		if (pd_CharacterControllerData_C == null)
		{
			this.AddStickerMaterialAsync(stickerId);
			return;
		}
		this.RemoveStickerMaterial(motorStickerConfig.Value.PartId);
		int value = this.RenderingMaterialComponent.AddRenderingMaterialByData(pd_CharacterControllerData_C);
		this.MotorStickerMaterialIdMap[motorStickerConfig.Value.PartId] = value;
	}

	// Token: 0x06016EF0 RID: 93936 RVA: 0x0065B63C File Offset: 0x0065983C
	public UniTask AddStickerMaterialAsync(int stickerId)
	{
		UiMotorStickerComponent.<AddStickerMaterialAsync>d__6 <AddStickerMaterialAsync>d__;
		<AddStickerMaterialAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<AddStickerMaterialAsync>d__.<>4__this = this;
		<AddStickerMaterialAsync>d__.stickerId = stickerId;
		<AddStickerMaterialAsync>d__.<>1__state = -1;
		<AddStickerMaterialAsync>d__.<>t__builder.Start<UiMotorStickerComponent.<AddStickerMaterialAsync>d__6>(ref <AddStickerMaterialAsync>d__);
		return <AddStickerMaterialAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0400B0E1 RID: 45281
	[Nullable(1)]
	private readonly Dictionary<int, int> MotorStickerMaterialIdMap = new Dictionary<int, int>();

	// Token: 0x0400B0E2 RID: 45282
	private UiModelLoadComponent LoadComponent;

	// Token: 0x0400B0E3 RID: 45283
	private UiModelRenderingMaterialComponent RenderingMaterialComponent;
}
