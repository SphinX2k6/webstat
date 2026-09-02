using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Phantom.Vision.View;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.TabView.VisionSubView
{
	// Token: 0x0200506D RID: 20589
	[NullableContext(2)]
	[Nullable(0)]
	public class RoleVisionInfoPanel : UiPanelBase
	{
		// Token: 0x060350C9 RID: 217289 RVA: 0x00D4DC13 File Offset: 0x00D4BE13
		[NullableContext(1)]
		public RoleVisionInfoPanel(UUIItem uiItem)
		{
			this.SourceItem = uiItem;
		}

		// Token: 0x060350CA RID: 217290 RVA: 0x00D4DC24 File Offset: 0x00D4BE24
		public UniTask Init()
		{
			RoleVisionInfoPanel.<Init>d__7 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<RoleVisionInfoPanel.<Init>d__7>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x060350CB RID: 217291 RVA: 0x00D4DC68 File Offset: 0x00D4BE68
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action(this.OnClickMoreButton)),
				new ValueTuple<int, Delegate>(3, new Action(this.OnClickConfirmButton)),
				new ValueTuple<int, Delegate>(4, new Action(this.OnOneKeyDownEquipmentButton)),
				new ValueTuple<int, Delegate>(5, new Action(this.OnOneKeyUpEquipmentButton))
			};
		}

		// Token: 0x060350CC RID: 217292 RVA: 0x00D4DD88 File Offset: 0x00D4BF88
		protected override UniTask OnBeforeStartAsync()
		{
			RoleVisionInfoPanel.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleVisionInfoPanel.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060350CD RID: 217293 RVA: 0x00D4DDCB File Offset: 0x00D4BFCB
		protected override void OnStart()
		{
			this.VisionDetailDescComponent.SetActive(true);
			this.RoleVisionAttribute = new RoleVisionAttribute(base.GetItem(0));
			this.RoleVisionAttribute.Init();
			this.AddEventListener();
		}

		// Token: 0x060350CE RID: 217294 RVA: 0x00D4DDFC File Offset: 0x00D4BFFC
		private void BindRedDot()
		{
			if (!this.RedDotBindState)
			{
				this.RedDotBindState = true;
				int curSelectRoleId = this.RoleViewAgent.GetCurSelectRoleId();
				ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.VisionOneKeyEquip, base.GetItem(6), null, curSelectRoleId);
			}
		}

		// Token: 0x060350CF RID: 217295 RVA: 0x00D4DE39 File Offset: 0x00D4C039
		private void UnBindRedDot()
		{
			if (this.RedDotBindState)
			{
				this.RedDotBindState = false;
				ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.VisionOneKeyEquip, base.GetItem(6), 0);
			}
		}

		// Token: 0x060350D0 RID: 217296 RVA: 0x00D4DE5E File Offset: 0x00D4C05E
		public UUIItem GetTxtItemByIndex(int index)
		{
			VisionDetailDescComponent visionDetailDescComponent = this.VisionDetailDescComponent;
			if (visionDetailDescComponent == null)
			{
				return null;
			}
			return visionDetailDescComponent.GetTxtItemByIndex(index);
		}

		// Token: 0x060350D1 RID: 217297 RVA: 0x00D4DE74 File Offset: 0x00D4C074
		private void OnOneKeyDownEquipmentButton()
		{
			RoleDataBase roleInstance = this.RoleViewAgent.GetCurSelectRoleData();
			int[] tempList = new int[5];
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.VisionDownAllEquipmentTip);
			confirmBoxDataNew.FunctionMap.Add(1, delegate
			{
				ControllerBase<ConfirmBoxController>.Instance.CloseConfirmBoxView();
			});
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				ControllerBase<PhantomBattleController>.Instance.SendPhantomAutoPutRequest(roleInstance.GetRoleId(), new List<int>(tempList), null);
				ControllerBase<ConfirmBoxController>.Instance.CloseConfirmBoxView();
				Singleton<UiManager>.Instance.CloseView(EUiViewName.VisionNewRecommendView, null);
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x060350D2 RID: 217298 RVA: 0x00D4DF00 File Offset: 0x00D4C100
		private void OnOneKeyUpEquipmentButton()
		{
			int curSelectRoleId = this.RoleViewAgent.GetCurSelectRoleId();
			VisionRecommendViewOpenParam param = new VisionRecommendViewOpenParam
			{
				RoleId = curSelectRoleId,
				IsFromRoleDev = false
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.VisionNewRecommendView, param, null);
		}

		// Token: 0x060350D3 RID: 217299 RVA: 0x00D4DF40 File Offset: 0x00D4C140
		private void OnClickMoreButton()
		{
			RoleDataBase curSelectRoleData = this.RoleViewAgent.GetCurSelectRoleData();
			if (curSelectRoleData == null)
			{
				return;
			}
			List<AttrListScrollData> extraAttrList = ModelBase<PhantomBattleModel>.Instance.GetExtraAttrList(curSelectRoleData.GetDataId());
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleAttributeDetailView, extraAttrList, null);
		}

		// Token: 0x060350D4 RID: 217300 RVA: 0x00D4DF7F File Offset: 0x00D4C17F
		private void OnClickConfirmButton()
		{
			Action onClickConfirmCall = this.OnClickConfirmCall;
			if (onClickConfirmCall == null)
			{
				return;
			}
			onClickConfirmCall();
		}

		// Token: 0x060350D5 RID: 217301 RVA: 0x00D4DF91 File Offset: 0x00D4C191
		[NullableContext(1)]
		public void SetConfirmButtonCall(Action call)
		{
			this.OnClickConfirmCall = call;
		}

		// Token: 0x060350D6 RID: 217302 RVA: 0x00D4DF9C File Offset: 0x00D4C19C
		public void RefreshButtonShowState()
		{
			bool flag = this.RoleViewAgent.GetCurSelectRoleData().IsTrialRole();
			this.RefreshConfirmButtonState(!flag);
			this.RefreshOneKeyButtonState(!flag);
		}

		// Token: 0x060350D7 RID: 217303 RVA: 0x00D4DFD0 File Offset: 0x00D4C1D0
		public void RefreshConfirmButtonState(bool state)
		{
			base.GetButton(3).RootUIComp.Get().SetUIActive(state);
		}

		// Token: 0x060350D8 RID: 217304 RVA: 0x00D4DFF8 File Offset: 0x00D4C1F8
		public void RefreshOneKeyButtonState(bool state)
		{
			base.GetButton(5).RootUIComp.Get().SetUIActive(state);
		}

		// Token: 0x060350D9 RID: 217305 RVA: 0x00D4E01F File Offset: 0x00D4C21F
		protected void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.PhantomEquip, new Action(this.OnPhantomEquip));
		}

		// Token: 0x060350DA RID: 217306 RVA: 0x00D4E03D File Offset: 0x00D4C23D
		protected void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.PhantomEquip, new Action(this.OnPhantomEquip));
		}

		// Token: 0x060350DB RID: 217307 RVA: 0x00D4E05B File Offset: 0x00D4C25B
		[NullableContext(1)]
		public void RefreshView(RoleViewAgent roleViewAgent)
		{
			this.RoleViewAgent = roleViewAgent;
			this.RefreshUi();
		}

		// Token: 0x060350DC RID: 217308 RVA: 0x00D4E06A File Offset: 0x00D4C26A
		private void RefreshUi()
		{
			this.RefreshAttribute();
			this.RefreshDetailComponent();
			this.RefreshOneKeyDownButtonState();
			this.RefreshButtonShowState();
			this.UnBindRedDot();
			this.BindRedDot();
		}

		// Token: 0x060350DD RID: 217309 RVA: 0x00D4E090 File Offset: 0x00D4C290
		private void RefreshAttribute()
		{
			RoleDataBase curSelectRoleData = this.RoleViewAgent.GetCurSelectRoleData();
			List<AttrListScrollData> list = new List<AttrListScrollData>(ModelBase<PhantomBattleModel>.Instance.GetShowAttrList(curSelectRoleData.GetDataId()));
			int count = list.Count;
			IEnumerable<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("VisionMainViewShowAttribute");
			List<AttrListScrollData> list2 = new List<AttrListScrollData>();
			foreach (int num in intArrayConfig)
			{
				PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(num);
				bool flag = false;
				for (int i = 0; i < count; i++)
				{
					if (list[i].Id == num)
					{
						list2.Add(list[i]);
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					list2.Add(new AttrListScrollData(num, 0.0, 0.0, propertyIndexInfo.Value.Priority, false, CommonComponentDefine.EAttributeType.PhantomType));
				}
			}
			this.RoleVisionAttribute.Refresh(list2, true);
		}

		// Token: 0x060350DE RID: 217310 RVA: 0x00D4E1A0 File Offset: 0x00D4C3A0
		private void RefreshDetailComponent()
		{
			RoleDataBase curSelectRoleData = this.RoleViewAgent.GetCurSelectRoleData();
			PhantomDataBase dataByIndex = curSelectRoleData.GetPhantomData().GetDataByIndex(0);
			List<VisionDetailDesc> list = new List<VisionDetailDesc>();
			if (dataByIndex != null)
			{
				using (List<VisionDetailDesc>.Enumerator enumerator = VisionDetailDesc.ConvertVisionSkillDescToDescData(dataByIndex.GetNormalSkillConfig().Value, dataByIndex.GetPhantomLevel(), true, false, dataByIndex.GetQuality()).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						VisionDetailDesc item = enumerator.Current;
						list.Add(item);
					}
					goto IL_AF;
				}
			}
			foreach (VisionDetailDesc item2 in VisionDetailDesc.CreateEmptySkillDescData())
			{
				list.Add(item2);
			}
			IL_AF:
			VisionFetterData[] phantomFettersData = curSelectRoleData.GetPhantomData().GetPhantomFettersData();
			if (phantomFettersData.Length == 0)
			{
				using (List<VisionDetailDesc>.Enumerator enumerator = VisionDetailDesc.CreateEmptyFetterDescData().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						VisionDetailDesc item3 = enumerator.Current;
						list.Add(item3);
					}
					goto IL_141;
				}
			}
			foreach (VisionDetailDesc item4 in VisionDetailDesc.ConvertVisionFetterDataToDetailDescData(new List<VisionFetterData>(phantomFettersData), false, null, null))
			{
				list.Add(item4);
			}
			IL_141:
			foreach (VisionDetailDesc visionDetailDesc in list)
			{
				visionDetailDesc.DoNotNeedCheckSimplyState = true;
			}
			this.VisionDetailDescComponent.Refresh(list, false);
		}

		// Token: 0x060350DF RID: 217311 RVA: 0x00D4E36C File Offset: 0x00D4C56C
		private void RefreshOneKeyDownButtonState()
		{
			RoleDataBase curSelectRoleData = this.RoleViewAgent.GetCurSelectRoleData();
			if (curSelectRoleData.IsTrialRole())
			{
				this.RefreshOneKeyButtonState(false);
				base.GetButton(4).RootUIComp.Get().SetUIActive(false);
				return;
			}
			Dictionary<int, PhantomDataBase> dataMap = curSelectRoleData.GetPhantomData().GetDataMap();
			int num = 0;
			foreach (KeyValuePair<int, PhantomDataBase> keyValuePair in dataMap)
			{
				if (keyValuePair.Value != null)
				{
					num++;
				}
			}
			base.GetButton(4).RootUIComp.Get().SetUIActive(num >= 1);
		}

		// Token: 0x060350E0 RID: 217312 RVA: 0x00D4E424 File Offset: 0x00D4C624
		private void OnPhantomEquip()
		{
			this.RefreshUi();
		}

		// Token: 0x060350E1 RID: 217313 RVA: 0x00D4E42C File Offset: 0x00D4C62C
		protected override void OnBeforeDestroy()
		{
			this.UnBindRedDot();
			this.RemoveEventListener();
		}

		// Token: 0x0401E8B2 RID: 125106
		private RoleViewAgent RoleViewAgent;

		// Token: 0x0401E8B3 RID: 125107
		private RoleVisionAttribute RoleVisionAttribute;

		// Token: 0x0401E8B4 RID: 125108
		private VisionDetailDescComponent VisionDetailDescComponent;

		// Token: 0x0401E8B5 RID: 125109
		private Action OnClickConfirmCall;

		// Token: 0x0401E8B6 RID: 125110
		private readonly UUIItem SourceItem;

		// Token: 0x0401E8B7 RID: 125111
		private bool RedDotBindState;

		// Token: 0x0200B022 RID: 45090
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x04036A3D RID: 223805
			AttributeItem,
			// Token: 0x04036A3E RID: 223806
			MoreButton,
			// Token: 0x04036A3F RID: 223807
			DetailContent,
			// Token: 0x04036A40 RID: 223808
			ConfirmButton,
			// Token: 0x04036A41 RID: 223809
			OneKeyDownEquipmentButton,
			// Token: 0x04036A42 RID: 223810
			OneKeyUpEquipmentButton,
			// Token: 0x04036A43 RID: 223811
			OneKeyEquipRedItem
		}
	}
}
