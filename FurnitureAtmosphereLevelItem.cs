using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.SpringManor;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001083 RID: 4227
public class FurnitureAtmosphereLevelItem : UiPanelBase
{
	// Token: 0x06006E05 RID: 28165 RVA: 0x001C95D8 File Offset: 0x001C77D8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIArtText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUISliderComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(7, new Action(this.OnItemButtonClick))
		};
	}

	// Token: 0x06006E06 RID: 28166 RVA: 0x001C96C3 File Offset: 0x001C78C3
	[NullableContext(1)]
	public void Refresh(IFurnitureAtmosphereLevelData data)
	{
		this.Data = data;
		this.RefreshAtmosphereArt();
		this.RefreshProgress();
		this.RefreshBg(this.Data.Level);
	}

	// Token: 0x06006E07 RID: 28167 RVA: 0x001C96EC File Offset: 0x001C78EC
	private void RefreshAtmosphereArt()
	{
		if (this.Data == null)
		{
			return;
		}
		base.GetArtText(3).SetText(this.Data.Level.ToString());
	}

	// Token: 0x06006E08 RID: 28168 RVA: 0x001C9724 File Offset: 0x001C7924
	private void RefreshProgress()
	{
		if (this.Data == null)
		{
			return;
		}
		SpringManorConfig instance = ConfigBase<SpringManorConfig>.Instance;
		AtmosphereLevel? atmosphereLevel = (instance != null) ? instance.GetLevelConfigById(this.Data.Level) : null;
		if (atmosphereLevel == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SpringManor;
			ELogAuthor author = ELogAuthor.LJ;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
			defaultInterpolatedStringHandler.AppendLiteral("获取不到等级配置！");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.Data.Level);
			instance2.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int num = Singleton<MathUtils>.Instance.Clamp((this.Data.CurLevelAtmosphere - atmosphereLevel.Value.AtmosphereNeed) / atmosphereLevel.Value.AtmosphereNext, 0, 1);
		base.GetSlider(5).SetValue((float)num, true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "Spring26_MainHud_PassProgress", new <>z__ReadOnlyArray<object>(new object[]
		{
			this.Data.CurLevelAtmosphere,
			this.Data.CurLevelMaxAtmosphere
		}));
	}

	// Token: 0x06006E09 RID: 28169 RVA: 0x001C9844 File Offset: 0x001C7A44
	public void RefreshBg(int level)
	{
		int num = 1;
		foreach (int num2 in SpringManorDefine.atmosphereLevelList)
		{
			if (level < num2)
			{
				break;
			}
			num++;
		}
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			item.SetUIActive(num == 1);
		}
		UUIItem item2 = base.GetItem(1);
		if (item2 != null)
		{
			item2.SetUIActive(num == 2);
		}
		UUIItem item3 = base.GetItem(2);
		if (item3 == null)
		{
			return;
		}
		item3.SetUIActive(num == 3);
	}

	// Token: 0x06006E0A RID: 28170 RVA: 0x001C98DC File Offset: 0x001C7ADC
	private void OnItemButtonClick()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SpringManorAtmosphereLevelView, null, null);
	}

	// Token: 0x04003454 RID: 13396
	[Nullable(2)]
	private IFurnitureAtmosphereLevelData Data;
}
