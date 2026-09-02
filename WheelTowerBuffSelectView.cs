using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020016C4 RID: 5828
public class WheelTowerBuffSelectView : UiViewBase, IUiViewResource
{
	// Token: 0x0600A1D6 RID: 41430 RVA: 0x002A9342 File Offset: 0x002A7542
	[NullableContext(1)]
	public WheelTowerBuffSelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600A1D7 RID: 41431 RVA: 0x002A9354 File Offset: 0x002A7554
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickConfirm));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A1D8 RID: 41432 RVA: 0x002A94A0 File Offset: 0x002A76A0
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerBuffSelectView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerBuffSelectView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A1D9 RID: 41433 RVA: 0x002A94E4 File Offset: 0x002A76E4
	protected override void OnStart()
	{
		List<int> levelBuffList = ModelBase<WheelTowerModel>.Instance.GetLevelBuffList();
		LoopScrollView<WheelTowerBuffSelectView.BuffCard, int> cardScroll = this.CardScroll;
		if (cardScroll != null)
		{
			cardScroll.RefreshByData(new <>z__ReadOnlyArray<int>(levelBuffList.ToArray()), false, null, false);
		}
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem != null)
		{
			captionItem.SetCloseCallBack(delegate
			{
				base.CloseMe(null);
			});
		}
		UUIButtonComponent button = base.GetButton(4);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(this.SelectedBuffId != -1);
	}

	// Token: 0x0600A1DA RID: 41434 RVA: 0x002A9555 File Offset: 0x002A7755
	[NullableContext(1)]
	private WheelTowerBuffSelectView.BuffCard CreateCard()
	{
		WheelTowerBuffSelectView.BuffCard buffCard = new WheelTowerBuffSelectView.BuffCard();
		buffCard.SetToggleCallback(new Action<int, int>(this.OnClickCard));
		return buffCard;
	}

	// Token: 0x0600A1DB RID: 41435 RVA: 0x002A956E File Offset: 0x002A776E
	private void OnClickCard(int buffId, int index)
	{
		this.SelectedBuffId = buffId;
		LoopScrollView<WheelTowerBuffSelectView.BuffCard, int> cardScroll = this.CardScroll;
		if (cardScroll != null)
		{
			cardScroll.SelectGridProxy(index, false);
		}
		UUIButtonComponent button = base.GetButton(4);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(true);
	}

	// Token: 0x0600A1DC RID: 41436 RVA: 0x002A959C File Offset: 0x002A779C
	private void OnClickConfirm()
	{
		if (this.SelectedBuffId != -1)
		{
			ModelBase<WheelTowerModel>.Instance.SelectedBuff = this.SelectedBuffId;
		}
		base.CloseMe(null);
	}

	// Token: 0x0600A1DD RID: 41437 RVA: 0x002A95C0 File Offset: 0x002A77C0
	[NullableContext(1)]
	public string GetExtraResourceId([Nullable(2)] object param = null)
	{
		if ((param as int?).GetValueOrDefault() != 32)
		{
			return string.Empty;
		}
		return "UiView_WheelTowerBuffSelect32";
	}

	// Token: 0x04004BE5 RID: 19429
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04004BE6 RID: 19430
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private LoopScrollView<WheelTowerBuffSelectView.BuffCard, int> CardScroll;

	// Token: 0x04004BE7 RID: 19431
	private int SelectedBuffId = -1;

	// Token: 0x02007A16 RID: 31254
	private class BuffCard : GridProxyAbstract<int>
	{
		// Token: 0x0604785F RID: 292959 RVA: 0x0130F740 File Offset: 0x0130D940
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06047860 RID: 292960 RVA: 0x0130F84C File Offset: 0x0130DA4C
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.BuffId = data;
			NewTowerBuff? buffConfigById = ConfigBase<WheelTowerConfig>.Instance.GetBuffConfigById(data);
			if (buffConfigById == null)
			{
				return;
			}
			base.SetTextureShowUntilLoaded(buffConfigById.Value.Icon, base.GetTexture(1), null);
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.ShowTextNew(buffConfigById.Value.Name);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), buffConfigById.Value.Desc, buffConfigById.Value.DescParam());
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(ModelBase<WheelTowerModel>.Instance.SelectedBuff == data);
			}
			this.SetToggleSelect(false, true);
		}

		// Token: 0x06047861 RID: 292961 RVA: 0x0130F90A File Offset: 0x0130DB0A
		public override void OnDeselected(bool fireEvent)
		{
			this.SetToggleSelect(false, false);
		}

		// Token: 0x06047862 RID: 292962 RVA: 0x0130F914 File Offset: 0x0130DB14
		[NullableContext(1)]
		public void SetToggleCallback(Action<int, int> callback)
		{
			this.ToggleCallback = callback;
		}

		// Token: 0x06047863 RID: 292963 RVA: 0x0130F91D File Offset: 0x0130DB1D
		public void SetToggleSelect(bool selected, bool skipAnim = false)
		{
			base.GetExtendToggle(0).SetToggleStateForce(selected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, skipAnim);
		}

		// Token: 0x06047864 RID: 292964 RVA: 0x0130F935 File Offset: 0x0130DB35
		private void OnToggleClick(EToggleState state)
		{
			Action<int, int> toggleCallback = this.ToggleCallback;
			if (toggleCallback == null)
			{
				return;
			}
			toggleCallback(this.BuffId, base.GridIndex);
		}

		// Token: 0x04029E33 RID: 171571
		private int BuffId = -1;

		// Token: 0x04029E34 RID: 171572
		[Nullable(2)]
		private Action<int, int> ToggleCallback;
	}
}
