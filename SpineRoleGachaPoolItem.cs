using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.DreamLink;
using CSharpScript.Game.Module.SkipInterface;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001CF4 RID: 7412
[NullableContext(2)]
[Nullable(0)]
public class SpineRoleGachaPoolItem : GachaPoolItem
{
	// Token: 0x0600D998 RID: 55704 RVA: 0x003A5E07 File Offset: 0x003A4007
	public SpineRoleGachaPoolItem(GachaDefine.EGachaViewType gachaType) : base(gachaType)
	{
	}

	// Token: 0x0600D999 RID: 55705 RVA: 0x003A5E10 File Offset: 0x003A4010
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(USpineSkeletonAnimationComponent));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D99A RID: 55706 RVA: 0x003A5E9C File Offset: 0x003A409C
	protected override UniTask OnBeforeStartAsync()
	{
		SpineRoleGachaPoolItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SpineRoleGachaPoolItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D99B RID: 55707 RVA: 0x003A5EE0 File Offset: 0x003A40E0
	private UniTask AddDesc()
	{
		SpineRoleGachaPoolItem.<AddDesc>d__5 <AddDesc>d__;
		<AddDesc>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<AddDesc>d__.<>4__this = this;
		<AddDesc>d__.<>1__state = -1;
		<AddDesc>d__.<>t__builder.Start<SpineRoleGachaPoolItem.<AddDesc>d__5>(ref <AddDesc>d__);
		return <AddDesc>d__.<>t__builder.Task;
	}

	// Token: 0x0600D99C RID: 55708 RVA: 0x003A5F24 File Offset: 0x003A4124
	private UniTask AddButton()
	{
		SpineRoleGachaPoolItem.<AddButton>d__6 <AddButton>d__;
		<AddButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<AddButton>d__.<>4__this = this;
		<AddButton>d__.<>1__state = -1;
		<AddButton>d__.<>t__builder.Start<SpineRoleGachaPoolItem.<AddButton>d__6>(ref <AddButton>d__);
		return <AddButton>d__.<>t__builder.Task;
	}

	// Token: 0x0600D99D RID: 55709 RVA: 0x003A5F68 File Offset: 0x003A4168
	public override void Refresh()
	{
		if (this.GachaViewInfo == null)
		{
			return;
		}
		int gachaTextureInfoId = this.GachaViewInfo.Value.GetShowIdListArray()[0];
		this.DescComponent.Update(gachaTextureInfoId, this.GachaType.GetValueOrDefault() != GachaDefine.EGachaViewType.NewPlayerCustom);
		if (!StringUtils.IsBlank(this.GachaViewInfo.Value.TextTexture))
		{
			base.SetTextureByPath(this.GachaViewInfo.Value.TextTexture, base.GetTexture(1), null, null);
		}
		this.RefreshAnimation();
		bool flag = ModelBase<ActivityModel>.Instance.IsActivityOpen(this.GachaViewInfo.Value.TrialActivityId);
		ButtonFunctionComponent buttonFunctionComponent = this.ButtonFunctionComponent;
		if (buttonFunctionComponent == null)
		{
			return;
		}
		buttonFunctionComponent.SetUiActive(this.GachaViewInfo.Value.JumpId > 0 || (this.GachaViewInfo.Value.TrialActivityId > 0 && flag));
	}

	// Token: 0x0600D99E RID: 55710 RVA: 0x003A605F File Offset: 0x003A425F
	public void SetDescUiActive(bool bActive)
	{
		this.DescComponent.SetUiActive(bActive);
	}

	// Token: 0x0600D99F RID: 55711 RVA: 0x003A606D File Offset: 0x003A426D
	public void RefreshAnimation()
	{
		base.GetSpine(2).SetAnimation(0, EDreamLinkSpineDefine.Idle.ToString(), true);
	}

	// Token: 0x0600D9A0 RID: 55712 RVA: 0x003A6090 File Offset: 0x003A4290
	private void OnSkipButtonClick()
	{
		if (this.GachaViewInfo.Value.JumpId > 0)
		{
			SkipTaskManager.RunByConfigId(this.GachaViewInfo.Value.JumpId, null);
			return;
		}
		if (!ModelBase<ActivityModel>.Instance.IsActivityOpen(this.GachaViewInfo.Value.TrialActivityId))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ErrorCode_1100253_Text", Array.Empty<object>());
			return;
		}
		ControllerBase<ActivityController>.Instance.OpenActivityById(this.GachaViewInfo.Value.TrialActivityId, EActivityViewOpenType.Other, this.GachaViewInfo.Value.TrialRoleId, null);
		OnClickGachaTryRoleLogEvent onClickGachaTryRoleLogEvent = new OnClickGachaTryRoleLogEvent();
		onClickGachaTryRoleLogEvent.i_gacha_id = this.GachaViewInfo.Value.Id;
		onClickGachaTryRoleLogEvent.i_role_id = this.GachaViewInfo.Value.GetShowIdListArray()[0];
		ControllerBase<LogReportController>.Instance.LogReport(onClickGachaTryRoleLogEvent);
	}

	// Token: 0x040067DA RID: 26586
	private RoleDescribeComponent DescComponent;

	// Token: 0x040067DB RID: 26587
	private ButtonFunctionComponent ButtonFunctionComponent;
}
