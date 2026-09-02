using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.AutoAttach;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x0200566A RID: 22122
	[NullableContext(2)]
	[Nullable(0)]
	public class RogueDungeonDataItem : AutoAttachItem<int>
	{
		// Token: 0x06038624 RID: 230948 RVA: 0x00E468D0 File Offset: 0x00E44AD0
		public RogueDungeonDataItem(AActor uiItem = null) : base(null)
		{
			this.Canvas = (uiItem.GetComponentByClass(ULGUICanvas.StaticClass()) as ULGUICanvas);
		}

		// Token: 0x06038625 RID: 230949 RVA: 0x00E468F4 File Offset: 0x00E44AF4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.SelectedItem))
			};
		}

		// Token: 0x06038626 RID: 230950 RVA: 0x00E46987 File Offset: 0x00E44B87
		protected override void OnStart()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.CanExecuteChange.Bind(new Func<bool>(this.CheckCanClick));
		}

		// Token: 0x06038627 RID: 230951 RVA: 0x00E469AC File Offset: 0x00E44BAC
		public override void OnSelect()
		{
			if (this.OnSelectCall != null && this.Data != 0)
			{
				this.OnSelectCall(this.Data);
			}
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
			}
			this.Canvas.SetSortOrder(1, true);
		}

		// Token: 0x06038628 RID: 230952 RVA: 0x00E469FD File Offset: 0x00E44BFD
		protected override void OnUnSelect()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
			}
			this.Canvas.SetSortOrder(0, true);
		}

		// Token: 0x06038629 RID: 230953 RVA: 0x00E46A22 File Offset: 0x00E44C22
		protected override void OnRefreshItem(int data)
		{
			this.Data = data;
			this.RefreshCover();
			this.RefreshState();
		}

		// Token: 0x0603862A RID: 230954 RVA: 0x00E46A37 File Offset: 0x00E44C37
		protected override void OnMoveItem()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0603862B RID: 230955 RVA: 0x00E46A50 File Offset: 0x00E44C50
		private void RefreshCover()
		{
			if (this.Data == 0)
			{
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_SelectLevelPixEmpty");
				base.SetTextureByPath(resourcePath, base.GetTexture(1), null, null);
				return;
			}
			RogueResDungeonConfig? config = ConfigRogueResDungeonConfigById.GetConfig(this.Data, true);
			if (config == null)
			{
				return;
			}
			string path = (ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Female) ? config.Value.IconF : config.Value.IconM;
			base.SetTextureByPath(path, base.GetTexture(1), null, null);
		}

		// Token: 0x0603862C RID: 230956 RVA: 0x00E46AEC File Offset: 0x00E44CEC
		private void RefreshState()
		{
			if (this.Data == 0)
			{
				base.GetExtendToggle(0).SetSelfInteractive(false);
				UUIItem item = base.GetItem(3);
				if (item != null)
				{
					item.SetUIActive(false);
				}
				UUIItem item2 = base.GetItem(2);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(false);
				return;
			}
			else
			{
				base.GetExtendToggle(0).SetSelfInteractive(true);
				RogueResDungeonConfig? config = ConfigRogueResDungeonConfigById.GetConfig(this.Data, true);
				if (config == null)
				{
					return;
				}
				bool flag = ConfigRogueResThemeById.GetConfig(config.Value.SeasonId, true).Value.Insts().IndexOf(this.Data) == 0;
				ERogueResInstState instDungeonState = ModelBase<ActivityPermanentRogueModel>.Instance.GetInstDungeonState(this.Data);
				UUIItem item3 = base.GetItem(3);
				if (item3 != null)
				{
					item3.SetUIActive(!flag && instDungeonState == ERogueResInstState.Lock);
				}
				UUIItem item4 = base.GetItem(2);
				if (item4 == null)
				{
					return;
				}
				item4.SetUIActive(instDungeonState == ERogueResInstState.Finished);
				return;
			}
		}

		// Token: 0x0603862D RID: 230957 RVA: 0x00E46BD0 File Offset: 0x00E44DD0
		private void SelectedItem(EToggleState toggleState)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
			}
			Action<RogueDungeonDataItem> onToggleClick = this.OnToggleClick;
			if (onToggleClick == null)
			{
				return;
			}
			onToggleClick(this);
		}

		// Token: 0x0603862E RID: 230958 RVA: 0x00E46BF9 File Offset: 0x00E44DF9
		private bool CheckCanClick()
		{
			return this.CheckToggleCanClick == null || this.CheckToggleCanClick(this.Data);
		}

		// Token: 0x0603862F RID: 230959 RVA: 0x00E46C16 File Offset: 0x00E44E16
		public int? GetData()
		{
			return new int?(this.Data);
		}

		// Token: 0x06038630 RID: 230960 RVA: 0x00E46C23 File Offset: 0x00E44E23
		public void UnSelectWhenEnter()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
			}
			this.Canvas.SetSortOrder(0, true);
		}

		// Token: 0x0402027F RID: 131711
		private int Data;

		// Token: 0x04020280 RID: 131712
		private readonly ULGUICanvas Canvas;

		// Token: 0x04020281 RID: 131713
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<RogueDungeonDataItem> OnToggleClick;

		// Token: 0x04020282 RID: 131714
		public Action<int> OnSelectCall;

		// Token: 0x04020283 RID: 131715
		public Func<int, bool> CheckToggleCanClick;

		// Token: 0x04020284 RID: 131716
		public const int SORT_MAX = 1;

		// Token: 0x04020285 RID: 131717
		public const int SORT_EMPTY = 0;
	}
}
