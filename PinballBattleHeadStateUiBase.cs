using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D72 RID: 7538
[NullableContext(1)]
[Nullable(0)]
public class PinballBattleHeadStateUiBase : UiPanelBase
{
	// Token: 0x0600DDB9 RID: 56761 RVA: 0x003B9C89 File Offset: 0x003B7E89
	protected override void OnStart()
	{
		if (this.InitHeadHpContext != null)
		{
			this.UpdateByHeadInfo(this.InitHeadHpContext);
			this.InitHeadHpContext = null;
		}
	}

	// Token: 0x0600DDBA RID: 56762 RVA: 0x003B9CAC File Offset: 0x003B7EAC
	public void UpdateByHeadInfo(FKSC_HeadHpContext headInfo)
	{
		if (this.RootItem == null)
		{
			this.InitHeadHpContext = headInfo;
			return;
		}
		this.OnUpdateByHeadInfo(headInfo);
	}

	// Token: 0x0600DDBB RID: 56763 RVA: 0x003B9CC5 File Offset: 0x003B7EC5
	protected virtual void OnUpdateByHeadInfo(FKSC_HeadHpContext headInfo)
	{
	}

	// Token: 0x0600DDBC RID: 56764 RVA: 0x003B9CC7 File Offset: 0x003B7EC7
	public void InitScaleCurve(UCurveFloat headStateScaleCurve)
	{
		this.HeadStateScaleCurve = headStateScaleCurve;
	}

	// Token: 0x0600DDBD RID: 56765 RVA: 0x003B9CD0 File Offset: 0x003B7ED0
	protected void UpdateHeadStateLocation(FVectorDouble location)
	{
		Vector commonTempVector = Singleton<MathUtils>.Instance.CommonTempVector;
		commonTempVector.FromUeVector(location);
		UUIItem rootItem = this.RootItem;
		if (rootItem != null)
		{
			rootItem.SetUIRelativeLocation(commonTempVector.ToUeVectorOld());
		}
		float num = this.CalculateScaleByDistance(commonTempVector);
		UUIItem rootItem2 = this.RootItem;
		if (rootItem2 == null)
		{
			return;
		}
		rootItem2.SetUIItemScale(new FVector(num, num, num));
	}

	// Token: 0x0600DDBE RID: 56766 RVA: 0x003B9D28 File Offset: 0x003B7F28
	protected void UpdateHeadStateRotation()
	{
		Rotator cameraRotator = ControllerBase<CameraController>.Instance.MainModel.CameraRotator;
		Rotator commonTempRotator = Singleton<MathUtils>.Instance.CommonTempRotator;
		commonTempRotator.Yaw = cameraRotator.Yaw + 90f;
		commonTempRotator.Roll = cameraRotator.Pitch - 90f;
		commonTempRotator.Pitch = 0f;
		UUIItem rootItem = this.RootItem;
		if (rootItem == null)
		{
			return;
		}
		FRotator frotator = commonTempRotator.ToUeRotator();
		rootItem.SetUIRelativeRotation(frotator);
	}

	// Token: 0x0600DDBF RID: 56767 RVA: 0x003B9D98 File Offset: 0x003B7F98
	protected float CalculateScaleByDistance(Vector worldLocation)
	{
		double num = Vector.DistSquared(ControllerBase<CameraController>.Instance.MainModel.CameraLocation, worldLocation);
		if (this.HeadStateScaleCurve == null)
		{
			return 1f;
		}
		return this.HeadStateScaleCurve.GetFloatValue((float)num);
	}

	// Token: 0x04006A74 RID: 27252
	[Nullable(2)]
	private FKSC_HeadHpContext InitHeadHpContext;

	// Token: 0x04006A75 RID: 27253
	[Nullable(2)]
	protected UCurveFloat HeadStateScaleCurve;
}
