using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using Cysharp.Threading.Tasks;

// Token: 0x02001F9F RID: 8095
[NullableContext(1)]
[Nullable(0)]
public class StrengthHandle : HudUnitHandleBase
{
	// Token: 0x0600F33F RID: 62271 RVA: 0x00427EA8 File Offset: 0x004260A8
	protected override void OnInitialize()
	{
		base.OnInitialize();
		base.NewHudUnit<StrengthUnit>(typeof(StrengthUnit), "UiItem_PhysicalBar", true, false).ContinueWith(delegate(StrengthUnit unit)
		{
			this.StrengthUnit = unit;
			if (this.StrengthUnit == null)
			{
				return;
			}
			BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
			if (curRoleData == null)
			{
				this.StrengthUnit.SetVisible(false, 0);
				return;
			}
			this.AddEntityEvents(curRoleData);
			this.StrengthUnit.RefreshRoleData(curRoleData);
			this.UpdateStrengthUnitByRole(curRoleData);
		});
	}

	// Token: 0x0600F340 RID: 62272 RVA: 0x00427ED9 File Offset: 0x004260D9
	protected override void OnDestroyed()
	{
		this.StrengthUnit = null;
		if (this.CurrentEntity != null)
		{
			this.RemoveEntity(this.CurrentEntity);
		}
		base.OnDestroyed();
	}

	// Token: 0x0600F341 RID: 62273 RVA: 0x00427EFC File Offset: 0x004260FC
	public override void OnShowHud()
	{
	}

	// Token: 0x0600F342 RID: 62274 RVA: 0x00427F00 File Offset: 0x00426100
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.BattleUiCurRoleDataChangedNextTick, new Action<int, int>(this.OnChangeRole));
		Singleton<EventSystem>.Instance.Add<EStrengthItemType>(EEventName.AddStrengthItem, new Action<EStrengthItemType>(this.OnAddStrengthItem));
		Singleton<EventSystem>.Instance.Add<EStrengthItemType>(EEventName.RemoveStrengthItem, new Action<EStrengthItemType>(this.OnRemoveStrengthItem));
	}

	// Token: 0x0600F343 RID: 62275 RVA: 0x00427F64 File Offset: 0x00426164
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.BattleUiCurRoleDataChangedNextTick, new Action<int, int>(this.OnChangeRole));
		Singleton<EventSystem>.Instance.Remove<EStrengthItemType>(EEventName.AddStrengthItem, new Action<EStrengthItemType>(this.OnAddStrengthItem));
		Singleton<EventSystem>.Instance.Remove<EStrengthItemType>(EEventName.RemoveStrengthItem, new Action<EStrengthItemType>(this.OnRemoveStrengthItem));
		Singleton<EventSystem>.Instance.RemoveAllTargetUseKey(this);
	}

	// Token: 0x0600F344 RID: 62276 RVA: 0x00427FD4 File Offset: 0x004261D4
	private void OnAddStrengthItem(EStrengthItemType strengthItemType)
	{
		if (!this.ExtraStrengthItemList.Contains(strengthItemType))
		{
			this.ExtraStrengthItemList.Add(strengthItemType);
		}
		BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
		if (curRoleData != null)
		{
			this.UpdateStrengthUnitByRole(curRoleData);
		}
	}

	// Token: 0x0600F345 RID: 62277 RVA: 0x00428010 File Offset: 0x00426210
	private void OnRemoveStrengthItem(EStrengthItemType strengthItemType)
	{
		int num = this.ExtraStrengthItemList.IndexOf(strengthItemType);
		if (num >= 0)
		{
			this.ExtraStrengthItemList.RemoveAt(num);
		}
		BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
		if (curRoleData != null)
		{
			this.UpdateStrengthUnitByRole(curRoleData);
		}
	}

	// Token: 0x0600F346 RID: 62278 RVA: 0x00428050 File Offset: 0x00426250
	private void OnChangeRole(int newEntityId, int oldEntityId)
	{
		BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
		if (curRoleData == null)
		{
			return;
		}
		if (this.CurrentEntity != null)
		{
			this.RemoveEntity(this.CurrentEntity);
		}
		else
		{
			StrengthUnit strengthUnit = this.StrengthUnit;
			if (strengthUnit != null)
			{
				strengthUnit.SetVisible(true, 0);
			}
		}
		this.AddEntityEvents(curRoleData);
		if (this.StrengthUnit == null)
		{
			return;
		}
		this.StrengthUnit.RefreshRoleData(curRoleData);
		this.UpdateStrengthUnitByRole(curRoleData);
	}

	// Token: 0x0600F347 RID: 62279 RVA: 0x004280B8 File Offset: 0x004262B8
	private void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle handle)
	{
		this.RemoveEntity(handle);
	}

	// Token: 0x0600F348 RID: 62280 RVA: 0x004280C1 File Offset: 0x004262C1
	private void RemoveEntity(EntityHandle handle)
	{
		this.RemoveEntityEvents(handle);
		this.CurrentEntityId = 0;
		this.CurrentEntity = null;
	}

	// Token: 0x0600F349 RID: 62281 RVA: 0x004280D8 File Offset: 0x004262D8
	private void AddEntityEvents(BattleUiRoleData roleData)
	{
		int id = roleData.EntityHandle.Id;
		if (this.CurrentEntityId == id)
		{
			return;
		}
		this.CurrentEntityId = id;
		this.CurrentEntity = roleData.EntityHandle;
		Singleton<EventSystem>.Instance.AddWithTargetUseHoldKey<ERemoveEntityType, EntityHandle>(this, roleData.EntityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		BaseTagComponent gameplayTagComponent = roleData.GameplayTagComponent;
		if (gameplayTagComponent == null)
		{
			return;
		}
		this.ListenForTagAddOrRemove(gameplayTagComponent, StrengthHandle.FlyTag, new Action<int, bool>(this.OnTagChanged), false);
		this.ListenForTagAddOrRemove(gameplayTagComponent, StrengthHandle.FlyStrengthTag, new Action<int, bool>(this.OnTagChanged), false);
		this.ListenForTagAddOrRemove(gameplayTagComponent, StrengthHandle.MotorcycleTag, new Action<int, bool>(this.OnTagChanged), false);
		this.ListenForTagAddOrRemove(gameplayTagComponent, StrengthHandle.MechanicalTag, new Action<int, bool>(this.OnTagChanged), false);
		this.ListenForTagAddOrRemove(gameplayTagComponent, GameplayTagDefine.EGameplayTagId["功能.功能制作.隐藏体力条"], new Action<int, bool>(this.OnHideChanged), true);
		this.ListenForTagAddOrRemove(gameplayTagComponent, GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.第一人称"], new Action<int, bool>(this.OnChangeToFirstPerson), true);
		this.ListenForTagAddOrRemove(gameplayTagComponent, GameplayTagDefine.EGameplayTagId["功能.功能制作.越肩模式"], new Action<int, bool>(this.OnOverShoulderView), true);
		this.ListenForTagAddOrRemove(gameplayTagComponent, StrengthHandle.MotorcycleFlyTag, new Action<int, bool>(this.OnMotorSoarChanged), true);
		StrengthUnit strengthUnit = this.StrengthUnit;
		if (strengthUnit == null)
		{
			return;
		}
		strengthUnit.SetDriving(gameplayTagComponent.HasTag(StrengthHandle.MotorcycleTag));
	}

	// Token: 0x0600F34A RID: 62282 RVA: 0x00428240 File Offset: 0x00426440
	private void RemoveEntityEvents(EntityHandle handle)
	{
		if (!handle.Valid || this.CurrentEntityId != handle.Id)
		{
			return;
		}
		Singleton<EventSystem>.Instance.RemoveWithTargetUseKey<ERemoveEntityType, EntityHandle>(this, handle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		foreach (ITagTask tagTask in this.TagTaskList)
		{
			tagTask.EndTask();
		}
		this.TagTaskList.Clear();
	}

	// Token: 0x0600F34B RID: 62283 RVA: 0x004282D0 File Offset: 0x004264D0
	private void ListenForTagAddOrRemove(BaseTagComponent tagComponent, int tagId, Action<int, bool> callback, bool checkExistImmediately = false)
	{
		if (checkExistImmediately && tagComponent.HasTag(tagId))
		{
			callback(tagId, true);
		}
		ITagTask tagTask = tagComponent.ListenForTagAddOrRemove(new int?(tagId), new BaseTagComponent.TTagSwitchedCallback(callback.Invoke), this.ListenTagStat);
		if (tagTask != null)
		{
			this.TagTaskList.Add(tagTask);
		}
	}

	// Token: 0x0600F34C RID: 62284 RVA: 0x00428320 File Offset: 0x00426520
	private void OnTagChanged(int tagId, bool tagExists)
	{
		if (this.StrengthUnit == null)
		{
			return;
		}
		BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
		if (curRoleData == null)
		{
			return;
		}
		this.UpdateStrengthUnitByRole(curRoleData);
		if (tagId == StrengthHandle.MotorcycleTag)
		{
			this.StrengthUnit.SetDriving(tagExists);
			if (!tagExists)
			{
				this.StrengthUnit.UpdateMotorBarState(false);
				this.StrengthUnit.SetStandardBarMode(true, true);
				this.StrengthUnit.SwapPlace(false);
			}
		}
	}

	// Token: 0x0600F34D RID: 62285 RVA: 0x00428388 File Offset: 0x00426588
	private void OnHideChanged(int tagId, bool tagExists)
	{
		StrengthUnit strengthUnit = this.StrengthUnit;
		if (strengthUnit == null)
		{
			return;
		}
		strengthUnit.SetVisible(!tagExists, 1);
	}

	// Token: 0x0600F34E RID: 62286 RVA: 0x0042839F File Offset: 0x0042659F
	private void OnChangeToFirstPerson(int tagId, bool tagExists)
	{
		StrengthUnit strengthUnit = this.StrengthUnit;
		if (strengthUnit == null)
		{
			return;
		}
		strengthUnit.SetFirstPersonState(tagExists);
	}

	// Token: 0x0600F34F RID: 62287 RVA: 0x004283B2 File Offset: 0x004265B2
	private void OnOverShoulderView(int tagId, bool tagExists)
	{
		StrengthUnit strengthUnit = this.StrengthUnit;
		if (strengthUnit == null)
		{
			return;
		}
		strengthUnit.SetOverShoulderState(tagExists);
	}

	// Token: 0x0600F350 RID: 62288 RVA: 0x004283C8 File Offset: 0x004265C8
	private void OnMotorSoarChanged(int tagId, bool tagExists)
	{
		if (tagExists)
		{
			BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
			if (curRoleData != null)
			{
				this.UpdateStrengthUnitByRole(curRoleData);
			}
		}
		StrengthUnit strengthUnit = this.StrengthUnit;
		if (strengthUnit == null)
		{
			return;
		}
		strengthUnit.UpdateMotorBarState(tagExists);
	}

	// Token: 0x0600F351 RID: 62289 RVA: 0x00428400 File Offset: 0x00426600
	private void UpdateStrengthUnitByRole(BattleUiRoleData roleData)
	{
		if (this.StrengthUnit == null)
		{
			return;
		}
		BaseTagComponent gameplayTagComponent = roleData.GameplayTagComponent;
		if (gameplayTagComponent == null)
		{
			return;
		}
		if (this.ExtraStrengthItemList.Count > 0)
		{
			EStrengthItemType strengthItemType = this.ExtraStrengthItemList[0];
			this.StrengthUnit.AddStrengthItem(strengthItemType, 1);
			this.StrengthUnit.SetStandardBarMode(true, false);
			this.StrengthUnit.SwapPlace(true);
			return;
		}
		if (gameplayTagComponent.HasTag(StrengthHandle.MechanicalTag))
		{
			this.StrengthUnit.AddStrengthItem(EStrengthItemType.StrengthForAimisi, 2);
			this.StrengthUnit.SetStandardBarMode(false, false);
			this.StrengthUnit.SwapPlace(true);
		}
		else
		{
			this.StrengthUnit.SetStandardBarMode(true, false);
		}
		if (gameplayTagComponent.HasTag(StrengthHandle.FlyTag) || gameplayTagComponent.HasTag(StrengthHandle.FlyStrengthTag))
		{
			this.StrengthUnit.AddStrengthItem(EStrengthItemType.Fly, 1);
			this.StrengthUnit.SwapPlace(true);
			return;
		}
		if (gameplayTagComponent.HasTag(StrengthHandle.MotorcycleFlyTag))
		{
			this.StrengthUnit.AddStrengthItem(EStrengthItemType.MotorcycleFly, 3);
			this.StrengthUnit.SwapPlace(true);
		}
		if (gameplayTagComponent.HasTag(StrengthHandle.MotorcycleTag))
		{
			this.StrengthUnit.AddStrengthItem(EStrengthItemType.Motorcycle, 1);
			this.StrengthUnit.SwapPlace(true);
			return;
		}
		this.StrengthUnit.SwapPlace(false);
	}

	// Token: 0x040074D9 RID: 29913
	private readonly Stat ChangeRoleStat = Stat.Create("[ChangeRole]StrengthHandle", "", "");

	// Token: 0x040074DA RID: 29914
	private readonly Stat ListenTagStat = Stat.Create("[StrengthHandle]ListenTag", "", "");

	// Token: 0x040074DB RID: 29915
	private static readonly int FlyTag = GameplayTagDefine.EGameplayTagId["行为状态.动作状态.XA"];

	// Token: 0x040074DC RID: 29916
	private static readonly int FlyStrengthTag = GameplayTagDefine.EGameplayTagId["功能.功能制作.翱翔体力显示"];

	// Token: 0x040074DD RID: 29917
	private static readonly int MotorcycleFlyTag = GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.状态.空中状态.翱翔"];

	// Token: 0x040074DE RID: 29918
	private static readonly int MotorcycleTag = GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.驾驶期间"];

	// Token: 0x040074DF RID: 29919
	private static readonly int MechanicalTag = GameplayTagDefine.EGameplayTagId["角色.AimisiMd10011.状态.主控机甲"];

	// Token: 0x040074E0 RID: 29920
	[Nullable(2)]
	private StrengthUnit StrengthUnit;

	// Token: 0x040074E1 RID: 29921
	private int CurrentEntityId;

	// Token: 0x040074E2 RID: 29922
	[Nullable(2)]
	private EntityHandle CurrentEntity;

	// Token: 0x040074E3 RID: 29923
	private readonly List<ITagTask> TagTaskList = new List<ITagTask>();

	// Token: 0x040074E4 RID: 29924
	private readonly List<EStrengthItemType> ExtraStrengthItemList = new List<EStrengthItemType>();
}
