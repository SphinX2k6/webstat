using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020028C4 RID: 10436
[NullableContext(2)]
[Nullable(0)]
public class RoleSkillLine : UiPanelBase
{
	// Token: 0x06014B42 RID: 84802 RVA: 0x005BBA6C File Offset: 0x005B9C6C
	[NullableContext(1)]
	public RoleSkillLine(int startNodeId, int endNodeId, string color, UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
		this.InactiveNode = uiItem.GetAttachUIChild(0);
		this.ActiveNode = uiItem.GetAttachUIChild(1);
		this.ActiveEffect = uiItem.GetAttachUIChild(2);
		this.StartPosId = new int?(startNodeId);
		this.EndPosId = new int?(endNodeId);
		this.SetColor(color);
	}

	// Token: 0x06014B43 RID: 84803 RVA: 0x005BBAD6 File Offset: 0x005B9CD6
	[NullableContext(1)]
	public void SetColor(string color)
	{
		if (this.ActiveEffect != null)
		{
			this.ActiveEffect.SetColor(FColor.FromHex(color));
		}
		if (this.ActiveNode != null)
		{
			this.ActiveNode.SetColor(FColor.FromHex(color));
		}
	}

	// Token: 0x06014B44 RID: 84804 RVA: 0x005BBB0C File Offset: 0x005B9D0C
	public void SetLineActive(ELineState lineState)
	{
		switch (lineState)
		{
		case ELineState.None:
			this.RootItem.SetUIActive(false);
			this.ActiveEffect.SetUIActive(false);
			return;
		case ELineState.InActive:
			this.RootItem.SetUIActive(true);
			this.InactiveNode.SetUIActive(true);
			this.ActiveNode.SetUIActive(false);
			this.ActiveEffect.SetUIActive(false);
			return;
		case ELineState.Active:
			this.RootItem.SetUIActive(true);
			this.InactiveNode.SetUIActive(false);
			this.ActiveNode.SetUIActive(true);
			this.ActiveEffect.SetUIActive(true);
			return;
		default:
			return;
		}
	}

	// Token: 0x06014B45 RID: 84805 RVA: 0x005BBBA8 File Offset: 0x005B9DA8
	protected override void OnBeforeDestroy()
	{
		this.StartPosId = null;
		this.EndPosId = null;
		this.InactiveNode = null;
		this.ActiveNode = null;
		this.ActiveEffect = null;
	}

	// Token: 0x04009FA3 RID: 40867
	public int? StartPosId;

	// Token: 0x04009FA4 RID: 40868
	public int? EndPosId;

	// Token: 0x04009FA5 RID: 40869
	private UUIItem InactiveNode;

	// Token: 0x04009FA6 RID: 40870
	private UUIItem ActiveNode;

	// Token: 0x04009FA7 RID: 40871
	private UUIItem ActiveEffect;
}
