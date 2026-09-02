using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002788 RID: 10120
public class RoleHandBookItem : UiPanelBase
{
	// Token: 0x06013F95 RID: 81813 RVA: 0x00590F44 File Offset: 0x0058F144
	[NullableContext(1)]
	public RoleHandBookItem(int roleId, UUIItem item)
	{
		this.RoleId = new int?(roleId);
		if (item != null)
		{
			base.CreateThenShowByActor(item.GetOwner(), null);
		}
	}

	// Token: 0x06013F96 RID: 81814 RVA: 0x00590F68 File Offset: 0x0058F168
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnClickItem));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06013F97 RID: 81815 RVA: 0x0059113B File Offset: 0x0058F33B
	public void PlaySequence()
	{
		ALevelSequenceActor showSequence = this.ShowSequence;
		if (showSequence == null)
		{
			return;
		}
		showSequence.SequencePlayer.Play();
	}

	// Token: 0x06013F98 RID: 81816 RVA: 0x00591152 File Offset: 0x0058F352
	private void ConfirmClick(int _)
	{
		if (this.IsCanRoleActive())
		{
			ControllerBase<RoleController>.Instance.SendRoleActiveRequest(this.RoleId.Value);
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleHandBookRootView, EUiViewName.RoleHandBookSelectionView, null);
	}

	// Token: 0x06013F99 RID: 81817 RVA: 0x0059118C File Offset: 0x0058F38C
	protected void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddCommonItemList));
	}

	// Token: 0x06013F9A RID: 81818 RVA: 0x005911AA File Offset: 0x0058F3AA
	protected void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddCommonItemList));
	}

	// Token: 0x06013F9B RID: 81819 RVA: 0x005911C8 File Offset: 0x0058F3C8
	[NullableContext(1)]
	private void OnAddCommonItemList(IReadOnlyList<IProto_NormalItem> _)
	{
		this.UpdateCostInfo();
	}

	// Token: 0x06013F9C RID: 81820 RVA: 0x005911D0 File Offset: 0x0058F3D0
	protected override void OnStart()
	{
		if (this.RoleId == null)
		{
			return;
		}
		this.ConfirmButton = new ButtonItem(base.GetItem(4));
		this.ConfirmButton.SetFunction(new Action<int>(this.ConfirmClick));
		this.UpdateComponent(this.RoleId.Value);
		this.AddEventListener();
	}

	// Token: 0x06013F9D RID: 81821 RVA: 0x0059122C File Offset: 0x0058F42C
	public void UpdateComponent(int roleId)
	{
		this.RoleId = new int?(roleId);
		RoleInfo value = ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.RoleId.Value).Value;
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId.Value);
		base.GetText(0).ShowTextNew(value.Name);
		this.ConfirmButton.UnBindRedDot();
		this.ConfirmButton.BindRedDot(ERedDotName.RoleHandBookActiveButton, this.RoleId.Value);
		UUIItem item = base.GetItem(7);
		UUIItem item2 = base.GetItem(8);
		UUIItem item3 = base.GetItem(9);
		if (this.IsRoleUnlock())
		{
			this.ConfirmButton.SetLocalText("Detail", Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(5), "ActiveTime", Array.Empty<object>());
			base.GetText(6).SetText(Singleton<TimeUtil>.Instance.DateFormat4(new DateTime(1970, 1, 1).AddSeconds((double)roleInstanceById.GetRoleCreateTime()).AddMilliseconds((double)Singleton<TimeUtil>.Instance.InverseMillisecond)), true);
			item.SetUIActive(true);
			item2.SetUIActive(false);
			item3.SetUIActive(false);
		}
		else
		{
			if (this.IsCanRoleActive())
			{
				this.ConfirmButton.SetLocalText("Tuning", Array.Empty<object>());
			}
			else
			{
				this.ConfirmButton.SetLocalText("Detail", Array.Empty<object>());
			}
			this.UpdateCostInfo();
			item.SetUIActive(false);
			item2.SetUIActive(true);
			item3.SetUIActive(true);
		}
		if (this.ShowSequence != null)
		{
			ALevelSequenceActor tmp = this.ShowSequence;
			TimerSystem.GameplayTimeInstance.Next(delegate(float _)
			{
				Singleton<ActorSystem>.Instance.Put("RoleHandBookItem.UpdateComponent", tmp, null);
			}, null, null);
			this.ShowSequence = null;
		}
		GachaEffectConfig value2 = ConfigBase<GachaConfig>.Instance.GetGachaEffectConfigByTimesAndQuality(1, value.QualityId).Value;
		Singleton<ResourceSystem>.Instance.LoadAsync<ULevelSequence>(value2.FinalShowSequencePath, delegate(ULevelSequence levelSequenceObject, string _)
		{
			if (ObjectUtils.IsValid(levelSequenceObject))
			{
				FMovieSceneSequencePlaybackSettings fmovieSceneSequencePlaybackSettings = new FMovieSceneSequencePlaybackSettings();
				fmovieSceneSequencePlaybackSettings.bRestoreState = true;
				this.ShowSequence = (Singleton<ActorSystem>.Instance.Get(ALevelSequenceActor.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, false) as ALevelSequenceActor);
				this.ShowSequence.PlaybackSettings = fmovieSceneSequencePlaybackSettings;
				this.ShowSequence.SetSequence(levelSequenceObject);
			}
		}, 100, this.MemoryTag);
	}

	// Token: 0x06013F9E RID: 81822 RVA: 0x00591434 File Offset: 0x0058F634
	public void UpdateCostInfo()
	{
		if (this.RoleId == null)
		{
			return;
		}
		Dictionary<int, int> dictionary = ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.RoleId.Value).Value.ExchangeConsume();
		ItemInfo? itemInfo = null;
		int? num = null;
		using (Dictionary<int, int>.Enumerator enumerator = dictionary.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				KeyValuePair<int, int> keyValuePair = enumerator.Current;
				itemInfo = ConfigBase<ItemConfig>.Instance.GetConfig(keyValuePair.Key);
				num = new int?(keyValuePair.Value);
			}
		}
		base.SetTextureByPath(itemInfo.Value.Icon, base.GetTexture(1), null, null);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), "RoleFragment", Array.Empty<object>());
		int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(itemInfo.Value.Id, 0);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(3), "RoleExp", new <>z__ReadOnlyArray<object>(new object[]
		{
			itemCountByConfigId,
			num
		}));
	}

	// Token: 0x06013F9F RID: 81823 RVA: 0x00591574 File Offset: 0x0058F774
	public bool IsRoleUnlock()
	{
		return ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId.Value) != null;
	}

	// Token: 0x06013FA0 RID: 81824 RVA: 0x00591590 File Offset: 0x0058F790
	public bool IsCanRoleActive()
	{
		RoleInfo value = ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.RoleId.Value).Value;
		bool flag = this.IsRoleUnlock();
		Dictionary<int, int> dictionary = value.ExchangeConsume();
		ItemInfo? itemInfo = null;
		int? num = null;
		using (Dictionary<int, int>.Enumerator enumerator = dictionary.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				KeyValuePair<int, int> keyValuePair = enumerator.Current;
				itemInfo = ConfigBase<ItemConfig>.Instance.GetConfig(keyValuePair.Key);
				num = new int?(keyValuePair.Value);
			}
		}
		int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(itemInfo.Value.Id, 0);
		return !flag && itemCountByConfigId >= num.Value;
	}

	// Token: 0x06013FA1 RID: 81825 RVA: 0x00591664 File Offset: 0x0058F864
	protected override void OnBeforeDestroy()
	{
		this.RemoveEventListener();
		this.ConfirmButton.UnBindRedDot();
		this.RoleId = null;
		if (this.ShowSequence != null)
		{
			ALevelSequenceActor tmp = this.ShowSequence;
			TimerSystem.GameplayTimeInstance.Next(delegate(float _)
			{
				Singleton<ActorSystem>.Instance.Put("RoleHandBookItem.OnBeforeDestroy", tmp, null);
			}, null, null);
			this.ShowSequence = null;
		}
	}

	// Token: 0x06013FA2 RID: 81826 RVA: 0x005916C8 File Offset: 0x0058F8C8
	protected void OnClickItem()
	{
		Dictionary<int, int> dictionary = ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.RoleId.Value).Value.ExchangeConsume();
		int? num = null;
		using (Dictionary<int, int>.KeyCollection.Enumerator enumerator = dictionary.Keys.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				int value = enumerator.Current;
				num = new int?(value);
			}
		}
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(num.Value, true, null);
	}

	// Token: 0x04009B8C RID: 39820
	[Nullable(2)]
	private ButtonItem ConfirmButton;

	// Token: 0x04009B8D RID: 39821
	private int? RoleId;

	// Token: 0x04009B8E RID: 39822
	[Nullable(2)]
	private ALevelSequenceActor ShowSequence;

	// Token: 0x02008B41 RID: 35649
	private enum ERoleHandBookItemDefine
	{
		// Token: 0x0402EF0A RID: 192266
		NameText,
		// Token: 0x0402EF0B RID: 192267
		IconTexture,
		// Token: 0x0402EF0C RID: 192268
		FragmentTitleText,
		// Token: 0x0402EF0D RID: 192269
		FragmentCostText,
		// Token: 0x0402EF0E RID: 192270
		ConfirmButton,
		// Token: 0x0402EF0F RID: 192271
		ActiveTimeTitleText,
		// Token: 0x0402EF10 RID: 192272
		ActiveTimeText,
		// Token: 0x0402EF11 RID: 192273
		ActiveTimeItem,
		// Token: 0x0402EF12 RID: 192274
		IconItem,
		// Token: 0x0402EF13 RID: 192275
		FragmentItem,
		// Token: 0x0402EF14 RID: 192276
		ItemTipsButton
	}
}
