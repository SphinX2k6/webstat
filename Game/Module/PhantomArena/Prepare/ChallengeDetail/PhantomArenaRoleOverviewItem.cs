using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.ChallengeDetail
{
	// Token: 0x02005523 RID: 21795
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaRoleOverviewItem : UiPanelBase
	{
		// Token: 0x06037999 RID: 227737 RVA: 0x00E1B9A4 File Offset: 0x00E19BA4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnItemButtonClick))
			};
		}

		// Token: 0x0603799A RID: 227738 RVA: 0x00E1BA64 File Offset: 0x00E19C64
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaRoleOverviewItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaRoleOverviewItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603799B RID: 227739 RVA: 0x00E1BAA8 File Offset: 0x00E19CA8
		public void Refresh(IPhantomArenaRoleOverviewItemData data)
		{
			this.Data = data;
			if (data.CardRoleId <= 0)
			{
				base.GetItem(5).SetUIActive(true);
				base.GetItem(1).SetUIActive(false);
				return;
			}
			base.GetItem(5).SetUIActive(false);
			base.GetItem(1).SetUIActive(true);
			PhantomBattleCardRole phantomBattleCardRole = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardRole(data.CardRoleId);
			int roleConfigId = phantomBattleCardRole.RoleConfigId;
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleConfigId);
			if (roleConfig != null)
			{
				base.SetTextureByPath(phantomBattleCardRole.RolePreviewTexture, base.GetTexture(2), null, null);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), roleConfig.Value.Name, Array.Empty<object>());
				CardElementItem elementItem = this.ElementItem;
				if (elementItem == null)
				{
					return;
				}
				elementItem.RefreshElement((ECardElement)roleConfig.Value.ElementId);
			}
		}

		// Token: 0x0603799C RID: 227740 RVA: 0x00E1BB8C File Offset: 0x00E19D8C
		public void PlaySelectAnim()
		{
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlayLevelSequenceByName("In", false, null, false);
		}

		// Token: 0x0603799D RID: 227741 RVA: 0x00E1BBB9 File Offset: 0x00E19DB9
		private void OnItemButtonClick()
		{
			Action onRoleOverviewItemClick = this.OnRoleOverviewItemClick;
			if (onRoleOverviewItemClick == null)
			{
				return;
			}
			onRoleOverviewItemClick();
		}

		// Token: 0x0401FE08 RID: 130568
		protected IPhantomArenaRoleOverviewItemData Data;

		// Token: 0x0401FE09 RID: 130569
		public Action OnRoleOverviewItemClick;

		// Token: 0x0401FE0A RID: 130570
		private CardElementItem ElementItem;

		// Token: 0x0401FE0B RID: 130571
		protected LevelSequencePlayer SequencePlayer;

		// Token: 0x0200B4B9 RID: 46265
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037F35 RID: 229173
			public const int ItemButton = 0;

			// Token: 0x04037F36 RID: 229174
			public const int RoleItem = 1;

			// Token: 0x04037F37 RID: 229175
			public const int RoleTexture = 2;

			// Token: 0x04037F38 RID: 229176
			public const int NameText = 3;

			// Token: 0x04037F39 RID: 229177
			public const int ElementItem = 4;

			// Token: 0x04037F3A RID: 229178
			public const int EmptyItem = 5;
		}
	}
}
