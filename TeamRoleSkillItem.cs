using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020027A1 RID: 10145
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class TeamRoleSkillItem : GridProxyAbstract<TeamRoleSkillData>
{
	// Token: 0x06014080 RID: 82048 RVA: 0x00597AB8 File Offset: 0x00595CB8
	protected override void OnStart()
	{
		base.GetExtendToggle(1).OnStateChange.Add(delegate(EToggleState state)
		{
			if (this.Data != null)
			{
				Action<EToggleState, TeamRoleSkillData> callback = this.Callback;
				if (callback == null)
				{
					return;
				}
				callback(state, this.Data);
			}
		});
	}

	// Token: 0x06014081 RID: 82049 RVA: 0x00597AD7 File Offset: 0x00595CD7
	protected override void OnBeforeDestroy()
	{
		base.GetExtendToggle(1).OnStateChange.Clear();
	}

	// Token: 0x06014082 RID: 82050 RVA: 0x00597AEA File Offset: 0x00595CEA
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle))
		};
	}

	// Token: 0x06014083 RID: 82051 RVA: 0x00597B23 File Offset: 0x00595D23
	public override void OnSelected(bool fireEvent)
	{
		base.GetExtendToggle(1).SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x06014084 RID: 82052 RVA: 0x00597B35 File Offset: 0x00595D35
	public override void OnDeselected(bool fireEvent)
	{
		base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06014085 RID: 82053 RVA: 0x00597B48 File Offset: 0x00595D48
	public override void Refresh(TeamRoleSkillData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.SetSpriteByPath(data.SkillIcon, base.GetSprite(0), false, null, null);
	}

	// Token: 0x06014086 RID: 82054 RVA: 0x00597B7A File Offset: 0x00595D7A
	public void BindOnSkillStateChange(Action<EToggleState, TeamRoleSkillData> callback)
	{
		this.Callback = callback;
	}

	// Token: 0x04009C22 RID: 39970
	[Nullable(2)]
	private TeamRoleSkillData Data;

	// Token: 0x04009C23 RID: 39971
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<EToggleState, TeamRoleSkillData> Callback;

	// Token: 0x02008B5B RID: 35675
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402EFAB RID: 192427
		IconSprite,
		// Token: 0x0402EFAC RID: 192428
		ExtendToggle
	}
}
