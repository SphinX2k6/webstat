using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002AB6 RID: 10934
public class SubPackageDownLoadVersionTipsView : UiPanelBase
{
	// Token: 0x06015E09 RID: 89609 RVA: 0x00613010 File Offset: 0x00611210
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickMaskBtn))
		};
	}

	// Token: 0x06015E0A RID: 89610 RVA: 0x006130A4 File Offset: 0x006112A4
	public void RefreshItem(int versionId, FVectorDouble vector)
	{
		DownLoadVersion? downLoadVersionByVersion = ConfigBase<SubPackageConfig>.Instance.GetDownLoadVersionByVersion(versionId);
		if (downLoadVersionByVersion == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), downLoadVersionByVersion.Value.HelpTitle, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), downLoadVersionByVersion.Value.HelpDesc, Array.Empty<object>());
		this.TipsVector.X = vector.X + 45.0;
		this.TipsVector.Z = vector.Z + 20.0;
		FHitResult fhitResult = new FHitResult();
		base.GetItem(1).D_K2_SetWorldLocation(this.TipsVector, false, ref fhitResult, false);
	}

	// Token: 0x06015E0B RID: 89611 RVA: 0x00613164 File Offset: 0x00611364
	public void RefreshItemByClearType(ESubPackageDownLoadPackageType clearType, FVectorDouble vector)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "SubPackageClearTipsTitle_TipsTitle_" + SubPackageDefineClearTypeToTipsNumber.clearTypeToTipsNumber[clearType].ToString(), Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "SubPackageClearTipsTitle_TipsDes_" + SubPackageDefineClearTypeToTipsNumber.clearTypeToTipsNumber[clearType].ToString(), Array.Empty<object>());
		this.TipsVector.X = vector.X + 45.0;
		this.TipsVector.Z = vector.Z + 20.0;
		FHitResult fhitResult = new FHitResult();
		base.GetItem(1).D_K2_SetWorldLocation(this.TipsVector, false, ref fhitResult, false);
	}

	// Token: 0x06015E0C RID: 89612 RVA: 0x00613229 File Offset: 0x00611429
	private void OnClickMaskBtn()
	{
		base.SetUiActive(false);
	}

	// Token: 0x0400A7F4 RID: 42996
	private const int BG_ITEM_OFFSETX = 45;

	// Token: 0x0400A7F5 RID: 42997
	private const int BG_ITEM_OFFSETZ = 20;

	// Token: 0x0400A7F6 RID: 42998
	private FVectorDouble TipsVector = new FVectorDouble();

	// Token: 0x02008E24 RID: 36388
	private class EComponentDefine
	{
		// Token: 0x0402FD12 RID: 195858
		public const int MaskBtn = 0;

		// Token: 0x0402FD13 RID: 195859
		public const int BgItem = 1;

		// Token: 0x0402FD14 RID: 195860
		public const int TitleText = 2;

		// Token: 0x0402FD15 RID: 195861
		public const int ContentText = 3;
	}
}
