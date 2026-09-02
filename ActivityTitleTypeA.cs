using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001607 RID: 5639
[NullableContext(1)]
[Nullable(0)]
public class ActivityTitleTypeA : UiPanelBase
{
	// Token: 0x06009F34 RID: 40756 RVA: 0x00299AA0 File Offset: 0x00297CA0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 13;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.OnClickToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009F35 RID: 40757 RVA: 0x00299CB8 File Offset: 0x00297EB8
	protected override void OnStart()
	{
		this.SetSubTitleVisible(false);
		UUIExtendToggle extendToggle = base.GetExtendToggle(5);
		if (extendToggle == null)
		{
			return;
		}
		UUIItem uuiitem = extendToggle.RootUIComp.Get();
		if (uuiitem == null)
		{
			return;
		}
		uuiitem.SetUIActive(false);
	}

	// Token: 0x06009F36 RID: 40758 RVA: 0x00299CF0 File Offset: 0x00297EF0
	[NullableContext(2)]
	public void SetActivityBaseData(ActivityBaseData data)
	{
		if (data == null)
		{
			return;
		}
		this.ActivityData = data;
		this.SetPnlActTypeByConfig();
	}

	// Token: 0x06009F37 RID: 40759 RVA: 0x00299D04 File Offset: 0x00297F04
	private void SetPnlActTypeByConfig()
	{
		if (this.ActivityData == null)
		{
			return;
		}
		Activity? localConfig = this.ActivityData.LocalConfig;
		if (localConfig == null)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(5);
			if (extendToggle == null)
			{
				return;
			}
			UUIItem uuiitem = extendToggle.RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(false);
			return;
		}
		else
		{
			bool flag = localConfig.Value.ShowActTypeIds().Length >= 1;
			bool flag2 = localConfig.Value.ShowActTypeIds().Length >= 2;
			if (flag)
			{
				UUIExtendToggle extendToggle2 = base.GetExtendToggle(5);
				if (extendToggle2 != null)
				{
					UUIItem uuiitem2 = extendToggle2.RootUIComp.Get();
					if (uuiitem2 != null)
					{
						uuiitem2.SetUIActive(true);
					}
				}
				UUIItem item = base.GetItem(6);
				if (item != null)
				{
					item.SetUIActive(flag);
				}
				UUIItem item2 = base.GetItem(9);
				if (item2 != null)
				{
					item2.SetUIActive(flag2);
				}
				if (flag && localConfig.Value.ShowActTypeIds()[0] != 0)
				{
					this.TagId_1 = localConfig.Value.ShowActTypeIds()[0];
					this.SetActTypeTogByConfig(this.TagId_1);
				}
				if (flag2 && localConfig.Value.ShowActTypeIds()[1] != 0)
				{
					this.TagId_2 = localConfig.Value.ShowActTypeIds()[1];
					this.SetPlayTypeTogBtnByConfig(this.TagId_2);
				}
				return;
			}
			UUIExtendToggle extendToggle3 = base.GetExtendToggle(5);
			if (extendToggle3 == null)
			{
				return;
			}
			UUIItem uuiitem3 = extendToggle3.RootUIComp.Get();
			if (uuiitem3 == null)
			{
				return;
			}
			uuiitem3.SetUIActive(false);
			return;
		}
	}

	// Token: 0x06009F38 RID: 40760 RVA: 0x00299E74 File Offset: 0x00298074
	private void SetActTypeTogByConfig(int id)
	{
		ActivityTitleTags? activityTitleTags = ConfigBase<ActivityConfig>.Instance.GetActivityTitleTags(id);
		if (activityTitleTags == null)
		{
			return;
		}
		string togIcon = activityTitleTags.Value.TogIcon;
		this.SetSpriteByPath(togIcon, base.GetSprite(7), false, null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), activityTitleTags.Value.TagName, Array.Empty<object>());
	}

	// Token: 0x06009F39 RID: 40761 RVA: 0x00299EE8 File Offset: 0x002980E8
	private void SetPlayTypeTogBtnByConfig(int id)
	{
		ActivityTitleTags? activityTitleTags = ConfigBase<ActivityConfig>.Instance.GetActivityTitleTags(id);
		if (activityTitleTags == null)
		{
			return;
		}
		string togIcon = activityTitleTags.Value.TogIcon;
		this.SetSpriteByPath(togIcon, base.GetSprite(10), false, null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), activityTitleTags.Value.TagName, Array.Empty<object>());
	}

	// Token: 0x06009F3A RID: 40762 RVA: 0x00299F5B File Offset: 0x0029815B
	private void OnClickToggle(EToggleState _)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityTagInfoHelpView, new int[]
		{
			this.TagId_1,
			this.TagId_2
		}, null);
	}

	// Token: 0x06009F3B RID: 40763 RVA: 0x00299F85 File Offset: 0x00298185
	public void SetTitleByTextId(string textId, params string[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textId, args);
	}

	// Token: 0x06009F3C RID: 40764 RVA: 0x00299F9A File Offset: 0x0029819A
	public void SetTitleByText(string text)
	{
		UUIText text2 = base.GetText(0);
		if (text2 == null)
		{
			return;
		}
		text2.SetText(text, true);
	}

	// Token: 0x06009F3D RID: 40765 RVA: 0x00299FB0 File Offset: 0x002981B0
	public void SetTimeTextByText(string text)
	{
		UUIText text2 = base.GetText(1);
		if (text2 == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Activity, ELogAuthor.YYZ, "[活动][DEBUG] SetTimeTextByText.Text不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		text2.SetText(text, true);
	}

	// Token: 0x06009F3E RID: 40766 RVA: 0x00299FF0 File Offset: 0x002981F0
	public void SetTimeTextVisible(bool bVisible)
	{
		if (base.GetText(1) == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Activity, ELogAuthor.YYZ, "[活动][DEBUG] SetTimeTextVisible.Text不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		UUIItem item = base.GetItem(12);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(bVisible);
	}

	// Token: 0x06009F3F RID: 40767 RVA: 0x0029A039 File Offset: 0x00298239
	public void SetTimeTextByTextId(string textId, params string[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, args);
	}

	// Token: 0x06009F40 RID: 40768 RVA: 0x0029A050 File Offset: 0x00298250
	public void SetBgTextureByPath(string path, [Nullable(2)] Action<bool> callback = null)
	{
		base.SetTextureByPath(path, base.GetTexture(2), null, callback);
	}

	// Token: 0x06009F41 RID: 40769 RVA: 0x0029A075 File Offset: 0x00298275
	public void SetBgTextureVisible(bool bVisible)
	{
		UUITexture texture = base.GetTexture(2);
		if (texture == null)
		{
			return;
		}
		texture.SetUIActive(bVisible);
	}

	// Token: 0x06009F42 RID: 40770 RVA: 0x0029A089 File Offset: 0x00298289
	public void SetSubTitleVisible(bool bVisible)
	{
		UUIText text = base.GetText(3);
		if (text == null)
		{
			return;
		}
		text.SetUIActive(false);
	}

	// Token: 0x06009F43 RID: 40771 RVA: 0x0029A09D File Offset: 0x0029829D
	public void SetSubTitleByTextId(string textId, params string[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), textId, args);
	}

	// Token: 0x06009F44 RID: 40772 RVA: 0x0029A0B2 File Offset: 0x002982B2
	public void SetSubTitleByText(string text)
	{
		UUIText text2 = base.GetText(3);
		if (text2 == null)
		{
			return;
		}
		text2.SetText(text, true);
	}

	// Token: 0x06009F45 RID: 40773 RVA: 0x0029A0C7 File Offset: 0x002982C7
	public void SetSubTitleIconVisible(bool bVisible)
	{
		UUISprite sprite = base.GetSprite(4);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(bVisible);
	}

	// Token: 0x06009F46 RID: 40774 RVA: 0x0029A0DC File Offset: 0x002982DC
	public void SetSubTitleIconByPath(string path, [Nullable(2)] Action<bool> callback = null)
	{
		this.SetSpriteByPath(path, base.GetSprite(4), true, null, callback);
	}

	// Token: 0x06009F47 RID: 40775 RVA: 0x0029A104 File Offset: 0x00298304
	public void SetTogActPlayTypeVisible(bool bVisible)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(5);
		if (extendToggle == null)
		{
			return;
		}
		UUIItem uuiitem = extendToggle.RootUIComp.Get();
		if (uuiitem == null)
		{
			return;
		}
		uuiitem.SetUIActive(bVisible);
	}

	// Token: 0x04004904 RID: 18692
	[Nullable(2)]
	private ActivityBaseData ActivityData;

	// Token: 0x04004905 RID: 18693
	private int TagId_1;

	// Token: 0x04004906 RID: 18694
	private int TagId_2;

	// Token: 0x020079D2 RID: 31186
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029D12 RID: 171282
		public const int Title = 0;

		// Token: 0x04029D13 RID: 171283
		public const int TextTime = 1;

		// Token: 0x04029D14 RID: 171284
		public const int BgTexture = 2;

		// Token: 0x04029D15 RID: 171285
		public const int SubTitle = 3;

		// Token: 0x04029D16 RID: 171286
		public const int SubTitleIcon = 4;

		// Token: 0x04029D17 RID: 171287
		public const int TogActPlayType = 5;

		// Token: 0x04029D18 RID: 171288
		public const int ItemActType = 6;

		// Token: 0x04029D19 RID: 171289
		public const int SprActType = 7;

		// Token: 0x04029D1A RID: 171290
		public const int TxtActType = 8;

		// Token: 0x04029D1B RID: 171291
		public const int ItemPlayType = 9;

		// Token: 0x04029D1C RID: 171292
		public const int SprPlayType = 10;

		// Token: 0x04029D1D RID: 171293
		public const int TxtPlayType = 11;

		// Token: 0x04029D1E RID: 171294
		public const int PnlLimitedTime = 12;
	}
}
