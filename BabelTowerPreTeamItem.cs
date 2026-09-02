using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001222 RID: 4642
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class BabelTowerPreTeamItem : GridProxyAbstract<EditFormationData>
{
	// Token: 0x06007B88 RID: 31624 RVA: 0x00205F48 File Offset: 0x00204148
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007B89 RID: 31625 RVA: 0x00206054 File Offset: 0x00204254
	protected override UniTask OnBeforeStartAsync()
	{
		BabelTowerPreTeamItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BabelTowerPreTeamItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007B8A RID: 31626 RVA: 0x00206097 File Offset: 0x00204297
	[NullableContext(2)]
	private UUIExtendToggle GetItemToggle()
	{
		return base.GetExtendToggle(0);
	}

	// Token: 0x06007B8B RID: 31627 RVA: 0x002060A0 File Offset: 0x002042A0
	public override void Refresh(EditFormationData data, bool isSelected, int gridIndex)
	{
		this.ItemData = data;
		List<int> roleIdListWithTrial = data.GetRoleIdListWithTrial(false);
		for (int i = 0; i < this.RoleList.Count; i++)
		{
			MediumItemGrid mediumItemGrid = this.RoleList[i];
			int num = (i < roleIdListWithTrial.Count) ? roleIdListWithTrial[i] : 0;
			this.HasCharacter[i] = (num != 0);
			if (num != 0)
			{
				RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(num, true);
				bool flag = isSelected && this.HasCharacter[i];
				int roleSkillBranchIndexInGamePlay = ModelBase<RoleModel>.Instance.GetRoleSkillBranchIndexInGamePlay(num, ESkillBranchCacheType.Normal);
				CharacterMediumItemGrid characterMediumItemGrid = new CharacterMediumItemGrid();
				characterMediumItemGrid.ItemConfigId = new int?(num);
				CharacterMediumItemGrid characterMediumItemGrid2 = characterMediumItemGrid;
				EditFormationRoleData roleDataById2 = data.GetRoleDataById(num);
				characterMediumItemGrid2.SkinId = ((roleDataById2 != null) ? roleDataById2.RoleSkinId : 0);
				characterMediumItemGrid.BottomTextId = "Text_LevelShow_Text";
				characterMediumItemGrid.BottomTextParameter = new object[]
				{
					roleDataById.GetLevelData().GetLevel()
				};
				characterMediumItemGrid.ElementId = new int?(roleDataById.GetRoleConfig().ElementId);
				characterMediumItemGrid.IsTrialRoleVisible = new bool?(roleDataById.IsTrialRole());
				characterMediumItemGrid.SkillBranchIndex = ((roleSkillBranchIndexInGamePlay > -1) ? new int?(roleSkillBranchIndexInGamePlay) : null);
				CharacterMediumItemGrid parameters = characterMediumItemGrid;
				mediumItemGrid.Apply<CharacterMediumItemGrid>(parameters);
				mediumItemGrid.GetItemGridExtendToggle().SetToggleStateForce(flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			}
			else
			{
				mediumItemGrid.Apply<OnlyEmptyItemGrid>(new OnlyEmptyItemGrid());
			}
		}
		base.GetText(1).SetText(data.FormationId.ToString(), true);
	}

	// Token: 0x06007B8C RID: 31628 RVA: 0x0020622F File Offset: 0x0020442F
	public override void OnSelected(bool fireEvent)
	{
		UUIExtendToggle itemToggle = this.GetItemToggle();
		if (itemToggle != null)
		{
			itemToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
		}
		Action<EditFormationData, int> onClickCallback = this.OnClickCallback;
		if (onClickCallback == null)
		{
			return;
		}
		onClickCallback(this.ItemData, base.GridIndex);
	}

	// Token: 0x06007B8D RID: 31629 RVA: 0x00206262 File Offset: 0x00204462
	public override void OnDeselected(bool fireEvent)
	{
		UUIExtendToggle itemToggle = this.GetItemToggle();
		if (itemToggle == null)
		{
			return;
		}
		itemToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06007B8E RID: 31630 RVA: 0x00206278 File Offset: 0x00204478
	public void ForceSetSelected(bool selected)
	{
		UUIExtendToggle itemToggle = this.GetItemToggle();
		if (itemToggle == null)
		{
			return;
		}
		itemToggle.SetToggleStateForce(selected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06007B8F RID: 31631 RVA: 0x00206294 File Offset: 0x00204494
	private void OnToggleClick(EToggleState state)
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

	// Token: 0x04003B21 RID: 15137
	private readonly List<MediumItemGrid> RoleList = new List<MediumItemGrid>();

	// Token: 0x04003B22 RID: 15138
	private readonly List<bool> HasCharacter = new List<bool>();

	// Token: 0x04003B23 RID: 15139
	private EditFormationData ItemData;

	// Token: 0x04003B24 RID: 15140
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<EditFormationData, int> OnClickCallback;

	// Token: 0x02007589 RID: 30089
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x040288DB RID: 166107
		public const int ToggleRoot = 0;

		// Token: 0x040288DC RID: 166108
		public const int TxtTeamIndex = 1;

		// Token: 0x040288DD RID: 166109
		public const int ItemRole1 = 2;

		// Token: 0x040288DE RID: 166110
		public const int ItemRole2 = 3;

		// Token: 0x040288DF RID: 166111
		public const int ItemRole3 = 4;
	}
}
