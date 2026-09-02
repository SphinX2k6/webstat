using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x020022F3 RID: 8947
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleDiyPartTabItem : CommonTabItemBase
{
	// Token: 0x06010EF0 RID: 69360 RVA: 0x004A3404 File Offset: 0x004A1604
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x06010EF1 RID: 69361 RVA: 0x004A34D9 File Offset: 0x004A16D9
	private void OnClickToggle(EToggleState toggleState)
	{
		bool flag = toggleState == EToggleState.ETT_Checked;
		this.ChangeTabIcon(toggleState == EToggleState.ETT_Checked);
		if (!flag)
		{
			return;
		}
		Action<int> selectedCallBack = this.SelectedCallBack;
		if (selectedCallBack == null)
		{
			return;
		}
		selectedCallBack(base.GridIndex);
	}

	// Token: 0x06010EF2 RID: 69362 RVA: 0x004A3504 File Offset: 0x004A1704
	protected override void OnRefresh(CommonTabItemData data, bool isSelected, int gridIndex)
	{
		MotorcycleDiyPartTabItemData motorcycleDiyPartTabItemData = data as MotorcycleDiyPartTabItemData;
		if (motorcycleDiyPartTabItemData == null)
		{
			return;
		}
		EOutlookType outlookType = motorcycleDiyPartTabItemData.OutlookType;
		int partId = motorcycleDiyPartTabItemData.PartId;
		string text = null;
		if (outlookType == EOutlookType.Sticker)
		{
			MotorStickerPart? motorStickerPartConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerPartConfig(partId);
			if (motorStickerPartConfig != null)
			{
				text = motorStickerPartConfig.Value.Icon;
			}
		}
		else if (outlookType == EOutlookType.Decoration)
		{
			MotorDecorationsPart? motorDecorationPartConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorDecorationPartConfig(partId);
			if (motorDecorationPartConfig != null)
			{
				text = motorDecorationPartConfig.Value.Icon;
			}
		}
		if (text != null)
		{
			base.SetTextureByPath(text, base.GetTexture(0), null, null);
		}
		base.GetItem(4).SetUIActive(motorcycleDiyPartTabItemData.IsShowLine);
		this.SetPresetRedDotVisible(false);
	}

	// Token: 0x06010EF3 RID: 69363 RVA: 0x004A35B9 File Offset: 0x004A17B9
	protected override void OnUpdateTabIcon(string iconPath)
	{
	}

	// Token: 0x06010EF4 RID: 69364 RVA: 0x004A35BB File Offset: 0x004A17BB
	protected override void OnSetToggleState(EToggleState state, bool bFire)
	{
		base.GetExtendToggle(1).SetToggleStateForce(state, bFire, false, false);
		this.ChangeTabIcon(state == EToggleState.ETT_Checked);
	}

	// Token: 0x06010EF5 RID: 69365 RVA: 0x004A35D7 File Offset: 0x004A17D7
	protected override UUIExtendToggle GetTabToggle()
	{
		return base.GetExtendToggle(1);
	}

	// Token: 0x06010EF6 RID: 69366 RVA: 0x004A35E0 File Offset: 0x004A17E0
	private void ChangeTabIcon(bool selected)
	{
		MotorcycleDiyPartTabItemData motorcycleDiyPartTabItemData = this.CurrentData as MotorcycleDiyPartTabItemData;
		if (motorcycleDiyPartTabItemData == null)
		{
			return;
		}
		EOutlookType outlookType = motorcycleDiyPartTabItemData.OutlookType;
		int partId = motorcycleDiyPartTabItemData.PartId;
		string text = null;
		if (outlookType == EOutlookType.Sticker)
		{
			MotorStickerPart? motorStickerPartConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerPartConfig(partId);
			if (motorStickerPartConfig != null)
			{
				text = (selected ? motorStickerPartConfig.Value.IconSelect : motorStickerPartConfig.Value.Icon);
			}
		}
		else if (outlookType == EOutlookType.Decoration)
		{
			MotorDecorationsPart? motorDecorationPartConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorDecorationPartConfig(partId);
			if (motorDecorationPartConfig != null)
			{
				text = (selected ? motorDecorationPartConfig.Value.IconSelect : motorDecorationPartConfig.Value.Icon);
			}
		}
		if (text != null)
		{
			base.SetTextureByPath(text, base.GetTexture(0), null, null);
		}
	}

	// Token: 0x06010EF7 RID: 69367 RVA: 0x004A36AC File Offset: 0x004A18AC
	public void BindRedDot(ERedDotName redDotName, int typePart)
	{
		this.UnBindRedDot();
		UUIItem item = base.GetItem(3);
		this.RedDotName = new ERedDotName?(redDotName);
		this.TypePart = typePart;
		ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, item, null, typePart);
	}

	// Token: 0x06010EF8 RID: 69368 RVA: 0x004A36E8 File Offset: 0x004A18E8
	public void UnBindRedDot()
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, base.GetItem(3), this.TypePart);
			this.RedDotName = null;
			this.TypePart = 0;
		}
	}

	// Token: 0x06010EF9 RID: 69369 RVA: 0x004A3738 File Offset: 0x004A1938
	public void BindPreviewRedDot(ERedDotName redDotName, int typePart)
	{
		this.UnBindPreviewRedDot();
		UUIItem item = base.GetItem(5);
		this.PreviewRedDotName = new ERedDotName?(redDotName);
		this.PreviewTypePart = typePart;
		ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, item, null, typePart);
	}

	// Token: 0x06010EFA RID: 69370 RVA: 0x004A3774 File Offset: 0x004A1974
	public void UnBindPreviewRedDot()
	{
		if (this.PreviewRedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.PreviewRedDotName.Value, base.GetItem(5), this.PreviewTypePart);
			this.PreviewRedDotName = null;
			this.PreviewTypePart = 0;
		}
	}

	// Token: 0x06010EFB RID: 69371 RVA: 0x004A37C3 File Offset: 0x004A19C3
	public void SetPreviewRedDotVisible(bool isVisible)
	{
		base.GetItem(5).SetUIActive(isVisible);
	}

	// Token: 0x06010EFC RID: 69372 RVA: 0x004A37D2 File Offset: 0x004A19D2
	public void SetPresetRedDotVisible(bool isVisible)
	{
		base.GetItem(6).SetUIActive(isVisible);
	}

	// Token: 0x0400855D RID: 34141
	private ERedDotName? RedDotName;

	// Token: 0x0400855E RID: 34142
	private int TypePart;

	// Token: 0x0400855F RID: 34143
	private ERedDotName? PreviewRedDotName;

	// Token: 0x04008560 RID: 34144
	private int PreviewTypePart;

	// Token: 0x020085C9 RID: 34249
	[NullableContext(0)]
	private class EMotorDiyPartTabItemComponent
	{
		// Token: 0x0402D40E RID: 185358
		public const int TexIcon = 0;

		// Token: 0x0402D40F RID: 185359
		public const int TogItem = 1;

		// Token: 0x0402D410 RID: 185360
		public const int RedDotItem = 2;

		// Token: 0x0402D411 RID: 185361
		public const int NewItem = 3;

		// Token: 0x0402D412 RID: 185362
		public const int LineItem = 4;

		// Token: 0x0402D413 RID: 185363
		public const int PreviewItem = 5;

		// Token: 0x0402D414 RID: 185364
		public const int PresetChangeItem = 6;
	}
}
