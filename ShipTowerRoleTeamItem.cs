using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029D6 RID: 10710
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ShipTowerRoleTeamItem : GridProxyAbstract<EditFormationData>
{
	// Token: 0x0601559D RID: 87453 RVA: 0x005EAAB4 File Offset: 0x005E8CB4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUISprite))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggleRoot))
		};
	}

	// Token: 0x0601559E RID: 87454 RVA: 0x005EAB74 File Offset: 0x005E8D74
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerRoleTeamItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerRoleTeamItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601559F RID: 87455 RVA: 0x005EABB7 File Offset: 0x005E8DB7
	[NullableContext(2)]
	private UUIExtendToggle GetItemToggle()
	{
		return base.GetExtendToggle(0);
	}

	// Token: 0x060155A0 RID: 87456 RVA: 0x005EABC0 File Offset: 0x005E8DC0
	private void OnClickToggleRoot(EToggleState state)
	{
		UUIExtendToggle itemToggle = this.GetItemToggle();
		if (itemToggle != null)
		{
			itemToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
		}
		IScrollViewDelegate<IGridProxy<EditFormationData>, EditFormationData> scrollViewDelegate = base.ScrollViewDelegate;
		if (scrollViewDelegate == null)
		{
			return;
		}
		scrollViewDelegate.SelectGridProxy(base.GridIndex, base.DisplayIndex, false);
	}

	// Token: 0x060155A1 RID: 87457 RVA: 0x005EABF4 File Offset: 0x005E8DF4
	public override void Refresh(EditFormationData data, bool isSelected, int gridIndex)
	{
		this.ItemData = data;
		bool flag = true;
		List<int> roleIdListWithTrial = data.GetRoleIdListWithTrial(false);
		for (int i = 0; i < this.RoleList.Count; i++)
		{
			int num = (i < roleIdListWithTrial.Count) ? roleIdListWithTrial[i] : 0;
			MediumItemGrid mediumItemGrid = this.RoleList[i];
			if (num != 0)
			{
				RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(num, true);
				ShipTowerRoleData allTeamRoleData = ModelBase<ShipTowerModel>.Instance.GetAllTeamRoleData(num);
				EditFormationRoleData roleDataById2 = data.GetRoleDataById(num);
				int roleCurrentBranchIndex = ModelBase<RoleModel>.Instance.GetRoleCurrentBranchIndex(num);
				CharacterMediumItemGrid parameters = new CharacterMediumItemGrid
				{
					ItemConfigId = new int?(num),
					SkinId = ((roleDataById2 != null) ? roleDataById2.RoleSkinId : 0),
					BottomTextId = "Text_LevelShow_Text",
					BottomTextParameter = new object[]
					{
						roleDataById.GetLevelData().GetLevel()
					},
					ElementId = new int?(roleDataById.GetRoleConfig().ElementId),
					HalfAreaInfo = allTeamRoleData,
					IsTrialRoleVisible = new bool?(roleDataById.IsTrialRole()),
					SkillBranchIndex = ((roleCurrentBranchIndex > -1) ? new int?(roleCurrentBranchIndex) : null)
				};
				mediumItemGrid.Apply<CharacterMediumItemGrid>(parameters);
				if (allTeamRoleData == null)
				{
					flag = false;
				}
			}
			else
			{
				flag = false;
				mediumItemGrid.Apply<OnlyEmptyItemGrid>(new OnlyEmptyItemGrid());
			}
		}
		base.GetText(1).SetText(data.FormationId.ToString(), true);
		if (flag)
		{
			int[] getRoleIdList = data.GetRoleIdList;
			flag = false;
			for (int j = 0; j < this.StageData.TeamDataList.Count; j++)
			{
				List<int> roleIdListEdit = this.StageData.TeamDataList[j].GetRoleIdListEdit();
				if (roleIdListEdit.Count == getRoleIdList.Length)
				{
					bool flag2 = true;
					for (int k = 0; k < getRoleIdList.Length; k++)
					{
						if (roleIdListEdit[k] != getRoleIdList[k])
						{
							flag2 = false;
							break;
						}
					}
					if (flag2)
					{
						flag = true;
						break;
					}
				}
			}
		}
		UUISprite sprite = base.GetSprite(5);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(flag);
	}

	// Token: 0x060155A2 RID: 87458 RVA: 0x005EAE09 File Offset: 0x005E9009
	public override void OnSelected(bool fireEvent)
	{
		UUIExtendToggle itemToggle = this.GetItemToggle();
		if (itemToggle != null)
		{
			itemToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
		}
		Action<EditFormationData> onClickCallback = this.OnClickCallback;
		if (onClickCallback == null)
		{
			return;
		}
		onClickCallback(this.ItemData);
	}

	// Token: 0x060155A3 RID: 87459 RVA: 0x005EAE36 File Offset: 0x005E9036
	public override void OnDeselected(bool fireEvent)
	{
		UUIExtendToggle itemToggle = this.GetItemToggle();
		if (itemToggle == null)
		{
			return;
		}
		itemToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0400A474 RID: 42100
	private readonly List<MediumItemGrid> RoleList = new List<MediumItemGrid>();

	// Token: 0x0400A475 RID: 42101
	private EditFormationData ItemData;

	// Token: 0x0400A476 RID: 42102
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<EditFormationData> OnClickCallback;

	// Token: 0x0400A477 RID: 42103
	public ShipTowerStageData StageData;

	// Token: 0x02008D3E RID: 36158
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F7FF RID: 194559
		public const int ToggleRoot = 0;

		// Token: 0x0402F800 RID: 194560
		public const int TxtTeamIndex = 1;

		// Token: 0x0402F801 RID: 194561
		public const int ItemRole1 = 2;

		// Token: 0x0402F802 RID: 194562
		public const int ItemRole2 = 3;

		// Token: 0x0402F803 RID: 194563
		public const int ItemRole3 = 4;

		// Token: 0x0402F804 RID: 194564
		public const int SpriteApplyAll = 5;
	}
}
