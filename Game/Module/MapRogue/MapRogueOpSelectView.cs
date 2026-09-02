using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200591A RID: 22810
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRogueOpSelectView : MapRogueOp
	{
		// Token: 0x1700941B RID: 37915
		// (get) Token: 0x06039E60 RID: 237152 RVA: 0x00EA8A3C File Offset: 0x00EA6C3C
		// (set) Token: 0x06039E61 RID: 237153 RVA: 0x00EA8A44 File Offset: 0x00EA6C44
		public override int StepSize { get; set; } = 1;

		// Token: 0x1700941C RID: 37916
		// (get) Token: 0x06039E62 RID: 237154 RVA: 0x00EA8A4D File Offset: 0x00EA6C4D
		public bool IsMax
		{
			get
			{
				return this.CurrentSelectCount >= this.MaxSelectCount;
			}
		}

		// Token: 0x06039E63 RID: 237155 RVA: 0x00EA8A60 File Offset: 0x00EA6C60
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(41, 5);
			defaultInterpolatedStringHandler.AppendLiteral("[SelectView] IncId:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.IncId);
			defaultInterpolatedStringHandler.AppendLiteral(" Type:");
			SelectViewOp selectViewOp = this.Data.SelectViewOp;
			RogueResDataType? value;
			if (selectViewOp == null)
			{
				value = null;
			}
			else
			{
				RogueResOption rogueResOption = selectViewOp.RogueResOption;
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

		// Token: 0x06039E64 RID: 237156 RVA: 0x00EA8B30 File Offset: 0x00EA6D30
		protected override void OnUpdate(MapRogueGameInfo gameInfo)
		{
			RogueResOption rogueResOption = this.Data.SelectViewOp.RogueResOption;
			this.MaxSelectCount = rogueResOption.MaxSelectCount;
			this.CurrentSelectCount = rogueResOption.UseSelectCount;
			this.CanGiveUp = rogueResOption.CanGiveUp;
			Action updateViewFunc = this.UpdateViewFunc;
			if (updateViewFunc != null)
			{
				updateViewFunc();
			}
			this.Lock = false;
		}

		// Token: 0x06039E65 RID: 237157 RVA: 0x00EA8B8A File Offset: 0x00EA6D8A
		public IList<RogueResGainData> GetGainDataList()
		{
			return this.Data.SelectViewOp.RogueResOption.RogueResGainDatas.ToList<RogueResGainData>();
		}

		// Token: 0x06039E66 RID: 237158 RVA: 0x00EA8BA6 File Offset: 0x00EA6DA6
		public void Select(int index)
		{
			if (this.Lock)
			{
				return;
			}
			this.Lock = true;
			this.OpExecuteClientId = index;
			base.ExecuteOp(delegate(bool success)
			{
				if (!success)
				{
					this.Lock = false;
				}
			});
		}

		// Token: 0x06039E67 RID: 237159 RVA: 0x00EA8BD1 File Offset: 0x00EA6DD1
		public void SelectAll(List<int> indexList)
		{
			if (this.Lock)
			{
				return;
			}
			this.Lock = true;
			base.ExecuteOpMultiSelect(indexList, delegate(bool success)
			{
				if (!success)
				{
					this.Lock = false;
				}
			});
		}

		// Token: 0x06039E68 RID: 237160 RVA: 0x00EA8BF8 File Offset: 0x00EA6DF8
		protected override void OnStartExecute(MapRogueGameInfo gameInfo)
		{
			RogueResOption rogueResOption = this.Data.SelectViewOp.RogueResOption;
			if (rogueResOption == null)
			{
				return;
			}
			RogueResDataType rogueResDataType = rogueResOption.RogueResDataType;
			switch (rogueResDataType)
			{
			case RogueResDataType.Token:
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueBattleSelectTokenView, this.IncId, null);
				break;
			case RogueResDataType.TokenShop:
			case RogueResDataType.Phantom:
				break;
			case RogueResDataType.Role:
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueBattleBuyRoleView, this.IncId, null);
				return;
			case RogueResDataType.RoleBuff:
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueBattleRoleBuffSelectView, this.IncId, null);
				return;
			default:
				if (rogueResDataType == RogueResDataType.Complex)
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.MapRogueRewardView, this.IncId, null);
					return;
				}
				break;
			}
		}

		// Token: 0x06039E69 RID: 237161 RVA: 0x00EA8CB1 File Offset: 0x00EA6EB1
		protected override void OnExecute(MapRogueGameInfo gameInfo)
		{
		}

		// Token: 0x06039E6A RID: 237162 RVA: 0x00EA8CB3 File Offset: 0x00EA6EB3
		protected override void OnFinish(MapRogueGameInfo gameInfo)
		{
		}

		// Token: 0x06039E6B RID: 237163 RVA: 0x00EA8CB5 File Offset: 0x00EA6EB5
		protected override void OnDelete(MapRogueGameInfo gameInfo)
		{
			Action closeViewFunc = this.CloseViewFunc;
			if (closeViewFunc == null)
			{
				return;
			}
			closeViewFunc();
		}

		// Token: 0x04020CD7 RID: 134359
		[Nullable(2)]
		public Action CloseViewFunc;

		// Token: 0x04020CD8 RID: 134360
		[Nullable(2)]
		public Action UpdateViewFunc;

		// Token: 0x04020CDA RID: 134362
		public int MaxSelectCount;

		// Token: 0x04020CDB RID: 134363
		public int CurrentSelectCount;

		// Token: 0x04020CDC RID: 134364
		public bool CanGiveUp;

		// Token: 0x04020CDD RID: 134365
		private bool Lock;
	}
}
