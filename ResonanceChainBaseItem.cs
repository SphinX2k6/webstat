using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x020028A2 RID: 10402
[NullableContext(2)]
[Nullable(0)]
public class ResonanceChainBaseItem : UiPanelBase
{
	// Token: 0x17001B16 RID: 6934
	// (get) Token: 0x06014A51 RID: 84561 RVA: 0x005B8371 File Offset: 0x005B6571
	protected virtual string ActivateSequenceName
	{
		get
		{
			return null;
		}
	}

	// Token: 0x06014A52 RID: 84562 RVA: 0x005B8374 File Offset: 0x005B6574
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUITexture))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnItemClick))
		};
	}

	// Token: 0x06014A53 RID: 84563 RVA: 0x005B8449 File Offset: 0x005B6649
	protected override void OnStart()
	{
		this.SequencePlayer = new LevelSequencePlayer(base.GetRootItem());
	}

	// Token: 0x06014A54 RID: 84564 RVA: 0x005B845C File Offset: 0x005B665C
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer == null)
		{
			return;
		}
		sequencePlayer.Clear();
	}

	// Token: 0x06014A55 RID: 84565 RVA: 0x005B846E File Offset: 0x005B666E
	public void Update(int roleId, int resonanceId, bool isActivate)
	{
		this.ResonanceId = resonanceId;
		this.RoleId = roleId;
		this.IsActivate = isActivate;
		this.Refresh();
	}

	// Token: 0x06014A56 RID: 84566 RVA: 0x005B848B File Offset: 0x005B668B
	public void Refresh()
	{
		this.RefreshToggleState(false);
		this.RefreshIcon();
		this.RefreshActivateItem();
		this.RefreshRedDot();
	}

	// Token: 0x06014A57 RID: 84567 RVA: 0x005B84A6 File Offset: 0x005B66A6
	public void ShowItem()
	{
		base.SetUiActive(true);
		this.PlayStartSequence();
	}

	// Token: 0x06014A58 RID: 84568 RVA: 0x005B84B5 File Offset: 0x005B66B5
	[NullableContext(1)]
	public UUIItem GetUiItemForGuide()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		return ((extendToggle != null) ? extendToggle.GetOwner().GetComponentByClass(UUIItem.StaticClass()) : null) as UUIItem;
	}

	// Token: 0x06014A59 RID: 84569 RVA: 0x005B84DE File Offset: 0x005B66DE
	private void OnItemClick(EToggleState toggleState)
	{
		if (this.ToggleCallBack != null)
		{
			this.ToggleCallBack(this.ResonanceId);
		}
	}

	// Token: 0x06014A5A RID: 84570 RVA: 0x005B84F9 File Offset: 0x005B66F9
	[NullableContext(1)]
	public void BindToggleCallBack(Action<int> callBack)
	{
		this.ToggleCallBack = callBack;
	}

	// Token: 0x06014A5B RID: 84571 RVA: 0x005B8504 File Offset: 0x005B6704
	public void RefreshToggleState(bool force = false)
	{
		EToggleState state = this.IsSelect ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		if (force)
		{
			base.GetExtendToggle(0).SetToggleStateForce(state, false, false, false);
			return;
		}
		base.GetExtendToggle(0).SetToggleState(state, false, false, false);
	}

	// Token: 0x06014A5C RID: 84572 RVA: 0x005B8543 File Offset: 0x005B6743
	public void SetSelectState(bool isSelect)
	{
		this.IsSelect = isSelect;
	}

	// Token: 0x06014A5D RID: 84573 RVA: 0x005B854C File Offset: 0x005B674C
	private void RefreshIcon()
	{
		ResonantChain? roleResonanceById = ConfigBase<RoleResonanceConfig>.Instance.GetRoleResonanceById(this.ResonanceId);
		UUITexture texture = base.GetTexture(6);
		UUITexture texture2 = base.GetTexture(4);
		if (roleResonanceById != null && !StringUtils.IsBlank(roleResonanceById.Value.NodeIcon))
		{
			base.SetTextureByPath(roleResonanceById.Value.NodeIcon, texture2, null, null);
			base.SetTextureByPath(roleResonanceById.Value.NodeIcon, texture, null, null);
		}
		texture2.SetUIActive(!this.IsActivate);
		texture.SetUIActive(this.IsActivate);
	}

	// Token: 0x06014A5E RID: 84574 RVA: 0x005B85F6 File Offset: 0x005B67F6
	private void RefreshActivateItem()
	{
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(!this.IsActivate);
		}
		UUIItem item2 = base.GetItem(3);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(this.IsActivate);
	}

	// Token: 0x06014A5F RID: 84575 RVA: 0x005B862A File Offset: 0x005B682A
	public void RefreshMaxActivateItem(bool isAllActive)
	{
		UUIItem item = base.GetItem(1);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(isAllActive);
	}

	// Token: 0x06014A60 RID: 84576 RVA: 0x005B8640 File Offset: 0x005B6840
	public void RefreshRedDot()
	{
		ResonantChain? roleResonanceById = ConfigBase<RoleResonanceConfig>.Instance.GetRoleResonanceById(this.ResonanceId);
		bool uiactive = ModelBase<RoleModel>.Instance.RedDotResonanceTabHoleCondition(this.RoleId, roleResonanceById.Value.GroupIndex);
		UUIItem item = base.GetItem(5);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(uiactive);
	}

	// Token: 0x06014A61 RID: 84577 RVA: 0x005B8690 File Offset: 0x005B6890
	public int GetResonanceId()
	{
		return this.ResonanceId;
	}

	// Token: 0x06014A62 RID: 84578 RVA: 0x005B8698 File Offset: 0x005B6898
	public UUIItem GetRedDotItem()
	{
		return base.GetItem(5);
	}

	// Token: 0x06014A63 RID: 84579 RVA: 0x005B86A4 File Offset: 0x005B68A4
	public void PlayActivateSequence()
	{
		this.SequencePlayer.PlayLevelSequenceByName("Unlock", false, null, false);
	}

	// Token: 0x06014A64 RID: 84580 RVA: 0x005B86CC File Offset: 0x005B68CC
	private void PlayStartSequence()
	{
		if (this.IsActivate)
		{
			this.SequencePlayer.PlayOrReplaySequenceByName("ActiveSet", false, null);
			return;
		}
		this.SequencePlayer.PlayOrReplaySequenceByName("LockSet", false, null);
	}

	// Token: 0x04009F4B RID: 40779
	protected int ResonanceId;

	// Token: 0x04009F4C RID: 40780
	protected int RoleId;

	// Token: 0x04009F4D RID: 40781
	protected bool IsActivate;

	// Token: 0x04009F4E RID: 40782
	private bool IsSelect;

	// Token: 0x04009F4F RID: 40783
	private Action<int> ToggleCallBack;

	// Token: 0x04009F50 RID: 40784
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x04009F51 RID: 40785
	protected UniTask? LoadPromise;

	// Token: 0x02008BF0 RID: 35824
	[NullableContext(0)]
	public enum EResonanceChainItemCom
	{
		// Token: 0x0402F23A RID: 193082
		Toggle,
		// Token: 0x0402F23B RID: 193083
		MaxActivateItem,
		// Token: 0x0402F23C RID: 193084
		DeActivateItem,
		// Token: 0x0402F23D RID: 193085
		ActivateItem,
		// Token: 0x0402F23E RID: 193086
		DeActivateIconTexture,
		// Token: 0x0402F23F RID: 193087
		RedDot,
		// Token: 0x0402F240 RID: 193088
		ActivateIconTexture
	}
}
