using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001746 RID: 5958
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MonsterDetectItem : GridProxyAbstract<MonsterDetectionRecord>
{
	// Token: 0x0600A796 RID: 42902 RVA: 0x002C94D3 File Offset: 0x002C76D3
	public void BindCallback(Action<int, UUIExtendToggle> onSelectedCallback)
	{
		this.OnSelectedCallback = onSelectedCallback;
	}

	// Token: 0x0600A797 RID: 42903 RVA: 0x002C94DC File Offset: 0x002C76DC
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
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A798 RID: 42904 RVA: 0x002C9588 File Offset: 0x002C7788
	protected override void OnStart()
	{
		this.ExtendToggle = base.GetExtendToggle(0);
		this.ExtendToggle.OnStateChange.Add(delegate(EToggleState state)
		{
			this.OnCallback();
		});
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

	// Token: 0x0600A799 RID: 42905 RVA: 0x002C9606 File Offset: 0x002C7806
	protected override void OnBeforeDestroy()
	{
		this.ExtendToggle.OnStateChange.Clear();
		this.ExtendToggle.OnPostAudioEvent.Unbind();
		this.ExtendToggle.OnPostAudioStateEvent.Unbind();
	}

	// Token: 0x0600A79A RID: 42906 RVA: 0x002C9638 File Offset: 0x002C7838
	public override void Refresh(MonsterDetectionRecord data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		UUIItem item = base.GetItem(2);
		UUITexture texture = base.GetTexture(3);
		if (data.IsLock)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Text_UnDiscovered_Text", Array.Empty<object>());
			item.SetUIActive(true);
			texture.SetUIActive(false);
		}
		else
		{
			MonsterInfo value = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterInfoConfig(data.Conf.MonsterInfoId).Value;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), value.Name, Array.Empty<object>());
			item.SetUIActive(false);
			texture.SetUIActive(true);
			base.SetTextureByPath(value.Icon, texture, null, null);
		}
		this.RootItem.SetUIActive(true);
		int? currentMonsterId = ModelBase<AdventureGuideModel>.Instance.CurrentMonsterId;
		int id = data.Conf.Id;
		bool flag = currentMonsterId.GetValueOrDefault() == id & currentMonsterId != null;
		this.Selected(flag, false);
		if (flag)
		{
			this.OnCallback();
		}
	}

	// Token: 0x0600A79B RID: 42907 RVA: 0x002C9744 File Offset: 0x002C7944
	public override void OnSelected(bool fireEvent)
	{
		this.Selected(true, true);
	}

	// Token: 0x0600A79C RID: 42908 RVA: 0x002C974E File Offset: 0x002C794E
	public override void OnDeselected(bool fireEvent)
	{
		this.Selected(false, true);
	}

	// Token: 0x0600A79D RID: 42909 RVA: 0x002C9758 File Offset: 0x002C7958
	private void OnCallback()
	{
		if (this.OnSelectedCallback != null)
		{
			this.OnSelectedCallback(this.Data.Conf.Id, this.ExtendToggle);
		}
	}

	// Token: 0x0600A79E RID: 42910 RVA: 0x002C9791 File Offset: 0x002C7991
	private void Selected(bool bSelected, bool fire = true)
	{
		if (bSelected)
		{
			this.ExtendToggle.SetToggleState(EToggleState.ETT_Checked, fire, false, false);
			return;
		}
		this.ExtendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600A79F RID: 42911 RVA: 0x002C97B8 File Offset: 0x002C79B8
	public UUIItem GetToggleItem()
	{
		return base.GetExtendToggle(0).RootUIComp.Get();
	}

	// Token: 0x04004F1A RID: 20250
	[Nullable(2)]
	private MonsterDetectionRecord Data;

	// Token: 0x04004F1B RID: 20251
	[Nullable(2)]
	private UUIExtendToggle ExtendToggle;

	// Token: 0x04004F1C RID: 20252
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<int, UUIExtendToggle> OnSelectedCallback;

	// Token: 0x02007AB1 RID: 31409
	[NullableContext(0)]
	private enum EDetectItemNodeDefine
	{
		// Token: 0x0402A06E RID: 172142
		MonsterToggle,
		// Token: 0x0402A06F RID: 172143
		NameText,
		// Token: 0x0402A070 RID: 172144
		UnknownItem,
		// Token: 0x0402A071 RID: 172145
		MonsterTexture
	}
}
