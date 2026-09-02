using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002A06 RID: 10758
[NullableContext(2)]
[Nullable(0)]
public class MoonTogetherMainView : UiTickViewBase
{
	// Token: 0x06015772 RID: 87922 RVA: 0x005F350F File Offset: 0x005F170F
	[NullableContext(1)]
	public MoonTogetherMainView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06015773 RID: 87923 RVA: 0x005F3518 File Offset: 0x005F1718
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(delegate()
			{
				this.OnCloseButtonClick().Forget();
			}))
		};
	}

	// Token: 0x06015774 RID: 87924 RVA: 0x005F35C4 File Offset: 0x005F17C4
	protected override UniTask OnBeforeStartAsync()
	{
		MoonTogetherMainView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MoonTogetherMainView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015775 RID: 87925 RVA: 0x005F3608 File Offset: 0x005F1808
	protected override void OnStart()
	{
		base.GetItem(4).SetUIActive(false);
		this.InviteSkillItem.SetPressCallback(delegate
		{
			this.OnInviteButtonClick().Forget();
		});
		this.ChangeVisionSkillItem.SetPressCallback(delegate
		{
			this.OnChangeVisionButtonClick().Forget();
		});
		this.TakePictureSkillItem.SetPressCallback(new Action(this.OnTakePictureButtonClick));
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		Entity entity = (baseCharacter != null) ? baseCharacter.GetEntityNoBlueprint() : null;
		BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
		if (baseTagComponent != null)
		{
			baseTagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["系统.功能.致敬观察索拉里斯.默认镜头"]));
		}
		IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("MoonTogetherCameraRotation");
		ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.ResetArmLengthAndRotation(Rotator.ZeroRotator);
		ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.SetRotation(Rotator.Create((float)((intArrayConfig != null) ? intArrayConfig.GetValueOrNull(0) : null).GetValueOrDefault(), (float)((intArrayConfig != null) ? intArrayConfig.GetValueOrNull(1) : null).GetValueOrDefault(), (float)((intArrayConfig != null) ? intArrayConfig.GetValueOrNull(2) : null).GetValueOrDefault()).ToUeRotator());
		ModelBase<MoonTogetherModel>.Instance.IsInMoonTogether = true;
	}

	// Token: 0x06015776 RID: 87926 RVA: 0x005F3754 File Offset: 0x005F1954
	protected override void OnBeforeDestroy()
	{
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		Entity entity = (baseCharacter != null) ? baseCharacter.GetEntityNoBlueprint() : null;
		BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
		if (baseTagComponent != null)
		{
			baseTagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["系统.功能.致敬观察索拉里斯.第一人称镜头"]));
		}
		if (baseTagComponent == null)
		{
			return;
		}
		baseTagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["系统.功能.致敬观察索拉里斯.默认镜头"]));
	}

	// Token: 0x06015777 RID: 87927 RVA: 0x005F37C0 File Offset: 0x005F19C0
	protected override void OnBeforeShow()
	{
		this.IsFirstPerson = false;
		int curInviteRoleId = ModelBase<MoonTogetherModel>.Instance.CurInviteRoleId;
		if (curInviteRoleId > 0 && ModelBase<MoonTogetherModel>.Instance.IsLinkageRole(curInviteRoleId))
		{
			this.OnInviteLinkageRole();
			return;
		}
		this.OnInviteNormalRole();
	}

	// Token: 0x06015778 RID: 87928 RVA: 0x005F37FD File Offset: 0x005F19FD
	protected override void OnTick(float delta)
	{
		this.ChangeVisionSkillItem.TickSkillCoolDown(delta);
	}

	// Token: 0x06015779 RID: 87929 RVA: 0x005F380C File Offset: 0x005F1A0C
	private UniTask OnInviteButtonClick()
	{
		MoonTogetherMainView.<OnInviteButtonClick>d__12 <OnInviteButtonClick>d__;
		<OnInviteButtonClick>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnInviteButtonClick>d__.<>4__this = this;
		<OnInviteButtonClick>d__.<>1__state = -1;
		<OnInviteButtonClick>d__.<>t__builder.Start<MoonTogetherMainView.<OnInviteButtonClick>d__12>(ref <OnInviteButtonClick>d__);
		return <OnInviteButtonClick>d__.<>t__builder.Task;
	}

	// Token: 0x0601577A RID: 87930 RVA: 0x005F3850 File Offset: 0x005F1A50
	private UniTask OnChangeVisionButtonClick()
	{
		MoonTogetherMainView.<OnChangeVisionButtonClick>d__13 <OnChangeVisionButtonClick>d__;
		<OnChangeVisionButtonClick>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnChangeVisionButtonClick>d__.<>4__this = this;
		<OnChangeVisionButtonClick>d__.<>1__state = -1;
		<OnChangeVisionButtonClick>d__.<>t__builder.Start<MoonTogetherMainView.<OnChangeVisionButtonClick>d__13>(ref <OnChangeVisionButtonClick>d__);
		return <OnChangeVisionButtonClick>d__.<>t__builder.Task;
	}

	// Token: 0x0601577B RID: 87931 RVA: 0x005F3894 File Offset: 0x005F1A94
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

	// Token: 0x0601577C RID: 87932 RVA: 0x005F38EC File Offset: 0x005F1AEC
	private UniTask OnCloseButtonClick()
	{
		MoonTogetherMainView.<OnCloseButtonClick>d__15 <OnCloseButtonClick>d__;
		<OnCloseButtonClick>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnCloseButtonClick>d__.<>4__this = this;
		<OnCloseButtonClick>d__.<>1__state = -1;
		<OnCloseButtonClick>d__.<>t__builder.Start<MoonTogetherMainView.<OnCloseButtonClick>d__15>(ref <OnCloseButtonClick>d__);
		return <OnCloseButtonClick>d__.<>t__builder.Task;
	}

	// Token: 0x0601577D RID: 87933 RVA: 0x005F3930 File Offset: 0x005F1B30
	public void OnInviteLinkageRole()
	{
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_IconMoonView01");
		ShowerSkillButton inviteSkillItem = this.InviteSkillItem;
		if (inviteSkillItem != null)
		{
			inviteSkillItem.SetSkillIconSprite(resourcePath);
		}
		ShowerSkillButton changeVisionSkillItem = this.ChangeVisionSkillItem;
		if (changeVisionSkillItem != null)
		{
			changeVisionSkillItem.SetButtonInteractive(false);
		}
		ShowerSkillButton changeVisionSkillItem2 = this.ChangeVisionSkillItem;
		if (changeVisionSkillItem2 == null)
		{
			return;
		}
		changeVisionSkillItem2.SetDisabledHint(delegate
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Perspective_switching_disabled_Tips", Array.Empty<object>());
		});
	}

	// Token: 0x0601577E RID: 87934 RVA: 0x005F39A0 File Offset: 0x005F1BA0
	public void OnInviteNormalRole()
	{
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_IconMoonView02");
		ShowerSkillButton inviteSkillItem = this.InviteSkillItem;
		if (inviteSkillItem != null)
		{
			inviteSkillItem.SetSkillIconSprite(resourcePath);
		}
		ShowerSkillButton changeVisionSkillItem = this.ChangeVisionSkillItem;
		if (changeVisionSkillItem != null)
		{
			changeVisionSkillItem.SetButtonInteractive(true);
		}
		ShowerSkillButton changeVisionSkillItem2 = this.ChangeVisionSkillItem;
		if (changeVisionSkillItem2 == null)
		{
			return;
		}
		changeVisionSkillItem2.SetDisabledHint(null);
	}

	// Token: 0x0400A52E RID: 42286
	private ShowerSkillButton InviteSkillItem;

	// Token: 0x0400A52F RID: 42287
	private ShowerSkillButton ChangeVisionSkillItem;

	// Token: 0x0400A530 RID: 42288
	private ShowerSkillButton TakePictureSkillItem;

	// Token: 0x0400A531 RID: 42289
	private bool IsFirstPerson;

	// Token: 0x02008D83 RID: 36227
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402F961 RID: 194913
		public const int InviteSkillItem = 0;

		// Token: 0x0402F962 RID: 194914
		public const int ChangeVisionSkillItem = 1;

		// Token: 0x0402F963 RID: 194915
		public const int TakePictureSkillItem = 2;

		// Token: 0x0402F964 RID: 194916
		public const int CloseButton = 3;

		// Token: 0x0402F965 RID: 194917
		public const int NiaItem = 4;
	}
}
