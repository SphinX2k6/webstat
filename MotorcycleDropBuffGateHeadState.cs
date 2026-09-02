using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D42 RID: 7490
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleDropBuffGateHeadState : UiPanelBase
{
	// Token: 0x0600DCBA RID: 56506 RVA: 0x003B5152 File Offset: 0x003B3352
	protected virtual string GetResourceId()
	{
		return "UiItem_WorldPosBuff1";
	}

	// Token: 0x0600DCBB RID: 56507 RVA: 0x003B515C File Offset: 0x003B335C
	[NullableContext(2)]
	public void CreateHeadStateView([Nullable(1)] USceneComponent parentComponent, IBuffGateDesc buffGateInfo = null, UCurveFloat dropHeadStateScaleCurve = null)
	{
		string resourceId = this.GetResourceId();
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		base.CreateThenShowByPathAsync(resourcePath, (UUIItem)parentComponent, true).Forget();
		this.BuffGateInfo = buffGateInfo;
		this.DropHeadStateScaleCurve = dropHeadStateScaleCurve;
	}

	// Token: 0x0600DCBC RID: 56508 RVA: 0x003B51A0 File Offset: 0x003B33A0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x0600DCBD RID: 56509 RVA: 0x003B51FC File Offset: 0x003B33FC
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleDropBuffGateHeadState.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleDropBuffGateHeadState.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DCBE RID: 56510 RVA: 0x003B523F File Offset: 0x003B343F
	public void UpdateByHeadInfo(FKSC_HeadHpContext headInfo)
	{
		this.UpdateHeadStateLocation(headInfo.Location);
	}

	// Token: 0x0600DCBF RID: 56511 RVA: 0x003B5250 File Offset: 0x003B3450
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
		if (rootItem != null)
		{
			rootItem.SetUIRelativeLocation(commonTempVector.ToUeVectorOld());
		}
		float num = this.CalculateScaleByDistance(commonTempVector);
		this.RootItem.SetUIItemScale(new FVector(num, num, num));
	}

	// Token: 0x0600DCC0 RID: 56512 RVA: 0x003B52B8 File Offset: 0x003B34B8
	private float CalculateScaleByDistance(Vector worldLocation)
	{
		double num = Vector.DistSquared(ControllerBase<CameraController>.Instance.MainModel.CameraLocation, worldLocation);
		if (this.DropHeadStateScaleCurve == null)
		{
			return 1f;
		}
		return this.DropHeadStateScaleCurve.GetFloatValue((float)num);
	}

	// Token: 0x0600DCC1 RID: 56513 RVA: 0x003B52F8 File Offset: 0x003B34F8
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

	// Token: 0x040069AC RID: 27052
	[Nullable(2)]
	private IBuffGateDesc BuffGateInfo;

	// Token: 0x040069AD RID: 27053
	private FVectorDouble? Location;

	// Token: 0x040069AE RID: 27054
	[Nullable(2)]
	private UCurveFloat DropHeadStateScaleCurve;

	// Token: 0x020080D9 RID: 32985
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BD1C RID: 179484
		public const int TextureQuality = 0;

		// Token: 0x0402BD1D RID: 179485
		public const int TextIcon = 1;

		// Token: 0x0402BD1E RID: 179486
		public const int TextDialogue = 2;
	}
}
