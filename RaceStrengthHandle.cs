using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;

// Token: 0x02001F9A RID: 8090
[NullableContext(1)]
[Nullable(0)]
public class RaceStrengthHandle : HudUnitHandleBase
{
	// Token: 0x0600F302 RID: 62210 RVA: 0x00426DC0 File Offset: 0x00424FC0
	protected override void OnInitialize()
	{
		base.OnInitialize();
		this.InitTagAndAttributeId();
		BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
		if (curRoleData == null)
		{
			return;
		}
		this.RefreshRole(curRoleData);
	}

	// Token: 0x0600F303 RID: 62211 RVA: 0x00426DEF File Offset: 0x00424FEF
	protected virtual void InitTagAndAttributeId()
	{
		this.FormationAttributeId = EFormationAttributeId.MigrationStrength;
		this.VisibleTagId = GameplayTagDefine.EGameplayTagId["关卡.滑水.专用UI"];
		this.SpeedUpTagId = GameplayTagDefine.EGameplayTagId["关卡.滑水.能量值不衰减"];
	}

	// Token: 0x0600F304 RID: 62212 RVA: 0x00426E24 File Offset: 0x00425024
	[NullableContext(2)]
	private void RefreshRole(BattleUiRoleData roleData)
	{
		this.RemoveEntityEvents();
		if (roleData != null)
		{
			EntityHandle entityHandle = roleData.EntityHandle;
			if (entityHandle != null && entityHandle.Valid)
			{
				this.RoleData = roleData;
				MigrationStrengthUnit strengthUnit = this.StrengthUnit;
				if (strengthUnit != null)
				{
					strengthUnit.RefreshEntity(roleData);
				}
				this.AddEntityEvents();
				this.IsVisible = this.RoleData.GameplayTagComponent.HasTag(this.VisibleTagId);
				this.IsSpeedUp = this.RoleData.GameplayTagComponent.HasTag(this.SpeedUpTagId);
				this.RefreshUnit();
				return;
			}
		}
		this.RoleData = null;
		MigrationStrengthUnit strengthUnit2 = this.StrengthUnit;
		if (strengthUnit2 != null)
		{
			strengthUnit2.RefreshEntity(null);
		}
		MigrationStrengthUnit strengthUnit3 = this.StrengthUnit;
		if (strengthUnit3 == null)
		{
			return;
		}
		strengthUnit3.SetVisible(false, 0);
	}

	// Token: 0x0600F305 RID: 62213 RVA: 0x00426EDA File Offset: 0x004250DA
	private void RefreshUnit()
	{
		if (this.IsVisible)
		{
			this.TryCreateUnit();
			return;
		}
		MigrationStrengthUnit strengthUnit = this.StrengthUnit;
		if (strengthUnit == null)
		{
			return;
		}
		strengthUnit.SetVisible(false, 0);
	}

	// Token: 0x0600F306 RID: 62214 RVA: 0x00426F00 File Offset: 0x00425100
	private void TryCreateUnit()
	{
		if (this.StrengthUnit != null)
		{
			this.StrengthUnit.SetVisible(true, 0);
			return;
		}
		base.NewHudUnitWithReturn<MigrationStrengthUnit>(typeof(MigrationStrengthUnit), "UiItem_EnduranceB", out this.StrengthUnit, false, delegate(MigrationStrengthUnit _)
		{
			if (this.StrengthUnit != null)
			{
				this.StrengthUnit.InitData(4);
				this.StrengthUnit.RefreshEntity(this.RoleData);
				this.RefreshStrengthPercent();
			}
		}, false);
		this.StrengthUnit.SetVisible(true, 0);
	}

	// Token: 0x0600F307 RID: 62215 RVA: 0x00426F59 File Offset: 0x00425159
	protected override void OnDestroyed()
	{
		base.OnDestroyed();
		this.StrengthUnit = null;
		this.RefreshRole(null);
	}

	// Token: 0x0600F308 RID: 62216 RVA: 0x00426F6F File Offset: 0x0042516F
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.BattleUiCurRoleDataChangedNextTick, new Action<int, int>(this.OnChangeRole));
	}

	// Token: 0x0600F309 RID: 62217 RVA: 0x00426F8D File Offset: 0x0042518D
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.BattleUiCurRoleDataChangedNextTick, new Action<int, int>(this.OnChangeRole));
		Singleton<EventSystem>.Instance.RemoveAllTargetUseKey(this);
	}

	// Token: 0x0600F30A RID: 62218 RVA: 0x00426FB8 File Offset: 0x004251B8
	private void AddEntityEvents()
	{
		this.ListenForTagAddOrRemove(this.VisibleTagId, new Action<int, bool>(this.OnVisibleTagChanged));
		this.ListenForTagAddOrRemove(this.SpeedUpTagId, new Action<int, bool>(this.OnSpeedUpTagChanged));
		BattleUiRoleData roleData = this.RoleData;
		if (((roleData != null) ? roleData.EntityHandle : null) != null)
		{
			Singleton<EventSystem>.Instance.AddWithTargetUseHoldKey<ERemoveEntityType, EntityHandle>(this, this.RoleData.EntityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		}
	}

	// Token: 0x0600F30B RID: 62219 RVA: 0x00427034 File Offset: 0x00425234
	private void RemoveEntityEvents()
	{
		foreach (ITagTask tagTask in this.TagTaskList)
		{
			if (tagTask != null)
			{
				tagTask.EndTask();
			}
		}
		this.TagTaskList.Clear();
		BattleUiRoleData roleData = this.RoleData;
		if (((roleData != null) ? roleData.EntityHandle : null) != null)
		{
			EventSystem instance = Singleton<EventSystem>.Instance;
			BattleUiRoleData roleData2 = this.RoleData;
			instance.RemoveWithTargetUseKey<ERemoveEntityType, EntityHandle>(this, (roleData2 != null) ? roleData2.EntityHandle : null, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		}
	}

	// Token: 0x0600F30C RID: 62220 RVA: 0x004270D8 File Offset: 0x004252D8
	private void OnChangeRole(int newEntityId, int oldEntityId)
	{
		this.RefreshRole(ModelBase<BattleUiModel>.Instance.GetCurRoleData());
	}

	// Token: 0x0600F30D RID: 62221 RVA: 0x004270EA File Offset: 0x004252EA
	private void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle handle)
	{
		BattleUiRoleData roleData = this.RoleData;
		if (((roleData != null) ? roleData.EntityHandle : null) == handle)
		{
			this.RemoveEntityEvents();
		}
	}

	// Token: 0x0600F30E RID: 62222 RVA: 0x00427107 File Offset: 0x00425307
	private void OnVisibleTagChanged(int tagId, bool tagExist)
	{
		this.IsVisible = tagExist;
		this.RefreshUnit();
	}

	// Token: 0x0600F30F RID: 62223 RVA: 0x00427116 File Offset: 0x00425316
	private void OnSpeedUpTagChanged(int tagId, bool tagExist)
	{
		this.IsSpeedUp = tagExist;
	}

	// Token: 0x0600F310 RID: 62224 RVA: 0x00427120 File Offset: 0x00425320
	private void ListenForTagAddOrRemove(int tagId, Action<int, bool> callback)
	{
		ITagTask tagTask = this.RoleData.GameplayTagComponent.ListenForTagAddOrRemove(new int?(tagId), new BaseTagComponent.TTagSwitchedCallback(callback.Invoke), null);
		if (tagTask == null)
		{
			return;
		}
		this.TagTaskList.Add(tagTask);
	}

	// Token: 0x0600F311 RID: 62225 RVA: 0x00427164 File Offset: 0x00425364
	private void RefreshStrengthPercent()
	{
		float value = ControllerBase<FormationAttributeController>.Instance.GetValue(this.FormationAttributeId);
		float max = ControllerBase<FormationAttributeController>.Instance.GetMax(this.FormationAttributeId);
		this.StrengthUnit.SetStrengthPercent(value, max);
	}

	// Token: 0x0600F312 RID: 62226 RVA: 0x004271A0 File Offset: 0x004253A0
	protected override void OnTick(float delta)
	{
		base.OnTick(delta);
		if (!this.IsVisible || this.StrengthUnit == null || !this.StrengthUnit.IsShowOrShowing)
		{
			return;
		}
		this.StrengthUnit.RefreshTargetPosition(delta);
		this.StrengthUnit.SetRecoverState(this.IsSpeedUp);
		this.RefreshStrengthPercent();
		this.StrengthUnit.TickRecoverAnim(delta);
	}

	// Token: 0x040074BF RID: 29887
	protected int VisibleTagId;

	// Token: 0x040074C0 RID: 29888
	protected int SpeedUpTagId;

	// Token: 0x040074C1 RID: 29889
	protected EFormationAttributeId FormationAttributeId = EFormationAttributeId.MigrationStrength;

	// Token: 0x040074C2 RID: 29890
	[Nullable(2)]
	protected MigrationStrengthUnit StrengthUnit;

	// Token: 0x040074C3 RID: 29891
	[Nullable(2)]
	protected BattleUiRoleData RoleData;

	// Token: 0x040074C4 RID: 29892
	protected readonly List<ITagTask> TagTaskList = new List<ITagTask>();

	// Token: 0x040074C5 RID: 29893
	protected bool IsVisible;

	// Token: 0x040074C6 RID: 29894
	protected bool IsSpeedUp;
}
