using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002D49 RID: 11593
[NullableContext(2)]
[Nullable(0)]
public class WeeklyRogueInfoView : UiViewBase
{
	// Token: 0x06017634 RID: 95796 RVA: 0x0067C18C File Offset: 0x0067A38C
	[NullableContext(1)]
	public WeeklyRogueInfoView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06017635 RID: 95797 RVA: 0x0067C198 File Offset: 0x0067A398
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(2, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(6, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnBtnClose)),
			new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnToggleRoleInfo)),
			new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnToggleTokenInfo)),
			new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.OnToggleDesc))
		};
	}

	// Token: 0x06017636 RID: 95798 RVA: 0x0067C2B5 File Offset: 0x0067A4B5
	private void OnBtnClose()
	{
		base.CloseMe(null);
	}

	// Token: 0x06017637 RID: 95799 RVA: 0x0067C2BE File Offset: 0x0067A4BE
	private void OnToggleDesc(EToggleState toggleState)
	{
		ModelBase<WeeklyRogueModel>.Instance.ChangeDescMode();
	}

	// Token: 0x06017638 RID: 95800 RVA: 0x0067C2CC File Offset: 0x0067A4CC
	private void OnToggleRoleInfo(EToggleState toggleState)
	{
		base.GetExtendToggle(2).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		this.TeamInfoPanel.SetActive(true);
		this.TokenInfoPanel.SetActive(false);
		UUIItem rootComponent = base.GetExtendToggle(5).GetRootComponent();
		if (rootComponent != null)
		{
			rootComponent.SetUIActive(false);
		}
		base.GetText(6).SetUIActive(false);
		TsUiSceneRoleActor tsUiSceneRoleActor = this.TsUiSceneRoleActor;
		object obj;
		if (tsUiSceneRoleActor == null)
		{
			obj = null;
		}
		else
		{
			UiModelBase model = tsUiSceneRoleActor.Model;
			obj = ((model != null) ? model.CheckGetComponent<UiModelDataComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 == null)
		{
			return;
		}
		obj2.SetVisible(true);
	}

	// Token: 0x06017639 RID: 95801 RVA: 0x0067C354 File Offset: 0x0067A554
	private void OnToggleTokenInfo(EToggleState toggleState)
	{
		base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		this.TeamInfoPanel.SetActive(false);
		this.TokenInfoPanel.SetActive(true);
		UUIItem rootComponent = base.GetExtendToggle(5).GetRootComponent();
		if (rootComponent != null)
		{
			rootComponent.SetUIActive(true);
		}
		base.GetText(6).SetUIActive(true);
		TsUiSceneRoleActor tsUiSceneRoleActor = this.TsUiSceneRoleActor;
		object obj;
		if (tsUiSceneRoleActor == null)
		{
			obj = null;
		}
		else
		{
			UiModelBase model = tsUiSceneRoleActor.Model;
			obj = ((model != null) ? model.CheckGetComponent<UiModelDataComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 == null)
		{
			return;
		}
		obj2.SetVisible(false);
	}

	// Token: 0x0601763A RID: 95802 RVA: 0x0067C3DC File Offset: 0x0067A5DC
	protected override UniTask OnBeforeStartAsync()
	{
		WeeklyRogueInfoView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WeeklyRogueInfoView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601763B RID: 95803 RVA: 0x0067C420 File Offset: 0x0067A620
	protected override void OnHandleLoadScene()
	{
		if (this.TsUiSceneRoleActor == null)
		{
			this.TsUiSceneRoleActor = Singleton<UiSceneManager>.Instance.InitRoleSystemRoleActor(EUiModelUseWay.RoleInRoleView);
		}
		UiModelBase model = this.TsUiSceneRoleActor.Model;
		UiModelActorComponent uiModelActorComponent = (model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null;
		if (uiModelActorComponent == null)
		{
			return;
		}
		uiModelActorComponent.SetTransformByTag("RoleCase");
	}

	// Token: 0x0601763C RID: 95804 RVA: 0x0067C46C File Offset: 0x0067A66C
	protected override void OnHandleReleaseScene()
	{
		Singleton<UiSceneManager>.Instance.DestroyRoleSystemRoleActor(this.TsUiSceneRoleActor);
		this.TsUiSceneRoleActor = null;
	}

	// Token: 0x0400B382 RID: 45954
	private WeeklyRogueTeamInfoPanel TeamInfoPanel;

	// Token: 0x0400B383 RID: 45955
	private WeeklyRogueTokenInfoPanel TokenInfoPanel;

	// Token: 0x0400B384 RID: 45956
	private TsUiSceneRoleActor TsUiSceneRoleActor;

	// Token: 0x02009010 RID: 36880
	[NullableContext(0)]
	private enum EWeeklyRogueInfoViewDefine
	{
		// Token: 0x0403055E RID: 197982
		BtnClose,
		// Token: 0x0403055F RID: 197983
		ToggleRoleInfo,
		// Token: 0x04030560 RID: 197984
		ToggleTokenInfo,
		// Token: 0x04030561 RID: 197985
		TeamInfoPanel,
		// Token: 0x04030562 RID: 197986
		TokenInfoPanel,
		// Token: 0x04030563 RID: 197987
		ToggleDesc,
		// Token: 0x04030564 RID: 197988
		ToggleText
	}
}
