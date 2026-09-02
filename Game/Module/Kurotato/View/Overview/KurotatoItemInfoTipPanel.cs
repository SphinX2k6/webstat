using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Module.Kurotato.View.AttrSelect;
using CSharpScript.Game.Module.Kurotato.View.PopupItemDetail;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Overview
{
	// Token: 0x02005A99 RID: 23193
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoItemInfoTipPanel : UiPanelBase
	{
		// Token: 0x0603AAE6 RID: 240358 RVA: 0x00EDEBB0 File Offset: 0x00EDCDB0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 25;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603AAE7 RID: 240359 RVA: 0x00EDEF24 File Offset: 0x00EDD124
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoItemInfoTipPanel.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoItemInfoTipPanel.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AAE8 RID: 240360 RVA: 0x00EDEF67 File Offset: 0x00EDD167
		private void CreateAttrSelectLayout()
		{
			this.PropertyLayout = new GenericLayout<PropertyInfoItem, IKurotatoAttrDisplay>(base.GetVerticalLayout(3), () => new PropertyInfoItem(), null, false, true);
		}

		// Token: 0x0603AAE9 RID: 240361 RVA: 0x00EDEFA0 File Offset: 0x00EDD1A0
		private UniTask CreateToggleTabItemAsync()
		{
			KurotatoItemInfoTipPanel.<CreateToggleTabItemAsync>d__17 <CreateToggleTabItemAsync>d__;
			<CreateToggleTabItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateToggleTabItemAsync>d__.<>4__this = this;
			<CreateToggleTabItemAsync>d__.<>1__state = -1;
			<CreateToggleTabItemAsync>d__.<>t__builder.Start<KurotatoItemInfoTipPanel.<CreateToggleTabItemAsync>d__17>(ref <CreateToggleTabItemAsync>d__);
			return <CreateToggleTabItemAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AAEA RID: 240362 RVA: 0x00EDEFE4 File Offset: 0x00EDD1E4
		private UniTask CreateLockPanelAsync()
		{
			KurotatoItemInfoTipPanel.<CreateLockPanelAsync>d__18 <CreateLockPanelAsync>d__;
			<CreateLockPanelAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateLockPanelAsync>d__.<>4__this = this;
			<CreateLockPanelAsync>d__.<>1__state = -1;
			<CreateLockPanelAsync>d__.<>t__builder.Start<KurotatoItemInfoTipPanel.<CreateLockPanelAsync>d__18>(ref <CreateLockPanelAsync>d__);
			return <CreateLockPanelAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AAEB RID: 240363 RVA: 0x00EDF028 File Offset: 0x00EDD228
		private void CreateBuildInfoPanel()
		{
			this.BuildLeftInfoLayout = new GenericLayout<KurotatoPopupWeaponBuildItem, IKurotatoWeaponBuildInfoPanel>(base.GetVerticalLayout(11), () => new KurotatoPopupWeaponBuildItem(), null, false, true);
			this.BuildRightInfoLayout = new GenericLayout<KurotatoPopupWeaponBuildItem, IKurotatoWeaponBuildInfoPanel>(base.GetVerticalLayout(12), () => new KurotatoPopupWeaponBuildItem(), null, false, true);
		}

		// Token: 0x0603AAEC RID: 240364 RVA: 0x00EDF0A0 File Offset: 0x00EDD2A0
		private UniTask CreateBuildTagItemAsync()
		{
			KurotatoItemInfoTipPanel.<CreateBuildTagItemAsync>d__20 <CreateBuildTagItemAsync>d__;
			<CreateBuildTagItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateBuildTagItemAsync>d__.<>4__this = this;
			<CreateBuildTagItemAsync>d__.<>1__state = -1;
			<CreateBuildTagItemAsync>d__.<>t__builder.Start<KurotatoItemInfoTipPanel.<CreateBuildTagItemAsync>d__20>(ref <CreateBuildTagItemAsync>d__);
			return <CreateBuildTagItemAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AAED RID: 240365 RVA: 0x00EDF0E3 File Offset: 0x00EDD2E3
		private void CreateSkillLayout()
		{
			this.SkillLayout = new GenericLayout<SkillItem, string>(base.GetVerticalLayout(15), () => new SkillItem(), null, false, true);
		}

		// Token: 0x0603AAEE RID: 240366 RVA: 0x00EDF11A File Offset: 0x00EDD31A
		protected override void OnStart()
		{
			this.ToggleTabItem.SetUiActive(false);
		}

		// Token: 0x0603AAEF RID: 240367 RVA: 0x00EDF128 File Offset: 0x00EDD328
		public void RefreshBuildInfoByCheckedTags()
		{
			if (!this.BuildTagItem.IsChecked())
			{
				this.CloseBuildInfo();
				return;
			}
			List<IKurotatoWeaponBuildData> dataList = this.BuildTagItem.GetDataList();
			if (dataList == null || dataList.Count == 0)
			{
				this.CloseBuildInfo();
				return;
			}
			List<IKurotatoWeaponBuildInfoPanel> data = (from tagData in dataList
			select new KurotatoWeaponBuildInfoPanel
			{
				BuildId = tagData.BuildId,
				BuildLevel = ModelBase<KurotatoModel>.Instance.GetWeaponBuildLevelByBuildId(tagData.BuildId)
			}).ToList<IKurotatoWeaponBuildInfoPanel>();
			if (this.TipShowLeft)
			{
				this.ShowBuildInfoLeft(data);
				return;
			}
			this.ShowBuildInfoRight(data);
		}

		// Token: 0x0603AAF0 RID: 240368 RVA: 0x00EDF1A9 File Offset: 0x00EDD3A9
		public void ShowBuildInfoLeft(IReadOnlyList<IKurotatoWeaponBuildInfoPanel> data)
		{
			this.BuildLeftInfoLayout.SetActive(true);
			this.BuildRightInfoLayout.SetActive(false);
			this.BuildLeftInfoLayout.RefreshByData(data, null, false);
		}

		// Token: 0x0603AAF1 RID: 240369 RVA: 0x00EDF1D1 File Offset: 0x00EDD3D1
		public void ShowBuildInfoRight(IReadOnlyList<IKurotatoWeaponBuildInfoPanel> data)
		{
			this.BuildRightInfoLayout.SetActive(true);
			this.BuildLeftInfoLayout.SetActive(false);
			this.BuildRightInfoLayout.RefreshByData(data, null, false);
		}

		// Token: 0x0603AAF2 RID: 240370 RVA: 0x00EDF1F9 File Offset: 0x00EDD3F9
		public void CloseBuildInfo()
		{
			this.BuildLeftInfoLayout.SetActive(false);
			this.BuildRightInfoLayout.SetActive(false);
		}

		// Token: 0x0603AAF3 RID: 240371 RVA: 0x00EDF213 File Offset: 0x00EDD413
		private void OnClickBuildTag(IReadOnlyList<IKurotatoWeaponBuildData> dataList, EToggleState state)
		{
			this.RefreshBuildInfoByCheckedTags();
		}

		// Token: 0x0603AAF4 RID: 240372 RVA: 0x00EDF21B File Offset: 0x00EDD41B
		public void Refresh(EKurotatoCardType selectedType, int selectedId, bool tipShowLeft = true, bool showBuildInfo = true, int? preWaveDealtDamage = null)
		{
			this.SelectedType = selectedType;
			this.SelectedId = selectedId;
			this.TipShowLeft = tipShowLeft;
			this.PreWaveDealtDamage = preWaveDealtDamage;
			this.RefreshInfo(showBuildInfo);
		}

		// Token: 0x0603AAF5 RID: 240373 RVA: 0x00EDF242 File Offset: 0x00EDD442
		private void RefreshInfo(bool showBuildInfo = true)
		{
			this.CloseBuildInfo();
			this.BuildTagItem.SetChecked(false);
			if (this.SelectedId <= 0)
			{
				return;
			}
			if (this.SelectedType == EKurotatoCardType.Weapon)
			{
				this.RefreshWeaponInfo(showBuildInfo);
				return;
			}
			this.RefreshItemInfo();
		}

		// Token: 0x0603AAF6 RID: 240374 RVA: 0x00EDF278 File Offset: 0x00EDD478
		private void RefreshItemInfo()
		{
			KurotatoConfig instance = ConfigBase<KurotatoConfig>.Instance;
			KurotatoItem value = instance.GetItemConfigByItemId(this.SelectedId).Value;
			KurotatoQuality value2 = instance.GetQualityByQuality(value.Quality).Value;
			this.BuildTagItem.SetUiActive(false);
			base.GetItem(9).SetUIActive(!StringUtils.IsEmpty(value.Tag));
			base.GetText(0).ShowTextNew(value.Name);
			base.GetText(1).ShowTextNew(value2.QualityName);
			base.GetText(1).SetColor(FColor.FromHex(value2.QualityColor));
			base.SetTextureByPath(value2.InfoQualityTexture, base.GetTexture(17), null, null);
			base.SetTextureByPath(value.Icon, base.GetTexture(2), null, null);
			List<IKurotatoAttrDisplay> itemAttrDisplayList = KurotatoUtil.GetItemAttrDisplayList(value.EffectIter().ToList<int>(), false, false, true);
			this.PropertyLayout.RefreshByData(itemAttrDisplayList, null, false);
			string cardDesc = KurotatoUtil.GetCardDesc(value.Desc, value.DescParamsIter().ToList<string>(), 0, 0, false);
			bool flag = cardDesc != "";
			GenericLayout<SkillItem, string> skillLayout = this.SkillLayout;
			List<string> data;
			if (!flag)
			{
				data = new List<string>();
			}
			else
			{
				(data = new List<string>()).Add(cardDesc);
			}
			skillLayout.RefreshByData(data, null, false);
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(itemAttrDisplayList.Count > 0 && flag);
			}
			if (!StringUtils.IsEmpty(value.Tag))
			{
				base.GetText(10).ShowTextNew(value.Tag);
			}
			base.GetItem(18).SetUIActive(false);
			this.RefreshBgDesc(value.BgDesc);
			if (this.IsInHandBook)
			{
				KurotatoItemData kurotatoItemData = ControllerBase<KurotatoActivityController>.Instance.GetActivityData().GetKurotatoItemData(this.SelectedId);
				FunctionalPanelConditionLock lockPanel = this.LockPanel;
				if (lockPanel != null)
				{
					lockPanel.SetUiActive(!kurotatoItemData.IsUnLock);
				}
				UUISprite sprite = base.GetSprite(20);
				if (sprite != null)
				{
					sprite.SetUIActive(!kurotatoItemData.IsUnLock);
				}
				if (!kurotatoItemData.IsUnLock)
				{
					string conditionGroupHintText = LevelGeneralCommons.GetConditionGroupHintText(kurotatoItemData.ConditionId);
					FunctionalPanelConditionLock lockPanel2 = this.LockPanel;
					if (lockPanel2 == null)
					{
						return;
					}
					lockPanel2.SetTextByTextId(conditionGroupHintText, Array.Empty<string>());
				}
			}
		}

		// Token: 0x0603AAF7 RID: 240375 RVA: 0x00EDF4AC File Offset: 0x00EDD6AC
		private void RefreshWeaponInfo(bool showBuildInfo = true)
		{
			KurotatoConfig instance = ConfigBase<KurotatoConfig>.Instance;
			KurotatoModel kurotatoModel = ModelBase<KurotatoModel>.Instance;
			IKurotatoWeaponData weaponDataByIncId = kurotatoModel.GetWeaponDataByIncId(this.SelectedId);
			bool flag = !this.IsOutside && weaponDataByIncId != null;
			int weaponId = flag ? weaponDataByIncId.WeaponId : this.SelectedId;
			KurotatoWeapon value = instance.GetWeaponConfigByWeaponId(weaponId).Value;
			KurotatoWeaponGroup value2 = instance.GetWeaponGroupConfigByWeaponId(weaponId).Value;
			KurotatoQuality value3 = instance.GetQualityByQuality(value.Quality).Value;
			bool flag2 = value2.WeaponBuildIdsIter().Any<int>();
			this.BuildTagItem.SetUiActive(flag2);
			base.GetItem(9).SetUIActive(false);
			base.GetText(0).ShowTextNew(value.Name);
			base.GetText(1).ShowTextNew(value3.QualityName);
			base.GetText(1).SetColor(FColor.FromHex(value3.QualityColor));
			base.SetTextureByPath(value3.InfoQualityTexture, base.GetTexture(17), null, null);
			base.SetTextureByPath(value2.Icon, base.GetTexture(2), null, null);
			int weaponIncId = flag ? this.SelectedId : 0;
			List<IKurotatoAttrDisplay> weaponPropertyDisplayList = KurotatoUtil.GetWeaponPropertyDisplayList(value.ShowPropertyIter().ToList<int>(), weaponId, weaponIncId);
			if (!StringUtils.IsEmpty(value.AttackDes))
			{
				string cardDesc = KurotatoUtil.GetCardDesc(value.AttackDes, value.AttackDesParamIter().ToList<string>(), weaponId, weaponIncId, true);
				KurotatoProperty? propertyById = instance.GetPropertyById(7);
				weaponPropertyDisplayList.Insert(0, new KurotatoAttrDisplay
				{
					Icon = (((propertyById != null) ? propertyById.GetValueOrDefault().Icon : null) ?? ""),
					Text = cardDesc,
					PropertyId = ((propertyById != null) ? propertyById.GetValueOrDefault().Id : 0)
				});
			}
			this.PropertyLayout.RefreshByData(weaponPropertyDisplayList, null, false);
			string cardDesc2 = KurotatoUtil.GetCardDesc(value.Desc, value.DescParamsIter().ToList<string>(), weaponId, weaponIncId, false);
			bool flag3 = cardDesc2 != "";
			GenericLayout<SkillItem, string> skillLayout = this.SkillLayout;
			List<string> data;
			if (!flag3)
			{
				data = new List<string>();
			}
			else
			{
				(data = new List<string>()).Add(cardDesc2);
			}
			skillLayout.RefreshByData(data, null, false);
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(weaponPropertyDisplayList.Count > 0 && flag3);
			}
			if (showBuildInfo)
			{
				this.ShowBuildInfoLeft((from buildId in value2.WeaponBuildIdsIter()
				select new KurotatoWeaponBuildInfoPanel
				{
					BuildId = buildId,
					BuildLevel = kurotatoModel.GetWeaponBuildLevelByBuildId(buildId)
				}).ToList<IKurotatoWeaponBuildInfoPanel>());
			}
			if (flag2)
			{
				this.BuildTagItem.Refresh((from buildId in value2.WeaponBuildIdsIter()
				select new KurotatoWeaponBuildData
				{
					BuildId = buildId,
					WeaponId = weaponId
				}).ToList<IKurotatoWeaponBuildData>());
			}
			base.GetItem(18).SetUIActive(!this.IsOutside || this.PreWaveDealtDamage != null);
			int num = this.PreWaveDealtDamage ?? ((weaponDataByIncId != null) ? weaponDataByIncId.PreWaveDealtDamage : 0);
			base.GetText(19).SetText(num.ToString(), true);
			this.RefreshBgDesc(value.BgDesc);
			if (this.IsInHandBook)
			{
				KurotatoWeaponData kurotatoWeaponData = ControllerBase<KurotatoActivityController>.Instance.GetActivityData().GetKurotatoWeaponData(this.SelectedId);
				FunctionalPanelConditionLock lockPanel = this.LockPanel;
				if (lockPanel != null)
				{
					lockPanel.SetUiActive(!kurotatoWeaponData.IsUnLock);
				}
				UUISprite sprite = base.GetSprite(20);
				if (sprite != null)
				{
					sprite.SetUIActive(!kurotatoWeaponData.IsUnLock);
				}
				if (!kurotatoWeaponData.IsUnLock)
				{
					string conditionGroupHintText = LevelGeneralCommons.GetConditionGroupHintText(kurotatoWeaponData.ConditionId);
					FunctionalPanelConditionLock lockPanel2 = this.LockPanel;
					if (lockPanel2 == null)
					{
						return;
					}
					lockPanel2.SetTextByTextId(conditionGroupHintText, Array.Empty<string>());
				}
			}
		}

		// Token: 0x0603AAF8 RID: 240376 RVA: 0x00EDF888 File Offset: 0x00EDDA88
		private void RefreshBgDesc(string text)
		{
			bool flag = text == "";
			UUIItem item = base.GetItem(21);
			if (item != null)
			{
				item.SetUIActive(!flag && this.IsInHandBook);
			}
			UUIItem item2 = base.GetItem(22);
			if (item2 != null)
			{
				item2.SetUIActive(!flag && this.IsInHandBook);
			}
			if (flag)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(23), text, Array.Empty<object>());
		}

		// Token: 0x040212E5 RID: 135909
		private readonly PopupCaptionToggleItem ToggleTabItem = new PopupCaptionToggleItem();

		// Token: 0x040212E6 RID: 135910
		private readonly FunctionalPanelConditionLock LockPanel = new FunctionalPanelConditionLock();

		// Token: 0x040212E7 RID: 135911
		private readonly KurotatoWeaponTagItem BuildTagItem = new KurotatoWeaponTagItem();

		// Token: 0x040212E8 RID: 135912
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<PropertyInfoItem, IKurotatoAttrDisplay> PropertyLayout;

		// Token: 0x040212E9 RID: 135913
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<KurotatoPopupWeaponBuildItem, IKurotatoWeaponBuildInfoPanel> BuildLeftInfoLayout;

		// Token: 0x040212EA RID: 135914
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<KurotatoPopupWeaponBuildItem, IKurotatoWeaponBuildInfoPanel> BuildRightInfoLayout;

		// Token: 0x040212EB RID: 135915
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<SkillItem, string> SkillLayout;

		// Token: 0x040212EC RID: 135916
		private EKurotatoCardType SelectedType;

		// Token: 0x040212ED RID: 135917
		private int SelectedId;

		// Token: 0x040212EE RID: 135918
		private bool TipShowLeft = true;

		// Token: 0x040212EF RID: 135919
		private int? PreWaveDealtDamage;

		// Token: 0x040212F0 RID: 135920
		public bool IsOutside;

		// Token: 0x040212F1 RID: 135921
		public bool IsInHandBook;

		// Token: 0x0200BA8D RID: 47757
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x04039996 RID: 235926
			TextName,
			// Token: 0x04039997 RID: 235927
			TextQuality,
			// Token: 0x04039998 RID: 235928
			TextureIcon,
			// Token: 0x04039999 RID: 235929
			VerticalLayoutAttr,
			// Token: 0x0403999A RID: 235930
			AttrItem,
			// Token: 0x0403999B RID: 235931
			ItemMiddleLine,
			// Token: 0x0403999C RID: 235932
			PanelTag,
			// Token: 0x0403999D RID: 235933
			ItemTog,
			// Token: 0x0403999E RID: 235934
			ToggleTabNameItem,
			// Token: 0x0403999F RID: 235935
			PanelType,
			// Token: 0x040399A0 RID: 235936
			TextType,
			// Token: 0x040399A1 RID: 235937
			PanelTipsLeft,
			// Token: 0x040399A2 RID: 235938
			PanelTipsRight,
			// Token: 0x040399A3 RID: 235939
			TagTipLeftItem,
			// Token: 0x040399A4 RID: 235940
			TagTipRightItem,
			// Token: 0x040399A5 RID: 235941
			VerticalSkillData,
			// Token: 0x040399A6 RID: 235942
			SkillInfo,
			// Token: 0x040399A7 RID: 235943
			TextureQuality,
			// Token: 0x040399A8 RID: 235944
			PanelHarm,
			// Token: 0x040399A9 RID: 235945
			TextHarm,
			// Token: 0x040399AA RID: 235946
			SpriteLockIcon,
			// Token: 0x040399AB RID: 235947
			ItemBgDescLine,
			// Token: 0x040399AC RID: 235948
			ItemBgDescPanel,
			// Token: 0x040399AD RID: 235949
			TextBgDesc,
			// Token: 0x040399AE RID: 235950
			ItemLockPanel
		}
	}
}
