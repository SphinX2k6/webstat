using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020020A9 RID: 8361
public class KingShipResultView : UiViewBase
{
	// Token: 0x0600FF52 RID: 65362 RVA: 0x00461A46 File Offset: 0x0045FC46
	[NullableContext(1)]
	public KingShipResultView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600FF53 RID: 65363 RVA: 0x00461A50 File Offset: 0x0045FC50
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(6, new Action(this.OnClickCloseBtn)),
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickMaskBtn))
		};
	}

	// Token: 0x0600FF54 RID: 65364 RVA: 0x00461B40 File Offset: 0x0045FD40
	protected override void OnStart()
	{
		IKingShipResultViewData kingShipResultViewData = (IKingShipResultViewData)this.OpenParam;
		this.IsSuccess = kingShipResultViewData.IsSuccess;
		this.ReignsId = kingShipResultViewData.ReignsId;
		this.NextReignsId = kingShipResultViewData.NextReignsId;
		int cardId = kingShipResultViewData.CardId;
		string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey("ReignsCard_" + cardId.ToString() + "_CardDesc");
		base.GetText(3).SetText(configTextByKey, true);
		string configTextByKey2 = Singleton<PublicUtil>.Instance.GetConfigTextByKey("ReignsCard_" + cardId.ToString() + "_CardTitle");
		base.GetText(0).SetText(configTextByKey2, true);
		string configTextByKey3 = Singleton<PublicUtil>.Instance.GetConfigTextByKey("ReignsCard_" + cardId.ToString() + "_CardHeader");
		base.GetText(1).SetText(configTextByKey3, true);
	}

	// Token: 0x0600FF55 RID: 65365 RVA: 0x00461C14 File Offset: 0x0045FE14
	private void OnClickMaskBtn()
	{
		if (this.IsSuccess)
		{
			ControllerBase<GeneralLogicTreeController>.Instance.RequestFinishUiGameplay(UiGamePlayType.Reigns, this.ReignsId.ToString());
		}
		if (this.IsSuccess && this.NextReignsId != 0)
		{
			IKingShipMainViewOpenData kingShipOpenData = KingShipUtil.GetKingShipOpenData(this.NextReignsId);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.KingShipLoadingView, kingShipOpenData, delegate(bool _, int _)
			{
				base.CloseMe(null);
			});
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x0600FF56 RID: 65366 RVA: 0x00461C7F File Offset: 0x0045FE7F
	private void OnClickCloseBtn()
	{
		if (this.IsSuccess)
		{
			ControllerBase<GeneralLogicTreeController>.Instance.RequestFinishUiGameplay(UiGamePlayType.Reigns, this.ReignsId.ToString());
		}
		base.CloseMe(null);
	}

	// Token: 0x04007A76 RID: 31350
	private bool IsSuccess;

	// Token: 0x04007A77 RID: 31351
	private int ReignsId;

	// Token: 0x04007A78 RID: 31352
	private int NextReignsId;

	// Token: 0x02008435 RID: 33845
	private class EComponentDefine
	{
		// Token: 0x0402CCF9 RID: 183545
		public const int TitleText = 0;

		// Token: 0x0402CCFA RID: 183546
		public const int MainTitleText = 1;

		// Token: 0x0402CCFB RID: 183547
		public const int StaticText = 2;

		// Token: 0x0402CCFC RID: 183548
		public const int DesText = 3;

		// Token: 0x0402CCFD RID: 183549
		public const int Static2Text = 4;

		// Token: 0x0402CCFE RID: 183550
		public const int MaskBtn = 5;

		// Token: 0x0402CCFF RID: 183551
		public const int CloseBtn = 6;
	}
}
