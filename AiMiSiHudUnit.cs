using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001FA5 RID: 8101
[NullableContext(2)]
[Nullable(0)]
public class AiMiSiHudUnit : HudUnitBase
{
	// Token: 0x0600F37B RID: 62331 RVA: 0x00428DE4 File Offset: 0x00426FE4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 51;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIArtText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIArtText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIArtText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIArtText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(27, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(30, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(31, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(32, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(33, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(34, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(35, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(36, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(37, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(38, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(39, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(40, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(41, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(42, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(43, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(44, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(45, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(46, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(47, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(48, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(49, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(50, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(51, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(52, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F37C RID: 62332 RVA: 0x004294CC File Offset: 0x004276CC
	protected override UniTask OnBeforeStartAsync()
	{
		AiMiSiHudUnit.<OnBeforeStartAsync>d__58 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<AiMiSiHudUnit.<OnBeforeStartAsync>d__58>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F37D RID: 62333 RVA: 0x00429510 File Offset: 0x00427710
	protected override void OnStart()
	{
		base.InitTweenAnim(17);
		base.InitTweenAnim(18);
		base.InitTweenAnim(19);
		base.InitTweenAnim(20);
		base.InitTweenAnim(21);
		base.InitTweenAnim(22);
		base.InitTweenAnim(23);
		base.InitTweenAnim(24);
		base.InitTweenAnim(25);
		base.InitTweenAnim(26);
		base.InitTweenAnim(27);
		base.InitTweenAnim(47);
		base.InitTweenAnim(48);
		base.InitTweenAnim(30);
		base.InitTweenAnim(31);
		base.InitTweenAnim(32);
		base.InitTweenAnim(33);
		base.InitTweenAnim(34);
		base.InitTweenAnim(35);
		base.InitTweenAnim(36);
		base.InitTweenAnim(37);
		base.InitTweenAnim(43);
		base.InitTweenAnim(44);
		base.InitTweenAnim(49);
		base.InitTweenAnim(50);
		this.EnduranceItem = base.GetItem(0);
		this.EnduranceBarSprite = base.GetSprite(1);
		this.TopItem = base.GetItem(2);
		this.BottomItem = base.GetItem(3);
		this.LeftItem1 = base.GetItem(4);
		this.RightItem1 = base.GetItem(7);
		this.TexAltimeterScale = base.GetTexture(38);
		this.TexHorizonScaleL = base.GetTexture(39);
		this.TexHorizonScaleR = base.GetTexture(40);
		this.TexTopScale = base.GetTexture(41);
		this.AnchorItemList.Add(base.GetItem(42));
		this.AnchorItemList.Add(base.GetItem(51));
		this.AnchorItemList.Add(base.GetItem(52));
		this.PitchUpMin = ConfigCommonParamById.GetFloatConfig("AimisiHudPitchUpMin").Value;
		this.PitchUpMax = ConfigCommonParamById.GetFloatConfig("AimisiHudPitchUpMax").Value;
		this.PitchDownMin = ConfigCommonParamById.GetFloatConfig("AimisiHudPitchDownMin").Value;
		this.PitchDownMax = ConfigCommonParamById.GetFloatConfig("AimisiHudPitchDownMax").Value;
		this.HorizonScaleSpeed = ConfigCommonParamById.GetFloatConfig("AimisiHudHorizonScaleSpeed").Value;
		this.AltimeterScaleSpeed = ConfigCommonParamById.GetFloatConfig("AimisiHudAltimeterScaleSpeed").Value;
		this.MaxPitch = ConfigCommonParamById.GetFloatConfig("AimisiHudMaxPitch").Value;
		this.MaxRoll = ConfigCommonParamById.GetFloatConfig("AimisiHudMaxRoll").Value;
		this.RotateMachine.Speed = (double)ConfigCommonParamById.GetFloatConfig("AimisiHudRollAnimSpeed").Value;
		this.RotateMachine.Countdown = (int)ConfigCommonParamById.GetFloatConfig("AimisiHudRollAnimTime").Value;
		this.RotateAnimInFight = ConfigCommonParamById.GetBoolConfig("AimisiHudAnimInFight").Value;
		this.EnduranceVisible = false;
		this.EnduranceItem.SetUIActive(false);
		this.RefreshKeyNode();
		this.RefreshRotateMachineSpeed();
	}

	// Token: 0x0600F37E RID: 62334 RVA: 0x004297D8 File Offset: 0x004279D8
	protected override UniTask OnBeforeHideAsync()
	{
		AiMiSiHudUnit.<OnBeforeHideAsync>d__60 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<AiMiSiHudUnit.<OnBeforeHideAsync>d__60>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F37F RID: 62335 RVA: 0x0042981B File Offset: 0x00427A1B
	private void OnCloseAnimTimerEnd(float delta)
	{
		this.CloseTimer = null;
		this.Promise.SetResult();
		this.Promise = null;
	}

	// Token: 0x0600F380 RID: 62336 RVA: 0x00429838 File Offset: 0x00427A38
	protected override void OnBeforeDestroy()
	{
		this.StopTweenAnim(32);
		this.StopTweenAnim(33);
		base.OnBeforeDestroy();
		if (this.CloseTimer != null)
		{
			TimerSystem.Instance.Remove(this.CloseTimer);
			this.CloseTimer = null;
			this.Promise.SetResult();
			this.Promise = null;
		}
		this.StopDelayHideEnduranceTimer();
		foreach (InputMultiKeyItem inputMultiKeyItem in this.KeyItemList)
		{
			inputMultiKeyItem.Destroy(null);
		}
		this.KeyItemList.Clear();
	}

	// Token: 0x0600F381 RID: 62337 RVA: 0x004298E4 File Offset: 0x00427AE4
	public void RefreshKeyNode()
	{
		UUIItem item = base.GetItem(45);
		UUIItem item2 = base.GetItem(46);
		if (item == null || item2 == null)
		{
			return;
		}
		if (Singleton<Info>.Instance.IsInTouch())
		{
			item.SetUIActive(false);
			item2.SetUIActive(false);
			return;
		}
		item.SetUIActive(true);
		item2.SetUIActive(true);
		if (!this.IsInitKey)
		{
			this.IsInitKey = true;
			this.InitKeyItem(item, "跳跃");
			this.InitKeyItem(item2, "下降");
		}
	}

	// Token: 0x0600F382 RID: 62338 RVA: 0x0042995C File Offset: 0x00427B5C
	[NullableContext(1)]
	private UniTask InitKeyItem(UUIItem parentItem, string actionName)
	{
		AiMiSiHudUnit.<InitKeyItem>d__64 <InitKeyItem>d__;
		<InitKeyItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitKeyItem>d__.<>4__this = this;
		<InitKeyItem>d__.parentItem = parentItem;
		<InitKeyItem>d__.actionName = actionName;
		<InitKeyItem>d__.<>1__state = -1;
		<InitKeyItem>d__.<>t__builder.Start<AiMiSiHudUnit.<InitKeyItem>d__64>(ref <InitKeyItem>d__);
		return <InitKeyItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600F383 RID: 62339 RVA: 0x004299B0 File Offset: 0x00427BB0
	public void RefreshRotateMachineSpeed()
	{
		if (Singleton<Info>.Instance.IsInTouch())
		{
			this.RotateMachine.YawSpeedMin = (double)ConfigCommonParamById.GetFloatConfig("AimisiHudCameraRotateMinSpeedMobile").Value;
			return;
		}
		this.RotateMachine.YawSpeedMin = (double)ConfigCommonParamById.GetFloatConfig("AimisiHudCameraRotateMinSpeed").Value;
	}

	// Token: 0x0600F384 RID: 62340 RVA: 0x00429A06 File Offset: 0x00427C06
	[NullableContext(1)]
	public void InitData(AiMiSiHudData data)
	{
		this.Data = data;
		this.RefreshAll(true);
	}

	// Token: 0x0600F385 RID: 62341 RVA: 0x00429A16 File Offset: 0x00427C16
	public void SetTargetVisible(bool visible)
	{
		this.TargetVisible = visible;
		base.SetVisible(visible, 0);
	}

	// Token: 0x0600F386 RID: 62342 RVA: 0x00429A27 File Offset: 0x00427C27
	public override void SetActive(bool visibility)
	{
		if (visibility && !this.TargetVisible)
		{
			return;
		}
		base.SetActive(visibility);
	}

	// Token: 0x0600F387 RID: 62343 RVA: 0x00429A3C File Offset: 0x00427C3C
	public void MarkDataDirty()
	{
		this.DataDirty = true;
	}

	// Token: 0x0600F388 RID: 62344 RVA: 0x00429A45 File Offset: 0x00427C45
	public void SetEnduranceProgress(float progress)
	{
		this.EnduranceProgress = progress;
		UUISprite enduranceBarSprite = this.EnduranceBarSprite;
		if (enduranceBarSprite != null)
		{
			enduranceBarSprite.SetFillAmount(progress);
		}
		this.RefreshEnduranceVisible();
	}

	// Token: 0x0600F389 RID: 62345 RVA: 0x00429A66 File Offset: 0x00427C66
	private void RefreshEnduranceVisible()
	{
		if (!this.MechanismNodeVisible)
		{
			this.SetEnduranceVisible(false, true);
			return;
		}
		if (this.EnduranceProgress < 1f)
		{
			this.SetEnduranceVisible(true, false);
			return;
		}
		this.SetEnduranceVisible(false, false);
	}

	// Token: 0x0600F38A RID: 62346 RVA: 0x00429A98 File Offset: 0x00427C98
	private void SetEnduranceVisible(bool bVisible, bool immediately = false)
	{
		if (this.EnduranceVisible == bVisible && this.TargetEnduranceVisible == bVisible)
		{
			return;
		}
		this.TargetEnduranceVisible = bVisible;
		if (bVisible)
		{
			this.StopDelayHideEnduranceTimer();
			if (!this.EnduranceVisible)
			{
				this.EnduranceVisible = true;
				this.StopTweenAnim(44);
				this.PlayTweenAnim(43);
				return;
			}
		}
		else if (immediately)
		{
			this.StopDelayHideEnduranceTimer();
			if (this.EnduranceVisible)
			{
				this.EnduranceVisible = false;
				this.StopTweenAnim(43);
				this.PlayTweenAnim(44);
				return;
			}
		}
		else
		{
			if (this.DelayHideEnduranceTimer != null)
			{
				return;
			}
			this.DelayHideEnduranceTimer = TimerSystem.Instance.Delay(delegate(float delta)
			{
				this.DelayHideEnduranceTimer = null;
				if (!this.TargetEnduranceVisible)
				{
					this.EnduranceVisible = false;
					this.PlayTweenAnim(44);
				}
			}, 1000f, null, null, true, 1f);
		}
	}

	// Token: 0x0600F38B RID: 62347 RVA: 0x00429B43 File Offset: 0x00427D43
	private void StopDelayHideEnduranceTimer()
	{
		if (this.DelayHideEnduranceTimer != null)
		{
			if (TimerSystem.Instance.Has(this.DelayHideEnduranceTimer))
			{
				TimerSystem.Instance.Remove(this.DelayHideEnduranceTimer);
			}
			this.DelayHideEnduranceTimer = null;
		}
	}

	// Token: 0x0600F38C RID: 62348 RVA: 0x00429B78 File Offset: 0x00427D78
	public override void Tick(float delta)
	{
		base.Tick(delta);
		if (!base.IsShowOrShowing && !base.IsHideOrHiding)
		{
			return;
		}
		if (this.Data == null)
		{
			return;
		}
		if (this.DataDirty)
		{
			this.DataDirty = false;
			this.RefreshAll(false);
		}
		if (this.Data.IsMechanism)
		{
			this.RefreshCamera();
			if (this.OutNodeVisible)
			{
				this.RefreshLocation();
				this.RefreshLocalTime();
			}
		}
		this.RefreshAltimeterUpDownAnim();
		this.RefreshRotateAnim(delta);
		this.RefreshHorizonAnim();
		this.RefreshAltimeterAnim();
		if (this.AnchorRotationDirty)
		{
			this.AnchorRotationDirty = false;
			FRotator frotator = this.AnchorRotation.ToUeRotator();
			foreach (UUIItem uuiitem in this.AnchorItemList)
			{
				uuiitem.SetUIRelativeRotation(frotator);
			}
		}
	}

	// Token: 0x0600F38D RID: 62349 RVA: 0x00429C5C File Offset: 0x00427E5C
	private void RefreshAll(bool isInit = false)
	{
		bool flag = this.Data.IsJoint || this.Data.IsSpecialJoint;
		bool flag2 = this.Data.IsMechanism && this.Data.IsForeground;
		bool flag4;
		bool flag3 = flag4 = flag;
		bool flag5 = !flag3 && this.Data.IsMechanism;
		bool flag6 = flag3 || this.Data.IsMechanism;
		bool isSpecialJoint = this.Data.IsSpecialJoint;
		bool isSprint = this.Data.IsSprint;
		bool flag7 = !this.Data.InFight && !this.Data.IsUltraBuff;
		bool flag8 = flag2 && this.Data.InAir && this.Data.IsForeground;
		bool isUltraBuff = this.Data.IsUltraBuff;
		bool emptyEndurance = this.Data.EmptyEndurance;
		if (isInit)
		{
			this.MechanismNodeVisible = flag2;
			this.JointNodeVisible = flag4;
			this.NoJointNodeVisible = flag5;
			this.JointBgNodeVisible = flag6;
			this.SpecialJointNodeVisible = isSpecialJoint;
			this.SprintVisible = isSprint;
			this.OutNodeVisible = flag7;
			this.AirNodeVisible = flag8;
			this.UltraBuffVisible = isUltraBuff;
			this.PlayExhaustAnim = emptyEndurance;
			this.RefreshMechanismNode(isInit);
			this.RefreshJointNode(isInit);
			this.RefreshNoJointNode();
			this.RefreshJointBgNode();
			this.RefreshSpecialJointNode();
			this.RefreshSprint(isInit);
			this.RefreshOutNode(isInit);
			this.RefreshModeIcon();
			this.RefreshInAir(isInit);
			this.RefreshUltraBuff(isInit);
			this.RefreshExhaustAnim(isInit);
			return;
		}
		if (this.MechanismNodeVisible != flag2)
		{
			this.MechanismNodeVisible = flag2;
			this.RefreshMechanismNode(false);
		}
		if (this.JointNodeVisible != flag4)
		{
			this.JointNodeVisible = flag4;
			this.RefreshJointNode(false);
		}
		if (this.NoJointNodeVisible != flag5)
		{
			this.NoJointNodeVisible = flag5;
			this.RefreshNoJointNode();
		}
		if (this.JointBgNodeVisible != flag6)
		{
			this.JointBgNodeVisible = flag6;
			this.RefreshJointBgNode();
		}
		if (this.SpecialJointNodeVisible != isSpecialJoint)
		{
			this.SpecialJointNodeVisible = isSpecialJoint;
			this.RefreshSpecialJointNode();
		}
		if (this.SprintVisible != isSprint)
		{
			this.SprintVisible = isSprint;
			this.RefreshSprint(false);
		}
		if (this.OutNodeVisible != flag7)
		{
			this.OutNodeVisible = flag7;
			this.RefreshOutNode(false);
		}
		if (this.AirNodeVisible != flag8)
		{
			this.AirNodeVisible = flag8;
			this.RefreshInAir(false);
		}
		if (this.UltraBuffVisible != isUltraBuff)
		{
			this.UltraBuffVisible = isUltraBuff;
			this.RefreshUltraBuff(false);
		}
		if (this.PlayExhaustAnim != emptyEndurance)
		{
			this.PlayExhaustAnim = emptyEndurance;
			this.RefreshExhaustAnim(false);
		}
	}

	// Token: 0x0600F38E RID: 62350 RVA: 0x00429EC4 File Offset: 0x004280C4
	private void RefreshMechanismNode(bool isInit = false)
	{
		if (this.MechanismNodeVisible)
		{
			this.StopTweenAnim(25);
			this.PlayTweenAnim(22);
		}
		else if (isInit)
		{
			this.PlayTweenAnim(17);
		}
		else
		{
			this.StopTweenAnim(22);
			this.PlayTweenAnim(25);
		}
		this.RefreshEnduranceVisible();
	}

	// Token: 0x0600F38F RID: 62351 RVA: 0x00429F03 File Offset: 0x00428103
	private void RefreshJointNode(bool isInit = false)
	{
		if (this.JointNodeVisible)
		{
			this.StopTweenAnim(21);
			this.PlayTweenAnim(19);
			return;
		}
		if (isInit)
		{
			return;
		}
		this.StopTweenAnim(19);
		this.PlayTweenAnim(21);
	}

	// Token: 0x0600F390 RID: 62352 RVA: 0x00429F32 File Offset: 0x00428132
	private void RefreshNoJointNode()
	{
		this.LeftItem1.SetUIActive(this.NoJointNodeVisible);
		this.RightItem1.SetUIActive(this.NoJointNodeVisible);
	}

	// Token: 0x0600F391 RID: 62353 RVA: 0x00429F56 File Offset: 0x00428156
	private void RefreshJointBgNode()
	{
	}

	// Token: 0x0600F392 RID: 62354 RVA: 0x00429F58 File Offset: 0x00428158
	private void RefreshSpecialJointNode()
	{
		if (this.SpecialJointNodeVisible)
		{
			this.PlayTweenAnim(20);
		}
	}

	// Token: 0x0600F393 RID: 62355 RVA: 0x00429F6A File Offset: 0x0042816A
	private void RefreshSprint(bool isInit = false)
	{
		if (this.SprintVisible)
		{
			this.StopTweenAnim(48);
			this.PlayTweenAnim(47);
			return;
		}
		if (isInit)
		{
			return;
		}
		this.StopTweenAnim(47);
		this.PlayTweenAnim(48);
	}

	// Token: 0x0600F394 RID: 62356 RVA: 0x00429F9C File Offset: 0x0042819C
	private void RefreshOutNode(bool isInit = false)
	{
		if (this.OutNodeVisible)
		{
			this.StopTweenAnim(24);
			this.PlayTweenAnim(23);
		}
		else if (!isInit)
		{
			this.StopTweenAnim(23);
			this.PlayTweenAnim(24);
		}
		this.TopItem.SetUIActive(this.OutNodeVisible);
		this.BottomItem.SetUIActive(this.OutNodeVisible);
	}

	// Token: 0x0600F395 RID: 62357 RVA: 0x00429FF8 File Offset: 0x004281F8
	private void RefreshCamera()
	{
		if (this.Data.InFight && !this.RotateAnimInFight)
		{
			this.SetAnchorRoll(0f);
			return;
		}
		float pitch = ControllerBase<CameraController>.Instance.MainModel.CameraRotator.Pitch;
		if (pitch > this.PitchUpMin)
		{
			float anchorRoll = Singleton<MathUtils>.Instance.RangeClamp(pitch, this.PitchUpMin, this.PitchUpMax, 0f, -this.MaxRoll);
			this.SetAnchorRoll(anchorRoll);
			return;
		}
		if (pitch < this.PitchDownMax)
		{
			float anchorRoll2 = Singleton<MathUtils>.Instance.RangeClamp(pitch, this.PitchDownMin, this.PitchDownMax, this.MaxRoll, 0f);
			this.SetAnchorRoll(anchorRoll2);
			return;
		}
		this.SetAnchorRoll(0f);
	}

	// Token: 0x0600F396 RID: 62358 RVA: 0x0042A0B0 File Offset: 0x004282B0
	private void SetAnchorRoll(float roll)
	{
		if (roll == 0f && this.AnchorRotation.Roll != 0f)
		{
			this.AnchorRotation.Roll = 0f;
			this.AnchorRotationDirty = true;
			return;
		}
		if ((double)Math.Abs(this.AnchorRotation.Roll - roll) > 0.01)
		{
			this.AnchorRotation.Roll = roll;
			this.AnchorRotationDirty = true;
		}
	}

	// Token: 0x0600F397 RID: 62359 RVA: 0x0042A120 File Offset: 0x00428320
	private void RefreshRotateAnim(float delta)
	{
		double yaw;
		if (this.Data.InFight && !this.RotateAnimInFight)
		{
			yaw = 0.0;
		}
		else
		{
			yaw = (double)ControllerBase<CameraController>.Instance.MainModel.CameraRotator.Yaw;
		}
		if (this.RotateMachine.Update(delta, yaw))
		{
			float num = (float)(this.RotateMachine.CurValue * (double)this.MaxPitch);
			if (this.AnchorRotation.Pitch != num)
			{
				this.AnchorRotation.Pitch = num;
				this.AnchorRotationDirty = true;
			}
		}
	}

	// Token: 0x0600F398 RID: 62360 RVA: 0x0042A1B4 File Offset: 0x004283B4
	private void RefreshLocation()
	{
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		global::Vector vector;
		if (baseCharacter == null)
		{
			vector = null;
		}
		else
		{
			CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
			vector = ((characterActorComponent != null) ? characterActorComponent.ActorLocationProxy : null);
		}
		global::Vector vector2 = vector;
		if (vector2 == null)
		{
			return;
		}
		int num = (int)Math.Round(vector2.X);
		if (num != this.PlayerLocationX)
		{
			this.PlayerLocationX = num;
			base.GetArtText(11).SetText(num.ToString("F0"));
		}
		int num2 = (int)Math.Round(vector2.Y);
		if (num2 != this.PlayerLocationY)
		{
			this.PlayerLocationY = num2;
			base.GetArtText(12).SetText(num2.ToString("F0"));
		}
		int num3 = (int)Math.Round(vector2.Z);
		if (num3 != this.PlayerLocationZ)
		{
			this.PlayerLocationZ = num3;
			base.GetArtText(13).SetText(num3.ToString("F0"));
		}
	}

	// Token: 0x0600F399 RID: 62361 RVA: 0x0042A288 File Offset: 0x00428488
	private void RefreshLocalTime()
	{
		DateTime now = DateTime.Now;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 3);
		defaultInterpolatedStringHandler.AppendFormatted<int>(now.Hour, "D2");
		defaultInterpolatedStringHandler.AppendFormatted<int>(now.Minute, "D2");
		defaultInterpolatedStringHandler.AppendLiteral(".");
		defaultInterpolatedStringHandler.AppendFormatted<int>(now.Second, "D2");
		string text = defaultInterpolatedStringHandler.ToStringAndClear();
		base.GetArtText(14).SetText(text);
	}

	// Token: 0x0600F39A RID: 62362 RVA: 0x0042A300 File Offset: 0x00428500
	private void RefreshAltimeterUpDownAnim()
	{
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		global::Vector vector;
		if (baseCharacter == null)
		{
			vector = null;
		}
		else
		{
			CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
			vector = ((characterActorComponent != null) ? characterActorComponent.ActorLocationProxy : null);
		}
		global::Vector vector2 = vector;
		if (vector2 == null)
		{
			return;
		}
		if (!this.IsInitAltimeterZ)
		{
			this.AltimeterZ = vector2.Z;
			this.IsInitAltimeterZ = true;
			return;
		}
		double num = vector2.Z - this.AltimeterZ;
		this.AltimeterZ = vector2.Z;
		int num2 = 0;
		if (num > 1.0)
		{
			num2 = 1;
		}
		else if (num < -1.0)
		{
			num2 = -1;
		}
		if (this.UpDownState != num2)
		{
			this.UpDownState = num2;
			if (num2 == 1)
			{
				this.StopTweenAnim(33);
				this.PlayTweenAnim(32);
				return;
			}
			if (num2 == -1)
			{
				this.StopTweenAnim(32);
				this.PlayTweenAnim(33);
				return;
			}
			this.StopTweenAnim(32);
			this.StopTweenAnim(33);
			this.PlayTweenAnim(31);
		}
	}

	// Token: 0x0600F39B RID: 62363 RVA: 0x0042A3D8 File Offset: 0x004285D8
	public void RefreshModeIcon()
	{
		if (this.Data == null)
		{
			return;
		}
		if (this.Data.IsModeOne)
		{
			base.GetItem(15).SetAlpha(1f);
			base.GetItem(16).SetAlpha(0.168628f);
			return;
		}
		base.GetItem(15).SetAlpha(0.168628f);
		base.GetItem(16).SetAlpha(1f);
	}

	// Token: 0x0600F39C RID: 62364 RVA: 0x0042A444 File Offset: 0x00428644
	public void RefreshInAir(bool isInit = false)
	{
		if (this.AirNodeVisible)
		{
			this.StopTweenAnim(34);
			this.PlayTweenAnim(30);
			return;
		}
		if (isInit)
		{
			return;
		}
		this.StopTweenAnim(30);
		this.PlayTweenAnim(34);
	}

	// Token: 0x0600F39D RID: 62365 RVA: 0x0042A473 File Offset: 0x00428673
	public void RefreshUltraBuff(bool isInit = false)
	{
		if (this.UltraBuffVisible)
		{
			this.StopTweenAnim(27);
			this.PlayTweenAnim(26);
			return;
		}
		if (isInit)
		{
			return;
		}
		this.StopTweenAnim(26);
		this.PlayTweenAnim(27);
	}

	// Token: 0x0600F39E RID: 62366 RVA: 0x0042A4A2 File Offset: 0x004286A2
	private void RefreshExhaustAnim(bool isInit = false)
	{
		if (this.PlayExhaustAnim)
		{
			this.StopTweenAnim(50);
			this.PlayTweenAnim(49);
			return;
		}
		if (isInit)
		{
			return;
		}
		this.StopTweenAnim(49);
		this.PlayTweenAnim(50);
	}

	// Token: 0x0600F39F RID: 62367 RVA: 0x0042A4D1 File Offset: 0x004286D1
	public void OnHurt()
	{
		this.PlayTweenAnim(35);
	}

	// Token: 0x0600F3A0 RID: 62368 RVA: 0x0042A4DC File Offset: 0x004286DC
	public void SetHpPercent(float percent)
	{
		bool flag = percent <= 0.2f;
		if (this.LowHp == flag)
		{
			return;
		}
		this.LowHp = flag;
		if (flag)
		{
			this.StopTweenAnim(37);
			this.PlayTweenAnim(36);
			return;
		}
		this.StopTweenAnim(36);
		this.PlayTweenAnim(37);
	}

	// Token: 0x0600F3A1 RID: 62369 RVA: 0x0042A52C File Offset: 0x0042872C
	private void RefreshHorizonAnim()
	{
		if (!this.JointBgNodeVisible)
		{
			return;
		}
		float num = ControllerBase<CameraController>.Instance.MainModel.CameraRotator.Yaw % this.HorizonScaleSpeed / this.HorizonScaleSpeed;
		if ((double)Math.Abs(this.ValueSliderX - num) < 0.001)
		{
			return;
		}
		this.ValueSliderX = num;
		this.TexHorizonScaleL.SetCustomMaterialScalarParameter(this.NameSliderX, num);
		this.TexHorizonScaleR.SetCustomMaterialScalarParameter(this.NameSliderX, -num);
		this.TexTopScale.SetCustomMaterialScalarParameter(this.NameSliderX, num);
	}

	// Token: 0x0600F3A2 RID: 62370 RVA: 0x0042A5C0 File Offset: 0x004287C0
	private void RefreshAltimeterAnim()
	{
		float num = (float)Math.Round(this.AltimeterZ) % this.AltimeterScaleSpeed / this.AltimeterScaleSpeed;
		if ((double)Math.Abs(this.ValueSliderY - num) < 0.001)
		{
			return;
		}
		this.ValueSliderY = num;
		this.TexAltimeterScale.SetCustomMaterialScalarParameter(this.NameSliderY, num);
	}

	// Token: 0x0600F3A3 RID: 62371 RVA: 0x0042A61B File Offset: 0x0042881B
	protected new void PlayTweenAnim(int componentType)
	{
		base.PlayTweenAnim(componentType);
	}

	// Token: 0x0600F3A4 RID: 62372 RVA: 0x0042A624 File Offset: 0x00428824
	protected new void StopTweenAnim(int componentType)
	{
		base.StopTweenAnim(componentType);
	}

	// Token: 0x040074FA RID: 29946
	private const int CLOSE_ANIM_TIME = 100;

	// Token: 0x040074FB RID: 29947
	private bool TargetVisible;

	// Token: 0x040074FC RID: 29948
	private AiMiSiHudData Data;

	// Token: 0x040074FD RID: 29949
	private bool DataDirty;

	// Token: 0x040074FE RID: 29950
	private bool MechanismNodeVisible;

	// Token: 0x040074FF RID: 29951
	private bool JointNodeVisible;

	// Token: 0x04007500 RID: 29952
	private bool NoJointNodeVisible;

	// Token: 0x04007501 RID: 29953
	private bool JointBgNodeVisible;

	// Token: 0x04007502 RID: 29954
	private bool SpecialJointNodeVisible;

	// Token: 0x04007503 RID: 29955
	private bool SprintVisible;

	// Token: 0x04007504 RID: 29956
	private bool OutNodeVisible;

	// Token: 0x04007505 RID: 29957
	private bool AirNodeVisible;

	// Token: 0x04007506 RID: 29958
	private bool UltraBuffVisible;

	// Token: 0x04007507 RID: 29959
	private bool PlayExhaustAnim;

	// Token: 0x04007508 RID: 29960
	private TimerHandle CloseTimer;

	// Token: 0x04007509 RID: 29961
	private CustomPromise Promise;

	// Token: 0x0400750A RID: 29962
	private UUIItem EnduranceItem;

	// Token: 0x0400750B RID: 29963
	private UUISprite EnduranceBarSprite;

	// Token: 0x0400750C RID: 29964
	private float EnduranceProgress;

	// Token: 0x0400750D RID: 29965
	private bool EnduranceVisible;

	// Token: 0x0400750E RID: 29966
	private bool TargetEnduranceVisible;

	// Token: 0x0400750F RID: 29967
	private TimerHandle DelayHideEnduranceTimer;

	// Token: 0x04007510 RID: 29968
	private UUIItem TopItem;

	// Token: 0x04007511 RID: 29969
	private UUIItem BottomItem;

	// Token: 0x04007512 RID: 29970
	private UUIItem LeftItem1;

	// Token: 0x04007513 RID: 29971
	private UUIItem RightItem1;

	// Token: 0x04007514 RID: 29972
	private UUITexture TexAltimeterScale;

	// Token: 0x04007515 RID: 29973
	private UUITexture TexHorizonScaleL;

	// Token: 0x04007516 RID: 29974
	private UUITexture TexHorizonScaleR;

	// Token: 0x04007517 RID: 29975
	private UUITexture TexTopScale;

	// Token: 0x04007518 RID: 29976
	[Nullable(1)]
	private readonly List<UUIItem> AnchorItemList = new List<UUIItem>();

	// Token: 0x04007519 RID: 29977
	private float PitchUpMin = 10f;

	// Token: 0x0400751A RID: 29978
	private float PitchUpMax = 30f;

	// Token: 0x0400751B RID: 29979
	private float PitchDownMin = -40f;

	// Token: 0x0400751C RID: 29980
	private float PitchDownMax = -20f;

	// Token: 0x0400751D RID: 29981
	private float HorizonScaleSpeed = 90f;

	// Token: 0x0400751E RID: 29982
	private float AltimeterScaleSpeed = 100f;

	// Token: 0x0400751F RID: 29983
	private float MaxPitch = 15f;

	// Token: 0x04007520 RID: 29984
	private float MaxRoll = 15f;

	// Token: 0x04007521 RID: 29985
	private int PlayerLocationX;

	// Token: 0x04007522 RID: 29986
	private int PlayerLocationY;

	// Token: 0x04007523 RID: 29987
	private int PlayerLocationZ;

	// Token: 0x04007524 RID: 29988
	private double AltimeterZ;

	// Token: 0x04007525 RID: 29989
	private bool IsInitAltimeterZ;

	// Token: 0x04007526 RID: 29990
	private bool LowHp;

	// Token: 0x04007527 RID: 29991
	private int UpDownState;

	// Token: 0x04007528 RID: 29992
	private bool IsInitKey;

	// Token: 0x04007529 RID: 29993
	[Nullable(1)]
	private readonly List<InputMultiKeyItem> KeyItemList = new List<InputMultiKeyItem>();

	// Token: 0x0400752A RID: 29994
	[Nullable(1)]
	private readonly AiMiSiHudUnitRotateMachine RotateMachine = new AiMiSiHudUnitRotateMachine();

	// Token: 0x0400752B RID: 29995
	[Nullable(1)]
	private readonly Rotator AnchorRotation = Rotator.Create(0f, 0f, 0f);

	// Token: 0x0400752C RID: 29996
	private bool AnchorRotationDirty;

	// Token: 0x0400752D RID: 29997
	private bool RotateAnimInFight;

	// Token: 0x0400752E RID: 29998
	private float ValueSliderX;

	// Token: 0x0400752F RID: 29999
	private float ValueSliderY;

	// Token: 0x04007530 RID: 30000
	private readonly FName NameSliderX = FNameUtil.GetDynamicFName("SliderX").Value;

	// Token: 0x04007531 RID: 30001
	private readonly FName NameSliderY = FNameUtil.GetDynamicFName("SliderY").Value;

	// Token: 0x02008326 RID: 33574
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402C779 RID: 182137
		EnduranceItem,
		// Token: 0x0402C77A RID: 182138
		EnduranceBarSprite,
		// Token: 0x0402C77B RID: 182139
		TopItem,
		// Token: 0x0402C77C RID: 182140
		BottomItem,
		// Token: 0x0402C77D RID: 182141
		LeftItem1,
		// Token: 0x0402C77E RID: 182142
		LeftItem2,
		// Token: 0x0402C77F RID: 182143
		LeftRedItem,
		// Token: 0x0402C780 RID: 182144
		RightItem1,
		// Token: 0x0402C781 RID: 182145
		RightItem2,
		// Token: 0x0402C782 RID: 182146
		RightRedItem,
		// Token: 0x0402C783 RID: 182147
		MidItem,
		// Token: 0x0402C784 RID: 182148
		ArtTextPosX,
		// Token: 0x0402C785 RID: 182149
		ArtTextPosY,
		// Token: 0x0402C786 RID: 182150
		ArtTextPosZ,
		// Token: 0x0402C787 RID: 182151
		ArtTextTime,
		// Token: 0x0402C788 RID: 182152
		LeftModeItem,
		// Token: 0x0402C789 RID: 182153
		RightModeItem,
		// Token: 0x0402C78A RID: 182154
		AniDefaultSet,
		// Token: 0x0402C78B RID: 182155
		AniPilotSet,
		// Token: 0x0402C78C RID: 182156
		AniAssaultIn,
		// Token: 0x0402C78D RID: 182157
		AniAssaultExIn,
		// Token: 0x0402C78E RID: 182158
		AniAssaultOut,
		// Token: 0x0402C78F RID: 182159
		AniPilotIn,
		// Token: 0x0402C790 RID: 182160
		AniDisEngage,
		// Token: 0x0402C791 RID: 182161
		AniEngage,
		// Token: 0x0402C792 RID: 182162
		AniPilotOut,
		// Token: 0x0402C793 RID: 182163
		AniBuffIn,
		// Token: 0x0402C794 RID: 182164
		AniBuffOut,
		// Token: 0x0402C795 RID: 182165
		AniSprintBarIn,
		// Token: 0x0402C796 RID: 182166
		AniSprintBarOut,
		// Token: 0x0402C797 RID: 182167
		AniAltimeterIn,
		// Token: 0x0402C798 RID: 182168
		AniAltimeterSet,
		// Token: 0x0402C799 RID: 182169
		AniAltimeterUp,
		// Token: 0x0402C79A RID: 182170
		AniAltimeterDown,
		// Token: 0x0402C79B RID: 182171
		AniAltimeterOut,
		// Token: 0x0402C79C RID: 182172
		AniHurt,
		// Token: 0x0402C79D RID: 182173
		AniWarningIn,
		// Token: 0x0402C79E RID: 182174
		AniWarningOut,
		// Token: 0x0402C79F RID: 182175
		TexAltimeterScale,
		// Token: 0x0402C7A0 RID: 182176
		TexHorizonScaleL,
		// Token: 0x0402C7A1 RID: 182177
		TexHorizonScaleR,
		// Token: 0x0402C7A2 RID: 182178
		TexTopScale,
		// Token: 0x0402C7A3 RID: 182179
		AnchorItem1,
		// Token: 0x0402C7A4 RID: 182180
		AniEnduranceIn,
		// Token: 0x0402C7A5 RID: 182181
		AniEnduranceOut,
		// Token: 0x0402C7A6 RID: 182182
		KeyNode1,
		// Token: 0x0402C7A7 RID: 182183
		KeyNode2,
		// Token: 0x0402C7A8 RID: 182184
		AniSprintIn,
		// Token: 0x0402C7A9 RID: 182185
		AniSprintOut,
		// Token: 0x0402C7AA RID: 182186
		AniExhaustIn,
		// Token: 0x0402C7AB RID: 182187
		AniExhaustOut,
		// Token: 0x0402C7AC RID: 182188
		AnchorItem2,
		// Token: 0x0402C7AD RID: 182189
		AnchorItem3
	}
}
