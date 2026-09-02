using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002349 RID: 9033
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class OnlineMultipleApplyItem : GridProxyAbstract<OnlineApplyData>
{
	// Token: 0x060113FD RID: 70653 RVA: 0x004BD954 File Offset: 0x004BBB54
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickAgreeBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickRefuseBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060113FE RID: 70654 RVA: 0x004BDAA1 File Offset: 0x004BBCA1
	protected override void OnStart()
	{
		this.CountDownBar = base.GetSprite(3);
	}

	// Token: 0x060113FF RID: 70655 RVA: 0x004BDAB0 File Offset: 0x004BBCB0
	[NullableContext(1)]
	public override void Refresh(OnlineApplyData data, bool isSelected, int gridIndex)
	{
		this.OnlineApplyData = data;
		PlayerHeadData playerHeadData = ModelBase<PersonalModel>.Instance.GetPlayerHeadData(data.HeadId, false);
		if (playerHeadData != null)
		{
			base.SetTextureByPath(playerHeadData.GetRoleHeadIconCircle(), base.GetTexture(1), null, null);
		}
		base.GetText(0).SetText(data.Name, true);
		base.GetText(2).SetText(data.Level.ToString(), true);
	}

	// Token: 0x06011400 RID: 70656 RVA: 0x004BDB24 File Offset: 0x004BBD24
	public void UpdateCountDownProgressBar()
	{
		if (this.OnlineApplyData == null)
		{
			return;
		}
		this.CountDownBar.SetFillAmount((float)this.OnlineApplyData.ApplyTimeLeftTime / (float)ModelBase<OnlineModel>.Instance.ApplyCd);
		if (this.OnlineApplyData.ApplyTimeLeftTime <= 0.0 && ModelBase<OnlineModel>.Instance.GetCurrentApplyListById(this.OnlineApplyData.PlayerId) != null)
		{
			ModelBase<OnlineModel>.Instance.DeleteCurrentApplyListById(this.OnlineApplyData.PlayerId);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshApply);
		}
	}

	// Token: 0x06011401 RID: 70657 RVA: 0x004BDBAF File Offset: 0x004BBDAF
	private void OnClickAgreeBtn()
	{
		ControllerBase<OnlineController>.Instance.AgreeJoinResultRequest(this.OnlineApplyData.PlayerId, true);
	}

	// Token: 0x06011402 RID: 70658 RVA: 0x004BDBC8 File Offset: 0x004BBDC8
	private void OnClickRefuseBtn()
	{
		ControllerBase<OnlineController>.Instance.AgreeJoinResultRequest(this.OnlineApplyData.PlayerId, false);
		if (ModelBase<OnlineModel>.Instance.GetCurrentApplyListById(this.OnlineApplyData.PlayerId) != null)
		{
			ModelBase<OnlineModel>.Instance.DeleteCurrentApplyListById(this.OnlineApplyData.PlayerId);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshApply);
		}
	}

	// Token: 0x0400878A RID: 34698
	private OnlineApplyData OnlineApplyData;

	// Token: 0x0400878B RID: 34699
	private UUISprite CountDownBar;

	// Token: 0x02008661 RID: 34401
	[NullableContext(0)]
	private enum EOnlineMultipleApplyItem
	{
		// Token: 0x0402D73E RID: 186174
		PlayerName,
		// Token: 0x0402D73F RID: 186175
		RoleHead,
		// Token: 0x0402D740 RID: 186176
		Level,
		// Token: 0x0402D741 RID: 186177
		CountDownProgressBar,
		// Token: 0x0402D742 RID: 186178
		AgreeBtn,
		// Token: 0x0402D743 RID: 186179
		RefuseBtn
	}
}
