using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020028FA RID: 10490
[NullableContext(1)]
[Nullable(0)]
public class RoleAttrListScrollItem : UiPanelBase
{
	// Token: 0x06014D5C RID: 85340 RVA: 0x005C5374 File Offset: 0x005C3574
	public RoleAttrListScrollItem(UUIItem uiItem, CommonComponentDefine.EAttributeType type)
	{
		this.Type = type;
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x06014D5D RID: 85341 RVA: 0x005C5390 File Offset: 0x005C3590
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.ToggleEvent))
		};
	}

	// Token: 0x06014D5E RID: 85342 RVA: 0x005C54A8 File Offset: 0x005C36A8
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		extendToggle.RootUIComp.Get().SetUIActive(true);
		extendToggle.CanExecuteChange.Unbind();
		extendToggle.CanExecuteChange.Bind(new Func<bool>(this.CanClickLikeToggle));
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		base.GetItem(7).SetUIActive(false);
	}

	// Token: 0x06014D5F RID: 85343 RVA: 0x005C550F File Offset: 0x005C370F
	protected override void OnBeforeDestroy()
	{
		if (this.LevelSequencePlayer != null)
		{
			this.LevelSequencePlayer.Clear();
			this.LevelSequencePlayer = null;
		}
	}

	// Token: 0x06014D60 RID: 85344 RVA: 0x005C552C File Offset: 0x005C372C
	public void ShowTemp(AttrListScrollData data, int index)
	{
		base.GetSprite(1).SetUIActive(index % 2 == 1);
		base.GetItem(9).SetUIActive(index % 2 == 0);
		this.Data = data;
		this.SetAttrValue(data);
		base.GetText(3).ShowTextNew(data.GetName());
		base.SetTextureByPath(data.GetIcon(), base.GetTexture(2), null, null);
		string desc = data.GetDesc();
		if (!string.IsNullOrEmpty(desc))
		{
			base.GetItem(6).SetUIActive(true);
			base.GetText(8).ShowTextNew(desc);
			return;
		}
		base.GetItem(6).SetUIActive(false);
	}

	// Token: 0x06014D61 RID: 85345 RVA: 0x005C55D4 File Offset: 0x005C37D4
	protected void SetAttrValue(AttrListScrollData attrData)
	{
		double? num = null;
		double? num2 = null;
		if (attrData.Id == 2 || attrData.Id == 7 || attrData.Id == 10)
		{
			num = new double?(attrData.BaseValue);
			num2 = new double?(attrData.AddValue);
		}
		else if (attrData.Id == 69)
		{
			num = new double?((attrData.BaseValue + attrData.AddValue) / 100.0);
		}
		else
		{
			num = new double?(attrData.BaseValue + attrData.AddValue);
		}
		if (this.Type == CommonComponentDefine.EAttributeType.PhantomType)
		{
			double num3 = attrData.BaseValue + attrData.AddValue;
			if (attrData.Id == 69)
			{
				num2 = new double?(num3 / 100.0);
			}
			else
			{
				num2 = new double?(num3);
			}
			base.GetText(4).SetText(ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(attrData.Id, num2.Value, false), true);
			base.GetText(5).SetUIActive(false);
			return;
		}
		base.GetText(4).SetText(ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(attrData.Id, num.Value, attrData.IsRatio), true);
		UUIText text = base.GetText(5);
		if (num2 != null && num2.Value != 0.0)
		{
			string str = (num2.Value >= 0.0) ? "+" : "";
			text.SetText(str + ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(attrData.Id, attrData.AddValue, attrData.IsRatio), true);
			text.SetUIActive(true);
			return;
		}
		text.SetUIActive(false);
	}

	// Token: 0x06014D62 RID: 85346 RVA: 0x005C577D File Offset: 0x005C397D
	private bool CanClickLikeToggle()
	{
		AttrListScrollData data = this.Data;
		return !string.IsNullOrEmpty((data != null) ? data.GetDesc() : null);
	}

	// Token: 0x06014D63 RID: 85347 RVA: 0x005C579C File Offset: 0x005C399C
	protected void ToggleEvent(EToggleState bState)
	{
		bool flag = bState == EToggleState.ETT_Checked;
		base.GetText(8).SetUIActive(flag);
		base.GetItem(7).SetUIActive(flag);
		string sequenceName = flag ? "Show" : "Hide";
		if (this.LevelSequencePlayer != null)
		{
			this.LevelSequencePlayer.StopCurrentSequence(false, false);
			this.LevelSequencePlayer.PlayLevelSequenceByName(sequenceName, false, null, false);
		}
	}

	// Token: 0x0400A053 RID: 41043
	private readonly CommonComponentDefine.EAttributeType Type;

	// Token: 0x0400A054 RID: 41044
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400A055 RID: 41045
	[Nullable(2)]
	private AttrListScrollData Data;
}
