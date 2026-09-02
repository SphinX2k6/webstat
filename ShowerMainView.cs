using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002A10 RID: 10768
[NullableContext(2)]
[Nullable(0)]
public class ShowerMainView : UiTickViewBase
{
	// Token: 0x060157DD RID: 88029 RVA: 0x005F5507 File Offset: 0x005F3707
	[NullableContext(1)]
	public ShowerMainView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060157DE RID: 88030 RVA: 0x005F5510 File Offset: 0x005F3710
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(delegate()
			{
				this.OnCloseButtonClick().Forget();
			}))
		};
	}

	// Token: 0x060157DF RID: 88031 RVA: 0x005F55A4 File Offset: 0x005F37A4
	protected override UniTask OnBeforeStartAsync()
	{
		ShowerMainView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShowerMainView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060157E0 RID: 88032 RVA: 0x005F55E7 File Offset: 0x005F37E7
	protected override void OnBeforeShow()
	{
		this.IsFirstPerson = false;
	}

	// Token: 0x060157E1 RID: 88033 RVA: 0x005F55F0 File Offset: 0x005F37F0
	protected override void OnStart()
	{
		this.InviteSkillItem.SetPressCallback(delegate
		{
			this.OnInviteButtonClick().Forget();
		});
		this.ChangeVisionSkillItem.SetPressCallback(delegate
		{
			this.OnChangeVisionButtonClick().Forget();
		});
		this.TakePictureSkillItem.SetPressCallback(new Action(this.OnTakePictureButtonClick));
	}

	// Token: 0x060157E2 RID: 88034 RVA: 0x005F5642 File Offset: 0x005F3842
	protected override void OnTick(float delta)
	{
		this.ChangeVisionSkillItem.TickSkillCoolDown(delta);
	}

	// Token: 0x060157E3 RID: 88035 RVA: 0x005F5650 File Offset: 0x005F3850
	private UniTask OnInviteButtonClick()
	{
		ShowerMainView.<OnInviteButtonClick>d__11 <OnInviteButtonClick>d__;
		<OnInviteButtonClick>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnInviteButtonClick>d__.<>4__this = this;
		<OnInviteButtonClick>d__.<>1__state = -1;
		<OnInviteButtonClick>d__.<>t__builder.Start<ShowerMainView.<OnInviteButtonClick>d__11>(ref <OnInviteButtonClick>d__);
		return <OnInviteButtonClick>d__.<>t__builder.Task;
	}

	// Token: 0x060157E4 RID: 88036 RVA: 0x005F5694 File Offset: 0x005F3894
	private UniTask OnChangeVisionButtonClick()
	{
		ShowerMainView.<OnChangeVisionButtonClick>d__12 <OnChangeVisionButtonClick>d__;
		<OnChangeVisionButtonClick>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnChangeVisionButtonClick>d__.<>4__this = this;
		<OnChangeVisionButtonClick>d__.<>1__state = -1;
		<OnChangeVisionButtonClick>d__.<>t__builder.Start<ShowerMainView.<OnChangeVisionButtonClick>d__12>(ref <OnChangeVisionButtonClick>d__);
		return <OnChangeVisionButtonClick>d__.<>t__builder.Task;
	}

	// Token: 0x060157E5 RID: 88037 RVA: 0x005F56D8 File Offset: 0x005F38D8
	private void OnTakePictureButtonClick()
	{
		PhotoSaveViewParam param = new PhotoSaveViewParam
		{
			ScreenShot = true,
			PrepareFullScreenShot = false,
			IsHiddenBattleView = true,
			HandBookPhotoData = null,
			GachaData = null,
			FragmentMemory = null,
			RoleSkinData = null,
			ShareId = 1
		};
		ControllerBase<PhotographController>.Instance.ScreenShot(param);
	}

	// Token: 0x060157E6 RID: 88038 RVA: 0x005F5730 File Offset: 0x005F3930
	private UniTask OnCloseButtonClick()
	{
		ShowerMainView.<OnCloseButtonClick>d__14 <OnCloseButtonClick>d__;
		<OnCloseButtonClick>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnCloseButtonClick>d__.<>4__this = this;
		<OnCloseButtonClick>d__.<>1__state = -1;
		<OnCloseButtonClick>d__.<>t__builder.Start<ShowerMainView.<OnCloseButtonClick>d__14>(ref <OnCloseButtonClick>d__);
		return <OnCloseButtonClick>d__.<>t__builder.Task;
	}

	// Token: 0x0400A55A RID: 42330
	private ShowerSkillButton InviteSkillItem;

	// Token: 0x0400A55B RID: 42331
	private ShowerSkillButton ChangeVisionSkillItem;

	// Token: 0x0400A55C RID: 42332
	private ShowerSkillButton TakePictureSkillItem;

	// Token: 0x0400A55D RID: 42333
	private bool IsFirstPerson;

	// Token: 0x02008D91 RID: 36241
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402F9A7 RID: 194983
		public const int InviteSkillItem = 0;

		// Token: 0x0402F9A8 RID: 194984
		public const int ChangeVisionSkillItem = 1;

		// Token: 0x0402F9A9 RID: 194985
		public const int TakePictureSkillItem = 2;

		// Token: 0x0402F9AA RID: 194986
		public const int CloseButton = 3;
	}
}
