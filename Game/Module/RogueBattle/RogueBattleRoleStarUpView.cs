using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.MapRogue;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005276 RID: 21110
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueBattleRoleStarUpView : UiViewBase
	{
		// Token: 0x06036013 RID: 221203 RVA: 0x00D97355 File Offset: 0x00D95555
		public RogueBattleRoleStarUpView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06036014 RID: 221204 RVA: 0x00D97360 File Offset: 0x00D95560
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(7, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(4, new Action(this.OnBtnConfirm)),
				new ValueTuple<int, Delegate>(5, new Action(this.OnBtnRoleDetail))
			};
		}

		// Token: 0x06036015 RID: 221205 RVA: 0x00D97464 File Offset: 0x00D95664
		protected override UniTask OnBeforeStartAsync()
		{
			RogueBattleRoleStarUpView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattleRoleStarUpView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036016 RID: 221206 RVA: 0x00D974A7 File Offset: 0x00D956A7
		protected override void OnAfterShow()
		{
			GenericScrollViewNew<RogueBattleFetterUpItem, IRogueBattleRoleBondUpdateInfo> fetterScrollView = this.FetterScrollView;
			if (fetterScrollView == null)
			{
				return;
			}
			fetterScrollView.GetScrollItemList().ForEach(delegate(RogueBattleFetterUpItem item)
			{
				item.PlayExpAnimation();
			});
		}

		// Token: 0x06036017 RID: 221207 RVA: 0x00D974DD File Offset: 0x00D956DD
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		}

		// Token: 0x06036018 RID: 221208 RVA: 0x00D974FB File Offset: 0x00D956FB
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		}

		// Token: 0x06036019 RID: 221209 RVA: 0x00D9751C File Offset: 0x00D9571C
		private unsafe void OnBtnRoleDetail()
		{
			int parentId = (ModelBase<MapRogueModel>.Instance.GetOpData((int)this.OpenParam) as MapRogueOpRoleBuffBondLinkId).Data.RollBuffBondLinkIdOp.RoleBondInfoView.ParentId;
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

		// Token: 0x0603601A RID: 221210 RVA: 0x00D975B7 File Offset: 0x00D957B7
		private void OnActivitySequenceEmitEvent(string param)
		{
			if (param == "Enter")
			{
				GenericScrollViewNew<RogueBattleFetterUpItem, IRogueBattleRoleBondUpdateInfo> fetterScrollView = this.FetterScrollView;
				if (fetterScrollView != null)
				{
					fetterScrollView.PlayTurnAnimation();
				}
				this.RefreshStar();
			}
		}

		// Token: 0x0603601B RID: 221211 RVA: 0x00D975DD File Offset: 0x00D957DD
		private void OnBtnConfirm()
		{
			ModelBase<MapRogueModel>.Instance.ExecuteOpData((int)this.OpenParam, null);
		}

		// Token: 0x0603601C RID: 221212 RVA: 0x00D975F8 File Offset: 0x00D957F8
		protected List<IRogueBattleRoleBondUpdateInfo> BuildFetterData()
		{
			List<IRogueBattleRoleBondUpdateInfo> list = new List<IRogueBattleRoleBondUpdateInfo>();
			RoleBondInfoView roleBondInfoView = ModelBase<MapRogueModel>.Instance.GetOpData((int)this.OpenParam).Data.RollBuffBondLinkIdOp.RoleBondInfoView;
			RogueResBondRole? rogueResBondRole = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBondRole(roleBondInfoView.ParentId);
			int num = roleBondInfoView.NewStar - roleBondInfoView.OldStar;
			foreach (int num2 in rogueResBondRole.Value.BondIdsIter())
			{
				RoleBondInfo roleBondInfo = null;
				foreach (RoleBondInfo roleBondInfo2 in roleBondInfoView.OldRoleBondInfos)
				{
					if (roleBondInfo2.ConfigId == num2)
					{
						roleBondInfo = roleBondInfo2;
						break;
					}
				}
				if (roleBondInfo == null)
				{
					roleBondInfo = ModelBase<RogueBattleModel>.Instance.GetRoleBondDataById(num2);
				}
				RoleBondInfo roleBondPreviewDataById = ModelBase<RogueBattleModel>.Instance.GetRoleBondPreviewDataById(roleBondInfo.ConfigId, num, new int?(roleBondInfo.Level), new int?(roleBondInfo.CurStar));
				RogueBattleRoleBondUpdateInfo item = new RogueBattleRoleBondUpdateInfo
				{
					OldRoleBondInfo = roleBondInfo,
					NewRoleBondInfo = roleBondPreviewDataById,
					AddStar = num
				};
				list.Add(item);
			}
			List<IRogueBattleRoleBondUpdateInfo> list2 = list;
			Comparison<IRogueBattleRoleBondUpdateInfo> comparison;
			if ((comparison = RogueBattleRoleStarUpView.<>O.<0>__SortRogueBattleRoleBondUpdateInfo) == null)
			{
				comparison = (RogueBattleRoleStarUpView.<>O.<0>__SortRogueBattleRoleBondUpdateInfo = new Comparison<IRogueBattleRoleBondUpdateInfo>(RogueBattleDefine.SortRogueBattleRoleBondUpdateInfo));
			}
			list2.Sort(comparison);
			return list;
		}

		// Token: 0x0603601D RID: 221213 RVA: 0x00D97774 File Offset: 0x00D95974
		public void RefreshStar()
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

		// Token: 0x0401F089 RID: 127113
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<RogueBattleFetterUpItem, IRogueBattleRoleBondUpdateInfo> FetterScrollView;

		// Token: 0x0401F08A RID: 127114
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RogueBattleRoleStarItem, ERogueRoleStarState> StarLayout;

		// Token: 0x0200B1E3 RID: 45539
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x04037260 RID: 225888
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Comparison<IRogueBattleRoleBondUpdateInfo> <0>__SortRogueBattleRoleBondUpdateInfo;
		}
	}
}
