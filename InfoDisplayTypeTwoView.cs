using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AutoAttach;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002005 RID: 8197
[NullableContext(1)]
[Nullable(0)]
public class InfoDisplayTypeTwoView : UiTickViewBase
{
	// Token: 0x0600F7A3 RID: 63395 RVA: 0x0043D14B File Offset: 0x0043B34B
	public InfoDisplayTypeTwoView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600F7A4 RID: 63396 RVA: 0x0043D15C File Offset: 0x0043B35C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickCloseBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickRightBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickLeftBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F7A5 RID: 63397 RVA: 0x0043D352 File Offset: 0x0043B552
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<AutoAttachItem<string>>(EEventName.ClickDisplayItem, new Action<AutoAttachItem<string>>(this.OnClickItem));
	}

	// Token: 0x0600F7A6 RID: 63398 RVA: 0x0043D370 File Offset: 0x0043B570
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.ClickDisplayItem, new Action<AutoAttachItem<string>>(this.OnClickItem));
	}

	// Token: 0x0600F7A7 RID: 63399 RVA: 0x0043D38E File Offset: 0x0043B58E
	private void OnClickItem(AutoAttachItem<string> item)
	{
		this.ScrollToItem(item);
	}

	// Token: 0x0600F7A8 RID: 63400 RVA: 0x0043D398 File Offset: 0x0043B598
	protected override void OnStart()
	{
		int id = ModelBase<InfoDisplayModel>.Instance.CurrentInformationId();
		this.InitView(id);
		this.RefreshLeftRightBtnShowState(id);
		this.RefreshElement(id);
	}

	// Token: 0x0600F7A9 RID: 63401 RVA: 0x0043D3C8 File Offset: 0x0043B5C8
	private void InitView(int id)
	{
		CircleAttachView<string, InfoDisplayCircleAttachItem> circleExhibitionView = this.CircleExhibitionView;
		if (circleExhibitionView != null)
		{
			circleExhibitionView.Clear();
		}
		NoCircleAttachView<string, InfoDisplayNoCircleAttachItem> noCircleExhibitionView = this.NoCircleExhibitionView;
		if (noCircleExhibitionView != null)
		{
			noCircleExhibitionView.Clear();
		}
		this.CircleExhibitionView = null;
		this.NoCircleExhibitionView = null;
		string[] infoDisplayPictures = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayPictures(id);
		if (infoDisplayPictures == null)
		{
			return;
		}
		UUIItem item = base.GetItem(1);
		if (((item != null) ? item.GetOwner() : null) == null)
		{
			return;
		}
		if (infoDisplayPictures.Length < this.ShowItemNum)
		{
			AUIBaseActor auibaseActor = item.GetOwner() as AUIBaseActor;
			if (auibaseActor != null)
			{
				this.NoCircleExhibitionView = new NoCircleAttachView<string, InfoDisplayNoCircleAttachItem>(auibaseActor, false);
				UUIItem item2 = base.GetItem(0);
				if (((item2 != null) ? item2.GetOwner() : null) != null)
				{
					AUIBaseActor auibaseActor2 = item2.GetOwner() as AUIBaseActor;
					if (auibaseActor2 != null)
					{
						this.NoCircleExhibitionView.CreateItems(auibaseActor2, -850f, new Func<AActor, int, int, InfoDisplayNoCircleAttachItem>(this.CreateNoCircleItem), EAttachDirection.Horizontal);
					}
				}
				this.NoCircleExhibitionView.DisableDragEvent();
				this.NoCircleExhibitionView.ReloadView(infoDisplayPictures.Length, infoDisplayPictures, 0);
			}
		}
		else
		{
			AUIBaseActor auibaseActor3 = item.GetOwner() as AUIBaseActor;
			if (auibaseActor3 != null)
			{
				this.CircleExhibitionView = new CircleAttachView<string, InfoDisplayCircleAttachItem>(auibaseActor3, false);
				UUIItem item3 = base.GetItem(0);
				if (((item3 != null) ? item3.GetOwner() : null) != null)
				{
					AUIBaseActor auibaseActor4 = item3.GetOwner() as AUIBaseActor;
					if (auibaseActor4 != null)
					{
						this.CircleExhibitionView.CreateItems(auibaseActor4, -850f, new Func<AActor, int, int, InfoDisplayCircleAttachItem>(this.CreateCircleItem), EAttachDirection.Horizontal);
					}
				}
				this.CircleExhibitionView.DisableDragEvent();
				this.CircleExhibitionView.ReloadView(infoDisplayPictures.Length, infoDisplayPictures, 0);
			}
		}
		this.CurrentDataLength = infoDisplayPictures.Length;
		UUIItem item4 = base.GetItem(0);
		if (item4 != null)
		{
			item4.SetUIActive(false);
		}
		this.RefreshIndexText();
	}

	// Token: 0x0600F7AA RID: 63402 RVA: 0x0043D568 File Offset: 0x0043B768
	private void RefreshLeftRightBtnShowState(int id)
	{
		string[] infoDisplayPictures = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayPictures(id);
		if (infoDisplayPictures == null)
		{
			return;
		}
		bool uiactive = infoDisplayPictures.Length > 1;
		UUIItem item = base.GetItem(8);
		UUIItem item2 = base.GetItem(9);
		if (item != null)
		{
			item.SetUIActive(uiactive);
		}
		if (item2 != null)
		{
			item2.SetUIActive(uiactive);
		}
	}

	// Token: 0x0600F7AB RID: 63403 RVA: 0x0043D5B2 File Offset: 0x0043B7B2
	private InfoDisplayCircleAttachItem CreateCircleItem(AActor actor, int index, int showNum)
	{
		return new InfoDisplayCircleAttachItem(actor);
	}

	// Token: 0x0600F7AC RID: 63404 RVA: 0x0043D5BA File Offset: 0x0043B7BA
	private InfoDisplayNoCircleAttachItem CreateNoCircleItem(AActor actor, int index, int showNum)
	{
		return new InfoDisplayNoCircleAttachItem(actor);
	}

	// Token: 0x0600F7AD RID: 63405 RVA: 0x0043D5C2 File Offset: 0x0043B7C2
	private void RefreshElement(int id)
	{
		this.RefreshShowText(id);
		this.RefreshIndexText();
	}

	// Token: 0x0600F7AE RID: 63406 RVA: 0x0043D5D4 File Offset: 0x0043B7D4
	private void RefreshShowText(int id)
	{
		string infoDisplayTitle = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayTitle(id);
		UUIText text = base.GetText(6);
		if (text != null)
		{
			text.SetText(infoDisplayTitle, true);
		}
		string infoDisplayDesc = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayDesc(id);
		UUIText text2 = base.GetText(5);
		if (text2 != null)
		{
			text2.SetText(infoDisplayDesc, true);
		}
	}

	// Token: 0x0600F7AF RID: 63407 RVA: 0x0043D61F File Offset: 0x0043B81F
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600F7B0 RID: 63408 RVA: 0x0043D628 File Offset: 0x0043B828
	private void OnClickRightBtn()
	{
		this.AttachToItem(1);
	}

	// Token: 0x0600F7B1 RID: 63409 RVA: 0x0043D631 File Offset: 0x0043B831
	private void OnClickLeftBtn()
	{
		this.AttachToItem(-1);
	}

	// Token: 0x0600F7B2 RID: 63410 RVA: 0x0043D63A File Offset: 0x0043B83A
	private void AttachToItem(int direction)
	{
		if (this.NoCircleExhibitionView != null)
		{
			this.NoCircleExhibitionView.AttachToNextItem(direction);
			return;
		}
		if (this.CircleExhibitionView != null)
		{
			this.CircleExhibitionView.AttachToNextItem(direction);
		}
	}

	// Token: 0x0600F7B3 RID: 63411 RVA: 0x0043D665 File Offset: 0x0043B865
	private void ScrollToItem(AutoAttachItem<string> item)
	{
		if (this.NoCircleExhibitionView != null)
		{
			this.NoCircleExhibitionView.ScrollToItem((InfoDisplayNoCircleAttachItem)item, false);
		}
		else if (this.CircleExhibitionView != null)
		{
			this.CircleExhibitionView.ScrollToItem((InfoDisplayCircleAttachItem)item, false);
		}
		this.RefreshIndexText();
	}

	// Token: 0x0600F7B4 RID: 63412 RVA: 0x0043D6A4 File Offset: 0x0043B8A4
	private void RefreshIndexText()
	{
		int num = 0;
		if (this.NoCircleExhibitionView != null)
		{
			num = this.NoCircleExhibitionView.GetCurrentSelectIndex();
		}
		else if (this.CircleExhibitionView != null)
		{
			num = this.CircleExhibitionView.GetCurrentSelectIndex();
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(num + 1);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.CurrentDataLength);
		string newText = defaultInterpolatedStringHandler.ToStringAndClear();
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.SetText(newText, true);
		}
	}

	// Token: 0x0600F7B5 RID: 63413 RVA: 0x0043D724 File Offset: 0x0043B924
	protected override void OnBeforeDestroy()
	{
		int displayId = ModelBase<InfoDisplayModel>.Instance.CurrentInformationId();
		ControllerBase<InfoDisplayController>.Instance.RequestReadDisplayInfo(displayId);
		CircleAttachView<string, InfoDisplayCircleAttachItem> circleExhibitionView = this.CircleExhibitionView;
		if (circleExhibitionView != null)
		{
			circleExhibitionView.Clear();
		}
		NoCircleAttachView<string, InfoDisplayNoCircleAttachItem> noCircleExhibitionView = this.NoCircleExhibitionView;
		if (noCircleExhibitionView == null)
		{
			return;
		}
		noCircleExhibitionView.Clear();
	}

	// Token: 0x0600F7B6 RID: 63414 RVA: 0x0043D768 File Offset: 0x0043B968
	protected override UniTask OnBeforeHideAsync()
	{
		InfoDisplayTypeTwoView.<OnBeforeHideAsync>d__25 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<InfoDisplayTypeTwoView.<OnBeforeHideAsync>d__25>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0400778E RID: 30606
	private const int PICTURE_DISTANCE = -850;

	// Token: 0x0400778F RID: 30607
	private int CurrentDataLength;

	// Token: 0x04007790 RID: 30608
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private CircleAttachView<string, InfoDisplayCircleAttachItem> CircleExhibitionView;

	// Token: 0x04007791 RID: 30609
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private NoCircleAttachView<string, InfoDisplayNoCircleAttachItem> NoCircleExhibitionView;

	// Token: 0x04007792 RID: 30610
	private readonly int ShowItemNum = 3;

	// Token: 0x0200838C RID: 33676
	[NullableContext(0)]
	private class EInfoDisplayTypeTwoComponents
	{
		// Token: 0x0402C9CE RID: 182734
		public const int InformationBtnItem = 0;

		// Token: 0x0402C9CF RID: 182735
		public const int Viewport = 1;

		// Token: 0x0402C9D0 RID: 182736
		public const int IndexText = 2;

		// Token: 0x0402C9D1 RID: 182737
		public const int RightBtn = 3;

		// Token: 0x0402C9D2 RID: 182738
		public const int LeftBtn = 4;

		// Token: 0x0402C9D3 RID: 182739
		public const int Desc = 5;

		// Token: 0x0402C9D4 RID: 182740
		public const int Name = 6;

		// Token: 0x0402C9D5 RID: 182741
		public const int BackBtn = 7;

		// Token: 0x0402C9D6 RID: 182742
		public const int RightBtnItem = 8;

		// Token: 0x0402C9D7 RID: 182743
		public const int LeftBtnItem = 9;
	}
}
