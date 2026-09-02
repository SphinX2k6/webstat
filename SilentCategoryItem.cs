using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001769 RID: 5993
public class SilentCategoryItem : UiPanelBase
{
	// Token: 0x0600A87E RID: 43134 RVA: 0x002CDA22 File Offset: 0x002CBC22
	[NullableContext(1)]
	public SilentCategoryItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600A87F RID: 43135 RVA: 0x002CDA38 File Offset: 0x002CBC38
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickExtendToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A880 RID: 43136 RVA: 0x002CDB20 File Offset: 0x002CBD20
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

	// Token: 0x0600A881 RID: 43137 RVA: 0x002CDB82 File Offset: 0x002CBD82
	protected override void OnBeforeDestroy()
	{
		this.UnbindRedDot();
		this.Data = null;
		this.ExtendToggle.OnPostAudioEvent.Unbind();
		this.ExtendToggle.OnPostAudioStateEvent.Unbind();
	}

	// Token: 0x0600A882 RID: 43138 RVA: 0x002CDBB4 File Offset: 0x002CBDB4
	[NullableContext(1)]
	public void Update(ISilentAreaTitleData data, bool isShow)
	{
		this.Data = data;
		this.IsShowingSilentCategoryItem = isShow;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), this.Data.TitleName, Array.Empty<object>());
		base.GetExtendToggle(0).SetToggleState(this.IsShowingSilentCategoryItem ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		this.BindRedDot();
	}

	// Token: 0x0600A883 RID: 43139 RVA: 0x002CDC12 File Offset: 0x002CBE12
	private void BindRedDot()
	{
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.AdventureFirstAwardCategory, base.GetItem(3), null, this.Data.TypeDescription);
	}

	// Token: 0x0600A884 RID: 43140 RVA: 0x002CDC33 File Offset: 0x002CBE33
	private void UnbindRedDot()
	{
		if (this.Data == null)
		{
			return;
		}
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.AdventureFirstAwardCategory, base.GetItem(3), this.Data.TypeDescription);
	}

	// Token: 0x0600A885 RID: 43141 RVA: 0x002CDC5C File Offset: 0x002CBE5C
	public void RefreshRedDot(bool isShow)
	{
		base.GetItem(3).SetUIActive(isShow);
	}

	// Token: 0x0600A886 RID: 43142 RVA: 0x002CDC6B File Offset: 0x002CBE6B
	public void BindCategoryCallback([Nullable(new byte[]
	{
		2,
		1
	})] Action<int, UUIExtendToggle, bool> onCategoryCallback)
	{
		this.CategoryCallback = onCategoryCallback;
	}

	// Token: 0x0600A887 RID: 43143 RVA: 0x002CDC74 File Offset: 0x002CBE74
	public void OnClickExtendToggle(EToggleState state)
	{
		this.IsShowingSilentCategoryItem = !this.IsShowingSilentCategoryItem;
		if (this.CategoryCallback != null)
		{
			this.CategoryCallback(this.Data.TypeDescription, this.ExtendToggle, this.IsShowingSilentCategoryItem);
		}
	}

	// Token: 0x04004F61 RID: 20321
	[Nullable(2)]
	private UUIExtendToggle ExtendToggle;

	// Token: 0x04004F62 RID: 20322
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<int, UUIExtendToggle, bool> CategoryCallback;

	// Token: 0x04004F63 RID: 20323
	[Nullable(2)]
	private ISilentAreaTitleData Data;

	// Token: 0x04004F64 RID: 20324
	private bool IsShowingSilentCategoryItem;

	// Token: 0x02007ACB RID: 31435
	private enum ESilentCategoryDefine
	{
		// Token: 0x0402A0F9 RID: 172281
		ExtendToggle,
		// Token: 0x0402A0FA RID: 172282
		TitleText,
		// Token: 0x0402A0FB RID: 172283
		FlagSprite,
		// Token: 0x0402A0FC RID: 172284
		RedDotItem
	}
}
