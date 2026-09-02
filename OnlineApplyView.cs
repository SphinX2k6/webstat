using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002340 RID: 9024
public class OnlineApplyView : UiTickViewBase
{
	// Token: 0x0601138B RID: 70539 RVA: 0x004BA011 File Offset: 0x004B8211
	[NullableContext(1)]
	public OnlineApplyView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601138C RID: 70540 RVA: 0x004BA01C File Offset: 0x004B821C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 13;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickHandleBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickCancelBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0601138D RID: 70541 RVA: 0x004BA255 File Offset: 0x004B8455
	protected override void OnStart()
	{
		this.CountDown = base.GetText(5);
		this.CountDownBar = base.GetSprite(6);
		this.RefreshView();
		this.RefreshPcItem();
		this.RefreshThirdPartyItem();
	}

	// Token: 0x0601138E RID: 70542 RVA: 0x004BA284 File Offset: 0x004B8484
	protected override void OnTick(float delta)
	{
		OnlineApplyData currentApply = ModelBase<OnlineModel>.Instance.CurrentApply;
		if (currentApply == null || currentApply.ApplyTimeLeftTime < 0.0)
		{
			if (!this.HaveClosed)
			{
				base.CloseMe(null);
				this.HaveClosed = true;
			}
			return;
		}
		this.CountDown.SetText(Singleton<TimeUtil>.Instance.GetCoolDown(currentApply.ApplyTimeLeftTime), true);
		this.CountDownBar.SetFillAmount((float)currentApply.ApplyTimeLeftTime / (float)ModelBase<OnlineModel>.Instance.ApplyCd);
	}

	// Token: 0x0601138F RID: 70543 RVA: 0x004BA301 File Offset: 0x004B8501
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshApply, new Action(this.CallServerNotifyOnlineApply));
	}

	// Token: 0x06011390 RID: 70544 RVA: 0x004BA31F File Offset: 0x004B851F
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshApply, new Action(this.CallServerNotifyOnlineApply));
	}

	// Token: 0x06011391 RID: 70545 RVA: 0x004BA340 File Offset: 0x004B8540
	public void RefreshView()
	{
		int currentApplySize = ModelBase<OnlineModel>.Instance.GetCurrentApplySize();
		UUIItem item = base.GetItem(3);
		UUIItem item2 = base.GetItem(4);
		UUIText text = base.GetText(7);
		if (currentApplySize <= 1)
		{
			item.SetUIActive(true);
			item2.SetUIActive(false);
			Singleton<LguiUtil>.Instance.SetLocalText(text, "OnlineSingleApply", Array.Empty<object>());
		}
		else
		{
			item.SetUIActive(false);
			item2.SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalText(text, "OnlineMultipleApply", new <>z__ReadOnlySingleElementList<object>(currentApplySize));
		}
		OnlineApplyData currentApply = ModelBase<OnlineModel>.Instance.CurrentApply;
		if (currentApply == null)
		{
			return;
		}
		base.GetText(1).SetText(currentApply.Name, true);
		this.CountDown.SetText(Singleton<TimeUtil>.Instance.GetCoolDown(ModelBase<OnlineModel>.Instance.CurrentApply.ApplyTimeLeftTime), true);
		this.CountDownBar.SetFillAmount((float)currentApply.ApplyTimeLeftTime / (float)ModelBase<OnlineModel>.Instance.ApplyCd);
		PlayerHeadData playerHeadData = ModelBase<PersonalModel>.Instance.GetPlayerHeadData(currentApply.HeadId, false);
		if (playerHeadData != null)
		{
			base.SetTextureByPath(playerHeadData.GetRoleHeadIconCircle(), base.GetTexture(0), null, null);
		}
		UUIButtonComponent button = base.GetButton(8);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(true);
	}

	// Token: 0x06011392 RID: 70546 RVA: 0x004BA484 File Offset: 0x004B8684
	private void OnClickHandleBtn()
	{
		if (ModelBase<OnlineModel>.Instance.GetCurrentApplySize() > 1)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.OnlineMultipleApplyView, null, null);
			base.CloseMe(null);
			return;
		}
		if (ModelBase<OnlineModel>.Instance.CurrentApply == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.MultiPlayerTeam, ELogAuthor.LJQ, "当前申请不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<UiManager>.Instance.CloseView(EUiViewName.OnlineMultipleApplyView, null);
			return;
		}
		ControllerBase<OnlineController>.Instance.AgreeJoinResultRequest(ModelBase<OnlineModel>.Instance.CurrentApply.PlayerId, true);
	}

	// Token: 0x06011393 RID: 70547 RVA: 0x004BA50C File Offset: 0x004B870C
	private void OnClickCancelBtn()
	{
		if (ModelBase<OnlineModel>.Instance.CurrentApply == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.MultiPlayerTeam, ELogAuthor.LJQ, "当前申请不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<UiManager>.Instance.CloseView(EUiViewName.OnlineMultipleApplyView, null);
			return;
		}
		ControllerBase<OnlineController>.Instance.AgreeJoinResultRequest(ModelBase<OnlineModel>.Instance.CurrentApply.PlayerId, false);
	}

	// Token: 0x06011394 RID: 70548 RVA: 0x004BA56C File Offset: 0x004B876C
	private void RefreshPcItem()
	{
		if (ControllerBase<KuroSdkController>.Instance.NeedShowThirdPartyId())
		{
			bool flag = ModelBase<OnlineModel>.Instance.CurrentApply.ThirdOnlineId != "";
			UUIItem item = base.GetItem(15);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(!flag);
			return;
		}
		else
		{
			UUIItem item2 = base.GetItem(15);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
			return;
		}
	}

	// Token: 0x06011395 RID: 70549 RVA: 0x004BA5CC File Offset: 0x004B87CC
	private void RefreshThirdPartyItem()
	{
		if (ControllerBase<KuroSdkController>.Instance.NeedShowThirdPartyId())
		{
			bool flag = ModelBase<OnlineModel>.Instance.CurrentApply.ThirdOnlineId != "";
			UUIItem item = base.GetItem(16);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			if (flag)
			{
				string thirdOnlineId = ModelBase<OnlineModel>.Instance.CurrentApply.ThirdOnlineId;
				UUIText text = base.GetText(17);
				if (text != null)
				{
					text.SetText(thirdOnlineId, true);
				}
			}
			string thirdPartyLogoTexturePath = ConfigBase<UiResourceConfig>.Instance.GetThirdPartyLogoTexturePath(ELogoSize.Medium);
			base.SetTextureByPath(thirdPartyLogoTexturePath, base.GetTexture(18), null, null);
			string thirdPartyTextColor = ConfigBase<UiResourceConfig>.Instance.GetThirdPartyTextColor(EConsoleColorSet.Set1);
			UUIText text2 = base.GetText(17);
			if (text2 == null)
			{
				return;
			}
			text2.SetColor(FColor.FromHex(thirdPartyTextColor));
			return;
		}
		else
		{
			UUIItem item2 = base.GetItem(16);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
			return;
		}
	}

	// Token: 0x06011396 RID: 70550 RVA: 0x004BA69C File Offset: 0x004B889C
	private void CallServerNotifyOnlineApply()
	{
		this.RefreshView();
	}

	// Token: 0x04008764 RID: 34660
	[Nullable(2)]
	private UUIText CountDown;

	// Token: 0x04008765 RID: 34661
	[Nullable(2)]
	private UUISprite CountDownBar;

	// Token: 0x04008766 RID: 34662
	private bool HaveClosed;

	// Token: 0x0200864E RID: 34382
	private enum EOnlineApplyView
	{
		// Token: 0x0402D6AF RID: 186031
		RoleTexture,
		// Token: 0x0402D6B0 RID: 186032
		PlayerName,
		// Token: 0x0402D6B1 RID: 186033
		HandleBtn,
		// Token: 0x0402D6B2 RID: 186034
		ApplySprite,
		// Token: 0x0402D6B3 RID: 186035
		MoreSprite,
		// Token: 0x0402D6B4 RID: 186036
		CountDown,
		// Token: 0x0402D6B5 RID: 186037
		CountDownProgressBar,
		// Token: 0x0402D6B6 RID: 186038
		MultipleApplyText,
		// Token: 0x0402D6B7 RID: 186039
		CancelBtn,
		// Token: 0x0402D6B8 RID: 186040
		TexturePc = 15,
		// Token: 0x0402D6B9 RID: 186041
		ThirdPartyItem,
		// Token: 0x0402D6BA RID: 186042
		ThirdPartyText,
		// Token: 0x0402D6BB RID: 186043
		ThirdPartyTexture
	}
}
