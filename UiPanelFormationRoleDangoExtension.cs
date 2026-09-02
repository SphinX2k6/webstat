using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B4C RID: 6988
public class UiPanelFormationRoleDangoExtension : UiPanelBase
{
	// Token: 0x0600CA11 RID: 51729 RVA: 0x0035B588 File Offset: 0x00359788
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(26, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600CA12 RID: 51730 RVA: 0x0035B5D1 File Offset: 0x003597D1
	private void AddEventListeners()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnAbyssDangoLevelUp, new Action<int, int>(this.OnAbyssDangoLevelUp));
		Singleton<EventSystem>.Instance.Add(EEventName.OnAbyssRoleInfoUpdate, new Action(this.OnAbyssRoleInfoUpdate));
	}

	// Token: 0x0600CA13 RID: 51731 RVA: 0x0035B60B File Offset: 0x0035980B
	private void RemoveEventListeners()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAbyssDangoLevelUp, new Action<int, int>(this.OnAbyssDangoLevelUp));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAbyssRoleInfoUpdate, new Action(this.OnAbyssRoleInfoUpdate));
	}

	// Token: 0x0600CA14 RID: 51732 RVA: 0x0035B645 File Offset: 0x00359845
	private void OnAbyssDangoLevelUp(int dangoId, int level)
	{
		DangoItem dangoItem = this.DangoItem;
		if (dangoItem == null)
		{
			return;
		}
		dangoItem.OnLevelUp(dangoId, level);
	}

	// Token: 0x0600CA15 RID: 51733 RVA: 0x0035B659 File Offset: 0x00359859
	private void OnAbyssRoleInfoUpdate()
	{
		DangoItem dangoItem = this.DangoItem;
		if (dangoItem == null)
		{
			return;
		}
		dangoItem.OnDangoInfoUpdate();
	}

	// Token: 0x0600CA16 RID: 51734 RVA: 0x0035B66C File Offset: 0x0035986C
	protected override UniTask OnBeforeStartAsync()
	{
		UiPanelFormationRoleDangoExtension.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<UiPanelFormationRoleDangoExtension.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600CA17 RID: 51735 RVA: 0x0035B6AF File Offset: 0x003598AF
	protected override void OnStart()
	{
		this.AddEventListeners();
	}

	// Token: 0x0600CA18 RID: 51736 RVA: 0x0035B6B7 File Offset: 0x003598B7
	protected override void OnBeforeDestroy()
	{
		this.RemoveEventListeners();
	}

	// Token: 0x0600CA19 RID: 51737 RVA: 0x0035B6BF File Offset: 0x003598BF
	public void SetRelativeUiActive(bool active)
	{
		base.GetItem(26).SetUIActive(active);
	}

	// Token: 0x0600CA1A RID: 51738 RVA: 0x0035B6D0 File Offset: 0x003598D0
	public void Refresh(int index, int roleCfgId, int playerId)
	{
		if (playerId == 0)
		{
			ModelBase<DangoAbyssModel>.Instance.RefreshOwnDataAfterChange(ModelBase<PlayerInfoModel>.Instance.GetId().Value);
			return;
		}
		ModelBase<DangoAbyssModel>.Instance.RefreshOwnDataAfterChange(playerId);
		DangoItemData dangoItemData = new DangoItemData();
		dangoItemData.Index = index;
		DangoItemData dangoItemData2 = dangoItemData;
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		dangoItemData2.IfSelf = (playerId == id.GetValueOrDefault() & id != null);
		AbyssDangoOwnerData roleOwnerData = ModelBase<DangoAbyssModel>.Instance.GetRoleOwnerData(playerId, roleCfgId);
		dangoItemData.DangoId = ((roleOwnerData != null) ? roleOwnerData.DangoId : 0);
		dangoItemData.RoleConfigId = roleCfgId;
		dangoItemData.Level = ((roleOwnerData != null) ? roleOwnerData.DangoLevel : 0);
		dangoItemData.DangoEquipIds = (((roleOwnerData != null) ? roleOwnerData.DangoEquipIds : null) ?? new int[0]);
		this.DangoItem.Refresh(dangoItemData);
	}

	// Token: 0x0600CA1B RID: 51739 RVA: 0x0035B798 File Offset: 0x00359998
	[NullableContext(1)]
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length == 0)
		{
			return null;
		}
		DangoItem dangoItem = this.DangoItem;
		UUIItem uuiitem = (dangoItem != null) ? dangoItem.GetRootItem() : null;
		if (uuiitem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uuiitem,
			uuiitem
		};
	}

	// Token: 0x040060AF RID: 24751
	[Nullable(2)]
	private DangoItem DangoItem;

	// Token: 0x02007E2F RID: 32303
	private enum EComponent
	{
		// Token: 0x0402AFA6 RID: 176038
		DangoNode = 26
	}
}
