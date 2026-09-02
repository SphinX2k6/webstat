using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AutoAttach;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200241E RID: 9246
[NullableContext(1)]
[Nullable(0)]
public class PersonalBirthView : UiTickViewBase
{
	// Token: 0x06011E1B RID: 73243 RVA: 0x004EB137 File Offset: 0x004E9337
	public PersonalBirthView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06011E1C RID: 73244 RVA: 0x004EB170 File Offset: 0x004E9370
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(12, typeof(UUIText)),
			new ValueTuple<int, Type>(13, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(14, typeof(UUIInteractionGroup))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnLeftButtonClicked)),
			new ValueTuple<int, Delegate>(5, new Action(this.OnRightButtonClicked))
		};
	}

	// Token: 0x06011E1D RID: 73245 RVA: 0x004EB313 File Offset: 0x004E9513
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnBirthChange, new Action(this.OnBirthChange));
	}

	// Token: 0x06011E1E RID: 73246 RVA: 0x004EB331 File Offset: 0x004E9531
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnBirthChange, new Action(this.OnBirthChange));
	}

	// Token: 0x06011E1F RID: 73247 RVA: 0x004EB350 File Offset: 0x004E9550
	private void OnBirthChange()
	{
		string textById = ConfigBase<TextConfig>.Instance.GetTextById("SetBirthSuccess");
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(textById);
		base.CloseMe(null);
	}

	// Token: 0x06011E20 RID: 73248 RVA: 0x004EB37F File Offset: 0x004E957F
	protected void OnLeftButtonClicked()
	{
		base.CloseMe(null);
	}

	// Token: 0x06011E21 RID: 73249 RVA: 0x004EB388 File Offset: 0x004E9588
	protected void OnRightButtonClicked()
	{
		if (this.IsSetBirth())
		{
			base.CloseMe(null);
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.SetBirthDay);
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			double timeStampSecond = Singleton<TimeUtil>.Instance.GetServerTimeStamp() / (double)Singleton<TimeUtil>.Instance.InverseMillisecond;
			DateTime dataFromTimeStamp = Singleton<TimeUtil>.Instance.GetDataFromTimeStamp(timeStampSecond);
			ControllerBase<PersonalController>.Instance.SendBirthdayInitRequest(dataFromTimeStamp.Year * 10000 + this.MonthNumber.Value * 100 + this.DayNumber.Value);
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06011E22 RID: 73250 RVA: 0x004EB3D1 File Offset: 0x004E95D1
	protected void OnMonthButtonClick()
	{
		if (this.IsSetBirth())
		{
			return;
		}
		this.RefreshLeftCircleExhibitionView();
		this.IsSelectMonthToggle = true;
	}

	// Token: 0x06011E23 RID: 73251 RVA: 0x004EB3E9 File Offset: 0x004E95E9
	protected void OnDayButtonClick()
	{
		if (this.IsSetBirth())
		{
			return;
		}
		if (!this.IsSelectMonthToggle)
		{
			return;
		}
		this.RefreshRightCircleExhibitionView();
		this.IsSelectDayToggle = true;
	}

	// Token: 0x06011E24 RID: 73252 RVA: 0x004EB40C File Offset: 0x004E960C
	protected bool IsSetBirth()
	{
		int birthday = ModelBase<PersonalModel>.Instance.GetBirthday();
		return ModelBase<BirthdayModel>.Instance.GetBirthdayIsReset() && birthday != 0;
	}

	// Token: 0x06011E25 RID: 73253 RVA: 0x004EB436 File Offset: 0x004E9636
	protected void CloseClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x06011E26 RID: 73254 RVA: 0x004EB440 File Offset: 0x004E9640
	protected override void OnStart()
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(8), "AcquireCancel", Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "PrefabTextItem_1541715829_Text", Array.Empty<object>());
		UUIText text = base.GetText(6);
		text.SetUIActive(true);
		UUIText text2 = base.GetText(7);
		text2.SetUIActive(true);
		if (this.IsSetBirth())
		{
			int birthday = ModelBase<PersonalModel>.Instance.GetBirthday();
			int date = birthday / 100;
			int date2 = birthday % 100;
			text.SetText(ConfigBase<PersonalConfig>.Instance.GetBirthLocalText(date, EBirthDateType.MONTH), true);
			text2.SetText(ConfigBase<PersonalConfig>.Instance.GetBirthLocalText(date2, EBirthDateType.DAY), true);
			base.GetButton(5).SetSelfInteractive(true);
			base.GetInteractionGroup(14).SetInteractable(true);
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(12), "BirthIsSetCanNotChange", Array.Empty<object>());
		}
		else
		{
			this.MonthNumber = new int?(1);
			this.DayNumber = new int?(1);
			text.SetText(this.MonthNumber.ToString(), true);
			text2.SetText(this.DayNumber.ToString(), true);
			base.GetButton(5).SetSelfInteractive(false);
			base.GetInteractionGroup(14).SetInteractable(false);
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(12), "SetBirthCanNotChange", Array.Empty<object>());
			this.OnMonthButtonClick();
			this.OnDayButtonClick();
		}
		EToggleState state = ModelBase<PersonalModel>.Instance.GetBirthdayDisplay() ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		UUIExtendToggle extendToggle = base.GetExtendToggle(13);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(state, false, false, false);
	}

	// Token: 0x06011E27 RID: 73255 RVA: 0x004EB5D4 File Offset: 0x004E97D4
	private void RefreshLeftCircleExhibitionView()
	{
		UUIItem item = base.GetItem(0);
		UUIItem item2 = base.GetItem(1);
		this.LeftCircleExhibitionView = new CircleAttachView<int, PersonalBirthAttachItem>(item.GetOwner(), true);
		this.LeftCircleExhibitionView.CreateItems(item2.GetOwner(), 2f, new Func<AActor, int, int, PersonalBirthAttachItem>(this.OnCreateLeftCircleItem), EAttachDirection.Vertical);
		List<int> list = new List<int>();
		for (int i = 1; i <= 12; i++)
		{
			list.Add(i);
		}
		this.LeftCircleExhibitionView.ReloadView(list.Count, list.ToArray(), 0);
		item2.SetUIActive(false);
	}

	// Token: 0x06011E28 RID: 73256 RVA: 0x004EB65F File Offset: 0x004E985F
	private PersonalBirthAttachItem OnCreateLeftCircleItem(AActor actor, int index, int showNum)
	{
		PersonalBirthAttachItem personalBirthAttachItem = new PersonalBirthAttachItem(actor);
		personalBirthAttachItem.SetDateType(EBirthDateType.MONTH);
		personalBirthAttachItem.BindOnSelected(new Action<int>(this.OnSelectedLeftNum));
		return personalBirthAttachItem;
	}

	// Token: 0x06011E29 RID: 73257 RVA: 0x004EB680 File Offset: 0x004E9880
	private void OnSelectedLeftNum(int num)
	{
		this.MonthNumber = new int?(num);
		base.GetText(6).SetText(num.ToString(), true);
		if (this.IsSelectDayToggle)
		{
			if (this.DayNumber != null)
			{
				base.GetButton(5).SetSelfInteractive(true);
				base.GetInteractionGroup(14).SetInteractable(true);
				this.DayNumber = new int?(1);
				base.GetText(7).SetText(this.DayNumber.ToString(), true);
			}
			this.RefreshRightCircleExhibitionView();
		}
	}

	// Token: 0x06011E2A RID: 73258 RVA: 0x004EB710 File Offset: 0x004E9910
	private void RefreshRightCircleExhibitionView()
	{
		UUIItem item = base.GetItem(2);
		UUIItem item2 = base.GetItem(3);
		if (this.RightCircleExhibitionView == null)
		{
			this.RightCircleExhibitionView = new CircleAttachView<int, PersonalBirthAttachItem>(item.GetOwner(), true);
			this.RightCircleExhibitionView.CreateItems(item2.GetOwner(), 2f, new Func<AActor, int, int, PersonalBirthAttachItem>(this.OnCreateRightCircleItem), EAttachDirection.Vertical);
		}
		int days = this.GetDays(this.MonthNumber.Value);
		List<int> list = new List<int>();
		for (int i = 1; i <= days; i++)
		{
			list.Add(i);
		}
		this.RightCircleExhibitionView.ReloadView(list.Count, list.ToArray(), 0);
		item2.SetUIActive(false);
	}

	// Token: 0x06011E2B RID: 73259 RVA: 0x004EB7B9 File Offset: 0x004E99B9
	private PersonalBirthAttachItem OnCreateRightCircleItem(AActor actor, int index, int showNum)
	{
		PersonalBirthAttachItem personalBirthAttachItem = new PersonalBirthAttachItem(actor);
		personalBirthAttachItem.SetDateType(EBirthDateType.DAY);
		personalBirthAttachItem.BindOnSelected(new Action<int>(this.OnSelectedRightNum));
		return personalBirthAttachItem;
	}

	// Token: 0x06011E2C RID: 73260 RVA: 0x004EB7DC File Offset: 0x004E99DC
	private void OnSelectedRightNum(int num)
	{
		this.DayNumber = new int?(num);
		if (this.MonthNumber != null)
		{
			base.GetButton(5).SetSelfInteractive(true);
			base.GetInteractionGroup(14).SetInteractable(true);
		}
		base.GetText(7).SetText(num.ToString(), true);
	}

	// Token: 0x06011E2D RID: 73261 RVA: 0x004EB834 File Offset: 0x004E9A34
	private int GetDays(int month)
	{
		if (month == 2)
		{
			return this.FebruaryDays;
		}
		int num = this.BigMonth.Length;
		for (int i = 0; i < num; i++)
		{
			if (this.BigMonth[i] == month)
			{
				return this.BigMonthDays;
			}
		}
		return this.SmallMonthDays;
	}

	// Token: 0x06011E2E RID: 73262 RVA: 0x004EB879 File Offset: 0x004E9A79
	protected override void OnAfterShow()
	{
	}

	// Token: 0x06011E2F RID: 73263 RVA: 0x004EB87C File Offset: 0x004E9A7C
	protected override void OnBeforeHide()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(13);
		EToggleState? etoggleState = (extendToggle != null) ? new EToggleState?(extendToggle.GetToggleState()) : null;
		EToggleState etoggleState2 = EToggleState.ETT_Checked;
		bool flag = (etoggleState.GetValueOrDefault() == etoggleState2 & etoggleState != null) > false;
		bool birthdayDisplay = ModelBase<PersonalModel>.Instance.GetBirthdayDisplay();
		if (flag != birthdayDisplay)
		{
			ControllerBase<PersonalController>.Instance.SendBirthdayShowSetRequest(flag);
		}
	}

	// Token: 0x06011E30 RID: 73264 RVA: 0x004EB8DD File Offset: 0x004E9ADD
	protected override void OnBeforeDestroy()
	{
		CircleAttachView<int, PersonalBirthAttachItem> leftCircleExhibitionView = this.LeftCircleExhibitionView;
		if (leftCircleExhibitionView != null)
		{
			leftCircleExhibitionView.Clear();
		}
		CircleAttachView<int, PersonalBirthAttachItem> rightCircleExhibitionView = this.RightCircleExhibitionView;
		if (rightCircleExhibitionView == null)
		{
			return;
		}
		rightCircleExhibitionView.Clear();
	}

	// Token: 0x04008BFB RID: 35835
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private CircleAttachView<int, PersonalBirthAttachItem> LeftCircleExhibitionView;

	// Token: 0x04008BFC RID: 35836
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private CircleAttachView<int, PersonalBirthAttachItem> RightCircleExhibitionView;

	// Token: 0x04008BFD RID: 35837
	private int? MonthNumber;

	// Token: 0x04008BFE RID: 35838
	private int? DayNumber;

	// Token: 0x04008BFF RID: 35839
	private readonly int[] BigMonth = new int[]
	{
		1,
		3,
		5,
		7,
		8,
		10,
		12
	};

	// Token: 0x04008C00 RID: 35840
	private readonly int BigMonthDays = 31;

	// Token: 0x04008C01 RID: 35841
	private readonly int SmallMonthDays = 30;

	// Token: 0x04008C02 RID: 35842
	private readonly int FebruaryDays = 29;

	// Token: 0x04008C03 RID: 35843
	private bool IsSelectMonthToggle;

	// Token: 0x04008C04 RID: 35844
	private bool IsSelectDayToggle;

	// Token: 0x04008C05 RID: 35845
	private const int SHOW_GAP = 2;

	// Token: 0x04008C06 RID: 35846
	private const int MONTH_COUNT = 12;
}
