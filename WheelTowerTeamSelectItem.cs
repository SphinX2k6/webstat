using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020016AF RID: 5807
internal class WheelTowerTeamSelectItem : GridProxyAbstract<int>
{
	// Token: 0x0600A194 RID: 41364 RVA: 0x002A7618 File Offset: 0x002A5818
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

	// Token: 0x0600A195 RID: 41365 RVA: 0x002A7724 File Offset: 0x002A5924
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerTeamSelectItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerTeamSelectItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A196 RID: 41366 RVA: 0x002A7768 File Offset: 0x002A5968
	protected override void OnStart()
	{
		UUIExtendToggle toggle = base.GetExtendToggle(0);
		if (toggle != null)
		{
			toggle.CanExecuteChange.Bind(() => toggle.ToggleState == EToggleState.ETT_UnChecked);
		}
	}

	// Token: 0x0600A197 RID: 41367 RVA: 0x002A77AC File Offset: 0x002A59AC
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.TeamId = data;
		List<RoleDataWithBranch> list = new List<RoleDataWithBranch>();
		for (int i = 0; i < ModelBase<WheelTowerModel>.Instance.GetTeamMaxRoleCount(); i++)
		{
			list.Add(new RoleDataWithBranch(0, 0));
		}
		EditFormationData formationData = ModelBase<EditFormationModel>.Instance.GetFormationData(data);
		Dictionary<int, EditFormationRoleData> dictionary = (formationData != null) ? formationData.GetRoleDataMapWithTrial(false) : null;
		if (dictionary != null)
		{
			int num = 0;
			foreach (KeyValuePair<int, EditFormationRoleData> keyValuePair in dictionary)
			{
				int configId = keyValuePair.Value.ConfigId;
				int roleCurrentBranchId = ModelBase<RoleModel>.Instance.GetRoleCurrentBranchId(configId);
				list[num] = new RoleDataWithBranch(configId, roleCurrentBranchId);
				num++;
			}
		}
		int num2 = 0;
		while (num2 < list.Count && num2 < this.SlotList.Count)
		{
			this.SlotList[num2].Refresh(list[num2], false, num2);
			num2++;
		}
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		string newText;
		if (data <= 9)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("0");
			defaultInterpolatedStringHandler.AppendFormatted<int>(data);
			newText = defaultInterpolatedStringHandler.ToStringAndClear();
		}
		else
		{
			newText = data.ToString();
		}
		text.SetText(newText, true);
	}

	// Token: 0x0600A198 RID: 41368 RVA: 0x002A78F8 File Offset: 0x002A5AF8
	public override void OnDeselected(bool fireEvent)
	{
		this.SetToggleForce(false, false);
	}

	// Token: 0x0600A199 RID: 41369 RVA: 0x002A7902 File Offset: 0x002A5B02
	private void OnToggleClick(EToggleState state)
	{
		Action<int, int> onToggleClickCallback = this.OnToggleClickCallback;
		if (onToggleClickCallback == null)
		{
			return;
		}
		onToggleClickCallback(this.TeamId, base.GridIndex);
	}

	// Token: 0x0600A19A RID: 41370 RVA: 0x002A7920 File Offset: 0x002A5B20
	public void SetToggleForce(bool selected, bool skipAnim = false)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(selected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, skipAnim);
	}

	// Token: 0x04004B88 RID: 19336
	[Nullable(2)]
	public Action<int, int> OnToggleClickCallback;

	// Token: 0x04004B89 RID: 19337
	private int TeamId = -1;

	// Token: 0x04004B8A RID: 19338
	[Nullable(1)]
	private readonly List<WheelTowerRoleGridItem> SlotList = new List<WheelTowerRoleGridItem>();
}
