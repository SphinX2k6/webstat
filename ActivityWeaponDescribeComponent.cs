using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020015FB RID: 5627
public class ActivityWeaponDescribeComponent : UiPanelBase
{
	// Token: 0x06009E92 RID: 40594 RVA: 0x00297EA0 File Offset: 0x002960A0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.LookButtonClicked));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009E93 RID: 40595 RVA: 0x00297FEC File Offset: 0x002961EC
	protected override void OnStart()
	{
		this.StarLayout = new SimpleGenericLayout(base.GetHorizontalLayout(2));
		UUITexture texture = base.GetTexture(3);
		if (texture != null)
		{
			texture.SetUIActive(false);
		}
		UUISprite sprite = base.GetSprite(5);
		if (sprite != null)
		{
			sprite.SetUIActive(true);
		}
		this.SetLookButtonVisible(false);
	}

	// Token: 0x06009E94 RID: 40596 RVA: 0x00298038 File Offset: 0x00296238
	public void Refresh(int weaponId, bool isUp = false)
	{
		WeaponConf? weaponConfigByItemId = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(weaponId);
		if (weaponConfigByItemId == null)
		{
			return;
		}
		base.GetText(0).ShowTextNew(weaponConfigByItemId.Value.WeaponName);
		base.GetItem(1).SetUIActive(isUp);
		this.UpdateWeaponIcon(weaponConfigByItemId.Value.WeaponType);
		this.UpdateQuality(weaponConfigByItemId.Value.QualityId);
	}

	// Token: 0x06009E95 RID: 40597 RVA: 0x002980B0 File Offset: 0x002962B0
	private void UpdateQuality(int quality)
	{
		this.StarLayout.RebuildLayout(quality);
		UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 1);
		defaultInterpolatedStringHandler.AppendLiteral("SP_WeaponAttributeQualityBg");
		defaultInterpolatedStringHandler.AppendFormatted<int>(quality);
		string resourcePath = instance.GetResourcePath(defaultInterpolatedStringHandler.ToStringAndClear());
		if (string.IsNullOrEmpty(resourcePath))
		{
			return;
		}
		this.SetSpriteByPath(resourcePath, base.GetSprite(4), false, null, null);
	}

	// Token: 0x06009E96 RID: 40598 RVA: 0x0029811C File Offset: 0x0029631C
	private void UpdateWeaponIcon(int weaponType)
	{
		foreach (Mapping mapping in ConfigBase<MappingConfig>.Instance.GetWeaponConfList())
		{
			if (weaponType == mapping.Value)
			{
				this.SetSpriteByPath(mapping.Icon, base.GetSprite(5), false, null, null);
				break;
			}
		}
	}

	// Token: 0x06009E97 RID: 40599 RVA: 0x00298194 File Offset: 0x00296394
	private void LookButtonClicked()
	{
		Action buttonFunction = this.ButtonFunction;
		if (buttonFunction == null)
		{
			return;
		}
		buttonFunction();
	}

	// Token: 0x06009E98 RID: 40600 RVA: 0x002981A6 File Offset: 0x002963A6
	[NullableContext(1)]
	public void BindButtonFunction(Action func)
	{
		this.ButtonFunction = func;
	}

	// Token: 0x06009E99 RID: 40601 RVA: 0x002981B0 File Offset: 0x002963B0
	public void SetLookButtonVisible(bool bVisible)
	{
		UUIButtonComponent button = base.GetButton(6);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(bVisible);
	}

	// Token: 0x06009E9A RID: 40602 RVA: 0x002981DC File Offset: 0x002963DC
	[NullableContext(1)]
	public void BindWeaponPreviewFunction(int[] previewWeaponIdList, int selectedIndex = 0)
	{
		Action func = delegate()
		{
			if (previewWeaponIdList.Length == 0)
			{
				return;
			}
			List<WeaponTrialData> list = new List<WeaponTrialData>();
			foreach (int trialId in previewWeaponIdList)
			{
				WeaponTrialData weaponTrialData = new WeaponTrialData();
				weaponTrialData.SetTrialId(trialId, true);
				list.Add(weaponTrialData);
			}
			WeaponPreviewViewParam weaponPreviewViewParam = new WeaponPreviewViewParam();
			WeaponDataBase[] weaponDataList = list.ToArray();
			weaponPreviewViewParam.WeaponDataList = weaponDataList;
			weaponPreviewViewParam.SelectedIndex = selectedIndex;
			WeaponPreviewViewParam param = weaponPreviewViewParam;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.WeaponPreviewView, param, null);
		};
		this.BindButtonFunction(func);
	}

	// Token: 0x040048EE RID: 18670
	[Nullable(2)]
	private Action ButtonFunction;

	// Token: 0x040048EF RID: 18671
	[Nullable(2)]
	private SimpleGenericLayout StarLayout;

	// Token: 0x020079BA RID: 31162
	private class EComponent
	{
		// Token: 0x04029CC6 RID: 171206
		public const int NameText = 0;

		// Token: 0x04029CC7 RID: 171207
		public const int UpItem = 1;

		// Token: 0x04029CC8 RID: 171208
		public const int StarLayout = 2;

		// Token: 0x04029CC9 RID: 171209
		public const int WeaponIconTexture = 3;

		// Token: 0x04029CCA RID: 171210
		public const int WeaponBgSprite = 4;

		// Token: 0x04029CCB RID: 171211
		public const int WeaponIconSprite = 5;

		// Token: 0x04029CCC RID: 171212
		public const int LookButton = 6;
	}
}
