using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020012DC RID: 4828
public class DangoMonopolyBuffActiveGetPanel : UiPanelBase
{
	// Token: 0x060082D9 RID: 33497 RVA: 0x0022A214 File Offset: 0x00228414
	[NullableContext(1)]
	public UniTask Init(UUIItem item, DangoMonopolyGridData gridData)
	{
		DangoMonopolyBuffActiveGetPanel.<Init>d__3 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.item = item;
		<Init>d__.gridData = gridData;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<DangoMonopolyBuffActiveGetPanel.<Init>d__3>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x060082DA RID: 33498 RVA: 0x0022A268 File Offset: 0x00228468
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtnConfirm))
		};
	}

	// Token: 0x060082DB RID: 33499 RVA: 0x0022A327 File Offset: 0x00228527
	protected override void OnBeforeShow()
	{
		this.UpdateData();
	}

	// Token: 0x060082DC RID: 33500 RVA: 0x0022A330 File Offset: 0x00228530
	public void UpdateData()
	{
		DangoData dangoData = this.GridData.GetDangoData();
		DangoMonopolyProperty? addPropertyConfig = this.GridData.GetAddPropertyConfig();
		string key = ((dangoData != null) ? dangoData.NameKey : null) ?? "DangoName";
		string dangoSay = ((dangoData != null) ? dangoData.DangoSay : null) ?? "";
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.ShowTextNew(key);
		}
		UUIText text2 = base.GetText(5);
		if (text2 != null)
		{
			text2.ShowTextNew(((addPropertyConfig != null) ? addPropertyConfig.GetValueOrDefault().Desc : null) ?? "");
		}
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIButtonComponent button = base.GetButton(0);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(false);
		}
		this.UpdateDangoSay(dangoSay);
	}

	// Token: 0x060082DD RID: 33501 RVA: 0x0022A405 File Offset: 0x00228605
	public void SetDialogVisible(bool visible)
	{
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(visible);
	}

	// Token: 0x060082DE RID: 33502 RVA: 0x0022A419 File Offset: 0x00228619
	private void OnClickBtnConfirm()
	{
		Action onClickCallback = this.OnClickCallback;
		if (onClickCallback == null)
		{
			return;
		}
		onClickCallback();
	}

	// Token: 0x060082DF RID: 33503 RVA: 0x0022A42C File Offset: 0x0022862C
	[NullableContext(2)]
	public void UpdateDangoSay(string dangoSay)
	{
		bool flag = dangoSay != null;
		this.SetDialogVisible(flag);
		if (flag)
		{
			UUIText text = base.GetText(3);
			if (text == null)
			{
				return;
			}
			text.ShowTextNew(dangoSay);
		}
	}

	// Token: 0x04003E14 RID: 15892
	[Nullable(1)]
	public DangoMonopolyGridData GridData;

	// Token: 0x04003E15 RID: 15893
	[Nullable(2)]
	public Action OnClickCallback;

	// Token: 0x0200765E RID: 30302
	private enum EChildType
	{
		// Token: 0x04028CA5 RID: 167077
		BtnConfirm,
		// Token: 0x04028CA6 RID: 167078
		TxtName,
		// Token: 0x04028CA7 RID: 167079
		ItemDialog,
		// Token: 0x04028CA8 RID: 167080
		TxtDangoSay,
		// Token: 0x04028CA9 RID: 167081
		ItemNameRoot,
		// Token: 0x04028CAA RID: 167082
		TxtDesc
	}
}
