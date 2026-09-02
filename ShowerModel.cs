using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x02002A09 RID: 10761
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class ShowerModel : ModelBase<ShowerModel>
{
	// Token: 0x17001BFD RID: 7165
	// (get) Token: 0x0601578F RID: 87951 RVA: 0x005F3CC7 File Offset: 0x005F1EC7
	public int CurSelectPosIndex
	{
		get
		{
			return this.CurSelectPosIndexInternal;
		}
	}

	// Token: 0x17001BFE RID: 7166
	// (get) Token: 0x06015790 RID: 87952 RVA: 0x005F3CCF File Offset: 0x005F1ECF
	public int PosCount
	{
		get
		{
			return this.RolePosIdList.Count;
		}
	}

	// Token: 0x06015791 RID: 87953 RVA: 0x005F3CDC File Offset: 0x005F1EDC
	public string GetInviteNumString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.SelectInviteMap.Count);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.PosCount);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06015792 RID: 87954 RVA: 0x005F3D24 File Offset: 0x005F1F24
	[NullableContext(2)]
	public RoleInstance GetRoleInstanceByPos(int posIndex)
	{
		RoleInstance result;
		if (this.SelectInviteMap.TryGetValue(posIndex, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x06015793 RID: 87955 RVA: 0x005F3D44 File Offset: 0x005F1F44
	[NullableContext(2)]
	public void SetShowerSeatConfigIds(List<int> configIds)
	{
		if (configIds != null && !this.IsInShower)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			object obj;
			if (baseCharacter == null)
			{
				obj = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
				obj = ((characterActorComponent != null) ? characterActorComponent.Entity : null);
			}
			object obj2 = obj;
			CharacterDriveVehicleComponent characterDriveVehicleComponent = (obj2 != null) ? obj2.GetComponent<CharacterDriveVehicleComponent>() : null;
			int num = (characterDriveVehicleComponent != null) ? characterDriveVehicleComponent.Seat : -1;
			if (num == -1)
			{
				Singleton<Log>.Instance.Error(ELogModule.Vehicle, ELogAuthor.LRC, "共浴 玩家座位id undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.VehicleSeatConfigIds = configIds;
			this.RolePosIdList.Clear();
			for (int i = 0; i < this.VehicleSeatConfigIds.Count; i++)
			{
				if (i != num)
				{
					this.RolePosIdList.Add(i);
				}
			}
		}
	}

	// Token: 0x06015794 RID: 87956 RVA: 0x005F3DF4 File Offset: 0x005F1FF4
	[NullableContext(2)]
	public WorldEntity GetShowerSeatEntityByPos(int posIndex)
	{
		if (posIndex >= this.PosCount)
		{
			return null;
		}
		int num = this.VehicleSeatConfigIds[this.RolePosIdList[posIndex]];
		if (num == 0)
		{
			return null;
		}
		List<EntityHandle> list = new List<EntityHandle>();
		ModelBase<CreatureModel>.Instance.GetEntitiesWithPbDataId(num, ref list);
		WorldEntity worldEntity;
		if (list.Count <= 0)
		{
			worldEntity = null;
		}
		else
		{
			EntityHandle entityHandle = list[0];
			worldEntity = ((entityHandle != null) ? entityHandle.Entity : null);
		}
		WorldEntity worldEntity2 = worldEntity;
		if (worldEntity2 == null)
		{
			return null;
		}
		return worldEntity2;
	}

	// Token: 0x06015795 RID: 87957 RVA: 0x005F3E62 File Offset: 0x005F2062
	public void RightPos()
	{
		if (this.CurSelectPosIndexInternal >= this.PosCount - 1)
		{
			this.CurSelectPosIndexInternal = 0;
			return;
		}
		this.CurSelectPosIndexInternal++;
	}

	// Token: 0x06015796 RID: 87958 RVA: 0x005F3E8A File Offset: 0x005F208A
	public void LeftPos()
	{
		if (this.CurSelectPosIndexInternal <= 0)
		{
			this.CurSelectPosIndexInternal = this.PosCount - 1;
			return;
		}
		this.CurSelectPosIndexInternal--;
	}

	// Token: 0x06015797 RID: 87959 RVA: 0x005F3EB2 File Offset: 0x005F20B2
	public void ChangePos(int posIndex)
	{
		if (posIndex >= this.PosCount || posIndex < 0)
		{
			return;
		}
		this.CurSelectPosIndexInternal = posIndex;
	}

	// Token: 0x06015798 RID: 87960 RVA: 0x005F3ECC File Offset: 0x005F20CC
	public void InviteRole(RoleInstance roleInstance)
	{
		int curSelectPosIndexInternal = this.CurSelectPosIndexInternal;
		int num = -1;
		foreach (KeyValuePair<int, RoleInstance> keyValuePair in this.SelectInviteMap)
		{
			if (keyValuePair.Value.GetRoleId() == roleInstance.GetRoleId())
			{
				num = keyValuePair.Key;
				break;
			}
		}
		if (curSelectPosIndexInternal == num)
		{
			this.SelectInviteMap.Remove(curSelectPosIndexInternal);
			return;
		}
		RoleInstance value;
		if (this.SelectInviteMap.TryGetValue(curSelectPosIndexInternal, out value))
		{
			this.SelectInviteMap[curSelectPosIndexInternal] = roleInstance;
			if (num != -1)
			{
				this.SelectInviteMap[num] = value;
				return;
			}
		}
		else
		{
			if (num != -1)
			{
				this.SelectInviteMap.Remove(num);
			}
			this.SelectInviteMap[curSelectPosIndexInternal] = roleInstance;
		}
	}

	// Token: 0x06015799 RID: 87961 RVA: 0x005F3FA0 File Offset: 0x005F21A0
	public int GetRolePos(RoleInstance roleInstance)
	{
		foreach (KeyValuePair<int, RoleInstance> keyValuePair in this.SelectInviteMap)
		{
			if (keyValuePair.Value.GetRoleId() == roleInstance.GetRoleId())
			{
				return keyValuePair.Key;
			}
		}
		return -1;
	}

	// Token: 0x0601579A RID: 87962 RVA: 0x005F4010 File Offset: 0x005F2210
	public bool CheckRoleInCurPos(RoleInstance roleInstance)
	{
		RoleInstance roleInstance2;
		return this.SelectInviteMap.TryGetValue(this.CurSelectPosIndexInternal, out roleInstance2) && roleInstance2.GetRoleId() == roleInstance.GetRoleId();
	}

	// Token: 0x0601579B RID: 87963 RVA: 0x005F4044 File Offset: 0x005F2244
	public void ExitAndClear()
	{
		this.VehicleSeatConfigIds.Clear();
		this.RolePosIdList.Clear();
		this.SelectInviteMap.Clear();
		this.CurInviteMap.Clear();
		this.IsInShower = false;
		this.CurSelectPosIndexInternal = 0;
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ShowerMainView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.ShowerMainView, null);
		}
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ShowerInviteView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.ShowerInviteView, null);
		}
	}

	// Token: 0x0601579C RID: 87964 RVA: 0x005F40CD File Offset: 0x005F22CD
	public void ClearCurInviteRoles()
	{
		this.SelectInviteMap.Clear();
		this.CurSelectPosIndexInternal = 0;
	}

	// Token: 0x0601579D RID: 87965 RVA: 0x005F40E4 File Offset: 0x005F22E4
	public void ResetCurInviteRoles()
	{
		this.SelectInviteMap.Clear();
		foreach (KeyValuePair<int, RoleInstance> keyValuePair in this.CurInviteMap)
		{
			this.SelectInviteMap[keyValuePair.Key] = keyValuePair.Value;
		}
	}

	// Token: 0x0601579E RID: 87966 RVA: 0x005F4154 File Offset: 0x005F2354
	public void SendAndSave()
	{
		this.IsInShower = true;
		foreach (KeyValuePair<int, RoleInstance> keyValuePair in this.CurInviteMap)
		{
			if (!this.SelectInviteMap.ContainsKey(keyValuePair.Key))
			{
				Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnRemoveRideSharingPassenger, keyValuePair.Value.GetRoleId(), this.RolePosIdList[keyValuePair.Key]);
			}
		}
		foreach (KeyValuePair<int, RoleInstance> keyValuePair2 in this.SelectInviteMap)
		{
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnChangeRideSharingPassenger, keyValuePair2.Value.GetRoleId(), this.RolePosIdList[keyValuePair2.Key]);
		}
		this.CurInviteMap.Clear();
		foreach (KeyValuePair<int, RoleInstance> keyValuePair3 in this.SelectInviteMap)
		{
			this.CurInviteMap[keyValuePair3.Key] = keyValuePair3.Value;
		}
	}

	// Token: 0x0400A537 RID: 42295
	private readonly Dictionary<int, RoleInstance> SelectInviteMap = new Dictionary<int, RoleInstance>();

	// Token: 0x0400A538 RID: 42296
	private readonly Dictionary<int, RoleInstance> CurInviteMap = new Dictionary<int, RoleInstance>();

	// Token: 0x0400A539 RID: 42297
	private int CurSelectPosIndexInternal;

	// Token: 0x0400A53A RID: 42298
	private List<int> VehicleSeatConfigIds = new List<int>();

	// Token: 0x0400A53B RID: 42299
	private readonly List<int> RolePosIdList = new List<int>();

	// Token: 0x0400A53C RID: 42300
	public bool IsInShower;
}
