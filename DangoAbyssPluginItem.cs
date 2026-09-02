using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Dango;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001AF2 RID: 6898
[NullableContext(2)]
[Nullable(0)]
public class DangoAbyssPluginItem : UiPanelBase
{
	// Token: 0x0600C6A5 RID: 50853 RVA: 0x003480BB File Offset: 0x003462BB
	public DangoAbyssPluginItem(int index, bool isEquipView)
	{
		this.Index = index;
		this.IsEquipView = isEquipView;
	}

	// Token: 0x0600C6A6 RID: 50854 RVA: 0x003480E0 File Offset: 0x003462E0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600C6A7 RID: 50855 RVA: 0x0034820A File Offset: 0x0034640A
	protected override void OnStart()
	{
		this.Sequence = new LevelSequencePlayer(this.RootItem);
		base.GetExtendToggle(0).OnUndeterminedClicked.Add(new Action(this.OnUndeterminedClicked));
	}

	// Token: 0x0600C6A8 RID: 50856 RVA: 0x0034823A File Offset: 0x0034643A
	protected override void OnBeforeDestroy()
	{
		base.GetExtendToggle(0).OnUndeterminedClicked.Clear();
	}

	// Token: 0x0600C6A9 RID: 50857 RVA: 0x0034824D File Offset: 0x0034644D
	public void Refresh(AbyssDangoRoleSlotData data)
	{
		if (data == null)
		{
			this.SetDangoLock();
			return;
		}
		this.RefreshEffect(this.CurrentData, data);
		this.CurrentData = data;
		this.RefreshState();
		this.RefreshTexture();
		this.RefreshSpriteBg(false);
	}

	// Token: 0x0600C6AA RID: 50858 RVA: 0x00348280 File Offset: 0x00346480
	private void SetDangoLock()
	{
		int dangoId = this.ViewModel.GetDangoId();
		int slotUnlockLevel = ModelBase<DangoAbyssModel>.Instance.GetSlotUnlockLevel(dangoId, this.Index);
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnDetermined, false, false, false);
		base.GetText(2).SetText(StringUtils.Format("Lv.{0}", new string[]
		{
			slotUnlockLevel.ToString()
		}), true);
		base.GetText(2).SetUIActive(true);
		base.GetTexture(1).SetUIActive(false);
		base.GetTexture(5).SetUIActive(false);
		base.GetSprite(3).SetUIActive(true);
		base.GetSprite(4).SetUIActive(false);
	}

	// Token: 0x0600C6AB RID: 50859 RVA: 0x00348324 File Offset: 0x00346524
	private void RefreshEffect(AbyssDangoRoleSlotData oldData, AbyssDangoRoleSlotData newData)
	{
		int dangoId = (newData != null) ? newData.GetDangoId() : 0;
		if (ModelBase<DangoAbyssModel>.Instance.GetSlotLockState(dangoId, this.Index))
		{
			return;
		}
		switch (ModelBase<DangoAbyssModel>.Instance.GetSlotSwitchTypeByData(oldData, newData))
		{
		case DangoAbyssDefine.ESlotSwitchType.TakeOff:
			this.PlaySequence("MoveAway");
			return;
		case DangoAbyssDefine.ESlotSwitchType.Replace:
			this.PlaySequence("Replace");
			return;
		case DangoAbyssDefine.ESlotSwitchType.PutOn:
			this.PlaySequence("DropIn");
			return;
		default:
			return;
		}
	}

	// Token: 0x0600C6AC RID: 50860 RVA: 0x0034839C File Offset: 0x0034659C
	[NullableContext(1)]
	public UniTask PlaySequence(string name)
	{
		DangoAbyssPluginItem.<PlaySequence>d__13 <PlaySequence>d__;
		<PlaySequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlaySequence>d__.<>4__this = this;
		<PlaySequence>d__.name = name;
		<PlaySequence>d__.<>1__state = -1;
		<PlaySequence>d__.<>t__builder.Start<DangoAbyssPluginItem.<PlaySequence>d__13>(ref <PlaySequence>d__);
		return <PlaySequence>d__.<>t__builder.Task;
	}

	// Token: 0x0600C6AD RID: 50861 RVA: 0x003483E8 File Offset: 0x003465E8
	private void RefreshState()
	{
		int dangoId = this.CurrentData.GetDangoId();
		int slotUnlockLevel = ModelBase<DangoAbyssModel>.Instance.GetSlotUnlockLevel(dangoId, this.Index);
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		int slotIndex = this.ViewModel.GetSlotIndex();
		bool slotLockState = ModelBase<DangoAbyssModel>.Instance.GetSlotLockState(dangoId, this.Index);
		bool flag = slotIndex == this.Index;
		base.GetText(2).SetText(StringUtils.Format("Lv.{0}", new string[]
		{
			slotUnlockLevel.ToString()
		}), true);
		base.GetText(2).SetUIActive(slotLockState);
		if (flag && !slotLockState && this.IsEquipView)
		{
			extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
			return;
		}
		if (!slotLockState)
		{
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_UnDetermined, false, false, false);
	}

	// Token: 0x0600C6AE RID: 50862 RVA: 0x003484AC File Offset: 0x003466AC
	private void RefreshTexture()
	{
		int equipId = this.CurrentData.GetEquipId();
		AbyssItem? dangoItemById = ConfigBase<DangoAbyssConfig>.Instance.GetDangoItemById(equipId);
		if (equipId <= 0 || dangoItemById == null || dangoItemById.Value.IconMiddle == "")
		{
			base.GetTexture(1).SetUIActive(false);
			base.GetTexture(5).SetUIActive(false);
			return;
		}
		string pluginItemQualityIcon = ModelBase<DangoAbyssModel>.Instance.GetPluginItemQualityIcon(equipId);
		base.SetTextureByPath(dangoItemById.Value.IconMiddle, base.GetTexture(1), null, null);
		base.SetTextureByPath(pluginItemQualityIcon, base.GetTexture(5), null, null);
		base.GetTexture(1).SetUIActive(true);
		base.GetTexture(5).SetUIActive(true);
		DangoAbyssDefine.ESlotType slotTypeByIndex = ConfigBase<DangoAbyssConfig>.Instance.GetSlotTypeByIndex(this.Index);
		UUITexture texture = base.GetTexture(1);
		int num;
		DangoAbyssDefine.iconSizeBySlotType.TryGetValue(slotTypeByIndex, out num);
		texture.SetWidth((float)num);
		texture.SetHeight((float)num);
	}

	// Token: 0x0600C6AF RID: 50863 RVA: 0x003485B4 File Offset: 0x003467B4
	private void RefreshSpriteBg(bool newState)
	{
		AbyssDangoRoleSlotData currentData = this.CurrentData;
		AbyssItem? dangoItemById = ConfigBase<DangoAbyssConfig>.Instance.GetDangoItemById(currentData.GetEquipId());
		bool flag = (currentData.GetEquipId() != 0 && dangoItemById != null && !(dangoItemById.Value.Icon == "")) || !newState;
		base.GetSprite(3).SetUIActive(flag);
		base.GetSprite(4).SetUIActive(!flag);
	}

	// Token: 0x0600C6B0 RID: 50864 RVA: 0x0034862D File Offset: 0x0034682D
	private void OnToggleClick(EToggleState toggleState)
	{
		this.OnUndeterminedClicked();
	}

	// Token: 0x0600C6B1 RID: 50865 RVA: 0x00348638 File Offset: 0x00346838
	private void OnUndeterminedClicked()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Activity;
		ELogAuthor author = ELogAuthor.WDX;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 1);
		defaultInterpolatedStringHandler.AppendLiteral("OnToggleClick, ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.Index);
		instance.Info(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
		int dangoId = this.ViewModel.GetDangoId();
		if (ModelBase<DangoAbyssModel>.Instance.GetDangoIfLock(dangoId))
		{
			return;
		}
		if (ModelBase<DangoAbyssModel>.Instance.GetSlotLockState(dangoId, this.Index))
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.DangoAbyssLockSlotToLevelUp);
			confirmBoxDataNew.FunctionMap.Add(2, new Action(this.OnClickLevelUpConfirm));
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		this.ViewModel.SetSlotIndex(this.Index, false);
		if (!this.IsEquipView)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DangoAbyssPluginEquipView, this.ViewModel, null);
		}
	}

	// Token: 0x0600C6B2 RID: 50866 RVA: 0x00348718 File Offset: 0x00346918
	private void OnClickLevelUpConfirm()
	{
		int dangoId = this.ViewModel.GetDangoId();
		Singleton<UiManager>.Instance.OpenView(EUiViewName.DangoAbyssLevelUpView, dangoId, null);
	}

	// Token: 0x04005F2C RID: 24364
	private readonly int Index = -1;

	// Token: 0x04005F2D RID: 24365
	private readonly bool IsEquipView = true;

	// Token: 0x04005F2E RID: 24366
	private AbyssDangoRoleSlotData CurrentData;

	// Token: 0x04005F2F RID: 24367
	public PluginEquipViewModel ViewModel;

	// Token: 0x04005F30 RID: 24368
	public LevelSequencePlayer Sequence;

	// Token: 0x02007DC5 RID: 32197
	[NullableContext(0)]
	private class EPluginComponent
	{
		// Token: 0x0402AD6A RID: 175466
		public const int Toggle = 0;

		// Token: 0x0402AD6B RID: 175467
		public const int Texture = 1;

		// Token: 0x0402AD6C RID: 175468
		public const int LevelText = 2;

		// Token: 0x0402AD6D RID: 175469
		public const int SpriteBg = 3;

		// Token: 0x0402AD6E RID: 175470
		public const int SpriteNew = 4;

		// Token: 0x0402AD6F RID: 175471
		public const int TextureQuality = 5;
	}
}
