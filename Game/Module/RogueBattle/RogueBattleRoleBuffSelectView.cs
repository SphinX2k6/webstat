using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.MapRogue;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005274 RID: 21108
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueBattleRoleBuffSelectView : UiViewBase
	{
		// Token: 0x06036003 RID: 221187 RVA: 0x00D96DF4 File Offset: 0x00D94FF4
		public RogueBattleRoleBuffSelectView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06036004 RID: 221188 RVA: 0x00D96E00 File Offset: 0x00D95000
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(7, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(8, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(4, new Action(this.OnBtnConfirm)),
				new ValueTuple<int, Delegate>(5, new Action(this.OnBtnDetail))
			};
		}

		// Token: 0x06036005 RID: 221189 RVA: 0x00D96F1C File Offset: 0x00D9511C
		private void OnBtnConfirm()
		{
			int incId = (int)this.OpenParam;
			((MapRogueOpRoleBuffBondLinkId)ModelBase<MapRogueModel>.Instance.GetOpData(incId)).Select(this.BuffLayout.GetSelectedGridIndex());
			ModelBase<MapRogueModel>.Instance.ExecuteOpData(incId, null);
		}

		// Token: 0x06036006 RID: 221190 RVA: 0x00D96F64 File Offset: 0x00D95164
		private unsafe void OnBtnDetail()
		{
			int parentId = ((MapRogueOpRoleBuffBondLinkId)ModelBase<MapRogueModel>.Instance.GetOpData((int)this.OpenParam)).Data.RollBuffBondLinkIdOp.RoleBondInfoView.ParentId;
			RogueResBondRole? rogueResBondRole = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBondRole(parentId);
			if (rogueResBondRole != null)
			{
				RoleController instance = ControllerBase<RoleController>.Instance;
				ERoleAgentType agentType = ERoleAgentType.Preview;
				int selectRoleId = 0;
				int num = 1;
				List<int> list = new List<int>(num);
				CollectionsMarshal.SetCount<int>(list, num);
				Span<int> span = CollectionsMarshal.AsSpan<int>(list);
				int index = 0;
				*span[index] = rogueResBondRole.Value.TrialRoleId;
				instance.OpenRoleMainView(agentType, selectRoleId, list, new EUiTabViewName?(EUiTabViewName.RoleSkillTabView), null);
			}
		}

		// Token: 0x06036007 RID: 221191 RVA: 0x00D97000 File Offset: 0x00D95200
		private void OnSelectBuff(int index)
		{
			if (index == this.BuffLayout.GetSelectedGridIndex())
			{
				GenericLayout<RogueBattleRoleBuffItem, RogueResGainData> buffLayout = this.BuffLayout;
				if (buffLayout != null)
				{
					buffLayout.DeselectCurrentGridProxy();
				}
				base.GetButton(4).SetSelfInteractive(false);
				return;
			}
			GenericLayout<RogueBattleRoleBuffItem, RogueResGainData> buffLayout2 = this.BuffLayout;
			if (buffLayout2 != null)
			{
				buffLayout2.SelectGridProxy(index, false);
			}
			base.GetButton(4).SetSelfInteractive(true);
		}

		// Token: 0x06036008 RID: 221192 RVA: 0x00D9705C File Offset: 0x00D9525C
		private void OnClickDetail(int index)
		{
			MapRogueOpRoleBuffBondLinkId mapRogueOpRoleBuffBondLinkId = (MapRogueOpRoleBuffBondLinkId)ModelBase<MapRogueModel>.Instance.GetOpData((int)this.OpenParam);
			IList<RogueResGainData> gainDataList = mapRogueOpRoleBuffBondLinkId.GetGainDataList();
			List<int> list = new List<int>();
			for (int i = 0; i < gainDataList.Count; i++)
			{
				RogueResGainData rogueResGainData = gainDataList[i];
				if (rogueResGainData.RogueResRoleBuff != null)
				{
					list.Add(rogueResGainData.RogueResRoleBuff.ConfigId);
				}
			}
			IRogueBattleRoleAffixDetailOpenParam param = new RogueBattleRoleAffixDetailOpenParam
			{
				Index = index,
				AffixIds = list,
				RoleId = mapRogueOpRoleBuffBondLinkId.Data.RollBuffBondLinkIdOp.RogueResOption.RoleId
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueBattleRoleAffixDetailView, param, null);
		}

		// Token: 0x06036009 RID: 221193 RVA: 0x00D9710B File Offset: 0x00D9530B
		private RogueBattleRoleBuffItem CreateItem()
		{
			return new RogueBattleRoleBuffItem
			{
				OnSelectCallback = new Action<int>(this.OnSelectBuff),
				OnClickBtnDetailCallback = new Action<int>(this.OnClickDetail)
			};
		}

		// Token: 0x0603600A RID: 221194 RVA: 0x00D97138 File Offset: 0x00D95338
		protected override UniTask OnBeforeStartAsync()
		{
			RogueBattleRoleBuffSelectView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattleRoleBuffSelectView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603600B RID: 221195 RVA: 0x00D9717B File Offset: 0x00D9537B
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		}

		// Token: 0x0603600C RID: 221196 RVA: 0x00D97199 File Offset: 0x00D95399
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		}

		// Token: 0x0603600D RID: 221197 RVA: 0x00D971B7 File Offset: 0x00D953B7
		private void OnActivitySequenceEmitEvent(string param)
		{
			if (param == "Enter")
			{
				this.RefreshStar();
			}
		}

		// Token: 0x0603600E RID: 221198 RVA: 0x00D971CC File Offset: 0x00D953CC
		private void InitExtendToggle()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(6);
			EToggleState state = (ModelBase<RogueBattleModel>.Instance.DescMode == EDescModel.DETAIL) ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked;
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(state, false, false, false);
			}
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.OnStateChange.Add(new Action<EToggleState>(this.OnExtendToggleStateChange));
		}

		// Token: 0x0603600F RID: 221199 RVA: 0x00D9721E File Offset: 0x00D9541E
		private void OnExtendToggleStateChange(EToggleState _)
		{
			ModelBase<RogueBattleModel>.Instance.ChangeDescMode();
		}

		// Token: 0x06036010 RID: 221200 RVA: 0x00D9722C File Offset: 0x00D9542C
		private void RefreshStar()
		{
			RoleBondInfoView roleBondInfoView = ModelBase<MapRogueModel>.Instance.GetOpData((int)this.OpenParam).Data.RollBuffBondLinkIdOp.RoleBondInfoView;
			int maxRoleStar = ModelBase<RogueBattleModel>.Instance.MaxRoleStar;
			int oldStar = roleBondInfoView.OldStar;
			int newStar = roleBondInfoView.NewStar;
			List<ERogueRoleStarState> list = new List<ERogueRoleStarState>();
			for (int i = 0; i < maxRoleStar; i++)
			{
				if (i < newStar)
				{
					if (i >= oldStar)
					{
						list.Add(ERogueRoleStarState.LightOn);
					}
					else
					{
						list.Add(ERogueRoleStarState.Active);
					}
				}
				else
				{
					list.Add(ERogueRoleStarState.InActive);
				}
			}
			this.StarLayout.RefreshByData(list, null, true);
		}

		// Token: 0x06036011 RID: 221201 RVA: 0x00D972BC File Offset: 0x00D954BC
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
			GenericLayout<RogueBattleRoleBuffItem, RogueResGainData> buffLayout = this.BuffLayout;
			RogueBattleRoleBuffItem rogueBattleRoleBuffItem = (buffLayout != null) ? buffLayout.GetLayoutItemByIndex(0) : null;
			if (rogueBattleRoleBuffItem == null)
			{
				return null;
			}
			return rogueBattleRoleBuffItem.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x0401F07D RID: 127101
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RogueBattleRoleBuffItem, RogueResGainData> BuffLayout;

		// Token: 0x0401F07E RID: 127102
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RogueBattleRoleStarItem, ERogueRoleStarState> StarLayout;

		// Token: 0x0401F07F RID: 127103
		[Nullable(2)]
		private RogueBattleTopPanel TopPanel;
	}
}
