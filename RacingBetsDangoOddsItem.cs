using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200271A RID: 10010
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RacingBetsDangoOddsItem : GridProxyAbstract<IRacingBetsDangoActorData>
{
	// Token: 0x06013BEC RID: 80876 RVA: 0x0057ED34 File Offset: 0x0057CF34
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x06013BED RID: 80877 RVA: 0x0057EDC7 File Offset: 0x0057CFC7
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.CanExecuteChange.Bind(new Func<bool>(this.CanToggleExecuteChange));
	}

	// Token: 0x06013BEE RID: 80878 RVA: 0x0057EDEB File Offset: 0x0057CFEB
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRacingBetsDangoOddsUpdate, new Action(this.OnRacingBetsDangoOddsUpdate));
	}

	// Token: 0x06013BEF RID: 80879 RVA: 0x0057EE0C File Offset: 0x0057D00C
	public override void Refresh(IRacingBetsDangoActorData data, bool isSelected, int gridIndex)
	{
		this.DangoOddsData = data;
		DangoData dangoData = Singleton<DangoManager>.Instance.GetDangoData(this.DangoOddsData.DangoId);
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.SetText((this.DangoOddsData.Odds / 100).ToString(), true);
		}
		base.SetTextureShowUntilLoaded(dangoData.Icon, base.GetTexture(2), null);
		this.RefreshSelect(false);
	}

	// Token: 0x06013BF0 RID: 80880 RVA: 0x0057EE7A File Offset: 0x0057D07A
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRacingBetsDangoOddsUpdate, new Action(this.OnRacingBetsDangoOddsUpdate));
	}

	// Token: 0x06013BF1 RID: 80881 RVA: 0x0057EE98 File Offset: 0x0057D098
	public void RefreshOddsDango(int dangoId)
	{
		UUIItem item = base.GetItem(3);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(dangoId == this.DangoOddsData.DangoId);
	}

	// Token: 0x06013BF2 RID: 80882 RVA: 0x0057EEB9 File Offset: 0x0057D0B9
	public override void OnSelected(bool fireEvent)
	{
		this.RefreshSelect(true);
	}

	// Token: 0x06013BF3 RID: 80883 RVA: 0x0057EEC2 File Offset: 0x0057D0C2
	public override void OnDeselected(bool fireEvent)
	{
		this.RefreshSelect(false);
	}

	// Token: 0x06013BF4 RID: 80884 RVA: 0x0057EECB File Offset: 0x0057D0CB
	private void RefreshSelect(bool isSelected)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06013BF5 RID: 80885 RVA: 0x0057EEE8 File Offset: 0x0057D0E8
	public void BindClickGearItemCallBack(Action<IRacingBetsDangoActorData> clickDangoOddsItemCallBack)
	{
		this.ClickDangoOddsItemCallBack = clickDangoOddsItemCallBack;
	}

	// Token: 0x06013BF6 RID: 80886 RVA: 0x0057EEF1 File Offset: 0x0057D0F1
	private void OnClickToggle(EToggleState toggleState)
	{
		Action<IRacingBetsDangoActorData> clickDangoOddsItemCallBack = this.ClickDangoOddsItemCallBack;
		if (clickDangoOddsItemCallBack == null)
		{
			return;
		}
		clickDangoOddsItemCallBack(this.DangoOddsData);
	}

	// Token: 0x06013BF7 RID: 80887 RVA: 0x0057EF09 File Offset: 0x0057D109
	private bool CanToggleExecuteChange()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		return extendToggle == null || extendToggle.GetToggleState() != EToggleState.ETT_Checked;
	}

	// Token: 0x06013BF8 RID: 80888 RVA: 0x0057EF24 File Offset: 0x0057D124
	private void OnRacingBetsDangoOddsUpdate()
	{
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText((this.DangoOddsData.Odds / 100).ToString(), true);
	}

	// Token: 0x040099CC RID: 39372
	private IRacingBetsDangoActorData DangoOddsData;

	// Token: 0x040099CD RID: 39373
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<IRacingBetsDangoActorData> ClickDangoOddsItemCallBack;

	// Token: 0x02008ABA RID: 35514
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402EC6B RID: 191595
		Toggle,
		// Token: 0x0402EC6C RID: 191596
		OddsText,
		// Token: 0x0402EC6D RID: 191597
		DangoIcon,
		// Token: 0x0402EC6E RID: 191598
		OddsDangoItem
	}
}
