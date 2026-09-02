using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02001F8C RID: 8076
[NullableContext(2)]
[Nullable(0)]
public class CameraAimHandle : HudUnitHandleBase
{
	// Token: 0x0600F20A RID: 61962 RVA: 0x00421F20 File Offset: 0x00420120
	protected override void OnDestroyed()
	{
		this.ResId = null;
		this.DestroyCameraAimUnit();
	}

	// Token: 0x0600F20B RID: 61963 RVA: 0x00421F2F File Offset: 0x0042012F
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<bool, ECameraAimVisibleReason, string, string>(EEventName.SetCameraAimVisible, new Action<bool, ECameraAimVisibleReason, string, string>(this.OnSetCameraAimVisible));
	}

	// Token: 0x0600F20C RID: 61964 RVA: 0x00421F4D File Offset: 0x0042014D
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<bool, ECameraAimVisibleReason, string, string>(EEventName.SetCameraAimVisible, new Action<bool, ECameraAimVisibleReason, string, string>(this.OnSetCameraAimVisible));
	}

	// Token: 0x0600F20D RID: 61965 RVA: 0x00421F6C File Offset: 0x0042016C
	private void OnSetCameraAimVisible(bool bVisible, ECameraAimVisibleReason reason, string resId = null, string cameraName = null)
	{
		if (cameraName != null && cameraName != "MainCamera")
		{
			return;
		}
		if (bVisible && reason == ECameraAimVisibleReason.Default)
		{
			if (this.ResId != resId)
			{
				this.ResId = resId;
			}
			if (this.CameraAimUnit == null)
			{
				this.NewCameraAimUnit();
				return;
			}
			if (this.CameraAimUnit.ResourceId != this.ResId)
			{
				this.DestroyCameraAimUnit();
				this.NewCameraAimUnit();
				return;
			}
		}
		if (this.CameraAimUnit == null)
		{
			return;
		}
		this.CameraAimUnit.SetVisible(bVisible, (int)reason);
	}

	// Token: 0x0600F20E RID: 61966 RVA: 0x00421FF4 File Offset: 0x004201F4
	private void NewCameraAimUnit()
	{
		if (this.ResId == null || this.ResId.Length == 0)
		{
			return;
		}
		base.NewHudUnitWithReturn<CameraAimUnit>(typeof(CameraAimUnit), this.ResId, out this.CameraAimUnit, true, delegate(CameraAimUnit _)
		{
			string resId = this.ResId;
			CameraAimUnit cameraAimUnit = this.CameraAimUnit;
			if (resId != ((cameraAimUnit != null) ? cameraAimUnit.ResourceId : null))
			{
				this.DestroyCameraAimUnit();
			}
		}, false);
		this.CameraAimUnit.SetVisible(true, 0);
	}

	// Token: 0x0600F20F RID: 61967 RVA: 0x0042204E File Offset: 0x0042024E
	private void DestroyCameraAimUnit()
	{
		if (this.CameraAimUnit == null)
		{
			return;
		}
		base.DestroyHudUnit(this.CameraAimUnit);
		this.CameraAimUnit = null;
	}

	// Token: 0x04007438 RID: 29752
	private CameraAimUnit CameraAimUnit;

	// Token: 0x04007439 RID: 29753
	private string ResId;
}
