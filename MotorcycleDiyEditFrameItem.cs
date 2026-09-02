using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020022CD RID: 8909
[Nullable(new byte[]
{
	0,
	1
})]
public class MotorcycleDiyEditFrameItem : GridProxyAbstract<MotorcycleDiyEditFrameItemData>
{
	// Token: 0x06010DC1 RID: 69057 RVA: 0x0049D538 File Offset: 0x0049B738
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickItem))
		};
	}

	// Token: 0x06010DC2 RID: 69058 RVA: 0x0049D63C File Offset: 0x0049B83C
	[NullableContext(1)]
	public override void Refresh(MotorcycleDiyEditFrameItemData data, bool isSelected, int gridIndex)
	{
		this.FrameId = data.ItemId;
		UUITexture texture = base.GetTexture(1);
		UUITexture texture2 = base.GetTexture(2);
		UUITexture texture3 = base.GetTexture(3);
		UUIItem item = base.GetItem(4);
		UUIItem item2 = base.GetItem(5);
		UUIItem item3 = base.GetItem(6);
		UUIItem item4 = base.GetItem(7);
		UUIItem item5 = base.GetItem(8);
		item3.SetUIActive(false);
		item4.SetUIActive(false);
		item5.SetUIActive(false);
		item2.SetUIActive(false);
		bool flag = ModelBase<MotorcycleDiyModel>.Instance.GetSelectedFrameId() == data.ItemId;
		item.SetUIActive(flag);
		if (ModelBase<MotorcycleDiyModel>.Instance.GetFrameState(data.ItemId) == EOutLookState.IsBan)
		{
			item4.SetUIActive(true);
		}
		MotorFrame? motorFrameConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorFrameConfig(data.ItemId);
		if (motorFrameConfig == null)
		{
			return;
		}
		MotorQuality? motorQualityConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorQualityConfig(motorFrameConfig.Value.QualityId);
		if (motorQualityConfig == null)
		{
			return;
		}
		base.SetTextureByPath(motorFrameConfig.Value.ModelIconPath, texture, null, null);
		base.SetTextureByPath(motorQualityConfig.Value.FramePath, texture2, null, null);
		base.SetTextureByPath(motorQualityConfig.Value.FrameShinePath, texture3, null, null);
		EToggleState state = flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(0).SetToggleState(state, false, false, false);
	}

	// Token: 0x06010DC3 RID: 69059 RVA: 0x0049D7A8 File Offset: 0x0049B9A8
	public override void OnSelected(bool fireEvent)
	{
		this.OnClickItem(EToggleState.ETT_Checked);
	}

	// Token: 0x06010DC4 RID: 69060 RVA: 0x0049D7B1 File Offset: 0x0049B9B1
	private void OnClickItem(EToggleState toggleState)
	{
		if (this.FrameId == 0)
		{
			return;
		}
		Action<int, UUIExtendToggle, UUIItem> onClickToggleBack = this.OnClickToggleBack;
		if (onClickToggleBack == null)
		{
			return;
		}
		onClickToggleBack(this.FrameId, base.GetExtendToggle(0), base.GetItem(6));
	}

	// Token: 0x040084E2 RID: 34018
	private int FrameId;

	// Token: 0x040084E3 RID: 34019
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<int, UUIExtendToggle, UUIItem> OnClickToggleBack;

	// Token: 0x020085A7 RID: 34215
	private class EEditFrameItemComponent
	{
		// Token: 0x0402D372 RID: 185202
		public const int TogFrame = 0;

		// Token: 0x0402D373 RID: 185203
		public const int TexIcon = 1;

		// Token: 0x0402D374 RID: 185204
		public const int TexQuality1 = 2;

		// Token: 0x0402D375 RID: 185205
		public const int TexQuality2 = 3;

		// Token: 0x0402D376 RID: 185206
		public const int PnlSelect = 4;

		// Token: 0x0402D377 RID: 185207
		public const int Pnllock = 5;

		// Token: 0x0402D378 RID: 185208
		public const int NewItem = 6;

		// Token: 0x0402D379 RID: 185209
		public const int BanItem = 7;

		// Token: 0x0402D37A RID: 185210
		public const int PreviewItem = 8;
	}
}
