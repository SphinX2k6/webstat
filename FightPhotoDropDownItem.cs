using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020025C1 RID: 9665
[NullableContext(1)]
[Nullable(0)]
public class FightPhotoDropDownItem : FightPhotoSetupBase
{
	// Token: 0x06012E42 RID: 77378 RVA: 0x00539D80 File Offset: 0x00537F80
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x06012E43 RID: 77379 RVA: 0x00539DDC File Offset: 0x00537FDC
	protected override UniTask OnBeforeStartAsync()
	{
		FightPhotoDropDownItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FightPhotoDropDownItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012E44 RID: 77380 RVA: 0x00539E1F File Offset: 0x0053801F
	protected override void OnBeforeDestroy()
	{
		if (Singleton<EventSystem>.Instance.Has(EEventName.UIViewPortSizeChanged, new Action(this.OnViewPortSizeChange)))
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.UIViewPortSizeChanged, new Action(this.OnViewPortSizeChange));
		}
	}

	// Token: 0x06012E45 RID: 77381 RVA: 0x00539E54 File Offset: 0x00538054
	public override void Refresh()
	{
		if (this.SetupConfig == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), this.SetupConfig.Value.Name, Array.Empty<object>());
		this.RefreshDropDown();
		this.RefreshResolutionText();
	}

	// Token: 0x06012E46 RID: 77382 RVA: 0x00539EA4 File Offset: 0x005380A4
	private int GetSelectedDropDownId()
	{
		int? fightPhotoSetupOption = ModelBase<FightPhotoModel>.Instance.GetFightPhotoSetupOption((EFightPhotoSetupOptionType)this.SetupConfig.Value.Id);
		if (fightPhotoSetupOption == null)
		{
			return this.SetupConfig.Value.DefaultDropDownIndex;
		}
		return fightPhotoSetupOption.GetValueOrDefault();
	}

	// Token: 0x06012E47 RID: 77383 RVA: 0x00539EF4 File Offset: 0x005380F4
	private void RefreshDropDown()
	{
		int[] dropDownListArray = this.SetupConfig.Value.GetDropDownListArray();
		List<PhotoDropDown> list = new List<PhotoDropDown>();
		int[] array = dropDownListArray;
		for (int i = 0; i < array.Length; i++)
		{
			PhotoDropDown? config = ConfigPhotoDropDownById.GetConfig(array[i], true);
			if (config != null && (config.Value.IsShowInLowDevice || !Singleton<Info>.Instance.IsLowMemoryDevice))
			{
				list.Add(config.Value);
			}
		}
		int selectedId = this.GetSelectedDropDownId();
		this.DropDown.InitScroll(list, new Func<PhotoDropDown, TableTextArgNew>(this.GetDropDownTextId), list.FindIndex((PhotoDropDown d) => d.Id == selectedId), true);
	}

	// Token: 0x06012E48 RID: 77384 RVA: 0x00539FAC File Offset: 0x005381AC
	private void RefreshResolutionText()
	{
		UUIText text = base.GetText(2);
		if (text == null)
		{
			return;
		}
		if (this.SetupConfig.Value.Id != 1)
		{
			text.SetUIActive(false);
			return;
		}
		PhotoDropDown? config = ConfigPhotoDropDownById.GetConfig(this.GetSelectedDropDownId(), true);
		if (config == null)
		{
			text.SetUIActive(false);
			return;
		}
		float num = float.Parse(config.Value.Param()[0]);
		FVector2D viewportSize = UWidgetLayoutLibrary.GetViewportSize(GlobalData.World);
		int value = (int)Math.Round((double)(viewportSize.X * num));
		int value2 = (int)Math.Round((double)(viewportSize.Y * num));
		text.SetUIActive(true);
		LguiUtil instance = Singleton<LguiUtil>.Instance;
		UUIText uiText = text;
		string textStringId = "FightPhoto_CurrentResolutionText";
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(value);
		defaultInterpolatedStringHandler.AppendLiteral("×");
		defaultInterpolatedStringHandler.AppendFormatted<int>(value2);
		instance.SetLocalTextNew(uiText, textStringId, new <>z__ReadOnlySingleElementList<object>(defaultInterpolatedStringHandler.ToStringAndClear()));
	}

	// Token: 0x06012E49 RID: 77385 RVA: 0x0053A08D File Offset: 0x0053828D
	private TableTextArgNew GetDropDownTextId(PhotoDropDown data)
	{
		return new TableTextArgNew(data.TextId, Array.Empty<object>());
	}

	// Token: 0x06012E4A RID: 77386 RVA: 0x0053A0A0 File Offset: 0x005382A0
	private void OnSelectChange(int index, PhotoDropDown data)
	{
		base.OnSetupValueChange(data.Id);
		this.RefreshResolutionText();
	}

	// Token: 0x06012E4B RID: 77387 RVA: 0x0053A0B5 File Offset: 0x005382B5
	private void OnViewPortSizeChange()
	{
		if (this.SetupConfig == null)
		{
			return;
		}
		this.RefreshResolutionText();
	}

	// Token: 0x06012E4C RID: 77388 RVA: 0x0053A0CB File Offset: 0x005382CB
	private OneTextDropDownItem CreateDropDownItem(UUIItem uiItem, PhotoDropDown data)
	{
		return new OneTextDropDownItem(uiItem);
	}

	// Token: 0x06012E4D RID: 77389 RVA: 0x0053A0D3 File Offset: 0x005382D3
	private OneTextTitleItem CreateTitleItem(UUIItem uiItem)
	{
		return new OneTextTitleItem(uiItem);
	}

	// Token: 0x040093A3 RID: 37795
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private CommonDropDown<TableTextArgNew, PhotoDropDown> DropDown;

	// Token: 0x0200891F RID: 35103
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402E454 RID: 189524
		ItemDropDown,
		// Token: 0x0402E455 RID: 189525
		TxtTitle,
		// Token: 0x0402E456 RID: 189526
		TextResolution
	}
}
