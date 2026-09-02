using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001811 RID: 6161
[NullableContext(1)]
[Nullable(0)]
public class VisionRefineAttributeItem : UiPanelBase, IGridProxy<VisionRefineAttributeItemData>
{
	// Token: 0x17000E49 RID: 3657
	// (get) Token: 0x0600AF5D RID: 44893 RVA: 0x002EBC2D File Offset: 0x002E9E2D
	// (set) Token: 0x0600AF5E RID: 44894 RVA: 0x002EBC35 File Offset: 0x002E9E35
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	public IScrollViewDelegate<IGridProxy<VisionRefineAttributeItemData>, VisionRefineAttributeItemData> ScrollViewDelegate { [return: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] set; }

	// Token: 0x17000E4A RID: 3658
	// (get) Token: 0x0600AF5F RID: 44895 RVA: 0x002EBC3E File Offset: 0x002E9E3E
	// (set) Token: 0x0600AF60 RID: 44896 RVA: 0x002EBC46 File Offset: 0x002E9E46
	public int GridIndex { get; set; }

	// Token: 0x17000E4B RID: 3659
	// (get) Token: 0x0600AF61 RID: 44897 RVA: 0x002EBC4F File Offset: 0x002E9E4F
	// (set) Token: 0x0600AF62 RID: 44898 RVA: 0x002EBC57 File Offset: 0x002E9E57
	public int DisplayIndex { get; set; }

	// Token: 0x0600AF63 RID: 44899 RVA: 0x002EBC60 File Offset: 0x002E9E60
	public void Refresh(VisionRefineAttributeItemData data, bool isSelected, int gridIndex)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		extendToggle.IsSelfInteractive = data.CanInteractive;
		extendToggle.SetToggleState(data.IsChosen ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.NameTextId, Array.Empty<object>());
		UUIText text = base.GetText(3);
		if (text != null)
		{
			text.SetText(data.NumberText ?? "", true);
		}
		if (data.ForceCheckboxActive != null)
		{
			UUISprite sprite = base.GetSprite(4);
			if (sprite != null)
			{
				sprite.SetUIActive(data.ForceCheckboxActive.Value);
			}
		}
		if (data.HasNewIcon == null)
		{
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(false);
			}
		}
		else
		{
			UUIItem item2 = base.GetItem(5);
			if (item2 != null)
			{
				item2.SetUIActive(true);
			}
			UUIItem item3 = base.GetItem(5);
			if (item3 != null)
			{
				item3.SetAlpha(data.HasNewIcon.Value > false);
			}
		}
		UUIItem item4 = base.GetItem(6);
		if (item4 != null)
		{
			item4.SetUIActive(false);
		}
		UUITexture texture = base.GetTexture(1);
		if (texture != null)
		{
			texture.SetUIActive(data.IsRecommend);
		}
		if (data.HasNewIcon.GetValueOrDefault())
		{
			UUIItem item5 = base.GetItem(6);
			if (item5 == null)
			{
				return;
			}
			item5.SetUIActive(true);
		}
	}

	// Token: 0x0600AF64 RID: 44900 RVA: 0x002EBD9D File Offset: 0x002E9F9D
	public UniTask RefreshAsync(VisionRefineAttributeItemData data, bool isSelected, int gridIndex)
	{
		this.Refresh(data, isSelected, gridIndex);
		return UniTask.CompletedTask;
	}

	// Token: 0x0600AF65 RID: 44901 RVA: 0x002EBDAD File Offset: 0x002E9FAD
	public void Clear()
	{
	}

	// Token: 0x0600AF66 RID: 44902 RVA: 0x002EBDAF File Offset: 0x002E9FAF
	public void OnSelected(bool fireEvent)
	{
		if (this.OnSelectedCallback != null && !this.OnSelectedCallback(this.GridIndex))
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
	}

	// Token: 0x0600AF67 RID: 44903 RVA: 0x002EBDE2 File Offset: 0x002E9FE2
	public void OnDeselected(bool fireEvent)
	{
		if (this.OnDeselectedCallback != null && !this.OnDeselectedCallback(this.GridIndex))
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}
	}

	// Token: 0x0600AF68 RID: 44904 RVA: 0x002EBE15 File Offset: 0x002EA015
	[return: Nullable(2)]
	public object GetKey(VisionRefineAttributeItemData data, int gridIndex)
	{
		return data;
	}

	// Token: 0x0600AF69 RID: 44905 RVA: 0x002EBE18 File Offset: 0x002EA018
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClick))
		};
	}

	// Token: 0x0600AF6A RID: 44906 RVA: 0x002EBEF0 File Offset: 0x002EA0F0
	protected override UniTask OnBeforeStartAsync()
	{
		VisionRefineAttributeItem.<OnBeforeStartAsync>d__22 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionRefineAttributeItem.<OnBeforeStartAsync>d__22>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600AF6B RID: 44907 RVA: 0x002EBF33 File Offset: 0x002EA133
	private void OnClick(EToggleState toggleState)
	{
		if (toggleState != EToggleState.ETT_UnChecked)
		{
			if (toggleState == EToggleState.ETT_Checked)
			{
				this.OnSelected(false);
				return;
			}
		}
		else
		{
			this.OnDeselected(false);
		}
	}

	// Token: 0x04005322 RID: 21282
	[Nullable(2)]
	public Func<int, bool> OnSelectedCallback;

	// Token: 0x04005323 RID: 21283
	[Nullable(2)]
	public Func<int, bool> OnDeselectedCallback;

	// Token: 0x02007B92 RID: 31634
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402A3C7 RID: 172999
		Toggle,
		// Token: 0x0402A3C8 RID: 173000
		LightTexture,
		// Token: 0x0402A3C9 RID: 173001
		NameText,
		// Token: 0x0402A3CA RID: 173002
		NumberText,
		// Token: 0x0402A3CB RID: 173003
		ChosenSprite,
		// Token: 0x0402A3CC RID: 173004
		NewItem,
		// Token: 0x0402A3CD RID: 173005
		EffectItem
	}
}
