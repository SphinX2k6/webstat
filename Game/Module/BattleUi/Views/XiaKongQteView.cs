using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006108 RID: 24840
	[NullableContext(1)]
	[Nullable(0)]
	public class XiaKongQteView : UiTickViewBase
	{
		// Token: 0x0603EC25 RID: 257061 RVA: 0x01011C7C File Offset: 0x0100FE7C
		public XiaKongQteView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603EC26 RID: 257062 RVA: 0x01011C9C File Offset: 0x0100FE9C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EC27 RID: 257063 RVA: 0x01011D68 File Offset: 0x0100FF68
		protected override UniTask OnBeforeStartAsync()
		{
			XiaKongQteView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<XiaKongQteView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EC28 RID: 257064 RVA: 0x01011DAC File Offset: 0x0100FFAC
		private UniTask NewBarItem(XiaKongQteView.EChildType childType)
		{
			XiaKongQteView.<NewBarItem>d__13 <NewBarItem>d__;
			<NewBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewBarItem>d__.<>4__this = this;
			<NewBarItem>d__.childType = childType;
			<NewBarItem>d__.<>1__state = -1;
			<NewBarItem>d__.<>t__builder.Start<XiaKongQteView.<NewBarItem>d__13>(ref <NewBarItem>d__);
			return <NewBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EC29 RID: 257065 RVA: 0x01011DF8 File Offset: 0x0100FFF8
		private UniTask NewSkillItem(XiaKongQteView.EChildType childType)
		{
			XiaKongQteView.<NewSkillItem>d__14 <NewSkillItem>d__;
			<NewSkillItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewSkillItem>d__.<>4__this = this;
			<NewSkillItem>d__.childType = childType;
			<NewSkillItem>d__.<>1__state = -1;
			<NewSkillItem>d__.<>t__builder.Start<XiaKongQteView.<NewSkillItem>d__14>(ref <NewSkillItem>d__);
			return <NewSkillItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EC2A RID: 257066 RVA: 0x01011E44 File Offset: 0x01010044
		private UniTask NewEndSkillItem()
		{
			XiaKongQteView.<NewEndSkillItem>d__15 <NewEndSkillItem>d__;
			<NewEndSkillItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewEndSkillItem>d__.<>4__this = this;
			<NewEndSkillItem>d__.<>1__state = -1;
			<NewEndSkillItem>d__.<>t__builder.Start<XiaKongQteView.<NewEndSkillItem>d__15>(ref <NewEndSkillItem>d__);
			return <NewEndSkillItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EC2B RID: 257067 RVA: 0x01011E88 File Offset: 0x01010088
		protected override void OnStart()
		{
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnRoleChange));
			Singleton<EventSystem>.Instance.Add<EInputControllerMainType, EInputControllerMainType>(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.OnInputControllerMainTypeChange));
			Singleton<EventSystem>.Instance.Add<int, int, bool>(EEventName.BattleUiSpecialSkillEnableChanged, new Action<int, int, bool>(this.OnSpecialSkillEnableChanged));
			for (int i = 0; i < this.SkillItemList.Count; i++)
			{
				this.BarItemList[i].Init(this.SkillItemList[i]);
				this.SkillItemList[i].SetPressCallback(new Action<int>(this.OnPressItem));
				this.SkillItemList[i].RefreshType(XiaKongQteView.InputTypeList[i]);
			}
			this.RefreshRoleData();
			if (this.EndSkillItem != null)
			{
				this.EndSkillItem.SetPressCallback(new Action<int>(this.OnPressItem));
				this.EndSkillItem.RefreshType(4);
				this.EndSkillItem.SetSkillIconName("SkillButton_1407200_Name");
			}
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetAlpha(0f);
			}
			this.IsPlayStartAnim = false;
		}

		// Token: 0x0603EC2C RID: 257068 RVA: 0x01011FB0 File Offset: 0x010101B0
		private void RefreshRoleData()
		{
			BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
			bool flag;
			if (curRoleData == null)
			{
				flag = true;
			}
			else
			{
				BattleUiRoleData battleUiRoleData = curRoleData;
				flag = (((battleUiRoleData.RoleConfig != null) ? new int?(battleUiRoleData.RoleConfig.GetValueOrDefault().Id) : null).GetValueOrDefault() != 1407);
			}
			if (flag)
			{
				this.RoleData = null;
				this.SpecialSkill = null;
				foreach (XiaKongQteBar xiaKongQteBar in this.BarItemList)
				{
					xiaKongQteBar.Refresh(null);
				}
				base.CloseMe(null);
				return;
			}
			this.RoleData = curRoleData;
			EntityHandle entityHandle = this.RoleData.EntityHandle;
			CharacterSpecialSkillComponent characterSpecialSkillComponent;
			if (entityHandle == null)
			{
				characterSpecialSkillComponent = null;
			}
			else
			{
				WorldEntity entity = entityHandle.Entity;
				characterSpecialSkillComponent = ((entity != null) ? entity.GetComponent<CharacterSpecialSkillComponent>() : null);
			}
			CharacterSpecialSkillComponent characterSpecialSkillComponent2 = characterSpecialSkillComponent;
			this.SpecialSkill = (((characterSpecialSkillComponent2 != null) ? characterSpecialSkillComponent2.SpecialSkill : null) as SpecialSkillXiaKong);
			SpecialSkillXiaKong specialSkill = this.SpecialSkill;
			if (specialSkill == null || !specialSkill.GetIsUltraSkillState())
			{
				base.CloseMe(null);
				return;
			}
			this.SetVisible(true);
			foreach (XiaKongQteBar xiaKongQteBar2 in this.BarItemList)
			{
				xiaKongQteBar2.Refresh(this.SpecialSkill);
			}
		}

		// Token: 0x0603EC2D RID: 257069 RVA: 0x01012118 File Offset: 0x01010318
		private void SetVisible(bool visible)
		{
			if (this.IsVisible == visible)
			{
				return;
			}
			this.IsVisible = visible;
			this.SetActive(visible);
			BattleUiChildViewData childViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
			if (childViewData == null)
			{
				return;
			}
			childViewData.SetChildrenVisible(EBattleUiVisibleReason.SpecialSkill, new <>z__ReadOnlyArray<EBattleUiChild>(new EBattleUiChild[]
			{
				EBattleUiChild.SkillButton,
				EBattleUiChild.GamepadSkillButton,
				EBattleUiChild.BattleHud
			}), !visible, true, 0);
		}

		// Token: 0x0603EC2E RID: 257070 RVA: 0x0101216F File Offset: 0x0101036F
		protected override void OnAddEventListener()
		{
			ControllerBase<InputDistributeController>.Instance.BindActions(new <>z__ReadOnlyArray<string>(new string[]
			{
				"向左移动",
				"向右移动",
				"大招"
			}), new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
		}

		// Token: 0x0603EC2F RID: 257071 RVA: 0x010121AA File Offset: 0x010103AA
		protected override void OnRemoveEventListener()
		{
			ControllerBase<InputDistributeController>.Instance.UnBindActions(new <>z__ReadOnlyArray<string>(new string[]
			{
				"向左移动",
				"向右移动",
				"大招"
			}), new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
		}

		// Token: 0x0603EC30 RID: 257072 RVA: 0x010121E8 File Offset: 0x010103E8
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnRoleChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.OnInputControllerMainTypeChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiSpecialSkillEnableChanged, new Action<int, int, bool>(this.OnSpecialSkillEnableChanged));
			foreach (XiaKongQteBar xiaKongQteBar in this.BarItemList)
			{
				xiaKongQteBar.Destroy(null);
			}
			this.BarItemList.Clear();
			foreach (XiaKongQteSkillItem xiaKongQteSkillItem in this.SkillItemList)
			{
				xiaKongQteSkillItem.Destroy(null);
			}
			this.SkillItemList.Clear();
			if (this.EndSkillItem != null)
			{
				this.EndSkillItem.Destroy(null);
				this.EndSkillItem = null;
			}
			BattleUiChildViewData childViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
			if (childViewData == null)
			{
				return;
			}
			childViewData.SetChildrenVisible(EBattleUiVisibleReason.SpecialSkill, new <>z__ReadOnlyArray<EBattleUiChild>(new EBattleUiChild[]
			{
				EBattleUiChild.SkillButton,
				EBattleUiChild.GamepadSkillButton,
				EBattleUiChild.BattleHud
			}), true, true, 0);
		}

		// Token: 0x0603EC31 RID: 257073 RVA: 0x01012330 File Offset: 0x01010530
		private void OnRoleChange(int i, int i1)
		{
			this.RefreshRoleData();
		}

		// Token: 0x0603EC32 RID: 257074 RVA: 0x01012338 File Offset: 0x01010538
		private void OnInputControllerMainTypeChange(EInputControllerMainType last, EInputControllerMainType now)
		{
			foreach (XiaKongQteSkillItem xiaKongQteSkillItem in this.SkillItemList)
			{
				xiaKongQteSkillItem.RefreshOnInputControllerMainTypeChange();
			}
			XiaKongQteSkillItem endSkillItem = this.EndSkillItem;
			if (endSkillItem == null)
			{
				return;
			}
			endSkillItem.RefreshOnInputControllerMainTypeChange();
		}

		// Token: 0x0603EC33 RID: 257075 RVA: 0x01012398 File Offset: 0x01010598
		private void OnSpecialSkillEnableChanged(int entityId, int roleId, bool enable)
		{
			if (roleId == 1407 && !enable)
			{
				base.CloseMe(null);
			}
		}

		// Token: 0x0603EC34 RID: 257076 RVA: 0x010123AC File Offset: 0x010105AC
		private void OnInputAction(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (actionType != InputDistributeDefine.EActionType.Press)
			{
				return;
			}
			if (this.SpecialSkill == null)
			{
				return;
			}
			if (actionName == "向左移动")
			{
				this.SpecialSkill.SetInputType(2);
				return;
			}
			if (actionName == "向右移动")
			{
				this.SpecialSkill.SetInputType(1);
				return;
			}
			if (!(actionName == "大招"))
			{
				return;
			}
			this.SpecialSkill.SetInputType(4);
		}

		// Token: 0x0603EC35 RID: 257077 RVA: 0x01012417 File Offset: 0x01010617
		private void OnPressItem(int inputType)
		{
			SpecialSkillXiaKong specialSkill = this.SpecialSkill;
			if (specialSkill == null)
			{
				return;
			}
			specialSkill.SetInputType(inputType);
		}

		// Token: 0x0603EC36 RID: 257078 RVA: 0x0101242C File Offset: 0x0101062C
		protected override void OnTick(float delta)
		{
			foreach (XiaKongQteBar xiaKongQteBar in this.BarItemList)
			{
				xiaKongQteBar.Tick(delta);
			}
			foreach (XiaKongQteSkillItem xiaKongQteSkillItem in this.SkillItemList)
			{
				xiaKongQteSkillItem.Tick(delta);
			}
			XiaKongQteSkillItem endSkillItem = this.EndSkillItem;
			if (endSkillItem != null)
			{
				endSkillItem.Tick(delta);
			}
			if (!this.IsPlayStartAnim && this.SpecialSkill != null && this.SpecialSkill.GetNextGenCircleIndex() > 0 && this.SpecialSkill.GetNextEndCircleAttrValue(0) / this.SpecialSkill.GetMinAttrValue() >= 0.3f)
			{
				UUIItem rootItem = this.RootItem;
				if (rootItem != null)
				{
					rootItem.SetAlpha(1f);
				}
				base.PlaySequence("Start01", null, false);
				this.IsPlayStartAnim = true;
			}
		}

		// Token: 0x04023328 RID: 144168
		private const int XIA_KONG_ROLE_ID = 1407;

		// Token: 0x04023329 RID: 144169
		[StaticVariableRuleIgnore]
		private static readonly int[] InputTypeList = new int[]
		{
			1,
			2
		};

		// Token: 0x0402332A RID: 144170
		private readonly List<XiaKongQteSkillItem> SkillItemList = new List<XiaKongQteSkillItem>();

		// Token: 0x0402332B RID: 144171
		[Nullable(2)]
		private XiaKongQteSkillItem EndSkillItem;

		// Token: 0x0402332C RID: 144172
		private readonly List<XiaKongQteBar> BarItemList = new List<XiaKongQteBar>();

		// Token: 0x0402332D RID: 144173
		[Nullable(2)]
		private BattleUiRoleData RoleData;

		// Token: 0x0402332E RID: 144174
		[Nullable(2)]
		private SpecialSkillXiaKong SpecialSkill;

		// Token: 0x0402332F RID: 144175
		private bool IsVisible;

		// Token: 0x04023330 RID: 144176
		private bool IsPlayStartAnim;

		// Token: 0x0200C291 RID: 49809
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BFBE RID: 245694
			BarItem,
			// Token: 0x0403BFBF RID: 245695
			SkillItem,
			// Token: 0x0403BFC0 RID: 245696
			EndSkillItem,
			// Token: 0x0403BFC1 RID: 245697
			BarItem2,
			// Token: 0x0403BFC2 RID: 245698
			SkillItem2
		}
	}
}
