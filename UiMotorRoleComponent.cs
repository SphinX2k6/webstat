using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Entity.Struct;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02002CA0 RID: 11424
[NullableContext(2)]
[Nullable(0)]
public class UiMotorRoleComponent : UiModelComponentBase, IUiModelVisible
{
	// Token: 0x06016ED1 RID: 93905 RVA: 0x0065AD40 File Offset: 0x00658F40
	protected override void OnInit()
	{
		this.RoleActor = Singleton<UiSceneManager>.Instance.InitRoleSystemRoleActor(EUiModelUseWay.RoleOnMotor);
		this.RoleDataComponent = this.RoleActor.Model.CheckGetComponent<UiRoleDataComponent>();
		this.ModelDataComponent = this.RoleActor.Model.CheckGetComponent<UiModelDataComponent>();
		this.SetActive(false);
	}

	// Token: 0x06016ED2 RID: 93906 RVA: 0x0065AD94 File Offset: 0x00658F94
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnMotorMeshLoadComplete));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.BeforeUiModelLoadStart, new Action(this.OnMotorModelStartLoad));
	}

	// Token: 0x06016ED3 RID: 93907 RVA: 0x0065ADE8 File Offset: 0x00658FE8
	protected override void OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnMotorMeshLoadComplete));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.BeforeUiModelLoadStart, new Action(this.OnMotorModelStartLoad));
		this.CancelAnimLoad();
		Singleton<UiSceneManager>.Instance.DestroyRoleSystemRoleActor(this.RoleActor);
	}

	// Token: 0x06016ED4 RID: 93908 RVA: 0x0065AE50 File Offset: 0x00659050
	public void OnModelVisibleChange(bool visible)
	{
		if (this.ModelDataComponent.GetModelLoadState() != EUiModelLoadState.LoadComplete)
		{
			this.SetActive(false);
			return;
		}
		this.SetActive(visible);
	}

	// Token: 0x06016ED5 RID: 93909 RVA: 0x0065AE6F File Offset: 0x0065906F
	private void OnMotorModelStartLoad()
	{
		this.Refresh();
	}

	// Token: 0x06016ED6 RID: 93910 RVA: 0x0065AE78 File Offset: 0x00659078
	public void Refresh()
	{
		UiModelBase model = this.RoleActor.Model;
		UiMotorDataComponent motorDataComponent = base.Owner.CheckGetComponent<UiMotorDataComponent>();
		string animPath = motorDataComponent.GetAnimPath();
		if (string.IsNullOrEmpty(animPath))
		{
			return;
		}
		UiRoleLoadComponent loadComponent = model.CheckGetComponent<UiRoleLoadComponent>();
		this.CancelAnimLoad();
		this.LoadAnimByAnimPath(animPath, delegate(UAnimationAsset animAsset)
		{
			int roleId = motorDataComponent.GetRoleId();
			int roleSkinId = motorDataComponent.GetRoleSkinId();
			if (roleId == this.RoleDataComponent.RoleConfigId && roleSkinId == this.RoleDataComponent.RoleSkinId)
			{
				return;
			}
			this.SetActive(false);
			loadComponent.LoadModelByRoleConfigId(roleId, roleSkinId, true, delegate
			{
				UiModelDataComponent uiModelDataComponent = this.Owner.CheckGetComponent<UiModelDataComponent>();
				TsUiSceneRoleActor roleActor = this.RoleActor;
				UiModelActorComponent uiModelActorComponent;
				if (roleActor == null)
				{
					uiModelActorComponent = null;
				}
				else
				{
					UiModelBase model2 = roleActor.Model;
					uiModelActorComponent = ((model2 != null) ? model2.CheckGetComponent<UiModelActorComponent>() : null);
				}
				UiModelActorComponent uiModelActorComponent2 = uiModelActorComponent;
				if (((uiModelActorComponent2 != null) ? uiModelActorComponent2.Actor : null) != null)
				{
					FHitResult fhitResult = new FHitResult();
					SModelConfig modelConfig = ModelUtil.GetModelConfig(uiModelDataComponent.ModelConfigId);
					uiModelActorComponent2.Actor.D_K2_SetActorRelativeLocation(modelConfig.骑摩托位置偏移, false, ref fhitResult, false);
				}
				bool active = uiModelDataComponent != null && uiModelDataComponent.GetModelLoadState() == EUiModelLoadState.LoadComplete;
				this.SetActive(active);
				TsUiSceneRoleActor roleActor2 = this.RoleActor;
				object obj;
				if (roleActor2 == null)
				{
					obj = null;
				}
				else
				{
					UiModelBase model3 = roleActor2.Model;
					obj = ((model3 != null) ? model3.CheckGetComponent<UiModelAnimationComponent>() : null);
				}
				object obj2 = obj;
				if (obj2 == null)
				{
					return;
				}
				obj2.PlayAnimation(animAsset, true);
			});
		});
	}

	// Token: 0x06016ED7 RID: 93911 RVA: 0x0065AEEC File Offset: 0x006590EC
	public void SetActive(bool isActive)
	{
		if ((isActive && this.CurState == EMotorShowState.Showing) || (!isActive && this.CurState == EMotorShowState.Hidden))
		{
			return;
		}
		TsUiSceneRoleActor roleActor = this.RoleActor;
		object obj;
		if (roleActor == null)
		{
			obj = null;
		}
		else
		{
			UiModelBase model = roleActor.Model;
			obj = ((model != null) ? model.CheckGetComponent<UiModelDataComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 != null)
		{
			obj2.SetVisible(isActive);
		}
		this.CurState = (isActive ? EMotorShowState.Showing : EMotorShowState.Hidden);
	}

	// Token: 0x06016ED8 RID: 93912 RVA: 0x0065AF4A File Offset: 0x0065914A
	public void OnMotorMeshLoadComplete()
	{
		this.ExecuteAttachRoleToMotor();
		this.SetActive(this.ModelDataComponent.GetModelLoadState() == EUiModelLoadState.LoadComplete);
	}

	// Token: 0x06016ED9 RID: 93913 RVA: 0x0065AF68 File Offset: 0x00659168
	private void ExecuteAttachRoleToMotor()
	{
		UiModelActorComponent uiModelActorComponent = base.Owner.CheckGetComponent<UiModelActorComponent>();
		if (base.Owner.CheckGetComponent<UiModelDataComponent>().GetModelLoadState() == EUiModelLoadState.LoadComplete)
		{
			USkeletalMeshComponent mainMeshComponent = uiModelActorComponent.MainMeshComponent;
			TsUiSceneRoleActor roleActor = this.RoleActor;
			UiModelActorComponent uiModelActorComponent2;
			if (roleActor == null)
			{
				uiModelActorComponent2 = null;
			}
			else
			{
				UiModelBase model = roleActor.Model;
				uiModelActorComponent2 = ((model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null);
			}
			UiModelActorComponent uiModelActorComponent3 = uiModelActorComponent2;
			if (uiModelActorComponent3 != null)
			{
				AActor actor = uiModelActorComponent3.Actor;
				if (actor != null)
				{
					actor.K2_AttachToComponent(mainMeshComponent, this.SocketName, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.KeepWorld, false, true);
				}
			}
			if (((uiModelActorComponent3 != null) ? uiModelActorComponent3.Actor : null) != null)
			{
				FRotator deltaRotation = new FRotator(0f, -90f, 0f);
				FHitResult fhitResult = new FHitResult();
				uiModelActorComponent3.Actor.K2_AddActorWorldRotation(deltaRotation, false, ref fhitResult, false);
				SModelConfig modelConfig = ModelUtil.GetModelConfig(base.Owner.CheckGetComponent<UiModelDataComponent>().ModelConfigId);
				uiModelActorComponent3.Actor.D_K2_SetActorRelativeLocation(modelConfig.骑摩托位置偏移, false, ref fhitResult, false);
			}
		}
	}

	// Token: 0x06016EDA RID: 93914 RVA: 0x0065B048 File Offset: 0x00659248
	[NullableContext(1)]
	private void LoadAnimByAnimPath(string standAnim, Action<UAnimationAsset> finishCallBack)
	{
		this.AnimHandleId = Singleton<ResourceSystem>.Instance.LoadAsync<UAnimationAsset>(standAnim, delegate([Nullable(2)] UAnimationAsset asset, string _)
		{
			if (asset == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiModel;
				ELogAuthor author = ELogAuthor.BB;
				string message = "UiMotorRoleComponent LoadAnimByAnimPath animAsset is null";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("standAnim", standAnim);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			finishCallBack(asset);
		}, 100, "Ui.UiSceneModel");
	}

	// Token: 0x06016EDB RID: 93915 RVA: 0x0065B092 File Offset: 0x00659292
	private void CancelAnimLoad()
	{
		if (this.AnimHandleId != Singleton<UiModelResourcesManager>.Instance.InvalidValue)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.AnimHandleId);
			this.AnimHandleId = Singleton<UiModelResourcesManager>.Instance.InvalidValue;
		}
	}

	// Token: 0x0400B0D0 RID: 45264
	private TsUiSceneRoleActor RoleActor;

	// Token: 0x0400B0D1 RID: 45265
	private UiRoleDataComponent RoleDataComponent;

	// Token: 0x0400B0D2 RID: 45266
	private UiModelDataComponent ModelDataComponent;

	// Token: 0x0400B0D3 RID: 45267
	private readonly FName SocketName = new FName("SeatProp01");

	// Token: 0x0400B0D4 RID: 45268
	private int AnimHandleId = Singleton<UiModelResourcesManager>.Instance.InvalidValue;

	// Token: 0x0400B0D5 RID: 45269
	private EMotorShowState CurState;
}
