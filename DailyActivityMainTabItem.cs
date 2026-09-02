using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001A9F RID: 6815
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class DailyActivityMainTabItem : GridProxyAbstract<DailyActivityDefine.IDailyActivityMainTabData>
{
	// Token: 0x0600C340 RID: 49984 RVA: 0x003371AC File Offset: 0x003353AC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
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

	// Token: 0x0600C341 RID: 49985 RVA: 0x003372B8 File Offset: 0x003354B8
	public override void Refresh(DailyActivityDefine.IDailyActivityMainTabData data, bool isSelected, int gridIndex)
	{
		this.TabType = data.TabType;
		ActivityTab? activityTabByType = ConfigBase<WeeklyChallengeConfig>.Instance.GetActivityTabByType((int)data.TabType);
		if (activityTabByType != null)
		{
			base.GetText(2).ShowTextNew(activityTabByType.Value.Tag);
		}
		this.SetToggleState(isSelected);
		base.GetItem(3).SetUIActive(data.IsFinished);
		this.RebindRedDot(data.TabType);
	}

	// Token: 0x0600C342 RID: 49986 RVA: 0x0033732C File Offset: 0x0033552C
	private void RebindRedDot(DailyActivityDefine.EDailyActivityMainTab tab)
	{
		ERedDotName eredDotName = (tab == DailyActivityDefine.EDailyActivityMainTab.Daily) ? ERedDotName.AdventureDailyActivityTabDaily : ERedDotName.AdventureDailyActivityTabWeekly;
		ERedDotName? boundRedDotName = this.BoundRedDotName;
		ERedDotName eredDotName2 = eredDotName;
		if (boundRedDotName.GetValueOrDefault() == eredDotName2 & boundRedDotName != null)
		{
			return;
		}
		this.UnbindRedDot();
		ControllerBase<RedDotController>.Instance.BindRedDot(eredDotName, base.GetItem(4), null, 0);
		this.BoundRedDotName = new ERedDotName?(eredDotName);
	}

	// Token: 0x0600C343 RID: 49987 RVA: 0x00337388 File Offset: 0x00335588
	private void UnbindRedDot()
	{
		if (this.BoundRedDotName == null)
		{
			return;
		}
		ControllerBase<RedDotController>.Instance.UnBindRedDot(this.BoundRedDotName.Value);
		this.BoundRedDotName = null;
	}

	// Token: 0x0600C344 RID: 49988 RVA: 0x003373B9 File Offset: 0x003355B9
	protected override void OnBeforeDestroy()
	{
		this.UnbindRedDot();
	}

	// Token: 0x0600C345 RID: 49989 RVA: 0x003373C1 File Offset: 0x003355C1
	public override object GetKey(DailyActivityDefine.IDailyActivityMainTabData data, int displayIndex)
	{
		return data.TabType;
	}

	// Token: 0x0600C346 RID: 49990 RVA: 0x003373CE File Offset: 0x003355CE
	public override void OnSelected(bool fireEvent)
	{
		this.SetToggleState(true);
	}

	// Token: 0x0600C347 RID: 49991 RVA: 0x003373D7 File Offset: 0x003355D7
	public override void OnDeselected(bool fireEvent)
	{
		this.SetToggleState(false);
	}

	// Token: 0x0600C348 RID: 49992 RVA: 0x003373E0 File Offset: 0x003355E0
	private void SetToggleState(bool isChecked)
	{
		EToggleState state = isChecked ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(0).SetToggleState(state, false, false, false);
	}

	// Token: 0x0600C349 RID: 49993 RVA: 0x00337406 File Offset: 0x00335606
	private void OnClickToggle(EToggleState state)
	{
		if (state != EToggleState.ETT_Checked)
		{
			return;
		}
		Action<DailyActivityDefine.EDailyActivityMainTab> onToggleCallBack = this.OnToggleCallBack;
		if (onToggleCallBack == null)
		{
			return;
		}
		onToggleCallBack(this.TabType);
	}

	// Token: 0x04005D84 RID: 23940
	private DailyActivityDefine.EDailyActivityMainTab TabType = DailyActivityDefine.EDailyActivityMainTab.Daily;

	// Token: 0x04005D85 RID: 23941
	private ERedDotName? BoundRedDotName;

	// Token: 0x04005D86 RID: 23942
	[Nullable(2)]
	public Action<DailyActivityDefine.EDailyActivityMainTab> OnToggleCallBack;

	// Token: 0x02007D61 RID: 32097
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402AB95 RID: 174997
		Toggle,
		// Token: 0x0402AB96 RID: 174998
		IconSprite,
		// Token: 0x0402AB97 RID: 174999
		NameText,
		// Token: 0x0402AB98 RID: 175000
		FinishItem,
		// Token: 0x0402AB99 RID: 175001
		RedDot
	}
}
