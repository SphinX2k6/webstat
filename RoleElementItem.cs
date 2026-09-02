using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020027AB RID: 10155
[NullableContext(2)]
[Nullable(0)]
public class RoleElementItem : GridProxyAbstract<MainRoleConfig>
{
	// Token: 0x060140D5 RID: 82133 RVA: 0x00598E40 File Offset: 0x00597040
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
		Action<EToggleState> item = delegate(EToggleState toggleState)
		{
			Action<int> onToggleCallback = this.OnToggleCallback;
			if (onToggleCallback == null)
			{
				return;
			}
			onToggleCallback(base.GridIndex);
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, item)
		};
	}

	// Token: 0x060140D6 RID: 82134 RVA: 0x00598EEB File Offset: 0x005970EB
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(3);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.CanExecuteChange.Bind(() => this.CanToggleChange == null || this.CanToggleChange(base.GridIndex));
	}

	// Token: 0x060140D7 RID: 82135 RVA: 0x00598F10 File Offset: 0x00597110
	public void Update(MainRoleConfig mainRoleConfig)
	{
		this.MainRoleConfig = new MainRoleConfig?(mainRoleConfig);
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.MainRoleConfig.Value.Id);
		if (roleConfig == null)
		{
			return;
		}
		int elementId = roleConfig.Value.ElementId;
		ElementInfo? elementInfo = ConfigBase<ElementInfoConfig>.Instance.GetElementInfo(elementId);
		if (elementInfo == null)
		{
			return;
		}
		base.GetText(2).ShowTextNew(elementInfo.Value.Name);
		base.SetElementIcon("", base.GetTexture(1), elementId, null);
		base.SetTextureByPath(elementInfo.Value.ElementChangeTexture, base.GetTexture(0), null, null);
		this.RefreshState();
	}

	// Token: 0x060140D8 RID: 82136 RVA: 0x00598FDF File Offset: 0x005971DF
	public override void Refresh(MainRoleConfig data, bool isSelected, int gridIndex)
	{
		this.MainRoleConfig = new MainRoleConfig?(data);
		this.Update(data);
	}

	// Token: 0x060140D9 RID: 82137 RVA: 0x00598FF4 File Offset: 0x005971F4
	public void RefreshState()
	{
		int id = this.MainRoleConfig.Value.Id;
		bool uiactive = this.RoleViewAgent.GetCurSelectRoleId() == id;
		base.GetItem(4).SetUIActive(uiactive);
	}

	// Token: 0x060140DA RID: 82138 RVA: 0x00599031 File Offset: 0x00597231
	public override void OnSelected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(3);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x060140DB RID: 82139 RVA: 0x00599049 File Offset: 0x00597249
	public override void OnDeselected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(3);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x060140DC RID: 82140 RVA: 0x00599061 File Offset: 0x00597261
	[NullableContext(1)]
	public void SetRoleViewAgent(RoleViewAgent roleViewAgent)
	{
		this.RoleViewAgent = roleViewAgent;
	}

	// Token: 0x04009C39 RID: 39993
	private RoleViewAgent RoleViewAgent;

	// Token: 0x04009C3A RID: 39994
	private MainRoleConfig? MainRoleConfig;

	// Token: 0x04009C3B RID: 39995
	public Action<int> OnToggleCallback;

	// Token: 0x04009C3C RID: 39996
	public Func<int, bool> CanToggleChange;

	// Token: 0x02008B64 RID: 35684
	[NullableContext(0)]
	private enum ERoleElementItemDefine
	{
		// Token: 0x0402EFD1 RID: 192465
		ElementBgTexture,
		// Token: 0x0402EFD2 RID: 192466
		ElementIconTexture,
		// Token: 0x0402EFD3 RID: 192467
		ElementText,
		// Token: 0x0402EFD4 RID: 192468
		Toggle,
		// Token: 0x0402EFD5 RID: 192469
		MyItem
	}
}
