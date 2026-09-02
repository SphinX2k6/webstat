using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001C8B RID: 7307
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
internal class MemoryFragmentTabItem : GridProxyAbstract<TabItemData>
{
	// Token: 0x0600D5E4 RID: 54756 RVA: 0x00391794 File Offset: 0x0038F994
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnTabToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D5E5 RID: 54757 RVA: 0x00391900 File Offset: 0x0038FB00
	private void OnTabToggleClick(EToggleState toggleState)
	{
		if (this.Data == null)
		{
			return;
		}
		this.Data.TabCallBack(base.GridIndex);
	}

	// Token: 0x0600D5E6 RID: 54758 RVA: 0x00391921 File Offset: 0x0038FB21
	private LevelSequencePlayer GetLevelSequencePlayer()
	{
		if (this.LevelSequencePlayer == null)
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}
		return this.LevelSequencePlayer;
	}

	// Token: 0x0600D5E7 RID: 54759 RVA: 0x00391944 File Offset: 0x0038FB44
	public override void Refresh(TabItemData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		bool flag = base.GridIndex == data.GetCurrentSelectTabIndex();
		EToggleState etoggleState = flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(etoggleState, false, false, false);
		}
		if (data.FragmentCollectData == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), data.FragmentCollectData.GetTitle(), Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.FragmentCollectData.GetTitle(), Array.Empty<object>());
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(data.FragmentCollectData.GetIfGetReward());
		}
		this.RefreshRedDot();
		this.RefreshHaveItem();
		this.RefreshNoneItem();
		this.RefreshNumText();
		if (this.SelectState != flag)
		{
			this.RefreshToggleAnimation(etoggleState);
		}
		this.SelectState = flag;
	}

	// Token: 0x0600D5E8 RID: 54760 RVA: 0x00391A24 File Offset: 0x0038FC24
	private void RefreshToggleAnimation(EToggleState targetState)
	{
		string text = (targetState == EToggleState.ETT_Checked) ? "Select" : "Unselect";
		TabItemData data = this.Data;
		if (data != null && data.NeedSwitchAnimation)
		{
			LevelSequencePlayer levelSequencePlayer = this.GetLevelSequencePlayer();
			if (levelSequencePlayer.GetCurrentSequence() == text)
			{
				if (levelSequencePlayer != null)
				{
					levelSequencePlayer.ReplaySequenceByKey(text);
					return;
				}
			}
			else if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlaySequencePurely(text, false, false, null, null, false);
				return;
			}
		}
		else
		{
			LevelSequencePlayer levelSequencePlayer2 = this.GetLevelSequencePlayer();
			if (levelSequencePlayer2 != null)
			{
				levelSequencePlayer2.StopSequenceByKey("Select", false, false);
			}
			if (levelSequencePlayer2 != null)
			{
				levelSequencePlayer2.PlaySequencePurely(text, false, false, null, null, false);
			}
			levelSequencePlayer2.StopSequenceByKey(text, false, true);
		}
	}

	// Token: 0x0600D5E9 RID: 54761 RVA: 0x00391ACC File Offset: 0x0038FCCC
	private void RefreshNumText()
	{
		TabItemData data = this.Data;
		if (((data != null) ? data.FragmentCollectData : null) == null)
		{
			return;
		}
		if (this.Data.FragmentCollectData.GetIfUnlock())
		{
			string newText = (base.GridIndex + 1).ToString().PadLeft(2, '0');
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.SetText(newText, true);
			return;
		}
		else
		{
			UUIText text2 = base.GetText(1);
			if (text2 == null)
			{
				return;
			}
			text2.SetText("", true);
			return;
		}
	}

	// Token: 0x0600D5EA RID: 54762 RVA: 0x00391B44 File Offset: 0x0038FD44
	private void RefreshHaveItem()
	{
		TabItemData data = this.Data;
		if (((data != null) ? data.FragmentCollectData : null) == null)
		{
			return;
		}
		bool ifUnlock = this.Data.FragmentCollectData.GetIfUnlock();
		UUIItem item = base.GetItem(5);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(ifUnlock);
	}

	// Token: 0x0600D5EB RID: 54763 RVA: 0x00391B8C File Offset: 0x0038FD8C
	private void RefreshNoneItem()
	{
		TabItemData data = this.Data;
		if (((data != null) ? data.FragmentCollectData : null) == null)
		{
			return;
		}
		bool uiactive = !this.Data.FragmentCollectData.GetIfUnlock();
		UUIItem item = base.GetItem(6);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(uiactive);
	}

	// Token: 0x0600D5EC RID: 54764 RVA: 0x00391BD4 File Offset: 0x0038FDD4
	private void RefreshRedDot()
	{
		TabItemData data = this.Data;
		if (((data != null) ? data.FragmentCollectData : null) == null)
		{
			return;
		}
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.FragmentMemoryReward, base.GetItem(4), this.Data.FragmentCollectData.GetId());
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.FragmentMemoryReward, base.GetItem(4), null, this.Data.FragmentCollectData.GetId());
	}

	// Token: 0x04006570 RID: 25968
	[Nullable(2)]
	private TabItemData Data;

	// Token: 0x04006571 RID: 25969
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04006572 RID: 25970
	private bool SelectState;

	// Token: 0x02007FD7 RID: 32727
	[NullableContext(0)]
	private class ETabItem
	{
		// Token: 0x0402B826 RID: 178214
		public const int TabToggle = 0;

		// Token: 0x0402B827 RID: 178215
		public const int NumText = 1;

		// Token: 0x0402B828 RID: 178216
		public const int NameText = 2;

		// Token: 0x0402B829 RID: 178217
		public const int DoneSprite = 3;

		// Token: 0x0402B82A RID: 178218
		public const int RedDot = 4;

		// Token: 0x0402B82B RID: 178219
		public const int HaveItem = 5;

		// Token: 0x0402B82C RID: 178220
		public const int NoneItem = 6;

		// Token: 0x0402B82D RID: 178221
		public const int TextNumNone = 7;
	}
}
