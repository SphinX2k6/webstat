using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.Ui.HotFix;
using UnrealEngine;

// Token: 0x0200276C RID: 10092
public class ResDownLoadViewTabItem : GridProxyAbstract<int>
{
	// Token: 0x06013EAD RID: 81581 RVA: 0x0058D17C File Offset: 0x0058B37C
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
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06013EAE RID: 81582 RVA: 0x0058D208 File Offset: 0x0058B408
	protected override void OnStart()
	{
		UUIExtendToggle toggle = base.GetExtendToggle(0);
		toggle.OnStateChange.Add(delegate(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked && this.OnClickExtendToggleCallBack != null)
			{
				this.OnClickExtendToggleCallBack(this.TabIndex, this.ResType, toggle);
			}
		});
	}

	// Token: 0x06013EAF RID: 81583 RVA: 0x0058D24C File Offset: 0x0058B44C
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.TabIndex = data;
		EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
		if (this.TabIndex == 3)
		{
			if (playerGender == EPlayerGender.Male)
			{
				this.ResType = 4;
			}
			else
			{
				this.ResType = 3;
			}
		}
		else if (playerGender == EPlayerGender.Male)
		{
			this.ResType = 3;
		}
		else
		{
			this.ResType = 4;
		}
		DownLoadTab? config = ConfigDownLoadTabById.GetConfig(this.TabIndex, true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), config.Value.Title, Array.Empty<object>());
		long videoResSize = Singleton<VideoResUpdate>.Instance.GetVideoResSize((EVideoResSizeType)this.ResType);
		if (videoResSize == Singleton<VideoResUpdate>.Instance.GetVideoResSavedSize((EVideoResSizeType)this.ResType))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "HaveDownLoadRes", Array.Empty<object>());
			return;
		}
		base.GetText(2).SetText(HotFixManager.ByteConverter(videoResSize), true);
	}

	// Token: 0x06013EB0 RID: 81584 RVA: 0x0058D323 File Offset: 0x0058B523
	public void SelectToggle()
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, true, false, false);
	}

	// Token: 0x06013EB1 RID: 81585 RVA: 0x0058D336 File Offset: 0x0058B536
	[NullableContext(1)]
	public override object GetKey(int data, int displayIndex)
	{
		return data;
	}

	// Token: 0x04009AEE RID: 39662
	private int TabIndex;

	// Token: 0x04009AEF RID: 39663
	private int ResType;

	// Token: 0x04009AF0 RID: 39664
	[Nullable(1)]
	public Action<int, int, UUIExtendToggle> OnClickExtendToggleCallBack;

	// Token: 0x02008B26 RID: 35622
	private enum EResDownLoadViewTabItem
	{
		// Token: 0x0402EEB6 RID: 192182
		Toggle,
		// Token: 0x0402EEB7 RID: 192183
		NameText,
		// Token: 0x0402EEB8 RID: 192184
		SpaceText
	}
}
