using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002AA7 RID: 10919
public class SubPackageDownLoadClearTipsView : UiViewBase
{
	// Token: 0x06015D9F RID: 89503 RVA: 0x006103A1 File Offset: 0x0060E5A1
	[NullableContext(1)]
	public SubPackageDownLoadClearTipsView(UiViewInfo uiViewInfo) : base(uiViewInfo)
	{
	}

	// Token: 0x06015DA0 RID: 89504 RVA: 0x006103AC File Offset: 0x0060E5AC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickCancelBtn)),
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickConfirmBtn)),
			new ValueTuple<int, Delegate>(6, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x06015DA1 RID: 89505 RVA: 0x006104E0 File Offset: 0x0060E6E0
	protected override void OnStart()
	{
		bool player = LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.SubDownLoadClearOnLogin, false);
		base.GetExtendToggle(6).SetToggleState(player ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		long subPackageCanClearSpace = ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageCanClearSpace();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "SubPackageDownLoad_Clear_Des", new <>z__ReadOnlySingleElementList<object>(ModelBase<SubPackageDownLoadModel>.Instance.ByteConverter(subPackageCanClearSpace).ToString()));
		if (subPackageCanClearSpace > 0L)
		{
			base.GetItem(3).SetUIActive(true);
			base.GetText(8).SetUIActive(false);
			return;
		}
		base.GetItem(3).SetUIActive(false);
		base.GetText(8).SetUIActive(true);
	}

	// Token: 0x06015DA2 RID: 89506 RVA: 0x00610580 File Offset: 0x0060E780
	private void OnClickCancelBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x06015DA3 RID: 89507 RVA: 0x00610589 File Offset: 0x0060E789
	private void OnClickConfirmBtn()
	{
		ControllerBase<SubPackageController>.Instance.DeleteUnneededResource(true);
		base.CloseMe(null);
	}

	// Token: 0x06015DA4 RID: 89508 RVA: 0x006105A0 File Offset: 0x0060E7A0
	private void OnClickToggle(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.AutoClearUnusedResourcesConfirm);
			confirmBoxDataNew.FunctionMap[1] = delegate()
			{
				ControllerBase<ConfirmBoxController>.Instance.CloseConfirmBoxView();
				base.GetExtendToggle(6).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			};
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.SubDownLoadClearOnLogin, true);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.SubDownLoadClearOnLogin, false);
	}

	// Token: 0x02008E18 RID: 36376
	private class EComponentDefine
	{
		// Token: 0x0402FCDD RID: 195805
		public const int TitleText = 0;

		// Token: 0x0402FCDE RID: 195806
		public const int DesText = 1;

		// Token: 0x0402FCDF RID: 195807
		public const int SubDesText = 2;

		// Token: 0x0402FCE0 RID: 195808
		public const int BtnItem = 3;

		// Token: 0x0402FCE1 RID: 195809
		public const int CancelBtn = 4;

		// Token: 0x0402FCE2 RID: 195810
		public const int ConfirmBtn = 5;

		// Token: 0x0402FCE3 RID: 195811
		public const int Toggle = 6;

		// Token: 0x0402FCE4 RID: 195812
		public const int ToggleText = 7;

		// Token: 0x0402FCE5 RID: 195813
		public const int TipsText = 8;
	}
}
