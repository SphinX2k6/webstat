using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.RogueBattle;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005919 RID: 22809
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRogueOpRoleBuffBondLinkId : MapRogueOp
	{
		// Token: 0x1700941A RID: 37914
		// (get) Token: 0x06039E51 RID: 237137 RVA: 0x00EA8623 File Offset: 0x00EA6823
		// (set) Token: 0x06039E52 RID: 237138 RVA: 0x00EA862B File Offset: 0x00EA682B
		public override int StepSize { get; set; } = 2;

		// Token: 0x06039E53 RID: 237139 RVA: 0x00EA8634 File Offset: 0x00EA6834
		public MapRogueOpRoleBuffBondLinkId()
		{
			this.Priority = ERogueOpPriority.RoleBuff;
		}

		// Token: 0x06039E54 RID: 237140 RVA: 0x00EA864C File Offset: 0x00EA684C
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(39, 5);
			defaultInterpolatedStringHandler.AppendLiteral("[RoleBuff] IncId:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.IncId);
			defaultInterpolatedStringHandler.AppendLiteral(" Type:");
			RollBuffBondLinkIdOp rollBuffBondLinkIdOp = this.Data.RollBuffBondLinkIdOp;
			RogueResDataType? value;
			if (rollBuffBondLinkIdOp == null)
			{
				value = null;
			}
			else
			{
				RogueResOption rogueResOption = rollBuffBondLinkIdOp.RogueResOption;
				value = ((rogueResOption != null) ? new RogueResDataType?(rogueResOption.RogueResDataType) : null);
			}
			defaultInterpolatedStringHandler.AppendFormatted<RogueResDataType?>(value);
			defaultInterpolatedStringHandler.AppendLiteral(" Cur:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.CurrentSelectCount);
			defaultInterpolatedStringHandler.AppendLiteral(" Max:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.MaxSelectCount);
			defaultInterpolatedStringHandler.AppendLiteral(" Lock:");
			defaultInterpolatedStringHandler.AppendFormatted<bool>(this.Lock);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06039E55 RID: 237141 RVA: 0x00EA8719 File Offset: 0x00EA6919
		protected override void OnUpdate(MapRogueGameInfo gameInfo)
		{
			Action updateViewFunc = this.UpdateViewFunc;
			if (updateViewFunc != null)
			{
				updateViewFunc();
			}
			this.Lock = false;
		}

		// Token: 0x06039E56 RID: 237142 RVA: 0x00EA8733 File Offset: 0x00EA6933
		protected override void OnStartExecute(MapRogueGameInfo gameInfo)
		{
			if (this.Data.RollBuffBondLinkIdOp.RogueResOption == null)
			{
				return;
			}
			this.OpenAndCloseLastView(EUiViewName.RogueBattleRoleBuffSelectView);
		}

		// Token: 0x06039E57 RID: 237143 RVA: 0x00EA8753 File Offset: 0x00EA6953
		public IList<RogueResGainData> GetGainDataList()
		{
			return this.Data.RollBuffBondLinkIdOp.RogueResOption.RogueResGainDatas.ToList<RogueResGainData>();
		}

		// Token: 0x06039E58 RID: 237144 RVA: 0x00EA8770 File Offset: 0x00EA6970
		protected override void OnExecute(MapRogueGameInfo gameInfo)
		{
			if (this.CurrentStep == 1)
			{
				RoleBondInfoView roleBondInfoView = this.Data.RollBuffBondLinkIdOp.RoleBondInfoView;
				RogueResBondRole value = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBondRole(roleBondInfoView.ParentId).Value;
				int upStar = roleBondInfoView.NewStar - roleBondInfoView.OldStar;
				bool flag = false;
				foreach (int num in value.GetBondIdsArray())
				{
					RoleBondInfo roleBondInfo = null;
					foreach (RoleBondInfo roleBondInfo2 in roleBondInfoView.OldRoleBondInfos)
					{
						if (roleBondInfo2.ConfigId == num)
						{
							roleBondInfo = roleBondInfo2;
							break;
						}
					}
					if (roleBondInfo == null)
					{
						roleBondInfo = ModelBase<RogueBattleModel>.Instance.GetRoleBondDataById(num);
					}
					if (ModelBase<RogueBattleModel>.Instance.GetRoleBondPreviewDataById(roleBondInfo.ConfigId, upStar, new int?(roleBondInfo.Level), new int?(roleBondInfo.CurStar)).Level != roleBondInfo.Level)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					this.OpenAndCloseLastView(EUiViewName.RogueBattleRoleStarUpView);
					return;
				}
				base.Execute(gameInfo, null);
				return;
			}
			else
			{
				if (this.CurrentStep != 2)
				{
					if (this.CurrentStep == 3)
					{
						base.ExecuteOp(delegate(bool success)
						{
							if (!success)
							{
								this.Lock = false;
							}
						});
					}
					return;
				}
				if (this.Data.RollBuffBondLinkIdOp.LinkId.Count == 0)
				{
					base.Execute(gameInfo, null);
					return;
				}
				this.OpenAndCloseLastView(EUiViewName.RogueBattleLinkUnlockView);
				return;
			}
		}

		// Token: 0x06039E59 RID: 237145 RVA: 0x00EA88F8 File Offset: 0x00EA6AF8
		private void OpenAndCloseLastView(EUiViewName viewName)
		{
			Singleton<UiManager>.Instance.OpenView(viewName, this.IncId, delegate(bool isSuccess, int viewId)
			{
				this.CloseLastView();
				if (isSuccess)
				{
					this.LastViewName = new EUiViewName?(viewName);
				}
			});
		}

		// Token: 0x06039E5A RID: 237146 RVA: 0x00EA8940 File Offset: 0x00EA6B40
		private void CloseLastView()
		{
			if (this.LastViewName == null)
			{
				return;
			}
			if (Singleton<UiManager>.Instance.IsViewOpen(this.LastViewName.Value) || Singleton<UiManager>.Instance.IsViewHide(this.LastViewName.Value))
			{
				Singleton<UiManager>.Instance.CloseView(this.LastViewName.Value, null);
			}
			this.LastViewName = null;
		}

		// Token: 0x06039E5B RID: 237147 RVA: 0x00EA89AB File Offset: 0x00EA6BAB
		public void Select(int index)
		{
			if (this.Lock)
			{
				return;
			}
			this.Lock = true;
			this.OpExecuteClientId = index;
		}

		// Token: 0x06039E5C RID: 237148 RVA: 0x00EA89C4 File Offset: 0x00EA6BC4
		protected override void OnFinish(MapRogueGameInfo gameInfo)
		{
		}

		// Token: 0x06039E5D RID: 237149 RVA: 0x00EA89C6 File Offset: 0x00EA6BC6
		protected override void OnDelete(MapRogueGameInfo gameInfo)
		{
			this.CloseLastView();
		}

		// Token: 0x06039E5E RID: 237150 RVA: 0x00EA89D0 File Offset: 0x00EA6BD0
		protected override bool OnBeforeStartExecuteCheck(MapRogueGameInfo gameInfo)
		{
			using (List<MapRogueOp>.Enumerator enumerator = ModelBase<MapRogueModel>.Instance.GetOpDataByType(RogueResOpType.RollBuffBondLinkId).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsStartExecute)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x04020CD1 RID: 134353
		[Nullable(2)]
		public Action UpdateViewFunc;

		// Token: 0x04020CD3 RID: 134355
		public int MaxSelectCount;

		// Token: 0x04020CD4 RID: 134356
		public int CurrentSelectCount;

		// Token: 0x04020CD5 RID: 134357
		private bool Lock;

		// Token: 0x04020CD6 RID: 134358
		private EUiViewName? LastViewName;
	}
}
