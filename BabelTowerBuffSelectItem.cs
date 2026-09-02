using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020011D2 RID: 4562
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class BabelTowerBuffSelectItem : GridProxyAbstract<IBabelTowerBuffInfo>
{
	// Token: 0x06007863 RID: 30819 RVA: 0x001F81F4 File Offset: 0x001F63F4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007864 RID: 30820 RVA: 0x001F82FD File Offset: 0x001F64FD
	protected override void OnStart()
	{
		base.GetExtendToggle(0).CanExecuteChange.Bind(() => base.GetExtendToggle(0).GetToggleState() == EToggleState.ETT_Checked || this.CanClickCallBack == null || this.CanClickCallBack(this.BuffId));
		base.GetExtendToggle(0).OnUndeterminedClicked.Add(new Action(this.OnUndeterminedClicked));
	}

	// Token: 0x06007865 RID: 30821 RVA: 0x001F833C File Offset: 0x001F653C
	[NullableContext(1)]
	public override void Refresh(IBabelTowerBuffInfo data, bool isSelected, int gridIndex)
	{
		this.BuffId = data.Id;
		this.LevelId = data.LevelId.GetValueOrDefault();
		BabelTowerBuff? config = ConfigBabelTowerBuffById.GetConfig(this.BuffId, true);
		if (config == null)
		{
			return;
		}
		BabelTowerBuff value = config.Value;
		UUIText text = base.GetText(1);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, value.NameText, Array.Empty<object>());
		base.SetTextureByPath(value.Texture, base.GetTexture(3), null, null);
		base.GetItem(4).SetUIActive(data.IsRecommend);
		this.RefreshState(data.State);
	}

	// Token: 0x06007866 RID: 30822 RVA: 0x001F83E4 File Offset: 0x001F65E4
	public void RefreshState(EBabelTowerBuffState state)
	{
		UUIText text = base.GetText(1);
		UUIText text2 = base.GetText(2);
		text2.SetUIActive(state > EBabelTowerBuffState.Normal);
		UUIItem uuiitem = text2;
		bool bUseChangeColor = state > EBabelTowerBuffState.Normal;
		FColor? fcolor = new FColor?(text2.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		UUIItem uuiitem2 = text;
		bool bUseChangeColor2 = state > EBabelTowerBuffState.Normal;
		fcolor = new FColor?(text.changeColor);
		uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
		if (state == EBabelTowerBuffState.Use)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, "BabelTowerBuffUse", Array.Empty<object>());
			return;
		}
		if (state == EBabelTowerBuffState.Lock)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, "BabelTowerBuffLock", Array.Empty<object>());
		}
	}

	// Token: 0x06007867 RID: 30823 RVA: 0x001F846E File Offset: 0x001F666E
	private void OnClickToggle(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			Action<int> onClickToggleCallBack = this.OnClickToggleCallBack;
			if (onClickToggleCallBack == null)
			{
				return;
			}
			onClickToggleCallBack(this.BuffId);
			return;
		}
		else
		{
			Action<int> onCancelClickToggleCallBack = this.OnCancelClickToggleCallBack;
			if (onCancelClickToggleCallBack == null)
			{
				return;
			}
			onCancelClickToggleCallBack(this.BuffId);
			return;
		}
	}

	// Token: 0x06007868 RID: 30824 RVA: 0x001F84A1 File Offset: 0x001F66A1
	public void SetToggleState(EToggleState state)
	{
		base.GetExtendToggle(0).SetToggleStateForce(state, false, false, false);
	}

	// Token: 0x06007869 RID: 30825 RVA: 0x001F84B4 File Offset: 0x001F66B4
	private void OnUndeterminedClicked()
	{
		BabelTowerItemInfoViewInfo param = new BabelTowerItemInfoViewInfo
		{
			IsDeTerm = false,
			ConfigId = this.BuffId,
			ShowWays = true
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerItemInfoView, param, null);
	}

	// Token: 0x04003A24 RID: 14884
	public int BuffId;

	// Token: 0x04003A25 RID: 14885
	public int LevelId;

	// Token: 0x04003A26 RID: 14886
	public Action<int> OnClickToggleCallBack;

	// Token: 0x04003A27 RID: 14887
	public Action<int> OnCancelClickToggleCallBack;

	// Token: 0x04003A28 RID: 14888
	public Func<int, bool> CanClickCallBack;

	// Token: 0x0200752B RID: 29995
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402871D RID: 165661
		public const int Toggle = 0;

		// Token: 0x0402871E RID: 165662
		public const int NameText = 1;

		// Token: 0x0402871F RID: 165663
		public const int DesText = 2;

		// Token: 0x04028720 RID: 165664
		public const int IconTexture = 3;

		// Token: 0x04028721 RID: 165665
		public const int RecommendItem = 4;
	}
}
