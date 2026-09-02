using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Dango
{
	// Token: 0x02005DDE RID: 24030
	[NullableContext(2)]
	[Nullable(0)]
	public class DangoAbyssSelectDangoView : UiViewBase
	{
		// Token: 0x0603C7CA RID: 247754 RVA: 0x00F5CA07 File Offset: 0x00F5AC07
		[NullableContext(1)]
		public DangoAbyssSelectDangoView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603C7CB RID: 247755 RVA: 0x00F5CA10 File Offset: 0x00F5AC10
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnCloseBtnClick))
			};
		}

		// Token: 0x0603C7CC RID: 247756 RVA: 0x00F5CB40 File Offset: 0x00F5AD40
		protected override UniTask OnBeforeStartAsync()
		{
			DangoAbyssSelectDangoView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DangoAbyssSelectDangoView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C7CD RID: 247757 RVA: 0x00F5CB84 File Offset: 0x00F5AD84
		protected override void OnStart()
		{
			DangoSelectViewData dangoSelectViewData = this.OpenParam as DangoSelectViewData;
			this.CurrentRoleConfigId = dangoSelectViewData.RoleConfigId;
			this.CurrentSelectDangoId = dangoSelectViewData.CurrentSelectDangoId;
			if (this.CurrentSelectDangoId > 0)
			{
				ModelBase<DangoAbyssModel>.Instance.SetDangoFormationIfNew(this.CurrentSelectDangoId, false);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshAbyssDangoRedDot, this.CurrentSelectDangoId);
			}
		}

		// Token: 0x0603C7CE RID: 247758 RVA: 0x00F5CBE5 File Offset: 0x00F5ADE5
		[NullableContext(1)]
		private AbyssDangoItem InitItem()
		{
			return new AbyssDangoItem();
		}

		// Token: 0x0603C7CF RID: 247759 RVA: 0x00F5CBEC File Offset: 0x00F5ADEC
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603C7D0 RID: 247760 RVA: 0x00F5CBF5 File Offset: 0x00F5ADF5
		protected override void OnBeforeShow()
		{
			this.RefreshDangoList();
			this.RefreshInfo();
		}

		// Token: 0x0603C7D1 RID: 247761 RVA: 0x00F5CC04 File Offset: 0x00F5AE04
		private void RefreshLevelUpBtn(AbyssDangoRoleData data)
		{
			bool dangoUpAvailable = ModelBase<DangoAbyssModel>.Instance.GetDangoUpAvailable();
			ButtonItem levelUpBtnItem = this.LevelUpBtnItem;
			if (levelUpBtnItem == null)
			{
				return;
			}
			levelUpBtnItem.SetActive(data != null && dangoUpAvailable && !ModelBase<GameModeModel>.Instance.IsMulti);
		}

		// Token: 0x0603C7D2 RID: 247762 RVA: 0x00F5CC44 File Offset: 0x00F5AE44
		private void RefreshConfirmBtn(AbyssDangoRoleData data)
		{
			ButtonItem confirmBtnItem = this.ConfirmBtnItem;
			if (confirmBtnItem == null)
			{
				return;
			}
			confirmBtnItem.SetActive(data != null);
		}

		// Token: 0x0603C7D3 RID: 247763 RVA: 0x00F5CC5C File Offset: 0x00F5AE5C
		private void RefreshRightDownText(AbyssDangoRoleData data)
		{
			if (data == null)
			{
				UUIItem item = base.GetItem(8);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(false);
				return;
			}
			else
			{
				bool ifLock = data.GetIfLock();
				UUIItem item2 = base.GetItem(8);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(ifLock);
				return;
			}
		}

		// Token: 0x0603C7D4 RID: 247764 RVA: 0x00F5CC98 File Offset: 0x00F5AE98
		private void RefreshDangoList()
		{
			AbyssDangoRoleData[] allDangoList = ModelBase<DangoAbyssModel>.Instance.GetAllDangoList();
			List<AbyssDangoItemData> list = new List<AbyssDangoItemData>();
			foreach (AbyssDangoRoleData abyssDangoRoleData in allDangoList)
			{
				list.Add(new AbyssDangoItemData
				{
					DangoId = abyssDangoRoleData.GetId(),
					PlayerId = ModelBase<PlayerInfoModel>.Instance.GetId().Value,
					RoleId = ModelBase<DangoAbyssModel>.Instance.GetDangoBelongRoleId(ModelBase<PlayerInfoModel>.Instance.GetId().Value, abyssDangoRoleData.GetId()),
					SelectState = (abyssDangoRoleData.GetId() == this.CurrentSelectDangoId),
					OnSelectCallBack = new Action<AbyssDangoItemData>(this.OnSelectDango)
				});
			}
			this.LoopScrollView.RefreshByData(list, false, null, false);
		}

		// Token: 0x0603C7D5 RID: 247765 RVA: 0x00F5CD68 File Offset: 0x00F5AF68
		[NullableContext(1)]
		private void OnSelectDango(AbyssDangoItemData data)
		{
			this.CurrentSelectDangoId = data.DangoId;
			if (this.CurrentSelectDangoId > 0)
			{
				ModelBase<DangoAbyssModel>.Instance.SetDangoFormationIfNew(this.CurrentSelectDangoId, false);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshAbyssDangoRedDot, this.CurrentSelectDangoId);
			}
			this.RefreshDangoList();
			this.RefreshInfo();
		}

		// Token: 0x0603C7D6 RID: 247766 RVA: 0x00F5CDC0 File Offset: 0x00F5AFC0
		private void RefreshInfo()
		{
			AbyssDangoRoleData dangoAbyssRoleData = ModelBase<DangoAbyssModel>.Instance.GetDangoAbyssRoleData(this.CurrentSelectDangoId);
			this.RefreshRoleInfo(dangoAbyssRoleData);
			this.RefreshBuff(dangoAbyssRoleData);
			this.RefreshSkill(dangoAbyssRoleData);
			this.RefreshPassiveSkill(dangoAbyssRoleData);
			this.RefreshRightDownText(dangoAbyssRoleData);
			this.RefreshLevelUpBtn(dangoAbyssRoleData);
			this.RefreshConfirmBtn(dangoAbyssRoleData);
		}

		// Token: 0x0603C7D7 RID: 247767 RVA: 0x00F5CE0F File Offset: 0x00F5B00F
		private void RefreshRoleInfo(AbyssDangoRoleData data)
		{
			if (data == null)
			{
				RoleInfoPanel rolePanel = this.RolePanel;
				if (rolePanel == null)
				{
					return;
				}
				rolePanel.SetActive(false);
				return;
			}
			else
			{
				RoleInfoPanel rolePanel2 = this.RolePanel;
				if (rolePanel2 != null)
				{
					rolePanel2.SetActive(true);
				}
				RoleInfoPanel rolePanel3 = this.RolePanel;
				if (rolePanel3 == null)
				{
					return;
				}
				rolePanel3.Refresh(data);
				return;
			}
		}

		// Token: 0x0603C7D8 RID: 247768 RVA: 0x00F5CE4C File Offset: 0x00F5B04C
		private void RefreshBuff(AbyssDangoRoleData data)
		{
			if (data == null)
			{
				BuffPanel buffPanel = this.BuffPanel;
				if (buffPanel == null)
				{
					return;
				}
				buffPanel.SetActive(false);
				return;
			}
			else
			{
				int id = data.GetId();
				DangoAbyssDefine.DangoAbyssTagData[] dangoTagData = ModelBase<DangoAbyssModel>.Instance.GetDangoTagData(id, DangoAbyssDefine.ETagDataGetType.Valid);
				BuffPanel buffPanel2 = this.BuffPanel;
				if (buffPanel2 != null)
				{
					buffPanel2.SetActive(dangoTagData.Length != 0);
				}
				BuffPanel buffPanel3 = this.BuffPanel;
				if (buffPanel3 == null)
				{
					return;
				}
				buffPanel3.Refresh(data);
				return;
			}
		}

		// Token: 0x0603C7D9 RID: 247769 RVA: 0x00F5CEA9 File Offset: 0x00F5B0A9
		private void RefreshSkill(AbyssDangoRoleData data)
		{
			if (data == null)
			{
				SkillPanel skillPanel = this.SkillPanel;
				if (skillPanel == null)
				{
					return;
				}
				skillPanel.SetActive(false);
				return;
			}
			else
			{
				SkillPanel skillPanel2 = this.SkillPanel;
				if (skillPanel2 != null)
				{
					skillPanel2.SetActive(true);
				}
				SkillPanel skillPanel3 = this.SkillPanel;
				if (skillPanel3 == null)
				{
					return;
				}
				skillPanel3.Refresh(data);
				return;
			}
		}

		// Token: 0x0603C7DA RID: 247770 RVA: 0x00F5CEE3 File Offset: 0x00F5B0E3
		private void RefreshPassiveSkill(AbyssDangoRoleData data)
		{
			if (data == null)
			{
				SkillPanel passiveSkillPanel = this.PassiveSkillPanel;
				if (passiveSkillPanel == null)
				{
					return;
				}
				passiveSkillPanel.SetActive(false);
				return;
			}
			else
			{
				SkillPanel passiveSkillPanel2 = this.PassiveSkillPanel;
				if (passiveSkillPanel2 == null)
				{
					return;
				}
				passiveSkillPanel2.Refresh(data);
				return;
			}
		}

		// Token: 0x0603C7DB RID: 247771 RVA: 0x00F5CF0C File Offset: 0x00F5B10C
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length != 2)
			{
				return null;
			}
			int displayIndex;
			if (!int.TryParse(configParams[1], out displayIndex))
			{
				return null;
			}
			LoopScrollView<AbyssDangoItem, AbyssDangoItemData> loopScrollView = this.LoopScrollView;
			UUIItem uuiitem = (loopScrollView != null) ? loopScrollView.GetGridByDisplayIndex(displayIndex) : null;
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

		// Token: 0x04022026 RID: 139302
		private int CurrentRoleConfigId;

		// Token: 0x04022027 RID: 139303
		private int CurrentSelectDangoId;

		// Token: 0x04022028 RID: 139304
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<AbyssDangoItem, AbyssDangoItemData> LoopScrollView;

		// Token: 0x04022029 RID: 139305
		private RoleInfoPanel RolePanel;

		// Token: 0x0402202A RID: 139306
		private BuffPanel BuffPanel;

		// Token: 0x0402202B RID: 139307
		private SkillPanel SkillPanel;

		// Token: 0x0402202C RID: 139308
		private SkillPanel PassiveSkillPanel;

		// Token: 0x0402202D RID: 139309
		private ButtonItem LevelUpBtnItem;

		// Token: 0x0402202E RID: 139310
		private ButtonItem ConfirmBtnItem;

		// Token: 0x0200BE35 RID: 48693
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403A8EC RID: 239852
			CloseBtn,
			// Token: 0x0403A8ED RID: 239853
			LoopScrollView,
			// Token: 0x0403A8EE RID: 239854
			ScrollItem,
			// Token: 0x0403A8EF RID: 239855
			LeftDownText,
			// Token: 0x0403A8F0 RID: 239856
			RolePanel,
			// Token: 0x0403A8F1 RID: 239857
			BuffPanel,
			// Token: 0x0403A8F2 RID: 239858
			SkillPanel,
			// Token: 0x0403A8F3 RID: 239859
			PassiveSkillPanel,
			// Token: 0x0403A8F4 RID: 239860
			RightDownRedTips,
			// Token: 0x0403A8F5 RID: 239861
			LevelUpBtn,
			// Token: 0x0403A8F6 RID: 239862
			ConfirmBtn
		}
	}
}
