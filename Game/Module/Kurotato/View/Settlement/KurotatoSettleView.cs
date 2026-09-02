using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.Encircle;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Settlement
{
	// Token: 0x02005A84 RID: 23172
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoSettleView : UiViewBase
	{
		// Token: 0x0603AA08 RID: 240136 RVA: 0x00ED9FD4 File Offset: 0x00ED81D4
		public KurotatoSettleView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603AA09 RID: 240137 RVA: 0x00EDA024 File Offset: 0x00ED8224
		protected unsafe override void OnRegisterComponent()
		{
			int num = 17;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(USpineSkeletonAnimationComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickBtnShare));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickBtnSwitch));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603AA0A RID: 240138 RVA: 0x00EDA2E5 File Offset: 0x00ED84E5
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnFirstShare, new Action(this.OnFirstShare));
		}

		// Token: 0x0603AA0B RID: 240139 RVA: 0x00EDA303 File Offset: 0x00ED8503
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFirstShare, new Action(this.OnFirstShare));
		}

		// Token: 0x0603AA0C RID: 240140 RVA: 0x00EDA324 File Offset: 0x00ED8524
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoSettleView.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoSettleView.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AA0D RID: 240141 RVA: 0x00EDA368 File Offset: 0x00ED8568
		private void SetupParams()
		{
			IKurotatoSettlementData settlementData = ModelBase<KurotatoModel>.Instance.GetSettlementData();
			int? num;
			if (settlementData == null)
			{
				num = null;
			}
			else
			{
				List<int> unlockRoles = settlementData.UnlockRoles;
				num = ((unlockRoles != null) ? new int?(unlockRoles.Count) : null);
			}
			int? num2 = num;
			bool flag;
			if (num2.GetValueOrDefault() <= 0)
			{
				int? num3;
				if (settlementData == null)
				{
					num3 = null;
				}
				else
				{
					List<int> unlockWeapons = settlementData.UnlockWeapons;
					num3 = ((unlockWeapons != null) ? new int?(unlockWeapons.Count) : null);
				}
				num2 = num3;
				if (num2.GetValueOrDefault() <= 0)
				{
					int? num4;
					if (settlementData == null)
					{
						num4 = null;
					}
					else
					{
						List<int> unlockItems = settlementData.UnlockItems;
						num4 = ((unlockItems != null) ? new int?(unlockItems.Count) : null);
					}
					num2 = num4;
					flag = (num2.GetValueOrDefault() > 0);
					goto IL_BF;
				}
			}
			flag = true;
			IL_BF:
			this.PageState = (flag ? EKurotatoSettlePageState.Unlock : EKurotatoSettlePageState.Info);
			int curLevelId = ModelBase<KurotatoModel>.Instance.GetCurLevelId();
			KurotatoActivityData activityData = ControllerBase<KurotatoActivityController>.Instance.GetActivityData();
			this.NextLevelId = ((activityData != null) ? activityData.GetNextLevelId(curLevelId) : 0);
			this.PassTime = Singleton<TimeUtil>.Instance.DateFormat2(DateTimeOffset.FromUnixTimeMilliseconds((long)Singleton<TimeUtil>.Instance.GetServerTimeStamp()).DateTime);
			KurotatoActivityData activityData2 = ControllerBase<KurotatoActivityController>.Instance.GetActivityData();
			KurotatoLevelData kurotatoLevelData = (activityData2 != null) ? activityData2.GetKurotatoLevelData(curLevelId) : null;
			this.IsEndlessLevel = (kurotatoLevelData != null && kurotatoLevelData.IsEndless);
		}

		// Token: 0x0603AA0E RID: 240142 RVA: 0x00EDA4C0 File Offset: 0x00ED86C0
		private UniTask CreateRightPanelAsync()
		{
			KurotatoSettleView.<CreateRightPanelAsync>d__18 <CreateRightPanelAsync>d__;
			<CreateRightPanelAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateRightPanelAsync>d__.<>4__this = this;
			<CreateRightPanelAsync>d__.<>1__state = -1;
			<CreateRightPanelAsync>d__.<>t__builder.Start<KurotatoSettleView.<CreateRightPanelAsync>d__18>(ref <CreateRightPanelAsync>d__);
			return <CreateRightPanelAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AA0F RID: 240143 RVA: 0x00EDA504 File Offset: 0x00ED8704
		private UniTask CreateBtnNextPageAsync()
		{
			KurotatoSettleView.<CreateBtnNextPageAsync>d__19 <CreateBtnNextPageAsync>d__;
			<CreateBtnNextPageAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateBtnNextPageAsync>d__.<>4__this = this;
			<CreateBtnNextPageAsync>d__.<>1__state = -1;
			<CreateBtnNextPageAsync>d__.<>t__builder.Start<KurotatoSettleView.<CreateBtnNextPageAsync>d__19>(ref <CreateBtnNextPageAsync>d__);
			return <CreateBtnNextPageAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AA10 RID: 240144 RVA: 0x00EDA548 File Offset: 0x00ED8748
		private UniTask CreateBtnExitAsync()
		{
			KurotatoSettleView.<CreateBtnExitAsync>d__20 <CreateBtnExitAsync>d__;
			<CreateBtnExitAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateBtnExitAsync>d__.<>4__this = this;
			<CreateBtnExitAsync>d__.<>1__state = -1;
			<CreateBtnExitAsync>d__.<>t__builder.Start<KurotatoSettleView.<CreateBtnExitAsync>d__20>(ref <CreateBtnExitAsync>d__);
			return <CreateBtnExitAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AA11 RID: 240145 RVA: 0x00EDA58C File Offset: 0x00ED878C
		private UniTask CreateBtnStartAsync()
		{
			KurotatoSettleView.<CreateBtnStartAsync>d__21 <CreateBtnStartAsync>d__;
			<CreateBtnStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateBtnStartAsync>d__.<>4__this = this;
			<CreateBtnStartAsync>d__.<>1__state = -1;
			<CreateBtnStartAsync>d__.<>t__builder.Start<KurotatoSettleView.<CreateBtnStartAsync>d__21>(ref <CreateBtnStartAsync>d__);
			return <CreateBtnStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AA12 RID: 240146 RVA: 0x00EDA5CF File Offset: 0x00ED87CF
		protected override void OnStart()
		{
			this.CreateAttrLayout();
			this.CreateSkillScrollList();
			this.RefreshTitle();
			this.RefreshRoleInfo();
			this.RefreshAttrList();
			this.RefreshSkillList();
			this.RefreshRoleAttrInfo();
			this.RefreshButtons();
			this.RefreshShare();
			this.PlaySettlementAudio();
		}

		// Token: 0x0603AA13 RID: 240147 RVA: 0x00EDA60D File Offset: 0x00ED880D
		private void CreateAttrLayout()
		{
			this.AttrLayout = new GenericLayout<AttributeItem, IKurotatoRoleSkillInfo>(base.GetGridLayout(5), new Func<AttributeItem>(this.InitAttrItem), null, false, true);
		}

		// Token: 0x0603AA14 RID: 240148 RVA: 0x00EDA630 File Offset: 0x00ED8830
		private void CreateSkillScrollList()
		{
			this.SkillScrollList = new GenericScrollViewNew<SkillItem, string>(base.GetScrollViewWithScrollbar(8), new Func<SkillItem>(this.InitSkillItem), null, false, null);
		}

		// Token: 0x0603AA15 RID: 240149 RVA: 0x00EDA653 File Offset: 0x00ED8853
		private AttributeItem InitAttrItem()
		{
			return new AttributeItem();
		}

		// Token: 0x0603AA16 RID: 240150 RVA: 0x00EDA65A File Offset: 0x00ED885A
		private SkillItem InitSkillItem()
		{
			return new SkillItem();
		}

		// Token: 0x0603AA17 RID: 240151 RVA: 0x00EDA664 File Offset: 0x00ED8864
		private void RefreshAttrList()
		{
			IKurotatoSettlementData settlementData = ModelBase<KurotatoModel>.Instance.GetSettlementData();
			Dictionary<int, int> dictionary = (settlementData != null) ? settlementData.PropertyMap : null;
			List<IKurotatoRoleSkillInfo> list = new List<IKurotatoRoleSkillInfo>();
			foreach (KurotatoProperty kurotatoProperty in ConfigBase<KurotatoConfig>.Instance.GetAllProperty())
			{
				if (kurotatoProperty.RoleType == 1)
				{
					int? num = null;
					int value;
					if (dictionary != null && dictionary.TryGetValue(kurotatoProperty.Id, out value))
					{
						num = new int?(value);
					}
					list.Add(new KurotatoRoleSkillInfo
					{
						AttrId = kurotatoProperty.Id,
						Value = (num ?? ModelBase<KurotatoModel>.Instance.GetSystemPropertyValue(kurotatoProperty.Id)),
						IsRecommend = false
					});
				}
			}
			this.AttrLayout.RefreshByData(list, null, false);
		}

		// Token: 0x0603AA18 RID: 240152 RVA: 0x00EDA75C File Offset: 0x00ED895C
		private void RefreshSkillList()
		{
			int roleId = ModelBase<KurotatoModel>.Instance.GetRoleId();
			KurotatoCharacter value = ConfigBase<KurotatoConfig>.Instance.GetCharacterById(roleId).Value;
			List<string> data = new List<string>
			{
				KurotatoUtil.GetCardDesc(value.Desc, value.DescParamsIter().ToList<string>(), 0, 0, false)
			};
			this.SkillScrollList.RefreshByData(data, null, false);
		}

		// Token: 0x0603AA19 RID: 240153 RVA: 0x00EDA7C0 File Offset: 0x00ED89C0
		private void RefreshRoleInfo()
		{
			int roleId = ModelBase<KurotatoModel>.Instance.GetRoleId();
			KurotatoCharacter value = ConfigBase<KurotatoConfig>.Instance.GetCharacterById(roleId).Value;
			RoleDataBase roleDataByKurotatoRoleId = ModelBase<KurotatoModel>.Instance.GetRoleDataByKurotatoRoleId(roleId);
			RoleSkin value2 = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(roleDataByKurotatoRoleId.GetRoleSkinId()).Value;
			USpineSkeletonAnimationComponent roleSpine = base.GetSpine(0);
			UUIItem uuiitem = roleSpine.GetOwner().GetComponentByClass(UUIItem.StaticClass()) as UUIItem;
			float[] spineParamArray = value2.GetSpineParamArray();
			uuiitem.SetAnchorOffsetX(spineParamArray[0]);
			uuiitem.SetAnchorOffsetY(spineParamArray[1]);
			uuiitem.SetUIItemScale(new FVector(spineParamArray[2], spineParamArray[2], spineParamArray[2]));
			base.SetSpineAssetByPath(value2.FormationSpineAtlas, value2.FormationSpineSkeletonData, roleSpine).ContinueWith(delegate()
			{
				roleSpine.SetAnimation(0, ESpineAnimation.Idle.ToEnumString(), true);
			}).Forget();
			base.GetText(2).ShowTextNew(value.Name);
			base.GetText(3).SetText(ConfigMultiTextLang.GetLocalTextNew("Kurotato_Lv", null) + ModelBase<KurotatoModel>.Instance.BattleData.GetRoleLevel().ToString(), true);
		}

		// Token: 0x0603AA1A RID: 240154 RVA: 0x00EDA8F1 File Offset: 0x00ED8AF1
		private void RefreshRoleAttrInfo()
		{
			GenericLayout<AttributeItem, IKurotatoRoleSkillInfo> attrLayout = this.AttrLayout;
			if (attrLayout != null)
			{
				attrLayout.SetActive(!this.IsShowingSkill);
			}
			base.GetItem(7).SetUIActive(this.IsShowingSkill);
		}

		// Token: 0x0603AA1B RID: 240155 RVA: 0x00EDA91F File Offset: 0x00ED8B1F
		private void RefreshTitle()
		{
			if (this.PageState == EKurotatoSettlePageState.Unlock)
			{
				base.GetText(16).ShowTextNew("Kurotato_FinishprefabTilte_GetAll");
				return;
			}
			base.GetText(16).ShowTextNew("Kurotato_FinishprefabTilte_All");
		}

		// Token: 0x0603AA1C RID: 240156 RVA: 0x00EDA950 File Offset: 0x00ED8B50
		private void PlaySettlementAudio()
		{
			if (this.IsEndlessLevel)
			{
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_tudou_settlement_start");
				return;
			}
			IKurotatoSettlementData settlementData = ModelBase<KurotatoModel>.Instance.GetSettlementData();
			bool flag = settlementData != null && settlementData.IsPass;
			Singleton<AudioSystem>.Instance.PostEvent(flag ? "play_ui_tudou_settlement_success_start" : "play_ui_tudou_settlement_fail_start");
		}

		// Token: 0x0603AA1D RID: 240157 RVA: 0x00EDA9A8 File Offset: 0x00ED8BA8
		private void RefreshButtons()
		{
			this.BtnNextPage.GetRootItem().SetUIActive(this.PageState == EKurotatoSettlePageState.Unlock);
			this.BtnExit.GetRootItem().SetUIActive(this.PageState == EKurotatoSettlePageState.Info);
			this.BtnStart.GetRootItem().SetUIActive(this.PageState == EKurotatoSettlePageState.Info && this.NextLevelId != 0);
			IKurotatoSettlementData settlementData = ModelBase<KurotatoModel>.Instance.GetSettlementData();
			if (settlementData != null && settlementData.IsPass && this.NextLevelId != 0)
			{
				this.BtnStart.SetLocalTextNew("PrefabTextItem_2819293743_Text", Array.Empty<object>());
				return;
			}
			this.BtnStart.SetLocalTextNew("Kurotato_finishbutton_back", Array.Empty<object>());
		}

		// Token: 0x0603AA1E RID: 240158 RVA: 0x00EDAA58 File Offset: 0x00ED8C58
		private void RefreshShare()
		{
			UUIButtonComponent button = base.GetButton(1);
			if (button != null)
			{
				UUIItem uuiitem = button.RootUIComp.Get();
				if (uuiitem != null)
				{
					uuiitem.SetUIActive(this.IsEndlessLevel);
				}
			}
			UUIItem item = base.GetItem(15);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x0603AA1F RID: 240159 RVA: 0x00EDAAA4 File Offset: 0x00ED8CA4
		private void SetShareState(bool isShow)
		{
			UUIButtonComponent button = base.GetButton(1);
			if (button != null)
			{
				UUIItem uuiitem = button.RootUIComp.Get();
				if (uuiitem != null)
				{
					uuiitem.SetUIActive(isShow);
				}
			}
			UUIItem item = base.GetItem(15);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIButtonComponent button2 = base.GetButton(4);
			if (button2 != null)
			{
				UUIItem uuiitem2 = button2.RootUIComp.Get();
				if (uuiitem2 != null)
				{
					uuiitem2.SetUIActive(isShow);
				}
			}
			UUIItem item2 = base.GetItem(11);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(isShow);
		}

		// Token: 0x0603AA20 RID: 240160 RVA: 0x00EDAB24 File Offset: 0x00ED8D24
		private void OpenShareView()
		{
			UiAsyncTask task = new UiAsyncTask("OpenShareView", delegate()
			{
				KurotatoSettleView.<<OpenShareView>b__36_0>d <<OpenShareView>b__36_0>d;
				<<OpenShareView>b__36_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<OpenShareView>b__36_0>d.<>4__this = this;
				<<OpenShareView>b__36_0>d.<>1__state = -1;
				<<OpenShareView>b__36_0>d.<>t__builder.Start<KurotatoSettleView.<<OpenShareView>b__36_0>d>(ref <<OpenShareView>b__36_0>d);
				return <<OpenShareView>b__36_0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task).Forget();
		}

		// Token: 0x0603AA21 RID: 240161 RVA: 0x00EDAB58 File Offset: 0x00ED8D58
		private UniTask OpenShareViewAsync()
		{
			KurotatoSettleView.<OpenShareViewAsync>d__37 <OpenShareViewAsync>d__;
			<OpenShareViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenShareViewAsync>d__.<>4__this = this;
			<OpenShareViewAsync>d__.<>1__state = -1;
			<OpenShareViewAsync>d__.<>t__builder.Start<KurotatoSettleView.<OpenShareViewAsync>d__37>(ref <OpenShareViewAsync>d__);
			return <OpenShareViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AA22 RID: 240162 RVA: 0x00EDAB9B File Offset: 0x00ED8D9B
		private void OnClickBtnShare()
		{
			this.OpenShareView();
		}

		// Token: 0x0603AA23 RID: 240163 RVA: 0x00EDABA3 File Offset: 0x00ED8DA3
		private void OnFirstShare()
		{
			this.RefreshShare();
		}

		// Token: 0x0603AA24 RID: 240164 RVA: 0x00EDABAB File Offset: 0x00ED8DAB
		private void OnClickBtnSwitch()
		{
			this.IsShowingSkill = !this.IsShowingSkill;
			this.RefreshRoleAttrInfo();
		}

		// Token: 0x0402129B RID: 135835
		private readonly KurotatoSettleRightPanel RightPanel = new KurotatoSettleRightPanel();

		// Token: 0x0402129C RID: 135836
		private readonly ButtonItem BtnNextPage = new ButtonItem(null);

		// Token: 0x0402129D RID: 135837
		private readonly ButtonItem BtnExit = new ButtonItem(null);

		// Token: 0x0402129E RID: 135838
		private readonly ButtonItem BtnStart = new ButtonItem(null);

		// Token: 0x0402129F RID: 135839
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<AttributeItem, IKurotatoRoleSkillInfo> AttrLayout;

		// Token: 0x040212A0 RID: 135840
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<SkillItem, string> SkillScrollList;

		// Token: 0x040212A1 RID: 135841
		private bool IsShowingSkill;

		// Token: 0x040212A2 RID: 135842
		private EKurotatoSettlePageState PageState;

		// Token: 0x040212A3 RID: 135843
		private int NextLevelId;

		// Token: 0x040212A4 RID: 135844
		private string PassTime = "";

		// Token: 0x040212A5 RID: 135845
		private bool IsEndlessLevel;

		// Token: 0x0200BA58 RID: 47704
		[NullableContext(0)]
		private class EComps
		{
			// Token: 0x04039897 RID: 235671
			public const int SpineRole = 0;

			// Token: 0x04039898 RID: 235672
			public const int BtnShare = 1;

			// Token: 0x04039899 RID: 235673
			public const int TextName = 2;

			// Token: 0x0403989A RID: 235674
			public const int TextLv = 3;

			// Token: 0x0403989B RID: 235675
			public const int BtnSwitch = 4;

			// Token: 0x0403989C RID: 235676
			public const int PanelGrid = 5;

			// Token: 0x0403989D RID: 235677
			public const int PanelAttribute = 6;

			// Token: 0x0403989E RID: 235678
			public const int PanelSkill = 7;

			// Token: 0x0403989F RID: 235679
			public const int ScrollSkill = 8;

			// Token: 0x040398A0 RID: 235680
			public const int PanelInfo = 9;

			// Token: 0x040398A1 RID: 235681
			public const int PanelRight = 10;

			// Token: 0x040398A2 RID: 235682
			public const int PanelBtn = 11;

			// Token: 0x040398A3 RID: 235683
			public const int BtnNextPage = 12;

			// Token: 0x040398A4 RID: 235684
			public const int BtnExit = 13;

			// Token: 0x040398A5 RID: 235685
			public const int BtnStart = 14;

			// Token: 0x040398A6 RID: 235686
			public const int ItemFirstShareBubble = 15;

			// Token: 0x040398A7 RID: 235687
			public const int TextTittle = 16;
		}
	}
}
