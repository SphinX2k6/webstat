using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Utils;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002907 RID: 10503
[NullableContext(2)]
[Nullable(0)]
public class RoleViewViewModel
{
	// Token: 0x06014DBB RID: 85435 RVA: 0x005C73EE File Offset: 0x005C55EE
	public RoleViewViewModel(int roleId, bool isNeedLoadRole, ERoleViewSource source = ERoleViewSource.Normal)
	{
		this.RoleId = roleId;
		this.IsNeedLoadRole = isNeedLoadRole;
		this.Source = source;
	}

	// Token: 0x06014DBC RID: 85436 RVA: 0x005C740C File Offset: 0x005C560C
	public UniTask InitRoleActor()
	{
		RoleViewViewModel.<InitRoleActor>d__14 <InitRoleActor>d__;
		<InitRoleActor>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRoleActor>d__.<>4__this = this;
		<InitRoleActor>d__.<>1__state = -1;
		<InitRoleActor>d__.<>t__builder.Start<RoleViewViewModel.<InitRoleActor>d__14>(ref <InitRoleActor>d__);
		return <InitRoleActor>d__.<>t__builder.Task;
	}

	// Token: 0x06014DBD RID: 85437 RVA: 0x005C7450 File Offset: 0x005C5650
	public void HandleLoadScene(Action callback)
	{
		this.InitRoleActor().ContinueWith(delegate()
		{
			Action callback2 = callback;
			if (callback2 == null)
			{
				return;
			}
			callback2();
		});
		this.LoadFloorEffect();
		UiModelBase model = this.TsUiSceneRoleActor.Model;
		UiModelActorComponent uiModelActorComponent = (model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null;
		if (uiModelActorComponent == null)
		{
			return;
		}
		uiModelActorComponent.SetTransformByTag("RoleCase");
	}

	// Token: 0x06014DBE RID: 85438 RVA: 0x005C74B0 File Offset: 0x005C56B0
	public void ShowActor()
	{
		Singleton<UiSceneManager>.Instance.ShowRoleSystemRoleActor();
		if (new ERoleFadeCurveDefine?(this.FadeOutCurveId) != new ERoleFadeCurveDefine?(ERoleFadeCurveDefine.None))
		{
			Singleton<UiModelUtil>.Instance.ModelFadeOut(this.TsUiSceneRoleActor.Model, new ERoleFadeCurveDefine?(this.FadeOutCurveId), null);
		}
		if (this.RoleStatePlayContextOnShow != null)
		{
			ControllerBase<RoleController>.Instance.PlayRoleMontage(this.RoleStatePlayContextOnShow.RoleState, this.RoleStatePlayContextOnShow.ReLoop, this.RoleStatePlayContextOnShow.ReLoopFromLoopToStart, this.RoleStatePlayContextOnShow.WaitLaseStateEnd);
		}
	}

	// Token: 0x06014DBF RID: 85439 RVA: 0x005C7544 File Offset: 0x005C5744
	public void HideActor()
	{
		if (new ERoleFadeCurveDefine?(this.FadeInCurveId) != new ERoleFadeCurveDefine?(ERoleFadeCurveDefine.None))
		{
			Singleton<UiModelUtil>.Instance.ModelFadeIn(this.TsUiSceneRoleActor.Model, new ERoleFadeCurveDefine?(this.FadeInCurveId), delegate
			{
				Singleton<UiSceneManager>.Instance.HideRoleSystemRoleActor();
			});
		}
		else
		{
			Singleton<UiSceneManager>.Instance.HideRoleSystemRoleActor();
		}
		if (this.RoleStatePlayContextOnHide != null)
		{
			ControllerBase<RoleController>.Instance.PlayRoleMontage(this.RoleStatePlayContextOnHide.RoleState, this.RoleStatePlayContextOnHide.ReLoop, this.RoleStatePlayContextOnHide.ReLoopFromLoopToStart, this.RoleStatePlayContextOnHide.WaitLaseStateEnd);
		}
	}

	// Token: 0x06014DC0 RID: 85440 RVA: 0x005C75F8 File Offset: 0x005C57F8
	private void LoadFloorEffect()
	{
		AActor actorByTag = Singleton<UiSceneManager>.Instance.GetActorByTag("RoleFloorCase");
		if (actorByTag != null)
		{
			this.FloorEffect = EffectUtil.SpawnUiEffect("RoleSystemFloorEffect", "[RoleRootView.LoadFloorEffect]", new FTransformDouble?(actorByTag.D_GetTransform()), new EffectContext(null, actorByTag, false)).GetValueOrDefault();
		}
	}

	// Token: 0x06014DC1 RID: 85441 RVA: 0x005C7650 File Offset: 0x005C5850
	public void HandleReleaseScene()
	{
		this.HideActor();
		if (Singleton<EffectSystem>.Instance.IsValid(this.FloorEffect))
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.FloorEffect, "[RoleRootView.HandleReleaseScene]", false, null);
		}
		Singleton<UiSceneManager>.Instance.DestroyRoleSystemRoleActor(this.TsUiSceneRoleActor);
		this.TsUiSceneRoleActor = null;
		Singleton<UiSceneManager>.Instance.ClearUiSequenceFrame();
		this.IsNeedLoadRole = true;
		this.IsLoadRole = false;
	}

	// Token: 0x0400A07E RID: 41086
	public int RoleId;

	// Token: 0x0400A07F RID: 41087
	public int WeaponIncId;

	// Token: 0x0400A080 RID: 41088
	public bool IsNeedLoadRole;

	// Token: 0x0400A081 RID: 41089
	public ERoleViewSource Source;

	// Token: 0x0400A082 RID: 41090
	public TsUiSceneRoleActor TsUiSceneRoleActor;

	// Token: 0x0400A083 RID: 41091
	public RoleStatePlayContext RoleStatePlayContextOnShow;

	// Token: 0x0400A084 RID: 41092
	public RoleStatePlayContext RoleStatePlayContextOnHide;

	// Token: 0x0400A085 RID: 41093
	public bool NeedShowOnViewPlayingStartSequence;

	// Token: 0x0400A086 RID: 41094
	public bool NeedHideOnViewPlayingCloseSequence;

	// Token: 0x0400A087 RID: 41095
	private bool IsLoadRole;

	// Token: 0x0400A088 RID: 41096
	private int FloorEffect;

	// Token: 0x0400A089 RID: 41097
	public ERoleFadeCurveDefine FadeInCurveId;

	// Token: 0x0400A08A RID: 41098
	public ERoleFadeCurveDefine FadeOutCurveId;
}
