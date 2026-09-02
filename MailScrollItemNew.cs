using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002231 RID: 8753
[NullableContext(1)]
[Nullable(0)]
public class MailScrollItemNew : UiPanelBase, IDynamicScrollItem<MailData>
{
	// Token: 0x06010874 RID: 67700 RVA: 0x00484E00 File Offset: 0x00483000
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
	}

	// Token: 0x06010875 RID: 67701 RVA: 0x00484F5C File Offset: 0x0048315C
	public void Update(MailData data, int index)
	{
		this.Index = index;
		this.Data = data;
		if (this.SelectTrigger)
		{
			this.OnSelected(true);
			this.SelectTrigger = false;
		}
		else
		{
			Func<int> getSelectIndexFunction = this.GetSelectIndexFunction;
			int? num = (getSelectIndexFunction != null) ? new int?(getSelectIndexFunction()) : null;
			if (index == num.GetValueOrDefault() & num != null)
			{
				this.OnSelected(false);
			}
			else
			{
				this.OnDeselected(false);
			}
		}
		base.GetText(2).SetText(data.Title, true);
		base.GetText(4).SetText(data.Sender, true);
		int num2 = Singleton<TimeUtil>.Instance.CalculateMailDayGapByServerTime((double)data.Time);
		if (num2 > 7)
		{
			DateTime dataFromTimeStamp = Singleton<TimeUtil>.Instance.GetDataFromTimeStamp((double)data.Time);
			UUIText text = base.GetText(5);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
			defaultInterpolatedStringHandler.AppendFormatted<int>(dataFromTimeStamp.Year);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(dataFromTimeStamp.Month);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(dataFromTimeStamp.Day);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		else if (num2 >= 1)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "Text_FriendOfflineSomeDay_Text", new <>z__ReadOnlySingleElementList<object>(num2));
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "Text_Today_Text", Array.Empty<object>());
		}
		base.GetItem(6).SetUIActive(!data.GetWasScanned());
		base.GetItem(3).SetUIActive(data.GetMailLevel() == 2);
		bool isFavorite = data.IsFavorite;
		base.GetSprite(8).SetUIActive(isFavorite);
		UUIButtonComponent favoriteButton = this.FavoriteButton;
		if (favoriteButton != null)
		{
			favoriteButton.SetSelfInteractive(isFavorite);
		}
		if (!data.GetWasScanned() && data.GetAttachmentStatus() == EMailAttachment.AttachmentRemained)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_IconRewardA");
			this.SetSpriteByPath(resourcePath, base.GetSprite(0), false, null, null);
			base.GetItem(7).SetAlpha(1f);
			return;
		}
		if (data.GetWasScanned() && data.GetAttachmentStatus() == EMailAttachment.AttachmentRemained)
		{
			string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_IconRewardA");
			this.SetSpriteByPath(resourcePath2, base.GetSprite(0), false, null, null);
			base.GetItem(7).SetAlpha(1f);
			return;
		}
		if (data.GetWasScanned() && data.GetAttachmentStatus() == EMailAttachment.AttachmentPicked)
		{
			string resourcePath3 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_IconRewardB");
			this.SetSpriteByPath(resourcePath3, base.GetSprite(0), false, null, null);
			base.GetItem(7).SetAlpha(0.4f);
			return;
		}
		if (!data.GetWasScanned() && data.GetAttachmentStatus() == EMailAttachment.NoneAttachment)
		{
			string resourcePath4 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_IconMailA");
			this.SetSpriteByPath(resourcePath4, base.GetSprite(0), false, null, null);
			base.GetItem(7).SetAlpha(1f);
			return;
		}
		if (data.GetWasScanned() && data.GetAttachmentStatus() == EMailAttachment.NoneAttachment)
		{
			string resourcePath5 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_IconMailB");
			this.SetSpriteByPath(resourcePath5, base.GetSprite(0), false, null, null);
			base.GetItem(7).SetAlpha(0.4f);
		}
	}

	// Token: 0x06010876 RID: 67702 RVA: 0x0048529D File Offset: 0x0048349D
	public void BindSelectCall(Action<int, MailData> func)
	{
		this.OnSelectCallback = func;
	}

	// Token: 0x06010877 RID: 67703 RVA: 0x004852A6 File Offset: 0x004834A6
	public void BindGetSelectedIndexFunction(Func<int> func)
	{
		this.GetSelectIndexFunction = func;
	}

	// Token: 0x06010878 RID: 67704 RVA: 0x004852AF File Offset: 0x004834AF
	public void BindFavoriteClickCall(Action<int, MailData> func)
	{
		this.OnFavoriteClickCallback = func;
	}

	// Token: 0x06010879 RID: 67705 RVA: 0x004852B8 File Offset: 0x004834B8
	public void OnSelected(bool fireEvent)
	{
		(this.RootActor.GetComponentByClass(UUIExtendToggle.StaticClass()) as UUIExtendToggle).SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
	}

	// Token: 0x0601087A RID: 67706 RVA: 0x004852DE File Offset: 0x004834DE
	public void OnDeselected(bool fireEvent)
	{
		this.SelectTrigger = false;
		(this.RootActor.GetComponentByClass(UUIExtendToggle.StaticClass()) as UUIExtendToggle).SetToggleState(EToggleState.ETT_UnChecked, fireEvent, false, false);
	}

	// Token: 0x0601087B RID: 67707 RVA: 0x0048530B File Offset: 0x0048350B
	private void OnExtendToggleStateChanged(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked && this != null)
		{
			this.OnSelectCallback(this.Index, this.Data);
		}
	}

	// Token: 0x0601087C RID: 67708 RVA: 0x0048532B File Offset: 0x0048352B
	private void OnFavoriteButtonClick()
	{
		if (this.Data == null)
		{
			return;
		}
		Action<int, MailData> onFavoriteClickCallback = this.OnFavoriteClickCallback;
		if (onFavoriteClickCallback == null)
		{
			return;
		}
		onFavoriteClickCallback(this.Index, this.Data);
	}

	// Token: 0x0601087D RID: 67709 RVA: 0x00485354 File Offset: 0x00483554
	private void BindFavoriteButton()
	{
		UUISprite sprite = base.GetSprite(8);
		if (sprite == null)
		{
			return;
		}
		AUIBaseActor auibaseActor = sprite.GetOwner() as AUIBaseActor;
		this.FavoriteButton = (auibaseActor.GetComponentByClass(UUIButtonComponent.StaticClass()) as UUIButtonComponent);
		UUIButtonComponent favoriteButton = this.FavoriteButton;
		if (favoriteButton == null)
		{
			return;
		}
		favoriteButton.OnClickCallBack.Bind(new Action(this.OnFavoriteButtonClick));
	}

	// Token: 0x0601087E RID: 67710 RVA: 0x004853B5 File Offset: 0x004835B5
	public AUIBaseActor GetUsingItem(MailData data)
	{
		return base.GetRootItem().GetOwner() as AUIBaseActor;
	}

	// Token: 0x0601087F RID: 67711 RVA: 0x004853C8 File Offset: 0x004835C8
	public UniTask Init(UUIItem actor)
	{
		MailScrollItemNew.<Init>d__22 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<MailScrollItemNew.<Init>d__22>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x06010880 RID: 67712 RVA: 0x00485413 File Offset: 0x00483613
	public void ClearItem()
	{
		UUIButtonComponent favoriteButton = this.FavoriteButton;
		if (favoriteButton != null)
		{
			favoriteButton.OnClickCallBack.Unbind();
		}
		this.Toggle.OnStateChange.Clear();
		this.OnSelectCallback = null;
		base.Destroy(null);
	}

	// Token: 0x040081FE RID: 33278
	private const int DAY_GAP = 7;

	// Token: 0x040081FF RID: 33279
	private UUIExtendToggle Toggle;

	// Token: 0x04008200 RID: 33280
	private UUIButtonComponent FavoriteButton;

	// Token: 0x04008201 RID: 33281
	private Action<int, MailData> OnSelectCallback;

	// Token: 0x04008202 RID: 33282
	private Action<int, MailData> OnFavoriteClickCallback;

	// Token: 0x04008203 RID: 33283
	private Func<int> GetSelectIndexFunction;

	// Token: 0x04008204 RID: 33284
	public bool SelectTrigger;

	// Token: 0x04008205 RID: 33285
	public bool IsInit;

	// Token: 0x04008206 RID: 33286
	private int Index = -1;

	// Token: 0x04008207 RID: 33287
	private MailData Data;

	// Token: 0x0200850F RID: 34063
	[NullableContext(0)]
	private enum EMailScrollItemComponents
	{
		// Token: 0x0402D0D2 RID: 184530
		SprIcon,
		// Token: 0x0402D0D3 RID: 184531
		Toggle,
		// Token: 0x0402D0D4 RID: 184532
		TxtMailTitle,
		// Token: 0x0402D0D5 RID: 184533
		SprStar,
		// Token: 0x0402D0D6 RID: 184534
		TxtPoster,
		// Token: 0x0402D0D7 RID: 184535
		TxtTime,
		// Token: 0x0402D0D8 RID: 184536
		RedDot,
		// Token: 0x0402D0D9 RID: 184537
		PnlContent,
		// Token: 0x0402D0DA RID: 184538
		SprFavorite
	}
}
