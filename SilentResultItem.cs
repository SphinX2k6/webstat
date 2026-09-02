using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200176A RID: 5994
public class SilentResultItem : UiPanelBase
{
	// Token: 0x0600A88A RID: 43146 RVA: 0x002CDCD1 File Offset: 0x002CBED1
	[NullableContext(1)]
	public SilentResultItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600A88B RID: 43147 RVA: 0x002CDCE8 File Offset: 0x002CBEE8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickExtendToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A88C RID: 43148 RVA: 0x002CDE34 File Offset: 0x002CC034
	protected override void OnStart()
	{
		this.ExtendToggle = base.GetExtendToggle(0);
		this.ExtendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		this.ExtendToggle.OnPostAudioEvent.Bind(delegate(string eventPath)
		{
			if (!string.IsNullOrEmpty(eventPath))
			{
				base.PostClickAudioEvent(eventPath);
			}
		});
		this.ExtendToggle.OnPostAudioStateEvent.Bind(delegate(EToggleAudioTransitionState state, string eventPath)
		{
			if (!string.IsNullOrEmpty(eventPath))
			{
				base.PostClickAudioEvent(eventPath);
			}
		});
	}

	// Token: 0x0600A88D RID: 43149 RVA: 0x002CDE96 File Offset: 0x002CC096
	protected override void OnBeforeDestroy()
	{
		this.UnbindRedDot();
		this.Data = null;
		this.ExtendToggle.OnPostAudioEvent.Unbind();
		this.ExtendToggle.OnPostAudioStateEvent.Unbind();
	}

	// Token: 0x0600A88E RID: 43150 RVA: 0x002CDEC8 File Offset: 0x002CC0C8
	[NullableContext(1)]
	public void Update(SilentAreaDetectionRecord data)
	{
		this.Data = data;
		UUIText text = base.GetText(4);
		string name = data.Conf.Name;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, name, Array.Empty<object>());
		base.GetText(3).SetUIActive(false);
		base.GetTexture(1).SetUIActive(false);
		UUIItem item = base.GetItem(2);
		if (data.IsLock)
		{
			item.SetUIActive(true);
			text.SetUIActive(false);
		}
		else
		{
			item.SetUIActive(false);
			text.SetUIActive(true);
		}
		base.GetSprite(5).SetUIActive(data.IsTargeting);
		this.BindRedDot();
	}

	// Token: 0x0600A88F RID: 43151 RVA: 0x002CDF64 File Offset: 0x002CC164
	private void BindRedDot()
	{
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.AdventureFirstAwardResult, base.GetItem(6), null, this.Data.Conf.Id);
	}

	// Token: 0x0600A890 RID: 43152 RVA: 0x002CDF98 File Offset: 0x002CC198
	private void UnbindRedDot()
	{
		if (this.Data == null)
		{
			return;
		}
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.AdventureFirstAwardResult, base.GetItem(6), this.Data.Conf.Id);
	}

	// Token: 0x0600A891 RID: 43153 RVA: 0x002CDFD4 File Offset: 0x002CC1D4
	public void BindResultCallback([Nullable(new byte[]
	{
		2,
		1
	})] Action<int, UUIExtendToggle> onResultCallback)
	{
		this.ResultCallback = onResultCallback;
	}

	// Token: 0x0600A892 RID: 43154 RVA: 0x002CDFE0 File Offset: 0x002CC1E0
	public void OnClickExtendToggle(EToggleState state)
	{
		if (this.ResultCallback != null)
		{
			this.ResultCallback(this.Data.Conf.Id, this.ExtendToggle);
		}
	}

	// Token: 0x04004F65 RID: 20325
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<int, UUIExtendToggle> ResultCallback;

	// Token: 0x04004F66 RID: 20326
	[Nullable(2)]
	private SilentAreaDetectionRecord Data;

	// Token: 0x04004F67 RID: 20327
	[Nullable(2)]
	private UUIExtendToggle ExtendToggle;

	// Token: 0x02007ACC RID: 31436
	private enum ESilentResultDefine
	{
		// Token: 0x0402A0FE RID: 172286
		ExtendToggle,
		// Token: 0x0402A0FF RID: 172287
		TargetPic,
		// Token: 0x0402A100 RID: 172288
		NotFoundItem,
		// Token: 0x0402A101 RID: 172289
		LvlTxt,
		// Token: 0x0402A102 RID: 172290
		NameTxt,
		// Token: 0x0402A103 RID: 172291
		TargetingIco,
		// Token: 0x0402A104 RID: 172292
		RedDotItem
	}
}
