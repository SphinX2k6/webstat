using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200209A RID: 8346
public class KingShipFailView : UiViewBase
{
	// Token: 0x0600FEB7 RID: 65207 RVA: 0x0045E626 File Offset: 0x0045C826
	[NullableContext(1)]
	public KingShipFailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600FEB8 RID: 65208 RVA: 0x0045E630 File Offset: 0x0045C830
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickCloseBtn))
		};
	}

	// Token: 0x0600FEB9 RID: 65209 RVA: 0x0045E6B0 File Offset: 0x0045C8B0
	protected override void OnStart()
	{
		int cardId = ((IKingShipFailViewData)this.OpenParam).CardId;
		string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey("ReignsCard_" + cardId.ToString() + "_CardDesc");
		base.GetText(1).SetText(configTextByKey, true);
		string configTextByKey2 = Singleton<PublicUtil>.Instance.GetConfigTextByKey("ReignsCard_" + cardId.ToString() + "_CardTitle");
		base.GetText(0).SetText(configTextByKey2, true);
	}

	// Token: 0x0600FEBA RID: 65210 RVA: 0x0045E72C File Offset: 0x0045C92C
	private void OnClickCloseBtn()
	{
		((IKingShipFailViewData)this.OpenParam).OnCloseCallBack();
		base.CloseMe(null);
	}

	// Token: 0x0600FEBB RID: 65211 RVA: 0x0045E74A File Offset: 0x0045C94A
	protected override void OnBeforeDestroy()
	{
	}

	// Token: 0x02008426 RID: 33830
	private class EComponentDefine
	{
		// Token: 0x0402CCA3 RID: 183459
		public const int TitleText = 0;

		// Token: 0x0402CCA4 RID: 183460
		public const int DesText = 1;

		// Token: 0x0402CCA5 RID: 183461
		public const int CloseBtn = 2;
	}
}
