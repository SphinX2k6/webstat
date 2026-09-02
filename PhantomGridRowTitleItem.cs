using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020024D0 RID: 9424
public class PhantomGridRowTitleItem : SyncGridProxyAbstract<int>
{
	// Token: 0x060124C6 RID: 74950 RVA: 0x00508100 File Offset: 0x00506300
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(delegate()
			{
				Action clickRecommendBtnCb = this.ClickRecommendBtnCb;
				if (clickRecommendBtnCb == null)
				{
					return;
				}
				clickRecommendBtnCb();
			}))
		};
	}

	// Token: 0x060124C7 RID: 74951 RVA: 0x00508168 File Offset: 0x00506368
	public override void Refresh(int data)
	{
		bool uiactive = false;
		string textStringId;
		if (data - 1 > 1)
		{
			if (data != 3)
			{
				textStringId = "";
			}
			else
			{
				textStringId = "PhantomDisplay_ElseTitle";
			}
		}
		else
		{
			uiactive = true;
			textStringId = "PhantomDisplay_RecommendingTitle";
		}
		bool selfInteractive = data != 2;
		UUIText text = base.GetText(0);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textStringId, Array.Empty<object>());
		UUIButtonComponent button = base.GetButton(1);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(uiactive);
		}
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(selfInteractive);
	}

	// Token: 0x04008EBF RID: 36543
	[Nullable(2)]
	public Action ClickRecommendBtnCb;
}
