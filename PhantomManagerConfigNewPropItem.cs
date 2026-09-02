using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002485 RID: 9349
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
internal class PhantomManagerConfigNewPropItem : GridProxyAbstract<IPhantomManagerConfigNewSettingDetailInfo>
{
	// Token: 0x06012246 RID: 74310 RVA: 0x004FCB8C File Offset: 0x004FAD8C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIExtendToggle));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06012247 RID: 74311 RVA: 0x004FCCE0 File Offset: 0x004FAEE0
	protected override void OnStart()
	{
		this.LevelSequence = new LevelSequencePlayer(base.GetRootItem());
		UUIExtendToggle extendToggle = base.GetExtendToggle(7);
		if (extendToggle != null)
		{
			extendToggle.OnStateChange.Add(new Action<EToggleState>(this.OnClickedDiscard));
		}
		UUIExtendToggle extendToggle2 = base.GetExtendToggle(8);
		if (extendToggle2 == null)
		{
			return;
		}
		extendToggle2.OnStateChange.Add(new Action<EToggleState>(this.OnClickedLock));
	}

	// Token: 0x06012248 RID: 74312 RVA: 0x004FCD44 File Offset: 0x004FAF44
	public override void Refresh(IPhantomManagerConfigNewSettingDetailInfo data, bool isSelected, int gridIndex)
	{
		PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(data.MainPropId);
		this.CurData = data;
		base.GetText(2).ShowTextNew(propertyIndexInfo.Value.Name);
		base.SetTextureByPath(propertyIndexInfo.Value.Icon, base.GetTexture(1), null, null);
		this.RefreshState(data.IsEdit, false);
	}

	// Token: 0x06012249 RID: 74313 RVA: 0x004FCDB8 File Offset: 0x004FAFB8
	public void RefreshState(bool isEdit, bool needAnim = false)
	{
		UUIButtonComponent button = base.GetButton(0);
		if (button != null)
		{
			button.SetSelfInteractive(isEdit);
		}
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(!isEdit);
		}
		UUIItem item2 = base.GetItem(6);
		if (item2 != null)
		{
			item2.SetUIActive(isEdit);
		}
		EPhantomManagerConfigState propCurrentState = ModelBase<PhantomBattleModel>.Instance.GetPhantomConfigData().GetPropCurrentState(this.CurData);
		if (needAnim && propCurrentState != this.CurState)
		{
			LevelSequencePlayer levelSequence = this.LevelSequence;
			if (levelSequence != null)
			{
				levelSequence.PlayOrReplaySequenceByName("Refresh", false, null);
			}
		}
		this.CurState = propCurrentState;
		if (isEdit)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(8);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState((propCurrentState == EPhantomManagerConfigState.Lock) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			}
			UUIExtendToggle extendToggle2 = base.GetExtendToggle(7);
			if (extendToggle2 == null)
			{
				return;
			}
			extendToggle2.SetToggleState((propCurrentState == EPhantomManagerConfigState.Discard) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			return;
		}
		else
		{
			UUISprite sprite = base.GetSprite(4);
			if (sprite != null)
			{
				sprite.SetUIActive(propCurrentState == EPhantomManagerConfigState.Lock);
			}
			UUISprite sprite2 = base.GetSprite(5);
			if (sprite2 == null)
			{
				return;
			}
			sprite2.SetUIActive(propCurrentState == EPhantomManagerConfigState.Discard);
			return;
		}
	}

	// Token: 0x0601224A RID: 74314 RVA: 0x004FCEB4 File Offset: 0x004FB0B4
	private void OnClickedDiscard(EToggleState state)
	{
		PhantomManagerConfigData phantomConfigData = ModelBase<PhantomBattleModel>.Instance.GetPhantomConfigData();
		if (state == EToggleState.ETT_UnChecked)
		{
			phantomConfigData.SetPropCurrentState(this.CurData, EPhantomManagerConfigState.Default, true);
			this.CurState = EPhantomManagerConfigState.Default;
			return;
		}
		EPhantomManagerConfigState propCurrentState = phantomConfigData.GetPropCurrentState(this.CurData);
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId((propCurrentState == EPhantomManagerConfigState.Default) ? "PhantomProject_ModifyPlan_Des_3" : "PhantomProject_ModifyPlan_Des_5", Array.Empty<object>());
		UUIExtendToggle extendToggle = base.GetExtendToggle(8);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		phantomConfigData.SetPropCurrentState(this.CurData, EPhantomManagerConfigState.Discard, true);
		this.CurState = EPhantomManagerConfigState.Discard;
	}

	// Token: 0x0601224B RID: 74315 RVA: 0x004FCF3C File Offset: 0x004FB13C
	private void OnClickedLock(EToggleState state)
	{
		PhantomManagerConfigData phantomConfigData = ModelBase<PhantomBattleModel>.Instance.GetPhantomConfigData();
		if (state == EToggleState.ETT_UnChecked)
		{
			phantomConfigData.SetPropCurrentState(this.CurData, EPhantomManagerConfigState.Default, true);
			this.CurState = EPhantomManagerConfigState.Default;
			return;
		}
		EPhantomManagerConfigState propCurrentState = phantomConfigData.GetPropCurrentState(this.CurData);
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId((propCurrentState == EPhantomManagerConfigState.Default) ? "PhantomProject_ModifyPlan_Des_2" : "PhantomProject_ModifyPlan_Des_4", Array.Empty<object>());
		UUIExtendToggle extendToggle = base.GetExtendToggle(7);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		phantomConfigData.SetPropCurrentState(this.CurData, EPhantomManagerConfigState.Lock, true);
		this.CurState = EPhantomManagerConfigState.Lock;
	}

	// Token: 0x04008D93 RID: 36243
	protected IPhantomManagerConfigNewSettingDetailInfo CurData = new PhantomManagerConfigNewSettingDetailInfo();

	// Token: 0x04008D94 RID: 36244
	[Nullable(2)]
	protected LevelSequencePlayer LevelSequence;

	// Token: 0x04008D95 RID: 36245
	protected EPhantomManagerConfigState CurState;

	// Token: 0x0200879E RID: 34718
	[NullableContext(0)]
	private enum EItem
	{
		// Token: 0x0402DD87 RID: 187783
		BtnSetProp,
		// Token: 0x0402DD88 RID: 187784
		TexIcon,
		// Token: 0x0402DD89 RID: 187785
		TxtName,
		// Token: 0x0402DD8A RID: 187786
		PanelPreviewState,
		// Token: 0x0402DD8B RID: 187787
		SpriteLock,
		// Token: 0x0402DD8C RID: 187788
		SpriteDiscard,
		// Token: 0x0402DD8D RID: 187789
		PanelEdit,
		// Token: 0x0402DD8E RID: 187790
		ToggleDiscard,
		// Token: 0x0402DD8F RID: 187791
		ToggleLock
	}
}
