using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Common;
using CSharpScript.Game.Ui;

// Token: 0x0200274E RID: 10062
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class RecommendQualityModel : ModelBase<RecommendQualityModel>
{
	// Token: 0x06013DD4 RID: 81364 RVA: 0x00589168 File Offset: 0x00587368
	protected override bool OnInit()
	{
		if (Singleton<CloudGameManager>.Instance.IsCloudGame)
		{
			this.IsFinishRecommendQuality = true;
			EGameQualitySettingLevel? recommendQualityLv = Singleton<GameSettingsDeviceRender>.Instance.GetRecommendQualityLv();
			if (recommendQualityLv == null)
			{
				return false;
			}
			this.SaveApply(recommendQualityLv.Value);
			return true;
		}
		else
		{
			if (Singleton<Info>.Instance.IsHomeConsolePlatform() && !Singleton<Info>.Instance.IsWinGDKPlatform())
			{
				this.IsFinishRecommendQuality = true;
				return true;
			}
			this.IsFinishRecommendQuality = LocalStorage.GetGlobal<bool>(ELocalStorageGlobalKey.IsFinishRecommendQuality, false);
			if (!this.IsFinishRecommendQuality)
			{
				this.InitQualityRangeMap();
				this.InitQualityList();
			}
			return true;
		}
	}

	// Token: 0x06013DD5 RID: 81365 RVA: 0x005891F1 File Offset: 0x005873F1
	protected override bool OnClear()
	{
		return true;
	}

	// Token: 0x06013DD6 RID: 81366 RVA: 0x005891F4 File Offset: 0x005873F4
	public void InitQualityRangeMap()
	{
		this.QualityRangeMap = new Dictionary<EGameQualityRange, List<EGameQualitySettingLevel>>
		{
			{
				EGameQualityRange.Zero2Two,
				new List<EGameQualitySettingLevel>
				{
					EGameQualitySettingLevel.VeryLow,
					EGameQualitySettingLevel.Low,
					EGameQualitySettingLevel.Middle
				}
			},
			{
				EGameQualityRange.One2Three,
				new List<EGameQualitySettingLevel>
				{
					EGameQualitySettingLevel.Low,
					EGameQualitySettingLevel.Middle,
					EGameQualitySettingLevel.High
				}
			},
			{
				EGameQualityRange.Zero2One,
				new List<EGameQualitySettingLevel>
				{
					EGameQualitySettingLevel.Middle,
					EGameQualitySettingLevel.High
				}
			},
			{
				EGameQualityRange.One,
				new List<EGameQualitySettingLevel>
				{
					EGameQualitySettingLevel.High
				}
			},
			{
				EGameQualityRange.Two2Four,
				new List<EGameQualitySettingLevel>
				{
					EGameQualitySettingLevel.Middle,
					EGameQualitySettingLevel.High,
					EGameQualitySettingLevel.VeryHigh
				}
			},
			{
				EGameQualityRange.Three2Five,
				new List<EGameQualitySettingLevel>
				{
					EGameQualitySettingLevel.High,
					EGameQualitySettingLevel.VeryHigh,
					EGameQualitySettingLevel.Highest
				}
			}
		};
	}

	// Token: 0x06013DD7 RID: 81367 RVA: 0x005892C0 File Offset: 0x005874C0
	public void InitQualityList()
	{
		EGameQualityRange qualityRange = Singleton<GameSettingsDeviceRender>.Instance.GetQualityRange();
		List<EGameQualitySettingLevel> list;
		if (this.QualityRangeMap == null || !this.QualityRangeMap.TryGetValue(qualityRange, out list))
		{
			return;
		}
		this.QualityList = new List<IRecommendQualityItemData>();
		MenuConfig? valueOrNull = Singleton<GameSettingsManager>.Instance.ValidApplyConfigMap.GetValueOrNull(EFunction.IMAGEQUALITY);
		string[] array = ((valueOrNull != null) ? valueOrNull.GetValueOrDefault().OptionsName() : null) ?? Array.Empty<string>();
		EGameQualitySettingLevel? recommendQualityLv = Singleton<GameSettingsDeviceRender>.Instance.GetRecommendQualityLv();
		for (int i = 0; i < list.Count; i++)
		{
			EGameQualitySettingLevel egameQualitySettingLevel = list[i];
			string resourceId = "T_LoginSetQuality" + ((int)(egameQualitySettingLevel + 1)).ToString();
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			int[] array2 = (valueOrNull != null) ? valueOrNull.GetValueOrDefault().OptionsValue() : null;
			int num = -1;
			if (array2 != null)
			{
				num = Array.IndexOf<int>(array2, (int)egameQualitySettingLevel);
			}
			RecommendQualityItemData recommendQualityItemData = new RecommendQualityItemData
			{
				Quality = egameQualitySettingLevel,
				Name = ((num >= 0 && num < array.Length) ? array[num] : ((array.Length != 0) ? array[0] : "")),
				IsRecommend = (recommendQualityLv != null && recommendQualityLv.Value == egameQualitySettingLevel),
				Bg = (resourcePath ?? "")
			};
			this.QualityList.Add(recommendQualityItemData);
			if (recommendQualityItemData.IsRecommend)
			{
				this.RecommendQualityIndex = i;
			}
		}
	}

	// Token: 0x06013DD8 RID: 81368 RVA: 0x0058943D File Offset: 0x0058763D
	public List<IRecommendQualityItemData> GetQualityList()
	{
		return this.QualityList ?? new List<IRecommendQualityItemData>();
	}

	// Token: 0x06013DD9 RID: 81369 RVA: 0x0058944E File Offset: 0x0058764E
	public int GetRecommendQualityIndex()
	{
		return this.RecommendQualityIndex;
	}

	// Token: 0x06013DDA RID: 81370 RVA: 0x00589456 File Offset: 0x00587656
	public void SaveApply(EGameQualitySettingLevel quality)
	{
		this.IsNeedApply = true;
		this.NeedApplyQuality = quality;
	}

	// Token: 0x06013DDB RID: 81371 RVA: 0x00589466 File Offset: 0x00587666
	public void FinishRecommendQualityShow()
	{
		LocalStorage.SetGlobal<bool>(ELocalStorageGlobalKey.IsFinishRecommendQuality, true);
	}

	// Token: 0x06013DDC RID: 81372 RVA: 0x00589471 File Offset: 0x00587671
	public void CheckOpenRecommendQuality()
	{
		if (this.IsFinishRecommendQuality || GameSettingsManager.HasImageQualityOrSubSettingLoginOverride())
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.CreateCharacterView, null);
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RecommendQualityView, null, null);
	}

	// Token: 0x04009A7B RID: 39547
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<EGameQualityRange, List<EGameQualitySettingLevel>> QualityRangeMap;

	// Token: 0x04009A7C RID: 39548
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<IRecommendQualityItemData> QualityList;

	// Token: 0x04009A7D RID: 39549
	private int RecommendQualityIndex;

	// Token: 0x04009A7E RID: 39550
	private bool IsFinishRecommendQuality;

	// Token: 0x04009A7F RID: 39551
	public bool IsNeedApply;

	// Token: 0x04009A80 RID: 39552
	public EGameQualitySettingLevel NeedApplyQuality = EGameQualitySettingLevel.Middle;
}
