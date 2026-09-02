using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D3F RID: 7487
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleBuffGateHeadState : UiPanelBase
{
	// Token: 0x0600DCA1 RID: 56481 RVA: 0x003B4B1F File Offset: 0x003B2D1F
	protected virtual string GetResourceId()
	{
		return "UiItem_WorldPosBuff2";
	}

	// Token: 0x0600DCA2 RID: 56482 RVA: 0x003B4B28 File Offset: 0x003B2D28
	public void CreateHeadStateView(USceneComponent parentComponent, [Nullable(2)] IBuffGateDesc buffGateInfo = null)
	{
		string resourceId = this.GetResourceId();
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		base.CreateThenShowByPathAsync(resourcePath, (UUIItem)parentComponent, true).Forget();
		this.BuffGateInfo = buffGateInfo;
	}

	// Token: 0x0600DCA3 RID: 56483 RVA: 0x003B4B62 File Offset: 0x003B2D62
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x0600DCA4 RID: 56484 RVA: 0x003B4B9C File Offset: 0x003B2D9C
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleBuffGateHeadState.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleBuffGateHeadState.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DCA5 RID: 56485 RVA: 0x003B4BDF File Offset: 0x003B2DDF
	public void UpdateByHeadInfo(FKSC_HeadHpContext headInfo)
	{
		this.UpdateHeadStateLocation(headInfo.Location);
	}

	// Token: 0x0600DCA6 RID: 56486 RVA: 0x003B4BF0 File Offset: 0x003B2DF0
	private void UpdateHeadStateLocation(FVectorDouble location)
	{
		if (this.RootItem == null)
		{
			this.Location = new FVectorDouble?(location);
			return;
		}
		Vector commonTempVector = Singleton<MathUtils>.Instance.CommonTempVector;
		commonTempVector.FromUeVector(location);
		UUIItem rootItem = this.RootItem;
		if (rootItem == null)
		{
			return;
		}
		rootItem.SetUIRelativeLocation(commonTempVector.ToUeVectorOld());
	}

	// Token: 0x0600DCA7 RID: 56487 RVA: 0x003B4C3C File Offset: 0x003B2E3C
	protected void RefreshHeadStateRotation()
	{
		Rotator cameraRotator = ControllerBase<CameraController>.Instance.MainModel.CameraRotator;
		Rotator commonTempRotator = Singleton<MathUtils>.Instance.CommonTempRotator;
		commonTempRotator.Yaw = cameraRotator.Yaw + 90f;
		commonTempRotator.Roll = cameraRotator.Pitch - 90f;
		commonTempRotator.Pitch = 0f;
		UUIItem rootItem = this.RootItem;
		FRotator frotator = commonTempRotator.ToUeRotator();
		rootItem.SetUIRelativeRotation(frotator);
	}

	// Token: 0x040069A2 RID: 27042
	[Nullable(2)]
	private IBuffGateDesc BuffGateInfo;

	// Token: 0x040069A3 RID: 27043
	private FVectorDouble? Location;

	// Token: 0x020080D3 RID: 32979
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BD08 RID: 179464
		public const int TextureQuality = 0;

		// Token: 0x0402BD09 RID: 179465
		public const int TextDialogue = 1;
	}
}
