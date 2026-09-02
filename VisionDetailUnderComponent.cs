using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020024F7 RID: 9463
[NullableContext(1)]
[Nullable(0)]
public class VisionDetailUnderComponent : UiPanelBase
{
	// Token: 0x06012615 RID: 75285 RVA: 0x0050DE19 File Offset: 0x0050C019
	public VisionDetailUnderComponent(UUIItem actor)
	{
		base.CreateThenShowByActor(actor.GetOwner(), null);
	}

	// Token: 0x06012616 RID: 75286 RVA: 0x0050DE30 File Offset: 0x0050C030
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06012617 RID: 75287 RVA: 0x0050DE8C File Offset: 0x0050C08C
	protected override void OnStart()
	{
		this.RightButtonItem = new ButtonItem(base.GetItem(0));
		this.RightButtonItem.SetFunction(new Action<int>(this.OnRightButton));
		this.LeftButtonItem = new ButtonItem(base.GetItem(1));
		this.LeftButtonItem.SetFunction(new Action<int>(this.OnLeftButton));
		this.EquipRoleAttribute = new EquipRoleAttribute(base.GetItem(2));
	}

	// Token: 0x06012618 RID: 75288 RVA: 0x0050DEFD File Offset: 0x0050C0FD
	public void RefreshRightButtonText(string textId)
	{
		this.RightButtonItem.SetLocalText(textId, Array.Empty<object>());
	}

	// Token: 0x06012619 RID: 75289 RVA: 0x0050DF10 File Offset: 0x0050C110
	public void RefreshLeftButtonText(string textId)
	{
		this.LeftButtonItem.SetLocalText(textId, Array.Empty<object>());
	}

	// Token: 0x0601261A RID: 75290 RVA: 0x0050DF23 File Offset: 0x0050C123
	private void OnRightButton(int _)
	{
		Action onClickRightButton = this.OnClickRightButton;
		if (onClickRightButton == null)
		{
			return;
		}
		onClickRightButton();
	}

	// Token: 0x0601261B RID: 75291 RVA: 0x0050DF35 File Offset: 0x0050C135
	private void OnLeftButton(int _)
	{
		Action onClickLeftButton = this.OnClickLeftButton;
		if (onClickLeftButton == null)
		{
			return;
		}
		onClickLeftButton();
	}

	// Token: 0x0601261C RID: 75292 RVA: 0x0050DF47 File Offset: 0x0050C147
	public void SetRightButtonClick(Action call)
	{
		this.OnClickRightButton = call;
	}

	// Token: 0x0601261D RID: 75293 RVA: 0x0050DF50 File Offset: 0x0050C150
	public void SetLeftButtonClick(Action call)
	{
		this.OnClickLeftButton = call;
	}

	// Token: 0x0601261E RID: 75294 RVA: 0x0050DF59 File Offset: 0x0050C159
	public void RefreshViewByCompareState(bool ifCompare)
	{
		this.LeftButtonItem.SetActive(!ifCompare);
		this.RightButtonItem.SetActive(!ifCompare);
	}

	// Token: 0x0601261F RID: 75295 RVA: 0x0050DF79 File Offset: 0x0050C179
	public void Update(PhantomBattleData data)
	{
		this.EquipRoleAttribute.SetActive(ControllerBase<PhantomBattleController>.Instance.CheckIsEquip(data.GetUniqueId()));
		this.EquipRoleAttribute.Update(data);
	}

	// Token: 0x04008F5E RID: 36702
	[Nullable(2)]
	private EquipRoleAttribute EquipRoleAttribute;

	// Token: 0x04008F5F RID: 36703
	[Nullable(2)]
	private ButtonItem RightButtonItem;

	// Token: 0x04008F60 RID: 36704
	[Nullable(2)]
	private ButtonItem LeftButtonItem;

	// Token: 0x04008F61 RID: 36705
	[Nullable(2)]
	private Action OnClickRightButton;

	// Token: 0x04008F62 RID: 36706
	[Nullable(2)]
	private Action OnClickLeftButton;

	// Token: 0x02008810 RID: 34832
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402DF67 RID: 188263
		RightButton,
		// Token: 0x0402DF68 RID: 188264
		LeftButton,
		// Token: 0x0402DF69 RID: 188265
		AttributePanel
	}
}
