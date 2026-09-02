using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x0200278D RID: 10125
[NullableContext(1)]
[Nullable(0)]
public class RoleHandBookSelectionView : UiViewBase
{
	// Token: 0x06013FC0 RID: 81856 RVA: 0x00591B0A File Offset: 0x0058FD0A
	public RoleHandBookSelectionView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013FC1 RID: 81857 RVA: 0x00591B13 File Offset: 0x0058FD13
	protected override void OnHandleLoadScene()
	{
	}

	// Token: 0x06013FC2 RID: 81858 RVA: 0x00591B15 File Offset: 0x0058FD15
	protected override void OnHandleReleaseScene()
	{
	}

	// Token: 0x06013FC3 RID: 81859 RVA: 0x00591B17 File Offset: 0x0058FD17
	protected override void OnStart()
	{
		this.RoleSelectionComponent = new RoleHandBookSelectionComponent();
		this.LoadFloorEffect();
	}

	// Token: 0x06013FC4 RID: 81860 RVA: 0x00591B2C File Offset: 0x0058FD2C
	protected override void OnAfterShow()
	{
		ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.Attribute, false, false, false);
		if (this.RoleSelectionComponent != null)
		{
			int curSelectRoleId = this.RoleSelectionComponent.GetCurSelectRoleId();
			this.RoleSelectionComponent.UpdateComponent(this.RoleList);
			this.RoleSelectionComponent.UpdateRoleHandBookItem(curSelectRoleId);
		}
		ControllerBase<RoleController>.Instance.ShowUiSceneActorAndShadow(true);
	}

	// Token: 0x06013FC5 RID: 81861 RVA: 0x00591B83 File Offset: 0x0058FD83
	protected override void OnAddEventListener()
	{
		base.OnAddEventListener();
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RoleHandBookActive, new Action<int>(this.OnRoleHandBookActive));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddCommonItemList));
	}

	// Token: 0x06013FC6 RID: 81862 RVA: 0x00591BC3 File Offset: 0x0058FDC3
	protected override void OnRemoveEventListener()
	{
		base.OnRemoveEventListener();
		Singleton<EventSystem>.Instance.Remove(EEventName.RoleHandBookActive, new Action<int>(this.OnRoleHandBookActive));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddCommonItemList));
	}

	// Token: 0x06013FC7 RID: 81863 RVA: 0x00591C04 File Offset: 0x0058FE04
	private void OnAddCommonItemList(IReadOnlyList<IProto_NormalItem> _)
	{
		if (this.RoleSelectionComponent == null)
		{
			return;
		}
		int curSelectRoleId = this.RoleSelectionComponent.GetCurSelectRoleId();
		if (curSelectRoleId == 0)
		{
			return;
		}
		this.RoleSelectionComponent.UpdateItemByRoleId(curSelectRoleId);
	}

	// Token: 0x06013FC8 RID: 81864 RVA: 0x00591C36 File Offset: 0x0058FE36
	private void OnRoleHandBookActive(int roleId)
	{
		if (this.RoleSelectionComponent == null)
		{
			return;
		}
		ControllerBase<RoleController>.Instance.ShowUiSceneActorAndShadow(false);
		this.SetActive(false);
		this.RoleSelectionComponent.PlaySequence();
	}

	// Token: 0x06013FC9 RID: 81865 RVA: 0x00591C60 File Offset: 0x0058FE60
	protected void InitRoleList()
	{
		List<RoleInfo> list = ConfigCommon.ToList<RoleInfo>(ConfigBase<RoleConfig>.Instance.GetRoleListByType(ERoleType.Common));
		list.Sort((RoleInfo aRoleConfig, RoleInfo bRoleConfig) => aRoleConfig.Id - bRoleConfig.Id);
		int count = list.Count;
		this.RoleList = new RoleDataBase[count];
		int num = 0;
		for (int i = 0; i < count; i++)
		{
			RoleInfo roleInfo = list[i];
			if (roleInfo.PartyId != 9)
			{
				RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleInfo.Id, true);
				this.RoleList[num] = roleDataById;
				num++;
			}
		}
	}

	// Token: 0x06013FCA RID: 81866 RVA: 0x00591CFC File Offset: 0x0058FEFC
	protected void LoadFloorEffect()
	{
		AActor actorByTag = Singleton<UiSceneManager>.Instance.GetActorByTag("RoleFloorCase");
		if (actorByTag != null)
		{
			this.FloorEffect = EffectUtil.SpawnUiEffect("RoleSystemFloorEffect", "[RoleHandBookSelectionView.LoadFloorEffect]", new FTransformDouble?(actorByTag.D_GetTransform()), new EffectContext(null, actorByTag, false)).Value;
		}
	}

	// Token: 0x06013FCB RID: 81867 RVA: 0x00591D54 File Offset: 0x0058FF54
	protected override void OnAfterHide()
	{
		if (Singleton<EffectSystem>.Instance.IsValid(this.FloorEffect))
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.FloorEffect, "[RoleHandBookSelectionView.OnHide]", false, null);
		}
	}

	// Token: 0x06013FCC RID: 81868 RVA: 0x00591D94 File Offset: 0x0058FF94
	protected void RoleSelectionSelectedEvent(int roleId)
	{
		int? curSelectMainRoleId = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleId();
		if (!(curSelectMainRoleId.GetValueOrDefault() == roleId & curSelectMainRoleId != null))
		{
			ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.Attribute, false, false, false);
			if (this.RoleSelectionComponent != null)
			{
				this.RoleSelectionComponent.UpdateRoleHandBookItem(roleId);
			}
		}
	}

	// Token: 0x06013FCD RID: 81869 RVA: 0x00591DE4 File Offset: 0x0058FFE4
	protected override void OnBeforeCreate()
	{
		this.UiSceneRoleActor = Singleton<UiSceneManager>.Instance.InitRoleSystemRoleActor(EUiModelUseWay.RoleInRoleView);
	}

	// Token: 0x06013FCE RID: 81870 RVA: 0x00591DF8 File Offset: 0x0058FFF8
	protected override void OnBeforeDestroy()
	{
		Singleton<UiSceneManager>.Instance.DestroyRoleSystemRoleActor(this.UiSceneRoleActor);
		if (Singleton<EffectSystem>.Instance.IsValid(this.FloorEffect))
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.FloorEffect, "[RoleHandBookSelectionView.OnDestroy]", true, null);
			this.FloorEffect = 0;
		}
		this.RoleList = null;
	}

	// Token: 0x04009B93 RID: 39827
	public const string ROLE_HAND_BOOK_BLENDNAME = "10061";

	// Token: 0x04009B94 RID: 39828
	[Nullable(2)]
	protected RoleHandBookSelectionComponent RoleSelectionComponent;

	// Token: 0x04009B95 RID: 39829
	private int FloorEffect;

	// Token: 0x04009B96 RID: 39830
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected RoleDataBase[] RoleList;

	// Token: 0x04009B97 RID: 39831
	[Nullable(2)]
	private TsUiSceneRoleActor UiSceneRoleActor;
}
