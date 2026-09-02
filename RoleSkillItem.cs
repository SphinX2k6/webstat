using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200169F RID: 5791
[NullableContext(1)]
[Nullable(0)]
internal class RoleSkillItem : GridProxyAbstract<int>
{
	// Token: 0x0600A14F RID: 41295 RVA: 0x002A63CC File Offset: 0x002A45CC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.ToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A150 RID: 41296 RVA: 0x002A6494 File Offset: 0x002A4694
	public override void Refresh(int skillId, bool isSelected, int gridIndex)
	{
		this.SkillId = skillId;
		Aki.Config.Skill? skillConfigById = ConfigBase<RoleSkillConfig>.Instance.GetSkillConfigById(skillId);
		if (skillConfigById == null)
		{
			return;
		}
		UUISprite icon = base.GetSprite(1);
		icon.SetUIActive(false);
		this.SetSpriteByPath(skillConfigById.Value.Icon, icon, false, null, delegate(bool _)
		{
			icon.SetUIActive(true);
		});
		int roleId = ModelBase<WheelTowerModel>.Instance.TryGetRealRoleId(ModelBase<WheelTowerModel>.Instance.TmpSelectRoleId);
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(ModelBase<WheelTowerModel>.Instance.IsEnhanceSkill(roleId, skillId));
		}
		this.SetSelectedState(isSelected, true);
	}

	// Token: 0x0600A151 RID: 41297 RVA: 0x002A654A File Offset: 0x002A474A
	public override object GetKey(int data, int gridIndex)
	{
		return data;
	}

	// Token: 0x0600A152 RID: 41298 RVA: 0x002A6552 File Offset: 0x002A4752
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelectedState(false, false);
	}

	// Token: 0x0600A153 RID: 41299 RVA: 0x002A655C File Offset: 0x002A475C
	public void SetToggleCallback(Action<int> callback)
	{
		this.ToggleCallback = callback;
	}

	// Token: 0x0600A154 RID: 41300 RVA: 0x002A6565 File Offset: 0x002A4765
	private void ToggleClick(EToggleState state)
	{
		Action<int> toggleCallback = this.ToggleCallback;
		if (toggleCallback == null)
		{
			return;
		}
		toggleCallback(this.SkillId);
	}

	// Token: 0x0600A155 RID: 41301 RVA: 0x002A657D File Offset: 0x002A477D
	public void SetSelectedState(bool selected, bool skipAnim = false)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(selected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, skipAnim);
	}

	// Token: 0x04004B53 RID: 19283
	private int SkillId;

	// Token: 0x04004B54 RID: 19284
	[Nullable(2)]
	private Action<int> ToggleCallback;
}
