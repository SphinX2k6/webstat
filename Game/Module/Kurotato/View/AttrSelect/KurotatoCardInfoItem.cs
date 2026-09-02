using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.Kurotato.View.PopupItemDetail;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.AttrSelect
{
	// Token: 0x02005ACC RID: 23244
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoCardInfoItem : UiPanelBase
	{
		// Token: 0x0603AC5A RID: 240730 RVA: 0x00EE6E68 File Offset: 0x00EE5068
		protected unsafe override void OnRegisterComponent()
		{
			int num = 31;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIMultiTemplateScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(24, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(25, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(27, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(28, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(29, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(30, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(7, new Action<EToggleState>(this.OnToggleClickLock));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(29, new Action<EToggleState>(this.OnTogglePreviewState));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603AC5B RID: 240731 RVA: 0x00EE7308 File Offset: 0x00EE5508
		protected override void OnStart()
		{
			this.CreateAttrMultiScrollView();
			this.CreateBuildInfoPanel();
			this.RegisterTextPropTermExplanation();
			this.CloseBuildInfo();
			UUIExtendToggle extendToggle = base.GetExtendToggle(29);
			if (extendToggle != null)
			{
				extendToggle.OnPointEnterCallBack.Bind(new Action<EToggleState>(this.OnPreviewHoverEnter));
			}
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.OnPointExitCallBack.Bind(new Action<EToggleState>(this.OnPreviewHoverExit));
		}

		// Token: 0x0603AC5C RID: 240732 RVA: 0x00EE736D File Offset: 0x00EE556D
		protected override void OnBeforeDestroy()
		{
			Action<bool, IReadOnlyList<IKurotatoAttrPreviewDelta>> attrPreviewCb = this.AttrPreviewCb;
			if (attrPreviewCb == null)
			{
				return;
			}
			attrPreviewCb(false, new List<IKurotatoAttrPreviewDelta>());
		}

		// Token: 0x0603AC5D RID: 240733 RVA: 0x00EE7388 File Offset: 0x00EE5588
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoCardInfoItem.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoCardInfoItem.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AC5E RID: 240734 RVA: 0x00EE73CC File Offset: 0x00EE55CC
		private void RegisterTextPropTermExplanation()
		{
			TermExplanationRegistryParam param = new TermExplanationRegistryParam
			{
				UiText = base.GetText(3),
				ViewType = ETermExplanationViewType.Center,
				ReportType = ETermExplanationReportType.Kurotato
			};
			ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
		}

		// Token: 0x0603AC5F RID: 240735 RVA: 0x00EE7408 File Offset: 0x00EE5608
		private UniTask CreateBuildTagItem()
		{
			KurotatoCardInfoItem.<CreateBuildTagItem>d__16 <CreateBuildTagItem>d__;
			<CreateBuildTagItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateBuildTagItem>d__.<>4__this = this;
			<CreateBuildTagItem>d__.<>1__state = -1;
			<CreateBuildTagItem>d__.<>t__builder.Start<KurotatoCardInfoItem.<CreateBuildTagItem>d__16>(ref <CreateBuildTagItem>d__);
			return <CreateBuildTagItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603AC60 RID: 240736 RVA: 0x00EE744B File Offset: 0x00EE564B
		private void CreateAttrMultiScrollView()
		{
			this.AttrMultiScrollView = new MultiTemplateScrollView(base.GetMultiTemplateScrollViewComponent(4));
		}

		// Token: 0x0603AC61 RID: 240737 RVA: 0x00EE7460 File Offset: 0x00EE5660
		private void CreateBuildInfoPanel()
		{
			this.BuildLeftInfoLayout = new GenericLayout<KurotatoPopupWeaponBuildItem, IKurotatoWeaponBuildInfoPanel>(base.GetVerticalLayout(13), () => new KurotatoPopupWeaponBuildItem(), null, false, true);
			this.BuildRightInfoLayout = new GenericLayout<KurotatoPopupWeaponBuildItem, IKurotatoWeaponBuildInfoPanel>(base.GetVerticalLayout(14), () => new KurotatoPopupWeaponBuildItem(), null, false, true);
		}

		// Token: 0x0603AC62 RID: 240738 RVA: 0x00EE74D7 File Offset: 0x00EE56D7
		public void Refresh(IKurotatoCardItemData data)
		{
			this.Data = data;
			if (data.CardType == EKurotatoCardType.Weapon)
			{
				this.RefreshWeaponData();
				return;
			}
			this.RefreshItemInfo();
		}

		// Token: 0x0603AC63 RID: 240739 RVA: 0x00EE74F5 File Offset: 0x00EE56F5
		public void SetLockToggleCb(Action<int, bool> cb)
		{
			this.LockToggleCb = cb;
		}

		// Token: 0x0603AC64 RID: 240740 RVA: 0x00EE74FE File Offset: 0x00EE56FE
		public void SetBuildTagClickCb(Action<EToggleState> cb)
		{
			this.BuildTagClickCb = cb;
		}

		// Token: 0x0603AC65 RID: 240741 RVA: 0x00EE7507 File Offset: 0x00EE5707
		public void SetAttrPreviewCb(Action<bool, IReadOnlyList<IKurotatoAttrPreviewDelta>> cb)
		{
			this.AttrPreviewCb = cb;
		}

		// Token: 0x0603AC66 RID: 240742 RVA: 0x00EE7510 File Offset: 0x00EE5710
		public void ClearAttrPreviewSelection()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(29);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0603AC67 RID: 240743 RVA: 0x00EE7528 File Offset: 0x00EE5728
		private void OnTogglePreviewState(EToggleState state)
		{
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				return;
			}
			if (state == EToggleState.ETT_Checked)
			{
				Action<bool, IReadOnlyList<IKurotatoAttrPreviewDelta>> attrPreviewCb = this.AttrPreviewCb;
				if (attrPreviewCb == null)
				{
					return;
				}
				attrPreviewCb(true, this.BuildPreviewDeltas());
				return;
			}
			else
			{
				Action<bool, IReadOnlyList<IKurotatoAttrPreviewDelta>> attrPreviewCb2 = this.AttrPreviewCb;
				if (attrPreviewCb2 == null)
				{
					return;
				}
				attrPreviewCb2(false, new List<IKurotatoAttrPreviewDelta>());
				return;
			}
		}

		// Token: 0x0603AC68 RID: 240744 RVA: 0x00EE7574 File Offset: 0x00EE5774
		private void OnPreviewHoverEnter(EToggleState state)
		{
			if (Singleton<Info>.Instance.IsInTouch())
			{
				return;
			}
			Action<bool, IReadOnlyList<IKurotatoAttrPreviewDelta>> attrPreviewCb = this.AttrPreviewCb;
			if (attrPreviewCb == null)
			{
				return;
			}
			attrPreviewCb(true, this.BuildPreviewDeltas());
		}

		// Token: 0x0603AC69 RID: 240745 RVA: 0x00EE759A File Offset: 0x00EE579A
		private void OnPreviewHoverExit(EToggleState state)
		{
			if (Singleton<Info>.Instance.IsInTouch())
			{
				return;
			}
			Action<bool, IReadOnlyList<IKurotatoAttrPreviewDelta>> attrPreviewCb = this.AttrPreviewCb;
			if (attrPreviewCb == null)
			{
				return;
			}
			attrPreviewCb(false, new List<IKurotatoAttrPreviewDelta>());
		}

		// Token: 0x0603AC6A RID: 240746 RVA: 0x00EE75C0 File Offset: 0x00EE57C0
		private IReadOnlyList<IKurotatoAttrPreviewDelta> BuildPreviewDeltas()
		{
			List<IKurotatoAttrPreviewDelta> list = new List<IKurotatoAttrPreviewDelta>();
			if (this.Data == null || this.Data.CardType == EKurotatoCardType.Weapon)
			{
				return list;
			}
			KurotatoItem? itemConfigByItemId = ConfigBase<KurotatoConfig>.Instance.GetItemConfigByItemId(this.Data.Id);
			if (itemConfigByItemId == null)
			{
				return list;
			}
			foreach (IKurotatoAttrDisplay kurotatoAttrDisplay in KurotatoUtil.GetItemAttrPreviewList(itemConfigByItemId.Value.EffectIter().ToList<int>()))
			{
				list.Add(new KurotatoAttrPreviewDelta
				{
					PropertyId = kurotatoAttrDisplay.PropertyId,
					ValueStr = kurotatoAttrDisplay.Text
				});
			}
			foreach (ValueTuple<int, int> valueTuple in KurotatoUtil.GetItemAttrLockPreviewList(itemConfigByItemId.Value.EffectIter().ToList<int>()))
			{
				list.Add(new KurotatoAttrPreviewDelta
				{
					PropertyId = valueTuple.Item1,
					ValueStr = "",
					LockValue = new int?(valueTuple.Item2)
				});
			}
			return list;
		}

		// Token: 0x0603AC6B RID: 240747 RVA: 0x00EE770C File Offset: 0x00EE590C
		private void RefreshItemInfo()
		{
			KurotatoConfig instance = ConfigBase<KurotatoConfig>.Instance;
			KurotatoItem value = instance.GetItemConfigByItemId(this.Data.Id).Value;
			List<IKurotatoAttrDisplay> itemAttrDisplayList = KurotatoUtil.GetItemAttrDisplayList(value.EffectIter().ToList<int>(), true, true, false);
			string cardDesc = KurotatoUtil.GetCardDesc(value.Desc, value.DescParamsIter().ToList<string>(), 0, 0, false);
			this.AttrScrollDataList.Clear();
			foreach (IKurotatoAttrDisplay data in itemAttrDisplayList)
			{
				this.AttrScrollDataList.Add(new AttrInfoItemData(data));
			}
			this.AttrScrollDataList.Add(new DesItemData(cardDesc));
			MultiTemplateScrollViewRefreshContext context = new MultiTemplateScrollViewRefreshContext(this.AttrScrollDataList);
			this.AttrMultiScrollView.RefreshByData(context);
			this.BuildTagItem.SetUiActive(false);
			bool flag = !StringUtils.IsEmpty(value.Tag);
			base.GetItem(10).SetUIActive(flag);
			base.GetItem(11).SetUIActive(this.Data.HasBuy);
			base.GetSprite(23).SetUIActive(this.Data.HasBuy);
			base.GetText(3).SetUIActive(true);
			base.GetItem(17).SetUIActive(itemAttrDisplayList.Count == 0);
			UUIItem uuiitem = base.GetMultiTemplateScrollViewComponent(4).RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(itemAttrDisplayList.Count > 0);
			}
			KurotatoQuality value2 = instance.GetQualityByQuality(value.Quality).Value;
			base.SetTextureByPath(value2.CardQualityTexture, base.GetTexture(0), null, null);
			base.SetTextureByPath(value.Icon, base.GetTexture(1), null, null);
			base.GetSprite(20).SetColor(FColor.FromHex(value2.QualityBoxColor));
			UUINiagara uiNiagara = base.GetUiNiagara(24);
			if (uiNiagara != null)
			{
				uiNiagara.SetColor(FColor.FromHex(value2.ItemGridNiagaraColor));
			}
			base.GetText(2).ShowTextNew(value.Name);
			base.GetText(2).SetColor(FColor.FromHex(value2.QualityColor));
			base.GetText(3).SetText(KurotatoUtil.GetCardDesc(value.Desc, value.DescParamsIter().ToList<string>(), 0, 0, false), true);
			if (flag)
			{
				base.GetText(12).ShowTextNew(value.Tag);
			}
			base.GetItem(6).SetUIActive(this.Data.IsRecommend);
			base.GetExtendToggle(7).GetRootComponent().SetUIActive(this.Data.ShowLock && !this.Data.HasBuy);
			base.GetExtendToggle(7).SetToggleState(this.Data.HasLock ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked, false, false, false);
			this.RefreshHoldNum();
			base.GetSprite(25).SetUIActive(false);
			base.GetItem(26).SetUIActive(false);
		}

		// Token: 0x0603AC6C RID: 240748 RVA: 0x00EE7A1C File Offset: 0x00EE5C1C
		public void RefreshHoldNum()
		{
			if (this.Data == null || this.Data.CardType == EKurotatoCardType.Weapon)
			{
				return;
			}
			KurotatoItem? itemConfigByItemId = ConfigBase<KurotatoConfig>.Instance.GetItemConfigByItemId(this.Data.Id);
			if (itemConfigByItemId == null)
			{
				return;
			}
			int holdItemCount = ModelBase<KurotatoModel>.Instance.GetHoldItemCount(itemConfigByItemId.Value.Id);
			base.GetItem(22).SetUIActive(itemConfigByItemId.Value.MaxStackCount < 999);
			UUIText text = base.GetText(21);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(holdItemCount);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(itemConfigByItemId.Value.MaxStackCount);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x0603AC6D RID: 240749 RVA: 0x00EE7AE4 File Offset: 0x00EE5CE4
		private void RefreshWeaponData()
		{
			KurotatoConfig instance = ConfigBase<KurotatoConfig>.Instance;
			KurotatoWeapon value = instance.GetWeaponConfigByWeaponId(this.Data.Id).Value;
			KurotatoWeaponGroup value2 = instance.GetWeaponGroupConfigByWeaponId(this.Data.Id).Value;
			bool flag = value2.WeaponBuildIdsIter().Any<int>();
			this.BuildTagItem.SetUiActive(flag);
			base.GetItem(10).SetUIActive(false);
			base.GetItem(11).SetUIActive(this.Data.HasBuy);
			base.GetSprite(23).SetUIActive(this.Data.HasBuy);
			base.GetText(3).SetUIActive(true);
			base.GetItem(17).SetUIActive(false);
			UUIItem uuiitem = base.GetMultiTemplateScrollViewComponent(4).RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(true);
			}
			KurotatoQuality value3 = instance.GetQualityByQuality(value.Quality).Value;
			base.SetTextureByPath(value3.CardQualityTexture, base.GetTexture(0), null, null);
			base.SetTextureByPath(value2.Icon, base.GetTexture(1), null, null);
			base.GetSprite(20).SetColor(FColor.FromHex(value3.QualityBoxColor));
			UUINiagara uiNiagara = base.GetUiNiagara(24);
			if (uiNiagara != null)
			{
				uiNiagara.SetColor(FColor.FromHex(value3.ItemGridNiagaraColor));
			}
			base.GetText(2).ShowTextNew(value.Name);
			base.GetText(2).SetColor(FColor.FromHex(value3.QualityColor));
			base.GetText(3).SetText(KurotatoUtil.GetCardDesc(value.Desc, value.DescParamsIter().ToList<string>(), 0, 0, false), true);
			base.GetItem(6).SetUIActive(this.Data.IsRecommend);
			base.GetExtendToggle(7).GetRootComponent().SetUIActive(this.Data.ShowLock && !this.Data.HasBuy);
			base.GetExtendToggle(7).SetToggleState(this.Data.HasLock ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked, false, false, false);
			base.GetItem(22).SetUIActive(false);
			int id = this.Data.Id;
			List<IKurotatoAttrDisplay> weaponPropertyDisplayList = KurotatoUtil.GetWeaponPropertyDisplayList(value.ShowPropertyIter().ToList<int>(), id, 0);
			if (!string.IsNullOrEmpty(value.AttackDes))
			{
				string cardDesc = KurotatoUtil.GetCardDesc(value.AttackDes, value.AttackDesParamIter().ToList<string>(), id, 0, true);
				KurotatoProperty? propertyById = instance.GetPropertyById(7);
				weaponPropertyDisplayList.Insert(0, new KurotatoAttrDisplay
				{
					Icon = (((propertyById != null) ? propertyById.GetValueOrDefault().Icon : null) ?? ""),
					Text = cardDesc,
					PropertyId = ((propertyById != null) ? propertyById.GetValueOrDefault().Id : 0)
				});
			}
			this.AttrScrollDataList.Clear();
			foreach (IKurotatoAttrDisplay data in weaponPropertyDisplayList)
			{
				this.AttrScrollDataList.Add(new WeaponAttrInfoItemData(data));
			}
			string cardDesc2 = KurotatoUtil.GetCardDesc(value.Desc, value.DescParamsIter().ToList<string>(), id, 0, false);
			this.AttrScrollDataList.Add(new DesItemData(cardDesc2));
			MultiTemplateScrollViewRefreshContext context = new MultiTemplateScrollViewRefreshContext(this.AttrScrollDataList);
			this.AttrMultiScrollView.RefreshByData(context);
			this.CloseBuildInfo();
			List<IKurotatoWeaponBuildData> list = new List<IKurotatoWeaponBuildData>();
			foreach (int buildId in value2.WeaponBuildIdsIter())
			{
				list.Add(new KurotatoWeaponBuildData
				{
					BuildId = buildId,
					WeaponId = this.Data.Id
				});
			}
			this.BuildTagItem.SetChecked(false);
			if (flag)
			{
				this.BuildTagItem.Refresh(list);
			}
			this.SetComposeUpgradeVisible(false);
			base.GetItem(26).SetUIActive(true);
			UUISprite sprite = base.GetSprite(27);
			UUISprite sprite2 = base.GetSprite(28);
			UUIItem uuiitem2 = sprite;
			bool hasBuy = this.Data.HasBuy;
			FColor? fcolor = new FColor?(sprite.changeColor);
			uuiitem2.SetChangeColor(hasBuy, fcolor);
			UUIItem uuiitem3 = sprite2;
			bool hasBuy2 = this.Data.HasBuy;
			fcolor = new FColor?(sprite2.changeColor);
			uuiitem3.SetChangeColor(hasBuy2, fcolor);
		}

		// Token: 0x0603AC6E RID: 240750 RVA: 0x00EE7F70 File Offset: 0x00EE6170
		public void SetComposeUpgradeVisible(bool visible)
		{
			base.GetSprite(25).SetUIActive(visible);
		}

		// Token: 0x0603AC6F RID: 240751 RVA: 0x00EE7F80 File Offset: 0x00EE6180
		public void RefreshBuildTagLevel()
		{
			if (this.Data == null || this.Data.CardType != EKurotatoCardType.Weapon)
			{
				return;
			}
			KurotatoWeaponGroup? weaponGroupConfigByWeaponId = ConfigBase<KurotatoConfig>.Instance.GetWeaponGroupConfigByWeaponId(this.Data.Id);
			if (weaponGroupConfigByWeaponId == null || !weaponGroupConfigByWeaponId.Value.WeaponBuildIdsIter().Any<int>())
			{
				return;
			}
			List<IKurotatoWeaponBuildData> list = new List<IKurotatoWeaponBuildData>();
			foreach (int buildId in weaponGroupConfigByWeaponId.Value.WeaponBuildIdsIter())
			{
				list.Add(new KurotatoWeaponBuildData
				{
					BuildId = buildId,
					WeaponId = this.Data.Id
				});
			}
			this.BuildTagItem.Refresh(list);
			this.RefreshBuildInfoByCheckedTags();
		}

		// Token: 0x0603AC70 RID: 240752 RVA: 0x00EE8058 File Offset: 0x00EE6258
		public void RefreshBuildInfoByCheckedTags()
		{
			if (this.Data.CardType != EKurotatoCardType.Weapon)
			{
				return;
			}
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
			KurotatoModel instance = ModelBase<KurotatoModel>.Instance;
			List<IKurotatoWeaponBuildInfoPanel> list = new List<IKurotatoWeaponBuildInfoPanel>();
			foreach (IKurotatoWeaponBuildData kurotatoWeaponBuildData in dataList)
			{
				list.Add(new KurotatoWeaponBuildInfoPanel
				{
					BuildId = kurotatoWeaponBuildData.BuildId,
					BuildLevel = instance.GetWeaponBuildLevelByBuildId(kurotatoWeaponBuildData.BuildId)
				});
			}
			this.ShowBuildInfoLeft(list);
		}

		// Token: 0x0603AC71 RID: 240753 RVA: 0x00EE8120 File Offset: 0x00EE6320
		public void ClearBuildTagSelection()
		{
			this.BuildTagItem.SetChecked(false);
			this.CloseBuildInfo();
		}

		// Token: 0x0603AC72 RID: 240754 RVA: 0x00EE8134 File Offset: 0x00EE6334
		private void OnClickBuildTag(List<IKurotatoWeaponBuildData> dataList, EToggleState state)
		{
			this.RefreshBuildInfoByCheckedTags();
			Action<EToggleState> buildTagClickCb = this.BuildTagClickCb;
			if (buildTagClickCb == null)
			{
				return;
			}
			buildTagClickCb(state);
		}

		// Token: 0x0603AC73 RID: 240755 RVA: 0x00EE814D File Offset: 0x00EE634D
		public void ShowBuildInfoLeft(List<IKurotatoWeaponBuildInfoPanel> data)
		{
			this.BuildLeftInfoLayout.SetActive(true);
			this.BuildRightInfoLayout.SetActive(false);
			this.BuildLeftInfoLayout.RefreshByData(data, null, false);
		}

		// Token: 0x0603AC74 RID: 240756 RVA: 0x00EE8175 File Offset: 0x00EE6375
		public void ShowBuildInfoRight(List<IKurotatoWeaponBuildInfoPanel> data)
		{
			this.BuildRightInfoLayout.SetActive(true);
			this.BuildLeftInfoLayout.SetActive(false);
			this.BuildRightInfoLayout.RefreshByData(data, null, false);
		}

		// Token: 0x0603AC75 RID: 240757 RVA: 0x00EE819D File Offset: 0x00EE639D
		public void CloseBuildInfo()
		{
			this.BuildLeftInfoLayout.SetActive(false);
			this.BuildRightInfoLayout.SetActive(false);
		}

		// Token: 0x0603AC76 RID: 240758 RVA: 0x00EE81B7 File Offset: 0x00EE63B7
		private void OnToggleClickLock(EToggleState state)
		{
			Action<int, bool> lockToggleCb = this.LockToggleCb;
			if (lockToggleCb == null)
			{
				return;
			}
			lockToggleCb(this.Data.SelectionId, state == EToggleState.ETT_Checked);
		}

		// Token: 0x0603AC77 RID: 240759 RVA: 0x00EE81D8 File Offset: 0x00EE63D8
		public bool HasBuildTag()
		{
			if (this.Data == null || this.Data.CardType != EKurotatoCardType.Weapon)
			{
				return false;
			}
			KurotatoWeaponGroup? weaponGroupConfigByWeaponId = ConfigBase<KurotatoConfig>.Instance.GetWeaponGroupConfigByWeaponId(this.Data.Id);
			return weaponGroupConfigByWeaponId != null && weaponGroupConfigByWeaponId.Value.WeaponBuildIdsIter().Any<int>();
		}

		// Token: 0x0603AC78 RID: 240760 RVA: 0x00EE8234 File Offset: 0x00EE6434
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			string a = configParams[0];
			if (a == "ShopRecommend")
			{
				UUIItem item = base.GetItem(6);
				if (item == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					item,
					item
				};
			}
			else if (a == "ShopCardLock")
			{
				UUIExtendToggle extendToggle = base.GetExtendToggle(7);
				UUIItem uuiitem = (extendToggle != null) ? extendToggle.GetRootComponent() : null;
				if (uuiitem == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					uuiitem,
					uuiitem
				};
			}
			else if (a == "ShopBuildTag")
			{
				UUIExtendToggle extendToggle2 = base.GetExtendToggle(9);
				UUIItem uuiitem2 = (extendToggle2 != null) ? extendToggle2.GetRootComponent() : null;
				if (uuiitem2 == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					uuiitem2,
					uuiitem2
				};
			}
			else
			{
				if (!(a == "ShopCardDes"))
				{
					return null;
				}
				UUIItem item2 = base.GetItem(30);
				if (item2 == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					item2,
					item2
				};
			}
		}

		// Token: 0x04021392 RID: 136082
		private const int INFINITE_STACK_COUNT = 999;

		// Token: 0x04021393 RID: 136083
		[Nullable(2)]
		private IKurotatoCardItemData Data;

		// Token: 0x04021394 RID: 136084
		[Nullable(2)]
		private MultiTemplateScrollView AttrMultiScrollView;

		// Token: 0x04021395 RID: 136085
		private readonly List<IMultiTemplateGridData> AttrScrollDataList = new List<IMultiTemplateGridData>();

		// Token: 0x04021396 RID: 136086
		private readonly KurotatoWeaponTagItem BuildTagItem = new KurotatoWeaponTagItem();

		// Token: 0x04021397 RID: 136087
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<KurotatoPopupWeaponBuildItem, IKurotatoWeaponBuildInfoPanel> BuildLeftInfoLayout;

		// Token: 0x04021398 RID: 136088
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<KurotatoPopupWeaponBuildItem, IKurotatoWeaponBuildInfoPanel> BuildRightInfoLayout;

		// Token: 0x04021399 RID: 136089
		[Nullable(2)]
		private Action<int, bool> LockToggleCb;

		// Token: 0x0402139A RID: 136090
		[Nullable(2)]
		private Action<EToggleState> BuildTagClickCb;

		// Token: 0x0402139B RID: 136091
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Action<bool, IReadOnlyList<IKurotatoAttrPreviewDelta>> AttrPreviewCb;

		// Token: 0x0200BAF1 RID: 47857
		[NullableContext(0)]
		private class EChildComp
		{
			// Token: 0x04039B35 RID: 236341
			public const int TextureQuality = 0;

			// Token: 0x04039B36 RID: 236342
			public const int TextureIcon = 1;

			// Token: 0x04039B37 RID: 236343
			public const int TextName = 2;

			// Token: 0x04039B38 RID: 236344
			public const int TextProp = 3;

			// Token: 0x04039B39 RID: 236345
			public const int MultiTemplateScrollViewInfo = 4;

			// Token: 0x04039B3A RID: 236346
			public const int PanelItemAttr = 5;

			// Token: 0x04039B3B RID: 236347
			public const int PanelRecommend = 6;

			// Token: 0x04039B3C RID: 236348
			public const int ToggleLock = 7;

			// Token: 0x04039B3D RID: 236349
			public const int PanelTag = 8;

			// Token: 0x04039B3E RID: 236350
			public const int ToggleTag = 9;

			// Token: 0x04039B3F RID: 236351
			public const int PanelType = 10;

			// Token: 0x04039B40 RID: 236352
			public const int PanelDone = 11;

			// Token: 0x04039B41 RID: 236353
			public const int TextType = 12;

			// Token: 0x04039B42 RID: 236354
			public const int VerticalTipsLeft = 13;

			// Token: 0x04039B43 RID: 236355
			public const int VerticalTipsRight = 14;

			// Token: 0x04039B44 RID: 236356
			public const int PanelTipsLeft = 15;

			// Token: 0x04039B45 RID: 236357
			public const int PanelTipsRight = 16;

			// Token: 0x04039B46 RID: 236358
			public const int PanelDes = 17;

			// Token: 0x04039B47 RID: 236359
			public const int PanelWeaponAttr = 18;

			// Token: 0x04039B48 RID: 236360
			public const int PanelInfoDes = 19;

			// Token: 0x04039B49 RID: 236361
			public const int SpriteItemBg = 20;

			// Token: 0x04039B4A RID: 236362
			public const int TextLimitNum = 21;

			// Token: 0x04039B4B RID: 236363
			public const int PanelLimitNum = 22;

			// Token: 0x04039B4C RID: 236364
			public const int SpriteDone = 23;

			// Token: 0x04039B4D RID: 236365
			public const int NiagaraFxGlow = 24;

			// Token: 0x04039B4E RID: 236366
			public const int SpriteUpgrade = 25;

			// Token: 0x04039B4F RID: 236367
			public const int PanelWeaponTag = 26;

			// Token: 0x04039B50 RID: 236368
			public const int SpriteWeaponTagBg = 27;

			// Token: 0x04039B51 RID: 236369
			public const int SpriteWeaponTagIcon = 28;

			// Token: 0x04039B52 RID: 236370
			public const int TogglePreview = 29;

			// Token: 0x04039B53 RID: 236371
			public const int DescriptionItem = 30;
		}
	}
}
