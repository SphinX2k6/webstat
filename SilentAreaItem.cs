using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200176B RID: 5995
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SilentAreaItem : GridProxyAbstract<ISilentAreaDetectionDynamicData>
{
	// Token: 0x0600A895 RID: 43157 RVA: 0x002CE03B File Offset: 0x002CC23B
	public void BindCallback(Action<int, UUIExtendToggle> onSelectedCallback)
	{
		this.OnSelectedCallback = onSelectedCallback;
	}

	// Token: 0x0600A896 RID: 43158 RVA: 0x002CE044 File Offset: 0x002CC244
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A897 RID: 43159 RVA: 0x002CE0D0 File Offset: 0x002CC2D0
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

	// Token: 0x0600A898 RID: 43160 RVA: 0x002CE14E File Offset: 0x002CC34E
	protected override void OnBeforeDestroy()
	{
		this.ExtendToggle.OnStateChange.Clear();
		this.ExtendToggle.OnPostAudioEvent.Unbind();
		this.ExtendToggle.OnPostAudioStateEvent.Unbind();
	}

	// Token: 0x0600A899 RID: 43161 RVA: 0x002CE180 File Offset: 0x002CC380
	public override void Refresh(ISilentAreaDetectionDynamicData data, bool isSelected, int gridIndex)
	{
		this.Data = data.SilentAreaDetectionData;
		if (this.Data.IsLock)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Text_UnDiscovered_Text", Array.Empty<object>());
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), this.Data.Conf.Name, Array.Empty<object>());
		}
		UUISprite sprite = base.GetSprite(2);
		sprite.SetUIActive(true);
		int dangerType = this.Data.Conf.DangerType;
		this.SetSpriteByPath(ConfigBase<AdventureGuideConfig>.Instance.GetSecondaryGuideDataConf(dangerType).Value.Icon, sprite, false, null, null);
		this.RootItem.SetUIActive(true);
		bool flag = ModelBase<AdventureGuideModel>.Instance.CurrentSilentId == this.Data.Conf.Id;
		this.Selected(flag, false);
		if (flag)
		{
			this.OnCallback();
		}
	}

	// Token: 0x0600A89A RID: 43162 RVA: 0x002CE27E File Offset: 0x002CC47E
	public override void OnSelected(bool fireEvent)
	{
		this.Selected(true, true);
	}

	// Token: 0x0600A89B RID: 43163 RVA: 0x002CE288 File Offset: 0x002CC488
	public override void OnDeselected(bool fireEvent)
	{
		this.Selected(false, true);
	}

	// Token: 0x0600A89C RID: 43164 RVA: 0x002CE294 File Offset: 0x002CC494
	private void OnCallback()
	{
		if (this.OnSelectedCallback != null && this.Data != null)
		{
			this.OnSelectedCallback(this.Data.Conf.Id, this.ExtendToggle);
		}
	}

	// Token: 0x0600A89D RID: 43165 RVA: 0x002CE2D5 File Offset: 0x002CC4D5
	private void Selected(bool bSelected, bool fire = true)
	{
		if (bSelected)
		{
			this.ExtendToggle.SetToggleState(EToggleState.ETT_Checked, fire, false, false);
			return;
		}
		this.ExtendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x04004F68 RID: 20328
	[Nullable(2)]
	private SilentAreaDetectionRecord Data;

	// Token: 0x04004F69 RID: 20329
	[Nullable(2)]
	private UUIExtendToggle ExtendToggle;

	// Token: 0x04004F6A RID: 20330
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<int, UUIExtendToggle> OnSelectedCallback;

	// Token: 0x02007ACD RID: 31437
	[NullableContext(0)]
	private enum EDetectItemNodeDefine
	{
		// Token: 0x0402A106 RID: 172294
		MonsterToggle,
		// Token: 0x0402A107 RID: 172295
		NameText,
		// Token: 0x0402A108 RID: 172296
		NormalIcon
	}
}
